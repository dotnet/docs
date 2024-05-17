---
title: "Using UI Automation for Automated Testing"
description: Read an overview that describes how to use UI Automation as a framework for programmatic access in automated testing scenarios.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "automated testing"
  - "testing, UI Automation"
  - "UI Automation, automated testing"
ms.assetid: 3a0435c0-a791-4ad7-ba92-a4c1d1231fde
---
# Using UI Automation for Automated Testing

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This overview describes how Microsoft UI Automation can be useful as a framework for programmatic access in automated testing scenarios.

 UI Automation provides a unified object model that enables all user interface (UI) frameworks to expose complex and rich functionality in an accessible and easily automated manner.

 UI Automation was developed as a successor to Microsoft Active Accessibility. Active Accessibility is an existing framework designed to provide a solution for making controls and applications accessible. Active Accessibility was not designed with test automation in mind even though it evolved into that role due to the very similar requirements of accessibility and automation. UI Automation, in addition to providing more refined solutions for accessibility, is also specifically designed to provide robust functionality for automated testing. For example, Active Accessibility relies on a single interface to both expose information about the UI and collect the information needed by AT products; UI Automation separates the two models.

 Both a provider and client are required to implement UI Automation for it to be useful as an automated test tool. UI Automation providers are applications such as Microsoft Word, Excel, and other third-party applications or controls based on the Microsoft Windows operating system. UI Automation clients include automated test scripts and assistive technology applications.

> [!NOTE]
> The intent of this overview is to showcase the new and improved automated testing capabilities of UI Automation. This overview is not intended to provide information on accessibility features and will not address accessibility other than where necessary.

## UI Automation in a Provider

 For a UI to be automated, a developer of an application or control must look at what actions an end-user can perform on the UI object using standard keyboard and mouse interaction.

 Once these key actions have been identified, the corresponding UI Automation control patterns (that is, the control patterns that mirror the functionality and behavior of the UI element) should be implemented on the control. For example, user interaction with a combo box control (such as the run dialog) typically involves expanding and collapsing the combo box to hide or display a list of items, selecting an item from that list, or adding a new value via keyboard input.

> [!NOTE]
> With other accessibility models, developers must gather information directly from individual buttons, menus, or other controls. Unfortunately, every control type comes in dozens of minor variations. In other words, even though ten variations of a pushbutton may all work the same way and perform the same function, they must all be treated as unique controls. There is no way to know that these controls are functionally equivalent. Control patterns were developed to represent these common control behaviors. For more information, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

### Implementing UI Automation

 As mentioned earlier, without the unified model provided by UI Automation, test tools and developers are required to know framework-specific information in order to expose properties and behaviors of controls in that framework. Since there can be several different UI frameworks present at any single time within Windows operating systems, including Win32, Windows Forms, and Windows Presentation Foundation (WPF), it can be a daunting task to test multiple applications with controls that seem similar. For example, the following table outlines the framework-specific property names required to retrieve the name (or text) associated with a button control and shows the single equivalent UI Automation property.

| UI Automation Control Type | UI Framework                    | Framework Specific Property | UI Automation Property |
|----------------------------|---------------------------------|-----------------------------|------------------------|
| Button                     | Windows Presentation Foundation | Content                     | NameProperty           |
| Button                     | Win32                           | Caption                     | NameProperty           |
| Image                      | HTML                            | alt                         | NameProperty           |

 UI Automation providers are responsible for mapping the framework-specific properties of their controls to the equivalent UI Automation properties.

 Information on implementing UI Automation in a provider can be found at [UI Automation Providers for Managed Code](ui-automation-providers-for-managed-code.md). Information on implementing control patterns is available at [UI Automation Control Patterns](ui-automation-control-patterns.md) and [UI Automation Text Pattern](ui-automation-text-pattern.md).

## UI Automation in a Client

 The goal of many automated test tools and scenarios is the consistent and repeatable manipulation of the user interface. This can involve unit testing specific controls through to the recording and playback of test scripts that iterate through a series of generic actions on a group of controls.

 A complication that arises from automated applications is the difficulty synchronizing a test with a dynamic target. For example, a list box control, such as one contained in the Windows Task Manager, that displays a list of currently running applications. Since the items in the list box are dynamically updated outside the control of the test application, attempting to repeat the selection of a specific item in the list box with any consistency is impossible. Similar issues can also arise when attempting to repeat simple focus changes in a UI that is outside the control of the test application.

### Programmatic Access

 Programmatic access provides the ability to imitate, through code, any interaction and experience exposed by traditional mouse and keyboard input. UI Automation enables programmatic access through five components:

- The UI Automation tree facilitates navigation through the structure of the UI. The tree is built from the collection of hWnd's. For more information, see [UI Automation Tree Overview](ui-automation-tree-overview.md)

