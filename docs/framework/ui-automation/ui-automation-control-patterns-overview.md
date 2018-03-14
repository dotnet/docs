---
title: "UI Automation Control Patterns Overview"
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
  - "control patterns"
  - "UI Automation, control patterns"
ms.assetid: cc229b33-234b-469b-ad60-f0254f32d45d
caps.latest.revision: 34
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# UI Automation Control Patterns Overview
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 This overview introduces [!INCLUDE[TLA#tla_uiautomation](../../../includes/tlasharptla-uiautomation-md.md)] control patterns. Control patterns provide a way to categorize and expose a control's functionality independent of the control type or the appearance of the control.  
  
 [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] uses control patterns to represent common control behaviors. For example, you use the Invoke control pattern for controls that can be invoked (such as buttons) and the Scroll control pattern for controls that have scroll bars (such as list boxes, list views, or combo boxes). Because each control pattern represents a separate functionality, they can be combined to describe the full set of functionality supported by a particular control.  
  
> [!NOTE]
>  Aggregate controls—built with child controls that provide the [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)] for functionality exposed by the parent—should implement all control patterns normally associated with each child control. In turn, those same control patterns are not required to be implemented by the child controls.  
  
<a name="uiautomation_control_pattern_includes"></a>   
## UI Automation Control Pattern Components  
 Control patterns support the methods, properties, events, and relationships needed to define a discrete piece of functionality available in a control.  
  
-   The relationship between a UI Automation element and its parent, children and siblings describes the element's structure within the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree.  
  
-   The methods allow UI Automation clients to manipulate the control.  
  
-   The properties and events provide information about the control pattern's functionality as well as information about the state of the control.  
  
 Control patterns relate to [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] as interfaces relate to [!INCLUDE[TLA#tla_com](../../../includes/tlasharptla-com-md.md)] objects. In [!INCLUDE[TLA2#tla_com](../../../includes/tla2sharptla-com-md.md)], you can query an object to ask what interfaces it supports and then use those interfaces to access functionality. In [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], UI Automation clients can ask a control which control patterns it supports and then interact with the control through the properties, methods, events, and structures exposed by the supported control patterns. For example, for a multiline edit box, UI Automation providers implement <xref:System.Windows.Automation.Provider.IScrollProvider>. When a client knows that an <xref:System.Windows.Automation.AutomationElement> supports the <xref:System.Windows.Automation.ScrollPattern> control pattern, it can use the properties, methods, and events exposed by that control pattern to manipulate the control, or access information about the control.  
  
<a name="uiautomation_control_pattern_client_provider"></a>   
## UI Automation Providers and Clients  
 UI Automation providers implement control patterns to expose the appropriate behavior for a specific piece of functionality supported by the control.  
  
 UI Automation clients access methods and properties of [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] control pattern classes and use them to get information about the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)], or to manipulate the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)]. These control pattern classes are found in the <xref:System.Windows.Automation> namespace (for example, <xref:System.Windows.Automation.InvokePattern> and <xref:System.Windows.Automation.SelectionPattern>).  
  
 Clients use <xref:System.Windows.Automation.AutomationElement> methods (such as <xref:System.Windows.Automation.AutomationElement.GetCurrentPropertyValue%2A?displayProperty=nameWithType> or <xref:System.Windows.Automation.AutomationElement.GetCachedPropertyValue%2A?displayProperty=nameWithType>) or the [!INCLUDE[TLA#tla_clr](../../../includes/tlasharptla-clr-md.md)] accessors to access the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] properties on a pattern. Each control pattern class has a field member (for example, <xref:System.Windows.Automation.InvokePattern.Pattern?displayProperty=nameWithType>``or <xref:System.Windows.Automation.SelectionPattern.Pattern?displayProperty=nameWithType>) that identifies that control pattern and can be passed as a parameter to <xref:System.Windows.Automation.AutomationElement.GetCachedPattern%2A> or <xref:System.Windows.Automation.AutomationElement.GetCurrentPattern%2A> to retrieve that pattern for an <xref:System.Windows.Automation.AutomationElement>.  
  
<a name="uiautomation_control_patterns_dynamic"></a>   
## Dynamic Control Patterns  
 Some controls do not always support the same set of control patterns. Control patterns are considered supported when they are available to a UI Automation client. For example, a multiline edit box enables vertical scrolling only when it contains more lines of text than can be displayed in its viewable area. Scrolling is disabled when enough text is removed so that scrolling is no longer required. For this example, the ScrollPattern control pattern is dynamically supported depending on the current state of the control (how much text is in the edit box).  
  
<a name="Control_Pattern_Classes_and_Interfaces"></a>   
## Control Pattern Classes and Interfaces  
 The following table describes the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] control patterns. The table also lists the classes used by UI Automation clients to access the control patterns, as well as the interfaces used by UI Automation providers to implement them.  
  
|Control Pattern Class|Provider Interface|Description|  
|---------------------------|------------------------|-----------------|  
|<xref:System.Windows.Automation.DockPattern>|<xref:System.Windows.Automation.Provider.IDockProvider>|Used for controls that can be docked in a docking container. For example, toolbars or tool palettes.|  
|<xref:System.Windows.Automation.ExpandCollapsePattern>|<xref:System.Windows.Automation.Provider.IExpandCollapseProvider>|Used for controls that can be expanded or collapsed. For example, menu items in an application such as the **File** menu.|  
|<xref:System.Windows.Automation.GridPattern>|<xref:System.Windows.Automation.Provider.IGridProvider>|Used for controls that support grid functionality such as sizing and moving to a specified cell. For example, the large icon view in Windows Explorer or simple tables without headers in [!INCLUDE[TLA#tla_word](../../../includes/tlasharptla-word-md.md)].|  
|<xref:System.Windows.Automation.GridItemPattern>|<xref:System.Windows.Automation.Provider.IGridItemProvider>|Used for controls that have cells within grids. The individual cells should support the GridItem pattern. For example, each cell in [!INCLUDE[TLA#tla_winexpl](../../../includes/tlasharptla-winexpl-md.md)] detail view.|  
|<xref:System.Windows.Automation.InvokePattern>|<xref:System.Windows.Automation.Provider.IInvokeProvider>|Used for controls that can be invoked, such as a button.|  
|<xref:System.Windows.Automation.MultipleViewPattern>|<xref:System.Windows.Automation.Provider.IMultipleViewProvider>|Used for controls that can switch between multiple representations of the same set of information, data, or children. For example, a list view control where data is available in thumbnail, tile, icon, list, or detail views.|  
|<xref:System.Windows.Automation.RangeValuePattern>|<xref:System.Windows.Automation.Provider.IRangeValueProvider>|Used for controls that have a range of values that can be applied to the control. For example, a spinner control containing years might have a range of 1900 to 2010, while another spinner control presenting months would have a range of 1 to 12.|  
|<xref:System.Windows.Automation.ScrollPattern>|<xref:System.Windows.Automation.Provider.IScrollProvider>|Used for controls that can scroll. For example, a control that has scroll bars that are active when there is more information than can be displayed in the viewable area of the control.|  
|<xref:System.Windows.Automation.ScrollItemPattern>|<xref:System.Windows.Automation.Provider.IScrollItemProvider>|Used for controls that have individual items in a list that scrolls. For example, a list control that has individual items in the scroll list, such as a combo box control.|  
|<xref:System.Windows.Automation.SelectionPattern>|<xref:System.Windows.Automation.Provider.ISelectionProvider>|Used for selection container controls. For example, list boxes and combo boxes.|  
|<xref:System.Windows.Automation.SelectionItemPattern>|<xref:System.Windows.Automation.Provider.ISelectionItemProvider>|Used for individual items in selection container controls, such as list boxes and combo boxes.|  
|<xref:System.Windows.Automation.TablePattern>|<xref:System.Windows.Automation.Provider.ITableProvider>|Used for controls that have a grid as well as header information. For example, [!INCLUDE[TLA#tla_xl](../../../includes/tlasharptla-xl-md.md)] worksheets.|  
|<xref:System.Windows.Automation.TableItemPattern>|<xref:System.Windows.Automation.Provider.ITableItemProvider>|Used for items in a table.|  
|<xref:System.Windows.Automation.TextPattern>|<xref:System.Windows.Automation.Provider.ITextProvider>|Used for edit controls and documents that expose textual information.|  
|<xref:System.Windows.Automation.TogglePattern>|<xref:System.Windows.Automation.Provider.IToggleProvider>|Used for controls where the state can be toggled. For example, check boxes and checkable menu items.|  
|<xref:System.Windows.Automation.TransformPattern>|<xref:System.Windows.Automation.Provider.ITransformProvider>|Used for controls that can be resized, moved, and rotated. Typical uses for the Transform control pattern are in designers, forms, graphical editors, and drawing applications.|  
|<xref:System.Windows.Automation.ValuePattern>|<xref:System.Windows.Automation.Provider.IValueProvider>|Allows clients to get or set a value on controls that do not support a range of values. For example, a date time picker.|  
|<xref:System.Windows.Automation.WindowPattern>|<xref:System.Windows.Automation.Provider.IWindowProvider>|Exposes information specific to windows, a fundamental concept to the [!INCLUDE[TLA#tla_win](../../../includes/tlasharptla-win-md.md)] operating system. Examples of controls that are windows are top-level application windows ([!INCLUDE[TLA#tla_word](../../../includes/tlasharptla-word-md.md)], [!INCLUDE[TLA#tla_winexpl](../../../includes/tlasharptla-winexpl-md.md)], and so on), [!INCLUDE[TLA#tla_mdi](../../../includes/tlasharptla-mdi-md.md)] child windows, and dialogs.|  
  
## See Also  
 [UI Automation Control Patterns for Clients](../../../docs/framework/ui-automation/ui-automation-control-patterns-for-clients.md)  
 [Control Pattern Mapping for UI Automation Clients](../../../docs/framework/ui-automation/control-pattern-mapping-for-ui-automation-clients.md)  
 [UI Automation Overview](../../../docs/framework/ui-automation/ui-automation-overview.md)  
 [UI Automation Properties for Clients](../../../docs/framework/ui-automation/ui-automation-properties-for-clients.md)  
 [UI Automation Events for Clients](../../../docs/framework/ui-automation/ui-automation-events-for-clients.md)
