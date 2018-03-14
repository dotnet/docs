---
title: "Obtaining UI Automation Elements"
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
  - "UI Automation, obtaining elements"
  - "elements, UI Automation, obtaining"
ms.assetid: c2caaf45-e59c-42a1-bc9b-77a6de520171
caps.latest.revision: 23
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Obtaining UI Automation Elements
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 This topic describes the various ways of obtaining <xref:System.Windows.Automation.AutomationElement> objects for [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)] elements.  
  
> [!CAUTION]
>  If your client application might attempt to find elements in its own user interface, you must make all [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] calls on a separate thread. For more information, see [UI Automation Threading Issues](../../../docs/framework/ui-automation/ui-automation-threading-issues.md).  
  
<a name="The_Root_Element"></a>   
## Root Element  
 All searches for <xref:System.Windows.Automation.AutomationElement> objects must have a starting-place. This can be any element, including the desktop, an application window, or a control.  
  
 The root element for the desktop, from which all elements are descended, is obtained from the static <xref:System.Windows.Automation.AutomationElement.RootElement%2A?displayProperty=nameWithType> property.  
  
> [!CAUTION]
>  In general, you should try to obtain only direct children of the <xref:System.Windows.Automation.AutomationElement.RootElement%2A>. A search for descendants may iterate through hundreds or even thousands of elements, possibly resulting in a stack overflow. If you are attempting to obtain a specific element at a lower level, you should start your search from the application window or from a container at a lower level.  
  
<a name="Using_Conditions"></a>   
## Conditions  
 For most techniques you can use to retrieve [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] elements, you must specify a <xref:System.Windows.Automation.Condition>, which is a set of criteria defining what elements you want to retrieve.  
  
 The simplest condition is <xref:System.Windows.Automation.Condition.TrueCondition>, a predefined object specifying that all elements within the search scope are to be returned. <xref:System.Windows.Automation.Condition.FalseCondition>, the converse of <xref:System.Windows.Automation.Condition.TrueCondition>, is less useful, as it would prevent any elements from being found.  
  
 Three other predefined conditions can be used alone or in combination with other conditions: <xref:System.Windows.Automation.Automation.ContentViewCondition>, <xref:System.Windows.Automation.Automation.ControlViewCondition>, and <xref:System.Windows.Automation.Automation.RawViewCondition>. <xref:System.Windows.Automation.Automation.RawViewCondition>, used by itself, is equivalent to <xref:System.Windows.Automation.Condition.TrueCondition>, because it does not filter elements by their <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.IsControlElement%2A> or <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.IsContentElement%2A> properties.  
  
 Other conditions are built up from one or more <xref:System.Windows.Automation.PropertyCondition> objects, each of which specifies a property value. For example, a <xref:System.Windows.Automation.PropertyCondition> might specify that the element is enabled, or that it supports a certain control pattern.  
  
 Conditions can be combined using Boolean logic by constructing objects of types <xref:System.Windows.Automation.AndCondition>, <xref:System.Windows.Automation.OrCondition>, and <xref:System.Windows.Automation.NotCondition>.  
  
<a name="Search_Scope"></a>   
## Search Scope  
 Searches done by using <xref:System.Windows.Automation.AutomationElement.FindFirst%2A> or <xref:System.Windows.Automation.AutomationElement.FindAll%2A> must have a scope as well as a starting-place.  
  
 The scope defines the space around the starting-place that is to be searched. This might include the element itself, its siblings, its parent, its ancestors, its immediate children, and its descendants.  
  
 The scope of a search is defined by a bitwise combination of values from the <xref:System.Windows.Automation.TreeScope> enumeration.  
  
<a name="Finding_a_Known_Element"></a>   
## Finding a Known Element  
 To find a known element, identified by its <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.Name%2A>, <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.AutomationId%2A>, or some other property or combination of properties, it is easiest to use the <xref:System.Windows.Automation.AutomationElement.FindFirst%2A> method. If the element sought is an application window, the starting-point of the search can be the <xref:System.Windows.Automation.AutomationElement.RootElement%2A>.  
  
 This way of finding [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] elements is most useful in automated testing scenarios.  
  
