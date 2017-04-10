' <Snippet22>
Imports System.IO
Imports System.Text

Module Module1

    Sub Main()
        WriteCharacters()
    End Sub

    Async Sub WriteCharacters()
        Dim firstChar As Char = "a"
        Dim secondChar As Char = "b"
        Using writer As StreamWriter = File.CreateText("newfile.txt")
            Await writer.WriteLineAsync(firstChar)
            Await writer.WriteLineAsync(secondChar)
        End Using
    End Sub
End Module
' </Snippet22>