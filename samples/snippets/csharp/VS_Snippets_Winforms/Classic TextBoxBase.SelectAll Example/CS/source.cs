using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
public void CopyAllMyText()
 {
    // Determine if any text is selected in the TextBox control.
    if(textBox1.SelectionLength == 0)
       // Select all text in the text box.
       textBox1.SelectAll();
    
    // Copy the contents of the control to the Clipboard.
    textBox1.Copy();
 }

// </Snippet1>
}
