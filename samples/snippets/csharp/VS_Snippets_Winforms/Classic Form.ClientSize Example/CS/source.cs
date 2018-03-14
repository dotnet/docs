using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected Button button1;
// <Snippet1>
private void MyForm_Resize (Object sender, EventHandler e)
 {
    // Set the size of button1 to the size of the client area of the form.
    button1.Size = this.ClientSize;
 }
    
// </Snippet1>
}
