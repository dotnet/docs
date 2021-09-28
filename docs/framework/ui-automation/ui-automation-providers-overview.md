---
title: "UI Automation Providers Overview"
description: See an overview of UI Automation providers, which let controls communicate with UI Automation client applications. Review provider types and provider concepts.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "UI Automation, providers"
  - "providers, UI Automation"
ms.assetid: 859557b8-51e1-4d15-92e8-318d2dcdb2f7
---
# UI Automation Providers Overview

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 UI Automation providers enable controls to communicate with UI Automation client applications. In general, each control or other distinct element in a user interface (UI) is represented by a provider. The provider exposes information about the element and optionally implements control patterns that enable the client application to interact with the control.

 Client applications do not usually have to work directly with providers. Most of the standard controls in applications that use the Win32, Windows Forms, or Windows Presentation Foundation (WPF) frameworks are automatically exposed to the UI Automation system. Applications that implement custom controls may also implement UI Automation providers for those controls, and client applications do not have to take any special steps to gain access to them.

 This topic provides an overview of how control developers implement UI Automation providers, particularly for controls in Windows Forms and Win32 windows.

<a name="Types_of_Providers"></a>

## Types of Providers

 UI Automation providers fall into two categories: client-side providers and server-side providers.

### Client-side providers

 Client-side providers are implemented by UI Automation clients to communicate with an application that does not support, or does not fully support, UI Automation. Client-side providers usually communicate with the server across the process boundary by sending and receiving Windows messages.

 Because UI Automation providers for controls in Win32, Windows Forms, or WPF applications are supplied as part of the operating system, client applications seldom have to implement their own providers, and this overview does not cover them further.

### Server-side providers

 Server-side providers are implemented by custom controls or by applications that are based on a UI framework other than Win32, Windows Forms, or WPF.

 Server-side providers communicate with client applications across the process boundary by exposing interfaces to the UI Automation core system, which in turn serves requests from clients.

<a name="AutomationProviderConcepts"></a>

## UI Automation Provider Concepts

 This section provides brief explanations of some of the key concepts you need to understand in order to implement UI Automation providers.

### Elements

 UI Automation elements are pieces of user interface (UI) that are visible to UI Automation clients. Examples include application windows, panes, buttons, tooltips, list boxes, and list items.

### Navigation

 UI Automation elements are exposed to clients as a UI Automation tree. UI Automation constructs the tree by navigating from one element to another. Navigation is enabled by the providers for each element, each of which may point to a parent, siblings, and children.

 For more information on the client view of the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

### Views

 A client can see the UI Automation tree in three principal views, as shown in the following table.

| View         | Description                          |
| ------------ | ------------------------------------ |
| Raw view     | Contains all elements.               |
| Control view | Contains elements that are controls. |
| Content view | Contains elements that have content. |

 For more information on client views of the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

 It is the responsibility of the provider implementation to define an element as a content element or a control element. Control elements may or may not also be content elements, but all content elements are control elements.

### Frameworks

 A framework is a component that manages child controls, hit-testing, and rendering in an area of the screen. For example, a Win32 window, often referred to as an HWND, can serve as a framework that contains multiple UI Automation elements such as a menu bar, a status bar, and buttons.

 Win32 container controls such as list boxes and tree views are considered to be frameworks, because they contain their own code for rendering child items and performing hit-testing on them. By contrast, a WPF list box is not a framework, because the rendering and hit-testing is being handled by the containing WPF window.

 The UI in an application can be made up of different frameworks. For example, an HWND application window might contain Dynamic HTML (DHTML) which in turn contains a component such as a combo box in an HWND.

### Fragments

 A fragment is a complete subtree of elements from a particular framework. The element at the root node of the subtree is called a fragment root. A fragment root does not have a parent, but is hosted within some other framework, usually a Win32 window (HWND).

### Hosts

 The root node of every fragment must be hosted in an element, usually a Win32 window (HWND). The exception is the desktop, which is not hosted in any other element. The host of a custom control is the HWND of the control itself, not the application window or any other window that might contain groups of top-level controls.

 The host of a fragment plays an important role in providing UI Automation services. It enables navigation to the fragment root, and supplies some default properties so that the custom provider does not have to implement them.

## See also

- [Server-Side UI Automation Provider Implementation](server-side-ui-automation-provider-implementation.md)
