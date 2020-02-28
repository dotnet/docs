---
title: GCNoAffinitize element
ms.date: 11/08/2019
helpviewer_keywords:
  - "gcNoAffinitize element"
  - "<gcNoAffinitize> element"
---
# \<GCNoAffinitize> element

Specifies whether or not to affinitize server GC threads with CPUs.

\<configuration>\
&nbsp;&nbsp;\<runtime>\
&nbsp;&nbsp;&nbsp;&nbsp;\<GCNoAffinitize>

## Syntax

```xml
<GCNoAffinitize
   enabled="true|false"/>
```

## Attributes and elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

|Attribute|Description|
|---------------|-----------------|
|`enabled`|Required attribute.<br /><br />Specifies whether server GC threads/heaps are affinitized with the processors available on the machine.|

#### enabled attribute

|Value|Description|
|-----------|-----------------|
|`false`|Affinitizes server GC threads with CPUs. This is the default.|
|`true`|Does not affinitize server GC threads with CPUs.|

### Child elements

None.

### Parent elements

|Element|Description|
|-------------|-----------------|
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|
|`runtime`|Contains information about assembly binding and garbage collection.|

## Remarks

By default, server GC threads are hard-affinitized with their respective CPUs. Each of the system's available processors has its own GC heap and thread. This is typically the preferred setting since it optimizes cache usage. Starting with .NET Framework 4.6.2, by setting the **GCNoAffinitize** element's `enabled` attribute to `false`, you can specify that server GC threads and CPUs should not be tightly coupled.

You can specify the **GCNoAffinitize** configuration element alone to not affinitize server GC threads with CPUs. You can also use it along with the [GCHeapCount](gcheapcount-element.md) element to control the number of GC heaps and threads used by an application.

If the `enabled` attribute of the **GCNoAffinitize** element is `false` (its default value), you can also use the [GCHeapCount](gcheapcount-element.md) element to specify the number of GC threads and heaps, along with the [GCHeapAffinitizeMask](gcheapaffinitizemask-element.md) element to specify the processors to which the GC threads and heaps are affinitized.

## Example

The following example does not hard-affinitize server GC threads:

```xml
<configuration>
   <runtime>
      <gcServer enabled="true"/>
      <GCNoAffinitize enabled="true"/>
   </runtime>
</configuration>
```

The following example does not affinitize server GC threads and limits the number of GC heaps/threads to 10:

```xml
<configuration>
   <runtime>
      <gcServer enabled="true"/>
      <GCHeapCount enabled="10"/>
      <GCNoAffinitize enabled="true"/>
   </runtime>
</configuration>
```

## See also

- <xref:System.Runtime.GCSettings.IsServerGC%2A?displayProperty=nameWithType>
- [GCHeapAffinitizeMask element](gcheapaffinitizemask-element.md)
- [GCHeapCount element](gcheapcount-element.md)
- [Fundamentals of garbage collection](../../../../standard/garbage-collection/fundamentals.md)
- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
