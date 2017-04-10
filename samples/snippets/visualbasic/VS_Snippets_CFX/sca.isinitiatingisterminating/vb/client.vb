
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

  'The service contract is defined in generatedwcfClient.vb, generated from the service by the svcutil tool.

    'Client implementation code.
    Class Client

    Public Shared Sub Main()

      ' Create a wcfClient with given client endpoint configuration
      Dim wcfClient As CalculatorSessionClient = New CalculatorSessionClient()

      wcfClient.Clear()
      wcfClient.AddTo(100D)
      wcfClient.SubtractFrom(50D)
      wcfClient.MultiplyBy(17.65D)
      wcfClient.DivideBy(2D)
      Dim result As Double = wcfClient.Equal()
      Console.WriteLine("0 + 100 - 50 * 17.65 / 2 = {0}", result)
      Console.WriteLine()
      Console.WriteLine("Press <ENTER> to terminate client.")
      Console.ReadLine()
    End Sub

    End Class

End Namespace
