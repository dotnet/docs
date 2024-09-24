' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System.IdentityModel.Claims
Imports System.IdentityModel.Selectors
Imports System.IdentityModel.Tokens
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Namespace Microsoft.ServiceModel.Samples

    ' Define a service contract.
    <ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")>
    Public Interface ICalculator

        <OperationContract()>
        Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
    End Interface

    ' Service class which implements the service contract.
    Public Class BackendService
        Implements ICalculator

        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Multiply

            Return n1 * n2

        End Function

        Public Shared Sub Main()

            ' <snippet1>
            ' Create a ServiceHost for the CalculatorService type and provide the base address.
            Using host As New ServiceHost(GetType(BackendService), New Uri("net.tcp://localhost:8001/BackendService"))

                Dim bindingElements As New BindingElementCollection()
                bindingElements.Add(SecurityBindingElement.CreateUserNameOverTransportBindingElement())
                bindingElements.Add(New WindowsStreamSecurityBindingElement())
                bindingElements.Add(New TcpTransportBindingElement())
                Dim backendServiceBinding As New CustomBinding(bindingElements)

                host.AddServiceEndpoint(GetType(ICalculator), backendServiceBinding, "BackendService")

                ' Open the ServiceHostBase to create listeners and start listening for messages.
                host.Open()

                ' The service can now be accessed.
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()
                host.Close()
            End Using
            ' </snippet1>
        End Sub

    End Class

End Namespace
