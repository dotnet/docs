Imports System.Linq

Module Module1

    Sub Main()
        Dim db As New Northwnd("c:\northwnd.mdf")

        ' <Snippet1>
        Dim cust1 As Customer = _
            (From cust In db.Customers _
             Where cust.CustomerID = "BONAP" _
             Select cust).First()

        Dim cust2 As Customer = _
            (From cust In db.Customers _
             Where cust.CustomerID = "BONAP" _
             Select cust).First()
        ' </Snippet1>
    End Sub

    Sub method2()
        Dim db As New Northwnd("c:\northwnd.mdf")

        ' <Snippet2>
        Dim cust1 As Customer = _
            (From cust In db.Customers _
             Where cust.CustomerID = "BONAP" _
             Select cust).First()

        Dim cust2 As Customer = _
            (From ord In db.Orders _
             Where ord.Customer.CustomerID = "BONAP" _
             Select ord).First().Customer
        ' </Snippet2>
    End Sub


End Module
