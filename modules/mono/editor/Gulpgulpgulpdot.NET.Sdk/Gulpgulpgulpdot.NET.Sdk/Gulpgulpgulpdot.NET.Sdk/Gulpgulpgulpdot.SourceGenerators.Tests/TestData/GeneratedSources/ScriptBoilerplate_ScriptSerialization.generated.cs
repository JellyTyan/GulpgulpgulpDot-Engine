using Gulpgulpgulpdot;
using Gulpgulpgulpdot.NativeInterop;

partial class ScriptBoilerplate
{
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void SaveGulpgulpgulpdotObjectData(global::Gulpgulpgulpdot.Bridge.GulpgulpgulpdotSerializationInfo info)
    {
        base.SaveGulpgulpgulpdotObjectData(info);
        info.AddProperty(PropertyName.@_nodePath, global::Gulpgulpgulpdot.Variant.From<global::Gulpgulpgulpdot.NodePath>(this.@_nodePath));
        info.AddProperty(PropertyName.@_velocity, global::Gulpgulpgulpdot.Variant.From<int>(this.@_velocity));
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void RestoreGulpgulpgulpdotObjectData(global::Gulpgulpgulpdot.Bridge.GulpgulpgulpdotSerializationInfo info)
    {
        base.RestoreGulpgulpgulpdotObjectData(info);
        if (info.TryGetProperty(PropertyName.@_nodePath, out var _value__nodePath))
            this.@_nodePath = _value__nodePath.As<global::Gulpgulpgulpdot.NodePath>();
        if (info.TryGetProperty(PropertyName.@_velocity, out var _value__velocity))
            this.@_velocity = _value__velocity.As<int>();
    }
}
