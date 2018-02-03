---
title: "Discovery Versioning"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f91c6d0a-3af2-45c5-9a5c-e75390619836
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Discovery Versioning
This topic provides a brief overview of the implementation of some new discovery features. It also gives an overview on how to select the discovery version to use.  
  
## Discovery Versioning  
 The discovery feature includes support for three versions of the WS_Discovery protocol. The discovery APIs allow you to select which version of the protocol you want to use. This document briefly describes the versioning-related settings.  
  
 The following Discovery classes now have a <xref:System.ServiceModel.Discovery.DiscoveryVersion> property and take a <xref:System.ServiceModel.Discovery.DiscoveryVersion> argument in their constructors:  
  
-   <xref:System.ServiceModel.Discovery.AnnouncementEndpoint>  
  
-   <xref:System.ServiceModel.Discovery.DiscoveryEndpoint>  
  
-   <xref:System.ServiceModel.Discovery.UdpDiscoveryEndpoint>  
  
-   <xref:System.ServiceModel.Discovery.UdpAnnouncementEndpoint>  
  
### DiscoveryVersion.WSDiscoveryApril2005  
 Providing <xref:System.ServiceModel.Discovery.DiscoveryVersion.WSDiscoveryApril2005> as a constructor parameter makes the implementation use the April2005 version of the WS-Discovery protocol. This version corresponds to the published version of the WS-Discovery protocol specification. This version should be used to interoperate with legacy application utilizing the April2005 version of WS-Discovery.  
  
### DiscoveryVersion.WSDiscovery11  
 The default discovery version used by the APIs is <xref:System.ServiceModel.Discovery.DiscoveryVersion.WSDiscovery11>. This is the current standardized version of the WS-Discovery protocol.  
  
## DiscoveryVersion.WSDiscoveryCD1  
 Providing <xref:System.ServiceModel.Discovery.DiscoveryVersion.WSDiscoveryCD1> as a constructor parameter makes the implementation use the committee draft 1 version of the WS-Discovery protocol. This version of the protocol should be used to interoperate with implementations running the CD1 version of the WS-Discovery protocol.  
  
## Supporting Multiple UDP Discovery Endpoints for Different Discovery Versions on a Single Service Host  
 You may want to expose multiple UDP Discovery Endpoints for different discovery versions on a single service host. To do this you must specify a unique address for each UDP discovery endpoint. The following example shows how to do this.  
  
```  
UdpDiscoveryEndpoint newVersionUdpEndpoint = new UdpDiscoveryEndpoint(DiscoveryVersion.WSDiscovery11);  
UdpDiscoveryEndpoint oldVersionUdpEndpoint = new UdpDiscoveryEndpoint(DiscoveryVersion.WSDiscoveryApril2005);  
  
newVersionUdpEndpoint.Address = new EndpointAddress(newVersionUdpEndpoint.Address.Uri.ToString() + "/version11");  
oldVersionUdpEndpoint.Address = new EndpointAddress(oldVersionUdpEndpoint.Address.Uri.ToString() + "/versionAril2005");  
  
serviceHost.AddServiceEndpoint(newVersionUdpEndpoint);  
serviceHost.AddServiceEndpoint(oldVersionUdpEndpoint);  
```
