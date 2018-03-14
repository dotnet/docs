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
 Private Sub WriteSchemaWithXmlTextWriter(thisDataSet As DataSet)
     ' Set the file path and name. Modify this for your purposes.
     Dim filename As String = "SchemaDoc.xml"

     ' Create a FileStream object with the file path and name.
     Dim stream As New System.IO.FileStream _
        (filename, System.IO.FileMode.Create)

     ' Create a new XmlTextWriter object with the FileStream.
     Dim writer As New System.Xml.XmlTextWriter _
        (stream, System.Text.Encoding.Unicode)

     ' Write the schema into the DataSet and close the reader.
     thisDataSet.WriteXmlSchema(writer)
     writer.Close()
 End Sub
' </Snippet1>
End Class
