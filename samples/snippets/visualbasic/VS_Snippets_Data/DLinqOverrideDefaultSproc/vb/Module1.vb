Imports System.Linq


Module Module1

    Sub method5()
        ' <Snippet5>
        Dim db As New Northwind("...")
        ' Use a method call (stored procedure wrapper) instead of
        ' a LINQ query against the database.
        Dim custQuery = db.CustomersByCity("London")

        For Each custObj In custQuery
            ' Deferred loading of custObj.Orders uses the override
            ' LoadOrders. There is no dynamic SQL.

            For Each ord In custObj.Orders
                ' Make some changes to customers/orders.
                ' Overrides for Customer are called during the execution
                ' of the following:
                db.SubmitChanges()
            Next
        Next
        ' </Snippet5>

    End Sub

    Sub Main()

        ' <Snippet3>
        Dim db As New NorthwindThroughSprocs()
        Dim custQuery = From cust In db.Customers _
                        Where cust.City = "London" _
                        Select cust

        For Each custObj In custQuery
            ' Deferred loading of cust.Orders uses the override LoadOrders.
            For Each ord In custObj.Orders
                ' ...
                ' Make some changes to customers/orders.
                ' Overrides for Customer are called during the execution 
                ' of the following:
                db.SubmitChanges()
            Next
        Next
        ' </Snippet3>

    End Sub


End Module

