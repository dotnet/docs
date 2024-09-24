Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Module Module1
    Sub Main()
        Dim connectionString As String = GetConnectionString()
        GetSqlTypesAW(connectionString)
        Console.ReadLine()
    End Sub
    ' <Snippet1>
    Private Sub GetSqlTypesAW(ByVal connectionString As String)

        ' Create a DataTable and specify the
        ' SqlType for each column.
        Dim table As New DataTable()
        Dim icolumnolumn As DataColumn = _
          table.Columns.Add("SalesOrderID", GetType(SqlInt32))
        Dim priceColumn As DataColumn = _
          table.Columns.Add("UnitPrice", GetType(SqlMoney))
        Dim totalColumn As DataColumn = _
          table.Columns.Add("LineTotal", GetType(SqlDecimal))
        Dim columnModifiedDate As DataColumn = _
          table.Columns.Add("ModifiedDate", GetType(SqlDateTime))

        ' Open a connection to SQL Server and fill the DataTable
        ' with data from the Sales.SalesOrderDetail table
        ' in the AdventureWorks sample database.
        Using connection As New SqlConnection(connectionString)

            Dim queryString As String = _
               "SELECT TOP 5 SalesOrderID, UnitPrice, LineTotal, ModifiedDate " _
               & "FROM Sales.SalesOrderDetail WHERE LineTotal < @LineTotal"

            ' Create the SqlCommand.
            Dim command As SqlCommand = New SqlCommand(queryString, connection)

            ' Create the SqlParameter and assign a value.
            Dim parameter As SqlParameter = _
               New SqlParameter("@LineTotal", SqlDbType.Decimal)
            parameter.Value = 1.5
            command.Parameters.Add(parameter)

            ' Open the connection and load the data.
            connection.Open()
            Dim reader As SqlDataReader = _
               command.ExecuteReader(CommandBehavior.CloseConnection)
            table.Load(reader)

            ' Close the SqlDataReader
            reader.Close()
        End Using

        ' Display the SqlType of each column.
        Dim column As DataColumn
        Console.WriteLine("Data Types:")
        For Each column In table.Columns
            Console.WriteLine(" {0} -- {1}", _
            column.ColumnName, column.DataType.UnderlyingSystemType)
        Next column

        ' Display the value for each row.
        Dim row As DataRow
        Console.WriteLine("Values:")
        For Each row In table.Rows
            Console.Write(" {0}, ", row("SalesOrderID"))
            Console.Write(" {0}, ", row("UnitPrice"))
            Console.Write(" {0}, ", row("LineTotal"))
            Console.Write(" {0} ", row("ModifiedDate"))
            Console.WriteLine()
        Next row
    End Sub
    ' </Snippet1>

    Private Function GetConnectionString() As String
        Throw New NotImplementedException()
    End Function
End Module

