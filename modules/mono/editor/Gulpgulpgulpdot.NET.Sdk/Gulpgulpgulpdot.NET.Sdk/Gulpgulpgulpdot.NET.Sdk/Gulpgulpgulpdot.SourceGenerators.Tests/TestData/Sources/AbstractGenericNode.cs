using Gulpgulpgulpdot;

public abstract partial class AbstractGenericNode<[MustBeVariant] T> : Node
{
    [Export] // This should be included, but without type hints.
    public Gulpgulpgulpdot.Collections.Array<T> MyArray { get; set; } = new();
}
