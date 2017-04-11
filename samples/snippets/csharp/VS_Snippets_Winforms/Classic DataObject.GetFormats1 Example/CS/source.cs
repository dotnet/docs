using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void GetAllFormats() {
    // Creates a new data object using a string and the text format.
    DataObject myDataObject = new DataObject(DataFormats.Text, "Another string");
 
    // Gets all the data formats and data conversion formats in the DataObject.
    String[] arrayOfFormats = myDataObject.GetFormats();
 
    // Prints the results.
    textBox1.Text = "The format(s) associated with the data are: " + '\n';
    for(int i=0; i<arrayOfFormats.Length; i++)
       textBox1.Text += arrayOfFormats[i] + '\n';
 }
 
// </Snippet1>
}
