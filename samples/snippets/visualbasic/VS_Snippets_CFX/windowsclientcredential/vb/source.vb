Imports System
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Security
Imports System.ServiceModel.Description
Imports System.Security.Cryptography.X509Certificates

Namespace Example

    Public Class Test

        Shared Sub Main()
            Dim t As New Test()
            t.Snippet1()

        End Sub
        Private Sub Snippet1()
            '<snippet1>
            ' Create a service host.
            Dim ea As New EndpointAddress("http://localhost/Calculator")
            Dim b As New WSHttpBinding(SecurityMode.Message)
            b.Security.Message.ClientCredentialType = _
            MessageCredentialType.Windows

            ' Create a client. The code is not shown here. See the WCF samples
            ' for an example of the CalculatorClient code.
            Dim cc As New CalculatorClient(b, ea)
            ' Get a reference to the Windows client credential object.
            Dim winCred As WindowsClientCredential = cc.ClientCredentials.Windows
            Console.WriteLine("AllowedImpersonationLevel: {0}", _
                             winCred.AllowedImpersonationLevel)
            Console.WriteLine("AllowNtlm: {0}", winCred.AllowNtlm)
            Console.WriteLine("Domain: {0}", winCred.ClientCredential.Domain)

            Console.ReadLine()
            ' Change the AllowedImpersonationLevel.
            winCred.AllowedImpersonationLevel = _
            System.Security.Principal.TokenImpersonationLevel.Impersonation

            Console.WriteLine("Changed AllowedImpersonationLevel: {0}", _
            winCred.AllowedImpersonationLevel)
            Console.ReadLine()
            ' Open the calculator and use it.
            ' cc.Open()
            ' Console.WriteLine(cc.Add(11, 11))
            ' Close the client.
            ' cc.Close()
            '</snippet1>
        End Sub

    End Class
End Namespace

<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"), System.ServiceModel.ServiceContractAttribute(ConfigurationName := "ICalculator")>  _
Public Interface ICalculator
    
    <System.ServiceModel.OperationContractAttribute(Action := "http://tempuri.org/ICalculator/Add", ReplyAction := "http://tempuri.org/ICalculator/AddResponse")>  _
    Function Add(ByVal a As Double, ByVal b As Double) As Double 
End Interface 'ICalculator

<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")>  _
Public Interface ICalculatorChannel
    : Inherits ICalculator, System.ServiceModel.IClientChannel
End Interface 'ICalculatorChannel


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
    
    End Function
End Class