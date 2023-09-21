' <SnippetImportsUsing>

Option Explicit On
Option Strict On
Imports System.Data.Objects
Imports System.Globalization

' </SnippetImportsUsing>


Module Module1

    Sub Main()

        '*** Projection Operators ***'
        'SelectSimple1()
        'SelectSimple2()
        'SelectSimple2_MQ()
        'SelectAnonymousTypes()
        'SelectAnonymousTypes_MQ()
        'SelectManyCompoundFrom() ' Needs work.
        'SelectManyCompoundFrom_MQ() 'Throws exception when mapping anonymous type. ?
        'SelectManyCompoundFrom2()
        'SelectManyCompoundFrom2_MQ() 'Throws exception when mapping anonymous type. ?
        'SelectManyFromAssignment()

        '*** Restriction Operators ***'
        'Where1()
        'Where1_MQ()
        'Where2()
        'Where2_MQ()
        'Where3()
        'Where3_MQ()
        'WhereNavProperty()
        'WhereNavProperty_MQ()
        'WhereDrilldown()

        '*** Partitioning Operators ***'
        'TakeSimple()
        'SkipSimple()
        'TakeNested()
        'SkipNested()
        'TakeWhileSimple_MQ()  'TakeWhile not supported in L2E
        'SkipWhileSimple_MQ()  'SkipWhile not supported in L2E

        '*** Ordering Operators ***'
        'OrderBySimple1()
        'OrderBySimple1_MQ()
        'OrderBySimple2()
        'OrderByThenBy()
        OrderByThenBy_MQ()
        'OrderByDescendingSimple1()
        'OrderByDescendingSimple1_MQ()
        'ThenByDescendingSimple()
        'ThenByDescending_MQ()
        'Reverse() ' Reverse not supported in L2E

        '*** Grouping Operators ***'
        ' GroupBySimple2()
        'GroupBySimple2_MQ()
        'GroupBySimple3()
        ' GroupBySimple3_MQ()
        ' GroupByCount()
        'GroupByCount_MQ()
        'GroupByNested() 'Runtime error on query.

        '*** Set Operators ***'
        'Except1()   ' Kludged Enumerable static method.
        'Except1_MQ()
        'Union1()    'ditto - kludged
        'Union1_MQ()
        'Intersect1()  'ditto - kludged
        'Intersect1_MQ()
        'DistinctRows() 'Not implemented as C# version fails at runtime.

        '*** Conversion Operators ***'
        'ToArray()  'Streamlined code
        'ToList()   'Streamlined code
        'ToDictionary()


        '*** Element Operators ***'
        'FirstSimple()
        'FirstCondition_MQ()
        'ElementAt() ' ElementAt not supported in L2E

        '*** Quantifier Operators ***'
        'AnyGrouped_MQ()
        'AllGrouped_MQ()

        '*** Aggregate Operators ***'
        'Aggregate_MQ()  'Aggregate not supported in L2E
        'Average_MQ()
        'Average2_MQ()
        'Count()
        'CountNested()
        'CountGrouped()
        'LongCountSimple()
        'SumProjection_MQ()
        'SumGrouped_MQ()
        'MinProjection_MQ()
        'MinGrouped_MQ()
        'MinElements_MQ()
        'AverageProjection_MQ()
        'AverageGrouped_MQ()
        'AverageElements_MQ()
        'MaxProjection_MQ()
        'MaxGrouped_MQ()
        'MaxElements_MQ()

        '*** Join Operators ***'
        'Join()
        'JoinSimple_MQ()
        'JoinWithGroupedResults_MQ()  'Times out.
        'GroupJoin()
        'GroupJoin_MQ()
        'GroupJoin2()
        'GroupJoin2_MQ()

        '*** Relationship Navigation ***'
        'SelectEachContactsOrders_MQ()
        'SelectEachContactsOrders2()
        'SelectEachContactsOrders2_MQ()
        'SelectEachContactsOrders3()
        'SelectEachContactsOrders3_MQ()
        'GetOrderInfoThruRelationships()
        'GetOrderInfoThruRelationships_MQ()
        LINQEntityTypeCollection()

        Console.WriteLine("Hit enter...")
        Console.Read()

    End Sub

#Region "Projection Operators"
    Public Sub LINQEntityTypeCollection()
        '<snippetQueryEntityTypeCollection>
        Using context As New AdventureWorksEntities()
            Dim LastName = "Zhou"
            Dim query = From contact In context.Contacts Where contact.LastName = LastName

            ' Iterate through the collection of Contact items.
            For Each result As Contact In query
                Console.WriteLine("Contact First Name: {0}; Last Name: {1}", _
                        result.FirstName, result.LastName)
            Next
        End Using
        ' </snippetQueryEntityTypeCollection>
    End Sub
    Sub SelectSimple1()
        ' <SnippetSelectSimple1>
        Using context As New AdventureWorksEntities
            Dim products As ObjectSet(Of Product) = context.Products

            Dim productsQuery = _
                From product In products _
                Select product

            Console.WriteLine("Product Names:")
            For Each product In productsQuery
                Console.WriteLine(product.Name)
            Next
        End Using
        ' </SnippetSelectSimple1>
    End Sub

    Sub SelectSimple2()
        ' <SnippetSelectSimple2>
        Using context As New AdventureWorksEntities
            Dim products As ObjectSet(Of Product) = context.Products

            Dim productNames = _
                From p In products _
                Select p.Name

            Console.WriteLine("Product Names:")
            For Each productName In productNames
                Console.WriteLine(productName)
            Next
        End Using
        ' </SnippetSelectSimple2>
    End Sub

    Sub SelectSimple2_MQ()
        ' <SnippetSelectSimple2_MQ>
        Using context As New AdventureWorksEntities
            Dim productNames = context.Products _
            .Select(Function(p) p.Name())

            Console.WriteLine("Product Names:")
            For Each productName In productNames
                Console.WriteLine(productName)
            Next
        End Using
        ' </SnippetSelectSimple2_MQ>
    End Sub

    Sub SelectAnonymousTypes()
        ' <SnippetSelectAnonymousTypes>
        Using context As New AdventureWorksEntities
            Dim products As ObjectSet(Of Product) = context.Products

            Dim query = _
                From product In products _
                Select New With _
                { _
                    .ProductId = product.ProductID, _
                    .ProductName = product.Name _
                }

            Console.WriteLine("Product Info:")
            For Each productInfo In query
                Console.WriteLine("Product Id: {0} Product name: {1} ", _
                        productInfo.ProductId, productInfo.ProductName)
            Next
        End Using
        ' </SnippetSelectAnonymousTypes>
    End Sub

    Sub SelectAnonymousTypes_MQ()
        ' <SnippetSelectAnonymousTypes_MQ>
        Using context As New AdventureWorksEntities
            Dim query = context.Products _
            .Select(Function(prod) New With _
            { _
                .ProductName = prod.Name, _
                .ProductId = prod.ProductID _
            })

            Console.WriteLine("Product Info:")
            For Each productInfo In query
                Console.WriteLine("Product Id: {0} Product name: {1} ", _
                        productInfo.ProductId, productInfo.ProductName)
            Next
        End Using
        ' </SnippetSelectAnonymousTypes_MQ>
    End Sub

    Sub SelectManyCompoundFrom()
        ' <SnippetSelectManyCompoundFrom>
        Dim totalDue = 500D
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = _
                From contact In contacts _
                From order In orders _
                Where contact.ContactID = order.Contact.ContactID _
                        And order.TotalDue < totalDue _
                Select New With _
                { _
                    .ContactID = contact.ContactID, _
                    .LastName = contact.LastName, _
                    .FirstName = contact.FirstName, _
                    .OrderID = order.SalesOrderID, _
                    .Total = order.TotalDue _
                }

            For Each smallOrder In query
                Console.WriteLine("Contact ID: {0} Name: {1}, {2} Order ID: {3} Total Due: ${4} ", _
                    smallOrder.ContactID, smallOrder.LastName, smallOrder.FirstName, _
                    smallOrder.OrderID, smallOrder.Total)
            Next
        End Using
        '</SnippetSelectManyCompoundFrom>
    End Sub

    Sub SelectManyCompoundFrom_MQ()
        ' <SnippetSelectManyCompoundFrom_MQ>
        Dim totalDue = 500D
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = contacts.SelectMany( _
                Function(contact) orders.Where(Function(order) _
                    (contact.ContactID = order.Contact.ContactID) _
                            And order.TotalDue < totalDue) _
                    .Select(Function(order) New With _
                    { _
                        .ContactID = contact.ContactID, _
                        .LastName = contact.LastName, _
                        .FirstName = contact.FirstName, _
                        .OrderID = order.SalesOrderID, _
                        .Total = order.TotalDue _
                    }) _
            )

            For Each smallOrder In query
                Console.WriteLine("Contact ID: {0} Name: {1}, {2} Order ID: {3} Total Due: ${4} ", _
                    smallOrder.ContactID, smallOrder.LastName, smallOrder.FirstName, _
                    smallOrder.OrderID, smallOrder.Total)
            Next
        End Using
        '</SnippetSelectManyCompoundFrom_MQ>
    End Sub

    Sub SelectManyCompoundFrom2()
        ' <SnippetSelectManyCompoundFrom2>
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = _
                From contact In contacts _
                From order In orders _
                Where contact.ContactID = order.Contact.ContactID _
                        And order.OrderDate >= New DateTime(2002, 10, 1) _
                Select New With _
                { _
                    .ContactID = contact.ContactID, _
                    .LastName = contact.LastName, _
                    .FirstName = contact.FirstName, _
                    .OrderID = order.SalesOrderID, _
                    .OrderDate = order.OrderDate _
                }

            For Each order In query
                Console.WriteLine("Contact ID: {0} Name: {1}, {2} Order ID: {3} Order date: {4:d} ", _
                    order.ContactID, order.LastName, order.FirstName, _
                    order.OrderID, order.OrderDate)
            Next
        End Using
        '</SnippetSelectManyCompoundFrom2>
    End Sub

    Sub SelectManyCompoundFrom2_MQ()
        ' <SnippetSelectManyCompoundFrom2_MQ>
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = contacts.SelectMany( _
                Function(contact) orders.Where(Function(order) _
                    (contact.ContactID = order.Contact.ContactID) _
                            And order.OrderDate >= New DateTime(2002, 10, 1)) _
                    .Select(Function(order) New With _
                    { _
                        .ContactID = contact.ContactID, _
                        .LastName = contact.LastName, _
                        .FirstName = contact.FirstName, _
                        .OrderID = order.SalesOrderID, _
                        .OrderDate = order.OrderDate _
                    }) _
            )

            For Each order In query
                Console.WriteLine("Contact ID: {0} Name: {1}, {2} Order ID: {3} Order date: {4:d} ", _
                    order.ContactID, order.LastName, order.FirstName, _
                    order.OrderID, order.OrderDate)
            Next
        End Using
        '</SnippetSelectManyCompoundFrom2_MQ>
    End Sub

    Sub SelectManyFromAssignment()
        ' <SnippetSelectManyFromAssignment>
        Dim totalDue = 10000D
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = _
                From contact In contacts _
                From order In orders _
                Let total = order.TotalDue _
                Where contact.ContactID = order.Contact.ContactID _
                        And total >= totalDue _
                Select New With _
                { _
                    .ContactID = contact.ContactID, _
                    .LastName = contact.LastName, _
                    .OrderID = order.SalesOrderID, _
                    total _
                }

            For Each order In query
                Console.WriteLine("Contact ID: {0} Last name: {1} Order ID: {2} Total: {3}", _
                        order.ContactID, order.LastName, order.OrderID, order.total)
            Next
        End Using
        '</SnippetSelectManyFromAssignment>
    End Sub
