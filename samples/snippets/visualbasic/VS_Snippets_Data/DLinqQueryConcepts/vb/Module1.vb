Imports System.Data.Linq

Module Module1

    Sub Main()
        ' <Snippet2>
        Dim db As New Northwnd("c:\northwnd.mdf")

        db.DeferredLoadingEnabled = False

        Dim custQuery = _
            From cust In db.Customers _
            Where cust.City = "London" _
            Select cust

        For Each custObj As Customer In custQuery
            For Each ordObj As Order In custObj.Orders
                ProcessCustomerOrder(ordObj)
            Next
        Next
        ' </Snippet2>

    End Sub

    Sub ProcessCustomerOrder(ByVal ord As Order)

    End Sub

    Sub SendCustomerNotification(ByVal ord As Customer)

    End Sub

    Sub ProcessOrder(ByVal ord As Order)

    End Sub

    Sub method1()

        ' <Snippet1>
        Dim db As New Northwnd("c:\northwnd.mdf")
        Dim notificationQuery = _
            From ord In db.Orders _
            Where ord.ShipVia = 3 _
            Select ord

        For Each ordObj As Order In notificationQuery
            If ordObj.Freight > 200 Then
                SendCustomerNotification(ordObj.Customer)
                ProcessOrder(ordObj)
            End If

        Next
        ' </Snippet1>

    End Sub

    Sub method3()

        ' <Snippet3>
        Dim db As New Northwnd("c:\northwnd.mdf")
        Dim londonOrderQuery = _
    From ord In db.Orders _
    Where ord.Customer.City = "London" _
    Select ord
        ' </Snippet3>

    End Sub

    Sub method4()
        ' <Snippet4>
        Dim db As New Northwnd("c:\northwnd.mdf")
        Dim londOrderQuery = _
    From cust In db.Customers _
    Join ord In db.Orders On cust.CustomerID Equals ord.CustomerID _
    Select ord
        ' </Snippet4>
    End Sub

    Sub method5()
        ' <Snippet5>
        Dim db As New Northwnd("c:\northwnd.mdf")
        Dim idQuery = _
    From cust In db.Customers, ord In cust.Orders _
    Where cust.City = "London" _
    Select cust.CustomerID, ord.OrderID
        ' </Snippet5>
    End Sub

    Sub method6()
        ' <Snippet6>
        Dim db As New Northwnd("c:\northwnd.mdf")
        Dim idQuery = _
    From ord In db.Orders _
    Where ord.Customer.City = "London" _
    Select ord.CustomerID, ord.OrderID
        ' </Snippet6>
    End Sub

    Sub method7()
        ' <Snippet7>
        Dim db As New Northwnd("c:\northwnd.mdf")
        Dim c As Customer = _
    (From cust In db.Customers _
     Where cust.CustomerID = 19283).First()
        Dim orders = From ord In c.Orders _
                     Where ord.ShippedDate.Value.Year = 1998
        For Each nextOrder In orders
            ' Do something.
        Next
        ' </Snippet7>
    End Sub

    Sub method8()
        ' <Snippet8>
        Dim db As New Northwnd("c:\northwnd.mdf")
        Dim c As Customer = _
    (From cust In db.Customers _
     Where cust.CustomerID = 19283).First
        c.Orders.Load()

        Dim orders = From ord In c.Orders _
                     Where ord.ShippedDate.Value.Year = 1998

        For Each nextOrder In orders
            ' Do something.
        Next
        ' </Snippet8>
    End Sub

    Sub method9()
        ' <Snippet9>
        Dim db As New Northwnd("c:\northwnd.mdf")
        Dim ds As DataLoadOptions = New DataLoadOptions()
        ds.LoadWith(Of Customer)(Function(c) c.Orders)
        ds.LoadWith(Of Order)(Function(o) o.OrderDetails)
        db.LoadOptions = ds

        Dim custQuery = From cust In db.Customers() _
                        Where cust.City = "London" _
                        Select cust

        For Each custObj In custQuery
            Console.WriteLine("Customer ID: " & custObj.CustomerID)

            For Each ord In custObj.Orders
                Console.WriteLine(vbTab & "Order ID: " & ord.OrderID)

                For Each detail In ord.OrderDetails
                    Console.WriteLine(vbTab & vbTab & _
                                "Product ID: {0}", detail.ProductID)
                Next
            Next
        Next
        ' </Snippet9>

    End Sub

    Sub method10()
        ' <Snippet10>
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' Preload Orders for Customer.
        ' One directive per relationship to be preloaded.
        Dim ds As DataLoadOptions = New DataLoadOptions()
        ds.LoadWith(Of Customer)(Function(cust) cust.Orders)
        ds.AssociateWith(Of Customer)( _
            Function(cust) _
                From ord In cust.Orders _
                Where ord.ShippedDate <> DateTime.Today)

        db.LoadOptions = ds

        Dim custQuery = From cust In db.Customers _
                        Where cust.City = "London" _
                        Select cust

        For Each custObj In custQuery
            Console.WriteLine("Customer ID: " & custObj.CustomerID)

            For Each ord In custObj.Orders
                Console.WriteLine(vbTab & "Order ID: " & ord.OrderID)

                For Each detail In ord.OrderDetails
                    Console.WriteLine(vbTab & vbTab & _
                        "Product ID: " & detail.ProductID)
                Next
            Next
        Next
        ' </Snippet10>

    End Sub

End Module
