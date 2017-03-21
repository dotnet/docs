        // Defining generic parameters for the method makes it a
        // generic method. By convention, type parameters are 
        // single alphabetic characters. T and U are used here.
        //
        string[] typeParamNames = {"T", "U"};
        GenericTypeParameterBuilder[] typeParameters = 
            demoMethod.DefineGenericParameters(typeParamNames);

        // The second type parameter is constrained to be a 
        // reference type.
        typeParameters[1].SetGenericParameterAttributes( 
            GenericParameterAttributes.ReferenceTypeConstraint);