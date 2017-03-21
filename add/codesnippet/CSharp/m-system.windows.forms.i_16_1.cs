        private void GetData3() 
        {
            // Creates a new data object using a text string.
            string myString = "Hello World!";
            DataObject myDataObject = new DataObject(DataFormats.Text, myString);
 
            // Displays the string with autoConvert equal to false.
            if (myDataObject.GetData("System.String", false) != null) 
            {
                // Displays the string in a message box.
                MessageBox.Show(myDataObject.GetData("System.String", false).ToString() + ".", "Message #1");
            } 
            else
                // Displays a not found message in a message box.
                MessageBox.Show("Could not find data of the specified format.", "Message #1");
 
            // Displays the string in a text box with autoConvert equal to true.
            string myData = "The data is " + myDataObject.GetData("System.String", true).ToString() +".";
            MessageBox.Show(myData,"Message #2");
        }