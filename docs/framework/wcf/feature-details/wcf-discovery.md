---
title: "WCF Discovery"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WCF [WCF], discovery"
  - "Windows Communication Foundation [WCF], discovery"
  - "discovery [WCF]"
ms.assetid: 462c4913-f388-45a9-9042-28ae96a4e735
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Discovery
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] provides support to enable services to be discoverable at runtime in an interoperable way using the WS-Discovery protocol. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services can announce their availability to the network using a multicast message or to a discovery proxy server. Client applications can search the network or a discovery proxy server to find services that meet a set of criteria. The topics in this section provide an overview and describe the programming model for this feature in detail.  
  
## In This Section  
 [WCF Discovery Overview](../../../../docs/framework/wcf/feature-details/wcf-discovery-overview.md)  
 Provides an overview of WS-Discovery support provided by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
 [WCF Discovery Object Model](../../../../docs/framework/wcf/feature-details/wcf-discovery-object-model.md)  
 Describes the classes in the object model and extensibility of WS-Discovery support.  
  
 [How to: Programmatically Add Discoverability to a WCF Service and Client](../../../../docs/framework/wcf/feature-details/how-to-programmatically-add-discoverability-to-a-wcf-service-and-client.md)  
 Shows how to make a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service discoverable.  
  
 [Implementing a Discovery Proxy](../../../../docs/framework/wcf/feature-details/implementing-a-discovery-proxy.md)  
 Describes the steps required to implement a discovery proxy, a discoverable service that registers with the discovery proxy, and a client that uses the discovery proxy to find the discoverable service.  
  
 [Discovery Versioning](../../../../docs/framework/wcf/feature-details/discovery-versioning.md)  
 Provides a brief overview of a prototype implementation of some new discovery features. It also gives an overview on how to select the discovery version to use.  
  
 [Configuring Discovery in a Configuration File](../../../../docs/framework/wcf/feature-details/configuring-discovery-in-a-configuration-file.md)  
 Shows how to configure Discovery in configuration.  
  
 [Using the Discovery Client Channel](../../../../docs/framework/wcf/feature-details/using-the-discovery-client-channel.md)  
 Shows how to use a Discovery Client Channel when writing a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client application.