#End Region

#Region "Restriction Operators"
    Sub Where1()
        ' <SnippetWhere1>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim onlineOrders = _
                From order In orders _
                Where order.OnlineOrderFlag = True _
                Select New With { _
                   .SalesOrderID = order.SalesOrderID, _
                   .OrderDate = order.OrderDate, _
                   .SalesOrderNumber = order.SalesOrderNumber _
                }

            For Each onlineOrder In onlineOrders
                Console.WriteLine("Order ID: {0} Order date: {1:d} Order number: {2}", _
                        onlineOrder.SalesOrderID, _
                        onlineOrder.OrderDate, _
                        onlineOrder.SalesOrderNumber)
            Next
        End Using
        ' </SnippetWhere1>
    End Sub

    Sub Where1_MQ()
        ' <SnippetWhere1_MQ>
        Using context As New AdventureWorksEntities
            Dim onlineOrders = context.SalesOrderHeaders _
                .Where(Function(order) order.OnlineOrderFlag = True) _
                .Select(Function(order) New With { _
                   .SalesOrderID = order.SalesOrderID, _
                   .OrderDate = order.OrderDate, _
                   .SalesOrderNumber = order.SalesOrderNumber _
                })

            For Each onlineOrder In onlineOrders
                Console.WriteLine("Order ID: {0} Order date: {1:d} Order number: {2}", _
                        onlineOrder.SalesOrderID, _
                        onlineOrder.OrderDate, _
                        onlineOrder.SalesOrderNumber)
            Next
        End Using
        ' </SnippetWhere1_MQ>
    End Sub

    Sub Where2()
        ' <SnippetWhere2>
        Dim orderQtyMin = 2
        Dim orderQtyMax = 6
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderDetail) = context.SalesOrderDetails

            Dim query = _
                From order In orders _
                Where order.OrderQty > orderQtyMin And order.OrderQty < orderQtyMax _
                Select New With { _
                    .SalesOrderID = order.SalesOrderID, _
                    .OrderQty = order.OrderQty _
                }

            For Each order In query
                Console.WriteLine("Order ID: {0} Order quantity: {1}", _
                        order.SalesOrderID, order.OrderQty)
            Next
        End Using
        ' </SnippetWhere2>
    End Sub

    Sub Where2_MQ()
        ' <SnippetWhere2_MQ>
        Dim orderQtyMin = 2
        Dim orderQtyMax = 6
        Using context As New AdventureWorksEntities
            Dim query = context.SalesOrderDetails _
                .Where(Function(order) order.OrderQty > orderQtyMin And order.OrderQty < orderQtyMax) _
                .Select(Function(order) New With { _
                    .SalesOrderID = order.SalesOrderID, _
                    .OrderQty = order.OrderQty _
                })

            For Each order In query
                Console.WriteLine("Order ID: {0} Order quantity: {1}", _
                        order.SalesOrderID, order.OrderQty)
            Next
        End Using
        ' </SnippetWhere2_MQ>
    End Sub

    Sub Where3()
        ' <SnippetWhere3>
        Dim color = "Red"
        Using context As New AdventureWorksEntities
            Dim products As ObjectSet(Of Product) = context.Products

            Dim query = _
                From product In products _
                Where product.Color = color _
                Select New With { _
                    .Name = product.Name, _
                    .ProductNumber = product.ProductNumber, _
                    .ListPrice = product.ListPrice _
                }

            For Each product In query
                Console.WriteLine("Name: {0}", product.Name)
                Console.WriteLine("Product number: {0}", product.ProductNumber)
                Console.WriteLine("List price: ${0}", product.ListPrice)
                Console.WriteLine("")
            Next
        End Using
        ' </SnippetWhere3>
    End Sub

    Sub Where3_MQ()
        ' <SnippetWhere3_MQ>
        Dim color = "Red"
        Using context As New AdventureWorksEntities
            Dim query = context.Products _
                .Where(Function(product) product.Color = color) _
                .Select(Function(product) New With { _
                    .Name = product.Name, _
                    .ProductNumber = product.ProductNumber, _
                    .ListPrice = product.ListPrice _
                })

            For Each product In query
                Console.WriteLine("Name: {0}", product.Name)
                Console.WriteLine("Product number: {0}", product.ProductNumber)
                Console.WriteLine("List price: ${0}", product.ListPrice)
                Console.WriteLine("")
            Next
        End Using
        ' </SnippetWhere3_MQ>
    End Sub

    Sub WhereNavProperty()
        ' <SnippetWhereNavProperty>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = _
                From order In orders _
                Where order.OrderDate >= New DateTime(2003, 12, 1) _
                Select order

            Console.WriteLine("Orders that were made after December 1, 2003:")
            For Each order In query
                Console.WriteLine("OrderID {0} Order date: {1:d} ", _
                        order.SalesOrderID, order.OrderDate)
                For Each orderDetail In order.SalesOrderDetails
                    Console.WriteLine("  Product ID: {0} Unit Price {1}", _
                        orderDetail.ProductID, orderDetail.UnitPrice)
                Next
            Next
        End Using
        ' </SnippetWhereNavProperty>
    End Sub

    Sub WhereNavProperty_MQ()
        ' <SnippetWhereNavProperty_MQ>
        Using context As New AdventureWorksEntities
            Dim query = context.SalesOrderHeaders _
                .Where(Function(order) order.OrderDate >= New DateTime(2003, 12, 1)) _
                .Select(Function(order) order)

            Console.WriteLine("Orders that were made after December 1, 2003:")
            For Each order In query
                Console.WriteLine("OrderID {0} Order date: {1:d} ", _
                        order.SalesOrderID, order.OrderDate)
                For Each orderDetail In order.SalesOrderDetails
                    Console.WriteLine("  Product ID: {0} Unit Price {1}", _
                        orderDetail.ProductID, orderDetail.UnitPrice)
                Next
            Next
        End Using
        ' </SnippetWhereNavProperty_MQ>
    End Sub



    Sub WhereDrilldown()
        ' <SnippetWhereDrilldown>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = _
                From order In orders _
                Where order.OrderDate >= New DateTime(2002, 12, 1) _
                Select order

            Console.WriteLine("Orders that were made after 12/1/2002:")
            For Each order As SalesOrderHeader In query
                Console.WriteLine("OrderID {0} Order date: {1:d} ", _
                    order.SalesOrderID, order.OrderDate)
                For Each orderDetail In order.SalesOrderDetails
                    Console.WriteLine("  Product ID: {0} Unit Price {1}", _
                        orderDetail.ProductID, orderDetail.UnitPrice)
                Next
            Next
        End Using
        ' </SnippetWhereDrilldown>
    End Sub
