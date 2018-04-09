---
title: "Retrieving Setup Information from an Application Domain"
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
  - "AppDomainSetup object"
  - "retrieving setup information"
  - "application domains, retrieving setup information"
ms.assetid: 5cdb12ae-1e37-4a62-8ec7-93d6dcc6e8d9
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Retrieving Setup Information from an Application Domain
Each instance of an application domain consists of both properties and <xref:System.AppDomainSetup> information. You can retrieve setup information from an application domain using the <xref:System.AppDomain?displayProperty=nameWithType> class. This class provides several members that retrieve configuration information about an application domain.  
  
 You can also query the **AppDomainSetup** object for the application domain to obtain setup information that was passed to the domain when it was created.  
  
 The following example creates a new application domain and then prints several member values to the console.  
  
 [!code-cpp[AppDomain_Setup#2](../../../samples/snippets/cpp/VS_Snippets_CLR/AppDomain_Setup/CPP/source2.cpp#2)]
 [!code-csharp[AppDomain_Setup#2](../../../samples/snippets/csharp/VS_Snippets_CLR/AppDomain_Setup/CS/source2.cs#2)]
 [!code-vb[AppDomain_Setup#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AppDomain_Setup/VB/source2.vb#2)]  
  
 The following example sets, and then retrieves, setup information for an application domain. Note that `AppDomain.SetupInformation.ApplicationBase` gets the configuration information.  
  
 [!code-cpp[AppDomain_Setup#3](../../../samples/snippets/cpp/VS_Snippets_CLR/AppDomain_Setup/CPP/source3.cpp#3)]
 [!code-csharp[AppDomain_Setup#3](../../../samples/snippets/csharp/VS_Snippets_CLR/AppDomain_Setup/CS/source3.cs#3)]
 [!code-vb[AppDomain_Setup#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AppDomain_Setup/VB/source3.vb#3)]  
  
## See Also  
 [Programming with Application Domains](application-domains.md#programming-with-application-domains)  
 [Using Application Domains](../../../docs/framework/app-domains/use.md)
