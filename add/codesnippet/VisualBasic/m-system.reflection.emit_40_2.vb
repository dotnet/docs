        ' Set parameter types for the method. The method takes
        ' one parameter, and its type is specified by the first
        ' type parameter, T.
        Dim params() As Type = {typeParameters(0)}
        demoMethod.SetParameters(params)

        ' Set the return type for the method. The return type is
        ' specified by the second type parameter, U.
        demoMethod.SetReturnType(typeParameters(1))