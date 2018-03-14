Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
    Private Sub MakeTableWithUniqueConstraint()

        Dim table As New DataTable("table")
        Dim column As New DataColumn("UniqueColumn")
        column.Unique = True
        table.Columns.Add(column)

        ' Print count, name, and type.
        Console.WriteLine("Constraints.Count " _
           + table.Constraints.Count.ToString())
        Console.WriteLine(table.Constraints(0).ConstraintName)
        Console.WriteLine( _
            table.Constraints(0).GetType().ToString())

        ' Add a second unique column.
        column = New DataColumn("UniqueColumn2")
        column.Unique = True
        table.Columns.Add(column)

        ' Print info again.
        Console.WriteLine("Constraints.Count " _
           + table.Constraints.Count.ToString())
        Console.WriteLine(table.Constraints(1).ConstraintName)
        Console.WriteLine( _
            table.Constraints(1).GetType().ToString())
    End Sub
    
    Private Sub MakeTableWithForeignConstraint()

        ' Create a DataSet.
        Dim dataSet As New DataSet("dataSet")

        ' Make two tables.
        Dim customersTable As New DataTable("Customers")
        Dim ordersTable As New DataTable("Orders")

        ' Create four columns, two for each table.
        Dim name As New DataColumn("Name")
        Dim id As New DataColumn("ID")
        Dim orderId As New DataColumn("OrderID")
        Dim orderDate As New DataColumn("OrderDate")
        
        ' Add columns to tables.
        customersTable.Columns.Add(name)
        customersTable.Columns.Add(id)
        ordersTable.Columns.Add(orderId)
        ordersTable.Columns.Add(orderDate)
        
        ' Add tables to the DataSet.
        dataSet.Tables.Add(customersTable)
        dataSet.Tables.Add(ordersTable)

        ' Create a DataRelation for two of the columns.
        Dim myRelation As New DataRelation _
           ("CustomersOrders", id, orderId, True)
        dataSet.Relations.Add(myRelation)

        ' Print TableName, Constraints.Count, 
        ' ConstraintName and Type.
        Dim t As DataTable
        For Each t In  dataSet.Tables
            Console.WriteLine(t.TableName)
            Console.WriteLine("Constraints.Count " _
               + t.Constraints.Count.ToString())
            Console.WriteLine("ParentRelations.Count " _
               + t.ParentRelations.Count.ToString())
            Console.WriteLine("ChildRelations.Count " _
               + t.ChildRelations.Count.ToString())
            Dim cstrnt As Constraint
            For Each cstrnt In  t.Constraints
                Console.WriteLine(cstrnt.ConstraintName)
                Console.WriteLine(cstrnt.GetType())
            Next cstrnt
        Next t
    End Sub
' </Snippet1>
End Class
