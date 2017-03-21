 Private Sub WriteXmlToFile(thisDataSet As DataSet)
     If thisDataSet Is Nothing Then
         Return
     End If

     ' Create a file name to write to.
     Dim filename As String = "XmlDoc.xml"

     ' Create the FileStream to write with.
     Dim stream As New System.IO.FileStream _
        (filename, System.IO.FileMode.Create)

     ' Create an XmlTextWriter with the fileStream.
     Dim xmlWriter As New System.Xml.XmlTextWriter _
        (stream, System.Text.Encoding.Unicode)

     ' Write to the file with the WriteXml method.
     thisDataSet.WriteXml(xmlWriter)
     xmlWriter.Close()
 End Sub