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

The .NET Framework aims to make applications more accessibile for your users. Accessibility features allow an application to handle a range of devices and form factors seamlessly. By default, the accessibility features are enabled by default for applications that target the .NET Framework 4.7.1 or later. In addition, applications that target an earlier version of the .NET Framework but are running on the .NET Framework 4.7.1 can opt out of legacy accessibility behaviors by adding the following switch to the [`<AppContextSwitchOverrides>`](~/docs/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) element in the [`<runtime>`](~/docs/configure-apps/file-schema/runtime/index.md) section of the application's configuration file. 

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

### Windows Presentation Foundation (WPF)

**UIAutomation LiveRegion support**

Screen readers such as Narrator help people read the UI contents of an application, usually by text-to-speech output of the UI content that has the focus. However, if a UI element changes and does not have the focus, the user may not be notified and may miss important information. LiveRegions are meant to solve this problem. A developer can use them to inform the screen reader or any other UIAutomation client that an important change has been made to a UI element. The screen reader can then decide how and when to inform the user of this change. 

To support LiveRegions, the **AutomationProperties.LiveSetting** attached property informs the screen reader of the importance of the UI change to the user. 
In addition, the new <xref:System.Windows.Automation.AutomationElementIdentifiers.LiveSettingProperty?displayProperty=nameWithType> and <xref:System.Windows.Automation.AutomationElementIdentifiers.LiveRegionChangedEvent?displayProperty=nameWithType> fields can be set using XAML.

// <summary>Property ID: LiveSetting - Indicates the "politeness" level that a client should use to notify the user of changes to the live region. Supported starting with Windows 8. </summary>

public static readonly AutomationProperty LiveSettingProperty;



// <summary>Event ID: Raised when the content of a live region has changed. Supported starting with Windows 8.</summary> 

public static readonly AutomationEvent LiveRegionChangedEvent;  
view raw
Net471_WPF_LiveSetting.cs hosted with ❤ by GitHub 
A new DependencyProperty is now registered for “LiveSetting” under System.Windows.Automation.AutomationProperties, as well as Set and Get methods. System.Windows.Automation.Peers.AutomationPeer now has a new method GetLiveSettingCore, which can be overridden to provide a LiveSetting value.

public static readonly DependencyProperty LiveSettingProperty;

public static void SetLiveSetting(DependencyObject element, AutomationLiveSetting value); 

public static AutomationLiveSetting GetLiveSetting(DependencyObject element);

virtual protected AutomationLiveSetting GetLiveSettingCore();
view raw
Net471_WPF_LiveSetting_DependencyProperty.cs hosted with ❤ by GitHub 
A new enumeration for the possible values of LiveSetting has been added to System.Windows.Automation.

/// <summary>

       /// Describes the notification characteristics of a particular live region

       /// </summary>

       public enum AutomationLiveSetting

       {

              /// <summary>

              /// The element does not send notifications if the content of the live region has changed.

              /// </summary>

              Off = 0,



              /// <summary>

              /// The element sends non-interruptive notifications if the content of the live region has

              /// changed. With this setting, UI Automation clients and assistive technologies are expected 

              /// to not interrupt the user to inform of changes to the live region.

              /// </summary>

              Polite = 1,



              /// <summary>

              /// The element sends interruptive notifications if the content of the live region has changed. 

              /// With this setting, UI Automation clients and assistive technologies are expected to interrupt 

              /// the user to inform of changes to the live region.

              /// </summary>

              Assertive = 2,

        }
view raw
Net471_WPF_LiveSetting_Enum.cs hosted with ❤ by GitHub 
How to make a LiveRegion?
You can set the AutomationProperties.LiveSetting property on the element of interest to make it a “LiveRegion” as shown in the following sample.

<TextBlock Name="MyTextBlock" AutomationProperties.LiveSetting="Assertive">announcement</TextBlock>
view raw
Net471_WPF_LiveRegion_MakingLiveRegion.xml hosted with ❤ by GitHub 
Announcing an important UI change
When the data changes on your LiveRegion, and you feel the need to inform a screen reader about that change, you need to explicitly raise an event as illustrated by the following sample.

var peer = FrameworkElementAutomationPeer.FromElement(MyTextBlock);

peer.RaiseAutomationEvent(AutomationEvents.LiveRegionChanged);
view raw
Net471_WPF_LiveRegion_AnnounceChange.cs hosted with ❤ by GitHub 

## See Also
[What's new in the .NET Framework](whats-new.md)   
 