using System.Runtime.CompilerServices;

namespace Gulpgulpgulpdot.NativeInterop;

// Ref structs are not allowed as generic type parameters, so we can't use Unsafe.AsPointer<T>/AsRef<T>.
// As a workaround we create our own overloads for our structs with some tricks under the hood.

public static class CustomUnsafe
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_ref* AsPointer(ref gulpgulpgulpdot_ref value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_ref* ReadOnlyRefAsPointer(in gulpgulpgulpdot_ref value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_ref AsRef(gulpgulpgulpdot_ref* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_ref AsRef(in gulpgulpgulpdot_ref source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_variant_call_error* AsPointer(ref gulpgulpgulpdot_variant_call_error value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_variant_call_error* ReadOnlyRefAsPointer(in gulpgulpgulpdot_variant_call_error value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_variant_call_error AsRef(gulpgulpgulpdot_variant_call_error* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_variant_call_error AsRef(in gulpgulpgulpdot_variant_call_error source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_variant* AsPointer(ref gulpgulpgulpdot_variant value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_variant* ReadOnlyRefAsPointer(in gulpgulpgulpdot_variant value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_variant AsRef(gulpgulpgulpdot_variant* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_variant AsRef(in gulpgulpgulpdot_variant source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_string* AsPointer(ref gulpgulpgulpdot_string value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_string* ReadOnlyRefAsPointer(in gulpgulpgulpdot_string value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_string AsRef(gulpgulpgulpdot_string* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_string AsRef(in gulpgulpgulpdot_string source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_string_name* AsPointer(ref gulpgulpgulpdot_string_name value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_string_name* ReadOnlyRefAsPointer(in gulpgulpgulpdot_string_name value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_string_name AsRef(gulpgulpgulpdot_string_name* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_string_name AsRef(in gulpgulpgulpdot_string_name source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_node_path* AsPointer(ref gulpgulpgulpdot_node_path value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_node_path* ReadOnlyRefAsPointer(in gulpgulpgulpdot_node_path value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_node_path AsRef(gulpgulpgulpdot_node_path* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_node_path AsRef(in gulpgulpgulpdot_node_path source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_signal* AsPointer(ref gulpgulpgulpdot_signal value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_signal* ReadOnlyRefAsPointer(in gulpgulpgulpdot_signal value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_signal AsRef(gulpgulpgulpdot_signal* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_signal AsRef(in gulpgulpgulpdot_signal source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_callable* AsPointer(ref gulpgulpgulpdot_callable value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_callable* ReadOnlyRefAsPointer(in gulpgulpgulpdot_callable value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_callable AsRef(gulpgulpgulpdot_callable* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_callable AsRef(in gulpgulpgulpdot_callable source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_array* AsPointer(ref gulpgulpgulpdot_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_array* ReadOnlyRefAsPointer(in gulpgulpgulpdot_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_array AsRef(gulpgulpgulpdot_array* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_array AsRef(in gulpgulpgulpdot_array source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_dictionary* AsPointer(ref gulpgulpgulpdot_dictionary value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_dictionary* ReadOnlyRefAsPointer(in gulpgulpgulpdot_dictionary value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_dictionary AsRef(gulpgulpgulpdot_dictionary* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_dictionary AsRef(in gulpgulpgulpdot_dictionary source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_byte_array* AsPointer(ref gulpgulpgulpdot_packed_byte_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_byte_array* ReadOnlyRefAsPointer(in gulpgulpgulpdot_packed_byte_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_byte_array AsRef(gulpgulpgulpdot_packed_byte_array* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_byte_array AsRef(in gulpgulpgulpdot_packed_byte_array source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_int32_array* AsPointer(ref gulpgulpgulpdot_packed_int32_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_int32_array* ReadOnlyRefAsPointer(in gulpgulpgulpdot_packed_int32_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_int32_array AsRef(gulpgulpgulpdot_packed_int32_array* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_int32_array AsRef(in gulpgulpgulpdot_packed_int32_array source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_int64_array* AsPointer(ref gulpgulpgulpdot_packed_int64_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_int64_array* ReadOnlyRefAsPointer(in gulpgulpgulpdot_packed_int64_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_int64_array AsRef(gulpgulpgulpdot_packed_int64_array* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_int64_array AsRef(in gulpgulpgulpdot_packed_int64_array source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_float32_array* AsPointer(ref gulpgulpgulpdot_packed_float32_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_float32_array* ReadOnlyRefAsPointer(in gulpgulpgulpdot_packed_float32_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_float32_array AsRef(gulpgulpgulpdot_packed_float32_array* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_float32_array AsRef(in gulpgulpgulpdot_packed_float32_array source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_float64_array* AsPointer(ref gulpgulpgulpdot_packed_float64_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_float64_array* ReadOnlyRefAsPointer(in gulpgulpgulpdot_packed_float64_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_float64_array AsRef(gulpgulpgulpdot_packed_float64_array* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_float64_array AsRef(in gulpgulpgulpdot_packed_float64_array source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_string_array* AsPointer(ref gulpgulpgulpdot_packed_string_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_string_array* ReadOnlyRefAsPointer(in gulpgulpgulpdot_packed_string_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_string_array AsRef(gulpgulpgulpdot_packed_string_array* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_string_array AsRef(in gulpgulpgulpdot_packed_string_array source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_vector2_array* AsPointer(ref gulpgulpgulpdot_packed_vector2_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_vector2_array* ReadOnlyRefAsPointer(in gulpgulpgulpdot_packed_vector2_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_vector2_array AsRef(gulpgulpgulpdot_packed_vector2_array* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_vector2_array AsRef(in gulpgulpgulpdot_packed_vector2_array source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_vector3_array* AsPointer(ref gulpgulpgulpdot_packed_vector3_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_vector3_array* ReadOnlyRefAsPointer(in gulpgulpgulpdot_packed_vector3_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_vector3_array AsRef(gulpgulpgulpdot_packed_vector3_array* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_vector3_array AsRef(in gulpgulpgulpdot_packed_vector3_array source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_vector4_array* AsPointer(ref gulpgulpgulpdot_packed_vector4_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_vector4_array* ReadOnlyRefAsPointer(in gulpgulpgulpdot_packed_vector4_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_vector4_array AsRef(gulpgulpgulpdot_packed_vector4_array* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_vector4_array AsRef(in gulpgulpgulpdot_packed_vector4_array source)
        => ref *ReadOnlyRefAsPointer(in source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_color_array* AsPointer(ref gulpgulpgulpdot_packed_color_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe gulpgulpgulpdot_packed_color_array* ReadOnlyRefAsPointer(in gulpgulpgulpdot_packed_color_array value)
        => value.GetUnsafeAddress();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_color_array AsRef(gulpgulpgulpdot_packed_color_array* source)
        => ref *source;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref gulpgulpgulpdot_packed_color_array AsRef(in gulpgulpgulpdot_packed_color_array source)
        => ref *ReadOnlyRefAsPointer(in source);
}
