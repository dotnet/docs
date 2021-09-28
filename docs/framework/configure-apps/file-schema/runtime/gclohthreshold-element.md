---
description: "Learn more about: GCLOHThreshold element"
title: GCLOHThreshold element
ms.date: 11/20/2019
helpviewer_keywords:
  - "GCLOHThreshold element"
  - "<GCLOHThreshold> element"
---
# GCLOHThreshold element

Specifies the threshold size, in bytes, that causes the garbage collector to put objects on the large object heap (LOH).

[\<configuration>](../configuration-element.md)\
&nbsp;&nbsp;[\<runtime>](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;\<GCLOHThreshold>

## Syntax

```xml
<GCLOHThreshold
   enabled="nnnn"/>
```

## Attributes

|Attribute|Description|
|---------------|-----------------|
|`enabled`|Required attribute.<br /><br />Specifies the threshold size that causes objects to go on the large object heap.|

### enabled attribute

|Value|Description|
|-----------|-----------------|
|`nnnn`|The threshold size, in bytes, that causes objects to go on the large object heap.|

## Child elements

None.

## Parent elements

|Element|Description|
|-------------|-----------------|
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|
|`runtime`|Contains information about assembly binding and garbage collection.|

## Remarks

This setting was introduced in .NET Framework 4.8.

## See also

- [Run-time settings schema](index.md)
- [Configuration file schema](../index.md)
- [Fundamentals of garbage collection](../../../../standard/garbage-collection/fundamentals.md)
- [NET Core runtime config options for GC](../../../../core/run-time-config/garbage-collector.md)
