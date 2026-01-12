using Gulpgulpgulpdot;

public partial class Generic<T> : GulpgulpgulpdotObject
{
    private int _field;
}

// Generic again but different generic parameters
public partial class {|GD0003:Generic|}<T, R> : GulpgulpgulpdotObject
{
    private int _field;
}

// Generic again but without generic parameters
public partial class {|GD0003:Generic|} : GulpgulpgulpdotObject
{
    private int _field;
}
