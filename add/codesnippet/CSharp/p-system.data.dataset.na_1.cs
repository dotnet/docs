    private void ReadData(DataSet thisDataSet)
    {
        thisDataSet.Namespace = "CorporationA";
        thisDataSet.Prefix = "DivisionA";

        // Read schema and data.
        string fileName = "CorporationA_Schema.xml";
        thisDataSet.ReadXmlSchema(fileName);
        fileName = "DivisionA_Report.xml";
        thisDataSet.ReadXml(fileName);
    }