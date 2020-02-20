---
title: "UI Automation Control Types Overview"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "UI Automation, control types"
  - "control types, UI Automation"
ms.assetid: 75159ef8-bd43-4d13-acb7-1f1fe9253160
---
# UI Automation Control Types Overview
> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).  
  
 [!INCLUDE[TLA#tla_uiautomation](../../../includes/tlasharptla-uiautomation-md.md)] control types are well-known identifiers that can be used to indicate what kind of control a particular element represents, such as a combo box or a button.  
  
 Having a well-known identifier makes it easier for assistive technology devices to determine what types of controls are available in the [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)] and how to interact with the controls.  
  
<a name="UI_Automation_Control_Type_Requisites"></a>   
## UI Automation Control Type Requisites  
 [!INCLUDE[TLA#tla_uiautomation](../../../includes/tlasharptla-uiautomation-md.md)] control types provide a set of conditions that providers must meet. When these conditions are met, the control can use the specific control type name. Each control type has conditions for the following:  
  
- [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] control patterns—which control patterns must be supported, which control patterns are optional, and which control patterns must not be supported by the control.  
  
- [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] property values—which property values are supported.  
  
- [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree structure—the required [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree structure for the control.  
  
 When a control meets the conditions for a particular control type, the <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.ControlType%2A> property value will indicate that control type.  
  
<a name="Current_UI_Automation_Control_Types"></a>   
## Current UI Automation Control Types  
 The following list contains the current set of [!INCLUDE[TLA#tla_uiautomation](../../../includes/tlasharptla-uiautomation-md.md)] control types:  
  
- [UI Automation Support for the Button Control Type](ui-automation-support-for-the-button-control-type.md)  
  
- [UI Automation Support for the Calendar Control Type](ui-automation-support-for-the-calendar-control-type.md)  
  
- [UI Automation Support for the CheckBox Control Type](ui-automation-support-for-the-checkbox-control-type.md)  
  
- [UI Automation Support for the ComboBox Control Type](ui-automation-support-for-the-combobox-control-type.md)  
  
- [UI Automation Support for the DataGrid Control Type](ui-automation-support-for-the-datagrid-control-type.md)  
  
- [UI Automation Support for the DataItem Control Type](ui-automation-support-for-the-dataitem-control-type.md)  
  
- [UI Automation Support for the Document Control Type](ui-automation-support-for-the-document-control-type.md)  
  
- [UI Automation Support for the Edit Control Type](ui-automation-support-for-the-edit-control-type.md)  
  
- [UI Automation Support for the Group Control Type](ui-automation-support-for-the-group-control-type.md)  
  
- [UI Automation Support for the Header Control Type](ui-automation-support-for-the-header-control-type.md)  
  
- [UI Automation Support for the HeaderItem Control Type](ui-automation-support-for-the-headeritem-control-type.md)  
  
- [UI Automation Support for the Hyperlink Control Type](ui-automation-support-for-the-hyperlink-control-type.md)  
  
- [UI Automation Support for the Image Control Type](ui-automation-support-for-the-image-control-type.md)  
  
- [UI Automation Support for the List Control Type](ui-automation-support-for-the-list-control-type.md)  
  
- [UI Automation Support for the ListItem Control Type](ui-automation-support-for-the-listitem-control-type.md)  
  
- [UI Automation Support for the Menu Control Type](ui-automation-support-for-the-menu-control-type.md)  
  
- [UI Automation Support for the MenuBar Control Type](ui-automation-support-for-the-menubar-control-type.md)  
  
- [UI Automation Support for the MenuItem Control Type](ui-automation-support-for-the-menuitem-control-type.md)  
  
- [UI Automation Support for the Pane Control Type](ui-automation-support-for-the-pane-control-type.md)  
  
- [UI Automation Support for the ProgressBar Control Type](ui-automation-support-for-the-progressbar-control-type.md)  
  
- [UI Automation Support for the RadioButton Control Type](ui-automation-support-for-the-radiobutton-control-type.md)  
  
- [UI Automation Support for the ScrollBar Control Type](ui-automation-support-for-the-scrollbar-control-type.md)  
  
- [UI Automation Support for the Separator Control Type](ui-automation-support-for-the-separator-control-type.md)  
  
- [UI Automation Support for the Slider Control Type](ui-automation-support-for-the-slider-control-type.md)  
  
- [UI Automation Support for the Spinner Control Type](ui-automation-support-for-the-spinner-control-type.md)  
  
- [UI Automation Support for the SplitButton Control Type](ui-automation-support-for-the-splitbutton-control-type.md)  
  
- [UI Automation Support for the StatusBar Control Type](ui-automation-support-for-the-statusbar-control-type.md)  
  
- [UI Automation Support for the Tab Control Type](ui-automation-support-for-the-tab-control-type.md)  
  
- [UI Automation Support for the TabItem Control Type](ui-automation-support-for-the-tabitem-control-type.md)  
  
- [UI Automation Support for the Table Control Type](ui-automation-support-for-the-table-control-type.md)  
  
- [UI Automation Support for the Text Control Type](ui-automation-support-for-the-text-control-type.md)  
  
- [UI Automation Support for the Thumb Control Type](ui-automation-support-for-the-thumb-control-type.md)  
  
- [UI Automation Support for the TitleBar Control Type](ui-automation-support-for-the-titlebar-control-type.md)  
  
- [UI Automation Support for the ToolBar Control Type](ui-automation-support-for-the-toolbar-control-type.md)  
  
- [UI Automation Support for the ToolTip Control Type](ui-automation-support-for-the-tooltip-control-type.md)  
  
- [UI Automation Support for the Tree Control Type](ui-automation-support-for-the-tree-control-type.md)  
  
- [UI Automation Support for the TreeItem Control Type](ui-automation-support-for-the-treeitem-control-type.md)  
  
- [UI Automation Support for the Window Control Type](ui-automation-support-for-the-window-control-type.md)  
  
## See also

- <xref:System.Windows.Automation.ControlType>
