---
title: "Subscribe to UI Automation Events"
description: See how to subscribe to events raised by UI Automation providers. The example code registers an event handler for the event raised when a control is invoked.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "UI Automation, subscribing to events"
  - "subscribing to UI Automation events"
  - "events, subscribing to"
  - "listening for events"
ms.topic: how-to
---
# Subscribe to UI Automation Events

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic shows how to subscribe to events raised by UI Automation providers.

## Example 1

 The following example code registers an event handler for the event that is raised when a control such as a button is invoked, and removes it when the application form closes. The event is identified by an <xref:System.Windows.Automation.AutomationEvent> passed as a parameter to <xref:System.Windows.Automation.Automation.AddAutomationEventHandler%2A>.

 [!code-csharp[UIAClient_snip#101](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAClient_snip/CSharp/ClientForm.cs#101)]
 [!code-vb[UIAClient_snip#101](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAClient_snip/VisualBasic/ClientForm.vb#101)]

## Example 2

 The following example shows how to use Microsoft UI Automation to subscribe to an event that is raised when the focus changes. The event handler is unregistered in a method that could be called on application shutdown, or when notification of UI events is no longer required.

 [!code-csharp[UIAClient_snip#102](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAClient_snip/CSharp/ClientForm.cs#102)]
 [!code-vb[UIAClient_snip#102](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAClient_snip/VisualBasic/ClientForm.vb#102)]

## See also

- <xref:System.Windows.Automation.Automation.AddAutomationEventHandler%2A>
- <xref:System.Windows.Automation.Automation.RemoveAllEventHandlers%2A>
- <xref:System.Windows.Automation.Automation.RemoveAutomationEventHandler%2A>
- [UI Automation Events Overview](ui-automation-events-overview.md)
