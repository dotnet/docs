 Private Sub WriteXmlToFile(thisDataSet As DataSet)
     If thisDataSet Is Nothing Then
         Return
     End If

     ' Create a file name to write to.
     Dim filename As String = "XmlDoc.xml"

     ' Write to the file with the WriteXml method.
     thisDataSet.WriteXml(filename)
 End Sub