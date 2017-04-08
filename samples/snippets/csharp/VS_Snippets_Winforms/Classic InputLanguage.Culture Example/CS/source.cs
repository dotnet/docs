using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
 public void MyCulture() {
    // Gets the current input language.
    InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;
 
    // Gets the culture for the language  and prints it.
    CultureInfo myCultureInfo = myCurrentLanguage.Culture;
    textBox1.Text = myCultureInfo.EnglishName;
 }

// </Snippet1>
}
