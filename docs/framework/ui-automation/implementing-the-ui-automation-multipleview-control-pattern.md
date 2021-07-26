---
title: "Implementing the UI Automation MultipleView Control Pattern"
description: Review guidelines and conventions to implement the MultipleView control pattern in UI Automation. See required members for the IMultipleViewProvider interface.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "UI Automation, MultipleView control pattern"
  - "MultipleView control pattern"
  - "control patterns, MultipleView"
ms.assetid: 5bf1b248-ffee-48c8-9613-0b134bbe9f6a
---
# Implementing the UI Automation MultipleView Control Pattern

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic introduces guidelines and conventions for implementing <xref:System.Windows.Automation.Provider.IMultipleViewProvider>, including information about events and properties. Links to additional references are listed at the end of the topic.

 The <xref:System.Windows.Automation.MultipleViewPattern> control pattern is used to support controls that provide, and are able to switch between, multiple representations of the same set of information or child controls.

 Examples of controls that can present multiple views include the list view (which can show its contents as thumbnails, tiles, icons, or details), Microsoft Excel charts (pie, line, bar, cell value with a formula), Microsoft Word documents (normal, Web layout, print layout, reading layout, outline), Microsoft Outlook calendar (year, month, week, day), and Microsoft Windows Media Player skins. The supported views are determined by the control developer and are specific to each control.

<a name="Implementation_Guidelines_and_Conventions"></a>

## Implementation Guidelines and Conventions

 When implementing the Multiple View control pattern, note the following guidelines and conventions:

- <xref:System.Windows.Automation.Provider.IMultipleViewProvider> should also be implemented on a container that manages the current view if it is different from a control that provides the current view. For example, Windows Explorer contains a List control for the current folder content while the view for the control is managed from the Windows Explorer application.

- A control that is able to sort its content is not considered to support multiple views.

- The collection of views must be identical across instances.

- View names must be suitable for use in Text to Speech, Braille, and other human-readable applications.

<a name="Required_Members_for_IMultipleViewProvider"></a>

## Required Members for IMultipleViewProvider

 The following properties and methods are required for implementing IMultipleViewProvider.

|Required members|Member type|Notes|
|----------------------|-----------------|-----------|
|<xref:System.Windows.Automation.Provider.IMultipleViewProvider.CurrentView%2A>|Property|None|
|<xref:System.Windows.Automation.Provider.IMultipleViewProvider.GetSupportedViews%2A>|Method|None|
|<xref:System.Windows.Automation.Provider.IMultipleViewProvider.GetViewName%2A>|Method|None|
|<xref:System.Windows.Automation.Provider.IMultipleViewProvider.SetCurrentView%2A>|Method|None|

 There are no events associated with this control pattern.

<a name="Exceptions"></a>

## Exceptions

 Provider must throw the following exceptions.

|Exception type|Condition|
|--------------------|---------------|
|<xref:System.ArgumentException>|When either <xref:System.Windows.Automation.Provider.IMultipleViewProvider.SetCurrentView%2A> or <xref:System.Windows.Automation.Provider.IMultipleViewProvider.GetViewName%2A> is called with a parameter that is not a member of the supported views collection.|

## See also

- [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md)
- [Support Control Patterns in a UI Automation Provider](support-control-patterns-in-a-ui-automation-provider.md)
- [UI Automation Control Patterns for Clients](ui-automation-control-patterns-for-clients.md)
- [UI Automation Tree Overview](ui-automation-tree-overview.md)
- [Use Caching in UI Automation](use-caching-in-ui-automation.md)
