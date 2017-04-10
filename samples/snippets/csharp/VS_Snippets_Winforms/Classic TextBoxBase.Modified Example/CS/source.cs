using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 
protected string originalText;
// <Snippet1>
private void TextBox1_TextChanged(object sender, EventArgs e)
 {
    /* Check to see if the change made does not return the
       control to its original state. */
    if (originalText != textBox1.Text)
       // Set the Modified property to true to reflect the change.
       textBox1.Modified = true;
    else
       // Contents of textBox1 have not changed, reset the Modified property.
       textBox1.Modified = false;
 }
 
// </Snippet1>
}
