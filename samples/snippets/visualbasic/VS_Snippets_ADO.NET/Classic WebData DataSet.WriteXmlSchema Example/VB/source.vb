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
' </Snippet1>
End Class
