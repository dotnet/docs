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