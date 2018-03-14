Imports System.Linq


Module Module1

    Sub Main()
        Dim db As New Northwnd("c:\northwnd.mdf")

        ' <Snippet1>
        Dim query = _
        From cust In db.Customers _
        Group cust.ContactName By Key = New With {cust.City, cust.Region} _
        Into Group

        For Each grp In query
            Console.WriteLine("Location Key: {0}", grp.Key)
            For Each listing In grp.Group
                Console.WriteLine(vbTab & "0}", listing)
            Next
        Next
        ' </Snippet1>

    End Sub

    Sub nextmethod()

        Dim db As New Northwnd("c:\northwnd.mdf")

        ' <Snippet2>
        Dim query = From ord In db.Orders, prod In db.Products _
            Join det In db.OrderDetails _
            On New With {ord.OrderID, prod.ProductID} Equals _
            New With {det.OrderID, det.ProductID} _
            Select ord.OrderID, prod.ProductID, det.UnitPrice
        ' </Snippet2>

    End Sub

End Module
