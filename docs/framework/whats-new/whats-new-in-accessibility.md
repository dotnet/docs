---
title: "What's new in accessibility in the .NET Framework"
ms.custom: "updateeachrelease"
ms.date: "10/13/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
helpviewer_keywords: 
  - "what's new [.NET Framework]"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---

# What's new in accessibility in the .NET Framework

The .NET Framework aims at making applications more accessibile for your users. Accessibility features allow an application to handle a range of devices and form factors seamlessly. Starting with the .NET Framework 4.7.1, the .NET Framework includes a large number of accessibility improvements that allow developers to create accessible applications. 

The new accessibility features are enabled by default for applications that target the .NET Framework 4.7.1 or later. In addition, applications that target an earlier version of the .NET Framework but are running on the .NET Framework 4.7.1 or later can opt out of legacy accessibility behaviors by adding the following switch to the [`<AppContextSwitchOverrides>`](~/docs/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) element in the [`<runtime>`](~/docs/configure-apps/file-schema/runtime/index.md) section of the application's configuration file. 

```xml
<runtime>
    <!-- AppContextSwitchOverrides value attribute is in the form of 'key1=true|false;key2=true|false  -->
    <AppContextSwitchOverrides value="Switch.UseLegacyAccessibilityFeatures=false" />
</runtime>
```

Similarly, applications that target versions of the .NET Framework starting with 4.7.1 can disable accessibility features adding the following switch to the [`<AppContextSwitchOverrides>`](~/docs/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) element in the [`<runtime>`](~/docs/configure-apps/file-schema/runtime/index.md) section of the application's configuration file. 

```xml
<runtime>
    <!-- AppContextSwitchOverrides value attribute is in the form of 'key1=true|false;key2=true|false  -->
    <AppContextSwitchOverrides value="Switch.UseLegacyAccessibilityFeatures=true" />
</runtime>
```

## What's new in accessibility in the .NET Framework 4.7.1

The .NET Framework 4.7.1 includes new accessibility features in the following areas:

- [Windows Presentation Foundation (WPF)](windows-presentation-foundation-wpf)

- [Windows Forms](windows-forms-accessibility-improvements)
 
### Windows Presentation Foundation (WPF)

**Screen reader improvements**

If accessibility improvcements are enabled, the .NET Framework 4.7.1 includes the following enhancements that affect screen readers:

- In the .NET Framework 4.7 and earlier versions, <xref:System.Windows.Controls.Expander> controls were announced by screen readers as buttons. Starting with the .NET Framework 4.7.1, they are correctly announced as expandable/collapsible groups.

- In the .NET Framework 4.7 and earlier versions, <xref:System.Windows.Controls.DataGridCell> controls were announced by screen readers as “custom.” Starting with the .NET Framework 4.7.1, they are now correctly announced as data grid cell (localized).
 
- Starting with the .NET Framework 4.7.1, screen readers announce the name of an editable <xref:System.Windows.Controls.ComboBox>.

- In the .NET Framework 4.7 and earlier versions, <xref:System.Windows.Controls.PasswordBoxe> controls were announced as “no item in view” or had otherwise incorrect behavior. This issue is fixed starting with the .NET Framework 4.7.1.     

**UIAutomation LiveRegion support**

Screen readers such as Narrator help people read the UI contents of an application, usually by text-to-speech output of the UI content that has the focus. However, if a UI element changes and does not have the focus, the user may not be notified and may miss important information. Live regions aim at solving this problem. A developer can use them to inform the screen reader or any other UIAutomation client that an important change has been made to a UI element. The screen reader can then decide how and when to inform the user of this change. 

To support live regions, the following APIs have been added to WPF:

- The <xref:System.Windows.Automation.AutomationElementIdentifiers.LiveSettingProperty?displayProperty=nameWithType> and <xref:System.Windows.Automation.AutomationElementIdentifiers.LiveRegionChangedEvent?displayProperty=nameWithType> fields, which identify the **LiveSetting** property and the **LiveRegionChanged** event. They can be set by using XAML.

- The **AutomationProperties.LiveSetting** attached property, which informs the screen reader of the importance of the UI change to the user.

- The <xref:System.Windows.Automation.AutomationProperties.LiveSettingProperty%2A?displayProperty=nameWithType> property, which identifies the **AutomationProperties.LiveSetting** attached property.
 
- The <xref:System.Windows.Automation.Peers.AutomationPeer.GetLiveSetting%2A?displayProperty=nameWithType> method, which can be overridden to provide a **LiveSetting** value.

- The <xref:System.Windows.Automation.Peers.AutomationPeer.GetLiveSetting%2A?displayProperty=nameWithType> and  <xref:System.Windows.Automation.Peers.AutomationPeer.SetLiveSetting%2A?displayProperty=nameWithType> methods, which get and set a **LiveSetting** value.
 
