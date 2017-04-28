
Option Explicit On
Option Strict On
Option Infer On

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.Services.Client
'<snippetUsingForAttributes>
Imports System.Data.Services.Common
Imports NorthwindClient.Northwind
'</snippetUsingForAttributes>

Public Class SourceVb
    'Public Shared svcUri As Uri = New Uri("http://localhost/Northwind/Northwind.svc")
    Public Shared svcUri As Uri = New Uri("http://localhost:54321/northwind.svc")
    Public Shared svcUri2 As Uri = New Uri("http://localhost/Northwind/Northwind2.svc")
    Public Shared Sub GetAllCustomers()
        '<snippetGetAllCustomers>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        '<snippetGetAllCustomersSpecific>  
        ' Define a new query for Customers.
        Dim query As DataServiceQuery(Of Customer) = context.Customers
        '</snippetGetAllCustomersSpecific>

        Try
            ' Enumerate over the query result, which is executed implicitly.
            For Each customer As Customer In query
                Console.WriteLine("Customer Name: {0}", customer.CompanyName)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
        '</snippetGetAllCustomers>
    End Sub
    Public Shared Sub GetAllCustomersLinq()
        '<snippetGetAllCustomersLinq>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        Try
            ' Define a LINQ query that returns all customers.
            Dim allCustomers = From cust In context.Customers _
                                   Select cust

            ' Enumerate over the query obtained from the context.
            For Each customer As Customer In allCustomers
                Console.WriteLine("Customer Name: {0}", customer.CompanyName)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
        '</snippetGetAllCustomersLinq>
    End Sub
    Public Shared Sub GetAllCustomersFromContext()
        '<snippetGetAllCustomersFromContext>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        Try
            ' Enumerate over the query obtained from the context.
            For Each customer As Customer In context.Customers
                Console.WriteLine("Customer Name: {0}", customer.CompanyName)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
        '</snippetGetAllCustomersFromContext>
    End Sub
    Public Shared Sub GetAllCustomersQuery()
        '<snippetGetAllCustomersQuery>
        ' Create the DataServiceContext using the service URI.
        Dim context = New DataServiceContext(svcUri)

        ' Define a new query for Customers.
        Dim query As DataServiceQuery(Of Customer) = _
        context.CreateQuery(Of Customer)("Customers")

        Try
            ' Enumerate over the query result.
            For Each customer As Customer In query.Execute()
                Console.WriteLine("Customer Name: {0}", customer.CompanyName)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
        '</snippetGetAllCustomersQuery>
    End Sub
    Public Shared Sub GetAllCustomersExplicit()
        '<snippetGetAllCustomersExplicit>
        ' Define a request URI that returns Customers.
        Dim customersUri = New Uri(svcUri, "Northwind.svc/Customers")

        ' Create the DataServiceContext using the service URI.
        Dim context = New DataServiceContext(svcUri)

        Try
            ' Enumerate over the query result.
            For Each customer As Customer In context.Execute(Of Customer)(customersUri)
                Console.WriteLine("Customer Name: {0}", customer.CompanyName)
            Next

        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
        '</snippetGetAllCustomersExplicit>
    End Sub
    '<snippetExecuteQueryAsync>
    Public Shared Sub BeginExecuteCustomersQuery()
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        ' Define the delegate to callback into the process
        Dim callback As AsyncCallback = AddressOf OnCustomersQueryComplete

        ' Define the query to execute asynchronously that returns 
        ' all customers with their respective orders.
        Dim query As DataServiceQuery(Of Customer) = _
        context.Customers.Expand("Orders")

        Try
            ' Begin query execution, supplying a method to handle the response
            ' and the original query object to maintain state in the callback.
            query.BeginExecute(callback, query)
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
    End Sub
    ' Handle the query callback.
    Private Shared Sub OnCustomersQueryComplete(ByVal result As IAsyncResult)
        ' Get the original query from the result.
        Dim query As DataServiceQuery(Of Customer) = _
            CType(result.AsyncState, DataServiceQuery(Of Customer))

        ' Complete the query execution.
        For Each customer As Customer In query.EndExecute(result)
            Console.WriteLine("Customer Name: {0}", customer.CompanyName)
            For Each order As Order In customer.Orders
                Console.WriteLine("Order #: {0} - Freight $: {1}", _
                        order.OrderID, order.Freight)
            Next
        Next
    End Sub
    '</snippetExecuteQueryAsync>
    Public Shared Sub LoadRelatedOrderCustomer()
        '<snippetLoadRelatedOrderCustomer>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        Try
            ' Enumerate over the top 10 orders obtained from the context.
            For Each order As Order In context.Orders.Take(10)
                '<snippetLoadRelatedOrderCustomerSpecific>
                ' Explicitly load the customer for each order.
                context.LoadProperty(order, "Customer")
                '</snippetLoadRelatedOrderCustomerSpecific>

                ' Write out customer and order information.
                Console.WriteLine("Customer: {0} - Order ID: {1}", _
                        order.Customer.CompanyName, order.OrderID)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
        '</snippetLoadRelatedOrderCustomer>
    End Sub
    Public Shared Sub LoadRelatedOrderDetails()
        '<snippetLoadRelatedOrderDetails>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        Try
            ' Enumerate over the top 10 orders obtained from the context.
            For Each order As Order In context.Orders.Take(10)
                Console.WriteLine("Order ID: {0}", order.OrderID)

                '<snippetLoadRelatedOrderDetailsSpecific>
                ' Explicitly load the order details for each order.
                context.LoadProperty(order, "Order_Details")
                '</snippetLoadRelatedOrderDetailsSpecific>

                For Each item As Order_Detail In order.Order_Details
                    Console.WriteLine(vbTab & "Product: {0} - Quantity: {1}", _
                            item.ProductID, item.Quantity)
                Next
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
        '</snippetLoadRelatedOrderDetails>
    End Sub
    Public Shared Sub ExpandOrderDetails()
        '<snippetExpandOrderDetails>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        '<snippetExpandOrderDetailsSpecific>
        ' Define a query for orders that also returns items and customers.
        Dim query As DataServiceQuery(Of Order) = _
        context.Orders.Expand("Order_Details,Customer")
        '</snippetExpandOrderDetailsSpecific>

        Try
            ' Enumerate over the first 10 results of the query.
            For Each order As Order In query.Take(10)
                Console.WriteLine("Customer: {0}", order.Customer.CompanyName)
                Console.WriteLine("Order ID: {0}", order.OrderID)

                For Each item As Order_Detail In order.Order_Details
                    Console.WriteLine(vbTab & "Product: {0} - Quantity: {1}", _
                            item.ProductID, item.Quantity)
                Next
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
        '</snippetExpandOrderDetails>
    End Sub
    Public Shared Sub AddQueryOptions()
        '<snippetAddQueryOptions>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        '<snippetAddQueryOptionsSpecific>
        ' Define a query for orders with a Freight value greater than 30
        ' and that is ordered by the ship date, descending.
        Dim selectedOrders As DataServiceQuery(Of Order) = context.Orders _
        .AddQueryOption("$filter", "Freight gt 30") _
        .AddQueryOption("$orderby", "OrderID desc")
        '</snippetAddQueryOptionsSpecific>

        Try
            ' Enumerate over the results of the query.
            For Each order As Order In selectedOrders
                Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}", _
                        order.OrderID, order.ShippedDate, order.Freight)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
        '</snippetAddQueryOptions>
    End Sub
    Public Shared Sub AddQueryOptionsLinq()
        '<snippetAddQueryOptionsLinq>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        ' Define a query for orders with a Freight value greater than 30
        ' and that is ordered by the ship date, descending.
        '<snippetAddQueryOptionsLinqSpecific>
        Dim selectedOrders = From o In context.Orders _
                Where (o.Freight > 30) _
                Order By o.ShippedDate Descending _
                Select o
        '</snippetAddQueryOptionsLinqSpecific>

        Try
            ' Enumerate over the results of the query.
            For Each order As Order In selectedOrders
                Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}", _
                        order.OrderID, order.ShippedDate, order.Freight)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
        '</snippetAddQueryOptionsLinq>
    End Sub
    Public Shared Sub AddQueryOptionsLinqExpression()
        '<snippetAddQueryOptionsLinqExpression>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        ' Define a query for orders with a Freight value greater than 30
        ' and that is ordered by the ship date, descending.
        '<snippetAddQueryOptionsLinqExpressionSpecific>
        Dim selectedOrders = context.Orders _
                             .Where(Function(o) o.Freight.Value > 30) _
                             .OrderByDescending(Function(o) o.ShippedDate)
        '</snippetAddQueryOptionsLinqExpressionSpecific>

        Try
            ' Enumerate over the results of the query.
            For Each order As Order In selectedOrders

                Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}", _
                        order.OrderID, order.ShippedDate, order.Freight)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                "An error occurred during query execution.", ex)
        End Try
        '</snippetAddQueryOptionsLinqExpression>
    End Sub
    Public Shared Sub OrderWithFilter()
        '<snippetOrderWithFilter>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        '<snippetOrderWithFilterSpecific>
        ' Define a query for orders with a Freight value greater than 30
        ' that also orders the result by the Freight value, descending.
        Dim selectedOrders As DataServiceQuery(Of Order) = _
        context.Orders.AddQueryOption("$orderby", "Freight gt 30 desc")
        '</snippetOrderWithFilterSpecific>

        Try
            ' Enumerate over the results of the query.
            For Each order As Order In selectedOrders
                Console.WriteLine("Order ID: {0} - Freight: {1}", _
                        order.OrderID, order.Freight)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
        '</snippetOrderWithFilter>
    End Sub
    Public Shared Sub BatchQuery()
        '<snippetBatchQuery>
        Dim customerId = "ALFKI"

        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        ' Create the separate query URI's, one that returns 
        ' a single customer and another that returns all Products.
        Dim customerUri = New Uri(svcUri.AbsoluteUri & _
            "/Customers('" & customerId & "')/?$expand=Orders")
        Dim productsUri = New Uri(svcUri.AbsoluteUri & _
               "/Products")

        ' Create the query requests.
        Dim customerQuery = New DataServiceRequest(Of Customer)(customerUri)
        Dim productsQuery = New DataServiceRequest(Of Product)(productsUri)

        ' Add the query requests to a batch request array.
        Dim batchRequests = _
            New DataServiceRequest() {customerQuery, productsQuery}

        Dim batchResponse As DataServiceResponse

        Try
            ' Execute the query batch and get the response.
            batchResponse = context.ExecuteBatch(batchRequests)

            If batchResponse.IsBatchResponse Then
                ' Parse the batchResponse.BatchHeaders.
            End If

            ' Enumerate over the results of the query.
            For Each response As QueryOperationResponse In batchResponse
                ' Handle an error response.
                If response.StatusCode > 299 OrElse response.StatusCode < 200 Then
                    Console.WriteLine("An error occurred.")
                    Console.WriteLine(response.Error.Message)
                Else
                    ' Find the response for the Customers query.
                    If response.Query.ElementType Is GetType(Customer) Then
                        For Each customer As Customer In response
                            Console.WriteLine("Customer: {0}", customer.CompanyName)
                            For Each order As Order In customer.Orders
                                Console.WriteLine("Order ID: {0} - Freight: {1}", _
                                        order.OrderID, order.Freight)
                            Next
                        Next
                        ' Find the response for the Products query.
                    ElseIf response.Query.ElementType Is GetType(Product) Then
                        For Each product As Product In response
                            Console.WriteLine("Product: {0}", product.ProductName)
                        Next
                    End If
                End If
            Next
            ' This type of error is raised when the data service returns with
            ' a response code < 200 or >299 in the top level element.
        Catch ex As DataServiceRequestException
            ' Get the response from the exception.
            batchResponse = ex.Response

            If (batchResponse.IsBatchResponse) Then
                ' Parse the batchResponse.BatchHeaders.
            End If
            For Each response As QueryOperationResponse In batchResponse
                If response.Error IsNot Nothing Then
                    Console.WriteLine("An error occurred.")
                    Console.WriteLine(response.Error.Message)
                End If
            Next
        End Try
        '</snippetBatchQuery>
    End Sub
    Public Shared Sub AttachObject()
        '<snippetAttachObject>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        ' Define an existing customer to attach, including the key.
        Dim customer As Customer = _
            customer.CreateCustomer("ALFKI", "Alfreds Futterkiste")

        ' Set current property values.
        customer.Address = "Obere Str. 57"
        customer.City = "Berlin"
        customer.PostalCode = "12209"
        customer.Country = "Germany"

        ' Set property values to update.
        customer.ContactName = "Peter Franken"
        customer.ContactTitle = "Marketing Manager"
        customer.Phone = "089-0877310"
        customer.Fax = "089-0877451"

        Try
            '<snippetAttachObjectSpecific>
            ' Attach the existing customer to the context and mark it as updated.
            context.AttachTo("Customers", customer)
            context.UpdateObject(customer)

            ' Send updates to the data service.
            context.SaveChanges()
            '</snippetAttachObjectSpecific>  
        Catch ex As DataServiceClientException
            Throw New ApplicationException( _
                    "An error occurred when saving changes.", ex)
        End Try
        '</snippetAttachObject>
    End Sub
    Public Shared Sub AddProduct()
        '<snippetAddProduct>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        '<snippetCreateNewProduct>
        ' Create the new product.
        Dim newProduct = _
            Product.CreateProduct(0, "White Tea - loose", False)
        '</snippetCreateNewProduct>

        ' Set property values.
        newProduct.QuantityPerUnit = "120gm bags"
        newProduct.ReorderLevel = 5
        newProduct.UnitPrice = 5.2D

        Try
            '<snippetAddProductSpecific>
            ' Add the new product to the Products entity set.
            context.AddToProducts(newProduct)
            '</snippetAddProductSpecific>  

            ' Send the insert to the data service.
            context.SaveChanges()

            Console.WriteLine("New product added with ID {0}.", newProduct.ProductID)
        Catch ex As DataServiceRequestException
            Throw New ApplicationException( _
                    "An error occurred when saving changes.", ex)
            '</snippetAddProduct>
        Finally
            'remove the added product.
            context.DeleteObject(newProduct)
            context.SaveChanges()
        End Try
    End Sub
    Public Shared Sub ModifyCustomer()
        '<snippetModifyCustomer>
        Dim customerId = "ALFKI"

        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        ' Get a customer to modify using the supplied ID.
        Dim customerToChange = (From customer In context.Customers _
                                Where customer.CustomerID = customerId _
                                Select customer).Single()

        ' Change some property values.
        customerToChange.CompanyName = "Alfreds Futterkiste"
        customerToChange.ContactName = "Maria Anders"
        customerToChange.ContactTitle = "Sales Representative"

        Try
            '<snippetModifyCustomerSpecific>
            ' Mark the customer as updated.
            context.UpdateObject(customerToChange)
            '</snippetModifyCustomerSpecific>  

            ' Send the update to the data service.
            context.SaveChanges()
        Catch ex As DataServiceRequestException
            Throw New ApplicationException( _
                    "An error occurred when saving changes.", ex)
        End Try
        '</snippetModifyCustomer>
    End Sub
    Public Shared Sub DeleteProduct()
        ' Create the DataServiceContext using the service URI.
        Dim extraContext = New NorthwindEntities(svcUri)

        'First add a product to the context.
        Dim newProduct = Product.CreateProduct(0, "White Tea - loose", False)
        extraContext.AddToProducts(newProduct)
        extraContext.SaveChanges()

        Dim productID As Integer = newProduct.ProductID

        '<snippetDeleteProduct>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        Try
            ' Get the product to delete, by product ID.
            Dim deletedProduct = (From product In context.Products _
                                  Where product.ProductID = productID _
                                  Select product).Single()


            '<snippetDeleteProductSpecific>    
            ' Mark the product for deletion.    
            context.DeleteObject(deletedProduct)
            '</snippetDeleteProductSpecific>    

            ' Send the delete to the data service.
            context.SaveChanges()

            ' Handle the error that occurs when the delete operation fails,
            ' which can happen when there are entities with existing 
            ' relationships to the product being deleted.
        Catch ex As DataServiceRequestException
            Throw New ApplicationException( _
                    "An error occurred when saving changes.", ex)
        End Try
        '</snippetDeleteProduct>
    End Sub
    Public Shared Sub AddOrderDetailToOrder()
        '<snippetAddOrderDetailToOrder>
        Dim productId = 25
        Dim customerId = "ALFKI"

        Dim newItem As Order_Detail = Nothing

        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        Try
            ' Get the specific product.
            Dim selectedProduct = (From product In context.Products _
                                                   Where product.ProductID = productId _
                                                   Select product).Single()

            ' Get the specific customer.
            Dim cust = (From customer In context.Customers.Expand("Orders") _
                        Where customer.CustomerID = customerId _
                        Select customer).Single()

            ' Get the first order. 
            Dim order = cust.Orders.FirstOrDefault()

            ' Create a new order detail for the specific product.
            newItem = Order_Detail.CreateOrder_Detail( _
            order.OrderID, selectedProduct.ProductID, 10, 5, 0)

            ' Add the new order detail to the context.
            context.AddToOrder_Details(newItem)

            ' Add links for the one-to-many relationships.
            context.AddLink(order, "Order_Details", newItem)
            context.AddLink(selectedProduct, "Order_Details", newItem)

            ' Add the new order detail to the collection, and
            ' set the reference to the product.
            order.Order_Details.Add(newItem)
            newItem.Product = selectedProduct

            ' Send the insert to the data service.
            Dim response As DataServiceResponse = context.SaveChanges()

            ' Enumerate the returned responses.
            For Each change As ChangeOperationResponse In response
                ' Get the descriptor for the entity.
                Dim descriptor = TryCast(change.Descriptor, EntityDescriptor)

                If Not descriptor Is Nothing Then

                    Dim addedProduct = TryCast(descriptor.Entity, Product)

                    If Not addedProduct Is Nothing Then
                        Console.WriteLine("New product added with ID {0}.", _
                            addedProduct.ProductID)
                    End If
                End If
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred when saving changes.", ex)

            ' Handle any errors that may occur during insert, such as 
            ' a constraint violation.
        Catch ex As DataServiceRequestException
            Throw New ApplicationException( _
                    "An error occurred when saving changes.", ex)
            '</snippetAddOrderDetailToOrder>
            'remove the added product.
        Finally
            context.DeleteObject(newItem)
            context.SaveChanges()
        End Try
    End Sub
    Public Shared Sub AddOrderDetailToOrderAuto()
        '<snippetAddOrderDetailToOrderAuto>
        Dim productId = 25
        Dim customerId = "ALFKI"

        Dim newItem As Order_Detail = Nothing

        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        Try
            ' Get the specific product.
            Dim selectedProduct = (From product In context.Products _
                                   Where product.ProductID = productId _
                                   Select product).Single()

            ' Get the specific customer.
            Dim cust = (From customer In context.Customers.Expand("Orders") _
                        Where customer.CustomerID = customerId _
                        Select customer).Single()

            ' Get the first order. 
            Dim order = cust.Orders.FirstOrDefault()

            ' Create a new order detail for the specific product.
            newItem = Order_Detail.CreateOrder_Detail( _
                    order.OrderID, selectedProduct.ProductID, 10, 5, 0)

            '<snippetAddOrderDetailToOrderSpecific>
            ' Add the new item with a link to the related order.
            context.AddRelatedObject(order, "Order_Details", newItem)
            '</snippetAddOrderDetailToOrderSpecific>

            '<snippetSetNavProps>
            ' Add the new order detail to the collection, and
            ' set the reference to the product.
            order.Order_Details.Add(newItem)
            newItem.Order = order
            newItem.Product = selectedProduct
            '</snippetSetNavProps>

            ' Send the changes to the data service.
            Dim response As DataServiceResponse = context.SaveChanges()

            ' Enumerate the returned responses.
            For Each change As ChangeOperationResponse In response
                ' Get the descriptor for the entity.
                Dim descriptor = TryCast(change.Descriptor, EntityDescriptor)

                If Not descriptor Is Nothing Then
                    If TypeOf descriptor.Entity Is Order_Detail Then
                        Dim addedItem = TryCast(descriptor.Entity, Order_Detail)

                        If Not addedItem Is Nothing Then
                            Console.WriteLine("New {0} item added to order {1}.", _
                                addedItem.Product.ProductName, addedItem.OrderID.ToString())
                        End If
                    End If
                End If
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred when saving changes.", ex)

            ' Handle any errors that may occur during insert, such as 
            ' a constraint violation.
        Catch ex As DataServiceRequestException
            Throw New ApplicationException( _
                    "An error occurred when saving changes.", ex)
            '</snippetAddOrderDetailToOrderAuto>
            'remove the added product.
        Finally
            If Not newItem Is Nothing Then
                context.DeleteObject(newItem)
                context.SaveChanges()
            End If
        End Try
    End Sub
    Public Shared Sub CountAllCustomersValueOnly()
        '<snippetCountAllCustomersValueOnly>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        ' Define a new query for Customers.
        Dim query As DataServiceQuery(Of Customer) = context.Customers

        Try
            ' Execute the query to just return the value of all customers in the set.
            Dim totalCount = query.Count()

            ' Retrieve the total count from the response.
            Console.WriteLine("There are {0} customers in total.", totalCount)
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
        '</snippetCountAllCustomersValueOnly>
    End Sub
    Public Shared Sub CountAllCustomers()
        '<snippetCountAllCustomers>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        '<snippetCountAllCustomersSpecific>  
        ' Define a new query for Customers that includes the total count.
        Dim query As DataServiceQuery(Of Customer) = _
        context.Customers.IncludeTotalCount()
        '</snippetCountAllCustomersSpecific>

        Try
            '<snippetGetResponseSpecific> 
            ' Execute the query for all customers and get the response object.
            Dim response As QueryOperationResponse(Of Customer) = _
                CType(query.Execute(), QueryOperationResponse(Of Customer))
            '</snippetGetResponseSpecific> 

            ' Retrieve the total count from the response.
            Console.WriteLine("There are a total of {0} customers.", response.TotalCount)

            ' Enumerate the customers in the response.
            For Each customer As Customer In response
                Console.WriteLine(vbTab & "Customer Name: {0}", customer.CompanyName)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
        '</snippetCountAllCustomers>
    End Sub
    Public Shared Sub GetCustomersPaged()
        '<snippetGetCustomersPaged>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)
        Dim token As DataServiceQueryContinuation(Of Customer) = Nothing
        Dim pageCount = 0

        Try
            ' Execute the query for all customers and get the response object.
            Dim response As QueryOperationResponse(Of Customer) = _
                CType(context.Customers.Execute(), QueryOperationResponse(Of Customer))

            '<snippetLoadNextLink>
            ' With a paged response from the service, use a do...while loop 
            ' to enumerate the results before getting the next link.
            Do
                ' Write the page number.
                Console.WriteLine("Page {0}:", pageCount + 1)

                ' If nextLink is not null, then there is a new page to load.
                If token IsNot Nothing Then
                    ' Load the new page from the next link URI.
                    response = CType(context.Execute(Of Customer)(token),  _
                    QueryOperationResponse(Of Customer))
                End If

                ' Enumerate the customers in the response.
                For Each customer As Customer In response
                    Console.WriteLine(vbTab & "Customer Name: {0}", customer.CompanyName)
                Next

                ' Get the next link, and continue while there is a next link.
                token = response.GetContinuation()
            Loop While token IsNot Nothing
            '</snippetLoadNextLink>
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
        '</snippetGetCustomersPaged>
    End Sub
    Public Shared Sub GetCustomersPagedNested()
        '<snippetGetCustomersPagedNested>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)
        Dim nextLink As DataServiceQueryContinuation(Of Customer) = Nothing
        Dim pageCount = 0
        Dim innerPageCount = 0

        Try
            ' Execute the query for all customers and related orders,
            ' and get the response object.
            Dim response = _
            CType(context.Customers.AddQueryOption("$expand", "Orders") _
                    .Execute(), QueryOperationResponse(Of Customer))

            ' With a paged response from the service, use a do...while loop 
            ' to enumerate the results before getting the next link.
            Do
                ' Write the page number.
                Console.WriteLine("Customers Page {0}:", ++pageCount)

                ' If nextLink is not null, then there is a new page to load.
                If nextLink IsNot Nothing Then
                    ' Load the new page from the next link URI.
                    response = CType(context.Execute(Of Customer)(nextLink),  _
                            QueryOperationResponse(Of Customer))
                End If

                ' Enumerate the customers in the response.
                For Each c As Customer In response
                    Console.WriteLine(vbTab & "Customer Name: {0}", c.CompanyName)
                    Console.WriteLine(vbTab & "Orders Page {0}:", innerPageCount + 1)

                    ' Get the next link for the collection of related Orders.
                    Dim nextOrdersLink As DataServiceQueryContinuation(Of Order) = _
                    response.GetContinuation(c.Orders)

                    '<snippetLoadNextOrdersLink>
                    While nextOrdersLink IsNot Nothing
                        For Each o As Order In c.Orders
                            ' Print out the orders.
                            Console.WriteLine(vbTab & vbTab & "OrderID: {0} - Freight: ${1}", _
                                    o.OrderID, o.Freight)
                        Next
                        ' Load the next page of Orders.
                        Dim ordersResponse = _
                        context.LoadProperty(c, "Orders", nextOrdersLink)
                        nextOrdersLink = ordersResponse.GetContinuation()
                    End While
                    '</snippetLoadNextOrdersLink>
                Next
                ' Get the next link, and continue while there is a next link.
                nextLink = response.GetContinuation()
            Loop While nextLink IsNot Nothing
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
        '</snippetGetCustomersPagedNested>
    End Sub
    Public Shared Sub SelectCustomerAddress()
        '<snippetSelectCustomerAddress>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        '<snippetSelectCustomerAddressSpecific>  
        ' Define an anonymous LINQ query that projects the Customers type into 
        ' a CustomerAddress type that contains only address properties.
        '<snippetProjectWithInitializer> 
        Dim query = From c In context.Customers _
                        Where c.Country = "Germany" _
                        Select New CustomerAddress With { _
                            .CustomerID = c.CustomerID, _
                            .Address = c.Address, _
                            .City = c.City, _
                            .Region = c.Region, _
                            .PostalCode = c.PostalCode, _
                            .Country = c.Country}
        '</snippetProjectWithInitializer>
        '</snippetSelectCustomerAddressSpecific>

        Try
            ' Enumerate over the query result, which is executed implicitly.
            For Each item In query
                ' Modify the address and mark the object as updated.
                item.Address += " #101"
                context.UpdateObject(item)

                ' Write out the current values.
                Console.WriteLine("Customer ID: {0} " & vbCrLf & "Street: {1} " _
                        & vbCrLf & "City: {2} " & vbCrLf & "State: {3} " & vbCrLf & "Zip Code: {4}" _
                        & vbCrLf & "Country: {5}", _
                        item.CustomerID, item.Address, item.City, item.Region, _
                        item.PostalCode, item.Country)
            Next

            ' Save changes to the data service.
            context.SaveChanges()
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
        '</snippetSelectCustomerAddress>
    End Sub
    Public Shared Sub SelectCustomerAddressNonEntity()
        '<snippetSelectCustomerAddressNonEntity>
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        ' Define an anonymous LINQ query that projects the Customers type into 
        ' a CustomerAddress type that contains only address properties.
        Dim query = From c In context.Customers _
                        Where c.Country = "Germany" _
                        Select New CustomerAddressNonEntity With _
                        {.CompanyName = c.CompanyName, _
                            .Address = c.Address, _
                            .City = c.City, _
                            .Region = c.Region, _
                            .PostalCode = c.PostalCode, _
                            .Country = c.Country}

        Try
            ' Enumerate over the query result, which is executed implicitly.
            For Each item In query
                item.Address += "Street"

                Console.WriteLine("Company name: {0} " & vbNewLine & "Street: {1} " _
                    & "" & vbNewLine & "City: {2} " & vbNewLine & "State: {3} " & vbNewLine & _
                    "Zip Code: {4} " & vbNewLine & "Country: {5}", _
                    item.CompanyName, item.Address, item.City, item.Region, _
                    item.PostalCode, item.Country)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                    "An error occurred during query execution.", ex)
        End Try
        '</snippetSelectCustomerAddressNonEntity>
    End Sub
    Public Shared Sub ProjectWithConstructor()
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        ' Define an anonymous LINQ query that projects the Customers type into 
        ' a CustomerAddress type that contains only address properties.
        '<snippetProjectWithConstructor> 
        Dim query = From c In context.Customers _
                        Where c.Country = "Germany" _
                        Select New CustomerAddress( _
                        c.CustomerID, _
                        c.Address, _
                        c.City, _
                        c.Region, _
                        c.PostalCode, _
                        c.Country)
        '</snippetProjectWithConstructor>

        Try
            ' Enumerate over the query result, which is executed implicitly.
            For Each item In query
                ' Write out the current values.
                Console.WriteLine("Customer ID: {0} " & vbCrLf & "Street: {1} " _
                    & vbCrLf & "City: {2} " & vbCrLf & "State: {3} " & vbCrLf & "Zip Code: {4}" _
                    & vbCrLf & "Country: {5}", _
                    item.CustomerID, item.Address, item.City, item.Region, _
                    item.PostalCode, item.Country)
            Next
        Catch ex As NotSupportedException
            Throw New ApplicationException( _
                    "This is an expected error.", ex)
        End Try
    End Sub
    Public Shared Sub ProjectWithTransform()
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        ' Define an anonymous LINQ query that projects the Customers type into 
        ' a CustomerAddress type and tries to create a new Address string by
        ' concatenating other properties.
        '<snippetProjectWithTransform> 
        Dim query = From c In context.Customers _
                        Where c.Country = "Germany" _
                        Select New CustomerAddress With _
                        {.CustomerID = c.CustomerID, _
                            .Address = "Full address: " & c.Address & ", " & _
                            c.City & "," & c.Region & " " & c.PostalCode, _
                            .City = c.City, _
                            .Region = c.Region, _
                            .PostalCode = c.PostalCode, _
                            .Country = c.Country}
        '</snippetProjectWithTransform>

        Try
            ' Enumerate over the query result, which is executed implicitly.
            For Each item In query
                ' Write out the current values.
                Console.WriteLine("Customer ID: {0} " & vbCrLf & "Street: {1} " _
                    & vbCrLf & "City: {2} " & vbCrLf & "State: {3} " & vbCrLf & "Zip Code: {4}" _
                    & vbCrLf & "Country: {5}", _
                    item.CustomerID, item.Address, item.City, item.Region, _
                    item.PostalCode, item.Country)
            Next
        Catch ex As NotSupportedException
            Throw New ApplicationException( _
                    "This is an expected error.", ex)
        End Try
    End Sub
    Public Shared Sub ProjectWithConvertion()
        ' Create the DataServiceContext using the service URI.
        Dim context = New NorthwindEntities(svcUri)

        ' Define an anonymous LINQ query that projects the Customers type into 
        ' a CustomerAddress type that contains only address properties.
        '<snippetProjectWithConvertion> 
        Dim query = From c In context.Customers _
                        Where c.Country = "Germany" _
                        Select New CustomerAddress With _
                        {.CustomerID = c.CustomerID, _
                            .Address = c.Address, _
                            .City = c.City, _
                            .Region = c.Region, _
                            .PostalCode = c.PostalCode, _
                            .Country = c.Country}
        '</snippetProjectWithConvertion>

        Try
            ' Enumerate over the query result, which is executed implicitly.
            For Each item In query
                ' Write out the current values.
                Console.WriteLine("Customer ID: {0} " & vbCrLf & "Street: {1} " _
                    & vbCrLf & "City: {2} " & vbCrLf & "State: {3} " & vbCrLf & "Zip Code: {4}" _
                    & vbCrLf & "Country: {5}", _
                    item.CustomerID, item.Address, item.City, item.Region, _
                    item.PostalCode.Split(New [Char]() {"-"c})(0), item.Country)
            Next
        Catch ex As NotSupportedException
            Throw New ApplicationException( _
                    "This is an expected error.", ex)
        End Try
    End Sub
    Public Shared Sub LinqQueryPrecedence()
        '<snippetLinqQueryPrecedence>
        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri)

        ' Define a query for orders that have shipped.
        '<snippetLinqQueryPrecedenceSpecific>
        Dim ordersQuery = (From o In context.Orders
                                 Where o.ShippedDate < DateTime.Today
                                 Order By o.OrderDate Descending, o.CustomerID
                                 Select o).Skip(10).Take(10)
        '</snippetLinqQueryPrecedenceSpecific>

        Try
            ' Write out the URI.
            Console.WriteLine(CType(ordersQuery, DataServiceQuery(Of Order)) _
                .RequestUri.ToString())

            ' Enumerate over the results of the query.
            For Each o As Order In ordersQuery
                Console.WriteLine("CustomerID:{0}" & vbNewLine & "{1}, {2}", _
                    o.ShipName, o.ShipCity, o.ShipCountry)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                "An error occurred during query execution.", ex)
        End Try
        '</snippetLinqQueryPrecedence>
    End Sub
    Public Shared Sub LinqMethodPrecedence()
        '<snippetLinqMethodPrecedence>
        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri)
        ' Define a query for orders with a Freight value greater than 30.
        '<snippetLinqMethodPrecedenceSpecific>
        Dim projectedQuery = context.Customers _
                .Where(Function(c) c.Country = "Germany") _
                .OrderBy(Function(c) c.CompanyName) _
                .Select(Function(c) New CustomerAddress With _
                {
                    .CustomerID = c.CustomerID, _
                    .Address = c.Address, _
                    .City = c.City, _
                    .Region = c.Region, _
                    .PostalCode = c.PostalCode, _
                    .Country = c.Country _
                }).Skip(10).Take(10)
        '</snippetLinqMethodPrecedenceSpecific>

        Try
            ' Write out the URI.
            Console.WriteLine(CType(projectedQuery, DataServiceQuery(Of CustomerAddress)) _
                    .RequestUri.ToString())

            ' Enumerate over the results of the query.
            For Each address As CustomerAddress In projectedQuery
                Console.WriteLine("Address:" & vbNewLine & "{0}" & vbNewLine & "{1}, {2}", _
                    address.Address, address.City, address.Region)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                "An error occurred during query execution.", ex)
        End Try
        '</snippetLinqMethodPrecedence>
    End Sub
