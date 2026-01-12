using Gulpgulpgulpdot;
using Gulpgulpgulpdot.NativeInterop;

partial class AllWriteOnly
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Gulpgulpgulpdot.GulpgulpgulpdotObject.PropertyName {
        /// <summary>
        /// Cached name for the 'WriteOnlyProperty' property.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @WriteOnlyProperty = "WriteOnlyProperty";
        /// <summary>
        /// Cached name for the '_writeOnlyBackingField' field.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @_writeOnlyBackingField = "_writeOnlyBackingField";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGulpgulpgulpdotClassPropertyValue(in gulpgulpgulpdot_string_name name, in gulpgulpgulpdot_variant value)
    {
        if (name == PropertyName.@WriteOnlyProperty) {
            this.@WriteOnlyProperty = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        if (name == PropertyName.@_writeOnlyBackingField) {
            this.@_writeOnlyBackingField = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        return base.SetGulpgulpgulpdotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGulpgulpgulpdotClassPropertyValue(in gulpgulpgulpdot_string_name name, out gulpgulpgulpdot_variant value)
    {
        if (name == PropertyName.@_writeOnlyBackingField) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<bool>(this.@_writeOnlyBackingField);
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
        properties.Add(new(type: (global::Gulpgulpgulpdot.Variant.Type)1, name: PropertyName.@_writeOnlyBackingField, hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Gulpgulpgulpdot.Variant.Type)1, name: PropertyName.@WriteOnlyProperty, hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)4096, exported: false));
        return properties;
    }
#pragma warning restore CS0109
}
