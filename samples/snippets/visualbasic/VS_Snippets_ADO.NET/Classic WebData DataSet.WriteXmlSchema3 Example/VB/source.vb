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
 Private Sub WriteSchemaToFile(thisDataSet As DataSet)
     ' Set the file path and name. Modify this for your purposes.
     Dim filename As String = "Schema.xml"

     ' Write the schema to the file.
     thisDataSet.WriteXmlSchema(filename)
 End Sub
' </Snippet1>
End Class
