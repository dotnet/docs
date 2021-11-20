' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Module Example9
    Public Sub Main9()
        Dim formatter As New BinaryFormatter()

        ' Serialize a date.
        Dim dateOriginal As Date = #03/30/2013 6:00PM#
        dateOriginal = DateTime.SpecifyKind(dateOriginal, DateTimeKind.Local)

        ' Serialize the date in string form.
        If Not File.Exists("DateInfo2.dat") Then
            Dim sw As New StreamWriter("DateInfo2.dat")
            sw.Write("{0:o}|{1:r}|{1:u}", dateOriginal,
                                          dateOriginal.ToUniversalTime())
            sw.Close()
            Console.WriteLine("Serialized dates to DateInfo.dat")
        End If
        ' Serialize the date as a binary value.
        If Not File.Exists("DateInfo2.bin") Then
            Dim fsIn As New FileStream("DateInfo2.bin", FileMode.Create)
            formatter.Serialize(fsIn, dateOriginal.ToUniversalTime())
            fsIn.Close()
            Console.WriteLine("Serialized date to DateInfo.bin")
        End If
        Console.WriteLine()

        ' Restore the date from string values.
        Dim sr As New StreamReader("DateInfo2.dat")
        Dim datesToSplit As String = sr.ReadToEnd()
        Dim dateStrings() As String = datesToSplit.Split("|"c)
        For ctr As Integer = 0 To dateStrings.Length - 1
            Dim newDate As DateTime = DateTime.Parse(dateStrings(ctr))
            If ctr = 1 Then
                Console.WriteLine("'{0}' --> {1} {2}",
                                  dateStrings(ctr), newDate, newDate.Kind)
            Else
                Dim newLocalDate As DateTime = newDate.ToLocalTime()
                Console.WriteLine("'{0}' --> {1} {2}",
                                  dateStrings(ctr), newLocalDate, newLocalDate.Kind)
            End If
        Next
        Console.WriteLine()

        ' Restore the date from binary data.
        Dim fsOut As New FileStream("DateInfo2.bin", FileMode.Open)
        Dim restoredDate As Date = DirectCast(formatter.Deserialize(fsOut), DateTime)
        restoredDate = restoredDate.ToLocalTime()
        Console.WriteLine("{0} {1}", restoredDate, restoredDate.Kind)
    End Sub
End Module
' </Snippet11>

