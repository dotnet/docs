Module Multiline
    Public Sub Main()
        'Create a Random object to seed our starting value 
        Dim randomizer As New Random()
        'set our variable
        Dim count As Integer = randomizer.Next(0, 5)

        Dim message As String

        'If count is zero, output will be no items
        If count = 0 Then
            message = "There are no items."
        'If count is 1, output will be "There is 1 item.".        
        ElseIf count = 1 Then
            message = "There is 1 item."
        'If count is greater than 1, output will be "There are {count} items.", where {count} is replaced by the value of count. 
        Else
            message = $"There are {count} items."
        End If

        Console.WriteLine(message)
    End Sub
End Module
'This example displays output like the following:
' There are 4 items.
