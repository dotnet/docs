---
title: "Server-Side UI Automation Provider Implementation"
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
  - "server-side UI Automation provider implementation"
  - "UI Automation, server-side provider implementation"
  - "provider implementation, UI Automation"
ms.assetid: 6acc6d08-bd67-4e2e-915c-9c1d34eb86fe
caps.latest.revision: 39
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Server-Side UI Automation Provider Implementation
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 This section describes how to implement a server-side UI Automation provider for a custom control.  
  
 The implementation for [!INCLUDE[TLA#tla_wpf](../../../includes/tlasharptla-wpf-md.md)] elements and non-[!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] elements (such as those designed for [!INCLUDE[TLA#tla_winforms](../../../includes/tlasharptla-winforms-md.md)]) is fundamentally different. [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] elements provide support for [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] through a class derived from <xref:System.Windows.Automation.Peers.AutomationPeer>. Non-[!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] elements provide support through implementations of provider interfaces.  
  
<a name="Security_Considerations"></a>   
## Security Considerations  
 Providers should be written so that they can work in a partial-trust environment. Because UIAutomationClient.dll is not configured to run under partial trust, your provider code should not reference that assembly. If it does so, the code may run in a full-trust environment but then fail in a partial-trust environment.  
  
 In particular, do not use fields from classes in UIAutomationClient.dll such as those in <xref:System.Windows.Automation.AutomationElement>. Instead, use the equivalent fields from classes in UIAutomationTypes.dll, such as <xref:System.Windows.Automation.AutomationElementIdentifiers>.  
  
<a name="Provider_Implementation_by_WPF_Elements"></a>   
## Provider Implementation by Windows Presentation Foundation Elements  
 For more information on this topic, please see [UI Automation of a WPF Custom Control](../../../docs/framework/wpf/controls/ui-automation-of-a-wpf-custom-control.md).  
  
<a name="Provider_Implementation_by_non_WPF_Elements"></a>   
## Provider Implementation by non-WPF Elements  
 Custom controls that are not part of the [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] framework, but that are written in managed code (most often these are [!INCLUDE[TLA#tla_winforms](../../../includes/tlasharptla-winforms-md.md)] controls), provide support for [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] by implementing interfaces. Every element must implement at least one of the interfaces listed in the first table in the next section. In addition, if the element supports one or more control patterns, it must implement the appropriate interface for each control pattern.  
  
 Your [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] provider project must reference the following assemblies:  
  
-   UIAutomationProviders.dll  
  
-   UIAutomationTypes.dll  
  
-   WindowsBase.dll  
  
  
<a name="Provider_Interfaces"></a>   
### Provider Interfaces  
 Every [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] provider must implement one of the following interfaces.  
  
|Interface|Description|  
|---------------|-----------------|  
|<xref:System.Windows.Automation.Provider.IRawElementProviderSimple>|Provides functionality for a simple control hosted in a window, including support for control patterns and properties.|  
|<xref:System.Windows.Automation.Provider.IRawElementProviderFragment>|Inherits from <xref:System.Windows.Automation.Provider.IRawElementProviderSimple>. Adds functionality for an element in a complex control, including navigation within the fragment, setting focus, and returning the bounding rectangle of the element.|  
|<xref:System.Windows.Automation.Provider.IRawElementProviderFragmentRoot>|Inherits from <xref:System.Windows.Automation.Provider.IRawElementProviderFragment>. Adds functionality for the root element in a complex control, including locating a child element at specified coordinates and setting the focus state for the entire control.|  
  
 The following interfaces provide added functionality but are not required to be implemented.  
  
|Interface|Description|  
|---------------|-----------------|  
|<xref:System.Windows.Automation.Provider.IRawElementProviderAdviseEvents>|Enables the provider to track requests for events.|  
|<xref:System.Windows.Automation.Provider.IRawElementProviderHwndOverride>|Enables repositioning of window-based elements within the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree of a fragment.|  
  
 All other interfaces in the <xref:System.Windows.Automation.Provider> namespace are for control pattern support.  
  
<a name="Requirements_for_Non_WPF_Providers"></a>   
### Requirements for Non-WPF Providers  
 In order to communicate with [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], your control must implement the following main areas of functionality:  
  
|Functionality|Implementation|  
|-------------------|--------------------|  
|Expose the provider to [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)]|In response to a WM_GETOBJECT message sent to the control window, return the object that implements <xref:System.Windows.Automation.Provider.IRawElementProviderSimple> (or a derived interface). For fragments, this must be the provider for the fragment root.|  
|Provide property values|Implement <xref:System.Windows.Automation.Provider.IRawElementProviderSimple.GetPropertyValue%2A> to provide or override values.|  
|Enable the client to interact with the control|Implement interfaces that support control patterns, such as <xref:System.Windows.Automation.Provider.IInvokeProvider>. Return these pattern providers in your implementation of <xref:System.Windows.Automation.Provider.IRawElementProviderSimple.GetPatternProvider%2A>.|  
|Raise events|Call one of the static methods of <xref:System.Windows.Automation.Provider.AutomationInteropProvider> to raise an event that a client can listen for.|  
|Enable navigation and focusing within a fragment|Implement <xref:System.Windows.Automation.Provider.IRawElementProviderFragment> for each element within the fragment. (Not necessary for elements that are not part of a fragment.)|  
|Enable focusing and location of child element in a fragment|Implement <xref:System.Windows.Automation.Provider.IRawElementProviderFragmentRoot>. (Not necessary for elements that are not fragment roots.)|  
  
<a name="Property_Values_in_Non_WPF_Providers"></a>   
### Property Values in Non-WPF Providers  
 [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] providers for custom controls must support certain properties that can be used by the automation system as well as by client applications. For elements that are hosted in windows (HWNDs), [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] can retrieve some properties from the default window provider, but must obtain others from the custom provider.  
  
 Providers for HWND based controls do not usually need to provide the following properties (identified by field values):  
  
-   <xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>  
  
-   <xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>  
  
-   <xref:System.Windows.Automation.AutomationElementIdentifiers.ProcessIdProperty>  
  
-   <xref:System.Windows.Automation.AutomationElementIdentifiers.ClassNameProperty>  
  
-   <xref:System.Windows.Automation.AutomationElementIdentifiers.HasKeyboardFocusProperty>  
  
-   <xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty>  
  
-   <xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>  
  
-   <xref:System.Windows.Automation.AutomationElementIdentifiers.IsPasswordProperty>  
  
-   <xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>  
  
-   <xref:System.Windows.Automation.AutomationElementIdentifiers.RuntimeIdProperty>  
  
> [!NOTE]
>  The <xref:System.Windows.Automation.AutomationElementIdentifiers.RuntimeIdProperty> of a simple element or fragment root hosted in a window is obtained from the window; however, fragment elements below the root (such as list items in a list box) must provide their own identifiers. For more information, see <xref:System.Windows.Automation.Provider.IRawElementProviderFragment.GetRuntimeId%2A>.  
>   
>  The <xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty> should be returned for providers hosted in a [!INCLUDE[TLA#tla_winforms](../../../includes/tlasharptla-winforms-md.md)] control. In this case, the default window provider may be unable to retrieve the correct value.  
>   
>  The <xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty> is usually supplied by the host provider. For example, if a custom control is derived from <xref:System.Windows.Forms.Control>, the name is derived from the `Text` property of the control.  
  
 For example code, see [Return Properties from a UI Automation Provider](../../../docs/framework/ui-automation/return-properties-from-a-ui-automation-provider.md).  
  
<a name="Events_in_Non_WPF_Providers"></a>   
### Events in Non-WPF Providers  
 [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] providers should raise events to notify client applications of changes in the state of the UI. The following methods are used to raise events.  
  
|Method|Description|  
|------------|-----------------|  
|<xref:System.Windows.Automation.Provider.AutomationInteropProvider.RaiseAutomationEvent%2A>|Raises various events, including events triggered by control patterns.|  
|<xref:System.Windows.Automation.Provider.AutomationInteropProvider.RaiseAutomationPropertyChangedEvent%2A>|Raises an event when a [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] property has changed.|  
|<xref:System.Windows.Automation.Provider.AutomationInteropProvider.RaiseStructureChangedEvent%2A>|Raises an event when the structure of the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree has changed; for example, by the removal or addition of an element.|  
  
 The purpose of an event is to notify the client of something taking place in the [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)], whether or not the activity is triggered by the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] system itself. For example, the event identified by <xref:System.Windows.Automation.InvokePatternIdentifiers.InvokedEvent> should be raised whenever the control is invoked, either through direct user input or by the client application calling <xref:System.Windows.Automation.InvokePattern.Invoke%2A>.  
  
 To optimize performance, a provider can selectively raise events, or raise no events at all if no client application is registered to receive them. The following methods are used for optimization.  
  
|Method|Description|  
|------------|-----------------|  
|<xref:System.Windows.Automation.Provider.AutomationInteropProvider.ClientsAreListening%2A>|This static property specifies whether any client applications have subscribed to [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] events.|  
|<xref:System.Windows.Automation.Provider.IRawElementProviderAdviseEvents>|The provider's implementation of this interface on a fragment root enables it to be advised when clients register and unregister event handlers for events on the fragment.|  
  
<a name="Non_WPF_Provider_Navigation"></a>   
### Non-WPF Provider Navigation  
 Providers for simple controls such as a custom button hosted in a window (HWND) do not need to support navigation within the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree. Navigation to and from the element is handled by the default provider for the host window, which is specified in the implementation of <xref:System.Windows.Automation.Provider.IRawElementProviderSimple.HostRawElementProvider%2A>. When you implement a provider for a complex custom control, however, you must support navigation between the root node of the fragment and its descendants, and between sibling nodes.  
  
> [!NOTE]
>  Elements of a fragment other than the root must return a `null` reference  from <xref:System.Windows.Automation.Provider.IRawElementProviderSimple.HostRawElementProvider%2A>, because they are not directly hosted in a window, and no default provider can support navigation to and from them.  
  
 The structure of the fragment is determined by your implementation of <xref:System.Windows.Automation.Provider.IRawElementProviderFragment.Navigate%2A>. For each possible direction from each fragment, this method returns the provider object for the element in that direction. If there is no element in that direction, the method returns a `null` reference.  
  
 The fragment root supports navigation only to child elements. For example, a list box returns the first item in the list when the direction is <xref:System.Windows.Automation.Provider.NavigateDirection.FirstChild>, and the last item when the direction is <xref:System.Windows.Automation.Provider.NavigateDirection.LastChild>. The fragment root does not support navigation to a parent or siblings; this is handled by the host window provider.  
  
 Elements of a fragment that are not the root must support navigation to the parent, and to any siblings and children they have.  
  
<a name="Non_WPF_Provider_Reparenting"></a>   
### Non-WPF Provider Reparenting  
 Pop-up windows are actually top-level windows, and so by default appear in the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree as children of the desktop. In many cases, however, pop-up windows are logically children of some other control. For example, the drop-down list of a combo box is logically a child of the combo box. Similarly, a menu pop-up window is logically a child of the menu. [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] provides support to reparent pop-up windows so that they appear to be children of the associated control.  
  
 To reparent a pop-up window:  
  
1.  Create a provider for the pop-up window. This requires that the class of the pop-up window is known in advance.  
  
2.  Implement all properties and patterns as usual for that pop-up, as though it were a control in its own right.  
  
3.  Implement the <xref:System.Windows.Automation.Provider.IRawElementProviderSimple.HostRawElementProvider%2A> property so that it returns the value obtained from <xref:System.Windows.Automation.Provider.AutomationInteropProvider.HostProviderFromHandle%2A>, where the parameter is the window handle of the pop-up window.  
  
4.  Implement <xref:System.Windows.Automation.Provider.IRawElementProviderFragment.Navigate%2A> for the pop-up window and its parent so that navigation is handled properly from the logical parent to the logical children, and between sibling children.  
  
 When [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] encounters the pop-up window, it recognizes that navigation is being overridden from the default, and skips over the pop-up window when it is encountered as a child of the desktop. Instead, the node will only be reachable through the fragment.  
  
 Reparenting is not suitable for cases where a control can host a window of any class. For example, a rebar can host any type of HWND in its bands. To handle these cases, [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] supports an alternative form of HWND relocation, as described in the next section.  
  
<a name="Non_WPF_Provider_Repositioning"></a>   
### Non-WPF Provider Repositioning  
 [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] fragments may contain two or more elements that are each contained in a window (HWND). Because each HWND has its own default provider that considers the HWND to be a child of a containing HWND, the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree will, by default, show the HWNDs in the fragment as children of the parent window. In most cases this is desirable behavior, but sometimes it can lead to confusion because it does not match the logical structure of the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)].  
  
 A good example of this is a rebar control. A rebar contains bands, each of which can in turn contain an HWND-based control such as a toolbar, an edit box, or a combo box. The default window provider for the rebar HWND sees the band control HWNDs as children, and the rebar provider sees the bands as children. Because the HWND provider and the rebar provider are working in tandem and combining their children, both the bands and the HWND-based controls appear as children of the rebar. Logically, however, only the bands should appear as children of the rebar, and each band provider should be coupled with the default HWND provider for the control it contains.  
  
 To accomplish this, the fragment root provider for the rebar exposes a set of children representing the bands. Each band has a single provider that may expose properties and patterns. In its implementation of <xref:System.Windows.Automation.Provider.IRawElementProviderSimple.HostRawElementProvider%2A>, the band provider returns the default window provider for the control HWND, which it obtains by calling <xref:System.Windows.Automation.Provider.AutomationInteropProvider.HostProviderFromHandle%2A>, passing in the control's window handle. Finally, the fragment root provider for the rebar implements the <xref:System.Windows.Automation.Provider.IRawElementProviderHwndOverride> interface, and in its implementation of <xref:System.Windows.Automation.Provider.IRawElementProviderHwndOverride.GetOverrideProviderForHwnd%2A> it returns the appropriate band provider for the control contained in the specified HWND.  
  
## See Also  
 [UI Automation Providers Overview](../../../docs/framework/ui-automation/ui-automation-providers-overview.md)  
 [Expose a Server-side UI Automation Provider](../../../docs/framework/ui-automation/expose-a-server-side-ui-automation-provider.md)  
 [Return Properties from a UI Automation Provider](../../../docs/framework/ui-automation/return-properties-from-a-ui-automation-provider.md)  
 [Raise Events from a UI Automation Provider](../../../docs/framework/ui-automation/raise-events-from-a-ui-automation-provider.md)  
 [Enable Navigation in a UI Automation Fragment Provider](../../../docs/framework/ui-automation/enable-navigation-in-a-ui-automation-fragment-provider.md)  
 [Support Control Patterns in a UI Automation Provider](../../../docs/framework/ui-automation/support-control-patterns-in-a-ui-automation-provider.md)  
 [Simple Provider Sample](http://msdn.microsoft.com/library/c10a6255-e8dc-494b-a051-15111b47984a)  
 [Fragment Provider Sample](http://msdn.microsoft.com/library/778ef1bc-8610-4bc9-886e-aeff94a8a13e)
