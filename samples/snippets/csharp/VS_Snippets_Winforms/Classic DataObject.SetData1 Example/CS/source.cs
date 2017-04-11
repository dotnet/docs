using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void AddMyData() {
    // Creates a new data object using a string and the text format.
    DataObject myDataObject = new DataObject();
 
    // Stores a string, specifying the Unicode format.
    myDataObject.SetData(DataFormats.UnicodeText, "Text string");
 
    // Retrieves the data by specifying Text.
    textBox1.Text = myDataObject.GetData(DataFormats.Text).GetType().Name;
 }
 
// </Snippet1>
}
