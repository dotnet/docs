    Private Sub ShowInTaskBarEx()
        Dim myForm As New Form()
        myForm.Text = "My Form"
        myForm.SetBounds(10, 10, 200, 200)
        myForm.FormBorderStyle = FormBorderStyle.FixedDialog
        myForm.MinimizeBox = False
        myForm.MaximizeBox = False
        ' Do not allow form to be displayed in taskbar.
        myForm.ShowInTaskbar = False
        myForm.ShowDialog()
    End Sub