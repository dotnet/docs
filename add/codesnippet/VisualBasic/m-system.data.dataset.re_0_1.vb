 Private Sub ReadSchemaFromFile()
     ' Create the DataSet to read the schema into.
     Dim thisDataSet As New DataSet()

     ' Set the file path and name. Modify this for your purposes.
     Dim filename As String = "Schema.xml"

     ' Invoke the ReadXmlSchema method with the file name.
     thisDataSet.ReadXmlSchema(filename)
 End Sub