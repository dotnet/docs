Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Module Module1
    Sub Main()
        WorkWithSqlNulls()
        Console.ReadLine()
    End Sub
    ' <Snippet1>
    Private Sub WorkWithSqlNulls()
        Dim table As New DataTable()

        ' Specify the SqlType for each column.
        Dim idColumn As DataColumn = _
          table.Columns.Add("ID", GetType(SqlInt32))
        Dim descColumn As DataColumn = _
          table.Columns.Add("Description", GetType(SqlString))

        ' Add some data.
        Dim row As DataRow = table.NewRow()
        row("ID") = 123
        row("Description") = "Side Mirror"
        table.Rows.Add(row)

        ' Add null values.
        row = table.NewRow()
        row("ID") = SqlInt32.Null
        row("Description") = SqlString.Null
        table.Rows.Add(row)

        ' Initialize variables to use when
        ' extracting the data.
        Dim isColumnNull As SqlBoolean = False
        Dim idValue As SqlInt32 = SqlInt32.Zero
        Dim descriptionValue As SqlString = SqlString.Null

        ' Iterate through the DataTable and display the values.
        For Each row In table.Rows
            ' Assign values to variables. Note that you 
            ' do not have to test for null values.
            idValue = CType(row("ID"), SqlInt32)
            descriptionValue = CType(row("Description"), SqlString)

            ' Test for null value with ID column
            isColumnNull = idValue.IsNull

            ' Display variable values in console window.
            Console.Write("isColumnNull={0}, ID={1}, Description={2}", _
              isColumnNull, idValue, descriptionValue)
            Console.WriteLine()
        Next row
    End Sub
    ' </Snippet1>
End Module

