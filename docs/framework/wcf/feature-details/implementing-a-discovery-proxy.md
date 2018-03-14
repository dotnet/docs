---
title: "Implementing a Discovery Proxy"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: dda20e79-8df3-438e-a281-69d779d978ec
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Implementing a Discovery Proxy
This section describes the steps required to implement a discovery proxy. A discovery proxy is a standalone service that contains a repository of services. Clients can query a discovery proxy to find discoverable services that the proxy is aware of. How a proxy is populated with services is up to the implementer. For example, a discovery proxy can connect to an existing service repository and make that information discoverable, an administrator can use a management API to add discoverable services to a proxy, or a discovery proxy can use the announcement functionality to update its internal cache.  
  
 The WCF implementation provides base classes that allow you to easily build a proxy. You can utilize these APIs to build a Discovery Proxy on top of your existing repository.  
  
 The discovery proxy implemented here is like any other WCF services, in that you can also make the discovery proxy discoverable and have the clients locate its endpoints.  
  
## In This Section  
 [How to: Implement a Discovery Proxy](../../../../docs/framework/wcf/feature-details/how-to-implement-a-discovery-proxy.md)  
 Describes how to implement a discovery proxy.  
  
 [How to: Implement a Discoverable Service that Registers with the Discovery Proxy](../../../../docs/framework/wcf/feature-details/discoverable-service-that-registers-with-the-discovery-proxy.md)  
 Describes how to implement a discoverable [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service that registers with the discovery proxy.  
  
 [How to: Implement a Client Application that Uses the Discovery Proxy to Find a Service](../../../../docs/framework/wcf/feature-details/client-app-discovery-proxy-to-find-a-service.md)  
 Describes how to implement a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client application that uses the discovery proxy to search for a service.  
  
 [How to: Test the Discovery Proxy](../../../../docs/framework/wcf/feature-details/how-to-test-the-discovery-proxy.md)  
 Describes how to test the code written in the previous three topics.  
  
## See Also  
 [WCF Discovery](../../../../docs/framework/wcf/feature-details/wcf-discovery.md)  
 [How to: Programmatically Add Discoverability to a WCF Service and Client](../../../../docs/framework/wcf/feature-details/how-to-programmatically-add-discoverability-to-a-wcf-service-and-client.md)
