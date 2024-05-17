---
description: "Learn more about: GCConserveMemory element"
title: GCConserveMemory element
ms.date: 03/08/2022
helpviewer_keywords:
  - "GCConserveMemory element"
  - "<GCConserveMemory> element"
---
# GCConserveMemory element

Configures the garbage collector to conserve memory at the expense of more frequent garbage collections and possibly longer pause times.
Default value is 0 - this implies no change.
Besides the default value 0, values between 1 and 9 (inclusive) are valid. The higher the value, the more the garbage collector tries to conserve memory and thus to keep the heap small.
If the value is non-zero, the large object heap will be compacted automatically if it has too much fragmentation.

[\<configuration>](../configuration-element.md)\
&nbsp;&nbsp;[\<runtime>](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;\<GCConserveMemory>

## Syntax

```xml
<GCConserveMemory
   enabled="n"/>
```

## Attributes

|Attribute|Description|
|---------------|-----------------|
|`enabled`|Required attribute.<br /><br />Specifies how hard the garbage collector should try to conserve memory.|

### enabled attribute

|Value|Description|
|-----------|-----------------|
|`n`|Default value is 0 - this implies no change. Besides 0, values between 1 and 9 (inclusive) are valid. The higher the value, the more the garbage collector tries to conserve memory and thus to keep the heap small.|

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

- [Configure apps by using configuration files](../../index.md)
- [Run-time settings schema](index.md)
- [Configuration file schema](../index.md)
- [Fundamentals of garbage collection](../../../../standard/garbage-collection/fundamentals.md)
- [NET Core runtime config options for GC](../../../../core/runtime-config/garbage-collector.md)
