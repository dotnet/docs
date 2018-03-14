'<Snippet1>
''' <summary>
''' A single customer
''' </summary>
Public Class Customer

    Public Sub New()
    End Sub

    ''' <summary>
    ''' Creates a new customer
    ''' </summary>
    ''' <param name="customerId">The ID that uniquely identifies this customer</param>
    ''' <param name="companyName">The name for this customer</param>
    ''' <param name="contactName">The name for this customer's contact</param>
    ''' <param name="contactTitle">The title for this contact</param>
    ''' <param name="address">The address for this customer</param>
    ''' <param name="city">The city for this customer</param>
    ''' <param name="region">The region for this customer</param>
    ''' <param name="postalCode">The postal code for this customer</param>
    ''' <param name="country">The country for this customer</param>
    ''' <param name="phone">The phone number for this customer</param>
    ''' <param name="fax">The fax number for this customer</param>
    Public Sub New(ByVal customerId As String,
                   ByVal companyName As String,
                   ByVal contactName As String,
                   ByVal contactTitle As String,
                   ByVal address As String,
                   ByVal city As String,
                   ByVal region As String,
                   ByVal postalCode As String,
                   ByVal country As String,
                   ByVal phone As String,
                   ByVal fax As String)
        customerIDValue = customerId
        companyNameValue = companyName
        contactNameValue = contactName
        contactTitleValue = contactTitle
        addressValue = address
        cityValue = city
        regionValue = region
        postalCodeValue = postalCode
        countryValue = country
        phoneValue = phone
        faxValue = fax
    End Sub

    Private customerIDValue As String
    ''' <summary>
    ''' The ID that uniquely identifies this customer
    ''' </summary>
    Public Property CustomerID() As String
        Get
            Return customerIDValue
        End Get
        Set(ByVal value As String)
            customerIDValue = value
        End Set
    End Property

    Private companyNameValue As String
    ''' <summary>
    ''' The name for this customer
    ''' </summary>
    Public Property CompanyName() As String
        Get
            Return companyNameValue
        End Get
        Set(ByVal Value As String)
            companyNameValue = Value
        End Set
    End Property

    Private contactNameValue As String
    ''' <summary>
    ''' The name for this customer's contact
    ''' </summary>
    Public Property ContactName() As String
        Get
            Return contactNameValue
        End Get
        Set(ByVal Value As String)
            contactNameValue = Value
        End Set
    End Property

    Private contactTitleValue As String
    ''' <summary>
    ''' The title for this contact
    ''' </summary>
    Public Property ContactTitle() As String
        Get
            Return contactTitleValue
        End Get
        Set(ByVal Value As String)
            contactTitleValue = Value
        End Set
    End Property

    Private addressValue As String
    ''' <summary>
    ''' The address for this customer
    ''' </summary>
    Public Property Address() As String
        Get
            Return addressValue
        End Get
        Set(ByVal Value As String)
            addressValue = Value
        End Set
    End Property

    Private cityValue As String
    ''' <summary>
    ''' The city for this customer
    ''' </summary>
    Public Property City() As String
        Get
            Return cityValue
        End Get
        Set(ByVal Value As String)
            cityValue = Value
        End Set
    End Property

    Private regionValue As String
    ''' <summary>
    ''' The region for this customer
    ''' </summary>
    Public Property Region() As String
        Get
            Return regionValue
        End Get
        Set(ByVal Value As String)
            regionValue = Value
        End Set
    End Property

    Private postalCodeValue As String
    ''' <summary>
    ''' The postal code for this customer
    ''' </summary>
    Public Property PostalCode() As String
        Get
            Return postalCodeValue
        End Get
        Set(ByVal Value As String)
            postalCodeValue = Value
        End Set
    End Property

    Private countryValue As String
    ''' <summary>
    ''' The country for this customer
    ''' </summary>
    Public Property Country() As String
        Get
            Return countryValue
        End Get
        Set(ByVal Value As String)
            countryValue = Value
        End Set
    End Property


    Private phoneValue As String
    ''' <summary>
    ''' The phone number for this customer
    ''' </summary>
    Public Property Phone() As String
        Get
            Return phoneValue
        End Get
        Set(ByVal Value As String)
            phoneValue = Value
        End Set
    End Property

    Private faxValue As String
    ''' <summary>
    ''' The fax number for this customer
    ''' </summary>
    Public Property Fax() As String
        Get
            Return faxValue
        End Get
        Set(ByVal Value As String)
            faxValue = Value
        End Set
    End Property

    Private ordersCollection As New System.ComponentModel.BindingList(Of Order)
    ''' <summary>
    ''' The orders for this customer
    ''' </summary>
    Public Property Orders() As System.ComponentModel.BindingList(Of Order)
        Get
            Return ordersCollection
        End Get
        Set(ByVal value As System.ComponentModel.BindingList(Of Order))
            ordersCollection = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return Me.CompanyName & " (" & Me.CustomerID & ")"
    End Function

End Class
'</Snippet1>
