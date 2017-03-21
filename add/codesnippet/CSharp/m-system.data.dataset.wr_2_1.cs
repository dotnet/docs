    private void WriteXmlToFile(DataSet thisDataSet) 
    {
        if (thisDataSet == null) { return; }

        // Create a file name to write to.
        string filename = "XmlDoc.xml";

        // Create the FileStream to write with.
        System.IO.FileStream stream = new System.IO.FileStream
            (filename, System.IO.FileMode.Create);

        // Write to the file with the WriteXml method.
        thisDataSet.WriteXml(stream);   
    }