' Create three buttons and place them on a form using 
' several size and location related properties. 
Private Sub AddOKCancelButtons()
   ' Set the button size and location using 
      ' the Size and Location properties. 
   Dim buttonOK As New Button()
   buttonOK.Location = New Point(136, 248)
   buttonOK.Size = New Size(75, 25)
   ' Set the Text property and make the 
   ' button the form's default button. 
   buttonOK.Text = "&OK"
   Me.AcceptButton = buttonOK
   
   ' Set the button size and location using the Top, 
   ' Left, Width, and Height properties. 
   Dim buttonCancel As New Button()
   buttonCancel.Top = buttonOK.Top
   buttonCancel.Left = buttonOK.Right + 5
   buttonCancel.Width = buttonOK.Width
   buttonCancel.Height = buttonOK.Height
   ' Set the Text property and make the 
   ' button the form's cancel button. 
   buttonCancel.Text = "&Cancel"
   Me.CancelButton = buttonCancel
   
   ' Set the button size and location using 
   ' the Bounds property. 
   Dim buttonHelp As New Button()
   buttonHelp.Bounds = New Rectangle(10, 10, 75, 25)
   ' Set the Text property of the button.
   buttonHelp.Text = "&Help"
   
   ' Add the buttons to the form.
   Me.Controls.AddRange(New Control() {buttonOK, buttonCancel, buttonHelp})
End Sub