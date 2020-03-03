' <snippet2>
Public Class Words
    ' Object to store the current state, for passing to the caller.
    Public Class CurrentState
        Public LinesCounted As Integer
        Public WordsMatched As Integer
    End Class

    Public SourceFile As String
    Public CompareString As String
    Private WordCount As Integer = 0
    Private LinesCounted As Integer = 0

    Public Sub CountWords(
        ByVal worker As System.ComponentModel.BackgroundWorker,
        ByVal e As System.ComponentModel.DoWorkEventArgs
    )
        ' Initialize the variables.
        Dim state As New CurrentState
        Dim line = ""
        Dim elapsedTime = 20
        Dim lastReportDateTime = Now

        If CompareString Is Nothing OrElse
           CompareString = System.String.Empty Then

           Throw New Exception("CompareString not specified.")
        End If

        Using myStream As New System.IO.StreamReader(SourceFile)

            ' Process lines while there are lines remaining in the file.
            Do While Not myStream.EndOfStream
                If worker.CancellationPending Then
                    e.Cancel = True
                    Exit Do
                Else
                    line = myStream.ReadLine
                    WordCount += CountInString(line, CompareString)
                    LinesCounted += 1

                    ' Raise an event so the form can monitor progress.
                    If Now > lastReportDateTime.AddMilliseconds(elapsedTime) Then
                        state.LinesCounted = LinesCounted
                        state.WordsMatched = WordCount
                        worker.ReportProgress(0, state)
                        lastReportDateTime = Now
                    End If

                    ' Uncomment for testing.
                    'System.Threading.Thread.Sleep(5)
                End If
            Loop

            ' Report the final count values.
            state.LinesCounted = LinesCounted
            state.WordsMatched = WordCount
            worker.ReportProgress(0, state)
        End Using
    End Sub

    Private Function CountInString(
        ByVal SourceString As String,
        ByVal CompareString As String
    ) As Integer
        ' This function counts the number of times
        ' a word is found in a line.
        If SourceString Is Nothing Then
            Return 0
        End If

        Dim EscapedCompareString =
            System.Text.RegularExpressions.Regex.Escape(CompareString)

        ' To count all occurrences of the string, even within words, remove
        ' both instances of "\b".
        Dim regex As New System.Text.RegularExpressions.Regex(
            "\b" + EscapedCompareString + "\b",
            System.Text.RegularExpressions.RegexOptions.IgnoreCase)

        Dim matches As System.Text.RegularExpressions.MatchCollection
        matches = regex.Matches(SourceString)
        Return matches.Count
    End Function
End Class
' </snippet2>
