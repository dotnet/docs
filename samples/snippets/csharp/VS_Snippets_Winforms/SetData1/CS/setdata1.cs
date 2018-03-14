using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

public class Form1: Form
{
   public Form1()
   {
      SetData1();
   }
// <snippet1>
private void SetData1() 
{
    // Creates a component to store in the data object.
    Component myComponent = new Component();
 
    // Creates a data object.
    DataObject myDataObject = new DataObject();

    // Adds the component to the data object.
    myDataObject.SetData(myComponent);
 
    // Checks whether data of the specified type is in the data object.
    Type myType = myComponent.GetType();
    string myMessageText;
    if(myDataObject.GetDataPresent(myType))
         myMessageText = "Data of type " + myType.Name + 
            " is present in the data object";
    else
        myMessageText = "Data of type " + myType.Name +
            " is not present in the data object";

    // Displays the result in a message box.
    MessageBox.Show(myMessageText, "The Test Result"); 
}
// </snippet1>
    static void Main() 
    {
        Application.Run(new Form1());
    }

}

