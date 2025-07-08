' <SnippetImportsUsing>
Option Explicit On

Imports System.Linq
Imports System.Linq.Expressions
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Globalization
' </SnippetImportsUsing>
Imports System.Windows.Forms

Module Module1

    Sub Main()

        ' Fill the DataSet.
        'Dim ds As New DataSet()
        'ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        'FillDataSet(ds)
        '//DSInfo(ds);
        '//WriteSchemaToXSD(ds);

        '*** Select Operators ***
        'SelectSimple1()
        'SelectSimple2()
        'SelectManyCompoundFrom()
        'SelectManyCompoundFrom_MQ()
        'SelectManyCompoundFrom2()
        'SelectManyCompoundFrom2_MQ()
        SelectAnonymousTypes_MQ()
        'SelectManyFromAssignment()

        '*** Restriction Operators ***
        'Where1()
        'Where2()
        'Where3()
        'WhereDrilldown()
        'WhereIsNull()

        '*** Partitioning Operators ***
        'TakeSimple()
        'SkipSimple()
        'TakeNested()
        'SkipNested()
        'TakeWhileSimple_MQ()
        'SkipWhileSimple_MQ()

        '*** Ordering Operators ***
        'OrderBySimple1()
        'OrderBySimple2()
        'OrderByComparer_MQ()
        'OrderByDescendingSimple1()
        'ThenByDescendingSimple()
        'ThenByDescendingComparer_MQ()
        'Reverse()

        '*** Grouping Operators ***
        'GroupBySimple2()
        'GroupBySimple3()
        'GroupByNested()

        '*** Set Operators ***
        'DistinctRows()
        'Distinct2()
        'Union2()
        'Intersect2()
        'Except2()

        '*** Conversion Operators ***
        'ToArray()
        'ToArray2()
        'ToList()
        'ToDictionary()
        'OfType() - Listed in C# top portion, but no C# implementation

        '*** Element Operators ***
        'FirstSimple()
        'FirstCondition_MQ()
        'ElementAt()

        '*** Generation Operators ***
        'Range()       'Didn't use Range, couldn't get it to work.

        '*** Quantifier Operators ***
        'AnyGrouped_MQ()
        'AllGrouped_MQ()

        '*** Aggregate Operators ***
        'Aggregate_MQ()
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

        '*** Join Operators ***
        'Join()
        'JoinSimple_MQ()
        'JoinWithGroupedResults_MQ()
        'GroupJoin()
        'GroupJoin2()

        '*** DataSet Loading examples***
        'LoadingQueryResultsIntoDataTable()
        'LoadDataTableWithQueryResults()

        '*** DataRowComparer examples ***
        'CompareDifferentDataRows()
        'CompareEqualDataRows()
        'CompareNullDataRows()

        '*** CopyToDataTable examples ***
        'CopyToDataTable1()

        '*** Misc ***'
        Composing()

        '*** Other stuff  ***
        '[MDL] Why are the first two not undering Ordering and the last under Grouping?
        'OrderBy() ' Not in docs
        'OrderByDescending() ' Not in docs
        'Sum();
        'GroupBy();


        Console.WriteLine("Hit enter...")
        Console.Read()

    End Sub

    Sub FillDataSet(ByRef ds As DataSet)
        ' <SnippetFillDataSet>
        Try
            Dim connectionString As String

            connectionString = "..."

            ' Create a new adapter and give it a query to fetch sales order, contact,
            ' address, and product information for sales in the year 2002. Point connection
            ' information to the configuration setting "AdventureWorks".
            Dim da = New SqlDataAdapter( _
            "SELECT SalesOrderID, ContactID, OrderDate, OnlineOrderFlag, " & _
                "TotalDue, SalesOrderNumber, Status, ShipToAddressID, BillToAddressID " & _
                "FROM Sales.SalesOrderHeader " & _
                "WHERE DATEPART(YEAR, OrderDate) = @year; " & _
                "SELECT d.SalesOrderID, d.SalesOrderDetailID, d.OrderQty, " & _
                "d.ProductID, d.UnitPrice " & _
                "FROM Sales.SalesOrderDetail d " & _
                "INNER JOIN Sales.SalesOrderHeader h " & _
                "ON d.SalesOrderID = h.SalesOrderID  " & _
                "WHERE DATEPART(YEAR, OrderDate) = @year; " & _
                "SELECT p.ProductID, p.Name, p.ProductNumber, p.MakeFlag, " & _
                "p.Color, p.ListPrice, p.Size, p.Class, p.Style  " & _
                "FROM Production.Product p; " & _
                "SELECT DISTINCT a.AddressID, a.AddressLine1, a.AddressLine2, " & _
                "a.City, a.StateProvinceID, a.PostalCode " & _
                "FROM Person.Address a " & _
                "INNER JOIN Sales.SalesOrderHeader h " & _
                "ON  a.AddressID = h.ShipToAddressID OR a.AddressID = h.BillToAddressID " & _
                "WHERE DATEPART(YEAR, OrderDate) = @year; " & _
                "SELECT DISTINCT c.ContactID, c.Title, c.FirstName, " & _
                "c.LastName, c.EmailAddress, c.Phone " & _
                "FROM Person.Contact c " & _
                "INNER JOIN Sales.SalesOrderHeader h " & _
                "ON c.ContactID = h.ContactID " & _
                "WHERE DATEPART(YEAR, OrderDate) = @year;", _
            connectionString)

            ' Add table mappings.
            da.SelectCommand.Parameters.AddWithValue("@year", 2002)
            da.TableMappings.Add("Table", "SalesOrderHeader")
            da.TableMappings.Add("Table1", "SalesOrderDetail")
            da.TableMappings.Add("Table2", "Product")
            da.TableMappings.Add("Table3", "Address")
            da.TableMappings.Add("Table4", "Contact")

            da.Fill(ds)

            ' Add data relations.
            Dim orderHeader As DataTable = ds.Tables("SalesOrderHeader")
            Dim orderDetail As DataTable = ds.Tables("SalesOrderDetail")
            Dim co As DataRelation = New DataRelation("SalesOrderHeaderDetail", _
                                            orderHeader.Columns("SalesOrderID"), _
                                            orderDetail.Columns("SalesOrderID"), True)
            ds.Relations.Add(co)

            Dim contact As DataTable = ds.Tables("Contact")
            Dim orderContact As DataRelation = New DataRelation("SalesOrderContact", _
                                            contact.Columns("ContactID"), _
                                            orderHeader.Columns("ContactID"), True)
            ds.Relations.Add(orderContact)
        Catch ex As SqlException
            Console.WriteLine("SQL exception occurred: " & ex.Message)
        End Try
        ' </SnippetFillDataSet>
    End Sub

