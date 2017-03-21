        // For dynamic methods, the reflected type is always null.
        if (hello.ReflectedType == null)
        {
            Console.WriteLine("\r\nReflectedType is null.");
        }
        else
        {
            Console.WriteLine("\r\nReflectedType: {0}", hello.ReflectedType);
        }