    private void WriteXmlToFile(DataSet thisDataSet) 
    {
        if (thisDataSet == null) { return; }

        // Create a file name to write to.
        string filename = "XmlDoc.xml";

        // Create the FileStream to write with.
        System.IO.FileStream stream = new System.IO.FileStream
            (filename, System.IO.FileMode.Create);

        // Create an XmlTextWriter with the fileStream.
        System.Xml.XmlTextWriter xmlWriter = 
            new System.Xml.XmlTextWriter(stream, 
            System.Text.Encoding.Unicode);

        // Write to the file with the WriteXml method.
        thisDataSet.WriteXml(xmlWriter);   
        xmlWriter.Close();
    }