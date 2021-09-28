' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Module IntervalArithmetic
    Public Sub Main()
        Dim generalTime As Date = #03/09/2008 1:30AM#
        Const tzName As String = "Central Standard Time"
        Dim twoAndAHalfHours As New TimeSpan(2, 30, 0)

        ' Instantiate DateTimeOffset value to have correct CST offset
        Try
            Dim centralTime1 As New DateTimeOffset(generalTime, _
                       TimeZoneInfo.FindSystemTimeZoneById(tzName).GetUtcOffset(generalTime))

            ' Add two and a half hours      
            Dim centralTime2 As DateTimeOffset = centralTime1.Add(twoAndAHalfHours)
            ' Display result
            Console.WriteLine("{0} + {1} hours = {2}", centralTime1, _
                                                       twoAndAHalfHours.ToString(), _
                                                       centralTime2)
        Catch e As TimeZoneNotFoundException
            Console.WriteLine("Unable to retrieve Central Standard Time zone information.")
        End Try
    End Sub
End Module
' The example displays the following output to the console:
'    3/9/2008 1:30:00 AM -06:00 + 02:30:00 hours = 3/9/2008 4:00:00 AM -06:00
' </Snippet4>

