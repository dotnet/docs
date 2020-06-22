Imports System.IO
Imports System.Collections.Generic

Public Class QuerySamples1

    Private productList As List(Of Product)
    Private customerList As List(Of Customer)

    Public Sub Sample1()
        Dim customers = GetCustomerList()

        Dim regularCustomers = From cust In customers
                               Where cust.Orders.Count > 2

        Console.WriteLine("Regular Customers: ")
        For Each cust In regularCustomers
            Console.WriteLine(cust.CompanyName & ", " & cust.Orders.Count)
        Next
    End Sub

    '<Snippet1>
    Public Sub PagingSample()
        Dim pageNumber As Integer = 0
        Dim pageSize As Integer = 10

        Dim customersPage = GetCustomers(pageNumber * pageSize, pageSize)

        Do While customersPage IsNot Nothing
            Console.WriteLine(vbCrLf & "Page: " & pageNumber + 1 & vbCrLf)

            For Each cust In customersPage
                Console.WriteLine(cust.CustomerID & ", " & cust.CompanyName)
            Next

            Console.WriteLine(vbCrLf)

            pageNumber += 1
            customersPage = GetCustomers(pageNumber * pageSize, pageSize)
        Loop
    End Sub

    Public Function GetCustomers(ByVal startIndex As Integer,
                                 ByVal pageSize As Integer) As List(Of Customer)

        Dim customers = GetCustomerList()

        Dim returnCustomers = From cust In customers
                              Skip startIndex Take pageSize

        If returnCustomers.Count = 0 Then Return Nothing

        Return returnCustomers
    End Function
    '</Snippet1>

    '<Snippet2>
    Public Sub TakeWhileSample()
        Dim customers = GetCustomerList()

        ' Return customers until the first customer with no orders is found.
        Dim customersWithOrders = From cust In customers
                                  Order By cust.Orders.Count Descending
                                  Take While HasOrders(cust)

        For Each cust In customersWithOrders
            Console.WriteLine(cust.CompanyName & " (" & cust.Orders.Length & ")")
        Next
    End Sub

    Public Function HasOrders(ByVal cust As Customer) As Boolean
        If cust.Orders.Length > 0 Then Return True

        Return False
    End Function
    '</Snippet2>

    '<Snippet3>
    Public Sub SkipWhileSample()
        Dim customers = GetCustomerList()

        ' Return customers starting from the first U.S. customer encountered.
        Dim customerList = From cust In customers
                           Order By cust.Country
                           Skip While IsInternationalCustomer(cust)

        For Each cust In customerList
            Console.WriteLine(cust.CompanyName & vbTab & cust.Country)
        Next
    End Sub

    Public Function IsInternationalCustomer(ByVal cust As Customer) As Boolean
        If cust.Country = "USA" Then Return False

        Return True
    End Function
    '</Snippet3>

    '<Snippet4>
    Public Sub AggregateSample()
        Dim customers = GetCustomerList()

        Dim customerOrderTotal =
            From cust In customers
            Aggregate order In cust.Orders
            Into Sum(order.Total), MaxOrder = Max(order.Total),
            MinOrder = Min(order.Total), Avg = Average(order.Total)

        For Each customer In customerOrderTotal
            Console.WriteLine(customer.cust.CompanyName & vbCrLf &
                             vbTab & "Sum = " & customer.Sum & vbCrLf &
                             vbTab & "Min = " & customer.MinOrder & vbCrLf &
                             vbTab & "Max = " & customer.MaxOrder & vbCrLf &
                             vbTab & "Avg = " & customer.Avg.ToString("#.##"))
        Next
    End Sub
    '</Snippet4>

    Public Sub AggregateFunctionList()
        Dim customers = GetCustomerList()
        Dim orders = From cust In customers, ord In cust.Orders
                     Select ord.OrderID, ord.Total, cust.CustomerID


        '<Snippet5>
        Dim customerList1 = Aggregate order In orders
                            Into AllOrdersOver100 = All(order.Total >= 100)
        '</Snippet5>

        '<Snippet6>
        Dim customerList2 = From cust In customers
                            Aggregate order In cust.Orders
                            Into AnyOrderOver500 = Any(order.Total >= 500)
        '</Snippet6>

        Console.WriteLine(vbCrLf & "Customers with at least one order over $500")
        For Each c In customerList2
            Console.WriteLine(c.cust.CompanyName & " (" & c.AnyOrderOver500 & ")")
        Next

        '<Snippet7>
        Dim customerOrderAverage = Aggregate order In orders
                                   Into Average(order.Total)
        '</Snippet7>

        'Console.WriteLine(vbCrLf & "Customer order averages")
        'For Each c In customerList3
        ' Console.WriteLine(c.cust.CompanyName & " (" & c.Average.ToString("#.##") & ")")
        'Next

        '<Snippet8>
        Dim customerOrderAfter1996 = From cust In customers
                                     Aggregate order In cust.Orders
                                     Into Count(order.OrderDate > #12/31/1996#)
        '</Snippet8>

        Console.WriteLine(vbCrLf & "Customer order count")
        For Each c In customerOrderAfter1996
            Console.WriteLine(c.cust.CompanyName & " (" & c.Count & ")")
        Next

        '<Snippet9>
        Dim customerMaxOrder = Aggregate order In orders
                               Into MaxOrder = Max(order.Total)
        '</Snippet9>

        'Console.WriteLine(vbCrLf & "Customer order Max order")
        'For Each c In customerMaxOrder
        ' Console.WriteLine(c.cust.CompanyName & " (" & c.MaxOrder & ")")
        'Next

        '<Snippet10>
        Dim customerMinOrder = From cust In customers
                               Aggregate order In cust.Orders
                               Into MinOrder = Min(order.Total)
        '</Snippet10>

        'Console.WriteLine(vbCrLf & "Customer order Min order")
        'For Each c In customerMinOrder
        ' Console.WriteLine(c.cust.CompanyName & " (" & c.MinOrder & ")")
        'Next

        '<Snippet15>
        Dim customerTotals = From cust In customers
                             Aggregate order In cust.Orders
                             Into Sum(order.Total)
        '</Snippet15>

        Console.WriteLine(vbCrLf & "Customer order Min order")
        For Each c In customerTotals
            Console.WriteLine(c.cust.CompanyName & " (" & c.Sum & ")")
        Next

    End Sub

    '<Snippet11>
    Public Sub GroupBySample()
        Dim customers = GetCustomerList()

        Dim customersByCountry = From cust In customers
                                 Order By cust.City
                                 Group By CountryName = cust.Country
                                 Into RegionalCustomers = Group, Count()
                                 Order By CountryName

        For Each country In customersByCountry
            Console.WriteLine(country.CountryName &
                              " (" & country.Count & ")" & vbCrLf)

            For Each customer In country.RegionalCustomers
                Console.WriteLine(vbTab & customer.CompanyName &
                                  " (" & customer.City & ")")
            Next
        Next
    End Sub
    '</Snippet11>

    Public Sub ImplicitJoin()
        Dim customers = From cust In GetCustomerList()
                        Select cust.CustomerID, cust.CompanyName

        Dim orders = From cust In GetCustomerList(), ord In cust.Orders
                     Select ord.OrderID, ord.Total, cust.CustomerID

        Dim orderIDs() = {10344, 10365, 10504, 10643}

        Dim customerOrders = From cust In customers, ord In orders
                             Join id In orderIDs On id Equals ord.OrderID
                             Where cust.CustomerID = ord.CustomerID
                             Select cust.CompanyName, ord.OrderID

        For Each order In customerOrders
            Console.WriteLine(order.CompanyName & ", " & order.OrderID)
        Next

        '<Snippet13>
        Dim customerIDs() = {"ALFKI", "VICTE", "BLAUS", "TRAIH"}

        Dim customerList = From cust In customers, custID In customerIDs
                           Where cust.CustomerID = custID
                           Select cust.CompanyName

        For Each companyName In customerList
            Console.WriteLine(companyName)
        Next
        '</Snippet13>
    End Sub

    Public Sub GroupJoinSample()
        Dim customers = From cust In GetCustomerList()
                        Select cust.CustomerID, cust.CompanyName

        Dim orders = From cust In GetCustomerList(), ord In cust.Orders
                     Select ord.OrderID, ord.Total, cust.CustomerID

        '<Snippet14>
        Dim customerList = From cust In customers
                           Group Join ord In orders On
                           cust.CustomerID Equals ord.CustomerID
                           Into CustomerOrders = Group,
                                OrderTotal = Sum(ord.Total)
                           Select cust.CompanyName, cust.CustomerID,
                                  CustomerOrders, OrderTotal

        For Each customer In customerList
            Console.WriteLine(customer.CompanyName &
                              " (" & customer.OrderTotal & ")")

            For Each order In customer.CustomerOrders
                Console.WriteLine(vbTab & order.OrderID & ": " & order.Total)
            Next
        Next
        '</Snippet14>
    End Sub

    Public Sub LetSample()
        Dim products = GetProductList()
        '<Snippet16>
        Dim discountedProducts = From prod In products
                                 Let Discount = prod.UnitPrice * 0.1
                                 Where Discount >= 50
                                 Select prod.ProductName, prod.UnitPrice, Discount

        For Each prod In discountedProducts
            Console.WriteLine("Product: {0}, Price: {1}, Discounted Price: {2}",
                              prod.ProductName, prod.UnitPrice.ToString("$#.00"),
                              (prod.UnitPrice - prod.Discount).ToString("$#.00"))
        Next
        '</Snippet16>
    End Sub

    Public Sub DistinctSample()
        Dim customers = From cust In GetCustomerList()
                        Select cust.CustomerID, cust.CompanyName

        Dim orders = From cust In GetCustomerList(), ord In cust.Orders
                     Select ord.OrderID, ord.Total, cust.CustomerID, ord.OrderDate

        '<Snippet20>
        Dim customerOrders = From cust In customers, ord In orders
                             Where cust.CustomerID = ord.CustomerID
                             Select cust.CompanyName, ord.OrderDate
                             Distinct
        '</Snippet20>
        For Each order In customerOrders
            Console.WriteLine(order.CompanyName & ", " & order.OrderDate)
        Next
    End Sub

    Sub FromSamples()
        Dim collection1 = {1, 2, 3}
        Dim collection2 = {1, 2, 3}
        '<Snippet21>
        ' Multiple From clauses in a query.
        Dim result = From var1 In collection1, var2 In collection2

        ' Equivalent syntax with a single From clause.
        Dim result2 = From var1 In collection1
                      From var2 In collection2
        '</Snippet21>

        '<Snippet22>
        Dim allOrders = From cust In GetCustomerList()
                        From ord In cust.Orders
                        Select ord
        '</Snippet22>
    End Sub

    '<Snippet23>
    Sub DisplayCustomersForRegion(ByVal customers As List(Of Customer),
                                  ByVal region As String)

        Dim customersForRegion = From cust In customers
                                 Where cust.Region = region

        For Each cust In customersForRegion
            Console.WriteLine(cust.CompanyName)
        Next
    End Sub
    '</Snippet23>

    Public Sub OrderBySamples()
        Dim books = GetBooks()

        '<Snippet24>
        Dim titlesAscendingPrice = From book In books
                                   Order By book.Price, book.Title
                                   Select book.Title, book.Price
        '</Snippet24>

        '<Snippet25>
        Dim titlesDescendingPrice = From book In books
                                    Order By book.Price Descending, book.Title
                                    Select book.Title, book.Price
        '</Snippet25>

        '<Snippet26>
        Dim bookOrders =
          From book In books
          Select book.Title, book.Price, book.PublishDate, book.Author
          Order By Author, Title, Price
        '</Snippet26>


        For Each book In books
            Console.WriteLine(book.ID)
        Next
    End Sub

    Public Sub SelectSamples()
        Dim products = GetProductList()
        '<Snippet27>
        ' 10% discount 
        Dim discount_10 = 0.1
        Dim priceList =
          From product In products
          Let DiscountedPrice = product.UnitPrice * (1 - discount_10)
          Select product.ProductName, Price = product.UnitPrice,
          Discount = discount_10, DiscountedPrice
        '</Snippet27>

        Dim customers = GetCustomerList()
        '<Snippet28>
        Dim customerList = From cust In customers, ord In cust.Orders
                           Select Name = cust.CompanyName,
                                  Total = ord.Total, ord.OrderID
                           Where Total > 500
                           Select Name, OrderID
        '</Snippet28>

        '<Snippet29>
        Dim customerNames = From cust In customers
                            Select cust.CompanyName

        Dim customerInfo As IEnumerable(Of Customer) =
          From cust In customers
          Select New Customer With {.CompanyName = cust.CompanyName,
                                     .Address = cust.Address,
                                     .City = cust.City,
                                     .Region = cust.Region,
                                     .Country = cust.Country}
        '</Snippet29>
    End Sub

    '<Snippet30>
    Sub SelectCustomerNameAndId(ByVal customers() As Customer)
        Dim nameIds = From cust In customers
                      Select cust.CompanyName, cust.CustomerID
        For Each nameId In nameIds
            Console.WriteLine(nameId.CompanyName & ": " & nameId.CustomerID)
        Next
    End Sub
    '</Snippet30>



    ' Where Clause (Visual Basic)
    ' 48b5c2c5-3181-429c-8545-894296798c89

    '<Snippet31>
    Private Sub DisplayElements()
        Dim elements As List(Of Element) = BuildList()

        ' Get a list of elements that have an atomic number from 12 to 14,
        ' or that have a name that ends in "r".
        Dim subset = From theElement In elements
                     Where (theElement.AtomicNumber >= 12 And theElement.AtomicNumber < 15) _
                     Or theElement.Name.EndsWith("r")
                     Order By theElement.Name

        For Each theElement In subset
            Console.WriteLine(theElement.Name & " " & theElement.AtomicNumber)
        Next

        ' Output:
        '  Aluminum 13
        '  Magnesium 12
        '  Silicon 14
        '  Sulfur 16
    End Sub

    Private Function BuildList() As List(Of Element)
        Return New List(Of Element) From
            {
                {New Element With {.Name = "Sodium", .AtomicNumber = 11}},
                {New Element With {.Name = "Magnesium", .AtomicNumber = 12}},
                {New Element With {.Name = "Aluminum", .AtomicNumber = 13}},
                {New Element With {.Name = "Silicon", .AtomicNumber = 14}},
                {New Element With {.Name = "Phosphorous", .AtomicNumber = 15}},
                {New Element With {.Name = "Sulfur", .AtomicNumber = 16}}
            }
    End Function

    Public Class Element
        Public Property Name As String
        Public Property AtomicNumber As Integer
    End Class
    '</Snippet31>



    Public Sub LeftJoin()
        Dim numbersL = {0, 2, 4, 5, 6, 8, 9}
        Dim numbersR = {1, 3, 5, 7, 8}

        ' Implicit Inner Join
        Dim pairs = From a In numbersL, b In numbersR
                    Where a = b
                    Select a, b

        Console.WriteLine("Inner Join:")
        For Each pair In pairs
            Console.WriteLine(pair.a & " = " & pair.b)
        Next

        Dim innerJoin = From a In numbersL, b In numbersR
                        Where a = b
                        Select a, b

        Dim outerJoin = From a In numbersL, b In numbersR
                        Select a, b

        Dim leftOuterJoin = From a In numbersL
                            Where (From l In innerJoin Where a = l.a Select l).Count = 0
                            Select a

        Dim rightOuterJoin = From b In numbersR
                             Where (From r In innerJoin Where b = r.b Select r).Count = 0
                             Select b

        Dim leftJoin = (From a In numbersL
                        Where (From l In innerJoin Where a = l.a Select l).Count = 0
                        Select a, b = Nothing).Union(From a In numbersL, b In numbersR
                                                     Where a = b
                                                     Select a, b)

        Console.WriteLine("Left Join:")
        For Each pair In leftJoin
            Console.WriteLine(pair.a & ", " & pair.b)
        Next

        Console.WriteLine("Outer Join:")
        For Each pair In outerJoin
            Console.WriteLine(pair.a & ", " & pair.b)
        Next
    End Sub

    Public Function GetProductList() As List(Of Product)
        If productList Is Nothing Then
            CreateLists()
        End If

        Return productList
    End Function

    Public Function GetCustomerList() As List(Of Customer)
        If customerList Is Nothing Then
            CreateLists()
        End If

        Return customerList
    End Function

    Public Function GetBooks() As List(Of Book)
        Dim dataPath As String = My.Application.Info.DirectoryPath & "\..\Data"
        Dim bookListPath = Path.GetFullPath(Path.Combine(dataPath, "books.xml"))

        Dim bookDoc = XDocument.Load(bookListPath)

        Dim bookList = From bk In bookDoc.<Catalog>.<Book>
                       Select New Book With {.ID = bk.@id,
                                             .Author = bk.<Author>.Value,
                                             .Genre = bk.<Genre>.Value,
                                             .Description = bk.<Description>.Value,
                                             .Price = bk.<Price>.Value,
                                             .PublishDate = bk.<PublishDate>.Value,
                                             .Title = bk.<Title>.Value}


        Return bookList.ToList()
    End Function

    Private Sub CreateLists()
        ' Product data created in-memory using collection initializer:
        productList = New List(Of Product) From {
          New Product With {.ProductID = 1, .ProductName = "Chai", .Category = "Beverages", .UnitPrice = 18.0, .UnitsInStock = 39},
          New Product With {.ProductID = 2, .ProductName = "Chang", .Category = "Beverages", .UnitPrice = 19.0, .UnitsInStock = 17},
          New Product With {.ProductID = 3, .ProductName = "Aniseed Syrup", .Category = "Condiments", .UnitPrice = 10.0, .UnitsInStock = 13},
          New Product With {.ProductID = 4, .ProductName = "Chef Anton's Cajun Seasoning", .Category = "Condiments", .UnitPrice = 22.0, .UnitsInStock = 53},
          New Product With {.ProductID = 5, .ProductName = "Chef Anton's Gumbo Mix", .Category = "Condiments", .UnitPrice = 21.35, .UnitsInStock = 0},
          New Product With {.ProductID = 6, .ProductName = "Grandma's Boysenberry Spread", .Category = "Condiments", .UnitPrice = 25.0, .UnitsInStock = 120},
          New Product With {.ProductID = 7, .ProductName = "Uncle Bob's Organic Dried Pears", .Category = "Produce", .UnitPrice = 30.0, .UnitsInStock = 15},
          New Product With {.ProductID = 8, .ProductName = "Northwoods Cranberry Sauce", .Category = "Condiments", .UnitPrice = 40.0, .UnitsInStock = 6},
          New Product With {.ProductID = 9, .ProductName = "Mishi Kobe Niku", .Category = "Meat/Poultry", .UnitPrice = 97.0, .UnitsInStock = 29},
          New Product With {.ProductID = 10, .ProductName = "Ikura", .Category = "Seafood", .UnitPrice = 31.0, .UnitsInStock = 31},
          New Product With {.ProductID = 11, .ProductName = "Queso Cabrales", .Category = "Dairy Products", .UnitPrice = 21.0, .UnitsInStock = 22},
          New Product With {.ProductID = 12, .ProductName = "Queso Manchego La Pastora", .Category = "Dairy Products", .UnitPrice = 38.0, .UnitsInStock = 86},
          New Product With {.ProductID = 13, .ProductName = "Konbu", .Category = "Seafood", .UnitPrice = 6.0, .UnitsInStock = 24},
          New Product With {.ProductID = 14, .ProductName = "Tofu", .Category = "Produce", .UnitPrice = 23.25, .UnitsInStock = 35},
          New Product With {.ProductID = 15, .ProductName = "Genen Shouyu", .Category = "Condiments", .UnitPrice = 15.5, .UnitsInStock = 39},
          New Product With {.ProductID = 16, .ProductName = "Pavlova", .Category = "Confections", .UnitPrice = 17.45, .UnitsInStock = 29},
          New Product With {.ProductID = 17, .ProductName = "Alice Mutton", .Category = "Meat/Poultry", .UnitPrice = 39.0, .UnitsInStock = 0},
          New Product With {.ProductID = 18, .ProductName = "Carnarvon Tigers", .Category = "Seafood", .UnitPrice = 62.5, .UnitsInStock = 42},
          New Product With {.ProductID = 19, .ProductName = "Teatime Chocolate Biscuits", .Category = "Confections", .UnitPrice = 9.2, .UnitsInStock = 25},
          New Product With {.ProductID = 20, .ProductName = "Sir Rodney's Marmalade", .Category = "Confections", .UnitPrice = 81.0, .UnitsInStock = 40},
          New Product With {.ProductID = 21, .ProductName = "Sir Rodney's Scones", .Category = "Confections", .UnitPrice = 10.0, .UnitsInStock = 3},
          New Product With {.ProductID = 22, .ProductName = "Gustaf's KnÃ¤ckebrÃ¶d", .Category = "Grains/Cereals", .UnitPrice = 21.0, .UnitsInStock = 104},
          New Product With {.ProductID = 23, .ProductName = "TunnbrÃ¶d", .Category = "Grains/Cereals", .UnitPrice = 9.0, .UnitsInStock = 61},
          New Product With {.ProductID = 24, .ProductName = "GuaranÃ¡ FantÃ¡stica", .Category = "Beverages", .UnitPrice = 4.5, .UnitsInStock = 20},
          New Product With {.ProductID = 25, .ProductName = "NuNuCa NuÃŸ-Nougat-Creme", .Category = "Confections", .UnitPrice = 14.0, .UnitsInStock = 76},
          New Product With {.ProductID = 26, .ProductName = "GumbÃ¤r GummibÃ¤rchen", .Category = "Confections", .UnitPrice = 31.23, .UnitsInStock = 15},
          New Product With {.ProductID = 27, .ProductName = "Schoggi Schokolade", .Category = "Confections", .UnitPrice = 43.9, .UnitsInStock = 49},
          New Product With {.ProductID = 28, .ProductName = "RÃ¶ssle Sauerkraut", .Category = "Produce", .UnitPrice = 45.6, .UnitsInStock = 26},
          New Product With {.ProductID = 29, .ProductName = "ThÃ¼ringer Rostbratwurst", .Category = "Meat/Poultry", .UnitPrice = 123.79, .UnitsInStock = 0},
          New Product With {.ProductID = 30, .ProductName = "Nord-Ost Matjeshering", .Category = "Seafood", .UnitPrice = 25.89, .UnitsInStock = 10},
          New Product With {.ProductID = 31, .ProductName = "Gorgonzola Telino", .Category = "Dairy Products", .UnitPrice = 12.5, .UnitsInStock = 0},
          New Product With {.ProductID = 32, .ProductName = "Mascarpone Fabioli", .Category = "Dairy Products", .UnitPrice = 32.0, .UnitsInStock = 9},
          New Product With {.ProductID = 33, .ProductName = "Geitost", .Category = "Dairy Products", .UnitPrice = 2.5, .UnitsInStock = 112},
          New Product With {.ProductID = 34, .ProductName = "Sasquatch Ale", .Category = "Beverages", .UnitPrice = 14.0, .UnitsInStock = 111},
          New Product With {.ProductID = 35, .ProductName = "Steeleye Stout", .Category = "Beverages", .UnitPrice = 18.0, .UnitsInStock = 20},
          New Product With {.ProductID = 36, .ProductName = "Inlagd Sill", .Category = "Seafood", .UnitPrice = 19.0, .UnitsInStock = 112},
          New Product With {.ProductID = 37, .ProductName = "Gravad lax", .Category = "Seafood", .UnitPrice = 26.0, .UnitsInStock = 11},
          New Product With {.ProductID = 38, .ProductName = "CÃ´te de Blaye", .Category = "Beverages", .UnitPrice = 263.5, .UnitsInStock = 17},
          New Product With {.ProductID = 39, .ProductName = "Chartreuse verte", .Category = "Beverages", .UnitPrice = 18.0, .UnitsInStock = 69},
          New Product With {.ProductID = 40, .ProductName = "Boston Crab Meat", .Category = "Seafood", .UnitPrice = 18.4, .UnitsInStock = 123},
          New Product With {.ProductID = 41, .ProductName = "Jack's New England Clam Chowder", .Category = "Seafood", .UnitPrice = 9.65, .UnitsInStock = 85},
          New Product With {.ProductID = 42, .ProductName = "Singaporean Hokkien Fried Mee", .Category = "Grains/Cereals", .UnitPrice = 14.0, .UnitsInStock = 26},
          New Product With {.ProductID = 43, .ProductName = "Ipoh Coffee", .Category = "Beverages", .UnitPrice = 46.0, .UnitsInStock = 17},
          New Product With {.ProductID = 44, .ProductName = "Gula Malacca", .Category = "Condiments", .UnitPrice = 19.45, .UnitsInStock = 27},
          New Product With {.ProductID = 45, .ProductName = "Rogede sild", .Category = "Seafood", .UnitPrice = 9.5, .UnitsInStock = 5},
          New Product With {.ProductID = 46, .ProductName = "Spegesild", .Category = "Seafood", .UnitPrice = 12.0, .UnitsInStock = 95},
          New Product With {.ProductID = 47, .ProductName = "Zaanse koeken", .Category = "Confections", .UnitPrice = 9.5, .UnitsInStock = 36},
          New Product With {.ProductID = 48, .ProductName = "Chocolade", .Category = "Confections", .UnitPrice = 12.75, .UnitsInStock = 15},
          New Product With {.ProductID = 49, .ProductName = "Maxilaku", .Category = "Confections", .UnitPrice = 20.0, .UnitsInStock = 10},
          New Product With {.ProductID = 50, .ProductName = "Valkoinen suklaa", .Category = "Confections", .UnitPrice = 16.25, .UnitsInStock = 65},
          New Product With {.ProductID = 51, .ProductName = "Manjimup Dried Apples", .Category = "Produce", .UnitPrice = 53.0, .UnitsInStock = 20},
          New Product With {.ProductID = 52, .ProductName = "Filo Mix", .Category = "Grains/Cereals", .UnitPrice = 7.0, .UnitsInStock = 38},
          New Product With {.ProductID = 53, .ProductName = "Perth Pasties", .Category = "Meat/Poultry", .UnitPrice = 32.8, .UnitsInStock = 0},
          New Product With {.ProductID = 54, .ProductName = "TourtiÃ¨re", .Category = "Meat/Poultry", .UnitPrice = 7.45, .UnitsInStock = 21},
          New Product With {.ProductID = 55, .ProductName = "PÃ¢tÃ© chinois", .Category = "Meat/Poultry", .UnitPrice = 24.0, .UnitsInStock = 115},
          New Product With {.ProductID = 56, .ProductName = "Gnocchi di nonna Alice", .Category = "Grains/Cereals", .UnitPrice = 38.0, .UnitsInStock = 21},
          New Product With {.ProductID = 57, .ProductName = "Ravioli Angelo", .Category = "Grains/Cereals", .UnitPrice = 19.5, .UnitsInStock = 36},
          New Product With {.ProductID = 58, .ProductName = "Escargots de Bourgogne", .Category = "Seafood", .UnitPrice = 13.25, .UnitsInStock = 62},
          New Product With {.ProductID = 59, .ProductName = "Raclette Courdavault", .Category = "Dairy Products", .UnitPrice = 55.0, .UnitsInStock = 79},
          New Product With {.ProductID = 60, .ProductName = "Camembert Pierrot", .Category = "Dairy Products", .UnitPrice = 34.0, .UnitsInStock = 19},
          New Product With {.ProductID = 61, .ProductName = "Sirop d'Ã©rable", .Category = "Condiments", .UnitPrice = 28.5, .UnitsInStock = 113},
          New Product With {.ProductID = 62, .ProductName = "Tarte au sucre", .Category = "Confections", .UnitPrice = 49.3, .UnitsInStock = 17},
          New Product With {.ProductID = 63, .ProductName = "Vegie-spread", .Category = "Condiments", .UnitPrice = 43.9, .UnitsInStock = 24},
          New Product With {.ProductID = 64, .ProductName = "Wimmers gute SemmelknÃ¶del", .Category = "Grains/Cereals", .UnitPrice = 33.25, .UnitsInStock = 22},
          New Product With {.ProductID = 65, .ProductName = "Louisiana Fiery Hot Pepper Sauce", .Category = "Condiments", .UnitPrice = 21.05, .UnitsInStock = 76},
          New Product With {.ProductID = 66, .ProductName = "Louisiana Hot Spiced Okra", .Category = "Condiments", .UnitPrice = 17.0, .UnitsInStock = 4},
          New Product With {.ProductID = 67, .ProductName = "Laughing Lumberjack Lager", .Category = "Beverages", .UnitPrice = 14.0, .UnitsInStock = 52},
          New Product With {.ProductID = 68, .ProductName = "Scottish Longbreads", .Category = "Confections", .UnitPrice = 12.5, .UnitsInStock = 6},
          New Product With {.ProductID = 69, .ProductName = "Gudbrandsdalsost", .Category = "Dairy Products", .UnitPrice = 36.0, .UnitsInStock = 26},
          New Product With {.ProductID = 70, .ProductName = "Outback Lager", .Category = "Beverages", .UnitPrice = 15.0, .UnitsInStock = 15},
          New Product With {.ProductID = 71, .ProductName = "Flotemysost", .Category = "Dairy Products", .UnitPrice = 21.5, .UnitsInStock = 26},
          New Product With {.ProductID = 72, .ProductName = "Mozzarella di Giovanni", .Category = "Dairy Products", .UnitPrice = 34.8, .UnitsInStock = 14},
          New Product With {.ProductID = 73, .ProductName = "RÃ¶d Kaviar", .Category = "Seafood", .UnitPrice = 15.0, .UnitsInStock = 101},
          New Product With {.ProductID = 74, .ProductName = "Longlife Tofu", .Category = "Produce", .UnitPrice = 10.0, .UnitsInStock = 4},
          New Product With {.ProductID = 75, .ProductName = "RhÃ¶nbrÃ¤u Klosterbier", .Category = "Beverages", .UnitPrice = 7.75, .UnitsInStock = 125},
          New Product With {.ProductID = 76, .ProductName = "LakkalikÃ¶Ã¶ri", .Category = "Beverages", .UnitPrice = 18.0, .UnitsInStock = 57},
          New Product With {.ProductID = 77, .ProductName = "Original Frankfurter grÃ¼ne SoÃŸe", .Category = "Condiments", .UnitPrice = 13.0, .UnitsInStock = 32}
        }

        ' Customer/order data read into memory from XML file using LINQ to XML
        Dim dataPath As String = My.Application.Info.DirectoryPath & "\..\Data"
        Dim customerListPath = Path.GetFullPath(Path.Combine(dataPath, "customers.xml"))

        Dim list = XDocument.Load(customerListPath).Root.Elements("customer")

        customerList = (From e In list
                        Select New Customer With {
                            .CustomerID = CStr(e.<id>.Value),
                            .CompanyName = CStr(e.<name>.Value),
                            .Address = CStr(e.<address>.Value),
                            .City = CStr(e.<city>.Value),
                            .Region = CStr(e.<region>.Value),
                            .PostalCode = CStr(e.<postalcode>.Value),
                            .Country = CStr(e.<country>.Value),
                            .Phone = CStr(e.<phone>.Value),
                            .Fax = CStr(e.<fax>.Value),
                            .Orders = (
                                    From o In e...<orders>...<order>
                                    Select New [Order] With {
                        .OrderID = CInt(o.<id>.Value),
                        .OrderDate = CDate(o.<orderdate>.Value),
                        .Total = CDec(o.<total>.Value)}
                                      ).ToArray()
                            }).ToList()
    End Sub

End Class

Public Class Customer
    Public Property CustomerID As String
    Public Property CompanyName As String
    Public Property Address As String
    Public Property City As String
    Public Property Region As String
    Public Property PostalCode As String
    Public Property Country As String
    Public Property Phone As String
    Public Property Fax As String
    Public Property Orders As [Order]()
End Class

Public Class [Order]
    Public Property OrderID As Integer
    Public Property OrderDate As DateTime
    Public Property Total As Decimal
End Class

Public Class Product
    Public Property ProductID As Integer
    Public Property ProductName As String
    Public Property Category As String
    Public Property UnitPrice As Decimal
    Public Property UnitsInStock As Integer
End Class

Public Class Book
    Public Property ID As String
    Public Property Author As String
    Public Property Title As String
    Public Property Genre As String
    Public Property Price As Double
    Public Property PublishDate As DateTime
    Public Property Description As String
End Class




