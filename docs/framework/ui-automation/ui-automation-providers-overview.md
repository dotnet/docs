---
title: "UI Automation Providers Overview"
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
  - "UI Automation, providers"
  - "providers, UI Automation"
ms.assetid: 859557b8-51e1-4d15-92e8-318d2dcdb2f7
caps.latest.revision: 38
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# UI Automation Providers Overview
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 UI Automation providers enable controls to communicate with UI Automation client applications. In general, each control or other distinct element in a [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)] is represented by a provider. The provider exposes information about the element and optionally implements control patterns that enable the client application to interact with the control.  
  
 Client applications do not usually have to work directly with providers. Most of the standard controls in applications that use the [!INCLUDE[TLA#tla_win32](../../../includes/tlasharptla-win32-md.md)], [!INCLUDE[TLA#tla_winforms](../../../includes/tlasharptla-winforms-md.md)], or [!INCLUDE[TLA#tla_winclient](../../../includes/tlasharptla-winclient-md.md)] frameworks are automatically exposed to the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] system. Applications that implement custom controls may also implement [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] providers for those controls, and client applications do not have to take any special steps to gain access to them.  
  
 This topic provides an overview of how control developers implement [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] providers, particularly for controls in [!INCLUDE[TLA#tla_winforms](../../../includes/tlasharptla-winforms-md.md)] and [!INCLUDE[TLA#tla_win32](../../../includes/tlasharptla-win32-md.md)] windows.  
  
<a name="Types_of_Providers"></a>   
## Types of Providers  
 UI Automation providers fall into two categories: client-side providers and server-side providers.  
  
### Client-side providers  
 Client-side providers are implemented by UI Automation clients to communicate with an application that does not support, or does not fully support, [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)]. Client-side providers usually communicate with the server across the process boundary by sending and receiving [!INCLUDE[TLA2#tla_win](../../../includes/tla2sharptla-win-md.md)] messages.  
  
 Because UI Automation providers for controls in [!INCLUDE[TLA2#tla_win32](../../../includes/tla2sharptla-win32-md.md)], [!INCLUDE[TLA2#tla_winforms](../../../includes/tla2sharptla-winforms-md.md)], or [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] applications are supplied as part of the operating system, client applications seldom have to implement their own providers, and this overview does not cover them further.  
  
### Server-side providers  
 Server-side providers are implemented by custom controls or by applications that are based on a UI framework other than [!INCLUDE[TLA2#tla_win32](../../../includes/tla2sharptla-win32-md.md)], [!INCLUDE[TLA2#tla_winforms](../../../includes/tla2sharptla-winforms-md.md)], or [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)].  
  
 Server-side providers communicate with client applications across the process boundary by exposing interfaces to the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] core system, which in turn serves requests from clients.  
  
<a name="AutomationProviderConcepts"></a>   
## UI Automation Provider Concepts  
 This section provides brief explanations of some of the key concepts you need to understand in order to implement UI Automation providers.  
  
### Elements  
 [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] elements are pieces of [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)] that are visible to UI Automation clients. Examples include application windows, panes, buttons, tooltips, list boxes, and list items.  
  
### Navigation  
 [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] elements are exposed to clients as a [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree. [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] constructs the tree by navigating from one element to another. Navigation is enabled by the providers for each element, each of which may point to a parent, siblings, and children.  
  
 For more information on the client view of the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree, see [UI Automation Tree Overview](../../../docs/framework/ui-automation/ui-automation-tree-overview.md).  
  
### Views  
 A client can see the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree in three principal views, as shown in the following table.  
  
|||  
|-|-|  
|Raw view|Contains all elements.|  
|Control view|Contains elements that are controls.|  
|Content view|Contains elements that have content.|  
  
 For more information on client views of the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree, see [UI Automation Tree Overview](../../../docs/framework/ui-automation/ui-automation-tree-overview.md).  
  
 It is the responsibility of the provider implementation to define an element as a content element or a control element. Control elements may or may not also be content elements, but all content elements are control elements.  
  
### Frameworks  
 A framework is a component that manages child controls, hit-testing, and rendering in an area of the screen. For example, a [!INCLUDE[TLA#tla_win32](../../../includes/tlasharptla-win32-md.md)] window, often referred to as an HWND, can serve as a framework that contains multiple [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] elements such as a menu bar, a status bar, and buttons.  
  
 [!INCLUDE[TLA2#tla_win32](../../../includes/tla2sharptla-win32-md.md)] container controls such as list boxes and tree views are considered to be frameworks, because they contain their own code for rendering child items and performing hit-testing on them. By contrast, a [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] list box is not a framework, because the rendering and hit-testing is being handled by the containing [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] window.  
  
 The [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] in an application can be made up of different frameworks. For example, an HWND application window might contain [!INCLUDE[TLA#tla_dhtml](../../../includes/tlasharptla-dhtml-md.md)] which in turn contains a component such as a combo box in an HWND.  
  
### Fragments  
 A fragment is a complete subtree of elements from a particular framework. The element at the root node of the subtree is called a fragment root. A fragment root does not have a parent, but is hosted within some other framework, usually a [!INCLUDE[TLA2#tla_win32](../../../includes/tla2sharptla-win32-md.md)] window (HWND).  
  
### Hosts  
 The root node of every fragment must be hosted in an element, usually a [!INCLUDE[TLA#tla_win32](../../../includes/tlasharptla-win32-md.md)] window (HWND). The exception is the desktop, which is not hosted in any other element. The host of a custom control is the HWND of the control itself, not the application window or any other window that might contain groups of top-level controls.  
  
 The host of a fragment plays an important role in providing [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] services. It enables navigation to the fragment root, and supplies some default properties so that the custom provider does not have to implement them.  
  
## See Also  
 [Server-Side UI Automation Provider Implementation](../../../docs/framework/ui-automation/server-side-ui-automation-provider-implementation.md)
