'<snippetUsingSerialization> 
'<snippetUsing> 
'<snippetUsingEvents> 
Imports System.ComponentModel
Imports System.Data.Common
Imports System.Data.EntityClient
Imports System.Data.Metadata.Edm
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
'</snippetUsingEvents> 
Imports System.Data.SqlClient
'</snippetUsing> 
Imports System.IO
'</snippetUsingSerialization> 
Imports System.Xml.Serialization

Class Source1
    '<snippetExecuteStoreCommandAndQueryForNewEntity> 
    Public Class DepartmentInfo
        Private _startDate As DateTime
        Private _name As String
        Private _departmentID As Int32

        Public Property DepartmentID() As Int32
            Get
                Return _departmentID
            End Get
            Set(ByVal value As Int32)
                _departmentID = value
            End Set
        End Property
        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Public Property StartDate() As DateTime
            Get
                Return _startDate
            End Get
            Set(ByVal value As DateTime)
                _startDate = value
            End Set
        End Property
    End Class

    Public Shared Sub ExecuteStoreCommands()
        Using context As New SchoolEntities()

            Dim DepartmentID As Integer = 21
            ' Insert the row in the Department table. Use the parameter substitution pattern. 
            Dim rowsAffected As Integer = context.ExecuteStoreCommand("insert Department values ({0}, {1}, {2}, {3}, {4})", _
                                                                      DepartmentID, "Engineering", 350000.0R, "2009-09-01", 2)
            Console.WriteLine("Number of affected rows: {0}", rowsAffected)

            ' Get the DepartmentTest object. 
            Dim department As DepartmentInfo = context.ExecuteStoreQuery(Of DepartmentInfo) _
                                               ("select * from Department where DepartmentID= {0}", _
                                               DepartmentID).FirstOrDefault()

            Console.WriteLine("ID: {0}, Name: {1} ", _
                              department.DepartmentID, department.Name)

            rowsAffected = context.ExecuteStoreCommand("delete from Department where DepartmentID = {0}", _
                                                       DepartmentID)
            Console.WriteLine("Number of affected rows: {0}", _
                              rowsAffected)
        End Using
    End Sub
    '</snippetExecuteStoreCommandAndQueryForNewEntity> 

    Public Shared Sub CallCustomMethod()
        Console.WriteLine("Starting method 'CallCustomMethod'")
        '<snippetCallCustomMethod> 
        Dim orderId As Integer = 43662

        Using context As New AdventureWorksEntities()
            ' Return an order and its items. 
            Dim order As SalesOrderHeader = context.SalesOrderHeaders.Include("SalesOrderDetails") _
                                            .Where("it.SalesOrderID = @orderId", _
                                                   New ObjectParameter("orderId", orderId)).First()

            Console.WriteLine("The original order total was: " & order.TotalDue)

            ' Update the order status. 
            order.Status = 1

            ' Increase the quantity of the first item, if one exists. 
            If order.SalesOrderDetails.Count > 0 Then
                order.SalesOrderDetails.First().OrderQty += 1
            End If

            ' Increase the shipping amount by 10%. 
            order.Freight = Decimal.Round(order.Freight * CDec(1.1), 4)

            ' Call the custom method to update the total. 
            order.UpdateOrderTotal()

            Console.WriteLine("The calculated order total is: " & order.TotalDue)

            ' Save changes in the object context to the database. 
            Dim changes As Integer = context.SaveChanges()

            ' Refresh the order to get the computed total from the store. 
            context.Refresh(RefreshMode.StoreWins, order)

            Console.WriteLine("The store generated order total is: " & order.TotalDue)
        End Using
        '</snippetCallCustomMethod> 
    End Sub


