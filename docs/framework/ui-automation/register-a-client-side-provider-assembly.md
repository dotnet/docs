---
title: "Register a Client-Side Provider Assembly"
description: Review an example that shows how to register a DLL that contains client-side UI Automation providers.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "registering client-side provider assemblies"
  - "client-side provider assemblies, registering"
  - "UI Automation, registering provider assemblies"
  - "provider assemblies, registering"
ms.topic: how-to
---
# Register a Client-Side Provider Assembly

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic shows how to register a DLL that contains client-side UI Automation providers.

## Example

 The following example shows how to register an assembly that contains a provider for a console window.

 [!code-csharp[UIAClientSideProvider_snip#102](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAClientSideProvider_snip/CSharp/CSClientProgram.cs#102)]
 [!code-vb[UIAClientSideProvider_snip#102](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAClientSideProvider_snip/visualbasic/csclientprogram.vb#102)]

## See also

- [Create a Client-Side UI Automation Provider](create-a-client-side-ui-automation-provider.md)
