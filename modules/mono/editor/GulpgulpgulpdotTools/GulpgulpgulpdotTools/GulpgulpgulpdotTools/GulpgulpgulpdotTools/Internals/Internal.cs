#pragma warning disable IDE1006 // Naming rule violation
// ReSharper disable InconsistentNaming

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Gulpgulpgulpdot;
using Gulpgulpgulpdot.NativeInterop;
using Gulpgulpgulpdot.SourceGenerators.Internal;
using GulpgulpgulpdotTools.IdeMessaging.Requests;

namespace GulpgulpgulpdotTools.Internals
{
    [GenerateUnmanagedCallbacks(typeof(InternalUnmanagedCallbacks))]
    internal static partial class Internal
    {
        public const string CSharpLanguageType = "CSharpScript";
        public const string CSharpLanguageExtension = ".cs";

        public static string FullExportTemplatesDir
        {
            get
            {
                gulpgulpgulpdot_icall_Internal_FullExportTemplatesDir(out gulpgulpgulpdot_string dest);
                using (dest)
                    return Marshaling.ConvertStringToManaged(dest);
            }
        }

        public static string SimplifyGulpgulpgulpdotPath(this string path) => Gulpgulpgulpdot.StringExtensions.SimplifyPath(path);

        public static bool IsMacOSAppBundleInstalled(string bundleId)
        {
            using gulpgulpgulpdot_string bundleIdIn = Marshaling.ConvertStringToNative(bundleId);
            return gulpgulpgulpdot_icall_Internal_IsMacOSAppBundleInstalled(bundleIdIn);
        }

        public static bool LipOCreateFile(string outputPath, string[] files)
        {
            using gulpgulpgulpdot_string outputPathIn = Marshaling.ConvertStringToNative(outputPath);
            using gulpgulpgulpdot_packed_string_array filesIn = Marshaling.ConvertSystemArrayToNativePackedStringArray(files);
            return gulpgulpgulpdot_icall_Internal_LipOCreateFile(outputPathIn, filesIn);
        }

        public static bool GulpgulpgulpdotIs32Bits() => gulpgulpgulpdot_icall_Internal_GulpgulpgulpdotIs32Bits();

        public static bool GulpgulpgulpdotIsRealTDouble() => gulpgulpgulpdot_icall_Internal_GulpgulpgulpdotIsRealTDouble();

        public static void GulpgulpgulpdotMainIteration() => gulpgulpgulpdot_icall_Internal_GulpgulpgulpdotMainIteration();

        public static bool IsAssembliesReloadingNeeded() => gulpgulpgulpdot_icall_Internal_IsAssembliesReloadingNeeded();

        public static void ReloadAssemblies(bool softReload) => gulpgulpgulpdot_icall_Internal_ReloadAssemblies(softReload);

        public static void EditorDebuggerNodeReloadScripts() => gulpgulpgulpdot_icall_Internal_EditorDebuggerNodeReloadScripts();

        public static bool ScriptEditorEdit(Resource resource, int line, int col, bool grabFocus = true) =>
            gulpgulpgulpdot_icall_Internal_ScriptEditorEdit(resource.NativeInstance, line, col, grabFocus);

        public static void EditorNodeShowScriptScreen() => gulpgulpgulpdot_icall_Internal_EditorNodeShowScriptScreen();

        public static void EditorRunPlay() => gulpgulpgulpdot_icall_Internal_EditorRunPlay();

        public static void EditorRunStop() => gulpgulpgulpdot_icall_Internal_EditorRunStop();

        public static void EditorPlugin_AddControlToEditorRunBar(Control control) =>
            gulpgulpgulpdot_icall_Internal_EditorPlugin_AddControlToEditorRunBar(control.NativeInstance);

        public static void ScriptEditorDebugger_ReloadScripts() =>
            gulpgulpgulpdot_icall_Internal_ScriptEditorDebugger_ReloadScripts();

        public static string[] CodeCompletionRequest(CodeCompletionRequest.CompletionKind kind,
            string scriptFile)
        {
            using gulpgulpgulpdot_string scriptFileIn = Marshaling.ConvertStringToNative(scriptFile);
            gulpgulpgulpdot_icall_Internal_CodeCompletionRequest((int)kind, scriptFileIn, out gulpgulpgulpdot_packed_string_array res);
            using (res)
                return Marshaling.ConvertNativePackedStringArrayToSystemArray(res);
        }

        #region Internal

        private static bool initialized = false;

        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Global
        internal static unsafe void Initialize(IntPtr unmanagedCallbacks, int unmanagedCallbacksSize)
        {
            if (initialized)
                throw new InvalidOperationException("Already initialized.");
            initialized = true;

            if (unmanagedCallbacksSize != sizeof(InternalUnmanagedCallbacks))
                throw new ArgumentException("Unmanaged callbacks size mismatch.", nameof(unmanagedCallbacksSize));

            _unmanagedCallbacks = Unsafe.AsRef<InternalUnmanagedCallbacks>((void*)unmanagedCallbacks);
        }

        private partial struct InternalUnmanagedCallbacks
        {
        }

        /*
         * IMPORTANT:
         * The order of the methods defined in NativeFuncs must match the order
         * in the array defined at the bottom of 'editor/editor_internal_calls.cpp'.
         */

