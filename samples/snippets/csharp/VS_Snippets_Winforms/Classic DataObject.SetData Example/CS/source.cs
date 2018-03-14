using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void AddMyData4() {
    // Creates a new data object, and assigns it the component.
    DataObject myDataObject = new DataObject();
 
    // Adds data to the DataObject, and specifies no format conversion.
    myDataObject.SetData(DataFormats.UnicodeText, false, "My Unicode data");
 
    // Gets the data formats in the DataObject.
    String[] arrayOfFormats = myDataObject.GetFormats();
 
    // Prints the results.
    textBox1.Text = "The format(s) associated with the data are: " + '\n';
    for(int i=0; i<arrayOfFormats.Length; i++)
       textBox1.Text += arrayOfFormats[i] + '\n';
 }
 
// </Snippet1>
}
