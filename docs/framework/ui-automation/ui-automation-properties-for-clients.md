---
title: "UI Automation Properties for Clients"
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
  - "properties, UI Automation clients"
  - "UI Automation, client properties"
ms.assetid: 255905af-0b17-485c-93d4-8a2db2a6524b
caps.latest.revision: 17
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# UI Automation Properties for Clients
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 This overview introduces you to [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] properties as they are exposed to UI Automation client applications.  
  
 Properties on <xref:System.Windows.Automation.AutomationElement> objects contain information about [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)] elements, usually controls. The properties of an <xref:System.Windows.Automation.AutomationElement> are generic; that is, not specific to a control type. Many of these properties are exposed in the <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation> structure.  
  
 Control patterns also have properties. The properties of control patterns are specific to the pattern. For example, <xref:System.Windows.Automation.ScrollPattern> has properties that enable a client application to discover whether a window is vertically or horizontally scrollable, and what the current view sizes and scroll positions are. Control patterns expose all their properties through a structure; for example, <xref:System.Windows.Automation.ScrollPattern.ScrollPatternInformation>.  
  
 [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] properties are read-only. To set properties of a control, you must use the methods of the appropriate control pattern. For example, use <xref:System.Windows.Automation.ScrollPattern.Scroll%2A> to change the position values of a scrolling window.  
  
 To improve performance, property values of controls and control patterns can be cached when <xref:System.Windows.Automation.AutomationElement> objects are retrieved. For more information, see [Caching in UI Automation Clients](../../../docs/framework/ui-automation/caching-in-ui-automation-clients.md).  
  
