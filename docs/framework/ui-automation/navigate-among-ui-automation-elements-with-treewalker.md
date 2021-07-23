---
title: "Navigate Among UI Automation Elements with TreeWalker"
description: See a code example that shows how to navigate among UI Automation elements by using the TreeWalker class.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "classes, TreeWalker"
  - "TreeWalker class"
  - "elements, navigating among"
  - "UI Automation, navigating among elements"
ms.topic: how-to
---
# Navigate Among UI Automation Elements with TreeWalker

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic contains example code that shows how to navigate among Microsoft UI Automation elements by using the <xref:System.Windows.Automation.TreeWalker> class.

## Example 1

 The following example uses <xref:System.Windows.Automation.TreeWalker.GetParent%2A> to walk up the Microsoft UI Automation tree until it finds the root element, or desktop. The element just below that is the parent window of the specified element.

 [!code-csharp[UIAFocusTracker_snip#102](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAFocusTracker_snip/CSharp/FocusTracker.cs#102)]
 [!code-vb[UIAFocusTracker_snip#102](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAFocusTracker_snip/VisualBasic/FocusTracker.vb#102)]

## Example 2

 The following example uses <xref:System.Windows.Automation.TreeWalker.GetFirstChild%2A> and <xref:System.Windows.Automation.TreeWalker.GetNextSibling%2A> to create a <xref:System.Windows.Forms.TreeView> that shows an entire subtree of Microsoft UI Automation elements that are in the control view and that are enabled.

 [!code-csharp[UIAClient_snip#174](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAClient_snip/CSharp/ClientForm.cs#174)]
 [!code-vb[UIAClient_snip#174](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAClient_snip/VisualBasic/ClientForm.vb#174)]

## See also

- [Obtaining UI Automation Elements](obtaining-ui-automation-elements.md)
