using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;

 protected void Method()
 {
// <Snippet1>
 Debug.WriteLine("List of errors:");
 Debug.Indent();
 Debug.WriteLine("Error 1: File not found");
 Debug.WriteLine("Error 2: Directory not found");
 Debug.Unindent();
 Debug.WriteLine("End of list of errors");
   
// </Snippet1>
 }
}
