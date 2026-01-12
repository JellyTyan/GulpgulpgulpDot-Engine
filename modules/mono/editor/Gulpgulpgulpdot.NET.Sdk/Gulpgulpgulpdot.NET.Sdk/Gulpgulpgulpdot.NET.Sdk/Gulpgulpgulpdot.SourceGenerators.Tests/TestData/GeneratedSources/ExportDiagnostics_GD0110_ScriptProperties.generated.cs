using Gulpgulpgulpdot;
using Gulpgulpgulpdot.NativeInterop;

partial class ExportDiagnostics_GD0110
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Gulpgulpgulpdot.Node.PropertyName {
        /// <summary>
        /// Cached name for the 'MyButton' property.
        /// </summary>
        public new static readonly global::Gulpgulpgulpdot.StringName @MyButton = "MyButton";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGulpgulpgulpdotClassPropertyValue(in gulpgulpgulpdot_string_name name, out gulpgulpgulpdot_variant value)
    {
        if (name == PropertyName.@MyButton) {
            value = global::Gulpgulpgulpdot.NativeInterop.VariantUtils.CreateFrom<int>(this.@MyButton);
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
        return properties;
    }
#pragma warning restore CS0109
}
