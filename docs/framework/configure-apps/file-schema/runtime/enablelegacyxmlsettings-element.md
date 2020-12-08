---
title: EnableLegacyXmlSettings element
ms.date: 12/08/2020
---
# \<EnableLegacyXmlSettings> Element

Specifies whether to use XML parsing settings from .NET Framework 4.5.1 and earlier versions.

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<EnableLegacyXmlSettings>**

## Syntax

```xml
<EnableLegacyXmlSettings enabled="0"|"1" />
```

## Attributes

|Attribute|Description|
|---------------|-----------------|
|`enabled`|Required attribute.<br /><br />Specifies whether to use XML parsing settings from .NET Framework 4.5.1 and earlier versions.|

### enabled attribute

| Value | Description                           |
|-------|---------------------------------------|
| 0     | Don't use legacy XML reader settings. |
| 1     | Use legacy XML reader settings.       |

## Parent elements

| Element         | Description                                                                                                       |
|-----------------|-------------------------------------------------------------------------------------------------------------------|
| `configuration` | The root element in every configuration file used by the common language runtime and .NET Framework applications. |
| `runtime`       | Contains information about runtime initialization options.                                                        |

## Remarks

A breaking change was introduced in .NET Framework 4.5.2. The following default values were changed:

- <xref:System.Xml.XmlReaderSettings.MaxCharactersFromEntities?displayProperty=nameWithType> is set to 10 million by default.
- <xref:System.Xml.XmlReaderSettings.XmlResolver?displayProperty=nameWithType> is set to `null` by default.

To revert to pre-4.5.2 defaults, set the `EnableLegacyXmlSettings` element to `1`.

## See also

- [\<runtime> Element](runtime-element.md)
- [\<configuration> Element](../configuration-element.md)
- [XML runtime changes for .NET Framework 4.5.2](../../../migration-guide/runtime/4.5.1-4.5.2.md)
