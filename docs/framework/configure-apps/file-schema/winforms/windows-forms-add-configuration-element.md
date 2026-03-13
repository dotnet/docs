---
description: "Learn more about: Windows Forms Add Configuration Element"
title: "Windows Forms Add Configuration Element"
ms.date: "03/04/2026"
helpviewer_keywords:
  - "Windows Forms Add configuration element"
  - "configuring Windows Forms applications"
ms.assetid: 3e3e04de-99d1-4658-b716-44cb669d9589
ai-usage: ai-assisted
---

# Windows Forms Add Configuration Element

The `<add>` element adds a predefined key that specifies whether your Windows Form app supports features added to Windows Forms apps in the .NET Framework 4.7 or later.

## Syntax

```xml
<System.Windows.Forms.ApplicationConfigurationSection>
  <add key="key-name" value="key-value" />
</System.Windows.Forms.ApplicationConfigurationSection>
```

## Attributes and elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

| Attribute | Description |
| --------- | ----------- |
| `key`     | Required attribute. A predefined key name that corresponds to a particular Windows Forms customizable feature. |
| `value`   | Required attribute. The value to assign to `key`. |

### `key` attribute names and associated values

| `key` name | Values | Description |
| ---------- | ------ | ----------- |
| "AnchorLayout.DisableSinglePassControlScaling" | "true"&#124;"false" | Indicates whether anchored controls are scaled in a single pass. "true" to disable single pass scaling; otherwise, false. See the "Single pass scaling" section in the [Remarks](#remarks) for more information. |
| "DpiAwareness" | "PerMonitorV2"&#124;"false" | Indicates whether an application is DPI-aware. Set the key to "PerMonitorV2" to support Dpi awareness; otherwise, set it to "false". DPI awareness is an opt-in feature; to take advantage of Windows Forms' high DPI support, you should set its value to "PerMonitorV2". See the [Remarks](#remarks) section for more information. |
| "CheckedListBox.DisableHighDpiImprovements" | "true"&#124;"false" | Indicates whether the <xref:System.Windows.Forms.CheckedListBox> control takes advantage of scaling and layout improvements introduced in .NET Framework 4.7. "true" to opt out of scaling and layout improvements; otherwise, "false". |
| "DataGridView.DisableHighDpiImprovements" | "true"&#124;"false" | Indicates whether the <xref:System.Windows.Forms.DataGridView> control scaling and layout improvements introduced in .NET Framework 4.7. "true" to opt out of DPI awareness; "false" otherwise. |
| "DisableDpiChangedMessageHandling" | "true"&#124;"false" | "true" to opt out of receiving messages related to DPI scaling changes; "false" otherwise. See the [Remarks](#remarks) section for more information. |
| "EnableWindowsFormsHighDpiAutoResizing" | "true"&#124;"false" | Indicates whether a Windows Forms application is automatically resized due to DPI scaling changes. "true" to enable automatic resizing; otherwise, false. |
| "Form.DisableSinglePassControlScaling" | "true"&#124;"false" | Indicates whether the <xref:System.Windows.Forms.Form> is scaled in a single pass. "true" to disable single-pass scaling; otherwise, false. See the "Single pass scaling" section in the [Remarks](#remarks) for more information. |
| "MonthCalendar.DisableSinglePassControlScaling" | "true"&#124;"false" | Indicates whether the <xref:System.Windows.Forms.MonthCalendar> control is scaled in a single pass. "true" to disable single-pass scaling; otherwise, false. See the "Single pass scaling" section in the [Remarks](#remarks) for more information. |
| "Toolstrip.DisableHighDpiImprovements" | "true"&#124;"false" | Indicates whether the <xref:System.Windows.Forms.ToolStrip> control takes advantage of scaling and layout improvements introduced in .NET Framework 4.7. "true" to opt out of DPI awareness; "false" otherwise. |

### Child elements

None.

### Parent elements

| Element | Description |
| ------- | ----------- |
| [`<System.Windows.Forms.ApplicationConfigurationSection>`](index.md) | Configures support for new Windows Forms application features. |

## Remarks

Starting with .NET Framework 4.7, the `<System.Windows.Forms.ApplicationConfigurationSection>` element allows you to configure Windows Forms applications to take advantage of features added in recent releases of the .NET Framework.

The `<System.Windows.Forms.ApplicationConfigurationSection>` element allows you to add one or more child `<add>` elements, each of which defines a specific configuration setting.

For an overview of Windows Forms High DPI support, see [High DPI Support in Windows Forms](/dotnet/desktop/winforms/high-dpi-support-in-windows-forms).

### DpiAwareness

Windows Forms apps that run under Windows versions starting with Windows 10 Creators Edition and target versions of the .NET Framework starting with the .NET Framework 4.7 can be configured to take advantage of high DPI improvements introduced in .NET Framework 4.7. These include:

