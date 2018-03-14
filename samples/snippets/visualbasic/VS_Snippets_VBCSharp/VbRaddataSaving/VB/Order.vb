''' <summary>
''' A single order
''' </summary>
Public Class Order

    Public Sub New()
    End Sub

    ''' <summary>
    ''' Creates a new order
    ''' </summary>
    ''' <param name="orderid">The identifier for this order</param>
    ''' <param name="customerID">The customer who placed this order</param>
    ''' <param name="employeeID">The ID of the employee who took this order</param>
    ''' <param name="orderDate">The date this order was placed</param>
    ''' <param name="requiredDate">The date this order is required</param>
    ''' <param name="shippedDate">The date the order was shipped</param>
    ''' <param name="shipVia">The shipping method for this order</param>
    ''' <param name="freight">The freight charge for this order</param>
    ''' <param name="shipName">The name of the recipient for this order</param>
    ''' <param name="shipAddress">The address to ship this order to</param>
    ''' <param name="shipCity">The city to ship this order to</param>
    ''' <param name="shipRegion">The region to ship this order to</param>
    ''' <param name="shipPostalCode">The postal code to ship this order to</param>
    ''' <param name="shipCountry">The country to ship this order to</param>
    Public Sub New(ByVal orderid As Integer, _
                   ByVal customerID As String, _
                   ByVal employeeID As Integer, _
                   ByVal orderDate As DateTime, _
                   ByVal requiredDate As DateTime, _
                   ByVal shippedDate As DateTime, _
                   ByVal shipVia As Integer, _
                   ByVal freight As Decimal, _
                   ByVal shipName As String, _
                   ByVal shipAddress As String, _
                   ByVal shipCity As String, _
                   ByVal shipRegion As String, _
                   ByVal shipPostalCode As String, _
                   ByVal shipCountry As String)
        orderIDValue = orderid
        customerIDValue = customerID
        employeeIDValue = employeeID
        orderDateValue = orderDate
        requiredDateValue = requiredDate
        shippedDateValue = shippedDate
        shipViaValue = shipVia
        freightValue = freight
        shipAddressValue = shipAddress
        shipCityValue = shipCity
        shipRegionValue = shipRegion
        shipPostalCodeValue = shipPostalCode
        shipCountryValue = shipCountry
    End Sub

    Private orderIDValue As Integer
    ''' <summary>
    ''' Identifier for this order
    ''' </summary>
    Public Property OrderID() As Integer
        Get
            Return orderIDValue
        End Get
        Set(ByVal value As Integer)
            orderIDValue = value
        End Set
    End Property

    Private customerIDValue As String
    ''' <summary>
    ''' The customer who placed this order
    ''' </summary>
    Public Property CustomerID() As String
        Get
            Return customerIDValue
        End Get
        Set(ByVal Value As String)
            customerIDValue = Value
        End Set
    End Property

    Private employeeIDValue As Integer
    ''' <summary>
    ''' The ID of the employee who took this order
    ''' </summary>
    Public Property EmployeeID() As Integer
        Get
            Return employeeIDValue
        End Get
        Set(ByVal Value As Integer)
            employeeIDValue = Value
        End Set
    End Property


    Private orderDateValue As DateTime
    ''' <summary>
    ''' The date this order was placed
    ''' </summary>
    Public Property OrderDate() As DateTime
        Get
            Return orderDateValue
        End Get
        Set(ByVal Value As DateTime)
            orderDateValue = Value
        End Set
    End Property

    Private requiredDateValue As DateTime
    ''' <summary>
    ''' The date this order is required
    ''' </summary>
    Public Property RequiredDate() As DateTime
        Get
            Return requiredDateValue
        End Get
        Set(ByVal Value As DateTime)
            requiredDateValue = Value
        End Set
    End Property


    Private shippedDateValue As DateTime
    ''' <summary>
    ''' The date this order was shipped
    ''' </summary>
    Public Property ShippedDate() As DateTime
        Get
            Return shippedDateValue
        End Get
        Set(ByVal Value As DateTime)
            shippedDateValue = Value
        End Set
    End Property

    Private shipViaValue As Integer
    ''' <summary>
    ''' The shipping method for this order
    ''' </summary>
    Public Property ShipVia() As Integer
        Get
            Return shipViaValue
        End Get
        Set(ByVal Value As Integer)
            shipViaValue = Value
        End Set
    End Property


    Private freightValue As Decimal
    ''' <summary>
    ''' The freight charge for this order
    ''' </summary>
    Public Property Freight() As Decimal
        Get
            Return freightValue
        End Get
        Set(ByVal Value As Decimal)
            freightValue = Value
        End Set
    End Property

    Private shipNameValue As String
    ''' <summary>
    ''' The name of the recipient for this order
    ''' </summary>
    Public Property ShipName() As String
        Get
            Return shipNameValue
        End Get
        Set(ByVal Value As String)
            shipNameValue = Value
        End Set
    End Property


    Private shipAddressValue As String
    ''' <summary>
    ''' The address to ship this order to
    ''' </summary>
    Public Property ShipAddress() As String
        Get
            Return shipAddressValue
        End Get
        Set(ByVal Value As String)
            shipAddressValue = Value
        End Set
    End Property

    Private shipCityValue As String
    ''' <summary>
    ''' The city to ship this order to
    ''' </summary>
    Public Property ShipCity() As String
        Get
            Return shipCityValue
        End Get
        Set(ByVal Value As String)
            shipCityValue = Value
        End Set
    End Property

    Private shipRegionValue As String
    ''' <summary>
    ''' The region to ship this order to
    ''' </summary>
    Public Property ShipRegion() As String
        Get
            Return shipRegionValue
        End Get
        Set(ByVal Value As String)
            shipRegionValue = Value
        End Set
    End Property

    Private shipPostalCodeValue As String
    ''' <summary>
    ''' The postal code to ship this order to
    ''' </summary>
    Public Property ShipPostalCode() As String
        Get
            Return shipPostalCodeValue
        End Get
        Set(ByVal Value As String)
            shipPostalCodeValue = Value
        End Set
    End Property

    Private shipCountryValue As String
    ''' <summary>
    ''' The country to ship this order to
    ''' </summary>
    Public Property ShipCountry() As String
        Get
            Return shipCountryValue
        End Get
        Set(ByVal Value As String)
            shipCountryValue = Value
        End Set
    End Property


    Private customerValue As Customer
    ''' <summary>
    ''' The customer this order belongs to
    ''' </summary>
    Public Property Customer() As Customer
        Get
            Return customerValue
        End Get
        Set(ByVal Value As Customer)
            customerValue = Value
        End Set
    End Property


End Class

''' <summary>
''' A collection of Orders
''' </summary>
Public Class Orders
    Inherits System.ComponentModel.BindingList(Of Order)

End Class
