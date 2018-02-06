---
title: "UI Automation Support for the Menu Control Type"
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
  - "control types, Menu"
  - "UI Automation, Menu control type"
  - "Menu control type"
ms.assetid: 016323cb-f800-4938-b77b-2eb25d646090
caps.latest.revision: 24
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# UI Automation Support for the Menu Control Type
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 This topic provides information about [!INCLUDE[TLA#tla_uiautomation](../../../includes/tlasharptla-uiautomation-md.md)] support for the Menu control type. It describes the control's [!INCLUDE[TLA#tla_uiautomation](../../../includes/tlasharptla-uiautomation-md.md)] tree structure and provides the properties and control patterns for specific control scenarios.  
  
 A menu control allows hierarchal organization of elements associated with commands and event handlers. In a typical [!INCLUDE[TLA#tla_win](../../../includes/tlasharptla-win-md.md)] application, a menu bar contains several menu buttons (such as **File**, **Edit**, and **Window**), and each menu button displays a menu. A menu contains a collection of menu items (such as **New**, **Open**, and **Close**), which can be expanded to display additional menu items or to perform a specific action when clicked.  
  
 The following sections define the required [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree structure, properties, control patterns, and events for the Menu control type. The [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] requirements apply to all list controls, whether [!INCLUDE[TLA#tla_winclient](../../../includes/tlasharptla-winclient-md.md)], [!INCLUDE[TLA#tla_win32](../../../includes/tlasharptla-win32-md.md)], or [!INCLUDE[TLA#tla_winforms](../../../includes/tlasharptla-winforms-md.md)].  
  
<a name="Required_UI_Automation_Tree_Structure"></a>   
## Required UI Automation Tree Structure  
 The following table depicts the control view and the content view of the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree that pertains to menu controls and describes what can be contained in each view. For more information on the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree, see [UI Automation Tree Overview](../../../docs/framework/ui-automation/ui-automation-tree-overview.md).  
  
|Control View|Content View|  
|------------------|------------------|  
|Menu<br /><br /> -   MenuItem (1 or many)|Not applicable (unless the menu control is a context menu that is a parent of an object that is not a menu item)<br /><br /> -   MenuItem (1 or many)|  
  
 Menu controls always appear in the control view and the content view of the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree. Menu control types should appear under the control that their information is referring to. UI Automation clients must listen for `MenuOpenedEvent` to ensure that they consistently obtain information conveyed by menu controls. Context menu controls are a special case. They appear as children of the Desktop.  
  
<a name="Required_UI_Automation_Properties"></a>   
## Required UI Automation Properties  
 The following table lists the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] properties whose value or definition is especially relevant to the Menu control type. For more information on [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] properties, see [UI Automation Properties for Clients](../../../docs/framework/ui-automation/ui-automation-properties-for-clients.md).  
  
|[!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] Property|Value|Notes|  
|------------------------------------------------------------------------------------|-----------|-----------|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|Not Supported|The menu control does not require a Name property to be set.|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|`Null`|No label is anticipated with a typical menu control.|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|Menu|This value is the same for all UI frameworks.|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|False|The menu control is not included in the content view of the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree.|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The menu control is always included in the control view of the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree.|  
  
<a name="Required_UI_Automation_Control_Patterns"></a>   
## Required UI Automation Control Patterns  
 There are no required control patterns for the Menu control type.  
  
<a name="Required_UI_Automation_Events"></a>   
## Required UI Automation Events  
 Menu controls must raise `MenuOpenedEvent` when they appear on the screen. The `MenuOpenedEvent` will include the text of the control. The `MenuClosedEvent` must be raised when a menu disappears from the screen.  
  
 The following table lists the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] events required to be supported by all menu controls. For more information on events, see [UI Automation Events Overview](../../../docs/framework/ui-automation/ui-automation-events-overview.md).  
  
|[!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] Event|Support/Value|Notes|  
|---------------------------------------------------------------------------------|--------------------|-----------|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.MenuOpenedEvent>|Required|None|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.MenuClosedEvent>|Required|None|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|  
  
## See Also  
 <xref:System.Windows.Automation.ControlType.Menu>  
 [UI Automation Control Patterns Overview](../../../docs/framework/ui-automation/ui-automation-control-patterns-overview.md)  
 [UI Automation Control Types Overview](../../../docs/framework/ui-automation/ui-automation-control-types-overview.md)  
 [UI Automation Overview](../../../docs/framework/ui-automation/ui-automation-overview.md)