- Support for dynamic DPI scenarios in which the user changes the DPI or scale factor after a Windows Forms application has been launched.

- Improvements in the scaling and layout of a number of Windows Forms controls, such as the <xref:System.Windows.Forms.MonthCalendar> control and the <xref:System.Windows.Forms.CheckedListBox> control.

High DPI awareness is an opt-in feature; by default, the value of `DpiAwareness` is `false`. You can opt in to Windows Forms' support for DPI awareness by setting the value of this key to `PerMonitorV2` in the application configuration file. If DPI awareness is enabled, all individual DPI features are also enabled. These include:

- DPI changed messages, which are controlled by the `DisableDpiChangedMessageHandling` key.

- Dynamic DPI support, which is controlled by the `EnableWindowsFormsHighDpiAutoResizing` key.

- Single-pass control scaling, which is controlled by the `Form.DisableSinglePassControlScaling` for individual <xref:System.Windows.Forms.Form> controls, by the `AnchorLayout.DisableSinglePassControlScaling` key for anchored controls, and by the `MonthCalendar.DisableSinglePassControlScaling` key for the <xref:System.Windows.Forms.MonthCalendar> control

- High DPI scaling and layout improvements, which is controlled by the `CheckListBox.DisableHighDpiImprovements` key for the <xref:System.Windows.Forms.CheckedListBox> control, by the `DataGridView.DisableHighDpiImprovements` key for the <xref:System.Windows.Forms.DataGridView> control, and by the `Toolstrip.DisableHighDpiImprovements` key for the <xref:System.Windows.Forms.ToolStrip> control.

The single default opt-in setting provided by setting `DpiAwareness` to `PerMonitorV2` is generally adequate for new Windows Forms applications. However, You can then opt out of individual high DPI improvements by adding the corresponding key to the application configuration file. For example, to take advantage of all the new DPI features except for dynamic DPI support, you would add the following to your application configuration file:

```xml
<System.Windows.Forms.ApplicationConfigurationSection>
   <add key="DpiAwareness" value="PerMonitorV2" />
   <!-- Disable dynamic DPI support -->
   <add key="EnableWindowsFormsHighDpiAutoResizing" value="false" />
</System.Windows.Forms.ApplicationConfigurationSection>
```

Typically, you opt out of a particular feature because you've chosen to handle it programmatically.

For more information on taking advantage of High DPI support in Windows Forms applications, see [High DPI Support in Windows Forms](/dotnet/desktop/winforms/high-dpi-support-in-windows-forms).

### AutoScaleMode

The default <xref:System.Windows.Forms.AutoScaleMode.Font?displayProperty=nameWithType> mode scales controls based on the current system font size. Font metrics can vary at different DPI levels, so Font scaling might not be linear when the app runs as system DPI-aware or per-monitor v2 DPI-aware (see <xref:System.Windows.Forms.HighDpiMode.SystemAware> and <xref:System.Windows.Forms.HighDpiMode.PerMonitorV2>). This can cause discrepancies in height-to-width ratios. The <xref:System.Windows.Forms.AutoScaleMode.Dpi?displayProperty=nameWithType> mode is always linear and doesn't have this limitation.

Keep in mind that certain controls—such as <xref:System.Windows.Forms.TextBox> and <xref:System.Windows.Forms.Label>—always use Font scaling regardless of the `AutoScaleMode` setting. Because of these per-control differences, it's not always straightforward to determine which mode works better without knowing your specific design requirements.

Starting with .NET 8, when a Windows Forms app runs in `PerMonitorV2` DPI awareness, top-level window sizing respects <xref:System.Windows.Forms.AutoScaleMode>, which improves consistency with how child controls scale. For more information, see [Top-level window scaling](../../../../core/compatibility/windows-forms/8.0/top-level-window-scaling.md).

### DisableDpiChangedMessageHandling

Starting with .NET Framework 4.7, Windows Forms controls raise a number of events related to changes in DPI scaling. These include the <xref:System.Windows.Forms.Control.DpiChangedAfterParent>, <xref:System.Windows.Forms.Control.DpiChangedBeforeParent>, and <xref:System.Windows.Forms.Form.DpiChanged> events. The value of the `DisableDpiChangedMessageHandling` key determines whether these events are raised in a Windows Forms application.

### Single-pass scaling

Single or multi-pass scaling influences the perceived responsiveness of the user interface and the visual appearance of user interface elements as they are scaled. Starting with .NET Framework 4.7, Windows Forms uses single pass scaling. In previous versions of the .NET Framework, scaling was performed through multiple passes, which caused some controls to be scaled more than was necessary. Single-pass scaling should only be disabled if your app depends on the old behavior.

## See also

- [Windows Forms Configuration Section](index.md)
- [High DPI Support in Windows Forms](/dotnet/desktop/winforms/high-dpi-support-in-windows-forms)
