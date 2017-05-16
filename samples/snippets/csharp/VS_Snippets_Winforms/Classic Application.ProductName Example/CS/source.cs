using System;
using System.Windows.Forms;

public class Form1: Form
{
 protected ListBox textBox1;
// <Snippet1>
private void PrintProductName() {
    textBox1.Text = "The product name is: " +
       Application.ProductName;
 }

// </Snippet1>
}
