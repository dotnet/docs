        ' Create local variables named myString and myInt.
        Dim myLB1 As LocalBuilder = myMethodIL.DeclareLocal(GetType(String))
        myLB1.SetLocalSymInfo("myString")
        Console.WriteLine("local 'myString' type is: {0}", myLB1.LocalType)

        Dim myLB2 As LocalBuilder = myMethodIL.DeclareLocal(GetType(Integer))
        myLB2.SetLocalSymInfo("myInt", 1, 2)
        Console.WriteLine("local 'myInt' type is: {0}", myLB2.LocalType)