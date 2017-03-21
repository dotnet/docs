 private void InitializeMyRadioButton()
 {
    // Create and initialize a new RadioButton. 
    RadioButton radioButton1 = new RadioButton();
    
    // Make the radio button control appear as a toggle button.
    radioButton1.Appearance = Appearance.Button;
 
    // Turn off the update of the display on the click of the control.
    radioButton1.AutoCheck = false;
 
    // Add the radio button to the form.
    Controls.Add(radioButton1);
 }
 