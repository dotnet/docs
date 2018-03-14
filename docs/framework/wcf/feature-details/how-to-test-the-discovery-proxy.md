---
title: "How to: Test the Discovery Proxy"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d96e3fa2-3c42-4e5d-8244-2694081bdc32
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Test the Discovery Proxy
This is the fourth of four topics that shows how to implement a discovery proxy. In the previous topic, [How to: Implement a Client Application that Uses the Discovery Proxy to Find a Service](../../../../docs/framework/wcf/feature-details/client-app-discovery-proxy-to-find-a-service.md), you implemented a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client application that uses the discovery proxy to find a service and then calls the service. This topic describes how to verify the discovery proxy, the service, and the client application work as expected.  
  
### Run the Discovery Proxy  
  
1.  Open a command prompt as an administrator.  
  
2.  You may see a dialog that says: Windows Firewall has blocked some features of this program. If you see this message, click the **Unblock** button.  
  
3.  Within the command prompt, run the discovery proxy, DiscoveryProxy.exe.  
  
4.  The application should display the following text: `Proxy started. Hit Enter to exit`.  
  
### Run the Discoverable Service  
  
1.  Open a command prompt as an administrator.  
  
2.  Within the command prompt, run the Service.exe discoverable service.  
  
3.  The DiscoveryProxy.exe should display the following text: `******* Adding the following service: ** [Service Contract Name] ** [Service Endpoint Addr] 3.******* Done *******` .  
  
### Run the Client Application  
  
1.  Open a command prompt.  
  
2.  Within the command prompt, run the client.exe application.  
  
3.  After a few seconds the client application displays the following text: Connecting to [Service-Endpoint].  
  
4.  The service.exe should then display the following text: Greeting request received, I will respond.  
  
5.  The client.exe should then display the following text: Hello Client!  
  
### Shut Down the Applications  
  
1.  Shut down the client application.  
  
2.  Shut down the service. The discovery proxy displays the following text: `******* Removing the following service: ** [Service Contract Name] ** [Service Endpoint Addr] 2.3.******* Done *******`.  
  
3.  Shut down the discovery proxy.  
  
## See Also  
 [WCF Discovery Overview](../../../../docs/framework/wcf/feature-details/wcf-discovery-overview.md)  
 [How to: Implement a Discovery Proxy](../../../../docs/framework/wcf/feature-details/how-to-implement-a-discovery-proxy.md)  
 [How to: Implement a Discoverable Service that Registers with the Discovery Proxy](../../../../docs/framework/wcf/feature-details/discoverable-service-that-registers-with-the-discovery-proxy.md)  
 [How to: Implement a Client Application that Uses the Discovery Proxy to Find a Service](../../../../docs/framework/wcf/feature-details/client-app-discovery-proxy-to-find-a-service.md)
