using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

public class Form1: Form
{
   public Form1()
   {
      SetData2();
   }

// <snippet1>
private void SetData2() 
{
    // Creates a data object.
    DataObject myDataObject = new DataObject();
 
    // Stores a string, specifying the UnicodeText format.
    myDataObject.SetData(DataFormats.UnicodeText, "Hello World!");
 
    // Retrieves the data by specifying the Text format.
    string myMessageText = "The data type is " + myDataObject.GetData(DataFormats.Text).GetType().Name;

    // Displays the result.
    MessageBox.Show(myMessageText, "The Test Result");
}
// </snippet1>
    static void Main() 
    {
        Application.Run(new Form1());
    }

}

