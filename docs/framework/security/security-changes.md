---
title: "Security Changes in the .NET Framework"
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
  - "Allow Partially Trusted Callers attribute"
  - ".NET Framework 4, security changes"
  - ".NET Framework security"
  - "security-transparent code"
  - "security-critical code"
  - "code access security, changes"
ms.assetid: 5e87881c-9c13-4b52-8ad1-e34bb46e8aaa
caps.latest.revision: 52
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Security Changes in the .NET Framework
The most important change to security in the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] is in strong naming. See [Enhanced Strong Naming](../../../docs/framework/app-domains/enhanced-strong-naming.md) for a description of those changes.  
  
 The .NET Framework provides a two-tier security model for managed applications. [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps run in a Windows security container that limits access to resources. Within that container, managed applications run fully trusted. From a code access security (CAS) perspective, there is nothing a developer can do to elevate privileges. For information about the privileges granted by Windows, see [App capability declarations (Windows Store apps)](http://go.microsoft.com/fwlink/?LinkId=230436) in the Windows Dev Center. For information about creating a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app, see [Create your first Windows Store app using C# or Visual Basic](http://go.microsoft.com/fwlink/?LinkId=230461).
