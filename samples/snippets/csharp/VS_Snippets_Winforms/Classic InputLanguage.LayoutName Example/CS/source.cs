using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
 public void MyLayoutName() {
    // Gets the current input language.
    InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;
 
    if(myCurrentLanguage != null) 
       textBox1.Text = "Layout: " + myCurrentLanguage.LayoutName;
    else
       textBox1.Text = "There is no current language";
 }

// </Snippet1>
}
