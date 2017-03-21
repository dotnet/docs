        MyClass1 myClass1 = new MyClass1();
	     // Get the type referenced by the specified type handle.
        Type myClass1Type = Type.GetTypeFromHandle(Type.GetTypeHandle(myClass1));
        Console.WriteLine("The Names of the Attributes :"+myClass1Type.Attributes);