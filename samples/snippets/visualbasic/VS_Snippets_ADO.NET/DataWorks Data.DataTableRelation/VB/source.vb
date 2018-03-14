Option Explicit On
Option Strict On

Imports System
Imports System.Data


Module Module1

    Sub Main()
        Dim customerOrders As DataSet = new dataset()

        ' <Snippet1>
        Dim customerOrdersRelation As DataRelation = _
           customerOrders.Relations.Add("CustOrders", _
           customerOrders.Tables("Customers").Columns("CustomerID"), _
           customerOrders.Tables("Orders").Columns("CustomerID"))

        Dim custRow, orderRow As DataRow

        For Each custRow In customerOrders.Tables("Customers").Rows
            Console.WriteLine("Customer ID:" & custRow("CustomerID").ToString())

            For Each orderRow In custRow.GetChildRows(customerOrdersRelation)
                Console.WriteLine(orderRow("OrderID").ToString())
            Next
        Next
        ' </Snippet1>
    End Sub

End Module
