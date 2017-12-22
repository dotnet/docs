---
title: "Custom Find Criteria"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b2723929-8829-424d-8015-a37ba2ab4f68
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Custom Find Criteria
This sample demonstrates how to create a custom scope match using logic and how to implement a custom discovery service. Clients use custom scope matching functionality to refine and further build on top of the system-provided find functionality of WCF Discovery. The scenario this sample covers is as follows:  
  
1.  A client is looking for a calculator service.  
  
2.  To refine its search, the client must use a custom scope matching rule.  
  
3.  According to this rule, a service responds back to the client if its endpoint matches any of the scopes specified by the client.  
  
## Demonstrates  
  
-   Creating a custom discovery service.  
  
-   Implementing a custom scope match by algorithm.  
  
## Discussion  
 The client is looking for "OR" type matching criteria. A service responds back if the scopes on its endpoints match any of the scopes provided by the client. In this case, the client is looking for a calculator service that has any of the scopes in the following list:  
  
1.  `net.tcp://Microsoft.Samples.Discovery/RedmondLocation`  
  
2.  `net.tcp://Microsoft.Samples.Discovery/SeattleLocation`  
  
3.  `net.tcp://Microsoft.Samples.Discovery/PortlandLocation`  
  
 To accomplish this, the client directs services to use a custom scope matching rule by passing in a custom scope match by URI. To facilitate the custom scope matching, the service must use a custom discovery service that understands the custom scope match rule and implements the associated matching logic.  
  
 In the client project, open the Program.cs file. Note that the `ScopeMatchBy` field of the `FindCriteria` object is set to a specific URI. This identifier is sent to the service. If the service does not understand this rule, it ignores the client’s find request.  
  
 Open the service project. Three files are used to implement the Custom Discovery Service:  
  
1.  **AsyncResult.cs**: This is the implementation of the `AsyncResult` that is required by Discovery methods.  
  
2.  **CustomDiscoveryService.cs**: This file implements the custom discovery service. The implementation extends the <xref:System.ServiceModel.Discovery.DiscoveryService> class and overrides the necessary methods. Note the implementation of the <xref:System.ServiceModel.Discovery.DiscoveryService.OnBeginFind%2A> method. The method checks to see whether the custom scope match by rule was specified by the client. This is the same custom URI that the client specified previously. If the custom rule is specified, the code path that implements the "OR" match logic is followed.  
  
     This custom logic goes through all of the scopes on each of the endpoints that the service has. If any of the endpoint's scopes match any of the scopes provided by the client, the discovery service adds that endpoint to the response that is sent back to the client.  
  
3.  **CustomDiscoveryExtension.cs**: The last step in implementing the discovery service is to connect this implementation of the custom discover service to the service host. The helper class used here is the `CustomDiscoveryExtension` class. This class extends the <xref:System.ServiceModel.Discovery.DiscoveryServiceExtension> class. The user must override the <xref:System.ServiceModel.Discovery.DiscoveryServiceExtension.GetDiscoveryService%2A> method. In this case, the method returns an instance of the custom discovery service that was created before. `PublishedEndpoints` is a <xref:System.Collections.ObjectModel.ReadOnlyCollection%601> that contains all of the application endpoints that are added to the <xref:System.ServiceModel.ServiceHost>. The custom discovery service uses this to populate its internal list. A user can to add other endpoint metadata as well.  
  
 Lastly, open Program.cs. Note that both the <xref:System.ServiceModel.Discovery.ServiceDiscoveryBehavior> and `CustomDiscoveryExtension` are added to the host. Once this is done and the host has an endpoint over which to receive discovery messages, the application can use the custom discovery service.  
  
 Observe that the client is able to find the service without knowing its address.  
  
#### To set up, build, and run the sample  
  
1.  Open the solution that contains the project.  
  
2.  Build the project.  
  
3.  Run the service application.  
  
4.  Run the client application.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Discovery\CustomFindCriteria`
