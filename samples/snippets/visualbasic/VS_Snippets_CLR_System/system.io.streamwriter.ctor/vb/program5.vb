' <snippet5>
Imports System.IO
Imports System.Text

Module Module1

    Sub Main()
        Dim fileName As String = "test.txt"
        Dim textToAdd As String = "Example text in file"

        Using writer As StreamWriter = New StreamWriter(fileName)
            writer.Write(textToAdd)
        End Using
    End Sub

End Module
' </snippet5>