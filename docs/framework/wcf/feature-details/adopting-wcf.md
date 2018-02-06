---
title: "Adopting Windows Communication Foundation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 49ba71e2-9468-4082-84c5-cf8daf95e34a
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Adopting Windows Communication Foundation
You can choose to use [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] for new development, while continuing to maintain existing applications developed using ASP.NET. Because [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is intended to be the most suitable choice for facilitating communication with applications built with the .NET Framework in any scenario, it can serve as a standard tool for solving a wide variety of software communications problems in a way that ASP.NET cannot.  
  
 New [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications can be deployed on the same machines as existing ASP.NET Web services. If the existing ASP.NET Web services use a version of the .NET Framework prior to version 2.0, then you can use the ASP.NET IIS Registration Tool to selectively deploy the .NET Framework 2.0 to IIS applications in which new [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications are to be hosted. That tool is documented at [ASP.NET IIS Registration Tool (Aspnet_regiis.exe)](http://go.microsoft.com/fwlink/?LinkId=94687), and has a user interface built into the IIS 6.0 management console.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] can be used to add new features to existing ASP.NET Web services by adding [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services configured to run in ASP.NET compatibility mode to existing ASP.NET Web service applications in IIS. Because of ASP.NET compatibility mode, the code for the new [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services can access and update the same application state information as the pre-existing ASP.NET code, by using the <xref:System.Web.HttpContext> class. The applications can also share the same class libraries.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] clients can use ASP.NET Web services. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services that are configured with the <xref:System.ServiceModel.BasicHttpBinding> can be used by ASP.NET Web service clients. ASP.NET Web services can co-exist with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications, and [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] can even be used to add features to existing ASP.NET Web services. Given all of these ways in which [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and ASP.NET Web services can be used together, you may want to migrate ASP.NET Web services to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] only if you require features that are provided by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and not ASP.NET Web services.  
  
 Even in the few cases where it is necessary, carefully consider that migrating code from one technology to another is seldom the correct approach. The reason for adopting the new technology is to meet new requirements that cannot be met with the earlier technology, and in that case, the correct thing to do is to design a new solution to meet the newly-expanded set of requirements. The new design benefits from your experience with the existing system and from wisdom gained since that system was designed. The new design can also use the full capabilities of the new technologies rather than reproducing the old design on the new platform. After prototyping key elements of the new design, it becomes easier to re-use code from the existing system within the new one.  
  
 For the few cases where porting from ASP.NET Web services to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is the correct solution, the following section provides some guidance on how to proceed. There is advice on how to migrate services, and how to migrate clients.  
  
 For a complete analysis on how to migrate existing ASP.NET Web Services to WCF please see [ASP.NET Web Services and the Windows Communication Foundation](http://go.microsoft.com/fwlink/?LinkID=71761). This section describes how to implement a compliant WCF service from the metadata for you ASP.NET Web Service, and how to migrate ASP.NET Web service and client code to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
## See Also  
 [How to: Retrieve Metadata and Implement a Compliant Service](../../../../docs/framework/wcf/feature-details/how-to-retrieve-metadata-and-implement-a-compliant-service.md)  
 [How to: Migrate ASP.NET Web Service Code to the Windows Communication Foundation](../../../../docs/framework/wcf/feature-details/migrate-asp-net-web-service-to-wcf.md)  
 [How to: Migrate ASP.NET Web Service Client Code to the Windows Communication Foundation](../../../../docs/framework/wcf/feature-details/migrate-asp-net-web-service-client-to-wcf.md)
