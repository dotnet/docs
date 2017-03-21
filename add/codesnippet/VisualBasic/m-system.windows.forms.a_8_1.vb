    Private Sub OnFormClosed(ByVal sender As Object, ByVal e As EventArgs)
        ' When a form is closed, decrement the count of open forms.

        ' When the count gets to 0, exit the app by calling
        ' ExitThread().
        formCount = formCount - 1
        If (formCount = 0) Then
            ExitThread()
        End If
    End Sub