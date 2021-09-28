Option Explicit
Option Strict

Imports System.Data

Module Module1

    ' <Snippet1>
    Sub Main()
        TestCreateDataReader(GetCustomers())
        Console.WriteLine("Press any key to continue.")
        Console.ReadKey()
    End Sub

    Private Sub TestCreateDataReader(ByVal dt As DataTable)
        ' Given a DataTable, retrieve a DataTableReader
        ' allowing access to all the tables's data:
        Using reader As DataTableReader = dt.CreateDataReader()
            Do
                If Not reader.HasRows Then
                    Console.WriteLine("Empty DataTableReader")
                Else
                    PrintColumns(reader)
                End If
                Console.WriteLine("========================")
            Loop While reader.NextResult()
        End Using
    End Sub

    Private Function GetCustomers() As DataTable
        ' Create sample Customers table, in order
        ' to demonstrate the behavior of the DataTableReader.
        Dim table As New DataTable

        ' Create two columns, ID and Name.
        Dim idColumn As DataColumn = table.Columns.Add("ID", GetType(Integer))
        table.Columns.Add("Name", GetType(String))

        ' Set the ID column as the primary key column.
        table.PrimaryKey = New DataColumn() {idColumn}

        table.Rows.Add(New Object() {1, "Mary"})
        table.Rows.Add(New Object() {2, "Andy"})
        table.Rows.Add(New Object() {3, "Peter"})
        table.Rows.Add(New Object() {4, "Russ"})
        Return table
    End Function

    Private Sub PrintColumns( _
       ByVal reader As DataTableReader)

        ' Loop through all the rows in the DataTableReader.
        Do While reader.Read()
            For i As Integer = 0 To reader.FieldCount - 1
                Console.Write(reader(i).ToString() & " ")
            Next
            Console.WriteLine()
        Loop
    End Sub
    ' </Snippet1>
End Module
