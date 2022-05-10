Imports System.IO
Imports System.ServiceModel
Imports System.Runtime.Serialization
Imports System.ServiceModel.Description
Imports System.ServiceModel.Channels
Imports System.Security.Permissions
Imports System.ServiceModel.Security.Tokens

Public Class Test

    Shared Sub Main()
        Try
            Dim t As New Test()
            t.Run()
        Catch exc As System.Exception
            Console.WriteLine(exc.Message)
            Console.ReadLine()
        End Try

    End Sub


    Private Sub Run()
        Dim baseAddress As New Uri("http://localhost:8088/base")
        Dim contract As Type = GetType(Calculator)
        Dim iContract As Type = GetType(ICalculator)
        Dim myServiceHost As New ServiceHost(contract, baseAddress)
        Dim smb As New ServiceMetadataBehavior()
        smb.HttpGetEnabled = True
        myServiceHost.Description.Behaviors.Add(smb)
        '<snippet5>
        Dim ep As ServiceEndpoint = myServiceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), String.Empty)
        Dim myEndpointAdd As New EndpointAddress(New Uri("http://localhost:8088/calc"), EndpointIdentity.CreateDnsIdentity("contoso.com"))
        ep.Address = myEndpointAdd
        '</snippet5>
        myServiceHost.Open()
        Console.WriteLine("Listening")
        Console.ReadLine()
        myServiceHost.Close()

    End Sub


    Private Sub CreateBinding()
        '<snippet8>
        Dim binding As New CustomBinding()
        ' The following binding exposes a DNS identity.
        binding.Elements.Add(SecurityBindingElement.CreateSecureConversationBindingElement(SecurityBindingElement.CreateIssuedTokenForSslBindingElement(New IssuedSecurityTokenParameters())))

        ' The following element requires a UPN or SPN identity.
        binding.Elements.Add(New WindowsStreamSecurityBindingElement())
        binding.Elements.Add(New TcpTransportBindingElement())
        '</snippet8>
    End Sub
End Class

<ServiceContract()> _
Interface ICalculator
    <OperationContract()> _
    Function Add(ByVal a As Double, ByVal b As Double) As Double
End Interface

Public Class Calculator
    Implements ICalculator

    Public Function Add(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Add
        Return a + b

    End Function
End Class
