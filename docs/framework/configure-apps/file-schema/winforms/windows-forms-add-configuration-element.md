---
title: "Windows Forms Add Configuration Element | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Windows Forms Add configuration element"
  - "configuring Windows Forms applications"
ms.assetid: 3e3e04de-99d1-4658-b716-44cb669d9589
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Windows Forms Add Configuration Element

The `<add>` element adds a predefined key that specifies whether your Windows Form app supports features added to Windows Forms apps in the .NET Framework 4.7 or later.

## Syntax

```xml
   <add key="key-name" value="key-value" />
```

## Attributes and elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

Attribute  | Description  |
---------|---------|
`key` | Required attribute. A predefined key name that corresponds to a particular Windows Forms customizable feature. |
`value` | Required attribute. The value to assign to `key`. |

### `key` attribute names and associated values


`key` name | Values  | Description  |
---------|---------|---------|
"AnchorLayout.DisableSinglePassControlScaling"  | "true"&#124;"false" | Indicates whether anchored controls are scaled in a single pass. "true" to disable single pass scaling; otherwise, false. "false" is the default. See the "Single pass scaling" section in the [Remarks](#Remarks) for more information. |
"DpiAwareness" | "PerMonitorV2"&#124;"false"  |Indicates whether an application is DPI-aware. Set the key to "PerMonitorV2" (the default) to support Dpi awareness; otherwise, set it to "false". See the [Remarks](#remarks) section for more information. |
"CheckedListBox.DisableHighDpiImprovements"  | "true"&#124;"false" | Indicates whether the <!--zz [CheckedListBox](xref:System.Windows.Forms.CheckListBox) --> `CheckedListBox` control is DPI-aware. "true" to opt out of DPI awareness; "false" otherwise. "false" is the default value. |
"DataGridView.DisableHighDpiImprovements"  | "true"&#124;"false" | Indicates whether the [DataGridView](xref:System.Windows.Forms.DataGridView) control is DPI-aware. "true" to opt out of DPI awareness; "false" otherwise. "false" is the default value. |
"DisableDpiChangedMessageHandling"  | "true"&#124;"false" | "true" to opt out of receiving messages related to DPI scaling changes; "false" otherwise. "false" is the default value." See the [Remarks](#remarks) section for more information. |
"EnableWindowsFormsHighDpiAutoResizing" | "true"&#124;"false" | Indicates whether a Windows Forms application is automatically resized due to DPI scaling changes. "true" to enable automatic resizing; otherwise, false. "true" is the default. |
"Form.DisableSinglePassControlScaling"  | "true"&#124;"false" | Indicates whether the [Form](xref:System.Windows.Forms.Form) is scaled in a single pass. "true" to disable single pass scaling; otherwise, false. "false" is the default. See the "Single pass scaling" section in the [Remarks](#Remarks) for more information. |
"MonthCalendar.DisableSinglePassControlScaling"  | "true"&#124;"false" | Indicates whether the [MonthCalendar](xref:System.Windows.Forms.MonthCalendar) control is scaled in a single pass. "true" to disable single pass scaling; otherwise, false. "false" is the default. See the "Single pass scaling" section in the [Remarks](#Remarks) for more information. |
"Toolstrip.DisableHighDpiImprovements" | "true"&#124;"false" | Indicates whether the `Toolstrip` control is DPI-aware. "true" to opt out of DPI awareness; "false" otherwise. "false" is the default value. |

### Child elements

None.

### Parent elements

Element  |Description |
---------|---------|
| [`<System.Windows.Forms.ConfigurationSection>`](../../../../../docs/framework/configure-apps/file-schema/winforms/index.md) | Configures support for new Windows Forms application features. |

## <a name="remarks" /> Remarks

Starting with the .NET Framework 4.7, the `<System.Windows.Forms.ConfigurationSection>` element allows you to configure Windows Forms applications to take advantage of features added in recent releases of the .NET Framework. 

The `<System.Windows.Forms.ConfigurationSection>` element allows you to add one or more child `<add>` elements, each of which defines a specific configuration setting.  

For an overview of Windows Forms High DPI support, see [High DPI Support in Windows Forms](../../../../../docs/framework/winforms/high-dpi-support-in-windows-forms.md).

### DpiAwareness

Apps that target the .NET Framework starting with version 4.7 are DPI-aware by default. You can disable high DPI awareness by setting this value to `false`. 

Apps that target earlier versions of the .NET Framework but are running on the .NET Framework 4.7 can opt into Windows Forms' support for high DPI awarness by setting this value to `PerMonitorV2`.

The value of the `DpiAwareness` key defines whether whether related features are enabled or disabled if their related keys are not present in the `<System.Windows.Forms.ConfigurationSection>` section of the application configuration file. In other words, if DPI awareness is enabled, the features controlled by keys such as `DisableDpiChangedMessageHandling`, `EnableWindowsFormsHighDpiAutoResizing`, and `Toolstrip.DisableHighDpiImprovements` are also enabled.   
 
### DisableDpiChangedMessageHandling

Starting with the .NET Framework 4.7, Windows Forms controls raise a number of events related to changes in DPI scaling. These include the [Control.DpichangedAfterParent](xref:System.Windows.Forms.Control.DpiChangedAfterParent), [Control.DpiChangedBeforeParent](xref:System.Windows.Forms.Control.DpiChangedBeforeParent), and [Form.DpiChanged](xref:System.Windows.Forms.Form.DpiChanged) events. The value of the `DisableDpiChangedMessageHandling` key determines whether these events are raised in a Windows Forms application.

### Single pass scaling

Single or multi-pass scaling influences the perceived responsiveness of the user interface and the the visual appearance of user interface elements as they are scaled. By default, Windows Forms uses single pass scaling. For higher-quality resolution that requires greater processing time, or for significant changes in scaling, you might prefer to disable single pass scaling. 

## See also

[Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)    
[Windows Forms Configuration Section](../../../../../docs/framework/configure-apps/file-schema/winforms/index.md)   
[High DPI Support in Windows Forms](../../../../../docs/framework/winforms/high-dpi-support-in-windows-forms.md)
