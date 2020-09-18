    Public Sub Method(ByVal condition1 As Boolean, ByVal condition2 As Boolean)
        If (condition1 OrElse condition2) Then
            Console.WriteLine("Hello World!")
        End If
    End Sub