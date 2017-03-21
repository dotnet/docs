 ' Get the set of methods associated with the type
 Dim mi As MemberInfo() = _
    GetType(Application).FindMembers( _
    MemberTypes.Constructor Or MemberTypes.Method, _
    BindingFlags.DeclaredOnly, _
    Type.FilterName, "*")
 Console.WriteLine("Number of methods (includes constructors): " & _
    mi.Length.ToString())