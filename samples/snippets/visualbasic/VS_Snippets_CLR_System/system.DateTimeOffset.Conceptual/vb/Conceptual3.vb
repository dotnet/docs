' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Public Enum TimeComparison As Integer
    EarlierThan = -1
    TheSameAs = 0
    LaterThan = 1
End Enum

Module DateTimeOffsetManipulation
    Public Sub Main()
        Dim localTime As DateTimeOffset = DateTimeOffset.Now
        Dim utcTime As DateTimeOffset = DateTimeOffset.UtcNow

        Console.WriteLine("Difference between local time and UTC: {0}:{1:D2} hours.", _
                          (localTime - utcTime).Hours, _
                          (localTime - utcTime).Minutes)
        Console.WriteLine("The local time is {0} UTC.", _
                          [Enum].GetName(GetType(TimeComparison), localTime.CompareTo(utcTime)))
    End Sub
End Module
' Regardless of the local time zone, the example displays 
' the following output to the console:
'    Difference between local time and UTC: 0:00 hours.
'    The local time is TheSameAs UTC.
'          Console.WriteLine(e.GetType().Name)
' </Snippet3>