#End Region

#Region "Partitioning Operators"

    Sub TakeSimple()
        ' <SnippetTakeSimple>
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts

            Dim first5Contacts As IQueryable(Of Contact) = contacts.Take(5)

            Console.WriteLine("First 5 contacts:")
            For Each contact As Contact In first5Contacts
                Console.WriteLine("Title = {0} " & vbTab & " FirstName = {1} " _
                    & vbTab & " Lastname = {2}", contact.Title, contact.FirstName, _
                    contact.LastName)
            Next
        End Using
        ' </SnippetTakeSimple>
    End Sub

    Sub SkipSimple()
        ' <SnippetSkipSimple>
        Using context As New AdventureWorksEntities
            'LINQ to Entities only supports Skip on ordered collections.
            Dim products As IOrderedQueryable(Of Product) = _
                    context.Products.OrderBy(Function(p) p.ListPrice)

            Dim allButFirst3Products As IQueryable(Of Product) = products.Skip(3)

            Console.WriteLine("All but first 3 products:")
            For Each product As Product In allButFirst3Products
                Console.WriteLine("Name: {0} \t ID: {1}", _
                        product.Name, _
                        product.ProductID)
            Next
        End Using
        ' </SnippetSkipSimple>
    End Sub

    Sub TakeNested()
        ' <SnippetTakeNested>
        Dim city = "Seattle"
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders
            Dim addresses As ObjectSet(Of Address) = context.Addresses

            Dim query = ( _
                From address In addresses _
                From order In orders _
                Where address.AddressID = order.Address.AddressID _
                         And address.City = city _
                Select New With _
                { _
                    .City = address.City, _
                    .OrderID = order.SalesOrderID, _
                    .OrderDate = order.OrderDate _
                }).Take(3)

            Console.WriteLine("First 3 orders in Seattle:")
            For Each order In query
                Console.WriteLine("City: {0} Order ID: {1} Total Due: {2:d}", _
                    order.City, order.OrderID, order.OrderDate)
            Next
        End Using
        ' </SnippetTakeNested>
    End Sub

    Sub SkipNested()
        ' <SnippetSkipNested>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders
            Dim addresses As ObjectSet(Of Address) = context.Addresses

            'LINQ to Entities only supports Skip on ordered collections.
            Dim query = ( _
                From address In addresses _
                From order In orders _
                Where address.AddressID = order.Address.AddressID _
                         And address.City = "Seattle" _
                Order By order.SalesOrderID _
                Select New With _
                { _
                    .City = address.City, _
                    .OrderID = order.SalesOrderID, _
                    .OrderDate = order.OrderDate _
                }).Skip(2)

            Console.WriteLine("All but first 2 orders in Seattle:")
            For Each order In query
                Console.WriteLine("City: {0} Order ID: {1} Total Due: {2:d}", _
                    order.City, order.OrderID, order.OrderDate)
            Next
        End Using
        ' </SnippetSkipNested>
    End Sub

    Sub TakeWhileSimple_MQ()
        ' TakeWhile not supported in L2E
        'Using context As New AdventureWorksEntities
        'Dim products As ObjectSet(Of Product) = context.Products

        'Dim takeWhilePriceUnder300 = products _
        '.OrderBy(Function(listprice) listprice.ListPrice) _
        '.TakeWhile(Function(prod) prod.ListPrice < 300D)

        'Console.WriteLine("First ListPrice less than 300:")
        'For Each product As Product In takeWhilePriceUnder300
        'Console.WriteLine(Product.ListPrice)
        'Next
        'End Using

    End Sub

    Sub SkipWhileSimple_MQ()
        ' SkipWhile not supported in L2E
        'Using context As New AdventureWorksEntities
        'Dim products As ObjectSet(Of Product) = context.Products

        'Dim skipWhilePriceUnder300 = products _
        '.OrderBy(Function(listprice) listprice.ListPrice) _
        '.AsEnumerable() _
        '.SkipWhile(Function(prod) prod.ListPrice < 300D)

        'Console.WriteLine("Skip ListPrice less than 300:")
        'For Each product As Product In skipWhilePriceUnder300
        'Console.WriteLine(Product.ListPrice)
        'Next
        'End Using

    End Sub

#End Region '"Partitioning Operators"

