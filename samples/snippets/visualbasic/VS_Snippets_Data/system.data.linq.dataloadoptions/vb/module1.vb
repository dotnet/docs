Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq

Module Module1

    Sub Main()
        ' <Snippet1>
        Dim db As New Northwnd("c:\northwnd.mdf")

        Dim dlo As DataLoadOptions = New DataLoadOptions()
        dlo.AssociateWith(Of Customer)(Function(c As Customer) _
                c.Orders.Where(Function(p) p.ShippedDate <> DateTime.Today))
        db.LoadOptions = dlo

        Dim custOrderQuery = _
            From cust In db.Customers _
            Where cust.City = "London" _
            Select cust

        For Each custObj In custOrderQuery
            Console.WriteLine(custObj.CustomerID)
            For Each ord In custObj.Orders
                Console.WriteLine("{0}{1}", vbTab, ord.OrderDate)
            Next

        Next
        ' </Snippet1>


        Console.ReadLine()

    End Sub

    Sub x()
        ' <Snippet2>
        Dim db As New Northwnd("c:\northwnd.mdf")

        Dim dlo As DataLoadOptions = New DataLoadOptions()
        dlo.LoadWith(Of Customer)(Function(c As Customer) c.Orders)
        db.LoadOptions = dlo

        Dim londonCustomers = _
            From cust In db.Customers _
            Where cust.City = "London" _
            Select cust

        For Each custObj In londonCustomers
            Console.WriteLine(custObj.CustomerID)
        Next
        ' </Snippet2>
    End Sub

End Module
