---
title: "UI Automation Threading Issues"
description: Read about issues with UI Automation threading. For example, conflicts may occur if a client application tries to interact with its own UI on the UI thread.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "UI Automation, threading issues"
  - "threading issues with UI Automation"
ms.assetid: 0ab8d42c-5b8b-481b-b788-2caecc2f0191
---
# UI Automation Threading Issues

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 Because of the way Microsoft UI Automation uses Windows messages, conflicts can occur when a client application attempts to interact with its own UI on the UI thread. These conflicts can lead to very slow performance or even cause the application to stop responding.

 If your client application is intended to interact with all elements on the desktop, including its own UI, you should make all UI Automation calls on a separate thread. This includes locating elements (for example, by using <xref:System.Windows.Automation.TreeWalker> or the <xref:System.Windows.Automation.AutomationElement.FindAll%2A> method) and using control patterns.

 It is safe to make UI Automation calls within a UI Automation event handler, because the event handler is always called on a non-UI thread. However, when subscribing to events that may originate from your client application's UI, you must make the call to <xref:System.Windows.Automation.Automation.AddAutomationEventHandler%2A>, or a related method, on a non-UI thread. Remove event handlers on the same thread.
