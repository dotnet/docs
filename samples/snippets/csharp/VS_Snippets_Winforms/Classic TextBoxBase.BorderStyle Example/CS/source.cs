using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
public void CreateTextBox()
 {
    // Create an instance of the TextBox control.
    TextBox textBox1 = new TextBox();
 
    // Set the TextBox Font property to Arial 20.
    textBox1.Font = new Font ("Arial" , 20);
    // Set the BorderStyle property to FixedSingle.
    textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    // Make the height of the control equal to the preferred height.
    textBox1.Height = textBox1.PreferredHeight;
 }

// </Snippet1>
}
