using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

class Form1: Form
{
 protected TextBox textBox1;

 protected void Method()
 {
// <Snippet1>
/* Create a listener that outputs to the console screen, and 
  * add it to the debug listeners. */
 TextWriterTraceListener myWriter = new 
    TextWriterTraceListener(System.Console.Out);
 Debug.Listeners.Add(myWriter);

// </Snippet1>
 }
}