#Region "MrefMethods"

    Public Shared Sub ContextClass()
        Console.WriteLine("Starting method 'ContextClass'")
        '<snippetObjectContext> 
        ' Create the ObjectContext. 
        Dim context As New ObjectContext("name=AdventureWorksEntities")

        ' Set the DefaultContainerName for the ObjectContext.
        ' When DefaultContainerName is set, the Entity Framework only
        ' searches for the type in the specified container. 
        ' Note that if a type is defined only once in the metadata workspace
        ' you do not have to set the DefaultContainerName.
        context.DefaultContainerName = "AdventureWorksEntities"

        Dim query As ObjectSet(Of Product) = context.CreateObjectSet(Of Product)()

        ' Iterate through the collection of Products. 
        For Each result As Product In query
            Console.WriteLine("Product Name: {0}", result.Name)
        Next
        '</snippetObjectContext> 
    End Sub

    Public Shared Sub ContextClass2()
        Console.WriteLine("Starting method 'ContextClass'")
        '<snippetObjectContext2> 
        ' Create the ObjectContext. 
        Dim context As New ObjectContext("name=AdventureWorksEntities")

        Dim query As ObjectSet(Of Product) = context.CreateObjectSet(Of Product)()

        ' Iterate through the collection of Products. 
        For Each result As Product In query
            Console.WriteLine("Product Name: {0}", result.Name)
        Next
        '</snippetObjectContext2> 
    End Sub

    Public Shared Sub ObjectQueryResult_GetEnumerator_Dispose()
        Console.WriteLine("Starting method 'QueryResult'")
        '<snippetQueryResult> 
        Using context As New AdventureWorksEntities()
            Dim query As ObjectSet(Of Product) = context.Products
            Dim queryResults As ObjectResult(Of Product) = Nothing

            Dim enumerator As System.Collections.IEnumerator = Nothing
            Try
                queryResults = query.Execute(MergeOption.AppendOnly)

                ' Get the enumerator. 
                enumerator = DirectCast(queryResults, System.Collections.IEnumerable).GetEnumerator()

                ' Iterate through the query results. 
                While enumerator.MoveNext()
                    Dim product As Product = DirectCast(enumerator.Current, Product)
                    Console.WriteLine("{0}", product.Name)
                End While
                ' Dispose the enumerator 
                DirectCast(enumerator, IDisposable).Dispose()
            Finally
                ' Dispose the query results and the enumerator. 
                If queryResults IsNot Nothing Then
                    queryResults.Dispose()
                End If
                If enumerator IsNot Nothing Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
        End Using
        '</snippetQueryResult> 
    End Sub
    Public Shared Sub ObjectStateEntry_CurrentValueGetModifiedPropertiesEntity()
        Console.WriteLine("Starting method 'ObjectStateEntry_CurrentValueGetModifiedPropertiesEntity'")
        '<snippetObjectStateEntry_GetModifiedProperties> 
        Dim orderId As Integer = 43680

        Using context As New AdventureWorksEntities()
            Dim order = (From o In context.SalesOrderHeaders
                         Where o.SalesOrderID = orderId
                         Select o).First()

            ' Get ObjectStateEntry from EntityKey. 
            Dim stateEntry As ObjectStateEntry = _
                context.ObjectStateManager.GetObjectStateEntry(DirectCast(order, IEntityWithKey).EntityKey)

            'Get the current value of SalesOrderHeader.PurchaseOrderNumber. 
            Dim rec1 As CurrentValueRecord = stateEntry.CurrentValues
            Dim oldPurchaseOrderNumber As String = _
                DirectCast(rec1.GetValue(rec1.GetOrdinal("PurchaseOrderNumber")), String)

            'Change the value. 
            order.PurchaseOrderNumber = "12345"
            Dim newPurchaseOrderNumber As String = _
                DirectCast(rec1.GetValue(rec1.GetOrdinal("PurchaseOrderNumber")), String)

            ' Get the modified properties. 
            Dim modifiedFields As IEnumerable(Of String) = stateEntry.GetModifiedProperties()
            For Each s As String In modifiedFields
                Console.WriteLine("Modified field name: {0}", s)
                Console.WriteLine("Old Value: {1}", oldPurchaseOrderNumber)
                Console.WriteLine("New Value: {2}", newPurchaseOrderNumber)
            Next

            ' Get the Entity that is associated with this ObjectStateEntry. 
            Dim associatedEnity As SalesOrderHeader = DirectCast(stateEntry.Entity, SalesOrderHeader)
            Console.WriteLine("Associated Enity's ID: {0}", associatedEnity.SalesOrderID)
        End Using
        '</snippetObjectStateEntry_GetModifiedProperties> 
    End Sub
    Public Shared Sub ObjectStateManager_TryGetObjectStateEntry()
        Console.WriteLine("Starting method 'ObjectStateManager_TryGetObjectStateEntry'")
        '<snippetObjectStateManager> 
        Dim orderId As Integer = 43680

        Using context As New AdventureWorksEntities()
            Dim objectStateManager As ObjectStateManager = context.ObjectStateManager
            Dim stateEntry As ObjectStateEntry = Nothing

            Dim order = (From o In context.SalesOrderHeaders
                         Where o.SalesOrderID = orderId
                         Select o).First()

            ' Attempts to retrieve ObjectStateEntry for the given EntityKey. 
            Dim isPresent As Boolean = objectStateManager.TryGetObjectStateEntry(DirectCast(order, IEntityWithKey).EntityKey, stateEntry)
            If isPresent Then
                Console.WriteLine("The entity was found")
            End If
        End Using
        '</snippetObjectStateManager> 
    End Sub
    Public Shared Sub ObjectQuery_GetResultType()
        Console.WriteLine("Starting method 'ObjectQuery_GetResultType'")
        '<snippetGetResultType> 
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE product " & "FROM AdventureWorksEntities.Products AS product"
            Dim query As New ObjectQuery(Of DbDataRecord)(queryString, context)

            Dim type As TypeUsage = query.GetResultType()
            If TypeOf type.EdmType Is RowType Then
                Dim row As RowType = TryCast(type.EdmType, RowType)
                For Each column As EdmProperty In row.Properties
                    Console.WriteLine("{0}", column.Name)
                Next
            End If
        End Using
        '</snippetGetResultType> 
    End Sub
    Public Shared Sub ObjectQuery_Execute()
        Console.WriteLine("Starting method 'ObjectQuery_Execute'")
        '<snippetObjectQuery_Execute> 
        Using context As New AdventureWorksEntities()
            Dim query As ObjectSet(Of Product) = context.Products

            ' Execute the query and get the ObjectResult. 
            Dim queryResult As ObjectResult(Of Product) = query.Execute(MergeOption.AppendOnly)
            ' Iterate through the collection of Product items. 
            For Each result As Product In queryResult
                Console.WriteLine("{0}", result.Name)
            Next
        End Using
        '</snippetObjectQuery_Execute> 
    End Sub
    Public Shared Sub ObjectQuery_ToTraceStringEsql()
        Console.WriteLine("Starting method 'ObjectQuery_ToTraceStringEsql'")
        '<snippetObjectQuery_ToTraceStringEsql> 
        Dim productID = 900

        Using context As New AdventureWorksEntities()
            ' Define the Entity SQL query string. 
            Dim queryString As String = "SELECT VALUE product FROM AdventureWorksEntities.Products AS product " & _
                " WHERE product.ProductID = @productID"

            ' Define the object query with the query string. 
            Dim productQuery As New ObjectQuery(Of Product)(queryString, context, MergeOption.AppendOnly)
            productQuery.Parameters.Add(New ObjectParameter("productID", productID))

            ' Write the store commands for the query. 
            Console.WriteLine(productQuery.ToTraceString())
        End Using
        '</snippetObjectQuery_ToTraceStringEsql> 
    End Sub
    Public Shared Sub ObjectQuery_ToTraceStringLinq()
        Console.WriteLine("Starting method 'ObjectQuery_ToTraceStringLinq'")
        '<snippetObjectQuery_ToTraceStringLinq> 
        Dim productID = 900
        Using context As New AdventureWorksEntities()
            ' Define an ObjectSet to use with the LINQ query. 
            Dim products As ObjectSet(Of Product) = context.Products

            ' Define a LINQ query that returns a selected product. 
            Dim result = From product In products _
                         Where product.ProductID = productID _
                         Select product

            ' Cast the inferred type var to an ObjectQuery 
            ' and then write the store commands for the query. 
            Console.WriteLine(DirectCast(result, ObjectQuery(Of Product)).ToTraceString())
        End Using
        '</snippetObjectQuery_ToTraceStringLinq> 
    End Sub
    Public Shared Sub ObjectQuery_ToTraceString()
        Console.WriteLine("Starting method 'ObjectQuery_ToTraceString'")
        '<snippetObjectQuery_ToTraceString> 
        Dim productID = 900
        Using context As New AdventureWorksEntities()
            ' Define the object query for the specific product. 
            Dim productQuery As ObjectQuery(Of Product) = context.Products.Where("it.ProductID = @productID")
            productQuery.Parameters.Add(New ObjectParameter("productID", productID))

            ' Write the store commands for the query. 
            Console.WriteLine(productQuery.ToTraceString())
        End Using
        '</snippetObjectQuery_ToTraceString> 
    End Sub

    Public Shared Sub ObjectQuery_First()
        Console.WriteLine("Starting method 'ObjectQuery_First'")
        '<snippetObjectQuery_First> 
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE product FROM AdventureWorksEntities.Products AS product"

            Dim productQuery1 As New ObjectQuery(Of Product)(queryString, context, MergeOption.NoTracking)

            ' Get the first Product. 
            Dim productQuery2 As Product = productQuery1.First()

            Console.WriteLine("Product Name: {0}", productQuery2.Name)
        End Using
        '</snippetObjectQuery_First> 
    End Sub
    Public Shared Sub ObjectQuery_Where()
        Console.WriteLine("Starting method 'ObjectQuery_Where'")
        '<snippetObjectQuery_Where> 
        Dim productID = 900
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE product FROM AdventureWorksEntities.Products AS product"

            Dim productQuery1 As New ObjectQuery(Of Product)(queryString, context, MergeOption.NoTracking)

            Dim productQuery2 As ObjectQuery(Of Product) = productQuery1.Where("it.ProductID = @productID")
            productQuery2.Parameters.Add(New ObjectParameter("productID", productID))

            ' Iterate through the collection of Product items. 
            For Each result As Product In productQuery2
                Console.WriteLine("Product Name: {0}; Product ID: {1}", result.Name, result.ProductID)
            Next
        End Using
        '</snippetObjectQuery_Where> 
    End Sub
    Public Shared Sub ObjectQuery_Top()
        Console.WriteLine("Starting method 'ObjectQuery_Top'")
        '<snippetObjectQuery_Top> 
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE product FROM AdventureWorksEntities.Products AS product"

            Dim productQuery1 As New ObjectQuery(Of Product)(queryString, context, MergeOption.NoTracking)

            Dim productQuery2 As ObjectQuery(Of Product) = productQuery1.Top("2")

            ' Iterate through the collection of Product items. 
            For Each result As Product In productQuery2
                Console.WriteLine("{0}", result.Name)
            Next
        End Using
        '</snippetObjectQuery_Top> 
    End Sub
    Public Shared Sub ObjectQuery_SelectValue()
        Console.WriteLine("Starting method 'ObjectQuery_SelectValue'")
        '<snippetObjectQuery_SelectValue> 
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE product FROM AdventureWorksEntities.Products AS product"

            Dim productQuery1 As New ObjectQuery(Of Product)(queryString, context, MergeOption.NoTracking)

            Dim productQuery2 As ObjectQuery(Of Int32) = productQuery1.SelectValue(Of Int32)("it.ProductID")

            For Each result As Int32 In productQuery2
                Console.WriteLine("{0}", result)
            Next
        End Using
        '</snippetObjectQuery_SelectValue> 
    End Sub

    Public Shared Sub ObjectQuery_Select()
        Console.WriteLine("Starting method 'ObjectQuery_Select'")
        '<snippetObjectQuery_Select> 
        Dim productID = 900
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE product FROM AdventureWorksEntities.Products AS product" & _
                    " WHERE product.ProductID > @productID"

            Dim productQuery1 As New ObjectQuery(Of Product)(queryString, context, MergeOption.NoTracking)
            productQuery1.Parameters.Add(New ObjectParameter("productID", productID))

            Dim productQuery2 As ObjectQuery(Of DbDataRecord) = productQuery1.Select("it.ProductID")

            For Each result As DbDataRecord In productQuery2
                Console.WriteLine("{0}", result("ProductID"))
            Next
        End Using
        '</snippetObjectQuery_Select> 
    End Sub
    Public Shared Sub ObjectQuery_OrderBy()
        Console.WriteLine("Starting method 'ObjectQuery_OrderBy'")
        '<snippetObjectQuery_OrderBy> 
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE product FROM AdventureWorksEntities.Products AS product"

            Dim productQuery1 As New ObjectQuery(Of Product)(queryString, context, MergeOption.NoTracking)

            Dim productQuery2 As ObjectQuery(Of Product) = productQuery1.OrderBy("it.ProductID")

            ' Iterate through the collection of Product items. 
            For Each result As Product In productQuery2
                Console.WriteLine("{0}", result.ProductID)
            Next
        End Using
        '</snippetObjectQuery_OrderBy> 
    End Sub
    Public Shared Sub ObjectQuery_Intersect()
        Console.WriteLine("Starting method 'ObjectQuery_Intersect'")
        '<snippetObjectQuery_Intersect> 
        Dim productID1 = 900
        Dim productID2 = 950

        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE product FROM AdventureWorksEntities.Products " & _
                    " AS product WHERE product.ProductID > @productID1"

            Dim productQuery As New ObjectQuery(Of Product)(queryString, context, MergeOption.NoTracking)

            Dim queryString2 As String = "SELECT VALUE product FROM AdventureWorksEntities.Products " & _
                " AS product WHERE product.ProductID > @productID2"

            Dim productQuery2 As New ObjectQuery(Of Product)(queryString2, context, MergeOption.NoTracking)

            Dim productQuery3 As ObjectQuery(Of Product) = productQuery.Intersect(productQuery2)
            productQuery3.Parameters.Add(New ObjectParameter("productID1", productID1))
            productQuery3.Parameters.Add(New ObjectParameter("productID2", productID2))

            Console.WriteLine("Result of Intersect")
            Console.WriteLine("------------------")

            ' Iterate through the collection of Product items 
            ' after the Intersect method was called. 
            For Each result As Product In productQuery3
                Console.WriteLine("Product Name: {0}", result.ProductID)
            Next
        End Using
        '</snippetObjectQuery_Intersect> 
    End Sub
    Public Shared Sub Projection_SkipLimit()
        Console.WriteLine("Starting method 'Projection_SkipLimit'")
        '<snippetProjection_SkipLimit> 
        Using context As New AdventureWorksEntities()
            ' Define the parameters used to define the "page" of returned data. 
            Dim skipValue As Integer = 3
            Dim limitValue As Integer = 5

            ' Define a query that returns a "page" or the full 
            ' Product data using the Skip and Top methods. 
            ' When Top() follows Skip(), it acts like the LIMIT statement. 
            Dim query As ObjectQuery(Of Product) = _
                context.Products.Skip("it.ListPrice", "@skip", _
                    New ObjectParameter("skip", skipValue)).Top("@limit", New ObjectParameter("limit", limitValue))

            ' Iterate through the page of Product items. 
            For Each result As Product In query
                Console.WriteLine("ID: {0}; Name: {1}", result.ProductID, result.Name)
            Next
        End Using
        '</snippetProjection_SkipLimit> 
    End Sub
    Public Shared Sub Projection_GroupBy()
        Console.WriteLine("Starting method 'Projection_GroupBy'")
        '<snippetProjection_GroupBy> 
        Using context As New AdventureWorksEntities()
            '<snippetComplexQueryBuilderMethod> 
            ' Define the query with a GROUP BY clause that returns 
            ' a set of nested LastName records grouped by first letter. 
            Dim query As ObjectQuery(Of DbDataRecord) = _
                context.Contacts.GroupBy("SUBSTRING(it.LastName, 1, 1) AS ln", "ln") _
                .Select("it.ln AS ln, (SELECT c1.LastName FROM AdventureWorksEntities.Contacts AS c1 " & _
                        "WHERE SubString(c1.LastName, 1, 1) = it.ln) AS CONTACT").OrderBy("it.ln")
            '</snippetComplexQueryBuilderMethod> 

            ' Execute the query and walk through the nested records. 
            For Each rec As DbDataRecord In query.Execute(MergeOption.AppendOnly)
                Console.WriteLine("Last names that start with the letter '{0}':", rec(0))
                Dim list As List(Of DbDataRecord) = TryCast(rec(1), List(Of DbDataRecord))
                For Each r As DbDataRecord In list
                    For i As Integer = 0 To r.FieldCount - 1
                        Console.WriteLine(" {0} ", r(i))
                    Next
                Next
            Next
        End Using
        '</snippetProjection_GroupBy> 
    End Sub
    Public Shared Sub Projection_Union()
        Console.WriteLine("Starting method 'Projection_Union'")
        '<snippetProjection_Union> 
        Using context As New AdventureWorksEntities()
            Dim query As ObjectQuery(Of DbDataRecord) = _
                context.Products.Select("it.Name, it.ProductID As Pid, it.ListPrice") _
                .Where("it.Name LIKE 'A%'").Union(context.Products.Select("it.Name, it.ProductID As Pid, it.ListPrice") _
                                                  .Where("it.Name LIKE 'B%'")).Select("it.Name, it.ListPrice").OrderBy("it.Name")

            For Each rec As DbDataRecord In query
                Console.WriteLine("Name: {0}; ListPrice: {1}", rec(0), rec(1))
            Next

        End Using
        '</snippetProjection_Union> 
    End Sub
    Public Shared Sub Projection_Union_LINQ()
        '<snippetProjectionUnionLINQ>
        Using context As New AdventureWorksEntities()
            Dim query = (From a In context.Products Where a.Name.StartsWith("A") _
                         Select (New With {a.Name, .pid = a.ProductID, a.ListPrice})). _
                     Union( _
                         From b In context.Products Where b.Name.StartsWith("B") _
                         Select (New With {b.Name, .pid = b.ProductID, b.ListPrice})). _
                     Select(Function(c) New With {c.Name, c.ListPrice}).OrderBy(Function(d) d.Name)


            For Each result In query
                Console.WriteLine(result.Name)
            Next
        End Using
        '</snippetProjectionUnionLINQ>
    End Sub
    Public Shared Sub ObjectQuery_Where2()
        Console.WriteLine("Starting method 'ObjectQuery_Where2'")
        '<snippetObjectQuery_Where2> 
        Using context As New AdventureWorksEntities()
            ' Define the product ID for filtering. 
            Dim productId As Integer = 900

            '<snippetObjectQuery_WhereOnly> 
            ' Return Product objects with the specified ID. 
            Dim query As ObjectQuery(Of Product) = context.Products.Where("it.ProductID = @product", New ObjectParameter("product", productId))
            '</snippetObjectQuery_WhereOnly> 

            ' Iterate through the collection of Product items. 
            For Each result As Product In query
                Console.WriteLine("Product Name: {0}; Product ID: {1}", result.Name, result.ProductID)
            Next
        End Using
        '</snippetObjectQuery_Where2> 
    End Sub
    Public Shared Sub ObjectQuery_GroupBy()
        Console.WriteLine("Starting method 'ObjectQuery_GroupBy'")
        '<snippetObjectQuery_GroupBy> 
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE product " & vbCr & vbLf & " FROM AdventureWorksEntities.Products AS product"

            Dim productQuery As New ObjectQuery(Of Product)(queryString, context, MergeOption.NoTracking)

            Dim productQuery2 As ObjectQuery(Of DbDataRecord) = _
                productQuery.GroupBy("it.name AS pn", "Sqlserver.COUNT(it.Name) as count, pn")

            ' Iterate through the collection of Products 
            ' after the GroupBy method was called. 
            For Each result As DbDataRecord In productQuery2
                Console.WriteLine("Name: {0}; Count: {1}", result("pn"), result("count"))
            Next
        End Using
    End Sub
    '</snippetObjectQuery_GroupBy> 
    Public Shared Sub ObjectQuery_Except()
        Console.WriteLine("Starting method 'ObjectQuery_Except'")
        '<snippetObjectQuery_Except> 
        Dim productID = 900
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE product FROM AdventureWorksEntities.Products AS product"
            Dim productQuery As New ObjectQuery(Of Product)(queryString, context, MergeOption.NoTracking)

            Dim queryString2 As String = "SELECT VALUE product FROM AdventureWorksEntities.Products " & _
                " AS product WHERE product.ProductID < @productID"
            Dim productQuery2 As New ObjectQuery(Of Product)(queryString2, context, MergeOption.NoTracking)
            productQuery2.Parameters.Add(New ObjectParameter("productID", productID))

            Dim productQuery3 As ObjectQuery(Of Product) = productQuery.Except(productQuery2)

            Console.WriteLine("Result of Except")
            Console.WriteLine("------------------")

            ' Iterate through the collection of Product items 
            ' after the Except method was called. 
            For Each result As Product In productQuery3
                Console.WriteLine("Product Name: {0}", result.ProductID)
            Next
        End Using
        '</snippetObjectQuery_Except> 
    End Sub
    Public Shared Sub ObjectQuery_Distinct_UnionAll()
        Console.WriteLine("Starting method 'ObjectQuery_Distinct_UnionAll'")
        '<snippetObjectQuery_Distinct_UnionAll> 
        Dim productID = 100
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE product FROM AdventureWorksEntities.Products " & _
                    " AS product WHERE product.ProductID < @productID"

            Dim productQuery As New ObjectQuery(Of Product)(queryString, context, MergeOption.NoTracking)

            Dim productQuery2 As New ObjectQuery(Of Product)(queryString, context, MergeOption.NoTracking)

            Dim productQuery3 As ObjectQuery(Of Product) = productQuery.UnionAll(productQuery2)

            productQuery3.Parameters.Add(New ObjectParameter("productID", productID))

            Console.WriteLine("Result of UnionAll")
            Console.WriteLine("------------------")

            ' Iterate through the collection of Product items, 
            ' after the UnionAll method was called on two queries. 
            For Each result As Product In productQuery3
                Console.WriteLine("Product Name: {0}", result.ProductID)
            Next
            Dim productQuery4 As ObjectQuery(Of Product) = productQuery3.Distinct()

            Console.WriteLine(vbLf & "Result of Distinct")
            Console.WriteLine("------------------")

            ' Iterate through the collection of Product items. 
            ' after the Distinct method was called on a query. 
            For Each result As Product In productQuery4
                Console.WriteLine("Product Name: {0}", result.ProductID)
            Next
        End Using
        '</snippetObjectQuery_Distinct_UnionAll> 
    End Sub
    Public Shared Sub ObjectQuery_Distinct_Union()
        Console.WriteLine("Starting method 'ObjectQuery_Distinct_Union'")
        '<snippetObjectQuery_Distinct_Union> 
        Dim productID = 100
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE product FROM AdventureWorksEntities.Products AS product " & _
                    " WHERE product.ProductID < @productID"
            Dim productQuery As New ObjectQuery(Of Product)(queryString, context, MergeOption.NoTracking)

            Dim productQuery2 As New ObjectQuery(Of Product)(queryString, context, MergeOption.NoTracking)

            Dim productQuery3 As ObjectQuery(Of Product) = productQuery.Union(productQuery2)

            productQuery3.Parameters.Add(New ObjectParameter("productID", productID))

            Console.WriteLine("Result of Union")
            Console.WriteLine("------------------")

            ' Iterate through the collection of Product items, 
            ' after the Union method was called on two queries. 
            For Each result As Product In productQuery3
                Console.WriteLine("Product Name: {0}", result.ProductID)
            Next
        End Using
        '</snippetObjectQuery_Distinct_Union> 
    End Sub
    Public Shared Sub LINQQuery_Parameters()
        Console.WriteLine("Starting method 'LINQQuery_Parameters'")
        '<snippetLINQQuery_Parameters> 
        Using context As New AdventureWorksEntities()

            Dim FirstName = "Frances"
            Dim LastName = "Adams"

            Dim contactQuery = From contact In context.Contacts _
                               Where contact.LastName = LastName AndAlso contact.FirstName = FirstName _
                               Select contact


            ' Iterate through the results of the parameterized query.
            For Each result In contactQuery
                Console.WriteLine("{0} {1}", result.FirstName, result.LastName)
            Next
        End Using
        '</snippetLINQQuery_Parameters> 
    End Sub
    Public Shared Sub ObjectQuery_Parameters()
        Console.WriteLine("Starting method 'ObjectQuery_Parameters'")
        '<snippetObjectQuery_Parameters> 
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE contact FROM AdventureWorksEntities.Contacts" & _
                    " AS contact WHERE contact.LastName = @ln AND contact.FirstName = @fn"

            Dim contactQuery As New ObjectQuery(Of Contact)(queryString, context)

            ' Add parameters to the collection. 
            contactQuery.Parameters.Add(New ObjectParameter("ln", "Adams"))
            contactQuery.Parameters.Add(New ObjectParameter("fn", "Frances"))

            Dim objectParameterCollection As ObjectParameterCollection = contactQuery.Parameters

            ' Iterate through the ObjectParameterCollection. 
            For Each result As ObjectParameter In objectParameterCollection
                Console.WriteLine("{0} {1} {2}", result.Name, result.Value, result.ParameterType)
            Next
        End Using
        '</snippetObjectQuery_Parameters> 
    End Sub
    Public Shared Sub ObjectQuery_Name()
        Console.WriteLine("Starting method 'ObjectQuery_Name'")
        '<snippetObjectQuery_Name> 
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE contact FROM AdventureWorksEntities.Contacts AS contact"

            Dim contactQuery As New ObjectQuery(Of Contact)(queryString, context, MergeOption.NoTracking)

            ' Write ObjectQuery's name. 
            Console.WriteLine("The ObjectQuery's name is: {0}", contactQuery.Name)
        End Using
        '</snippetObjectQuery_Name> 
    End Sub
    Public Shared Sub ObjectQuery_ScalarTypeException()
        Console.WriteLine("Starting method 'ObjectQuery_ScalarTypeException'")
        Console.WriteLine("This method should generate an ArgumentException.")
        '<snippetObjectQuery_ScalarTypeException> 
        Using context As New AdventureWorksEntities()
            Try
                '<snippetObjectQuery_ScalarTypeExceptionShort> 
                ' Define a query projection that returns 
                ' a collection with a single scalar result.
                Dim scalarQuery As New ObjectQuery(Of Int32)("100", context)

                ' Calling an extension method that requires a collection 
                ' will result in an exception. 
                Dim hasValues As Boolean = scalarQuery.Any()
                '</snippetObjectQuery_ScalarTypeExceptionShort> 
            Catch ex As ArgumentException
                Console.WriteLine(ex.ToString())
            End Try
        End Using
        '</snippetObjectQuery_ScalarTypeException> 
    End Sub
    Public Shared Sub ObjectQuery_Context()
        Console.WriteLine("Starting method 'ObjectQuery_Context'")
        '<snippetObjectQuery_Context> 
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE contact FROM AdventureWorksEntities.Contacts AS contact"

            Dim contactQuery As New ObjectQuery(Of Contact)(queryString, context, MergeOption.NoTracking)

            ' Get ObjectContext from ObjectQuery. 
            Dim objectContext As ObjectContext = contactQuery.Context
            Console.WriteLine("Connection string {0}", objectContext.Connection.ConnectionString)
        End Using
        '</snippetObjectQuery_Context> 
    End Sub
    Public Shared Sub ObjectQueryConstructors()
        Console.WriteLine("Starting method 'ObjectQueryConstructors'")
        '<snippetObjectQuery> 
        Using context As New AdventureWorksEntities()
            ' Call the constructor with a query for products and the ObjectContext. 
            Dim productQuery1 As New ObjectQuery(Of Product)("Products", context)

            For Each result As Product In productQuery1
                Console.WriteLine("Product Name: {0}", result.Name)
            Next

            Dim queryString As String = "SELECT VALUE product FROM AdventureWorksEntities.Products AS product"

            ' Call the constructor with the specified query and the ObjectContext. 
            Dim productQuery2 As New ObjectQuery(Of Product)(queryString, context)

            For Each result As Product In productQuery2
                Console.WriteLine("Product Name: {0}", result.Name)
            Next

            ' Call the constructor with the specified query, the ObjectContext, 
            ' and the NoTracking merge option. 
            Dim productQuery3 As New ObjectQuery(Of Product)(queryString, context, MergeOption.NoTracking)

            For Each result As Product In productQuery3
                Console.WriteLine("Product Name: {0}", result.Name)
            Next
        End Using
        '</snippetObjectQuery> 
    End Sub
    Public Shared Sub ObjectParameterCollectionClass_Remove()
        Console.WriteLine("Starting method 'ObjectParameterCollectionClass_Remove'")
        '<snippetObjectParameterCollection_Remove> 
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE contact FROM AdventureWorksEntities.Contacts " & _
                    " AS contact WHERE contact.LastName = @ln AND contact.FirstName = @fn"

            Dim contactQuery As New ObjectQuery(Of Contact)(queryString, context)

            ' Add parameters to the ObjectQuery's Parameters collection. 
            contactQuery.Parameters.Add(New ObjectParameter("ln", "Adams"))
            contactQuery.Parameters.Add(New ObjectParameter("fn", "Frances"))

            Dim objectParameterCollection As ObjectParameterCollection = contactQuery.Parameters
            Console.WriteLine("Count before Remove is called: {0}", objectParameterCollection.Count)

            Dim objectParameter As ObjectParameter = objectParameterCollection("ln")

            ' Remove the specified parameter from the collection. 
            objectParameterCollection.Remove(objectParameter)
            Console.WriteLine("Count after Remove is called: {0}", objectParameterCollection.Count)
        End Using
        '</snippetObjectParameterCollection_Remove> 
    End Sub
    Public Shared Sub ObjectParameterCollectionClass_CopyTo()
        Console.WriteLine("Starting method 'ObjectParameterCollectionClass_CopyTo'")
        '<snippetObjectParameterCollection_CopyTo> 
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE contact FROM AdventureWorksEntities.Contacts " & _
                    " AS contact WHERE contact.LastName = @ln AND contact.FirstName = @fn"

            Dim contactQuery As New ObjectQuery(Of Contact)(queryString, context)

            ' Add parameters to the collection. 
            contactQuery.Parameters.Add(New ObjectParameter("ln", "Adams"))
            contactQuery.Parameters.Add(New ObjectParameter("fn", "Frances"))

            Dim objectParameterCollection As ObjectParameterCollection = contactQuery.Parameters
            Dim objectParameterArray As ObjectParameter() = New ObjectParameter(objectParameterCollection.Count - 1) {}

            objectParameterCollection.CopyTo(objectParameterArray, 0)

            ' Iterate through the ObjectParameter array. 
            For i As Integer = 0 To objectParameterArray.Length - 1
                Console.WriteLine("Name: {0} Type: {1} Value: {2}", _
                                  objectParameterArray(i).Name, objectParameterArray(i).ParameterType, objectParameterArray(i).Value)
            Next
        End Using
        '</snippetObjectParameterCollection_CopyTo> 
    End Sub
    Public Shared Sub ObjectParameterCollectionClass_Count_Add_Indexer()
        Console.WriteLine("Starting method 'ObjectParameterCollectionClass_Count_Add_Indexer'")
        '<snippetObjectParameterCollection_Count_Add_Indexer> 
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE contact FROM AdventureWorksEntities.Contacts " & _
                    " AS contact WHERE contact.LastName = @ln AND contact.FirstName = @fn"

            Dim contactQuery As New ObjectQuery(Of Contact)(queryString, context)

            ' Add parameters to the collection. 
            contactQuery.Parameters.Add(New ObjectParameter("ln", "Adams"))
            contactQuery.Parameters.Add(New ObjectParameter("fn", "Frances"))

            Dim objectParameterCollection As ObjectParameterCollection = contactQuery.Parameters

            Console.WriteLine("Count is {0}.", objectParameterCollection.Count)

            ' Iterate through the ObjectParameterCollection collection. 
            For Each result As ObjectParameter In objectParameterCollection
                Console.WriteLine("{0} {1} {2}", result.Name, result.Value, result.ParameterType)
            Next
        End Using
        '</snippetObjectParameterCollection_Count_Add_Indexer> 
    End Sub
    Public Shared Sub ObjectParameterCollectionClass_ContainsWithParamArg()
        Console.WriteLine("Starting method 'ObjectParameterCollectionClass_ContainsWithParamArg'")
        '<snippetObjectParameterCollection_ParamArg> 
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE contact FROM AdventureWorksEntities.Contacts " & _
                    " AS contact WHERE contact.LastName = @ln AND contact.FirstName = @fn"

            Dim contactQuery As New ObjectQuery(Of Contact)(queryString, context)

            ' Create a collection of parameters. 
            Dim param As New ObjectParameter("ln", "Adams")
            contactQuery.Parameters.Add(param)
            contactQuery.Parameters.Add(New ObjectParameter("fn", "Frances"))

            Dim objectParameterCollection As ObjectParameterCollection = contactQuery.Parameters

            ' Check whether the specifed parameter is in the collection. 
            If objectParameterCollection.Contains(param) Then
                Console.WriteLine("parameter is here")
            Else
                Console.WriteLine("parameter is not here")
            End If
        End Using
        '</snippetObjectParameterCollection_ParamArg> 
    End Sub
    Public Shared Sub ObjectParameterCollectionClass_ContainsWithStringArg()
        Console.WriteLine("Starting method 'ObjectParameterCollectionClass_ContainsWithStringArg'")
        '<snippetObjectParameterCollection_StringArg> 
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE contact FROM AdventureWorksEntities.Contacts " & _
                    " AS contact WHERE contact.LastName = @ln AND contact.FirstName = @fn"

            Dim contactQuery As New ObjectQuery(Of Contact)(queryString, context)

            ' Add parameters to the collection. 
            contactQuery.Parameters.Add(New ObjectParameter("ln", "Adams"))
            contactQuery.Parameters.Add(New ObjectParameter("fn", "Frances"))

            Dim objectParameterCollection As ObjectParameterCollection = contactQuery.Parameters

            If objectParameterCollection.Contains("ln") Then
                Console.WriteLine("ln is here")
            Else
                Console.WriteLine("ln is not here")
            End If
        End Using
        '</snippetObjectParameterCollection_StringArg> 
    End Sub
    Public Shared Sub ObjectParameterClass_Value_Name_Type()
        Console.WriteLine("Starting method 'ObjectParameterClass_Value_Name_Type'")
        '<snippetObjectParameter_Value_Name_Type> 
        Using context As New AdventureWorksEntities()
            Dim param As New ObjectParameter("fn", GetType(System.String))
            param.Value = "Frances"

            Console.WriteLine("Parame Name: {0}, Param Value: {1} Param Type: {2}", _
                              param.Name, param.Value, param.ParameterType)
        End Using
        '</snippetObjectParameter_Value_Name_Type> 
    End Sub
    Public Shared Sub ObjectParameterClass()
        Console.WriteLine("Starting method 'ObjectParameterClass'")
        '<snippetObjectParameter> 
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE contact FROM AdventureWorksEntities.Contacts " & _
                    "AS contact WHERE contact.FirstName = @fn"

            Dim param As New ObjectParameter("fn", "Frances")

            Dim contactQuery As ObjectQuery(Of Contact) = context.CreateQuery(Of Contact)(queryString, param)

            ' Iterate through the collection of Contact items. 
            For Each result As Contact In contactQuery
                Console.WriteLine("First Name: {0}, Last Name: {1}", result.FirstName, result.LastName)
            Next
        End Using
        '</snippetObjectParameter> 
    End Sub
    Public Shared Sub EntityKeyClass_TryGetObjectByKey()
        Console.WriteLine("Starting method 'EntityKeyClass_TryGetObjectByKey'")
        '<snippetEntityKeyClass_TryGetObjectByKey> 
        Using context As New AdventureWorksEntities()
            Dim entity As Object = Nothing
            Dim entityKeyValues As IEnumerable(Of KeyValuePair(Of String, Object)) = _
                New KeyValuePair(Of String, Object)() {New KeyValuePair(Of String, Object)("SalesOrderID", 43680)}

            ' Create the key for a specific SalesOrderHeader object. 
            Dim key As New EntityKey("AdventureWorksEntities.SalesOrderHeaders", entityKeyValues)

            ' Get the object from the context or the persisted store by its key. 
            If context.TryGetObjectByKey(key, entity) Then
                Console.WriteLine("The requested " & entity.GetType().FullName & " object was found")
            Else
                Console.WriteLine("An object with this key could not be found.")
            End If
        End Using
        '</snippetEntityKeyClass_TryGetObjectByKey> 
    End Sub
    Public Shared Sub EntityKeyClass_GetObjectByKey_CreateKey()
        Console.WriteLine("Starting method 'EntityKeyClass_GetObjectByKey_CreateKey'")
        '<snippetEntityKeyClass_GetObjectByKey> 
        Using context As New AdventureWorksEntities()
            Try
                ' Define the entity key values. 
                Dim entityKeyValues As IEnumerable(Of KeyValuePair(Of String, Object)) = _
                    New KeyValuePair(Of String, Object)() {New KeyValuePair(Of String, Object)("SalesOrderID", 43680)}

                ' Create the key for a specific SalesOrderHeader object. 
                Dim key As New EntityKey("AdventureWorksEntities.SalesOrderHeaders", entityKeyValues)

                ' Get the object from the context or the persisted store by its key. 
                Dim order As SalesOrderHeader = DirectCast(context.GetObjectByKey(key), SalesOrderHeader)

                Console.WriteLine("SalesOrderID: {0} Order Number: {1}", order.SalesOrderID, order.SalesOrderNumber)
            Catch ex As ObjectNotFoundException
                Console.WriteLine(ex.ToString())
            End Try
        End Using
        '</snippetEntityKeyClass_GetObjectByKey> 
    End Sub
    Public Shared Sub CreateQuery()
        Console.WriteLine("Starting method 'CreateQuery'")
        '<snippetCreateQuery> 
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE contact FROM AdventureWorksEntities.Contacts " & _
                    " AS contact WHERE contact.FirstName = @fn"

            Dim contactQuery As ObjectQuery(Of Contact) = context.CreateQuery(Of Contact)(queryString, New ObjectParameter("fn", "Frances"))

            ' Iterate through the collection of Contact items. 
            For Each result As Contact In contactQuery
                Console.WriteLine("First Name: {0}, Last Name: {1}", result.FirstName, result.LastName)
            Next
        End Using
        '</snippetCreateQuery> 
    End Sub
    Public Shared Sub ObjectContextAddDeleteSave_ObjectStateEntryState()
        Console.WriteLine("Starting method 'ObjectContextAddDeleteSave_ObjectStateEntryState'")
        '<snippetObjectStateEntry> 
        ' Specify the order to update. 
        Dim orderId As Integer = 43680

        Using context As New AdventureWorksEntities()
            Try
                Dim order = (From o In context.SalesOrderHeaders
                             Where o.SalesOrderID = orderId
                             Select o).First()

                ' Change the status of an existing order. 
                order.Status = 1

                ' Delete the first item in the order. 
                context.DeleteObject(order.SalesOrderDetails.First())

                ' Create a new SalesOrderDetail object. 
                ' You can use the static CreateObjectName method (the Entity Framework 
                ' adds this method to the generated entity types) instead of the new operator: 
                ' SalesOrderDetail.CreateSalesOrderDetail(1, 0, 2, 750, 1, (decimal)2171.2942, 0, 0, 
                ' Guid.NewGuid(), DateTime.Today)); 
                Dim detail = New SalesOrderDetail With
                {
                    .SalesOrderID = 0,
                    .SalesOrderDetailID = 0,
                    .OrderQty = 2,
                    .ProductID = 750,
                    .SpecialOfferID = 1,
                    .UnitPrice = CDec(2171.2942),
                    .UnitPriceDiscount = 0,
                    .LineTotal = 0,
                    .rowguid = Guid.NewGuid(),
                    .ModifiedDate = DateTime.Now
                }

                order.SalesOrderDetails.Add(detail)

                ' Get the ObjectStateEntry for the order. 
                Dim stateEntry As ObjectStateEntry = context.ObjectStateManager.GetObjectStateEntry(order)
                Console.WriteLine("State before SaveChanges() is called: {0}", stateEntry.State.ToString())

                ' Save changes in the object context to the database. 
                Dim changes As Integer = context.SaveChanges()

                Console.WriteLine("State after SaveChanges() is called: {0}", stateEntry.State.ToString())

                Console.WriteLine(changes.ToString() & " changes saved!")
                Console.WriteLine("Updated item for order ID: " & order.SalesOrderID.ToString())

                ' Iterate through the collection of SalesOrderDetail items. 
                For Each item As SalesOrderDetail In order.SalesOrderDetails
                    Console.WriteLine("Item ID: {0}", item.SalesOrderDetailID.ToString())
                    Console.WriteLine("Product: {0}", item.ProductID.ToString())
                    Console.WriteLine("Quantity: {0}", item.OrderQty.ToString())
                Next
            Catch ex As UpdateException
                Console.WriteLine(ex.ToString())
            End Try
        End Using
        '</snippetObjectStateEntry> 
    End Sub
    Public Shared Sub EntityObjectRelManager_IRelatedEnd()
        Console.WriteLine("Starting method 'EntityObjectRelManager_IRelatedEnd'")
        '<snippetIRelatedEnd> 
        Using context As New AdventureWorksEntities()
            Dim contact As New Contact()

            ' Create a new SalesOrderHeader. 
            Dim newSalesOrder1 As New SalesOrderHeader()
            ' Add SalesOrderHeader to the Contact. 
            contact.SalesOrderHeaders.Add(newSalesOrder1)

            ' Create another SalesOrderHeader. 
            Dim newSalesOrder2 As New SalesOrderHeader()
            ' Add SalesOrderHeader to the Contact. 
            contact.SalesOrderHeaders.Add(newSalesOrder2)

            ' Get all related ends 
            Dim relEnds As IEnumerable(Of IRelatedEnd) = DirectCast(contact, IEntityWithRelationships).RelationshipManager.GetAllRelatedEnds()

            For Each relEnd As IRelatedEnd In relEnds
                Console.WriteLine("Relationship Name: {0}", relEnd.RelationshipName)
                Console.WriteLine("Source Role Name: {0}", relEnd.SourceRoleName)
                Console.WriteLine("Target Role Name: {0}", relEnd.TargetRoleName)
            Next
        End Using
        '</snippetIRelatedEnd> 
    End Sub
    Public Shared Sub EntityCollectionCountContainsAddRemove_IRelatedEnd_Add()
        Console.WriteLine("Starting method 'EntityCollectionCountContainsAddRemove_IRelatedEnd_Add'")
        '<snippetIRelatedEnd_Add> 
        Using context As New AdventureWorksEntities()
            Dim contact As New Contact()

            ' Create a new SalesOrderHeader. 
            Dim newSalesOrder1 As New SalesOrderHeader()
            ' Add SalesOrderHeader to the Contact. 
            contact.SalesOrderHeaders.Add(newSalesOrder1)

            ' Create another SalesOrderHeader. 
            Dim newSalesOrder2 As New SalesOrderHeader()
            ' Add SalesOrderHeader to the Contact. 
            contact.SalesOrderHeaders.Add(newSalesOrder2)

            ' Get all related ends 
            Dim relEnds As IEnumerable(Of IRelatedEnd) = DirectCast(contact, IEntityWithRelationships).RelationshipManager.GetAllRelatedEnds()

            For Each relEnd As IRelatedEnd In relEnds
                ' Get Entity Collection from related end 
                Dim entityCollection As EntityCollection(Of SalesOrderHeader) = DirectCast(relEnd, EntityCollection(Of SalesOrderHeader))

                Console.WriteLine("EntityCollection count: {0}", entityCollection.Count)
                ' Remove the first entity object. 
                entityCollection.Remove(newSalesOrder1)

                Dim contains As Boolean = entityCollection.Contains(newSalesOrder1)

                ' Write the number of items after one entity has been removed 
                Console.WriteLine("EntityCollection count after one entity has been removed: {0}", entityCollection.Count)

                If contains = False Then
                    Console.WriteLine("The removed entity is not in the collection any more.")
                End If

                'Use IRelatedEnd to add the entity back. 
                relEnd.Add(newSalesOrder1)
                Console.WriteLine("EntityCollection count after an entity has been added again: {0}", entityCollection.Count)
            Next
        End Using
        '</snippetIRelatedEnd_Add> 
    End Sub
    Public Shared Sub Projection_Navigation()
        Console.WriteLine("Starting method 'Projection_Navigation'")
        '<snippetProjection_Navigation>
        Dim lastName = "Zhou"

        Using context As New AdventureWorksEntities()
            '<snippetProjection_NavigationQuery> 
            ' Define a query that returns a nested 
            ' DbDataRecord for the projection. 
            Dim query As ObjectQuery(Of DbDataRecord) = context.Contacts.Select("it.FirstName, it.LastName, it.SalesOrderHeaders") _
                                                        .Where("it.LastName = @ln", New ObjectParameter("ln", lastName))
            '</snippetProjection_NavigationQuery> 

            For Each rec As DbDataRecord In query.Execute(MergeOption.AppendOnly)

                ' Display contact's first name. 
                Console.WriteLine("First Name {0}: ", rec(0))
                Dim list As List(Of SalesOrderHeader) = TryCast(rec(2), List(Of SalesOrderHeader))
                ' Display SalesOrderHeader information 
                ' associated with the contact. 
                For Each soh As SalesOrderHeader In list
                    Console.WriteLine(" Order ID: {0}, Order date: {1}, Total Due: {2}", _
                                      soh.SalesOrderID, soh.OrderDate, soh.TotalDue)
                Next
            Next
        End Using
        '</snippetProjection_Navigation> 
    End Sub
