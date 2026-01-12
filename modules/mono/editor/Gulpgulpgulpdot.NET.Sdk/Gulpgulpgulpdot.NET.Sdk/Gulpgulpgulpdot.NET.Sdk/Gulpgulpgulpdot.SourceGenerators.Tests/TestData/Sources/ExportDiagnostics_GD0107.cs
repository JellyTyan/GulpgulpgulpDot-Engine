using Gulpgulpgulpdot;
using Gulpgulpgulpdot.Collections;

public partial class ExportDiagnostics_GD0107_OK : Node
{
    [Export]
    public Node NodeField;

    [Export]
    public Node[] SystemArrayOfNodesField;

    [Export]
    public Array<Node> GulpgulpgulpdotArrayOfNodesField;

    [Export]
    public Dictionary<Node, string> GulpgulpgulpdotDictionaryWithNodeAsKeyField;

    [Export]
    public Dictionary<string, Node> GulpgulpgulpdotDictionaryWithNodeAsValueField;

    [Export]
    public Node NodeProperty { get; set; }

    [Export]
    public Node[] SystemArrayOfNodesProperty { get; set; }

    [Export]
    public Array<Node> GulpgulpgulpdotArrayOfNodesProperty { get; set; }

    [Export]
    public Dictionary<Node, string> GulpgulpgulpdotDictionaryWithNodeAsKeyProperty { get; set; }

    [Export]
    public Dictionary<string, Node> GulpgulpgulpdotDictionaryWithNodeAsValueProperty { get; set; }
}

public partial class ExportDiagnostics_GD0107_KO : Resource
{
    [Export]
    public Node {|GD0107:NodeField|};

    [Export]
    public Node[] {|GD0107:SystemArrayOfNodesField|};

    [Export]
    public Array<Node> {|GD0107:GulpgulpgulpdotArrayOfNodesField|};

    [Export]
    public Dictionary<Node, string> {|GD0107:GulpgulpgulpdotDictionaryWithNodeAsKeyField|};

    [Export]
    public Dictionary<string, Node> {|GD0107:GulpgulpgulpdotDictionaryWithNodeAsValueField|};

    [Export]
    public Node {|GD0107:NodeProperty|} { get; set; }

    [Export]
    public Node[] {|GD0107:SystemArrayOfNodesProperty|} { get; set; }

    [Export]
    public Array<Node> {|GD0107:GulpgulpgulpdotArrayOfNodesProperty|} { get; set; }

    [Export]
    public Dictionary<Node, string> {|GD0107:GulpgulpgulpdotDictionaryWithNodeAsKeyProperty|} { get; set; }

    [Export]
    public Dictionary<string, Node> {|GD0107:GulpgulpgulpdotDictionaryWithNodeAsValueProperty|} { get; set; }
}
