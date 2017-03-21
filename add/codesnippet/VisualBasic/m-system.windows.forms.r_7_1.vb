 Private Sub InitializeMyRadioButton()
     ' Create and initialize a new RadioButton. 
     Dim radioButton1 As New RadioButton()
        
     ' Make the radio button control appear as a toggle button.
     radioButton1.Appearance = Appearance.Button
        
     ' Turn off the update of the display on the click of the control.
     radioButton1.AutoCheck = False
        
     ' Add the radio button to the form.
     Controls.Add(radioButton1)
 End Sub
