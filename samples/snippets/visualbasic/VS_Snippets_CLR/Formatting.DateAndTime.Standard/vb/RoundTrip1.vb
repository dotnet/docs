' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module Example
    Public Sub Main()
        ' <Snippet16>      
        ' Round-trip DateTime values.
        Dim originalDate, newDate As Date
        Dim dateString As String
        ' Round-trip a local time.
        originalDate = Date.SpecifyKind(#4/10/2008 6:30AM#, DateTimeKind.Local)
        dateString = originalDate.ToString("o")
        newDate = Date.Parse(dateString, Nothing, DateTimeStyles.RoundtripKind)
        Console.WriteLine("Round-tripped {0} {1} to {2} {3}.", originalDate, originalDate.Kind, _
                          newDate, newDate.Kind)
        ' Round-trip a UTC time.
        originalDate = Date.SpecifyKind(#4/12/2008 9:30AM#, DateTimeKind.Utc)
        dateString = originalDate.ToString("o")
        newDate = Date.Parse(dateString, Nothing, DateTimeStyles.RoundtripKind)
        Console.WriteLine("Round-tripped {0} {1} to {2} {3}.", originalDate, originalDate.Kind, _
                          newDate, newDate.Kind)
        ' Round-trip time in an unspecified time zone.
        originalDate = Date.SpecifyKind(#4/13/2008 12:30PM#, DateTimeKind.Unspecified)
        dateString = originalDate.ToString("o")
        newDate = Date.Parse(dateString, Nothing, DateTimeStyles.RoundtripKind)
        Console.WriteLine("Round-tripped {0} {1} to {2} {3}.", originalDate, originalDate.Kind, _
                          newDate, newDate.Kind)

        ' Round-trip a DateTimeOffset value.
        Dim originalDTO As New DateTimeOffset(#4/12/2008 9:30AM#, New TimeSpan(-8, 0, 0))
        dateString = originalDTO.ToString("o")
        Dim newDTO As DateTimeOffset = DateTimeOffset.Parse(dateString, Nothing, DateTimeStyles.RoundtripKind)
        Console.WriteLine("Round-tripped {0} to {1}.", originalDTO, newDTO)
        ' The example displays the following output:
        '    Round-tripped 4/10/2008 6:30:00 AM Local to 4/10/2008 6:30:00 AM Local.
        '    Round-tripped 4/12/2008 9:30:00 AM Utc to 4/12/2008 9:30:00 AM Utc.
        '    Round-tripped 4/13/2008 12:30:00 PM Unspecified to 4/13/2008 12:30:00 PM Unspecified.
        '    Round-tripped 4/12/2008 9:30:00 AM -08:00 to 4/12/2008 9:30:00 AM -08:00.
        ' </Snippet16>                                    
    End Sub
End Module

