using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
 public void MyHandle() {
    // Gets the current input language.
    InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;
 
    // Gets a handle for the language  and prints the number.
    IntPtr myHandle = myCurrentLanguage.Handle;
    textBox1.Text = "The handle number is: " + myHandle.ToString();
 }

// </Snippet1>
}
