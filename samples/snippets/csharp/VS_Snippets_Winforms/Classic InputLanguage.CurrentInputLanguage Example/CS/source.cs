using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
 public void MyCurrentInputLanguage() {
    // Gets the current input language  and prints it in a text box.
    InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;
    textBox1.Text = "Current input language is: " +
        myCurrentLanguage.Culture.EnglishName;
 }

// </Snippet1>
}
