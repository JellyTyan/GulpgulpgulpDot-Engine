using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Gulpgulpgulpdot.SourceGenerators
{
    [Generator]
    public class GulpgulpgulpdotPluginsInitializerGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.IsGulpgulpgulpdotToolsProject() || context.IsGulpgulpgulpdotSourceGeneratorDisabled("GulpgulpgulpdotPluginsInitializer"))
                return;

            string source =
                @"using System;
using System.Runtime.InteropServices;
using Gulpgulpgulpdot.Bridge;
using Gulpgulpgulpdot.NativeInterop;

namespace GulpgulpgulpdotPlugins.Game
{
    internal static partial class Main
    {
        [UnmanagedCallersOnly(EntryPoint = ""gulpgulpgulpdotsharp_game_main_init"")]
        private static gulpgulpgulpdot_bool InitializeFromGameProject(IntPtr gulpgulpgulpdotDllHandle, IntPtr outManagedCallbacks,
            IntPtr unmanagedCallbacks, int unmanagedCallbacksSize)
        {
            try
            {
                DllImportResolver dllImportResolver = new GulpgulpgulpdotDllImportResolver(gulpgulpgulpdotDllHandle).OnResolveDllImport;

                var coreApiAssembly = typeof(global::Gulpgulpgulpdot.GulpgulpgulpdotObject).Assembly;

                NativeLibrary.SetDllImportResolver(coreApiAssembly, dllImportResolver);

                NativeFuncs.Initialize(unmanagedCallbacks, unmanagedCallbacksSize);

                ManagedCallbacks.Create(outManagedCallbacks);

                ScriptManagerBridge.LookupScriptsInAssembly(typeof(global::GulpgulpgulpdotPlugins.Game.Main).Assembly);

                return gulpgulpgulpdot_bool.True;
            }
            catch (Exception e)
            {
                global::System.Console.Error.WriteLine(e);
                return false.ToGulpgulpgulpdotBool();
            }
        }
    }
}
";

            context.AddSource("GulpgulpgulpdotPlugins.Game.generated",
                SourceText.From(source, Encoding.UTF8));
        }
    }
}
