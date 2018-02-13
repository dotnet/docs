---
title: "Implementing the UI Automation Invoke Control Pattern"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "UI Automation, Invoke control pattern"
  - "control patterns, Invoke"
  - "Invoke control pattern"
ms.assetid: e5b1e239-49f8-468e-bfec-1fba02ec9ac4
caps.latest.revision: 31
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Implementing the UI Automation Invoke Control Pattern
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 This topic introduces guidelines and conventions for implementing <xref:System.Windows.Automation.Provider.IInvokeProvider>, including information about events and properties. Links to additional references are listed at the end of the topic.  
  
 The <xref:System.Windows.Automation.InvokePattern> control pattern is used to support controls that do not maintain state when activated but rather initiate or perform a single, unambiguous action. Controls that do maintain state, such as check boxes and radio buttons, must instead implement <xref:System.Windows.Automation.Provider.IToggleProvider> and <xref:System.Windows.Automation.Provider.ISelectionItemProvider> respectively. For examples of controls that implement the Invoke control pattern, see [Control Pattern Mapping for UI Automation Clients](../../../docs/framework/ui-automation/control-pattern-mapping-for-ui-automation-clients.md).  
  
<a name="Implementation_Guidelines_and_Conventions"></a>   
## Implementation Guidelines and Conventions  
 When implementing the Invoke control pattern, note the following guidelines and conventions:  
  
-   Controls implement <xref:System.Windows.Automation.Provider.IInvokeProvider> if the same behavior is not exposed through another control pattern provider. For example, if the <xref:System.Windows.Automation.InvokePattern.Invoke%2A> method on a control performs the same action as the <xref:System.Windows.Automation.ExpandCollapsePattern.Expand%2A> or <xref:System.Windows.Automation.ExpandCollapsePattern.Collapse%2A> method, the control should not implement <xref:System.Windows.Automation.Provider.IInvokeProvider>.  
  
-   Invoking a control is generally performed by clicking or double-clicking or pressing ENTER, a predefined keyboard shortcut, or some alternate combination of keystrokes.  
  
-   <xref:System.Windows.Automation.InvokePatternIdentifiers.InvokedEvent> is raised on a control that has been activated (as a response to a control carrying out its associated action). If possible, the event should be raised after the control has completed the action and returned without blocking. The Invoked event should be raised before servicing the Invoke request in the following scenarios:  
  
    -   It is not possible or practical to wait until the action is complete.  
  
    -   The action requires user interaction.  
  
    -   The action is time-consuming and will cause the calling client to block for a significant amount of time.  
  
-   If invoking the control has significant side-effects, those side-effects should be exposed through the <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.HelpText%2A> property. For example, even though <xref:System.Windows.Automation.Provider.IInvokeProvider.Invoke%2A> is not associated with selection, <xref:System.Windows.Automation.Provider.IInvokeProvider.Invoke%2A> may cause another control to become selected.  
  
-   Hover (or mouse-over) effects generally do not constitute an Invoked event. However, controls that perform an action (as opposed to cause a visual effect) based on the hover state should support the <xref:System.Windows.Automation.InvokePattern> control pattern.  
  
> [!NOTE]
>  This implementation is considered an accessibility issue if the control can be invoked only as a result of a mouse-related side effect.  
  
-   Invoking a control is different from selecting an item. However, depending on the control, invoking it may cause the item to become selected as a side-effect. For example, invoking a [!INCLUDE[TLA#tla_word](../../../includes/tlasharptla-word-md.md)] document list item in the My Documents folder both selects the item and opens the document.  
  
-   An element can disappear from the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree immediately upon being invoked. Requesting information from the element provided by the event callback may fail as a result. Pre-fetching cached information is the recommended workaround.  
  
-   Controls can implement multiple control patterns. For example, the Fill Color control on the [!INCLUDE[TLA#tla_xl](../../../includes/tlasharptla-xl-md.md)] toolbar implements both the <xref:System.Windows.Automation.InvokePattern> and the <xref:System.Windows.Automation.ExpandCollapsePattern> control patterns. <xref:System.Windows.Automation.ExpandCollapsePattern> exposes the menu and the <xref:System.Windows.Automation.InvokePattern> fills the active selection with the chosen color.  
  
<a name="Required_Members_for_the_IValueProvider_Interface"></a>   
## Required Members for IInvokeProvider  
 The following properties and methods are required for implementing <xref:System.Windows.Automation.Provider.IInvokeProvider>.  
  
|Required members|Member type|Notes|  
|----------------------|-----------------|-----------|  
|<xref:System.Windows.Automation.Provider.IInvokeProvider.Invoke%2A>|method|<xref:System.Windows.Automation.Provider.IInvokeProvider.Invoke%2A> is an asynchronous call and must return immediately without blocking.<br /><br /> This behavior is particularly critical for controls that, directly or indirectly, launch a modal dialog when invoked. Any UI Automation client that instigated the event will remain blocked until the modal dialog is closed.|  
  
<a name="Exceptions"></a>   
## Exceptions  
 Providers must throw the following exceptions.  
  
|Exception Type|Condition|  
|--------------------|---------------|  
|<xref:System.Windows.Automation.ElementNotEnabledException>|If the control is not enabled.|  
  
## See Also  
 [UI Automation Control Patterns Overview](../../../docs/framework/ui-automation/ui-automation-control-patterns-overview.md)  
 [Support Control Patterns in a UI Automation Provider](../../../docs/framework/ui-automation/support-control-patterns-in-a-ui-automation-provider.md)  
 [UI Automation Control Patterns for Clients](../../../docs/framework/ui-automation/ui-automation-control-patterns-for-clients.md)  
 [Invoke a Control Using UI Automation](../../../docs/framework/ui-automation/invoke-a-control-using-ui-automation.md)  
 [UI Automation Tree Overview](../../../docs/framework/ui-automation/ui-automation-tree-overview.md)  
 [Use Caching in UI Automation](../../../docs/framework/ui-automation/use-caching-in-ui-automation.md)
