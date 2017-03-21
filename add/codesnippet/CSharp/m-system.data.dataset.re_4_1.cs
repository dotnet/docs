    private void ReadSchemaFromXmlTextReader()
    {
        // Create the DataSet to read the schema into.
        DataSet thisDataSet = new DataSet();

        // Set the file path and name. Modify this for your purposes.
        string filename="Schema.xml";

        // Create a FileStream object with the file path and name.
        System.IO.FileStream stream = new System.IO.FileStream
            (filename,System.IO.FileMode.Open);

        // Create a new XmlTextReader object with the FileStream.
        System.Xml.XmlTextReader xmlReader= 
            new System.Xml.XmlTextReader(stream);

        // Read the schema into the DataSet and close the reader.
        thisDataSet.ReadXmlSchema(xmlReader);
        xmlReader.Close();
    }