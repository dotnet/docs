using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

public class Form1: Form
{
 public void Method()
 {
// <Snippet1>
Trace.WriteLine("List of errors:");
 Trace.Indent();
 Trace.WriteLine("Error 1: File not found");
 Trace.WriteLine("Error 2: Directory not found");
 Trace.Unindent();
 Trace.WriteLine("End of list of errors");
   
// </Snippet1>
 }
}
