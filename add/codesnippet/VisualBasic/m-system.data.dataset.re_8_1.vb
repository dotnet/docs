 Private Sub ReadSchemaFromStreamReader()
     ' Create the DataSet to read the schema into.
     Dim thisDataSet As New DataSet()

     ' Set the file path and name. Modify this for your purposes.
     Dim filename As String = "Schema.xml"

     ' Create a StreamReader object with the file path and name.
     Dim readStream As New System.IO.StreamReader(filename)

     ' Invoke the ReadXmlSchema method with the StreamReader object.
     thisDataSet.ReadXmlSchema(readStream)

     ' Close the StreamReader
     readStream.Close()
 End Sub