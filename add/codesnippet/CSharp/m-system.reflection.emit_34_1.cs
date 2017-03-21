        // Create local variables named myString and myInt.
        LocalBuilder myLB1 = myMethodIL.DeclareLocal(typeof(string));
        myLB1.SetLocalSymInfo("myString");
        Console.WriteLine("local 'myString' type is: {0}", myLB1.LocalType);

        LocalBuilder myLB2 = myMethodIL.DeclareLocal(typeof(int));
        myLB2.SetLocalSymInfo("myInt", 1, 2);
        Console.WriteLine("local 'myInt' type is: {0}", myLB2.LocalType);