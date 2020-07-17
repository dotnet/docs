'<Snippet30>
Imports System.IO

Module Module1

    Sub Main()
        Dim path As String = "c:\temp\alphabet.txt"

        Dim sr As StreamReader = New StreamReader(path)
        Dim c(14) As Char

        sr.Read(c, 0, c.Length)
        Console.WriteLine("first 15 characters:")
        Console.WriteLine(c)
        ' writes - "abcdefghijklmno"

        sr.DiscardBufferedData()
        sr.BaseStream.Seek(2, SeekOrigin.Begin)
        Console.WriteLine(vbNewLine & "Back to offset 2 and read to end: ")
        Console.WriteLine(sr.ReadToEnd())
        ' writes - "cdefghijklmnopqrstuvwxyz"
        ' without DiscardBufferedData, writes - "pqrstuvwxyzcdefghijklmnopqrstuvwxyz"
        sr.Close()
    End Sub

End Module
'</Snippet30>
