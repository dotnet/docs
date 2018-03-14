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
' </Snippet1>
End Class
