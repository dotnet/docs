---
description: "Learn more about: How to: Access services with a duplex contract"
title: "How to: Access services with a duplex contract"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "duplex contracts [WCF]"
ms.assetid: 746a9d64-f21c-426c-b85d-972e916ec6c5
---

# How to: Access services with a duplex contract

One feature of Windows Communication Foundation (WCF) is the ability to create a service that uses a duplex messaging pattern. This pattern allows a service to communicate with the client through a callback. This topic shows the steps to create a WCF client in a client class that implements the callback interface.

A dual binding exposes the IP address of the client to the service. The client should use security to ensure that it connects only to services it trusts.

For a tutorial on creating a basic WCF service and client, see [Getting Started Tutorial](../getting-started-tutorial.md).

## To access a duplex service

1. Create a service that contains two interfaces. The first interface is for the service, the second is for the callback. For more information about creating a duplex service, see [How to: Create a Duplex Contract](how-to-create-a-duplex-contract.md).

2. Run the service.

3. Use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../servicemodel-metadata-utility-tool-svcutil-exe.md) to generate contracts (interfaces) for the client. For information about how to do this, see  [How to: Create a Client](../how-to-create-a-wcf-client.md).

4. Implement the callback interface in the client class, as shown in the following example.

    ```csharp
    public class CallbackHandler : ICalculatorDuplexCallback
    {
        public void Result(double result)
        {
            Console.WriteLine("Result ({0})", result);
        }
        public void Equation(string equation)
        {
            Console.WriteLine("Equation({0})", equation);
        }
    }
    ```

    ```vb
    Public Class CallbackHandler
    Implements ICalculatorDuplexCallback
       Public Sub Result (ByVal result As Double)
          Console.WriteLine("Result ({0})", result)
       End Sub
        Public Sub Equation(ByVal equation As String)
            Console.WriteLine("Equation({0})", equation)
        End Sub
    End Class
    ```

5. Create an instance of the <xref:System.ServiceModel.InstanceContext> class. The constructor requires an instance of the client class.

    ```csharp
    InstanceContext site = new InstanceContext(new CallbackHandler());
    ```

    ```vb
    Dim site As InstanceContext = New InstanceContext(new CallbackHandler())
    ```

6. Create an instance of the WCF client using the constructor that requires an <xref:System.ServiceModel.InstanceContext> object. The second parameter of the constructor is the name of an endpoint found in the configuration file.

    ```csharp
    CalculatorDuplexClient wcfClient = new CalculatorDuplexClient(site, "default");
    ```

    ```vb
    Dim wcfClient As New CalculatorDuplexClient(site, "default")
    ```

7. Call the methods of the WCF client as required.

## Example

The following code example demonstrates how to create a client class that accesses a duplex contract.

[!code-csharp[S_DuplexClients#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_duplexclients/cs/client.cs#1)]
[!code-vb[S_DuplexClients#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_duplexclients/vb/client.vb#1)]

## See also

- [Getting Started Tutorial](../getting-started-tutorial.md)
- [How to: Create a Duplex Contract](how-to-create-a-duplex-contract.md)
- [ServiceModel Metadata Utility Tool (Svcutil.exe)](../servicemodel-metadata-utility-tool-svcutil-exe.md)
- [How to: Create a Client](../how-to-create-a-wcf-client.md)
- [How to: Use the ChannelFactory](how-to-use-the-channelfactory.md)
