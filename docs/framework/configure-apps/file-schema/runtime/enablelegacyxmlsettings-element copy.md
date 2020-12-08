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

|Value|Description|
|-----------|-----------------|
|0|.|
|1.|

## Parent elements

|Element|Description|
|-------------|-----------------|
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|
|`runtime`|Contains information about runtime initialization options.|

## Remarks



## See also

- [\<runtime> Element](runtime-element.md)
- [\<configuration> Element](../configuration-element.md)
