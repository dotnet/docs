using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
public void DisableActiveFormControls()
 {
    // Create an instance of a form and assign it the currently active form.
    Form currentForm = Form.ActiveForm;
    
    // Loop through all the controls on the active form.
    for (int i = 0; i < currentForm.Controls.Count; i++)
    {
       // Disable each control in the active form's control collection.
       currentForm.Controls[i].Enabled = false;
    }
 }
    
// </Snippet1>
}
