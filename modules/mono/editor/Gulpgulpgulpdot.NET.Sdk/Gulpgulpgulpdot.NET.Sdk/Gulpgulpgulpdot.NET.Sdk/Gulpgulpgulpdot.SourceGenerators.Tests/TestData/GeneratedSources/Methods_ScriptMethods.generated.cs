using Gulpgulpgulpdot;
using Gulpgulpgulpdot.NativeInterop;

partial class Methods
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : global::Gulpgulpgulpdot.GulpgulpgulpdotObject.MethodName {
        /// <summary>
        /// Cached name for the 'MethodWithOverload' method.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @MethodWithOverload = "MethodWithOverload";
    }
    /// <summary>
    /// Get the method information for all the methods declared in this class.
    /// This method is used by Gulpgulpgulpdot to register the available methods in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Gulpgulpgulpdot.Bridge.MethodInfo> GetGulpgulpgulpdotMethodList()
    {
        var methods = new global::System.Collections.Generic.List<global::Gulpgulpgulpdot.Bridge.MethodInfo>(3);
        methods.Add(new(name: MethodName.@MethodWithOverload, returnVal: new(type: (global::Gulpgulpgulpdot.Variant.Type)0, name: "", hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)6, exported: false), flags: (global::Gulpgulpgulpdot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.@MethodWithOverload, returnVal: new(type: (global::Gulpgulpgulpdot.Variant.Type)0, name: "", hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)6, exported: false), flags: (global::Gulpgulpgulpdot.MethodFlags)1, arguments: new() { new(type: (global::Gulpgulpgulpdot.Variant.Type)2, name: "a", hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.@MethodWithOverload, returnVal: new(type: (global::Gulpgulpgulpdot.Variant.Type)0, name: "", hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)6, exported: false), flags: (global::Gulpgulpgulpdot.MethodFlags)1, arguments: new() { new(type: (global::Gulpgulpgulpdot.Variant.Type)2, name: "a", hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)6, exported: false), new(type: (global::Gulpgulpgulpdot.Variant.Type)2, name: "b", hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        return methods;
    }
#pragma warning restore CS0109
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool InvokeGulpgulpgulpdotClassMethod(in gulpgulpgulpdot_string_name method, NativeVariantPtrArgs args, out gulpgulpgulpdot_variant ret)
    {
        if (method == MethodName.@MethodWithOverload && args.Count == 0) {
            @MethodWithOverload();
            ret = default;
            return true;
        }
        if (method == MethodName.@MethodWithOverload && args.Count == 1) {
            @MethodWithOverload(global::Gulpgulpgulpdot.NativeInterop.VariantUtils.ConvertTo<int>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.@MethodWithOverload && args.Count == 2) {
            @MethodWithOverload(global::Gulpgulpgulpdot.NativeInterop.VariantUtils.ConvertTo<int>(args[0]), global::Gulpgulpgulpdot.NativeInterop.VariantUtils.ConvertTo<int>(args[1]));
            ret = default;
            return true;
        }
        return base.InvokeGulpgulpgulpdotClassMethod(method, args, out ret);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool HasGulpgulpgulpdotClassMethod(in gulpgulpgulpdot_string_name method)
    {
        if (method == MethodName.@MethodWithOverload) {
           return true;
        }
        return base.HasGulpgulpgulpdotClassMethod(method);
    }
}
