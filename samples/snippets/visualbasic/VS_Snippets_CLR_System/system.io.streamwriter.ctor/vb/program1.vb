' <snippet1>
Imports System.IO

Module Module1

    Sub Main()
        Dim fileName As String = "test.txt"
        Dim textToAdd As String = "Example text in file"
        Dim fs As FileStream = Nothing
        Try
            fs = New FileStream(fileName, FileMode.CreateNew)
            Using writer As StreamWriter = New StreamWriter(fs)
                writer.Write(textToAdd)
            End Using
        Finally
            If Not fs Is Nothing Then
                fs.Dispose()
            End If
        End Try
    End Sub

End Module
' </snippet1>