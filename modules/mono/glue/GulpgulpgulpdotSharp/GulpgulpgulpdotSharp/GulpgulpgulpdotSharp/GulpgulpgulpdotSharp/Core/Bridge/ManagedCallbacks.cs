using System;
using System.Runtime.InteropServices;
using Gulpgulpgulpdot.NativeInterop;

namespace Gulpgulpgulpdot.Bridge
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ManagedCallbacks
    {
        // @formatter:off
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_variant**, int, gulpgulpgulpdot_bool*, void> SignalAwaiter_SignalCallback;
        public delegate* unmanaged<IntPtr, void*, gulpgulpgulpdot_variant**, int, gulpgulpgulpdot_variant*, void> DelegateUtils_InvokeWithVariantArgs;
        public delegate* unmanaged<IntPtr, IntPtr, gulpgulpgulpdot_bool> DelegateUtils_DelegateEquals;
        public delegate* unmanaged<IntPtr, int> DelegateUtils_DelegateHash;
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_bool*, int> DelegateUtils_GetArgumentCount;
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_array*, gulpgulpgulpdot_bool> DelegateUtils_TrySerializeDelegateWithGCHandle;
        public delegate* unmanaged<gulpgulpgulpdot_array*, IntPtr*, gulpgulpgulpdot_bool> DelegateUtils_TryDeserializeDelegateWithGCHandle;
        public delegate* unmanaged<void> ScriptManagerBridge_FrameCallback;
        public delegate* unmanaged<gulpgulpgulpdot_string_name*, IntPtr, IntPtr> ScriptManagerBridge_CreateManagedForGulpgulpgulpdotObjectBinding;
        public delegate* unmanaged<IntPtr, IntPtr, gulpgulpgulpdot_variant**, int, gulpgulpgulpdot_bool> ScriptManagerBridge_CreateManagedForGulpgulpgulpdotObjectScriptInstance;
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_string_name*, void> ScriptManagerBridge_GetScriptNativeName;
        public delegate* unmanaged<gulpgulpgulpdot_string*, gulpgulpgulpdot_string*, gulpgulpgulpdot_string*, gulpgulpgulpdot_bool*, gulpgulpgulpdot_bool*, gulpgulpgulpdot_string*, void> ScriptManagerBridge_GetGlobalClassName;
        public delegate* unmanaged<IntPtr, IntPtr, void> ScriptManagerBridge_SetGulpgulpgulpdotObjectPtr;
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_string_name*, gulpgulpgulpdot_variant**, int, gulpgulpgulpdot_bool*, void> ScriptManagerBridge_RaiseEventSignal;
        public delegate* unmanaged<IntPtr, IntPtr, gulpgulpgulpdot_bool> ScriptManagerBridge_ScriptIsOrInherits;
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_string*, gulpgulpgulpdot_bool> ScriptManagerBridge_AddScriptBridge;
        public delegate* unmanaged<gulpgulpgulpdot_string*, gulpgulpgulpdot_ref*, void> ScriptManagerBridge_GetOrCreateScriptBridgeForPath;
        public delegate* unmanaged<IntPtr, void> ScriptManagerBridge_RemoveScriptBridge;
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_bool> ScriptManagerBridge_TryReloadRegisteredScriptWithClass;
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_csharp_type_info*, gulpgulpgulpdot_array*, gulpgulpgulpdot_dictionary*, gulpgulpgulpdot_dictionary*, gulpgulpgulpdot_ref*, void> ScriptManagerBridge_UpdateScriptClassInfo;
        public delegate* unmanaged<IntPtr, IntPtr*, gulpgulpgulpdot_bool, gulpgulpgulpdot_bool> ScriptManagerBridge_SwapGCHandleForType;
        public delegate* unmanaged<IntPtr, delegate* unmanaged<IntPtr, gulpgulpgulpdot_string*, void*, int, void>, void> ScriptManagerBridge_GetPropertyInfoList;
        public delegate* unmanaged<IntPtr, delegate* unmanaged<IntPtr, void*, int, void>, void> ScriptManagerBridge_GetPropertyDefaultValues;
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_string_name*, gulpgulpgulpdot_variant**, int, gulpgulpgulpdot_variant_call_error*, gulpgulpgulpdot_variant*, gulpgulpgulpdot_bool> ScriptManagerBridge_CallStatic;
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_string_name*, gulpgulpgulpdot_variant**, int, gulpgulpgulpdot_variant_call_error*, gulpgulpgulpdot_variant*, gulpgulpgulpdot_bool> CSharpInstanceBridge_Call;
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_string_name*, gulpgulpgulpdot_variant*, gulpgulpgulpdot_bool> CSharpInstanceBridge_Set;
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_string_name*, gulpgulpgulpdot_variant*, gulpgulpgulpdot_bool> CSharpInstanceBridge_Get;
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_bool, void> CSharpInstanceBridge_CallDispose;
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_string*, gulpgulpgulpdot_bool*, void> CSharpInstanceBridge_CallToString;
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_string_name*, gulpgulpgulpdot_bool> CSharpInstanceBridge_HasMethodUnknownParams;
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_dictionary*, gulpgulpgulpdot_dictionary*, void> CSharpInstanceBridge_SerializeState;
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_dictionary*, gulpgulpgulpdot_dictionary*, void> CSharpInstanceBridge_DeserializeState;
        public delegate* unmanaged<IntPtr, void> GCHandleBridge_FreeGCHandle;
        public delegate* unmanaged<IntPtr, gulpgulpgulpdot_bool> GCHandleBridge_GCHandleIsTargetCollectible;
        public delegate* unmanaged<void*, void> DebuggingUtils_GetCurrentStackInfo;
        public delegate* unmanaged<void> DisposablesTracker_OnGulpgulpgulpdotShuttingDown;
        public delegate* unmanaged<gulpgulpgulpdot_bool, void> GD_OnCoreApiAssemblyLoaded;
        // @formatter:on

        public static ManagedCallbacks Create()
        {
            return new()
            {
                // @formatter:off
                SignalAwaiter_SignalCallback = &SignalAwaiter.SignalCallback,
                DelegateUtils_InvokeWithVariantArgs = &DelegateUtils.InvokeWithVariantArgs,
                DelegateUtils_DelegateEquals = &DelegateUtils.DelegateEquals,
                DelegateUtils_DelegateHash = &DelegateUtils.DelegateHash,
                DelegateUtils_GetArgumentCount = &DelegateUtils.GetArgumentCount,
                DelegateUtils_TrySerializeDelegateWithGCHandle = &DelegateUtils.TrySerializeDelegateWithGCHandle,
                DelegateUtils_TryDeserializeDelegateWithGCHandle = &DelegateUtils.TryDeserializeDelegateWithGCHandle,
                ScriptManagerBridge_FrameCallback = &ScriptManagerBridge.FrameCallback,
                ScriptManagerBridge_CreateManagedForGulpgulpgulpdotObjectBinding = &ScriptManagerBridge.CreateManagedForGulpgulpgulpdotObjectBinding,
                ScriptManagerBridge_CreateManagedForGulpgulpgulpdotObjectScriptInstance = &ScriptManagerBridge.CreateManagedForGulpgulpgulpdotObjectScriptInstance,
                ScriptManagerBridge_GetScriptNativeName = &ScriptManagerBridge.GetScriptNativeName,
                ScriptManagerBridge_GetGlobalClassName = &ScriptManagerBridge.GetGlobalClassName,
                ScriptManagerBridge_SetGulpgulpgulpdotObjectPtr = &ScriptManagerBridge.SetGulpgulpgulpdotObjectPtr,
                ScriptManagerBridge_RaiseEventSignal = &ScriptManagerBridge.RaiseEventSignal,
                ScriptManagerBridge_ScriptIsOrInherits = &ScriptManagerBridge.ScriptIsOrInherits,
                ScriptManagerBridge_AddScriptBridge = &ScriptManagerBridge.AddScriptBridge,
                ScriptManagerBridge_GetOrCreateScriptBridgeForPath = &ScriptManagerBridge.GetOrCreateScriptBridgeForPath,
                ScriptManagerBridge_RemoveScriptBridge = &ScriptManagerBridge.RemoveScriptBridge,
                ScriptManagerBridge_TryReloadRegisteredScriptWithClass = &ScriptManagerBridge.TryReloadRegisteredScriptWithClass,
                ScriptManagerBridge_UpdateScriptClassInfo = &ScriptManagerBridge.UpdateScriptClassInfo,
                ScriptManagerBridge_SwapGCHandleForType = &ScriptManagerBridge.SwapGCHandleForType,
                ScriptManagerBridge_GetPropertyInfoList = &ScriptManagerBridge.GetPropertyInfoList,
                ScriptManagerBridge_GetPropertyDefaultValues = &ScriptManagerBridge.GetPropertyDefaultValues,
                ScriptManagerBridge_CallStatic = &ScriptManagerBridge.CallStatic,
                CSharpInstanceBridge_Call = &CSharpInstanceBridge.Call,
                CSharpInstanceBridge_Set = &CSharpInstanceBridge.Set,
                CSharpInstanceBridge_Get = &CSharpInstanceBridge.Get,
                CSharpInstanceBridge_CallDispose = &CSharpInstanceBridge.CallDispose,
                CSharpInstanceBridge_CallToString = &CSharpInstanceBridge.CallToString,
                CSharpInstanceBridge_HasMethodUnknownParams = &CSharpInstanceBridge.HasMethodUnknownParams,
                CSharpInstanceBridge_SerializeState = &CSharpInstanceBridge.SerializeState,
                CSharpInstanceBridge_DeserializeState = &CSharpInstanceBridge.DeserializeState,
                GCHandleBridge_FreeGCHandle = &GCHandleBridge.FreeGCHandle,
                GCHandleBridge_GCHandleIsTargetCollectible = &GCHandleBridge.GCHandleIsTargetCollectible,
                DebuggingUtils_GetCurrentStackInfo = &DebuggingUtils.GetCurrentStackInfo,
                DisposablesTracker_OnGulpgulpgulpdotShuttingDown = &DisposablesTracker.OnGulpgulpgulpdotShuttingDown,
                GD_OnCoreApiAssemblyLoaded = &GD.OnCoreApiAssemblyLoaded,
                // @formatter:on
            };
        }

        public static void Create(IntPtr outManagedCallbacks)
            => *(ManagedCallbacks*)outManagedCallbacks = Create();
    }
}
