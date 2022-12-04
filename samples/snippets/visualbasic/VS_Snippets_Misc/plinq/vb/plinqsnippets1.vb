Imports System.Threading

Module PLinqSnippetsVB

    Sub Main()
        Dim x As New IntroSnippet
        x.SimpleQuery()

    End Sub

    Class IntroSnippet
        Sub IntroSnippets()

            Dim source = Enumerable.Range(1, 10000)

            ' Opt-in to PLINQ with AsParallel
            Dim evenNums = From num In source.AsParallel()
                           Where Compute(num) > 0
                           Select num



            Console.WriteLine("TBD")


            Dim randomValues(1000) As Integer

            'Order first, then filter
            evenNums = From num In randomValues.AsParallel().AsOrdered()
                       Where num Mod 2 = 0
                       Select num

            Dim nums = Enumerable.Range(10, 10000)

            Dim query = From num In nums.AsParallel()
                        Where num Mod 10 = 0
                        Select num

            ' Process results as each thread completes.
            query.ForAll(Sub(e)
                             Compute(e)
                         End Sub)



        End Sub
        Function Compute(ByVal i As Integer) As Integer
            Compute = 1
        End Function


        Sub SimpleQuery()

            Dim source = Enumerable.Range(100, 20000)

            ' Result sequence might be out of order.
            Dim parallelQuery = From num In source.AsParallel()
                                Where num Mod 10 = 0
                                Select num

            ' Process result sequence in parallel
            parallelQuery.ForAll(Sub(e)
                                     DoSomething(e)
                                 End Sub)

            ' Or use For Each to merge results first
            ' as in this example, Where results must
            ' be serialized sequentially through static Console method.
            For Each n In parallelQuery
                Console.Write("{0} ", n)
            Next

            ' You can also use ToArray, ToList, etc
            ' as with LINQ to Objects.
            Dim parallelQuery2 = (From num In source.AsParallel()
                                  Where num Mod 10 = 0
                                  Select num).ToArray()

            'Method syntax is also supported
            Dim parallelQuery3 = source.AsParallel().Where(Function(n)
                                                               Return (n Mod 10) = 0
                                                           End Function).Select(Function(n)
                                                                                    Return n

                                                                                End Function)

            For Each i As Integer In parallelQuery3
                Console.Write("{0} ", i)
            Next
            Console.ReadLine()

        End Sub

        ' A toy function to demonstrate syntax. Typically you need a more
        ' computationally expensive method to see speedup over sequential queries.
        Sub DoSomething(ByVal i As Integer)
            Console.Write("{0:###.## }", Math.Sqrt(i))
        End Sub

        '<snippet12>
        Sub OrderedQuery()

            Dim source = Enumerable.Range(9, 10000)

            ' Source is ordered let's preserve it.
            Dim parallelQuery = From num In source.AsParallel().AsOrdered()
                                Where num Mod 3 = 0
                                Select num

            ' Use For Each to preserve order at execution time.
            For Each item In parallelQuery
                Console.Write("{0} ", item)
            Next

            ' Some operators expect an ordered source sequence.
            Dim lowValues = parallelQuery.Take(10)

        End Sub
        '</snippet12>



        '<Snippet13>
        Sub OrderedQuery2()

            Dim source = Enumerable.Range(8, 100000)

            ' Let the query access the data source will full parallelism
            ' and apply ordering to the filtered results.
            Dim orderedQuery = From num In source.AsParallel()
                               Where num Mod 8 = 0
                               Order By num
                               Select num


            ' Use For Each to preserve query ordering.
            For Each item In orderedQuery
                Console.Write("{0} ", item)
            Next

        End Sub
        '</snippet13>

        Sub OrderedQuery3()
            Dim source = Enumerable.Range(108, 100000)
            Dim parallelQuery = From num In source.AsParallel().AsOrdered()
                                Where num Mod 8 = 0
                                Select num

            ' use For Each to preserve ordering
            ' during query execution.
            For Each item In parallelQuery
                Console.Write("{0} ", item)
            Next
        End Sub



        '<snippet16>
        Class Program
            Private Shared Sub Main(ByVal args As String())
                Dim source As Integer() = Enumerable.Range(1, 10000000).ToArray()
                Dim cs As New CancellationTokenSource()

                ' Start a new asynchronous task that will cancel the 
                ' operation from another thread. Typically you would call
                ' Cancel() in response to a button click or some other
                ' user interface event.
                Task.Factory.StartNew(Sub()
                                          UserClicksTheCancelButton(cs)
                                      End Sub)

                Dim results As Integer() = Nothing
                Try

                    results = (From num In source.AsParallel().WithCancellation(cs.Token) _
                               Where num Mod 3 = 0 _
                               Order By num Descending _
                               Select num).ToArray()
                Catch e As OperationCanceledException

                    Console.WriteLine(e.Message)
                Catch ae As AggregateException

                    If ae.InnerExceptions IsNot Nothing Then
                        For Each e As Exception In ae.InnerExceptions
                            Console.WriteLine(e.Message)
                        Next
                    End If
                Finally
                    cs.Dispose()
                End Try

                If results IsNot Nothing Then
                    For Each item In results
                        Console.WriteLine(item)
                    Next
                End If
                Console.WriteLine()

                Console.ReadKey()
            End Sub

            Private Shared Sub UserClicksTheCancelButton(ByVal cs As CancellationTokenSource)
                ' Wait between 150 and 500 ms, then cancel.
                ' Adjust these values if necessary to make
                ' cancellation fire while query is still executing.
                Dim rand As New Random()
                Thread.Sleep(rand.[Next](150, 350))
                cs.Cancel()
            End Sub
        End Class
        '</snippet16>

        '<snippet17>
        Class Program2
            Private Shared Sub Main(ByVal args As String())


                Dim source As Integer() = Enumerable.Range(1, 10000000).ToArray()
                Dim cs As New CancellationTokenSource()

                ' Start a new asynchronous task that will cancel the 
                ' operation from another thread. Typically you would call
                ' Cancel() in response to a button click or some other
                ' user interface event.
                Task.Factory.StartNew(Sub()

                                          UserClicksTheCancelButton(cs)
                                      End Sub)

                Dim results As Double() = Nothing
                Try

                    results = (From num In source.AsParallel().WithCancellation(cs.Token) _
                               Where num Mod 3 = 0 _
                               Select [Function](num, cs.Token)).ToArray()
                Catch e As OperationCanceledException


                    Console.WriteLine(e.Message)
                Catch ae As AggregateException
                    If ae.InnerExceptions IsNot Nothing Then
                        For Each e As Exception In ae.InnerExceptions
                            Console.WriteLine(e.Message)
                        Next
                    End If
                Finally
                    cs.Dispose()
                End Try

                If results IsNot Nothing Then
                    For Each item In results
                        Console.WriteLine(item)
                    Next
                End If
                Console.WriteLine()

                Console.ReadKey()
            End Sub

            ' A toy method to simulate work.
            Private Shared Function [Function](ByVal n As Integer, ByVal ct As CancellationToken) As Double
                ' If work is expected to take longer than 1 ms
                ' then try to check cancellation status more
                ' often within that work.
                For i As Integer = 0 To 4
                    ' Work hard for approx 1 millisecond.
                    Thread.SpinWait(50000)

                    ' Check for cancellation request.
                    If ct.IsCancellationRequested Then
                        Throw New OperationCanceledException(ct)
                    End If
                Next
                ' Anything will do for our purposes.
                Return Math.Sqrt(n)
            End Function

            Private Shared Sub UserClicksTheCancelButton(ByVal cs As CancellationTokenSource)
                ' Wait between 150 and 500 ms, then cancel.
                ' Adjust these values if necessary to make
                ' cancellation fire while query is still executing.
                Dim rand As New Random()
                Thread.Sleep(rand.[Next](150, 350))
                Console.WriteLine("Press 'c' to cancel")
                If Console.ReadKey().KeyChar = "c"c Then
                    cs.Cancel()

                End If
            End Sub
        End Class
        '</snippet17>





    End Class

    '<snippet31>
    Class aggregation
        Private Shared Sub Main(ByVal args As String())

            ' Create a data source for demonstration purposes.
            Dim source As Integer() = New Integer(99999) {}
            Dim rand As New Random()
            For x As Integer = 0 To source.Length - 1
                ' Should result in a mean of approximately 15.0.
                source(x) = rand.[Next](10, 20)
            Next

            ' Standard deviation calculation requires that we first
            ' calculate the mean average. Average is a predefined
            ' aggregation operator, along with Max, Min and Count.
            Dim mean As Double = source.AsParallel().Average()


            ' We use the overload that is unique to ParallelEnumerable. The 
            ' third Func parameter combines the results from each thread.
            ' initialize subtotal. Use decimal point to tell 
            ' the compiler this is a type double. Can also use: 0d.

            ' do this on each thread

            ' aggregate results after all threads are done.

            ' perform standard deviation calc on the aggregated result.
            Dim standardDev As Double = source.AsParallel().Aggregate(0.0R, Function(subtotal, item) subtotal + Math.Pow((item - mean), 2), Function(total, thisThread) total + thisThread, Function(finalSum) Math.Sqrt((finalSum / (source.Length - 1))))
            Console.WriteLine("Mean value is = {0}", mean)
            Console.WriteLine("Standard deviation is {0}", standardDev)

            Console.ReadLine()
        End Sub
    End Class
    '</snippet31>






    ' <snippet50>
    ' This class contains a subset of data from the Northwind database
    ' in the form of string arrays. The methods such as GetCustomers, GetOrders, and so on
    ' transform the strings into object arrays that you can query in an object-oriented way.
    ' Many of the code examples in the PLINQ How-to topics are designed to be pasted into 
    ' the PLINQDataSample class and invoked from the Main method.
    ' IMPORTANT: This data set is not large enough for meaningful comparisons of PLINQ vs. LINQ performance.
    Class PLINQDataSample
        Shared Sub Main(ByVal args As String())

            'Call methods here.
            TestDataSource()

            Console.WriteLine("Press any key to exit.")
            Console.ReadKey()
        End Sub

        Shared Sub TestDataSource()
            Console.WriteLine("Customer count: {0}", GetCustomers().Count())
            Console.WriteLine("Product count: {0}", GetProducts().Count())
            Console.WriteLine("Order count: {0}", GetOrders().Count())
            Console.WriteLine("Order Details count: {0}", GetOrderDetails().Count())
        End Sub

