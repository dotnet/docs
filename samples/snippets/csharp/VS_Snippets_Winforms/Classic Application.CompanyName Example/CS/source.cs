using System;
using System.Windows.Forms;

public class Form1: Form
{
 protected ListBox textBox1;
// <Snippet1>
private void PrintCompanyName() {
    textBox1.Text = "The company name is: " + Application.CompanyName;
 }
   
// </Snippet1>
}
