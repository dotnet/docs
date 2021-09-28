' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Public Structure TimeZoneTime
    Public TimeZone As TimeZoneInfo
    Public Time As DateTimeOffset

    Public Sub New(tz As TimeZoneInfo, time As DateTimeOffset)
        If tz Is Nothing Then _
           Throw New ArgumentNullException("The time zone cannot be a null reference.")

        Me.TimeZone = tz
        Me.Time = time
    End Sub

    Public Function AddTime(interval As TimeSpan) As TimeZoneTime
        ' Convert time to UTC
        Dim utcTime As DateTimeOffset = TimeZoneInfo.ConvertTime(Me.Time, TimeZoneInfo.Utc)
        ' Add time interval to time
        utcTime = utcTime.Add(interval)
        ' Convert time back to time in time zone
        Return New TimeZoneTime(Me.TimeZone, TimeZoneInfo.ConvertTime(utcTime, Me.TimeZone))
    End Function
End Structure

Module TimeArithmetic
    Public Const tzName As String = "Central Standard Time"

    Public Sub Main()
        Try
            Dim cstTime1, cstTime2 As TimeZoneTime

            Dim cst As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(tzName)
            Dim time1 As Date = #03/09/2008 1:30AM#
            Dim twoAndAHalfHours As New TimeSpan(2, 30, 0)

            cstTime1 = New TimeZoneTime(cst, _
                           New DateTimeOffset(time1, cst.GetUtcOffset(time1)))
            cstTime2 = cstTime1.AddTime(twoAndAHalfHours)

            Console.WriteLine("{0} + {1} hours = {2}", cstTime1.Time, _
                                                       twoAndAHalfHours.ToString(), _
                                                       cstTime2.Time)
        Catch
            Console.WriteLine("Unable to find {0}.", tzName)
        End Try
    End Sub
End Module
' </Snippet7>


' <Snippet6>
' Define a structure for DateTime values for internal use only
Friend Structure TimeWithTimeZone
    Dim TimeZone As TimeZoneInfo
    Dim Time As Date
End Structure
' </Snippet6>
