Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Collections
Imports System.Collections.Generic



Module Module1

    Sub Main()
        ' LINQ TO SQL Query Example Snippets

        Dim db As New Northwnd("c:\northwnd.mdf")
        '''''''''''''''''''''''''''' A G G R E G A T E S ''''''''''''''''''

        ''''''''''''''''''''''' A V E R A G E ''''''''''''''''''''''''''
        ' <Snippet1>
        Dim averageFreight = Aggregate ord In db.Orders _
                             Into Average(ord.Freight)

        Console.WriteLine(averageFreight)
        ' </Snippet1>

        ' <Snippet2>
        Dim averageUnitPrice = Aggregate prod In db.Products _
                               Into Average(prod.UnitPrice)

        Console.WriteLine(averageUnitPrice)
        ' </Snippet2>

        ' <Snippet3>
        Dim priceQuery = From prod In db.Products() _
            Group prod By prod.CategoryID Into grouping = Group _
            Select CategoryID, _
            ExpensiveProducts = _
                (From prod2 In grouping _
                Where prod2.UnitPrice > _
                grouping.Average(Function(prod3) _
                prod3.UnitPrice) _
                Select prod2)

        For Each grp In priceQuery
            Console.WriteLine(grp.CategoryID)
            For Each listing In grp.ExpensiveProducts
                Console.WriteLine(listing.ProductName)
            Next
        Next
        ' </Snippet3>

        ''''''''''''''''''''''''''''''' C O U N T '''''''''''''''''''''''''''
        ' <Snippet4>
        Dim customerCount = db.Customers.Count()
        Console.WriteLine(customerCount)
        ' </Snippet4>

        ' <Snippet5>
        Dim notDiscontinuedCount = Aggregate prod In db.Products _
                                   Into Count(Not prod.Discontinued)

        Console.WriteLine(notDiscontinuedCount)
        ' </Snippet5>

        ''''''''''''''''''''''''''''''''''' M A X '''''''''''''''''''''''''
        ' <Snippet6>
        Dim latestHireDate = Aggregate emp In db.Employees _
                             Into Max(emp.HireDate)

        Console.WriteLine(latestHireDate)
        ' </Snippet6>

        ' <Snippet7>
        Dim maxUnitsInStock = Aggregate prod In db.Products _
                              Into Max(prod.UnitsInStock)

        Console.WriteLine(maxUnitsInStock)
        ' </Snippet7>

        ' <Snippet8>
        Dim maxQuery = From prod In db.Products() _
            Group prod By prod.CategoryID Into grouping = Group _
            Select CategoryID, _
            MostExpensiveProducts = _
                (From prod2 In grouping _
                Where prod2.UnitPrice = _
                grouping.Max(Function(prod3) prod3.UnitPrice))

        For Each grp In maxQuery
            Console.WriteLine(grp.CategoryID)
            For Each listing In grp.MostExpensiveProducts
                Console.WriteLine(listing.ProductName)
            Next
        Next
        ' </Snippet8>

        '''''''''''''''''''''''''''' M I N ''''''''''''''''''''
        ' <Snippet9>
        Dim lowestUnitPrice = Aggregate prod In db.Products _
                              Into Min(prod.UnitPrice)

        Console.WriteLine(lowestUnitPrice)
        ' </Snippet9>

        ' <Snippet10>
        Dim lowestFreight = Aggregate ord In db.Orders _
                            Into Min(ord.Freight)

        Console.WriteLine(lowestFreight)
        ' </Snippet10>

        ' <Snippet11>
        Dim minQuery = From prod In db.Products() _
            Group prod By prod.CategoryID Into grouping = Group _
            Select CategoryID, LeastExpensiveProducts = _
                From prod2 In grouping _
                Where prod2.UnitPrice = grouping.Min(Function(prod3) _
                prod3.UnitPrice)

        For Each grp In minQuery
            Console.WriteLine(grp.CategoryID)
            For Each listing In grp.LeastExpensiveProducts
                Console.WriteLine(listing.ProductName)
            Next
        Next
        ' </Snippet11>

        '''''''''''''''''''''''''''' S U M '''''''''''''''''''''''''''
        ' <Snippet12>
        Dim totalFreight = Aggregate ord In db.Orders _
                           Into Sum(ord.Freight)

        Console.WriteLine(totalFreight)
        ' </Snippet12>

        ' <Snippet13>
        Dim totalUnitsOnOrder = Aggregate prod In db.Products _
                                Into Sum(prod.UnitsOnOrder)

        Console.WriteLine(totalUnitsOnOrder)
        ' </Snippet13>

        '''''''''''''  E N D   O F   A G G R E G A T E S ''''''''''''''

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '''''''''''''''''''' F I R S T ''''''''''''''''''''''''
        ' <Snippet14>
        Dim shipper As Shipper = db.Shippers.First()
        Console.WriteLine("ID = {0}, Company = {1}", shipper.ShipperID, _
                shipper.CompanyName)
        ' </Snippet14>

        ' <Snippet15>
        Dim custquery As Customer = _
            (From c In db.Customers _
            Where c.CustomerID = "BONAP" _
            Select c) _
            .First()

        Console.WriteLine("ID = {0}, Contact = {1}", custquery.CustomerID, _
            custquery.ContactName)
        ' </Snippet15>

        ''''''''''''''''''''''' T A K E  /  S K I P ''''''''''''''''''
        ' <Snippet16>
        Dim firstHiredQuery = _
            From emp In db.Employees _
            Select emp _
            Order By emp.HireDate _
            Take 5

        For Each empObj As Employee In firstHiredQuery
            Console.WriteLine("{0}, {1}", empObj.EmployeeID, _
                empObj.HireDate)
        Next
        ' </Snippet16>

        ' <Snippet17>
        Dim lessExpensiveQuery = _
            From prod In db.Products _
            Select prod _
            Order By prod.UnitPrice Descending _
            Skip 10

        For Each prodObj As Product In lessExpensiveQuery
            Console.WriteLine(prodObj.ProductName)
        Next
        ' </Snippet17>

        ' <Snippet18>
        Dim custQuery2 = _
            From cust In db.Customers _
            Order By (cust.ContactName) _
            Select cust _
            Skip 50 _
            Take 10

        For Each custRecord As Customer In custQuery2
            Console.WriteLine(custRecord.ContactName)
        Next
        ' </Snippet18>

        ' <Snippet19>
        Dim custQuery3 = _
            From custs In db.Customers _
            Where custs.City = "London" _
            Select custs _
            Order By custs.CustomerID _
            Skip 1 _
            Take 1

        For Each custObj In custQuery3
            Console.WriteLine(custObj.CustomerID)
        Next
        ' </Snippet19>

        '''''''''''''''''''''''''''''' S O R T ''''''''''''''''''''''''''
        ' <Snippet20>
        Dim hireQuery = _
            From emp In db.Employees _
            Select emp _
            Order By emp.HireDate

        For Each empObj As Employee In hireQuery
            Console.WriteLine("EmpID = {0}, Date Hired = {1}", _
                empObj.EmployeeID, empObj.HireDate)
        Next
        ' </Snippet20>

        ' <Snippet21>
        Dim freightQuery = _
            From ord In db.Orders _
            Where ord.ShipCity = "London" _
            Select ord _
            Order By ord.Freight

        For Each ordObj In freightQuery
            Console.WriteLine("Order ID = {0}, Freight = {1}", _
                ordObj.OrderID, ordObj.Freight)
        Next
        ' </Snippet21>

        ' S22 lives in separate method.
        ' There is no S23.
        ' S24 lives in separate method.

        ' <Snippet25>
        Dim ordQuery = _
            From ord In db.Orders _
            Where CInt(ord.EmployeeID.Value) = 1 _
            Select ord _
            Order By ord.ShipCountry, ord.Freight Descending

        For Each ordObj In ordQuery
            Console.WriteLine("Country = {0}, Freight = {1}", _
                ordObj.ShipCountry, ordObj.Freight)
        Next
        ' </Snippet25>

        ' <Snippet26>
        Dim highPriceQuery = From prod In db.Products _
            Group prod By prod.CategoryID Into grouping = Group _
            Order By CategoryID _
            Select CategoryID, _
            MostExpensiveProducts = _
                From prod2 In grouping _
                Where prod2.UnitPrice = _
                grouping.Max(Function(p3) p3.UnitPrice)

        For Each prodObj In highPriceQuery
            Console.WriteLine(prodObj.CategoryID)
            For Each listing In prodObj.MostExpensiveProducts
                Console.WriteLine(listing.ProductName)
            Next
        Next
        ' </Snippet26>

        ' <Snippet27>
        Dim prodQuery = From prod In db.Products _
            Group prod By prod.CategoryID Into grouping = Group

        For Each grp In prodQuery
            Console.WriteLine(vbNewLine & "CategoryID Key = {0}:", _
                grp.CategoryID)
            For Each listing In grp.grouping
                Console.WriteLine(vbTab & listing.ProductName)
            Next
        Next
        ' </Snippet27>

        ' <Snippet28>
        Dim query = From p In db.Products _
            Group p By p.CategoryID Into g = Group _
            Select CategoryID, MaxPrice = g.Max(Function(p) p.UnitPrice)
        ' </Snippet28>

        ' <Snippet29>
        Dim q2 = From p In db.Products _
            Group p By p.CategoryID Into g = Group _
            Select CategoryID, AveragePrice = g.Average(Function(p) _
                p.UnitPrice)
        ' </Snippet29>

        ' S30 lives in separate method.

        ' <Snippet31>
        Dim disconQuery = From prod In db.Products _
            Group prod By prod.CategoryID Into grouping = Group _
            Select CategoryID, NumProducts = grouping.Count(Function(p) _
                p.Discontinued)

        For Each prodObj In disconQuery
            Console.WriteLine("CategoryID = {0}, Discontinued# = {1}", _
                prodObj.CategoryID, prodObj.NumProducts)
        Next
        ' </Snippet31>

        ' <Snippet32>
        Dim prodCountQuery = From prod In db.Products _
            Group prod By prod.CategoryID Into grouping = Group _
            Where grouping.Count >= 10 _
            Select CategoryID, ProductCount = grouping.Count

        For Each prodCount In prodCountQuery
            Console.WriteLine("CategoryID = {0}, Product count = {1}", _
                prodCount.CategoryID, prodCount.ProductCount)
        Next
        ' </Snippet32>

        ' S 33, S34 live in separate methods.

        ' <Snippet35>
        Dim custRegionQuery = From cust In db.Customers _
            Group cust.ContactName By Key = New With _
                {cust.City, cust.Region} Into grouping = Group

        For Each grp In custRegionQuery
            Console.WriteLine(vbNewLine & "Location Key: {0}", grp.Key)
            For Each listing In grp.grouping
                Console.WriteLine(vbTab & "{0}", listing)
            Next
        Next
        ' </Snippet35>

        ''''''''''''''''''''''''''' D I S T I N C T '''''''''''''''
        ' <Snippet36>
        Dim cityQuery = _
            (From cust In db.Customers _
            Select cust.City).Distinct()

        For Each cityString In cityQuery
            Console.WriteLine(cityString)
        Next
        ' </Snippet36>

        ''''''''''''''' A N Y   O R   A L L '''''''''''''''''''
        ' <Snippet37>
        Dim OrdersQuery = _
            From cust In db.Customers _
            Where cust.Orders.Any() _
            Select cust
        ' </Snippet37>

        ' S37v is VB only and lives in separate section below.

        ''''''''''''''''''' C O N C A T E N A T E '''''''''''''''''''''
        ' S39 lives in separate method.

        ' <Snippet40>
        Dim infoQuery = _
            (From cust In db.Customers _
            Select Name = cust.CompanyName, Phone = cust.Phone) _
            .Concat _
                (From emp In db.Employees _
                Select Name = emp.FirstName & " " & emp.LastName, _
                    Phone = emp.HomePhone)

        For Each infoData In infoQuery
            Console.WriteLine("Name = " & infoData.Name & _
                ", Phone = " & infoData.Phone)
        Next
        ' </Snippet40>

        ''''''''''''''''''''''' S E T   D I F F E R E N C E '''''''''''''''
        ' S41 lives in separate method

        ''''''''''''''''''' S E T   I N T E R S E C T I O N ''''''''''''
        ' S42 lives in separate method.

        ''''''''''''''''''' S E T   U N I O N ''''''''''''''''''''''
        ' S43 lives in separate method.

        ''''''''''' C O N V E R T   S E Q   T O   A R R A Y '''''''''''
        ' S44 lives in separate method.

        '''''' C O N V E R T   S E Q   T O   G E N   L I S T '''''''

        ' <Snippet45>
        Dim empQuery = _
            From emp In db.Employees _
            Where emp.HireDate.Value >= #1/1/1994# _
            Select emp
        Dim qList As List(Of Employee) = empQuery.ToList()
        ' </Snippet45>

        ''''''' C O N V E R T   T Y P E   T O   G E N   I E N U M ''''''''
        ' S46 lives in separate section.

        ''''''''''''''''''''''''''''' J O I N S '''''''''''''''''''''''
        ' There are 11 of these (one is VB only). All live in separate methods.
        ' S47 thru S56 inclusive, plus S50v for VB only.

        '''''''''''''' F O R M U L A T E   P R O J E C T I O N S '''''''''
        ' There are 9 of these: S57 - S65 inclusive.
        ' <Snippet57>
        Dim nameQuery = From cust In db.Customers _
            Select cust.ContactName
        ' </Snippet57>

        ' S58 lives in separate method.

        ' <Snippet59>
        Dim info2Query = From emp In db.Employees _
            Select Name = emp.FirstName & " " & emp.LastName, _
        Phone = emp.HomePhone
        ' </Snippet59>

        ' <Snippet60>
        Dim specialQuery = From prod In db.Products _
            Select prod.ProductID, HalfPrice = CDec(prod.UnitPrice) / 2
        ' </Snippet60>

        ' S61 and S62 live in separate methods.

        ' <Snippet63>
        Dim contactQuery = _
            From cust In db.Customers _
            Where cust.City = "London" _
            Select cust.ContactName
        ' </Snippet63>

        ' S64 and S65 live in separate methods.

        ''''''''''''''''''' E N D   O F   Q U E R I E S ''''''''''''''''''''

    End Sub ' End Main Sub


    '''''''''''''''''''''''''' OUT OF SCOPE METHODS ''''''''''''''''''


    Sub Method22()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet22>
        Dim priceQuery = _
            From prod In db.Products _
            Select prod _
            Order By prod.UnitPrice Descending

        For Each prodObj In priceQuery
            Console.WriteLine("Product ID = {0}, Unit Price = {1}", _
               prodObj.ProductID, prodObj.UnitPrice)
        Next
        ' </Snippet22>
    End Sub

    Sub Method24()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet24>
        Dim custQuery = _
            From cust In db.Customers _
            Select cust _
            Order By cust.City, cust.ContactName

        For Each custObj In custQuery
            Console.WriteLine("City = {0}, Name = {1}", custObj.City, _
                custObj.ContactName)
        Next
        ' </Snippet24>
    End Sub

    Sub Method30()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet30>
        Dim priceQuery = From prod In db.Products _
            Group prod By prod.CategoryID Into grouping = Group _
            Select CategoryID, TotalPrice = grouping.Sum(Function(p) _
                p.UnitPrice)

        For Each grp In priceQuery
            Console.WriteLine("Category = {0}, Total price = {1}", _
                grp.CategoryID, grp.TotalPrice)
        Next
        ' </Snippet30>
    End Sub

    Sub Method33()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet33>
        Dim prodQuery = From prod In db.Products _
            Group prod By Key = New With {prod.CategoryID, prod.SupplierID} _
                Into grouping = Group

        For Each grp In prodQuery
            Console.WriteLine(vbNewLine & "CategoryID {0}, SupplierID {1}", _
                grp.Key.CategoryID, grp.Key.SupplierID)
            For Each listing In grp.grouping
                Console.WriteLine(vbTab & listing.ProductName)
            Next
        Next
        ' </Snippet33>
    End Sub

    Sub Method34()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet34>
        Dim priceQuery = From prod In db.Products _
            Group prod By Key = New With {.Criterion = prod.UnitPrice > 10} _
                Into grouping = Group Select Key, grouping

        For Each prodObj In priceQuery
            If prodObj.Key.Criterion = False Then
                Console.WriteLine("Prices 10 or less:")
            Else
                Console.WriteLine("\nPrices greater than 10")
                For Each listing In prodObj.grouping
                    Console.WriteLine("{0}, {1}", listing.ProductName, _
                        listing.UnitPrice)
                Next
            End If
        Next
        ' </Snippet34>
    End Sub

    ' Following code is vb only.
    ' <Snippet37v>
    Public Sub ContactsAvailable()
        Dim db As New Northwnd("c:\northwnd.mdf")
        Dim result = _
            (From cust In db.Customers _
            Where Not cust.Orders.Any() _
            Select cust).All(AddressOf ContactAvailable)

        If result Then
            Console.WriteLine _
        ("All of the customers who have made no orders have a contact name")
        Else
            Console.WriteLine _
        ("Some customers who have made no orders have no contact name")
        End If
    End Sub

    Function ContactAvailable(ByVal contact As Object) As Boolean
        Dim cust As Customer = CType(contact, Customer)
        Return (cust.ContactTitle Is Nothing OrElse _
            cust.ContactTitle.Trim().Length = 0)
    End Function
    ' </Snippet37v>

    Sub Method39()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet39>
        Dim custQuery = _
            (From c In db.Customers _
            Select c.Phone) _
            .Concat _
            (From c In db.Customers _
            Select c.Fax) _
            .Concat _
            (From e In db.Employees _
            Select e.HomePhone)

        For Each custData In custQuery
            Console.WriteLine(custData)
        Next
        ' </Snippet39>
    End Sub

    Sub Method41()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet41>
        Dim infoQuery = _
            (From cust In db.Customers _
            Select cust.Country) _
            .Except _
                (From emp In db.Employees _
                Select emp.Country)
        ' </Snippet41>
    End Sub

    Sub Method42()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet42>
        Dim infoQuery = _
            (From cust In db.Customers _
            Select cust.Country) _
            .Intersect _
                (From emp In db.Employees _
                Select emp.Country)
        ' </Snippet42>
    End Sub

    Sub Method43()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet43>
        Dim infoQuery = _
            (From cust In db.Customers _
            Select cust.Country) _
            .Union _
                (From emp In db.Employees _
                Select emp.Country)
        ' </Snippet43>
    End Sub

    Sub Method44()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet44>
        Dim custQuery = _
            From cust In db.Customers _
            Where cust.City = "London" _
            Select cust
            Dim qArray() As Customer = custQuery.ToArray()
        ' </Snippet44>
    End Sub

    Sub Method47()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet47>
        Dim infoQuery = _
        From cust In db.Customers, ord In cust.Orders _
        Where cust.City = "London" _
        Select ord
        ' </Snippet47>
    End Sub

    Sub Method48()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet48>
        Dim infoQuery = _
            From prod In db.Products _
            Where prod.Supplier.Country = "USA" AndAlso _
                CShort(prod.UnitsInStock) = 0 _
            Select prod
        ' </Snippet48>
    End Sub

    Sub Method49()
        Dim db As New Northwnd("c:\northwnd.mdf")
        Dim infoQuery = _
        From emp In db.Employees, empterr In emp.EmployeeTerritories _
        Where emp.City = "Seattle" _
        Select emp.FirstName, emp.LastName, _
            empterr.Territory.TerritoryDescription
    End Sub

    Sub Method50()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet50>
        Dim infoQuery = _
            From e1 In db.Employees, e2 In e1.Employees _
            Where e1.City = e2.City _
            Select FirstName1 = e1.FirstName, _
                LastName1 = e1.LastName, FirstName2 = e2.FirstName, _
                LastName2 = e2.LastName, e1.City
        ' </Snippet50>
    End Sub

    Sub Method50v()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' This snippet is for VB only,
        ' <Snippet50v>
        Dim q1 = From c In db.Customers, o In db.Orders _
            Where c.CustomerID = o.CustomerID _
            Select c.CompanyName, o.ShipRegion

        ' Note that because the O/R designer generates class
        ' hierarchies for database relationships for you,
        ' the following code has the same effect as the above
        ' and is shorter:

        Dim q2 = From c In db.Customers, o In c.Orders _
            Select c.CompanyName, o.ShipRegion

        For Each nextItem In q2
            Console.WriteLine("{0}   {1}", nextItem.CompanyName, _
                nextItem.ShipRegion)
        Next
        ' </Snippet50v>
    End Sub

    Sub Method51()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet51>
        Dim q = From c In db.Customers _
            Group Join o In db.Orders On c.CustomerID Equals o.CustomerID _
                Into orders = Group _
            Select c.ContactName, OrderCount = orders.Count()
        ' </Snippet51>
    End Sub

    Sub Method52()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet52>
        Dim q = From c In db.Customers _
            Group Join o In db.Orders On c.CustomerID Equals o.CustomerID _
                Into ords = Group _
                Group Join e In db.Employees On c.City Equals e.City _
                    Into emps = Group _
            Select c.ContactName, ords = ords.Count(), emps = emps.Count()
        ' </Snippet52>
    End Sub

    Sub Method53()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet53>
        Dim q = From e In db.Employees() _
            Group Join o In db.Orders On e Equals o.Employee Into ords _
                = Group _
            From o In ords.DefaultIfEmpty() _
            Select e.FirstName, e.LastName, Order = o
        ' </Snippet53>
    End Sub

    Sub Method54()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet54>
        Dim q = From c In db.Customers _
            Group Join o In db.Orders On c.CustomerID Equals o.CustomerID _
                Into ords = Group _
            Let z = c.City + c.Country _
                From o In ords _
                Select c.ContactName, o.OrderID, z
        ' </Snippet54>
    End Sub

    Sub Method55()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet55>
        Dim q = From o In db.Orders _
            From p In db.Products _
            Group Join d In db.OrderDetails On New With {o.OrderID, _
                p.ProductID} _
                Equals New With {d.OrderID, d.ProductID} Into details _
                    = Group _
                From d In details _
            Select o.OrderID, p.ProductID, d.UnitPrice
        ' </Snippet55>
    End Sub

    Sub Method56()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet56>
        Dim q = From o In db.Orders _
            Group Join e In db.Employees On o.EmployeeID _
                Equals e.EmployeeID Into emps = Group _
                From e In emps _
            Select o.OrderID, e.FirstName
        ' </Snippet56>
    End Sub

    Sub Method58()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet58>
        Dim infoQuery = From cust In db.Customers _
            Select cust.ContactName, cust.Phone
        ' </Snippet58>
    End Sub

    Sub Method61()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet61>
        Dim prodQuery = From prod In db.Products _
        Select prod.ProductName, Availability = _
            If(prod.UnitsInStock - prod.UnitsOnOrder < 0, _
            "Out Of Stock", "In Stock")
        ' </Snippet61>
    End Sub


    ' <Snippet62>
    Public Class Name
        Public FirstName As String
        Public LastName As String
    End Class

    Dim db As New Northwnd("c:\northwnd.mdf")
    Dim empQuery = From emp In db.Employees _
        Select New Name With {.FirstName = emp.FirstName, .LastName = _
            emp.LastName}
    ' </Snippet62>

    Sub Method64()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet64>
        Dim custQuery = From cust In db.Customers _
            Select cust.CustomerID, CompanyInfo = New With {cust.CompanyName, _
                cust.City, cust.Country}, ContactInfo = _
                New With {cust.ContactName, cust.ContactTitle}
        ' </Snippet64>
    End Sub

    Sub Method65()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet65>
        Dim ordQuery = From ord In db.Orders _
            Select ord.OrderID, DiscountedProducts = _
            (From od In ord.OrderDetails _
                Where od.Discount > 0.0 _
            Select od), _
        FreeShippingDiscount = ord.Freight
        ' </Snippet65>
    End Sub

    ' <Snippet46>
    Private Function isValidProduct(ByVal prod As Product) As Boolean
        Return prod.ProductName.LastIndexOf("C") = 0
    End Function

    Sub ConvertToIEnumerable()
        Dim db As New Northwnd("c:\northwnd.mdf")
        Dim validProdQuery = _
            From prod In db.Products.AsEnumerable _
            Where isValidProduct(prod) _
            Select prod
    End Sub
    ' </Snippet46>

End Module
