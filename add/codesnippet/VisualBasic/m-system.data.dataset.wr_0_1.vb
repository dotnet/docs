 Private Sub WriteSchemaWithStringWriter(thisDataSet As DataSet)
     ' Create a new StringBuilder object.
     Dim builder As New System.Text.StringBuilder()

     ' Create the StringWriter object with the StringBuilder object.
     Dim writer As New System.IO.StringWriter(builder)

     ' Write the schema into the StringWriter.
     thisDataSet.WriteXmlSchema(writer)

     ' Print the string to the console window.
     Console.WriteLine(writer.ToString())
 End Sub