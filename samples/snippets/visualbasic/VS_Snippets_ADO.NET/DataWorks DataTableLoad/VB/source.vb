Option Explicit
Option Strict

Imports System
Imports System.Data

    
Module Module1
' <Snippet1>
  Sub Main()
    Dim table As New DataTable()

    ' This example examines a number of scenarios involving the 
    ' DataTable.Load method.
    Console.WriteLine("Load a DataTable and infer its schema:")

    ' Retrieve a data reader, based on the Customers data. In
    ' an application, this data might be coming from a middle-tier
    ' business object:
    Dim reader As New DataTableReader(GetCustomers())

    ' The table has no schema. The Load method will infer the 
    ' schema from the IDataReader:
    table.Load(reader)
    PrintColumns(table)

    Console.WriteLine(" ============================= ")
    Console.WriteLine("Load a DataTable from an incompatible IDataReader:")

    ' Create a table with a single integer column. Attempt
    ' to load data from a reader with a schema that is 
    ' incompatible. Note the exception, determined
    ' by the particular incompatibility:
    table = GetIntegerTable()
    reader = New DataTableReader(GetStringTable())
    Try
      table.Load(reader)
    Catch ex As Exception
      Console.WriteLine(ex.GetType.Name & ":" & ex.Message())
    End Try

    Console.WriteLine(" ============================= ")
    Console.WriteLine( _
        "Load a DataTable with an IDataReader that has extra columns:")

    ' Note that loading a reader with extra columns adds
    ' the columns to the existing table, if possible:
    table = GetIntegerTable()
    reader = New DataTableReader(GetCustomers())
    table.Load(reader)
    PrintColumns(table)

    Console.WriteLine(" ============================= ")
    Console.WriteLine( _
        "Load a DataTable with an IDataReader that has missing columns:")

    ' Note that loading a reader with missing columns causes 
    ' the columns to be filled with null data, if possible:
    table = GetCustomers()
    reader = New DataTableReader(GetIntegerTable())
    table.Load(reader)
    PrintColumns(table)

    ' Demonstrate the various possibilites when loading data into
    ' a DataTable that already contains data.
    Console.WriteLine(" ============================= ")
    Console.WriteLine("Demonstrate data considerations:")
    Console.WriteLine("Current value, Original value, (RowState)")
    Console.WriteLine(" ============================= ")
    Console.WriteLine("Original table:")

    table = SetupModifiedRows()
    DisplayRowState(table)

    Console.WriteLine(" ============================= ")
    Console.WriteLine("Data in IDataReader to be loaded:")
    DisplayRowState(GetChangedCustomers())

    PerformDemo(LoadOption.OverwriteChanges)
    PerformDemo(LoadOption.PreserveChanges)
    PerformDemo(LoadOption.Upsert)

    Console.WriteLine("Press any key to continue.")
    Console.ReadKey()
  End Sub

  Private Sub DisplayRowState(ByVal table As DataTable)
    For i As Integer = 0 To table.Rows.Count - 1
      Dim current As Object = "--"
      Dim original As Object = "--"
      Dim rowState As DataRowState = table.Rows(i).RowState

      ' Attempt to retrieve the current value, which doesn't exist
      ' for deleted rows:
      If rowState <> DataRowState.Deleted Then
        current = table.Rows(i)("Name", DataRowVersion.Current)
      End If

      ' Attempt to retrieve the original value, which doesn't exist
      ' for added rows:
      If rowState <> DataRowState.Added Then
        original = table.Rows(i)("Name", DataRowVersion.Original)
      End If
      Console.WriteLine("{0}: {1}, {2} ({3})", i, current, original, rowState)
    Next
  End Sub

  Private Function GetChangedCustomers() As DataTable
    ' Create sample Customers table.
    Dim table As New DataTable

    ' Create two columns, ID and Name.
    Dim idColumn As DataColumn = table.Columns.Add("ID", GetType(Integer))
    table.Columns.Add("Name", GetType(String))

    ' Set the ID column as the primary key column.
    table.PrimaryKey = New DataColumn() {idColumn}

    table.Rows.Add(New Object() {0, "XXX"})
    table.Rows.Add(New Object() {1, "XXX"})
    table.Rows.Add(New Object() {2, "XXX"})
    table.Rows.Add(New Object() {3, "XXX"})
    table.Rows.Add(New Object() {4, "XXX"})
    table.AcceptChanges()
    Return table
  End Function

  Private Function GetCustomers() As DataTable
    ' Create sample Customers table.
    Dim table As New DataTable

    ' Create two columns, ID and Name.
    Dim idColumn As DataColumn = table.Columns.Add("ID", GetType(Integer))
    table.Columns.Add("Name", GetType(String))

    ' Set the ID column as the primary key column.
    table.PrimaryKey = New DataColumn() {idColumn}

    table.Rows.Add(New Object() {0, "Mary"})
    table.Rows.Add(New Object() {1, "Andy"})
    table.Rows.Add(New Object() {2, "Peter"})
    table.AcceptChanges()
    Return table
  End Function

  Private Function GetIntegerTable() As DataTable
    ' Create sample table with a single Int32 column.
    Dim table As New DataTable

    Dim idColumn As DataColumn = table.Columns.Add("ID", GetType(Integer))

    ' Set the ID column as the primary key column.
    table.PrimaryKey = New DataColumn() {idColumn}

    table.Rows.Add(New Object() {4})
    table.Rows.Add(New Object() {5})
    table.AcceptChanges()
    Return table
  End Function

  Private Function GetStringTable() As DataTable
    ' Create sample table with a single String column.
    Dim table As New DataTable

    Dim idColumn As DataColumn = table.Columns.Add("ID", GetType(String))

    ' Set the ID column as the primary key column.
    table.PrimaryKey = New DataColumn() {idColumn}

    table.Rows.Add(New Object() {"Mary"})
    table.Rows.Add(New Object() {"Andy"})
    table.Rows.Add(New Object() {"Peter"})
    table.AcceptChanges()
    Return table
  End Function

  Private Sub PerformDemo(ByVal optionForLoad As LoadOption)

    ' Load data into a DataTable, retrieve a DataTableReader containing
    ' different data, and call the Load method. Depending on the
    ' LoadOption value passed as a parameter, this procedure displays
    ' different results in the DataTable.
    Console.WriteLine(" ============================= ")
    Console.WriteLine("table.Load(reader, {0})", optionForLoad)
    Console.WriteLine(" ============================= ")

    Dim table As DataTable = SetupModifiedRows()
    Dim reader As New DataTableReader(GetChangedCustomers())
    AddHandler table.RowChanging, New _
        DataRowChangeEventHandler(AddressOf HandleRowChanging)

    table.Load(reader, optionForLoad)
    Console.WriteLine()
    DisplayRowState(table)
  End Sub

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

  Private Function SetupModifiedRows() As DataTable
    ' Fill a DataTable with customer info, and 
    ' then modify, delete, and add rows.

    Dim table As DataTable = GetCustomers()
    ' Row 0 is unmodified.
    ' Row 1 is modified.
    ' Row 2 is deleted.
    ' Row 3 is added.
    table.Rows(1)("Name") = "Sydney"
    table.Rows(2).Delete()
    Dim row As DataRow = table.NewRow
    row("ID") = 3
    row("Name") = "Melony"
    table.Rows.Add(row)

    ' Note that the code doesn't call
    ' table.AcceptChanges()
    Return table
  End Function

  Private Sub HandleRowChanging(ByVal sender As Object, _
    ByVal e As System.Data.DataRowChangeEventArgs)
    Console.WriteLine( _
        "RowChanging event: ID = {0}, action = {1}", e.Row("ID"), _
        e.Action)
  End Sub
' </Snippet1>

End Module
