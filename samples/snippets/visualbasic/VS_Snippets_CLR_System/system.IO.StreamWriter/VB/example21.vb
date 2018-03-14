' <Snippet21>
Imports System.IO
Imports System.Text

Module Module1

    Sub Main()
        WriteCharacters()
    End Sub

    Async Sub WriteCharacters()

        Using writer As StreamWriter = File.CreateText("newfile.txt")
            Await writer.WriteAsync("Example text as string")
        End Using
    End Sub
End Module
' </Snippet21>