#Region "Select Operator"

    '/*[Category("Projection Operators")]
    '[Title("Select - Simple 1")]
    '[Description("This example uses Select to return all the rows from the Product table and display the product names.")]*/
    Sub SelectSimple1()
        ' <SnippetSelectSimple1>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim query = From product In products.AsEnumerable() _
                    Select product
        Console.WriteLine("Product Names:")
        For Each p In query
            Console.WriteLine(p.Field(Of String)("Name"))
        Next
        ' </SnippetSelectSimple1>
    End Sub

    '/*[Category("Projection Operators")]
    '[Title("Select - Simple 2")]
    '[Description("This sample uses Select to return a sequence of just the names of a list of products.")]*/
    Sub SelectSimple2()
        ' <SnippetSelectSimple2>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim query = From product In products.AsEnumerable() _
                    Select product.Field(Of String)("Name")

        Console.WriteLine("Product Names:")
        For Each productName In query
            Console.WriteLine(productName)
        Next
        ' </SnippetSelectSimple2>
    End Sub

    '/*[Category("Projection Operators")]
    '[Title("SelectMany - Compound From")]
    '[Description("This sample uses a compound From clause to Select all orders where " &
    '             " TotalDue is less than 500.00.")]*/
    Sub SelectManyCompoundFrom()
        ' <SnippetSelectManyCompoundFrom>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")
        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = _
            From contact In contacts.AsEnumerable() _
            From order In orders.AsEnumerable() _
            Where (contact.Field(Of Integer)("ContactID") = _
                order.Field(Of Integer)("ContactID")) _
                And (order.Field(Of Decimal)("TotalDue") < 500D) _
            Select New With _
            { _
                .ContactID = contact.Field(Of Integer)("ContactID"), _
                .LastName = contact.Field(Of String)("LastName"), _
                .FirstName = contact.Field(Of String)("FirstName"), _
                .OrderID = order.Field(Of Integer)("SalesOrderID"), _
                .TotalDue = order.Field(Of Decimal)("TotalDue") _
            }

        For Each smallOrder In query
            Console.Write("ContactID: " & smallOrder.ContactID)
            Console.Write(" Name: {0}, {1}", smallOrder.LastName, _
                               smallOrder.FirstName)
            Console.Write(" OrderID: " & smallOrder.OrderID)
            Console.WriteLine(" TotalDue: $" & smallOrder.TotalDue)
        Next
        ' </SnippetSelectManyCompoundFrom>
    End Sub

    '/*[Category("Projection Operators")]
    '[Title("SelectMany - Compound from using method syntax")]
    '[Description("This example uses SelectMany to select all orders where " &
    '             " TotalDue is less than 500.00.")]*/
    Sub SelectManyCompoundFrom_MQ()
        '<SnippetSelectManyCompoundFrom_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts = ds.Tables("Contact").AsEnumerable()
        Dim orders = ds.Tables("SalesOrderHeader").AsEnumerable()

        Dim query = _
            contacts.SelectMany( _
                Function(contact) orders.Where(Function(order) _
                    (contact.Field(Of Int32)("ContactID") = order.Field(Of Int32)("ContactID")) _
                        And order.Field(Of Decimal)("TotalDue") < 500D) _
                    .Select(Function(order) New With _
                    { _
                        .ContactID = contact.Field(Of Integer)("ContactID"), _
                        .LastName = contact.Field(Of String)("LastName"), _
                        .FirstName = contact.Field(Of String)("FirstName"), _
                        .OrderID = order.Field(Of Integer)("SalesOrderID"), _
                        .Total = order.Field(Of Decimal)("TotalDue") _
                    }))

        For Each smallOrder In query
            Console.Write("ContactID: " & smallOrder.ContactID)
            Console.Write(" Name: " & smallOrder.LastName & ", " & smallOrder.FirstName)
            Console.Write(" Order ID: " & smallOrder.OrderID)
            Console.WriteLine(" Total Due: $" & smallOrder.Total)
        Next
        '</SnippetSelectManyCompoundFrom_MQ>
    End Sub

    '/*[Category("Projection Operators")]
    '[Title("SelectMany - Compound From 2")]
    '[Description("This example uses a compound From clause to select all orders where the " &
    '      "order was made on October 1, 2002 or later.")]*/
    Sub SelectManyCompoundFrom2()
        '<SnippetSelectManyCompoundFrom2>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")
        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = _
            From contact In contacts.AsEnumerable() _
            From order In orders.AsEnumerable() _
            Where contact.Field(Of Integer)("ContactID") = order.Field(Of Integer)("ContactID") And _
                order.Field(Of DateTime)("OrderDate") >= New DateTime(2002, 10, 1) _
            Select New With _
                { _
                   .ContactID = contact.Field(Of Integer)("ContactID"), _
                   .LastName = contact.Field(Of String)("LastName"), _
                   .FirstName = contact.Field(Of String)("FirstName"), _
                   .OrderID = order.Field(Of Integer)("SalesOrderID"), _
                   .OrderDate = order.Field(Of DateTime)("OrderDate") _
                }

        For Each order In query
            Console.Write("Contact ID: " & order.ContactID)
            Console.Write(" Name: " & order.LastName & ", " & order.FirstName)
            Console.Write(" Order ID: " & order.OrderID)
            Console.WriteLine(" Order date: {0:d} ", order.OrderDate)
        Next
        '</SnippetSelectManyCompoundFrom2>
    End Sub

    '/*[Category("Projection Operators")]
    '[Title("SelectMany - Compound from 2, method-based query syntax")]
    '[Description("This example uses SelectMany to select all orders where the " &
    '      "order was made on October 1, 2002 or later.")]*/
    Sub SelectManyCompoundFrom2_MQ()
        '<SnippetSelectManyCompoundFrom2_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts = ds.Tables("Contact").AsEnumerable()
        Dim orders = ds.Tables("SalesOrderHeader").AsEnumerable()

        Dim query = _
            contacts.SelectMany( _
                Function(contact) orders.Where(Function(order) _
                    (contact.Field(Of Int32)("ContactID") = order.Field(Of Int32)("ContactID")) _
                        And order.Field(Of DateTime)("OrderDate") >= New DateTime(2002, 10, 1)) _
                    .Select(Function(order) New With _
                        { _
                            .ContactID = contact.Field(Of Integer)("ContactID"), _
                            .LastName = contact.Field(Of String)("LastName"), _
                            .FirstName = contact.Field(Of String)("FirstName"), _
                            .OrderID = order.Field(Of Integer)("SalesOrderID"), _
                            .OrderDate = order.Field(Of DateTime)("OrderDate") _
                        }))

        For Each order In query
            Console.Write("Contact ID: " & order.ContactID)
            Console.Write(" Name: " & order.LastName & ", " & order.FirstName)
            Console.Write(" Order ID: " & order.OrderID)
            Console.WriteLine(" Order date: {0:d}", order.OrderDate)
        Next
        '</SnippetSelectManyCompoundFrom2_MQ>
    End Sub

    '/*[Category("Projection Operators")]
    '[Title("Select - Anonymous Types ")]
    '[Description("This example uses Select to project the Name, ProductNumber, and" &
    '  "ListPrice properties to a sequence of anonymous types.  The ListPrice" &
    '  "property is also renamed to Price in the resulting type.")]*/
    Sub SelectAnonymousTypes_MQ()
        ' <SnippetSelectAnonymousTypes_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim query = products.AsEnumerable() _
            .Select(Function(product As DataRow) New With _
            { _
                .ProductName = product.Field(Of String)("Name"), _
                .ProductNumber = product.Field(Of String)("ProductNumber"), _
                .Price = product.Field(Of Decimal)("ListPrice") _
            })

        Console.WriteLine("Product Info:")
        For Each product In query
            Console.Write("Product name: " & product.ProductName)
            Console.Write("Product number: " & product.ProductNumber)
            Console.WriteLine("List price: $ " & product.Price)
        Next
        ' </SnippetSelectAnonymousTypes_MQ>
    End Sub

    '/*[Category("Projection Operators")]
    '[Title("SelectMany - from Assignment")]
    '[Description("This example uses a compound From clause to select all orders where the " &
    '             "order total is greater than 10000.00 and uses From assignment to avoid " &
    '             "requesting the total twice.")]*/
    Sub SelectManyFromAssignment()
        '<SnippetSelectManyFromAssignment>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")
        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = _
            From contact In contacts.AsEnumerable() _
            From order In orders.AsEnumerable() _
            Let total = order.Field(Of Decimal)("TotalDue") _
            Where contact.Field(Of Integer)("ContactID") = order.Field(Of Integer)("ContactID") And _
                total >= 10000D _
            Select New With _
                { _
                   .ContactID = contact.Field(Of Integer)("ContactID"), _
                   .LastName = contact.Field(Of String)("LastName"), _
                   .OrderID = order.Field(Of Integer)("SalesOrderID"), _
                   .OrderDate = order.Field(Of DateTime)("OrderDate"), _
                   total _
                }

        For Each order In query
            Console.Write("Contact ID: " & order.ContactID)
            Console.Write(" Last Name: " & order.LastName)
            Console.Write(" Order ID: " & order.OrderID)
            Console.WriteLine(" Total: $" & order.total)
        Next
        '</SnippetSelectManyFromAssignment>
    End Sub

#End Region 'Select Operators

#Region "Restriction Operators"

    '[Category("Restriction Operators")]
    '[Title("Where 1")]
    '[Description("This example returns all online orders.")]
    Sub Where1()
        ' <SnippetWhere1>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = _
            From order In orders.AsEnumerable() _
            Where order.Field(Of Boolean)("OnlineOrderFlag") = True _
            Select New With { _
                .SalesOrderID = order.Field(Of Integer)("SalesOrderID"), _
                .OrderDate = order.Field(Of DateTime)("OrderDate"), _
                .SalesOrderNumber = order.Field(Of String)("SalesOrderNumber") _
             }

        For Each onlineOrder In query
            Console.Write("Order ID: " & onlineOrder.SalesOrderID)
            Console.Write(" Order date: " & onlineOrder.OrderDate)
            Console.WriteLine(" Order number: " & onlineOrder.SalesOrderNumber)
        Next
        ' </SnippetWhere1>
    End Sub

    '/*[Category("Restriction Operators")]
    '[Title("Where ")]
    '[Description("This example returns the orders where the order quantity is greater than 2 and less than 6.")]*/
    Sub Where2()
        ' <SnippetWhere2>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderDetail")

        Dim query = _
            From order In orders.AsEnumerable() _
            Where order.Field(Of Short)("OrderQty") > 2 And _
                    order.Field(Of Short)("OrderQty") < 6 _
            Select New With _
            { _
                .SalesOrderID = order.Field(Of Integer)("SalesOrderID"), _
                .OrderQty = order.Field(Of Short)("OrderQty") _
            }

        For Each order In query
            Console.Write("Order ID: " & order.SalesOrderID)
            Console.WriteLine(" Order quantity: " & order.OrderQty)
        Next
        ' </SnippetWhere2>
    End Sub

    ' /*[Category("Restriction Operators")]
    ' [Title("Where 3")]
    ' [Description("This example returns all red colored products.")]*/
    Sub Where3()
        ' <SnippetWhere3>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim query = _
            From product In products.AsEnumerable() _
            Where product.Field(Of String)("Color") = "Red" _
            Select New With _
               { _
                   .Name = product.Field(Of String)("Name"), _
                   .ProductNumber = product.Field(Of String)("ProductNumber"), _
                   .ListPrice = product.Field(Of Decimal)("ListPrice") _
               }

        For Each product In query
            Console.WriteLine("Name: " & product.Name)
            Console.WriteLine("Product number: " & product.ProductNumber)
            Console.WriteLine("List price: $ " & product.ListPrice & vbNewLine)
        Next
        ' </SnippetWhere3>
    End Sub

    '/*[Category("Restriction Operators")]
    '[Title("Where - Drilldown")]
    '[Description("This example uses Where to find orders that were made after December 1, 2002 " &
    '             "and then uses the GetChildRows to get the details for each order.")]*/
    Sub WhereDrilldown()
        '<SnippetWhereDrilldown>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query As IEnumerable(Of DataRow) = _
            From order In orders.AsEnumerable() _
            Where order.Field(Of DateTime)("OrderDate") >= New DateTime(2002, 12, 1) _
            Select order

        Console.WriteLine("Orders that were made after 12/1/2002:")
        For Each order As DataRow In query
            Console.WriteLine("OrderID {0} Order date: {1:d} ", _
                order.Field(Of Integer)("SalesOrderID"), order.Field(Of DateTime)("OrderDate"))
            For Each orderDetail As DataRow In order.GetChildRows("SalesOrderHeaderDetail")
                Console.WriteLine("  Product ID: {0} Unit Price {1}", _
                    orderDetail("ProductID"), orderDetail("UnitPrice"))
            Next
        Next
        '</SnippetWhereDrilldown>
    End Sub

    '/*[Category("Restriction Operators")]
    '[Title("Where Is Null")]
    '[Description("This example returns all red colored products.  This query does not used the generic Field"
    ' "method, but explicitly checks column values for null.")]*/
    Sub WhereIsNull()
        ' <SnippetWhereIsNull>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim query = _
            From product In products.AsEnumerable() _
            Where product!Color IsNot DBNull.Value AndAlso product!Color = "Red" _
            Select New With _
               { _
                   .Name = product!Name, _
                   .ProductNumber = product!ProductNumber, _
                   .ListPrice = product!ListPrice _
               }

        For Each product In query
            Console.WriteLine("Name: " & product.Name)
            Console.WriteLine("Product number: " & product.ProductNumber)
            Console.WriteLine("List price: $" & product.ListPrice & vbNewLine)
        Next
        ' </SnippetWhereIsNull>
    End Sub

