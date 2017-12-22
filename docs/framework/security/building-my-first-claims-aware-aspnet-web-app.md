---
title: "Building My First Claims-Aware ASP.NET Web Application"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3ee8ee7f-caba-4267-9343-e313fae2876d
caps.latest.revision: 5
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Building My First Claims-Aware ASP.NET Web Application
## Applies To  
  
-   Windows Identity Foundation (WIF)  
  
-   ASP.NET  
  
 This topic outlines the scenario of building claims-aware ASP.NET web applications using WIF. There are usually three participants in a claims-aware application scenario: the application itself, the end user, and the Security Token Service (STS). The following figure describes this scenario:  
  
 ![WIF Basic Web App](../../../docs/framework/security/media/wifbasicwebapp.gif "WIFBasicWebApp")  
  
1.  The claims-aware application uses WIF to identify unauthenticated requests and to redirect them to the STS.  
  
2.  The end user provides credentials to the STS and upon successful authentication the user is issued a token by the STS.  
  
3.  The user is redirected from the STS to the claims-aware application with the STS-issued token in the request.  
  
4.  The claims-aware application is configured to trust the STS and the tokens it issues. The claims-aware application uses WIF to validate the token and to parse it. Developers use the appropriate WIF API and types, for example, **ClaimsPrincpal** for the application’s needs, such as implementing authorization for it.  
  
 Starting from .NET 4.5, WIF is part of the .NET Framework package. Having the WIF classes directly available in the framework allows a much deeper integration of claims-based identity in .NET, making it easier to use claims. With WIF 4.5, you do not need to install any out-of-band components in order to start developing claims-aware web applications. WIF classes are now spread across various assemblies, the main ones being System.Security.Claims, System.IdentityModel and System.IdentityModel.Services.  
  
 STS is a service that issues tokens upon successful authentication. Microsoft offers two industry standard STS’s:  
  
-   [Active Directory Federation Services (AD FS) 2.0](http://go.microsoft.com/fwlink/?LinkID=247516) (http://go.microsoft.com/fwlink/?LinkID=247516)  
  
-   [Windows Azure Access Control Service (ACS)](http://go.microsoft.com/fwlink/?LinkID=247517) (http://go.microsoft.com/fwlink/?LinkID=247517).  
  
 AD FS 2.0 is part of the Windows Server R2 and can be used as an STS for on-premise scenarios. ACS is a cloud service, offered as part of the Windows Azure Platform. For testing or educational purposes, you can also use other STS’s in order to build your claims-aware applications. For example, you can use the Local Development STS that is part of the [Identity and Access Tool for Visual Studio](http://go.microsoft.com/fwlink/?LinkID=245849) (http://go.microsoft.com/fwlink/?LinkID=245849) which is freely available online.  
  
 To build your first claims-aware ASP.NET application using WIF, follow the instructions in one of the following:  
  
-   [How To: Build Claims-Aware ASP.NET MVC Web Application Using WIF](../../../docs/framework/security/how-to-build-claims-aware-aspnet-mvc-web-app-using-wif.md)  
  
-   [How To: Build Claims-Aware ASP.NET Web Forms Application Using WIF](../../../docs/framework/security/how-to-build-claims-aware-aspnet-web-forms-app-using-wif.md)  
  
-   [How To: Build Claims-Aware ASP.NET Application Using Forms-Based Authentication](../../../docs/framework/security/claims-aware-aspnet-app-forms-authentication.md)  
  
## See Also  
 [Getting Started With WIF](../../../docs/framework/security/getting-started-with-wif.md)
