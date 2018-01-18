---
title: "UI Automation Overview"
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
  - "UI Automation, overview"
  - "user interface, see UI"
  - "accessibility, UI automation"
ms.assetid: 65847654-9994-4a9e-b36d-2dd5d998770b
caps.latest.revision: 35
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# UI Automation Overview
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 [!INCLUDE[TLA#tla_uiautomation](../../../includes/tlasharptla-uiautomation-md.md)] is the new accessibility framework for [!INCLUDE[TLA#tla_win](../../../includes/tlasharptla-win-md.md)], available on all operating systems that support [!INCLUDE[TLA#tla_winclient](../../../includes/tlasharptla-winclient-md.md)].  
  
 [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] provides programmatic access to most [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)] elements on the desktop, enabling assistive technology products such as screen readers to provide information about the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] to end users and to manipulate the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] by means other than standard input. [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] also allows automated test scripts to interact with the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)].  
  
> [!NOTE]
>  [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] does not enable communication between processes started by different users through the **Run as** command.  
  
 UI Automation client applications can be written with the assurance that they will work on multiple frameworks. The [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] core masks any differences in the frameworks that underlie various pieces of [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)]. For example, the `Content` property of a [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] button, the `Caption` property of a [!INCLUDE[TLA2#tla_win32](../../../includes/tla2sharptla-win32-md.md)] button, and the `ALT` property of an HTML image are all mapped to a single property, <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.Name%2A>, in the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] view.  
  
 [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] provides full functionality in [!INCLUDE[TLA#tla_longhorn](../../../includes/tlasharptla-longhorn-md.md)], [!INCLUDE[TLA#tla_winxp](../../../includes/tlasharptla-winxp-md.md)], and [!INCLUDE[TLA2#tla_winnetsvrfam](../../../includes/tla2sharptla-winnetsvrfam-md.md)].  
  
 UI Automation providers offer some support for [!INCLUDE[TLA#tla_aa](../../../includes/tlasharptla-aa-md.md)] client applications, through a built-in bridging service.  
  
<a name="Providers_and_Clients"></a>   
## Providers and Clients  
 [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] has four main components, as shown in the following table.  
  
|Component|Description|  
|---------------|-----------------|  
|Provider [!INCLUDE[TLA#tla_api](../../../includes/tlasharptla-api-md.md)] (UIAutomationProvider.dll and UIAutomationTypes.dll)|A set of interface definitions that are implemented by UI Automation providers, objects that provide information about [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] elements and respond to programmatic input.|  
|Client API (UIAutomationClient.dll and UIAutomationTypes.dll)|A set of types for managed code that enables UI Automation client applications to obtain information about the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] and to send input to controls.|  
|UiAutomationCore.dll|The underlying code (sometimes called the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] core) that handles communication between providers and clients.|  
|UIAutomationClientsideProviders.dll|A set of UI Automation providers for standard legacy controls. ([!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] controls have native support for [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)].) This support is automatically available to client applications.|  
  
 From the software developer's perspective, there are two ways of using [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)]: to create support for custom controls (using the provider API), and creating applications that use the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] core to communicate with [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] elements (using the client API). Depending on your focus, you should refer to different parts of the documentation. You can learn more about the concepts and gain practical how-to knowledge in the following sections.  
  
|Section|Subject matter|Audience|  
|-------------|--------------------|--------------|  
|[UI Automation Fundamentals](../../../docs/framework/ui-automation/index.md) (this section)|Broad overviews of the concepts.|All.|  
|[UI Automation Providers for Managed Code](../../../docs/framework/ui-automation/ui-automation-providers-for-managed-code.md)|Overviews and how-to topics to help you use the provider API.|Control developers.|  
|[UI Automation Clients for Managed Code](../../../docs/framework/ui-automation/ui-automation-clients-for-managed-code.md)|Overviews and how-to topics to help you use the client API.|Client application developers.|  
|[UI Automation Control Patterns](../../../docs/framework/ui-automation/ui-automation-control-patterns.md)|Information about how control patterns should be implemented by providers, and what functionality is available to clients.|All.|  
|[UI Automation Text Pattern](../../../docs/framework/ui-automation/ui-automation-text-pattern.md)|Information about how the Text control pattern should be implemented by providers, and what functionality is available to clients.|All.|  
|[UI Automation Control Types](../../../docs/framework/ui-automation/ui-automation-control-types.md)|Information about the properties and control patterns supported by different control types.|All.|  
  
 The following table lists [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] namespaces, the DLLs that contain them, and the audience that uses them.  
  
|Namespace|Referenced DLLs|Audience|  
|---------------|---------------------|--------------|  
|<xref:System.Windows.Automation>|UIAutomationClientUIAutomationTypes|UI Automation client developers; used to find <xref:System.Windows.Automation.AutomationElement> objects, register for [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] events, and work with [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] control patterns.|  
|<xref:System.Windows.Automation.Provider>|UIAutomationProviderUIAutomationTypes|Developers of UI Automation providers for frameworks other than [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)].|  
|<xref:System.Windows.Automation.Text>|UIAutomationClientUIAutomationTypes|Developers of UI Automation providers for frameworks other than [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)]; used to implement the TextPattern control pattern.|  
|<xref:System.Windows.Automation.Peers>|PresentationFramework|Developers of UI Automation providers for [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)].|  
  
<a name="UI_Automation_Model"></a>   
## UI Automation Model  
 [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] exposes every piece of the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] to client applications as an <xref:System.Windows.Automation.AutomationElement>. Elements are contained in a tree structure, with the desktop as the root element. Clients can filter the raw view of the tree as a control view or a content view. Applications can also create custom views.  
  
 <xref:System.Windows.Automation.AutomationElement> objects expose common properties of the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] elements they represent. One of these properties is the control type, which defines its basic appearance and functionality as a single recognizable entity: for example, a button or check box.  
  
 In addition, elements expose control patterns that provide properties specific to their control types. Control patterns also expose methods that enable clients to get further information about the element and to provide input.  
  
> [!NOTE]
>  There is not a one-to-one correspondence between control types and control patterns. A control pattern may be supported by multiple control types, and a control may support multiple control patterns, each of which exposes different aspects of its behavior. For example, a combo box has at least two control patterns: one that represents its ability to expand and collapse, and another that represents the selection mechanism. For specifics, see [UI Automation Control Types](../../../docs/framework/ui-automation/ui-automation-control-types.md).  
  
 [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] also provides information to client applications through events. Unlike [!INCLUDE[TLA2#tla_winevents](../../../includes/tla2sharptla-winevents-md.md)], [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] events are not based on a broadcast mechanism. [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] clients register for specific event notifications and can request that specific [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] properties and control pattern information be passed into their event handlers. In addition, a [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] event contains a reference to the element that raised it. Providers can improve performance by raising events selectively, depending on whether any clients are listening.  
  
## See Also  
 [UI Automation Tree Overview](../../../docs/framework/ui-automation/ui-automation-tree-overview.md)  
 [UI Automation Control Patterns Overview](../../../docs/framework/ui-automation/ui-automation-control-patterns-overview.md)  
 [UI Automation Properties Overview](../../../docs/framework/ui-automation/ui-automation-properties-overview.md)  
 [UI Automation Events Overview](../../../docs/framework/ui-automation/ui-automation-events-overview.md)  
 [UI Automation Security Overview](../../../docs/framework/ui-automation/ui-automation-security-overview.md)