        public static partial void gulpgulpgulpdot_icall_GulpgulpgulpdotSharpDirs_ResMetadataDir(out gulpgulpgulpdot_string r_dest);

        public static partial void gulpgulpgulpdot_icall_GulpgulpgulpdotSharpDirs_MonoUserDir(out gulpgulpgulpdot_string r_dest);

        public static partial void gulpgulpgulpdot_icall_GulpgulpgulpdotSharpDirs_BuildLogsDirs(out gulpgulpgulpdot_string r_dest);

        public static partial void gulpgulpgulpdot_icall_GulpgulpgulpdotSharpDirs_DataEditorToolsDir(out gulpgulpgulpdot_string r_dest);

        public static partial void gulpgulpgulpdot_icall_GulpgulpgulpdotSharpDirs_CSharpProjectName(out gulpgulpgulpdot_string r_dest);

        public static partial void gulpgulpgulpdot_icall_EditorProgress_Create(in gulpgulpgulpdot_string task, in gulpgulpgulpdot_string label,
            int amount, bool canCancel);

        public static partial void gulpgulpgulpdot_icall_EditorProgress_Dispose(in gulpgulpgulpdot_string task);

        public static partial bool gulpgulpgulpdot_icall_EditorProgress_Step(in gulpgulpgulpdot_string task, in gulpgulpgulpdot_string state,
            int step,
            bool forceRefresh);

        private static partial void gulpgulpgulpdot_icall_Internal_FullExportTemplatesDir(out gulpgulpgulpdot_string dest);

        private static partial bool gulpgulpgulpdot_icall_Internal_IsMacOSAppBundleInstalled(in gulpgulpgulpdot_string bundleId);

        private static partial bool gulpgulpgulpdot_icall_Internal_LipOCreateFile(in gulpgulpgulpdot_string outputPath, in gulpgulpgulpdot_packed_string_array files);

        private static partial bool gulpgulpgulpdot_icall_Internal_GulpgulpgulpdotIs32Bits();

        private static partial bool gulpgulpgulpdot_icall_Internal_GulpgulpgulpdotIsRealTDouble();

        private static partial void gulpgulpgulpdot_icall_Internal_GulpgulpgulpdotMainIteration();

        private static partial bool gulpgulpgulpdot_icall_Internal_IsAssembliesReloadingNeeded();

        private static partial void gulpgulpgulpdot_icall_Internal_ReloadAssemblies(bool softReload);

        private static partial void gulpgulpgulpdot_icall_Internal_EditorDebuggerNodeReloadScripts();

        private static partial bool gulpgulpgulpdot_icall_Internal_ScriptEditorEdit(IntPtr resource, int line, int col,
            bool grabFocus);

        private static partial void gulpgulpgulpdot_icall_Internal_EditorNodeShowScriptScreen();

        private static partial void gulpgulpgulpdot_icall_Internal_EditorRunPlay();

        private static partial void gulpgulpgulpdot_icall_Internal_EditorRunStop();

        private static partial void gulpgulpgulpdot_icall_Internal_EditorPlugin_AddControlToEditorRunBar(IntPtr p_control);

        private static partial void gulpgulpgulpdot_icall_Internal_ScriptEditorDebugger_ReloadScripts();

        private static partial void gulpgulpgulpdot_icall_Internal_CodeCompletionRequest(int kind, in gulpgulpgulpdot_string scriptFile,
            out gulpgulpgulpdot_packed_string_array res);

        public static partial float gulpgulpgulpdot_icall_Globals_EditorScale();

        public static partial void gulpgulpgulpdot_icall_Globals_GlobalDef(in gulpgulpgulpdot_string setting, in gulpgulpgulpdot_variant defaultValue,
            bool restartIfChanged, out gulpgulpgulpdot_variant result);

        public static partial void gulpgulpgulpdot_icall_Globals_EditorDef(in gulpgulpgulpdot_string setting, in gulpgulpgulpdot_variant defaultValue,
            bool restartIfChanged, out gulpgulpgulpdot_variant result);

        public static partial void
            gulpgulpgulpdot_icall_Globals_EditorDefShortcut(in gulpgulpgulpdot_string setting, in gulpgulpgulpdot_string name, Key keycode, gulpgulpgulpdot_bool physical, out gulpgulpgulpdot_variant result);

        public static partial void
            gulpgulpgulpdot_icall_Globals_EditorGetShortcut(in gulpgulpgulpdot_string setting, out gulpgulpgulpdot_variant result);

        public static partial void
            gulpgulpgulpdot_icall_Globals_EditorShortcutOverride(in gulpgulpgulpdot_string setting, in gulpgulpgulpdot_string feature, Key keycode, gulpgulpgulpdot_bool physical);

        public static partial void gulpgulpgulpdot_icall_Globals_TTR(in gulpgulpgulpdot_string text, out gulpgulpgulpdot_string dest);

        public static partial void gulpgulpgulpdot_icall_Utils_OS_GetPlatformName(out gulpgulpgulpdot_string dest);

        public static partial bool gulpgulpgulpdot_icall_Utils_OS_UnixFileHasExecutableAccess(in gulpgulpgulpdot_string filePath);

        #endregion
    }
}
