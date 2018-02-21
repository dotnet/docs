---
title: "Deploying a WCF Library Project"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9f9222fe-d358-443c-9a49-12c5498e35e7
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Deploying a WCF Library Project
This topic describes how you can deploy a [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] Service Library Project.  
  
## Deploying a WCF Service Library  
 A [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service library is a dynamic-link library (DLL). As such, it cannot be executed on its own. It needs to be deployed into a hosting environment. For more information about this process, see [Hosting and Consuming WCF Services](http://go.microsoft.com/fwlink/?LinkId=99932).  
  
 A [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service library can be deployed like any other [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service. However, be aware that [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] does not support configuration for DLLs. <xref:System.Configuration> supports one configuration file per app-domain. The [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service library project alleviates this limitation by providing an App.config file for the library during development. However, the App.config file is not recognized after deployment.  
  
 You have to move your configuration code into the configuration file recognized by your hosting environment. For self-hosting, you should copy the contents of the App.config file into the App.config file of the hosting executable. If you use IIS to host your service, you should copy the contents of the App.config file into the Web.config file of the virtual directory.
