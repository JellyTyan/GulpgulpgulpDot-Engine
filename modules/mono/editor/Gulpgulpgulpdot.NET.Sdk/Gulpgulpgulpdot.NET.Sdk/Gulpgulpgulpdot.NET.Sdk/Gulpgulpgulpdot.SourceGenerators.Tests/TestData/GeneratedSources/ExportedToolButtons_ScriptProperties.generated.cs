using Gulpgulpgulpdot;
using Gulpgulpgulpdot.NativeInterop;

partial class ExportedToolButtons
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Gulpgulpgulpdot.GulpgulpgulpdotObject.PropertyName {
        /// <summary>
        /// Cached name for the 'MyButton1' property.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @MyButton1 = "MyButton1";
        /// <summary>
        /// Cached name for the 'MyButton2' property.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @MyButton2 = "MyButton2";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGulpgulpgulpdotClassPropertyValue(in gulpgulpgulpdot_string_name name, out gulpgulpgulpdot_variant value)
    {
        if (name == PropertyName.@MyButton1) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<global::Gulpgulpgulpdot.Callable>(this.@MyButton1);
            return true;
        }
        if (name == PropertyName.@MyButton2) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<global::Gulpgulpgulpdot.Callable>(this.@MyButton2);
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
        properties.Add(new(type: (global::Gulpgulpgulpdot.Variant.Type)25, name: PropertyName.@MyButton1, hint: (global::Gulpgulpgulpdot.PropertyHint)39, hintString: "Click me!", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)4, exported: true));
        properties.Add(new(type: (global::Gulpgulpgulpdot.Variant.Type)25, name: PropertyName.@MyButton2, hint: (global::Gulpgulpgulpdot.PropertyHint)39, hintString: "Click me!,ColorRect", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)4, exported: true));
        return properties;
    }
#pragma warning restore CS0109
}
