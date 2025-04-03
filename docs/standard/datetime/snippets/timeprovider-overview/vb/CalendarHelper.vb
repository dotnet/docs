'<CalendarHelper>
Public Module CalendarHelper

    ReadOnly MoonLandingDateTime As DateTimeOffset = #7/20/1969 20:17:40#

    Public Sub SendGreeting(currentTime As TimeProvider, name As String)

        Dim localTime As DateTimeOffset = currentTime.GetLocalNow()

        Console.WriteLine($"Good morning, {name}!")
        Console.WriteLine($"The date is {localTime.Date:d} and the day is {localTime.Date.DayOfWeek}.")

        If (localTime.Date.Month = MoonLandingDateTime.Date.Month _
            And localTime.Date.Day = MoonLandingDateTime.Date.Day) Then

            Console.WriteLine("Did you know that on this day in 1969 humans landed on the Moon?")
        End If

        Console.WriteLine($"I hope you enjoy your day!")

    End Sub

End Module
'</CalendarHelper>
