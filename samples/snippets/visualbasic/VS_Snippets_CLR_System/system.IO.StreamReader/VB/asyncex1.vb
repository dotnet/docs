' <Snippet51>
Imports System
Imports System.IO
Imports System.Threading.Tasks

Module Example
    Public Sub Main()
        ReadAndDisplayFilesAsync()
    End Sub

    Private Async Sub ReadAndDisplayFilesAsync()
        Dim filename As String = "TestFile1.txt"
        Dim buffer() As Char
        
        Using sr As New StreamReader(filename)
            ReDim buffer(CInt(sr.BaseStream.Length))
            Await sr.ReadAsync(buffer, 0, CInt(sr.BaseStream.Length))
        End Using

        Console.WriteLine(New String(buffer))
    End Sub
End Module
' The example displays the following output:
'       This is the first line of text in a relatively short file.
'       This is the second line.
'       This is the third line.
'       This is the fourth and final line.
' </Snippet51>