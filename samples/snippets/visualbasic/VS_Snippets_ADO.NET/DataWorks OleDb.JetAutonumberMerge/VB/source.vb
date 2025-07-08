Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.OleDb

Class Class1


    Shared Sub Main()
        Dim connectionString As String = GetConnectionString()
        connection = New OleDbConnection(connectionString)
        MergeIdentityColumns(connection)
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    Shared connection As OleDbConnection = Nothing

    Private Shared Sub MergeIdentityColumns(ByVal connection As OleDbConnection)
        Using connection

            ' Create a DataAdapter based on a SELECT query.
            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(
              "SELECT CategoryID, CategoryName FROM Categories",
              connection)

            ' Create the INSERT command for the new category.
            adapter.InsertCommand = New OleDbCommand(
              "INSERT INTO Categories (CategoryName) Values(?)", connection)
            adapter.InsertCommand.CommandType = CommandType.Text

            ' Add the parameter for the CategoryName.
            adapter.InsertCommand.Parameters.Add(
              "@CategoryName", OleDbType.VarWChar, 15, "CategoryName")
            adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both

            ' Create a DataTable.
            Dim categories As DataTable = New DataTable

            ' Create the CategoryID column and set its auto
            ' incrementing properties to decrement from zero.
            Dim column As New DataColumn()
            column.DataType = System.Type.GetType("System.Int32")
            column.ColumnName = "CategoryID"
            column.AutoIncrement = True
            column.AutoIncrementSeed = 0
            column.AutoIncrementStep = -1
            categories.Columns.Add(column)

            ' Create the CategoryName column.
            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "CategoryName"
            categories.Columns.Add(column)

            ' Set the primary key on CategoryID.
            Dim pKey(0) As DataColumn
            pKey(0) = categories.Columns("CategoryID")
            categories.PrimaryKey = pKey

            ' Fetch the data and fill the DataTable.
            adapter.Fill(categories)

            ' Add a new row.
            Dim newRow As DataRow = categories.NewRow()
            newRow("CategoryName") = "New Category"
            categories.Rows.Add(newRow)

            ' Add another new row.
            Dim newRow2 As DataRow = categories.NewRow()
            newRow2("CategoryName") = "Another New Category"
            categories.Rows.Add(newRow2)

            ' Add changed rows to a new DataTable that will be
            ' used to post the inserts to the database.
            Dim dataChanges As DataTable = categories.GetChanges()

            ' Include an event to fill in the Autonumber value.
            AddHandler adapter.RowUpdated,
              New OleDbRowUpdatedEventHandler(AddressOf OnRowUpdated)

            ' Update the database, inserting the new rows.
            adapter.Update(dataChanges)

            Console.WriteLine("Rows before merge:")
            Dim row1 As DataRow
            For Each row1 In categories.Rows
                Console.WriteLine("  {0}: {1}", row1(0), row1(1))
            Next

            ' Merge the two DataTables.
            categories.Merge(dataChanges)

            ' Commit the changes.
            categories.AcceptChanges()

            Console.WriteLine("Rows after merge:")
            Dim row As DataRow
            For Each row In categories.Rows
                Console.WriteLine("  {0}: {1}", row(0), row(1))
            Next
        End Using
    End Sub
    ' </Snippet1>

    ' <Snippet2>
    Private Shared Sub OnRowUpdated(
        ByVal sender As Object, ByVal e As OleDbRowUpdatedEventArgs)
        ' Conditionally execute this code block on inserts only.
        If e.StatementType = StatementType.Insert Then
            ' Retrieve the Autonumber and store it in the CategoryID column.
            Dim cmdNewID As New OleDbCommand("SELECT @@IDENTITY",
               connection)
            e.Row("CategoryID") = CInt(cmdNewID.ExecuteScalar)
            e.Status = UpdateStatus.SkipCurrentRow
        End If
    End Sub
    ' </Snippet2>
    Private Shared Function GetConnectionString() As String
        Throw New NotImplementedException()
    End Function
End Class
