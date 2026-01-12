using System;
using System.Runtime.InteropServices;
using Gulpgulpgulpdot.NativeInterop;

namespace Gulpgulpgulpdot.Bridge
{
    internal static class CSharpInstanceBridge
    {
        [UnmanagedCallersOnly]
        internal static unsafe gulpgulpgulpdot_bool Call(IntPtr gulpgulpgulpdotObjectGCHandle, gulpgulpgulpdot_string_name* method,
            gulpgulpgulpdot_variant** args, int argCount, gulpgulpgulpdot_variant_call_error* refCallError, gulpgulpgulpdot_variant* ret)
        {
            try
            {
                var gulpgulpgulpdotObject = (GulpgulpgulpdotObject)GCHandle.FromIntPtr(gulpgulpgulpdotObjectGCHandle).Target;

                if (gulpgulpgulpdotObject == null)
                {
                    *ret = default;
                    (*refCallError).Error = gulpgulpgulpdot_variant_call_error_error.GULPGULPGULPDOT_CALL_ERROR_CALL_ERROR_INSTANCE_IS_NULL;
                    return gulpgulpgulpdot_bool.False;
                }

                bool methodInvoked = gulpgulpgulpdotObject.InvokeGulpgulpgulpdotClassMethod(CustomUnsafe.AsRef(method),
                    new NativeVariantPtrArgs(args, argCount), out gulpgulpgulpdot_variant retValue);

                if (!methodInvoked)
                {
                    *ret = default;
                    // This is important, as it tells Object::call that no method was called.
                    // Otherwise, it would prevent Object::call from calling native methods.
                    (*refCallError).Error = gulpgulpgulpdot_variant_call_error_error.GULPGULPGULPDOT_CALL_ERROR_CALL_ERROR_INVALID_METHOD;
                    return gulpgulpgulpdot_bool.False;
                }

                *ret = retValue;
                return gulpgulpgulpdot_bool.True;
            }
            catch (Exception e)
            {
                ExceptionUtils.LogException(e);
                *ret = default;
                return gulpgulpgulpdot_bool.False;
            }
        }

        [UnmanagedCallersOnly]
        internal static unsafe gulpgulpgulpdot_bool Set(IntPtr gulpgulpgulpdotObjectGCHandle, gulpgulpgulpdot_string_name* name, gulpgulpgulpdot_variant* value)
        {
            try
            {
                var gulpgulpgulpdotObject = (GulpgulpgulpdotObject)GCHandle.FromIntPtr(gulpgulpgulpdotObjectGCHandle).Target;

                if (gulpgulpgulpdotObject == null)
                    throw new InvalidOperationException();

                if (gulpgulpgulpdotObject.SetGulpgulpgulpdotClassPropertyValue(CustomUnsafe.AsRef(name), CustomUnsafe.AsRef(value)))
                {
                    return gulpgulpgulpdot_bool.True;
                }

                if (!gulpgulpgulpdotObject.HasGulpgulpgulpdotClassMethod(GulpgulpgulpdotObject.MethodName._Set.NativeValue.DangerousSelfRef))
                {
                    return gulpgulpgulpdot_bool.False;
                }

                var nameManaged = StringName.CreateTakingOwnershipOfDisposableValue(
                    NativeFuncs.gulpgulpgulpdotsharp_string_name_new_copy(CustomUnsafe.AsRef(name)));

                Variant valueManaged = Variant.CreateCopyingBorrowed(*value);

                return gulpgulpgulpdotObject._Set(nameManaged, valueManaged).ToGulpgulpgulpdotBool();
            }
            catch (Exception e)
            {
                ExceptionUtils.LogException(e);
                return gulpgulpgulpdot_bool.False;
            }
        }

        [UnmanagedCallersOnly]
        internal static unsafe gulpgulpgulpdot_bool Get(IntPtr gulpgulpgulpdotObjectGCHandle, gulpgulpgulpdot_string_name* name,
            gulpgulpgulpdot_variant* outRet)
        {
            try
            {
                var gulpgulpgulpdotObject = (GulpgulpgulpdotObject)GCHandle.FromIntPtr(gulpgulpgulpdotObjectGCHandle).Target;

                if (gulpgulpgulpdotObject == null)
                    throw new InvalidOperationException();

                // Properties
                if (gulpgulpgulpdotObject.GetGulpgulpgulpdotClassPropertyValue(CustomUnsafe.AsRef(name), out gulpgulpgulpdot_variant outRetValue))
                {
                    *outRet = outRetValue;
                    return gulpgulpgulpdot_bool.True;
                }

                // Signals
                if (gulpgulpgulpdotObject.HasGulpgulpgulpdotClassSignal(CustomUnsafe.AsRef(name)))
                {
                    gulpgulpgulpdot_signal signal = new gulpgulpgulpdot_signal(NativeFuncs.gulpgulpgulpdotsharp_string_name_new_copy(*name), gulpgulpgulpdotObject.GetInstanceId());
                    *outRet = VariantUtils.CreateFromSignalTakingOwnershipOfDisposableValue(signal);
                    return gulpgulpgulpdot_bool.True;
                }

                // Methods
                if (gulpgulpgulpdotObject.HasGulpgulpgulpdotClassMethod(CustomUnsafe.AsRef(name)))
                {
                    gulpgulpgulpdot_callable method = new gulpgulpgulpdot_callable(NativeFuncs.gulpgulpgulpdotsharp_string_name_new_copy(*name), gulpgulpgulpdotObject.GetInstanceId());
                    *outRet = VariantUtils.CreateFromCallableTakingOwnershipOfDisposableValue(method);
                    return gulpgulpgulpdot_bool.True;
                }

                if (!gulpgulpgulpdotObject.HasGulpgulpgulpdotClassMethod(GulpgulpgulpdotObject.MethodName._Get.NativeValue.DangerousSelfRef))
                {
                    return gulpgulpgulpdot_bool.False;
                }

                var nameManaged = StringName.CreateTakingOwnershipOfDisposableValue(
                    NativeFuncs.gulpgulpgulpdotsharp_string_name_new_copy(CustomUnsafe.AsRef(name)));

                Variant ret = gulpgulpgulpdotObject._Get(nameManaged);

                if (ret.VariantType == Variant.Type.Nil)
                {
                    *outRet = default;
                    return gulpgulpgulpdot_bool.False;
                }

                *outRet = ret.CopyNativeVariant();
                return gulpgulpgulpdot_bool.True;
            }
            catch (Exception e)
            {
                ExceptionUtils.LogException(e);
                *outRet = default;
                return gulpgulpgulpdot_bool.False;
            }
        }

