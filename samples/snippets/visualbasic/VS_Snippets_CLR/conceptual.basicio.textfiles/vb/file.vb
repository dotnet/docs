Imports System.IO

Class WriteFile

    Public Shared Sub Main()

        ' Create a string array with the lines of text
        Dim text As String = "First line" & Environment.NewLine

        ' Set a variable to the Documents path.
        Dim docPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        ' Write the text to a new file named "WriteFile.txt".
        File.WriteAllText(Path.Combine(docPath, Convert.ToString("WriteFile.txt")), text)

        ' Create a string array with the additional lines of text
        Dim lines() As String = {"New line 1", "New line 2"}

        ' Append new lines of text to the file
        File.AppendAllLines(Path.Combine(docPath, Convert.ToString("WriteFile.txt")), lines)

    End Sub

End Class

' The example creates a file named "WriteFile.txt" with the following contents:
' First line
' And then appends the following contents:
' New line 1
' New line 2
