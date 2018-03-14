' <snippet2>
Imports System.IO
Imports System.Text

Module Module1

    Sub Main()
        WriteToFile()
    End Sub

    Async Sub WriteToFile()
        Dim bytesToWrite = Encoding.Unicode.GetBytes("example text to write")
        Using createdFile As FileStream = File.Create("c:/Temp/testfile.txt", 4096, FileOptions.Asynchronous)
            Await createdFile.WriteAsync(bytesToWrite, 0, bytesToWrite.Length)
        End Using
    End Sub

End Module
' </snippet2>