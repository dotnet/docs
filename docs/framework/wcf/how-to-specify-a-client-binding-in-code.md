---
title: "How to: Specify a Client Binding in Code"
description: Learn how to specify the binding for a WCF client imperatively in code. The client accesses a service in this example.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 6bee5da4-adf7-42e6-8f78-63a9e5c6dbad
---
# How to: Specify a Client Binding in Code

In this example, a client is created to use a calculator service and the binding for that client is specified imperatively in code. The client accesses the `CalculatorService`, which implements the `ICalculator` interface, and both the service and the client use the <xref:System.ServiceModel.BasicHttpBinding> class.  
  
 This procedure assumes that the calculator service is running. For information about building the service, see [How to: Specify a Service Binding in Configuration](how-to-specify-a-service-binding-in-configuration.md). It also uses the [ServiceModel Metadata Utility Tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md)Windows Communication Foundation (WCF) provides to automatically generate the client components. The tool generates the client code for accessing the service.  
  
 The client is built in two parts. Svcutil.exe generates the `ClientCalculator` that implements the `ICalculator` interface. This client application is then constructed by constructing an instance of `ClientCalculator` and then specifying the binding and the address for the service in code.  
  
 For the source copy of this example, see the [BasicBinding](./samples/basicbinding.md) sample.  
  
### To specify a custom binding in code  
  
1. Use Svcutil.exe from the command line to generate code from service metadata.  
  
    ```console  
    Svcutil.exe <service's Metadata Exchange (MEX) address or HTTP GET address>
    ```  
  
2. The client that is generated contains the `ICalculator` interface that defines the service contract that the client implementation must satisfy.  
  
     [!code-csharp[C_HowTo_CodeClientBinding#1](../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_codeclientbinding/cs/client.cs#1)]
     [!code-vb[C_HowTo_CodeClientBinding#1](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howto_codeclientbinding/vb/client.vb#1)]  
  
3. The generated client also contains the implementation of the `ClientCalculator`.  
  
     [!code-csharp[C_HowTo_CodeClientBinding#2](../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_codeclientbinding/cs/client.cs#2)]
     [!code-vb[C_HowTo_CodeClientBinding#2](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howto_codeclientbinding/vb/client.vb#2)]  
  
4. Create an instance of the `ClientCalculator` that uses the <xref:System.ServiceModel.BasicHttpBinding> class in a client application, and then call the service operations at the specified address.  
  
     [!code-csharp[C_HowTo_CodeClientBinding#3](../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_codeclientbinding/cs/client.cs#3)]
     [!code-vb[C_HowTo_CodeClientBinding#3](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howto_codeclientbinding/vb/client.vb#3)]  
  
5. Compile and run the client.  
  
## See also

- [Using Bindings to Configure Services and Clients](using-bindings-to-configure-services-and-clients.md)