#Region "DataClasses"
        Class Order
            Public Sub New()
                _OrderDetails = New Lazy(Of OrderDetail())(Function() GetOrderDetailsForOrder(OrderID))
            End Sub
            Private _OrderID As Integer
            Public Property OrderID() As Integer
                Get
                    Return _OrderID
                End Get
                Set(ByVal value As Integer)
                    _OrderID = value
                End Set
            End Property
            Private _CustomerID As String
            Public Property CustomerID() As String
                Get
                    Return _CustomerID
                End Get
                Set(ByVal value As String)
                    _CustomerID = value
                End Set
            End Property
            Private _OrderDate As DateTime
            Public Property OrderDate() As DateTime
                Get
                    Return _OrderDate
                End Get
                Set(ByVal value As DateTime)
                    _OrderDate = value
                End Set
            End Property
            Private _ShippedDate As DateTime
            Public Property ShippedDate() As DateTime
                Get
                    Return _ShippedDate
                End Get
                Set(ByVal value As DateTime)
                    _ShippedDate = value
                End Set
            End Property
            Private _OrderDetails As Lazy(Of OrderDetail())
            Public ReadOnly Property OrderDetails As OrderDetail()
                Get
                    Return _OrderDetails.Value
                End Get
            End Property
        End Class

        Class Customer

            Private _Orders As Lazy(Of Order())
            Public Sub New()
                _Orders = New Lazy(Of Order())(Function() GetOrdersForCustomer(_CustomerID))
            End Sub

            Private _CustomerID As String
            Public Property CustomerID() As String
                Get
                    Return _CustomerID
                End Get
                Set(ByVal value As String)
                    _CustomerID = value
                End Set
            End Property
            Private _CustomerName As String
            Public Property CustomerName() As String
                Get
                    Return _CustomerName
                End Get
                Set(ByVal value As String)
                    _CustomerName = value
                End Set
            End Property
            Private _Address As String
            Public Property Address() As String
                Get
                    Return _Address
                End Get
                Set(ByVal value As String)
                    _Address = value
                End Set
            End Property
            Private _City As String
            Public Property City() As String
                Get
                    Return _City
                End Get
                Set(ByVal value As String)
                    _City = value
                End Set
            End Property
            Private _PostalCode As String
            Public Property PostalCode() As String
                Get
                    Return _PostalCode
                End Get
                Set(ByVal value As String)
                    _PostalCode = value
                End Set
            End Property
            Public ReadOnly Property Orders() As Order()
                Get
                    Return _Orders.Value
                End Get
            End Property
        End Class

        Class Product
            Private _ProductName As String
            Public Property ProductName() As String
                Get
                    Return _ProductName
                End Get
                Set(ByVal value As String)
                    _ProductName = value
                End Set
            End Property
            Private _ProductID As Integer
            Public Property ProductID() As Integer
                Get
                    Return _ProductID
                End Get
                Set(ByVal value As Integer)
                    _ProductID = value
                End Set
            End Property
            Private _UnitPrice As Double
            Public Property UnitPrice() As Double
                Get
                    Return _UnitPrice
                End Get
                Set(ByVal value As Double)
                    _UnitPrice = value
                End Set
            End Property
        End Class

        Class OrderDetail
            Private _OrderID As Integer
            Public Property OrderID() As Integer
                Get
                    Return _OrderID
                End Get
                Set(ByVal value As Integer)
                    _OrderID = value
                End Set
            End Property
            Private _ProductID As Integer
            Public Property ProductID() As Integer
                Get
                    Return _ProductID
                End Get
                Set(ByVal value As Integer)
                    _ProductID = value
                End Set
            End Property
            Private _UnitPrice As Double
            Public Property UnitPrice() As Double
                Get
                    Return _UnitPrice
                End Get
                Set(ByVal value As Double)
                    _UnitPrice = value
                End Set
            End Property
            Private _Quantity As Double
            Public Property Quantity() As Double
                Get
                    Return _Quantity
                End Get
                Set(ByVal value As Double)
                    _Quantity = value
                End Set
            End Property
            Private _Discount As Double
            Public Property Discount() As Double
                Get
                    Return _Discount
                End Get
                Set(ByVal value As Double)
                    _Discount = value
                End Set
            End Property


        End Class
