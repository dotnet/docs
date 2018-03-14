using System;
using System.Windows.Forms;

public class Form1: Form
{
 protected ListBox textBox1;
// <Snippet1>
private void PrintCurrentCulture() {
    textBox1.Text = "The current culture is: " +
       Application.CurrentCulture.EnglishName;
 }
   
// </Snippet1>
}
