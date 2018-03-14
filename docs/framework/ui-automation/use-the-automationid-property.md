---
title: "Use the AutomationID Property"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "AutomationId property"
  - "UI Automation, AutomationId property"
  - "properties, AutomationId"
ms.assetid: a24e807b-d7c3-4e93-ac48-80094c4e1c90
caps.latest.revision: 21
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Use the AutomationID Property
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 This topic contains scenarios and sample code that show how and when the <xref:System.Windows.Automation.AutomationElement.AutomationIdProperty> can be used to locate an element within the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree.  
  
 <xref:System.Windows.Automation.AutomationElement.AutomationIdProperty> uniquely identifies a UI Automation element from its siblings. For more information on property identifiers related to control identification, see [UI Automation Properties Overview](../../../docs/framework/ui-automation/ui-automation-properties-overview.md).  
  
> [!NOTE]
>  <xref:System.Windows.Automation.AutomationElement.AutomationIdProperty> does not guarantee a unique identity throughout the tree; it typically needs container and scope information to be useful. For example, an application may contain a menu control with multiple top-level menu items that, in turn, have multiple child menu items. These secondary menu items may be identified by a generic scheme such as "Item1", "Item 2", and so on, allowing duplicate identifiers for children across top-level menu items.  
  
## Scenarios  
 Three primary UI Automation client application scenarios have been identified that require the use of <xref:System.Windows.Automation.AutomationElement.AutomationIdProperty> to achieve accurate and consistent results when searching for elements.  
  
> [!NOTE]
>  <xref:System.Windows.Automation.AutomationElement.AutomationIdProperty> is supported by all UI Automation elements in the control view except top-level application windows, UI Automation elements derived from [!INCLUDE[TLA#tla_winclient](../../../includes/tlasharptla-winclient-md.md)] controls that do not have an ID or x:Uid, and UI Automation elements derived from [!INCLUDE[TLA#tla_win32](../../../includes/tlasharptla-win32-md.md)] controls that do not have a control ID.  
  
#### Use a unique and discoverable AutomationID to locate a specific element in the UI Automation tree  
  
-   Use a tool such as [!INCLUDE[TLA#tla_uispy](../../../includes/tlasharptla-uispy-md.md)] to report the <xref:System.Windows.Automation.AutomationElement.AutomationIdProperty> of a [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] element of interest. This value can then be copied and pasted into a client application such as a test script for subsequent automated testing. This approach reduces and simplifies the code necessary to identify and locate an element at runtime.  
  
> [!CAUTION]
>  In general, you should try to obtain only direct children of the <xref:System.Windows.Automation.AutomationElement.RootElement%2A>. A search for descendants may iterate through hundreds or even thousands of elements, possibly resulting in a stack overflow. If you are attempting to obtain a specific element at a lower level, you should start your search from the application window or from a container at a lower level.  
  
 [!code-csharp[UIAAutomationID_snip#100](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAAutomationID_snip/CSharp/FindByAutomationID.xaml.cs#100)]
 [!code-vb[UIAAutomationID_snip#100](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAAutomationID_snip/VisualBasic/FindByAutomationID.xaml.vb#100)]  
  
#### Use a persistent path to return to a previously identified AutomationElement  
  
-   Client applications, from simple test scripts to robust record and playback utilities, may require access to elements that are not currently instantiated, such as a file open dialog or a menu item and therefore do not exist in the UI Automation tree. These elements can only be instantiated by reproducing, or "playing back", a specific sequence of [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)] actions through the use of [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] properties such as AutomationID, control patterns and event listeners. See [Test Script Generator Sample](http://msdn.microsoft.com/library/028467fd-2980-4691-9522-0131dcef23a0) for an example that uses [!INCLUDE[TLA#tla_uiautomation](../../../includes/tlasharptla-uiautomation-md.md)] to generate test scripts based on user interaction with the [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)].  
  
 [!code-csharp[UIAAutomationID_snip#UIAWorkerThread](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAAutomationID_snip/CSharp/FindByAutomationID.xaml.cs#uiaworkerthread)]
 [!code-vb[UIAAutomationID_snip#UIAWorkerThread](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAAutomationID_snip/VisualBasic/FindByAutomationID.xaml.vb#uiaworkerthread)]  
[!code-csharp[UIAAutomationID_snip#Playback](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAAutomationID_snip/CSharp/FindByAutomationID.xaml.cs#playback)]
[!code-vb[UIAAutomationID_snip#Playback](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAAutomationID_snip/VisualBasic/FindByAutomationID.xaml.vb#playback)]  
  
#### Use a relative path to return to a previously identified AutomationElement  
  
-   In certain circumstances, since AutomationID is only guaranteed to be unique amongst siblings, multiple elements in the UI Automation tree may have identical AutomationID property values. In these situations the elements can be uniquely identified based on a parent and, if necessary, a grandparent. For example, a developer may provide a menu bar with multiple menu items each with multiple child menu items where the children are identified with sequential AutomationID's such as "Item1", "Item2", and so on. Each menu item could then be uniquely identified by its AutomationID along with the AutomationID of its parent and, if necessary, its grandparent.  
  
## See Also  
 <xref:System.Windows.Automation.AutomationElement.AutomationIdProperty>  
 [UI Automation Tree Overview](../../../docs/framework/ui-automation/ui-automation-tree-overview.md)  
 [Find a UI Automation Element Based on a Property Condition](../../../docs/framework/ui-automation/find-a-ui-automation-element-based-on-a-property-condition.md)
