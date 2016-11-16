        ' Disable Option Infer when trying this example.

        Dim someVar = 5
        Console.WriteLine(someVar.GetType.ToString)

        ' If Option Infer is instead enabled, the following
        ' statement causes a run-time error. This is because
        ' someVar was implicitly defined as an integer.
        someVar = "abc"
        Console.WriteLine(someVar.GetType.ToString)

        ' Output:
        '  System.Int32
        '  System.String