#Region "Ordering Operators"
    Sub OrderBySimple1()
        ' <SnippetOrderBySimple1>
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts

            Dim sortedContacts = _
                From contact In contacts _
                Order By contact.LastName _
                Select contact

            Console.WriteLine("The sorted list of last names:")
            For Each n As Contact In sortedContacts
                Console.WriteLine(n.LastName)
            Next
        End Using
        ' </SnippetOrderBySimple1>
    End Sub

    Sub OrderBySimple1_MQ()
        ' <SnippetOrderBySimple1_MQ>
        Using context As New AdventureWorksEntities

            Dim sortedContacts = context.Contacts _
                .OrderBy(Function(contact) contact.LastName) _
                .Select(Function(contact) contact)

            Console.WriteLine("The sorted list of last names:")
            For Each n As Contact In sortedContacts
                Console.WriteLine(n.LastName)
            Next
        End Using
        ' </SnippetOrderBySimple1_MQ>
    End Sub

    Sub OrderBySimple2()
        ' <SnippetOrderBySimple2>
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts

            Dim sortedNames = _
                From n In contacts _
                Order By n.LastName.Length _
                Select n

            Console.WriteLine("The sorted list of last names (by length):")
            For Each n As Contact In sortedNames
                Console.WriteLine(n.LastName)
            Next
        End Using
        ' </SnippetOrderBySimple2>
    End Sub

    Sub OrderByThenBy()
        ' <SnippetOrderByThenBy>
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts

            Dim sortedContacts = _
                From contact In contacts _
                Order By contact.LastName, contact.FirstName _
                Select contact

            Console.WriteLine("The list of contacts sorted by last name then by first name:")
            For Each sortedContact As Contact In sortedContacts
                Console.WriteLine(sortedContact.LastName + ", " + sortedContact.FirstName)
            Next
        End Using
        ' </SnippetOrderByThenBy>
    End Sub

    Sub OrderByThenBy_MQ()
        ' <SnippetOrderByThenBy_MQ>
        Using context As New AdventureWorksEntities

            Dim sortedContacts = context.Contacts _
            .OrderBy(Function(c) c.LastName) _
            .ThenBy(Function(c) c.FirstName) _
            .Select(Function(c) c)

            Console.WriteLine("The list of contacts sorted by last name then by first name:")
            For Each sortedContact As Contact In sortedContacts
                Console.WriteLine(sortedContact.LastName + ", " + sortedContact.FirstName)
            Next
        End Using
        ' </SnippetOrderByThenBy_MQ>
    End Sub

    '<SnippetCustomComparer>
    Private Class CaseInsensitiveComparer
        Implements IComparer(Of String)

        Function Compare(ByVal x As String, ByVal y As String) As Integer _
                        Implements IComparer(Of String).Compare
            Return String.Compare(x, y, True, CultureInfo.InvariantCulture)
        End Function
    End Class
    '</SnippetCustomComparer>



    Sub OrderByDescendingSimple1()
        ' <SnippetOrderByDescendingSimple1>
        Using context As New AdventureWorksEntities
            Dim products As ObjectSet(Of Product) = context.Products

            Dim sortedPrices = _
                From product In products _
                Order By product.ListPrice Descending _
                Select product.ListPrice

            Console.WriteLine("The list price from highest to lowest:")
            For Each price As Decimal In sortedPrices
                Console.WriteLine(price)
            Next
        End Using
        ' </SnippetOrderByDescendingSimple1>
    End Sub

    Sub OrderByDescendingSimple1_MQ()
        ' <SnippetOrderByDescendingSimple1_MQ>
        Using context As New AdventureWorksEntities
            Dim sortedPrices = context.Products _
                .OrderByDescending(Function(prod) prod.ListPrice) _
                .Select(Function(prod) prod.ListPrice)

            Console.WriteLine("The list price from highest to lowest:")
            For Each listPrice As Decimal In sortedPrices
                Console.WriteLine(listPrice)
            Next
        End Using
        ' </SnippetOrderByDescendingSimple1_MQ>
    End Sub

    Sub ThenByDescendingSimple()
        ' <SnippetThenByDescendingSimple>
        Using context As New AdventureWorksEntities
            Dim products As ObjectSet(Of Product) = context.Products

            Dim query As IQueryable(Of Product) = _
                From product In products _
                Order By product.Name, product.ListPrice Descending _
                Select product

            For Each prod As Product In query
                Console.WriteLine("Product ID: {0} Product Name: {1} List Price {2}", _
                    prod.ProductID, _
                    prod.Name, _
                    prod.ListPrice)
            Next
        End Using
        ' </SnippetThenByDescendingSimple>
    End Sub

    Sub ThenByDescending_MQ()
        ' <SnippetThenByDescending_MQ>
        Using context As New AdventureWorksEntities
            Dim products As ObjectSet(Of Product) = context.Products

            Dim query As IOrderedQueryable(Of Product) = products _
            .OrderBy(Function(prod As Product) prod.ListPrice) _
            .ThenByDescending(Function(prod As Product) prod.Name)

            For Each prod As Product In query
                Console.WriteLine("Product ID: {0} Product Name: {1} List Price {2}", _
                    prod.ProductID, _
                    prod.Name, _
                    prod.ListPrice)
            Next
        End Using
        ' </SnippetThenByDescending_MQ>
    End Sub

    Sub Reverse()
        ' Reverse not supported in L2E
        'Using context As New AdventureWorksEntities
        'Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

        'Dim query = ( _
        '    From order In orders _
        '    Where order.OrderDate < New DateTime(2002, 2, 20) _
        '    Select order).Reverse()

        'Console.WriteLine("A backwards list of orders where OrderDate < Feb 20, 2002")
        'For Each order As SalesOrderHeader In query
        'Console.WriteLine(order.OrderDate)
        'Next
        'End Using

    End Sub

#End Region

#Region "Grouping Operators"

    Sub GroupBySimple2()
        ' <SnippetGroupBySimple2>
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts

            Dim query = ( _
                From contact In contacts _
                Group By firstLetter = contact.LastName.Substring(0, 1) _
                Into contactGroup = Group _
                Select New With {.FirstLetter = firstLetter, .Names = contactGroup}) _
                .OrderBy(Function(letter) letter.FirstLetter)

            For Each n In query
                Console.WriteLine("Last names that start with the letter '{0}':", _
                    n.FirstLetter)
                For Each name In n.Names
                    Console.WriteLine(name.LastName)
                Next
            Next
        End Using
        ' </SnippetGroupBySimple2>

    End Sub

    Sub GroupBySimple2_MQ()
        ' <SnippetGroupBySimple2_MQ>
        Using context As New AdventureWorksEntities

            Dim query = context.Contacts _
            .GroupBy(Function(c) c.LastName.Substring(0, 1)) _
            .OrderBy(Function(c) c.Key) _
            .Select(Function(c) c)

            For Each group As IGrouping(Of String, Contact) In query
                Console.WriteLine("Last names that start with the letter '{0}':", group.Key)

                For Each contact As Contact In group

                    Console.WriteLine(contact.LastName)
                Next
            Next

        End Using
        ' </SnippetGroupBySimple2_MQ>
    End Sub

    Sub GroupBySimple3()
        ' <SnippetGroupBySimple3>
        Using context As New AdventureWorksEntities
            Dim addresses As ObjectSet(Of Address) = context.Addresses

            Dim query = _
                From adrs In addresses _
                Group adrs By adrs.PostalCode Into g = Group _
                Select New With {.PostalCode = PostalCode, .AddressLine = g}

            For Each addressGroup In query
                Console.WriteLine("Postal Code: {0}", addressGroup.PostalCode)
                For Each adrs In addressGroup.AddressLine
                    Console.WriteLine(vbTab & adrs.AddressLine1 & _
                        adrs.AddressLine2)
                Next
            Next
        End Using
        ' </SnippetGroupBySimple3>
    End Sub

    Sub GroupBySimple3_MQ()
        ' <SnippetGroupBySimple3_MQ>
        Using context As New AdventureWorksEntities
            Dim query = context.Addresses _
                .GroupBy(Function(Address) Address.PostalCode) _
                .Select(Function(Address) Address)

            For Each addressGroup As IGrouping(Of String, Address) In query
                Console.WriteLine("Postal Code: {0}", addressGroup.Key)
                For Each address As Address In addressGroup

                    Console.WriteLine("   " + address.AddressLine1 + address.AddressLine2)
                Next
            Next
        End Using
        ' </SnippetGroupBySimple3_MQ>
    End Sub

    Sub GroupByCount()
        ' <SnippetGroupByCount>
        Using context As New AdventureWorksEntities
            Dim salesOrders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = From order In salesOrders _
                        Group order By order.CustomerID Into idGroup = Group, Count()

            For Each group In query
                Console.WriteLine("Customer ID: {0}", group.CustomerID)
                Console.WriteLine("Order Count: {0}", group.Count)

                For Each sale In group.idGroup
                    Console.WriteLine("   Sale ID: {0}", sale.SalesOrderID)
                Next

                Console.WriteLine("")
            Next


        End Using
        ' </SnippetGroupByCount>
    End Sub

    Sub GroupByCount_MQ()
        ' <SnippetGroupByCount_MQ>
        Using context As New AdventureWorksEntities

            Dim query = context.SalesOrderHeaders _
                .GroupBy(Function(order) order.CustomerID)

            ' Iterate over each IGrouping
            For Each group In query

                Console.WriteLine("Customer ID: {0}", group.Key)
                Console.WriteLine("Order Count: {0}", group.Count)

                For Each sale In group
                    Console.WriteLine("   Sale ID: {0}", sale.SalesOrderID)
                Next

                Console.WriteLine("")

            Next

        End Using
        ' </SnippetGroupByCount_MQ>
    End Sub

    Sub GroupByNested()
        ' <SnippetGroupByNested>
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts
            Dim sales As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim saleContacts = sales.Select(Function(s) s.Contact.ContactID)

            'Don't know how to mimic SalesOrderContact DataRelation object.
            Dim query = _
                From cont In contacts _
                Select New With _
                    { _
                        .ContactID = cont.ContactID, _
                        .YearGroups = _
                            From ordr In sales _
                            Let odYear = ordr.OrderDate.Year _
                            Group ordr By odYear Into yg = Group _
                            Select New With _
                            { _
                                .Year = odYear, _
                                .MonthGroups = _
                                    From ordr In yg _
                                    Let odMonth = ordr.OrderDate.Month _
                                    Group ordr By odMonth Into mg = Group _
                                    Select New With {.Month = odMonth, .Orders = mg} _
                            } _
                    }

            For Each contactGroup In query
                Console.WriteLine("ContactID = {0}", contactGroup.ContactID)
                For Each yearGroup In contactGroup.YearGroups
                    Console.WriteLine(vbTab & " Year= {0}", yearGroup.Year)
                    For Each monthGroup In yearGroup.MonthGroups
                        Console.WriteLine(vbTab & vbTab & " Month= {0}", monthGroup.Month)
                        For Each order In monthGroup.Orders
                            Console.WriteLine(vbTab & vbTab & vbTab & " OrderID= {0} ", _
                                order.SalesOrderID)
                            Console.WriteLine(vbTab & vbTab & vbTab & " OrderDate= {0} ", _
                                order.OrderDate)
                        Next
                    Next
                Next
            Next
        End Using
        ' </SnippetGroupByNested>
    End Sub



    '*** Grouping Operators ***'
    '    GroupBySimple2()
    ' GroupBySimple3()
    ' GroupByNested()