#End Region


#Region "ConceptualMethods"

    Public Shared Sub CallEnlistTransaction()
        Console.WriteLine("Starting method 'EnlistTransaction'")
        TransactionSample.EnlistTransaction()
    End Sub

    Public Shared Sub SerializeToXml()
        Using context As New AdventureWorksEntities()
            Dim query As ObjectQuery(Of Contact) = context.Contacts.Include("SalesOrderHeaders.SalesOrderDetails")
            Dim writer As New StringWriter()
            Dim serializer As New XmlSerializer(GetType(SalesOrderHeader))

            ' Return the first 5 orders. 
            Dim orders As EntityCollection(Of SalesOrderHeader) = context.Contacts.First().SalesOrderHeaders

            For Each order As SalesOrderHeader In orders
                serializer.Serialize(writer, order)
                writer.WriteLine()
            Next

            Console.WriteLine(writer.ToString())
        End Using
    End Sub

    Public Shared Function CleanupOrders() As Boolean
        Using context As New AdventureWorksEntities()
            Dim query As ObjectQuery(Of Contact) = context.Contacts.Include("SalesOrderHeaders.SalesOrderDetails")

            Dim order As SalesOrderHeader = query.First().SalesOrderHeaders.First()

            DetachOrders(context, order)

            If order.EntityState <> EntityState.Detached Then
                Console.WriteLine("Detach failed")
                Return False
            End If
            Return True
        End Using
    End Function

    '<snippetDetachObjects> 
    ' This method is called to detach SalesOrderHeader objects and 
    ' related SalesOrderDetail objects from the supplied object 
    ' context when no longer needed by the application. 
    ' Once detached, the resources can be garbage collected. 
    Private Shared Sub DetachOrders(ByVal context As ObjectContext, ByVal order As SalesOrderHeader)
        Try
            ' Detach each item from the collection. 
            While order.SalesOrderDetails.Count > 0
                '<snippetDetachOnly> 
                ' Detach the first SalesOrderDetail in the collection. 
                context.Detach(order.SalesOrderDetails.First())
                '</snippetDetachOnly> 
            End While

            ' Detach the order. 
            context.Detach(order)
        Catch ex As InvalidOperationException
            Console.WriteLine(ex.ToString())
        End Try
    End Sub
    '</snippetDetachObjects> 

    Public Shared Sub ObjectContextProxy()

        Console.WriteLine("Starting method 'ObjectContextProxy'")
        '<snippetObjectContextProxy> 

        ' Create an instance of the proxy class that returns an object context. 
        Dim context As New AdventureWorksProxy()
        ' Get the first order from the context. 
        Dim order As SalesOrderHeader = context.Context.SalesOrderHeaders.First()

        ' Add some text that we want to catch before saving changes. 
        order.Comment = "some text"

        Try
            ' Save changes using the proxy class. 
            Dim changes As Integer = context.Context.SaveChanges()
        Catch ex As InvalidOperationException
            ' Handle the exception returned by the proxy class 
            ' validation if a problem string is found. 
            Console.WriteLine(ex.ToString())

            '</snippetObjectContextProxy> 

        End Try
    End Sub
    Public Shared Sub FilterQueryLinq()
        Console.WriteLine("Starting method 'FilterQueryLinq'")
        '<snippetFilterQueryLinq> 
        Using context As New AdventureWorksEntities()
            ' Specify the order amount. 
            Dim orderCost As Integer = 2500

            ' Define a LINQ query that returns only online orders 
            ' more than the specified amount. 
            Dim onlineOrders = From order In context.SalesOrderHeaders _
                               Where order.OnlineOrderFlag = True AndAlso order.TotalDue > orderCost _
                               Select order

            ' Print order information. 
            For Each onlineOrder In onlineOrders
                Console.WriteLine("Order ID: {0} Order date: ", onlineOrder.SalesOrderID)
                Console.WriteLine("Order date: {0:d}", onlineOrder.OrderDate)
                Console.WriteLine("Order number: {0}", onlineOrder.SalesOrderNumber)
            Next
        End Using
        '</snippetFilterQueryLinq> 
    End Sub
    Public Shared Sub FilterQueryEsql()
        Console.WriteLine("Starting method 'FilterQueryEsql'")
        '<snippetFilterQueryEsql> 
        Using context As New AdventureWorksEntities()
            ' Specify the order amount. 
            Dim orderCost As Decimal = 2500

            ' Specify the Entity SQL query that returns only online orders 
            ' more than the specified amount. 
            Dim queryString As String = "SELECT VALUE o FROM AdventureWorksEntities.SalesOrderHeaders AS o " & _
                                        " WHERE o.OnlineOrderFlag = TRUE AND o.TotalDue > @ordercost"

            ' Define an ObjectQuery and pass the maxOrderCost parameter. 
            Dim onlineOrders As New ObjectQuery(Of SalesOrderHeader)(queryString, context)
            onlineOrders.Parameters.Add(New ObjectParameter("ordercost", orderCost))

            ' Print order information. 
            For Each onlineOrder In onlineOrders
                Console.WriteLine("Order ID: {0} Order date: {1:d} Order number: {2}", _
                                  onlineOrder.SalesOrderID, onlineOrder.OrderDate, onlineOrder.SalesOrderNumber)
            Next
        End Using
        '</snippetFilterQueryEsql> 
    End Sub
    Public Shared Sub FilterQuery()
        Console.WriteLine("Starting method 'FilterQuery'")
        '<snippetFilterQuery> 
        Using context As New AdventureWorksEntities()
            ' Specify the order amount. 
            Dim orderCost As Integer = 2500

            ' Define an ObjectQuery that returns only online orders 
            ' more than the specified amount. 
            Dim onlineOrders As ObjectQuery(Of SalesOrderHeader) = _
                context.SalesOrderHeaders.Where("it.OnlineOrderFlag = TRUE AND it.TotalDue > @ordercost", _
                                                New ObjectParameter("ordercost", orderCost))

            ' Print order information. 
            For Each onlineOrder In onlineOrders
                Console.WriteLine("Order ID: {0} Order date: {1:d} Order number: {2}", _
                                  onlineOrder.SalesOrderID, onlineOrder.OrderDate, onlineOrder.SalesOrderNumber)
            Next
        End Using
        '</snippetFilterQuery> 
    End Sub
    Public Shared Sub SortQueryLinq()
        Console.WriteLine("Starting method 'SortQueryLinq'")
        '<snippetSortQueryLinq> 
        Using context As New AdventureWorksEntities()
            ' Define a query that returns a list 
            ' of Contact objects sorted by last name. 
            Dim sortedNames = From n In context.Contacts _
                              Order By n.LastName _
                              Select n

            Console.WriteLine("The sorted list of last names:")
            For Each name As Contact In sortedNames
                Console.WriteLine(name.LastName)
            Next
        End Using
        '</snippetSortQueryLinq> 
    End Sub
    Public Shared Sub SortQueryEsql()
        Console.WriteLine("Starting method 'SortQueryEsql'")
        '<snippetSortQueryEsql> 
        ' Define the Entity SQL query string that returns 
        ' Contact objects sorted by last name. 
        Dim queryString As String = "SELECT VALUE contact FROM Contacts AS contact Order By contact.LastName"

        Using context As New AdventureWorksEntities()
            ' Define an ObjectQuery that returns a collection 
            ' of Contact objects sorted by last name. 
            Dim query As New ObjectQuery(Of Contact)(queryString, context)

            Console.WriteLine("The sorted list of last names:")
            For Each name As Contact In query.Execute(MergeOption.AppendOnly)
                Console.WriteLine(name.LastName)
            Next
        End Using
        '</snippetSortQueryEsql> 
    End Sub
    Public Shared Sub SortQuery()
        Console.WriteLine("Starting method 'SortQuery'")
        '<snippetSortQuery> 
        Using context As New AdventureWorksEntities()
            ' Define an ObjectQuery that returns a collection 
            ' of Contact objects sorted by last name. 
            Dim query As ObjectQuery(Of Contact) = context.Contacts.OrderBy("it.LastName")

            Console.WriteLine("The sorted list of last names:")
            For Each name As Contact In query.Execute(MergeOption.AppendOnly)
                Console.WriteLine(name.LastName)
            Next
        End Using
        '</snippetSortQuery> 
    End Sub
    Public Shared Sub QueryEntityCollection()
        Console.WriteLine("Starting method 'QueryEntityCollection'")
        '<snippetQueryEntityCollection> 

        ' Specify the customer ID. 
        Dim customerId As Integer = 4332

        Using context As New AdventureWorksEntities()
            ' Get a specified customer by contact ID. 
            Dim customer = (From customers In context.Contacts _
                            Where customers.ContactID = customerId _
                            Select customers).First()

            ' You do not have to call the Load method to load the orders for the customer, 
            ' because lazy loading is set to true 
            ' by the constructor of the AdventureWorksEntities object. 
            ' With lazy loading set to true the related objects are loaded when 
            ' you access the navigation property. In this case SalesOrderHeaders. 

            ' Write the number of orders for the customer. 
            Console.WriteLine("Customer '{0}' has placed {1} total orders.", _
                              customer.LastName, customer.SalesOrderHeaders.Count)

            ' Get the online orders that have shipped. 
            Dim shippedOrders = From order In customer.SalesOrderHeaders _
                                Where order.OnlineOrderFlag = True AndAlso order.Status = 5 _
                                Select order

            ' Write the number of orders placed online. 
            Console.WriteLine("{0} orders placed online have been shipped.", shippedOrders.Count())
        End Using
        '</snippetQueryEntityCollection> 
    End Sub
    Public Shared Sub QueryCreateSourceQuery()
        Console.WriteLine("Starting method 'QueryCreateSourceQuery'")
        '<snippetQueryCreateSourceQuery> 

        ' Specify the customer ID. 
        Dim customerId As Integer = 4332

        Using context As New AdventureWorksEntities()
            ' Get a specified customer by contact ID. 
            Dim customer = (From customers In context.Contacts
                            Where customers.ContactID = customerId
                            Select customers).First()

            ' Use CreateSourceQuery to generate a query that returns 
            ' only the online orders that have shipped. 
            Dim shippedOrders = From orders In customer.SalesOrderHeaders.CreateSourceQuery() _
                                Where orders.OnlineOrderFlag = True AndAlso orders.Status = 5 _
                                Select orders

            ' Write the number of orders placed online. 
            Console.WriteLine("{0} orders placed online have been shipped.", shippedOrders.Count())

            ' You do not have to call the Load method to load the orders for the customer, 
            ' because lazy loading is set to true 
            ' by the constructor of the AdventureWorksEntities object. 
            ' With lazy loading set to true the related objects are loaded when 
            ' you access the navigation property. In this case SalesOrderHeaders. 

            ' Write the number of total orders for the customer. 
            Console.WriteLine("Customer '{0}' has placed {1} total orders.", _
                              customer.LastName, customer.SalesOrderHeaders.Count)
        End Using
        '</snippetQueryCreateSourceQuery> 
    End Sub
    Public Shared Sub LoadSelectedObjects()
        Console.WriteLine("Starting method 'LoadSelectedObjects'")
        '<snippetLoadSelectedObjects> 
        ' Specify the customer ID. 
        Dim customerId As Integer = 4332

        Using context As New AdventureWorksEntities()
            ' Get a specified customer by contact ID. 
            Dim customer As Contact = context.Contacts.Where("it.ContactID = @customerId", _
                                                             New ObjectParameter("customerId", customerId)).First()

            ' Return the customer's first five orders with line items and 
            ' attach them to the SalesOrderHeader collection. 
            customer.SalesOrderHeaders.Attach(customer.SalesOrderHeaders.CreateSourceQuery().Include("SalesOrderDetails").Take(5))

            For Each order As SalesOrderHeader In customer.SalesOrderHeaders
                Console.WriteLine(String.Format("PO Number: {0}", order.PurchaseOrderNumber))
                Console.WriteLine(String.Format("Order Date: {0}", order.OrderDate.ToString()))
                Console.WriteLine("Order items:")

                For Each item As SalesOrderDetail In order.SalesOrderDetails
                    Console.WriteLine(String.Format("Product: {0} Quantity: {1}", _
                                                      item.ProductID.ToString(), item.OrderQty.ToString()))
                Next
            Next
        End Using
        '</snippetLoadSelectedObjects>> 
    End Sub

