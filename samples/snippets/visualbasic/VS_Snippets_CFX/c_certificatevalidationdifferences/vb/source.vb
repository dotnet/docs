Imports System.Xml
Imports System.Collections
Imports System.ServiceModel
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel.Security
Imports System.Security.Permissions
Imports System.Net
Imports System.Net.Security
Imports System.Runtime.Serialization
Imports System.Xml.Schema

Public Class Test
    Public Shared Sub Main()
        Try
            Dim t As New Test()
            t.Run()
        Catch exc As Exception
            Console.WriteLine("Message: {0}", exc.Message)
            Console.ReadLine()
        Finally
            Console.WriteLine(vbLf & " " & vbLf & " Done")
            Console.ReadLine()
        End Try
    End Sub
    Private Sub Run()
        '<snippet1>
        ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf ValidateServerCertificate)
        '</snippet1>
    End Sub

    '<snippet2>
    Public Shared Function ValidateServerCertificate(ByVal sender As Object, _
                                                     ByVal certificate As X509Certificate, _
                                                     ByVal chain As X509Chain, _
                                                     ByVal sslPolicyErrors As SslPolicyErrors) As Boolean
        '</snippet2>
        If sslPolicyErrors = sslPolicyErrors.None Then
            Return True
        End If

        Console.WriteLine("Certificate error: {0}", sslPolicyErrors)

        ' Do not allow this client to communicate with unauthenticated servers.
        Return False
    End Function

    Private Sub CreateServiceHost()
        Dim myServiceHost As New ServiceHost(GetType(Calculator))
        '<snippet3>
        With myServiceHost.Credentials.ClientCertificate.Authentication
            .CertificateValidationMode = X509CertificateValidationMode.PeerOrChainTrust
            .RevocationMode = X509RevocationMode.Offline
        End With
        '</snippet3>
    End Sub

    Private Sub CreateClient()
        Dim myClient As New CalculatorClient()
        '<snippet4>
        With myClient.ClientCredentials.ServiceCertificate.Authentication
            .CertificateValidationMode = X509CertificateValidationMode.PeerOrChainTrust
            .RevocationMode = X509RevocationMode.Offline
        End With
        '</snippet4>
    End Sub

    <ServiceContract()> _
    Public Interface ICalculator
        <OperationContract()> _
        Function Add(ByVal a As Double, ByVal b As Double) As Double
    End Interface

    Public Class Calculator
        Implements ICalculator
        Public Function Add(ByVal a As Double, _
                            ByVal b As Double) _
                            As Double Implements ICalculator.Add
            Return a + b
        End Function
    End Class


    <System.Diagnostics.DebuggerStepThroughAttribute()> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
    Public Class CalculatorClient
        Inherits System.ServiceModel.ClientBase(Of ICalculator)
        Implements ICalculator

        Public Sub New()
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String, _
                       ByVal remoteAddress As String)
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

        Public Function Add(ByVal n1 As Double, _
                            ByVal n2 As Double) _
                            As Double Implements ICalculator.Add
            Return MyBase.Channel.Add(n1, n2)
        End Function

    End Class

End Class
