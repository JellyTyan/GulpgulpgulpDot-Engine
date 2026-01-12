using Gulpgulpgulpdot;

public partial class AllWriteOnly : GulpgulpgulpdotObject
{
    private bool _writeOnlyBackingField = false;
    public bool WriteOnlyProperty { set => _writeOnlyBackingField = value; }
}
