using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;

 protected enum Option { First, Second };

 protected Option option;

 protected double result;

 protected void Method()
{
try{
    //
}
// <Snippet1>
catch (Exception) {
    Debug.Fail("Unknown Option " + option + ", using the default.");
 }
// </Snippet1>
// <Snippet2>
switch (option) {
    case Option.First:
       result = 1.0;
       break;
 
    // Insert additional cases.
 
    default:
       Debug.Fail("Unknown Option " + option);
       result = 1.0;
       break;
 }
// </Snippet2>
 }
}

