using System;
using System.Runtime.InteropServices;
using Gulpgulpgulpdot.NativeInterop;

namespace Gulpgulpgulpdot
{
    public class SignalAwaiter : IAwaiter<Variant[]>, IAwaitable<Variant[]>
    {
        private bool _completed;
        private Variant[] _result;
        private Action _continuation;

        public SignalAwaiter(GulpgulpgulpdotObject source, StringName signal, GulpgulpgulpdotObject target)
        {
            var awaiterGcHandle = CustomGCHandle.AllocStrong(this);
            using gulpgulpgulpdot_string_name signalSrc = NativeFuncs.gulpgulpgulpdotsharp_string_name_new_copy(
                (gulpgulpgulpdot_string_name)(signal?.NativeValue ?? default));
            NativeFuncs.gulpgulpgulpdotsharp_internal_signal_awaiter_connect(GulpgulpgulpdotObject.GetPtr(source), in signalSrc,
                GulpgulpgulpdotObject.GetPtr(target), GCHandle.ToIntPtr(awaiterGcHandle));
        }

        public bool IsCompleted => _completed;

        public void OnCompleted(Action continuation)
        {
            _continuation = continuation;
        }

        public Variant[] GetResult() => _result;

        public IAwaiter<Variant[]> GetAwaiter() => this;

        [UnmanagedCallersOnly]
        internal static unsafe void SignalCallback(IntPtr awaiterGCHandlePtr, gulpgulpgulpdot_variant** args, int argCount,
            gulpgulpgulpdot_bool* outAwaiterIsNull)
        {
            try
            {
                var awaiter = (SignalAwaiter)GCHandle.FromIntPtr(awaiterGCHandlePtr).Target;

                if (awaiter == null)
                {
                    *outAwaiterIsNull = gulpgulpgulpdot_bool.True;
                    return;
                }

                *outAwaiterIsNull = gulpgulpgulpdot_bool.False;

                awaiter._completed = true;

                if (argCount > 0)
                {
                    Variant[] signalArgs = new Variant[argCount];

                    for (int i = 0; i < argCount; i++)
                        signalArgs[i] = Variant.CreateCopyingBorrowed(*args[i]);

                    awaiter._result = signalArgs;
                }
                else
                {
                    awaiter._result = [];
                }

                awaiter._continuation?.Invoke();
            }
            catch (Exception e)
            {
                ExceptionUtils.LogException(e);
                *outAwaiterIsNull = gulpgulpgulpdot_bool.False;
            }
        }
    }
}
