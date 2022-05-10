'<snippet0>
Imports System.IdentityModel.Selectors
Imports System.Security.Permissions
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel.Configuration
Imports System.Configuration


Public Class MyClientCredentials
    Inherits ClientCredentials
    Private creditCardNumberValue As String

    Public Sub New()

    End Sub

    ' Perform client credentials initialization.    
    Protected Sub New(ByVal other As MyClientCredentials)
        MyBase.New(other)
        ' Clone fields defined in this class.
        Me.creditCardNumberValue = other.creditCardNumberValue

    End Sub

    Public Property CreditCardNumber() As String
        Get
            Return Me.creditCardNumberValue
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                Throw New ArgumentNullException("value")
            End If
            Me.creditCardNumberValue = value
        End Set
    End Property

    Public Overrides Function CreateSecurityTokenManager() As SecurityTokenManager
        ' Return your implementation of the SecurityTokenManager.
        Return New MyClientCredentialsSecurityTokenManager(Me)

    End Function

    Protected Overrides Function CloneCore() As ClientCredentials
        ' Implement the cloning functionality.
        Return New MyClientCredentials(Me)

    End Function
End Class

Friend Class MyClientCredentialsSecurityTokenManager
    Inherits ClientCredentialsSecurityTokenManager
    Private credentials As MyClientCredentials


    Public Sub New(ByVal credentials As MyClientCredentials)
        MyBase.New(credentials)
        Me.credentials = credentials

    End Sub


    Public Overrides Function CreateSecurityTokenProvider( _
    ByVal tokenRequirement As SecurityTokenRequirement) As SecurityTokenProvider
        ' Return your implementation of the SecurityTokenProvider, if required.
        ' This implementation delegates to the base class.
        Return MyBase.CreateSecurityTokenProvider(tokenRequirement)

    End Function


    Public Overrides Function CreateSecurityTokenAuthenticator( _
    ByVal tokenRequirement As SecurityTokenRequirement, _
    ByRef outOfBandTokenResolver As SecurityTokenResolver) As SecurityTokenAuthenticator
        ' Return your implementation of the SecurityTokenAuthenticator, if required.
        ' This implementation delegates to the base class.
        Return MyBase.CreateSecurityTokenAuthenticator(tokenRequirement, outOfBandTokenResolver)

    End Function


    Public Overrides Function CreateSecurityTokenSerializer(ByVal version As SecurityTokenVersion) _
    As SecurityTokenSerializer
        ' Return your implementation of the SecurityTokenSerializer, if required.
        ' This implementation delegates to the base class.
        Return MyBase.CreateSecurityTokenSerializer(version)

    End Function
End Class
'<snippet4>
Public Class MyServiceCredentials
    Inherits ServiceCredentials
    Private additionalCertificateValue As X509Certificate2

    Public Sub New()

    End Sub

    Protected Sub New(ByVal other As MyServiceCredentials)
        MyBase.New(other)
        Me.additionalCertificate = other.additionalCertificate
    End Sub


    Public Property AdditionalCertificate() As X509Certificate2
        Get
            Return Me.additionalCertificateValue
        End Get
        Set
            If value Is Nothing Then
                Throw New ArgumentNullException("value")
            End If
            Me.additionalCertificateValue = value
        End Set
    End Property

    Public Overrides Function CreateSecurityTokenManager() As SecurityTokenManager
        Return MyBase.CreateSecurityTokenManager()

    End Function


    Protected Overrides Function CloneCore() As ServiceCredentials
        Return New MyServiceCredentials(Me)

    End Function
End Class
'</snippet4>