#End Region
    Public Shared Sub QueryWithMultipleSpan()
        Console.WriteLine("Starting method 'QueryWithMultiplePaths'")
        '<snippetQueryWithMultiplePaths> 
        Using context As New AdventureWorksEntities()
            '<snippetSpanOnlyWithMultiplePaths> 
            ' Create a SalesOrderHeader query with two query paths, 
            ' one that returns order items and a second that returns the 
            ' billing and shipping addresses for each order. 
            Dim query As ObjectQuery(Of SalesOrderHeader) = context.SalesOrderHeaders.Include("SalesOrderDetails").Include("Address")
            '</snippetSpanOnlyWithMultiplePaths> 

            ' Execute the query and display information for each item 
            ' in the orders that belong to the first contact. 
            For Each order As SalesOrderHeader In query.Top("10")
                Console.WriteLine(String.Format("PO Number: {0}", order.PurchaseOrderNumber))
                Console.WriteLine(String.Format("Order Date: {0}", order.OrderDate.ToString()))
                Console.WriteLine(String.Format("Bill to city and postal code: {0}, {1}", _
                                                  order.Address.City.ToString(), order.Address.PostalCode.ToString()))
                Console.WriteLine(String.Format("Ship to city and postal code: {0}, {1}", _
                                                  order.Address1.City.ToString(), order.Address1.PostalCode.ToString()))
                Console.WriteLine("Order items:")
                For Each item As SalesOrderDetail In order.SalesOrderDetails
                    Console.WriteLine(String.Format("Product: {0} Quantity: {1}", _
                                                      item.ProductID.ToString(), item.OrderQty.ToString()))
                Next
            Next
        End Using
        '</snippetQueryWithMultiplePaths> 
    End Sub
    Public Shared Sub OpenConnection()
        Console.WriteLine("Starting method 'OpenConnection'")
        '<snippetOpenConnection> 
        ' Define the order ID for the order we want. 
        Dim orderId As Integer = 43680

        Using context As New AdventureWorksEntities()
            '<snippetOpenConnection_line> 
            ' Explicitly open the connection. 
            context.Connection.Open()
            '</snippetOpenConnection_line> 

            ' Execute a query to return an order. 
            Dim order As SalesOrderHeader = context.SalesOrderHeaders.Where("it.SalesOrderID = @orderId", _
                                                New ObjectParameter("orderId", orderId)).Execute(MergeOption.AppendOnly).First()


            ' Change the status of the order. 
            order.Status = 1

            ' Save changes. 
            If 0 < context.SaveChanges() Then
                Console.WriteLine("Changes saved.")
            End If
            ' The connection is closed when the object context 
            ' is disposed because it is no longer in scope. 
        End Using
        '</snippetOpenConnection> 
    End Sub
    Public Shared Sub OpenConnection_Long()
        Console.WriteLine("Starting method 'OpenConnection_Long'")
        '<snippetOpenConnectionLong> 
        ' Define the order ID for the order we want. 
        Dim orderId As Integer = 43680

        ' Create a long-running context. 
        Dim context As New AdventureWorksEntities()
        Try
            If context.Connection.State <> ConnectionState.Open Then
                ' Explicitly open the connection. 
                context.Connection.Open()
            End If

            ' Execute a query to return an order. 
            Dim order As SalesOrderHeader = context.SalesOrderHeaders.Where("it.SalesOrderID = @orderId", _
                                                New ObjectParameter("orderId", orderId)).Execute(MergeOption.AppendOnly).First()

            ' Change the status of an existing order. 
            order.Status = 1

            ' You do not have to call the Load method to load the details for the order, 
            ' because lazy loading is set to true 
            ' by the constructor of the AdventureWorksEntities object. 
            ' With lazy loading set to true the related objects are loaded when 
            ' you access the navigation property. In this case SalesOrderDetails. 

            ' Delete the first item in the order. 
            context.DeleteObject(order.SalesOrderDetails.First())

            ' Save changes. 
            If 0 < context.SaveChanges() Then
                Console.WriteLine("Changes saved.")
            End If

            ' Create a new SalesOrderDetail object. 
            ' You can use the static CreateObjectName method (the Entity Framework 
            ' adds this method to the generated entity types) instead of the new operator: 
            ' SalesOrderDetail.CreateSalesOrderDetail(1, 0, 2, 750, 1, (decimal)2171.2942, 0, 0, 
            ' Guid.NewGuid(), DateTime.Today)); 
            Dim detail = New SalesOrderDetail With
            {
                .SalesOrderID = 0,
                .SalesOrderDetailID = 0,
                .OrderQty = 2,
                .ProductID = 750,
                .SpecialOfferID = 1,
                .UnitPrice = CDec(2171.2942),
                .UnitPriceDiscount = 0,
                .LineTotal = 0,
                .rowguid = Guid.NewGuid(),
                .ModifiedDate = DateTime.Now
            }

            order.SalesOrderDetails.Add(detail)


            ' Save changes again. 
            If 0 < context.SaveChanges() Then
                Console.WriteLine("Changes saved.")
            End If
        Catch ex As InvalidOperationException
            Console.WriteLine(ex.ToString())
        Finally
            ' Explicitly dispose of the context, 
            ' which closes the connection. 
            context.Dispose()
            '</snippetOpenConnectionLong> 
        End Try
    End Sub

    Public Shared Sub OpenEntityConnection()
        Console.WriteLine("Starting method 'OpenEntityConnection'")
        '<snippetOpenEntityConnection> 
        ' Define the order ID for the order we want. 
        Dim orderId As Integer = 43680

        '<snippetOpenEntityConnectionLine> 
        ' Create an EntityConnection. 
        Dim conn As New EntityConnection("name=AdventureWorksEntities")

        ' Create a long-running context with the connection. 
        Dim context As New AdventureWorksEntities(conn)
        '</snippetOpenEntityConnectionLine> 

        Try
            ' Explicitly open the connection. 
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If

            ' Execute a query to return an order. 
            Dim order As SalesOrderHeader = context.SalesOrderHeaders.Where("it.SalesOrderID = @orderId", _
                                                New ObjectParameter("orderId", orderId)).Execute(MergeOption.AppendOnly).First()

            ' Change the status of the order. 
            order.Status = 1

            ' You do not have to call the Load method to load the details for the order, 
            ' because lazy loading is set to true 
            ' by the constructor of the AdventureWorksEntities object. 
            ' With lazy loading set to true the related objects are loaded when 
            ' you access the navigation property. In this case SalesOrderDetails. 

            ' Delete the first item in the order. 
            context.DeleteObject(order.SalesOrderDetails.First())

            ' Save changes. 
            If 0 < context.SaveChanges() Then
                Console.WriteLine("Changes saved.")
            End If

            ' Create a new SalesOrderDetail object. 
            ' You can use the static CreateObjectName method (the Entity Framework 
            ' adds this method to the generated entity types) instead of the new operator: 
            ' SalesOrderDetail.CreateSalesOrderDetail(1, 0, 2, 750, 1, (decimal)2171.2942, 0, 0, 
            ' Guid.NewGuid(), DateTime.Today)); 
            Dim detail = New SalesOrderDetail With
            {
                .SalesOrderID = 0,
                .SalesOrderDetailID = 0,
                .OrderQty = 2,
                .ProductID = 750,
                .SpecialOfferID = 1,
                .UnitPrice = CDec(2171.2942),
                .UnitPriceDiscount = 0,
                .LineTotal = 0,
                .rowguid = Guid.NewGuid(),
                .ModifiedDate = DateTime.Now
            }

            order.SalesOrderDetails.Add(detail)

            ' Save changes again. 
            If 0 < context.SaveChanges() Then
                Console.WriteLine("Changes saved.")
            End If
        Catch ex As InvalidOperationException
            Console.WriteLine(ex.ToString())
        Finally
            ' Explicitly dispose of the context and the connection. 
            context.Dispose()
            conn.Dispose()
            '</snippetOpenEntityConnection> 
        End Try
    End Sub
    Public Shared Sub BuildObjectGraphAndAttach()
        Console.WriteLine("Starting method 'AttachRelatedObjects'")

        Dim order As New SalesOrderHeader()
        Dim items As New List(Of SalesOrderDetail)()

        ' First load up some objects and then drop the context. 
        Using context As New AdventureWorksEntities()

            Dim customer As Contact = context.Contacts.Include("SalesOrderHeaders.SalesOrderDetails").First()
            order = customer.SalesOrderHeaders.First()

            While order.SalesOrderDetails.Count > 0
                Dim item As SalesOrderDetail = order.SalesOrderDetails.First()
                ' Add the item to the List and detach. 
                items.Add(item)
                context.Detach(item)
            End While

            ' Remove the existing relationships. 
            order.SalesOrderDetails.Clear()

            ' Detach the order. 
            context.Detach(order)

            ' Call AttachRelatedObjects. 
            AttachRelatedObjects(context, order, items)

            ' Detach items. 
            For Each item As SalesOrderDetail In items
                context.Detach(item)
            Next

            ' Remove the existing relationships. 
            order.SalesOrderDetails.Clear()

            ' Detach the order. 
            context.Detach(order)

            ' Call AttachObjectGraph. 

            AttachObjectGraph(context, order, items)
        End Using
    End Sub
    '<snippetAttachObjectGraph> 
    Private Shared Sub AttachObjectGraph(ByVal currentContext As ObjectContext, ByVal detachedOrder As SalesOrderHeader, ByVal detachedItems As List(Of SalesOrderDetail))
        ' Define the relationships by adding each SalesOrderDetail 
        ' object in the detachedItems List<SalesOrderDetail> collection to the 
        ' EntityCollection on the SalesOrderDetail navigation property of detachedOrder. 
        For Each item As SalesOrderDetail In detachedItems
            detachedOrder.SalesOrderDetails.Add(item)
        Next

        ' Attach the object graph to the supplied context. 
        currentContext.Attach(detachedOrder)
    End Sub
    '</snippetAttachObjectGraph> 
    '<snippetAttachRelatedObjects> 
    Private Shared Sub AttachRelatedObjects(ByVal currentContext As ObjectContext, ByVal detachedOrder As SalesOrderHeader, ByVal detachedItems As List(Of SalesOrderDetail))
        ' Attach the root detachedOrder object to the supplied context. 
        currentContext.Attach(detachedOrder)

        ' Attach each detachedItem to the context, and define each relationship 
        ' by attaching the attached SalesOrderDetail object to the EntityCollection on 
        ' the SalesOrderDetail navigation property of the now attached detachedOrder. 
        For Each item As SalesOrderDetail In detachedItems
            currentContext.Attach(item)
            detachedOrder.SalesOrderDetails.Attach(item)
        Next
    End Sub
    '</snippetAttachRelatedObjects> 
    Public Shared Sub DetachAndUpdateItem()
        Console.WriteLine("Starting method 'DetachAndUpdateItem'")

        Using context As New AdventureWorksEntities()
            ' Get an item to detach. 
            Dim originalItem As SalesOrderDetail = context.SalesOrderDetails.First()

            ' Get the order for the item and set the status to 1, 
            ' or an exception will occur when the item Qty is changed. 
            If Not originalItem.SalesOrderHeaderReference.IsLoaded Then
                originalItem.SalesOrderHeaderReference.Load()
            End If

            originalItem.SalesOrderHeader.Status = 1

            Console.WriteLine("Original qty:" & originalItem.OrderQty.ToString())

            ' Detach the item. 
            context.Detach(originalItem)
            ' Create a new updated item and change the status. 
            Dim obj As Object = Nothing

            context.TryGetObjectByKey(originalItem.EntityKey, obj)

            If Object.ReferenceEquals(obj, originalItem) Then
                Throw New InvalidOperationException("Refs are identical.")
            End If
            Dim updatedItem As SalesOrderDetail = DirectCast(obj, SalesOrderDetail)
            updatedItem.OrderQty += 1
            updatedItem.ModifiedDate = DateTime.Today

            context.Detach(updatedItem)
            Dim newItem As SalesOrderDetail = SalesOrderDetail.CreateSalesOrderDetail(43680, 0, 5, 711, 1, CDec(13.0368), _
            0, 0, Guid.NewGuid(), DateTime.Now)

            ApplyItemUpdates(originalItem, newItem)

            Console.WriteLine("Updated qty:" & originalItem.OrderQty.ToString())

            updatedItem.OrderQty += 1

            'ApplyItemUpdates(updatedItem); 


            Console.WriteLine("Updated qty:" & originalItem.OrderQty.ToString())
        End Using
    End Sub

    '<snippetApplyItemUpdates> 
    Private Shared Sub ApplyItemUpdates(ByVal originalItem As SalesOrderDetail, ByVal updatedItem As SalesOrderDetail)
        Using context As New AdventureWorksEntities()
            context.SalesOrderDetails.Attach(updatedItem)
            ' Check if the ID is 0, if it is the item is new. 
            ' In this case we need to chage the state to Added. 
            If updatedItem.SalesOrderDetailID = 0 Then
                ' Because the ID is generated by the database we do not need to 
                ' set updatedItem.SalesOrderDetailID. 
                context.ObjectStateManager.ChangeObjectState(updatedItem, System.Data.EntityState.Added)
            Else
                ' If the SalesOrderDetailID is not 0, then the item is not new 
                ' and needs to be updated. Because we already added the 
                ' updated object to the context we need to apply the original values. 
                ' If we attached originalItem to the context 
                ' we would need to apply the current values: 
                ' context.ApplyCurrentValues("SalesOrderDetails", updatedItem); 
                ' Applying current or original values, changes the state 
                ' of the attached object to Modified. 
                context.ApplyOriginalValues("SalesOrderDetails", originalItem)
            End If
            context.SaveChanges()
        End Using
    End Sub
    '</snippetApplyItemUpdates> 

    '<snippetApplyItemUpdatesGetObject> 
    Private Shared Sub ApplyItemUpdates(ByVal updatedItem As SalesOrderDetail)
        ' Define an ObjectStateEntry and EntityKey for the current object. 
        Dim key As EntityKey
        Dim originalItem As Object

        Using context As New AdventureWorksEntities()
            ' Create the detached object's entity key. 
            key = context.CreateEntityKey("SalesOrderDetails", updatedItem)

            ' Get the original item based on the entity key from the context 
            ' or from the database. 
            If context.TryGetObjectByKey(key, originalItem) Then
                ' Call the ApplyCurrentValues method to apply changes 
                ' from the updated item to the original version. 
                context.ApplyCurrentValues(key.EntitySetName, updatedItem)
            End If

            context.SaveChanges()
        End Using
    End Sub
    '</snippetApplyItemUpdatesGetObject> 

    Public Shared Sub ChangeItemQuantity()
        Console.WriteLine("Starting method 'ChangeItemQuantity'")
        '<snippetCreateSalesOrderDetail> 
        Dim orderId As Integer = 43680
        Using context As New AdventureWorksEntities()
            Dim order = (From o In context.SalesOrderHeaders
                         Where o.SalesOrderID = orderId
                         Select o).First()

            ' Add a new item. 
            '<snippetCreateSalesOrderDetailShort> 
            Dim newItem As SalesOrderDetail = SalesOrderDetail.CreateSalesOrderDetail(0, 0, 5, 711, 1, CDec(13.0368), _
            0, 0, Guid.NewGuid(), DateTime.Now)
            '</snippetCreateSalesOrderDetailShort> 
            order.SalesOrderDetails.Add(newItem)

            context.SaveChanges()
        End Using
        '</snippetCreateSalesOrderDetail> 
    End Sub
    Public Shared Sub ChangeObjectRelationship()
        Console.WriteLine("Starting method 'ChangeObjectRelationship'")
        '<snippetChangeObjectRelationship> 

        ' Define the order and new address IDs. 
        Dim orderId As Integer = 43669
        Dim addressId As Integer = 26

        Using context As New AdventureWorksEntities()
            ' Get the billing address to change to. 
            Dim address As Address = context.Addresses.Single(Function(c) c.AddressID = addressId)

            ' Get the order being changed. 
            Dim order As SalesOrderHeader = context.SalesOrderHeaders.Single(Function(o) o.SalesOrderID = orderId)

            ' You do not have to call the Load method to load the addresses for the order, 
            ' because lazy loading is set to true 
            ' by the constructor of the AdventureWorksEntities object. 
            ' With lazy loading set to true the related objects are loaded when 
            ' you access the navigation property. In this case Address. 

            ' Write the current billing street address. 
            Console.WriteLine("Current street: " & order.Address.AddressLine1)

            ' Change the billing address. 
            If Not order.Address.Equals(address) Then
                ' Use Address navigation property to change the association. 
                order.Address = address

                ' Write the changed billing street address. 
                Console.WriteLine("Changed street: " & order.Address.AddressLine1)
            End If

            ' If the address change succeeds, save the changes. 
            context.SaveChanges()

            ' Write the current billing street address. 
            Console.WriteLine("Current street: " & order.Address.AddressLine1)
        End Using
        '</snippetChangeObjectRelationship> 
    End Sub

    Public Shared Sub ChangeObjectRelationshipUsingFKProperty()
        Console.WriteLine("Starting method 'ChangeObjectRelationshipUsingFKProperty'")
        ' The following code uses foreign key property to change the relationship. 

        '<snippetChangeObjectRelationshipUsingFKProperty> 
        Dim orderId As Integer = 43669
        Dim addressId As Integer = 24

        Using context As New AdventureWorksEntities()
            ' Get the order being changed. 
            Dim order As SalesOrderHeader = context.SalesOrderHeaders.First(Function(o) o.SalesOrderID = orderId)

            ' Chage the billing address. 
            order.BillToAddressID = addressId

            ' Write the current billing street address. 
            Console.WriteLine("Updated street: " & order.Address.AddressLine1)

            ' Save the changes. 

            context.SaveChanges()
        End Using
        '</snippetChangeObjectRelationshipUsingFKProperty> 
    End Sub

    Public Shared Sub AddObjectUsingKey()
        Console.WriteLine("Starting method 'AddObjectUsingKey'")
        ' Specify the order to which to add the item. 
        Dim orderId As Integer = 43680
        '<snippetAddObjectUsingStandInSalesOrderHeaders> 
        Using context As New AdventureWorksEntities()
            ' Create the stand-in SalesOrderHeader object 
            ' based on the specified SalesOrderID. 
            Dim order = New SalesOrderHeader() With
            {
                .SalesOrderID = orderId
            }

            ' Attach the stand-in SalesOrderHeader object. 
            context.SalesOrderHeaders.Attach(order)

            ' Create a new SalesOrderDetail object. 
            ' You can use the static CreateObjectName method (the Entity Framework 
            ' adds this method to the generated entity types) instead of the new operator: 
            ' SalesOrderDetail.CreateSalesOrderDetail(1, 0, 2, 750, 1, (decimal)2171.2942, 0, 0, 
            ' Guid.NewGuid(), DateTime.Today)); 
            Dim detail = New SalesOrderDetail With
            {
                .SalesOrderID = 0,
                .SalesOrderDetailID = 0,
                .OrderQty = 2,
                .ProductID = 750,
                .SpecialOfferID = 1,
                .UnitPrice = CDec(2171.2942),
                .UnitPriceDiscount = 0,
                .LineTotal = 0,
                .rowguid = Guid.NewGuid(),
                .ModifiedDate = DateTime.Now
            }

            order.SalesOrderDetails.Add(detail)

            context.SaveChanges()
        End Using
        '</snippetAddObjectUsingStandInSalesOrderHeaders> 
        '<snippetAddObjectUsingKey> 
        Using context As New AdventureWorksEntities()
            Try
                ' Create the key that represents the order. 
                Dim orderKey As New EntityKey("AdventureWorksEntities.SalesOrderHeaders", "SalesOrderID", orderId)

                ' Create the stand-in SalesOrderHeader object 
                ' based on the specified SalesOrderID. 
                Dim order As New SalesOrderHeader()
                order.EntityKey = orderKey

                ' Assign the ID to the SalesOrderID property to matche the key. 
                order.SalesOrderID = CInt(orderKey.EntityKeyValues(0).Value)

                ' Attach the stand-in SalesOrderHeader object. 
                context.SalesOrderHeaders.Attach(order)

                ' Create a new SalesOrderDetail object. 
                ' You can use the static CreateObjectName method (the Entity Framework 
                ' adds this method to the generated entity types) instead of the new operator: 
                ' SalesOrderDetail.CreateSalesOrderDetail(1, 0, 2, 750, 1, (decimal)2171.2942, 0, 0, 
                ' Guid.NewGuid(), DateTime.Today)); 
                Dim detail = New SalesOrderDetail With
                {
                    .SalesOrderID = 0,
                    .SalesOrderDetailID = 0,
                    .OrderQty = 2,
                    .ProductID = 750,
                    .SpecialOfferID = 1,
                    .UnitPrice = CDec(2171.2942),
                    .UnitPriceDiscount = 0,
                    .LineTotal = 0,
                    .rowguid = Guid.NewGuid(),
                    .ModifiedDate = DateTime.Now
                }

                order.SalesOrderDetails.Add(detail)

                context.SaveChanges()
            Catch generatedExceptionName As InvalidOperationException
                Console.WriteLine("Ensure that the key value matches the value of the object's ID property.")
            Catch generatedExceptionName As UpdateException
                Console.WriteLine("An error has occurred. Ensure that an object with the '{0}' key value exists.", orderId)
            End Try
        End Using
        '</snippetAddObjectUsingKey> 
    End Sub
    Public Shared Sub QueryWithAlias()
        Console.WriteLine("Starting method 'QueryWithAlias'")
        Using context As New AdventureWorksEntities()
            '<snippetQueryWithAliasNamed> 
            '<snippetQueryWithAlias> 
            ' Return Product objects with a standard cost 
            ' above 10 dollars. 
            Dim cost = 10
            Dim productQuery As ObjectQuery(Of Product) = context.Products.Where("it.StandardCost > @cost")
            productQuery.Parameters.Add(New ObjectParameter("cost", cost))
            '</snippetQueryWithAlias> 

            ' Set the Name property for the query and then 
            ' use that name as the alias in the subsequent 
            ' OrderBy method. 
            productQuery.Name = "product"
            Dim filteredProduct As ObjectQuery(Of Product) = productQuery.OrderBy("product.ProductID")
            '</snippetQueryWithAliasNamed> 

            ' Iterate through the collection of Product items. 
            For Each result As Product In filteredProduct
                Console.WriteLine("Product Name: {0}; Product ID: {1}", result.Name, result.ProductID)
            Next
        End Using
    End Sub
    Public Shared Sub QueryWithParams()
        Console.WriteLine("Starting method 'QueryWithParams'")
        '<snippetQueryWithParams> 
        Dim firstName As String = "Frances"
        Dim lastName As String = "Adams"

        Using context As New AdventureWorksEntities()
            '<snippetQueryWithParamsOnly> 
            ' Get the contacts with the specified name. 
            Dim contactQuery As ObjectQuery(Of Contact) = context.Contacts.Where("it.LastName = @ln AND it.FirstName = @fn", _
                                                             New ObjectParameter("ln", lastName), New ObjectParameter("fn", firstName))
            '</snippetQueryWithParamsOnly> 

            ' Iterate through the collection of Contact items. 
            For Each result As Contact In contactQuery
                Console.WriteLine("Last Name: {0}; First Name: {1}", result.LastName, result.FirstName)
            Next
        End Using
        '</snippetQueryWithParams> 
    End Sub
    Public Shared Sub QueryWithSpan()
        Console.WriteLine("Starting method 'QueryWithSpan'")
        '<snippetQueryWithSpan> 
        Using context As New AdventureWorksEntities()
            '<snippetSpanOnly> 
            ' Define an object query with a path that returns 
            ' orders and items for a specific contact. 
            Dim contact As Contact = context.Contacts.Include("SalesOrderHeaders.SalesOrderDetails").FirstOrDefault()
            '</snippetSpanOnly> 

            ' Execute the query and display information for each item 
            ' in the orders that belong to the first contact. 
            For Each order As SalesOrderHeader In contact.SalesOrderHeaders
                Console.WriteLine(String.Format("PO Number: {0}", order.PurchaseOrderNumber))
                Console.WriteLine(String.Format("Order Date: {0}", order.OrderDate.ToString()))
                Console.WriteLine("Order items:")
                For Each item As SalesOrderDetail In order.SalesOrderDetails
                    Console.WriteLine(String.Format("Product: {0} Quantity: {1}", _
                                                      item.ProductID.ToString(), item.OrderQty.ToString()))
                Next
            Next
        End Using
        '</snippetQueryWithSpan> 
    End Sub
    Public Shared Sub QueryWithSpanLinq()
        Console.WriteLine("Starting method 'QueryWithSpanLinq'")
        '<snippetQueryWithSpanLinq> 
        Using context As New AdventureWorksEntities()
            '<snippetSpanLinqOnly> 
            ' Define a LINQ query with a path that returns 
            ' orders and items for a contact. 
            Dim contacts = (From contact In context.Contacts.Include("SalesOrderHeaders.SalesOrderDetails") _
                            Select contact).FirstOrDefault()
            '</snippetSpanLinqOnly> 

            ' Execute the query and display information for each item 
            ' in the orders that belong to the contact. 
            For Each order As SalesOrderHeader In contacts.SalesOrderHeaders
                Console.WriteLine(String.Format("PO Number: {0}", order.PurchaseOrderNumber))
                Console.WriteLine(String.Format("Order Date: {0}", order.OrderDate.ToString()))
                Console.WriteLine("Order items:")
                For Each item As SalesOrderDetail In order.SalesOrderDetails
                    Console.WriteLine(String.Format("Product: {0} Quantity: {1}", _
                                                      item.ProductID.ToString(), item.OrderQty.ToString()))
                Next
            Next
        End Using
        '</snippetQueryWithSpanLinq> 
    End Sub
    Public Shared Sub QueryWithSpanEsql()
        Console.WriteLine("Starting method 'QueryWithSpanEsql'")
        '<snippetQueryWithSpanEsql> 
        Using context As New AdventureWorksEntities()
            '<snippetSpanEsqlOnly> 
            ' Define an object query with a path that returns 
            ' orders and items for a specific contact. 
            Dim queryString As String = "SELECT VALUE TOP(1) contact FROM AdventureWorksEntities.Contacts AS contact"

            ' Define the object query with the query string. 
            Dim contactQuery As New ObjectQuery(Of Contact)(queryString, context, MergeOption.NoTracking)

            Dim contact As Contact = contactQuery.Include("SalesOrderHeaders.SalesOrderDetails").FirstOrDefault()
            '</snippetSpanEsqlOnly> 

            ' Execute the query and display information for each item 
            ' in the orders that belong to the first contact. 
            For Each order As SalesOrderHeader In contact.SalesOrderHeaders
                Console.WriteLine(String.Format("PO Number: {0}", order.PurchaseOrderNumber))
                Console.WriteLine(String.Format("Order Date: {0}", order.OrderDate.ToString()))
                Console.WriteLine("Order items:")
                For Each item As SalesOrderDetail In order.SalesOrderDetails
                    Console.WriteLine(String.Format("Product: {0} Quantity: {1}", _
                                                      item.ProductID.ToString(), item.OrderQty.ToString()))
                Next
            Next
        End Using
        '</snippetQueryWithSpanEsql> 
    End Sub
    Public Shared Sub QueryEntityType()
        Console.WriteLine("Starting method 'QueryEntityType'")
        '<snippetQueryEntityType> 
        Using context As New AdventureWorksEntities()
            Dim productQuery As ObjectSet(Of Product) = context.Products

            ' Iterate through the collection of Product items. 
            For Each result As Product In productQuery
                Console.WriteLine("Product Name: {0}; Product ID: {1}", result.Name, result.ProductID)
            Next
        End Using
        '</snippetQueryEntityType> 
    End Sub
    Public Shared Sub QueryEntityTypeCollection()
        '<snippetQueryEntityTypeCollection>
        Using context As New AdventureWorksEntities()
            Dim query As ObjectQuery(Of Contact) = _
                context.Contacts.Where("it.LastName==@ln",
                New ObjectParameter("ln", "Zhou"))

            ' Iterate through the collection of Contact items.
            For Each result As Contact In query
                Console.WriteLine("Contact First Name: {0}; Last Name: {1}", _
                        result.FirstName, result.LastName)
            Next
        End Using
        ' </snippetQueryEntityTypeCollection>

    End Sub

    Public Shared Sub QueryAnonymousType()
        Console.WriteLine("Starting method 'QueryAnonymousType'")
        '<snippetQueryAnonymousType> 
        Using context As New AdventureWorksEntities()
            ' Use the Select method to define the projection. 
            Dim query As ObjectQuery(Of DbDataRecord) = context.Products.Select("it.ProductID, it.Name")

            ' Iterate through the collection of data rows. 
            For Each rec As DbDataRecord In query
                Console.WriteLine("ID {0}; Name {1}", rec(0), rec(1))
            Next
        End Using
        '</snippetQueryAnonymousType> 
    End Sub
    Public Shared Sub QueryPrimitiveTypeLinq()
        Console.WriteLine("Starting method 'QueryPrimitiveTypeLinq'")
        '<snippetQueryPrimitiveTypeLinq> 
        Dim contactId As Integer = 377

        Using context As New AdventureWorksEntities()
            ' Select a value. 
            Dim orders As ObjectSet(Of SalesOrderHeader) = context.SalesOrderHeaders

            Dim orderQuery As IQueryable(Of Int32) = From order In orders _
                                                     Where order.Contact.ContactID = contactId _
                                                     Select order.PurchaseOrderNumber.Length

            ' Iterate through the collection of values. 
            For Each result As Int32 In orderQuery
                Console.WriteLine("{0}", result)
            Next

            ' Use a nullable DateTime value because ShipDate can be null. 
            '<snippetQueryPrimitiveTypeLinqShort> 
            Dim shipDateQuery As IQueryable(Of System.Nullable(Of DateTime)) = From order In orders _
                                                                               Where order.Contact.ContactID = contactId _
                                                                               Select order.ShipDate
            '</snippetQueryPrimitiveTypeLinqShort> 

            ' Iterate through the collection of values. 
            For Each shipDate As System.Nullable(Of DateTime) In shipDateQuery
                Dim shipDateMessage As String = "date not set"

                If shipDate IsNot Nothing Then
                    shipDateMessage = shipDate.ToString()
                End If
                Console.WriteLine("Ship Date: {0}.", shipDateMessage)
            Next
        End Using
        '</snippetQueryPrimitiveTypeLinq> 
    End Sub
    Public Shared Sub QueryPrimitiveTypeEsql()
        Console.WriteLine("Starting method 'QueryPrimitiveTypeEsql'")
        '<snippetQueryPrimitiveTypeEsql> 
        Dim contactId As Integer = 377

        Using context As New AdventureWorksEntities()
            Dim orderQueryString As String = "SELECT VALUE Length(order.PurchaseOrderNumber) FROM " & _
                " AdventureWorksEntities.SalesOrderHeaders AS order WHERE order.CustomerID = @contactId"
            Dim shipDateQueryString As String = "SELECT VALUE order.ShipDate" & _
                " FROM AdventureWorksEntities.SalesOrderHeaders AS order WHERE order.CustomerID = @contactId"

            ' Use the SelectValue method to select a value. 
            Dim orderQuery As New ObjectQuery(Of Int32)(orderQueryString, context, MergeOption.NoTracking)
            orderQuery.Parameters.Add(New ObjectParameter("contactId", contactId))

            ' Iterate through the collection of values. 
            For Each result As Int32 In orderQuery
                Console.WriteLine("{0}", result)
            Next

            ' Use a nullable DateTime value because ShipDate can be null. 
            Dim shipDateQuery As New ObjectQuery(Of Nullable(Of DateTime))(shipDateQueryString, context, MergeOption.NoTracking)
            shipDateQuery.Parameters.Add(New ObjectParameter("contactId", contactId))

            ' Iterate through the collection of values. 
            For Each shipDate As Nullable(Of DateTime) In shipDateQuery
                Dim shipDateMessage As String = "date not set"

                If shipDate IsNot Nothing Then
                    shipDateMessage = shipDate.ToString()
                End If
                Console.WriteLine("Ship Date: {0}.", shipDateMessage)
            Next
        End Using
        '</snippetQueryPrimitiveTypeEsql> 
    End Sub
    Public Shared Sub QueryPrimitiveType()
        Console.WriteLine("Starting method 'QueryPrimitiveType'")
        '<snippetQueryPrimitiveType> 
        Dim contactId As Integer = 377

        Using context As New AdventureWorksEntities()
            ' Use the SelectValue method to select a value. 
            Dim orderQuery As ObjectQuery(Of Int32) = context.SalesOrderHeaders.Where("it.CustomerID = @contactId", _
                                New ObjectParameter("contactId", contactId)).SelectValue(Of Int32)("Length(it.PurchaseOrderNumber)")

            ' Iterate through the collection of values. 
            For Each result As Int32 In orderQuery
                Console.WriteLine("{0}", result)
            Next

            ' Use a nullable DateTime value because ShipDate can be null. 
            '<snippetQueryPrimitiveTypeShort> 
            Dim shipDateQuery As ObjectQuery(Of Nullable(Of DateTime)) = _
                context.SalesOrderHeaders.Where("it.CustomerID = @contactId", _
                    New ObjectParameter("contactId", contactId)).SelectValue(Of Nullable(Of DateTime))("it.ShipDate")
            '</snippetQueryPrimitiveTypeShort> 

            ' Iterate through the collection of values. 
            For Each shipDate As Nullable(Of DateTime) In shipDateQuery
                Dim shipDateMessage As String = "date not set"

                If shipDate IsNot Nothing Then
                    shipDateMessage = shipDate.ToString()
                End If
                Console.WriteLine("Ship Date: {0}.", shipDateMessage)
            Next
        End Using
        '</snippetQueryPrimitiveType> 
    End Sub

    Public Shared Sub ModifyObjects()
        Console.WriteLine("Starting method 'ModifyObjects'")
        '<snippetSaveChanges> 
        ' Specify the order to update. 
        Dim orderId As Integer = 43680

        Using context As New AdventureWorksEntities()
            Try
                '<snippetObjectChanges> 
                Dim order = (From o In context.SalesOrderHeaders
                             Where o.SalesOrderID = orderId
                             Select o).First()

                ' Change the status and ship date of an existing order. 
                order.Status = 1
                order.ShipDate = DateTime.Today

                ' You do not have to call the Load method to load the details for the order, 
                ' because lazy loading is set to true 
                ' by the constructor of the AdventureWorksEntities object. 
                ' With lazy loading set to true the related objects are loaded when 
                ' you access the navigation property. In this case SalesOrderDetails. 

                ' Delete the first item in the order. 
                context.DeleteObject(order.SalesOrderDetails.First())

                ' Create a new SalesOrderDetail object. 
                ' You can use the static CreateObjectName method (the Entity Framework 
                ' adds this method to the generated entity types) instead of the new operator: 
                ' SalesOrderDetail.CreateSalesOrderDetail(1, 0, 2, 750, 1, (decimal)2171.2942, 0, 0, 
                ' Guid.NewGuid(), DateTime.Today)) 
                Dim detail = New SalesOrderDetail With
                {
                    .SalesOrderID = 0,
                    .SalesOrderDetailID = 0,
                    .OrderQty = 2,
                    .ProductID = 750,
                    .SpecialOfferID = 1,
                    .UnitPrice = CDec(2171.2942),
                    .UnitPriceDiscount = 0,
                    .LineTotal = 0,
                    .rowguid = Guid.NewGuid(),
                    .ModifiedDate = DateTime.Now
                }
                order.SalesOrderDetails.Add(detail)

                '<snippetSave> 
                ' Save changes in the object context to the database. 
                Dim changes As Integer = context.SaveChanges()
                '</snippetSave> 
                '</snippetObjectChanges> 

                Console.WriteLine(changes.ToString() + " changes saved!")
                Console.WriteLine("Updated item for order: {0}", order.SalesOrderID.ToString())

                For Each item As SalesOrderDetail In order.SalesOrderDetails
                    Console.WriteLine("Item ID: {0}", item.SalesOrderDetailID.ToString())
                    Console.WriteLine("Product: {0}", item.ProductID.ToString())
                    Console.WriteLine("Quantity: {0}", item.OrderQty.ToString())
                Next
            Catch ex As UpdateException
                Console.WriteLine(ex.ToString())
            End Try
        End Using
        '</snippetSaveChanges>
    End Sub
    Public Shared Sub AddDeleteObject()
        Dim productId As Integer
        ' Add the product object. 
        productId = AddObject()

        DeleteObject(productId)
    End Sub

    Private Shared Function AddObject() As Integer
        Console.WriteLine("Starting method 'AddObject'")
        '<snippetAddObject> 
        Dim newProduct As Product

        ' Define values for the new product. 
        Dim dateTimeString As String = "1998-06-01 00:00:00.000"
        Dim productName As String = "Flat Washer 10"
        Dim productNumber As String = "FW-5600"
        Dim safetyStockLevel As Int16 = 1000
        Dim reorderPoint As Int16 = 750

        ' Convert the date time string into a DateTime instance. 
        Dim sellStartDate As DateTime
        If Not DateTime.TryParse(dateTimeString, sellStartDate) Then
            Throw New ArgumentException(String.Format("The string '{0}'cannot be converted to DateTime.", dateTimeString))
        End If

        ' Create a new Product. 
        newProduct = Product.CreateProduct(0, productName, productNumber, False, False, safetyStockLevel, _
                     reorderPoint, 0, 0, 0, DateTime.Today, Guid.NewGuid(), DateTime.Today)

        Using context As New AdventureWorksEntities()
            Try
                ' Add the new object to the context. 
                context.Products.AddObject(newProduct)

                ' Persist the new produc to the data source. 
                context.SaveChanges()

                ' Return the identity of the new product. 
                Return newProduct.ProductID
            Catch ex As UpdateException
                Throw New InvalidOperationException(String.Format("The object could not be added. Make sure that a " & _
                                                                  "product with a product number '{0}' does not aleady exist.", _
                                                                  newProduct.ProductNumber), ex)
            End Try
        End Using
        '</snippetAddObject> 
    End Function

    Private Shared Sub DeleteObject(ByVal productId As Integer)
        Console.WriteLine("Starting method 'DeleteObject'")
        '<snippetDeleteObject> 
        Dim deletedProduct As Object

        ' Define the key of the product to delete. 
        Dim productKey As New EntityKey("AdventureWorksEntities.Products", "ProductID", productId)

        Using context As New AdventureWorksEntities()
            ' Get the object to delete with the specified key. 
            If context.TryGetObjectByKey(productKey, deletedProduct) Then
                Try
                    ' Delete the object with the specified key 
                    ' and save changes to delete the row from the data source. 
                    context.DeleteObject(deletedProduct)
                    context.SaveChanges()
                Catch ex As OptimisticConcurrencyException
                    Throw New InvalidOperationException(String.Format("The product with an ID of '{0}' could not be deleted." & _
                                                                      "Make sure that any related objects are already deleted.", _
                                                                      productKey.EntityKeyValues(0).Value), ex)
                End Try
            Else
                Throw New InvalidOperationException(String.Format("The product with an ID of '{0}' could not be found." & _
                                                                  "Make sure that Product exists.", productKey.EntityKeyValues(0).Value))
            End If
        End Using
        '</snippetDeleteObject> 
    End Sub
    Public Shared Sub HandleConflicts()
        Console.WriteLine("Starting method 'HandleConflicts'")
        '<snippetConcurrency> 
        Using context As New AdventureWorksEntities()
            Try
                ' Perform an operation with a high-level of concurrency. 
                ' Change the status of all orders without an approval code. 
                Dim orders As ObjectQuery(Of SalesOrderHeader) = context.SalesOrderHeaders.Where("it.CreditCardApprovalCode IS NULL").Top("100")

                For Each order As SalesOrderHeader In orders
                    ' Reset the order status to 4 = Rejected. 
                    order.Status = 4
                Next
                '<snippetHandleConcurrencyException> 
                Try
                    ' Try to save changes, which may cause a conflict. 
                    Dim num As Integer = context.SaveChanges()
                    Console.WriteLine("No conflicts. " & num.ToString() & " updates saved.")
                Catch generatedExceptionName As OptimisticConcurrencyException
                    ' Resolve the concurrency conflict by refreshing the 
                    ' object context before re-saving changes. 
                    context.Refresh(RefreshMode.ClientWins, orders)

                    ' Save changes. 
                    context.SaveChanges()
                    Console.WriteLine("OptimisticConcurrencyException handled and changes saved")
                End Try
                '</snippetHandleConcurrencyException> 

                For Each order As SalesOrderHeader In orders
                    Console.WriteLine(("Order ID: " & order.SalesOrderID.ToString() & " Order status: ") + order.Status.ToString())
                Next
            Catch ex As UpdateException
                Console.WriteLine(ex.ToString())
            End Try
        End Using
        '</snippetConcurrency> 
    End Sub

    Public Shared Sub QueryWithLoad()
        Console.WriteLine("Starting method 'QueryWithLoad'")
        '<snippetQueryWithLoad> 
        ' Specify the customer ID. 
        Dim contactID As Integer = 4332

        Using context As New AdventureWorksEntities()
            context.ContextOptions.LazyLoadingEnabled = False

            ' Get a specified customer by contact ID. 
            Dim contact = (From c In context.Contacts
                           Where c.ContactID = contactID
                           Select c).First()

            ' Load the orders for the customer explicitly. 
            If Not contact.SalesOrderHeaders.IsLoaded Then
                contact.SalesOrderHeaders.Load()
            End If

            For Each order As SalesOrderHeader In contact.SalesOrderHeaders
                '<snippetLoad> 
                ' Load the items for the order if not already loaded. 
                If Not order.SalesOrderDetails.IsLoaded Then
                    order.SalesOrderDetails.Load()
                End If
                '</snippetLoad> 

                Console.WriteLine(String.Format("PO Number: {0}", order.PurchaseOrderNumber))
                Console.WriteLine(String.Format("Order Date: {0}", order.OrderDate.ToString()))
                Console.WriteLine("Order items:")
                For Each item As SalesOrderDetail In order.SalesOrderDetails
                    Console.WriteLine(String.Format("Product: {0} Quantity: {1}", _
                                                      item.ProductID.ToString(), item.OrderQty.ToString()))
                Next
            Next
        End Using
        '</snippetQueryWithLoad> 
    End Sub

    Public Shared Sub DirectlyExecuteCommandsAgainstStore()
        '<snippetExecuteStoreQueryWithParamReturnString> 
        Using context As New SchoolEntities()
            ' The following three queries demonstrate 
            ' three different ways of passing a parameter. 
            ' The queries return a string result type. 

            ' Use the parameter substitution pattern. 
            For Each name As String In context.ExecuteStoreQuery(Of String)("Select Name from Department where DepartmentID < {0}", 5)
                Console.WriteLine(name)
            Next

            ' Use parameter syntax with object values. 
            For Each name As String In context.ExecuteStoreQuery(Of String)("Select Name from Department where DepartmentID < @p0", 5)
                Console.WriteLine(name)
            Next
            ' Use an explicit SqlParameter. 
            For Each name As String In context.ExecuteStoreQuery(Of String)("Select Name from Department where DepartmentID < @p0", _
                                                                            New SqlParameter())
                Console.WriteLine(name)
            Next
        End Using
        '</snippetExecuteStoreQueryWithParamReturnString> 
    End Sub


    Public Shared Sub TranslateReader()
        '<snippetTranslate> 
        ' Initialize the connection string builder for the 
        ' underlying provider. 
        Dim sqlBuilder As New SqlConnectionStringBuilder()

        sqlBuilder.DataSource = "."
        sqlBuilder.InitialCatalog = "School"
        sqlBuilder.IntegratedSecurity = True

        Dim con As New SqlConnection(sqlBuilder.ToString())
        If True Then
            con.Open()
            Dim cmd As DbCommand = con.CreateCommand()
            cmd.CommandText = "SELECT * FROM Department"

            ' Create a reader that contains rows of entity data. 
            Using rdr As DbDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                Using context As New SchoolEntities()
                    ' Translate the reader to the objects of the Department type. 
                    For Each d As Department In context.Translate(Of Department)(rdr)
                        Console.WriteLine("DepartmentID: {0} ", d.DepartmentID)
                    Next
                End Using
            End Using
            con.Close()
        End If
        '</snippetTranslate> 
    End Sub
    Public Shared Sub ExecuteStoredProc()
        Console.WriteLine("Starting method 'ExecuteStoredProc'")
        '<snippetExecuteStoredProc> 
        ' Specify the Student ID. 
        Dim studentId As Integer = 2

        Using context As New SchoolEntities()
            For Each grade As StudentGrade In context.GetStudentGrades(studentId)
                Console.WriteLine("StudentID: " & studentId)
                Console.WriteLine("Student grade: " & grade.Grade)


            Next
        End Using
        '</snippetExecuteStoredProc> 
    End Sub

    Public Shared Sub ExecuteStoredProcWithOutputParams()
        Console.WriteLine("Starting method 'ExecuteStoredProcWithOutputParams'")
        '<snippetExecuteStoredProcWithOutParams> 
        Using context As New SchoolEntities()
            ' name is an output parameter. 
            Dim name As New ObjectParameter("Name", GetType(String))
            context.GetDepartmentName(1, name)

            Console.WriteLine(name.Value)
        End Using
        '</snippetExecuteStoredProcWithOutParams> 
    End Sub

    Public Shared Sub ExecuteFunctionWithOutParam()
        Console.WriteLine("Starting method 'ExecuteFunctionWithOutParam'")
        '<snippetExecuteFunctionWithOutParam> 
        Using context As New AdventureWorksEntities()
            Dim id As New ObjectParameter("ID", 1)
            Dim name As New ObjectParameter("Name", GetType(String))

            context.ExecuteFunction("GetProductName", id, name)

            Console.WriteLine(name.Value)
        End Using
        '</snippetExecuteFunctionWithOutParam> 
    End Sub

    Public Shared Sub ObjectQueryWithComplexType()
        Console.WriteLine("Starting method 'ObjectQueryWithComplexType'")
        '<snippetObjectQueryWithComplexType> 
        Using context As New AdventureWorksEntities()
            Dim contacts = From contact In context.Contacts _
                           Where contact.ContactID = 3 _
                           Select contact

            For Each contact As Contact In contacts
                Console.WriteLine("Contact Id: " & contact.ContactID)
                Console.WriteLine("Contact's email: " & contact.EmailPhoneComplexProperty.EmailAddress)
                Console.WriteLine("Contact's phone#: " & contact.EmailPhoneComplexProperty.Phone)
            Next
        End Using
        '</snippetObjectQueryWithComplexType> 
    End Sub
    Public Shared Sub ChangeExistingRelationshipWithFK()
        '<snippetChangeExistingRelationshipWithFK> 
        Dim studentId As Integer = 6
        Dim enrollmentID As Integer = 2

        Using context = New SchoolEntities()
            ' Get StudentGrade. 
            Dim grade = (From g In context.StudentGrades
                         Where g.EnrollmentID = enrollmentID
                         Select g).First()

            ' Change the relationship. 
            grade.StudentID = studentId
            ' You can access Person reference object on the grade object 
            ' without loading the reference explicitly when 
            ' the lazy loading option is set to true. 
            Console.WriteLine(grade.Person.PersonID)
            ' Save the changes. 
            context.SaveChanges()
        End Using
        '</snippetChangeExistingRelationshipWithFK> 
    End Sub

    Public Shared Sub AddNewObjectsWithFK()
        '<snippetAddNewObjectsWithFK> 
        Using context = New SchoolEntities()
            ' The database will generate PersonID. 
            ' The object context will get the ID 
            ' After the SaveChanges is called. 
            Dim newStudent = New Person With
            {
                .PersonID = 0,
                .LastName = "Li",
                .FirstName = "Yan"
             }
            ' The database will generate EnrollmentID. 
            ' The object context will get the ID 
            ' After the SaveChanges is called. 
            Dim newStudentGrade = New StudentGrade With
            {
                .EnrollmentID = 0,
                .Grade = CDec(4.0),
                .StudentID = 50
            }

            ' Add newStudent to object context. 
            ' The newStudent's state will change from Detached to Added. 
            context.People.AddObject(newStudent)

            ' To associate the new objects you can do one of the following: 
            ' Add the new dependent object to the principal object: newStudent.StudentGrades.Add(newStudentGrade). 
            ' Assign the reference (principal) object to the navigation property of the 
            ' dependent object: newStudentGrade.Person = newStudent. 
            ' Both of these methods will synchronize the navigation properties on both ends of the relationship. 

            ' Adding the newStudentGrade to newStudent will change newStudentGrade's status 
            ' from Detached to Added. 
            newStudent.StudentGrades.Add(newStudentGrade)
            ' Navigation properties in both directions will work immediately. 
            Console.WriteLine("Access StudentGrades navigation property to get the count: ", _
                              newStudent.StudentGrades.Count)
            Console.WriteLine("Access Person navigation property: {0} ", _
                              newStudentGrade.Person.FirstName)

            context.SaveChanges()
        End Using
        '</snippetAddNewObjectsWithFK> 
    End Sub
    Public Shared Sub CreateNewObjectSetFKAndRef()
        '<snippetFKvsRef> 
        '<snippetExistingPrincipaltoNewDependentFK> 

        ' The following example creates a new StudentGrade object and associates 
        ' the StudentGrade with the Course and Person by 
        ' setting the foreign key properties. 

        Using context As New SchoolEntities()
            ' The database will generate the EnrollmentID. 
            ' To create the association between the Course and StudentGrade, 
            ' and the Student and the StudentGrade, set the foreign key property 
            ' to the ID of the principal. 
            Dim newStudentGrade = New StudentGrade With
            {
                .EnrollmentID = 0,
                .Grade = CDec(4.0),
                .CourseID = 4022,
                .StudentID = 17
            }

            ' Adding the new object to the context will synchronize 
            ' the references with the foreign keys on the newStudentGrade object. 
            context.StudentGrades.AddObject(newStudentGrade)

            ' You can access Course and Student objects on the newStudentGrade object
            ' without loading the references explicitly because
            ' the lazy loading option is set to true in the constructor of SchoolEntities.
            Console.WriteLine("Student ID {0}:", newStudentGrade.Person.PersonID)
            Console.WriteLine("Course ID {0}:", newStudentGrade.Course.CourseID)

            context.SaveChanges()
        End Using
        '</snippetExistingPrincipaltoNewDependentFK> 

        '<snippetExistingPrincipaltoNewDependentRef> 
        ' The following example creates a new StudentGrade and associates 
        ' the StudentGrade with the Course and Person by 
        ' setting the navigation properties to the Course and Person objects that were returned 
        ' by the query. 
        ' You do not need to call AddObject() in order to add the grade object 
        ' to the context, because when you assign the reference 
        ' to the navigation property the objects on both ends get synchronized by the Entity Framework. 
        ' Note, that the Entity Framework will not synchronize the ends untill the SaveChanges method 
        ' is called if your objects do not meet the change tracking requirements. 
        Using context = New SchoolEntities()
            Dim courseID = 4022
            Dim course = (From c In context.Courses
                          Where c.CourseID = courseID
                          Select c).First()

            Dim personID = 17
            Dim student = (From p In context.People
                           Where p.PersonID = personID
                           Select p).First()

            ' The database will generate the EnrollmentID. 
            ' Use the navigation properties to create the association between the objects. 
            Dim newStudentGrade = New StudentGrade With
            {
                .EnrollmentID = 0,
                .Grade = CDec(4.0),
                .Course = course,
                .Person = student
            }
            context.SaveChanges()
        End Using
        '</snippetExistingPrincipaltoNewDependentRef> 
        '</snippetFKvsRef> 
    End Sub

    Public Shared Sub ObjectQueryTablePerType()
        Console.WriteLine("Starting method 'ObjectQueryTablePerType'")
        '<snippetObjectQueryTablePerType> 
        Try
            Using context As New SchoolEntities()
                Dim departmentID = 7
                ' Get courses for the department with id 7. 
                Dim courses As IQueryable(Of Course) = _
                    context.Departments.Where(Function(d) d.DepartmentID = departmentID).SelectMany(Function(d) d.Courses)

                Console.WriteLine("All the courses for the selected department.")
                For Each course As Course In courses

                    Console.WriteLine("CourseID: {0} ", course.CourseID)
                Next
                Dim onlineCourses = courses.OfType(Of OnlineCourse)()
                Console.WriteLine("Online courses only for the selected department.")
                For Each onlineCourse As OnlineCourse In onlineCourses

                    Console.WriteLine("CourseID: {0} ", onlineCourse.CourseID)
                Next
                Dim onsiteCourses = courses.OfType(Of OnsiteCourse)()
                Console.WriteLine("Onsite courses only for the selected department.")
                For Each onsite As OnsiteCourse In onsiteCourses

                    Console.WriteLine("CourseID: {0} ", onsite.CourseID)
                Next

            End Using
        Catch e As System.Data.MappingException
            Console.WriteLine(e.ToString())
        Catch e As System.Data.EntityException
            Console.WriteLine(e.ToString())
        End Try
        '</snippetObjectQueryTablePerType> 
    End Sub
    Public Shared Sub DDLTest2()
        '<snippetDDL2>
        ' Initialize the connection string.
        Dim connectionString As String = _
            "metadata=res://*/School.csdl|res://*/School.ssdl|res://*/School.msl;provider=System.Data.SqlClient;" & _
            "provider connection string=""Data Source=.;Initial Catalog=School;Integrated Security=True;MultipleActiveResultSets=True"""

        Using context As New SchoolEntities(connectionString)
            Try
                If context.DatabaseExists() Then
                    ' Make sure the database instance is closed.
                    context.DeleteDatabase()
                End If
                ' View the database creation script.
                Console.WriteLine(context.CreateDatabaseScript())
                ' Create the new database instance based on the storage (SSDL) section 
                ' of the .edmx file.
                context.CreateDatabase()

            Catch ex As InvalidOperationException
                Console.WriteLine(ex.InnerException.Message)
            Catch ex As NotSupportedException
                Console.WriteLine(ex.InnerException.Message)
            End Try
        End Using
        '</snippetDDL2>
    End Sub
    Public Shared Sub DDLTest()
        '<snippetDDL>
        ' Initialize the connection string.
        Dim connectionString As String =
            "metadata=res://*/School.csdl|res://*/School.ssdl|res://*/School.msl;provider=System.Data.SqlClient;" &
            "provider connection string=""Data Source=.;Initial Catalog=School;Integrated Security=True;MultipleActiveResultSets=True"""

        Using context As New SchoolEntities(connectionString)
            Try
                If context.DatabaseExists() Then
                    ' Make sure the database instance is closed.
                    context.DeleteDatabase()
                End If
                ' View the database creation script.
                Console.WriteLine(context.CreateDatabaseScript())
                ' Create the new database instance based on the storage (SSDL) section 
                ' of the .edmx file.
                context.CreateDatabase()

                ' The following code adds a new objects to the context
                ' and saves the changes to the database.
                Dim dpt As New Department()

                context.Departments.AddObject(dpt)
                ' An entity has a temporary key 
                ' until it is saved to the database.
                Console.WriteLine(dpt.EntityKey.IsTemporary)
                context.SaveChanges()

                ' The object was saved and the key 
                ' is not temporary any more.
                Console.WriteLine(dpt.EntityKey.IsTemporary)

            Catch ex As InvalidOperationException
                Console.WriteLine(ex.InnerException.Message)
            Catch ex As NotSupportedException
                Console.WriteLine(ex.InnerException.Message)
            End Try
        End Using
        '</snippetDDL>
    End Sub

