Imports System.IO
Imports System.Text
Imports System.Collections.Generic

Class WriteTextFiles

    Public Shared Sub Main()

        ' Example 1: shows how to write synchronously
        ' to a text file using StreamWriter
        ' line by line
        WriteLineByLine()

        ' Example 2: Appending text to
        ' an existing file using StreamWriter
        AppendTextSW()

        ' Example 3: shows how to write a 
        ' a simple string asynchronously
        ' to a text file using StreamWriter
        WriteTextAsync()

        ' Example 4: shows how to write synchronously
        ' to a text file using File and then
        ' adding additional lines 
        WriteFile()

    End Sub

    Shared Sub WriteLineByLine()
        ' <SnippetWriteLine>
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
        ' </SnippetWriteLine>

    End Sub

    Shared Sub AppendTextSW()
        ' <SnippetAppendText>
        ' Set a variable to the Documents path.
        Dim docPath As String =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        ' Append text to an existing file named "WriteLines.txt".
        Using outputFile As New StreamWriter(Path.Combine(docPath, Convert.ToString("WriteLines.txt")), True)
            outputFile.WriteLine("Fourth Line")
        End Using
        ' </SnippetAppendText>

    End Sub

    ' <SnippetWriteAsync>
    Shared Async Sub WriteTextAsync()
        ' Set a variable to the Documents path.
        Dim docPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        ' Write the text asynchronously to a new file named "WriteTextAsync.txt".
        Using outputFile As New StreamWriter(Path.Combine(docPath, Convert.ToString("WriteTextAsync.txt")))
            Await outputFile.WriteAsync("This is a sentence.")
        End Using
    End Sub
    ' </SnippetWriteAsync>

    Shared Sub WriteFile()
        ' <SnippetWriteFile>
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
        ' </SnippetWriteFile>

    End Sub

End Class
