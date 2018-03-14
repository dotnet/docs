---
title: "UI Automation Support for the List Control Type"
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
  - "control types, List"
  - "List control type"
  - "UI Automation, List control type"
ms.assetid: 0e959fcb-50f2-413b-948d-7167d279bc11
caps.latest.revision: 20
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# UI Automation Support for the List Control Type
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 This topic provides information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] support for the List control type. In [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree structure, [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] property values and control patterns.  
  
 The List control type provides a way to organize a flat group or groups of items and allows a user to select one or more of those items. The List control type has a loose restriction on what types of child elements it may contain. This enables UI Automation providers to support a well-known element for selection containers.  
  
 The [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] requirements in the following sections apply to all controls that implement the List control type, whether [!INCLUDE[TLA#tla_winclient](../../../includes/tlasharptla-winclient-md.md)], [!INCLUDE[TLA#tla_win32](../../../includes/tlasharptla-win32-md.md)], or [!INCLUDE[TLA#tla_winforms](../../../includes/tlasharptla-winforms-md.md)]. List container controls are an example of controls that implement the List control type.  
  
<a name="Required_UI_Automation_Tree_Structure"></a>   
## Required UI Automation Tree Structure  
 The following table depicts the two views of the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree that pertain to list controls and describes what can be contained in each view. The control view contains only elements that are controls, and the content view removes redundant information from the tree. For example, a text control used to label a combo box will be exposed as the `ComboBox NameProperty`. Because the text control is already exposed in this manner through the control view it is unnecessary to have it exposed twice; therefore it is removed from the content view. For more information on the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree, see [UI Automation Tree Overview](../../../docs/framework/ui-automation/ui-automation-tree-overview.md).  
  
|Control View|Content View|  
|------------------|------------------|  
|Contains the elements that correspond to controls.|Removes redundant information from the tree so that assistive technologies work with the smallest set of meaningful information to the end user.|  
|List<br /><br /> -   DataItem (0 or more)<br />-   ListItem (0 or more)<br />-   Group (0 or more)<br />-   ScrollBar (0, 1 or 2)|List<br /><br /> -   DataItem (0 or more)<br />-   ListItem (0 or more)<br />-   Group (0 or more)|  
  
 The control view for a control that implements the List control type (such as a list control) consists of:  
  
-   Zero or more items within the list control (items can be based on the List Item or Data Item control types)  
  
-   Zero or more group controls within a list control  
  
-   Zero, one, or two scroll bar controls  
  
-  
  
 The content view of a control that implements the List control type (such as a list control) consists of:  
  
-   Zero or more items within the list control (items can be based on the List Item or Data Item control types)  
  
-   Zero or more groups within the list control  
  
 A list control must not have items that have a hierarchical relationship other than being grouped together. If the items have children in the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree, then the list container should be based on the Tree control type.  
  
 The selectable items within the list control will be available from the descendants in the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree of the list control. All items within the list control must belong to the same selection group. The selectable items in the list should be exposed as ListItem (instead of DataItem) control types.  
  
<a name="Required_UI_Automation_Properties"></a>   
## Required UI Automation Properties  
 The following table lists the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] properties whose value or definition is especially relevant to list controls. For more information on [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] properties, see [UI Automation Properties for Clients](../../../docs/framework/ui-automation/ui-automation-properties-for-clients.md).  
  
|[!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] Property|Value|Notes|  
|------------------------------------------------------------------------------------|-----------|-----------|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes.|If the list control has a clickable point (a point that can be clicked to cause the list to take focus), then that point must be exposed through this property.<br /><br /> If the value of the `IsOffScreen` property is true, then the <xref:System.Windows.Automation.NoClickablePointException> will be raised.|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The value of a list control's Name property should convey the category of options that the user is being asked to select from. This property typically gets its name from a static text label. If there is not a static text label the application developer must expose a value for the Name property.<br /><br /> The only time this property is not required for list controls is if the control is used within the subtree of another control.|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|See notes.|If there is a static text label then this property must expose a reference to that control.|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|List|This value is the same for all UI frameworks.|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"list"|Localized string corresponding to the List control type.|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|True|The list control is always included in the content view of the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree.|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The list control is always included in the control view of the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree.|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|True|If the container can accept keyboard input then this property value should be true.|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.HelpTextProperty>|See notes.|The Help text for list controls should explain why the user is being asked to make a choice from a list of options. For example, "Selection an item from this list will set the display resolution for your monitor."|  
  
<a name="Required_UI_Automation_Control_Patterns"></a>   
## Required UI Automation Control Patterns and Properties  
 The following table lists the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] control patterns required to be supported by list controls. For more information on control patterns, see [UI Automation Control Patterns Overview](../../../docs/framework/ui-automation/ui-automation-control-patterns-overview.md).  
  
|Control Pattern/Pattern Property|Support/Value|Notes|  
|---------------------------------------|--------------------|-----------|  
|<xref:System.Windows.Automation.Provider.ISelectionProvider>|Required|All controls that support the List control type must implement `ISelectionProvider` when a selection state is maintained between the items contained in the control. If the items within the container are not selectable, the Group control type must be used.|  
|<xref:System.Windows.Automation.Provider.ISelectionProvider.IsSelectionRequired%2A>|Depends|List controls do not always require that an item be selected.|  
|<xref:System.Windows.Automation.Provider.ISelectionProvider.CanSelectMultiple%2A>|Depends|List controls can be single or multiple-selection containers.|  
|<xref:System.Windows.Automation.Provider.IScrollProvider>|Depends|Implement this control pattern if items in the container are scrollable.|  
|<xref:System.Windows.Automation.Provider.IGridProvider>|Depends|Implement this pattern when grid navigation needs to be available on an item by item basis.|  
|<xref:System.Windows.Automation.Provider.IMultipleViewProvider>|Depends|Implement this control pattern if the control can support multiple views of the items in the container.|  
|<xref:System.Windows.Automation.Provider.ITableProvider>|Never|`ITableProvider` is never supported for the List control type. If the control should support this control pattern, then the control should be based on the Data Grid control type.|  
  
<a name="Required_UI_Automation_Events"></a>   
## Required UI Automation Events  
 The following table lists the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] events required to be supported by all list controls. For more information on events, see [UI Automation Events Overview](../../../docs/framework/ui-automation/ui-automation-events-overview.md).  
  
|[!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] Event|Support/Value|Notes|  
|---------------------------------------------------------------------------------|--------------------|-----------|  
|<xref:System.Windows.Automation.SelectionPatternIdentifiers.InvalidatedEvent>|Depends|None|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LayoutInvalidatedEvent>|Depends|None|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|  
|<xref:System.Windows.Automation.MultipleViewPatternIdentifiers.CurrentViewProperty> property-changed event.|Depends|None|  
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontallyScrollableProperty> property-changed event.|Depends|None|  
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontalScrollPercentProperty> property-changed event.|Depends|None|  
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontalViewSizeProperty> property-changed event.|Depends|None|  
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticalScrollPercentProperty> property-changed event.|Depends|None|  
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticallyScrollableProperty> property-changed event.|Depends|None|  
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticalViewSizeProperty> property-changed event.|Depends|None|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|  
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|  
  
## See Also  
 <xref:System.Windows.Automation.ControlType.List>  
 [UI Automation Control Types Overview](../../../docs/framework/ui-automation/ui-automation-control-types-overview.md)  
 [UI Automation Overview](../../../docs/framework/ui-automation/ui-automation-overview.md)
