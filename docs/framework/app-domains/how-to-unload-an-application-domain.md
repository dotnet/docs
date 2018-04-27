---
title: "How to: Unload an Application Domain"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "Unload method"
  - "application domains, unloading"
  - "unloading application domains"
ms.assetid: f356116d-e415-4f7c-a332-6e6a60227192
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Unload an Application Domain
When you have finished using an application domain, unload it using the <xref:System.AppDomain.Unload%2A?displayProperty=nameWithType> method. The **Unload** method gracefully shuts down the specified application domain. During the unloading process, no new threads can access the application domain, and all application domain–specific data structures are freed.  
  
 Assemblies loaded into the application domain are removed and are no longer available. If an assembly in the application domain is domain-neutral, data for the assembly remains in memory until the entire process is shut down. There is no mechanism to unload a domain-neutral assembly other than shutting down the entire process. There are situations where the request to unload an application domain does not work and results in a <xref:System.CannotUnloadAppDomainException>.  
  
 The following example creates a new application domain called `MyDomain`, prints some information to the console, and then unloads the application domain. Note that the code then attempts to print the friendly name of the unloaded application domain to the console. This action generates an exception that is handled by the try/catch statements at the end of the program.  
  
## Example  
 [!code-cpp[System.AppDomain.Load#3](../../../samples/snippets/cpp/VS_Snippets_CLR_System/system.appdomain.load/cpp/source3.cpp#3)]
 [!code-csharp[System.AppDomain.Load#3](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.appdomain.load/cs/source3.cs#3)]
 [!code-vb[System.AppDomain.Load#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.appdomain.load/vb/source3.vb#3)]  
  
## See Also  
 [Programming with Application Domains](application-domains.md#programming-with-application-domains)  
 [How to: Create an Application Domain](../../../docs/framework/app-domains/how-to-create-an-application-domain.md)  
 [Using Application Domains](../../../docs/framework/app-domains/use.md)
