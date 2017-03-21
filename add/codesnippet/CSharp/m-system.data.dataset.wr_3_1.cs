    private void WriteXmlToFile(DataSet thisDataSet) 
    {
        if (thisDataSet == null) { return; }

        // Create a file name to write to.
        string filename = "XmlDoc.xml";

        // Write to the file with the WriteXml method.
        thisDataSet.WriteXml(filename);
    }