#End Region 'Restriction Operators

#Region "Partitioning Operators"
    '/*[Category("Partitioning Operators")]
    '[Title("Take - Simple")]
    '[Description("This sample uses Take to get only the first 5 elements of the Contact table.")]*/
    Sub TakeSimple()
        ' <SnippetTakeSimple>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")

        Dim first5Contacts = contacts.AsEnumerable().Take(5)

        Console.WriteLine("First 5 contacts:")
        For Each contact In first5Contacts
            Console.Write("Title = " & contact.Field(Of String)("Title"))
            Console.Write(vbTab & "FirstName = " & contact.Field(Of String)("FirstName"))
            Console.WriteLine(vbTab & "LastName = " & contact.Field(Of String)("LastName"))
        Next
        ' </SnippetTakeSimple>
    End Sub

    '/*[Category("Partitioning Operators")]
    '[Title("Skip - Simple")]
    '[Description("This sample uses Skip to get all but the first 5 elements of the Contact table." */
    Sub SkipSimple()
        ' <SnippetSkipSimple>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")

        Dim allButFirst5Contacts = contacts.AsEnumerable().Skip(5)

        Console.WriteLine("All but first 5 contacts:")

        For Each contact In allButFirst5Contacts
            Console.Write("FirstName = {0} ", contact.Field(Of String)("FirstName"))
            Console.WriteLine(vbTab & " LastName = " & contact.Field(Of String)("LastName"))
        Next
        ' </SnippetSkipSimple>
    End Sub

    '/*[Category("Partitioning Operators")]
    '[Title("Take - Nested")]
    '[Description("This sample uses Take to get the first 3 addresses " &
    '             "in Seattle.")]*/
    Sub TakeNested()
        ' <SnippetTakeNested>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim addresses As DataTable = ds.Tables("Address")
        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = ( _
            From address In addresses.AsEnumerable() _
            From order In orders.AsEnumerable() _
            Where (address.Field(Of Integer)("AddressID") = _
                order.Field(Of Integer)("BillToAddressID")) _
                 And address.Field(Of String)("City") = "Seattle" _
            Select New With _
            { _
                .City = address.Field(Of String)("City"), _
                .OrderID = order.Field(Of Integer)("SalesOrderID"), _
                .OrderDate = order.Field(Of DateTime)("OrderDate") _
            }).Take(3)

        Console.WriteLine("First 3 orders in Seattle:")
        For Each order In query
            Console.Write("City: " & order.City)
            Console.Write(" Order ID: " & order.OrderID)
            Console.WriteLine(" Order date: " & order.OrderDate)
        Next
        ' </SnippetTakeNested>
    End Sub

    '/*[Category("Partitioning Operators")]
    '[Title("Skip - Nested")]
    '[Description("This sample uses Skip to get all but the first 2 addresses " &
    '             "in Seattle.")]*/
    Sub SkipNested()
        ' <SnippetSkipNested>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim addresses As DataTable = ds.Tables("Address")
        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = ( _
            From address In addresses.AsEnumerable() _
            From order In orders.AsEnumerable() _
            Where (address.Field(Of Integer)("AddressID") = _
                   order.Field(Of Integer)("BillToAddressID")) _
                 And address.Field(Of String)("City") = "Seattle" _
            Select New With _
               { _
                   .City = address.Field(Of String)("City"), _
                   .OrderID = order.Field(Of Integer)("SalesOrderID"), _
                   .OrderDate = order.Field(Of DateTime)("OrderDate") _
               }).Skip(2)

        Console.WriteLine("All but first 2 orders in Seattle:")
        For Each addOrder In query
            Console.Write("City: " & addOrder.City)
            Console.Write(" Order ID: " & addOrder.OrderID)
            Console.WriteLine(" Order date: " & addOrder.OrderDate)
        Next
        ' </SnippetSkipNested>
    End Sub

    '/*[Category("Partitioning Operators")]
    '[Title("TakeWhile - Simple")]
    '[Description("This example uses OrderBy and TakeWhile to return products from the Product table with a list price less than 300.00.")]*/
    Sub TakeWhileSimple_MQ()
        '<SnippetTakeWhileSimple_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim takeWhileListPriceLessThan300 As IEnumerable(Of DataRow) = _
            products.AsEnumerable() _
                .OrderBy(Function(listprice) listprice.Field(Of Decimal)("ListPrice")) _
                .TakeWhile(Function(product) product.Field(Of Decimal)("ListPrice") < 300D)

        Console.WriteLine("First ListPrice less than 300.00:")
        For Each product As DataRow In takeWhileListPriceLessThan300
            Console.WriteLine(product.Field(Of Decimal)("ListPrice"))
        Next
        '</SnippetTakeWhileSimple_MQ>
    End Sub

    '/*[Category("Partitioning Operators")]
    '[Title("SkipWhile - Simple")]
    '[Description("This example uses OrderBy and SkipWhile to return products from the Product table with a list price greater than 300.00.")]*/
    Sub SkipWhileSimple_MQ()
        '<SnippetSkipWhileSimple_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")
        Dim skipWhilePriceLessThan300 As IEnumerable(Of DataRow) = _
            products.AsEnumerable() _
                .OrderBy(Function(listprice) listprice.Field(Of Decimal)("ListPrice")) _
                .SkipWhile(Function(product) product.Field(Of Decimal)("ListPrice") < 300D)

        Console.WriteLine("First ListPrice less than 300.00:")
        For Each product As DataRow In skipWhilePriceLessThan300
            Console.WriteLine(product.Field(Of Decimal)("ListPrice"))
        Next
        '</SnippetSkipWhileSimple_MQ>
    End Sub

#End Region 'Partitioning Operators

#Region "Ordering Operators"

    '/*[Category("Ordering Operators")]
    '[Title("OrderBy - Simple 1")]
    '[Description("This sample uses orderby to sort a list of last names.")]*/
    Sub OrderBySimple1()
        ' <SnippetOrderBySimple1>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")

        Dim query = _
            From contact In contacts.AsEnumerable() _
            Select contact _
            Order By contact.Field(Of String)("LastName")

        Console.WriteLine("The sorted list of last names:")
        For Each contact In query
            Console.WriteLine(contact.Field(Of String)("LastName"))
        Next
        ' </SnippetOrderBySimple1>
    End Sub

    '/*[Category("Ordering Operators")]
    '[Title("OrderBy - Simple 2")]
    '[Description("This sample uses orderby to sort a list of last names by length.")]*/
    Sub OrderBySimple2()
        ' <SnippetOrderBySimple2>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")

        Dim query = _
            From contact In contacts.AsEnumerable() _
            Select contact _
            Order By contact.Field(Of String)("LastName").Length

        Console.WriteLine("The sorted list of last names (by length):")
        For Each contact In query
            Console.WriteLine(contact.Field(Of String)("LastName"))
        Next
        ' </SnippetOrderBySimple2>
    End Sub

    ' <SnippetCustomComparer>
    Private Class CaseInsensitiveComparer
        Implements IComparer(Of String)
        Public Function Compare(ByVal x As String, ByVal y As String) As Integer Implements System.Collections.Generic.IComparer(Of String).Compare
            Return String.Compare(x, y, True, CultureInfo.InvariantCulture)
        End Function
    End Class
    ' </SnippetCustomComparer>

    Sub OrderByComparer_MQ()
        '<SnippetOrderByComparer_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")

        Dim query As IEnumerable(Of DataRow) = _
            contacts.AsEnumerable().OrderBy(Function(contact) _
                        contact.Field(Of String)("LastName"), _
                        New CaseInsensitiveComparer())

        For Each contact As DataRow In query
            Console.WriteLine(contact.Field(Of String)("LastName"))
        Next
        '</SnippetOrderByComparer_MQ>
    End Sub

    '/*[Category("Ordering Operators")]
    '[Title("OrderByDescending - Simple 1")]
    '[Description("This sample uses orderby and descending to sort the price list " &
    '             "From highest to lowest.")]*/
    Sub OrderByDescendingSimple1()
        ' <SnippetOrderByDescendingSimple1>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim query = _
            From product In products.AsEnumerable() _
            Select product _
            Order By product.Field(Of Decimal)("ListPrice") Descending

        Console.WriteLine("The list price From highest to lowest:")

        For Each product In query
            Console.WriteLine(product.Field(Of Decimal)("ListPrice"))
        Next
        ' </SnippetOrderByDescendingSimple1>
    End Sub

    '/*[Category("Ordering Operators")]
    '[Title("ThenByDescending - Simple")]
    '[Description("This sample uses a compound orderby to sort a list of products, " &
    '             "first by name, and then by list price, From highest to lowest.")]*/
    Sub ThenByDescendingSimple()
        ' <SnippetThenByDescendingSimple>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim query = _
            From product In products.AsEnumerable() _
            Order By product.Field(Of String)("Name"), _
                    product.Field(Of Decimal)("ListPrice") Descending _
            Select product

        For Each product In query
            Console.Write("Product ID: " & product.Field(Of Integer)("ProductID"))
            Console.Write(" Product Name: " & product.Field(Of String)("Name"))
            Console.WriteLine(" List Price: " & product.Field(Of Decimal)("ListPrice"))
        Next
        ' </SnippetThenByDescendingSimple>
    End Sub

    '/*[Category("Ordering Operators")]
    '[Title("ThenByDescending - Comparer")]
    '[Description("This example uses OrderBy and ThenBy with a custom comparer to " &
    '             "first sort by list price, and then perform a case-insensitive descending sort " &
    '             "of the product names.")]
    '[LinkedClass("CaseInsensitiveComparer")]*/
    Sub ThenByDescendingComparer_MQ()
        '<SnippetThenByDescendingComparer_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim query As IEnumerable(Of DataRow) = _
            products.AsEnumerable().OrderBy(Function(product) product.Field(Of Decimal)("ListPrice")) _
                .ThenBy(Function(product) product.Field(Of String)("Name"), _
                        New CaseInsensitiveComparer())

        For Each product As DataRow In query
            Console.WriteLine("Product ID: {0} Product Name: {1} List Price {2}", _
                product.Field(Of Integer)("ProductID"), _
                product.Field(Of String)("Name"), _
                product.Field(Of Decimal)("ListPrice"))
        Next
        '</SnippetThenByDescendingComparer_MQ>
    End Sub

    '/* [Category("Ordering Operators")]
    '[Title("Reverse")]
    '[Description("This sample uses Reverse to create a list of orders where OrderDate < Feb 20, 2002.")]*/
    Sub Reverse()
        ' <SnippetReverse>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = ( _
            From order In orders.AsEnumerable() _
            Where order.Field(Of DateTime)("OrderDate") < New DateTime(2002, 2, 20) _
            Select order).Reverse()

        Console.WriteLine("A backwards list of orders where OrderDate < Feb 20, 2002")

        For Each order In query
            Console.WriteLine(order.Field(Of DateTime)("OrderDate"))
        Next
        ' </SnippetReverse>
    End Sub

