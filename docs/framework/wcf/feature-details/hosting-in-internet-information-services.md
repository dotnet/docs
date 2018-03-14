---
title: "Hosting in Internet Information Services"
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
  - "hosting services [WCF], IIS"
ms.assetid: ddae14e8-143c-442d-b660-2046809b2d43
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Hosting in Internet Information Services
One option for hosting [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] services is inside of an Internet Information Services (IIS) application. This hosting model is similar to the model used by [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] and ASP.NET Web services (ASMX) Web Services.  
  
## Versions of IIS  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] can be hosted on the following versions of IIS on the following operating systems:  
  
-   IIS 5.1 on [!INCLUDE[wxpsp2](../../../../includes/wxpsp2-md.md)]. This environment is useful for the design and development of IIS-hosted applications that are later deployed on a server operating system such as [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)].  
  
-   [!INCLUDE[iis601](../../../../includes/iis601-md.md)] on [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)]. [!INCLUDE[iis601](../../../../includes/iis601-md.md)] provides an advanced process model that offers improved scalability, reliability, and application isolation. This environment is suitable for production deployment of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services that use HTTP communication exclusively.  
  
-   IIS 7.0 on [!INCLUDE[wv](../../../../includes/wv-md.md)] and [!INCLUDE[lserver](../../../../includes/lserver-md.md)]. IIS 7.0 provides the same advanced process model as [!INCLUDE[iis601](../../../../includes/iis601-md.md)], but uses the Windows Process Activation Service (WAS) to allow activation and network communication over protocols other than HTTP. This environment is suitable for the development of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services that communicate over any network protocol supported by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] (including HTTP, net.tcp, net.pipe, and net.msmq). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] WAS, see [Hosting in Windows Process Activation Service](../../../../docs/framework/wcf/feature-details/hosting-in-windows-process-activation-service.md).  
  
-   [Windows Server AppFabric](http://go.microsoft.com/fwlink/?LinkId=196496) works with [!INCLUDE[iisver](../../../../includes/iisver-md.md)] and Windows Process Activation Service (WAS) to provide a rich application hosting environment for NET4 WCF and WF services. These benefits include process life-cycle management, process recycling, shared hosting, rapid failure protection, process orphaning, on-demand activation, and health monitoring. For detailed information, see [AppFabric Hosting Features](http://go.microsoft.com/fwlink/?LinkId=196494) and [AppFabric Hosting Concepts](http://go.microsoft.com/fwlink/?LinkId=196495).  
  
## Benefits of IIS Hosting  
 Hosting [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services in IIS has several benefits:  
  
-   [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services hosted in IIS are deployed and managed like any other type of IIS application, including [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] applications and ASMX.  
  
-   IIS provides process activation, health management, and recycling capabilities to increase the reliability of hosted applications.  
  
-   Like [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)], [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services hosted in [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] can take advantage of the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] shared hosting model where multiple applications reside in a common worker process for improved server density and scalability.  
  
-   [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services hosted in IIS use the same dynamic compilation model as [!INCLUDE[vstecasplong](../../../../includes/vstecasplong-md.md)], which simplifies development and deployment of hosted services.  
  
 When deciding to host [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services in IIS, it is important to remember that IIS 5.1 and [!INCLUDE[iis601](../../../../includes/iis601-md.md)] are limited to HTTP communication only. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] choosing a hosting environment, see [Hosting Services](../../../../docs/framework/wcf/hosting-services.md).  
  
## Deploying an IIS-Hosted WCF Service  
 Developing and deploying an IIS-hosted [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service consists of the following tasks:  
  
-   Ensure that IIS, ASP.NET, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] HTTP activation component are correctly installed and registered.  
  
-   Create a new IIS application, or reuse an existing [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] application.  
  
-   Create a .svc file for the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service.  
  
-   Deploy the service implementation to the IIS application.  
  
-   Configure the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service.  
  
 For a discussion of each of these tasks, see [Deploying an Internet Information Services-Hosted WCF Service](../../../../docs/framework/wcf/feature-details/deploying-an-internet-information-services-hosted-wcf-service.md).  
  
## WCF Services and ASP.NET  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services can be hosted either side-by-side with [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] or in [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Compatibility Mode in which services can take full advantage of features provided by the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Web application platform. For a discussion of these features, see [WCF Services and ASP.NET](../../../../docs/framework/wcf/feature-details/wcf-services-and-aspnet.md).  
  
## See Also  
 [Extending Hosting Using ServiceHostFactory](../../../../docs/framework/wcf/extending/extending-hosting-using-servicehostfactory.md)  
 [Deploying an Internet Information Services-Hosted WCF Service](../../../../docs/framework/wcf/feature-details/deploying-an-internet-information-services-hosted-wcf-service.md)  
 [WCF Services and ASP.NET](../../../../docs/framework/wcf/feature-details/wcf-services-and-aspnet.md)  
 [Internet Information Services Hosting Best Practices](../../../../docs/framework/wcf/feature-details/internet-information-services-hosting-best-practices.md)  
 [Configuring Internet Information Services 7.0 for Windows Communication Foundation](../../../../docs/framework/wcf/feature-details/configuring-iis-for-wcf.md)  
 [Windows Server App Fabric Hosting Features](http://go.microsoft.com/fwlink/?LinkId=201276)
