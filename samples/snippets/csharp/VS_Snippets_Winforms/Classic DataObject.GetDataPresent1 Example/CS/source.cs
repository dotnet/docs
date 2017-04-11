using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void GetIfPresent3() {
    // Creates a new data object using a string and the text format.
    DataObject myDataObject = new DataObject(DataFormats.Text, "Another string");
 
    // Prints the string in a text box with autoconvert = false.
    if(myDataObject.GetDataPresent("System.String", false)) {
       // Prints the string in a text box.
       textBox1.Text = myDataObject.GetData("System.String", false).ToString() + '\n';
    } else
       textBox1.Text = "Could not convert data to specified format" + '\n';
 
    // Prints the string in a text box with autoconvert = true.
    textBox1.Text += "With autoconvert = true, you can convert text to string format. " +
       "String is: " + myDataObject.GetData("System.String", true).ToString();
 }
 
// </Snippet1>
}
