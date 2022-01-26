' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Module Example6
    Public Sub Main6()
        Dim formatter As New BinaryFormatter()

        ' Serialize a date.
        Dim dateOriginal As Date = #03/30/2013 6:00PM#
        dateOriginal = DateTime.SpecifyKind(dateOriginal, DateTimeKind.Local)
        ' Serialize the date in string form.
        If Not File.Exists("DateInfo.dat") Then
            Dim sw As New StreamWriter("DateInfo.dat")
            sw.Write("{0:G}|{0:s}|{0:o}", dateOriginal)
            sw.Close()
            Console.WriteLine("Serialized dates to DateInfo.dat")
        End If
        ' Serialize the date as a binary value.
        If Not File.Exists("DateInfo.bin") Then
            Dim fsIn As New FileStream("DateInfo.bin", FileMode.Create)
            formatter.Serialize(fsIn, dateOriginal)
            fsIn.Close()
            Console.WriteLine("Serialized date to DateInfo.bin")
        End If
        Console.WriteLine()

        ' Restore the date from string values.
        Dim sr As New StreamReader("DateInfo.dat")
        Dim datesToSplit As String = sr.ReadToEnd()
        Dim dateStrings() As String = datesToSplit.Split("|"c)
        For Each dateStr In dateStrings
            Dim newDate As DateTime = DateTime.Parse(dateStr)
            Console.WriteLine("'{0}' --> {1} {2}",
                              dateStr, newDate, newDate.Kind)
        Next
        Console.WriteLine()

        ' Restore the date from binary data.
        Dim fsOut As New FileStream("DateInfo.bin", FileMode.Open)
        Dim restoredDate As Date = DirectCast(formatter.Deserialize(fsOut), DateTime)
        Console.WriteLine("{0} {1}", restoredDate, restoredDate.Kind)
    End Sub
End Module
' </Snippet10>

