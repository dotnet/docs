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
 Private Sub DemonstrateReadWriteXMLDocumentWithFileStream()
     ' Create a DataSet with one table and two columns.
     Dim originalDataSet As New DataSet("dataSet")
     Dim table As New DataTable("table")
     Dim idColumn As New DataColumn("id", _
        Type.GetType("System.Int32"))
     idColumn.AutoIncrement = True

     Dim itemColumn As New DataColumn("item")
     table.Columns.Add(idColumn)
     table.Columns.Add(itemColumn)
     originalDataSet.Tables.Add(table)

     ' Add ten rows.
     Dim newRow As DataRow
     Dim i As Integer
     For i = 0 To 9
         newRow = table.NewRow()
         newRow("item") = "item " & i.ToString()
         table.Rows.Add(newRow)
     Next i
     originalDataSet.AcceptChanges()

     ' Print out values of each table in the DataSet 
     ' using the function defined below.
     PrintValues(originalDataSet, "Original DataSet")

     ' Write the schema and data to XML file with FileStream.
     Dim xmlFilename As String = "XmlDocument.xml"
     Dim streamWrite As New System.IO.FileStream _
        (xmlFilename, System.IO.FileMode.Create)

     ' Use WriteXml to write the XML document.
     originalDataSet.WriteXml(streamWrite)

     ' Close the FileStream.
     streamWrite.Close()
      
     ' Dispose of the original DataSet.
     originalDataSet.Dispose()
     ' Create a new DataSet.
     Dim newDataSet As New DataSet("New DataSet")
        
     ' Read the XML document back in. 
     ' Create new FileStream to read schema with.
     Dim streamRead As New System.IO.FileStream _
        (xmlFilename, System.IO.FileMode.Open)
      
     newDataSet.ReadXml(streamRead)
     ' Print out values of each table in the DataSet  
     ' using the function defined below.
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
                 Console.Write(ControlChars.Tab & " " & _
                    row(column).ToString())
             Next column
             Console.WriteLine()
         Next row
     Next table
 End Sub
' </Snippet1>
End Class 'Form1 
