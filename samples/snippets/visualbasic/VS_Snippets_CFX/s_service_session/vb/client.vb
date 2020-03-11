
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    'The service contract is defined in generatedProxy.vb, generated from the service by the svcutil tool.

    'Client implementation code.
    Class Client

        Public Shared Sub Main()

            ' Create a WCF client with given client endpoint configuration
            Dim wcfClient As New CalculatorSessionClient()
            Try
                wcfClient.Clear()
                wcfClient.AddTo(100D)
                wcfClient.SubtractFrom(50D)
                wcfClient.MultiplyBy(17.65D)
                wcfClient.DivideBy(2D)
                Dim result As Double = wcfClient.Equal()
                Console.WriteLine("0 + 100 - 50 * 17.65 / 2 = {0}", result)

            Catch timeout As TimeoutException
                Console.WriteLine(timeout.Message)
                Console.Read()
                wcfClient.Abort()
            Catch commException As CommunicationException
                Console.WriteLine(commException.Message)
                Console.Read()
                wcfClient.Abort()
            End Try

            Console.WriteLine()
            Console.WriteLine("Press <ENTER> to terminate client.")
            Console.ReadLine()
        End Sub

    End Class

End Namespace
