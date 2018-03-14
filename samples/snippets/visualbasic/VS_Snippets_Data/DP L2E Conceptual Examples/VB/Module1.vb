Option Explicit On
Option Compare Text

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.Objects
Imports System.Data


Module Module1

    Sub Main()
        JoinOnNull()
        '*** Misc ***
        'UIntAsQueryParam()
        'UIntAsQueryParam_MQ()
        'SBUDT496552A()
        'SBUDT496552B()
        'SBUDT544351()
        ' EndsWithComparison()
        'SBUDT544355() ' No C# equivalent
        'SBUDT543840()
        'SBUDT543574()
        'SBUDT555877()

        '*** How to topics ***'
        ' QueryReturnsPrimitiveValue()
        'DistinctHowTo()
        'VBWalkthrough()

        '*** Expression examples. ***'
        'ConstantExpression()
        'RestrictionExpression()
        'RestrictionExpression_MQ()
        'DateTimeComparison()
        'DateTimeComparison_MQ()
        'PropertyAsConstant()
        'MethodAsConstantFails()
        ' NullComparison() ' Needs work
        ' CastResultsIsNull() ' Needs work
        'JoinOnNull()
        'AnonymousTypeInitialization()
        ' AnonymousTypeInitialization_MQ()
        ' TypeInitialization()
        ' TypeInitialization_MQ()
        ' NavProperty_MQ()
        'NavPropLoadError()
        'WhereExpression()
        'LiteralParameter1()
        'Dim orderID As Integer = 51987
        'MethodParameterExample(orderID)
        'NullCastToString()
        'CastToNullable()
        'ConstructorForLiteral()
        'CanonicalFuncVsCLRBaseType()

        '*** Query examples ***'
        'Query1()
        ' Query1_MQ()
        ' MethodQuery()
        'QueryExpression()
        ' composing1()
        'composing2()

        '*** Query results examples ***'
        ' QueryResults1()

        '*** Canonical Function Mapping***'
        'FunctionMapping()

        '*** Compiled Query examples ***
        'CompiledQuery1_MQ()
        'CompiledQuery2()
        'CompiledQuery2_MQ()
        'CompiledQuery3_MQ()
        'CompiledQuery4_MQ()
        'CompiledQuery5()
        'CompiledQuery6()
        '   CompiledQuery7()

        Console.WriteLine("Press a key...")
        Console.ReadKey()

    End Sub

