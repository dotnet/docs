' <snippet5>
Imports System.IO
Imports System.Text

Class MainWindow

    Private Async Sub AppendButton_Click(sender As Object, e As RoutedEventArgs)
        ' Set a variable to the My Documents path.
        Dim mydocpath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        ' Create a string builder and write the user input from the textbox to it.
        Dim sb As StringBuilder = New StringBuilder()
        sb.AppendLine("New User Input")
        sb.AppendLine("= = = = = =")
        sb.Append(UserInputTextBox.Text)
        sb.AppendLine()
        sb.AppendLine()

        ' Open a stream writer to a new text file named "UserInputFile.txt" and write the contents 
        ' of the stringbuilder to it.
        Using outfile As StreamWriter = New StreamWriter(mydocpath + "\UserInputFile.txt", True)
            Await outfile.WriteAsync(sb.ToString())
        End Using
    End Sub
End Class
' </snippet5>
