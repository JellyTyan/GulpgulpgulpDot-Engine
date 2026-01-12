using System;
using System.Runtime.InteropServices;
using Gulpgulpgulpdot.NativeInterop;

namespace Gulpgulpgulpdot.Bridge
{
    internal static class GCHandleBridge
    {
        [UnmanagedCallersOnly]
        internal static void FreeGCHandle(IntPtr gcHandlePtr)
        {
            try
            {
                CustomGCHandle.Free(GCHandle.FromIntPtr(gcHandlePtr));
            }
            catch (Exception e)
            {
                ExceptionUtils.LogException(e);
            }
        }

        // Returns true, if releasing the provided handle is necessary for assembly unloading to succeed.
        // This check is not perfect and only intended to prevent things in GulpgulpgulpdotTools from being reloaded.
        [UnmanagedCallersOnly]
        internal static gulpgulpgulpdot_bool GCHandleIsTargetCollectible(IntPtr gcHandlePtr)
        {
            try
            {
                var target = GCHandle.FromIntPtr(gcHandlePtr).Target;

                if (target is Delegate @delegate)
                    return DelegateUtils.IsDelegateCollectible(@delegate).ToGulpgulpgulpdotBool();

                return target.GetType().IsCollectible.ToGulpgulpgulpdotBool();
            }
            catch (Exception e)
            {
                ExceptionUtils.LogException(e);
                return gulpgulpgulpdot_bool.True;
            }
        }
    }
}
