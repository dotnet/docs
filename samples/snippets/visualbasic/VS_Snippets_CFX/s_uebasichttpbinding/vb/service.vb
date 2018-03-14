
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description

Namespace UE.ServiceModel.Samples

    ' <Snippet1>
    <ServiceContract(Namespace:="http://UE.ServiceModel.Samples")> _
    Public Interface ICalculator

        <OperationContract()> _
        Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()> _
        Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()> _
        Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()> _
        Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
    End Interface

    ' Service class which implements the service contract.
    ' Added code to write output to the console window
    Public Class CalculatorService
        Implements ICalculator

        Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double _
 Implements ICalculator.Add

            Dim result As Double = n1 + n2
            Console.WriteLine("Received Add({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function

        Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double _
 Implements ICalculator.Subtract

            Dim result As Double = n1 - n2
            Console.WriteLine("Received Subtract({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function

        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double _
 Implements ICalculator.Multiply

            Dim result As Double = n1 * n2
            Console.WriteLine("Received Multiply({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function

        Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double _
 Implements ICalculator.Divide

            Dim result As Double = n1 / n2
            Console.WriteLine("Received Divide({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function

        Public Shared Sub Main()
            ' <Snippet2>
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            binding.Name = "binding1"
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard
            binding.Security.Mode = BasicHttpSecurityMode.None

            Dim baseAddress As Uri = New Uri("http://localhost:8000/servicemodelsamples/service")
            Dim address As Uri = New Uri("http://localhost:8000/servicemodelsamples/service/calc")

            ' Create a ServiceHost for the CalculatorService type and provide the base address.
            Using serviceHost As ServiceHost = New ServiceHost(GetType(CalculatorService), baseAddress)

                serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, address)

                ' Open the ServiceHost to create listeners and start listening for messages.
                serviceHost.Open()

                ' The service can now be accessed.
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()

                ' Close the ServiceHost to shutdown the service.
                serviceHost.Close()
            End Using
            ' </Snippet2>
        End Sub
    End Class
    ' </Snippet1>
End Namespace
