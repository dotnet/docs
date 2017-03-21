private void CreateDefaultDataObject() {
    // Creates a data object.
    DataObject myDataObject;
 
    // Assigns the string to the data object.
    string myString = "My text string";
    myDataObject = new DataObject(myString);
 
    // Prints the string in a text box.
    textBox1.Text = myDataObject.GetData(DataFormats.Text).ToString();
 }
 