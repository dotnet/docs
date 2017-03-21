        // Display the declaring type, which is always null for dynamic
        // methods.
        if (hello.DeclaringType == null)
        {
            Console.WriteLine("\r\nDeclaringType is always null for dynamic methods.");
        }
        else
        {
            Console.WriteLine("DeclaringType: {0}", hello.DeclaringType);
        }