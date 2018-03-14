using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

public class Form1: Form
{
   public Form1()
   {
      SetData3();
   }
// <snippet1>
private void SetData3() 
{
    // Creates a component.
    Component myComponent = new Component();
 
    // Gets the type of the component.
    Type myType = myComponent.GetType();
 
    // Creates a data object.
    DataObject myDataObject = new DataObject();
 
    // Stores the component in the data object.
    myDataObject.SetData(myType, myComponent);
 
    // Checks whether data of the specified type is in the data object.
    string myMessageText;
    if(myDataObject.GetDataPresent(myType))
        myMessageText = "Data of type " + myType.Name + 
            " is stored in the data object";
    else
        myMessageText = "No data of type " + myType.Name +
            " is stored in the data object";
            
    // Displays the result.
    MessageBox.Show(myMessageText, "The Test Result");
}
// </snippet1>
    static void Main() 
    {
        Application.Run(new Form1());
    }

}

