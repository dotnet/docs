private void GetMyData3() {
    // Creates a new data object using a string and the text format.
    string myString = "My new text string";
    DataObject myDataObject = new DataObject(DataFormats.Text, myString);
 
    // Prints the string in a text box with autoconvert = false.
    if(myDataObject.GetData("System.String", false) != null) {
       // Prints the string in a text box.
       textBox1.Text = myDataObject.GetData("System.String", false).ToString() + '\n';
    } else
       textBox1.Text = "Could not find data of the specified format" + '\n';
 
    // Prints the string in a text box with autoconvert = true.
    textBox1.Text += myDataObject.GetData("System.String", true).ToString();
 }
 