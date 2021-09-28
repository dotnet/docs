---
description: "Learn more about: Windows Forms Configuration Section"
title: "Windows Forms Configuration Section"
ms.date: "04/07/2017"
ms.assetid: 6eb142d5-fc98-40e2-9d90-84733f2a27ba
---
# Windows Forms Configuration Section

Windows Forms configuration settings allow a Windows Forms app to store and retrieve information about customized application settings such as multi-monitor support, high DPI support, and other predefined configuration settings.

Windows Forms application configuration settings are stored in an application configuration file's `System.Windows.Forms.ApplicationConfigurationSection` element.

## Syntax

```xml
<configuration>
  <System.Windows.Forms.ApplicationConfigurationSection>
  ...
  </System.Windows.Forms.ApplicationConfigurationSection>
</configuration>
```

## Attributes and elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

None.

### Child elements

Element  |Description |
---------|---------|
[`<add>`](windows-forms-add-configuration-element.md) | Adds a configuration setting key with a specified value |

### Parent elements

Element  |Description |
---------|---------|
[\<configuration>](../configuration-element.md) | The root element in every configuration file used by the common language runtime and Windows Forms applications |

## Remarks

Starting with the .NET Framework 4.7, the `<System.Windows.Forms.ApplicationConfigurationSection>` element allows you to configure Windows Forms applications to take advantage of features added in recent releases of the .NET Framework.

The `<System.Windows.Forms.ApplicationConfigurationSection>` element can include one or more child [`<add>`](windows-forms-add-configuration-element.md) elements, each of which defines a specific configuration setting.

## See also

- [Configuration File Schema](../index.md)
- [High DPI Support in Windows Forms](/dotnet/desktop/winforms/high-dpi-support-in-windows-forms)
