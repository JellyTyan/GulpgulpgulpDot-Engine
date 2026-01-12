#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable IDE1006 // Naming rule violation
// ReSharper disable InconsistentNaming

using System;
using System.Runtime.CompilerServices;
using Gulpgulpgulpdot.SourceGenerators.Internal;


namespace Gulpgulpgulpdot.NativeInterop
{
    /*
     * IMPORTANT:
     * The order of the methods defined in NativeFuncs must match the order
     * in the array defined at the bottom of 'glue/runtime_interop.cpp'.
     */

    [GenerateUnmanagedCallbacks(typeof(UnmanagedCallbacks))]
    public static unsafe partial class NativeFuncs
    {
        private static bool initialized;

        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Global
        public static void Initialize(IntPtr unmanagedCallbacks, int unmanagedCallbacksSize)
        {
            if (initialized)
                throw new InvalidOperationException("Already initialized.");
            initialized = true;

            if (unmanagedCallbacksSize != sizeof(UnmanagedCallbacks))
                throw new ArgumentException("Unmanaged callbacks size mismatch.", nameof(unmanagedCallbacksSize));

            _unmanagedCallbacks = Unsafe.AsRef<UnmanagedCallbacks>((void*)unmanagedCallbacks);
        }

        private partial struct UnmanagedCallbacks
        {
        }

        // Custom functions

        internal static partial gulpgulpgulpdot_bool gulpgulpgulpdotsharp_dotnet_module_is_initialized();

        public static partial IntPtr gulpgulpgulpdotsharp_method_bind_get_method(in gulpgulpgulpdot_string_name p_classname,
            in gulpgulpgulpdot_string_name p_methodname);

        public static partial IntPtr gulpgulpgulpdotsharp_method_bind_get_method_with_compatibility(
            in gulpgulpgulpdot_string_name p_classname, in gulpgulpgulpdot_string_name p_methodname, ulong p_hash);

        public static partial delegate* unmanaged<gulpgulpgulpdot_bool, IntPtr> gulpgulpgulpdotsharp_get_class_constructor(
            in gulpgulpgulpdot_string_name p_classname);

        public static partial IntPtr gulpgulpgulpdotsharp_engine_get_singleton(in gulpgulpgulpdot_string p_name);


        internal static partial Error gulpgulpgulpdotsharp_stack_info_vector_resize(
            ref DebuggingUtils.gulpgulpgulpdot_stack_info_vector p_stack_info_vector, int p_size);

        internal static partial void gulpgulpgulpdotsharp_stack_info_vector_destroy(
            ref DebuggingUtils.gulpgulpgulpdot_stack_info_vector p_stack_info_vector);

        internal static partial void gulpgulpgulpdotsharp_internal_editor_file_system_update_files(in gulpgulpgulpdot_packed_string_array p_script_paths);

        internal static partial void gulpgulpgulpdotsharp_internal_script_debugger_send_error(in gulpgulpgulpdot_string p_func,
            in gulpgulpgulpdot_string p_file, int p_line, in gulpgulpgulpdot_string p_err, in gulpgulpgulpdot_string p_descr,
            gulpgulpgulpdot_error_handler_type p_type, in DebuggingUtils.gulpgulpgulpdot_stack_info_vector p_stack_info_vector);

        internal static partial gulpgulpgulpdot_bool gulpgulpgulpdotsharp_internal_script_debugger_is_active();

        internal static partial IntPtr gulpgulpgulpdotsharp_internal_object_get_associated_gchandle(IntPtr ptr);

        internal static partial void gulpgulpgulpdotsharp_internal_object_disposed(IntPtr ptr, IntPtr gcHandleToFree);

        internal static partial void gulpgulpgulpdotsharp_internal_refcounted_disposed(IntPtr ptr, IntPtr gcHandleToFree,
            gulpgulpgulpdot_bool isFinalizer);

        internal static partial Error gulpgulpgulpdotsharp_internal_signal_awaiter_connect(IntPtr source,
            in gulpgulpgulpdot_string_name signal,
            IntPtr target, IntPtr awaiterHandlePtr);

        internal static partial void gulpgulpgulpdotsharp_internal_tie_native_managed_to_unmanaged(IntPtr gcHandleIntPtr,
            IntPtr unmanaged, in gulpgulpgulpdot_string_name nativeName, gulpgulpgulpdot_bool refCounted);

        internal static partial void gulpgulpgulpdotsharp_internal_tie_user_managed_to_unmanaged(IntPtr gcHandleIntPtr,
            IntPtr unmanaged, gulpgulpgulpdot_ref* scriptPtr, gulpgulpgulpdot_bool refCounted);

        internal static partial void gulpgulpgulpdotsharp_internal_tie_managed_to_unmanaged_with_pre_setup(
            IntPtr gcHandleIntPtr, IntPtr unmanaged);

        internal static partial IntPtr gulpgulpgulpdotsharp_internal_unmanaged_get_script_instance_managed(IntPtr p_unmanaged,
            out gulpgulpgulpdot_bool r_has_cs_script_instance);

