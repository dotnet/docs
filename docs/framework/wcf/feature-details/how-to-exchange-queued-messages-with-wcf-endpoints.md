---
description: "Learn more about: How to: Exchange Queued Messages with WCF Endpoints"
title: "How to: Exchange Queued Messages with WCF Endpoints"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 938e7825-f63a-4c3d-b603-63772fabfdb3
---
# How to: Exchange Queued Messages with WCF Endpoints

Queues ensure that reliable messaging can occur between a client and a Windows Communication Foundation (WCF) service, even if the service is not available at the time of communication. The following procedures show how to ensure durable communication between a client and a service by using the standard queued binding when implementing the WCF service.  
  
 This section explains how to use <xref:System.ServiceModel.NetMsmqBinding> for queued communication between a WCF client and a WCF service.  
  
### To use queuing in a WCF service  
  
1. Define a service contract using an interface marked with the <xref:System.ServiceModel.ServiceContractAttribute>. Mark the operations in the interface that are part of the service contract with the <xref:System.ServiceModel.OperationContractAttribute> and specify them as one-way because no response to the method is returned. The following code provides an example service contract and its operation definition.  
  
     [!code-csharp[S_Msmq_Transacted#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_msmq_transacted/cs/service.cs#1)]
     [!code-vb[S_Msmq_Transacted#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_msmq_transacted/vb/service.vb#1)]  
  
2. When the service contract passes user-defined types, you must define data contracts for those types. The following code shows two data contracts, `PurchaseOrder` and `PurchaseOrderLineItem`. These two types define data that is sent to the service. (Note that the classes that define this data contract also define a number of methods. These methods are not considered part of the data contract. Only those members that are declared with the <xref:System.Runtime.Serialization.DataMemberAttribute> attribute are part of the data contract.)  
  
     [!code-csharp[S_Msmq_Transacted#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_msmq_transacted/cs/service.cs#2)]
     [!code-vb[S_Msmq_Transacted#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_msmq_transacted/vb/service.vb#2)]  
  
3. Implement the methods of the service contract defined in the interface in a class.  
  
     [!code-csharp[S_Msmq_Transacted#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_msmq_transacted/cs/service.cs#3)]
     [!code-vb[S_Msmq_Transacted#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_msmq_transacted/vb/service.vb#3)]  
  
     Notice the <xref:System.ServiceModel.OperationBehaviorAttribute> placed on the `SubmitPurchaseOrder` method. This specifies that this operation must be called within a transaction and that the transaction automatically completes when the method completes.  
  
4. Create a transactional queue using <xref:System.Messaging>. You can choose to create the queue using Microsoft Message Queuing (MSMQ) Microsoft Management Console (MMC) instead. If so, make sure you create a transactional queue.  
  
     [!code-csharp[S_Msmq_Transacted#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_msmq_transacted/cs/hostapp.cs#4)]
     [!code-vb[S_Msmq_Transacted#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_msmq_transacted/vb/hostapp.vb#4)]  
  
5. Define a <xref:System.ServiceModel.Description.ServiceEndpoint> in configuration that specifies the service address and uses the standard <xref:System.ServiceModel.NetMsmqBinding> binding. For more information about using WCF configuration, see [Configuring WCF services](../configuring-services.md).  

6. Create a host for the `OrderProcessing` service using <xref:System.ServiceModel.ServiceHost> that reads messages from the queue and processes them. Open the service host to make the service available. Display a message that tells the user to press any key to terminate the service. Call `ReadLine` to wait for the key to be pressed and then close the service.  
  
     [!code-csharp[S_Msmq_Transacted#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_msmq_transacted/cs/hostapp.cs#6)]
     [!code-vb[S_Msmq_Transacted#6](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_msmq_transacted/vb/hostapp.vb#6)]  
  
### To create a client for the queued service  
  
1. The following example shows how to run the hosting application and use the Svcutil.exe tool to create the WCF client.  
  
    ```console
    svcutil http://localhost:8000/ServiceModelSamples/service  
    ```  
  
2. Define a <xref:System.ServiceModel.Description.ServiceEndpoint> in configuration that specifies the address and uses the standard <xref:System.ServiceModel.NetMsmqBinding> binding, as shown in the following example.  

3. Create a transaction scope to write to the transactional queue, call the `SubmitPurchaseOrder` operation and close the WCF client, as shown in the following example.  
  
     [!code-csharp[S_Msmq_Transacted#8](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_msmq_transacted/cs/client.cs#8)]
     [!code-vb[S_Msmq_Transacted#8](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_msmq_transacted/vb/client.vb#8)]  
  
## Example  

 The following examples show the service code, hosting application, App.config file, and client code included for this example.  
  
 [!code-csharp[S_Msmq_Transacted#9](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_msmq_transacted/cs/service.cs#9)]
 [!code-vb[S_Msmq_Transacted#9](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_msmq_transacted/vb/service.vb#9)]  
  
 [!code-csharp[S_Msmq_Transacted#10](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_msmq_transacted/cs/hostapp.cs#10)]
 [!code-vb[S_Msmq_Transacted#10](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_msmq_transacted/vb/hostapp.vb#10)]  

 [!code-csharp[S_Msmq_Transacted#12](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_msmq_transacted/cs/client.cs#12)]
 [!code-vb[S_Msmq_Transacted#12](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_msmq_transacted/vb/client.vb#12)]  

## See also

- <xref:System.ServiceModel.NetMsmqBinding>
- [Transacted MSMQ Binding](../samples/transacted-msmq-binding.md)
- [Queuing in WCF](queuing-in-wcf.md)
- [How to: Exchange Messages with WCF Endpoints and Message Queuing Applications](how-to-exchange-messages-with-wcf-endpoints-and-message-queuing-applications.md)
- [Windows Communication Foundation to Message Queuing](../samples/wcf-to-message-queuing.md)
- [Installing Message Queuing (MSMQ)](../samples/installing-message-queuing-msmq.md)
- [Message Queuing to Windows Communication Foundation](../samples/message-queuing-to-wcf.md)
- [Message Security over Message Queuing](../samples/message-security-over-message-queuing.md)