#Region "Expression Examples"

    Sub ConstantExpression()
        ' <SnippetConstantExpression>
        Dim totalDue = 200 + 3
        Using context As New AdventureWorksEntities()
            Dim salesInfo = _
                From s In context.SalesOrderHeaders _
                Where s.TotalDue >= totalDue _
                Select s.SalesOrderNumber

            Console.WriteLine("Sales order numbers:")
            For Each orderNum As String In salesInfo
                Console.WriteLine(orderNum)
            Next
        End Using
        ' </SnippetConstantExpression>
    End Sub

    Sub RestrictionExpression()
        ' <SnippetRestrictionExpression>
        Dim salesOrderNumber = "SO43663"
        Using context As New AdventureWorksEntities()
            Dim salesInfo = _
                From s In context.SalesOrderHeaders _
                Where s.SalesOrderNumber = salesOrderNumber _
                Select s

            Console.WriteLine("Sales info-")
            For Each sale As SalesOrderHeader In salesInfo
                Console.WriteLine("Sales ID: " & sale.SalesOrderID)
                Console.WriteLine("Ship date: " & sale.ShipDate)
            Next
        End Using
        ' </SnippetRestrictionExpression>
    End Sub

    Sub RestrictionExpression_MQ()
        ' <SnippetRestrictionExpression_MQ>
        Dim salesOrderNumber = "SO43663"
        Using context As New AdventureWorksEntities()
            Dim salesInfo = _
                context.SalesOrderHeaders _
                    .Where(Function(s) s.SalesOrderNumber = salesOrderNumber) _
                    .Select(Function(s) s)

            Console.WriteLine("Sales info-")
            For Each sale As SalesOrderHeader In salesInfo
                Console.WriteLine("Sales ID: " & sale.SalesOrderID)
                Console.WriteLine("Ship date: " & sale.ShipDate)
            Next
        End Using
        ' </SnippetRestrictionExpression_MQ>
    End Sub

    Sub DateTimeComparison()
        ' <SnippetDateTimeComparison>
        Using context As New AdventureWorksEntities()
            Dim dt As DateTime = New DateTime(2001, 7, 8)
            Dim salesInfo = _
                From s In context.SalesOrderHeaders _
                Where s.ShipDate = dt _
                Select s

            Console.WriteLine("Orders shipped on August 7, 2001:")
            For Each sale As SalesOrderHeader In salesInfo
                Console.WriteLine("Sales ID: " & sale.SalesOrderID)
                Console.WriteLine("Total due: " & sale.TotalDue)
                Console.WriteLine()
            Next
        End Using
        ' </SnippetDateTimeComparison>
    End Sub

    Sub DateTimeComparison_MQ()
        ' <SnippetDateTimeComparison_MQ>
        Using context As New AdventureWorksEntities()
            Dim dt As DateTime = New DateTime(2001, 7, 8)

            Dim salesInfo = _
                context.SalesOrderHeaders _
                .Where(Function(s) s.ShipDate = dt) _
                .Select(Function(s) s)

            Console.WriteLine("Orders shipped on August 7, 2001:")
            For Each sale As SalesOrderHeader In salesInfo
                Console.WriteLine("Sales ID: " & sale.SalesOrderID)
                Console.WriteLine("Total due: " & sale.TotalDue)
                Console.WriteLine()
            Next
        End Using
        ' </SnippetDateTimeComparison_MQ>
    End Sub

    ' <SnippetMyClass>
    Class AClass
        Public ID As Integer
    End Class
    ' </SnippetMyClass>

    Sub PropertyAsConstant()
        ' <SnippetPropertyAsConstant> 
        Using context As New AdventureWorksEntities()
            Dim aClass As AClass = New aClass()
            aClass.ID = 43663

            Dim salesInfo = _
                From s In context.SalesOrderHeaders _
                Where s.SalesOrderID = aClass.ID _
                Select s

            Console.WriteLine("Order info-")
            For Each sale As SalesOrderHeader In salesInfo
                Console.WriteLine("Sales order number: " & sale.SalesOrderNumber)
                Console.WriteLine("Total due: " & sale.TotalDue)
                Console.WriteLine()
            Next
        End Using
        ' </SnippetPropertyAsConstant> 
    End Sub

    ' <SnippetMyClass2>
    Class AClass2
        Public Function returnInt() As Integer
            Return 5
        End Function
    End Class
    ' </SnippetMyClass2>

    Sub MethodAsConstantFails()
        ' <SnippetMethodAsConstantFails>   
        Using context As New AdventureWorksEntities()
            Dim aClass2 As AClass2 = New aClass2()

            ' Throws a NotSupportedException.
            Dim salesInfo = _
                From s In context.SalesOrderHeaders _
                Where s.SalesOrderID = aClass2.returnInt() _
                Select s

            Console.WriteLine("Order info-")
            Try
                For Each sale As SalesOrderHeader In salesInfo
                    Console.WriteLine("Sales order number: " & sale.SalesOrderNumber)
                    Console.WriteLine("Total due: " & sale.TotalDue)
                    Console.WriteLine()
                Next
            Catch ex As NotSupportedException
                Console.WriteLine("Exception: {0}", ex.Message)
            End Try
        End Using
        ' </SnippetMethodAsConstantFails>   
    End Sub

    Sub NullComparison()
        ' <SnippetNullComparison>
        Using context As New AdventureWorksEntities()
            Dim sales As ObjectQuery(Of SalesOrderHeader) = context.SalesOrderHeaders

            'Throws a NotSupportedException
            'Dim orders = _
            '    From c In edm.Customers _
            '    Join c2 In edm.Orders _
            '    On c.Region Equals c2.ShipRegion _
            '    Where c.Region Is Nothing _
            '    Select c.CustomerID

            'Console.WriteLine("Order info-")
            'For Each sale As SalesOrderHeader In salesInfo
            '    Console.WriteLine("Sales order number: " & sale.SalesOrderNumber)
            '    Console.WriteLine("Total due: " & sale.TotalDue)
            '    Console.WriteLine()
            'Next
        End Using
        ' </SnippetNullComparison>
    End Sub

    Class NewProduct : Inherits Product
        Public Introduced As DateTime
    End Class

    Sub CastResultsIsNull()
        ' <SnippetCastResultsIsNull>
        Using context As New AdventureWorksEntities()
            Dim dt As DateTime = New DateTime()
            Dim query = context.Products _
                .Where(Function(p) _
                    ((DirectCast(p, NewProduct)).Introduced > dt)) _
                .Select(Function(x) x)
        End Using
        ' </SnippetCastResultsIsNull>
    End Sub

    Sub JoinOnNull()
        'Select h.SalesOrderID
        'FROM Sales.SalesOrderHeader h
        'JOIN Sales.SalesOrderDetail o ON o.SalesOrderID = h.SalesOrderID
        'WHERE h.ShipDate IS Null

        ' <SnippetJoinOnNull>
        Using context As New AdventureWorksEntities()

            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders
            Dim details As ObjectSet(Of SalesOrderDetail) = context.SalesOrderDetails

            Dim query = _
                From order In orders _
                Join detail In details _
                On order.SalesOrderID _
                Equals detail.SalesOrderID _
                Where order.ShipDate = Nothing
                Select order.SalesOrderID


            For Each orderID In query
                Console.WriteLine("OrderID: {0} ", orderID)
            Next
        End Using
        ' </SnippetJoinOnNull>
    End Sub

    Sub AnonymousTypeInitialization()
        ' <SnippetAnonymousTypeInitialization>
        Dim totalDue = 200
        Using context As New AdventureWorksEntities()
            Dim salesInfo = _
                From s In context.SalesOrderHeaders _
                Where s.TotalDue >= totalDue _
                Select New With {s.SalesOrderNumber, s.TotalDue}

            Console.WriteLine("Sales order numbers:")
            For Each sale In salesInfo
                Console.WriteLine("Order number: " & sale.SalesOrderNumber)
                Console.WriteLine("Total due: " & sale.TotalDue)
                Console.WriteLine("")
            Next
        End Using
        ' </SnippetAnonymousTypeInitialization>
    End Sub


    Sub AnonymousTypeInitialization_MQ()
        ' <SnippetAnonymousTypeInitialization_MQ>
        Dim totalDue = 200
        Using context As New AdventureWorksEntities()

            Dim salesInfo = _
                context.SalesOrderHeaders _
                .Where(Function(s) s.TotalDue >= totalDue) _
                .Select(Function(s) New With {s.SalesOrderNumber, s.TotalDue})

            Console.WriteLine("Sales order numbers:")
            For Each sale In salesInfo
                Console.WriteLine("Order number: " & sale.SalesOrderNumber)
                Console.WriteLine("Total due: " & sale.TotalDue)
                Console.WriteLine("")
            Next
        End Using
        ' </SnippetAnonymousTypeInitialization_MQ>
    End Sub
    '<SnippetMyOrder>
    Class MyOrder
        Public SalesOrderNumber As String
        Public ShipDate As DateTime?
    End Class
    '</SnippetMyOrder>

    Sub TypeInitialization()
        ' <SnippetTypeInitialization>
        Dim totalDue = 200
        Using context As New AdventureWorksEntities()
            Dim salesInfo = _
                From s In context.SalesOrderHeaders _
                Where s.TotalDue >= totalDue _
                Select New MyOrder With _
                       { _
                           .SalesOrderNumber = s.SalesOrderNumber, _
                           .ShipDate = s.ShipDate _
                       }

            Console.WriteLine("Sales order info:")
            For Each order As MyOrder In salesInfo
                Console.WriteLine("Order number: " & order.SalesOrderNumber)
                Console.WriteLine("Ship date: " & order.ShipDate)
                Console.WriteLine("")
            Next
        End Using
        ' </SnippetTypeInitialization>
    End Sub

    Sub TypeInitialization_MQ()
        ' <SnippetTypeInitialization_MQ>
        Dim totalDue = 200
        Using context As New AdventureWorksEntities()

            Dim salesInfo As IQueryable(Of MyOrder) = _
                context.SalesOrderHeaders _
                .Where(Function(s) s.TotalDue >= totalDue) _
                .Select(Function(s) New MyOrder With _
                       { _
                           .SalesOrderNumber = s.SalesOrderNumber, _
                           .ShipDate = s.ShipDate _
                       })

            Console.WriteLine("Sales order info:")
            For Each order As MyOrder In salesInfo
                Console.WriteLine("Order number: " & order.SalesOrderNumber)
                Console.WriteLine("Ship date: " & order.ShipDate)
                Console.WriteLine("")
            Next
        End Using
        ' </SnippetTypeInitialization_MQ>
    End Sub

    Sub NavProperty_MQ()
        ' <SnippetNavProperty_MQ>
        Using context As New AdventureWorksEntities()

            Dim contactOrders = _
                context.Contacts _
                .Select(Function(c) New With _
                { _
                    .ContactID = c.ContactID, _
                    .Orders = c.SalesOrderHeaders _
                })

            Console.WriteLine("Orders by contact:")
            For Each contactOrder In contactOrders
                Console.WriteLine("Contact ID: " & contactOrder.ContactID)

                For Each order As SalesOrderHeader In contactOrder.Orders
                    Console.WriteLine("   Order ID: " & order.SalesOrderID)
                    Console.WriteLine("   Total due: " & order.TotalDue)
                Next

                Console.WriteLine("")
            Next
        End Using
        ' </SnippetNavProperty_MQ>
    End Sub

    Sub NavPropLoadError()
        ' <SnippetNavPropLoadError>
        Dim lastName = "Johnson"
        Using context As New AdventureWorksEntities()
            Dim contacts = _
                context.Contacts _
                .Where(Function(c) c.LastName = lastName) _
                .Select(Function(c) c)

            Try
                For Each contact As Contact In contacts

                    Console.WriteLine("Name: {0}, {1}", contact.LastName, contact.FirstName)

                    ' Throws a EntityCommandExecutionException if 
                    ' MultipleActiveResultSets is set to False in the 
                    ' connection string.
                    contact.SalesOrderHeaders.Load()

                    For Each order As SalesOrderHeader In contact.SalesOrderHeaders
                        Console.WriteLine("Order ID: {0}", order.SalesOrderID)
                    Next

                Next
            Catch ex As EntityCommandExecutionException

                Console.WriteLine(ex.InnerException)
            End Try
        End Using
        ' </SnippetNavPropLoadError>
    End Sub

    Sub WhereExpression()
        ' <SnippetWhereExpression>
        Dim totalDue = 200
        Using context As New AdventureWorksEntities()
            Dim salesInfo = _
                From s In context.SalesOrderHeaders _
                Where s.TotalDue >= totalDue _
                Select s.SalesOrderID

            Console.WriteLine("Sales order info:")
            For Each orderNumber As Integer In salesInfo
                Console.WriteLine("Order number: " & orderNumber)
            Next
        End Using
        ' </SnippetWhereExpression>
    End Sub

    Sub LiteralParameter1()

        Using context As New AdventureWorksEntities()

            ' <SnippetLiteralParameter1>
            Dim orderID As Integer = 51987

            Dim salesInfo = _
                From s In context.SalesOrderHeaders _
                Where s.SalesOrderID = orderID _
                Select s

            ' </SnippetLiteralParameter1>

            Console.WriteLine("Sales order info:")
            For Each sale As SalesOrderHeader In salesInfo
                Console.WriteLine(sale.SalesOrderID)
            Next
        End Using
    End Sub
    ' <SnippetMethodParameterExample>
    Function MethodParameterExample(ByVal orderID As Integer)
        Using context As New AdventureWorksEntities()

            Dim salesInfo = _
                From s In context.SalesOrderHeaders _
                Where s.SalesOrderID = orderID _
                Select s

            Console.WriteLine("Sales order info:")
            For Each sale As SalesOrderHeader In salesInfo
                Console.WriteLine("OrderID: {0}, Total due: {1}", sale.SalesOrderID, sale.TotalDue)
            Next
        End Using

    End Function
    ' </SnippetMethodParameterExample>

    Sub NullCastToString()
        Using context As New AdventureWorksEntities()
            '<SnippetNullCastToString>
            Dim query = _
                From c In context.Contacts _
                Where c.EmailAddress = CType(Nothing, String) _
                Select c
            '</SnippetNullCastToString>
            For Each Contact As Contact In query
                Console.WriteLine("Name: {0}", Contact.LastName)
            Next
        End Using
    End Sub

    Sub CastToNullable()

        Using context As New AdventureWorksEntities()
            '<SnippetCastToNullable>
            Dim weight = CType(23.77, Decimal?)
            Dim query = _
                From product In context.Products _
                    Where product.Weight = weight _
                    Select product
            '</SnippetCastToNullable>
            For Each product As Product In query
                Console.WriteLine("Name: {0}", product.Name)
            Next
        End Using

    End Sub

    Sub ConstructorForLiteral()
        Using context As New AdventureWorksEntities()
            ' <SnippetConstructorForLiteral>
            Dim weight = New Decimal(23.77)
            Dim query = _
                From product In context.Products _
                Where product.Weight = weight _
                Select product
            ' </SnippetConstructorForLiteral>

            For Each product As Product In query
                Console.WriteLine("Name: {0}", product.Name)
            Next

        End Using
    End Sub

    Sub CanonicalFuncVsCLRBaseType()
        ' <SnippetCanonicalFuncVsCLRBaseType>
        Using context As New AdventureWorksEntities()

            Dim query = _
                From p In context.Products _
                Where p.Name = "Reflector" _
                Select p.Name

            Dim q = _
                query.Select(Function(c) c.EndsWith("Reflector "))

            Console.WriteLine("LINQ to Entities returns: " & q.First())
            Console.WriteLine("CLR returns: " & "Reflector".EndsWith("Reflector "))
        End Using
        ' </SnippetCanonicalFuncVsCLRBaseType>
    End Sub