        internal static partial IntPtr gulpgulpgulpdotsharp_internal_unmanaged_get_instance_binding_managed(IntPtr p_unmanaged);

        internal static partial IntPtr gulpgulpgulpdotsharp_internal_unmanaged_instance_binding_create_managed(IntPtr p_unmanaged,
            IntPtr oldGCHandlePtr);

        internal static partial void gulpgulpgulpdotsharp_internal_new_csharp_script(gulpgulpgulpdot_ref* r_dest);

        internal static partial gulpgulpgulpdot_bool gulpgulpgulpdotsharp_internal_script_load(in gulpgulpgulpdot_string p_path, gulpgulpgulpdot_ref* r_dest);

        internal static partial void gulpgulpgulpdotsharp_internal_reload_registered_script(IntPtr scriptPtr);

        internal static partial void gulpgulpgulpdotsharp_array_filter_gulpgulpgulpdot_objects_by_native(scoped in gulpgulpgulpdot_string_name p_native_name,
            scoped in gulpgulpgulpdot_array p_input, out gulpgulpgulpdot_array r_output);

        internal static partial void gulpgulpgulpdotsharp_array_filter_gulpgulpgulpdot_objects_by_non_native(scoped in gulpgulpgulpdot_array p_input,
            out gulpgulpgulpdot_array r_output);

        public static partial void gulpgulpgulpdotsharp_ref_new_from_ref_counted_ptr(out gulpgulpgulpdot_ref r_dest,
            IntPtr p_ref_counted_ptr);

        public static partial void gulpgulpgulpdotsharp_ref_destroy(ref gulpgulpgulpdot_ref p_instance);

        public static partial void gulpgulpgulpdotsharp_string_name_new_from_string(out gulpgulpgulpdot_string_name r_dest,
            scoped in gulpgulpgulpdot_string p_name);

        public static partial void gulpgulpgulpdotsharp_node_path_new_from_string(out gulpgulpgulpdot_node_path r_dest,
            scoped in gulpgulpgulpdot_string p_name);

        public static partial void
            gulpgulpgulpdotsharp_string_name_as_string(out gulpgulpgulpdot_string r_dest, scoped in gulpgulpgulpdot_string_name p_name);

        public static partial void gulpgulpgulpdotsharp_node_path_as_string(out gulpgulpgulpdot_string r_dest, scoped in gulpgulpgulpdot_node_path p_np);

        public static partial gulpgulpgulpdot_packed_byte_array gulpgulpgulpdotsharp_packed_byte_array_new_mem_copy(byte* p_src,
            int p_length);

        public static partial gulpgulpgulpdot_packed_int32_array gulpgulpgulpdotsharp_packed_int32_array_new_mem_copy(int* p_src,
            int p_length);

        public static partial gulpgulpgulpdot_packed_int64_array gulpgulpgulpdotsharp_packed_int64_array_new_mem_copy(long* p_src,
            int p_length);

        public static partial gulpgulpgulpdot_packed_float32_array gulpgulpgulpdotsharp_packed_float32_array_new_mem_copy(float* p_src,
            int p_length);

        public static partial gulpgulpgulpdot_packed_float64_array gulpgulpgulpdotsharp_packed_float64_array_new_mem_copy(double* p_src,
            int p_length);

        public static partial gulpgulpgulpdot_packed_vector2_array gulpgulpgulpdotsharp_packed_vector2_array_new_mem_copy(Vector2* p_src,
            int p_length);

        public static partial gulpgulpgulpdot_packed_vector3_array gulpgulpgulpdotsharp_packed_vector3_array_new_mem_copy(Vector3* p_src,
            int p_length);

        public static partial gulpgulpgulpdot_packed_vector4_array gulpgulpgulpdotsharp_packed_vector4_array_new_mem_copy(Vector4* p_src,
            int p_length);

        public static partial gulpgulpgulpdot_packed_color_array gulpgulpgulpdotsharp_packed_color_array_new_mem_copy(Color* p_src,
            int p_length);

        public static partial void gulpgulpgulpdotsharp_packed_string_array_add(ref gulpgulpgulpdot_packed_string_array r_dest,
            in gulpgulpgulpdot_string p_element);

        public static partial void gulpgulpgulpdotsharp_callable_new_with_delegate(IntPtr p_delegate_handle, IntPtr p_trampoline,
            IntPtr p_object, out gulpgulpgulpdot_callable r_callable);

        internal static partial gulpgulpgulpdot_bool gulpgulpgulpdotsharp_callable_get_data_for_marshalling(scoped in gulpgulpgulpdot_callable p_callable,
            out IntPtr r_delegate_handle, out IntPtr r_trampoline, out IntPtr r_object, out gulpgulpgulpdot_string_name r_name);

        internal static partial gulpgulpgulpdot_variant gulpgulpgulpdotsharp_callable_call(scoped in gulpgulpgulpdot_callable p_callable,
            gulpgulpgulpdot_variant** p_args, int p_arg_count, out gulpgulpgulpdot_variant_call_error p_call_error);

