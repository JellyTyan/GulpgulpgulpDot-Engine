using Gulpgulpgulpdot;

// This works because it inherits from GulpgulpgulpdotObject.
[GlobalClass]
public partial class CustomGlobalClass1 : GulpgulpgulpdotObject
{

}

// This works because it inherits from an object that inherits from GulpgulpgulpdotObject
[GlobalClass]
public partial class CustomGlobalClass2 : Node
{

}

// This raises a GD0401 diagnostic error: global classes must inherit from GulpgulpgulpdotObject
[GlobalClass]
public partial class {|GD0401:CustomGlobalClass3|}
{

}
