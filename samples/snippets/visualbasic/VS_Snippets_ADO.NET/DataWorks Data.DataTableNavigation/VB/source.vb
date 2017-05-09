Option Explicit On
Option Strict On

Imports System
Imports System.Data


Module Module1

    Sub Main()
        Dim customerOrders As DataSet
        ' <Snippet1>
        Dim customerOrdersRelation As DataRelation = _
           customerOrders.Relations.Add("CustOrders", _
           customerOrders.Tables("Customers").Columns("CustomerID"), _
           customerOrders.Tables("Orders").Columns("CustomerID"))

        Dim orderDetailRelation As DataRelation = _
           customerOrders.Relations.Add("OrderDetail", _
           customerOrders.Tables("Orders").Columns("OrderID"), _
           customerOrders.Tables("OrderDetails").Columns("OrderID"), False)

        Dim orderProductRelation As DataRelation = _
           customerOrders.Relations.Add("OrderProducts", _
           customerOrders.Tables("Products").Columns("ProductID"), _
           customerOrders.Tables("OrderDetails").Columns("ProductID"))

        Dim custRow, orderRow, detailRow As DataRow

        For Each custRow In customerOrders.Tables("Customers").Rows
            Console.WriteLine("Customer ID:" & custRow("CustomerID").ToString())

            For Each orderRow In custRow.GetChildRows(customerOrdersRelation)
                Console.WriteLine("  Order ID: " & orderRow("OrderID").ToString())
                Console.WriteLine(vbTab & "Order Date: " & _
                  orderRow("OrderDate").ToString())

                For Each detailRow In orderRow.GetChildRows(orderDetailRelation)
                    Console.WriteLine(vbTab & "   Product: " & _
                      detailRow.GetParentRow(orderProductRelation) _
                      ("ProductName").ToString())
                    Console.WriteLine(vbTab & "  Quantity: " & _
                      detailRow("Quantity").ToString())
                Next
            Next
        Next
        ' </Snippet1>
    End Sub

End Module
