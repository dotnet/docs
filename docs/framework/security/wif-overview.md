---
title: "Windows Identity Foundation 4.5 Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5f723345-7270-49e2-b638-b3a34bd40517
caps.latest.revision: 11
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Windows Identity Foundation 4.5 Overview
Windows Identity Foundation 4.5 is a set of .NET Framework classes for implementing claims-based identity in your applications. By using it, you’ll more easily reap the benefits of claims-aware applications and services. WIF 4.5 can be used in any Web application or Web service that uses the .NET Framework version 4.5 or later. WIF is just one part of Microsoft’s Federated Identity software family that implements the shared industry vision based on open standards. Federated Identity comprises three components: [Active Directory® Federation Services](http://go.microsoft.com/fwlink/?LinkID=247516) (AD FS) 2.0, [Windows Azure Access Control Services](http://go.microsoft.com/fwlink/?LinkID=247517) (ACS), and WIF. Together, these three components form the core of Microsoft’s new claims-based cloud identity and access platform.  
  
 For more information about WIF, see the [Windows Identity Foundation Web site](http://go.microsoft.com/fwlink/?LinkId=149009) (http://go.microsoft.com/fwlink/?LinkId=149009) at the Security Developer Center on MSDN. For an introduction to creating applications using WIF, see [Programming Windows Identity Foundation](http://go.microsoft.com/fwlink/?LinkId=210158) (http://go.microsoft.com/fwlink/?LinkId=210158) by Vittorio Bertocci (published by Microsoft Press).  
  
## WIF 4.5 Features  
 WIF 4.5 is a framework for building identity-aware applications. The framework abstracts the WS-Trust and WS-Federation protocols and presents developers with APIs for building claims-aware applications and, if needed, security token services (STS)s. Applications can use WIF to process tokens issued from STSs, such as AD FS 2.0 and ACS, and make identity-based decisions at the web application or web service.  
  
 WIF 4.5 has the following major features:  
  
-   Build claims-aware applications (relying party applications). WIF helps developers build claims-aware applications. In addition to providing a claims model, it provides application developers with a rich set of APIs to help making user access decisions based on claims.  WIF also provides developers with a consistent programming experience whether they choose to build their applications in ASP.NET or in WCF environments.  
  
-   Build identity delegation support into claims-aware applications.  WIF offers the capability of maintaining the identities of original requestors across the multiple service boundaries. This capability can be achieved by either using the "ActAs" or the "OnBehalfOf" functionality in the framework and it offers developers the ability to add identity delegation support into their claims-aware applications.  
  
-   Build custom STSs.  WIF makes it substantially easier to build a custom STS that supports the WS-Trust protocol. Such an STS is also referred to as an Active STS.  
  
     In addition, the framework also provides support for building an STS that supports WS-Federation to enable Web browser clients. Such an STS is also referred to as a Passive STS.  
  
-   New identity and access tool for Visual Studio 11 that enables you to secure your application with claims based identity and accept users from multiple identity providers. You can download this WIF tool from the following URL: [http://go.microsoft.com/fwlink/?LinkID=245849](http://go.microsoft.com/fwlink/?LinkID=245849) or directly from within Visual Studio 11 by searching for "identity" directly in the Extensions Manager. For more information, see [Identity and Access Tool for Visual Studio 2012](../../../docs/framework/security/identity-and-access-tool-for-vs.md).  
  
 WIF supports the following major scenarios:  
  
-   Federation.  WIF makes it possible to enable federation between two or more partners. Its support for building claims-aware applications (RPs) and custom STSs helps developers achieve this scenario.  
  
-   Identity Delegation.  WIF makes it easy to maintain the identities across the service boundaries so that developers can achieve an identity delegation scenario.  
  
-   Step-up Authentication. Authentication requirements for different resources within an application may vary. WIF provides developers the ability to build applications that can require incremental authentication requirements (for example: initial login with Username/Password authentication and then step-up to Smart Card authentication).  
  
 By using WIF, you’ll more easily reap the benefits of the claims-based identity model. For more information, see [Windows Identity Foundation White Paper for Developers](http://download.microsoft.com/download/7/d/0/7d0b5166-6a8a-418a-addd-95ee9b046994/windowsidentityfoundationwhitepaperfordevelopers-rtw.pdf).
