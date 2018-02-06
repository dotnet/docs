---
title: "Duplex Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 396b875a-d203-4ebe-a3a1-6a330d962e95
caps.latest.revision: 17
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Duplex Services
A duplex service contract is a message exchange pattern in which both endpoints can send messages to the other independently. A duplex service, therefore, can send messages back to the client endpoint, providing event-like behavior. Duplex communication occurs when a client connects to a service and provides the service with a channel on which the service can send messages back to the client. Note that the event-like behavior of duplex services only works within a session.  
  
 To create a duplex contract you create a pair of interfaces. The first is the service contract interface that describes the operations that a client can invoke. That service contract must specify a *callback contract* in the <xref:System.ServiceModel.ServiceContractAttribute.CallbackContract%2A?displayProperty=nameWithType> property. The callback contract is the interface that defines the operations that the service can call on the client endpoint. A duplex contract does not require a session, although the system-provided duplex bindings make use of them.  
  
 The following is an example of a duplex contract.  
  
 [!code-csharp[c_DuplexServices#0](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_duplexservices/cs/service.cs#0)]
 [!code-vb[c_DuplexServices#0](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_duplexservices/vb/service.vb#0)]  
  
 The `CalculatorService` class implements the primary `ICalculatorDuplex` interface. The service uses the <xref:System.ServiceModel.InstanceContextMode.PerSession> instance mode to maintain the result for each session. A private property named `Callback` accesses the callback channel to the client. The service uses the callback for sending messages back to the client through the callback interface, as shown in the following sample code.  
  
 [!code-csharp[c_DuplexServices#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_duplexservices/cs/service.cs#1)]
 [!code-vb[c_DuplexServices#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_duplexservices/vb/service.vb#1)]  
  
 The client must provide a class that implements the callback interface of the duplex contract, for receiving messages from the service. The following sample code shows a `CallbackHandler` class that implements the `ICalculatorDuplexCallback` interface.  
  
 [!code-csharp[c_DuplexServices#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_duplexservices/cs/client.cs#2)]
 [!code-vb[c_DuplexServices#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_duplexservices/vb/client.vb#2)]  
  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client that is generated for a duplex contract requires a <xref:System.ServiceModel.InstanceContext> class to be provided upon construction. This <xref:System.ServiceModel.InstanceContext> class is used as the site for an object that implements the callback interface and handles messages that are sent back from the service. An <xref:System.ServiceModel.InstanceContext> class is constructed with an instance of the `CallbackHandler` class. This object handles messages sent from the service to the client on the callback interface.  
  
 [!code-csharp[c_DuplexServices#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_duplexservices/cs/client.cs#3)]
 [!code-vb[c_DuplexServices#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_duplexservices/vb/client.vb#3)]  
  
 The configuration for the service must be set up to provide a binding that supports both session communication and duplex communication. The `wsDualHttpBinding` element supports session communication and allows duplex communication by providing dual HTTP connections, one for each direction.  
  
 On the client, you must configure an address that the server can use to connect to the client, as shown in the following sample configuration.  
  
  
  
> [!NOTE]
>  Non-duplex clients that fail to authenticate using a secure conversation typically throw a <xref:System.ServiceModel.Security.MessageSecurityException>. However, if a duplex client that uses a secure conversation fails to authenticate, the client receives a <xref:System.TimeoutException> instead.  
  
 If you create a client/service using the `WSHttpBinding` element and you do not include the client callback endpoint, you will receive the following error.  
  
```  
HTTP could not register URL  
htp://+:80/Temporary_Listen_Addresses/<guid> because TCP port 80 is being used by another application.  
```  
  
 The following sample code shows how to specify the client endpoint address in code.  
  
```  
WSDualHttpBinding binding = new WSDualHttpBinding();  
EndpointAddress endptadr = new EndpointAddress("http://localhost:12000/DuplexTestUsingCode/Server");  
binding.ClientBaseAddress = new Uri("http://localhost:8000/DuplexTestUsingCode/Client/");  
```  
  
 The following sample code shows how to specify the client endpoint address in configuration.  
  
```xml  
<client>  
    <endpoint name ="ServerEndpoint"   
          address="http://localhost:12000/DuplexTestUsingConfig/Server"  
          bindingConfiguration="WSDualHttpBinding_IDuplexTest"   
            binding="wsDualHttpBinding"  
           contract="IDuplexTest" />  
</client>  
<bindings>  
    <wsDualHttpBinding>  
        <binding name="WSDualHttpBinding_IDuplexTest"    
          clientBaseAddress="http://localhost:8000/myClient/" >  
            <security mode="None"/>  
         </binding>  
    </wsDualHttpBinding>  
</bindings>  
```  
  
> [!WARNING]
>  The duplex model does not automatically detect when a service or client closes its channel. So if a client unexpectedly terminates, by default the service will not be notified, or if a client unexpectedly terminates, the service will not be notified. Clients and services can implement their own protocol to notify each other if they so choose.  
  
## See Also  
 [Duplex](../../../../docs/framework/wcf/samples/duplex.md)  
 [Specifying Client Run-Time Behavior](../../../../docs/framework/wcf/specifying-client-run-time-behavior.md)  
 [How to: Create a Channel Factory and Use it to Create and Manage Channels](../../../../docs/framework/wcf/feature-details/how-to-create-a-channel-factory-and-use-it-to-create-and-manage-channels.md)
