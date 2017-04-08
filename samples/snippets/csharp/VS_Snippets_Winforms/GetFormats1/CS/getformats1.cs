using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

public class Form1: Form
{
// <snippet1>
private void GetFormats1() 
{
    // Creates a data object using a string and the Text format.
    DataObject myDataObject = new DataObject(DataFormats.Text, "My text string");
 
    // Gets all the data formats and data conversion formats in the data object.
    String[] allFormats = myDataObject.GetFormats();

    // Creates the string that contains the formats.
    string theResult = "The format(s) associated with the data are: " + '\n';
    for(int i = 0; i < allFormats.Length; i++)
        theResult += allFormats[i] + '\n';
    // Displays the result in a message box.
    MessageBox.Show(theResult);
}
// </snippet1>
    static void Main() 
    {
        Application.Run(new Form1());
    }

}
