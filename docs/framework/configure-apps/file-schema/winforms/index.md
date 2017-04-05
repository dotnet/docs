---
title: "Windows Forms Configuration Section | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6eb142d5-fc98-40e2-9d90-84733f2a27ba
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
---
# Windows Forms Configuration Section
Windows Forms configuration settings allow a Windows Forms app to store and retrieve information about customized application settings such as multi-monitor support, high DPI support, and other predefined configuration settings.

Windows Forms application configuration settings are stored in an application configuration file's `System.Windows.Forms.ConfigurationSection` element.

## Syntax

```xml
<configuration>
   \<System.Windows.Forms.ConfigurationSection>
   \</System.Windows.Forms.ConfigurationSection>
</configuration>
```

## Attributes and elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

None.

### Child elements

Element  |Description |
---------|---------|
[`<add>`](../../../../../docs/framework/configure-apps/file-schema/winforms/windows-forms-add-configuration-element.md) | Adds a configuration setting key with a specified value |

### Parent elements

Element  |Description |
---------|---------|
[`<configuration>`](../../../../../docs/framework/configure-apps/file-schema/index.md) | The root element in every configuration file used by the common language runtime and Windows Forms applications |

## Remarks

Starting with the .NET Framework 4.7, the `<System.Windows.Forms.ConfigurationSection>` element allows you to configure Windows Forms applications to take advantage of features added in recent releases of the .NET Framework. 

The `<System.Windows.Forms.ConfigurationSection>` element can include one or more child [`<add>`](../../../../../docs/framework/configure-apps/file-schema/winforms/windows-forms-add-configuration-element.md) elements, each of which defines a specific configuration setting.

## See also

[Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)   
[High DPI Support in Windows Forms](../../../../../docs/framework/winforms/high-dpi-support-in-windows-forms.md)
