' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Imports System.IO

Module Example6
    Public Sub Main6()
        ' Serialize a date.
        Dim dateOriginal As Date = #03/30/2023 6:00PM#
        dateOriginal = DateTime.SpecifyKind(dateOriginal, DateTimeKind.Local)
        ' Serialize the date in string form.
        If Not File.Exists("DateInfo.dat") Then
            Dim sw As New StreamWriter("DateInfo.dat")
            sw.Write("{0:G}|{0:s}|{0:o}", dateOriginal)
            sw.Close()
        End If

        ' Restore the date from string values.
        Dim sr As New StreamReader("DateInfo.dat")
        Dim datesToSplit As String = sr.ReadToEnd()
        Dim dateStrings() As String = datesToSplit.Split("|"c)
        For Each dateStr In dateStrings
            Dim newDate As DateTime = DateTime.Parse(dateStr)
            Console.WriteLine("'{0}' --> {1} {2}",
                              dateStr, newDate, newDate.Kind)
        Next
    End Sub
End Module
' </Snippet10>

