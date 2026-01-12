using Gulpgulpgulpdot;

public partial class AllReadOnly : GulpgulpgulpdotObject
{
    public readonly string ReadOnlyField = "foo";
    public string ReadOnlyAutoProperty { get; } = "foo";
    public string ReadOnlyProperty { get => "foo"; }
    public string InitOnlyAutoProperty { get; init; }
}
