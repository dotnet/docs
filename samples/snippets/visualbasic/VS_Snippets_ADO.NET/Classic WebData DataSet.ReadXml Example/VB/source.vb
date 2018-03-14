Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
Private Sub DemonstrateReadWriteXMLDocumentWithXMLReader()
    ' Create a DataSet with one table and two columns.
    Dim OriginalDataSet As New DataSet("dataSet")
    OriginalDataSet.Namespace = "NetFrameWork"
    Dim table As New DataTable("table")
    Dim idColumn As New DataColumn("id", _
        Type.GetType("System.Int32"))
    idColumn.AutoIncrement = True

    Dim itemColumn As New DataColumn("item")
    table.Columns.Add(idColumn)
    table.Columns.Add(itemColumn)
    OriginalDataSet.Tables.Add(table)

    ' Add ten rows.
    Dim newRow As DataRow
    Dim i As Integer
    For i = 0 To 9
        newRow = table.NewRow()
        newRow("item") = "item " & i.ToString()
        table.Rows.Add(newRow)
    Next i
    OriginalDataSet.AcceptChanges()

    ' Print out values of each table in the DataSet 
    ' using the function defined below.
    PrintValues(OriginalDataSet, "Original DataSet")

    ' Write the XML schema and data to file with FileStream.
    Dim xmlFilename As String = "XmlDocument.xml"

    ' Create FileStream    
    Dim fsWriteXml As New System.IO.FileStream _
        (xmlFilename, System.IO.FileMode.Create)

    ' Create an XmlTextWriter to write the file.
    Dim xmlWriter As New System.Xml.XmlTextWriter _
        (fsWriteXml, System.Text.Encoding.Unicode)

    ' Use WriteXml to write the document.
    OriginalDataSet.WriteXml(xmlWriter, XmlWriteMode.WriteSchema)

    ' Close the FileStream.
    fsWriteXml.Close()
        
    ' Dispose of the original DataSet.
    OriginalDataSet.Dispose()

    ' Create a new DataSet.
    Dim newDataSet As New DataSet("New DataSet")
        
    ' Read the XML document back in. 
    ' Create new FileStream to read schema with.
    Dim fsReadXml As New System.IO.FileStream _
        (xmlFilename, System.IO.FileMode.Open)

    ' Create an XmlTextReader to read the file.
    Dim xmlReader As New System.Xml.XmlTextReader(fsReadXml)

    ' Read the XML document into the DataSet.
    newDataSet.ReadXml(xmlReader, XmlReadMode.ReadSchema)

    ' Close the XmlTextReader
    xmlReader.Close()
        
    ' Print out values of each table in the DataSet using the 
    ' function defined below.
    PrintValues(newDataSet, "New DataSet")
End Sub
    
    
 Private Sub PrintValues(dataSet As DataSet, label As String)
     Console.WriteLine(ControlChars.Cr & label)
     Dim table As DataTable
     Dim row As DataRow
     Dim column As DataColumn
     For Each table In  dataSet.Tables
         Console.WriteLine("TableName: " & table.TableName)
         For Each row In  table.Rows
             For Each column In  table.Columns
                 Console.Write(ControlChars.Tab & "{0}({1})='{2}'", column.ColumnName, column.DataType.Name, row(column).ToString())

             Next column
             Console.WriteLine()
         Next row
     Next table
  End Sub
' </Snippet1>
End Class 'Form1 
