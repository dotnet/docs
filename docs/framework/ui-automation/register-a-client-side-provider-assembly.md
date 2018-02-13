---
title: "Register a Client-Side Provider Assembly"
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
helpviewer_keywords: 
  - "registering client-side provider assemblies"
  - "client-side provider assemblies, registering"
  - "UI Automation, registering provider assemblies"
  - "provider assemblies, registering"
ms.assetid: a03af4d9-2771-43cc-b07b-d468dca23190
caps.latest.revision: 8
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Register a Client-Side Provider Assembly
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 This topic shows how to register a DLL that contains client-side UI Automation providers.  
  
## Example  
 The following example shows how to register an assembly that contains a provider for a console window.  
  
 [!code-csharp[UIAClientSideProvider_snip#102](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAClientSideProvider_snip/CSharp/CSClientProgram.cs#102)]
 [!code-vb[UIAClientSideProvider_snip#102](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAClientSideProvider_snip/visualbasic/csclientprogram.vb#102)]  
  
## See Also  
 [Create a Client-Side UI Automation Provider](../../../docs/framework/ui-automation/create-a-client-side-ui-automation-provider.md)
