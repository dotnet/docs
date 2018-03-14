Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.OleDb
Imports System.IO

Module Module1

    Sub Main()
        Dim x As String = "Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI;Initial Catalog=Northwind"
        CreateDataAdapter(x)
    End Sub

    ' <Snippet1>
    Public Sub CreateDataAdapter(ByVal connectionString As String)
        Using connection As New OleDbConnection(connectionString)
            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter( _
                "SELECT * FROM Customers WHERE CustomerID = 'ALFKI'", connection)

            adapter.InsertCommand = New OleDbCommand( _
                "INSERT INTO Customers (CustomerID, CompanyName) VALUES(?, ?)", _
                connection)

            adapter.InsertCommand.Parameters.Add( _
                "@CustomerID", OleDbType.VarChar, 5, "CustomerID")
            adapter.InsertCommand.Parameters.Add( _
                "@CompanyName", OleDbType.VarChar, 30, "CompanyName")

            connection.Open()

            Dim custDS As DataSet = New DataSet()
            adapter.Fill(custDS, "Customers")

            Dim custRow As DataRow = custDS.Tables("Customers").NewRow()
            custRow("CustomerID") = "NEWCO"
            custRow("CompanyName") = "New Company"
            custDS.Tables("Customers").Rows.Add(custRow)

            ' add handlers
            AddHandler adapter.RowUpdating, _
                New OleDbRowUpdatingEventHandler(AddressOf OnRowUpdating)
            AddHandler adapter.RowUpdated, _
                New OleDbRowUpdatedEventHandler(AddressOf OnRowUpdated)

            adapter.Update(custDS, "Customers")

            ' remove handlers
            RemoveHandler adapter.RowUpdating, _
                New OleDbRowUpdatingEventHandler(AddressOf OnRowUpdating)
            RemoveHandler adapter.RowUpdated, _
                New OleDbRowUpdatedEventHandler(AddressOf OnRowUpdated)

            Dim row As DataRow
            For Each row In custDS.Tables("Customers").Rows
                If row.HasErrors Then Console.WriteLine(row.RowError)
            Next
        End Using
    End Sub

    Sub OnRowUpdating(ByVal sender As Object, _
        ByVal args As OleDbRowUpdatingEventArgs)

        If args.StatementType = StatementType.Insert Then
            Dim writer As System.IO.TextWriter = _
                System.IO.File.AppendText("Inserts.log")
            writer.WriteLine("{0}: Customer {1} Inserted.", _
                DateTime.Now, args.Row("CustomerID"))
            writer.Close()
        End If
    End Sub

    Sub OnRowUpdated(ByVal sender As Object, _
        ByVal args As OleDbRowUpdatedEventArgs)

        If args.Status = UpdateStatus.ErrorsOccurred Then
            args.Row.RowError = args.Errors.Message
            args.Status = UpdateStatus.SkipCurrentRow
        End If
    End Sub
    ' </Snippet1>
End Module
