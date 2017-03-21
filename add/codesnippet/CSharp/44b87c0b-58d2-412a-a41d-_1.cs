        // Add parameter information to the dynamic method. (This is not
        // necessary, but can be useful for debugging.) For each parameter,
        // identified by position, supply the parameter attributes and a 
        // parameter name.
        hello.DefineParameter(1, ParameterAttributes.In, "message");
        hello.DefineParameter(2, ParameterAttributes.In, "valueToReturn");