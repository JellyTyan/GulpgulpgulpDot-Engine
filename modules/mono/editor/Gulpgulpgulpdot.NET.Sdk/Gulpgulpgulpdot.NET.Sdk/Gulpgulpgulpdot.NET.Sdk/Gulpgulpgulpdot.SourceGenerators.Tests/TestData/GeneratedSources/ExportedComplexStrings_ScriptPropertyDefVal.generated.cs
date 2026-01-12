partial class ExportedComplexStrings
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
#if TOOLS
    /// <summary>
    /// Get the default values for all properties declared in this class.
    /// This method is used by Gulpgulpgulpdot to determine the value that will be
    /// used by the inspector when resetting properties.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.Dictionary<global::Gulpgulpgulpdot.StringName, global::Gulpgulpgulpdot.Variant> GetGulpgulpgulpdotPropertyDefaultValues()
    {
        var values = new global::System.Collections.Generic.Dictionary<global::Gulpgulpgulpdot.StringName, global::Gulpgulpgulpdot.Variant>(5);
        string __PropertyInterpolated1_default_value = $"The quick brown fox jumps over {(global::Gulpgulpgulpdot.GD.VarToStr($"the lazy {(global::Gulpgulpgulpdot.Engine.GetVersionInfo())} do"))}g.";
        values.Add(PropertyName.@PropertyInterpolated1, global::Gulpgulpgulpdot.Variant.From<string>(__PropertyInterpolated1_default_value));
        string ___fieldInterpolated1_default_value = $"The quick brown fox jumps over ({(global::Gulpgulpgulpdot.Engine.GetVersionInfo())})";
        values.Add(PropertyName.@_fieldInterpolated1, global::Gulpgulpgulpdot.Variant.From<string>(___fieldInterpolated1_default_value));
        string ___fieldInterpolated2_default_value = $"The quick brown fox jumps over ({(global::Gulpgulpgulpdot.Engine.GetVersionInfo()["major"]),0:G}) the lazy dog.";
        values.Add(PropertyName.@_fieldInterpolated2, global::Gulpgulpgulpdot.Variant.From<string>(___fieldInterpolated2_default_value));
        string ___fieldInterpolated3_default_value = $"{(((int)global::Gulpgulpgulpdot.Engine.GetVersionInfo()["major"])  * -1    * -1):G} the lazy dog.";
        values.Add(PropertyName.@_fieldInterpolated3, global::Gulpgulpgulpdot.Variant.From<string>(___fieldInterpolated3_default_value));
        string ___fieldInterpolated4_default_value = $"{(":::fff,,}<,<}},,}]")}";
        values.Add(PropertyName.@_fieldInterpolated4, global::Gulpgulpgulpdot.Variant.From<string>(___fieldInterpolated4_default_value));
        return values;
    }
#endif // TOOLS
#pragma warning restore CS0109
}
