' <Snippet24>
Imports System.IO
Imports System.Text

Module Module1

    Sub Main()
        WriteCharacters()
    End Sub

    Async Sub WriteCharacters()
        Dim ue As UnicodeEncoding = New UnicodeEncoding()
        Dim charsToAdd() = ue.GetChars(ue.GetBytes("Example string"))

        Using writer As StreamWriter = File.CreateText("newfile.txt")
            Await writer.WriteAsync(charsToAdd, 0, charsToAdd.Length)
        End Using
    End Sub
End Module
' </Snippet24>