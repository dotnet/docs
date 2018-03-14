
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    'The service contract is defined in generatedProxy.vb, generated from the service by the svcutil tool.

    'Client implementation code.
    Class Client

        Public Shared Sub Main()

            ' Create a proxy with given client endpoint configuration.
            Using proxy As CalculatorSessionClient = New CalculatorSessionClient()

                proxy.Clear()
                proxy.AddTo(100D)
                proxy.SubtractFrom(50D)
                proxy.MultiplyBy(17.65D)
                proxy.DivideBy(2D)
                Dim result As Double = proxy.Equal()
                Console.WriteLine("0, + 100, - 50, * 17.65, / 2 = {0}", result)

            End Using

            Console.WriteLine()
            Console.WriteLine("Press <ENTER> to terminate client.")
            Console.ReadLine()
        End Sub

    End Class

End Namespace
