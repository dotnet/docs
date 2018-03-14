using System;
using System.Windows.Forms;

public class Form1: Form
{
 protected ListBox textBox1;
// <Snippet1>
private void PrintCurrentInputLanguage() {
    textBox1.Text = "The current input language is: " +
       Application.CurrentInputLanguage.Culture.EnglishName;
 }
   
// </Snippet1>
}
