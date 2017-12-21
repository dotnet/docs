---
title: "Implementing the UI Automation GridItem Control Pattern"
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
  - "control patterns, GridItem"
  - "UI Automation GridItem control pattern"
  - "GridItem control pattern"
ms.assetid: bffbae08-fe2a-42fd-ab84-f37187518916
caps.latest.revision: 15
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Implementing the UI Automation GridItem Control Pattern
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 This topic introduces guidelines and conventions for implementing <xref:System.Windows.Automation.Provider.IGridItemProvider>, including information about properties. Links to additional references are listed at the end of the overview.  
  
 The <xref:System.Windows.Automation.GridItemPattern> control pattern is used to support individual child controls of containers that implement <xref:System.Windows.Automation.Provider.IGridProvider>. For examples of controls that implement this control pattern, see [Control Pattern Mapping for UI Automation Clients](../../../docs/framework/ui-automation/control-pattern-mapping-for-ui-automation-clients.md).  
  
<a name="Implementation_Guidelines_and_Conventions"></a>   
## Implementation Guidelines and Conventions  
 When implementing <xref:System.Windows.Automation.Provider.IGridProvider>, note the following guidelines and conventions:  
  
-   Grid coordinates are zero-based with the upper left cell having coordinates (0, 0).  
  
-   Merged cells will report their <xref:System.Windows.Automation.Provider.IGridItemProvider.Row%2A> and <xref:System.Windows.Automation.Provider.IGridItemProvider.Column%2A> properties based on their underlying anchor cell as defined by the UI Automation provider. Typically, it will be the topmost and leftmost row or column.  
  
-   <xref:System.Windows.Automation.Provider.IGridItemProvider> does not provide for active manipulation of the grid such as merging or splitting cells.  
  
-   Controls that implement <xref:System.Windows.Automation.Provider.IGridItemProvider> can typically be traversed (that is, a UI Automation client can move to adjacent controls) by using the keyboard.  
  
<a name="Required_Members_for_IGridItemProvider"></a>   
## Required Members for IGridItemProvider  
 The following properties and methods are required for implementing <xref:System.Windows.Automation.Provider.IGridItemProvider>.  
  
|Required members|Member type|Notes|  
|----------------------|-----------------|-----------|  
|<xref:System.Windows.Automation.Provider.IGridItemProvider.Row%2A>|Property|None|  
|<xref:System.Windows.Automation.Provider.IGridItemProvider.Column%2A>|Property|None|  
|<xref:System.Windows.Automation.Provider.IGridItemProvider.RowSpan%2A>|Property|None|  
|<xref:System.Windows.Automation.Provider.IGridItemProvider.ColumnSpan%2A>|Property|None|  
|<xref:System.Windows.Automation.Provider.IGridItemProvider.ContainingGrid%2A>|Property|None|  
  
 This control pattern has no associated methods or events.  
  
<a name="Exceptions"></a>   
## Exceptions  
 This control pattern has no associated exceptions.  
  
## See Also  
 [UI Automation Control Patterns Overview](../../../docs/framework/ui-automation/ui-automation-control-patterns-overview.md)  
 [Support Control Patterns in a UI Automation Provider](../../../docs/framework/ui-automation/support-control-patterns-in-a-ui-automation-provider.md)  
 [UI Automation Control Patterns for Clients](../../../docs/framework/ui-automation/ui-automation-control-patterns-for-clients.md)  
 [Implementing the UI Automation Grid Control Pattern](../../../docs/framework/ui-automation/implementing-the-ui-automation-grid-control-pattern.md)  
 [UI Automation Tree Overview](../../../docs/framework/ui-automation/ui-automation-tree-overview.md)  
 [Use Caching in UI Automation](../../../docs/framework/ui-automation/use-caching-in-ui-automation.md)
