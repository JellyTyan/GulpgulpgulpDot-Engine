using System;
using System.Runtime.InteropServices;
using Gulpgulpgulpdot.NativeInterop;

namespace Gulpgulpgulpdot
{
    public static partial class GD
    {
        [UnmanagedCallersOnly]
        internal static void OnCoreApiAssemblyLoaded(gulpgulpgulpdot_bool isDebug)
        {
            try
            {
                Dispatcher.InitializeDefaultGulpgulpgulpdotTaskScheduler();

                if (isDebug.ToBool())
                {
                    DebuggingUtils.InstallTraceListener();

                    AppDomain.CurrentDomain.UnhandledException += (_, e) =>
                    {
                        // Exception.ToString() includes the inner exception
                        ExceptionUtils.LogUnhandledException((Exception)e.ExceptionObject);
                    };
                }
            }
            catch (Exception e)
            {
                ExceptionUtils.LogException(e);
            }
        }
    }
}
