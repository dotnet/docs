---
title: "Get UI Automation Element Properties"
description: See instructions and an example that shows how to retrieve current or cached properties of a UI Automation element.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "properties, retrieving"
  - "UI Automation, retrieving properties of elements"
ms.topic: how-to
---
# Get UI Automation Element Properties

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic shows how to retrieve properties of a UI Automation element.

### Get a Current Property Value

1. Obtain the <xref:System.Windows.Automation.AutomationElement> whose property you wish to get.

2. Call <xref:System.Windows.Automation.AutomationElement.GetCurrentPropertyValue%2A>, or retrieve the <xref:System.Windows.Automation.AutomationElement.Current%2A> property structure and get the value from one of its members.

### Get a Cached Property Value

1. Obtain the <xref:System.Windows.Automation.AutomationElement> whose property you wish to get. The property must have been specified in the <xref:System.Windows.Automation.CacheRequest>.

2. Call <xref:System.Windows.Automation.AutomationElement.GetCachedPropertyValue%2A>, or retrieve the <xref:System.Windows.Automation.AutomationElement.Cached%2A> property structure and get the value from one of its members.

## Example

 The following example shows various ways to retrieve current properties of an <xref:System.Windows.Automation.AutomationElement>.

 [!code-csharp[UIAClient_snip#170](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAClient_snip/CSharp/ClientForm.cs#170)]
 [!code-vb[UIAClient_snip#170](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAClient_snip/VisualBasic/ClientForm.vb#170)]

## See also

- [UI Automation Properties for Clients](ui-automation-properties-for-clients.md)
- [Use Caching in UI Automation](use-caching-in-ui-automation.md)
- [Caching in UI Automation Clients](caching-in-ui-automation-clients.md)