#End Region

#Region "Query Examples"

    Sub Query1()
        ' <SnippetQuery1>
        Using context As New AdventureWorksEntities
            Dim productNames = _
               From p In context.Products _
               Select p

        End Using
        ' </SnippetQuery1>
    End Sub
    Sub Query1_MQ()
        ' <SnippetQuery1_MQ>
        Using context As New AdventureWorksEntities


            Dim productNames = context.Products.Select(Function(p) p.Name)

        End Using
        ' </SnippetQuery1_MQ>
    End Sub
    Sub QueryExpression()
        ' <SnippetQueryExpression>
        Using context As New AdventureWorksEntities
            Dim productNames = _
               From p In context.Products _
               Select p.Name

            Console.WriteLine("Product Names:")
            For Each productName In productNames
                Console.WriteLine(productName)
            Next
        End Using
        ' </SnippetQueryExpression>
    End Sub
    Sub MethodQuery()
        ' <SnippetMethodQuery>
        Using context As New AdventureWorksEntities


            Dim productNames = context.Products.Select(Function(p) p.Name)


            Console.WriteLine("Product Names:")
            For Each productName In productNames
                Console.WriteLine(productName)
            Next
        End Using
        ' </SnippetMethodQuery>
    End Sub
    Sub composing1()
        ' <SnippetComposing1>
        Using context As New AdventureWorksEntities()
            Dim productsQuery = _
                From p In context.Products _
                Select p

            Dim largeProducts = _
                productsQuery.Where(Function(p) p.Size = "L")

            Console.WriteLine("Products of size 'L':")
            For Each product In largeProducts
                Console.WriteLine(product.Name)
            Next
        End Using
        ' </SnippetComposing1>
    End Sub

    Sub composing2()
        ' <SnippetComposing2>
        Dim color = "Red"
        Using context As New AdventureWorksEntities()
            Dim productsQuery = _
                From p In context.Products _
                Select p

            Console.WriteLine("The list of products:")
            For Each Product As Product In productsQuery
                Console.WriteLine(Product.Name)
            Next

            Dim redProducts = productsQuery _
                .Where(Function(p) p.Color = color) _
                .Select(Function(p) p)

            Console.WriteLine("")
            Console.WriteLine("The list of red products:")
            For Each redProduct As Product In redProducts
                Console.WriteLine(redProduct.Name)
            Next
        End Using
        ' </SnippetComposing2>
    End Sub