#Region "LINQ examples"
    Public Shared Sub LinqWhereClause()
        '<snippetLinqWhereClause>
        ' Create theB DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri)

        ' Define a query for orders with a Freight value greater than 30.
        '<snippetLinqWhereClauseSpecific>
        Dim filteredOrders = From o In context.Orders
                                Where o.Freight.Value > 30
                                Select o
        '</snippetLinqWhereClauseSpecific>

        Try
            ' Write out the URI.
            Console.WriteLine(CType(filteredOrders, DataServiceQuery(Of Order)).RequestUri.ToString())

            ' Enumerate over the results of the query.
            For Each o As Order In filteredOrders
                Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}", _
                    o.OrderID, o.ShippedDate, o.Freight)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                "An error occurred during query execution.", ex)
        End Try
        '</snippetLinqWhereClause>
    End Sub
    Public Shared Sub LinqWhereMethod()
        '<snippetLinqWhereMethod>
        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri)

        ' Define a query for orders with a Freight value greater than 30.
        '<snippetLinqWhereMethodSpecific>
        Dim filteredOrders = context.Orders.Where(Function(o) o.Freight.Value > 0)
        '</snippetLinqWhereMethodSpecific>

        Try
            ' Write out the URI.
            Console.WriteLine(CType(filteredOrders, DataServiceQuery(Of Order)).RequestUri.ToString())

            ' Enumerate over the results of the query.
            For Each o As Order In filteredOrders
                Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}", _
                    o.OrderID, o.ShippedDate, o.Freight)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                "An error occurred during query execution.", ex)
        End Try
        '</snippetLinqWhereMethod>
    End Sub
    Public Shared Sub ExplicitQueryWhereMethod()
        '<snippetExplicitQueryWhereMethod>
        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri)

        '<snippetExplicitQueryWhereMethodSpecific>
        ' Define a query for orders with a Freight value greater than 30.
        Dim filteredOrders _
                    = context.Orders.AddQueryOption("$filter", "Freight gt 30M")
        '</snippetExplicitQueryWhereMethodSpecific>

        Try
            ' Write out the URI.
            Console.WriteLine(filteredOrders.RequestUri.ToString())

            ' Enumerate over the results of the query.
            For Each order As Order In filteredOrders
                Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}", _
                    order.OrderID, order.ShippedDate.Value, order.Freight.Value)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                "An error occurred during query execution.", ex)
        End Try
        '</snippetExplicitQueryWhereMethod>
    End Sub
    Public Shared Sub LinqOrderByClause()
        '<snippetLinqOrderByClause>
        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri)

        ' Define a query for orders with a Freight value greater than 30.
        '<snippetLinqOrderByClauseSpecific>
        Dim sortedCustomers = From c In context.Customers
                                     Order By c.CompanyName Ascending,
                                     c.PostalCode Descending
                                     Select c
        '</snippetLinqOrderByClauseSpecific>

        Try
            ' Write out the URI.
            Console.WriteLine(CType(sortedCustomers, DataServiceQuery(Of Customer)) _
                              .RequestUri.ToString())

            ' Enumerate over the results of the query.
            For Each cust As Customer In sortedCustomers
                Console.WriteLine("Customer name: {0} - Zip code: {1}", _
                    cust.CompanyName, cust.PostalCode)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                "An error occurred during query execution.", ex)
        End Try
        '</snippetLinqOrderByClause>
    End Sub
    Public Shared Sub LinqOrderByMethod()
        '<snippetLinqOrderByMethod>
        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri)

        ' Define a query for orders with a Freight value greater than 30.
        '<snippetLinqOrderByMethodSpecific>
        Dim sortedCustomers = context.Customers.OrderBy(Function(c) c.CompanyName) _
        .ThenByDescending(Function(c) c.PostalCode)
        '</snippetLinqOrderByMethodSpecific>

        Try
            ' Write out the URI.
            Console.WriteLine(CType(sortedCustomers, DataServiceQuery(Of Customer)) _
                              .RequestUri.ToString())

            ' Enumerate over the results of the query.
            For Each cust As Customer In sortedCustomers
                Console.WriteLine("Customer name: {0} - Zip code: {1}", _
                    cust.CompanyName, cust.PostalCode)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                "An error occurred during query execution.", ex)
        End Try
        '</snippetLinqOrderByMethod>
    End Sub
    Public Shared Sub ExplicitQueryOrderByMethod()
        '<snippetExplicitQueryOrderByMethod>
        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri)

        ' Define a query for orders with a Freight value greater than 30.
        '<snippetExplicitQueryOrderByMethodSpecific>
        Dim sortedCustomers = context.Customers _
                              .AddQueryOption("$orderby", "CompanyName, PostalCode desc")
        '</snippetExplicitQueryOrderByMethodSpecific>

        Try
            ' Write out the URI.
            Console.WriteLine(sortedCustomers.RequestUri.ToString())

            ' Enumerate over the results of the query.
            For Each cust As Customer In sortedCustomers
                Console.WriteLine("Customer name: {0} - Zip code: {1}", _
                    cust.CompanyName, cust.PostalCode)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                "An error occurred during query execution.", ex)
        End Try
        '</snippetExplicitQueryOrderByMethod>
    End Sub
    Public Shared Sub LinqSkipTakeMethod()
        '<snippetLinqSkipTakeMethod>
        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri)

        ' Define a query that returns 25 orders after skipping the 
        ' first 50 orders returned by the query.
        '<snippetLinqSkipTakeMethodSpecific>
        Dim pagedOrders = (From o In context.Orders
                           Order By o.OrderDate Descending
                           Select o) _
                       .Skip(50).Take(25)
        '</snippetLinqSkipTakeMethodSpecific>

        Try
            ' Write out the URI.
            Console.WriteLine(CType(pagedOrders, DataServiceQuery(Of Order)) _
                              .RequestUri.ToString())

            ' Enumerate over the results of the query.
            For Each order As Order In pagedOrders
                Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}", _
                    order.OrderID, order.ShippedDate, order.Freight)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                "An error occurred during query execution.", ex)
        End Try
        '</snippetLinqSkipTakeMethod>
    End Sub
    Public Shared Sub ExplicitQuerySkipTakeMethod()
        '<snippetExplicitQuerySkipTakeMethod>
        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri)

        ' Define a query that returns 25 orders after skipping the 
        ' first 50 orders returned by the query.
        '<snippetExplicitQuerySkipTakeMethodSpecific>
        Dim pagedOrders = context.Orders _
                          .AddQueryOption("$orderby", "OrderDate desc") _
                          .AddQueryOption("$skip", 50) _
                          .AddQueryOption("$top", 25) _
        '</snippetExplicitQuerySkipTakeMethodSpecific>

        Try
            ' Write out the URI.
            Console.WriteLine(CType(pagedOrders, DataServiceQuery(Of Order)) _
                              .RequestUri.ToString())

            ' Enumerate over the results of the query.
            For Each o As Order In pagedOrders
                Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}", _
                    o.OrderID, o.ShippedDate, o.Freight)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                "An error occurred during query execution.", ex)
        End Try
        '</snippetExplicitQuerySkipTakeMethod>
    End Sub
    Public Shared Sub LinqSelectClause()
        '<snippetLinqSelectClause>
        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri)

        ' Define a query for orders with a Freight value greater than 30.
        '<snippetLinqSelectClauseSpecific>
        Dim projectedQuery = From c In context.Customers
                             Select New CustomerAddress With
                            {
                                .CustomerID = c.CustomerID,
                                .Address = c.Address,
                                .City = c.City,
                                .Region = c.Region,
                                .PostalCode = c.PostalCode,
                                .Country = c.Country
                            }
        '</snippetLinqSelectClauseSpecific>

        Try
            ' Write out the URI.
            Console.WriteLine(CType(projectedQuery, DataServiceQuery(Of CustomerAddress)) _
                              .RequestUri.ToString())

            ' Enumerate over the results of the query.
            For Each address As CustomerAddress In projectedQuery
                Console.WriteLine("Address:" & vbNewLine & "{0}" & vbNewLine & "{1}, {2}", _
                    address.Address, address.City, address.Region)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                "An error occurred during query execution.", ex)
        End Try
        '</snippetLinqSelectClause>
    End Sub
    Public Shared Sub LinqSelectMethod()
        '<snippetLinqSelectMethod>
        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri)

        ' Define a query for orders with a Freight value greater than 30.
        '<snippetLinqSelectMethodSpecific>
        Dim projectedQuery = context.Customers.Where(Function(c) c.Country = "Germany") _
                    .Select(Function(c) New CustomerAddress With
                    {
                        .CustomerID = c.CustomerID,
                        .Address = c.Address,
                        .City = c.City,
                        .Region = c.Region,
                        .PostalCode = c.PostalCode,
                        .Country = c.Country
                    })
        '</snippetLinqSelectMethodSpecific>

        Try
            ' Write out the URI.
            Console.WriteLine(CType(projectedQuery, DataServiceQuery(Of CustomerAddress)) _
                        .RequestUri.ToString())

            ' Enumerate over the results of the query.
            For Each address As CustomerAddress In projectedQuery
                Console.WriteLine("Address:" & vbNewLine & "{0}" & vbNewLine & "{1}, {2}", _
                    address.Address, address.City, address.Region)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                "An error occurred during query execution.", ex)
        End Try
        '</snippetLinqSelectMethod>
    End Sub
    Public Shared Sub LinqQueryExpand()
        '<snippetLinqQueryExpand>
        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri)

        ' Define a query that returns orders and details
        ' for the customer "ALKFI".
        '<snippetLinqQueryExpandSpecific>
        Dim ordersQuery = From o In context.Orders.Expand("Order_Details")
                             Where o.CustomerID = "ALFKI"
                             Select o
        '</snippetLinqQueryExpandSpecific>

        Try
            ' Write out the URI.
            Console.WriteLine(CType(ordersQuery, DataServiceQuery(Of Order)) _
                        .RequestUri.ToString())

            ' Enumerate over the results of the query.
            For Each o As Order In ordersQuery
                Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}", _
                    o.OrderID, o.ShippedDate, o.Freight)

                For Each item As Order_Detail In o.Order_Details
                    Console.WriteLine(vbTab & "Product: {0} (Price: {1}) - Quantity: {2}", _
                    item.ProductID, item.UnitPrice, item.Quantity)
                Next
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                "An error occurred during query execution.", ex)
        End Try
        '</snippetLinqQueryExpand>
    End Sub
    Public Shared Sub LinqQueryExpandMethod()
        '<snippetLinqQueryExpandMethod>
        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri)

        ' Define a query that returns orders and details
        ' for the customer "ALKFI".
        '<snippetLinqQueryExpandMethodSpecific>
        Dim ordersQuery = context.Orders.Expand("Order_Details") _
                                  .Where(Function(o) o.CustomerID = "ALFKI")
        '</snippetLinqQueryExpandMethodSpecific>

        Try
            ' Write out the URI.
            Console.WriteLine(CType(ordersQuery, DataServiceQuery(Of Order)) _
                        .RequestUri.ToString())

            ' Enumerate over the results of the query.
            For Each o As Order In ordersQuery
                Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}", _
                    o.OrderID, o.ShippedDate, o.Freight)

                For Each item As Order_Detail In o.Order_Details
                    Console.WriteLine(vbTab & "Product: {0} (Price: {1}) - Quantity: {2}", _
                    item.ProductID, item.UnitPrice, item.Quantity)
                Next
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                "An error occurred during query execution.", ex)
        End Try
        '</snippetLinqQueryExpandMethod>
    End Sub
