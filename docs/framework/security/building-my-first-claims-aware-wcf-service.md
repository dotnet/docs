---
title: "Building My First Claims-Aware WCF Service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e0e6d091-9a97-4888-8f2c-cbcee42d90ee
caps.latest.revision: 7
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Building My First Claims-Aware WCF Service
## Applies To  
  
-   Windows Identity Foundation (WIF)  
  
-   Windows Communication Foundation (WCF)  
  
## Overview  
 This topic outlines the scenario of building claims-aware WCF services using WIF. There are usually three participants in a claims-aware web service scenario: the web service itself, the end user, and the Security Token Service (STS). The following figure describes this scenario:  
  
 ![WIF Basic Claims Aware WCF Service](../../../docs/framework/security/media/wifbasicclaimsawarewcfservice.gif "WIFBasicClaimsAwareWCFService")  
  
1.  The WCF service client (sometimes called agent) uses WIF to send credentials to the STS and upon successful authentication, the agent is issued a token by the STS.  
  
2.  The agent sends this STS-issued token to the WCF service.  
  
3.  The claims-aware WCF service is configured to trust the STS and the tokens it issues. The claims-aware WCF service uses WIF to validate the token and to parse it. Developers use the appropriate WIF API and types, for example, **ClaimsPrincipal** for the application’s needs, such as implementing authorization for it.  
  
 Starting from .NET 4.5, WIF is part of the .NET Framework package. Having the WIF classes directly available in the framework allows a much deeper integration of claims-based identity in .NET, making it easier to use claims. With WIF 4.5, you do not need to install any out-of-band components in order to start developing claims-aware web applications. WIF classes are now spread across various assemblies, the main ones being System.Security.Claims, System.IdentityModel and System.IdentityModel.Services.  
  
 STS is a service that issues tokens upon successful authentication. Microsoft offers two industry standard STS’s:  
  
-   [Active Directory Federation Services (AD FS) 2.0](http://go.microsoft.com/fwlink/?LinkID=247516) (http://go.microsoft.com/fwlink/?LinkID=247516)  
  
-   [Windows Azure Access Control Service (ACS)](http://go.microsoft.com/fwlink/?LinkID=247517) (http://go.microsoft.com/fwlink/?LinkID=247517).  
  
 AD FS 2.0 is part of the Windows Server R2 and can be used as an STS for on-premise scenarios. Azure Active Directory Access Control (also known as Access Control Service or ACS) is a cloud service, offered as part of Microsoft Azure. For testing or educational purposes, you can also use other STS’s in order to build your claims-aware applications. For example, you can use the Local Development STS that is part of the [Identity and Access Tool for Visual Studio](http://go.microsoft.com/fwlink/?LinkID=245849) (http://go.microsoft.com/fwlink/?LinkID=245849) which is freely available online.  
  
 To build your first claims-aware WCF service using WIF, see [How To: Enable WIF for a WCF Web Service Application](../../../docs/framework/security/how-to-enable-wif-for-a-wcf-web-service-application.md).
  
## See Also  
 [Getting Started With WIF](../../../docs/framework/security/getting-started-with-wif.md)
