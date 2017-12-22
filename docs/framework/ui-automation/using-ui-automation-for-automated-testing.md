---
title: "Using UI Automation for Automated Testing"
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
  - "automated testing"
  - "testing, UI Automation"
  - "UI Automation, automated testing"
ms.assetid: 3a0435c0-a791-4ad7-ba92-a4c1d1231fde
caps.latest.revision: 26
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Using UI Automation for Automated Testing
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 This overview describes how [!INCLUDE[TLA#tla_uiautomation](../../../includes/tlasharptla-uiautomation-md.md)] can be useful as a framework for programmatic access in automated testing scenarios.  
  
 [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] provides a unified object model that enables all [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)] frameworks to expose complex and rich functionality in an accessible and easily automated manner.  
  
 [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] was developed as a successor to [!INCLUDE[TLA#tla_aa](../../../includes/tlasharptla-aa-md.md)]. [!INCLUDE[TLA2#tla_aa](../../../includes/tla2sharptla-aa-md.md)] is an existing framework designed to provide a solution for making controls and applications accessible. [!INCLUDE[TLA2#tla_aa](../../../includes/tla2sharptla-aa-md.md)] was not designed with test automation in mind even though it evolved into that role due to the very similar requirements of accessibility and automation. [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], in addition to providing more refined solutions for accessibility, is also specifically designed to provide robust functionality for automated testing. For example, [!INCLUDE[TLA2#tla_aa](../../../includes/tla2sharptla-aa-md.md)] relies on a single interface to both expose information about the UI and collect the information needed by AT products; [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] separates the two models.  
  
 Both a provider and client are required to implement [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] for it to be useful as an automated test tool. UI Automation providers are applications such as Microsoft Word, Excel, and other third-party applications or controls based on the [!INCLUDE[TLA#tla_win](../../../includes/tlasharptla-win-md.md)] operating system. UI Automation clients include automated test scripts and assistive technology applications.  
  
> [!NOTE]
>  The intent of this overview is to showcase the new and improved automated testing capabilities of [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)]. This overview is not intended to provide information on accessibility features and will not address accessibility other than where necessary.  
  
<a name="Using_UI_Automation_During_Development"></a>   
## UI Automation in a Provider  
 For a [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] to be automated, a developer of an application or control must look at what actions an end-user can perform on the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] object using standard keyboard and mouse interaction.  
  
 Once these key actions have been identified, the corresponding [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] control patterns (that is, the control patterns that mirror the functionality and behavior of the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] element) should be implemented on the control. For example, user interaction with a combo box control (such as the run dialog) typically involves expanding and collapsing the combo box to hide or display a list of items, selecting an item from that list, or adding a new value via keyboard input.  
  
> [!NOTE]
>  With other accessibility models, developers must gather information directly from individual buttons, menus, or other controls. Unfortunately, every control type comes in dozens of minor variations. In other words, even though ten variations of a pushbutton may all work the same way and perform the same function, they must all be treated as unique controls. There is no way to know that these controls are functionally equivalent. Control patterns were developed to represent these common control behaviors. For more information, see [UI Automation Control Patterns Overview](../../../docs/framework/ui-automation/ui-automation-control-patterns-overview.md).  
  
<a name="Implementing_UI_Automation"></a>   
### Implementing UI Automation  
 As mentioned earlier, without the unified model provided by [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], test tools and developers are required to know framework-specific information in order to expose properties and behaviors of controls in that framework. Since there can be several different UI frameworks present at any single time within [!INCLUDE[TLA2#tla_win](../../../includes/tla2sharptla-win-md.md)] operating systems, including [!INCLUDE[TLA2#tla_win32](../../../includes/tla2sharptla-win32-md.md)], [!INCLUDE[TLA#tla_winforms](../../../includes/tlasharptla-winforms-md.md)], and [!INCLUDE[TLA#tla_wpf](../../../includes/tlasharptla-wpf-md.md)], it can be a daunting task to test multiple applications with controls that seem similar. For example, the following table outlines the framework-specific property names required to retrieve the name (or text) associated with a button control and shows the single equivalent [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] property.  
  
|UI Automation Control Type|UI Framework|Framework Specific Property|UI Automation Property|  
|--------------------------------|------------------|---------------------------------|----------------------------|  
|Button|Windows Presentation Foundation|Content|NameProperty|  
|Button|Win32|Caption|NameProperty|  
|Image|HTML|alt|NameProperty|  
  
 UI Automation providers are responsible for mapping the framework-specific properties of their controls to the equivalent [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] properties.  
  
 Information on implementing [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] in a provider can be found at [UI Automation Providers for Managed Code](../../../docs/framework/ui-automation/ui-automation-providers-for-managed-code.md). Information on implementing control patterns is available at [UI Automation Control Patterns](../../../docs/framework/ui-automation/ui-automation-control-patterns.md) and [UI Automation Text Pattern](../../../docs/framework/ui-automation/ui-automation-text-pattern.md).  
  
<a name="Testing_with_UI_Automation"></a>   
## UI Automation in a Client  
 The goal of many automated test tools and scenarios is the consistent and repeatable manipulation of the user interface. This can involve unit testing specific controls through to the recording and playback of test scripts that iterate through a series of generic actions on a group of controls.  
  
 A complication that arises from automated applications is the difficulty synchronizing a test with a dynamic target. For example, a list box control, such as one contained in the Windows Task Manager, that displays a list of currently running applications. Since the items in the list box are dynamically updated outside the control of the test application, attempting to repeat the selection of a specific item in the list box with any consistency is impossible. Similar issues can also arise when attempting to repeat simple focus changes in a [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] that is outside the control of the test application.  
  
<a name="Programmatic_Access"></a>   
### Programmatic Access  
 Programmatic access provides the ability to imitate, through code, any interaction and experience exposed by traditional mouse and keyboard input. [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] enables programmatic access through five components:  
  
-   The [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree facilitates navigation through the structure of the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)]. The tree is built from the collection of hWnd's. For more information, see [UI Automation Tree Overview](../../../docs/framework/ui-automation/ui-automation-tree-overview.md)  
  
-   Automation elements are individual components in the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)]. These can often be more granular than an hWnd. For more information, see [UI Automation Control Types Overview](../../../docs/framework/ui-automation/ui-automation-control-types-overview.md).  
  
-   Automation properties provide specific information about [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] elements. For more information, see [UI Automation Properties Overview](../../../docs/framework/ui-automation/ui-automation-properties-overview.md).  
  
-   Control patterns define a particular aspect of a control's functionality; they can consist of property, method, event, and structure information. For more information, see [UI Automation Control Patterns Overview](../../../docs/framework/ui-automation/ui-automation-control-patterns-overview.md).  
  
-   Automation events provide event notifications and information. For more information, see [UI Automation Events Overview](../../../docs/framework/ui-automation/ui-automation-events-overview.md).  
  
<a name="Key_properties_critical_to_test_automation"></a>   
### Key Properties for Test Automation  
 The ability to uniquely identify and subsequently locate any control within the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] provides the basis for automated test applications to operate on that [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)]. There are several [!INCLUDE[TLA#tla_uiautomation](../../../includes/tlasharptla-uiautomation-md.md)] properties used by clients and providers that assist in this.  
  
#### AutomationID  
 Uniquely identifies an automation element from its siblings. <xref:System.Windows.Automation.AutomationElement.AutomationIdProperty> is not localized, unlike a property such as <xref:System.Windows.Automation.AutomationElement.NameProperty> that is typically localized if a product gets shipped in multiple languages. See [Use the AutomationID Property](../../../docs/framework/ui-automation/use-the-automationid-property.md).  
  
> [!NOTE]
>  <xref:System.Windows.Automation.AutomationElement.AutomationIdProperty> does not guarantee a unique identity throughout the automation tree. For example, an application may contain a menu control with multiple top-level menu items that, in turn, have multiple child menu items. These secondary menu items may be identified by a generic scheme such as "Item1, Item 2, Item3, etc.", allowing duplicate identifiers for children across top-level menu items.  
  
#### ControlType  
 Identifies the type of control represented by an automation element. Significant information can be inferred from knowledge of the control type. See [UI Automation Control Types Overview](../../../docs/framework/ui-automation/ui-automation-control-types-overview.md).  
  
#### NameProperty  
 This is a text string that identifies or explains a control. <xref:System.Windows.Automation.AutomationElement.NameProperty> should be used with caution since it can be localized. See [UI Automation Properties Overview](../../../docs/framework/ui-automation/ui-automation-properties-overview.md).  
  
<a name="Steps_Required_To_Automate_the_UI_in_a_Test_Application"></a>   
### Implementing UI Automation in a Test Application  
  
|||  
|-|-|  
|Add the UI Automation References.|The [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] dll's necessary for UI Automation clients are listed here.<br /><br /> -   UIAutomationClient.dll provides access to the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] client-side APIs.<br />-   UIAutomationClientSideProvider.dll provides the ability to automate [!INCLUDE[TLA2#tla_win32](../../../includes/tla2sharptla-win32-md.md)] controls. See [UI Automation Support for Standard Controls](../../../docs/framework/ui-automation/ui-automation-support-for-standard-controls.md).<br />-   UIAutomationTypes.dll provides access to the specific types defined in [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)].|  
|Add the <xref:System.Windows.Automation> namespace.|This namespace contains everything UI Automation clients need to use the capabilities of [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] except text handling.|  
|Add the <xref:System.Windows.Automation.Text> namespace.|This namespace contains everything a UI Automation clients need to use the capabilities of [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] text handling.|  
|Find controls of interest|Automated test scripts locate UI Automation elements that represent controls of interest within the automation tree.<br /><br /> There are multiple ways to obtain UI Automation elements with code.<br /><br /> -   Query the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] using a <xref:System.Windows.Automation.Condition> statement. This is typically where the language-neutral <xref:System.Windows.Automation.AutomationElement.AutomationIdProperty> is used. **Note:**  An <xref:System.Windows.Automation.AutomationElement.AutomationIdProperty> can be obtained using a tool such as Inspect.exe that is able to itemize the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] properties of a control. <br /><br /> -   Use the <xref:System.Windows.Automation.TreeWalker> class to traverse the entire [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] tree or a subset thereof.<br />-   Track focus.<br />-   Use the hWnd of the control.<br />-   Use screen location, such as the location of the mouse cursor.<br /><br /> See [Obtaining UI Automation Elements](../../../docs/framework/ui-automation/obtaining-ui-automation-elements.md)|  
|Obtain Control Patterns|Control patterns expose common behaviors for functionally similar controls.<br /><br /> After locating the controls that require testing, automated test scripts obtain the control patterns of interest from those UI Automation elements. For example, the <xref:System.Windows.Automation.InvokePattern> control pattern for typical button functionality or the <xref:System.Windows.Automation.WindowPattern> control pattern for window functionality.<br /><br /> See [UI Automation Control Patterns Overview](../../../docs/framework/ui-automation/ui-automation-control-patterns-overview.md).|  
|Automate the UI|Automated test scripts can now control any [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] of interest from a [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] framework using the information and functionality exposed by the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] control patterns.|  
  
<a name="Supporting_tools"></a>   
## Related Tools and Technologies  
 There are a number of related tools and technologies that support automated testing with [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)].  
  
-   Inspect.exe is a [!INCLUDE[TLA#tla_gui](../../../includes/tlasharptla-gui-md.md)] application that can be used to gather [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] information for both provider and client development and debugging. Inspect.exe is included in the [!INCLUDE[TLA#tla_winfxsdk](../../../includes/tlasharptla-winfxsdk-md.md)].  
  
-   MSAABridge exposes [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] information to [!INCLUDE[TLA2#tla_aa](../../../includes/tla2sharptla-aa-md.md)] clients. The primary goal of bridging [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] to [!INCLUDE[TLA2#tla_aa](../../../includes/tla2sharptla-aa-md.md)] is to allow existing [!INCLUDE[TLA2#tla_aa](../../../includes/tla2sharptla-aa-md.md)] clients the ability to interact with any framework that has implemented [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)].  
  
<a name="Security"></a>   
## Security  
 For security information, see [UI Automation Security Overview](../../../docs/framework/ui-automation/ui-automation-security-overview.md).  
  
## See Also  
 [UI Automation Fundamentals](../../../docs/framework/ui-automation/index.md)
