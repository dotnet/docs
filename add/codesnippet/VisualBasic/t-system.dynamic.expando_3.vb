        sampleObject.Number = 10
        sampleObject.Increment = Function() sampleObject.Number + 1
        ' Before calling the Increment method.
        Console.WriteLine(sampleObject.number)

        sampleObject.Increment.Invoke()

        ' After calling the Increment method.
        Console.WriteLine(sampleObject.number)
        ' This code example produces the following output:
        ' 10
        ' 11