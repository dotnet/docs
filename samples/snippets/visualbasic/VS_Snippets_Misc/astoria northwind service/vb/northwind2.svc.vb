Option Explicit On
Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.Data.Services
Imports System.Linq
Imports System.ServiceModel.Web
Imports System.Web
'<snippetUsingLinqExpressions>
Imports System.Linq.Expressions
'</snippetUsingLinqExpressions>
Imports System.Reflection
Imports System.Data.Objects

<System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults:=True)> _
Public Class Northwind2
    Inherits DataService(Of NorthwindEntities)
    ' This method is called only once to initialize service-wide policies.
    Public Shared Sub InitializeService(ByVal config As DataServiceConfiguration)
        config.SetEntitySetAccessRule("Employees", EntitySetRights.AllRead)
        config.SetEntitySetAccessRule("Customers", EntitySetRights.AllRead)
        config.SetEntitySetAccessRule("Orders", EntitySetRights.All)
        config.SetEntitySetAccessRule("Order_Details", EntitySetRights.All)
        config.SetEntitySetAccessRule("Products", EntitySetRights.AllRead)
        config.UseVerboseErrors = True
        config.DataServiceBehavior.MaxProtocolVersion = Common.DataServiceProtocolVersion.V2

        '<snippetServiceOperationConfig>
        config.SetServiceOperationAccessRule( _
            "GetOrdersByCity", ServiceOperationRights.AllRead)
        '</snippetServiceOperationConfig>

        config.SetEntitySetPageSize("Customers", 10)
        config.SetEntitySetPageSize("Orders", 10)
    End Sub
    '<snippetServiceOperation>
    '<snippetServiceOperationDef>
    <WebGet()> _
    Public Function GetOrdersByCity(ByVal city As String) As IQueryable(Of Order)
        '</snippetServiceOperationDef>
        If String.IsNullOrEmpty(city) Then
            Throw New ArgumentNullException("city", _
                "You must provide a value for the parameter'city'.")
        End If

        ' Get the ObjectContext that is the data source for the service.
        Dim context As NorthwindEntities = Me.CurrentDataSource

        Try
            Dim selectedOrders = From order In context.Orders.Include("Order_Details") _
                                     Where order.Customer.City = city _
                                     Select order
            Return selectedOrders
        Catch ex As Exception
            Throw New ApplicationException("An error occurred: {0}", ex)
        End Try
    End Function
    '</snippetServiceOperation>
    '<snippetQueryInterceptor>
    '<snippetQueryInterceptorDef>
    ' Define a query interceptor for the Orders entity set.
    <QueryInterceptor("Orders")> _
    Public Function OnQueryOrders() As Expression(Of Func(Of Order, Boolean))
        '</snippetQueryInterceptorDef>
        ' Filter the returned orders to only orders 
        ' that belong to a customer that is the current user.
        Return Function(o) o.Customer.ContactName = _
            HttpContext.Current.User.Identity.Name
    End Function
    '</snippetQueryInterceptor>
    '<snippetChangeInterceptor>
    '<snippetChangeInterceptorDef>
    ' Define a change interceptor for the Products entity set.
    <ChangeInterceptor("Products")> _
    Public Sub OnChangeProducts(ByVal product As Product, _
                                ByVal operations As UpdateOperations)
        '</snippetChangeInterceptorDef>
        If operations = UpdateOperations.Change Then
            Dim entry As System.Data.Objects.ObjectStateEntry

            If Me.CurrentDataSource.ObjectStateManager _
                .TryGetObjectStateEntry(product, entry) Then

                ' Reject changes to a discontinued Product.
                ' Because the update is already made to the entity by the time the 
                ' change interceptor in invoked, check the original value of the Discontinued
                ' property in the state entry and reject the change if 'true'.
                If CType(entry.OriginalValues("Discontinued"), Boolean) Then
                    Throw New DataServiceException(400, String.Format(
                                "A discontinued {0} cannot be modified.", product.ToString()))
                Else
                    Throw New DataServiceException(String.Format( _
                        "The requested {0} could not be found in the data source.", product.ToString()))
                End If
            ElseIf (operations = UpdateOperations.Delete) Then
                ' Block the delete and instead set the Discontinued flag.
                Throw New DataServiceException(400, _
                    "Products cannot be deleted; instead set the Discontinued flag to 'true'")
            End If
        End If
    End Sub
    '</snippetChangeInterceptor>
    '<snippetHandleExceptions>
    ' Override to manage returned exceptions.
    Protected Overrides Sub HandleException(args As HandleExceptionArgs)
        ' Handle exceptions raised in service operations.
        If args.Exception.GetType() = GetType(TargetInvocationException) _
            AndAlso args.Exception.InnerException IsNot Nothing Then
            If args.Exception.InnerException.GetType() = GetType(DataServiceException) Then
                ' Unpack the DataServiceException.
                args.Exception = _
                    TryCast(args.Exception.InnerException, DataServiceException)
            Else
                ' Return a new DataServiceException as "400: bad request."
                args.Exception = _
                    New DataServiceException(400, args.Exception.InnerException.Message)
            End If
        End If
    End Sub
    '</snippetHandleExceptions>

    '<snippetRaiseErrorOperation>
    <WebGet()>
    Public Sub RaiseError()
        Throw New DataServiceException(500, "My custom error message.")
    End Sub
    '</snippetRaiseErrorOperation>

    <WebInvoke(Method:="POST")>
    Public Function GetCustomerNamesPost() As IEnumerable(Of String)
        ' Get the ObjectContext that is the data source for the service.
        Dim context As NorthwindEntities = Me.CurrentDataSource

        Dim customerNames = From cust In context.Customers _
        Order By cust.ContactName _
        Select cust.ContactName

        Return customerNames
    End Function

    <WebGet()>
    Public Function GetCustomerNames() As IEnumerable(Of String)
       ' Get the ObjectContext that is the data source for the service.
        Dim context As NorthwindEntities = Me.CurrentDataSource

        Dim customerNames = From cust In context.Customers _
        Order By cust.ContactName _
        Select cust.ContactName

        Return customerNames
    End Function

    ' Used in the Service Operations topic to demo multiple params.
    <WebGet()>
    Public Function GetOrdersByState(state As String, includeItems As Boolean) As IQueryable(Of Order)
        If String.IsNullOrEmpty(state) Then
            Throw New ArgumentNullException("state", _
                "You must provide a value for the parameter'state'.")
        End If

        ' Get the ObjectContext that is the data source for the service.
        Dim context As NorthwindEntities = Me.CurrentDataSource

        Try
            Dim selectedOrders As ObjectQuery(Of Order) = context.Orders

            If includeItems Then

                selectedOrders = selectedOrders.Include("Order_Details")

                Return selectedOrders.Where(Function(o) o.ShipRegion.Equals(state))
            End If
        Catch ex As Exception            
            Throw New ApplicationException(String.Format( _
                "An error occurred: {0}", ex.Message))
        End Try
    End Function

    <WebGet()>
    Public Function CloneCustomer(ByVal serializedCustomer As String) As Customer

        Dim context As NorthwindEntities = Me.CurrentDataSource

        Dim xmlSerializer As System.Xml.Serialization.XmlSerializer = _
            New System.Xml.Serialization.XmlSerializer(GetType(Customer))

        Dim reader As System.IO.TextReader = New System.IO.StringReader(serializedCustomer)

        ' Get a customer created with a property-wise clone
        ' of the supplied entity, with a new ID.
        Dim clone As Customer = CloneCustomer(TryCast(xmlSerializer.Deserialize(reader), Customer))

        Try
            ' Note that this bypasses the service ops restrictions.
            context.AddToCustomers(clone)
            context.SaveChanges()    
        Catch ex As Exception

            Throw New DataServiceException(
                "The Customer could not be cloned.", ex.GetBaseException())
            Return clone
        End Try

    End Function

    Private Shared Function CloneCustomer(ByVal customer As Customer) As Customer
        Dim clone As Customer = customer.CreateCustomer("AAAAA", customer.CompanyName)
        With clone
            .Address = customer.Address
            .City = customer.City
            .CompanyName = customer.CompanyName
            .ContactName = customer.ContactName
            .ContactTitle = customer.ContactTitle
            .Country = customer.Country
            .Fax = customer.Fax
            .Phone = customer.Phone
            .PostalCode = customer.PostalCode
            .Region = customer.Region
        End With
        Return clone
    End Function
End Class