#End Region '"Grouping Operators"

#Region "Set Operators"

    Sub Except1()
        ' <SnippetExcept1>
        Dim title = "Ms."
        Dim firstName = "Sandra"
        Using context As New AdventureWorksEntities
            Dim contact As ObjectSet(Of Contact) = context.Contacts

            Dim query1 As IQueryable(Of Contact) = _
                From c In contact _
                Where c.Title = title _
                Select c

            Dim query2 As IQueryable(Of Contact) = _
                From c In contact _
                Where c.FirstName = firstName _
                Select c

            'Dim contacts = query1.Except(query2)  //Old, problematic line.
            Dim contacts = Enumerable.Except(query1, query2)

            Console.WriteLine("Except of contacts sequences:")
            For Each c As Contact In contacts
                Console.WriteLine("Id: {0}" & vbTab & " FirstName: {1}" & vbTab & " LastName: {2} ", _
                    c.ContactID, c.FirstName, c.LastName)
            Next
        End Using
        ' </SnippetExcept1>
    End Sub

    Sub Except1_MQ()
        ' <SnippetExcept1_MQ>
        Dim title = "Ms."
        Dim firstName = "Sandra"
        Using context As New AdventureWorksEntities
            Dim contact As ObjectSet(Of Contact) = context.Contacts

            Dim query1 As IQueryable(Of Contact) = contact _
                .Where(Function(c) c.Title = title) _
                .Select(Function(c) c)

            Dim query2 As IQueryable(Of Contact) = contact _
                .Where(Function(c) c.FirstName = firstName) _
                .Select(Function(c) c)

            'Dim contacts = query1.Except(query2)  //Old, problematic line.
            Dim contacts = Enumerable.Except(query1, query2)

            Console.WriteLine("Except of contacts sequences:")
            For Each c As Contact In contacts
                Console.WriteLine("Id: {0}" & vbTab & " FirstName: {1}" & vbTab & " LastName: {2} ", _
                    c.ContactID, c.FirstName, c.LastName)
            Next
        End Using
        ' </SnippetExcept1_MQ>
    End Sub

    Sub Union1()
        ' <SnippetUnion1>
        Dim title = "Ms."
        Dim firstName = "Sandra"
        Using context As New AdventureWorksEntities
            Dim contact As ObjectSet(Of Contact) = context.Contacts

            Dim query1 As IQueryable(Of Contact) = _
                From c In contact _
                Where c.Title = title _
                Select c

            Dim query2 As IQueryable(Of Contact) = _
                From c In contact _
                Where c.FirstName = firstName _
                Select c

            'Dim contacts = query1.Union(query2)  //old, problematic line
            Dim contacts = Enumerable.Union(query1, query2)

            Console.WriteLine("Union of contacts sequences:")
            For Each c As Contact In contacts
                Console.WriteLine("Id: {0}" & vbTab & " FirstName: {1}" & vbTab & " LastName: {2} ", _
                    c.ContactID, c.FirstName, c.LastName)
            Next
        End Using
        ' </SnippetUnion1>
    End Sub

    Sub Union1_MQ()
        ' <SnippetUnion1_MQ>
        Dim title = "Ms."
        Dim firstName = "Sandra"
        Using context As New AdventureWorksEntities
            Dim contact As ObjectSet(Of Contact) = context.Contacts

            Dim query1 As IQueryable(Of Contact) = contact _
                .Where(Function(c) c.Title = title) _
                .Select(Function(c) c)

            Dim query2 As IQueryable(Of Contact) = contact _
                .Where(Function(c) c.FirstName = firstName) _
                .Select(Function(c) c)

            'Dim contacts = query1.Union(query2)  //old, problematic line
            Dim contacts = Enumerable.Union(query1, query2)

            Console.WriteLine("Union of contacts sequences:")
            For Each c As Contact In contacts
                Console.WriteLine("Id: {0}" & vbTab & " FirstName: {1}" & vbTab & " LastName: {2} ", _
                    c.ContactID, c.FirstName, c.LastName)
            Next
        End Using
        ' </SnippetUnion1_MQ>
    End Sub

    Sub Intersect1()
        ' <SnippetIntersect1>
        Dim title = "Ms."
        Dim firstName = "Sandra"
        Using context As New AdventureWorksEntities
            Dim contact As ObjectSet(Of Contact) = context.Contacts

            Dim query1 As IQueryable(Of Contact) = _
                From c In contact _
                Where c.Title = title _
                Select c

            Dim query2 As IQueryable(Of Contact) = _
                From c In contact _
                Where c.FirstName = firstName _
                Select c

            'Dim contacts = query1.Intersect(query2)  //old, problematic line
            Dim contacts = Enumerable.Intersect(query1, query2)

            Console.WriteLine("Intersect of contacts sequences:")
            For Each c As Contact In contacts
                Console.WriteLine("Id: {0}" & vbTab & " FirstName: {1}" & vbTab & " LastName: {2} ", _
                    c.ContactID, c.FirstName, c.LastName)
            Next
        End Using
        ' </SnippetIntersect1>
    End Sub

    Sub Intersect1_MQ()
        ' <SnippetIntersect1_MQ>
        Dim title = "Ms."
        Dim firstName = "Sandra"
        Using context As New AdventureWorksEntities
            Dim contact As ObjectSet(Of Contact) = context.Contacts

            Dim query1 As IQueryable(Of Contact) = contact _
                .Where(Function(c) c.Title = title) _
                .Select(Function(c) c)

            Dim query2 As IQueryable(Of Contact) = contact _
                .Where(Function(c) c.FirstName = firstName) _
                .Select(Function(c) c)

            'Dim contacts = query1.Intersect(query2)  //old, problematic line
            Dim contacts = Enumerable.Intersect(query1, query2)

            Console.WriteLine("Intersect of contacts sequences:")
            For Each c As Contact In contacts
                Console.WriteLine("Id: {0}" & vbTab & " FirstName: {1}" & vbTab & " LastName: {2} ", _
                    c.ContactID, c.FirstName, c.LastName)
            Next
        End Using
        ' </SnippetIntersect1_MQ>
    End Sub

#End Region

#Region "Conversion Operators"

    Sub ToArray()
        ' <SnippetToArray>
        Using context As New AdventureWorksEntities
            Dim products As ObjectSet(Of Product) = context.Products

            Dim prodArray As Product() = ( _
                From product In products _
                Order By product.ListPrice Descending _
                Select product).ToArray()

            Console.WriteLine("The list price from highest to lowest:")
            For Each prod As Product In prodArray
                Console.WriteLine(prod.ListPrice)
            Next
        End Using
        ' </SnippetToArray>
    End Sub

    Sub ToList()
        ' <SnippetToList>
        Using context As New AdventureWorksEntities
            Dim products As ObjectSet(Of Product) = context.Products

            Dim prodList As List(Of Product) = ( _
                From product In products _
                Order By product.Name _
                Select product).ToList()

            Console.WriteLine("The product list, ordered by product name:")
            For Each prod As Product In prodList
                Console.WriteLine(prod.Name.ToLower(CultureInfo.InvariantCulture))
            Next
        End Using
        ' </SnippetToList>
    End Sub

    Sub ToDictionary()
        ' <SnippetToDictionary>
        Using context As New AdventureWorksEntities
            Dim products As ObjectSet(Of Product) = context.Products

            Dim scoreRecordsDict As Dictionary(Of String, Product) = _
                products.ToDictionary(Function(record) record.Name)

            Console.WriteLine("Top Tube's ProductID: {0}", _
                scoreRecordsDict("Top Tube").ProductID)
        End Using
        ' </SnippetToDictionary>
    End Sub

#End Region  '"Conversion Operators"

