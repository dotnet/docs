        // Create an instance of an unmanged COM object.
        UnmanagedComClass UnmanagedComClassInstance = new UnmanagedComClass();

        // Create a string to pass to the COM object.
        string helloString = "Hello World!";

        // Wrap the string with the VariantWrapper class.
        object var = new System.Runtime.InteropServices.VariantWrapper(helloString);

        // Pass the wrapped object.
        UnmanagedComClassInstance.MethodWithStringRefParam(ref var);