 private void ReadSchemaFromFile(){
    // Create the DataSet to read the schema into.
    DataSet thisDataSet = new DataSet();

    // Set the file path and name. Modify this for your purposes.
    string filename="Schema.xml";

    // Invoke the ReadXmlSchema method with the file name.
    thisDataSet.ReadXmlSchema(filename);
 }