
    Private Sub MyForm_Layout(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.LayoutEventArgs) Handles MyBase.Layout

        ' Center the Form on the user's screen everytime it requires a Layout.
        Me.SetBounds((System.Windows.Forms.Screen.GetBounds(Me).Width / 2) - (Me.Width / 2), _
            (System.Windows.Forms.Screen.GetBounds(Me).Height / 2) - (Me.Height / 2), _
            Me.Width, Me.Height, System.Windows.Forms.BoundsSpecified.Location)
    End Sub