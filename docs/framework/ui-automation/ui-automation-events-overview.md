---
title: "UI Automation Events Overview"
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
  - "UI Automation, events"
  - "clients, UI Automation"
  - "events, UI Automation"
  - "providers, UI Automation"
  - "UI Automation, clients"
ms.assetid: 69eebd8b-39ed-40e7-93cc-4457c4caf746
caps.latest.revision: 22
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# UI Automation Events Overview
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 [!INCLUDE[TLA#tla_uiautomation](../../../includes/tlasharptla-uiautomation-md.md)] event notification is a key feature for assistive technologies such as screen readers and screen magnifiers. These UI Automation clients track events that are raised by UI Automation providers when something happens in the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] and use the information to notify end users.  
  
 Efficiency is improved by allowing provider applications to raise events selectively, depending on whether any clients are subscribed to those events, or not at all, if no clients are listening for any events.  
  
<a name="Types_of_Events"></a>   
## Types of Events  
 [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] events fall into the following categories.  
  
|Event|Description|  
|-----------|-----------------|  
|Property change|Raised when a property on an [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] element or control pattern changes. For example, if a client needs to monitor an application's check box control, it can register to listen for a property change event on the <xref:System.Windows.Automation.TogglePattern.TogglePatternInformation.ToggleState%2A> property. When the check box control is checked or unchecked, the provider raises the event and the client can act as necessary.|  
|Element action|Raised when a change in the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] results from end user or programmatic activity; for example, when a button is clicked or invoked through <xref:System.Windows.Automation.InvokePattern>.|  
|Structure change|Raised when the structure of the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree changes. The structure changes when new [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] items become visible, hidden, or removed on the desktop.|  
|Global desktop change|Raised when actions of global interest to the client occur, such as when the focus shifts from one element to another, or when a window closes.|  
  
 Some events do not necessarily mean that the state of the UI has changed. For example, if the user tabs to a text entry field and then clicks a button to update the field, a `TextChangedEvent` is raised even if the user did not actually change the text. When processing an event, it may be necessary for a client application to check whether anything has actually changed before taking action.  
  
 The following events may be raised even when the state of the UI has not changed.  
  
-   `AutomationPropertyChangedEvent` (depending on the property that has changed)  
  
-   `ElementSelectedEvent`  
  
-   `InvalidatedEvent`  
  
-   `TextChangedEvent`  
  
<a name="UI_Automation_Event_Identifiers"></a>   
## UI Automation Event Identifiers  
 [!INCLUDE[TLA#tla_uiautomation](../../../includes/tlasharptla-uiautomation-md.md)] events are identified by <xref:System.Windows.Automation.AutomationEvent> objects. The <xref:System.Windows.Automation.AutomationIdentifier.Id%2A> property contains a value that uniquely identifies the kind of event.  
  
 The possible values for <xref:System.Windows.Automation.AutomationIdentifier.Id%2A> are given in the following table, along with the type used for event arguments. Note that the identifiers used by clients and providers are identically named fields from different classes.  
  
|Client Identifier|Provider identifier|Event Arguments Type|  
|-----------------------|-------------------------|--------------------------|  
|<xref:System.Windows.Automation.AutomationElement.AsyncContentLoadedEvent?displayProperty=nameWithType>|<xref:System.Windows.Automation.AutomationElementIdentifiers.AsyncContentLoadedEvent?displayProperty=nameWithType>|<xref:System.Windows.Automation.AsyncContentLoadedEventArgs>|  
|<xref:System.Windows.Automation.SelectionItemPattern.ElementAddedToSelectionEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.SelectionItemPattern.ElementRemovedFromSelectionEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.SelectionItemPattern.ElementSelectedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.SelectionPattern.InvalidatedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.InvokePattern.InvokedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.AutomationElement.LayoutInvalidatedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.AutomationElement.MenuClosedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.AutomationElement.MenuOpenedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.TextPattern.TextChangedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.TextPattern.TextSelectionChangedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.AutomationElement.ToolTipClosedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.AutomationElement.ToolTipOpenedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.WindowPattern.WindowOpenedEvent?displayProperty=nameWithType>|<xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementAddedToSelectionEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementRemovedFromSelectionEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementSelectedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.SelectionPatternIdentifiers.InvalidatedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.InvokePatternIdentifiers.InvokedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.AutomationElementIdentifiers.LayoutInvalidatedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.AutomationElementIdentifiers.MenuClosedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.AutomationElementIdentifiers.MenuOpenedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.TextPatternIdentifiers.TextChangedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.TextPatternIdentifiers.TextSelectionChangedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.AutomationElementIdentifiers.ToolTipClosedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.AutomationElementIdentifiers.ToolTipOpenedEvent?displayProperty=nameWithType><br /><br /> <xref:System.Windows.Automation.WindowPatternIdentifiers.WindowOpenedEvent?displayProperty=nameWithType>|<xref:System.Windows.Automation.AutomationEventArgs>|  
|<xref:System.Windows.Automation.AutomationElement.AutomationFocusChangedEvent?displayProperty=nameWithType>|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent?displayProperty=nameWithType>|<xref:System.Windows.Automation.AutomationFocusChangedEventArgs>|  
|<xref:System.Windows.Automation.AutomationElement.AutomationPropertyChangedEvent?displayProperty=nameWithType>|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationPropertyChangedEvent?displayProperty=nameWithType>|<xref:System.Windows.Automation.AutomationPropertyChangedEventArgs>|  
|<xref:System.Windows.Automation.AutomationElement.StructureChangedEvent?displayProperty=nameWithType>|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent?displayProperty=nameWithType>|<xref:System.Windows.Automation.StructureChangedEventArgs>|  
|<xref:System.Windows.Automation.WindowPattern.WindowClosedEvent?displayProperty=nameWithType>|<xref:System.Windows.Automation.WindowPatternIdentifiers.WindowClosedEvent?displayProperty=nameWithType>|<xref:System.Windows.Automation.WindowClosedEventArgs>|  
  
<a name="UI_Automation_Event_Arguments"></a>   
## UI Automation Event Arguments  
 The following classes encapsulate event arguments.  
  
|Class|Description|  
|-----------|-----------------|  
|<xref:System.Windows.Automation.AsyncContentLoadedEventArgs>|Contains information about the asynchronous loading of content, including the percentage of loading completed.|  
|<xref:System.Windows.Automation.AutomationEventArgs>|Contains information about a simple event that requires no extra data.|  
|<xref:System.Windows.Automation.AutomationFocusChangedEventArgs>|Contains information about a change in input focus from one element to another. Events of this type are raised by the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] system, not by providers.|  
|<xref:System.Windows.Automation.AutomationPropertyChangedEventArgs>|Contains information about a change in a property value of an element or control pattern.|  
|<xref:System.Windows.Automation.StructureChangedEventArgs>|Contains information about a change in the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree.|  
|<xref:System.Windows.Automation.WindowClosedEventArgs>|Contains information about a window closing.|  
  
 All the event argument classes contain an <xref:System.Windows.Automation.AutomationEventArgs.EventId%2A> member. This identifier is encapsulated in an <xref:System.Windows.Automation.AutomationEvent>.  
  
 The <xref:System.Windows.Automation.AutomationEvent> objects used to identify events are obtained by providers from fields in <xref:System.Windows.Automation.AutomationElementIdentifiers> and control pattern identifier classes such as <xref:System.Windows.Automation.DockPatternIdentifiers>. The equivalent fields are obtained by client applications from fields in <xref:System.Windows.Automation.AutomationElement> and control pattern classes such as <xref:System.Windows.Automation.DockPattern>.  
  
 For a list of event identifiers, see [UI Automation Events for Clients](../../../docs/framework/ui-automation/ui-automation-events-for-clients.md).  
  
## See Also  
 [UI Automation Events for Clients](../../../docs/framework/ui-automation/ui-automation-events-for-clients.md)  
 [Server-Side UI Automation Provider Implementation](../../../docs/framework/ui-automation/server-side-ui-automation-provider-implementation.md)  
 [Subscribe to UI Automation Events](../../../docs/framework/ui-automation/subscribe-to-ui-automation-events.md)
