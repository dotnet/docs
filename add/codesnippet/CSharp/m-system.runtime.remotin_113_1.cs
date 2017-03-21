        // Register a specific type with the SoapType attribute.
        Type exampleType = typeof(ExampleNamespace.ExampleClass);
        SoapServices.PreLoad(exampleType);