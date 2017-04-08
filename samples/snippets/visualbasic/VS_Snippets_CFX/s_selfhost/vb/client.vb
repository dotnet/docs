
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    ' The service contract is defined in generatedClient.vb, generated from the service by the svcutil tool.

    ' Client implementation code.
    Class Client
        ' <Snippet6>
        Public Shared Sub Main()

            ' Create a proxy with the given client endpoint configuration.
            Dim wcfClient As New CalculatorClient()

            Try
                ' Call the Add service operation.
                Dim value1 As Double = 100D
                Dim value2 As Double = 15.99D
                Dim result As Double = wcfClient.Add(value1, value2)
                Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result)

                ' Call the Subtract service operation.
                value1 = 145D
                value2 = 76.54D
                result = wcfClient.Subtract(value1, value2)
                Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result)

                ' Call the Multiply service operation.
                value1 = 9D
                value2 = 81.25D
                result = wcfClient.Multiply(value1, value2)
                Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result)

                ' Call the Divide service operation.
                value1 = 22D
                value2 = 7D
                result = wcfClient.Divide(value1, value2)
                Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result)
                wcfClient.Close()

            Catch timeout As TimeoutException
                Console.WriteLine(timeout.Message)
                wcfClient.Abort()
            Catch commException As CommunicationException
                Console.WriteLine(commException.Message)
                wcfClient.Abort()
            End Try
            Console.WriteLine()
            Console.WriteLine("Press <ENTER> to terminate client.")
            Console.ReadLine()
        End Sub
        ' </Snippet6>
    End Class

End Namespace
