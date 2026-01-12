using Gulpgulpgulpdot;
using Gulpgulpgulpdot.NativeInterop;

partial class AllReadOnly
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Gulpgulpgulpdot.GulpgulpgulpdotObject.PropertyName {
        /// <summary>
        /// Cached name for the 'ReadOnlyAutoProperty' property.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @ReadOnlyAutoProperty = "ReadOnlyAutoProperty";
        /// <summary>
        /// Cached name for the 'ReadOnlyProperty' property.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @ReadOnlyProperty = "ReadOnlyProperty";
        /// <summary>
        /// Cached name for the 'InitOnlyAutoProperty' property.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @InitOnlyAutoProperty = "InitOnlyAutoProperty";
        /// <summary>
        /// Cached name for the 'ReadOnlyField' field.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @ReadOnlyField = "ReadOnlyField";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGulpgulpgulpdotClassPropertyValue(in gulpgulpgulpdot_string_name name, out gulpgulpgulpdot_variant value)
    {
        if (name == PropertyName.@ReadOnlyAutoProperty) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<string>(this.@ReadOnlyAutoProperty);
            return true;
        }
        if (name == PropertyName.@ReadOnlyProperty) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<string>(this.@ReadOnlyProperty);
            return true;
        }
        if (name == PropertyName.@InitOnlyAutoProperty) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<string>(this.@InitOnlyAutoProperty);
            return true;
        }
        if (name == PropertyName.@ReadOnlyField) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<string>(this.@ReadOnlyField);
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
        properties.Add(new(type: (global::Gulpgulpgulpdot.Variant.Type)4, name: PropertyName.@ReadOnlyField, hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Gulpgulpgulpdot.Variant.Type)4, name: PropertyName.@ReadOnlyAutoProperty, hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Gulpgulpgulpdot.Variant.Type)4, name: PropertyName.@ReadOnlyProperty, hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Gulpgulpgulpdot.Variant.Type)4, name: PropertyName.@InitOnlyAutoProperty, hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)4096, exported: false));
        return properties;
    }
#pragma warning restore CS0109
}
