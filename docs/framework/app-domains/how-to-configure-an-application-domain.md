---
title: "How to: Configure an Application Domain"
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
  - "application domains, configuring"
  - "ApplicationBase property"
ms.assetid: 07ea8438-7a34-49f0-a7e8-3d6ff7e4a482
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Configure an Application Domain
You can provide the common language runtime with configuration information for a new application domain using the <xref:System.AppDomainSetup> class. When creating your own application domains, the most important property is <xref:System.AppDomainSetup.ApplicationBase%2A>. The other **AppDomainSetup** properties are used mainly by runtime hosts to configure a particular application domain.  
  
 The **ApplicationBase** property defines the root directory of the application. When the runtime needs to satisfy a type request, it probes for the assembly containing the type in the directory specified by the **ApplicationBase** property.  
  
> [!NOTE]
>  A new application domain inherits only the **ApplicationBase** property of the creator.  
  
 The following example creates an instance of the **AppDomainSetup** class, uses this class to create a new application domain, writes the information to console, and then unloads the application domain.  
  
## Example  
 [!code-cpp[ADApplicationBase#2](../../../samples/snippets/cpp/VS_Snippets_CLR/ADApplicationBase/CPP/source2.cpp#2)]
 [!code-csharp[ADApplicationBase#2](../../../samples/snippets/csharp/VS_Snippets_CLR/ADApplicationBase/CS/source2.cs#2)]
 [!code-vb[ADApplicationBase#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/ADApplicationBase/VB/source2.vb#2)]  
  
## See Also  
 [Programming with Application Domains](application-domains.md#programming-with-application-domains)  
 [Using Application Domains](../../../docs/framework/app-domains/use.md)
