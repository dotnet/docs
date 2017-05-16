' <Snippet25>
Imports System.IO
Imports System.Text

Module Module1

    Sub Main()
        WriteCharacters()
    End Sub

    Async Sub WriteCharacters()
        Dim ue As UnicodeEncoding = New UnicodeEncoding()
        Dim charsToAdd() = ue.GetChars(ue.GetBytes("First line and second line"))

        Using writer As StreamWriter = File.CreateText("newfile.txt")
            Await writer.WriteLineAsync(charsToAdd, 0, 11)
            Await writer.WriteLineAsync(charsToAdd, 11, charsToAdd.Length - 11)
        End Using
    End Sub
End Module
' </Snippet25>