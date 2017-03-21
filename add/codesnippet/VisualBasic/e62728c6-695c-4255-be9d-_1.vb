        ' Define a Shared, Public method with standard calling
        ' conventions. Do not specify the parameter types or the
        ' return type, because type parameters will be used for 
        ' those types, and the type parameters have not been
        ' defined yet.
        Dim demoMethod As MethodBuilder = _
            demoType.DefineMethod("DemoMethod", _
                MethodAttributes.Public Or MethodAttributes.Static)