
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel
Imports System.Configuration

Namespace Microsoft.ServiceModel.Samples

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

    Public Class CalculatorService
        Implements ICalculator

        Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
            Console.WriteLine("Called by {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name)
            Return n1 + n2
        End Function

        Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Subtract
            Console.WriteLine("Called by {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name)
            Return n1 - n2
        End Function

        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Multiply
            Console.WriteLine("Called by {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name)
            Return n1 * n2
        End Function

        Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Divide
            Console.WriteLine("Called by {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name)
            Return n1 / n2
        End Function

        ' <Snippet1>
        Shared Sub Main()
            ' Get base address from appsettings in configuration.
            Dim baseAddress As Uri = New Uri("http://localhost:8000/ServiceModelSamples/service")

            ' Create a ServiceHost for the CalculatorService type and provide the base address.
            Using serviceHost As ServiceHost = New ServiceHost(GetType(CalculatorService), baseAddress)

                'Open the ServiceHost to create listeners and start listening for messages.
                serviceHost.Open()

                ' The service can now be accessed.
                Console.WriteLine("Service started at {0}", serviceHost.BaseAddresses(0))
                Console.WriteLine("Press ENTER to terminate service.")
                Console.WriteLine()
                Console.ReadLine()

                ' Close the ServiceHost to shutdown the service.
                serviceHost.Close()
            End Using
        End Sub
        ' </Snippet1>
    End Class

End Namespace
