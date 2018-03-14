using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
public void ViewMyTextBoxContents()
 {
    // Create a string array and store the contents of the Lines property.
    string[] tempArray = textBox1.Lines;
 
    // Loop through the array and send the contents of the array to debug window.
    for(int counter=0; counter < tempArray.Length;counter++)
    {
       System.Diagnostics.Debug.WriteLine(tempArray[counter]);
    }
 }
 
// </Snippet1>
}
