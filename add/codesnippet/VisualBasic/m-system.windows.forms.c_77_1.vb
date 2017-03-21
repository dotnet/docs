    ' The following example displays the location of the form in screen coordinates
    ' on the caption bar of the form.
    Private Sub Form1_Move(sender As Object, e As System.EventArgs) Handles MyBase.Move
        Me.Text = "Form screen position = " + Me.Location.ToString()
    End Sub