using Gulpgulpgulpdot;
using Gulpgulpgulpdot.NativeInterop;

partial class ExportDiagnostics_GD0111
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Gulpgulpgulpdot.Node.PropertyName {
        /// <summary>
        /// Cached name for the 'MyButtonGet' property.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @MyButtonGet = "MyButtonGet";
        /// <summary>
        /// Cached name for the 'MyButtonGetSet' property.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @MyButtonGetSet = "MyButtonGetSet";
        /// <summary>
        /// Cached name for the 'MyButtonGetWithBackingField' property.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @MyButtonGetWithBackingField = "MyButtonGetWithBackingField";
        /// <summary>
        /// Cached name for the 'MyButtonGetSetWithBackingField' property.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @MyButtonGetSetWithBackingField = "MyButtonGetSetWithBackingField";
        /// <summary>
        /// Cached name for the 'MyButtonOkWithCallableCreationExpression' property.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @MyButtonOkWithCallableCreationExpression = "MyButtonOkWithCallableCreationExpression";
        /// <summary>
        /// Cached name for the 'MyButtonOkWithImplicitCallableCreationExpression' property.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @MyButtonOkWithImplicitCallableCreationExpression = "MyButtonOkWithImplicitCallableCreationExpression";
        /// <summary>
        /// Cached name for the 'MyButtonOkWithCallableFromExpression' property.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @MyButtonOkWithCallableFromExpression = "MyButtonOkWithCallableFromExpression";
        /// <summary>
        /// Cached name for the '_backingField' field.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @_backingField = "_backingField";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGulpgulpgulpdotClassPropertyValue(in gulpgulpgulpdot_string_name name, in gulpgulpgulpdot_variant value)
    {
        if (name == PropertyName.@MyButtonGetSet) {
            this.@MyButtonGetSet = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.ConvertTo<global::Gulpgulpgulpdot.Callable>(value);
            return true;
        }
        if (name == PropertyName.@MyButtonGetSetWithBackingField) {
            this.@MyButtonGetSetWithBackingField = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.ConvertTo<global::Gulpgulpgulpdot.Callable>(value);
            return true;
        }
        if (name == PropertyName.@_backingField) {
            this.@_backingField = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.ConvertTo<global::Gulpgulpgulpdot.Callable>(value);
            return true;
        }
        return base.SetGulpgulpgulpdotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGulpgulpgulpdotClassPropertyValue(in gulpgulpgulpdot_string_name name, out gulpgulpgulpdot_variant value)
    {
        if (name == PropertyName.@MyButtonGet) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<global::Gulpgulpgulpdot.Callable>(this.@MyButtonGet);
            return true;
        }
        if (name == PropertyName.@MyButtonGetSet) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<global::Gulpgulpgulpdot.Callable>(this.@MyButtonGetSet);
            return true;
        }
        if (name == PropertyName.@MyButtonGetWithBackingField) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<global::Gulpgulpgulpdot.Callable>(this.@MyButtonGetWithBackingField);
            return true;
        }
        if (name == PropertyName.@MyButtonGetSetWithBackingField) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<global::Gulpgulpgulpdot.Callable>(this.@MyButtonGetSetWithBackingField);
            return true;
        }
        if (name == PropertyName.@MyButtonOkWithCallableCreationExpression) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<global::Gulpgulpgulpdot.Callable>(this.@MyButtonOkWithCallableCreationExpression);
            return true;
        }
        if (name == PropertyName.@MyButtonOkWithImplicitCallableCreationExpression) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<global::Gulpgulpgulpdot.Callable>(this.@MyButtonOkWithImplicitCallableCreationExpression);
            return true;
        }
        if (name == PropertyName.@MyButtonOkWithCallableFromExpression) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<global::Gulpgulpgulpdot.Callable>(this.@MyButtonOkWithCallableFromExpression);
            return true;
        }
        if (name == PropertyName.@_backingField) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<global::Gulpgulpgulpdot.Callable>(this.@_backingField);
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
        properties.Add(new(type: (global::Gulpgulpgulpdot.Variant.Type)25, name: PropertyName.@_backingField, hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Gulpgulpgulpdot.Variant.Type)25, name: PropertyName.@MyButtonOkWithCallableCreationExpression, hint: (global::Gulpgulpgulpdot.PropertyHint)39, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)4, exported: true));
        properties.Add(new(type: (global::Gulpgulpgulpdot.Variant.Type)25, name: PropertyName.@MyButtonOkWithImplicitCallableCreationExpression, hint: (global::Gulpgulpgulpdot.PropertyHint)39, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)4, exported: true));
        properties.Add(new(type: (global::Gulpgulpgulpdot.Variant.Type)25, name: PropertyName.@MyButtonOkWithCallableFromExpression, hint: (global::Gulpgulpgulpdot.PropertyHint)39, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)4, exported: true));
        return properties;
    }
#pragma warning restore CS0109
}
