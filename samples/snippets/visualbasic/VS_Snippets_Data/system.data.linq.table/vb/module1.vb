Imports System.Linq


Module Module1

    Sub Main()


        Dim db As New Northwnd("...")
        ' This is InsertOnSubmit

        ' <Snippet1>
        ' Create a new Order object.
        Dim ord As New Order With _
        {.OrderID = 12000, _
         .ShipCity = "Seattle", _
         .OrderDate = DateTime.Now}

        ' Add the new object to the Orders collection.
        db.Orders.InsertOnSubmit(ord)

        ' Submit the change to the database.
        Try
            db.SubmitChanges()
        Catch e As Exception
            Console.WriteLine(e)
            ' Make some adjustments.
            ' ...
            ' Try again.
            db.SubmitChanges()
        End Try
        ' </Snippet1>

    End Sub

    Sub methodUpdate()
        ' This is Update.

        Dim db As New Northwnd("c:\northwnd.mdf")

        ' <Snippet2>
        ' Query the database for the row to be updated.
        Dim ordQuery = _
            From ord In db.Orders _
            Where ord.OrderID = 11000 _
            Select ord

        ' Execute the query, and change the column values
        ' you want to change.
        For Each ord As Order In ordQuery
            ord.ShipName = "Mariner"
            ord.ShipVia = 2
            ' Insert any additional changes to column values.
        Next

        ' Submit the changes to the database.
        Try
            db.SubmitChanges()
        Catch e As Exception
            Console.WriteLine(e)
            ' Make some adjustments.
            ' ...
            ' Try again
            db.SubmitChanges()
        End Try
        ' </Snippet2>

    End Sub

    Sub methodDelete()
        Dim db As New Northwnd("c:\northwnd.mdf")

        ' <Snippet3>
        ' Query the database for the rows to be deleted.
        Dim deleteOrderDetails = _
            From details In db.OrderDetails() _
            Where details.OrderID = 11000 _
            Select details

        For Each detail As OrderDetail In deleteOrderDetails
            db.OrderDetails.DeleteOnSubmit(detail)
        Next

        Try
            db.SubmitChanges()
        Catch ex As Exception
            Console.WriteLine(ex)
            ' Provide for exceptions
        End Try
        ' </Snippet3>

    End Sub



End Module
