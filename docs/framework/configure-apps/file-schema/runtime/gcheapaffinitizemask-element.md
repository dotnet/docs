---
title: GCHeapAffinitizeMask element
ms.date: 11/08/2019
helpviewer_keywords:
  - "gcHeapCount element"
  - "<gcHeapCount> element"
---
# \<GCHeapAffinitizeMask> element

Defines the affinity between GC heaps and individual processors.

\<configuration>\
&nbsp;&nbsp;\<runtime>\
&nbsp;&nbsp;&nbsp;&nbsp;\<GCHeapAffinitizeMask>

## Syntax

```xml
<GCHeapAffinitizeMask
   enabled="nnnn"/>
```

## Attributes and elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

|Attribute|Description|
|---------------|-----------------|
|`enabled`|Required attribute.<br /><br />Specifies the affinity between GC heaps and individual processors. |

#### enabled attribute

|Value|Description|
|-----------|-----------------|
|`nnnn`|A decimal value that forms a bitmask defining the affinity between server GC heaps and individual processors. |

### Child elements

None.

### Parent elements

|Element|Description|
|-------------|-----------------|
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|
|`runtime`|Contains information about assembly binding and garbage collection.|

## Remarks

By default, server GC threads are hard-affinitized with their respective CPU so that there is one GC heap, one server GC thread, and one background server GC thread for each processor. Starting with .NET Framework 4.6.2, you can use the **GCHeapAffinitizeMask** element to control the affinity between server GC heaps and processors when the number of heaps is limited by the **GCHeapCount** element.

**GCHeapAffinitizeMask** is typically used along with two other flags:

- [GCNoAffinitize](gcnoaffinitize-element.md), which controls whether server GC threads/heaps are affinitized with CPUs. The `enabled` attribute of the [GCNoAffinitize](gcnoaffinitize-element.md) element must be `false` (its default value) for the **GCHeapAffinitizeMask** setting to be used.

- [GCHeapCount](gcheapcount-element.md), which limits the number of heaps used by the process for server GC. By default, there is one heap for each processor.

**nnnn** is a bit mask expressed as a decimal value. Bit 0 of byte 0 represents processor 0, bit 1 of byte 0 represents processor 1, and so on. For example:

```xml
<GCHeapAffinitizeMask enabled="1023"/>
```

A value of 1023 is 0x3FF or 0011 1111 1111b. The process uses 10 processors, from processor 0 through processor 9.

## Example

The following example indicates that an application uses server GC with 10 heaps/threads. Since you don't want those heaps to overlap with heaps from other applications running on the system, use **GCHeapAffinitizeMask** to specify that the process should use CPUs 0 through 9.

```xml
<configuration>
   <runtime>
      <gcServer enabled="true"/>
      <GCHeapCount enabled="10"/>
      <GCHeapAffinitizeMask enabled="1023"/>
   </runtime>
</configuration>
```

## See also

- <xref:System.Runtime.GCSettings.IsServerGC%2A?displayProperty=nameWithType>
- [GCNoAffinitize element](gcnoaffinitize-element.md)
- [GCHeapCount element](gcheapcount-element.md)
- [Fundamentals of garbage collection](../../../../standard/garbage-collection/fundamentals.md)
- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
