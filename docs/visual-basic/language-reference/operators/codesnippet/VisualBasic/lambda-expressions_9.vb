        Dim notNothing =
          Function(num? As Integer) num IsNot Nothing
        Dim arg As Integer = 14
        Console.WriteLine("Does the argument have an assigned value?")
        Console.WriteLine(notNothing(arg))