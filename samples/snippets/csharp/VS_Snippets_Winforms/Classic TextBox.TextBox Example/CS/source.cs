using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
public void CreateMyTextBoxControl()
 {
    // Create a new TextBox control using this constructor.
    TextBox textBox1 = new TextBox();
    // Assign a string of text to the new TextBox control.
    textBox1.Text = "Hello World!";
    // Code goes here to add the control to the form's control collection.
 }
       
// </Snippet1>
}
