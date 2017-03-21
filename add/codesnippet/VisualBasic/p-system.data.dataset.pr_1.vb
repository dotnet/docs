 Private Sub ReadData(thisDataSet As DataSet)
     thisDataSet.Namespace = "CorporationA"
     thisDataSet.Prefix = "DivisionA"

     ' Read schema and data.
     Dim fileName As String = "CorporationA_Schema.xml"
     thisDataSet.ReadXmlSchema(fileName)
     fileName = "DivisionA_Report.xml"
     thisDataSet.ReadXml(fileName)
 End Sub