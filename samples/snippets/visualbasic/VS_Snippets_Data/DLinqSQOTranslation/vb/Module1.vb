Imports System.Linq
Imports System.Linq.Expressions
Imports System.Data.Linq


Module Module1

    Sub Main()
        Dim db As New Northwnd("c:\northwnd.mdf")

        ' <Snippet1>
        Dim custQuery = _
            From cust In db.Customers _
            Where cust.City = "London" _
            Order By cust.CustomerID _
            Select cust Skip 1 Take 1
        ' </Snippet1>
    End Sub

    Sub nextmethod()
        Dim db As New Northwnd("c:\northwnd.mdf")

        ' <Snippet2>
        db.Customers.GroupBy(Function(c) c)
        db.Customers.GroupBy(Function(c) New With {c.CustomerID, _
            c.ContactName})
        ' </Snippet2>
    End Sub

    Sub method3()
        Dim db As New Northwnd("c:\northwnd.mdf")

        ' <Snippet3>
        db.Customers.Select(Function(c) c)
        db.Customers.Select(Function(c) New With {c.CustomerID, c.City})
        db.Orders.Select(Function(o) New With {o.OrderID, o.Customer.City})
        db.Orders.Select(Function(o) New With {o.OrderID, o.Customer})
        ' </Snippet3>
    End Sub

    Sub method4()
        Dim db As New Northwnd("c:\northwnd.mdf")

        ' <Snippet4>
        ' In the following line, c.Orders is a sequence.
        db.Customers.Select(Function(c) New With {c.CustomerID, c.Orders})
        ' In the following line, the result has a sequence.
        db.Customers.GroupBy(Function(c) c.City)
        ' </Snippet4>
    End Sub

End Module
