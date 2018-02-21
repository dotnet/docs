---
title: "Implementing the UI Automation ExpandCollapse Control Pattern"
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
  - "UI Automation, ExpandCollapse control pattern"
  - "ExpandCollapse control pattern"
  - "control patterns, ExpandCollapse"
ms.assetid: 1dbabb8c-0d68-47c1-a35e-1c01cb01af26
caps.latest.revision: 25
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Implementing the UI Automation ExpandCollapse Control Pattern
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 This topic introduces guidelines and conventions for implementing <xref:System.Windows.Automation.Provider.IExpandCollapseProvider>, including information about properties, methods, and events. Links to additional references are listed at the end of the overview.  
  
 The <xref:System.Windows.Automation.ExpandCollapsePattern> control pattern is used to support controls that visually expand to display more content and collapse to hide content. For examples of controls that implement this control pattern, see [Control Pattern Mapping for UI Automation Clients](../../../docs/framework/ui-automation/control-pattern-mapping-for-ui-automation-clients.md).  
  
<a name="Implementation_Guidelines_and_Conventions"></a>   
## Implementation Guidelines and Conventions  
 When implementing the ExpandCollapse control pattern, note the following guidelines and conventions:  
  
-   Aggregate controls—built with child objects that provide the UI with expand/collapse functionality—must support the <xref:System.Windows.Automation.ExpandCollapsePattern> control pattern whereas their child elements do not. For example, a combo box control is built with a combination of list box, button, and edit controls, but it is only the parent combo box that must support the <xref:System.Windows.Automation.ExpandCollapsePattern>.  
  
    > [!NOTE]
    >  An exception is the menu control, which is an aggregate of individual MenuItem objects. The MenuItem objects can support the <xref:System.Windows.Automation.ExpandCollapsePattern> control pattern, but the parent Menu control cannot. A similar exception applies to the Tree and Tree Item controls.  
  
-   When the <xref:System.Windows.Automation.ExpandCollapseState> of a control is set to <xref:System.Windows.Automation.ExpandCollapseState.LeafNode>, any <xref:System.Windows.Automation.ExpandCollapsePattern> functionality is currently inactive for the control and the only information that can be obtained using this control pattern is the <xref:System.Windows.Automation.ExpandCollapseState>. If any child objects are subsequently added, the <xref:System.Windows.Automation.ExpandCollapseState> changes and <xref:System.Windows.Automation.ExpandCollapsePattern> functionality is activated.  
  
-   <xref:System.Windows.Automation.ExpandCollapseState> refers to the visibility of immediate child objects only; it does not refer to the visibility of all descendant objects.  
  
-   Expand and Collapse functionality is control-specific. The following are examples of this behavior.  
  
    -   The Office Personal Menu can be a tri-state MenuItem (<xref:System.Windows.Automation.ExpandCollapseState.Expanded>, <xref:System.Windows.Automation.ExpandCollapseState.Collapsed> and <xref:System.Windows.Automation.ExpandCollapseState.PartiallyExpanded>) where the control specifies the state to adopt when an <xref:System.Windows.Automation.ExpandCollapsePattern.Expand%2A> or <xref:System.Windows.Automation.ExpandCollapsePattern.Collapse%2A> is called.  
  
    -   Calling <xref:System.Windows.Automation.ExpandCollapsePattern.Expand%2A> on a TreeItem may display all descendants or only immediate children.  
  
    -   If calling <xref:System.Windows.Automation.ExpandCollapsePattern.Expand%2A> or <xref:System.Windows.Automation.ExpandCollapsePattern.Collapse%2A> on a control maintains the state of its descendants, a visibility change event should be sent, not a state change event If the parent control does not maintain the state of its descendants when collapsed, the control may destroy all the descendants that are no longer visible and raise a destroyed event; or it may change the <xref:System.Windows.Automation.Provider.IExpandCollapseProvider.ExpandCollapseState%2A> for each descendant and raise a visibility change event.  
  
-   To guarantee navigation, it is desirable for an object to be in the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree (with appropriate visibility state) regardless of its parents <xref:System.Windows.Automation.ExpandCollapseState>. If descendants are generated on demand, they may only appear in the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree after being displayed for the first time or only while they are visible.  
  
<a name="Required_Members_for_the_IValueProvider_Interface"></a>   
## Required Members for IExpandCollapseProvider  
 The following properties and methods are required for implementing <xref:System.Windows.Automation.Provider.IExpandCollapseProvider>.  
  
|Required members|Member type|Notes|  
|----------------------|-----------------|-----------|  
|<xref:System.Windows.Automation.Provider.IExpandCollapseProvider.ExpandCollapseState%2A>|Property|None|  
|<xref:System.Windows.Automation.ExpandCollapsePattern.Expand%2A>|Method|None|  
|<xref:System.Windows.Automation.ExpandCollapsePattern.Collapse%2A>|Method|None|  
|<xref:System.Windows.Automation.AutomationPropertyChangedEventHandler>|Event|This control has no associated events; use this generic delegate.|  
  
<a name="Exceptions"></a>   
## Exceptions  
 Providers must throw the following exceptions.  
  
|Exception type|Condition|  
|--------------------|---------------|  
|<xref:System.InvalidOperationException>|Either <xref:System.Windows.Automation.ExpandCollapsePattern.Expand%2A> or <xref:System.Windows.Automation.ExpandCollapsePattern.Collapse%2A> is called when the <xref:System.Windows.Automation.ExpandCollapseState> = <xref:System.Windows.Automation.ExpandCollapseState.LeafNode>.|  
  
## See Also  
 [UI Automation Control Patterns Overview](../../../docs/framework/ui-automation/ui-automation-control-patterns-overview.md)  
 [Support Control Patterns in a UI Automation Provider](../../../docs/framework/ui-automation/support-control-patterns-in-a-ui-automation-provider.md)  
 [UI Automation Control Patterns for Clients](../../../docs/framework/ui-automation/ui-automation-control-patterns-for-clients.md)  
 [Navigate Among UI Automation Elements with TreeWalker](../../../docs/framework/ui-automation/navigate-among-ui-automation-elements-with-treewalker.md)  
 [UI Automation Tree Overview](../../../docs/framework/ui-automation/ui-automation-tree-overview.md)  
 [Use Caching in UI Automation](../../../docs/framework/ui-automation/use-caching-in-ui-automation.md)
