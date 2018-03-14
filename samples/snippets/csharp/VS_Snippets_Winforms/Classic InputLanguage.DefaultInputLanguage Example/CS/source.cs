using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
 public void MyDefaultInputLanguage() {
    // Gets the default input language  and prints it in a text box.
    InputLanguage myDefaultLanguage = InputLanguage.DefaultInputLanguage;
    textBox1.Text = "Default input language is: " + myDefaultLanguage.Culture.EnglishName;
 }

// </Snippet1>
}
