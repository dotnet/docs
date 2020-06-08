Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description

Public Class Test

    Shared Sub Main()
        Dim s As New Service()
        s.Nego()

    End Sub
End Class


Public Class Service

    Friend Sub Nego()
        '<snippet1>
        Dim b As New WSHttpBinding()
        ' By default, the WSHttpBinding uses Windows authentication 
        ' and Message mode.
        b.Security.Message.NegotiateServiceCredential = False
        '</snippet1>
        '<snippet6>
        Dim httpUri As New Uri("http://localhost:8000/")
        Dim sh As New ServiceHost(GetType(Calculator), httpUri)
        sh.Credentials.WindowsAuthentication.AllowAnonymousLogons = True
        '</snippet6>
        sh.AddServiceEndpoint(GetType(ICalculator), b, "Calculator")
        Dim sb As New ServiceMetadataBehavior()
        sb.HttpGetEnabled = True
        sb.HttpGetUrl = httpUri
        sh.Description.Behaviors.Add(sb)
        sh.Open()
        Console.WriteLine("Open")
        Console.ReadLine()

    End Sub
End Class


Public Class Client

    Private Sub IncorrectReturn()
        '<snippet2>
        Dim cc As New CalculatorClient("WSHttpBinding_ICalculator")
        cc.ClientCredentials.UserName.UserName = GetUserName() ' wrong!
        cc.ClientCredentials.UserName.Password = GetPassword() ' wrong!
        '</snippet2>
    End Sub


    Private Sub CorrectReturn()
        '<snippet3>
        Dim cc As New CalculatorClient("WSHttpBinding_ICalculator")
        ' This code returns the WindowsClientCredential type.            
        cc.ClientCredentials.Windows.ClientCredential.UserName = GetUserName()
        cc.ClientCredentials.Windows.ClientCredential.Password = GetPassword()
        '</snippet3>
    End Sub


    Private Sub DisallowNTLM()
        '<snippet4>
        Dim cc As New CalculatorClient("WSHttpBinding_ICalculator")
        cc.ClientCredentials.Windows.AllowNtlm = False
        '</snippet4>
    End Sub


    Private Sub AnonymousDisabled()
        '<snippet5>
        Dim cc As New CalculatorClient("WSHttpBinding_ICalculator")
        cc.ClientCredentials.Windows.AllowedImpersonationLevel = _
        System.Security.Principal.TokenImpersonationLevel.Anonymous
        '</snippet5>
    End Sub


    Private Function GetUserName() As String
        Return "blah"

    End Function 'GetUserName


    Private Function GetPassword() As String
        Return "Blah"

    End Function 'GetPassword
End Class

<ServiceContract()> _
Public Interface ICalculator
    <OperationContract()> _
    Function Add(ByVal a As Double, ByVal b As Double) As Double

    <OperationContract()> _
    Function Multiply(ByVal a As Double, ByVal b As Double) As Double
End Interface 'ICalculator


Public Class Calculator
    Implements ICalculator

    Public Function Add(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Add
        Return a + b

    End Function


    Public Function Multiply(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Multiply
        Return a * b

    End Function
End Class


<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
Public Interface ICalculatorChannel
    : Inherits ICalculator, System.ServiceModel.IClientChannel
End Interface


Class CalculatorClient
    Inherits System.ServiceModel.ClientBase(Of ICalculator)


    Public Sub New()

    End Sub


    Public Sub New(ByVal endpointConfigurationName As String)
        MyBase.New(endpointConfigurationName)

    End Sub


    Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
        MyBase.New(endpointConfigurationName, remoteAddress)

    End Sub


    Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(endpointConfigurationName, remoteAddress)

    End Sub


    Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(binding, remoteAddress)

    End Sub


    Public Function Add(ByVal a As Double, ByVal b As Double) As Double
        Return MyBase.Channel.Add(a, b)

    End Function 'Add


    Public Function Multiply(ByVal a As Double, ByVal b As Double) As Double
        Return MyBase.Channel.Multiply(a, b)

    End Function 'Multiply
End Class


