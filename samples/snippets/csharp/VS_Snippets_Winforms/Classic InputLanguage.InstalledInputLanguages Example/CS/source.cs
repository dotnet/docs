using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
 public void GetLanguages() {
    // Gets the list of installed languages.
    foreach(InputLanguage lang in InputLanguage.InstalledInputLanguages) {
       textBox1.Text += lang.Culture.EnglishName + '\n';
    }
 }

// </Snippet1>
}
