---
title: "<GCCpuGroup> Element"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "GCCpuGroup element"
  - "<GCCpuGroup> element"
ms.assetid: c1fc7d6c-7220-475c-a312-5b8b201f66e0
author: "rpetrusha"
ms.author: "ronpet"
---
# \<GCCpuGroup> Element

Specifies whether garbage collection supports multiple CPU groups.

\<configuration>\
\<runtime>\
\<GCCpuGroup>

## Syntax

```xml
<GCCpuGroup
   enabled="true|false"/>
```

## Attributes and Elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

|Attribute|Description|
|---------------|-----------------|
|`enabled`|Required attribute.<br /><br /> Specifies whether garbage collection supports multiple CPU groups.|

## enabled Attribute

|Value|Description|
|-----------|-----------------|
|`false`|Garbage collection does not support multiple CPU groups. This is the default.|
|`true`|Garbage collection supports multiple CPU groups, if server garbage collection is enabled.|

### Child Elements

None.

### Parent Elements

|Element|Description|
|-------------|-----------------|
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|
|`runtime`|Contains information about assembly binding and garbage collection.|

## Remarks

When a computer has multiple CPU groups and server garbage collection is enabled (see the [\<gcServer>](gcserver-element.md) element), enabling this element extends garbage collection across all CPU groups and takes all cores into account when creating and balancing heaps.

> [!NOTE]
> This element applies only to garbage collection threads. To enable the runtime to distribute user threads across all CPU groups, you must also enable the [\<Thread_UseAllCpuGroups>](thread-useallcpugroups-element.md) element.

## Example

The following example shows how to enable garbage collection for multiple CPU groups.

```xml
<configuration>
   <runtime>
      <GCCpuGroup enabled="true"/>
      <gcServer enabled="true"/>
   </runtime>
</configuration>
```

## See also

- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
- [To disable concurrent garbage collection](gcconcurrent-element.md#to-disable-background-garbage-collection)
- [Workstation and server garbage collection](../../../../../docs/standard/garbage-collection/fundamentals.md#workstation-and-server-garbage-collection)
