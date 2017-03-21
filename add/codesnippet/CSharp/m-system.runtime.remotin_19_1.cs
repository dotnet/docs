        // Register all types in the assembly with the SoapType attribute.
        System.Reflection.Assembly executingAssembly =
            System.Reflection.Assembly.GetExecutingAssembly();
        SoapServices.PreLoad(executingAssembly);