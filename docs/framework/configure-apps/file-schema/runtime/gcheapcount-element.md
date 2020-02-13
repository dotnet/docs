---
title: GCHeapCount element
ms.date: 11/08/2019
helpviewer_keywords:
  - "gcHeapCount element"
  - "<gcHeapCount> element"
---
# \<GCHeapCount> element

Specifies the number of heaps/threads to use for server garbage collection.

\<configuration>\
&nbsp;&nbsp;\<runtime>\
&nbsp;&nbsp;&nbsp;&nbsp;\<GCHeapCount>

## Syntax

```xml
<GCHeapCount
   enabled="nn"/>
```

## Attributes and elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

|Attribute|Description|
|---------------|-----------------|
|`enabled`|Required attribute.<br /><br />Specifies the number of heaps to use for server garbage collection. The actual number of heaps is the minimum of the number of heaps you specify and the number of processors your process is allowed to use. |

#### enabled attribute

|Value|Description|
|-----------|-----------------|
|`nn`|The number of heaps to use for server GC.|

### Child elements

None.

### Parent elements

|Element|Description|
|-------------|-----------------|
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|
|`runtime`|Contains information about assembly binding and garbage collection.|

## Remarks

By default, server GC threads are hard-affinitized with their respective CPU so that there is one GC heap, one server GC thread, and one background server GC thread for each processor. Starting with .NET Framework 4.6.2, you can use the **GCHeapCount** element to limit the number of heaps used by your application for server GC. Limiting the number of heaps used for server GC is particularly useful for systems that run multiple instances of a server application.

**GCHeapCount** is typically used along with two other flags:

- [GCNoAffinitize](gcnoaffinitize-element.md), which controls whether server GC threads/heaps are affinitized with CPUs.

- [GCHeapAffinitizeMask](gcheapaffinitizemask-element.md), which controls the affinity of GC threads/heaps with CPUs.

If **GCHeapCount** is set and **GCNoAffinitize** is disabled (its default setting), there is an affinity between the *nn* GC threads/heaps and the first *nn* processors. You can use the **GCHeapAffinitizeMask** element to specify which processors are used by the process's server GC heaps. Otherwise, if multiple server processes are running on a system, their processor usage will overlap.

If **GCHeapCount** is set and **GCNoAffinitize** is enabled, the garbage collector limits the number of processors used for server GC but does not affinitize GC heaps and processors.

## Example

The following example indicates that an application uses server GC with 10 heaps/threads. Since you don't want those heaps to overlap with heaps from other applications running on the system, you use the **GCHeapAffinitizeMask** to specify that the process should use CPUs 0 through 9.

```xml
<configuration>
   <runtime>
      <gcServer enabled="true"/>
      <GCHeapCount enabled="10"/>
      <GCHeapAffinitizeMask enabled="1023"/>
   </runtime>
</configuration>
```

The following example does not affinitize server GC threads and limits the number of GC heaps/threads to 10.

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
- [GCNoAffinitize element](gcnoaffinitize-element.md)
- [GCHeapAffinitizeMask element](gcheapaffinitizemask-element.md)
- [Fundamentals of garbage collection](../../../../standard/garbage-collection/fundamentals.md)
- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
