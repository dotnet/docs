' <Snippet23>
Imports System.IO
Imports System.Text

Module Module1

    Sub Main()
        WriteCharacters()
    End Sub

    Async Sub WriteCharacters()
        Using writer As StreamWriter = File.CreateText("newfile.txt")
            Await writer.WriteLineAsync("First line of example")
            Await writer.WriteLineAsync("and second line")
        End Using
    End Sub
End Module
' </Snippet23>