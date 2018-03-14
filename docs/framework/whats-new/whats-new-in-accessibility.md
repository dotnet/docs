---
title: "What's new in accessibility in the .NET Framework"
ms.custom: "updateeachrelease"
ms.date: "10/13/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "what's new [.NET Framework]"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# What's new in accessibility in the .NET Framework

The .NET Framework aims at making applications more accessibile for your users. Accessibility features allow an application to provide an appropriate experience for users of Assistive Technology. Starting with the .NET Framework 4.7.1, the .NET Framework includes a large number of accessibility improvements that allow developers to create accessible applications. 

The new accessibility features are enabled by default for applications that target the .NET Framework 4.7.1 or later. In addition, applications that target an earlier version of the .NET Framework but are running on the .NET Framework 4.7.1 or later can opt out of legacy accessibility behaviors (and thereby opt in to the accessibility improvements in the .NET Framework 4.7.1) by adding the following switch to the [`<AppContextSwitchOverrides>`](~/docs/framework/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) element in the [`<runtime>`](~/docs/framework/configure-apps/file-schema/runtime/index.md) section of the application's configuration file. 

```xml
<runtime>
    <!-- AppContextSwitchOverrides value attribute is in the form of 'key1=true|false;key2=true|false  -->
    <AppContextSwitchOverrides value="Switch.UseLegacyAccessibilityFeatures=false" />
</runtime>
```

Similarly, applications that target versions of the .NET Framework starting with 4.7.1 can disable accessibility features by adding the following switch to the [`<AppContextSwitchOverrides>`](~/docs/framework/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) element in the [`<runtime>`](~/docs/framework/configure-apps/file-schema/runtime/index.md) section of the application's configuration file. 

```xml
<runtime>
    <!-- AppContextSwitchOverrides value attribute is in the form of 'key1=true|false;key2=true|false  -->
    <AppContextSwitchOverrides value="Switch.UseLegacyAccessibilityFeatures=true" />
</runtime>
```

## What's new in accessibility in the .NET Framework 4.7.1

The .NET Framework 4.7.1 includes new accessibility features in the following areas:

