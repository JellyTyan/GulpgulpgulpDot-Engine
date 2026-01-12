using System;

namespace Gulpgulpgulpdot.SourceGenerators.Sample;

public partial class NestedClass : GulpgulpgulpdotObject
{
    public partial class NestedClass2 : GulpgulpgulpdotObject
    {
        public partial class NestedClass3 : GulpgulpgulpdotObject
        {
            [Signal]
            public delegate void MySignalEventHandler(string str, int num);

            [Export] private String _fieldString = "foo";
            [Export] private String PropertyString { get; set; } = "foo";

            private void Method()
            {
            }
        }
    }
}
