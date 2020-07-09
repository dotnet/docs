'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples
    ' The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.

    ' Define class which implements callback interface of duplex contract
    '<snippet2>
    Public Class CallbackHandler
        Implements ICalculatorDuplexCallback
        Public Overridable Shadows Sub Equals(ByVal result As Double) Implements ICalculatorDuplexCallback.Equals
            Console.WriteLine("Equals({0})", result)
        End Sub

        Public Sub Equation(ByVal eqn As String) Implements ICalculatorDuplexCallback.Equation
            Console.WriteLine("Equation({0})", eqn)
        End Sub
    End Class
    '</snippet2>
    Friend Class Client
        Shared Sub Main()
            '<snippet3>
            ' Construct InstanceContext to handle messages on callback interface
            Dim instanceContext As New InstanceContext(New CallbackHandler())

            ' Create a client
            Dim client As New CalculatorDuplexClient(instanceContext)
            '</snippet3>
            Console.WriteLine("Press <ENTER> to terminate client once the output is displayed.")
            Console.WriteLine()

            ' Call the AddTo service operation.
            Dim value As Double = 100.0R
            client.AddTo(value)

            ' Call the SubtractFrom service operation.
            value = 50.00R
            client.SubtractFrom(value)

            ' Call the MultiplyBy service operation.
            value = 17.65R
            client.MultiplyBy(value)

            ' Call the DivideBy service operation.
            value = 2.00R
            client.DivideBy(value)

            ' Complete equation
            client.Clear()

            Console.ReadLine()

            'Closing the client gracefully closes the connection and cleans up resources
            client.Close()
        End Sub


    End Class
End Namespace
