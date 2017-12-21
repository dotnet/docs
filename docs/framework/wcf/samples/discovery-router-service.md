---
title: "Discovery Router Service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3d30af47-b24f-40e5-833a-24d77125c9e6
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Discovery Router Service
This sample demonstrates how to forward discovery messages to another endpoint.  
  
## Demonstrates  
 Discovery Routing  
  
## Discussion  
 Discovery routing is useful in a scenario in which a client is looking for a service using a proxy and the proxy is unaware of such a service, but knows of another proxy. This proxy can forward the discovery packet from this client to the second proxy. The second proxy can look for the service and return the responses to the original client.  
  
 In this sample, a client sends a message to a discovery routing component. This message is sent to a specific endpoint on the discovery router. The router then forwards the message to a UDP multicast endpoint. The probe message goes out to the multicast endpoint and a service listening on a UDP multicast address responds to that discovery router. The discovery router collects the responses and sends them back to the client.  
  
#### To set up, build, and run the sample  
  
1.  Build the sample.  
  
2.  Run the DiscoveryRouter executable.  
  
3.  Run the service executable from the build directory.  
  
4.  Run the client executable. Note that the client locates the service.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Discovery\DiscoveryRouter`
