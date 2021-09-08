---
title: "Find a UI Automation Element for a List Item"
description: See an example that shows how to find a UI Automation element for a list item when the index of the item is known.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "list items, finding elements for"
  - "elements, finding for list items"
  - "UI Automation, finding elements for List items"
ms.topic: how-to
---
# Find a UI Automation Element for a List Item

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic shows how to retrieve an <xref:System.Windows.Automation.AutomationElement> for an item within a list when the index of the item is known.

## Example

 The following example shows two ways of retrieving a specified item from a list, one using <xref:System.Windows.Automation.TreeWalker> and the other using <xref:System.Windows.Automation.AutomationElement.FindAll%2A>.

 The first technique tends to be faster for Win32 controls, but the second is faster for Windows Presentation Foundation (WPF) controls.

 [!code-csharp[UIAClient_snip#184](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAClient_snip/CSharp/ClientForm.cs#184)]
 [!code-vb[UIAClient_snip#184](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAClient_snip/VisualBasic/ClientForm.vb#184)]

## See also

- [Obtaining UI Automation Elements](obtaining-ui-automation-elements.md)
