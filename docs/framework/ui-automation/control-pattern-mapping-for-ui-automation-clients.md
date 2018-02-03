---
title: "Control Pattern Mapping for UI Automation Clients"
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
  - "control patterns, for UI Automation clients"
  - "UI Automation, clients, control patterns for"
ms.assetid: 8b81645b-8be3-4e26-9c98-4fb0fceca06b
caps.latest.revision: 18
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Control Pattern Mapping for UI Automation Clients
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 This topic lists control types and their associated control patterns.  
  
 The following table organizes the control patterns into the following categories:  
  
-   Supported. The control must support this control pattern.  
  
-   Conditional support. The control may support this control pattern depending on the state of the control.  
  
-   Not supported. The control does not support this control pattern; custom controls may support this control pattern.  
  
> [!NOTE]
>  Some controls have conditional support for several control patterns depending on the functionality of the control. For example, the menu item control has conditional support for the <xref:System.Windows.Automation.InvokePattern>, <xref:System.Windows.Automation.ExpandCollapsePattern>, <xref:System.Windows.Automation.TogglePattern>, or <xref:System.Windows.Automation.SelectionItemPattern> control pattern, depending on its function in the menu control.  
  
<a name="control_mapping_clients"></a>   
## UI Automation Control Patterns for Clients  
  
|Control Type|Supported|Conditional Support|Not Supported|  
|------------------|---------------|-------------------------|-------------------|  
|Button|None|Invoke, Toggle, Expand Collapse|None|  
|Calendar|Grid, Table|Selection, Scroll|Value|  
|Check Box|Toggle|None|None|  
|Combo Box|Expand Collapse|Selection, Value|Scroll|  
|Data Grid|Grid|Scroll, Selection, Table|None|  
|Data Item|Selection Item|Expand Collapse, Grid Item, Scroll Item, Table, Toggle, Value|None|  
|Document|Text|Scroll, Value|None|  
|Edit|None|Text, Range Value, Value|None|  
|Group|None|Expand Collapse|None|  
|Header|None|Transform|None|  
|Header Item|None|Transform, Invoke|None|  
|Hyperlink|Invoke|Value|None|  
|Image|None|Grid Item, Table Item|Invoke, Selection Item|  
|List|None|Grid, Multiple View, Scroll, Selection|Table|  
|List Item|Selection Item|Expand Collapse, Grid Item, Invoke, Scroll Item, Toggle, Value|None|  
|Menu|None|None|None|  
|Menu Bar|None|Expand Collapse, Dock, Transform|None|  
|Menu Item|None|Expand Collapse, Invoke, Selection Item, Toggle|None|  
|Pane|None|Dock. Scroll, Transform|Window|  
|Progress Bar|None|Range Value, Value|None|  
|Radio Button|Selection Item|None|Toggle|  
|Scroll Bar|None|Range Value|Scroll|  
|Separator|None|None|None|  
|Slider|None|Range Value, Selection, Value|None|  
|Spinner|None|Range Value, Selection, Value|None|  
|Split Button|Invoke, Expand Collapse|None|None|  
|Status Bar|None|Grid|None|  
|Tab|Selection|Scroll|None|  
|Tab Item|Selection Item|None|Invoke|  
|Table|Grid, Grid Item, Table, Table Item|None|None|  
|Text|None|Grid Item, Table Item, Text|Value|  
|Thumb|Transform|None|None|  
|Title Bar|None|None|None|  
|Tool Bar|None|Dock, Expand Collapse, Transform|None|  
|Tool Tip|None|Text, Window|None|  
|Tree|None|Scroll, Selection|None|  
|Tree Item|Expand Collapse|Invoke, Scroll Item, Selection Item, Toggle|None|  
|Window|Transform, Window|Dock|None|  
  
> [!NOTE]
>  If a control type has no supported control patterns listed but has one or more conditionally-supported control patterns, then one of those conditional control patterns will be supported at all times.  
  
## See Also  
 [UI Automation Overview](../../../docs/framework/ui-automation/ui-automation-overview.md)
