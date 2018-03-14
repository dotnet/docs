using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
public void ClearAllChildFormText()
 {
    // Obtain a reference to the currently active MDI child form.
    Form tempChild = this.ActiveMdiChild;
    
    // Loop through all controls on the child form.
    for (int i = 0; i < tempChild.Controls.Count; i++)
    {
       // Determine if the current control on the child form is a TextBox.
       if (tempChild.Controls[i] is TextBox)
       {
          // Clear the contents of the control since it is a TextBox.
          tempChild.Controls[i].Text = "";
       }
    }
 }
    
// </Snippet1>
}
