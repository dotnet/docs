using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void GetMyData() {
    // Creates a component to store in the data object.
    Component myComponent = new Component();
 
    // Creates a new data object and assigns it the component.
    DataObject myDataObject = new DataObject(myComponent);
 
    // Creates a type to store the type of data.
    Type myType = myComponent.GetType();
 
    // Retrieves the data using myType to represent its type.
    Object myObject = myDataObject.GetData(myType);
    if(myObject != null)
       textBox1.Text = "The data type stored in the DataObject is: " +
       myObject.GetType().Name;
    else
       textBox1.Text = "Data of the specified type was not stored " +
       "in the DataObject.";
 }
 
// </Snippet1>
}
