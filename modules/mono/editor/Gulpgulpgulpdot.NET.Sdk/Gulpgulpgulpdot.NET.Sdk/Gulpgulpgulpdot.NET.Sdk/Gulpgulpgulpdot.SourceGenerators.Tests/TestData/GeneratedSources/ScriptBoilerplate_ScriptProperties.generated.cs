using Gulpgulpgulpdot;
using Gulpgulpgulpdot.NativeInterop;

partial class ScriptBoilerplate
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Gulpgulpgulpdot.Node.PropertyName {
        /// <summary>
        /// Cached name for the '_nodePath' field.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @_nodePath = "_nodePath";
        /// <summary>
        /// Cached name for the '_velocity' field.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @_velocity = "_velocity";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGulpgulpgulpdotClassPropertyValue(in gulpgulpgulpdot_string_name name, in gulpgulpgulpdot_variant value)
    {
        if (name == PropertyName.@_nodePath) {
            this.@_nodePath = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.ConvertTo<global::Gulpgulpgulpdot.NodePath>(value);
            return true;
        }
        if (name == PropertyName.@_velocity) {
            this.@_velocity = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.ConvertTo<int>(value);
            return true;
        }
        return base.SetGulpgulpgulpdotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGulpgulpgulpdotClassPropertyValue(in gulpgulpgulpdot_string_name name, out gulpgulpgulpdot_variant value)
    {
        if (name == PropertyName.@_nodePath) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<global::Gulpgulpgulpdot.NodePath>(this.@_nodePath);
            return true;
        }
        if (name == PropertyName.@_velocity) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<int>(this.@_velocity);
            return true;
        }
        return base.GetGulpgulpgulpdotClassPropertyValue(name, out value);
    }
    /// <summary>
    /// Get the property information for all the properties declared in this class.
    /// This method is used by Gulpgulpgulpdot to register the available properties in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Gulpgulpgulpdot.Bridge.PropertyInfo> GetGulpgulpgulpdotPropertyList()
    {
        var properties = new global::System.Collections.Generic.List<global::Gulpgulpgulpdot.Bridge.PropertyInfo>();
        properties.Add(new(type: (global::Gulpgulpgulpdot.Variant.Type)22, name: PropertyName.@_nodePath, hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Gulpgulpgulpdot.Variant.Type)2, name: PropertyName.@_velocity, hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)4096, exported: false));
        return properties;
    }
#pragma warning restore CS0109
}
