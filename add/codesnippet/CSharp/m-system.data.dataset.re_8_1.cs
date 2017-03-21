    private void ReadSchemaFromStreamReader()
    {
        // Create the DataSet to read the schema into.
        DataSet thisDataSet = new DataSet();

        // Set the file path and name. Modify this for your purposes.
        string filename="Schema.xml";

        // Create a StreamReader object with the file path and name.
        System.IO.StreamReader readStream = 
            new System.IO.StreamReader(filename);

        // Invoke the ReadXmlSchema method with the StreamReader object.
        thisDataSet.ReadXmlSchema(readStream);

        // Close the StreamReader
        readStream.Close();
    }