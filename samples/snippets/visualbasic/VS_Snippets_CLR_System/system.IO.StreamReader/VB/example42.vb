' <Snippet42>
Imports System.Text
Imports System.IO

Class MainWindow

    Private Async Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Dim filename As String = "C:\Example\existingfile.txt"
        Dim result() As Char
        Dim builder As StringBuilder = New StringBuilder()

        Using reader As StreamReader = File.OpenText(filename)
            ReDim result(reader.BaseStream.Length)
            Await reader.ReadAsync(result, 0, reader.BaseStream.Length)
        End Using

        For Each c As Char In result
            If (Char.IsLetterOrDigit(c) Or Char.IsWhiteSpace(c)) Then
                builder.Append(c)
            End If
        Next
        FileOutput.Text = builder.ToString()
    End Sub
End Class
' </Snippet42>
