    ' The event handler on Form1.
    Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Create an instance of Form2.
        Dim f2 As New Form2()
        ' Make this form the parent of f2.
        f2.MdiParent = Me
        ' Display the form.
        f2.Show()
    End Sub 'button1_Click