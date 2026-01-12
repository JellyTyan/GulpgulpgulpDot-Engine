using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using Gulpgulpgulpdot.NativeInterop;

#nullable enable

namespace Gulpgulpgulpdot
{
    internal static class DisposablesTracker
    {
        [UnmanagedCallersOnly]
        internal static void OnGulpgulpgulpdotShuttingDown()
        {
            try
            {
                OnGulpgulpgulpdotShuttingDownImpl();
            }
            catch (Exception e)
            {
                ExceptionUtils.LogException(e);
            }
        }

        private static void OnGulpgulpgulpdotShuttingDownImpl()
        {
            bool isStdoutVerbose;

            try
            {
                isStdoutVerbose = OS.IsStdOutVerbose();
            }
            catch (ObjectDisposedException)
            {
                // OS singleton already disposed. Maybe OnUnloading was called twice.
                isStdoutVerbose = false;
            }

            if (isStdoutVerbose)
                GD.Print("Unloading: Disposing tracked instances...");

            // Dispose Gulpgulpgulpdot Objects first, and only then dispose other disposables
            // like StringName, NodePath, Gulpgulpgulpdot.Collections.Array/Dictionary, etc.
            // The Gulpgulpgulpdot Object Dispose() method may need any of the later instances.

            foreach (WeakReference<GulpgulpgulpdotObject> item in GulpgulpgulpdotObjectInstances.Keys)
            {
                if (item.TryGetTarget(out GulpgulpgulpdotObject? self))
                    self.Dispose();
            }

            foreach (WeakReference<IDisposable> item in OtherInstances.Keys)
            {
                if (item.TryGetTarget(out IDisposable? self))
                    self.Dispose();
            }

            if (isStdoutVerbose)
                GD.Print("Unloading: Finished disposing tracked instances.");
        }

        private static ConcurrentDictionary<WeakReference<GulpgulpgulpdotObject>, byte> GulpgulpgulpdotObjectInstances { get; } =
            new();

        private static ConcurrentDictionary<WeakReference<IDisposable>, byte> OtherInstances { get; } =
            new();

        public static WeakReference<GulpgulpgulpdotObject> RegisterGulpgulpgulpdotObject(GulpgulpgulpdotObject gulpgulpgulpdotObject)
        {
            var weakReferenceToSelf = new WeakReference<GulpgulpgulpdotObject>(gulpgulpgulpdotObject);
            GulpgulpgulpdotObjectInstances.TryAdd(weakReferenceToSelf, 0);
            return weakReferenceToSelf;
        }

        public static WeakReference<IDisposable> RegisterDisposable(IDisposable disposable)
        {
            var weakReferenceToSelf = new WeakReference<IDisposable>(disposable);
            OtherInstances.TryAdd(weakReferenceToSelf, 0);
            return weakReferenceToSelf;
        }

        public static void UnregisterGulpgulpgulpdotObject(GulpgulpgulpdotObject gulpgulpgulpdotObject, WeakReference<GulpgulpgulpdotObject> weakReferenceToSelf)
        {
            if (!GulpgulpgulpdotObjectInstances.TryRemove(weakReferenceToSelf, out _))
                throw new ArgumentException("Gulpgulpgulpdot Object not registered.", nameof(weakReferenceToSelf));
        }

        public static void UnregisterDisposable(WeakReference<IDisposable> weakReference)
        {
            if (!OtherInstances.TryRemove(weakReference, out _))
                throw new ArgumentException("Disposable not registered.", nameof(weakReference));
        }
    }
}
