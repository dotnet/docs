---
description: "Learn more about: <Thread_UseAllCpuGroups> Element"
title: "<Thread_UseAllCpuGroups> Element"
ms.date: "03/30/2017"
ms.assetid: d30fe7c5-8469-46e2-b804-e3eec7b24256
---
# \<Thread_UseAllCpuGroups> Element

Specifies whether the runtime distributes managed threads across all CPU groups.

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<Thread_UseAllCpuGroups>**  

## Syntax

```xml
<Thread_UseAllCpuGroups
   enabled="true|false"/>
```

## Attributes and Elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

|Attribute|Description|
|---------------|-----------------|
|`enabled`|Required attribute.<br /><br /> Specifies whether the runtime distributes managed threads across all CPU groups.|

## enabled Attribute

|Value|Description|
|-----------|-----------------|
|`false`|The runtime does not distribute managed threads across multiple CPU groups. This is the default.|
|`true`|The runtime distributes managed threads across multiple CPU groups, if the computer has multiple CPU groups and the [\<GCCpuGroup>](gccpugroup-element.md) element is enabled.|

### Child Elements

None.

### Parent Elements

|Element|Description|
|-------------|-----------------|
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|
|`runtime`|Contains information about assembly binding and garbage collection.|

## Remarks

When a computer has multiple CPU groups, enabling this element causes the runtime to distribute managed threads across all CPU groups. To use this feature, you must also enable the [\<GCCpuGroup>](gccpugroup-element.md) element, which extends garbage collection to all CPU groups and takes all cores into account when creating and balancing heaps. Enabling the [\<GCCpuGroup>](gccpugroup-element.md) element requires enabling the [\<gcServer>](gcserver-element.md) element. If these elements are not enabled, enabling the `<Thread_UseAllCpuGroups>` element has no effect.

## Example

The following example shows how to enable support for multiple CPU groups.

```xml
<configuration>
   <runtime>
      <Thread_UseAllCpuGroups enabled="true"/>
      <GCCpuGroup enabled="true"/>
      <gcServer enabled="true"/>
   </runtime>
</configuration>
```

## See also

- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
- [\<GCCpuGroup> Element](gccpugroup-element.md)
