Option Explicit
Option Strict

Imports System
Imports System.Data

    
Module Module1
' <Snippet1>
  Sub Main()
    Dim table As New DataTable()

    ' Attempt to load data from a data reader in which
    ' the schema is incompatible with the current schema.
    ' If you use exception handling, you won't get the chance
    ' to examine each row, and each individual table,
    ' as the Load method progresses.
    ' By taking advantage of the FillErrorEventHandler delegate,
    ' you can interact with the Load process as an error occurs,
    ' attempting to fix the problem, or simply continuing or quitting
    ' the Load process:
    table = GetIntegerTable()
    Dim reader As New DataTableReader(GetStringTable())
    table.Load(reader, LoadOption.OverwriteChanges, _
        AddressOf FillErrorHandler)

    Console.WriteLine("Press any key to continue.")
    Console.ReadKey()
  End Sub

  Private Sub FillErrorHandler(ByVal sender As Object, _
    ByVal e As FillErrorEventArgs)
    ' You can use the e.Errors value to determine exactly what
    ' went wrong.
    If e.Errors.GetType Is GetType(System.FormatException) Then
      Console.WriteLine("Error when attempting to update the value: {0}", _
        e.Values(0))
    End If

    ' Setting e.Continue to True tells the Load
    ' method to continue trying. Setting it to False
    ' indicates that an error has occurred, and the 
    ' Load method raises the exception that got 
    ' you here.
    e.Continue = True
  End Sub

  Private Function GetIntegerTable() As DataTable
    ' Create sample table with a single Int32 column.
    Dim table As New DataTable

    Dim idColumn As DataColumn = table.Columns.Add("ID", GetType(Integer))

    ' Set the ID column as the primary key column.
    table.PrimaryKey = New DataColumn() {idColumn}

    table.Rows.Add(New Object() {4})
    table.Rows.Add(New Object() {5})
    table.TableName = "IntegerTable"
    table.AcceptChanges()
    Return table
  End Function

  Private Function GetStringTable() As DataTable
    ' Create sample table with a single String column.
    Dim table As New DataTable

    Dim idColumn As DataColumn = table.Columns.Add("ID", _
        GetType(String))

    ' Set the ID column as the primary key column.
    table.PrimaryKey = New DataColumn() {idColumn}

    table.Rows.Add(New Object() {"Mary"})
    table.Rows.Add(New Object() {"Andy"})
    table.Rows.Add(New Object() {"Peter"})
    table.AcceptChanges()
    Return table
  End Function

  Private Sub PrintColumns( _
     ByVal table As DataTable)

    ' Loop through all the rows in the DataTableReader.
    For Each row As DataRow In table.Rows
      For Each col As DataColumn In table.Columns
        Console.Write(row(col).ToString() & " ")
      Next
      Console.WriteLine()
    Next
  End Sub
' </Snippet1>
End Module

