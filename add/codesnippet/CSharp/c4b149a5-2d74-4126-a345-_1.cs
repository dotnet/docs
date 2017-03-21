        // Get the method base object for the GetHello method.
        System.Reflection.MethodBase methodBase = 
            typeof(ExampleNamespace.ExampleClass).GetMethod("GetHello");

        // Print its current SOAP action.
        Console.WriteLine(
            "The SOAP action for the method " +
            "ExampleClass.GetHello is {0}.",
            SoapServices.GetSoapActionFromMethodBase(methodBase));
        
        // Set the SOAP action of the GetHello method to a new value.
        string newSoapAction = 
            "http://example.org/ExampleSoapAction#NewSoapAction";
        SoapServices.RegisterSoapActionForMethodBase(
            methodBase, newSoapAction);
        Console.WriteLine(
            "The SOAP action for the method " +
            "ExampleClass.GetHello is {0}.",
            SoapServices.GetSoapActionFromMethodBase(methodBase));

        // Reset the SOAP action of the GetHello method to its default
        // value, which is determined using its SoapMethod attribute.
        SoapServices.RegisterSoapActionForMethodBase(methodBase);
        Console.WriteLine(
            "The SOAP action for the method " +
            "ExampleClass.GetHello is {0}.",
            SoapServices.GetSoapActionFromMethodBase(methodBase));