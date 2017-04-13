Module Module1

    Sub Main()
        ' <Snippet1>
        Dim db As New Northwnd("…\Northwnd.mdf")

        Dim cust As Customer = _
        (From c In db.Customers _
        Where c.CustomerID = "ALFKI" _
        Select c) _
        .First()

        ' Change the name of the contact.
        cust.ContactName = "New Contact"

        ' Create and add a new Order to Orders collection.
        Dim ord As New Order With {.OrderDate = DateTime.Now}
        cust.Orders.Add(ord)

        ' Delete an existing Order.
        Dim ord0 As Order = cust.Orders(0)

        ' Removing it from the table also removes it from 
        ' the Customer’s list.
        db.Orders.DeleteOnSubmit(ord0)

        ' Ask the DataContext to save all the changes.
        db.SubmitChanges()
        ' </Snippet1>

    End Sub

End Module
