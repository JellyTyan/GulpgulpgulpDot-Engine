using Gulpgulpgulpdot;
using Gulpgulpgulpdot.NativeInterop;

partial class AbstractGenericNode<T>
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Gulpgulpgulpdot.Node.PropertyName {
        /// <summary>
        /// Cached name for the 'MyArray' property.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @MyArray = "MyArray";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGulpgulpgulpdotClassPropertyValue(in gulpgulpgulpdot_string_name name, in gulpgulpgulpdot_variant value)
    {
        if (name == PropertyName.@MyArray) {
            this.@MyArray = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.ConvertToArray<T>(value);
            return true;
        }
        return base.SetGulpgulpgulpdotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGulpgulpgulpdotClassPropertyValue(in gulpgulpgulpdot_string_name name, out gulpgulpgulpdot_variant value)
    {
        if (name == PropertyName.@MyArray) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFromArray(this.@MyArray);
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
        properties.Add(new(type: (global::Gulpgulpgulpdot.Variant.Type)28, name: PropertyName.@MyArray, hint: (global::Gulpgulpgulpdot.PropertyHint)0, hintString: "", usage: (global::Gulpgulpgulpdot.PropertyUsageFlags)4102, exported: true));
        return properties;
    }
#pragma warning restore CS0109
}
