using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void CreateDefaultDataObject() {
    // Creates a data object.
    DataObject myDataObject;
 
    // Assigns the string to the data object.
    string myString = "My text string";
    myDataObject = new DataObject(myString);
 
    // Prints the string in a text box.
    textBox1.Text = myDataObject.GetData(DataFormats.Text).ToString();
 }
 
// </Snippet1>
}
