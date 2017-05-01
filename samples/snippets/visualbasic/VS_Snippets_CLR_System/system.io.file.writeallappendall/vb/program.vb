' <Snippet1>
Imports System
Imports System.IO
Imports System.Linq

Class Program
    Shared dataPath As String = "c:\temp\timestamps.txt"

    Public Shared Sub Main(ByVal args As String())
        CreateSampleFile()

        Dim JulyWeekends = From line In File.ReadLines(dataPath) _
            Where (line.StartsWith("Saturday") OrElse _
            line.StartsWith("Sunday")) And line.Contains("July") _
            Select line

        File.WriteAllLines("C:\temp\selectedDays.txt", JulyWeekends)

        Dim MarchMondays = From line In File.ReadLines(dataPath) _
            Where line.StartsWith("Monday") AndAlso line.Contains("March") _
            Select line

        File.AppendAllLines("C:\temp\selectedDays.txt", MarchMondays)
    End Sub

    Private Shared Sub CreateSampleFile()
        Dim TimeStamp As New DateTime(1700, 1, 1)

        Using sw As New StreamWriter(dataPath)
            For i As Integer = 0 To 499
                Dim TS1 As DateTime = TimeStamp.AddYears(i)
                Dim TS2 As DateTime = TS1.AddMonths(i)
                Dim TS3 As DateTime = TS2.AddDays(i)

                sw.WriteLine(TS3.ToLongDateString())
            Next
        End Using
    End Sub
End Class
' </Snippet1>