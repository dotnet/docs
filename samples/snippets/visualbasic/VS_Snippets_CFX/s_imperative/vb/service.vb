'  Copyright (c) Microsoft Corporation.  All Rights Reserved.



Imports System.ServiceModel.Channels
Imports System.ServiceModel
Imports System.ServiceModel.Description

Namespace Microsoft.ServiceModel.Samples
    ' Define a service contract.
    <ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ICalculator
        <OperationContract> _
        Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract> _
        Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract> _
        Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract> _
        Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
    End Interface

    ' Service class that implements the service contract.
    Public Class CalculatorService
        Implements ICalculator
        Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
            Return n1 + n2
        End Function

        Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Subtract
            Return n1 - n2
        End Function

        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Multiply
            Return n1 * n2
        End Function

        Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Divide
            Return n1 / n2
        End Function

        ' Host the service within this EXE console application.
        Public Shared Sub Main()
            ' <Snippet1>
            Dim baseAddress As New Uri("http://localhost:8000/servicemodelsamples/service")

            ' Create a ServiceHost for the CalculatorService type and provide the base address.
            Using serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)
                ' <Snippet2>
                ' Create a custom binding that contains two binding elements.
                Dim reliableSession As New ReliableSessionBindingElement()
                ' </Snippet2>
                reliableSession.Ordered = True

                Dim httpTransport As New HttpTransportBindingElement()
                httpTransport.AuthenticationScheme = System.Net.AuthenticationSchemes.Anonymous
                httpTransport.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard

                Dim binding As New CustomBinding(reliableSession, httpTransport)

                ' Add an endpoint using that binding.
                serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, "")

                ' Add a MEX endpoint.
                Dim smb As New ServiceMetadataBehavior()
                smb.HttpGetEnabled = True
                smb.HttpGetUrl = New Uri("http://localhost:8001/servicemodelsamples")
                serviceHost.Description.Behaviors.Add(smb)

                ' Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open()

                ' The service can now be accessed.
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()

                ' Close the ServiceHostBase to shutdown the service.
                serviceHost.Close()
            End Using
            ' </Snippet1>
        End Sub
    End Class
End Namespace




