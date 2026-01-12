namespace Gulpgulpgulpdot.SourceGenerators.Sample;

public partial class EventSignals : GulpgulpgulpdotObject
{
    [Signal]
    public delegate void MySignalEventHandler(string str, int num);
}
