---
title: "How to: Create an Application Domain"
description: Review how to create an application domain in .NET. You can create an application domain to load assemblies to manage personally, or create one to execute code.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "application domains, creating"
ms.assetid: ba1fa43e-49f5-47d9-bd7f-3024af16f4ba
---
# How to: Create an Application Domain

A common language runtime host creates application domains automatically when they are needed. However, you can create your own application domains and load into them those assemblies that you want to manage personally. You can also create application domains from which you execute code.  
  
 You create a new application domain using one of the overloaded **CreateDomain** methods in the <xref:System.AppDomain?displayProperty=nameWithType> class. You can give the application domain a name and reference it by that name.  
  
 The following example creates a new application domain, assigns it the name `MyDomain`, and then prints the name of the host domain and the newly created child application domain to the console.  
  
## Example  

 [!code-cpp[ADCreateDomain#2](../../../samples/snippets/cpp/VS_Snippets_CLR/ADCreateDomain/CPP/source2.cpp#2)]
 [!code-csharp[ADCreateDomain#2](../../../samples/snippets/csharp/VS_Snippets_CLR/ADCreateDomain/CS/source2.cs#2)]
 [!code-vb[ADCreateDomain#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/ADCreateDomain/VB/source2.vb#2)]  
  
## See also

- [Programming with Application Domains](application-domains.md#programming-with-application-domains)
- [Using Application Domains](use.md)
