' <Snippet1>
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
' </Snippet1>

Module Module1

    Sub Main()
        ' <Snippet2>
        ' Use a connection string, but connect to
        '     the temporary copy of the database.
        Dim db As New Northwnd _
            ("C:\linqtest2\northwnd.mdf")

        ' Keep the console window open after activity stops.
        Console.ReadLine()
        ' </Snippet2>
    End Sub

    Sub method3()
        Dim db As New Northwnd _
            ("C:\linqtest2\northwnd.mdf")

        ' <Snippet3>
        ' Create the new Customer object.
        Dim newCust As New Customer()
        newCust.CompanyName = "AdventureWorks Cafe"
        newCust.CustomerID = "A3VCA"

        ' Add the customer to the Customers table.
        db.Customers.InsertOnSubmit(newCust)

        Console.WriteLine("Customers matching CA before insert:")

        Dim custQuery = _
            From cust In db.Customers _
            Where cust.CustomerID.Contains("CA") _
            Select cust

        For Each cust In custQuery
            Console.WriteLine("Customer ID: " & cust.CustomerID)
        Next
        ' </Snippet3>

    End Sub

    Sub method4()
        Dim db As New Northwnd _
            ("C:\linqtest2\northwnd.mdf")

        ' <Snippet4>
        Dim existingCust = _
            (From cust In db.Customers _
            Where cust.CustomerID = "ALFKI" _
            Select cust).First()

        ' Change the contact name of the customer.
        existingCust.ContactName = "New Contact"
        ' </Snippet4>

        ' <Snippet5>
        ' Access the first element in the Orders collection.
        Dim ord0 As Order = existingCust.Orders(0)

        ' Access the first element in the OrderDetails collection.
        Dim detail0 As OrderDetail = ord0.OrderDetails(0)

        ' Display the order to be deleted.
        Console.WriteLine _
            (vbCrLf & "The Order Detail to be deleted is: OrderID = " _
            & detail0.OrderID)

        ' Mark the Order Detail row for deletion from the database.
        db.OrderDetails.DeleteOnSubmit(detail0)
        ' </Snippet5>

        ' <Snippet6>
        db.SubmitChanges()
        ' </Snippet6>

        ' <Snippet7>
        Console.WriteLine(vbCrLf & "Customers matching CA after update:")
        Dim finalQuery = _
            From cust In db.Customers _
            Where cust.CustomerID.Contains("CA") _
            Select cust

        For Each cust In finalQuery
            Console.WriteLine("Customer ID: " & cust.CustomerID)
        Next
        ' </Snippet7>

    End Sub


End Module