#Region "Element Operators"

    Sub FirstSimple()
        ' <SnippetFirstSimple>
        Dim firstName = "Brooke"
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts

            Dim query As Contact = ( _
                From cont In contacts _
                Where cont.FirstName = firstName _
                Select cont).First()

            Console.WriteLine("ContactID: " & query.ContactID)
            Console.WriteLine("FirstName: " & query.FirstName)
            Console.WriteLine("LastName: " & query.LastName)
        End Using
        ' </SnippetFirstSimple>
    End Sub

    Sub FirstCondition_MQ()
        ' <SnippetFirstCondition_MQ>
        Dim name = "caroline"
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts

            Dim query = contacts.First(Function(cont) _
                    cont.EmailAddress.StartsWith(name))

            Console.WriteLine("An email address starting with 'caroline': {0}", _
                    query.EmailAddress)
        End Using
        ' </SnippetFirstCondition_MQ>
    End Sub

    Sub ElementAt()
        ' ElementAt not supported in L2E
        'Using context As New AdventureWorksEntities
        'Dim addresses As ObjectSet(Of Address) = context.Addresses

        'Dim fifthAddress As String = ( _
        '   From add In addresses _
        '   Where add.PostalCode = "M4B 1V7" _
        '   Select add.AddressLine1) _
        '.ElementAt(5)

        'Console.WriteLine("Fifth address where PostalCode = 'M4B 1V7': {0}", _
        '        fifthAddress)
        'End Using
        '
    End Sub

#End Region  '"Element Operators"

#Region "Quantifier Operators"

    Sub AnyGrouped_MQ()
        ' <SnippetAnyGrouped_MQ>
        Using context As New AdventureWorksEntities
            Dim products As ObjectSet(Of Product) = context.Products

            Dim query = _
                From prod In products _
                Let prodCol = prod.Color _
                Group prod By prodCol Into g = Group _
                Where g.Any(Function(p) p.ListPrice = 0) _
                Select New With {.Color = prodCol, .Products = g}

            For Each productGroup In query
                Console.WriteLine(productGroup.Color)
                For Each prod In productGroup.Products
                    Console.WriteLine(vbTab & " {0}, {1}", _
                        prod.Name, prod.ListPrice)
                Next
            Next
        End Using
        ' </SnippetAnyGrouped_MQ>
    End Sub

    Sub AllGrouped_MQ()
        ' <SnippetAllGrouped_MQ>
        Using context As New AdventureWorksEntities
            Dim products As ObjectSet(Of Product) = context.Products

            Dim query = _
                From prod In products _
                Let prodCol = prod.Color _
                Group prod By prodCol Into g = Group _
                Where g.All(Function(p) p.ListPrice > 0) _
                Select New With {.Color = prodCol, .Products = g}

            For Each productGroup In query
                Console.WriteLine(productGroup.Color)
                For Each prod In productGroup.Products
                    Console.WriteLine(vbTab & " {0}, {1}", _
                        prod.Name, prod.ListPrice)
                Next
            Next
        End Using
        ' </SnippetAllGrouped_MQ>
    End Sub

#End Region  '"Quantifier Operators"

#Region "Aggregate Operators"

    Sub Aggregate_MQ()
        ' Aggregate not supported in L2E
        'Using context As New AdventureWorksEntities
        'Dim contacts As ObjectSet(Of Contact) = context.Contacts

        'Dim nameList As String = contacts.Take(5) _
        '.Select(Function(cont) cont.LastName).AsEnumerable() _
        '.Aggregate(Function(workingList, nxt) _
        '              workingList & "," & nxt)

        'Console.WriteLine(nameList)
        'End Using
        '
    End Sub

    Sub Average_MQ()
        ' <SnippetAverage_MQ>
        Using context As New AdventureWorksEntities
            Dim products As ObjectSet(Of Product) = context.Products

            Dim averageListPrice As Decimal = _
                products.Average(Function(prod) prod.ListPrice)

            Console.WriteLine("The average list price of all the products is ${0}", _
                    averageListPrice)
        End Using
        ' </SnippetAverage_MQ>
    End Sub

    Sub Average2_MQ()
        ' <SnippetAverage2_MQ>
        Using context As New AdventureWorksEntities
            Dim products As ObjectSet(Of Product) = context.Products

            Dim query = _
                From prod In products _
                Let styl = prod.Style _
                Group prod By styl Into g = Group _
                Select New With _
                { _
                    .Style = styl, _
                    .AverageListPrice = g.Average(Function(p) p.ListPrice) _
                }

            For Each prod In query
                Console.WriteLine("Product style: {0} Average list price: {1}", _
                    prod.Style, prod.AverageListPrice)
            Next
        End Using
        ' </SnippetAverage2_MQ>
    End Sub

    Sub Count()
        ' <SnippetCount>
        Using context As New AdventureWorksEntities
            Dim products As ObjectSet(Of Product) = context.Products

            Dim numProducts As Integer = products.Count()

            Console.WriteLine("There are {0} products.", numProducts)
        End Using
        ' </SnippetCount>
    End Sub

    Sub CountNested()
        ' <SnippetCountNested>
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts

            Dim query = _
                From cont In contacts _
                Select New With _
                { _
                    .CustomerID = cont.ContactID, _
                    .OrderCount = cont.SalesOrderHeaders.Count() _
                 }

            For Each cont In query
                Console.WriteLine("CustomerID = {0}   OrderCount = {1}", _
                       cont.CustomerID, cont.OrderCount)
            Next
        End Using
        ' </SnippetCountNested>
    End Sub

    Sub CountGrouped()
        ' <SnippetCountGrouped>
        Using context As New AdventureWorksEntities
            Dim products As ObjectSet(Of Product) = context.Products

            Dim query = _
                From prod In products _
                Let pc = prod.Color _
                Group prod By pc Into g = Group _
                Select New With {.Color = pc, .ProductCount = g.Count()}

            For Each prod In query
                Console.WriteLine("Color = {0} " & vbTab & " ProductCount = {1}", _
                    prod.Color, prod.ProductCount)
            Next
        End Using
        ' </SnippetCountGrouped>
    End Sub

    Sub LongCountSimple()
        ' <SnippetLongCountSimple>
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts

            Dim numberOfContacts As Long = contacts.LongCount()

            Console.WriteLine("There are {0} Contacts", numberOfContacts)
        End Using
        ' </SnippetLongCountSimple>
    End Sub

    Sub SumProjection_MQ()
        ' <SnippetSumProjection_MQ>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderDetail) = context.SalesOrderDetails

            Dim totalOrderQty As Double = orders.Sum(Function(o) o.OrderQty)

            Console.WriteLine("There are a total of {0} OrderQty.", _
                totalOrderQty)
        End Using
        ' </SnippetSumProjection_MQ>
    End Sub

    Sub SumGrouped_MQ()
        ' <SnippetSumGrouped_MQ>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = _
                From ord In orders _
                Let contID = ord.Contact.ContactID _
                Group ord By contID Into g = Group _
                Select New With _
                { _
                    .Category = contID, _
                    .TotalDue = g.Sum(Function(o) o.TotalDue) _
                }

            For Each ord In query
                Console.WriteLine("ContactID = {0} " & vbTab & _
                    " TotalDue sum = {1}", ord.Category, ord.TotalDue)
            Next
        End Using
        ' </SnippetSumGrouped_MQ>
    End Sub

    Sub MinProjection_MQ()
        ' <SnippetMinProjection_MQ>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim smallestTotalDue As Decimal = _
                orders.Min(Function(totDue) totDue.TotalDue)

            Console.WriteLine("The smallest TotalDue is {0}.", _
                smallestTotalDue)
        End Using
        ' </SnippetMinProjection_MQ>
    End Sub

    Sub MinGrouped_MQ()
        ' <SnippetMinGrouped_MQ>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = _
                From ord In orders _
                Let contID = ord.Contact.ContactID _
                Group ord By contID Into g = Group _
                Select New With _
                { _
                    .Category = contID, _
                    .smallestTotalDue = _
                        g.Min(Function(o) o.TotalDue) _
                 }

            For Each ord In query
                Console.WriteLine("ContactID = {0} " & vbTab & _
                    " Minimum TotalDue = {1}", ord.Category, ord.smallestTotalDue)
            Next
        End Using
        ' </SnippetMinGrouped_MQ>
    End Sub

    Sub MinElements_MQ()
        ' <SnippetMinElements_MQ>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = _
                From ord In orders _
                Let contID = ord.Contact.ContactID _
                Group ord By contID Into g = Group _
                Let minTotalDue = g.Min(Function(o) o.TotalDue) _
                Select New With _
                { _
                    .Category = contID, _
                    .smallestTotalDue = _
                        g.Where(Function(o) o.TotalDue = minTotalDue) _
                 }

            For Each orderGroup In query
                Console.WriteLine("ContactID: {0}", orderGroup.Category)
                For Each ord In orderGroup.smallestTotalDue
                    Console.WriteLine("Minimum TotalDue {0} for SalesOrderID {1}: ", _
                        ord.TotalDue, ord.SalesOrderID)
                Next
                Console.Write(vbNewLine)
            Next
        End Using
        ' </SnippetMinElements_MQ>
    End Sub

    Sub AverageProjection_MQ()
        ' <SnippetAverageProjection_MQ>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim averageTotalDue As Decimal = _
                orders.Average(Function(ord) ord.TotalDue)

            Console.WriteLine("The average TotalDue is {0}.", averageTotalDue)
        End Using
        ' </SnippetAverageProjection_MQ>
    End Sub

    Sub AverageGrouped_MQ()
        ' <SnippetAverageGrouped_MQ>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = _
                From ord In orders _
                Let contID = ord.Contact.ContactID _
                Group ord By contID Into g = Group _
                Select New With _
                { _
                    .Category = contID, _
                    .averageTotalDue = _
                        g.Average(Function(ord) ord.TotalDue) _
                 }

            For Each ord In query
                Console.WriteLine("ContactID = {0} " & vbTab & _
                    " Average TotalDue = {1}", _
                    ord.Category, ord.averageTotalDue)
            Next
        End Using
        ' </SnippetAverageGrouped_MQ>
    End Sub

    Sub AverageElements_MQ()
        ' <SnippetAverageElements_MQ>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = _
                From ord In orders _
                Let contID = ord.Contact.ContactID _
                Group ord By contID Into g = Group _
                Let averageTotalDue = g.Average(Function(ord) ord.TotalDue) _
                Select New With _
                { _
                    .Category = contID, _
                    .CheapestProducts = _
                        g.Where(Function(ord) ord.TotalDue = averageTotalDue) _
                 }

            For Each orderGroup In query
                Console.WriteLine("ContactID: {0}", orderGroup.Category)
                For Each ord In orderGroup.CheapestProducts
                    Console.WriteLine("Average total due for SalesOrderID {1} is: {0}", _
                        ord.TotalDue, ord.SalesOrderID)
                Next
                Console.Write(vbNewLine)
            Next
        End Using
        ' </SnippetAverageElements_MQ>
    End Sub

    Sub MaxProjection_MQ()
        ' <SnippetMaxProjection_MQ>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim maxTotalDue As Decimal = _
                orders.Max(Function(ord) ord.TotalDue)

            Console.WriteLine("The maximum TotalDue is {0}.", maxTotalDue)
        End Using
        ' </SnippetMaxProjection_MQ>
    End Sub

    Sub MaxGrouped_MQ()
        ' <SnippetMaxGrouped_MQ>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = _
                From ord In orders _
                Let contID = ord.Contact.ContactID _
                Group ord By contID Into g = Group _
                Select New With _
                { _
                    .Category = contID, _
                    .MaxTotalDue = _
                        g.Max(Function(ord) ord.TotalDue) _
                 }

            For Each ord In query
                Console.WriteLine("ContactID = {0} " & vbTab & _
                    " Maximum TotalDue = {1}", _
                    ord.Category, ord.MaxTotalDue)
            Next
        End Using
        ' </SnippetMaxGrouped_MQ>
    End Sub

    Sub MaxElements_MQ()
        ' <SnippetMaxElements_MQ>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = _
                From ord In orders _
                Let contID = ord.Contact.ContactID _
                Group ord By contID Into g = Group _
                Let maxTotalDue = g.Max(Function(ord) ord.TotalDue) _
                Select New With _
                { _
                    .Category = contID, _
                    .CheapestProducts = _
                        g.Where(Function(ord) ord.TotalDue = maxTotalDue) _
                 }

            For Each orderGroup In query
                Console.WriteLine("ContactID: {0}", orderGroup.Category)
                For Each ord In orderGroup.CheapestProducts
                    Console.WriteLine("MaxTotalDue {0} for SalesOrderID {1}: ", _
                        ord.TotalDue, ord.SalesOrderID)
                Next
                Console.Write(vbNewLine)
            Next
        End Using
        ' </SnippetMaxElements_MQ>
    End Sub

