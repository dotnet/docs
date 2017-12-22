---
title: "Multiple Endpoints at a Single ListenUri"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 911ffad4-4d47-4430-b7c2-79192ce6bcbd
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Multiple Endpoints at a Single ListenUri
This sample demonstrates a service that hosts multiple endpoints at a single `ListenUri`. This sample is based on the [Getting Started](../../../../docs/framework/wcf/samples/getting-started-sample.md) that implements a calculator service.  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
 As demonstrated in the [Multiple Endpoints](../../../../docs/framework/wcf/samples/multiple-endpoints.md) sample, a service can host multiple endpoints, each with different addresses and possibly also different bindings. This sample shows that it is possible to host multiple endpoints at the same address. This sample also demonstrates the differences between the two kinds of addresses that a service endpoint has: `EndpointAddress` and `ListenUri`.  
  
 The `EndpointAddress` is the logical address of a service. It is the address that SOAP messages are addressed to. The `ListenUri` is the physical address of the service. It has the port and address information where the service endpoint actually listens for messages on the current machine. In most cases, there is no need for these addresses to differ; when a `ListenUri` is not explicitly specified, it defaults to the URI of the `EndpointAddress` of the endpoint. In a few cases, it is useful to distinguish them, such as when configuring a router, which might accept messages addressed to a number of different services.  
  
## Service  
 The service in this sample has two contracts, `ICalculator` and `IEcho`. In addition to the customary `IMetadataExchange` endpoint, there are three application endpoints, as shown in the following code.  
  
```xml  
<endpoint address="urn:Stuff"  
        binding="wsHttpBinding"  
        contract="Microsoft.ServiceModel.Samples.ICalculator"   
        listenUri="http://localhost/servicemodelsamples/service.svc" />  
<endpoint address="urn:Stuff"  
        binding="wsHttpBinding"  
        contract="Microsoft.ServiceModel.Samples.IEcho"   
        listenUri="http://localhost/servicemodelsamples/service.svc" />  
<endpoint address="urn:OtherEcho"  
        binding="wsHttpBinding"  
        contract="Microsoft.ServiceModel.Samples.IEcho"   
        listenUri="http://localhost/servicemodelsamples/service.svc" />  
```  
  
 All three endpoints are hosted at the same `ListenUri` and use the same `binding` - endpoints at the same `ListenUri` must have the same binding, because they are sharing a single channel stack that listens for messages at that physical address on the machine. The `address` of each endpoint is a URN; though typically addresses represent physical locations, in fact the address can be any kind of URI, because the address is used for matching and filtering purposes as is demonstrated in this sample.  
  
 Because all three endpoints share the same `ListenUri`, when a message arrives there, [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] must decide which endpoint the message is destined for. Each endpoint has a message filter that is comprised of two parts: the address filter and the contract filter. The address filter matches the `To` of the SOAP message to the address of the service endpoint. For example, only messages addressed `To "Urn:OtherEcho"` are candidates for the third endpoint of this service. The contract filter matches the Actions associated with the operations of a particular contract. For example, messages with the action of `IEcho`. `Echo` matches the contract filters of both the second and third endpoints of this service, because both of those endpoints host the `IEcho` contract.  
  
 Thus the combination of address filter and contract filter makes it possible to route each message that arrives at this service's `ListenUri` to the correct endpoint. The third endpoint is differentiated from the other two because it accepts messages sent to a different address from the other endpoints. The first and second endpoints are differentiated from each other based on their contracts (the Action of the incoming message).  
  
## Client  
 Just as endpoints on the server have two different addresses, client endpoints also have two addresses. On both server and client, the logical address is called the `EndpointAddress`. But whereas the physical address is called the `ListenUri` on the server, on the client, the physical address is called the `Via`.  
  
 As on the server, by default, these two addresses are the same. To specify a `Via` on the client that is different from the endpoint's address, `ClientViaBehavior` is used:  
  
```  
Uri via = new Uri("http://localhost/ServiceModelSamples/service.svc");  
CalculatorClient calcClient = new CalculatorClient();  
calcClient.ChannelFactory.Endpoint.Behaviors.Add(  
        new ClientViaBehavior(via));  
```  
  
 As usual, the address comes from the client configuration file, which was generated by Svcutil.exe. The `Via` (which corresponds to the `ListenUri` of the service) does not appear in the service's metadata and so this information must be communicated to the client out-of-band (just like the service's metadata address).  
  
 The client in this sample sends messages to each of the server's three application endpoints, to demonstrate that it can communicate with (and differentiate) all three endpoints, even though they all have the same `Via`.  
  
#### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
3.  To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
    > [!NOTE]
    >  For cross-machine, you must replace localhost in the Client.cs file with the name of the service machine.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Services\MultipleEndpointsSingleUri`  
  
## See Also
