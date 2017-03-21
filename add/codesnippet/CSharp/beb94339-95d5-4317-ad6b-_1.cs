        // Print the XML namespace for a method invocation and its
        // response.
        System.Reflection.MethodBase getHelloMethod = 
            typeof(ExampleNamespace.ExampleClass).GetMethod("GetHello");
        string methodCallXmlNamespace = 
            SoapServices.GetXmlNamespaceForMethodCall(getHelloMethod);
        string methodResponseXmlNamespace =
            SoapServices.GetXmlNamespaceForMethodResponse(getHelloMethod);
        Console.WriteLine(
            "The XML namespace for the invocation of the method " +
            "GetHello in ExampleClass is {0}.",
            methodResponseXmlNamespace);
        Console.WriteLine(
            "The XML namespace for the response of the method " +
            "GetHello in ExampleClass is {0}.",
            methodCallXmlNamespace);