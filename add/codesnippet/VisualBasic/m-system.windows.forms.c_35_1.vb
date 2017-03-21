Private Sub AddButtons()
   ' Suspend the form layout and add two buttons.
   Me.SuspendLayout()
   Dim buttonOK As New Button()
   buttonOK.Location = New Point(10, 10)
   buttonOK.Size = New Size(75, 25)
   buttonOK.Text = "OK"
   
   Dim buttonCancel As New Button()
   buttonCancel.Location = New Point(90, 10)
   buttonCancel.Size = New Size(75, 25)
   buttonCancel.Text = "Cancel"
   
   Me.Controls.AddRange(New Control() {buttonOK, buttonCancel})
   Me.ResumeLayout()
End Sub