#End Region  '"Aggregate Operators"

#Region "Join Operators"

    Sub Join()
        ' <SnippetJoin>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders
            Dim details As ObjectSet(Of SalesOrderDetail) = context.SalesOrderDetails

            Dim query = _
                From ord In orders _
                Join det In details _
                On ord.SalesOrderID Equals det.SalesOrderID _
                Where ord.OnlineOrderFlag = True _
                        And ord.OrderDate.Month = 8 _
                Select New With _
                { _
                    .SalesOrderID = ord.SalesOrderID, _
                    .SalesOrderDetailID = det.SalesOrderDetailID, _
                    .OrderDate = ord.OrderDate, _
                    .ProductID = det.ProductID _
                }

            For Each ord In query
                Console.WriteLine("{0}" & vbTab & "{1}" & vbTab & "{2:d}" & vbTab & "{3}", _
                    ord.SalesOrderID, _
                    ord.SalesOrderDetailID, _
                    ord.OrderDate, _
                    ord.ProductID)
            Next
        End Using
        '</SnippetJoin>
    End Sub

    Sub JoinSimple_MQ()
        ' <SnippetJoinSimple_MQ>
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = _
                contacts.Join( _
                    orders, _
                    Function(ord) ord.ContactID, _
                    Function(cont) cont.Contact.ContactID, _
                    Function(cont, ord) New With _
                        { _
                            .ContactID = cont.ContactID, _
                            .SalesOrderID = ord.SalesOrderID, _
                            .FirstName = cont.FirstName, _
                            .Lastname = cont.LastName, _
                            .TotalDue = ord.TotalDue _
                        })

            For Each contact_order In query
                Console.WriteLine("ContactID: {0} " _
                    & "SalesOrderID: {1} " & "FirstName: {2} " _
                    & "Lastname: {3} " & "TotalDue: {4}", _
                    contact_order.ContactID, _
                    contact_order.SalesOrderID, _
                    contact_order.FirstName, _
                    contact_order.Lastname, _
                    contact_order.TotalDue)
            Next
        End Using
        '</SnippetJoinSimple_MQ>
    End Sub

    Sub JoinWithGroupedResults_MQ()
        ' <SnippetJoinWithGroupedResults_MQ>
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = _
                contacts.Join( _
                    orders, _
                    Function(ord) ord.ContactID, _
                    Function(cont) cont.Contact.ContactID, _
                    Function(cont, ord) New With _
                        { _
                            .ContactID = cont.ContactID, _
                            .SalesOrderID = ord.SalesOrderID, _
                            .FirstName = cont.FirstName, _
                            .Lastname = cont.LastName, _
                            .TotalDue = ord.TotalDue _
                        }) _
                        .GroupBy(Function(record) record.ContactID)

            For Each group In query
                For Each contact_order In group
                    Console.WriteLine("ContactID: {0} " _
                        & "SalesOrderID: {1} " & "FirstName: {2} " _
                        & "Lastname: {3} " & "TotalDue: {4}", _
                        contact_order.ContactID, _
                        contact_order.SalesOrderID, _
                        contact_order.FirstName, _
                        contact_order.Lastname, _
                        contact_order.TotalDue)
                Next
            Next
        End Using
        '</SnippetJoinWithGroupedResults_MQ>
    End Sub

    Sub GroupJoin()
        ' <SnippetGroupJoin>
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = _
                From contact In contacts _
                Group Join order In orders _
                On contact.ContactID _
                Equals order.Contact.ContactID Into contactGroup = Group _
                Select New With { _
                    .ContactID = contact.ContactID, _
                    .OrderCount = contactGroup.Count(), _
                    .Orders = contactGroup.Select(Function(order) order)}

            For Each group In query
                Console.WriteLine("ContactID: {0}", group.ContactID)
                Console.WriteLine("Order count: {0}", group.OrderCount)

                For Each orderInfo In group.Orders
                    Console.WriteLine("   Sale ID: {0}", orderInfo.SalesOrderID)
                Next

                Console.WriteLine("")
            Next
        End Using
        '</SnippetGroupJoin>
    End Sub

    Sub GroupJoin_MQ()
        ' <SnippetGroupJoin_MQ>
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim query = contacts.GroupJoin(orders, _
                    Function(contact) contact.ContactID, _
                    Function(order) order.Contact.ContactID, _
                    Function(contact, contactGroup) New With _
                    { _
                        .ContactID = contact.ContactID, _
                        .OrderCount = contactGroup.Count(), _
                        .orders = contactGroup.Select(Function(order) order) _
                    })

            For Each group In query
                Console.WriteLine("ContactID: {0}", group.ContactID)
                Console.WriteLine("Order count: {0}", group.OrderCount)

                For Each orderInfo In group.orders
                    Console.WriteLine("   Sale ID: {0}", orderInfo.SalesOrderID)
                Next

                Console.WriteLine("")
            Next
        End Using
        ' </SnippetGroupJoin_MQ>
    End Sub

    Sub GroupJoin2()
        ' <SnippetGroupJoin2>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders
            Dim details As ObjectSet(Of SalesOrderDetail) = context.SalesOrderDetails

            Dim query = _
                From order In orders _
                Group Join detail In details _
                On order.SalesOrderID _
                Equals detail.SalesOrderID Into orderGroup = Group _
                Select New With _
                { _
                    .CustomerID = order.SalesOrderID, _
                    .OrderCount = orderGroup.Count() _
                }

            For Each order In query
                Console.WriteLine("CustomerID: {0}  Orders Count: {1}", _
                    order.CustomerID, order.OrderCount)
            Next
        End Using
        '</SnippetGroupJoin2>
    End Sub

    Sub GroupJoin2_MQ()
        ' <SnippetGroupJoin2_MQ>
        Using context As New AdventureWorksEntities
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders
            Dim details As ObjectSet(Of SalesOrderDetail) = context.SalesOrderDetails

            Dim query = orders.GroupJoin(details, _
                    Function(order) order.SalesOrderID, _
                    Function(detail) detail.SalesOrderID, _
                    Function(order, orderGroup) New With _
                    { _
                        .CustomerID = order.SalesOrderID, _
                        .OrderCount = orderGroup.Count() _
                    })

            For Each order In query
                Console.WriteLine("CustomerID: {0}  Orders Count: {1}", _
                    order.CustomerID, order.OrderCount)
            Next

        End Using
        ' </SnippetGroupJoin2_MQ>
    End Sub

