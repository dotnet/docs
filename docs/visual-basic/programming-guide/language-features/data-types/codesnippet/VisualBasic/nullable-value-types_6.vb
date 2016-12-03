        Dim b1? As Boolean
        Dim b2? As Boolean
        b1 = True
        b2 = Nothing

        ' The following If statement displays "Expression is not true".
        If (b1 And b2) Then
            Console.WriteLine("Expression is true")
        Else
            Console.WriteLine("Expression is not true")
        End If

        ' The following If statement displays "Expression is not false".
        If Not (b1 And b2) Then
            Console.WriteLine("Expression is false")
        Else
            Console.WriteLine("Expression is not false")
        End If