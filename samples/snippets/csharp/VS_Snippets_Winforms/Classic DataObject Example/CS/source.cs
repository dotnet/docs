using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void AddMyData3() {
    // Creates a component to store in the data object.
    Component myComponent = new Component();
 
    // Creates a new data object.
    DataObject myDataObject = new DataObject();
 
    // Adds the component to the DataObject.
    myDataObject.SetData(myComponent);
 
    // Prints whether data of the specified type is in the DataObject.
    Type myType = myComponent.GetType();
    if(myDataObject.GetDataPresent(myType))
       textBox1.Text = "Data of type " + myType.ToString() + 
       " is present in the DataObject";
    else
       textBox1.Text = "Data of type " + myType.ToString() +
       " is not present in the DataObject";
 }
 // </Snippet1>
// <Snippet2>
private void GetMyData2() {
    // Creates a new data object using a string and the text format.
    DataObject myDataObject = new DataObject(DataFormats.Text, "Text to Store");
 
    // Prints the string in a text box.
    textBox1.Text = myDataObject.GetData(DataFormats.Text).ToString();
 }
 // </Snippet2>
}
