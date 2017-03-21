Private Sub ReadSchemaFromFileStream(thisDataSet As DataSet)
    ' Set the file path and name. Modify this for your purposes.
    Dim filename As String = "Schema.xml"

    ' Create the FileStream object with the file name, 
    ' and set to open the file
    Dim stream As New System.IO.FileStream _
        (filename, System.IO.FileMode.Open)

    ' Read the schema into the DataSet.
    thisDataSet.ReadXmlSchema(stream)

    ' Close the FileStream.
    stream.Close()
End Sub