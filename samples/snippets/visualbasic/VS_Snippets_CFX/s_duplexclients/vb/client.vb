'<snippet1>
Imports System
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    ' The service contract is defined in generatedClient.vb, generated from the service by the svcutil tool.

    ' Define class which implements callback interface of duplex contract
    Public Class CallbackHandler
        Implements ICalculatorDuplexCallback

        Public Sub Result(ByVal result As Double) Implements ICalculatorDuplexCallback.Result
            Console.WriteLine("Result({0})", result)
        End Sub

        Public Sub Equation(ByVal eqn As String) Implements ICalculatorDuplexCallback.Equation
            Console.WriteLine("Equation({0})", eqn)
        End Sub
    End Class

    Class Client
        Public Shared Sub Main()

            ' Construct InstanceContext to handle messages on callback interface
            Dim instanceContext As New InstanceContext(New CallbackHandler())

            ' Create a client
            Dim wcfClient As New CalculatorDuplexClient(instanceContext)
            Console.WriteLine("Press <ENTER> to terminate client once the output is displayed.")
            Console.WriteLine()

            Try
                ' Call the AddTo service operation.
                Dim value As Double = 100
                wcfClient.AddTo(value)

                ' Call the SubtractFrom service operation.
                value = 50
                wcfClient.SubtractFrom(value)

                ' Call the MultiplyBy service operation.
                value = 17.65
                wcfClient.MultiplyBy(value)

                ' Call the DivideBy service operation.
                value = 2
                wcfClient.DivideBy(value)

                ' Complete equation
                wcfClient.Clear()

                Console.ReadLine()

                'Closing the client gracefully closes the connection and cleans up resources
                wcfClient.Close()

            Catch timeout As TimeoutException
                Console.WriteLine(timeout.Message)
                wcfClient.Abort()
            Catch commException As CommunicationException
                Console.WriteLine(commException.Message)
                wcfClient.Abort()
            End Try
        End Sub

    End Class

End Namespace
'</snippet1>

