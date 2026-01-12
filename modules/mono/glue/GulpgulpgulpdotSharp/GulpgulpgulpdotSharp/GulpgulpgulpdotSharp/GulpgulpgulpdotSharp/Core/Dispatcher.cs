using System;
using System.Runtime.InteropServices;
using Gulpgulpgulpdot.NativeInterop;

namespace Gulpgulpgulpdot
{
    public static class Dispatcher
    {
        internal static GulpgulpgulpdotTaskScheduler DefaultGulpgulpgulpdotTaskScheduler;

        internal static void InitializeDefaultGulpgulpgulpdotTaskScheduler()
        {
            DefaultGulpgulpgulpdotTaskScheduler?.Dispose();
            DefaultGulpgulpgulpdotTaskScheduler = new GulpgulpgulpdotTaskScheduler();
        }

        public static GulpgulpgulpdotSynchronizationContext SynchronizationContext => DefaultGulpgulpgulpdotTaskScheduler.Context;
    }
}
