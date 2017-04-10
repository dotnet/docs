Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
 Private Sub ReadSchemaFromXmlTextReader()
     ' Create the DataSet to read the schema into.
     Dim thisDataSet As New DataSet()

     ' Set the file path and name. Modify this for your purposes.
     Dim filename As String = "Schema.xml"

     ' Create a FileStream object with the file path and name.
     Dim stream As New System.IO.FileStream _
        (filename, System.IO.FileMode.Open)

     ' Create a new XmlTextReader object with the FileStream.
     Dim xmlReader As New System.Xml.XmlTextReader(stream)

     ' Read the schema into the DataSet and close the reader.
     thisDataSet.ReadXmlSchema(xmlReader)
     xmlReader.Close()
 End Sub
' </Snippet1>
End Class