#End Region

#Region "Query Results Examples"
    ' <SnippetQueryResults1>
    Public count As Integer = 0

    Public Class MyContact
        Private _lastName As String

        Public Property LastName() As String
            Get
                Return _lastName
            End Get
            Set(ByVal value As String)
                _lastName = value
                count += 1
            End Set
        End Property

    End Class


    Sub QueryResults1()
        Dim lastName = "Jones"
        Using context As New AdventureWorksEntities()
            Dim query1 = context _
                .Contacts _
                .Where(Function(c) c.LastName = lastName) _
                .Select(Function(c) New MyContact With {.LastName = c.LastName})

            ' Execute the first query and print the count.
            query1.ToList()
            Console.WriteLine("Count: " & count)

            ' Reset the count variable.
            count = 0

            Dim query2 = context _
                .Contacts _
                .Where(Function(c) c.LastName = lastName) _
                .Select(Function(c) New MyContact With {.LastName = c.LastName}) _
                .Select(Function(x) x.LastName)

            ' Execute the second query and print the count.
            query2.ToList()
            Console.WriteLine("Count: " & count)
        End Using
    End Sub
    ' </SnippetQueryResults1>
#End Region

#Region "Misc"


    Sub SBUDT544355()
        ' <SnippetSBUDT544355>
        Using context As New AdventureWorksEntities()
            Dim productsList = _
                From product In context.Products _
                Select CByte(product.MakeFlag)

            ' Throws an SqlException exception with a "Arithmetic overflow error 
            ' for data type tinyint" message when a value of 1 is iterated over.
            For Each makeFlag In productsList
                Console.WriteLine(makeFlag)
            Next
        End Using
        ' </SnippetSBUDT544355>
    End Sub

    Sub SBUDT544351()
        ' <SnippetSBUDT544351>
        Using context As New AdventureWorksEntities()

            ' In this query, the ordering is not preserved because Distinct
            ' is called after OrderByDescending.
            Dim productsList = _
            From product In context.Products _
            Order By product.Name Descending _
            Select product.Name _
            Distinct

            Console.WriteLine("The list of products:")
            For Each productName In productsList
                'Console.WriteLine(productName)
            Next

            ' In this query, the ordering is preserved because 
            ' OrderByDescending is called after Distinct.
            Dim productsList2 = _
            From product In context.Products _
            Select product.Name _
            Distinct _
            Order By Name Descending

            Console.WriteLine("The list of products:")
            For Each productName In productsList2
                Console.WriteLine(productName)
            Next

        End Using
        ' </SnippetSBUDT544351>
    End Sub

    Sub SBUDT496552B()
        ' <SnippetSBUDT496552B>
        Using context As New AdventureWorksEntities()
            Dim contacts = context.Contacts _
                    .OrderBy(Function(x) x.LastName) _
                    .Select(Function(x) x) _
                    .Select(Function(x) x.LastName)

            For Each contact In contacts
                Console.WriteLine(contact)
            Next
        End Using
        ' </SnippetSBUDT496552B>

    End Sub
    Sub SBUDT496552A()
        ' <SnippetSBUDT496552A>
        Dim firstName = "John"
        Using context As New AdventureWorksEntities()
            ' Return all contacts, ordered by last name. The OrderBy before
            ' the Where produces a nested query when translated to 
            ' canonical command trees and the ordering by last name is lost.
            Dim contacts = context.Contacts _
                    .OrderBy(Function(x) x.LastName) _
                    .Where(Function(x) x.FirstName = firstName) _
                    .Select(Function(x) x)

            For Each c In contacts
                Console.WriteLine(c.LastName & ", " & c.FirstName)
            Next

            ' Return all contacts, ordered by last name.
            Dim contacts2 = context.Contacts _
                    .Where(Function(x) x.FirstName = firstName) _
                    .OrderBy(Function(x) x.LastName) _
                    .Select(Function(x) x)

            For Each c In contacts2
                Console.WriteLine(c.LastName & ", " & c.FirstName)
            Next
        End Using
        ' </SnippetSBUDT496552A>
    End Sub

    Sub UIntAsQueryParam_MQ()
        ' <SnippetUIntAsQueryParam_MQ>
        Using context As New AdventureWorksEntities()
            Dim saleId As UInteger = UInt32.Parse("48000")

            Dim query = _
                context.SalesOrderDetails _
                .Where(Function(sale) sale.SalesOrderID = saleId) _
                .Select(Function(sale) sale)

            Try
                ' NotSupportedException exception is thrown here.
                For Each order As SalesOrderDetail In query
                    Console.WriteLine("SalesOrderID: " & order.SalesOrderID)
                Next
            Catch ex As NotSupportedException
                Console.WriteLine("Exception: " + ex.Message)
            End Try
        End Using
        ' </SnippetUIntAsQueryParam_MQ>
    End Sub

    Sub UIntAsQueryParam()
        ' <SnippetUIntAsQueryParam>
        Using context As New AdventureWorksEntities()
            Dim saleId As UInteger = UInt32.Parse("48000")

            Dim query = _
                From sale In context.SalesOrderDetails _
                Where sale.SalesOrderID = saleId _
                Select sale

            Try
                ' NotSupportedException exception is thrown here.
                For Each order As SalesOrderDetail In query
                    Console.WriteLine("SalesOrderID: " & order.SalesOrderID)
                Next
            Catch ex As NotSupportedException
                Console.WriteLine("Exception: " + ex.Message)
            End Try
        End Using
        ' </SnippetUIntAsQueryParam>
    End Sub

    Sub EndsWithComparison()
        ' <SnippetEndsWithComparison>
        Using context As New AdventureWorksEntities()
            Dim products = context.Products

            Dim query = _
                From p In products _
                Where p.Name = "Reflector" _
                Select p.Name

            Dim q As IEnumerable(Of Boolean) = _
                query.Select(Function(c) c.EndsWith("Reflector "))

            Console.WriteLine("LINQ to Entities returns: " & q.First())
            Console.WriteLine("CLR returns: " & "Reflector".EndsWith("Reflector "))
        End Using
        ' </SnippetEndsWithComparison>
    End Sub

    Sub SBUDT543840()
        ' <SnippetSBUDT543840>
        Using context As New AdventureWorksEntities()
            ' Ordering information is lost when executed against a SQL Server 2005
            ' database running with a compatibility level of "80".
            Dim results = context.Contacts.SelectMany(Function(c) c.SalesOrderHeaders) _
                .OrderBy(Function(c) c.SalesOrderDetails.Count) _
                .Select(Function(c) New With {c.SalesOrderDetails.Count})

            For Each result In results
                Console.WriteLine(result.Count)
            Next
        End Using
        ' </SnippetSBUDT543840>
    End Sub

    Sub SBUDT543574()
        '<SnippetSBUDT543574>
        Dim totalDue = 11.039
        Dim salesOrderID = 500
        Using context As New AdventureWorksEntities()
            ' The First() and FirstOrDefault() methods which take expressions
            ' as input parameters do not preserve order.
            Dim orders = context.SalesOrderHeaders _
                    .Where(Function(c) c.TotalDue = totalDue) _
                    .OrderByDescending(Function(c) c.SalesOrderID) _
                    .Select(Function(c) c)

            Console.WriteLine("The ordered results:")
            For Each order As SalesOrderHeader In orders
                Console.WriteLine("ID: {0}  Total due: {1}", order.SalesOrderID, order.TotalDue)
            Next

            Dim result As SalesOrderHeader = context.SalesOrderHeaders _
                    .Where(Function(c) c.TotalDue = totalDue) _
                    .OrderByDescending(Function(c) c.SalesOrderID) _
                    .First(Function(c) c.SalesOrderID > salesOrderID)

            Console.WriteLine("")
            Console.WriteLine("The result returned is not the first result from the ordered list.")
            Console.WriteLine("ID: {0}  Total due: {1}", result.SalesOrderID, result.TotalDue)
        End Using
        '</SnippetSBUDT543574>
    End Sub

    Sub SBUDT555877()
        ' <SnippetSBUDT555877>
        Using context As New AdventureWorksEntities()

            Dim contact As Contact = context.Contacts.FirstOrDefault()

            ' Referencing a non-scalar closure in a query will
            ' throw an exception when the query is executed.
            Dim contacts = From c In context.Contacts _
                           Where c.Equals(contact) _
                           Select c.LastName

            Try
                For Each name As String In contacts
                    Console.WriteLine("Name: ", name)
                Next

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

        End Using
        ' </SnippetSBUDT555877>

    End Sub
