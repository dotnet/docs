Imports System.Collections
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description
Imports System.Security.Permissions




Public Class Test

    Shared Sub Main()
        Dim t As New Test()
        Console.WriteLine("Starting....")
        t.Run()

    End Sub


    Private Sub Run()
        '<snippet1>
        Dim myBinding As New WSHttpBinding()
        myBinding.Security.Mode = SecurityMode.Message
        myBinding.Security.Message.ClientCredentialType = MessageCredentialType.Windows

        ' Create the Type instances for later use and the URI for 
        ' the base address.
        Dim contractType As Type = GetType(ICalculator)
        Dim serviceType As Type = GetType(Calculator)
        Dim baseAddress As New Uri("http://localhost:8036/serviceModelSamples/")

        ' Create the ServiceHost and add an endpoint, then start
        ' the service.
        Dim myServiceHost As New ServiceHost(serviceType, baseAddress)
        myServiceHost.AddServiceEndpoint(contractType, myBinding, "secureCalculator")
        myServiceHost.Open()
        '</snippet1>
        Console.WriteLine("Listening")
        Console.WriteLine("Press Enter to close the service")
        Console.ReadLine()
        myServiceHost.Close()
    End Sub
    Private Sub Run2()
        '<snippet2>
        Dim security As SecurityBindingElement = SecurityBindingElement.CreateMutualCertificateBindingElement()

        ' Use a secure session.
        security = SecurityBindingElement.CreateSecureConversationBindingElement(security, True)

        ' Specify whether derived keys are required.
        security.SetKeyDerivation(True)

        ' Create the custom binding.
        Dim myBinding As New CustomBinding(security, New HttpTransportBindingElement())

        ' Create the Type instances for later use and the URI for 
        ' the base address.
        Dim contractType As Type = GetType(ICalculator)
        Dim serviceType As Type = GetType(Calculator)
        Dim baseAddress As New Uri("http://localhost:8036/serviceModelSamples/")

        ' Create the ServiceHost and add an endpoint, then start
        ' the service.
        Dim myServiceHost As New ServiceHost(serviceType, baseAddress)
        myServiceHost.AddServiceEndpoint(contractType, myBinding, "secureCalculator")
        myServiceHost.Open()
        '</snippet2>
        Console.WriteLine("Listening")
        Console.WriteLine("Press Enter to close the service")
        Console.ReadLine()
        myServiceHost.Close()
    End Sub
End Class

<ServiceContract()> _
Public Interface ICalculator
    <OperationContract()> _
    Function Add(ByVal a As Double, ByVal b As Double) As Double
End Interface 'ICalculator


Public Class Calculator
    Implements ICalculator

    Public Function Add(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Add
        Return a + b

    End Function 'Add
End Class
