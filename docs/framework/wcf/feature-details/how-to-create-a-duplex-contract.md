---
title: "How to: Create a Duplex Contract"
description: Learn how to make a duplex contract, which allows WCF clients and servers to communicate with each other independently. Either can initiate calls to the other.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "duplex contracts [WCF]"
ms.assetid: 500a75b6-998a-47d5-8e3b-24e3aba2a434
---
# How to: Create a Duplex Contract

This topic shows the basic steps to create methods that use a duplex (two-way) contract. A duplex contract allows clients and servers to communicate with each other independently so that either can initiate calls to the other. The duplex contract is one of three message patterns available to Windows Communication Foundation (WCF) services. The other two message patterns are one-way and request-reply. A duplex contract consists of two one-way contracts between the client and the server and does not require that the method calls be correlated. Use this kind of contract when your service must query the client for more information or explicitly raise events on the client. For more information about creating a client application for a duplex contract, see [How to: Access Services with a Duplex Contract](how-to-access-services-with-a-duplex-contract.md). For a working sample, see the [Duplex](../samples/duplex.md) sample.  
  
### To create a duplex contract  
  
1. Create the interface that makes up the server side of the duplex contract.  
  
2. Apply the <xref:System.ServiceModel.ServiceContractAttribute> class to the interface.  
  
     [!code-csharp[S_WS_DualHttp#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_ws_dualhttp/cs/service.cs#3)]
     [!code-vb[S_WS_DualHttp#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_ws_dualhttp/vb/service.vb#3)]  
  
3. Declare the method signatures in the interface.  
  
4. Apply the <xref:System.ServiceModel.OperationContractAttribute> class to each method signature that must be part of the public contract.  
  
5. Create the callback interface that defines the set of operations that the service can invoke on the client.  
  
     [!code-csharp[S_WS_DualHttp#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_ws_dualhttp/cs/service.cs#4)]
     [!code-vb[S_WS_DualHttp#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_ws_dualhttp/vb/service.vb#4)]  
  
6. Declare the method signatures in the callback interface.  
  
7. Apply the <xref:System.ServiceModel.OperationContractAttribute> class to each method signature that must be part of the public contract.  
  
8. Link the two interfaces into a duplex contract by setting the <xref:System.ServiceModel.ServiceContractAttribute.CallbackContract%2A> property in the primary interface to the type of the callback interface.  
  
### To call methods on the client  
  
1. In the service's implementation of the primary contract, declare a variable for the callback interface.  
  
2. Set the variable to the object reference returned by the <xref:System.ServiceModel.OperationContext.GetCallbackChannel%2A> method of the <xref:System.ServiceModel.OperationContext> class.  
  
     [!code-csharp[S_WS_DualHttp#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_ws_dualhttp/cs/service.cs#1)]
     [!code-vb[S_WS_DualHttp#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_ws_dualhttp/vb/service.vb#1)]  
  
     [!code-csharp[S_WS_DualHttp#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_ws_dualhttp/cs/service.cs#2)]
     [!code-vb[S_WS_DualHttp#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_ws_dualhttp/vb/service.vb#2)]  
  
3. Call the methods defined by the callback interface.  
  
## Example  

 The following code example demonstrates duplex communication. The service’s contract contains service operations for moving forward and backward. The client’s contract contains a service operation for reporting its position.  
  
 [!code-csharp[S_WS_DualHttp#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_ws_dualhttp/cs/service.cs#5)]
 [!code-vb[S_WS_DualHttp#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_ws_dualhttp/vb/service.vb#5)]  
  
- Applying the <xref:System.ServiceModel.ServiceContractAttribute> and <xref:System.ServiceModel.OperationContractAttribute> attributes allows the automatic generation of service contract definitions in the Web Services Description Language (WSDL).  
  
- Use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../servicemodel-metadata-utility-tool-svcutil-exe.md) to retrieve the WSDL document and (optional) code and configuration for a client.  
  
- Endpoints exposing duplex services must be secured. When a service receives a duplex message, it looks at the ReplyTo in that incoming message to determine where to send the reply. If the channel is not secured, then an untrusted client could send a malicious message with a target machine's ReplyTo, leading to a denial of service of the target machine. With regular request-reply messages, this is not an issue, because the ReplyTo is ignored and the response is sent on the channel the original message came in on.  
  
## See also

- <xref:System.ServiceModel.ServiceContractAttribute>
- <xref:System.ServiceModel.OperationContractAttribute>
- [How to: Access Services with a Duplex Contract](how-to-access-services-with-a-duplex-contract.md)
- [Duplex](../samples/duplex.md)
- [Designing and Implementing Services](../designing-and-implementing-services.md)
- [How to: Define a Service Contract](../how-to-define-a-wcf-service-contract.md)
- [Session](../samples/session.md)
