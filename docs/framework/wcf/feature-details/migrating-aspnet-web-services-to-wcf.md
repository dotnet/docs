---
title: "Migrating ASP.NET Web Services to WCF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1adbb931-f0b1-47f3-9caf-169e4edc9907
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Migrating ASP.NET Web Services to WCF
ASP.NET provides .NET Framework class libraries and tools for building Web services, as well as facilities for hosting services within Internet Information Services (IIS). [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] provides .NET Framework class libraries, tools and hosting facilities for enabling software entities to communicate using any protocols, including those used by Web services.  Migrating ASP.NET Web Services to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] allows your applications to take advantage of new features and improvements that are unique to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] has several important advantages relative to ASP.NET Web services. While ASP.NET Web services tools are solely for building Web services, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides tools that can be used when software entities must be made to communicate with one another. This will reduce the number of technologies that developers are required to know in order to accommodate different software communication scenarios, which in turn will reduce the cost of software development resources, as well as the time to complete software development projects.  
  
 Even for Web service development projects, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports more Web service protocols than ASP.NET Web services support. These additional protocols provide for more sophisticated solutions involving, amongst other things, reliable sessions and transactions.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports more protocols for transporting messages than ASP.NET Web services. ASP.NET Web services only support sending messages by using the Hypertext Transfer Protocol (HTTP). [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports sending messages by using HTTP, as well as the Transmission Control Protocol (TCP), named pipes, and Microsoft Message Queuing (MSMQ). More important, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] can be extended to support additional transport protocols. Therefore, software developed using [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] can be adapted to work together with a wider variety of other software, thereby increasing the potential return on the investment.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides much richer facilities for deploying and managing applications than ASP.NET Web services provides. In addition to a configuration system, which ASP.NET also has, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] offers a configuration editor, activity tracing from senders to receivers and back through any number of intermediaries, a trace viewer, message logging, a vast number of performance counters, and support for Windows Management Instrumentation.  
  
 Given these potential benefits of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] relative to ASP.NET Web services, if you are using, or are considering using ASP.NET Web services you have several options:  
  
-   Continue to use ASP.NET Web services, and forego the benefits proffered by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
-   Keep using ASP.NET Web services with the intention of adopting [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] at some time in the future. The topics in this section explain how to maximize the prospects for being able to use new ASP.NET Web service applications together with future [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications. The topics in this section also explain how to build new ASP.NET Web services so as to make it easier to migrate them to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. However, if securing the services is important, or reliability or transaction assurances are required, or if custom management facilities will have to be constructed, then it is a better option to adopt [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is designed for precisely such scenarios.  
  
-   Adopt [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] for new development, while continuing to maintain your existing ASP.NET Web service applications. This choice is very likely the optimal one. It yields the benefits of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], while sparing the cost of modifying the existing applications to use it. In this scenario, new [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications can co-exist with existing ASP.NET applications. New [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications will be able to use existing ASP.NET Web services, and [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] can be used to program new operational capabilities into existing ASP.NET applications by virtue of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] ASP.NET compatibility mode.  
  
-   Adopt [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and migrate existing ASP.NET Web service applications to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. You may choose this option to enhance the existing applications with features provided by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], or to reproduce the functionality of existing ASP.NET Web services within new, more powerful [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications.  
  
> [!NOTE]
>  Care must be taken if a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service is hosted by IIS 5.x and ASP.NET is uninstalled. When a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service is hosted by IIS 5.x, the code for the service can be requested if ASP.NET is uninstalled. When ASP.NET is uninstalled on an operating system that is running IIS 5.x and [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is uninstalled, a file with the .svc extension is considered a text file and the contents, including any source code, is returned to the requester.  
  
 This section describes these options in detail, compares ASP.NET Web Services to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and provides instructions on how to migrate your ASP.NET Web Services code to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
## See Also  
 [Anticipating Adopting the Windows Communication Foundation: Easing Future Migration](../../../../docs/framework/wcf/feature-details/anticipating-adopting-wcf-migration.md)  
 [Anticipating Adopting the Windows Communication Foundation: Easing Future Integration](../../../../docs/framework/wcf/feature-details/anticipating-adopting-the-wcf-easing-future-integration.md)  
 [Adopting Windows Communication Foundation](../../../../docs/framework/wcf/feature-details/adopting-wcf.md)  
 [Comparing ASP.NET Web Services to WCF Based on Purpose and Standards Used](../../../../docs/framework/wcf/feature-details/comparing-aspnet-web-services-to-wcf-based-on-purpose-and-standards-used.md)  
 [Comparing ASP.NET Web Services to WCF Based on Development](../../../../docs/framework/wcf/feature-details/comparing-aspnet-web-services-to-wcf-based-on-development.md)
