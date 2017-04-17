Public Class Customer

    Public Sub New()
    End Sub

    Public Sub New(ByVal customerId As String, _
                   ByVal companyName As String, _
                   ByVal contactName As String, _
                   ByVal contactTitle As String, _
                   ByVal address As String, _
                   ByVal city As String, _
                   ByVal region As String, _
                   ByVal postalCode As String, _
                   ByVal country As String, _
                   ByVal phone As String, _
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
    Public Property CustomerID() As String
        Get
            Return customerIDValue
        End Get
        Set(ByVal value As String)
            customerIDValue = value
        End Set
    End Property

    Private companyNameValue As String
    Public Property CompanyName() As String
        Get
            Return companyNameValue
        End Get
        Set(ByVal Value As String)
            companyNameValue = Value
        End Set
    End Property

    Private contactNameValue As String
    Public Property ContactName() As String
        Get
            Return contactNameValue
        End Get
        Set(ByVal Value As String)
            contactNameValue = Value
        End Set
    End Property

    Private contactTitleValue As String
    Public Property ContactTitle() As String
        Get
            Return contactTitleValue
        End Get
        Set(ByVal Value As String)
            contactTitleValue = Value
        End Set
    End Property

    Private addressValue As String
    Public Property Address() As String
        Get
            Return addressValue
        End Get
        Set(ByVal Value As String)
            addressValue = Value
        End Set
    End Property

    Private cityValue As String
    Public Property City() As String
        Get
            Return cityValue
        End Get
        Set(ByVal Value As String)
            cityValue = Value
        End Set
    End Property

    Private regionValue As String
    Public Property Region() As String
        Get
            Return regionValue
        End Get
        Set(ByVal Value As String)
            regionValue = Value
        End Set
    End Property

    Private postalCodeValue As String
    Public Property PostalCode() As String
        Get
            Return postalCodeValue
        End Get
        Set(ByVal Value As String)
            postalCodeValue = Value
        End Set
    End Property

    Private countryValue As String
    Public Property Country() As String
        Get
            Return countryValue
        End Get
        Set(ByVal Value As String)
            countryValue = Value
        End Set
    End Property


    Private phoneValue As String
    Public Property Phone() As String
        Get
            Return phoneValue
        End Get
        Set(ByVal Value As String)
            phoneValue = Value
        End Set
    End Property

    Private faxValue As String
    Public Property Fax() As String
        Get
            Return faxValue
        End Get
        Set(ByVal Value As String)
            faxValue = Value
        End Set
    End Property

    Private ordersCollection As New System.ComponentModel.BindingList(Of Order)
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


    Public origCustomerID As String
    Public origCompanyName As String
    Public origContactName As String
    Public origContactTitle As String
    Public origAddress As String
    Public origCity As String
    Public origRegion As String
    Public origPostalCode As String
    Public origCountry As String
    Public origPhone As String
    Public origFax As String
End Class

