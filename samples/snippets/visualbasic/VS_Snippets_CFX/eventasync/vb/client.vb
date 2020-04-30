' Copyright (c) Microsoft Corporation. All rights reserved.
' <snippet6>
Namespace Microsoft.ServiceModel.Samples

    ' The service contract is defined in generatedClient.vb, generated from the service by the svcutil tool.

    Class Client

        Public Shared Sub Main()

            Console.WriteLine("Press <ENTER> to terminate client once the output is displayed.")
            Console.WriteLine()

            ' Create a client
            Dim client As New CalculatorClient()

            '<snippet5>
            ' AddAsync
            Dim value1 As Double = 100
            Dim value2 As Double = 15.99
            AddHandler client.AddCompleted, AddressOf AddCallback
            client.AddAsync(value1, value2)
            Console.WriteLine("Add({0},{1})", value1, value2)
            ' </snippet5>

            ' SubtractAsync
            value1 = 145
            value2 = 76.54
            AddHandler client.SubtractCompleted, AddressOf SubtractCallback
            client.SubtractAsync(value1, value2)
            Console.WriteLine("Subtract({0},{1})", value1, value2)

            ' Multiply
            value1 = 9
            value2 = 81.25
            Dim result As Double = client.Multiply(value1, value2)
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result)

            ' Divide
            value1 = 22
            value2 = 7
            result = client.Divide(value1, value2)
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result)
            Console.ReadLine()

            'Closing the client gracefully closes the connection and cleans up resources
            client.Close()

        End Sub
        '<snippet4>
        ' Asynchronous callbacks for displaying results.
        Private Shared Sub AddCallback(ByVal sender As Object, ByVal e As AddCompletedEventArgs)

            Console.WriteLine("Add Result: {0}", e.Result)

        End Sub
        ' </snippet4>
        Private Shared Sub SubtractCallback(ByVal sender As Object, ByVal e As SubtractCompletedEventArgs)

            Console.WriteLine("Subtract Result: {0}", e.Result)

        End Sub

    End Class

End Namespace
' </snippet6>
