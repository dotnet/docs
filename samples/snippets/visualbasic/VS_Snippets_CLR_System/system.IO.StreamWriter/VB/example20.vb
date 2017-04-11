' <Snippet20>
Imports System.IO
Imports System.Text

Module Module1

    Sub Main()
        WriteCharacters()
    End Sub

    Async Sub WriteCharacters()
        Dim oneLetter As Char = "a"
        Using writer As StreamWriter = File.CreateText("newfile.txt")
            Await writer.WriteAsync(oneLetter)
        End Using
    End Sub
End Module
' </Snippet20>