Imports System.ServiceModel

'<snippetCustomIQueryableFeeds>
Imports System.Collections.Generic
Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Linq

Namespace CustomDataService
    '<snippetCustomOrderFeed>
    <EntityPropertyMappingAttribute("Customer", _
        SyndicationItemProperty.AuthorName, _
        SyndicationTextContentKind.Plaintext, True)> _
    <EntityPropertyMapping("OrderId", _
        SyndicationItemProperty.Title, _
        SyndicationTextContentKind.Plaintext, False)> _
    <DataServiceKeyAttribute("OrderId")> _
    Public Class Order
        '</snippetCustomOrderFeed>
        Private _orderId As Integer
        Private _customer As String
        Private _items As IList(Of Item)
        Public Property OrderId() As Integer
            Get
                Return _orderId
            End Get
            Set(ByVal value As Integer)
                _orderId = value
            End Set
        End Property
        Public Property Customer() As String
            Get
                Return _customer
            End Get
            Set(ByVal value As String)
                _customer = value
            End Set
        End Property
        Public Property Items() As IList(Of Item)
            Get
                Return _items
            End Get
            Set(ByVal value As IList(Of Item))
                _items = value
            End Set
        End Property
    End Class
    <EntityPropertyMappingAttribute("Product", "productname", _
        "orders", "http://schema.examples.microsoft.com/dataservices", True)> _
    <DataServiceKeyAttribute("Product")> _
    Public Class Item
        Private _product As String
        Private _quantity As Integer
        Public Property Product() As String
            Get
                Return _product
            End Get
            Set(ByVal value As String)
                _product = value
            End Set
        End Property
        Public Property Quantity() As Integer
            Get
                Return _quantity
            End Get
            Set(ByVal value As Integer)
                _quantity = value
            End Set
        End Property
    End Class
    Partial Public Class OrderItemData
#Region "Populate Service Data"
        Shared _orders As IList(Of Order)
        Shared _items As IList(Of Item)
        Sub New()
            _orders = New Order() { _
                New Order() With {.OrderId = 0, .Customer = "Peter Franken", .Items = New List(Of Item)()}, _
              New Order() With {.OrderId = 1, .Customer = "Ana Trujillo", .Items = New List(Of Item)()}}
            _items = New Item() { _
              New Item() With {.Product = "Chai", .Quantity = 10}, _
              New Item() With {.Product = "Chang", .Quantity = 25}, _
              New Item() With {.Product = "Aniseed Syrup", .Quantity = 5}, _
              New Item() With {.Product = "Chef Anton's Cajun Seasoning", .Quantity = 30}}
            _orders(0).Items.Add(_items(0))
            _orders(0).Items.Add(_items(1))
            _orders(1).Items.Add(_items(2))
            _orders(1).Items.Add(_items(3))
        End Sub
#End Region
        Public ReadOnly Property Orders() As IQueryable(Of Order)
            Get
                Return _orders.AsQueryable()
            End Get
        End Property
        Public ReadOnly Property Items() As IQueryable(Of Item)
            Get
                Return _items.AsQueryable()
            End Get
        End Property
    End Class
    Public Class OrderItems
        Inherits DataService(Of OrderItemData)
        ' This method is called only once to initialize
        ' service-wide policies.
        Shared Sub InitializeService(ByVal config As DataServiceConfiguration)
            config.SetEntitySetAccessRule("Orders", _
                                          EntitySetRights.AllRead _
                                          Or EntitySetRights.AllWrite)
            config.SetEntitySetAccessRule("Items", _
                                          EntitySetRights.AllRead _
                                          Or EntitySetRights.AllWrite)
            config.DataServiceBehavior.MaxProtocolVersion =
                DataServiceProtocolVersion.V2
        End Sub
    End Class
End Namespace
'</snippetCustomIQueryableFeeds>
