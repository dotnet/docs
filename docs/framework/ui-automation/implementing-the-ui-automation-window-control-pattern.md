---
title: "Implementing the UI Automation Window Control Pattern"
description: Review guidelines and conventions to implement the Window control pattern in UI Automation. Know required members for the IWindowProvider interface.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "control patterns, Window"
  - "UI Automation, Window control pattern"
  - "Window control pattern"
ms.assetid: a28cb286-296e-4a62-b4cb-55ad636ebccc
---
# Implementing the UI Automation Window Control Pattern

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic introduces guidelines and conventions for implementing <xref:System.Windows.Automation.Provider.IWindowProvider>, including information about <xref:System.Windows.Automation.WindowPattern> properties, methods, and events. Links to additional references are listed at the end of the topic.

 The <xref:System.Windows.Automation.WindowPattern> control pattern is used to support controls that provide fundamental window-based functionality within a traditional graphical user interface (GUI). Examples of controls that must implement this control pattern include top-level application windows, multiple-document interface (MDI) child windows, resizable split pane controls, modal dialogs and balloon help windows.

<a name="Implementation_Guidelines_and_Conventions"></a>

## Implementation Guidelines and Conventions

 When implementing the Window control pattern, note the following guidelines and conventions:

- To support the ability to modify both window size and screen position using UI Automation, a control must implement <xref:System.Windows.Automation.Provider.ITransformProvider> in addition to <xref:System.Windows.Automation.Provider.IWindowProvider>.

- Controls that contain title bars and title bar elements that enable the control to be moved, resized, maximized, minimized, or closed are typically required to implement <xref:System.Windows.Automation.Provider.IWindowProvider>.

- Controls such as tooltip pop-ups and combo box or menu drop-downs do not typically implement <xref:System.Windows.Automation.Provider.IWindowProvider>.

- Balloon help windows are differentiated from basic tooltip pop-ups by the provision of a window-like Close button.

- Full-screen mode is not supported by IWindowProvider as it is feature-specific to an application and is not typical window behavior.

<a name="Required_Members_for_IWindowProvider"></a>

## Required Members for IWindowProvider

 The following properties, methods, and events are required for the IWindowProvider interface.

|Required member|Member type|Notes|
|---------------------|-----------------|-----------|
|<xref:System.Windows.Automation.Provider.IWindowProvider.InteractionState%2A>|Property|None|
|<xref:System.Windows.Automation.Provider.IWindowProvider.IsModal%2A>|Property|None|
|<xref:System.Windows.Automation.Provider.IWindowProvider.IsTopmost%2A>|Property|None|
|<xref:System.Windows.Automation.Provider.IWindowProvider.Maximizable%2A>|Property|None|
|<xref:System.Windows.Automation.Provider.IWindowProvider.Minimizable%2A>|Property|None|
|<xref:System.Windows.Automation.Provider.IWindowProvider.VisualState%2A>|Property|None|
|<xref:System.Windows.Automation.Provider.IWindowProvider.Close%2A>|Method|None|
|<xref:System.Windows.Automation.Provider.IWindowProvider.SetVisualState%2A>|Method|None|
|<xref:System.Windows.Automation.Provider.IWindowProvider.WaitForInputIdle%2A>|Method|None|
|<xref:System.Windows.Automation.WindowPattern.WindowClosedEvent>|Event|None|
|<xref:System.Windows.Automation.WindowPattern.WindowOpenedEvent>|Event|None|
|<xref:System.Windows.Automation.WindowInteractionState>|Event|Is not guaranteed to be <xref:System.Windows.Automation.WindowInteractionState.ReadyForUserInteraction>|

<a name="Exceptions"></a>

## Exceptions

 Providers must throw the following exceptions.

|Exception type|Condition|
|--------------------|---------------|
|<xref:System.InvalidOperationException>|<xref:System.Windows.Automation.Provider.IWindowProvider.SetVisualState%2A><br /><br /> -   When a control does not support a requested behavior.|
|<xref:System.ArgumentOutOfRangeException>|<xref:System.Windows.Automation.Provider.IWindowProvider.WaitForInputIdle%2A><br /><br /> -   When the parameter is not a valid number.|

## See also

- [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md)
- [Support Control Patterns in a UI Automation Provider](support-control-patterns-in-a-ui-automation-provider.md)
- [UI Automation Control Patterns for Clients](ui-automation-control-patterns-for-clients.md)
- [UI Automation Tree Overview](ui-automation-tree-overview.md)
- [Use Caching in UI Automation](use-caching-in-ui-automation.md)