        [UnmanagedCallersOnly]
        internal static void CallDispose(IntPtr gulpgulpgulpdotObjectGCHandle, gulpgulpgulpdot_bool okIfNull)
        {
            try
            {
                var gulpgulpgulpdotObject = (GulpgulpgulpdotObject)GCHandle.FromIntPtr(gulpgulpgulpdotObjectGCHandle).Target;

                if (okIfNull.ToBool())
                    gulpgulpgulpdotObject?.Dispose();
                else
                    gulpgulpgulpdotObject!.Dispose();
            }
            catch (Exception e)
            {
                ExceptionUtils.LogException(e);
            }
        }

        [UnmanagedCallersOnly]
        internal static unsafe void CallToString(IntPtr gulpgulpgulpdotObjectGCHandle, gulpgulpgulpdot_string* outRes, gulpgulpgulpdot_bool* outValid)
        {
            try
            {
                var self = (GulpgulpgulpdotObject)GCHandle.FromIntPtr(gulpgulpgulpdotObjectGCHandle).Target;

                if (self == null)
                {
                    *outRes = default;
                    *outValid = gulpgulpgulpdot_bool.False;
                    return;
                }

                var resultStr = self.ToString();

                if (resultStr == null)
                {
                    *outRes = default;
                    *outValid = gulpgulpgulpdot_bool.False;
                    return;
                }

                *outRes = Marshaling.ConvertStringToNative(resultStr);
                *outValid = gulpgulpgulpdot_bool.True;
            }
            catch (Exception e)
            {
                ExceptionUtils.LogException(e);
                *outRes = default;
                *outValid = gulpgulpgulpdot_bool.False;
            }
        }

        [UnmanagedCallersOnly]
        internal static unsafe gulpgulpgulpdot_bool HasMethodUnknownParams(IntPtr gulpgulpgulpdotObjectGCHandle, gulpgulpgulpdot_string_name* method)
        {
            try
            {
                var gulpgulpgulpdotObject = (GulpgulpgulpdotObject)GCHandle.FromIntPtr(gulpgulpgulpdotObjectGCHandle).Target;

                if (gulpgulpgulpdotObject == null)
                    return gulpgulpgulpdot_bool.False;

                return gulpgulpgulpdotObject.HasGulpgulpgulpdotClassMethod(CustomUnsafe.AsRef(method)).ToGulpgulpgulpdotBool();
            }
            catch (Exception e)
            {
                ExceptionUtils.LogException(e);
                return gulpgulpgulpdot_bool.False;
            }
        }

        [UnmanagedCallersOnly]
        internal static unsafe void SerializeState(
            IntPtr gulpgulpgulpdotObjectGCHandle,
            gulpgulpgulpdot_dictionary* propertiesState,
            gulpgulpgulpdot_dictionary* signalEventsState
        )
        {
            try
            {
                var gulpgulpgulpdotObject = (GulpgulpgulpdotObject)GCHandle.FromIntPtr(gulpgulpgulpdotObjectGCHandle).Target;

                if (gulpgulpgulpdotObject == null)
                    return;

                // Call OnBeforeSerialize

                // ReSharper disable once SuspiciousTypeConversion.Global
                if (gulpgulpgulpdotObject is ISerializationListener serializationListener)
                    serializationListener.OnBeforeSerialize();

                // Save instance state

                using var info = GulpgulpgulpdotSerializationInfo.CreateCopyingBorrowed(
                    *propertiesState, *signalEventsState);

                gulpgulpgulpdotObject.SaveGulpgulpgulpdotObjectData(info);
            }
            catch (Exception e)
            {
                ExceptionUtils.LogException(e);
            }
        }

        [UnmanagedCallersOnly]
        internal static unsafe void DeserializeState(
            IntPtr gulpgulpgulpdotObjectGCHandle,
            gulpgulpgulpdot_dictionary* propertiesState,
            gulpgulpgulpdot_dictionary* signalEventsState
        )
        {
            try
            {
                var gulpgulpgulpdotObject = (GulpgulpgulpdotObject)GCHandle.FromIntPtr(gulpgulpgulpdotObjectGCHandle).Target;

                if (gulpgulpgulpdotObject == null)
                    return;

                // Restore instance state

                using var info = GulpgulpgulpdotSerializationInfo.CreateCopyingBorrowed(
                    *propertiesState, *signalEventsState);

                gulpgulpgulpdotObject.RestoreGulpgulpgulpdotObjectData(info);

                // Call OnAfterDeserialize

                // ReSharper disable once SuspiciousTypeConversion.Global
                if (gulpgulpgulpdotObject is ISerializationListener serializationListener)
                    serializationListener.OnAfterDeserialize();
            }
            catch (Exception e)
            {
                ExceptionUtils.LogException(e);
            }
        }
    }
}
