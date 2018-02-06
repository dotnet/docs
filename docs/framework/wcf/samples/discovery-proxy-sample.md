---
title: "Discovery Proxy Sample"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1dfa02df-15b1-4e97-9c8e-f5f2772711b0
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Discovery Proxy Sample
This sample shows how to create an implementation of a Discovery proxy to store information about existing services and how clients can query that proxy for information. This sample consists of three projects:  
  
-   **Service**: A simple [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] calculator service that registers itself with the discovery proxy.  
  
-   **Discovery Proxy**: The implementation of a discovery proxy service.  
  
-   **Client**: A WCF client application that calls the discovery proxy to search for services.  
  
## Demonstrates  
 Discovery proxy implementation  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Discovery\DiscoveryProxy`  
  
## DiscoveryProxy  
 In the `Main` method of the Program.cs file, the sample shows how a service of type <xref:System.ServiceModel.Discovery.DiscoveryProxy> is hosted. It exposes two endpoints, one of type <xref:System.ServiceModel.Discovery.DiscoveryEndpoint> and another of type <xref:System.ServiceModel.Discovery.AnnouncementEndpoint>. Both of the endpoints use TCP as a transport. The <xref:System.ServiceModel.Discovery.DiscoveryEndpoint> is listening at the URI specified by the `probeEndpointAddress` parameter, this is where clients can send probe messages to query the proxy for its data. The <xref:System.ServiceModel.Discovery.AnnouncementEndpoint> is listening at the URI specified by the `announcementEndpointAddress` parameter. This is where the proxy listens to for announcements. When an online announcement is received, the proxy adds the service to its cache and when an offline announcement is received it removes the service from its cache.  
  
 The DiscoveryProxy.cs contains the implementation of the <xref:System.ServiceModel.Discovery.DiscoveryProxy>. The Proxy must inherit from the <xref:System.Object> class and requires an implementation of <xref:System.Runtime.Remoting.Messaging.AsyncResult>. At instantiation, the Proxy creates a new <xref:System.Collections.Generic.Dictionary%602>, which it uses to store elements it knows about.  
  
 The file is divided into two regions, Proxy Cache Methods and Discovery Proxy Implementation. The Proxy Cache Methods region contains methods used to update the <xref:System.Collections.Generic.Dictionary%602>, perform queries against the <xref:System.Collections.Generic.Dictionary%602>, and print the data for users. The Discovery Proxy Implementation region contains the overridden methods required for the Announcement and Probe functionality. They define the actions taken by a proxy after receiving an Online Announcement, an Offline Announcement, or a Probe message.  
  
## Service  
 In the Program.cs file in the Service project, the same URI is used for its announcement endpoint as the discovery proxy. This is because service uses the endpoint for sending the announcements, while the proxy uses it for receiving them. The service uses the <xref:System.ServiceModel.Discovery.EndpointDiscoveryBehavior> and adds an announcement endpoint to it.  
  
## Client  
 The Client project uses the same URI for its probe endpoint as the Proxy. This is because the probes in this scenario are also being unicast specifically to the endpoint available on the proxy. The Client connects to this well-known address and then queries it for the service. Once it has found the service it connects to it.  
  
#### To use this sample  
  
1.  Load the project solution in [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] and build the project.  
  
2.  First run the Discovery Proxy application, generated in [solution base directory]\DiscoveryProxy\bin\debug. The Discovery Proxy must run first because TCP announcement endpoints must be up for the service to send its announcements.  
  
3.  Second, run the service application generated in [solution base directory]\Service\bin\debug. At start-up, the service sends an announcement to the announcement endpoint of the discovery proxy and is registered in the proxy’s cache.  
  
4.  Next, run the client application, generated in [solution base directory]\Client\bin\debug. The client queries the proxy, gets the service address and then connects to the service.  
  
5.  Lastly, terminate the client, service and then the proxy. The proxy must be running for it to receive the service's offline announcement.  
  
## See Also
