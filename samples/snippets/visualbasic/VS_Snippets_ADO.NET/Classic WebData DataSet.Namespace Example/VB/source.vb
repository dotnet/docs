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
 Private Sub ReadData(thisDataSet As DataSet)
     thisDataSet.Namespace = "CorporationA"
     thisDataSet.Prefix = "DivisionA"

     ' Read schema and data.
     Dim fileName As String = "CorporationA_Schema.xml"
     thisDataSet.ReadXmlSchema(fileName)
     fileName = "DivisionA_Report.xml"
     thisDataSet.ReadXml(fileName)
 End Sub
' </Snippet1>
End Class