- The <xref:System.Windows.Automation.AutomationLiveSetting?displayProperty=nameWithType> enumeration, which defines the following possible **LiveSetting** values:

   - <xref:System.Windows.Automation.AutomationLiveSetting.Off?displayProperty=nameWithType>. The element does not send notifications if the content of the live region has changed.   
   - <xref:System.Windows.Automation.AutomationLiveSetting.Polite?displayProperty=nameWithType>. The element sends non-interruptive notifications if the content of the live region has changed.   

  - <xref:System.Windows.Automation.AutomationLiveSetting.Assertive?displayProperty=nameWithType>. The element sends interruptive notifications if the content of the live region has changed.   

You can create a LiveRegion by setting the **AutomationProperties.LiveSetting** property on the element of interest, as shown in the following example:   

```xaml
<TextBlock Name="myTextBlock" AutomationProperties.LiveSetting="Assertive">announcement</TextBlock>
```

When the data in the live region changes and you need to inform a screen reader, you explicitly raise an event, as shown in the following sample.

```csharp
var peer = FrameworkElementAutomationPeer.FromElement(myTextBlock);

peer.RaiseAutomationEvent(AutomationEvents.LiveRegionChanged);
```

```vb
Dim peer = FrameworkElementAutomationPeer.FromElement(myTextBlock)
peer.RaiseAutomationEvent(AutomationEvents.LiveRegionChanged)

```

**High contrast**

Starting with the .NET Framework 4.7.1, improvements in high conrast have been made to various WPF controls. They are now visible when the <xref:System.Windows.SystemParameters.HighContrast%2A> theme is set. These include:

- <xref:System.Windows.Controls.Expander> control

    The focus visual for the  <xref:System.Windows.Controls.Expander> control is now visible. The keyboard visuals for <xref:System.Windows.Controls.ComboBox>,<xref:System.Windows.Controls.ListBox>, and <xref:System.Windows.Controls.RadioButton> controls are visible as well. For example:

    Before: 
    
    ![Expander control with focus before accessibility improvements](media/expander-before.png)

    After: 

    ![Expander control with focus after accessibility improvements](media/expander-after.png)

- <xref:System.Windows.Controls.CheckBox> and <xref:System.Windows.Controls.RadioButton> controls
 
    The text in the <xref:System.Windows.Controls.CheckBox> and <xref:System.Windows.Controls.RadioButton> controls is now easier to see when selected in high contrast themes. For example:

    Before: 

    ![High contrast radio button with focus before accessibility improvements](media/radio-button-before.png)
    
    After: 

    ![High contrast radio button with focus after accessibility improvements](media/radio-button-after.png)

- <xref:System.Windows.Controls.ComboBox> control
 
    Starting with the .NET Framework 4.7.1, the border of a disabled <xref:System.Windows.Controls.ComboBox> control is the same color as disabled text. For example:
    
    Before: 

     ![ComboBox disabled border and text before accessibility improvements](media/combo-disabled-before.png)

    After:   

     ![ComboBox disabled border and text after accessibility improvements](media/combo-disabled-after.png)

    In addition, disabled and focused buttons use the correct theme color.

    Before:

    ![Button theme colors before accessibility improvements](media/button-themes-before.png) 
    
    After: 

    ![Button theme colors after accessibility improvements](media/button-themes-after.png) 

    Finally, in the .NET Framework 4.7 and earlier versions, setting a <xref:System.Windows.Controls.ComboBox> control’s style to <xref:System.Windows.Controls.Toolbar.ComboBoxStyleKey?displayProperty=nameWithType> caused the dropdown arrow to be invisible. This issue is fixed starting with the .NET Framework 4.7.1. For example:

    Before: 

    ![Toolbar.ComboBoxStyleKey before accessibility improvements](media/comboboxstylekey-before.png) 
    
    After: 

    ![Toolbar.ComboBoxStyleKey after accessibility improvements](media/comboboxstylekey-after.png) 

- <xref:System.Windows.Controls.DataGrid> control

    Starting with the .NET Framework 4.7.1, the sort indicator arrow in <xref:System.Windows.Controls.DataGrid> controls now uses correct theme colors. For example:

    Before: 

    ![Sort indicator arrow before accessibility improvements](media/sort-indicator-before.png) 
    
    After:   
 
    ![Sort indicator arrow after accessibility improvements](media/sort-indicator-after.png) 
    
    In addition, in the .NET Framework 4.7 and earlier versions, the default link style changed to an incorrect color on mouse over in high contrast modes. This is resolved starting with the .NET Framework 4.7.1. Similarly, <xref:System.Windows.Controls.DataGrid> checkbox columns uses the expected colors for keyboard focus feedback starting with the .NET Framework 4.7.1.

    Before: 

    ![DataGrid default link style before accessibility improvements](media/default-link-style-before.png) 
 
    After:    
  
    ![DataGrid default link style after accessibility improvements](media/default-link-style-after.png)  