End Class

#Region "partial methods"
'<snippetPartialClassMethod> 
Partial Public Class SalesOrderHeader
    ' Update the order total. 
    '<snippetUpdateOrderTotal> 
    Public Sub UpdateOrderTotal()
        Dim newSubTotal As Decimal = 0

        ' Ideally, this information is available in the EDM. 
        Dim taxRatePercent As Decimal = GetCurrentTaxRate()
        Dim freightPercent As Decimal = GetCurrentFreight()

        ' If the items for this order are loaded or if the order is 
        ' newly added, then recalculate the subtotal as it may have changed. 
        If Me.SalesOrderDetails.IsLoaded OrElse EntityState = EntityState.Added Then
            For Each item As SalesOrderDetail In Me.SalesOrderDetails
                ' Calculate line totals for loaded items. 
                newSubTotal += (item.OrderQty * (item.UnitPrice - item.UnitPriceDiscount))
            Next

            Me.SubTotal = newSubTotal
        End If

        ' Calculate the new tax amount. 
        Me.TaxAmt = Me.SubTotal + Decimal.Round((Me.SubTotal * taxRatePercent / 100), 4)

        ' Calculate the new freight amount. 
        Me.Freight = Me.SubTotal + Decimal.Round((Me.SubTotal * freightPercent / 100), 4)

        ' Calculate the new total. 
        Me.TotalDue = Me.SubTotal + Me.TaxAmt + Me.Freight
    End Sub
    '</snippetUpdateOrderTotal> 
