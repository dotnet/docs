    private void ReadSchemaFromFileStream(DataSet thisDataSet)
    {
        // Set the file path and name.
        // Modify this for your purposes.
        string filename="Schema.xml";

        // Create the FileStream object with the file name, 
        // and set to open the file.
        System.IO.FileStream stream = 
            new System.IO.FileStream(filename,System.IO.FileMode.Open);

        // Read the schema into the DataSet.
        thisDataSet.ReadXmlSchema(stream);

        // Close the FileStream.
        stream.Close();
    }