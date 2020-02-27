Class MainWindow 
    '<SnippetGoToElementStateCode>
    Private number As Integer

    Private Sub GenerateNumber()
        Dim r As New System.Random()
        number = r.Next(100) + 1
    End Sub

    Private Sub OnGuess(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim guess As Integer

        If Integer.TryParse(Me.Guess.Text, guess) Then
            If guess < Me.number Then
                VisualStateManager.GoToElementState(Me.LayoutRoot, "TooLow", True)
                Me.Result.Text = "Too Low!"
            ElseIf guess > Me.number Then
                VisualStateManager.GoToElementState(Me.LayoutRoot, "TooHigh", True)
                Me.Result.Text = "Too High!"
            Else
                VisualStateManager.GoToElementState(Me.LayoutRoot, "Correct", True)
                Me.Result.Text = "Correct!"
            End If
        End If
    End Sub

    Private Sub OnTypingGuess(ByVal sender As Object, ByVal e As System.Windows.Controls.TextChangedEventArgs)
        VisualStateManager.GoToElementState(Me.LayoutRoot, "Guessing", True)
        Me.Result.Text = ""
    End Sub
    '</SnippetGoToElementStateCode>

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        GenerateNumber()
        Title = number.ToString()
    End Sub
End Class
