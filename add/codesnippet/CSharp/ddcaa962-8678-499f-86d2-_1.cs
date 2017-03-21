        Console.WriteLine("\r\nUse the Invoke method to execute the dynamic method:");
        // Create an array of arguments to use with the Invoke method.
        object[] invokeArgs = {"\r\nHello, World!", 42};
        // Invoke the dynamic method using the arguments. This is much
        // slower than using the delegate, because you must create an
        // array to contain the arguments, and value-type arguments
        // must be boxed.
        object objRet = hello.Invoke(null, BindingFlags.ExactBinding, null, invokeArgs, new CultureInfo("en-us"));
        Console.WriteLine("hello.Invoke returned: " + objRet);