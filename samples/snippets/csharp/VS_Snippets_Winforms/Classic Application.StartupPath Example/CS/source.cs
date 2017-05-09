using System;
using System.Windows.Forms;

public class Form1: Form
{
 protected ListBox textBox1;
// <Snippet1>
private void PrintStartupPath() {
    textBox1.Text = "The path for the executable file that " +
       "started the application is: " +
       Application.StartupPath;
 }

// </Snippet1>
}