#End Region 'Ordering Operators

#Region "Grouping Operators"

    '/*[Category("Grouping Operators")]
    '[Title("GroupBy - Simple 2")]
    '[Description("This example uses GroupBy to partition a list of contacts by the first letter of their last name.")]*/
    Sub GroupBySimple2()
        '<SnippetGroupBySimple2>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")

        Dim query = ( _
            From contact In contacts.AsEnumerable() _
            Group contact By lastNameChar = contact.Field(Of String)("LastName")(0) Into Group _
            Select FirstLetter = lastNameChar, Names = Group). _
                OrderBy(Function(letter) letter.FirstLetter)

        For Each contact In query
            Console.WriteLine("Last names that start with the letter '{0}':", _
                contact.FirstLetter)
            For Each name In contact.Names
                Console.WriteLine(name.Field(Of String)("LastName"))
            Next
        Next
        '</SnippetGroupBySimple2>
    End Sub

    '/*[Category("Grouping Operators")]
    '[Title("GroupBy - Simple 3")]
    '[Description("This example uses GroupBy to partition a list of addresses by postal code.")]*/
    Sub GroupBySimple3()
        '<SnippetGroupBySimple3>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim addresses As DataTable = ds.Tables("Address")

        Dim query = _
            From address In addresses.AsEnumerable() _
            Group address By postalCode = address.Field(Of String)("PostalCode") Into Group _
            Select New With {.PostalCode = postalCode, .AddressLine = Group}

        For Each addressGroup In query
            Console.WriteLine("Postal Code: {0}", addressGroup.PostalCode)
            For Each address In addressGroup.AddressLine
                Console.WriteLine(vbTab & address.Field(Of String)("AddressLine1") & _
                    address.Field(Of String)("AddressLine2"))
            Next
        Next
        '</SnippetGroupBySimple3>
    End Sub

    '/*[Category("Grouping Operators")]
    '[Title("GroupBy - Nested")]
    '[Description("This example uses GroupBy to partition a list of each contact's orders, " &
    '             "first by year, and then by month.")]*/
    Sub GroupByNested()
        '<SnippetGroupByNested>

        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")

        'Dim query = _
        '    From contact In contacts.AsEnumerable() _
        '    Select New With _
        '    { _
        '        .ContactID = contact.Field(Of Integer)("ContactID"), _
        '        .YearGroups = _
        '            From order In contact.GetChildRows("SalesOrderContact") _
        '            Group order By order.Field(Of DateTime)("OrderDate").Year Into yg _
        '            Select New With _
        '            { _
        '                .Year = yg.Key, _
        '                .MonthGroups = _
        '                    From order In yg _
        '                    Group order By order.Field(Of DateTime)("OrderDate").Month Into mg _
        '                    Select New With {.Month = mg.Key, .Orders = mg} _
        '            } _
        '    }

        Dim query = _
            From contact In contacts.AsEnumerable() _
            Select New With _
            { _
                .ContactID = contact.Field(Of Integer)("ContactID"), _
                .YearGroups = _
                    From order In contact.GetChildRows("SalesOrderContact") _
                    Group order By year = order.Field(Of DateTime)("OrderDate").Year Into yg = Group _
                    Select New With _
                    { _
                        .Year = year, _
                        .MonthGroups = _
                            From order In yg _
                            Group order By month = order.Field(Of DateTime)("OrderDate").Month Into mg = Group _
                            Select New With {.Month = month, .Orders = mg} _
                    } _
            }

        For Each contactGroup In query
            Console.WriteLine("ContactID = " & contactGroup.ContactID)
            For Each yearGroup In contactGroup.YearGroups
                Console.WriteLine(vbTab & " Year = " & yearGroup.Year)
                For Each monthGroup In yearGroup.MonthGroups
                    Console.WriteLine(vbTab & vbTab & " Month = " & monthGroup.Month)
                    For Each order In monthGroup.Orders
                        Console.WriteLine(vbTab & vbTab & vbTab & " OrderID = " & _
                            order.Field(Of Integer)("SalesOrderID"))
                        Console.WriteLine(vbTab & vbTab & vbTab & " OrderDate = " & _
                            order.Field(Of DateTime)("OrderDate"))
                    Next
                Next
            Next
        Next
        '</SnippetGroupByNested>
    End Sub

#End Region 'Grouping Operators

