using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
public void InstantiateMyCheckBox()
 {
    // Create and initialize a CheckBox.   
    CheckBox checkBox1 = new CheckBox(); 
    
    // Make the check box control appear as a toggle button.
    checkBox1.Appearance = Appearance.Button;
 
    // Turn off the update of the display on the click of the control.
    checkBox1.AutoCheck = false;
 
    // Add the check box control to the form.
    Controls.Add(checkBox1);
 }
 
// </Snippet1>
}
