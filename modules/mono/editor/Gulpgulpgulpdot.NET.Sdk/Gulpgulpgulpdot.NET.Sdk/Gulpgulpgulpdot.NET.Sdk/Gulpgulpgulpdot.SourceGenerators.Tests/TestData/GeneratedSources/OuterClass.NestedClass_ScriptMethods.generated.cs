using Gulpgulpgulpdot;
using Gulpgulpgulpdot.NativeInterop;

partial struct OuterClass
{
partial class NestedClass
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : global::Gulpgulpgulpdot.RefCounted.MethodName {
        /// <summary>
        /// Cached name for the '_Get' method.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @_Get = "_Get";
    }
    /// <summary>
    /// Get the method information for all the methods declared in this class.
    /// This method is used by Gulpgulpgulpdot to register the available methods in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Gulpgulpgulpdot.Bridge.MethodInfo> GetGulpgulpgulpdotMethodList()
    {
        var methods = new global::System.Collections.Generic.List<global::Gulpgulpgulpdot.Bridge.MethodInfo>(1);
        methods.Add(new(name: MethodName.@_Get, returnVal: new(type: (global::Gulpgulpgulpdot.Variant.Type)0, name: "", hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)131078, exported: false), flags: (global::Gulpgulpgulpdot.MethodFlags)1, arguments: new() { new(type: (global::Gulpgulpgulpdot.Variant.Type)21, name: "property", hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        return methods;
    }
#pragma warning restore CS0109
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool InvokeGulpgulpgulpdotClassMethod(in gulpgulpgulpdot_string_name method, NativeVariantPtrArgs args, out gulpgulpgulpdot_variant ret)
    {
        if (method == MethodName.@_Get && args.Count == 1) {
            var callRet = @_Get(global::Gulpgulpgulpdot.NativeInterop.VariantUtils.ConvertTo<global::Gulpgulpgulpdot.StringName>(args[0]));
            ret = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<global::Gulpgulpgulpdot.Variant>(callRet);
            return true;
        }
        return base.InvokeGulpgulpgulpdotClassMethod(method, args, out ret);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool HasGulpgulpgulpdotClassMethod(in gulpgulpgulpdot_string_name method)
    {
        if (method == MethodName.@_Get) {
           return true;
        }
        return base.HasGulpgulpgulpdotClassMethod(method);
    }
}
}
