        // Set parameter types for the method. The method takes
        // one parameter, and its type is specified by the first
        // type parameter, T.
        Type[] parms = {typeParameters[0]};
        demoMethod.SetParameters(parms);

        // Set the return type for the method. The return type is
        // specified by the second type parameter, U.
        demoMethod.SetReturnType(typeParameters[1]);