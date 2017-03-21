Private Sub WriteSchemaWithFileStream(thisDataSet As DataSet)
    ' Set the file path and name. Modify this for your purposes.
    Dim filename As String = "Schema.xml"

    ' Create the FileStream object with the file name. 
    ' Use FileMode.Create.
    Dim stream As New System.IO.FileStream _
        (filename, System.IO.FileMode.Create)

    ' Write the schema to the file.
    thisDataSet.WriteXmlSchema(stream)

    ' Close the FileStream.
    stream.Close()
End Sub