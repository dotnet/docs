Imports System
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    Class Client

        Public Shared Sub Main()

            Using proxy As CalculatorClient = New CalculatorClient()

                ' Call the Add service operation.
                Dim value1 As Double = 100D
                Dim value2 As Double = 15.99D
                Dim result As Double = proxy.Add(value1, value2)
                Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result)

                ' Call the Subtract service operation.
                value1 = 145D
                value2 = 76.54D
                result = proxy.Subtract(value1, value2)
                Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result)

                ' Call the Multiply service operation.
                value1 = 9D
                value2 = 81.25D
                result = proxy.Multiply(value1, value2)
                Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result)

                ' Call the Divide service operation.
                value1 = 22D
                value2 = 7D
                result = proxy.Divide(value1, value2)
                Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result)

            End Using

            Console.WriteLine()
            Console.WriteLine("Press <ENTER> to terminate client.")
            Console.ReadLine()
        End Sub

    End Class

End Namespace
