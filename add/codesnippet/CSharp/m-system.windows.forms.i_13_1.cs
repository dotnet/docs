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