'<snippet5>
Friend Class MyServiceCredentialsSecurityTokenManager
    Inherits ServiceCredentialsSecurityTokenManager
    Private credentials As MyServiceCredentials

    Public Sub New(ByVal credentials As MyServiceCredentials)
        MyBase.New(credentials)
        Me.credentials = credentials

    End Sub


    Public Overrides Function CreateSecurityTokenProvider(ByVal tokenRequirement As SecurityTokenRequirement) _
    As SecurityTokenProvider
        ' Return your implementation of SecurityTokenProvider, if required.
        ' This implementation delegates to the base class.
        Return MyBase.CreateSecurityTokenProvider(tokenRequirement)

    End Function

    Public Overrides Function CreateSecurityTokenAuthenticator( _
    ByVal tokenRequirement As SecurityTokenRequirement, _
    ByRef outOfBandTokenResolver As SecurityTokenResolver) _
    As SecurityTokenAuthenticator
        ' Return your implementation of SecurityTokenProvider, if required.
        ' This implementation delegates to the base class.
        Return MyBase.CreateSecurityTokenAuthenticator(tokenRequirement, outOfBandTokenResolver)

    End Function


    Public Overrides Function CreateSecurityTokenSerializer(ByVal version As SecurityTokenVersion) _
    As SecurityTokenSerializer
        ' Return your implementation of SecurityTokenProvider, if required.
        ' This implementation delegates to the base class.
        Return MyBase.CreateSecurityTokenSerializer(version)

    End Function
End Class
'</snippet5>

'<snippet7>

Public Class MyClientCredentialsConfigHandler
    Inherits ClientCredentialsElement
    Private propertiesValue As ConfigurationPropertyCollection


    Public Overrides ReadOnly Property BehaviorType() As Type
        Get
            Return GetType(MyClientCredentials)
        End Get
    End Property

    Public Property CreditCardNumber() As String
        Get
            Return CStr(MyBase.Item("creditCardNumber"))
        End Get
        Set
            If String.IsNullOrEmpty(value) Then
                value = String.Empty
            End If
            MyBase.Item("creditCardNumber") = value
        End Set
    End Property


    Protected Overrides ReadOnly Property Properties() As ConfigurationPropertyCollection
        Get
            If Me.propertiesValue Is Nothing Then
                Dim myProperties As ConfigurationPropertyCollection = MyBase.Properties
                myProperties.Add(New ConfigurationProperty( _
                "creditCardNumber", _
                GetType(System.String), _
                String.Empty, _
                Nothing, _
                New StringValidator(0, 32, Nothing), _
                ConfigurationPropertyOptions.None))
                Me.propertiesValue = myProperties
            End If
            Return Me.propertiesValue
        End Get
    End Property


    Protected Overrides Function CreateBehavior() As Object
        Dim creds As New MyClientCredentials()
        creds.CreditCardNumber = Me.CreditCardNumber
        MyBase.ApplyConfiguration(creds)
        Return creds

    End Function
End Class
'</snippet7>

<ServiceContract()> _
Public Interface IService
    <OperationContract()> _
    Function Echo(ByVal value As String) As String
End Interface


Public Class Service
    Implements IService

    Shared Sub Main()
        '<snippet6>
        ' Create a service host with a service type.
        Dim serviceHost As New ServiceHost(GetType(Service))

        ' Remove the default ServiceCredentials behavior.
        serviceHost.Description.Behaviors.Remove(Of ServiceCredentials)()

        ' Add a custom service credentials instance to the collection.
        serviceHost.Description.Behaviors.Add(New MyServiceCredentials())
        '</snippet6>
        Console.WriteLine("Service started")
        Console.WriteLine("Press <ENTER> to terminate.")
        Console.ReadLine()

    End Sub

#Region "IService Members"
    Public Function Echo(ByVal value As String) As String Implements IService.Echo
        Return value
    End Function
#End Region
End Class



<System.ServiceModel.ServiceContractAttribute(ConfigurationName:="ICalculator")> _
Public Interface ICalculator

    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ICalculator/Add", _
    ReplyAction:="http://tempuri.org/ICalculator/AddResponse")> _
    Function Add(ByVal a As Double, ByVal b As Double) As Double
End Interface
'</snippet0>