- Automation elements are individual components in the UI. These can often be more granular than an hWnd. For more information, see [UI Automation Control Types Overview](ui-automation-control-types-overview.md).

- Automation properties provide specific information about UI elements. For more information, see [UI Automation Properties Overview](ui-automation-properties-overview.md).

- Control patterns define a particular aspect of a control's functionality; they can consist of property, method, event, and structure information. For more information, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

- Automation events provide event notifications and information. For more information, see [UI Automation Events Overview](ui-automation-events-overview.md).

### Key Properties for Test Automation

 The ability to uniquely identify and subsequently locate any control within the UI provides the basis for automated test applications to operate on that UI. There are several Microsoft UI Automation properties used by clients and providers that assist in this.

#### AutomationID

 Uniquely identifies an automation element from its siblings. <xref:System.Windows.Automation.AutomationElement.AutomationIdProperty> is not localized, unlike a property such as <xref:System.Windows.Automation.AutomationElement.NameProperty> that is typically localized if a product gets shipped in multiple languages. See [Use the AutomationID Property](use-the-automationid-property.md).

> [!NOTE]
> <xref:System.Windows.Automation.AutomationElement.AutomationIdProperty> does not guarantee a unique identity throughout the automation tree. For example, an application may contain a menu control with multiple top-level menu items that, in turn, have multiple child menu items. These secondary menu items may be identified by a generic scheme such as "Item1, Item 2, Item3, etc.", allowing duplicate identifiers for children across top-level menu items.

#### ControlType

 Identifies the type of control represented by an automation element. Significant information can be inferred from knowledge of the control type. See [UI Automation Control Types Overview](ui-automation-control-types-overview.md).

#### NameProperty

 This is a text string that identifies or explains a control. <xref:System.Windows.Automation.AutomationElement.NameProperty> should be used with caution since it can be localized. See [UI Automation Properties Overview](ui-automation-properties-overview.md).

### Implementing UI Automation in a Test Application

| Step | Description |
|-|-|
|Add the UI Automation References.|The UI Automation dll's necessary for UI Automation clients are listed here.<br /><br /> -   UIAutomationClient.dll provides access to the UI Automation client-side APIs.<br />-   UIAutomationClientSideProvider.dll provides the ability to automate Win32 controls. See [UI Automation Support for Standard Controls](ui-automation-support-for-standard-controls.md).<br />-   UIAutomationTypes.dll provides access to the specific types defined in UI Automation.|
|Add the <xref:System.Windows.Automation> namespace.|This namespace contains everything UI Automation clients need to use the capabilities of UI Automation except text handling.|
|Add the <xref:System.Windows.Automation.Text> namespace.|This namespace contains everything a UI Automation clients need to use the capabilities of UI Automation text handling.|
|Find controls of interest.|Automated test scripts locate UI Automation elements that represent controls of interest within the automation tree.<br /><br /> There are multiple ways to obtain UI Automation elements with code.<br /><br /> -   Query the UI using a <xref:System.Windows.Automation.Condition> statement. This is typically where the language-neutral <xref:System.Windows.Automation.AutomationElement.AutomationIdProperty> is used. **Note:**  An <xref:System.Windows.Automation.AutomationElement.AutomationIdProperty> can be obtained using a tool such as Inspect.exe that is able to itemize the UI Automation properties of a control. <br /><br /> -   Use the <xref:System.Windows.Automation.TreeWalker> class to traverse the entire UI Automation tree or a subset thereof.<br />-   Track focus.<br />-   Use the hWnd of the control.<br />-   Use screen location, such as the location of the mouse cursor.<br /><br /> See [Obtaining UI Automation Elements](obtaining-ui-automation-elements.md)|
|Obtain Control Patterns.|Control patterns expose common behaviors for functionally similar controls.<br /><br /> After locating the controls that require testing, automated test scripts obtain the control patterns of interest from those UI Automation elements. For example, the <xref:System.Windows.Automation.InvokePattern> control pattern for typical button functionality or the <xref:System.Windows.Automation.WindowPattern> control pattern for window functionality.<br /><br /> See [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).|
|Automate the UI.|Automated test scripts can now control any UI of interest from a UI framework using the information and functionality exposed by the UI Automation control patterns.|

## Related Tools and Technologies

 There are a number of related tools and technologies that support automated testing with UI Automation.

- Inspect.exe is a graphical user interface (GUI) application that can be used to gather UI Automation information for both provider and client development and debugging. Inspect.exe is included in the Windows SDK.

- MSAABridge exposes UI Automation information to Active Accessibility clients. The primary goal of bridging UI Automation to Active Accessibility is to allow existing Active Accessibility clients the ability to interact with any framework that has implemented UI Automation.

## Security

 For security information, see [UI Automation Security Overview](ui-automation-security-overview.md).

## See also

- [UI Automation Fundamentals](index.md)
