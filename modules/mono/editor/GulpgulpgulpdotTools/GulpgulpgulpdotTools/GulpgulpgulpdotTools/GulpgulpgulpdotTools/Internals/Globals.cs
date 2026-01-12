using Gulpgulpgulpdot;
using Gulpgulpgulpdot.NativeInterop;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace GulpgulpgulpdotTools.Internals
{
    public static class Globals
    {
        public static float EditorScale => Internal.gulpgulpgulpdot_icall_Globals_EditorScale();

        // ReSharper disable once UnusedMethodReturnValue.Global
        public static Variant GlobalDef(string setting, Variant defaultValue, bool restartIfChanged = false)
        {
            using gulpgulpgulpdot_string settingIn = Marshaling.ConvertStringToNative(setting);
            using gulpgulpgulpdot_variant defaultValueIn = defaultValue.CopyNativeVariant();
            Internal.gulpgulpgulpdot_icall_Globals_GlobalDef(settingIn, defaultValueIn, restartIfChanged,
                out gulpgulpgulpdot_variant result);
            return Variant.CreateTakingOwnershipOfDisposableValue(result);
        }

        // ReSharper disable once UnusedMethodReturnValue.Global
        public static Variant EditorDef(string setting, Variant defaultValue, bool restartIfChanged = false)
        {
            using gulpgulpgulpdot_string settingIn = Marshaling.ConvertStringToNative(setting);
            using gulpgulpgulpdot_variant defaultValueIn = defaultValue.CopyNativeVariant();
            Internal.gulpgulpgulpdot_icall_Globals_EditorDef(settingIn, defaultValueIn, restartIfChanged,
                out gulpgulpgulpdot_variant result);
            return Variant.CreateTakingOwnershipOfDisposableValue(result);
        }

        public static Shortcut EditorDefShortcut(string setting, string name, Key keycode = Key.None, bool physical = false)
        {
            using gulpgulpgulpdot_string settingIn = Marshaling.ConvertStringToNative(setting);
            using gulpgulpgulpdot_string nameIn = Marshaling.ConvertStringToNative(name);
            Internal.gulpgulpgulpdot_icall_Globals_EditorDefShortcut(settingIn, nameIn, keycode, physical.ToGulpgulpgulpdotBool(), out gulpgulpgulpdot_variant result);
            return (Shortcut)Variant.CreateTakingOwnershipOfDisposableValue(result);
        }

        public static Shortcut EditorGetShortcut(string setting)
        {
            using gulpgulpgulpdot_string settingIn = Marshaling.ConvertStringToNative(setting);
            Internal.gulpgulpgulpdot_icall_Globals_EditorGetShortcut(settingIn, out gulpgulpgulpdot_variant result);
            return (Shortcut)Variant.CreateTakingOwnershipOfDisposableValue(result);
        }

        public static void EditorShortcutOverride(string setting, string feature, Key keycode = Key.None, bool physical = false)
        {
            using gulpgulpgulpdot_string settingIn = Marshaling.ConvertStringToNative(setting);
            using gulpgulpgulpdot_string featureIn = Marshaling.ConvertStringToNative(feature);
            Internal.gulpgulpgulpdot_icall_Globals_EditorShortcutOverride(settingIn, featureIn, keycode, physical.ToGulpgulpgulpdotBool());
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public static string TTR(this string text)
        {
            using gulpgulpgulpdot_string textIn = Marshaling.ConvertStringToNative(text);
            Internal.gulpgulpgulpdot_icall_Globals_TTR(textIn, out gulpgulpgulpdot_string dest);
            using (dest)
                return Marshaling.ConvertStringToManaged(dest);
        }
    }
}