#End Region
    Public Shared Sub LinqQueryClientEval()
        '<snippetLinqQueryClientEval>
        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri)

        '<snippetLinqQueryClientEvalSpecific>
        Dim basePrice As Integer = 100
        Dim discount As Decimal = Convert.ToDecimal(0.1)

        ' Define a query that returns products based on a 
        ' calculation that is determined on the client.
        Dim productsQuery = From p In context.Products
                          Where p.UnitPrice >
                          (basePrice - (basePrice * discount)) AndAlso
                          p.ProductName.Contains("bike")
                          Select p
        '</snippetLinqQueryClientEvalSpecific>

        Try
            ' Write out the URI.
            Console.WriteLine(CType(productsQuery, DataServiceQuery(Of Product)) _
                        .RequestUri.ToString())

            ' Enumerate over the results of the query.
            For Each prod As Product In productsQuery
                Console.WriteLine("Product ID: {0} ({1}) - Unit price: {2}", _
                    prod.ProductID, prod.ProductName, prod.UnitPrice)
            Next
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                "An error occurred during query execution.", ex)
        End Try
        '</snippetLinqQueryClientEval>
    End Sub
    Public Shared Sub RegisterHeadersQuery()
        '<snippetRegisterHeadersQuery>
        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri)

        ' Register to handle the SendingRequest event.
        ' Note: If this must be done for every request to the data service, consider
        ' registering for this event by overriding the OnContextCreated partial method in 
        ' the entity container, in this case NorthwindEntities. 
        AddHandler context.SendingRequest, AddressOf OnSendingRequest

        ' Define a query for orders with a Freight value greater than 30.
        Dim query = From cust In context.Customers _
            Where cust.Country = "Germany" _
            Select cust

        Try
            ' Enumerate to execute the query.
            For Each cust As Customer In query
                Console.WriteLine("Name: {0}" & vbNewLine & "Address:" & vbNewLine & "{1}" _
                                  & vbNewLine & "{2}, {3}", _
                    cust.CompanyName, cust.Address, cust.City, cust.Region)
            Next        
        Catch ex As DataServiceQueryException
            Throw New ApplicationException( _
                "An error occurred during query execution.", ex)
        End Try
        '</snippetRegisterHeadersQuery>
    End Sub
    '<snippetOnSendingRequest>
    Private Shared Sub OnSendingRequest(ByVal sender As Object, ByVal e As SendingRequestEventArgs)
        ' Add an Authorization header that contains an OAuth WRAP access token to the request.
        e.RequestHeaders.Add("Authorization", "WRAP access_token=""123456789""")
    End Sub
    '</snippetOnSendingRequest>


    Public Shared Sub CallServiceOperationIQueryable()
        '<snippetCallServiceOperationIQueryable>
        ' Define the service operation query parameter.
        Dim city As String = "London"

        ' Define the query URI to access the service operation with specific 
        ' query options relative to the service URI.
        Dim queryString As String = String.Format("GetOrdersByCity?city='{0}'", city) _
                                    & "&$orderby=ShippedDate desc" _
                                    & "&$expand=Order_Details"

        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri2)

        Try

            ' Execute the service operation that returns all orders for the specified city.
            Dim results = context.Execute(Of Order)(New Uri(queryString, UriKind.Relative))

            ' Write out order information.
            For Each o As Order In results
                Console.WriteLine(String.Format("Order ID: {0}", o.OrderID))
                For Each item As Order_Detail In o.Order_Details
                    Console.WriteLine(String.Format(vbTab & "Item: {0}, quantity: {1}", _
                        item.ProductID, item.Quantity))
                Next
            Next
        Catch ex As DataServiceQueryException
            Dim response As QueryOperationResponse = ex.Response

            Console.WriteLine(response.Error.Message)
        End Try
        '</snippetCallServiceOperationIQueryable> 
    End Sub

    Public Shared Sub CallServiceOperationCreateQuery()
        '<snippetCallServiceOperationCreateQuery>
        ' Define the service operation query parameter.
        Dim city As String = "London"

        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri2)

        ' Use the CreateQuery method to create a query that accessess
        ' the service operation passing a single parameter.       
        Dim query = context.CreateQuery(Of Order)("GetOrdersByCity") _
                .AddQueryOption("city", String.Format("'{0}'", city)).Expand("Order_Details")

        Try
            ' The query is executed during enumeration.
            For Each o As Order In query
                Console.WriteLine(String.Format("Order ID: {0}", o.OrderID))
                For Each item As Order_Detail In o.Order_Details
                    Console.WriteLine(String.Format(vbTab & "Item: {0}, quantity: {1}", _
                        item.ProductID, item.Quantity))
                Next
            Next
        Catch ex As DataServiceQueryException
            Dim response As QueryOperationResponse = ex.Response
            Console.WriteLine(response.Error.Message)
        End Try
        '</snippetCallServiceOperationCreateQuery>
    End Sub

    Public Shared Sub CallServiceOperationSingleEntity()
        '<snippetCallServiceOperationSingleEntity>
        ' Define the query URI to access the service operation, 
        ' relative to the service URI.
        Dim queryString As String = "GetNewestOrder"

        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri2)

        Try
            ' Execute a service operation that returns only the newest single order.
            Dim o As Order = _
                context.Execute(Of Order)( _
                    New Uri(queryString, UriKind.Relative)).FirstOrDefault()

            ' Write out order information.
            Console.WriteLine(String.Format("Order ID: {0}", o.OrderID))
            Console.WriteLine(String.Format("Order date: {0}", o.OrderDate))
        Catch ex As DataServiceQueryException
            Dim response As QueryOperationResponse = ex.Response

            Console.WriteLine(response.Error.Message)
        End Try
        '</snippetCallServiceOperationSingleEntity>
    End Sub
    Public Shared Sub CallServiceOperationSingleInt()
        '<snippetCallServiceOperationSingleInt>
        ' Define the query URI to access the service operation, 
        ' relative to the service URI.
        Dim queryString As String = "CountOpenOrders"

        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri2)

        Try
            ' Execute a service operation that returns the integer 
            ' count of open orders.
            Dim numOrders As Integer = context.Execute(Of Integer)( _
                New Uri(queryString, UriKind.Relative)).FirstOrDefault()

            ' Write out the number of open orders.
            Console.WriteLine(String.Format("Open orders as of {0}: {1}",
                DateTime.Today.Date, numOrders))
        Catch ex As DataServiceQueryException
            Dim response As QueryOperationResponse = ex.Response

            Console.WriteLine(response.Error.Message)
        End Try
        '</snippetCallServiceOperationSingleInt>
    End Sub
    Public Shared Sub CallServiceOperationVoid()
        '<snippetCallServiceOperationVoid>
        ' Define the query URI to access the service operation, 
        ' relative to the service URI.
        Dim queryString As String = "ReturnsNoData"

        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri2)

        Try
            ' Execute a service operation that returns void.
            context.Execute(Of String)( _
                New Uri(queryString, UriKind.Relative))
        Catch ex As DataServiceQueryException
            Dim response As QueryOperationResponse = ex.Response

            Console.WriteLine(response.Error.Message)
        End Try
        '</snippetCallServiceOperationVoid>
    End Sub
    Public Shared Sub CallServiceOperationAsync()
        '<snippetCallServiceOperationAsync>
        ' Define the service operation query parameter.
        Dim city As String = "London"

        ' Define the query URI to access the service operation with specific 
        ' query options relative to the service URI.
        Dim queryString As String = String.Format("GetOrdersByCity?city='{0}'", city) _
                & "&$orderby=ShippedDate desc" _
                & "&$expand=Order_Details"

        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri2)

        ' Define the delegate to callback into the process
        Dim callback As AsyncCallback = AddressOf OnAsyncExecutionComplete

        ' Execute the service operation that returns 
        ' all orders for the specified city.
        Dim results = context.BeginExecute(Of Order)( _
            New Uri(queryString, UriKind.Relative), _
            callback, context)
        '</snippetCallServiceOperationAsync>
    End Sub
    '<snippetOnAsyncExecutionComplete>
    Private Shared Sub OnAsyncExecutionComplete(ByVal result As IAsyncResult)

        ' Get the context back from the stored state.
        Dim context = TryCast(result.AsyncState, NorthwindEntities)

        Try
            ' Complete the exection and write out the results.
            For Each o As Order In context.EndExecute(Of Order)(result)
                Console.WriteLine(String.Format("Order ID: {0}", o.OrderID))

                For Each item As Order_Detail In o.Order_Details
                    Console.WriteLine(String.Format(vbTab & "Item: {0}, quantity: {1}", _
                        item.ProductID, item.Quantity))
                Next
            Next
        Catch ex As DataServiceQueryException
            Dim response As QueryOperationResponse = ex.Response
            Console.WriteLine(response.Error.Message)
        End Try
    End Sub
    '</snippetOnAsyncExecutionComplete>
    Public Shared Sub CallServiceOperationQueryAsync()
        '<snippetCallServiceOperationQueryAsync>
        ' Define the service operation query parameter.
        Dim city As String = "London"

        ' Create the DataServiceContext using the service URI.
        Dim context As NorthwindEntities = New NorthwindEntities(svcUri2)

        ' Use the CreateQuery method to create a query that accessess
        ' the service operation passing a single parameter.       
        Dim query = context.CreateQuery(Of Order)("GetOrdersByCity") _
                    .AddQueryOption("city", String.Format("'{0}'", city)) _
                    .Expand("Order_Details")

        ' Define the delegate to callback into the process
        Dim callback As AsyncCallback = AddressOf OnAsyncQueryExecutionComplete

        ' Execute the service operation that returns 
        ' all orders for the specified city.
        Dim results = _
            query.BeginExecute(callback, query)
        '</snippetCallServiceOperationQueryAsync>
    End Sub
    '<snippetOnAsyncQueryExecutionComplete>
    Private Shared Sub OnAsyncQueryExecutionComplete(ByVal result As IAsyncResult)
        ' Get the query back from the stored state.
        Dim query = TryCast(result.AsyncState, DataServiceQuery(Of Order))

        Try
            ' Complete the exection and write out the results.
            For Each o As Order In query.EndExecute(result)

                Console.WriteLine(String.Format("Order ID: {0}", o.OrderID))

                For Each item As Order_Detail In o.Order_Details
                    Console.WriteLine(String.Format(vbTab & "Item: {0}, quantity: {1}", _
                        item.ProductID, item.Quantity))
                Next
            Next
        Catch ex As DataServiceQueryException
            Dim response As QueryOperationResponse = ex.Response

            Console.WriteLine(response.Error.Message)
        End Try
    End Sub
    '</snippetOnAsyncQueryExecutionComplete> 
End Class
