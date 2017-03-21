        private void TestDataObject() 
        {
            // Creates a new data object using a string and the Text format.
            string myString = "Hello World!";
            DataObject myDataObject = new DataObject(DataFormats.Text, myString);
 
            // Checks whether the data is present in the Text format and displays the result.
            if (myDataObject.GetDataPresent(DataFormats.Text))
                MessageBox.Show("The stored data is in the Text format." , "Test Result");
            else
                MessageBox.Show("The stored data is not in the Text format.", "Test Result");
        }