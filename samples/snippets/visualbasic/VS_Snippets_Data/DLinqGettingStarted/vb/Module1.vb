Imports System.Linq


Module Module1

    Sub Main()

        ' <Snippet1>
        ' Northwnd inherits from System.Data.Linq.DataContext.
        Dim nw As New Northwnd("c:\northwnd.mdf")
        ' or, if you are not using SQL Server Express
        ' Dim nw As New Northwnd("Database=Northwind;Server=dschwart7;Integrated Security=SSPI")

        Dim companyNameQuery = _
            From cust In nw.Customers _
            Where cust.City = "London" _
            Select cust.CompanyName

        For Each customer In companyNameQuery
            Console.WriteLine(customer)
        Next
        ' </Snippet1>

    End Sub

    Sub method2()
        ' <Snippet2>
        ' Northwnd inherits from System.Data.Linq.DataContext.
        Dim nw As New Northwnd("c:\northwnd.mdf")

        Dim cust As New Customer With {.CompanyName = "SomeCompany", _
            .City = "London", _
            .CustomerID = 98128, _
            .PostalCode = 55555, .Phone = "555-555-5555"}
        nw.Customers.InsertOnSubmit(cust)
        ' At this point, the new Customer object is added in the object model.
        ' In LINQ to SQL, the change is not sent to the database until
        ' SubmitChanges is called.
        nw.SubmitChanges()
        ' </Snippet2>

    End Sub

    Sub method3()

        ' <Snippet3>
        Dim nw As New Northwnd("c:\northwnd.mdf")
        Dim cityNameQuery = _
            From cust In nw.Customers _
            Where cust.City.Contains("London") _
            Select cust

        For Each customer In cityNameQuery
            If customer.City = "London" Then
                customer.City = "London - Metro"
            End If
        Next
        nw.SubmitChanges()
        ' </Snippet3>

    End Sub

    Sub method4()

        ' <Snippet4>
        Dim nw As New Northwnd("c:\northwnd.mdf")
        Dim deleteIndivCust = _
            From cust In nw.Customers _
            Where cust.CustomerID = 98128 _
            Select cust

        If deleteIndivCust.Count > 0 Then
            nw.Customers.DeleteOnSubmit(deleteIndivCust.First)
            nw.SubmitChanges()
        End If
        ' </Snippet4>

    End Sub

End Module
