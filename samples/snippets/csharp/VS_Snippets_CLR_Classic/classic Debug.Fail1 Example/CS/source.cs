using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 protected enum MyOption { First, Second };
 protected MyOption option1;
 protected double result;
 protected double value;
 protected double newValue;
 protected void Method()
 {
    try {
    }
    // <Snippet1>
    catch (Exception) {
        Debug.Fail("Invalid value: " + value.ToString(), 
           "Resetting value to newValue.");
        value = newValue;
     }
    // </Snippet1>
    // <Snippet2>
    switch (option1) {
        case MyOption.First:
           result = 1.0;
           break;
     
        // Insert additional cases.
     
        default:
           Debug.Fail("Unknown Option " + option1, "Result set to 1.0");
           result = 1.0;
           break;
     }
    // </Snippet2>
    }
}