#Region "Set Operators"

    '/*[Category("Set Operators")]
    '[Title("Distinct - 1")]
    '[Description("This sample uses Distinct to remove duplicate elements in a sequence.")]*/
    Sub DistinctRows()
        ' <SnippetDistinctRows>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim rows As List(Of DataRow) = New List(Of DataRow)

        Dim contacts As DataTable = ds.Tables("Contact")

        ' Get 100 rows from the Contact table.
        Dim query = ( _
            From c In contacts.AsEnumerable() _
            Select c).Take(100)

        Dim contactsTableWith100Rows = query.CopyToDataTable()

        ' Add 100 rows to the list.
        For Each row In contactsTableWith100Rows.Rows
            rows.Add(row)
        Next

        ' Create duplicate rows by adding the same 100 rows to the list.
        For Each row In contactsTableWith100Rows.Rows
            rows.Add(row)
        Next

        Dim table = _
                System.Data.DataTableExtensions.CopyToDataTable(Of DataRow)(rows)

        ' Find the unique contacts in the table.
        Dim uniqueContacts = _
            table.AsEnumerable().Distinct(DataRowComparer.Default)

        Console.WriteLine("Unique contacts:")
        For Each uniqueContact In uniqueContacts
            Console.WriteLine(uniqueContact.Field(Of Integer)("ContactID"))
        Next
        ' </SnippetDistinctRows>
    End Sub

    '/*[Category("Set Operators")]
    '[Title("Distinct - 2")]
    '[Description("This example uses Distinct to remove duplicate contacts.")]*/
    Sub Distinct2()
        '<SnippetDistinct2>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts1 As DataTable = ds.Tables("Contact")
        Dim query As IEnumerable(Of DataRow) = _
            From contact In contacts1.AsEnumerable() _
            Where contact.Field(Of String)("Title") = "Ms." _
            Select contact

        Dim contacts2 As DataTable = query.CopyToDataTable()

        Dim distinctContacts As IEnumerable(Of DataRow) = _
            contacts2.AsEnumerable().Distinct(DataRowComparer.Default)

        For Each row As DataRow In distinctContacts
            Console.WriteLine("Id: {0} {1} {2} {3}", _
                row("ContactID"), row("Title"), row("FirstName"), row("LastName"))
        Next
        '</SnippetDistinct2>
    End Sub

    '/*[Category("Set Operators")]
    '[Title("Union - 2")]
    '[Description("This sample uses Union to create one sequence based on two DataTables.")]*/
    Sub Union2()
        ' <SnippetUnion2>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contactTable As DataTable = ds.Tables("Contact")

        Dim query1 = _
            From contact In contactTable.AsEnumerable() _
            Where contact.Field(Of String)("Title") = "Ms." _
            Select contact

        Dim query2 = _
            From contact In contactTable.AsEnumerable() _
            Where contact.Field(Of String)("FirstName") = "Sandra" _
            Select contact

        Dim contacts1 = query1.CopyToDataTable()
        Dim contacts2 = query2.CopyToDataTable()

        Dim contacts = contacts1.AsEnumerable().Union(contacts2.AsEnumerable(), _
                                                      DataRowComparer.Default)

        Console.WriteLine("Union of employees tables")
        For Each row In contacts
            Console.WriteLine("Id: {0} {1} {2} {3}", _
                    row("ContactID"), row("Title"), row("FirstName"), row("LastName"))
        Next
        ' </SnippetUnion2>
    End Sub

    '/*[Category("Set Operators")]
    '[Title("Intersect - 2")]
    '[Description("This sample uses Intersect to create one sequence based on two DataTables.")]*/
    Sub Intersect2()
        ' <SnippetIntersect2>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contactTable As DataTable = ds.Tables("Contact")

        Dim query1 = _
            From contact In contactTable.AsEnumerable() _
            Where contact.Field(Of String)("Title") = "Ms." _
            Select contact

        Dim query2 = _
            From contact In contactTable.AsEnumerable() _
            Where contact.Field(Of String)("FirstName") = "Sandra" _
            Select contact

        Dim contacts1 = query1.CopyToDataTable()
        Dim contacts2 = query2.CopyToDataTable()

        Dim contacts = contacts1.AsEnumerable() _
            .Intersect(contacts2.AsEnumerable(), DataRowComparer.Default)

        Console.WriteLine("Intersect of employees tables")

        For Each row In contacts
            Console.WriteLine("Id: {0} {1} {2} {3}", _
                    row("ContactID"), row("Title"), row("FirstName"), row("LastName"))
        Next
        ' </SnippetIntersect2>
    End Sub

    '/*[Category("Set Operators")]
    '[Title("Except - 2")]
    '[Description("This sample uses Except to create one sequence based on two DataTables.")]*/
    Sub Except2()
        ' <SnippetExcept2>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contactTable As DataTable = ds.Tables("Contact")

        Dim query1 = _
            From contact In contactTable.AsEnumerable() _
            Where contact.Field(Of String)("Title") = "Ms." _
            Select contact

        Dim query2 = _
            From contact In contactTable.AsEnumerable() _
            Where contact.Field(Of String)("FirstName") = "Sandra" _
            Select contact

        Dim contacts1 = query1.CopyToDataTable()
        Dim contacts2 = query2.CopyToDataTable()

        ' Find the contacts that are in the first
        ' table but not the second.
        Dim contacts = contacts1.AsEnumerable().Except(contacts2.AsEnumerable(), _
                                                      DataRowComparer.Default)

        Console.WriteLine("Except of employees tables")

        For Each row In contacts
            Console.WriteLine("Id: {0} {1} {2} {3}", _
                    row("ContactID"), row("Title"), row("FirstName"), row("LastName"))
        Next
        ' </SnippetExcept2>
    End Sub

#End Region 'Set Operators

#Region "Conversion Operators"

    '/*[Category("Conversion Operators")]
    '[Title("ToArray")]
    '[Description("This sample uses ToArray to immediately evaluate a sequence into an array.")]*/
    Sub ToArray()
        ' <SnippetToArray>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim productsArray = products.AsEnumerable().ToArray()

        Dim query = _
                From product In productsArray _
                Select product _
                Order By product.Field(Of Decimal)("ListPrice") Descending

        Console.WriteLine("Every price From highest to lowest:")
        For Each product In query
            Console.WriteLine(product.Field(Of Decimal)("ListPrice"))
        Next
        ' </SnippetToArray>
    End Sub

    '/*[Category("Conversion Operators")]
    '[Title("ToArray")]
    '[Description("This sample uses ToArray to immediately evaluate a sequence into an array.")]*/
    Sub ToArray2()
        ' <SnippetToArray2>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim query = _
                From product In products.AsEnumerable() _
                Order By product.Field(Of Decimal)("ListPrice") Descending _
                Select product

        ' Force immediate execution of the query.
        Dim productsArray = query.ToArray()

        Console.WriteLine("Every price From highest to lowest:")
        For Each prod In productsArray
            Console.WriteLine(prod.Field(Of Decimal)("ListPrice"))
        Next
        ' </SnippetToArray2>
    End Sub

    '/*[Category("Conversion Operators")]
    '[Title("ToList")]
    '[Description("This sample uses ToList to immediately evaluate a sequence into a List<T>.")]*/
    Sub ToList()
        ' <SnippetToList>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim productList = products.AsEnumerable().ToList()

        Dim query = _
            From product In productList _
            Select product _
            Order By product.Field(Of String)("Name")

        Console.WriteLine("The sorted name list:")

        For Each product In query
            Console.WriteLine(product.Field(Of String)("Name").ToLower(CultureInfo.InvariantCulture))
        Next
        ' </SnippetToList>
    End Sub

    '/*[Category("Conversion Operators")]
    '[Title("ToDictionary")]
    '[Description("This example uses ToDictionary to immediately evaluate a sequence and a " &
    '            "related key expression into a dictionary.")]*/
    Sub ToDictionary()
        '<SnippetToDictionary>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim scoreRecordsDict = products.AsEnumerable(). _
            ToDictionary(Function(record) record.Field(Of String)("Name"))

        Console.WriteLine("Top Tube's ProductID: {0}", _
            scoreRecordsDict("Top Tube")("ProductID"))
        '</SnippetToDictionary>
    End Sub

#End Region 'Conversion Operators

#Region "Element Operators"

    '/*[Category("Element Operators")]
    '[Title("First - Simple")]
    '[Description("This sample uses First to return the first matching element " &
    '             "where fist name is Brooke.")]*/
    Sub FirstSimple()
        ' <SnippetFirstSimple>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")

        Dim query = ( _
            From contact In contacts.AsEnumerable() _
            Where contact.Field(Of String)("FirstName") = "Brooke" _
            Select contact).First()

        Console.WriteLine("ContactID: " & query.Field(Of Integer)("ContactID"))
        Console.WriteLine("FirstName: " & query.Field(Of String)("FirstName"))
        Console.WriteLine("LastName: " & query.Field(Of String)("LastName"))
        ' </SnippetFirstSimple>
    End Sub

    '/*[Category("Element Operators")]
    '[Title("First - Condition")]
    '[Description("This example uses First to find the first email address that starts with 'caroline'.")]*/
    Sub FirstCondition_MQ()
        '<SnippetFirstCondition_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")

        Dim startsWith As DataRow = contacts.AsEnumerable(). _
            First(Function(contact) contact.Field(Of String) _
            ("EmailAddress").StartsWith("caroline"))

        Console.WriteLine("An email address starting with 'caroline': {0}", _
            startsWith.Field(Of String)("EmailAddress"))
        '</SnippetFirstCondition_MQ>
    End Sub

    '/*[Category("Element Operators")]
    '[Title("ElementAt")]
    '[Description("This sample uses ElementAt to retrieve the 5th address where PostalCode = "M4B 1V7" .")]*/
    Sub ElementAt()
        ' <SnippetElementAt>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim addresses As DataTable = ds.Tables("Address")

        Dim fifthAddress = ( _
            From address In addresses.AsEnumerable() _
            Where address.Field(Of String)("PostalCode") = "M4B 1V7" _
            Select address.Field(Of String)("AddressLine1")).ElementAt(5)

        Console.WriteLine("Fifth address where PostalCode = 'M4B 1V7': " & _
                fifthAddress)
        ' </SnippetElementAt>
    End Sub

#End Region 'Element Operators

#Region "Generation Operators"

    '//Range();      // Didn't use Range, couldn't get it to work.
    '[MDL] No Range method found in C# samples.

#End Region 'Generation Operators

#Region "Quantifier Operators"

    '/*[Category("Quantifiers")]
    '[Title("Any - Grouped")]
    '[Description("This example uses Any to return a price grouped by color, where list price is 0.")]*/
    Sub AnyGrouped_MQ()
        '<SnippetAnyGrouped_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim query = _
            From product In products.AsEnumerable() _
            Group product By color = product.Field(Of String)("Color") Into g = Group _
            Where g.Any(Function(product) product.Field(Of Decimal)("ListPrice") = 0) _
            Select New With {.Color = color, .Products = g}

        For Each productGroup In query
            Console.WriteLine(productGroup.Color)
            For Each product In productGroup.Products
                Console.WriteLine(vbTab & " {0}, {1}", _
                    product.Field(Of String)("Name"), _
                    product.Field(Of Decimal)("ListPrice"))
            Next
        Next
        '</SnippetAnyGrouped_MQ>
    End Sub


    '/*[Category("Quantifiers")]
    '[Title("All - Grouped")]
    '[Description("This example uses All to return all products where list price is greater than 0, grouped by color.")]*/
    Sub AllGrouped_MQ()
        '<SnippetAllGrouped_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim query = _
            From product In products.AsEnumerable() _
            Group product By color = product.Field(Of String)("Color") Into g = Group _
            Where g.All(Function(product) product.Field(Of Decimal)("ListPrice") > 0) _
            Select New With {.Color = color, .Products = g}

        For Each productGroup In query
            Console.WriteLine(productGroup.Color)
            For Each product In productGroup.Products
                Console.WriteLine(vbTab & " {0}, {1}", _
                    product.Field(Of String)("Name"), _
                    product.Field(Of Decimal)("ListPrice"))
            Next
        Next
        '</SnippetAllGrouped_MQ>
    End Sub

#End Region 'Quantifier Operators