End Class
'</snippetPartialClassMethod> 
Partial Public Class SalesOrderHeader
    Private Shared Function GetCurrentTaxRate() As Decimal
        Return 8.8D
    End Function
    Private Shared Function GetCurrentFreight() As Decimal
        Return 2.5D
    End Function
End Class
'<snippetOnPropertyChange> 
Partial Public Class SalesOrderDetail
    Inherits EntityObject
    Private Sub OnOrderQtyChanging(ByVal value As Short)
        ' Only handle this change for existing SalesOrderHeader 
        ' objects that are attached to an object context. If the item 
        ' is detached then we cannot access or load the related order. 
        If EntityState <> EntityState.Detached Then
            Try
                ' Ensure that the referenced SalesOrderHeader is loaded. 
                If Not Me.SalesOrderHeaderReference.IsLoaded Then
                    Me.SalesOrderHeaderReference.Load()
                End If

                ' Cancel the change if the order cannot be modified. 
                If Me.SalesOrderHeader.Status > 3 Then
                    Throw New InvalidOperationException("The quantity cannot be changed " & _
                                                        "or the item cannot be added because the order has either " & _
                                                        "already been shipped or has been cancelled.")
                End If

                ' Log the pending order change. 
                File.AppendAllText(LogFile, "Quantity of item '" & _
                    Me.SalesOrderDetailID.ToString() & "' in order '" & _
                    Me.SalesOrderHeader.SalesOrderID.ToString() & _
                    "' changing from '" + Me.OrderQty.ToString() & _
                    "' to '" & value.ToString() + "'." & Environment.NewLine & _
                    "Change made by user: " & Environment.UserName & _
                    Environment.NewLine)
            Catch ex As InvalidOperationException
                Throw New InvalidOperationException(("The quantity could not be changed " & " because the order information could not be retrieved. " & "The following error occurred:") + ex.Message)
            End Try
        End If
    End Sub
    Private Sub OnOrderQtyChanged()
        ' Only handle this change for existing SalesOrderHeader 
        ' objects that are attached to an object context. 
        If EntityState <> EntityState.Detached Then
            Try
                ' Ensure that the SalesOrderDetail is loaded. 
                If Not SalesOrderHeaderReference.IsLoaded Then
                    SalesOrderHeaderReference.Load()
                End If

                ' Reset the status for the order related to this item. 
                Me.SalesOrderHeader.Status = 1

                ' Log the completed order change. 
                File.AppendAllText(LogFile, "Quantity of item '" & _
                    SalesOrderDetailID.ToString() + "' in order '" & _
                    SalesOrderHeader.SalesOrderID.ToString() & _
                    "' successfully changed to '" + OrderQty.ToString() & _
                    "'." + Environment.NewLine & _
                    "Change made by user: " + Environment.UserName & _
                    Environment.NewLine)
            Catch ex As InvalidOperationException
                Throw New InvalidOperationException(("An error occurred; " & _
                                                     "the data could be in an inconsistent state. ") & _
                                                 Environment.NewLine + ex.Message)
            End Try
        End If
    End Sub
