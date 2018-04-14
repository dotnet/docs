Module Multiline
    Public Sub Main()
        'Create a Random object to seed our starting value 
        Dim randomizer As New Random()
        'set our variable
        Dim count As Integer = randomizer.Next(0, 5)

        Dim message As String

        If count = 0 Then
            message = "There are no items."
        ElseIf count = 1 Then
            message = "There is 1 item."
        Else
            message = $"There are {count} items."
        End If

        Console.WriteLine(message)
    End Sub
End Module