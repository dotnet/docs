' Visual Basic .NET Document
Option Strict On

Imports System.Globalization
Imports System.IO

Module modMain

    Public Sub Main()
        RoundTripDateTime()
        Console.WriteLine()
        RoundTripDateTimeOffset()
        Console.WriteLine()
    End Sub

    Private Sub RoundTripDateTime()
        ' <Snippet1>
        Const fileName As String = ".\DateFile.txt"

        Dim outFile As New StreamWriter(fileName)

        ' Save DateTime value.
        Dim dateToSave As Date = DateTime.SpecifyKind(#06/12/2008 6:45:15 PM#, _
                                                      DateTimeKind.Local)
        Dim dateString As String = dateToSave.ToString("o")
        Console.WriteLine("Converted {0} ({1}) to {2}.", dateToSave.ToString(), _
                          dateToSave.Kind.ToString(), dateString)
        outFile.WriteLine(dateString)
        Console.WriteLine("Wrote {0} to {1}.", dateString, fileName)
        outFile.Close()

        ' Restore DateTime value.
        Dim restoredDate As Date

        Dim inFile As New StreamReader(fileName)
        dateString = inFile.ReadLine()
        inFile.Close()
        restoredDate = DateTime.Parse(dateString, Nothing, DateTimeStyles.RoundTripKind)
        Console.WriteLine("Read {0} ({2}) from {1}.", restoredDate.ToString(), _
                          fileName, restoredDAte.Kind.ToString())
        ' The example displays the following output:
        '    Converted 6/12/2008 6:45:15 PM (Local) to 2008-06-12T18:45:15.0000000-05:00.
        '    Wrote 2008-06-12T18:45:15.0000000-05:00 to .\DateFile.txt.
        '    Read 6/12/2008 6:45:15 PM (Local) from .\DateFile.txt.
        ' </Snippet1>
    End Sub

    Private Sub RoundTripDateTimeOffset()
        ' <Snippet2>
        Const fileName As String = ".\DateOff.txt"

        Dim outFile As New StreamWriter(fileName)

        ' Save DateTime value.
        Dim dateToSave As New DateTimeOffset(2008, 6, 12, 18, 45, 15, _
                                             New TimeSpan(7, 0, 0))
        Dim dateString As String = dateToSave.ToString("o")
        Console.WriteLine("Converted {0} to {1}.", dateToSave.ToString(), dateString)
        outFile.WriteLine(dateString)
        Console.WriteLine("Wrote {0} to {1}.", dateString, fileName)
        outFile.Close()

        ' Restore DateTime value.
        Dim restoredDateOff As DateTimeOffset

        Dim inFile As New StreamReader(fileName)
        dateString = inFile.ReadLine()
        inFile.Close()
        restoredDateOff = DateTimeOffset.Parse(dateString, Nothing, DateTimeStyles.RoundTripKind)
        Console.WriteLine("Read {0} from {1}.", restoredDateOff.ToString(), fileName)
        ' The example displays the following output:
        '    Converted 6/12/2008 6:45:15 PM +07:00 to 2008-06-12T18:45:15.0000000+07:00.
        '    Wrote 2008-06-12T18:45:15.0000000+07:00 to .\DateOff.txt.
        '    Read 6/12/2008 6:45:15 PM +07:00 from .\DateOff.txt.
        ' </Snippet2>
    End Sub
End Module

' <Snippet3>
<Serializable> Public Class DateInTimeZone
    Private tz As TimeZoneInfo
    Private thisDate As DateTimeOffset

    Public Sub New()
    End Sub

    Public Sub New(date1 As DateTimeOffset, timeZone As TimeZoneInfo)
        If timeZone Is Nothing Then
            Throw New ArgumentNullException("timeZone", "The time zone cannot be null.")
        End If
        Me.thisDate = date1
        Me.tz = timeZone
    End Sub

    Public Property DateAndTime As DateTimeOffset
        Get
            Return Me.thisDate
        End Get
        Set
            If Value.Offset <> Me.tz.GetUtcOffset(Value) Then
                Me.thisDate = TimeZoneInfo.ConvertTime(Value, tz)
            Else
                Me.thisDate = Value
            End If
        End Set
    End Property

    Public ReadOnly Property TimeZone As TimeZoneInfo
        Get
            Return tz
        End Get
    End Property
End Class
' </Snippet3>
