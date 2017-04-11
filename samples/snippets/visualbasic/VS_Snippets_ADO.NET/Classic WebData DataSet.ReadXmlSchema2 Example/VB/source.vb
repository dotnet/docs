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
' </Snippet1>
End Class
