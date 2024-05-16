---
title: "UI Automation Overview"
description: Read an overview of Microsoft UI Automation, the accessibility framework for Windows operating systems that support Windows Presentation Foundation (WPF).
ms.date: "03/30/2017"
helpviewer_keywords:
  - "UI Automation, overview"
  - "user interface, see UI"
  - "accessibility, UI automation"
ms.assetid: 65847654-9994-4a9e-b36d-2dd5d998770b
---
# UI Automation Overview

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 Microsoft UI Automation is the new accessibility framework for Microsoft Windows, available on all operating systems that support Windows Presentation Foundation (WPF).

 UI Automation provides programmatic access to most user interface (UI) elements on the desktop, enabling assistive technology products such as screen readers to provide information about the UI to end users and to manipulate the UI by means other than standard input. UI Automation also allows automated test scripts to interact with the UI.

> [!NOTE]
> UI Automation does not enable communication between processes started by different users through the **Run as** command.

 UI Automation client applications can be written with the assurance that they will work on multiple frameworks. The UI Automation core masks any differences in the frameworks that underlie various pieces of UI. For example, the `Content` property of a WPF button, the `Caption` property of a Win32 button, and the `ALT` property of an HTML image are all mapped to a single property, <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.Name%2A>, in the UI Automation view.

UI Automation provides full functionality on supported Windows operating systems running the .NET Framework (see [.NET Framework system requirements](../get-started/system-requirements.md) or versions of .NET Core starting with .NET Core 3.0.

 UI Automation providers offer some support for Microsoft Active Accessibility client applications through a built-in bridging service.

<a name="Providers_and_Clients"></a>

## Providers and Clients

 UI Automation has four main components, as shown in the following table.

|Component|Description|
|---------------|-----------------|
|Provider API (UIAutomationProvider.dll and UIAutomationTypes.dll)|A set of interface definitions that are implemented by UI Automation providers, objects that provide information about UI elements and respond to programmatic input.|
|Client API (UIAutomationClient.dll and UIAutomationTypes.dll)|A set of types for managed code that enables UI Automation client applications to obtain information about the UI and to send input to controls.|
|UiAutomationCore.dll|The underlying code (sometimes called the UI Automation core) that handles communication between providers and clients.|
|UIAutomationClientsideProviders.dll|A set of UI Automation providers for standard legacy controls. (WPF controls have native support for UI Automation.) This support is automatically available to client applications.|

 From the software developer's perspective, there are two ways of using UI Automation: to create support for custom controls (using the provider API), and creating applications that use the UI Automation core to communicate with UI elements (using the client API). Depending on your focus, you should refer to different parts of the documentation. You can learn more about the concepts and gain practical how-to knowledge in the following sections.

|Section|Subject matter|Audience|
|-------------|--------------------|--------------|
|[UI Automation Fundamentals](index.md) (this section)|Broad overviews of the concepts.|All.|
|[UI Automation Providers for Managed Code](ui-automation-providers-for-managed-code.md)|Overviews and how-to topics to help you use the provider API.|Control developers.|
|[UI Automation Clients for Managed Code](ui-automation-clients-for-managed-code.md)|Overviews and how-to topics to help you use the client API.|Client application developers.|
|[UI Automation Control Patterns](ui-automation-control-patterns.md)|Information about how control patterns should be implemented by providers, and what functionality is available to clients.|All.|
|[UI Automation Text Pattern](ui-automation-text-pattern.md)|Information about how the Text control pattern should be implemented by providers, and what functionality is available to clients.|All.|
|[UI Automation Control Types](ui-automation-control-types.md)|Information about the properties and control patterns supported by different control types.|All.|

 The following table lists UI Automation namespaces, the DLLs that contain them, and the audience that uses them.

|Namespace|Referenced DLLs|Audience|
|---------------|---------------------|--------------|
|<xref:System.Windows.Automation>|UIAutomationClientUIAutomationTypes|UI Automation client developers; used to find <xref:System.Windows.Automation.AutomationElement> objects, register for UI Automation events, and work with UI Automation control patterns.|
|<xref:System.Windows.Automation.Provider>|UIAutomationProviderUIAutomationTypes|Developers of UI Automation providers for frameworks other than WPF.|
|<xref:System.Windows.Automation.Text>|UIAutomationClientUIAutomationTypes|Developers of UI Automation providers for frameworks other than WPF; used to implement the TextPattern control pattern.|
|<xref:System.Windows.Automation.Peers>|PresentationFramework|Developers of UI Automation providers for WPF.|

<a name="UI_Automation_Model"></a>

## UI Automation Model

 UI Automation exposes every piece of the UI to client applications as an <xref:System.Windows.Automation.AutomationElement>. Elements are contained in a tree structure, with the desktop as the root element. Clients can filter the raw view of the tree as a control view or a content view. Applications can also create custom views.

 <xref:System.Windows.Automation.AutomationElement> objects expose common properties of the UI elements they represent. One of these properties is the control type, which defines its basic appearance and functionality as a single recognizable entity: for example, a button or check box.

 In addition, elements expose control patterns that provide properties specific to their control types. Control patterns also expose methods that enable clients to get further information about the element and to provide input.

> [!NOTE]
> There is not a one-to-one correspondence between control types and control patterns. A control pattern may be supported by multiple control types, and a control may support multiple control patterns, each of which exposes different aspects of its behavior. For example, a combo box has at least two control patterns: one that represents its ability to expand and collapse, and another that represents the selection mechanism. For specifics, see [UI Automation Control Types](ui-automation-control-types.md).

 UI Automation also provides information to client applications through events. Unlike WinEvents, UI Automation events are not based on a broadcast mechanism. UI Automation clients register for specific event notifications and can request that specific UI Automation properties and control pattern information be passed into their event handlers. In addition, a UI Automation event contains a reference to the element that raised it. Providers can improve performance by raising events selectively, depending on whether any clients are listening.

## See also

- [UI Automation Tree Overview](ui-automation-tree-overview.md)
- [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md)
- [UI Automation Properties Overview](ui-automation-properties-overview.md)
- [UI Automation Events Overview](ui-automation-events-overview.md)
- [UI Automation Security Overview](ui-automation-security-overview.md)
