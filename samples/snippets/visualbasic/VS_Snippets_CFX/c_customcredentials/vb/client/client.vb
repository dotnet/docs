'<snippet20>
Imports System.IdentityModel.Selectors
Imports System.Security.Permissions
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel.Configuration
Imports System.Configuration

'<snippet1>
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
        Set
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
'</snippet1>
'<snippet2>

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
'</snippet2>


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

Public Class Client

    Shared Sub Main()
        '<snippet3>
        ' Create a client with the client endpoint configuration.
        Dim client As New CalculatorClient()

        ' Remove the ClientCredentials behavior.
        client.ChannelFactory.Endpoint.Behaviors.Remove(Of ClientCredentials)()

        ' Add a custom client credentials instance to the behaviors collection.
        client.ChannelFactory.Endpoint.Behaviors.Add(New MyClientCredentials())
        '</snippet3>
        Dim value1 As Double = 100.0
        Dim value2 As Double = 15.99
        Dim result As Double = client.Add(value1, value2)
        Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result)

        ' Closing the client closes the connection and cleans up resources.
        client.Close()

        Console.WriteLine()
        Console.WriteLine("Press <ENTER> to terminate client.")
        Console.ReadLine()

    End Sub
End Class



Class CalculatorClient
    Inherits System.ServiceModel.ClientBase(Of ICalculator)
    Implements ICalculator


    Public Sub New()
    End Sub


    Public Sub New(ByVal endpointConfigurationName As String)
        MyBase.New(endpointConfigurationName)

    End Sub


    Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
        MyBase.New(endpointConfigurationName, remoteAddress)

    End Sub


    Public Sub New(ByVal endpointConfigurationName As String, _
    ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(endpointConfigurationName, remoteAddress)

    End Sub


    Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, _
    ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(binding, remoteAddress)

    End Sub


    Public Function Add(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Add
        Return MyBase.Channel.Add(a, b)
    End Function
End Class

<System.ServiceModel.ServiceContractAttribute(ConfigurationName:="ICalculator")> _
Public Interface ICalculator

    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ICalculator/Add", _
    ReplyAction:="http://tempuri.org/ICalculator/AddResponse")> _
    Function Add(ByVal a As Double, ByVal b As Double) As Double
End Interface
'</snippet20>
