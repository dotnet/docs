
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    'The service contract is defined in generatedProxy.vb, generated from the service by the svcutil tool.

    'Client implementation code.
    Class Client

        Public Shared Sub Main()

            ' Create a proxy with given client endpoint configuration
            Using proxy As CalculatorProxy = New CalculatorProxy()

                ' Call the Add service operation.
                Dim value1 As Double = 100.00D
                Dim value2 As Double = 15.99D
                Dim result As Double = proxy.Add(value1, value2)
                Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result)

                ' Call the Subtract service operation.
                value1 = 145.00D
                value2 = 76.54D
                result = proxy.Subtract(value1, value2)
                Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result)

                ' Call the Multiply service operation.
                value1 = 9.00D
                value2 = 81.25D
                result = proxy.Multiply(value1, value2)
                Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result)

                ' Call the Divide service operation.
                value1 = 22.00D
                value2 = 7.00D
                result = proxy.Divide(value1, value2)
                Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result)

            
            End Using

            Console.WriteLine()
            Console.WriteLine("Press <ENTER> to terminate client.")
            Console.ReadLine()
        End Sub

    End Class

End Namespace