        internal static partial void gulpgulpgulpdotsharp_callable_call_deferred(in gulpgulpgulpdot_callable p_callable,
            gulpgulpgulpdot_variant** p_args, int p_arg_count);

        internal static partial Color gulpgulpgulpdotsharp_color_from_ok_hsl(float p_h, float p_s, float p_l, float p_alpha);

        internal static partial float gulpgulpgulpdotsharp_color_get_ok_hsl_h(in Color p_self);

        internal static partial float gulpgulpgulpdotsharp_color_get_ok_hsl_s(in Color p_self);

        internal static partial float gulpgulpgulpdotsharp_color_get_ok_hsl_l(in Color p_self);

        // GDNative functions

        // gdnative.h

        public static partial void gulpgulpgulpdotsharp_method_bind_ptrcall(IntPtr p_method_bind, IntPtr p_instance, void** p_args,
            void* p_ret);

        public static partial gulpgulpgulpdot_variant gulpgulpgulpdotsharp_method_bind_call(IntPtr p_method_bind, IntPtr p_instance,
            gulpgulpgulpdot_variant** p_args, int p_arg_count, out gulpgulpgulpdot_variant_call_error p_call_error);

        // variant.h

        public static partial void
            gulpgulpgulpdotsharp_variant_new_string_name(out gulpgulpgulpdot_variant r_dest, scoped in gulpgulpgulpdot_string_name p_s);

        public static partial void gulpgulpgulpdotsharp_variant_new_copy(out gulpgulpgulpdot_variant r_dest, scoped in gulpgulpgulpdot_variant p_src);

        public static partial void gulpgulpgulpdotsharp_variant_new_node_path(out gulpgulpgulpdot_variant r_dest, scoped in gulpgulpgulpdot_node_path p_np);

        public static partial void gulpgulpgulpdotsharp_variant_new_object(out gulpgulpgulpdot_variant r_dest, IntPtr p_obj);

        public static partial void gulpgulpgulpdotsharp_variant_new_transform2d(out gulpgulpgulpdot_variant r_dest, scoped in Transform2D p_t2d);

        public static partial void gulpgulpgulpdotsharp_variant_new_basis(out gulpgulpgulpdot_variant r_dest, scoped in Basis p_basis);

        public static partial void gulpgulpgulpdotsharp_variant_new_transform3d(out gulpgulpgulpdot_variant r_dest, scoped in Transform3D p_trans);

        public static partial void gulpgulpgulpdotsharp_variant_new_projection(out gulpgulpgulpdot_variant r_dest, scoped in Projection p_proj);

        public static partial void gulpgulpgulpdotsharp_variant_new_aabb(out gulpgulpgulpdot_variant r_dest, scoped in Aabb p_aabb);

        public static partial void gulpgulpgulpdotsharp_variant_new_dictionary(out gulpgulpgulpdot_variant r_dest,
            scoped in gulpgulpgulpdot_dictionary p_dict);

        public static partial void gulpgulpgulpdotsharp_variant_new_array(out gulpgulpgulpdot_variant r_dest, scoped in gulpgulpgulpdot_array p_arr);

        public static partial void gulpgulpgulpdotsharp_variant_new_packed_byte_array(out gulpgulpgulpdot_variant r_dest,
            scoped in gulpgulpgulpdot_packed_byte_array p_pba);

        public static partial void gulpgulpgulpdotsharp_variant_new_packed_int32_array(out gulpgulpgulpdot_variant r_dest,
            scoped in gulpgulpgulpdot_packed_int32_array p_pia);

        public static partial void gulpgulpgulpdotsharp_variant_new_packed_int64_array(out gulpgulpgulpdot_variant r_dest,
            scoped in gulpgulpgulpdot_packed_int64_array p_pia);

        public static partial void gulpgulpgulpdotsharp_variant_new_packed_float32_array(out gulpgulpgulpdot_variant r_dest,
            scoped in gulpgulpgulpdot_packed_float32_array p_pra);

        public static partial void gulpgulpgulpdotsharp_variant_new_packed_float64_array(out gulpgulpgulpdot_variant r_dest,
            scoped in gulpgulpgulpdot_packed_float64_array p_pra);

        public static partial void gulpgulpgulpdotsharp_variant_new_packed_string_array(out gulpgulpgulpdot_variant r_dest,
            scoped in gulpgulpgulpdot_packed_string_array p_psa);

        public static partial void gulpgulpgulpdotsharp_variant_new_packed_vector2_array(out gulpgulpgulpdot_variant r_dest,
            scoped in gulpgulpgulpdot_packed_vector2_array p_pv2a);

        public static partial void gulpgulpgulpdotsharp_variant_new_packed_vector3_array(out gulpgulpgulpdot_variant r_dest,
            scoped in gulpgulpgulpdot_packed_vector3_array p_pv3a);

        public static partial void gulpgulpgulpdotsharp_variant_new_packed_vector4_array(out gulpgulpgulpdot_variant r_dest,
            scoped in gulpgulpgulpdot_packed_vector4_array p_pv4a);

