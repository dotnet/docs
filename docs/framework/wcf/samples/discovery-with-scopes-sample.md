---
title: "Discovery with Scopes Sample"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6a37a754-6b8c-4ebe-bdf2-d4f0520271d5
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Discovery with Scopes Sample
This sample shows how to use scopes to categorize discoverable endpoints as well how to use <xref:System.ServiceModel.Discovery.DiscoveryClient> to perform an asynchronous search for endpoints. On the service, this sample shows how to customize discovery for each endpoint by adding an endpoint discovery behavior and using it to add a scope to the endpoint as well as controlling the endpoint’s discoverability. On the client, the sample goes over how clients can create a <xref:System.ServiceModel.Discovery.DiscoveryClient> and fine tune search parameters to include scopes by adding scopes to the <xref:System.ServiceModel.Discovery.FindCriteria>. This sample also shows how clients can restrict responses by adding a termination criterion.  
  
## Service Features  
 This project shows two service endpoints being added to a <xref:System.ServiceModel.ServiceHost>. Each endpoint has a <xref:System.ServiceModel.Discovery.EndpointDiscoveryBehavior> associated with it. This behavior is used to add URI scopes for both endpoints. Scopes are used to distinguish each of these endpoints so that the clients can fine tune the search. For the second endpoint, the discoverability can be disabled by setting the <xref:System.ServiceModel.Discovery.EndpointDiscoveryBehavior.Enabled%2A> property to `false`. This ensures that the discovery metadata associated with this endpoint is not sent as part of any discovery messages.  
  
## Client Features  
 The `FindCalculatorServiceAddress()` method shows how to use a <xref:System.ServiceModel.Discovery.DiscoveryClient> and pass in a <xref:System.ServiceModel.Discovery.FindCriteria> with two restrictions. A scope is added to the criteria and the <xref:System.ServiceModel.Discovery.FindCriteria.MaxResults%2A> property is set to 1. The scope limits the results to only the services that publish the same scope. Setting <xref:System.ServiceModel.Discovery.FindCriteria.MaxResults%2A> to 1 limits the responses the <xref:System.ServiceModel.Discovery.DiscoveryClient> waits for to, at most, 1 endpoint. The <xref:System.ServiceModel.Discovery.DiscoveryClient.Find%2A> call is a synchronous operation that blocks the thread until a timeout is reached or one endpoint is found.  
  
#### To use this sample  
  
1.  This sample uses HTTP endpoints and to run this sample, proper URL ACLs must be added. See [Configuring HTTP and HTTPS](http://go.microsoft.com/fwlink/?LinkId=70353) for details. Executing the following command at an elevated privilege should add the appropriate ACLs. You may want to substitute your Domain and Username for the following arguments if the command does not work as is: `netsh http add urlacl url=http://+:8000/ user=%DOMAIN%\%UserName%`  
  
2.  Build the solution.  
  
3.  Run the service executable from the build directory.  
  
4.  Run the client executable. Note that the client is able to locate the service.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Discovery\DiscoveryWithScopes`  
  
## See Also
