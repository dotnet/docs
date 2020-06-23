Imports System.Data.Linq
Imports System.Linq

Module Module1

    Sub Main()

        ' <Snippet1>
        Dim db As New Northwnd("c:\northwnd.mdf")

        ' Query for customers in London.
        Dim custQuery = _
            From cust In db.Customers _
            Where cust.City = "London" _
            Select cust
        ' </Snippet1>

    End Sub

    Sub method2()

        ' <Snippet2>
        Dim db As New Northwnd("c:\northwnd.mdf")

        db.ObjectTrackingEnabled = False
        Dim hireQuery = _
            From emp In db.Employees _
            Select emp _
            Order By emp.HireDate

        For Each empObj As Employee In hireQuery
            Console.WriteLine("EmpID = {0}, Date Hired = {1}", _
                    empObj.EmployeeID, empObj.HireDate)
        Next
        ' </Snippet2>

    End Sub

    Sub method3()

        ' <Snippet3>
        Dim db As New Northwnd("c:\northwnd.mdf")

        db.DeferredLoadingEnabled = False

        Dim ds As New DataLoadOptions()
        ds.LoadWith(Function(c As Customer) c.Orders)
        ds.LoadWith(Of Order)(Function(o) o.OrderDetails)
        db.LoadOptions = ds

        Dim custQuery = From cust In db.Customers _
                        Where cust.City = "London" _
                        Select cust

        For Each custObj In custQuery
            Console.WriteLine("Customer ID: {0}", custObj.CustomerID)
            For Each ord In custObj.Orders
                Console.WriteLine(vbTab & "Order ID: {0}", ord.OrderID)
                For Each detail In ord.OrderDetails
                    Console.WriteLine(vbTab & vbTab & "Product ID: {0}", _
                        detail.ProductID)
                Next
            Next
        Next
        ' </Snippet3>

    End Sub

    Sub method4()

        ' <Snippet4>
        Dim db As New Northwnd("c:\northwnd.mdf")
        Dim results As IEnumerable(Of Customer) = _
            db.ExecuteQuery(Of Customer) _
            ("SELECT c1.custID as CustomerID," & _
            "c2.custName as ContactName" & _
            "FROM customer1 AS c1, customer2 as c2" & _
            "WHERE c1.custid = c2.custid")
        ' </Snippet4>

    End Sub

    Sub method5()
        ' <Snippet5>
        Dim db As New Northwnd("c:\northwnd.mdf")
        Dim results As IEnumerable(Of Customer) = _
    db.ExecuteQuery(Of Customer) _
    ("SELECT contactname FROM customers WHERE city = {0}, 'London'")
        ' </Snippet5>
    End Sub

    Public Property GetNorthwind()
        Get
            Dim x As Northwnd = Nothing
            Return x
        End Get
        Set(ByVal value)

        End Set
    End Property

    ' <Snippet7>
    ' The following example invokes such a compiled query in the main
    ' program
    Public Function GetCustomersByCity(ByVal city As String) As _
        IEnumerable(Of Customer)

        Dim myDb = GetNorthwind()
        Return Queries.CustomersByCity(myDb, city)
    End Function
    ' </Snippet7>

End Module

' <Snippet6>
Class Queries

    Public Shared CustomersByCity As _
        Func(Of Northwnd, String, IQueryable(Of Customer)) = _
            CompiledQuery.Compile(Function(db As Northwnd, _
    city As String) _
        From c In db.Customers Where c.City = city Select c)

    Public Shared CustomersById As _
        Func(Of Northwnd, String, IQueryable(Of Customer)) = _
            CompiledQuery.Compile(Function(db As Northwnd, _
    id As String) _
        db.Customers.Where(Function(c) c.CustomerID = id))

End Class
' </Snippet6>

' <Snippet8>
Class SimpleCustomer
    Private _ContactName As String
    Public Property ContactName() As String
        Get
            Return _ContactName
        End Get
        Set(ByVal value As String)
            _ContactName = value
        End Set
    End Property
End Class

Class Queries2
    Public Shared CustomersByCity As Func(Of Northwnd, String, IEnumerable(Of SimpleCustomer)) = _
        CompiledQuery.Compile(Of Northwnd, String, IEnumerable(Of SimpleCustomer))( _
        Function(db As Northwnd, city As String) _
        From c In db.Customers _
        Where c.City = city _
        Select New SimpleCustomer With {.ContactName = c.ContactName})
End Class
' </Snippet8>
