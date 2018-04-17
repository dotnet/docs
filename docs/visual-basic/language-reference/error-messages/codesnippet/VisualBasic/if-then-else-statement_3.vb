Module SingleLine
    Public Sub Main()

        'Create a Random object to seed our starting values 
        Dim randomizer As New Random()

        Dim A As Integer = randomizer.Next(10, 20)
        Dim B As Integer = randomizer.Next(0, 20)
        Dim C As Integer = randomizer.Next(0, 5)

        'Let's display the initial values for comparison
        Console.WriteLine($"A value before If: {A}")
        Console.WriteLine($"B value before If: {B}")
        Console.WriteLine($"C value before If: {C}")

        ' If A > 10, execute the three colon-separated statements in the order
        ' that they appear
        If A > 10 Then A = A + 1 : B = B + A : C = C + B

        'If the condition is true, the values will be different
        Console.WriteLine($"A value after If: {A}")
        Console.WriteLine($"B value after If: {B}")
        Console.WriteLine($"C value after If: {C}")

    End Sub
End Module
'This example displays output like the following:
'A value before If: 11
'B value before If: 6
'C value before If: 3
'A value after If: 12
'B value after If: 18
'C value after If: 21