#End Region  '"Join Operators"

#Region "Relationship Navigation"
    Sub SelectEachContactsOrders_MQ()
        '<SnippetSelectEachContactsOrders_MQ>
        Dim lastName = "Zhou"
        Using context As New AdventureWorksEntities
            Dim ordersQuery = context.Contacts _
            .Where(Function(c) c.LastName = lastName) _
            .SelectMany(Function(o) o.SalesOrderHeaders)

            For Each order In ordersQuery
                Console.WriteLine("Order ID: {0}, Order date: {1}, Total Due: {2}", _
                        order.SalesOrderID, order.OrderDate, order.TotalDue)
            Next
        End Using
        '</SnippetSelectEachContactsOrders_MQ>
    End Sub
    Sub SelectEachContactsOrders2()
        '<SnippetSelectEachContactsOrders2>
        Dim lastName = "Zhou"
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts

            Dim ordersQuery = From contact In contacts _
                              Where contact.LastName = lastName _
                              Select New With _
                                      {.ContactID = contact.ContactID, _
                                      .Total = contact.SalesOrderHeaders.Sum(Function(o) o.TotalDue)}

            For Each order In ordersQuery
                Console.WriteLine("Contact ID: {0} Orders total: {1}", order.ContactID, order.Total)
            Next
        End Using
        '</SnippetSelectEachContactsOrders2>

    End Sub

    Sub SelectEachContactsOrders2_MQ()
        '<SnippetSelectEachContactsOrders2_MQ>
        Dim lastName = "Zhou"
        Using context As New AdventureWorksEntities
            Dim ordersQuery = context.Contacts _
            .Where(Function(c) c.LastName = lastName) _
            .Select(Function(c) New With _
                        {.ContactID = c.ContactID, _
                        .Total = c.SalesOrderHeaders.Sum(Function(o) o.TotalDue)})

            For Each order In ordersQuery
                Console.WriteLine("Contact ID: {0} Orders total: {1}", order.ContactID, order.Total)
            Next
        End Using
        '</SnippetSelectEachContactsOrders2_MQ>

    End Sub

    Sub SelectEachContactsOrders3()
        '<SnippetSelectEachContactsOrders3>
        Dim lastName = "Zhou"
        Using context As New AdventureWorksEntities
            Dim contacts As ObjectSet(Of Contact) = context.Contacts

            Dim ordersQuery = From contact In contacts _
                              Where contact.LastName = lastName _
                              Select New With _
                                      {.LastName = contact.LastName, _
                                       .Orders = contact.SalesOrderHeaders}

            For Each order In ordersQuery
                Console.WriteLine("Name: {0}", order.LastName)
                For Each orderInfo In order.Orders

                    Console.WriteLine("Order ID: {0}, Order date: {1}, Total Due: {2}", _
                            orderInfo.SalesOrderID, orderInfo.OrderDate, orderInfo.TotalDue)
                Next

                Console.WriteLine("")
            Next
        End Using
        '</SnippetSelectEachContactsOrders3>
    End Sub

    Sub SelectEachContactsOrders3_MQ()
        '<SnippetSelectEachContactsOrders3_MQ>
        Dim lastName = "Zhou"
        Using context As New AdventureWorksEntities
            Dim ordersQuery = context.Contacts _
            .Where(Function(c) c.LastName = lastName) _
            .Select(Function(o) New With _
                        {.LastName = o.LastName, _
                         .Orders = o.SalesOrderHeaders})

            For Each order In ordersQuery
                Console.WriteLine("Name: {0}", order.LastName)
                For Each orderInfo In order.Orders

                    Console.WriteLine("Order ID: {0}, Order date: {1}, Total Due: {2}", _
                            orderInfo.SalesOrderID, orderInfo.OrderDate, orderInfo.TotalDue)
                Next

                Console.WriteLine("")
            Next
        End Using
        '</SnippetSelectEachContactsOrders3_MQ>
    End Sub

    Sub GetOrderInfoThruRelationships()
        '<SnippetGetOrderInfoThruRelationships>
        Dim city = "Seattle"
        Using context As New AdventureWorksEntities

            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim ordersQuery = From order In orders _
                              Where order.Address.City = city _
                              Select New With { _
                                             .ContactLastName = order.Contact.LastName, _
                                             .ContactFirstName = order.Contact.FirstName, _
                                             .StreetAddress = order.Address.AddressLine1, _
                                             .OrderNumber = order.SalesOrderNumber, _
                                             .TotalDue = order.TotalDue}

            For Each orderInfo In ordersQuery
                Console.WriteLine("Name: {0}, {1}", orderInfo.ContactLastName, orderInfo.ContactFirstName)
                Console.WriteLine("Street address: {0}", orderInfo.StreetAddress)
                Console.WriteLine("Order number: {0}", orderInfo.OrderNumber)
                Console.WriteLine("Total Due: {0}", orderInfo.TotalDue)
                Console.WriteLine("")
            Next

        End Using
        '</SnippetGetOrderInfoThruRelationships>
    End Sub

    Sub GetOrderInfoThruRelationships_MQ()
        '<SnippetGetOrderInfoThruRelationships_MQ>
        Dim city = "Seattle"
        Using context As New AdventureWorksEntities
            Dim ordersQuery = context.SalesOrderHeaders _
                     .Where(Function(o) o.Address.City = city) _
                     .Select(Function(o) New With { _
                                    .ContactLastName = o.Contact.LastName, _
                                    .ContactFirstName = o.Contact.FirstName, _
                                    .StreetAddress = o.Address.AddressLine1, _
                                    .OrderNumber = o.SalesOrderNumber, _
                                    .TotalDue = o.TotalDue _
                     })

            For Each orderInfo In ordersQuery
                Console.WriteLine("Name: {0}, {1}", orderInfo.ContactLastName, orderInfo.ContactFirstName)
                Console.WriteLine("Street address: {0}", orderInfo.StreetAddress)
                Console.WriteLine("Order number: {0}", orderInfo.OrderNumber)
                Console.WriteLine("Total Due: {0}", orderInfo.TotalDue)
                Console.WriteLine("")
            Next

        End Using
        '</SnippetGetOrderInfoThruRelationships_MQ>
    End Sub

#End Region

End Module