End Class
'</snippetOnPropertyChange> 

'<snippetRelationshipChangeHandler> 
Partial Public Class SalesOrderHeader
    ' SalesOrderHeader default constructor. 
    Public Sub New()
        ' Register the handler for changes to the 
        ' shipping address (Address1) reference. 
        AddHandler Me.AddressReference.AssociationChanged, AddressOf ShippingAddress_Changed
    End Sub

    ' AssociationChanged handler for the relationship 
    ' between the order and the shipping address. 
    Private Sub ShippingAddress_Changed(ByVal sender As Object, ByVal e As CollectionChangeEventArgs)
        ' Check for a related reference being removed. 
        If e.Action = CollectionChangeAction.Remove Then
            ' Check the order status and raise an exception if 
            ' the order can no longer be changed. 
            If Me.Status > 3 Then
                Throw New InvalidOperationException("The shipping address cannot " & _
                                                    "be changed because the order has either " & _
                                                    "already been shipped or has been cancelled.")
            End If
            ' Call the OnPropertyChanging method to raise the PropertyChanging event. 
            ' This event notifies client controls that the association is changing. 
            Me.OnPropertyChanging("Address1")
        ElseIf e.Action = CollectionChangeAction.Add Then
            ' Call the OnPropertyChanged method to raise the PropertyChanged event. 
            ' This event notifies client controls that the association has changed. 
            Me.OnPropertyChanged("Address1")
        End If
    End Sub
