---
title: "Enable Navigation in a UI Automation Fragment Provider"
description: Read an example that shows how to enable navigation in a UI Automation provider for an element that's within a fragment.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "UI Automation, enabling navigation in provider"
  - "navigation, enabling in UI Automation provider"
ms.topic: how-to
---
# Enable Navigation in a UI Automation Fragment Provider

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic contains example code that shows how to enable navigation in a UI Automation provider for an element that is within a fragment.

## Example

 The following example code implements <xref:System.Windows.Automation.Provider.IRawElementProviderFragment.Navigate%2A> for a list item within a list. The parent element is the list box element, and the sibling elements are other items in the list collection. The method returns `null` (`Nothing` in Visual Basic) for directions that are not valid; in this case, <xref:System.Windows.Automation.Provider.NavigateDirection.FirstChild> and <xref:System.Windows.Automation.Provider.NavigateDirection.LastChild>, because the element has no children.

 [!code-csharp[UIAFragmentProvider_snip#103](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAFragmentProvider_snip/CSharp/ListItemFragment.cs#103)]
 [!code-vb[UIAFragmentProvider_snip#103](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAFragmentProvider_snip/VisualBasic/ListItemFragment.vb#103)]

## See also

- [UI Automation Providers Overview](ui-automation-providers-overview.md)
- [Server-Side UI Automation Provider Implementation](server-side-ui-automation-provider-implementation.md)
