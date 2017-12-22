---
title: "Deploying Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ac361bfb-017d-4da9-a2d7-fc0fb72d65bb
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Deploying Services
This topic describes how you can deploy a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] application to a run-time environment.  
  
## Choosing the Hosting Environment for Your Application  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services are designed to run in any Windows process that supports managed code. To become active, a service must be hosted within a run-time environment that creates it and controls its context and lifetime. Hosting options range from running inside the simplest console application to server environments like a Windows service, Internet Information Services (IIS), or within a worker process managed by the Windows Activation Service (WAS). To review the different hosting options for your [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application, see [Hosting Services](../../../../docs/framework/wcf/hosting-services.md).  
  
## See Also  
 [Hosting](../../../../docs/framework/wcf/feature-details/hosting.md)  
 [Hosting Services](../../../../docs/framework/wcf/hosting-services.md)
