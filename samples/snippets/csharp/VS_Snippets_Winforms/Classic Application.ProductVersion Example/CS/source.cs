using System;
using System.Windows.Forms;

public class Form1: Form
{
 protected ListBox textBox1;
// <Snippet1>
private void PrintProductVersion() {
    textBox1.Text = "The product version is: " +
       Application.ProductVersion;
 }

// </Snippet1>
}
