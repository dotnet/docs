using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void GetIfPresent() {
    // Creates a new data object using a string and the text format.
    DataObject myDataObject = new DataObject(DataFormats.Text, "A new string");
 
    // Prints whether data is present in text format.
    textBox1.Text = "Data in text format is: " + 
       myDataObject.GetDataPresent(DataFormats.Text).ToString();
 }
 
// </Snippet1>
}
