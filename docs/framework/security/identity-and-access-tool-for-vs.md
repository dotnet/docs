---
title: "Identity and Access Tool for Visual Studio 2012"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 87b8f8f2-4074-44fd-9fd6-08278e877390
caps.latest.revision: 3
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Identity and Access Tool for Visual Studio 2012
This topic describes the new Identity and Access Tool for Visual Studio 11. You can download this tool from the following URL: [http://go.microsoft.com/fwlink/?LinkID=245849](http://go.microsoft.com/fwlink/?LinkID=245849) or directly from within Visual Studio 11 by searching for "identity" directly in the Extensions Manager.  
  
 The Identity and Access Tool for Visual Studio 11 delivers a dramatically simplified development-time experience with the following highlights:  
  
-   Using the new tool, you can develop using web applications project types and target IIS express.  
  
-   Unlike with the blanket protection-only authentication, with the new tool, you can specify your local home realm discovery page/controller (or any other endpoint handling the authentication experience within your application) and WIF will configure all unauthenticated requests to go there, instead of redirecting them to the STS.  
  
-   The tool includes a test Security Token Service (STS) which runs on your local machine when you launch a debug session. Therefore, you no longer need to create custom STS projects and tweak them in order to get the claims you need to test your applications. The claim types and values are fully customizable.  
  
-   You can modify common settings directly via the tool’s UI, without the need to edit web.config.  
  
-   You can establish federation with Active Directory Federation Services (AD FS) 2.0 (or other WS-Federation providers) in a single screen.  
  
-   The tool leverages Windows Azure Access Control Service (ACS) capabilities with a simple list of checkboxes for all the identity providers that you want to use: Facebook, Google, Live ID, Yahoo!, any OpenID provider, and any WS-Federation provider. Select your identity providers, click OK, then F5, and both your application and ACS will be automatically configured and your test application will be ACS-aware.  
  
## See Also  
 [WIF Features](../../../docs/framework/security/wif-features.md)
