' 0253bb6d-5519-4a50-b882-b93ef5cca0d9
' How to: Create a File in Visual Basic

' <snippet1>
Imports System.IO
Imports System.Text

Module Module1

    Sub Main()
        Dim path As String = "c:\temp\MyTest.txt"

        ' Create or overwrite the file.
        Dim fs As FileStream = File.Create(path)

        ' Add text to the file.
        Dim info As Byte() = New UTF8Encoding(True).GetBytes("This is some text in the file.")
        fs.Write(info, 0, info.Length)
        fs.Close()
    End Sub

End Module
' </snippet1>
