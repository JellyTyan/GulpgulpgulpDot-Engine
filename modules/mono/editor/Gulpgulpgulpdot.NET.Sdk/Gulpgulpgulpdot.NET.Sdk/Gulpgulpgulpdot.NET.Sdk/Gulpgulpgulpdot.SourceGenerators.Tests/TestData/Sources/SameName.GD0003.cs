using Gulpgulpgulpdot;

namespace NamespaceA
{
    partial class SameName : GulpgulpgulpdotObject
    {
        private int _field;
    }
}

// SameName again but different namespace
namespace NamespaceB
{
    partial class {|GD0003:SameName|} : GulpgulpgulpdotObject
    {
        private int _field;
    }
}
