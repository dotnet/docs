private void AddMyData() {
    // Creates a new data object using a string and the text format.
    DataObject myDataObject = new DataObject();
 
    // Stores a string, specifying the Unicode format.
    myDataObject.SetData(DataFormats.UnicodeText, "Text string");
 
    // Retrieves the data by specifying Text.
    textBox1.Text = myDataObject.GetData(DataFormats.Text).GetType().Name;
 }
 