#End Region
#Region "How To topics"

    Sub QueryReturnsPrimitiveValue()
        '<SnippetQueryReturnsPrimitiveValue>
        Using context As New AdventureWorksEntities()
            Dim products = context.Products

            Dim productQuery = _
                From p In products _
                Select p.Name.Length

            For Each result In productQuery
                Console.WriteLine(result)
            Next
        End Using
        '</SnippetQueryReturnsPrimitiveValue>
    End Sub

    Sub DistinctHowTo()
        ' <SnippetDistinctHowTo>
        Using context As New AdventureWorksEntities()
            Dim contacts = context.Contacts

            Dim contactsQuery = _
                From c In contacts _
                Select c.LastName

            Dim distinctNames = contactsQuery.Distinct()

            For Each name In distinctNames
                Console.WriteLine("Name: " + name)
            Next
        End Using
        '</SnippetDistinctHowTo>
    End Sub

    Sub VBWalkthrough()
        ' <SnippetVBWalkthrough>
        Dim color = "Red"
        Using context As New AdventureWorksEntities()
            Dim products = context.Products

            Dim query = From product In products _
                    Where product.Color = color _
                    Select product

            For Each product As Product In query
                Console.WriteLine("Name: {0}", product.Name)
                Console.WriteLine("Product number: {0}", product.ProductNumber)
                Console.WriteLine("List price: ${0}", product.ListPrice)
                Console.WriteLine("")
            Next
        End Using

        ' Prevent the console window from closing.
        Console.WriteLine("Hit Enter...")
        Console.Read()
        ' </SnippetVBWalkthrough>
    End Sub
