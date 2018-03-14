
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel

Namespace ServiceModel.Sample

    ' Define a service contract.
    <ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _
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

            ' Get base address from app settings in configuration
            Dim baseAddress As Uri = New Uri("http://localhost:8000/servicemodelsamples/service")

            ' Create a ServiceHost for the CalculatorService type and provide the base address.
            ' <Snippet1>
            Dim service As CalculatorService = New CalculatorService()
            Dim serviceHost As ServiceHost = New ServiceHost(service, baseAddress)
            ' </Snippet1>


            ' Open the ServiceHost to create listeners and start listening for messages.
            serviceHost.Open()

            ' The service can now be accessed.
            Console.WriteLine("The service is ready.")
            Console.WriteLine("Press <ENTER> to terminate service.")
            Console.WriteLine()
            Console.ReadLine()

            ' Close the ServiceHost to shutdown the service.
            serviceHost.Close()

        End Sub
       End Class
End Namespace
