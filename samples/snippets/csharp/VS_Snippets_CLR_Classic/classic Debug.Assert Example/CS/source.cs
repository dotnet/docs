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
// Create an index for an array.
 int index;
 
 // Perform some action that sets the index.
 index = -40;
 
 // Test that the index value is valid. 
 Debug.Assert(index > -1);   
// </Snippet1>
 }
}
