using Gulpgulpgulpdot;

// This works because it inherits from GulpgulpgulpdotObject and it doesn't have any generic type parameter.
[GlobalClass]
public partial class CustomGlobalClass : GulpgulpgulpdotObject
{

}

// This raises a GD0402 diagnostic error: global classes can't have any generic type parameter
[GlobalClass]
public partial class {|GD0402:CustomGlobalClass|}<T> : GulpgulpgulpdotObject
{

}
