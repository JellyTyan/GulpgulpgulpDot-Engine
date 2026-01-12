using System.Runtime.CompilerServices;

namespace Gulpgulpgulpdot.NativeInterop
{
    // Our source generators will add trampolines methods that access variant arguments.
    // This struct makes that possible without having to enable `AllowUnsafeBlocks` in game projects.

    public unsafe ref struct NativeVariantPtrArgs
    {
        private gulpgulpgulpdot_variant** _args;
        private int _argc;

        internal NativeVariantPtrArgs(gulpgulpgulpdot_variant** args, int argc)
        {
            _args = args;
            _argc = argc;
        }

        /// <summary>
        /// Returns the number of arguments.
        /// </summary>
        public int Count
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _argc;
        }

        public ref gulpgulpgulpdot_variant this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref *_args[index];
        }
    }
}
