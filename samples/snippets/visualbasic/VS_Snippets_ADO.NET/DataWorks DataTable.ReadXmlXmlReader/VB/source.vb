Option Explicit
Option Strict

Imports System
Imports System.Data

    
Module Module1

  Sub Main()
    DemonstrateReadWriteXMLDocumentWithReader()
    Console.WriteLine("Press any key to continue.")
    Console.ReadKey()
  End Sub
' <Snippet1>
  Private Sub DemonstrateReadWriteXMLDocumentWithReader()
    Dim table As DataTable = CreateTestTable("XmlDemo")
    PrintValues(table, "Original table")

    ' Write the schema and data to XML in a memory stream.
    Dim xmlStream As New System.IO.MemoryStream()
    table.WriteXml(xmlStream, XmlWriteMode.WriteSchema)

    ' Rewind the memory stream.
    xmlStream.Position = 0

    Dim reader As New System.Xml.XmlTextReader(xmlStream)
    Dim newTable As New DataTable
    newTable.ReadXml(reader)

    ' Print out values in the table.
    PrintValues(newTable, "New Table")
  End Sub

  Private Function CreateTestTable(ByVal tableName As String) _
    As DataTable
    ' Create a test DataTable with two columns and a few rows.
    Dim table As New DataTable(tableName)
    Dim column As New DataColumn("id", GetType(System.Int32))
    column.AutoIncrement = True
    table.Columns.Add(column)

    column = New DataColumn("item", GetType(System.String))
    table.Columns.Add(column)

    ' Add ten rows.
    Dim row As DataRow
    For i As Integer = 0 To 9
      row = table.NewRow()
      row("item") = "item " & i
      table.Rows.Add(row)
    Next i

    table.AcceptChanges()
    Return table
  End Function

  Private Sub PrintValues(ByVal table As DataTable, _
    ByVal label As String)
    Console.WriteLine(label)
    For Each row As DataRow In table.Rows
      For Each column As DataColumn In table.Columns
        Console.Write("{0}{1}", ControlChars.Tab, row(column))
      Next column
      Console.WriteLine()
    Next row
  End Sub
' </Snippet1>

End Module