<a name="Property_IDs"></a>   
## Property IDs  
 Property [!INCLUDE[TLA#tla_id#plural](../../../includes/tlasharptla-idsharpplural-md.md)] are unique, constant values that are encapsulated in <xref:System.Windows.Automation.AutomationProperty> objects. UI Automation client applications get these [!INCLUDE[TLA2#tla_id#plural](../../../includes/tla2sharptla-idsharpplural-md.md)] from the <xref:System.Windows.Automation.AutomationElement> class or from the appropriate control pattern class, such as <xref:System.Windows.Automation.ScrollPattern>. UI Automation providers get them from <xref:System.Windows.Automation.AutomationElementIdentifiers> or from one of the control pattern identifiers classes, such as <xref:System.Windows.Automation.ScrollPatternIdentifiers>.  
  
 The numeric <xref:System.Windows.Automation.AutomationIdentifier.Id%2A> of an <xref:System.Windows.Automation.AutomationProperty> is used by providers to identify properties that are being queried for in the <xref:System.Windows.Automation.Provider.IRawElementProviderSimple.GetPropertyValue%2A?displayProperty=nameWithType> method. In general, client applications do not need to examine the <xref:System.Windows.Automation.AutomationIdentifier.Id%2A>. The <xref:System.Windows.Automation.AutomationIdentifier.ProgrammaticName%2A> is used only for debugging and diagnostic purposes.  
  
<a name="Property_Conditions"></a>   
## Property Conditions  
 The property [!INCLUDE[TLA2#tla_id#plural](../../../includes/tla2sharptla-idsharpplural-md.md)] are used in constructing <xref:System.Windows.Automation.PropertyCondition> objects used to find <xref:System.Windows.Automation.AutomationElement> objects. For example, you might wish to find an <xref:System.Windows.Automation.AutomationElement> that has a certain name, or all controls that are enabled. Each <xref:System.Windows.Automation.PropertyCondition> specifies an <xref:System.Windows.Automation.AutomationProperty> identifier and the value that the property must match.  
  
 For more information, see the following reference topics:  
  
-   <xref:System.Windows.Automation.AutomationElement.FindFirst%2A>  
  
-   <xref:System.Windows.Automation.AutomationElement.FindAll%2A>  
  
-   <xref:System.Windows.Automation.TreeWalker.Condition%2A>  
  
<a name="Retrieving_Properties"></a>   
## Retrieving Properties  
 Some properties of <xref:System.Windows.Automation.AutomationElement> and all properties of a control pattern class are exposed as nested properties of the `Current` or `Cached` property of the <xref:System.Windows.Automation.AutomationElement> or control pattern object.  
  
 In addition, any <xref:System.Windows.Automation.AutomationElement> or control pattern property, including a property that is not available in the <xref:System.Windows.Automation.AutomationElement.Cached%2A> or <xref:System.Windows.Automation.AutomationElement.Current%2A> structure, can be retrieved by using one of the following methods:  
  
-   <xref:System.Windows.Automation.AutomationElement.GetCachedPropertyValue%2A>  
  
-   <xref:System.Windows.Automation.AutomationElement.GetCurrentPropertyValue%2A>  
  
 These methods offer slightly better performance as well as access to the full range of properties.  
  
 The following code example shows the two ways of retrieving a property on an <xref:System.Windows.Automation.AutomationElement>.  
  
 [!code-csharp[UIAClient_snip#121](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAClient_snip/CSharp/ClientForm.cs#121)]
 [!code-vb[UIAClient_snip#121](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAClient_snip/VisualBasic/ClientForm.vb#121)]  
  
 To retrieve properties of control patterns supported by the <xref:System.Windows.Automation.AutomationElement>, you do not need to retrieve the control pattern object. Simply pass one of the pattern property identifiers to the method.  
  
 The following code example shows the two ways of retrieving a property on a control pattern.  
  
 [!code-csharp[UIAClient_snip#122](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAClient_snip/CSharp/ClientForm.cs#122)]
 [!code-vb[UIAClient_snip#122](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAClient_snip/VisualBasic/ClientForm.vb#122)]  
  
 The `Get` methods return an <xref:System.Object>. The application must cast the returned object to the proper type before using the value.  
  
<a name="_Default_Property_Values"></a>   
## Default Property Values  
 If a UI Automation provider does not implement a property, the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] system is able to supply a default value. For example, if the provider for a control does not support the property identified by <xref:System.Windows.Automation.AutomationElement.HelpTextProperty>, [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] returns an empty string. Similarly, if the provider does not support the property identified by <xref:System.Windows.Automation.AutomationElement.IsDockPatternAvailableProperty>, [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] returns `false`.  
  
 You can change this behavior by using the <xref:System.Windows.Automation.AutomationElement.GetCachedPropertyValue%2A?displayProperty=nameWithType> and <xref:System.Windows.Automation.AutomationElement.GetCurrentPropertyValue%2A?displayProperty=nameWithType> method overloads. When you specify `true` as the second parameter, [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] does not return a default value, but instead returns the special value <xref:System.Windows.Automation.AutomationElement.NotSupported>.  
  
 The following example code attempts to retrieve a property from an element, and if the property is not supported, an application-defined value is used instead.  
  
 [!code-csharp[UIAClient_snip#123](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAClient_snip/CSharp/ClientForm.cs#123)]
 [!code-vb[UIAClient_snip#123](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAClient_snip/VisualBasic/ClientForm.vb#123)]  
  
 To discover what properties are supported by an element, use <xref:System.Windows.Automation.AutomationElement.GetSupportedProperties%2A>. This returns an array of <xref:System.Windows.Automation.AutomationProperty> identifiers.  
  
<a name="Property_changed_Events"></a>   
## Property-changed Events  
 When a property value on an <xref:System.Windows.Automation.AutomationElement> or control pattern changes, an event is raised. An application can subscribe to such events by calling <xref:System.Windows.Automation.Automation.AddAutomationPropertyChangedEventHandler%2A>, supplying an array of <xref:System.Windows.Automation.AutomationProperty> identifiers as the last parameter in order to specify the properties of interest.  
  
 In the <xref:System.Windows.Automation.AutomationPropertyChangedEventHandler>, you can identify the property that has changed by checking the <xref:System.Windows.Automation.AutomationPropertyChangedEventArgs.Property%2A> member of the event arguments. The arguments also contain the old and new values of the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] property that has changed. These values are of type <xref:System.Object> and must be cast to the correct type before being used.  
  
<a name="Additional_AutomationElement_Properties"></a>   
## Additional AutomationElement Properties  
 In addition to the <xref:System.Windows.Automation.AutomationElement.Current%2A> and <xref:System.Windows.Automation.AutomationElement.Cached%2A> property structures, <xref:System.Windows.Automation.AutomationElement> has the following properties, which are retrieved through simple property accessors.  
  
|Property|Description|  
|--------------|-----------------|  
|<xref:System.Windows.Automation.AutomationElement.CachedChildren%2A>|A collection of child <xref:System.Windows.Automation.AutomationElement> objects that are in the cache.|  
|<xref:System.Windows.Automation.AutomationElement.CachedParent%2A>|An <xref:System.Windows.Automation.AutomationElement> parent object that is in the cache.|  
|<xref:System.Windows.Automation.AutomationElement.FocusedElement%2A>|(Static property) The <xref:System.Windows.Automation.AutomationElement> that has the input focus.|  
|<xref:System.Windows.Automation.AutomationElement.RootElement%2A>|(Static property) The root <xref:System.Windows.Automation.AutomationElement>.|  
  
## See Also  
 [Caching in UI Automation Clients](../../../docs/framework/ui-automation/caching-in-ui-automation-clients.md)  
 [Server-Side UI Automation Provider Implementation](../../../docs/framework/ui-automation/server-side-ui-automation-provider-implementation.md)  
 [Subscribe to UI Automation Events](../../../docs/framework/ui-automation/subscribe-to-ui-automation-events.md)
