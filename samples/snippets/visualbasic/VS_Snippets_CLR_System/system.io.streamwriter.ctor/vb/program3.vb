' <snippet3>
Imports System.IO
Imports System.Text

Module Module1

    Sub Main()
        Dim fileName As String = "test.txt"
        Dim textToAdd As String = "Example text in file"
        Dim fs As FileStream = Nothing
        Try
            fs = New FileStream(fileName, FileMode.CreateNew)
            Using writer As StreamWriter = New StreamWriter(fs, Encoding.Default, 512)
                writer.Write(textToAdd)
            End Using
        Finally
            If Not fs Is Nothing Then
                fs.Dispose()
            End If
        End Try
    End Sub

End Module
' </snippet3>