#Region "Aggregate Operators"

    '/*[Category("Aggregate Operators")]
    '[Title("Aggregate")]
    '[Description("This example gets the first 5 contacts from the Contact table and builds a comma-delimited list of the last names.")]*/
    Sub Aggregate_MQ()
        '<SnippetAggregate_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As IEnumerable(Of DataRow) = _
            ds.Tables("Contact").AsEnumerable()

        Dim nameList As String = _
                contacts.Take(5).Select(Function(contact) contact.Field(Of String)("LastName")). _
                    Aggregate(Function(workingList, next1) workingList + "," + next1)

        Console.WriteLine(nameList)
        '</SnippetAggregate_MQ>
    End Sub

    '/*[Category("Aggregate Operators")]
    '[Title("Average2")]
    '[Description("This example uses Average to find the average list price of the products of each style.")]*/
    Sub Average2_MQ()
        '<SnippetAverage2_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As IEnumerable(Of DataRow) = _
            ds.Tables("Product").AsEnumerable()

        Dim query = _
            From product In products _
            Group product By style = product.Field(Of String)("Style") Into g = Group _
            Select New With _
                { _
                    .Style = style, _
                    .AverageListPrice = g.Average(Function(product) _
                            product.Field(Of Decimal)("ListPrice")) _
                }

        For Each product In query
            Console.WriteLine("Product style: {0} Average list price: {1}", _
                product.Style, product.AverageListPrice)
        Next
        '</SnippetAverage2_MQ>
    End Sub

    '/*[Category("Aggregate Operators")]
    '[Title("Average")]
    '[Description("This example uses Average to find the average list price of the products.")]*/
    Sub Average_MQ()
        '<SnippetAverage_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As IEnumerable(Of DataRow) = _
            ds.Tables("Product").AsEnumerable()

        Dim averageListPrice As Decimal = _
            products.Average(Function(product) product. _
                    Field(Of Decimal)("ListPrice"))

        Console.WriteLine("The average list price of all the products is $" & _
            averageListPrice)
        '</SnippetAverage_MQ>
    End Sub



    '/*[Category("Aggregate Operators")]
    '[Title("Count")]
    '[Description("This example uses Count to return the number of products in the Product table.")]*/
    Sub Count()
        ' <SnippetCount>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim numProducts = products.AsEnumerable().Count()

        Console.WriteLine("There are " & numProducts & " products.")
        ' </SnippetCount>
    End Sub

    '/*[Category("Aggregate Operators")]
    '[Title("Count - Grouped")]
    '[Description("This example groups products by color and uses Count to return the number of products " &
    '             "in each color group.")]*/
    Sub CountGrouped()
        '<SnippetCountGrouped>
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim query = _
            From product In products.AsEnumerable() _
            Group product By color = product.Field(Of String)("Color") Into g = Group _
            Select New With {.Color = color, .ProductCount = g.Count()}

        For Each product In query
            Console.WriteLine("Color = {0} " & vbTab & "ProductCount = {1}", _
                product.Color, _
                product.ProductCount)
        Next
        '</SnippetCountGrouped>
    End Sub

    '/*[Category("Aggregate Operators")]
    '[Title("Count - Nested")]
    '[Description("This sample uses Count to return a list of customer IDs and how many orders " &
    '             "each has.")]*/
    Sub CountNested()
        ' <SnippetCountNested>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")

        Dim query = _
            From contact In contacts.AsEnumerable() _
            Select New With _
            { _
                .ContactID = contact.Field(Of Integer)("ContactID"), _
                .OrderCount = contact.GetChildRows("SalesOrderContact").Count() _
            }

        For Each contact In query
            Console.Write("CustomerID = " & contact.ContactID)
            Console.WriteLine(vbTab & "OrderCount = " & contact.OrderCount)
        Next
        ' </SnippetCountNested>
    End Sub



    '/*[Category("Aggregate Operators")]
    '[Title("Long Count Simple")]
    '[Description("Gets the count as a long")]*/
    Sub LongCountSimple()
        ' <SnippetLongCountSimple>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")

        Dim numberOfContacts = contacts.AsEnumerable().LongCount()

        Console.WriteLine("There are {0} Contacts", numberOfContacts)
        ' </SnippetLongCountSimple>
    End Sub

    '/*[Category("Aggregate Operators")]
    '[Title("Sum - Projection")]
    '[Description("This example uses Sum to get the total number of order quantities in the SalesOrderDetail table.")]*/
    Sub SumProjection_MQ()
        '<SnippetSumProjection>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderDetail")

        Dim totalOrderQty As Double = orders.AsEnumerable(). _
            Sum(Function(o) o.Field(Of Int16)("OrderQty"))
        Console.WriteLine("There are a total of {0} OrderQty.", _
            totalOrderQty)
        '</SnippetSumProjection>
    End Sub

    '/*[Category("Aggregate Operators")]
    '[Title("Sum - Grouped")]
    '[Description("This example uses Sum to get the total due for each contact ID.")]*/
    Sub SumGrouped_MQ()
        '<SnippetSumGrouped_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = _
            From order In orders.AsEnumerable() _
            Group order By contactID = order.Field(Of Int32)("ContactID") Into g = Group _
            Select New With _
               { _
                   .Category = contactID, _
                   .TotalDue = g.Sum(Function(order) order. _
                        Field(Of Decimal)("TotalDue")) _
               }

        For Each order In query
            Console.WriteLine("ContactID = {0} " & vbTab & "TotalDue sum = {1}", _
                order.Category, order.TotalDue)
        Next
        '</SnippetSumGrouped_MQ>
    End Sub

    '/*[Category("Aggregate Operators")]
    '[Title("Min - Projection")]
    '[Description("This example uses Min to get the smallest total due.")]*/
    Sub MinProjection_MQ()
        '<SnippetMinProjection_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim smallestTotalDue As Decimal = orders.AsEnumerable(). _
            Min(Function(totalDue) totalDue.Field(Of Decimal)("TotalDue"))

        Console.WriteLine("The smallest TotalDue is {0}.", smallestTotalDue)
        '</SnippetMinProjection_MQ>
    End Sub

    '/*[Category("Aggregate Operators")]
    '[Title("Min - Grouped")]
    '[Description("This example uses Min to get the smallest total due for each contact ID.")]*/
    Sub MinGrouped_MQ()
        '<SnippetMinGrouped_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = _
            From order In orders.AsEnumerable() _
            Group order By contactID = order.Field(Of Int32)("ContactID") Into g = Group _
            Select New With _
            { _
               .Category = contactID, _
               .smallestTotalDue = g.Min(Function(order) _
                        order.Field(Of Decimal)("TotalDue")) _
            }

        For Each order In query
            Console.WriteLine("ContactID = {0} " & vbTab & _
                "Minimum TotalDue = {1}", order.Category, order.smallestTotalDue)
        Next
        '</SnippetMinGrouped_MQ>
    End Sub

    '/*[Category("Aggregate Operators")]
    '[Title("Min - Elements")]
    '[Description("This example uses Min to get the orders with the smallest total due for each contact.")]*/
    Sub MinElements_MQ()
        '<SnippetMinElements_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = _
            From order In orders.AsEnumerable() _
            Group order By contactID = order.Field(Of Int32)("ContactID") Into g = Group _
            Let minTotalDue = g.Min(Function(order) order.Field(Of Decimal)("TotalDue")) _
            Select New With _
            { _
               .Category = contactID, _
               .smallestTotalDue = g.Where(Function(order) order. _
                    Field(Of Decimal)("TotalDue") = minTotalDue) _
            }

        For Each orderGroup In query
            Console.WriteLine("ContactID: " & orderGroup.Category)
            For Each order In orderGroup.smallestTotalDue
                Console.WriteLine("Minimum TotalDue {0} for SalesOrderID {1} ", _
                    order.Field(Of Decimal)("TotalDue"), _
                    order.Field(Of Int32)("SalesOrderID"))
            Next
            Console.WriteLine("")
        Next
        '</SnippetMinElements_MQ>
    End Sub

    '/*[Category("Aggregate Operators")]
    '[Title("Average - Projection")]
    '[Description("This example uses Average to find the average total due.")]*/
    Sub AverageProjection_MQ()
        '<SnippetAverageProjection_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim averageTotalDue As Decimal = orders.AsEnumerable(). _
            Average(Function(order) order.Field(Of Decimal)("TotalDue"))
        Console.WriteLine("The average TotalDue is {0}.", _
            averageTotalDue)
        '</SnippetAverageProjection_MQ>
    End Sub

    '/*[Category("Aggregate Operators")]
    '[Title("Average - Grouped")]
    '[Description("This example uses Average to get the average total due for each contact ID.")]*/
    Sub AverageGrouped_MQ()
        '<SnippetAverageGrouped_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = _
            From order In orders.AsEnumerable() _
            Group order By contactID = order.Field(Of Int32)("ContactID") Into g = Group _
            Select New With _
            { _
                .Category = contactID, _
                .averageTotalDue = g.Average(Function(order) order. _
                        Field(Of Decimal)("TotalDue")) _
            }

        For Each order In query
            Console.WriteLine("ContactID = {0} " & vbTab & _
                " Average TotalDue = {1}", order.Category, _
                order.averageTotalDue)
        Next
        '</SnippetAverageGrouped_MQ>
    End Sub

    '/*[Category("Aggregate Operators")]
    '[Title("Average - Elements")]
    '[Description("This example uses Average to get the orders with the average TotalDue for each contact.")]*/
    Sub AverageElements_MQ()
        '<SnippetAverageElements_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = _
            From order In orders.AsEnumerable() _
            Group order By contactID = order.Field(Of Int32)("ContactID") Into g = Group _
            Let averageTotalDue = g.Average(Function(order) order.Field(Of Decimal)("TotalDue")) _
            Select New With _
            { _
                .Category = contactID, _
                .CheapestProducts = g.Where(Function(order) order. _
                        Field(Of Decimal)("TotalDue") = averageTotalDue) _
            }

        For Each orderGroup In query
            Console.WriteLine("ContactID: " & orderGroup.Category)
            For Each order In orderGroup.CheapestProducts
                Console.WriteLine("Average total due for SalesOrderID {1} is: {0}", _
                    order.Field(Of Decimal)("TotalDue"), _
                    order.Field(Of Int32)("SalesOrderID"))
            Next
            Console.WriteLine("")
        Next
        '</SnippetAverageElements_MQ>
    End Sub

    '/*[Category("Aggregate Operators")]
    '[Title("Max - Projection")]
    '[Description("This example uses Max to get the largest total due.")]*/
    Sub MaxProjection_MQ()
        '<SnippetMaxProjection_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim maxTotalDue As Decimal = orders.AsEnumerable(). _
            Max(Function(w) w.Field(Of Decimal)("TotalDue"))
        Console.WriteLine("The maximum TotalDue is {0}.", maxTotalDue)
        '</SnippetMaxProjection_MQ>
    End Sub

    '/*[Category("Aggregate Operators")]
    '[Title("Max - Grouped")]
    '[Description("This example uses Max to get the largest total due for each contact ID.")]*/
    Sub MaxGrouped_MQ()
        '<SnippetMaxGrouped_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = _
           From order In orders.AsEnumerable() _
           Group order By contactID = order.Field(Of Int32)("ContactID") Into g = Group _
           Select New With _
           { _
               .Category = contactID, _
               .maxTotalDue = _
                   g.Max(Function(order) order.Field(Of Decimal)("TotalDue")) _
           }
        For Each order In query
            Console.WriteLine("ContactID = {0} " & vbTab & _
                " Maximum TotalDue = {1}", _
                order.Category, order.maxTotalDue)
        Next
        '</SnippetMaxGrouped_MQ>
    End Sub

    '/*[Category("Aggregate Operators")]
    '[Title("Max - Elements")]
    '[Description("This example uses Max to get the orders with the largest TotalDue for each contact ID.")]*/
    Sub MaxElements_MQ()
        '<SnippetMaxElements_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = _
            From order In orders.AsEnumerable() _
            Group order By contactID = order.Field(Of Int32)("ContactID") Into g = Group _
            Let maxTotalDue = g.Max(Function(order) order.Field(Of Decimal)("TotalDue")) _
            Select New With _
            { _
                .Category = contactID, _
                .CheapestProducts = _
                    g.Where(Function(order) order. _
                            Field(Of Decimal)("TotalDue") = maxTotalDue) _
            }

        For Each orderGroup In query
            Console.WriteLine("ContactID: " & orderGroup.Category)
            For Each order In orderGroup.CheapestProducts
                Console.WriteLine("MaxTotalDue {0} for SalesOrderID {1} ", _
                    order.Field(Of Decimal)("TotalDue"), _
                    order.Field(Of Int32)("SalesOrderID"))
            Next
        Next
        '</SnippetMaxElements_MQ>
    End Sub


