        private void SetData4() 
        {
            // Creates a new data object.
            DataObject myDataObject = new DataObject();
 
            // Adds UnicodeText string to the object, and set the autoConvert 
            // parameter to false.
            myDataObject.SetData(DataFormats.UnicodeText, false, "My text string");
 
            // Gets the data format(s) in the data object.
            String[] arrayOfFormats = myDataObject.GetFormats();
 
            // Stores the results in a string.
            string theResult = "The format(s) associated with the data are:" + '\n';
            for(int i=0; i<arrayOfFormats.Length; i++)
                theResult += arrayOfFormats[i] + '\n';
            
            // Show the results in a message box. 
            MessageBox.Show(theResult);

        }