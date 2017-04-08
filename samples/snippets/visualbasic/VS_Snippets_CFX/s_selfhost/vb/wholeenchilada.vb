
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

'<snippet14>
Imports System
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

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

    End Class

    Public Class Host
        ' <Snippet1>
        ' Host the service within this EXE console application.
        Public Shared Sub Main()
            '<Snippet4>
            ' Create a ServiceHost for the CalculatorService type and use the base address from config.
            '<snippet12>
            Using svcHost As New ServiceHost(GetType(CalculatorService))
                '</snippet12>
                Try
                    ' Open the ServiceHost to start listening for messages.
                    '<snippet13>
                    svcHost.Open()
                    '</snippet13>

                    ' The service can now be accessed.
                    Console.WriteLine("The service is ready.")
                    Console.WriteLine("Press <ENTER> to terminate service.")
                    Console.WriteLine()
                    Console.ReadLine()

                    'Close the ServiceHost.
                    svcHost.Close()

                Catch timeout As TimeoutException
                    Console.WriteLine(timeout.Message)
                    Console.ReadLine()
                Catch commException As CommunicationException
                    Console.WriteLine(commException.Message)
                    Console.ReadLine()
                End Try
                '<snippet22>
            End Using
            '</snippet22>

            ' </Snippet4>
        End Sub

        ' </Snippet1>
    End Class
End Namespace
'</snippet14>
