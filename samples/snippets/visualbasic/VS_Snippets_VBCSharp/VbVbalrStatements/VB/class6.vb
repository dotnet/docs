Public Class Class6
    ' 790068a2-1307-4e28-8a72-be5ebda099e9
    ' If...Then...Else Statement (Visual Basic)

    Private Function Multiline() As String
        '<Snippet101>
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

        'This example displays output like the following:
        ' There are 4 items.
        '</Snippet101>
        Return message
    End Function

    '<Snippet102>
    Public Sub Main()
        ' Run the function as part of the WriteLine output.
        Console.WriteLine("Time Check is " & CheckIfTime() & ".")
    End Sub

    Private Function CheckIfTime() As Boolean
        ' Determine the current day of week and hour of day.
        Dim dayW As DayOfWeek = DateTime.Now.DayOfWeek
        Dim hour As Integer = DateTime.Now.Hour

        ' Return True if Wednesday from 2 to 3:59 P.M.,
        ' or if Thursday from noon to 12:59 P.M.
        If dayW = DayOfWeek.Wednesday Then
            If hour = 14 Or hour = 15 Then
                Return True
            Else
                Return False
            End If
        ElseIf dayW = DayOfWeek.Thursday Then
            If hour = 12 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    'This example displays output like the following:
    'Time Check is False.
    '</Snippet102>

    '<Snippet103>
    Private Sub SingleLine()

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

    'This example displays output like the following:
    'A value before If: 11
    'B value before If: 6
    'C value before If: 3
    'A value after If: 12
    'B value after If: 18
    'C value after If: 21
    '</Snippet103>

End Class