End Class
'</snippetRelationshipChangeHandler> 
Partial Public Class SalesOrderDetail
    ' Define the log file in the program directory. 
    Public Shared LogFile As String = "salesorderdetail.log"
End Class

'<snippetSavingChanges> 
Public Class AdventureWorksProxy
    ' Define the object context to be provided. 
    Private contextProxy As New AdventureWorksEntities()

    Public Sub New()
        ' When the object is initialized, register the 
        ' handler for the SavingChanges event. 
        AddHandler contextProxy.SavingChanges, AddressOf context_SavingChanges
    End Sub

    ' Method that provides an object context. 
    Public ReadOnly Property Context() As AdventureWorksEntities
        Get
            Return contextProxy
        End Get
    End Property

    ' SavingChanges event handler. 
    Private Sub context_SavingChanges(ByVal sender As Object, ByVal e As EventArgs)
        ' Ensure that we are passed an ObjectContext 
        Dim context As ObjectContext = TryCast(sender, ObjectContext)
        If context IsNot Nothing Then

            ' Validate the state of each entity in the context 
            ' before SaveChanges can succeed. 
            For Each entry As ObjectStateEntry In context.ObjectStateManager.GetObjectStateEntries(EntityState.Added Or EntityState.Modified)
                ' Find an object state entry for a SalesOrderHeader object. 
                If Not entry.IsRelationship AndAlso (entry.Entity.GetType() Is GetType(SalesOrderHeader)) Then
                    Dim orderToCheck As SalesOrderHeader = TryCast(entry.Entity, SalesOrderHeader)

                    ' Call a helper method that performs string checking 
                    ' on the Comment property. 
                    Dim textNotAllowed As String = Validator.CheckStringForLanguage(orderToCheck.Comment)

                    ' If the validation method returns a problem string, raise an error. 
                    If textNotAllowed <> String.Empty Then
                        Throw New ArgumentException(String.Format("Changes cannot be " & _
                                                                    "saved because the {0} '{1}' object contains a " & _
                                                                    "string that is not allowed in the property '{2}'.", _
                                                                    entry.State, "SalesOrderHeader", "Comment"))
                    End If
                End If
            Next
        End If
    End Sub
End Class
'</snippetSavingChanges> 
Public Class Validator
    Public Shared Function CheckStringForLanguage(ByVal inputString As String) As String
        'string invalid = "Some inappropriate comment."; 
        Dim invalid As String = String.Empty
        ' Do the string checking here. 
        Return invalid
    End Function
End Class

'<snippetOnContextCreated> 
Partial Public Class AdventureWorksEntities
    Private Sub OnContextCreated()
        ' Register the handler for the SavingChanges event. 
        AddHandler Me.SavingChanges, AddressOf context_SavingChanges
    End Sub
    ' SavingChanges event handler. 
    Private Shared Sub context_SavingChanges(ByVal sender As Object, ByVal e As EventArgs)
        ' Validate the state of each entity in the context 
        ' before SaveChanges can succeed. 
        For Each entry As ObjectStateEntry In DirectCast(sender, ObjectContext).ObjectStateManager.GetObjectStateEntries(EntityState.Added Or EntityState.Modified)
            ' Find an object state entry for a SalesOrderHeader object. 
            If Not entry.IsRelationship AndAlso (entry.Entity.GetType() Is GetType(SalesOrderHeader)) Then
                Dim orderToCheck As SalesOrderHeader = TryCast(entry.Entity, SalesOrderHeader)

                ' Call a helper method that performs string checking 
                ' on the Comment property. 
                Dim textNotAllowed As String = Validator.CheckStringForLanguage(orderToCheck.Comment)

                ' If the validation method returns a problem string, raise an error. 
                If textNotAllowed <> String.Empty Then
                    Throw New ArgumentException(String.Format("Changes cannot be " & _
                                                                "saved because the {0} '{1}' object contains a " & _
                                                                "string that is not allowed in the property '{2}'.", _
                                                                entry.State, "SalesOrderHeader", "Comment"))
                End If
            End If
        Next
    End Sub
End Class
'</snippetOnContextCreated> 
#End Region
Public Class UpdateScenario
    '<snippetFKUpateService> 
    Private Shared Function GetOriginalValue(ByVal ID As Integer) As StudentGrade
        Dim originalItem As StudentGrade
        Using context As New SchoolEntities()
            originalItem = context.StudentGrades.Where(Function(g) g.EnrollmentID = ID).FirstOrDefault()

            context.Detach(originalItem)
        End Using
        Return originalItem
    End Function

    Private Shared Sub SaveUpdates(ByVal updatedItem As StudentGrade)
        Using context As New SchoolEntities()
            ' Query for the StudentGrade object with the specified ID. 
            Dim original = (From o In context.StudentGrades
                            Where o.EnrollmentID = updatedItem.EnrollmentID
                            Select o).First()

            ' Apply changes. 
            context.StudentGrades.ApplyCurrentValues(updatedItem)

            ' Save changes. 
            context.SaveChanges()
        End Using
    End Sub
    '</snippetFKUpateService> 

    Public Shared Sub ManipulateObjects()
        '<snippetFKUpateClient> 
        ' A client calls a service to get the original object. 
        Dim studentGrade As StudentGrade = GetOriginalValue(3)
        ' Change the relationships. 
        studentGrade.CourseID = 5
        studentGrade.StudentID = 10
        ' The client calls a method on a service to save the updates. 
        '</snippetFKUpateClient> 
        SaveUpdates(studentGrade)
    End Sub
End Class

'<snippetEnableLazyLoad> 
Class LazyLoading
    Public Sub EnableLazyLoading()
        Using context As New AdventureWorksEntities()
            ' You do not have to set context.ContextOptions.LazyLoadingEnabled to true 
            ' if you used the Entity Framework to generate the object layer. 
            ' The generated object context type sets lazy loading to true 
            ' in the constructor. 
            context.ContextOptions.LazyLoadingEnabled = True

            ' Display ten contacts and select a contact 
            Dim contacts = context.Contacts.Take(10)
            For Each c In contacts
                Console.WriteLine(c.ContactID)
            Next

            Console.WriteLine("Select a customer:")
            Dim contactID As Int32 = Convert.ToInt32(Console.ReadLine())

            ' Get a specified customer by contact ID. 
            Dim contact = context.Contacts.Where(Function(c) c.ContactID = contactID).FirstOrDefault()

            ' If lazy loading was not enabled no SalesOrderHeaders would be loaded for the contact. 
            For Each order As SalesOrderHeader In contact.SalesOrderHeaders
                Console.WriteLine("SalesOrderID: {0} Order Date: {1} ", order.SalesOrderID, order.OrderDate)
            Next
        End Using
    End Sub
End Class
'</snippetEnableLazyLoad> 
