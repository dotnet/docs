---
title: "One-Way Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Windows Communication Foundation [WCF], one-way service contracts"
  - "WCF [WCF], one-way service contracts"
  - "service contracts [WCF], defining one-way"
ms.assetid: 19053a36-4492-45a3-bfe6-0365ee0205a3
caps.latest.revision: 18
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# One-Way Services
The default behavior of a service operation is the request-reply pattern. In a request-reply pattern, the client waits for the reply message, even if the service operation is represented in code as a `void` method. With a one-way operation, only one message is transmitted. The receiver does not send a reply message, nor does the sender expect one.  
  
 Use the one-way design pattern:  
  
-   When the client must call operations and is not affected by the result of the operation at the operation level.  
  
-   When using the <xref:System.ServiceModel.NetMsmqBinding> or the <xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding> class. ([!INCLUDE[crabout](../../../../includes/crabout-md.md)] this scenario, see [Queues in WCF](../../../../docs/framework/wcf/feature-details/queues-in-wcf.md).)  
  
 When an operation is one-way, there is no response message to carry error information back to the client. You can detect error conditions by using features of the underlying binding, such as reliable sessions, or by designing a duplex service contract that uses two one-way operations—a one-way contract from the client to the service to call service operation and another one-way contract between the service and the client so that the service can send back faults to the client using a callback that the client implements.  
  
 To create a one-way service contract, define your service contract, apply the <xref:System.ServiceModel.OperationContractAttribute> class to each operation, and set the <xref:System.ServiceModel.OperationContractAttribute.IsOneWay%2A> property to `true`, as shown in the following sample code.  
  
```  
[ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]  
public interface IOneWayCalculator  
{  
    [OperationContract(IsOneWay=true)]  
    void Add(double n1, double n2);  
    [OperationContract(IsOneWay = true)]  
    void Subtract(double n1, double n2);  
    [OperationContract(IsOneWay = true)]  
    void Multiply(double n1, double n2);  
    [OperationContract(IsOneWay = true)]  
    void Divide(double n1, double n2);  
}  
```  
  
 For a complete example, see the [One-Way](../../../../docs/framework/wcf/samples/one-way.md) sample.  
  
## Clients Blocking with One-Way Operations  
 It is important to realize that while some one-way applications return as soon as the outbound data is written to the network connection, in several scenarios the implementation of a binding or of a service can cause a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client to block using one-way operations. In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client applications, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client object does not return until the outbound data has been written to the network connection. This is true for all message exchange patterns, including one-way operations; this means that any problem writing the data to the transport prevents the client from returning. Depending upon the problem, the result could be an exception or a delay in sending messages to the service.  
  
 For example, if the transport cannot find the endpoint, a <xref:System.ServiceModel.EndpointNotFoundException?displayProperty=nameWithType> exception is thrown without much delay. However, it is also possible that the service is unable to read the data off the wire for some reason, which prevents the client transport send operation from returning. In these cases, if the <xref:System.ServiceModel.Channels.Binding.SendTimeout%2A?displayProperty=nameWithType> period on the client transport binding is exceeded, a <xref:System.TimeoutException?displayProperty=nameWithType> is thrown—but not until the timeout period has been exceeded. It is also possible to fire so many messages at a service that the service cannot process them past a certain point. In this case, too, the one-way client blocks until the service can process the messages or until an exception is thrown.  
  
 Another variation is the situation in which the service <xref:System.ServiceModel.ServiceBehaviorAttribute.ConcurrencyMode%2A?displayProperty=nameWithType> property is set to <xref:System.ServiceModel.ConcurrencyMode.Single> and the binding uses sessions. In this case, the dispatcher enforces ordering on the incoming messages (a requirement of sessions), which prevents subsequent messages from being read off the network until the service has processed the preceding message for that session. Again, the client blocks, but whether an exception occurs depends upon whether the service is able to process the waiting data prior to the timeout settings on the client.  
  
 You can mitigate some of this problem by inserting a buffer between the client object and the client transport's send operation. For example, using asynchronous calls or using an in-memory message queue can enable the client object to return quickly. Both approaches may increase functionality, but the size of the thread pool and the message queue still enforce limits.  
  
 It is recommended, instead, that you examine the various controls on the service as well as on the client, and then test your application scenarios to determine the best configuration on either side. For example, if the use of sessions is blocking the processing of messages on your service, you can set the <xref:System.ServiceModel.ServiceBehaviorAttribute.InstanceContextMode%2A?displayProperty=nameWithType> property to <xref:System.ServiceModel.InstanceContextMode.PerCall> so that each message can be processed by a different service instance, and set the <xref:System.ServiceModel.ServiceBehaviorAttribute.ConcurrencyMode%2A> to <xref:System.ServiceModel.ConcurrencyMode.Multiple> in order to allow more than one thread to dispatch messages at a time. Another approach is to increase the read quotas of the service and client bindings.  
  
## See Also  
 [One-Way](../../../../docs/framework/wcf/samples/one-way.md)
