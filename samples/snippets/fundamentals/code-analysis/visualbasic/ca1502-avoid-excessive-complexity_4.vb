    Public Sub Method(ByVal day As DayOfWeek)
        Select Case day
            Case DayOfWeek.Monday
                Console.WriteLine("Today is Monday!")
            Case DayOfWeek.Tuesday
                Console.WriteLine("Today is Tuesday!")
            Case DayOfWeek.Wednesday
                Console.WriteLine("Today is Wednesday!")
            Case DayOfWeek.Thursday
                Console.WriteLine("Today is Thursday!")
            Case DayOfWeek.Friday
                Console.WriteLine("Today is Friday!")
            Case DayOfWeek.Saturday
                Console.WriteLine("Today is Saturday!")
            Case DayOfWeek.Sunday
                Console.WriteLine("Today is Sunday!")
        End Select
    End Sub