#End Region 'Aggregate Operators

#Region "Join Operators"

    '/*[Category("Join Operators")]
    '[Title("Join ")]
    '[Description("This example performs a join over the SalesOrderHeader and SalesOrderDetail tables to get online orders from the month of August.")]*/
    Sub Join()
        ' <SnippetJoin>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderHeader")
        Dim details As DataTable = ds.Tables("SalesOrderDetail")


        Dim query = _
            From order In orders.AsEnumerable() _
            Join detail In details.AsEnumerable() _
            On order.Field(Of Integer)("SalesOrderID") Equals _
                    detail.Field(Of Integer)("SalesOrderID") _
            Where order.Field(Of Boolean)("OnlineOrderFlag") = True And _
                    order.Field(Of DateTime)("OrderDate").Month = 8 _
            Select New With _
            { _
                .SalesOrderID = order.Field(Of Integer)("SalesOrderID"), _
                .SalesOrderDetailID = detail.Field(Of Integer)("SalesOrderDetailID"), _
                .OrderDate = order.Field(Of DateTime)("OrderDate"), _
                .ProductID = detail.Field(Of Integer)("ProductID") _
            }

        For Each order In query
            Console.WriteLine(order.SalesOrderID & vbTab & _
                order.SalesOrderDetailID & vbTab & _
                order.OrderDate & vbTab & _
                order.ProductID)
        Next
        ' </SnippetJoin>
    End Sub

    '/*[Category("Join Operators")]
    '[Title("Join - simple")]
    '[Description("This example performs a join over the Contact and SalesOrderHeader tables.")]*/
    Sub JoinSimple_MQ()
        '<SnippetJoinSimple_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")
        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = _
            contacts.AsEnumerable().Join(orders.AsEnumerable(), _
            Function(order) order.Field(Of Int32)("ContactID"), _
            Function(contact) contact.Field(Of Int32)("ContactID"), _
            Function(contact, order) New With _
                { _
                    .ContactID = contact.Field(Of Int32)("ContactID"), _
                    .SalesOrderID = order.Field(Of Int32)("SalesOrderID"), _
                    .FirstName = contact.Field(Of String)("FirstName"), _
                    .Lastname = contact.Field(Of String)("Lastname"), _
                    .TotalDue = order.Field(Of Decimal)("TotalDue") _
                })

        For Each contact_order In query
            Console.WriteLine("ContactID: {0} " _
                            & "SalesOrderID: {1} " _
                            & "FirstName: {2} " _
                            & "Lastname: {3} " _
                            & "TotalDue: {4}", _
                contact_order.ContactID, _
                contact_order.SalesOrderID, _
                contact_order.FirstName, _
                contact_order.Lastname, _
                contact_order.TotalDue)
        Next
        '</SnippetJoinSimple_MQ>
    End Sub

    '/*[Category("Join Operators")]
    '[Title("Join with grouped results")]
    '[Description("This example performs a join over the Contact and SalesOrderHeader tables, grouping the results by contact ID.")]*/
    Sub JoinWithGroupedResults_MQ()
        '<SnippetJoinWithGroupedResults_MQ>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")
        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = _
            contacts.AsEnumerable().Join(orders.AsEnumerable(), _
            Function(order) order.Field(Of Int32)("ContactID"), _
            Function(contact) contact.Field(Of Int32)("ContactID"), _
                Function(contact, order) New With _
                { _
                    .ContactID = contact.Field(Of Int32)("ContactID"), _
                    .SalesOrderID = order.Field(Of Int32)("SalesOrderID"), _
                    .FirstName = contact.Field(Of String)("FirstName"), _
                    .Lastname = contact.Field(Of String)("Lastname"), _
                    .TotalDue = order.Field(Of Decimal)("TotalDue") _
                }) _
                .GroupBy(Function(record) record.ContactID)

        For Each group In query
            For Each contact_order In group
                Console.WriteLine("ContactID: {0} " _
                                & "SalesOrderID: {1} " _
                                & "FirstName: {2} " _
                                & "Lastname: {3} " _
                                & "TotalDue: {4}", _
                    contact_order.ContactID, _
                    contact_order.SalesOrderID, _
                    contact_order.FirstName, _
                    contact_order.Lastname, _
                    contact_order.TotalDue)
            Next
        Next
        '</SnippetJoinWithGroupedResults_MQ>
    End Sub

    '/*[Category("Join Operators")]
    '[Title("Group Join")]
    '[Description("This example performs a group join over the Contact and SalesOrderHeader tables. " &
    '     "A group join is the equivalent of a left outer join, which returns each element of the first (left) data source, " &
    '      "even if no correlated elements are in the other data source.")]*/
    Sub GroupJoin()
        ' <SnippetGroupJoin>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")
        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = _
            From contact In contacts.AsEnumerable(), order In orders.AsEnumerable() _
            Where (contact.Field(Of Integer)("ContactID") = _
                order.Field(Of Integer)("ContactID")) _
            Select New With _
                { _
                    .ContactID = contact.Field(Of Integer)("ContactID"), _
                    .SalesOrderID = order.Field(Of Integer)("SalesOrderID"), _
                    .FirstName = contact.Field(Of String)("FirstName"), _
                    .Lastname = contact.Field(Of String)("Lastname"), _
                    .TotalDue = order.Field(Of Decimal)("TotalDue") _
                }

        For Each contact_order In query
            Console.Write("ContactID: " & contact_order.ContactID)
            Console.Write(" SalesOrderID: " & contact_order.SalesOrderID)
            Console.Write(" FirstName: " & contact_order.FirstName)
            Console.Write(" Lastname: " & contact_order.Lastname)
            Console.WriteLine(" TotalDue: " & contact_order.TotalDue)
        Next
        ' </SnippetGroupJoin>
    End Sub

    '/*[Category("Join Operators")]
    '[Title("GroupJoin2")]
    '[Description("This example performs a GroupJoin over the SalesOrderHeader and SalesOrderDetail tables to find the number of orders per customer. " +
    '  "A group join is the equivalent of a left outer join, which returns each element of the first (left) data source, " +
    '  "even if no correlated elements are in the other data source.")]*/
    Sub GroupJoin2()
        '<SnippetGroupJoin2>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders = ds.Tables("SalesOrderHeader").AsEnumerable()
        Dim details = ds.Tables("SalesOrderDetail").AsEnumerable()

        Dim query = _
                From order In orders _
                Group Join detail In details _
                    On order.Field(Of Integer)("SalesOrderID") _
                    Equals detail.Field(Of Integer)("SalesOrderID") Into ords = Group _
                Select New With _
                    { _
                        .CustomerID = order.Field(Of Integer)("SalesOrderID"), _
                        .ords = ords.Count() _
                    }

        For Each order In query
            Console.WriteLine("CustomerID: {0}  Orders Count: {1}", _
                order.CustomerID, order.ords)
        Next
        '</SnippetGroupJoin2>
    End Sub

