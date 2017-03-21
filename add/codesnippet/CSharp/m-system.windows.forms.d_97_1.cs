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
       textBox1.Text = "Data of type " + myType.GetType().Name + 
       " is present in the DataObject";
    else
       textBox1.Text = "Data of type " + myType.GetType().Name +
       " is not present in the DataObject";
 }
    