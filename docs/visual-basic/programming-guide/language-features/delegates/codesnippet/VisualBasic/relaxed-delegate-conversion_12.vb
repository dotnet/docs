    ' Definition of Sub delegate Del3.
    Delegate Sub Del3(ByVal arg1 As Integer)

    ' Definition of function doubler, which both displays and returns the
    ' value of its integer parameter.
    Function doubler(ByVal p As Integer) As Integer
        Dim times2 = 2 * p
        Console.WriteLine("Value of p: " & p)
        Console.WriteLine("Double p:   " & times2)
        Return times2
    End Function