#End Region

        Shared Function GetCustomersAsStrings() As IEnumerable(Of String)

            Return IO.File.ReadAllLines("..\..\plinqdata.csv").
                SkipWhile(Function(line) line.StartsWith("CUSTOMERS") = False).
                Skip(1).
                TakeWhile(Function(line) line.StartsWith("END CUSTOMERS") = False)
        End Function
        Shared Function GetCustomers() As IEnumerable(Of Customer)

            Dim customers = IO.File.ReadAllLines("..\..\plinqdata.csv").
                SkipWhile(Function(line) line.StartsWith("CUSTOMERS") = False).
                Skip(1).
                TakeWhile(Function(line) line.StartsWith("END CUSTOMERS") = False)

            Return From line In customers
                   Let fields = line.Split(","c)
                   Select New Customer With {
                    .CustomerID = fields(0).Trim(),
                    .CustomerName = fields(1).Trim(),
                    .Address = fields(2).Trim(),
                    .City = fields(3).Trim(),
                    .PostalCode = fields(4).Trim()}
        End Function

        Shared Function GetOrders() As IEnumerable(Of Order)

            Dim orders = IO.File.ReadAllLines("..\..\plinqdata.csv").
                            SkipWhile(Function(line) line.StartsWith("ORDERS") = False).
                            Skip(1).
                            TakeWhile(Function(line) line.StartsWith("END ORDERS") = False)

            Return From line In orders
                   Let fields = line.Split(","c)
                   Select New Order With {
                    .OrderID = CType(fields(0).Trim(), Integer),
                    .CustomerID = fields(1).Trim(),
                    .OrderDate = DateTime.Parse(fields(2)),
                    .ShippedDate = DateTime.Parse(fields(3))}

        End Function

        Shared Function GetOrdersForCustomer(ByVal id As String) As Order()

            Dim orders = IO.File.ReadAllLines("..\..\plinqdata.csv").
                            SkipWhile(Function(line) line.StartsWith("ORDERS") = False).
                            Skip(1).
                            TakeWhile(Function(line) line.StartsWith("END ORDERS") = False)

            Dim orderStrings = From line In orders
                               Let fields = line.Split(","c)
                               Let custID = fields(1).Trim()
                               Where custID = id
                               Select New Order With {
                                .OrderID = CType(fields(0).Trim(), Integer),
                                .CustomerID = custID,
                                .OrderDate = DateTime.Parse(fields(2)),
                                .ShippedDate = DateTime.Parse(fields(3))}

            Return orderStrings.ToArray()

        End Function
        Shared Function GetProducts() As IEnumerable(Of Product)

            Dim products = IO.File.ReadAllLines("..\..\plinqdata.csv").
                SkipWhile(Function(line) line.StartsWith("PRODUCTS") = False).
                            Skip(1).
                            TakeWhile(Function(line) line.StartsWith("END PRODUCTS") = False)

            Return From line In products
                   Let fields = line.Split(","c)
                   Select New Product With {
                       .ProductID = CType(fields(0), Integer),
                        .ProductName = fields(1).Trim(),
                        .UnitPrice = CType(fields(2), Double)}
        End Function

        Shared Function GetOrderDetailsForOrder(ByVal orderID As Integer) As OrderDetail()
            Dim orderDetails = IO.File.ReadAllLines("..\..\plinqdata.csv").
                SkipWhile(Function(line) line.StartsWith("ORDER DETAILS") = False).
                            Skip(1).
                            TakeWhile(Function(line) line.StartsWith("END ORDER DETAILS") = False)

            Dim ordDetailStrings = From line In orderDetails
                                   Let fields = line.Split(","c)
                                   Let ordID = Convert.ToInt32(fields(0))
                                   Where ordID = orderID
                                   Select New OrderDetail With {
                                    .OrderID = ordID,
                                    .ProductID = CType(fields(1), Integer),
                                    .UnitPrice = CType(fields(2), Double),
                                    .Quantity = CType(fields(3), Double),
                                    .Discount = CType(fields(4), Double)}
            Return ordDetailStrings.ToArray()

        End Function

        Shared Function GetOrderDetails() As IEnumerable(Of OrderDetail)
            Dim orderDetails = IO.File.ReadAllLines("..\..\plinqdata.csv").
                SkipWhile(Function(line) line.StartsWith("ORDER DETAILS") = False).
                            Skip(1).
                            TakeWhile(Function(line) line.StartsWith("END ORDER DETAILS") = False)

            Return From line In orderDetails
                   Let fields = line.Split(","c)
                   Select New OrderDetail With {
                    .OrderID = CType(fields(0), Integer),
                    .ProductID = CType(fields(1), Integer),
                    .UnitPrice = CType(fields(2), Double),
                    .Quantity = CType(fields(3), Double),
                    .Discount = CType(fields(4), Double)}
        End Function

    End Class

    '</snippet50>

    ' This class duplicates snippet50 but we use it to embed methods that we don't want to show
    ' up in the published file, (because they have their own files) but we need them to compile as if they are members of this class.
    Class PLINQDataSample_InternalForCompilingSomeSnippets
        Shared Sub Main(ByVal args As String())

            'Call methods here.
            TestDataSource()
            Dim p As New PLINQDataSample_InternalForCompilingSomeSnippets
            PLINQExceptions_1()
            ' p.OrderedThenUnordered()
            Console.WriteLine("Press any key to exit.")
            Console.ReadKey()
        End Sub

        Shared Sub TestDataSource()
            Console.WriteLine("Customer count: {0}", GetCustomers().Count())
            Console.WriteLine("Product count: {0}", GetProducts().Count())
            Console.WriteLine("Order count: {0}", GetOrders().Count())
            Console.WriteLine("Order Details count: {0}", GetOrderDetails().Count())
        End Sub

        '<snippet14>
        ' Paste into PLINQDataSample class
        Shared Sub SimpleOrdering()
            Dim customers As List(Of Customer) = GetCustomers().ToList()

            ' Take the first 20, preserving the original order

            Dim firstTwentyCustomers = customers _
                                        .AsParallel() _
                                        .AsOrdered() _
                                        .Take(20)

            Console.WriteLine("Take the first 20 in original order")
            For Each c As Customer In firstTwentyCustomers
                Console.Write(c.CustomerID & " ")
            Next

            ' All elements in reverse order.
            Dim reverseOrder = customers _
                                .AsParallel() _
                                .AsOrdered() _
                                .Reverse()

            Console.WriteLine(vbCrLf & "Take all elements in reverse order")
            For Each c As Customer In reverseOrder
                Console.Write("{0} ", c.CustomerID)
            Next
            ' Get the element at a specified index. 
            Dim cust = customers.AsParallel() _
                                .AsOrdered() _
                                .ElementAt(48)

            Console.WriteLine("Element #48 is: " & cust.CustomerID)

        End Sub
        '</snippet14>

        '<snippet15>
        ' Paste into PLINQDataSample class
        Sub OrderedThenUnordered()
            Dim Orders As IEnumerable(Of Order) = GetOrders()
            Dim orderDetails As IEnumerable(Of OrderDetail) = GetOrderDetails()

            ' Sometimes it's easier to create a query
            ' by composing two subqueries
            Dim query1 = From ord In Orders.AsParallel()
                         Where ord.OrderDate < DateTime.Parse("07/04/1997")
                         Select ord
                         Order By ord.CustomerID
                         Take 20

            Dim query2 = From ord In query1.AsUnordered()
                         Join od In orderDetails.AsParallel() On ord.OrderID Equals od.OrderID
                         Order By od.ProductID
                         Select New With {ord.OrderID, ord.CustomerID, od.ProductID}


            For Each item In query2
                Console.WriteLine("{0} {1} {2}", item.OrderID, item.CustomerID, item.ProductID)
            Next
        End Sub
        '</snippet15>

        '<snippet22>
        Private Shared Sub ForceParallel()
            Dim customers = GetCustomers()
            Dim parallelQuery = (From cust In customers.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                                 Where cust.City = "Berlin"
                                 Select cust.CustomerName).ToList()
        End Sub
        '</snippet22>

        '<snippet24>
        ' Paste into PLINQDataSample class
        Shared Sub SequentialDemo()

            Dim orders = GetOrders()
            Dim query = From ord In orders.AsParallel()
                        Order By ord.OrderID
                        Select New With
                        {
                            ord.OrderID,
                            ord.OrderDate,
                            ord.ShippedDate
                        }

            Dim query2 = query.AsSequential().Take(5)

            For Each item In query2
                Console.WriteLine("{0}, {1}, {2}", item.OrderDate, item.OrderID, item.ShippedDate)
            Next
        End Sub
        '</snippet24>

        '<snippet25>
        Class FileIteration
            Shared Sub Main()
            End Sub
        End Class
        '</snippet25>

        '<snippet41>
        ' Paste into PLINQDataSample class
        Shared Sub PLINQExceptions_1()

            ' Using the raw string array here. See PLINQ Data Sample.
            Dim customers As String() = GetCustomersAsStrings().ToArray()

            ' First, we must simulate some corrupt input.
            customers(20) = "###"

            'throws indexoutofrange
            Dim query = From cust In customers.AsParallel()
                        Let fields = cust.Split(","c)
                        Where fields(3).StartsWith("C")
                        Select fields
            Try
                ' We use ForAll although it doesn't really improve performance
                ' since all output is serialized through the Console.
                query.ForAll(Sub(e)
                                 Console.WriteLine("City: {0}, Thread:{1}")
                             End Sub)
            Catch e As AggregateException

                ' In this design, we stop query processing when the exception occurs.
                For Each ex In e.InnerExceptions
                    Console.WriteLine(ex.Message)
                    If TypeOf ex Is IndexOutOfRangeException Then
                        Console.WriteLine("The data source is corrupt. Query stopped.")
                    End If
                Next
            End Try
        End Sub
        '</snippet41>

        '<snippet42>
        ' Paste into PLINQDataSample class
        Shared Sub PLINQExceptions_2()

            Dim customers() = GetCustomersAsStrings().ToArray()
            ' Using the raw string array here.
            ' First, we must simulate some corrupt input
            customers(20) = "###"

            ' Create a delegate with a lambda expression.
            ' Assume that in this app, we expect malformed data
            ' occasionally and by design we just report it and continue.
            Dim isTrue As Func(Of String(), String, Boolean) = Function(f, c)

                                                                   Try

                                                                       Dim s As String = f(3)
                                                                       Return s.StartsWith(c)

                                                                   Catch e As IndexOutOfRangeException

                                                                       Console.WriteLine("Malformed cust: {0}", f)
                                                                       Return False
                                                                   End Try
                                                               End Function

            ' Using the raw string array here
            Dim query = From cust In customers.AsParallel()
                        Let fields = cust.Split(","c)
                        Where isTrue(fields, "C")
                        Select New With {.City = fields(3)}
            Try
                ' We use ForAll although it doesn't really improve performance
                ' since all output must be serialized through the Console.
                query.ForAll(Sub(e) Console.WriteLine(e.City))


                ' IndexOutOfRangeException will not bubble up      
                ' because we handle it where it is thrown.
            Catch e As AggregateException
                For Each ex In e.InnerExceptions
                    Console.WriteLine(ex.Message)
                Next
            End Try
        End Sub
        '</snippet42>


