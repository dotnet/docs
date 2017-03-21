    private void WriteSchemaWithStringWriter(DataSet thisDataSet)
    {
        // Create a new StringBuilder object.
        System.Text.StringBuilder builder = new System.Text.StringBuilder();

        // Create the StringWriter object with the StringBuilder object.
        System.IO.StringWriter writer = new System.IO.StringWriter(builder);

        // Write the schema into the StringWriter.
        thisDataSet.WriteXmlSchema(writer);

        // Print the string to the console window.
        Console.WriteLine(writer.ToString());
    }