<a name="Finding_Elements_in_a_Subtree"></a>   
## Finding Elements in a Subtree  
 To find all elements meeting specific criteria that are related to a known element, you can use <xref:System.Windows.Automation.AutomationElement.FindAll%2A>. For example, you could use this method to retrieve list items or menu items from a list or menu, or to identify all controls in a dialog box.  
  
<a name="Walking_a_Subtree"></a>   
## Walking a Subtree  
 If you have no prior knowledge of the applications that your client may be used with, you can construct a subtree of all elements of interest by using the <xref:System.Windows.Automation.TreeWalker> class. Your application might do this in response to a focus-changed event; that is, when an application or control receives input focus, the UI Automation client examines children and perhaps all descendants of the focused element.  
  
 Another way in which <xref:System.Windows.Automation.TreeWalker> can be used is to identify the ancestors of an element. For example, by walking up the tree you can identify the parent window of a control.  
  
 You can use <xref:System.Windows.Automation.TreeWalker> either by creating an object of the class (defining the elements of interest by passing a <xref:System.Windows.Automation.Condition>), or by using one of the following predefined objects that are defined as fields of <xref:System.Windows.Automation.TreeWalker>.  
  
|||  
|-|-|  
|<xref:System.Windows.Automation.TreeWalker.ContentViewWalker>|Finds only elements whose <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.IsContentElement%2A> property is `true`.|  
|<xref:System.Windows.Automation.TreeWalker.ControlViewWalker>|Finds only elements whose <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.IsControlElement%2A> property is `true`.|  
|<xref:System.Windows.Automation.TreeWalker.RawViewWalker>|Finds all elements.|  
  
 After you have obtained a <xref:System.Windows.Automation.TreeWalker>, using it is straightforward. Simply call the `Get` methods to navigate among elements of the subtree.  
  
 The <xref:System.Windows.Automation.TreeWalker.Normalize%2A> method can be used for navigating to an element in the subtree from another element that is not part of the view. For example, suppose you have created a view of a subtree by using <xref:System.Windows.Automation.TreeWalker.ContentViewWalker>. Your application then receives notification that a scroll bar has received the input focus. Because a scroll bar is not a content element, it is not present in your view of the subtree. However, you can pass the <xref:System.Windows.Automation.AutomationElement> representing the scroll bar to <xref:System.Windows.Automation.TreeWalker.Normalize%2A> and retrieve the nearest ancestor that is in the content view.  
  
<a name="Other_Ways_to_Retrieve_an_Element"></a>   
## Other Ways to Retrieve an Element  
 In addition to searches and navigation, you can retrieve an <xref:System.Windows.Automation.AutomationElement> in the following ways.  
  
### From an Event  
 When your application receives a [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] event, the source object passed to your event handler is an <xref:System.Windows.Automation.AutomationElement>. For example, if you have subscribed to focus-changed events, the source passed to your <xref:System.Windows.Automation.AutomationFocusChangedEventHandler> is the element that received the focus.  
  
 For more information, see [Subscribe to UI Automation Events](../../../docs/framework/ui-automation/subscribe-to-ui-automation-events.md).  
  
### From a Point  
 If you have screen coordinates (for example, a cursor position), you can retrieve an <xref:System.Windows.Automation.AutomationElement> by using the static <xref:System.Windows.Automation.AutomationElement.FromPoint%2A> method.  
  
### From a Window Handle  
 To retrieve an <xref:System.Windows.Automation.AutomationElement> from an HWND, use the static <xref:System.Windows.Automation.AutomationElement.FromHandle%2A> method.  
  
### From the Focused Control  
 You can retrieve an <xref:System.Windows.Automation.AutomationElement> that represents the focused control from the static <xref:System.Windows.Automation.AutomationElement.FocusedElement%2A> property.  
  
## See Also  
 [Find a UI Automation Element Based on a Property Condition](../../../docs/framework/ui-automation/find-a-ui-automation-element-based-on-a-property-condition.md)  
 [Navigate Among UI Automation Elements with TreeWalker](../../../docs/framework/ui-automation/navigate-among-ui-automation-elements-with-treewalker.md)  
 [UI Automation Tree Overview](../../../docs/framework/ui-automation/ui-automation-tree-overview.md)
