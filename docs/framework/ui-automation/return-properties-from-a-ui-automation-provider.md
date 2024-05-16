---
title: "Return Properties from a UI Automation Provider"
description: See how a UI Automation provider can return properties of an element to client applications in .NET.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "providers, UI Automation, returning properties"
  - "properties, returned by UI Automation providers"
  - "UI Automation, providers returning properties"
ms.topic: how-to
---
# Return Properties from a UI Automation Provider

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic contains sample code that shows how a UI Automation provider can return properties of an element to client applications.

 For any property it does not explicitly support, the provider must return `null` (`Nothing` in Visual Basic). This ensures that UI Automation attempts to obtain the property from another source, such as the host window provider.

## Example

 [!code-csharp[UIAFragmentProvider_snip#117](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAFragmentProvider_snip/CSharp/ListFragment.cs#117)]
 [!code-vb[UIAFragmentProvider_snip#117](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAFragmentProvider_snip/VisualBasic/ListFragment.vb#117)]

## See also

- [UI Automation Providers Overview](ui-automation-providers-overview.md)
- [Server-Side UI Automation Provider Implementation](server-side-ui-automation-provider-implementation.md)
