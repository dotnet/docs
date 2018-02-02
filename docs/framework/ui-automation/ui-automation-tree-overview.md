---
title: "UI Automation Tree Overview"
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
  - "automation tree"
  - "UI Automation, tree"
ms.assetid: 03b98058-bdb3-47a0-8ff7-45e6cdf67166
caps.latest.revision: 25
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# UI Automation Tree Overview
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 Assistive technology products and test scripts navigate the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree to gather information about the [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)] and its elements.  
  
 Within the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree there is a root element (<xref:System.Windows.Automation.AutomationElement.RootElement%2A>) that represents the current desktop and whose child elements represent application windows. Each of these child elements can contain elements representing pieces of [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] such as menus, buttons, toolbars, and list boxes. These elements in turn can contain elements such as list items.  
  
 The [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree is not a fixed structure and is seldom seen in its totality because it might contain thousands of elements. Parts of it are built as they are needed, and it can undergo changes as elements are added, moved, or removed.  
  
 UI Automation providers support the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree by implementing navigation among items within a fragment, which consists of a root (usually hosted in a window) and a subtree. However, providers are not concerned with navigation from one control to another. This is managed by the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] core, using information from the default window providers.  
  
<a name="uiautomation_tree_view"></a>   
## Views of the Automation Tree  
 The [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree can be filtered to create views that contain only those <xref:System.Windows.Automation.AutomationElement> objects relevant for a particular client. This approach allows clients to customize the structure presented through [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] to their particular needs.  
  
 The client has two ways of customizing the view: by scoping and by filtering. Scoping is defining the extent of the view, starting from a base element: for example, the application might want to find only direct children of the desktop, or all descendants of an application window. Filtering is defining the types of elements that are to be included in the view.  
  
 UI Automation providers support filtering by defining properties on elements, including the <xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty> and <xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty> properties.  
  
 [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] provides three default views. These views are defined by the type of filtering performed; the scope of any view is defined by the application. In addition, the application can apply other filters on properties; for example, to include only enabled controls in a control view.  
  
<a name="uiautomation_raw_view"></a>   
### Raw View  
 The raw view of the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree is the full tree of <xref:System.Windows.Automation.AutomationElement> objects for which the desktop is the root. The raw view closely follows the native programmatic structure of an application and therefore is the most detailed view available. It is also the base on which the other views of the tree are built. Because this view depends on the underlying [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] framework, the raw view of a [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] button will have a different raw view than a [!INCLUDE[TLA2#tla_win32](../../../includes/tla2sharptla-win32-md.md)] button.  
  
 The raw view is obtained by searching for elements without specifying properties or by using the <xref:System.Windows.Automation.TreeWalker.RawViewWalker> to navigate the tree.  
  
<a name="uiautomation_control_view"></a>   
### Control View  
 The control view of the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree simplifies the assistive technology product's task of describing the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] to the end user and helping that end user interact with the application because it closely maps to the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] structure perceived by an end user.  
  
 The control view is a subset of the raw view. It includes all [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] items from the raw view that an end user would understand as interactive or contributing to the logical structure of the control in the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)]. Examples of [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] items that contribute to the logical structure of the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)], but are not interactive themselves, are item containers such as list view headers, toolbars, menus, and the status bar. Non-interactive items used simply for layout or decorative purposes will not be seen in the control view. An example is a panel that was used only to lay out the controls in a dialog but does not itself contain any information. Non-interactive items that will be seen in the control view are graphics with information and static text in a dialog. Non-interactive items that are included in the control view cannot receive keyboard focus.  
  
 The control view is obtained by searching for elements that have the <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.IsControlElement%2A> property set to `true`, or by using the <xref:System.Windows.Automation.TreeWalker.ControlViewWalker> to navigate the tree.  
  
<a name="uiautomation_content_view"></a>   
### Content View  
 The content view of the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree is a subset of the control view. It contains [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] items that convey the true information in a user interface, including [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] items that can receive keyboard focus and some text that is not a label on a [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] item. For example, the values in a drop-down combo box will appear in the content view because they represent the information being used by an end user. In the content view, a combo box and list box are both represented as a collection of [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] items where one, or perhaps more than one, item can be selected. The fact that one is always open and one can expand and collapse is irrelevant in the content view because it is designed to show the data, or content, that is being presented to the user.  
  
 The content view is obtained by searching for elements that have the <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.IsContentElement%2A> property set to `true`, or by using the <xref:System.Windows.Automation.TreeWalker.ContentViewWalker> to navigate the tree.  
  
## See Also  
 <xref:System.Windows.Automation.AutomationElement>  
 [UI Automation Overview](../../../docs/framework/ui-automation/ui-automation-overview.md)
