Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Private Sub AddForeignConstraint( _
    ByVal dataSet As DataSet, ByVal table As DataTable)
        Try
            Dim parentColumns(2) As DataColumn
            Dim childColumns(2) As DataColumn
            ' Get the tables from the DataSet.
            Dim customersTable As DataTable = _
                dataSet.Tables("Customers")
            Dim ordersTable As DataTable = _
                dataSet.Tables("Orders")

            ' Set Columns.
            parentColumns(0) = customersTable.Columns("id")
            parentColumns(1) = customersTable.Columns("Name")
            childColumns(0) = ordersTable.Columns("CustomerID")
            childColumns(1) = ordersTable.Columns("CustomerName")

            ' Create ForeignKeyConstraint
            table.Constraints.Add("CustOrdersConstraint", _
                parentColumns, childColumns)

        Catch ex As Exception
            ' In case the constraint already exists, 
            ' catch the collision here and respond.
            Console.WriteLine("Exception of type {0} occurred.", _
                ex.GetType().ToString())
        End Try
    End Sub
    ' </Snippet1>

End Module
