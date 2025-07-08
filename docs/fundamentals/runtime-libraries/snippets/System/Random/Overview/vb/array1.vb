' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Module Example1
    Public Sub Main()
        Dim cities() As String = {"Atlanta", "Boston", "Chicago", "Detroit",
                                 "Fort Wayne", "Greensboro", "Honolulu", "Indianapolis",
                                 "Jersey City", "Kansas City", "Los Angeles",
                                 "Milwaukee", "New York", "Omaha", "Philadelphia",
                                 "Raleigh", "San Francisco", "Tulsa", "Washington"}
        Dim rnd As New Random()
        Dim index As Integer = rnd.Next(0, cities.Length)
        Console.WriteLine("Today's city of the day: {0}",
                        cities(index))
    End Sub
End Module
' The example displays output like the following:
'   Today's city of the day: Honolulu
' </Snippet10>