#Region "DataClasses"
        Class Order
            Public Sub New()
                _OrderDetails = New Lazy(Of OrderDetail())(Function() GetOrderDetailsForOrder(OrderID))
            End Sub
            Private _OrderID As Integer
            Public Property OrderID() As Integer
                Get
                    Return _OrderID
                End Get
                Set(ByVal value As Integer)
                    _OrderID = value
                End Set
            End Property
            Private _CustomerID As String
            Public Property CustomerID() As String
                Get
                    Return _CustomerID
                End Get
                Set(ByVal value As String)
                    _CustomerID = value
                End Set
            End Property
            Private _OrderDate As DateTime
            Public Property OrderDate() As DateTime
                Get
                    Return _OrderDate
                End Get
                Set(ByVal value As DateTime)
                    _OrderDate = value
                End Set
            End Property
            Private _ShippedDate As DateTime
            Public Property ShippedDate() As DateTime
                Get
                    Return _ShippedDate
                End Get
                Set(ByVal value As DateTime)
                    _ShippedDate = value
                End Set
            End Property
            Private _OrderDetails As Lazy(Of OrderDetail())
            Public ReadOnly Property OrderDetails As OrderDetail()
                Get
                    Return _OrderDetails.Value
                End Get
            End Property
        End Class

        Class Customer

            Private _Orders As Lazy(Of Order())
            Public Sub New()
                _Orders = New Lazy(Of Order())(Function() GetOrdersForCustomer(_CustomerID))
            End Sub

            Private _CustomerID As String
            Public Property CustomerID() As String
                Get
                    Return _CustomerID
                End Get
                Set(ByVal value As String)
                    _CustomerID = value
                End Set
            End Property
            Private _CustomerName As String
            Public Property CustomerName() As String
                Get
                    Return _CustomerName
                End Get
                Set(ByVal value As String)
                    _CustomerName = value
                End Set
            End Property
            Private _Address As String
            Public Property Address() As String
                Get
                    Return _Address
                End Get
                Set(ByVal value As String)
                    _Address = value
                End Set
            End Property
            Private _City As String
            Public Property City() As String
                Get
                    Return _City
                End Get
                Set(ByVal value As String)
                    _City = value
                End Set
            End Property
            Private _PostalCode As String
            Public Property PostalCode() As String
                Get
                    Return _PostalCode
                End Get
                Set(ByVal value As String)
                    _PostalCode = value
                End Set
            End Property
            Public ReadOnly Property Orders() As Order()
                Get
                    Return _Orders.Value
                End Get
            End Property
        End Class

        Class Product
            Private _ProductName As String
            Public Property ProductName() As String
                Get
                    Return _ProductName
                End Get
                Set(ByVal value As String)
                    _ProductName = value
                End Set
            End Property
            Private _ProductID As Integer
            Public Property ProductID() As Integer
                Get
                    Return _ProductID
                End Get
                Set(ByVal value As Integer)
                    _ProductID = value
                End Set
            End Property
            Private _UnitPrice As Double
            Public Property UnitPrice() As Double
                Get
                    Return _UnitPrice
                End Get
                Set(ByVal value As Double)
                    _UnitPrice = value
                End Set
            End Property
        End Class

        Class OrderDetail
            Private _OrderID As Integer
            Public Property OrderID() As Integer
                Get
                    Return _OrderID
                End Get
                Set(ByVal value As Integer)
                    _OrderID = value
                End Set
            End Property
            Private _ProductID As Integer
            Public Property ProductID() As Integer
                Get
                    Return _ProductID
                End Get
                Set(ByVal value As Integer)
                    _ProductID = value
                End Set
            End Property
            Private _UnitPrice As Double
            Public Property UnitPrice() As Double
                Get
                    Return _UnitPrice
                End Get
                Set(ByVal value As Double)
                    _UnitPrice = value
                End Set
            End Property
            Private _Quantity As Double
            Public Property Quantity() As Double
                Get
                    Return _Quantity
                End Get
                Set(ByVal value As Double)
                    _Quantity = value
                End Set
            End Property
            Private _Discount As Double
            Public Property Discount() As Double
                Get
                    Return _Discount
                End Get
                Set(ByVal value As Double)
                    _Discount = value
                End Set
            End Property


        End Class
