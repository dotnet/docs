---
description: "Learn more about: <NetFx45_CultureAwareComparerGetHashCode_LongStrings> Element"
title: "<NetFx45_CultureAwareComparerGetHashCode_LongStrings> Element"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "NetFx45_CultureAwareComparerGetHashCode_LongStrings element"
  - "<NetFx45_CultureAwareComparerGetHashCode_LongStrings> element"
  - "GetHashCode method"
  - "hash codes, calculating"
ms.assetid: 3a5f38d1-ebc8-44de-aaeb-2929f6e6b48f
---
# \<NetFx45_CultureAwareComparerGetHashCode_LongStrings> Element

Specifies whether the runtime uses a fixed amount of memory to calculate hash codes for the <xref:System.StringComparer.GetHashCode%2A?displayProperty=nameWithType> method.

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<NetFx45_CultureAwareComparerGetHashCode_LongStrings>**  

## Syntax

```xml
<NetFx45_CultureAwareComparerGetHashCode_LongStrings enabled="0|1">
```

## Attributes and Elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

|Attribute|Description|
|---------------|-----------------|
|`enabled`|Required attribute.<br /><br /> Specifies whether the common language runtime allocates a fixed amount of memory when calculating hash codes.|

## enabled Attribute

|Value|Description|
|-----------|-----------------|
|0|The common language runtime allocates a variable amount of memory for the <xref:System.StringComparer.GetHashCode%2A?displayProperty=nameWithType> method to calculate hash codes. This is the default.|
|1|The common language runtime allocates a fixed amount of memory for the <xref:System.StringComparer.GetHashCode%2A?displayProperty=nameWithType> method to calculate hash codes.|

### Child Elements

None.

### Parent Elements

|Element|Description|
|-------------|-----------------|
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|
|`runtime`|Contains information about runtime initialization options.|

## Remarks

By default, the common language runtime allocates a variable amount of memory for the <xref:System.StringComparer.GetHashCode%2A?displayProperty=nameWithType> method, and an <xref:System.ArgumentException> can be thrown when the method attempts to compute the hash code of very large strings (over several million characters long). By adding this element to an application configuration file and setting its `enabled` attribute to "1", you can specify that the <xref:System.StringComparer.GetHashCode%2A?displayProperty=nameWithType> method use an alternate algorithm that allocates a fixed amount of memory for the computation of hash codes.

> [!IMPORTANT]
> The `<NetFx45_CultureAwareComparerGetHashCode_LongStrings>` element is not used in Windows 8 and later versions.

## See also

- <xref:System.StringComparer.GetHashCode%2A?displayProperty=nameWithType>
- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
