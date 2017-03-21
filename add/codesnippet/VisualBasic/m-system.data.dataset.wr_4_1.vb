 Private Sub WriteSchemaToFile(thisDataSet As DataSet)
     ' Set the file path and name. Modify this for your purposes.
     Dim filename As String = "Schema.xml"

     ' Write the schema to the file.
     thisDataSet.WriteXmlSchema(filename)
 End Sub