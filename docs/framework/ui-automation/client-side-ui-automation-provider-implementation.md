---
title: "Client-Side UI Automation Provider Implementation"
description: Understand client-side UI Automation provider implementation. Know how to distribute, register, and configure client-side providers.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "UI Automation, client-side provider implementation"
  - "client-side UI Automation provider, implementation"
  - "provider implementation, UI Automation"
ms.assetid: 3584c0a1-9cd0-4968-8b63-b06390890ef6
---
# Client-Side UI Automation Provider Implementation

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 Several different user interface (UI) frameworks are in use within Microsoft operating systems, including Win32, Windows Forms, and Windows Presentation Foundation (WPF). Microsoft UI Automation exposes information about UI elements to clients. However, UI Automation does not itself have awareness of the different types of controls that exist in these frameworks and the techniques that are needed to extract information from them. Instead, it leaves this task to objects called providers. A provider extracts information from a specific control and hands that information to UI Automation, which then presents it to the client in a consistent manner.

 Providers can exist either on the server side or on the client side. A server-side provider is implemented by the control itself. WPF elements implement providers, as can any third-party controls written with UI Automation in mind.

 However, older controls such as those in Win32 and Windows Forms do not directly support UI Automation. These controls are served instead by providers that exist in the client process and obtain information about controls using cross-process communication; for example, by monitoring Windows messages to and from the controls. Such client-side providers are sometimes called proxies.

 Windows Vista supplies providers for standard Win32 and Windows Forms controls. In addition, a fallback provider gives partial UI Automation support to any control that is not served by another server-side provider or proxy but has a Microsoft Active Accessibility implementation. All these providers are automatically loaded and available to client applications.

 For more information on support for Win32 and Windows Forms controls, see [UI Automation Support for Standard Controls](ui-automation-support-for-standard-controls.md).

 Applications can also register other client-side providers.

<a name="Distributing_Client-Side_Providers"></a>

## Distributing Client-Side Providers

 UI Automation expects to find client-side providers in a managed-code assembly. The namespace in this assembly should have the same name as the assembly. For example, an assembly called ContosoProxies.dll would contain the ContosoProxies namespace. Within the namespace, create a <xref:UIAutomationClientsideProviders.UIAutomationClientSideProviders> class. In the implementation of the static <xref:UIAutomationClientsideProviders.UIAutomationClientSideProviders.ClientSideProviderDescriptionTable> field, create an array of <xref:System.Windows.Automation.ClientSideProviderDescription> structures describing the providers.

<a name="Registering_and_Configuring_Client-Side_Providers"></a>

## Registering and Configuring Client-Side Providers

 Client-side providers in a dynamic-link library (DLL) are loaded by calling <xref:System.Windows.Automation.ClientSettings.RegisterClientSideProviderAssembly%2A>. No further action is required by a client application to make use of the providers.

 Providers implemented in the client's own code are registered by using <xref:System.Windows.Automation.ClientSettings.RegisterClientSideProviders%2A>. This method takes as an argument an array of <xref:System.Windows.Automation.ClientSideProviderDescription> structures, each of which specifies the following properties:

- A callback function that creates the provider object.

- The class name of the controls that the provider will serve.

- The image name of the application (usually the full name of the executable file) that the provider will serve.

- Flags that govern how the class name is matched against window classes found in the target application.

 The last two parameters are optional. The client might specify the image name of the target application when it wants to use different providers for different applications. For example, the client might use one provider for a Win32 list view control in a known application that supports the Multiple View pattern, and another for a similar control in another known application that does not.

## See also

- [Create a Client-Side UI Automation Provider](create-a-client-side-ui-automation-provider.md)
- [Implement UI Automation Providers in a Client Application](implement-ui-automation-providers-in-a-client-application.md)
