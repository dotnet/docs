    Private Sub ShowMyNonModalForm()
        Dim myForm As New Form()
        myForm.Text = "My Form"
        myForm.SetBounds(10, 10, 200, 200)

        myForm.Show()
        ' Determine if the form is modal.
        If myForm.Modal = False Then
            ' Change borderstyle and make it not a top level window.
            myForm.FormBorderStyle = FormBorderStyle.FixedToolWindow
            myForm.TopLevel = False
        End If
    End Sub