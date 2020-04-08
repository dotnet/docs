Option Explicit On
Option Strict On

Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.Services.Common

'<snippetCustomerAddressDefinition>
<DataServiceKey("CustomerID")> _
Partial Public Class CustomerAddress
    Private _customerID As String
    Private _address As String
    Private _city As String
    Private _region As String
    Private _postalCode As String
    Private _country As String

    Public Property CustomerID() As String
        Get
            Return Me._customerID
        End Get
        Set(ByVal value As String)
            Me._customerID = Value
        End Set
    End Property
    Public Property Address() As String
        Get
            Return Me._address
        End Get
        Set(ByVal value As String)
            Me._address = Value
        End Set
    End Property
    Public Property City() As String
        Get
            Return Me._city
        End Get
        Set(ByVal value As String)
            Me._city = Value
        End Set
    End Property
    Public Property Region() As String
        Get
            Return Me._region
        End Get
        Set(ByVal value As String)
            Me._region = Value
        End Set
    End Property
    Public Property PostalCode() As String
        Get
            Return Me._postalCode
        End Get
        Set(ByVal value As String)
            Me._postalCode = Value
        End Set
    End Property
    Public Property Country() As String
        Get
            Return Me._country
        End Get
        Set(ByVal value As String)
            Me._country = value
        End Set
    End Property
End Class
Public Class CustomerAddressNonEntity
    Private _companyName As String
    Private _address As String
    Private _city As String
    Private _region As String
    Private _postalCode As String
    Private _country As String

    Public Property CompanyName() As String
        Get
            Return Me._companyName
        End Get
        Set(ByVal value As String)
            Me._companyName = value
        End Set
    End Property
    Public Property Address() As String
        Get
            Return Me._address
        End Get
        Set(ByVal value As String)
            Me._address = Value
        End Set
    End Property
    Public Property City() As String
        Get
            Return Me._city
        End Get
        Set(ByVal value As String)
            Me._city = Value
        End Set
    End Property
    Public Property Region() As String
        Get
            Return Me._region
        End Get
        Set(ByVal value As String)
            Me._region = Value
        End Set
    End Property
    Public Property PostalCode() As String
        Get
            Return Me._postalCode
        End Get
        Set(ByVal value As String)
            Me._postalCode = Value
        End Set
    End Property
    Public Property Country() As String
        Get
            Return Me._country
        End Get
        Set(ByVal value As String)
            Me._country = value
        End Set
    End Property
End Class
'</snippetCustomerAddressDefinition>
Partial Public Class CustomerAddress
    ' Default constructor for initializers.
    Sub New()
    End Sub
    ' Public constructors with propeties.
    Sub New(ByVal customerID As String, _
        ByVal address As String, _
        ByVal city As String, _
        ByVal region As String, _
        ByVal postalCode As String, _
        ByVal country As String)
        _customerID = CustomerID
        _address = address
        _city = city
        _region = region
        _postalCode = postalCode
        _country = country
    End Sub
End Class
