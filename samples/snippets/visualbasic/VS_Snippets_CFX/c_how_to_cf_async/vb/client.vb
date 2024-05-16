'  Copyright (c) Microsoft Corporation.  All Rights Reserved.


Imports System.ServiceModel
Imports System.Threading

Namespace Microsoft.ServiceModel.Samples
    ' The service contract is defined in generatedClient.vb, generated from the service by the svcutil tool.

    Friend Class Client
        Shared Sub Main()
            Console.WriteLine("Press <ENTER> to terminate client once the output is displayed.")
            Console.WriteLine()

            ' Create a client
            '<snippet3>
            Dim factory As New ChannelFactory(Of ICalculatorChannel)()
            Dim channelClient As ICalculatorChannel = factory.CreateChannel()

            ' BeginAdd
            Dim value1 = 100.0R
            Dim value2 = 15.99R

            Dim arAdd As IAsyncResult = channelClient.BeginAdd(value1, value2, AddressOf AddCallback, channelClient)
            Console.WriteLine("Add({0},{1})", value1, value2)
            '</snippet3>
            ' BeginSubtract
            value1 = 145.00R
            value2 = 76.54R
            Dim arSubtract As IAsyncResult = channelClient.BeginSubtract(value1, value2, AddressOf SubtractCallback, channelClient)
            Console.WriteLine("Subtract({0},{1})", value1, value2)

            ' Multiply
            value1 = 9.00R
            value2 = 81.25R
            Dim result = channelClient.Multiply(value1, value2)
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result)

            ' Divide
            value1 = 22.00R
            value2 = 7.00R
            result = channelClient.Divide(value1, value2)
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result)

            Console.ReadLine()

            'Closing the client gracefully closes the connection and cleans up resources
            channelClient.Close()
        End Sub

        ' Asynchronous callbacks for displaying results.
        '<snippet2>
        Private Shared Sub AddCallback(ByVal ar As IAsyncResult)
            Dim result = (CType(ar.AsyncState, CalculatorClient)).EndAdd(ar)
            Console.WriteLine("Add Result: {0}", result)
        End Sub
        '</snippet2>
        Private Shared Sub SubtractCallback(ByVal ar As IAsyncResult)
            Dim result = (CType(ar.AsyncState, CalculatorClient)).EndSubtract(ar)
            Console.WriteLine("Subtract Result: {0}", result)
        End Sub
    End Class
End Namespace
