' Visual Basic .NET Document
'
' Note that code is VS TimeSpan project directory has debugging information.

Option Strict On

' <Snippet1>
Public Structure StoreInfo
    Dim store As String
    Dim tz As TimeZoneInfo
    Dim open As TimeSpan
    Dim close As TimeSpan

    Public Function IsOpenNow() As Boolean
        Return IsOpenAt(Date.Now.TimeOfDay)
    End Function

    Public Function IsOpenAt(time As TimeSpan) As Boolean
        Dim local As TimeZoneInfo = TimeZoneInfo.Local
        Dim offset As TimeSpan = TimeZoneInfo.Local.BaseUtcOffset

        ' Is the store in the same time zone?
        If tz.Equals(local) Then
            Return time >= open AndAlso time <= close
        Else
            Dim delta As TimeSpan = TimeSpan.Zero
            Dim storeDelta As TimeSpan = TimeSpan.Zero

            ' Is it daylight saving time in either time zone?
            If local.IsDaylightSavingTime(Date.Now.Date + time) Then
                delta = local.GetAdjustmentRules(local.GetAdjustmentRules().Length - 1).DaylightDelta
            End If
            If tz.IsDaylightSavingTime(TimeZoneInfo.ConvertTime(Date.Now.Date + time, local, tz))
                storeDelta = tz.GetAdjustmentRules(tz.GetAdjustmentRules().Length - 1).DaylightDelta
            End If
            Dim comparisonTime As TimeSpan = time + (offset - tz.BaseUtcOffset).Negate() + (delta - storeDelta).Negate
            Return (comparisonTime >= open AndAlso comparisonTime <= close)
        End If
    End Function
End Structure
' </Snippet1>

' <Snippet2>
Module Example
    Public Sub Main()
        ' Instantiate a StoreInfo object.
        Dim store103 As New StoreInfo()
        store103.store = "Store #103"
        store103.tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")
        ' Store opens at 8:00.
        store103.open = new TimeSpan(8, 0, 0)
        ' Store closes at 9:30.
        store103.close = new TimeSpan(21, 30, 0)

        Console.WriteLine("Store is open now at {0}: {1}",
                          Date.Now.TimeOfDay, store103.IsOpenNow())
        Dim times() As TimeSpan = {New TimeSpan(8, 0, 0),
                                    New TimeSpan(21, 0, 0),
                                    New TimeSpan(4, 59, 0),
                                    New TimeSpan(18, 31, 0)}
        For Each time In times
            Console.WriteLine("Store is open at {0}: {1}",
                              time, store103.IsOpenAt(time))
        Next
    End Sub
End Module
' The example displays the following output:
'       Store is open now at 15:29:01.6129911: True
'       Store is open at 08:00:00: True
'       Store is open at 21:00:00: False
'       Store is open at 04:59:00: False
'       Store is open at 18:31:00: False
' </Snippet2>