#End Region

#Region "Function Mapping"
    Sub FunctionMapping()
        ' <SnippetFunctionMapping>
        Dim line1 = "Algiers Dr."
        Using context As New AdventureWorksEntities()
            Dim query = _
            From address In context.Addresses _
            Where address.AddressLine1.Contains(line1) _
            Select address

            For Each algiersAddress As Address In query
                Console.WriteLine("Address 1: " + algiersAddress.AddressLine1)
            Next

        End Using
        ' </SnippetFunctionMapping>
    End Sub
#End Region

#Region "Compiled Query examples"
    ' <SnippetCompiledQuery1_MQ>
    ReadOnly s_compQuery1 As Func(Of AdventureWorksEntities, ObjectQuery(Of SalesOrderHeader)) = _
        CompiledQuery.Compile(Of AdventureWorksEntities, ObjectQuery(Of SalesOrderHeader))( _
                    Function(ctx) ctx.SalesOrderHeaders)

    Sub CompiledQuery1_MQ()

        Using context As New AdventureWorksEntities()

            Dim orders As ObjectQuery(Of SalesOrderHeader) = s_compQuery1.Invoke(context)

            For Each order In orders
                Console.WriteLine(order.SalesOrderID)
            Next

        End Using
    End Sub
    ' </SnippetCompiledQuery1_MQ>

    ' <SnippetCompiledQuery2>
    ReadOnly s_compQuery2 As Func(Of AdventureWorksEntities, Decimal, IQueryable(Of SalesOrderHeader)) = _
        CompiledQuery.Compile(Of AdventureWorksEntities, Decimal, IQueryable(Of SalesOrderHeader))( _
                    Function(ctx As AdventureWorksEntities, total As Decimal) _
                        From order In ctx.SalesOrderHeaders _
                        Where (order.TotalDue >= total) _
                        Select order)

    Sub CompiledQuery2()
        Using context As New AdventureWorksEntities()

            Dim totalDue As Decimal = 200.0

            Dim orders As IQueryable(Of SalesOrderHeader) = s_compQuery2.Invoke(context, totalDue)

            For Each order In orders
                Console.WriteLine("ID: {0}  Order date: {1} Total due: {2}", _
                                        order.SalesOrderID, _
                                        order.OrderDate, _
                                        order.TotalDue)
            Next
        End Using
    End Sub
    ' </SnippetCompiledQuery2>

    ' <SnippetCompiledQuery2_MQ>
    ReadOnly s_compQuery2MQ As Func(Of AdventureWorksEntities, Decimal, IQueryable(Of SalesOrderHeader)) = _
        CompiledQuery.Compile(Of AdventureWorksEntities, Decimal, IQueryable(Of SalesOrderHeader))( _
                    Function(ctx, total) ctx.SalesOrderHeaders _
                    .Where(Function(s) s.TotalDue >= total) _
                    .Select(Function(s) s))

    Sub CompiledQuery2_MQ()

        Using context As New AdventureWorksEntities()

            Dim totalDue As Decimal = 200.0

            Dim orders As IQueryable(Of SalesOrderHeader) = s_compQuery2MQ.Invoke(context, totalDue)

            For Each order In orders
                Console.WriteLine("ID: {0}  Order date: {1} Total due: {2}", _
                                        order.SalesOrderID, _
                                        order.OrderDate, _
                                        order.TotalDue)
            Next
        End Using
    End Sub
    ' </SnippetCompiledQuery2_MQ>


    Sub CompiledQuery3_MQ()
        ' <SnippetCompiledQuery3_MQ>
        Using context As New AdventureWorksEntities()
            Dim compQuery = CompiledQuery.Compile(Of AdventureWorksEntities, Decimal)( _
                    Function(ctx) ctx.Products.Average(Function(Product) Product.ListPrice))

            Dim averageProductPrice As Decimal = compQuery.Invoke(context)

            Console.WriteLine("The average of the product list prices is $: {0}", averageProductPrice)
        End Using
        ' </SnippetCompiledQuery3_MQ>
    End Sub


    Sub CompiledQuery4_MQ()
        ' <SnippetCompiledQuery4_MQ>
        Using context As New AdventureWorksEntities()
            Dim compQuery = CompiledQuery.Compile(Of AdventureWorksEntities, String, Contact)( _
                    Function(ctx, name) ctx.Contacts.First(Function(contact) contact.EmailAddress.StartsWith(name)))

            Dim contactName As String = "caroline"
            Dim foundContact As Contact = compQuery.Invoke(context, contactName)

            Console.WriteLine("An email address starting with 'caroline': {0}", _
                    foundContact.EmailAddress)
        End Using
        ' </SnippetCompiledQuery4_MQ>
    End Sub

    ' <SnippetCompiledQuery5>
    ReadOnly s_compQuery5 = _
       CompiledQuery.Compile(Of AdventureWorksEntities, DateTime, Decimal, IQueryable(Of SalesOrderHeader))( _
                    Function(ctx, orderDate, totalDue) From product In ctx.SalesOrderHeaders _
                                                       Where product.OrderDate > orderDate _
                                                          And product.TotalDue < totalDue _
                                                       Order By product.OrderDate _
                                                       Select product)
    Sub CompiledQuery5()

        Using context As New AdventureWorksEntities()

            Dim orderedAfterDate As DateTime = New DateTime(2003, 3, 8)
            Dim amountDue As Decimal = 300.0

            Dim orders As IQueryable(Of SalesOrderHeader) = _
                s_compQuery5.Invoke(context, orderedAfterDate, amountDue)

            For Each order In orders
                Console.WriteLine("ID: {0} Order date: {1} Total due: {2}", _
                                  order.SalesOrderID, order.OrderDate, order.TotalDue)
            Next

        End Using
    End Sub
    ' </SnippetCompiledQuery5>

    Sub CompiledQuery6()
        ' <SnippetCompiledQuery6>
        Using context As New AdventureWorksEntities()
            Dim compQuery = CompiledQuery.Compile( _
                    Function(ctx As AdventureWorksEntities, orderDate As DateTime) _
                        From order In ctx.SalesOrderHeaders _
                        Where order.OrderDate > orderDate _
                        Select New With {order.OrderDate, order.SalesOrderID, order.TotalDue})

            Dim orderedAfterDate As DateTime = New DateTime(2004, 3, 8)

            Dim orders = compQuery.Invoke(context, orderedAfterDate)

            For Each order In orders
                Console.WriteLine("ID: {0} Order date: {1} Total due: {2}", _
                                  order.SalesOrderID, order.OrderDate, order.TotalDue)
            Next

        End Using
        ' </SnippetCompiledQuery6>
    End Sub

    ' <SnippetMyParamsStruct>
    Public Structure MyParams
        Public startDate As DateTime
        Public endDate As DateTime
        Public totalDue As Decimal
    End Structure
    ' </SnippetMyParamsStruct>

    ' <SnippetCompiledQuery7>
    ReadOnly s_compQuery = CompiledQuery.Compile(Of AdventureWorksEntities, MyParams, IQueryable(Of SalesOrderHeader))( _
                    Function(ctx, mySearchParams) _
                        From sale In ctx.SalesOrderHeaders _
                        Where sale.ShipDate > mySearchParams.startDate _
                           And sale.ShipDate < mySearchParams.endDate _
                           And sale.TotalDue > mySearchParams.totalDue _
                        Select sale)

    Sub CompiledQuery7()

        Using context As New AdventureWorksEntities()

            Dim myParams As MyParams = New MyParams()
            myParams.startDate = New DateTime(2003, 3, 3)
            myParams.endDate = New DateTime(2003, 3, 8)
            myParams.totalDue = 700.0

            Dim sales = s_compQuery.Invoke(context, myParams)

            For Each sale In sales
                Console.WriteLine("ID: {0}", sale.SalesOrderID)
                Console.WriteLine("Ship date: {0}", sale.ShipDate)
                Console.WriteLine("Total due: {0}", sale.TotalDue)
            Next

        End Using
    End Sub
    ' </SnippetCompiledQuery7>
#End Region

	Sub ProjectToAnonType()
        '<snippetProjToAnonType1>
        Using context As New AdventureWorksEntities()
            Dim resultWithoutRelatedObjects = context.Contacts. _
                Include("SalesOrderHeaders"). _
                Select(Function(c) New With {c}).FirstOrDefault()
            If resultWithoutRelatedObjects.c.SalesOrderHeaders.Count = 0 Then
                Console.WriteLine("No orders are included.")
            End If
        End Using
        '</snippetProjToAnonType1>
        '<snippetProjToAnonType2>
        Using context As New AdventureWorksEntities()
            Dim resultWithRelatedObjects = context.Contacts. _
                Include("SalesOrderHeaders"). _
                Select(Function(c) c).FirstOrDefault()
            If resultWithRelatedObjects.SalesOrderHeaders.Count <> 0 Then
                Console.WriteLine("Orders are included.")
            End If
        End Using
        '</snippetProjToAnonType2>
    End Sub
End Module
