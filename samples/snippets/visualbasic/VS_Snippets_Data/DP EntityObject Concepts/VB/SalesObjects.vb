'<snippetEntityObject>
Option Explicit On
Option Strict On

Imports System
Imports System.Data.SqlTypes
Imports System.Collections.Generic
Imports System.Text
'<snippetEntityObjectUsing>
Imports System.Data
Imports System.Data.Objects.DataClasses
Imports System.Data.Metadata.Edm
Imports Microsoft.Samples.Edm
'</snippetEntityObjectUsing>

'<snippetCustomObjectAssemblyAttributes>
<Assembly: EdmSchemaAttribute()> 
<Assembly: EdmRelationshipAttribute("Microsoft.Samples.Edm", _
    "FK_LineItem_Order_OrderId", "Order", _
    RelationshipMultiplicity.One, GetType(Order), "LineItem", _
    RelationshipMultiplicity.Many, GetType(LineItem))> 
'</snippetCustomObjectAssemblyAttributes>
Namespace Microsoft.Samples.Edm

    '<snippetEntityObjectDeclaration>
    <EdmEntityTypeAttribute(NamespaceName:="Microsoft.Samples.Edm", Name:="Order")> _
    Public Class Order
        Inherits EntityObject
        '</snippetEntityObjectDeclaration>
        ' Define private property variables.
        Private _orderId As Integer
        Private _orderDate As DateTime
        Private _dueDate As DateTime
        Private _shipDate As DateTime
        Private _status As Byte
        Private _customer As Integer
        Private _subTotal As Decimal
        Private _tax As Decimal
        Private _freight As Decimal
        Private _totalDue As Decimal
        Private _extendedInfo As OrderInfo

        'Default Constructor.
        Sub New()

        End Sub
        ' Public properties of the Order object.
        <EdmScalarPropertyAttribute(EntityKeyProperty:=True, IsNullable:=False)> _
        Public Property OrderId() As Integer
            Get
                Return _orderId
            End Get
            '<snippetReportPropertyChange>
            Set(ByVal value As Integer)
                ReportPropertyChanging("OrderId")
                _orderId = value
                ReportPropertyChanged("OrderId")
            End Set
            '</snippetReportPropertyChange>
        End Property
        ' Navigation property that returns a collection of line items.
        <EdmRelationshipNavigationPropertyAttribute("Microsoft.Samples.Edm", _
                "FK_LineItem_Order_OrderId", "LineItem")> _
        Public ReadOnly Property LineItem() As EntityCollection(Of LineItem)
            Get
                Return CType(Me, IEntityWithRelationships).RelationshipManager _
                    .GetRelatedCollection(Of LineItem) _
                ("FK_LineItem_Order_OrderId", "LineItem")
            End Get
        End Property
        <EdmScalarPropertyAttribute(IsNullable:=False)> _
        Public Property OrderDate() As Date
            Get
                Return _orderDate
            End Get
            Set(ByVal value As DateTime)
                ReportPropertyChanging("OrderDate")
                _orderDate = value
                ReportPropertyChanged("OrderDate")
            End Set
        End Property
        <EdmScalarPropertyAttribute(IsNullable:=False)> _
        Public Property DueDate() As Date
            Get
                Return _dueDate
            End Get
            Set(ByVal value As Date)
                ReportPropertyChanging("DueDate")
                _dueDate = value
                ReportPropertyChanged("DueDate")
            End Set
        End Property
        <EdmScalarPropertyAttribute()> _
        Public Property ShipDate() As Date
            Get
                Return _shipDate
            End Get
            Set(ByVal value As Date)
                ReportPropertyChanging("ShipDate")
                _shipDate = value
                ReportPropertyChanged("ShipDate")
            End Set
        End Property
        '<snippetEntityObjectStatusProperty>
        <EdmScalarPropertyAttribute(IsNullable:=False)> _
        Public Property Status() As Byte
            Get
                Return _status
            End Get
            Set(ByVal value As Byte)
                If _status <> value Then
                    ReportPropertyChanging("Status")
                    _status = value
                    ReportPropertyChanged("Status")
                End If
            End Set
        End Property
        '</snippetEntityObjectStatusProperty>
        <EdmScalarPropertyAttribute(IsNullable:=False)> _
        Public Property Customer() As Integer
            Get
                Return _customer
            End Get
            Set(ByVal value As Integer)
                ReportPropertyChanging("Customer")
                _customer = value
                ReportPropertyChanged("Customer")
            End Set
        End Property
        <EdmScalarPropertyAttribute(IsNullable:=False)> _
        Public Property SubTotal() As Decimal
            Get
                Return _subTotal
            End Get
            Set(ByVal value As Decimal)
                If _subTotal <> value Then
                    ' Validate the value before setting it.
                    If value < 0 Then
                        Throw New ApplicationException(String.Format( _
                                  My.Resources.propertyNotValidNegative, _
                                  value.ToString, "SubTotal"))
                    End If
                    ReportPropertyChanging("SubTotal")
                    _subTotal = value
                    ReportPropertyChanged("SubTotal")

                    ' Recalculate the order total.
                    CalculateOrderTotal()
                End If
            End Set
        End Property
        <EdmScalarPropertyAttribute(IsNullable:=False)> _
        Public Property TaxAmt() As Decimal
            Get
                Return _tax
            End Get
            Set(ByVal value As Decimal)
                ' Validate the value before setting it.
                If value < 0 Then
                    Throw New ApplicationException(String.Format( _
                              My.Resources.propertyNotValidNegative, _
                              value.ToString(), "Tax"))
                End If
                ReportPropertyChanging("TaxAmt")
                _tax = value
                ReportPropertyChanged("TaxAmt")

                ' Recalculate the order total.
                CalculateOrderTotal()
            End Set
        End Property
        <EdmScalarPropertyAttribute(IsNullable:=False)> _
        Public Property Freight() As Decimal
            Get
                Return _freight
            End Get
            Set(ByVal value As Decimal)
                If _freight <> value Then
                    ' Validate the value before setting it.
                    If value < 0 Then
                        Throw New ApplicationException(String.Format( _
                                  My.Resources.propertyNotValidNegative, _
                        value.ToString(), "Freight"))
                    End If
                    ReportPropertyChanging("Freight")
                    _freight = value
                    ReportPropertyChanging("Freight")

                    ' Recalculate the order total.
                    CalculateOrderTotal()
                End If
            End Set
        End Property
        Public ReadOnly Property TotalDue() As Decimal
            Get
                Return _totalDue
            End Get
        End Property
        <EdmComplexPropertyAttribute()> _
        Public Property ExtendedInfo() As OrderInfo
            Get
                Return _extendedInfo
            End Get
            Set(ByVal value As OrderInfo)
                ReportPropertyChanging("ExtendedInfo")
                _extendedInfo = value
                ReportPropertyChanged("ExtendedInfo")
            End Set
        End Property
        Private Sub CalculateOrderTotal()
            ' Update the total due as a sum of the other cost properties.
            _totalDue = _subTotal + _tax + _freight
        End Sub
    End Class
    '<snippetComplexObjectDeclaration>
    <Global.System.Data.Objects.DataClasses.EdmComplexTypeAttribute( _
        NamespaceName:="Microsoft.Samples.Edm", Name:="OrderInfo")> _
    Partial Public Class OrderInfo
        Inherits Global.System.Data.Objects.DataClasses.ComplexObject
        '</snippetComplexObjectDeclaration>
        Private _orderNumber As String
        Private _purchaseOrder As String
        Private _accountNumber As String
        Private _comment As String
        <EdmScalarPropertyAttribute(IsNullable:=False)> _
    Public Property OrderNumber() As String
            Get
                Return _orderNumber
            End Get
            Set(ByVal value As String)
                ' Validate the value before setting it.
                If value.Length > 25 Then
                    Throw New ApplicationException(String.Format( _
                        My.Resources.propertyNotValidString, _
                        "OrderNumber", "25"))
                End If
                ReportPropertyChanging("OrderNumber")
                _orderNumber = value
                ReportPropertyChanged("OrderNumber")
            End Set
        End Property
        <EdmScalarPropertyAttribute()> _
        Public Property PurchaseOrder() As String
            Get
                Return _purchaseOrder
            End Get
            Set(ByVal value As String)
                '<snippetReportComplexPropertyChange>
                ' Validate the value before setting it.
                If (value <> Nothing) AndAlso value.Length > 25 Then
                    Throw New ApplicationException(String.Format( _
                              My.Resources.propertyNotValidString, _
                              "PurchaseOrder", "25"))
                End If
                If _purchaseOrder <> value Then
                    ReportPropertyChanging("PurchaseOrder")
                    _purchaseOrder = value
                    ReportPropertyChanged("PurchaseOrder")
                End If
                '</snippetReportComplexPropertyChange>
            End Set
        End Property
        <EdmScalarPropertyAttribute()> _
        Public Property AccountNumber() As String
            Get
                Return _accountNumber
            End Get
            Set(ByVal value As String)
                ' Validate the value before setting it.
                If (value <> Nothing) AndAlso value.Length > 15 Then
                    Throw New ApplicationException(String.Format( _
                              My.Resources.propertyNotValidString, _
                              "AccountNumber", "15"))
                End If
                ReportPropertyChanging("AccountNumber")
                _accountNumber = value
                ReportPropertyChanged("AccountNumber")
            End Set
        End Property
        <EdmScalarPropertyAttribute()> _
    Public Property Comment() As String
            Get
                Return _comment
            End Get
            Set(ByVal value As String)
                ' Validate the value before setting it.
                If (value <> Nothing) AndAlso value.Length > 128 Then
                    Throw New ApplicationException(String.Format( _
                              My.Resources.propertyNotValidString, _
                              "Comment", "128"))
                End If
                If _comment <> value Then
                    ReportPropertyChanging("Comment")
                    _comment = value
                    ReportPropertyChanged("Comment")
                End If
            End Set
        End Property
    End Class
    <EdmEntityTypeAttribute(NamespaceName:="Microsoft.Samples.Edm", _
                            Name:="LineItem")> _
    Public Class LineItem
        Inherits EntityObject

        ' Define private property variables.
        Dim _lineItemId As Integer
        Dim _trackingNumber As String
        Dim _quantity As Short
        Dim _product As Integer
        Dim _price As Decimal
        Dim _discount As Decimal
        Dim _total As Decimal
        Sub New()

        End Sub
        ' Defines a navigation property to the Order class.
        <EdmRelationshipNavigationPropertyAttribute("Microsoft.Samples.Edm", _
                "FK_LineItem_Order_OrderId", "Order")> _
        Public Property Order() As Order
            Get
                Return CType(Me,  _
                IEntityWithRelationships).RelationshipManager _
                    .GetRelatedReference(Of Order) _
                    ("FK_LineItem_Order_OrderId", "Order").Value
            End Get
            Set(ByVal value As Order)
                CType(Me,  _
                IEntityWithRelationships).RelationshipManager _
                    .GetRelatedReference(Of Order) _
                    ("FK_LineItem_Order_OrderId", "Order").Value = value
            End Set
        End Property
        <EdmScalarPropertyAttribute(EntityKeyProperty:=True, IsNullable:=False)> _
        Public Property LineItemId() As Integer
            Get
                Return _lineItemId
            End Get
            Set(ByVal value As Integer)
                ReportPropertyChanging("LineItemId")
                _lineItemId = value
                ReportPropertyChanged("LineItemId")
            End Set
        End Property
        <EdmScalarPropertyAttribute()> _
        Public Property TrackingNumber() As String
            Get
                Return _trackingNumber
            End Get
            Set(ByVal value As String)
                If _trackingNumber <> value Then
                    ' Validate the value before setting it.
                    If value.Length > 25 Then
                        Throw New ApplicationException(String.Format( _
                                My.Resources.propertyNotValidString, _
                                "TrackingNumber", "25"))
                    End If
                    ReportPropertyChanging("TrackingNumber")
                    _trackingNumber = value
                    ReportPropertyChanged("TrackingNumber")
                End If
            End Set
        End Property
        <EdmScalarPropertyAttribute(IsNullable:=False)> _
        Public Property Quantity() As Short
            Get
                Return _quantity
            End Get
            Set(ByVal value As Short)
                If _quantity <> value Then
                    ' Validate the value before setting it.
                    If value < 1 Then
                        Throw New ApplicationException(String.Format( _
                            My.Resources.propertyNotValidNegative, _
                            value.ToString(), "Quantity"))
                    End If
                    ReportPropertyChanging("Quantity")
                    _quantity = value
                    ReportPropertyChanged("Quantity")

                    ' Update the line total.
                    CalculateLineTotal()
                End If
            End Set
        End Property
        <EdmScalarPropertyAttribute(IsNullable:=False)> _
        Public Property Product() As Integer
            Get
                Return _product
            End Get
            Set(ByVal value As Integer)
                ' Validate the value before setting it.
                If value < 1 Then
                    Throw New ApplicationException(String.Format( _
                              My.Resources.propertyNotValidNegative, _
                              value.ToString(), "Product"))
                End If
                ReportPropertyChanging("Product")
                _product = value
                ReportPropertyChanged("Product")
            End Set
        End Property
        <EdmScalarPropertyAttribute(IsNullable:=False)> _
        Public Property Price() As Decimal
            Get
                Return _price
            End Get
            Set(ByVal value As Decimal)
                If _price <> value Then
                    ' Validate the value before setting it.
                    If value < 0 Then
                        Throw New ApplicationException(String.Format( _
                                  My.Resources.propertyNotValidNegative, _
                                  value.ToString(), "Price"))
                    End If
                    ReportPropertyChanging("Price")
                    _price = value
                    ReportPropertyChanged("Price")

                    ' Update the line total.
                    CalculateLineTotal()
                End If
            End Set
        End Property
        <EdmScalarPropertyAttribute(IsNullable:=False)> _
        Public Property Discount() As Decimal
            Get
                Return _discount
            End Get
            Set(ByVal value As Decimal)
                ' Validate the value before setting it.
                If value < 0 Then
                    Throw New ApplicationException(String.Format( _
                              My.Resources.propertyNotValidNegative, _
                              value.ToString(), "Discount"))
                End If
                ReportPropertyChanging("Discount")
                _discount = value
                ReportPropertyChanged("Discount")
            End Set
        End Property
        Public ReadOnly Property Total() As Decimal
            Get
                Return _total
            End Get
        End Property
        Private Sub CalculateLineTotal()
            _total = (_quantity * (_price - _discount))
        End Sub
    End Class
End Namespace
'</snippetEntityObject>
