---
title: "WCF and WebSockets"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1e53b49e-022c-49c7-8984-4b21b53c05b3
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF and WebSockets
The .NET Framework 4.5 introduces support for WebSockets in Windows Communication Foundation.  WebSockets is an efficient, standards-based technology that enables bidirectional communication over the standard HTTP ports 80 and 443. The use of the standard HTTP ports allow WebSockets to communicate across the web through intermediaries.  Two new standard bindings have been added to support communication over a WebSocket transport. <xref:System.ServiceModel.NetHttpBinding> and <xref:System.ServiceModel.NetHttpsBinding>. WebSockets-specific settings can be configured on the <xref:System.ServiceModel.Channels.HttpTransportBindingElement> by accessing the <xref:System.ServiceModel.Channels.HttpTransportBindingElement.WebSocketSettings%2A> property.
  
## In This Section  
 [Using the NetHttpBinding](../../../../docs/framework/wcf/feature-details/using-the-nethttpbinding.md)  
 Discusses the <xref:System.ServiceModel.NetHttpBinding> and how to configure it.  
  
 [How to: Create a WCF Service that Communicates over WebSockets](../../../../docs/framework/wcf/feature-details/how-to-create-a-wcf-service-that-communicates-over-websockets.md)  
 Describes how to create a WCF service that communicates over Websockets.  
  
## Reference  
  
## Related Sections
