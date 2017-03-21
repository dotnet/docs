    ' The event handler on Form2.
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Get the Name property of the parent.
        Dim s As String = ParentForm.Name
        ' Display the name in a message box.
        MessageBox.Show("My parent is " + s + ".")
    End Sub 'button1_Click