- [Windows Presentation Foundation (WPF)](#windows-presentation-foundation-wpf)

- [Windows Forms](#windows-forms-accessibility-improvements)

### Windows Presentation Foundation (WPF)

**Screen reader improvements**

If accessibility improvements are enabled, the .NET Framework 4.7.1 includes the following enhancements that affect screen readers:

- In the .NET Framework 4.7 and earlier versions, <xref:System.Windows.Controls.Expander> controls were announced by screen readers as buttons. Starting with the .NET Framework 4.7.1, they are correctly announced as expandable/collapsible groups.

- In the .NET Framework 4.7 and earlier versions, <xref:System.Windows.Controls.DataGridCell> controls were announced by screen readers as “custom.” Starting with the .NET Framework 4.7.1, they are now correctly announced as data grid cell (localized).
 
- Starting with the .NET Framework 4.7.1, screen readers announce the name of an editable <xref:System.Windows.Controls.ComboBox>.

- In the .NET Framework 4.7 and earlier versions, <xref:System.Windows.Controls.PasswordBox> controls were announced as “no item in view” or had otherwise incorrect behavior. This issue is fixed starting with the .NET Framework 4.7.1.     

**UIAutomation LiveRegion support**

Screen readers such as Narrator help people read the UI contents of an application, usually by text-to-speech output of the UI content that has the focus. However, if a UI element changes and does not have the focus, the user may not be notified and may miss important information. Live regions aim at solving this problem. A developer can use them to inform the screen reader or any other UIAutomation client that an important change has been made to a UI element. The screen reader can then decide how and when to inform the user of this change. 

To support live regions, the following APIs have been added to WPF:

- The <xref:System.Windows.Automation.AutomationElementIdentifiers.LiveSettingProperty?displayProperty=nameWithType> and <xref:System.Windows.Automation.AutomationElementIdentifiers.LiveRegionChangedEvent?displayProperty=nameWithType> fields, which identify the **LiveSetting** property and the **LiveRegionChanged** event. They can be set by using XAML.

- The **AutomationProperties.LiveSetting** attached property, which informs the screen reader of the importance of the UI change to the user.

- The <xref:System.Windows.Automation.AutomationProperties.LiveSettingProperty?displayProperty=nameWithType> property, which identifies the **AutomationProperties.LiveSetting** attached property.
 
- The <xref:System.Windows.Automation.Peers.AutomationPeer.GetLiveSettingCore%2A?displayProperty=nameWithType> method, which can be overridden to provide a **LiveSetting** value.

- The <xref:System.Windows.Automation.AutomationProperties.GetLiveSetting%2A?displayProperty=nameWithType> and <xref:System.Windows.Automation.AutomationProperties.SetLiveSetting%2A?displayProperty=nameWithType> methods, which get and set a **LiveSetting** value.
 
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

Starting with the .NET Framework 4.7.1, improvements in high contrast have been made to various WPF controls. They are now visible when the <xref:System.Windows.SystemParameters.HighContrast%2A> theme is set. These include:

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

    Finally, in the .NET Framework 4.7 and earlier versions, setting a <xref:System.Windows.Controls.ComboBox> control’s style to `Toolbar.ComboBoxStyleKey` caused the drop-down arrow to be invisible. This issue is fixed starting with the .NET Framework 4.7.1. For example:

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

For more information on WPF accessibility improvements in the .NET Framework 4.7.1, see [Accessibility improvements in WPF](../migration-guide/retargeting/4.7-4.7.1.md#accessibility-improvements-in-wpf).

## Windows Forms accessibility improvements

In the .NET Framework 4.7.1, Windows Forms (WinForms) includes accessibility changes in the following areas.

**Improved display in High Contrast mode**

Starting with the .NET Framework 4.7.1, various WinForms controls offer improved rendering in the HighContrast modes available in the operating system. Windows 10 has changed the values for some high contrast system colors, and Windows Forms is based on the Windows 10 Win32 framework. For the best experience, run on the latest version of Windows and opt in to the latest OS changes by adding an app.manifest file in a test application and un-comment the Windows 10 supported OS  line so that it looks the following:

```xml
<!-- Windows 10 -->
<supportedOS Id=”{8e0f7a12-bfb3-4fe8-b9a5-48fd50a15a9a}” />
```
Some examples of high contrast changes include:

- Checkmarks in <xref:System.Windows.Forms.MenuStrip> items are easier to view.

- When selected, disabled <xref:System.Windows.Forms.MenuStrip> items are easier to view.

- Text in a selected <xref:System.Windows.Forms.Button> control contrasts with the selection color.

- Disabled text is easier to read. For example:

    Before:

    ![Disabled text before accessibility improvements](media/wf-disabled-before.png) 

    After:

    ![Disabled text after accessibility improvements](media/wf-disabled-after.png) 

- High contrast improvements in the Thread Exception Dialog.

**Improved Narrator support**

Windows Forms in the .NET Framework 4.7.1 includes the following accessibility improvements for the Narrator:

- The <xref:System.Windows.Forms.MonthCalendar> control can be accessed by the Narrator, as well as by other UI automation tools.

- The <xref:System.Windows.Forms.CheckedListBox> control notifies Narrator when an item's check state has changed so the user is notified that they’ve changed the value of a list item.
 
- The <xref:System.Windows.Forms.DataGridViewCell> control reports the correct read-only status to Narrator.
 
- Narrator can now read disabled <xref:System.Windows.Forms.ToolStripMenuItem> text, whereas previously it would skip over disabled menu items.

**Enhanced support for UIAutomation accessibility patterns**

Starting with the .NET Framework 4.7.1, developers of accessibility technology tools can leverage common API accessibility patterns and properties for several WinForms controls. These accessibility improvements include:

- The <xref:System.Windows.Forms.ComboBox> and <xref:System.Windows.Forms.ToolStripSplitButton> now support the [expand/collapse pattern](../ui-automation/implementing-the-ui-automation-expandcollapse-control-pattern.md).
 
- The <xref:System.Windows.Forms.DataGridViewCheckBoxCell> now supports the [toggle pattern](../ui-automation/implementing-the-ui-automation-toggle-control-pattern.md).
 
- The <xref:System.Windows.Forms.ToolStripItem> control supports the <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.Name> property and the [expand/collapse pattern](../ui-automation/implementing-the-ui-automation-expandcollapse-control-pattern.md).

- The <xref:System.Windows.Forms.NumericUpDown> and <xref:System.Windows.Forms.DomainUpDown> controls support the <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.Name> property.

**Improved property browser experience**

Starting with the .NET Framework 4.7.1, Windows Forms includes:

- Better keyboard navigation through the various drop-down selection windows.
- A reduction of unnecessary tab stops.
- Better reporting of control types.
- Improved narrator behavior.
 
## See Also
[What's new in the .NET Framework](whats-new.md)   
 
