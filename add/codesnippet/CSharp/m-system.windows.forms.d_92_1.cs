private void CreateTextDataObject() {
    // Creates a new data object using a string.
    string myString = "My text string";
    DataObject myDataObject = new DataObject(myString);
 
    // Prints the string in a text box.
    textBox1.Text = myDataObject.GetData(DataFormats.Text).ToString();
 }
 