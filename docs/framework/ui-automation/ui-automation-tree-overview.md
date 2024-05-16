---
title: "UI Automation Tree Overview"
description: Read an overview about UI Automation trees. Learn about different views of a UI Automation tree, such as raw view, control view, and content view.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "automation tree"
  - "UI Automation, tree"
ms.assetid: 03b98058-bdb3-47a0-8ff7-45e6cdf67166
---
# UI Automation Tree Overview

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 Assistive technology products and test scripts navigate the UI Automation tree to gather information about the user interface (UI) and its elements.

 Within the UI Automation tree there is a root element (<xref:System.Windows.Automation.AutomationElement.RootElement%2A>) that represents the current desktop and whose child elements represent application windows. Each of these child elements can contain elements representing pieces of UI such as menus, buttons, toolbars, and list boxes. These elements in turn can contain elements such as list items.

 The UI Automation tree is not a fixed structure and is seldom seen in its totality because it might contain thousands of elements. Parts of it are built as they are needed, and it can undergo changes as elements are added, moved, or removed.

 UI Automation providers support the UI Automation tree by implementing navigation among items within a fragment, which consists of a root (usually hosted in a window) and a subtree. However, providers are not concerned with navigation from one control to another. This is managed by the UI Automation core, using information from the default window providers.

<a name="uiautomation_tree_view"></a>

## Views of the Automation Tree

 The UI Automation tree can be filtered to create views that contain only those <xref:System.Windows.Automation.AutomationElement> objects relevant for a particular client. This approach allows clients to customize the structure presented through UI Automation to their particular needs.

 The client has two ways of customizing the view: by scoping and by filtering. Scoping is defining the extent of the view, starting from a base element: for example, the application might want to find only direct children of the desktop, or all descendants of an application window. Filtering is defining the types of elements that are to be included in the view.

 UI Automation providers support filtering by defining properties on elements, including the <xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty> and <xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty> properties.

 UI Automation provides three default views. These views are defined by the type of filtering performed; the scope of any view is defined by the application. In addition, the application can apply other filters on properties; for example, to include only enabled controls in a control view.

<a name="uiautomation_raw_view"></a>

### Raw View

 The raw view of the UI Automation tree is the full tree of <xref:System.Windows.Automation.AutomationElement> objects for which the desktop is the root. The raw view closely follows the native programmatic structure of an application and therefore is the most detailed view available. It is also the base on which the other views of the tree are built. Because this view depends on the underlying UI framework, the raw view of a WPF button will have a different raw view than a Win32 button.

 The raw view is obtained by searching for elements without specifying properties or by using the <xref:System.Windows.Automation.TreeWalker.RawViewWalker> to navigate the tree.

<a name="uiautomation_control_view"></a>

### Control View

 The control view of the UI Automation tree simplifies the assistive technology product's task of describing the UI to the end user and helping that end user interact with the application because it closely maps to the UI structure perceived by an end user.

 The control view is a subset of the raw view. It includes all UI items from the raw view that an end user would understand as interactive or contributing to the logical structure of the control in the UI. Examples of UI items that contribute to the logical structure of the UI, but are not interactive themselves, are item containers such as list view headers, toolbars, menus, and the status bar. Non-interactive items used simply for layout or decorative purposes will not be seen in the control view. An example is a panel that was used only to lay out the controls in a dialog but does not itself contain any information. Non-interactive items that will be seen in the control view are graphics with information and static text in a dialog. Non-interactive items that are included in the control view cannot receive keyboard focus.

 The control view is obtained by searching for elements that have the <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.IsControlElement%2A> property set to `true`, or by using the <xref:System.Windows.Automation.TreeWalker.ControlViewWalker> to navigate the tree.

<a name="uiautomation_content_view"></a>

### Content View

 The content view of the UI Automation tree is a subset of the control view. It contains UI items that convey the true information in a user interface, including UI items that can receive keyboard focus and some text that is not a label on a UI item. For example, the values in a drop-down combo box will appear in the content view because they represent the information being used by an end user. In the content view, a combo box and list box are both represented as a collection of UI items where one, or perhaps more than one, item can be selected. The fact that one is always open and one can expand and collapse is irrelevant in the content view because it is designed to show the data, or content, that is being presented to the user.

 The content view is obtained by searching for elements that have the <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.IsContentElement%2A> property set to `true`, or by using the <xref:System.Windows.Automation.TreeWalker.ContentViewWalker> to navigate the tree.

## See also

- <xref:System.Windows.Automation.AutomationElement>
- [UI Automation Overview](ui-automation-overview.md)