#End Region

#Region "DataMethods"

        Shared Function GetCustomersAsStrings() As IEnumerable(Of String)

            Return IO.File.ReadAllLines("..\..\plinqdata.csv").
                SkipWhile(Function(line) line.StartsWith("CUSTOMERS") = False).
                Skip(1).
                TakeWhile(Function(line) line.StartsWith("END CUSTOMERS") = False)
        End Function
        Shared Function GetCustomers() As IEnumerable(Of Customer)

            Dim customers = IO.File.ReadAllLines("..\..\plinqdata.csv").
                SkipWhile(Function(line) line.StartsWith("CUSTOMERS") = False).
                Skip(1).
                TakeWhile(Function(line) line.StartsWith("END CUSTOMERS") = False)

            Return From line In customers
                   Let fields = line.Split(","c)
                   Select New Customer With {
                    .CustomerID = fields(0).Trim(),
                    .CustomerName = fields(1).Trim(),
                    .Address = fields(2).Trim(),
                    .City = fields(3).Trim(),
                    .PostalCode = fields(4).Trim()}
        End Function

        Shared Function GetOrders() As IEnumerable(Of Order)

            Dim orders = IO.File.ReadAllLines("..\..\plinqdata.csv").
                            SkipWhile(Function(line) line.StartsWith("ORDERS") = False).
                            Skip(1).
                            TakeWhile(Function(line) line.StartsWith("END ORDERS") = False)

            Return From line In orders
                   Let fields = line.Split(","c)
                   Select New Order With {
                    .OrderID = CType(fields(0).Trim(), Integer),
                    .CustomerID = fields(1).Trim(),
                    .OrderDate = DateTime.Parse(fields(2)),
                    .ShippedDate = DateTime.Parse(fields(3))}

        End Function

        Shared Function GetOrdersForCustomer(ByVal id As String) As Order()

            Dim orders = IO.File.ReadAllLines("..\..\plinqdata.csv").
                            SkipWhile(Function(line) line.StartsWith("ORDERS") = False).
                            Skip(1).
                            TakeWhile(Function(line) line.StartsWith("END ORDERS") = False)

            Dim orderStrings = From line In orders
                               Let fields = line.Split(","c)
                               Let custID = fields(1).Trim()
                               Where custID = id
                               Select New Order With {
                                .OrderID = CType(fields(0).Trim(), Integer),
                                .CustomerID = custID,
                                .OrderDate = DateTime.Parse(fields(2)),
                                .ShippedDate = DateTime.Parse(fields(3))}

            Return orderStrings.ToArray()

        End Function
        Shared Function GetProducts() As IEnumerable(Of Product)

            Dim products = IO.File.ReadAllLines("..\..\plinqdata.csv").
                SkipWhile(Function(line) line.StartsWith("PRODUCTS") = False).
                            Skip(1).
                            TakeWhile(Function(line) line.StartsWith("END PRODUCTS") = False)

            Return From line In products
                   Let fields = line.Split(","c)
                   Select New Product With {
                       .ProductID = CType(fields(0), Integer),
                        .ProductName = fields(1).Trim(),
                        .UnitPrice = CType(fields(2), Double)}
        End Function

        Shared Function GetOrderDetailsForOrder(ByVal orderID As Integer) As OrderDetail()
            Dim orderDetails = IO.File.ReadAllLines("..\..\plinqdata.csv").
                SkipWhile(Function(line) line.StartsWith("ORDER DETAILS") = False).
                            Skip(1).
                            TakeWhile(Function(line) line.StartsWith("END ORDER DETAILS") = False)

            Dim ordDetailStrings = From line In orderDetails
                                   Let fields = line.Split(","c)
                                   Let ordID = Convert.ToInt32(fields(0))
                                   Where ordID = orderID
                                   Select New OrderDetail With {
                                    .OrderID = ordID,
                                    .ProductID = CType(fields(1), Integer),
                                    .UnitPrice = CType(fields(2), Double),
                                    .Quantity = CType(fields(3), Double),
                                    .Discount = CType(fields(4), Double)}
            Return ordDetailStrings.ToArray()

        End Function

        Shared Function GetOrderDetails() As IEnumerable(Of OrderDetail)
            Dim orderDetails = IO.File.ReadAllLines("..\..\plinqdata.csv").
                SkipWhile(Function(line) line.StartsWith("ORDER DETAILS") = False).
                            Skip(1).
                            TakeWhile(Function(line) line.StartsWith("END ORDER DETAILS") = False)

            Return From line In orderDetails
                   Let fields = line.Split(","c)
                   Select New OrderDetail With {
                    .OrderID = CType(fields(0), Integer),
                    .ProductID = CType(fields(1), Integer),
                    .UnitPrice = CType(fields(2), Double),
                    .Quantity = CType(fields(3), Double),
                    .Discount = CType(fields(4), Double)}
        End Function
#End Region



    End Class
End Module