## Windows Forms accessibility improvements

In the .NET Framework 4.7.1, Windows Forms includes accessibility changes in the following areas.

Improved display during High Contrast mode
Improved property browser experience
Enhanced UI accessibility patterns
WPF – Changing implicit data templates
This feature enables the automatic update of elements that use implicit DataTemplates after changing a resource. When an application adds, removes, or replaces a value declared in a ResourceDictionary, WPF automatically updates all elements that use the value in most cases, including the implicit style case: <Style TargetType=”Button”. Here the value should apply to all buttons in the scope of the resource. This feature supports a similar update in the implicit data template case where the value should apply to all in-scope ContentPresenters whose content is a Book: <DataTemplate DataType=”{x:Type local:Book}”> 
This feature’s principal client is Visual Studio’s “Edit-and-Continue” facility, -when a user changes a DataTemplate resource in a running application and expects to see the effect of that change when the application continues. However it could also prove useful to any application with changing DataTemplate resources.
The feature is controlled by a new property ResourceDictionary.InvalidatesImplicitDataTemplateResources. After setting this to True, any changes  to DataTemplate resources in the dictionary will cause all ContentPresenters in the scope of the dictionary to re-evaluate their choice of DataTemplate. This is a moderately expensive process – our recommendation is to not to enable it unless you really need it.
WPF – Distinguishing dynamic values in a template
This feature enables a caller to determine whether a value obtained from a template is “dynamic”. Diagnostic assistants, such as Visual Studio’s “Edit-and-Continue” facility, need to know whether a templated value is dynamic, in order to propagate a user’s changes correctly.
The feature is implemented by a new method on the class DependencyPropertyHelper:

  public static bool IsTemplatedValueDynamic(DependencyObject elementInTemplate, DependencyProperty dependencyProperty);
view raw
Net471_WPF_DynamicValuesInTemplate.cs hosted with ❤ by GitHub 
This returns true if the template’s value for the given property is “dynamic”, that is if it declared via DynamicResourceReference or TemplateBinding, or via Binding or one of its derived classes.
WPF – SourceInfo for elements in templates
Diagnostic assistants such as Visual Studio’s “Edit-and-Continue” facility can use SourceInfo to locate the file and line number where a given element was declared.  The SourceInfo is now available for elements declared in a template loaded from XAML (as opposed to compiled BAML). This enables diagnostic assistants to do a better job. This feature is enabled automatically whenever SourceInfo itself is enabled.
WPF – Enable Visual Diagnostics
This feature provides a number of ways to control the VisualDiagnostic features. Diagnostic assistants can request WPF to share internal information. This feature gives both the assistant and the application developer more control over when this sharing is enabled.
The VisualDiagnostic features in WPF, with their introduction in .NET Framework 4.6, were initially only enabled when a managed debugger was attached. However, scenarios have arisen involving other components (besides a debugger) that can reasonably be considered as a diagnostic assistant, e.g. Visual Studio’s design surface. Thus, the need for a public way to control the features.  The feature is controlled by two new methods on the class VisualDiagnostics, and by a number of registry keys, app-context switches, and environment variables.

public static void EnableVisualTreeChanged();

public static void DisableVisualTreeChanged(); 
view raw
Net471_WPF_VisualDiagnostics.cs hosted with ❤ by GitHub 
The methods enable and disable the VisualTreeChanged event. You can only enable this event in a “diagnostic scenario”, defined as one of the following:
A debugger is attached
Windows 10 Developer Mode is set. More precisely, registry key HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\AppModelUnlock\AllowDevelopmentWithoutDevLicense has value 1
Environment variable ENABLE_XAML_DIAGNOSTICS_VISUAL_TREE_NOTIFICATIONS is set to a value different from “0” or “false” (case-insensitive).
Changes to the visual tree are disallowed while a VisualTreeChanged event is in progress. Specifically, an InvalidOperationException is thrown by any of the following actions:
Changing a visual or logical parent
Changing a resource dictionary
Changing a DependencyProperty value on a FrameworkElement or FrameworkContentElement.
This guards against unexpected and unsupported re-entrancy.
It is possible to override this InvalidOperationException, should you encounter a situation where debugging is impeded by it. To do so, add the following AppContext Switch to the <runtime> section of the app config file and set it to true, 
Switch.System.Windows.Diagnostics.AllowChangesDuringVisualTreeChanged
None of the features mentioned here are supported in production applications. They are intended only for diagnostic assistance.
Finally, you may want to run your application under the debugger, but in “production mode” without any potential interference from the VisualDiagnostic features. To do so, add the following AppContext Switch to the <runtime> section of the app config file and set it to true,




## See Also
[What's new in the .NET Framework](whats-new.md)   
 