        public static partial void gulpgulpgulpdotsharp_variant_new_packed_color_array(out gulpgulpgulpdot_variant r_dest,
            scoped in gulpgulpgulpdot_packed_color_array p_pca);

        public static partial gulpgulpgulpdot_bool gulpgulpgulpdotsharp_variant_as_bool(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Int64 gulpgulpgulpdotsharp_variant_as_int(scoped in gulpgulpgulpdot_variant p_self);

        public static partial double gulpgulpgulpdotsharp_variant_as_float(scoped in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_string gulpgulpgulpdotsharp_variant_as_string(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Vector2 gulpgulpgulpdotsharp_variant_as_vector2(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Vector2I gulpgulpgulpdotsharp_variant_as_vector2i(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Rect2 gulpgulpgulpdotsharp_variant_as_rect2(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Rect2I gulpgulpgulpdotsharp_variant_as_rect2i(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Vector3 gulpgulpgulpdotsharp_variant_as_vector3(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Vector3I gulpgulpgulpdotsharp_variant_as_vector3i(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Transform2D gulpgulpgulpdotsharp_variant_as_transform2d(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Vector4 gulpgulpgulpdotsharp_variant_as_vector4(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Vector4I gulpgulpgulpdotsharp_variant_as_vector4i(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Plane gulpgulpgulpdotsharp_variant_as_plane(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Quaternion gulpgulpgulpdotsharp_variant_as_quaternion(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Aabb gulpgulpgulpdotsharp_variant_as_aabb(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Basis gulpgulpgulpdotsharp_variant_as_basis(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Transform3D gulpgulpgulpdotsharp_variant_as_transform3d(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Projection gulpgulpgulpdotsharp_variant_as_projection(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Color gulpgulpgulpdotsharp_variant_as_color(scoped in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_string_name gulpgulpgulpdotsharp_variant_as_string_name(scoped in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_node_path gulpgulpgulpdotsharp_variant_as_node_path(scoped in gulpgulpgulpdot_variant p_self);

        public static partial Rid gulpgulpgulpdotsharp_variant_as_rid(scoped in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_callable gulpgulpgulpdotsharp_variant_as_callable(scoped in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_signal gulpgulpgulpdotsharp_variant_as_signal(scoped in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_dictionary gulpgulpgulpdotsharp_variant_as_dictionary(scoped in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_array gulpgulpgulpdotsharp_variant_as_array(scoped in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_packed_byte_array gulpgulpgulpdotsharp_variant_as_packed_byte_array(scoped in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_packed_int32_array gulpgulpgulpdotsharp_variant_as_packed_int32_array(scoped in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_packed_int64_array gulpgulpgulpdotsharp_variant_as_packed_int64_array(scoped in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_packed_float32_array gulpgulpgulpdotsharp_variant_as_packed_float32_array(scoped in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_packed_float64_array gulpgulpgulpdotsharp_variant_as_packed_float64_array(scoped in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_packed_string_array gulpgulpgulpdotsharp_variant_as_packed_string_array(scoped in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_packed_vector2_array gulpgulpgulpdotsharp_variant_as_packed_vector2_array(scoped in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_packed_vector3_array gulpgulpgulpdotsharp_variant_as_packed_vector3_array(scoped in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_packed_vector4_array gulpgulpgulpdotsharp_variant_as_packed_vector4_array(
            in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_packed_color_array gulpgulpgulpdotsharp_variant_as_packed_color_array(scoped in gulpgulpgulpdot_variant p_self);

        public static partial gulpgulpgulpdot_bool gulpgulpgulpdotsharp_variant_equals(scoped in gulpgulpgulpdot_variant p_a, scoped in gulpgulpgulpdot_variant p_b);

        // string.h

        public static partial void gulpgulpgulpdotsharp_string_new_with_utf16_chars(out gulpgulpgulpdot_string r_dest, char* p_contents);

        // string_name.h

        public static partial void gulpgulpgulpdotsharp_string_name_new_copy(out gulpgulpgulpdot_string_name r_dest,
            scoped in gulpgulpgulpdot_string_name p_src);

        // node_path.h

        public static partial void gulpgulpgulpdotsharp_node_path_new_copy(out gulpgulpgulpdot_node_path r_dest, scoped in gulpgulpgulpdot_node_path p_src);

        // array.h

        public static partial void gulpgulpgulpdotsharp_array_new(out gulpgulpgulpdot_array r_dest);

        public static partial void gulpgulpgulpdotsharp_array_new_copy(out gulpgulpgulpdot_array r_dest, scoped in gulpgulpgulpdot_array p_src);

        public static partial gulpgulpgulpdot_variant* gulpgulpgulpdotsharp_array_ptrw(ref gulpgulpgulpdot_array p_self);

        // dictionary.h

        public static partial void gulpgulpgulpdotsharp_dictionary_new(out gulpgulpgulpdot_dictionary r_dest);

        public static partial void gulpgulpgulpdotsharp_dictionary_new_copy(out gulpgulpgulpdot_dictionary r_dest,
            scoped in gulpgulpgulpdot_dictionary p_src);

        // destroy functions

        public static partial void gulpgulpgulpdotsharp_packed_byte_array_destroy(ref gulpgulpgulpdot_packed_byte_array p_self);

        public static partial void gulpgulpgulpdotsharp_packed_int32_array_destroy(ref gulpgulpgulpdot_packed_int32_array p_self);

        public static partial void gulpgulpgulpdotsharp_packed_int64_array_destroy(ref gulpgulpgulpdot_packed_int64_array p_self);

        public static partial void gulpgulpgulpdotsharp_packed_float32_array_destroy(ref gulpgulpgulpdot_packed_float32_array p_self);

        public static partial void gulpgulpgulpdotsharp_packed_float64_array_destroy(ref gulpgulpgulpdot_packed_float64_array p_self);

        public static partial void gulpgulpgulpdotsharp_packed_string_array_destroy(ref gulpgulpgulpdot_packed_string_array p_self);

        public static partial void gulpgulpgulpdotsharp_packed_vector2_array_destroy(ref gulpgulpgulpdot_packed_vector2_array p_self);

        public static partial void gulpgulpgulpdotsharp_packed_vector3_array_destroy(ref gulpgulpgulpdot_packed_vector3_array p_self);

        public static partial void gulpgulpgulpdotsharp_packed_vector4_array_destroy(ref gulpgulpgulpdot_packed_vector4_array p_self);

        public static partial void gulpgulpgulpdotsharp_packed_color_array_destroy(ref gulpgulpgulpdot_packed_color_array p_self);

        public static partial void gulpgulpgulpdotsharp_variant_destroy(ref gulpgulpgulpdot_variant p_self);

        public static partial void gulpgulpgulpdotsharp_string_destroy(ref gulpgulpgulpdot_string p_self);

        public static partial void gulpgulpgulpdotsharp_string_name_destroy(ref gulpgulpgulpdot_string_name p_self);

        public static partial void gulpgulpgulpdotsharp_node_path_destroy(ref gulpgulpgulpdot_node_path p_self);

        public static partial void gulpgulpgulpdotsharp_signal_destroy(ref gulpgulpgulpdot_signal p_self);

        public static partial void gulpgulpgulpdotsharp_callable_destroy(ref gulpgulpgulpdot_callable p_self);

        public static partial void gulpgulpgulpdotsharp_array_destroy(ref gulpgulpgulpdot_array p_self);

        public static partial void gulpgulpgulpdotsharp_dictionary_destroy(ref gulpgulpgulpdot_dictionary p_self);

        // Array

        public static partial int gulpgulpgulpdotsharp_array_add(ref gulpgulpgulpdot_array p_self, in gulpgulpgulpdot_variant p_item);

        public static partial int gulpgulpgulpdotsharp_array_add_range(ref gulpgulpgulpdot_array p_self, in gulpgulpgulpdot_array p_collection);

        public static partial int gulpgulpgulpdotsharp_array_binary_search(ref gulpgulpgulpdot_array p_self, int p_index, int p_count, in gulpgulpgulpdot_variant p_value);

        public static partial void gulpgulpgulpdotsharp_array_duplicate(scoped ref gulpgulpgulpdot_array p_self, gulpgulpgulpdot_bool p_deep, out gulpgulpgulpdot_array r_dest);

        public static partial void gulpgulpgulpdotsharp_array_fill(ref gulpgulpgulpdot_array p_self, in gulpgulpgulpdot_variant p_value);

        public static partial int gulpgulpgulpdotsharp_array_index_of(ref gulpgulpgulpdot_array p_self, in gulpgulpgulpdot_variant p_item, int p_index = 0);

        public static partial void gulpgulpgulpdotsharp_array_insert(ref gulpgulpgulpdot_array p_self, int p_index, in gulpgulpgulpdot_variant p_item);

        public static partial int gulpgulpgulpdotsharp_array_last_index_of(ref gulpgulpgulpdot_array p_self, in gulpgulpgulpdot_variant p_item, int p_index);

        public static partial void gulpgulpgulpdotsharp_array_make_read_only(ref gulpgulpgulpdot_array p_self);

        public static partial void gulpgulpgulpdotsharp_array_set_typed(
            ref gulpgulpgulpdot_array p_self,
            uint p_elem_type,
            in gulpgulpgulpdot_string_name p_elem_class_name,
            in gulpgulpgulpdot_ref p_elem_script);

        public static partial gulpgulpgulpdot_bool gulpgulpgulpdotsharp_array_is_typed(ref gulpgulpgulpdot_array p_self);

        public static partial void gulpgulpgulpdotsharp_array_max(scoped ref gulpgulpgulpdot_array p_self, out gulpgulpgulpdot_variant r_value);

        public static partial void gulpgulpgulpdotsharp_array_min(scoped ref gulpgulpgulpdot_array p_self, out gulpgulpgulpdot_variant r_value);

        public static partial void gulpgulpgulpdotsharp_array_pick_random(scoped ref gulpgulpgulpdot_array p_self, out gulpgulpgulpdot_variant r_value);

        public static partial gulpgulpgulpdot_bool gulpgulpgulpdotsharp_array_recursive_equal(ref gulpgulpgulpdot_array p_self, in gulpgulpgulpdot_array p_other);

        public static partial void gulpgulpgulpdotsharp_array_remove_at(ref gulpgulpgulpdot_array p_self, int p_index);

        public static partial Error gulpgulpgulpdotsharp_array_resize(ref gulpgulpgulpdot_array p_self, int p_new_size);

        public static partial void gulpgulpgulpdotsharp_array_reverse(ref gulpgulpgulpdot_array p_self);

        public static partial void gulpgulpgulpdotsharp_array_shuffle(ref gulpgulpgulpdot_array p_self);

        public static partial void gulpgulpgulpdotsharp_array_slice(scoped ref gulpgulpgulpdot_array p_self, int p_start, int p_end,
            int p_step, gulpgulpgulpdot_bool p_deep, out gulpgulpgulpdot_array r_dest);

        public static partial void gulpgulpgulpdotsharp_array_sort(ref gulpgulpgulpdot_array p_self);

        public static partial void gulpgulpgulpdotsharp_array_to_string(ref gulpgulpgulpdot_array p_self, out gulpgulpgulpdot_string r_str);

        public static partial void gulpgulpgulpdotsharp_packed_byte_array_compress(scoped in gulpgulpgulpdot_packed_byte_array p_src, int p_mode, out gulpgulpgulpdot_packed_byte_array r_dst);

        public static partial void gulpgulpgulpdotsharp_packed_byte_array_decompress(scoped in gulpgulpgulpdot_packed_byte_array p_src, long p_buffer_size, int p_mode, out gulpgulpgulpdot_packed_byte_array r_dst);

        public static partial void gulpgulpgulpdotsharp_packed_byte_array_decompress_dynamic(scoped in gulpgulpgulpdot_packed_byte_array p_src, long p_buffer_size, int p_mode, out gulpgulpgulpdot_packed_byte_array r_dst);

        // Dictionary

        public static partial gulpgulpgulpdot_bool gulpgulpgulpdotsharp_dictionary_try_get_value(scoped ref gulpgulpgulpdot_dictionary p_self,
            scoped in gulpgulpgulpdot_variant p_key,
            out gulpgulpgulpdot_variant r_value);

        public static partial void gulpgulpgulpdotsharp_dictionary_set_value(ref gulpgulpgulpdot_dictionary p_self, in gulpgulpgulpdot_variant p_key,
            in gulpgulpgulpdot_variant p_value);

        public static partial void gulpgulpgulpdotsharp_dictionary_keys(scoped ref gulpgulpgulpdot_dictionary p_self, out gulpgulpgulpdot_array r_dest);

        public static partial void gulpgulpgulpdotsharp_dictionary_values(scoped ref gulpgulpgulpdot_dictionary p_self, out gulpgulpgulpdot_array r_dest);

        public static partial int gulpgulpgulpdotsharp_dictionary_count(ref gulpgulpgulpdot_dictionary p_self);

        public static partial void gulpgulpgulpdotsharp_dictionary_key_value_pair_at(scoped ref gulpgulpgulpdot_dictionary p_self, int p_index,
            out gulpgulpgulpdot_variant r_key, out gulpgulpgulpdot_variant r_value);

        public static partial void gulpgulpgulpdotsharp_dictionary_add(ref gulpgulpgulpdot_dictionary p_self, in gulpgulpgulpdot_variant p_key,
            in gulpgulpgulpdot_variant p_value);

        public static partial void gulpgulpgulpdotsharp_dictionary_clear(ref gulpgulpgulpdot_dictionary p_self);

        public static partial gulpgulpgulpdot_bool gulpgulpgulpdotsharp_dictionary_contains_key(ref gulpgulpgulpdot_dictionary p_self,
            in gulpgulpgulpdot_variant p_key);

        public static partial void gulpgulpgulpdotsharp_dictionary_duplicate(scoped ref gulpgulpgulpdot_dictionary p_self, gulpgulpgulpdot_bool p_deep,
            out gulpgulpgulpdot_dictionary r_dest);

        public static partial void gulpgulpgulpdotsharp_dictionary_merge(ref gulpgulpgulpdot_dictionary p_self, in gulpgulpgulpdot_dictionary p_dictionary, gulpgulpgulpdot_bool p_overwrite);

        public static partial gulpgulpgulpdot_bool gulpgulpgulpdotsharp_dictionary_recursive_equal(ref gulpgulpgulpdot_dictionary p_self, in gulpgulpgulpdot_dictionary p_other);

        public static partial gulpgulpgulpdot_bool gulpgulpgulpdotsharp_dictionary_remove_key(ref gulpgulpgulpdot_dictionary p_self,
            in gulpgulpgulpdot_variant p_key);

        public static partial void gulpgulpgulpdotsharp_dictionary_make_read_only(ref gulpgulpgulpdot_dictionary p_self);

        public static partial void gulpgulpgulpdotsharp_dictionary_set_typed(
            ref gulpgulpgulpdot_dictionary p_self,
            uint p_key_type,
            in gulpgulpgulpdot_string_name p_key_class_name,
            in gulpgulpgulpdot_ref p_key_script,
            uint p_value_type,
            in gulpgulpgulpdot_string_name p_value_class_name,
            in gulpgulpgulpdot_ref p_value_script);

        public static partial gulpgulpgulpdot_bool gulpgulpgulpdotsharp_dictionary_is_typed_key(ref gulpgulpgulpdot_dictionary p_self);

        public static partial gulpgulpgulpdot_bool gulpgulpgulpdotsharp_dictionary_is_typed_value(ref gulpgulpgulpdot_dictionary p_self);

        public static partial uint gulpgulpgulpdotsharp_dictionary_get_typed_key_builtin(ref gulpgulpgulpdot_dictionary p_self);

        public static partial uint gulpgulpgulpdotsharp_dictionary_get_typed_value_builtin(ref gulpgulpgulpdot_dictionary p_self);

        public static partial void gulpgulpgulpdotsharp_dictionary_get_typed_key_class_name(ref gulpgulpgulpdot_dictionary p_self, out gulpgulpgulpdot_string_name r_dest);

        public static partial void gulpgulpgulpdotsharp_dictionary_get_typed_value_class_name(ref gulpgulpgulpdot_dictionary p_self, out gulpgulpgulpdot_string_name r_dest);

        public static partial void gulpgulpgulpdotsharp_dictionary_get_typed_key_script(ref gulpgulpgulpdot_dictionary p_self, out gulpgulpgulpdot_variant r_dest);

        public static partial void gulpgulpgulpdotsharp_dictionary_get_typed_value_script(ref gulpgulpgulpdot_dictionary p_self, out gulpgulpgulpdot_variant r_dest);

        public static partial void gulpgulpgulpdotsharp_dictionary_to_string(scoped ref gulpgulpgulpdot_dictionary p_self, out gulpgulpgulpdot_string r_str);

        // StringExtensions

        public static partial void gulpgulpgulpdotsharp_string_simplify_path(scoped in gulpgulpgulpdot_string p_self,
            out gulpgulpgulpdot_string r_simplified_path);

        public static partial void gulpgulpgulpdotsharp_string_capitalize(scoped in gulpgulpgulpdot_string p_self,
            out gulpgulpgulpdot_string r_capitalized);

        public static partial void gulpgulpgulpdotsharp_string_to_camel_case(scoped in gulpgulpgulpdot_string p_self,
            out gulpgulpgulpdot_string r_camel_case);

        public static partial void gulpgulpgulpdotsharp_string_to_pascal_case(scoped in gulpgulpgulpdot_string p_self,
            out gulpgulpgulpdot_string r_pascal_case);

        public static partial void gulpgulpgulpdotsharp_string_to_snake_case(scoped in gulpgulpgulpdot_string p_self,
            out gulpgulpgulpdot_string r_snake_case);

        public static partial void gulpgulpgulpdotsharp_string_to_kebab_case(scoped in gulpgulpgulpdot_string p_self,
            out gulpgulpgulpdot_string r_kebab_case);

        // NodePath

        public static partial void gulpgulpgulpdotsharp_node_path_get_as_property_path(in gulpgulpgulpdot_node_path p_self,
            ref gulpgulpgulpdot_node_path r_dest);

        public static partial void gulpgulpgulpdotsharp_node_path_get_concatenated_names(scoped in gulpgulpgulpdot_node_path p_self,
            out gulpgulpgulpdot_string r_names);

        public static partial void gulpgulpgulpdotsharp_node_path_get_concatenated_subnames(scoped in gulpgulpgulpdot_node_path p_self,
            out gulpgulpgulpdot_string r_subnames);

        public static partial void gulpgulpgulpdotsharp_node_path_get_name(scoped in gulpgulpgulpdot_node_path p_self, int p_idx,
            out gulpgulpgulpdot_string r_name);

        public static partial int gulpgulpgulpdotsharp_node_path_get_name_count(in gulpgulpgulpdot_node_path p_self);

        public static partial void gulpgulpgulpdotsharp_node_path_get_subname(scoped in gulpgulpgulpdot_node_path p_self, int p_idx,
            out gulpgulpgulpdot_string r_subname);

        public static partial int gulpgulpgulpdotsharp_node_path_get_subname_count(in gulpgulpgulpdot_node_path p_self);

        public static partial gulpgulpgulpdot_bool gulpgulpgulpdotsharp_node_path_is_absolute(in gulpgulpgulpdot_node_path p_self);

        public static partial gulpgulpgulpdot_bool gulpgulpgulpdotsharp_node_path_equals(in gulpgulpgulpdot_node_path p_self, in gulpgulpgulpdot_node_path p_other);

        public static partial int gulpgulpgulpdotsharp_node_path_hash(in gulpgulpgulpdot_node_path p_self);

        // GD, etc

        internal static partial void gulpgulpgulpdotsharp_bytes_to_var(scoped in gulpgulpgulpdot_packed_byte_array p_bytes,
            gulpgulpgulpdot_bool p_allow_objects,
            out gulpgulpgulpdot_variant r_ret);

        internal static partial void gulpgulpgulpdotsharp_convert(scoped in gulpgulpgulpdot_variant p_what, int p_type,
            out gulpgulpgulpdot_variant r_ret);

        internal static partial int gulpgulpgulpdotsharp_hash(in gulpgulpgulpdot_variant p_var);

        internal static partial IntPtr gulpgulpgulpdotsharp_instance_from_id(ulong p_instance_id);

        internal static partial void gulpgulpgulpdotsharp_print(in gulpgulpgulpdot_string p_what);

        public static partial void gulpgulpgulpdotsharp_print_rich(in gulpgulpgulpdot_string p_what);

        internal static partial void gulpgulpgulpdotsharp_printerr(in gulpgulpgulpdot_string p_what);

        internal static partial void gulpgulpgulpdotsharp_printraw(in gulpgulpgulpdot_string p_what);

        internal static partial void gulpgulpgulpdotsharp_prints(in gulpgulpgulpdot_string p_what);

        internal static partial void gulpgulpgulpdotsharp_printt(in gulpgulpgulpdot_string p_what);

        internal static partial float gulpgulpgulpdotsharp_randf();

        internal static partial uint gulpgulpgulpdotsharp_randi();

        internal static partial void gulpgulpgulpdotsharp_randomize();

        internal static partial double gulpgulpgulpdotsharp_randf_range(double from, double to);

        internal static partial double gulpgulpgulpdotsharp_randfn(double mean, double deviation);

        internal static partial int gulpgulpgulpdotsharp_randi_range(int from, int to);

        internal static partial uint gulpgulpgulpdotsharp_rand_from_seed(ulong seed, out ulong newSeed);

        internal static partial void gulpgulpgulpdotsharp_seed(ulong seed);

        internal static partial void gulpgulpgulpdotsharp_weakref(IntPtr p_obj, out gulpgulpgulpdot_ref r_weak_ref);

        internal static partial void gulpgulpgulpdotsharp_str_to_var(scoped in gulpgulpgulpdot_string p_str, out gulpgulpgulpdot_variant r_ret);

        internal static partial void gulpgulpgulpdotsharp_var_to_bytes(scoped in gulpgulpgulpdot_variant p_what, gulpgulpgulpdot_bool p_full_objects,
            out gulpgulpgulpdot_packed_byte_array r_bytes);

        internal static partial void gulpgulpgulpdotsharp_var_to_str(scoped in gulpgulpgulpdot_variant p_var, out gulpgulpgulpdot_string r_ret);

        internal static partial void gulpgulpgulpdotsharp_err_print_error(in gulpgulpgulpdot_string p_function, in gulpgulpgulpdot_string p_file, int p_line, in gulpgulpgulpdot_string p_error, in gulpgulpgulpdot_string p_message = default, gulpgulpgulpdot_bool p_editor_notify = gulpgulpgulpdot_bool.False, gulpgulpgulpdot_error_handler_type p_type = gulpgulpgulpdot_error_handler_type.ERR_HANDLER_ERROR);

        // Object

        public static partial void gulpgulpgulpdotsharp_object_to_string(IntPtr ptr, out gulpgulpgulpdot_string r_str);

        // Vector

        public static partial long gulpgulpgulpdotsharp_string_size(in gulpgulpgulpdot_string p_self);

        public static partial long gulpgulpgulpdotsharp_packed_byte_array_size(in gulpgulpgulpdot_packed_byte_array p_self);

        public static partial long gulpgulpgulpdotsharp_packed_int32_array_size(in gulpgulpgulpdot_packed_int32_array p_self);

        public static partial long gulpgulpgulpdotsharp_packed_int64_array_size(in gulpgulpgulpdot_packed_int64_array p_self);

        public static partial long gulpgulpgulpdotsharp_packed_float32_array_size(in gulpgulpgulpdot_packed_float32_array p_self);

        public static partial long gulpgulpgulpdotsharp_packed_float64_array_size(in gulpgulpgulpdot_packed_float64_array p_self);

        public static partial long gulpgulpgulpdotsharp_packed_string_array_size(in gulpgulpgulpdot_packed_string_array p_self);

        public static partial long gulpgulpgulpdotsharp_packed_vector2_array_size(in gulpgulpgulpdot_packed_vector2_array p_self);

        public static partial long gulpgulpgulpdotsharp_packed_vector3_array_size(in gulpgulpgulpdot_packed_vector3_array p_self);

        public static partial long gulpgulpgulpdotsharp_packed_vector4_array_size(in gulpgulpgulpdot_packed_vector4_array p_self);

        public static partial long gulpgulpgulpdotsharp_packed_color_array_size(in gulpgulpgulpdot_packed_color_array p_self);

        public static partial long gulpgulpgulpdotsharp_array_size(in gulpgulpgulpdot_array p_self);
    }
}
