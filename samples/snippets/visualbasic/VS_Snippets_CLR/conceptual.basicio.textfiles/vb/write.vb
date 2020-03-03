Imports System.IO

Class WriteText

    Public Shared Sub Main()

        ' Create a string array with the lines of text
        Dim lines() As String = {"First line", "Second line", "Third line"}

        ' Set a variable to the Documents path.
        Dim docPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        ' Write the string array to a new file named "WriteLines.txt".
        Using outputFile As New StreamWriter(Path.Combine(docPath, Convert.ToString("WriteLines.txt")))
            For Each line As String In lines
                outputFile.WriteLine(line)
            Next
        End Using

    End Sub

End Class

' The example creates a file named "WriteLines.txt" with the following contents:
' First line
' Second line
' Third line
