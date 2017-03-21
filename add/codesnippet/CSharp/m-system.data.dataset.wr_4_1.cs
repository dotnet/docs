    private void WriteSchemaToFile(DataSet thisDataSet)
    {
        // Set the file path and name. Modify this for your purposes.
        string filename="Schema.xml";

        // Write the schema to the file.
        thisDataSet.WriteXmlSchema(filename);
    }