        // Get the SOAP action for the method.
        System.Reflection.MethodBase getHelloMethodBase = 
            typeof(ExampleNamespace.ExampleClass).GetMethod("GetHello");
        string getHelloSoapAction =
            SoapServices.GetSoapActionFromMethodBase(getHelloMethodBase);
        Console.WriteLine(
            "The SOAP action for the method " +
            "ExampleClass.GetHello is {0}.", getHelloSoapAction);
        bool isSoapActionValid = SoapServices.IsSoapActionValidForMethodBase(
            getHelloSoapAction,
            getHelloMethodBase);
        if (isSoapActionValid)
        {
            Console.WriteLine(
                "The SOAP action, {0}, " + 
                "is valid for ExampleClass.GetHello", 
                getHelloSoapAction);
        }
        else
        {
            Console.WriteLine(
                "The SOAP action, {0}, " + 
                "is not valid for ExampleClass.GetHello", 
                getHelloSoapAction);
        }

        // Register the SOAP action for the GetHello method.
        SoapServices.RegisterSoapActionForMethodBase(getHelloMethodBase);

        // Get the type and the method names encoded into the SOAP action.
        string encodedTypeName;
        string encodedMethodName;
        SoapServices.GetTypeAndMethodNameFromSoapAction(
            getHelloSoapAction, 
            out encodedTypeName, 
            out encodedMethodName);
        Console.WriteLine(
            "The type name encoded in this SOAP action is {0}.",
            encodedTypeName);
        Console.WriteLine(
            "The method name encoded in this SOAP action is {0}.",
            encodedMethodName);