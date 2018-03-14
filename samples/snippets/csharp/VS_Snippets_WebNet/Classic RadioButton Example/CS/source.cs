using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
// <Snippet1>
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
 
// </Snippet1>
}
