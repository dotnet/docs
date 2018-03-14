---
title: "Basic Programming Lifecycle"
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
  - "service creation [WCF]"
ms.assetid: 7cf21bfe-23bd-46aa-8033-609f851dbf76
caps.latest.revision: 36
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Basic Programming Lifecycle
[!INCLUDE[indigo1](../../../includes/indigo1-md.md)] enables applications to communicate whether they are on the same computer, across the Internet, or on different application platforms. This topic outlines the tasks that are required to build a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] application. For a working sample application, see [Getting Started Tutorial](../../../docs/framework/wcf/getting-started-tutorial.md).  
  
## The Basic Tasks  
 The basic tasks to perform are, in order:  
  
1.  Define the service contract. A service contract specifies the signature of a service, the data it exchanges, and other contractually required data. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Designing Service Contracts](../../../docs/framework/wcf/designing-service-contracts.md).  
  
2.  Implement the contract. To implement a service contract, create a class that implements the contract and specify custom behaviors that the runtime should have. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Implementing Service Contracts](../../../docs/framework/wcf/implementing-service-contracts.md).  
  
3.  Configure the service by specifying endpoints and other behavior information. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Configuring Services](../../../docs/framework/wcf/configuring-services.md).  
  
4.  Host the service. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Hosting Services](../../../docs/framework/wcf/hosting-services.md).  
  
5.  Build a client application. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Building Clients](../../../docs/framework/wcf/building-clients.md).  
  
 Although the topics in this section follow this order, some scenarios do not start at the beginning. For example, if you want to build a client for a pre-existing service, you start at step 5. Or if you are building a service that others will use, you may skip step 5.  
  
 Once you are familiar with developing service contracts, you can also read [Introduction to Extensibility](../../../docs/framework/wcf/introduction-to-extensibility.md). If you have problems with your service, check [WCF Troubleshooting Quickstart](../../../docs/framework/wcf/wcf-troubleshooting-quickstart.md) to see whether others have the same or similar problems.  
  
## See Also  
 [Implementing Service Contracts](../../../docs/framework/wcf/implementing-service-contracts.md)
