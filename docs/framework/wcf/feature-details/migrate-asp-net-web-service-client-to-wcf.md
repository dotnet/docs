---
title: "How to: Migrate ASP.NET Web Service Client Code to the Windows Communication Foundation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2e0a22a7-e1d5-4718-8997-4319a7cd9027
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Migrate ASP.NET Web Service Client Code to the Windows Communication Foundation
The following procedure describes the broad steps that need to be followed to migrate ASP.NET Web Service client code to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
## Procedure  
  
#### To migrate ASP.NET Web Service client code to WCF  
  
1.  Ensure that a comprehensive set of tests exist for the client.  
  
2.  Use Visual Studio 2005 to upgrade the client application to .NET 2.0. Run the set of tests.  
  
3.  Remove ASP.NET client code from the client project. That code is in modules generated using the WSDL.exe tool.  
  
4.  Generate [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client code using the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md). Add that code to the client project and merge the configuration output into the client’s existing configuration file.  
  
5.  Compile the application. Repair the compilation errors by replacing references to the former ASP.NET client types with references to the new [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client types.  
  
6.  Run the set of tests.  
  
## See Also  
 [How to: Migrate ASP.NET Web Service Code to the Windows Communication Foundation](../../../../docs/framework/wcf/feature-details/migrate-asp-net-web-service-to-wcf.md)