#End Region 'Join Operators


#Region "DataSet Loading examples"

    '/*[Category("DataSet Loading examples")]
    '[Title("Loading query results into a DataTable")]
    '[Description("Create and load a DataTable From a sequence")]*/
    Sub LoadingQueryResultsIntoDataTable()
        ' <SnippetLoadingQueryResultsIntoDataTable>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contacts As DataTable = ds.Tables("Contact")
        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        Dim query = _
            From contact In contacts.AsEnumerable() _
            From order In orders.AsEnumerable() _
            Where (contact.Field(Of Integer)("ContactID") = order.Field(Of Integer)("ContactID")) And _
                  (order.Field(Of Boolean)("OnlineOrderFlag") = True) _
            Select New With { _
                       .FirstName = contact.Field(Of String)("FirstName"), _
                       .LastName = contact.Field(Of String)("LastName"), _
                       .OrderDate = order.Field(Of DateTime)("OrderDate"), _
                       .TotalDue = order.Field(Of Decimal)("TotalDue") _
            }

        Dim OnlineOrders = New DataTable("OnlineOrders")
        OnlineOrders.Locale = CultureInfo.InvariantCulture
        OnlineOrders.Columns.Add("FirstName", GetType(String))
        OnlineOrders.Columns.Add("LastName", GetType(String))
        OnlineOrders.Columns.Add("OrderDate", GetType(DateTime))
        OnlineOrders.Columns.Add("TotalDue", GetType(Decimal))

        Dim query10 = query.Take(10)


        For Each result In query10
            OnlineOrders.Rows.Add(New Object() { _
                                      result.FirstName, _
                                      result.LastName, _
                                      result.OrderDate, _
                                      result.TotalDue})
        Next


        For Each row In OnlineOrders.Rows
            Console.WriteLine("First Name: {0}", row("FirstName"))
            Console.WriteLine("Last Name:  {0}", row("LastName"))
            Console.WriteLine("Order Date: {0}", row("OrderDate"))
            Console.WriteLine("Total Due:  ${0}", row("TotalDue"))
            Console.WriteLine("")
        Next
        ' </SnippetLoadingQueryResultsIntoDataTable>
    End Sub

    '/*[Category("DataSet Loading examples")]
    '[Title("Using CopyToDataTable")]
    '[Description("Load a DataTable with query results")]*/
    Sub LoadDataTableWithQueryResults()

        ' <SnippetLoadDataTableWithQueryResults>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim contactTable As DataTable = ds.Tables("Contact")

        Dim query = _
            From contact In contactTable.AsEnumerable() _
            Where contact.Field(Of String)("Title") = "Ms." _
                    And contact.Field(Of String)("FirstName") = "Carla" _
            Select contact

        Dim contacts = query.CopyToDataTable().AsEnumerable()

        For Each contact In contacts
            Console.Write("ID: " & contact.Field(Of Integer)("ContactID"))
            Console.WriteLine(" Name: " & contact.Field(Of String)("LastName") & _
                              ", " & contact.Field(Of String)("FirstName"))
        Next
        ' </SnippetLoadDataTableWithQueryResults>
    End Sub

#End Region 'DataSet Loading examples

#Region "DataRowComparer examples"

    Sub CompareDifferentDataRows()
        ' <SnippetCompareDifferentRows>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        ' Get two rows from the SalesOrderHeader table.
        Dim table As DataTable = ds.Tables("SalesOrderHeader")
        Dim left = table.Rows(0)
        Dim right = table.Rows(1)

        ' Compare the two different rows.
        Dim comparer As IEqualityComparer(Of DataRow) = DataRowComparer.Default
        Dim bEqual = comparer.Equals(left, right)

        If (bEqual = True) Then
            Console.WriteLine("Two rows are equal")
        Else
            Console.WriteLine("Two rows are not equal")
        End If

        ' Output the hash codes of the two rows.
        Console.WriteLine("The hashcodes for the two rows are {0}, {1}", _
            comparer.GetHashCode(left), _
            comparer.GetHashCode(right))

        ' </SnippetCompareDifferentRows>
    End Sub

    Sub CompareEqualDataRows()
        ' <SnippetCompareEqualDataRows>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        'Get a row from the SalesOrderHeader table.
        Dim table As DataTable = ds.Tables("SalesOrderHeader")
        Dim left = table.Rows(0)
        Dim right = table.Rows(0)

        'Compare two equal rows.
        Dim comparer As IEqualityComparer(Of DataRow) = DataRowComparer.Default
        Dim bEqual = comparer.Equals(left, right)

        If (bEqual = True) Then
            Console.WriteLine("Two rows are equal")
        Else
            Console.WriteLine("Two rows are not equal")
        End If

        ' Get the hash codes of the two rows.
        Console.WriteLine("The hashcodes for the two rows are {0}, {1}", _
            comparer.GetHashCode(left), _
            comparer.GetHashCode(right))

        ' </SnippetCompareEqualDataRows>
    End Sub

    '/*[Category("DataRowComparer examples")]
    ' [Title("Compare null data row")]
    ' [Description("This example compares a data row with a null value.")]*/
    Sub CompareNullDataRows()
        ' <SnippetCompareNullDataRows>
        ' Compare with null.
        Dim table = New DataTable()
        Dim dr = table.NewRow()

        Dim Comparer As IEqualityComparer(Of DataRow) = DataRowComparer.Default

        Try
            Comparer.Equals(Nothing, dr)
        Catch e As ArgumentNullException
            Console.WriteLine("ArgumentNullException is thrown if parameter is null")
        End Try
        ' </SnippetCompareNullDataRows>
    End Sub

#End Region 'DataRowComparer examples

#Region "CopyToDataTable examples"

    Sub CopyToDataTable1()
        Dim dataGridView As DataGridView = New DataGridView()
        Dim bindingSource As BindingSource = New BindingSource()
        ' <SnippetCopyToDataTable1>
        ' Bind the System.Windows.Forms.DataGridView object
        ' to the System.Windows.Forms.BindingSource object.
        dataGridView.DataSource = bindingSource

        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderHeader")

        ' Query the SalesOrderHeader table for orders placed
        '  after August 8, 2001.
        Dim query = _
            From order In orders.AsEnumerable() _
            Where order.Field(Of DateTime)("OrderDate") > New DateTime(2001, 8, 1) _
            Select order

        ' Create a table from the query.
        Dim boundTable As DataTable = query.CopyToDataTable()

        ' Bind the table to a System.Windows.Forms.BindingSource object,
        ' which acts as a proxy for a System.Windows.Forms.DataGridView object.
        bindingSource.DataSource = boundTable
        ' </SnippetCopyToDataTable1>

        For Each row As DataRow In boundTable.Rows

            Console.WriteLine(row("SalesOrderNumber") & " " & row("OrderDate"))
        Next

    End Sub

#End Region 'CopyToDataTable examples

#Region "Misc"
    Sub Composing()
        ' <SnippetComposing>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim products As DataTable = ds.Tables("Product")

        Dim productsQuery = From product In products.AsEnumerable() _
                            Select product

        Dim largeProducts = _
            productsQuery.Where(Function(p) p.Field(Of String)("Size") = "L")

        Console.WriteLine("Products of size 'L':")
        For Each product In largeProducts
            Console.WriteLine(product.Field(Of String)("Name"))
        Next

        ' </SnippetComposing>

    End Sub

#End Region

#Region "Other stuff"

    Sub OrderBy()
        ' <SnippetOrderBy>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderDetail")

        ' Order by unit price
        Dim query = _
            From order In orders.AsEnumerable() _
            Where (order.Field(Of Short)("OrderQty") > 2) And _
                  (order.Field(Of Short)("OrderQty") < 6) _
            Order By order.Field(Of Decimal)("UnitPrice") _
            Select New With _
               { _
                .SalesOrderID = order.Field(Of Integer)("SalesOrderID"), _
                .OrderQty = order.Field(Of Short)("OrderQty"), _
                .UnitPrice = order.Field(Of Decimal)("UnitPrice") _
               }

        For Each order In query
            Console.Write("OrderID: " & order.SalesOrderID)
            Console.Write(" OrderQty: " & order.OrderQty)
            Console.WriteLine(" UnitPrice: $ " & order.UnitPrice)
        Next
        ' </SnippetOrderBy>
    End Sub

    Sub OrderByDescending()
        ' <SnippetOrderByDescending>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderDetail")

        ' Order by unit price
        Dim query = _
            From order In orders.AsEnumerable() _
            Where (order.Field(Of Short)("OrderQty") > 2) And _
                  (order.Field(Of Short)("OrderQty") < 6) _
            Order By order.Field(Of Decimal)("UnitPrice") Descending _
            Select New With _
                   {.SalesOrderID = order.Field(Of Integer)("SalesOrderID"), _
                    .OrderQty = order.Field(Of Short)("OrderQty"), _
                    .UnitPrice = order.Field(Of Decimal)("UnitPrice") _
                   }

        For Each order In query
            Console.Write("OrderID: " & order.SalesOrderID)
            Console.Write(" OrderQty: " & order.OrderQty)
            Console.WriteLine(" UnitPrice: $ " & order.UnitPrice)
        Next
        ' </SnippetOrderByDescending>
    End Sub

    '[MDL - Told not to worry about these.]
    '//Sum();
    '//GroupBy();


#End Region 'Other stuff

End Module
