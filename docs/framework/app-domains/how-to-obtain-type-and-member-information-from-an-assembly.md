---
title: "How to: Obtain Type and Member Information from an Assembly"
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
  - "obtaining assembly information"
  - "assemblies [.NET Framework], obtaining information from"
ms.assetid: 348ae651-ccda-4f13-8eda-19e8337e9438
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Obtain Type and Member Information from an Assembly
The <xref:System.Reflection> namespace contains many methods for obtaining information from an assembly. This section demonstrates one of these methods. For additional information, see [Reflection Overview](../../../docs/framework/reflection-and-codedom/reflection.md).  
  
 The following example obtains type and member information from an assembly.  
  
## Example  
 [!code-cpp[Conceptual.Types.ViewInfo#8](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.types.viewinfo/cpp/source6.cpp#8)]
 [!code-csharp[Conceptual.Types.ViewInfo#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.types.viewinfo/cs/source6.cs#8)]
 [!code-vb[Conceptual.Types.ViewInfo#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.types.viewinfo/vb/source6.vb#8)]  
  
## See Also  
 [Programming with Application Domains](./application-domains.md#programming-with-application-domains)
 [Reflection](../../../docs/framework/reflection-and-codedom/reflection.md)  
 [Using Application Domains](../../../docs/framework/app-domains/use.md)
