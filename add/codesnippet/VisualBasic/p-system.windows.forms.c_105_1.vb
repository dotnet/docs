    'This method handles the mouse down event for all the controls on the form.  When a control has
    'captured the mouse, the control's name will be output on label1.
    Private Sub Control_MouseDown(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown, _
        label1.MouseDown, listbox1.MouseDown, listbox2.MouseDown
        Dim control As Control = CType(sender, Control)
        If (control.Capture) Then
            label1.Text = control.Name & " has captured the mouse"
        End If
    End Sub