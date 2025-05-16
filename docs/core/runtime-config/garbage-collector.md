---
title: Garbage collector config settings
description: Learn about run-time settings for configuring how the garbage collector manages memory for .NET apps.
ms.date: 08/09/2024
---
# Runtime configuration options for garbage collection

This page contains information about settings for the .NET runtime garbage collector (GC). If you're trying to achieve peak performance of a running app, consider using these settings. However, the defaults provide optimum performance for most applications in typical situations.

Settings are arranged into groups on this page. The settings within each group are commonly used in conjunction with each other to achieve a specific result.

> [!NOTE]
>
> - These configurations are only read by the runtime when the GC is initialized (usually this means during the process startup time). If you change an environment variable when a process is already running, the change won't be reflected in that process. Settings that can be changed through APIs at run time, such as [latency level](../../standard/garbage-collection/latency.md), are omitted from this page.
> - Because GC is per process, it rarely ever makes sense to set these configurations at the machine level. For example, you wouldn't want every .NET process on a machine to use server GC or the same heap hard limit.
> - For number values, use decimal notation for settings in the *runtimeconfig.json* or *runtimeconfig.template.json* file and hexadecimal notation for environment variable settings. For hexadecimal values, you can specify them with or without the "0x" prefix.
> - If you're using the environment variables, .NET 6 and later versions standardize on the prefix `DOTNET_` instead of `COMPlus_`. However, the `COMPlus_` prefix will continue to work. If you're using a previous version of the .NET runtime, you should still use the `COMPlus_` prefix, for example, `COMPlus_gcServer`.

## Ways to specify the configuration

For different versions of the .NET runtime, there are different ways to specify the configuration values. The following table shows a summary.

| Config location      | .NET versions this location applies to | Formats  | How it's interpreted                                         |
| -------------------- | -------------------------------------- | -------- | ------------------------------------------------------------ |
| runtimeconfig.json file/</br>runtimeconfig.template.json file | .NET (Core)                           | n        | n is interpreted as a decimal value.                         |
| Environment variable | .NET Framework, .NET (Core)              | 0xn or n | n is interpreted as a hex value in either format             |
| app.config file      | .NET Framework                         | 0xn      | n is interpreted as a hex value<sup>1</sup>                  |

<sup>1</sup> You can specify a value without the `0x` prefix for an app.config file setting, but it's not recommended. On .NET Framework 4.8+, due to a bug, a value specified without the `0x` prefix is interpreted as hexadecimal, but on previous versions of .NET Framework, it's interpreted as decimal. To avoid having to change your config, use the `0x` prefix when specifying a value in your app.config file.

For example, to specify 12 heaps for `GCHeapCount` for a .NET Framework app named *A.exe*, add the following XML to the *A.exe.config* file.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    ...
    <runtime>
        <gcServer enabled="true"/>
        <GCHeapCount>0xc</GCHeapCount>
    </runtime>
</configuration>
```

For both .NET (Core) and .NET Framework, you can use environment variables.

On Windows using .NET 6 or a later version:

```cmd
SET DOTNET_gcServer=1
SET DOTNET_GCHeapCount=c
```

On Windows using .NET 5 or earlier:

```cmd
SET COMPlus_gcServer=1
SET COMPlus_GCHeapCount=c
```

On other operating systems:

For .NET 6 or later versions:

```bash
export DOTNET_gcServer=1
export DOTNET_GCHeapCount=c
```

For .NET 5 and earlier versions:

```bash
export COMPlus_gcServer=1
export COMPlus_GCHeapCount=c
```

If you're not using .NET Framework, you can also set the value in the *runtimeconfig.json* or *runtimeconfig.template.json* file.

*runtimeconfig.json* file:

```json
{
  "runtimeOptions": {
   "configProperties": {
      "System.GC.Server": true,
      "System.GC.HeapCount": 12
   }
  }
}
```

*runtimeconfig.template.json* file:

```json
{
  "configProperties": {
    "System.GC.Server": true,
    "System.GC.HeapCount": 12
  }
}
```

## Flavors of garbage collection

The two main flavors of garbage collection are workstation GC and server GC. For more information about differences between the two, see [Workstation and server garbage collection](../../standard/garbage-collection/workstation-server-gc.md).

The subflavors of garbage collection are background and non-concurrent.

Use the following settings to select flavors of garbage collection:

- [Workstation vs. server GC](#workstation-vs-server)
- [Background GC](#background-gc)

### Workstation vs. server

- Configures whether the application uses workstation garbage collection or server garbage collection.
- Default: Workstation garbage collection. This is equivalent to setting the value to `false`.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.Server` | `false` - workstation<br/>`true` - server | .NET Core 1.0 |
| **MSBuild property** | `ServerGarbageCollection` | `false` - workstation<br/>`true` - server | .NET Core 1.0 |
| **Environment variable** | `COMPlus_gcServer` | `0` - workstation<br/>`1` - server | .NET Core 1.0 |
| **Environment variable** | `DOTNET_gcServer` | `0` - workstation<br/>`1` - server | .NET 6 |
| **app.config for .NET Framework** | [GCServer](../../framework/configure-apps/file-schema/runtime/gcserver-element.md) | `false` - workstation<br/>`true` - server |  |

#### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.Server": true
      }
   }
}
```

*runtimeconfig.template.json* file:

```json
{
   "configProperties": {
      "System.GC.Server": true
   }
}
```

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <ServerGarbageCollection>true</ServerGarbageCollection>
  </PropertyGroup>

</Project>
```

### Background GC

- Configures whether background (concurrent) garbage collection is enabled.
- Default: Use background GC. This is equivalent to setting the value to `true`.
- For more information, see [Background garbage collection](../../standard/garbage-collection/background-gc.md).

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.Concurrent` | `true` - background GC<br/>`false` - non-concurrent GC | .NET Core 1.0 |
| **MSBuild property** | `ConcurrentGarbageCollection` | `true` - background GC<br/>`false` - non-concurrent GC | .NET Core 1.0 |
| **Environment variable** | `COMPlus_gcConcurrent` | `1` - background GC<br/>`0` - non-concurrent GC | .NET Core 1.0 |
| **Environment variable** | `DOTNET_gcConcurrent` | `1` - background GC<br/>`0` - non-concurrent GC | .NET 6 |
| **app.config for .NET Framework** | [gcConcurrent](../../framework/configure-apps/file-schema/runtime/gcconcurrent-element.md) | `true` - background GC<br/>`false` - non-concurrent GC |  |

#### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.Concurrent": false
      }
   }
}
```

*runtimeconfig.template.json* file:

```json
{
   "configProperties": {
      "System.GC.Concurrent": false
   }
}
```

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <ConcurrentGarbageCollection>false</ConcurrentGarbageCollection>
  </PropertyGroup>

</Project>
```

## Manage resource usage

Use the following settings to manage the garbage collector's memory and processor usage:

- [Affinitize](#affinitize)
- [Affinitize mask](#affinitize-mask)
- [Affinitize ranges](#affinitize-ranges)
- [CPU groups](#cpu-groups)
- [Heap count](#heap-count)
- [Heap hard limit](#heap-hard-limit)
- [Heap hard limit percent](#heap-hard-limit-percent)
- [Per-object-heap hard limits](#per-object-heap-hard-limits)
- [Per-object-heap hard limit percents](#per-object-heap-hard-limit-percents)
- [Region range](#region-range)
- [Region size](#region-size)
- [High memory percent](#high-memory-percent)
- [Retain VM](#retain-vm)

For more information about some of these settings, see the [Middle ground between workstation and server GC](https://devblogs.microsoft.com/dotnet/middle-ground-between-server-and-workstation-gc/) blog entry.

### Heap count

- Limits the number of heaps created by the garbage collector.
- Applies to server garbage collection only.
- If [GC processor affinity](#affinitize) is enabled, which is the default, the heap count setting affinitizes `n` GC heaps/threads to the first `n` processors. (Use the [affinitize mask](#affinitize-mask) or [affinitize ranges](#affinitize-ranges) settings to specify exactly which processors to affinitize.)
- If [GC processor affinity](#affinitize) is disabled, this setting limits the number of GC heaps.
- For more information, see the [GCHeapCount remarks](../../framework/configure-apps/file-schema/runtime/gcheapcount-element.md#remarks).

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapCount` | *decimal value* | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCHeapCount` | *hexadecimal value* | .NET Core 3.0 |
| **Environment variable** | `DOTNET_GCHeapCount` | *hexadecimal value* | .NET 6 |
| **app.config for .NET Framework** | [GCHeapCount](../../framework/configure-apps/file-schema/runtime/gcheapcount-element.md) | *decimal value* | .NET Framework 4.6.2 |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

#### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.HeapCount": 16
      }
   }
}
```

*runtimeconfig.template.json* file:

```json
{
   "configProperties": {
      "System.GC.HeapCount": 16
   }
}
```

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to limit the number of heaps to 16, the values would be 16 for the JSON file and 0x10 or 10 for the environment variable.

### Affinitize mask

- Specifies the exact processors that garbage collector threads should use.
- If [GC processor affinity](#affinitize) is disabled, this setting is ignored.
- Applies to server garbage collection only.
- The value is a bit mask that defines the processors that are available to the process. For example, a decimal value of 1023 (or a hexadecimal value of 0x3FF or 3FF if you're using the environment variable) is 0011 1111 1111 in binary notation. This specifies that the first 10 processors are to be used. To specify the next 10 processors, that is, processors 10-19, specify a decimal value of 1047552 (or a hexadecimal value of 0xFFC00 or FFC00), which is equivalent to a binary value of 1111 1111 1100 0000 0000.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapAffinitizeMask` | *decimal value* | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCHeapAffinitizeMask` | *hexadecimal value* | .NET Core 3.0 |
| **Environment variable** | `DOTNET_GCHeapAffinitizeMask` | *hexadecimal value* | .NET 6 |
| **app.config for .NET Framework** | [GCHeapAffinitizeMask](../../framework/configure-apps/file-schema/runtime/gcheapaffinitizemask-element.md) | *decimal value* | .NET Framework 4.6.2 |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

#### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.HeapAffinitizeMask": 1023
      }
   }
}
```

*runtimeconfig.template.json* file:

```json
{
   "configProperties": {
      "System.GC.HeapAffinitizeMask": 1023
   }
}
```

### Affinitize ranges

- Specifies the list of processors to use for garbage collector threads.
- This setting is similar to [System.GC.HeapAffinitizeMask](#affinitize-mask), except it allows you to specify more than 64 processors.
- For Windows operating systems, prefix the processor number or range with the corresponding [CPU group](/windows/win32/procthread/processor-groups), for example, "0:1-10,0:12,1:50-52,1:7". If you don't actually have more than 1 CPU group, you can't use this setting. You must use the [Affinitize mask](#affinitize-mask) setting. And the numbers you specify are within that group, which means it cannot be >= 64.
- For Linux operating systems, where the [CPU group](/windows/win32/procthread/processor-groups) concept doesn't exist, you can use both this setting and the [Affinitize mask](#affinitize-mask) setting to specify the same ranges. And instead of "0:1-10", specify "1-10" because you don't need to specify a group index.
- If [GC processor affinity](#affinitize) is disabled, this setting is ignored.
- Applies to server garbage collection only.
- For more information, see [Making CPU configuration better for GC on machines with > 64 CPUs](https://devblogs.microsoft.com/dotnet/making-cpu-configuration-better-for-gc-on-machines-with-64-cpus/) on Maoni Stephens' blog.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapAffinitizeRanges` | Comma-separated list of processor numbers or ranges of processor numbers.<br/>Unix example: "1-10,12,50-52,70"<br/>Windows example: "0:1-10,0:12,1:50-52,1:7" | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCHeapAffinitizeRanges` | Comma-separated list of processor numbers or ranges of processor numbers.<br/>Unix example: "1-10,12,50-52,70"<br/>Windows example: "0:1-10,0:12,1:50-52,1:7" | .NET Core 3.0 |
| **Environment variable** | `DOTNET_GCHeapAffinitizeRanges` | Comma-separated list of processor numbers or ranges of processor numbers.<br/>Unix example: "1-10,12,50-52,70"<br/>Windows example: "0:1-10,0:12,1:50-52,1:7" | .NET 6 |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

#### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.HeapAffinitizeRanges": "0:1-10,0:12,1:50-52,1:7"
      }
   }
}
```

*runtimeconfig.template.json* file:

```json
{
   "configProperties": {
      "System.GC.HeapAffinitizeRanges": "0:1-10,0:12,1:50-52,1:7"
   }
}
```

### CPU groups

- Configures whether the garbage collector uses [CPU groups](/windows/win32/procthread/processor-groups) or not.

  When a 64-bit Windows computer has multiple CPU groups, that is, there are more than 64 processors, enabling this element extends garbage collection across all CPU groups. The garbage collector uses all cores to create and balance heaps.

  > [!NOTE]
  > This is a Windows-only concept. In older Windows versions, Windows limited a process to one CPU group. Thus, GC only used one CPU group unless you used this setting to enable multiple CPU groups. This OS limitation was lifted in Windows 11 and Server 2022. Also, starting in .NET 7, GC by default uses all CPU groups when running on Windows 11 or Server 2022.

- Applies to server garbage collection on 64-bit Windows operating systems only.
- Default: GC does not extend across CPU groups. This is equivalent to setting the value to `0`.
- For more information, see [Making CPU configuration better for GC on machines with > 64 CPUs](https://devblogs.microsoft.com/dotnet/making-cpu-configuration-better-for-gc-on-machines-with-64-cpus/) on Maoni Stephens' blog.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.CpuGroup` | `false` - disabled<br/>`true` - enabled | .NET 5 |
| **Environment variable** | `COMPlus_GCCpuGroup` | `0` - disabled<br/>`1` - enabled | .NET Core 1.0 |
| **Environment variable** | `DOTNET_GCCpuGroup` | `0` - disabled<br/>`1` - enabled | .NET 6 |
| **app.config for .NET Framework** | [GCCpuGroup](../../framework/configure-apps/file-schema/runtime/gccpugroup-element.md) | `false` - disabled<br/>`true` - enabled |  |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

> [!NOTE]
> To configure the common language runtime (CLR) to also distribute threads from the thread pool across all CPU groups, enable the [Thread_UseAllCpuGroups element](../../framework/configure-apps/file-schema/runtime/thread-useallcpugroups-element.md) option. For .NET Core apps, you can enable this option by setting the value of the `DOTNET_Thread_UseAllCpuGroups` environment variable to `1`.

### Affinitize

- Specifies whether to *affinitize* garbage collection threads with processors. To affinitize a GC thread means that it can only run on its specific CPU. A heap is created for each GC thread.
- Applies to server garbage collection only.
- Default: Affinitize garbage collection threads with processors. This is equivalent to setting the value to `false`.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.NoAffinitize` | `false` - affinitize<br/>`true` - don't affinitize | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCNoAffinitize` | `0` - affinitize<br/>`1` - don't affinitize | .NET Core 3.0 |
| **Environment variable** | `DOTNET_GCNoAffinitize` | `0` - affinitize<br/>`1` - don't affinitize | .NET 6 |
| **app.config for .NET Framework** | [GCNoAffinitize](../../framework/configure-apps/file-schema/runtime/gcnoaffinitize-element.md) | `false` - affinitize<br/>`true` - don't affinitize | .NET Framework 4.6.2 |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

#### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.NoAffinitize": true
      }
   }
}
```

*runtimeconfig.template.json* file:

```json
{
   "configProperties": {
      "System.GC.NoAffinitize": true
   }
}
```

### Heap hard limit

- The heap hard limit is defined as the maximum commit size, in bytes, for the GC heap and GC bookkeeping.
- This setting only applies to 64-bit computers.
- If this limit isn't configured but the process is running in a memory-constrained environment, that is, inside a container with a specified memory limit, a default value is set. That default is the greater of 20 MB or 75% of the memory limit on the container.
- This setting is ignored if the [Per-object-heap hard limits](#per-object-heap-hard-limits) are configured.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimit` | *decimal value* | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCHeapHardLimit` | *hexadecimal value* | .NET Core 3.0 |
| **Environment variable** | `DOTNET_GCHeapHardLimit` | *hexadecimal value* | .NET 6 |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

#### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.HeapHardLimit": 209715200
      }
   }
}
```

*runtimeconfig.template.json* file:

```json
{
   "configProperties": {
      "System.GC.HeapHardLimit": 209715200
   }
}
```

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to specify a heap hard limit of 200 mebibytes (MiB), the values would be 209715200 for the JSON file and 0xC800000 or C800000 for the environment variable.

### Heap hard limit percent

- Specifies the heap hard limit as a percentage of the total physical memory. If the process is running in a memory-constrained environment, that is, inside a container with a specified memory limit, the total physical memory is the memory limit; otherwise it's what's available on the machine.
- This setting only applies to 64-bit computers.
- This setting is ignored if the [Per-object-heap hard limits](#per-object-heap-hard-limits) are configured or the [heap hard limit](#heap-hard-limit) is configured.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimitPercent` | *decimal value* | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCHeapHardLimitPercent` | *hexadecimal value* | .NET Core 3.0 |
| **Environment variable** | `DOTNET_GCHeapHardLimitPercent` | *hexadecimal value* | .NET 6 |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

#### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.HeapHardLimitPercent": 30
      }
   }
}
```

*runtimeconfig.template.json* file:

```json
{
   "configProperties": {
      "System.GC.HeapHardLimitPercent": 30
   }
}
```

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to limit the heap usage to 30%, the values would be 30 for the JSON file and 0x1E or 1E for the environment variable.

### Per-object-heap hard limits

You can specify the GC's heap hard limit on a per-object-heap basis. The different heaps are the large object heap (LOH), small object heap (SOH), and pinned object heap (POH).

- If you specify a value for any of the `DOTNET_GCHeapHardLimitSOH`, `DOTNET_GCHeapHardLimitLOH`, or `DOTNET_GCHeapHardLimitPOH` settings, you must also specify a value for `DOTNET_GCHeapHardLimitSOH` and `DOTNET_GCHeapHardLimitLOH`. If you don't, the runtime will fail to initialize.
- The default value for `DOTNET_GCHeapHardLimitPOH` is 0. `DOTNET_GCHeapHardLimitSOH` and `DOTNET_GCHeapHardLimitLOH` don't have default values.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimitSOH` | *decimal value* | .NET 5 |
| **Environment variable** | `COMPlus_GCHeapHardLimitSOH` | *hexadecimal value* | .NET 5 |
| **Environment variable** | `DOTNET_GCHeapHardLimitSOH` | *hexadecimal value* | .NET 6 |

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimitLOH` | *decimal value* | .NET 5 |
| **Environment variable** | `COMPlus_GCHeapHardLimitLOH` | *hexadecimal value* | .NET 5 |
| **Environment variable** | `DOTNET_GCHeapHardLimitLOH` | *hexadecimal value* | .NET 6 |

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimitPOH` | *decimal value* | .NET 5 |
| **Environment variable** | `COMPlus_GCHeapHardLimitPOH` | *hexadecimal value* | .NET 5 |
| **Environment variable** | `DOTNET_GCHeapHardLimitPOH` | *hexadecimal value* | .NET 6 |

These configuration settings don't have specific MSBuild properties. However, you can add a `RuntimeHostConfigurationOption` MSBuild item instead. Use the *runtimeconfig.json* setting name as the value of the `Include` attribute. For an example, see [MSBuild properties](index.md#msbuild-properties).

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to specify a heap hard limit of 200 mebibytes (MiB), the values would be 209715200 for the JSON file and 0xC800000 or C800000 for the environment variable.

### Per-object-heap hard limit percents

You can specify the GC's heap hard limit on a per-object-heap basis. The different heaps are the large object heap (LOH), small object heap (SOH), and pinned object heap (POH).

- If you specify a value for any of the `DOTNET_GCHeapHardLimitSOHPercent`, `DOTNET_GCHeapHardLimitLOHPercent`, or `DOTNET_GCHeapHardLimitPOHPercent` settings, you must also specify a value for `DOTNET_GCHeapHardLimitSOHPercent` and `DOTNET_GCHeapHardLimitLOHPercent`. If you don't, the runtime will fail to initialize.
- These settings are ignored if `DOTNET_GCHeapHardLimitSOH`, `DOTNET_GCHeapHardLimitLOH`, and `DOTNET_GCHeapHardLimitPOH` are specified.
- A value of 1 means that GC uses 1% of total physical memory for that object heap.
- Each value must be greater than zero and less than 100. Additionally, the sum of the three percentage values must be less than 100. Otherwise, the runtime will fail to initialize.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimitSOHPercent` | *decimal value* | .NET 5 |
| **Environment variable** | `COMPlus_GCHeapHardLimitSOHPercent` | *hexadecimal value* | .NET 5 |
| **Environment variable** | `DOTNET_GCHeapHardLimitSOHPercent` | *hexadecimal value* | .NET 6 |

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimitLOHPercent` | *decimal value* | .NET 5 |
| **Environment variable** | `COMPlus_GCHeapHardLimitLOHPercent` | *hexadecimal value* | .NET 5 |
| **Environment variable** | `DOTNET_GCHeapHardLimitLOHPercent` | *hexadecimal value* | .NET 6 |

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimitPOHPercent` | *decimal value* | .NET 5 |
| **Environment variable** | `COMPlus_GCHeapHardLimitPOHPercent` | *hexadecimal value* | .NET 5 |
| **Environment variable** | `DOTNET_GCHeapHardLimitPOHPercent` | *hexadecimal value* | .NET 6 |

These configuration settings don't have specific MSBuild properties. However, you can add a `RuntimeHostConfigurationOption` MSBuild item instead. Use the *runtimeconfig.json* setting name as the value of the `Include` attribute. For an example, see [MSBuild properties](index.md#msbuild-properties).

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to limit the heap usage to 30%, the values would be 30 for the JSON file and 0x1E or 1E for the environment variable.

### Region range

Starting in .NET 7, the GC heap switched its physical representation from segments to regions for 64-bit Windows and Linux. (For more information, see [Maoni Stephens' blog article](https://itnext.io/how-segments-and-regions-differ-in-decommitting-memory-in-the-net-7-gc-68c58465ab5a).) With this change, the GC reserves a range of virtual memory during initialization. Note that this is only reserving memory, not committing (the GC heap size is committed memory). It's merely a range to define the maximum range the GC heap can commit. Most applications don't need to commit nearly this much.

If you don't have any other configurations and aren't running in a memory-constrained environment (which would cause some GC configs to be set), by default 256 GB is reserved. If you have more than 256 GB physical memory available, it will be twice that amount.

If the per heap hard limits are set, the reserve range will be the same as the total hard limit. If a single hard limit config is set, this range will be 5x that amount.

This range is limited by the amount of total virtual memory. Normally on 64-bit this is never a problem but there could be a virtual memory limit set on a process. This range will be limited by half that amount. For example, if you set the HeapHardLimit config to 1GB and have a 4GB virtual memory limit set on the process, this range will be min (5x1GB, 4GB/2) which is 2GB.

You can use the `GC.GetConfigurationVariables` API to see the value of this range under the name `GCRegionRange`. If you do get `E_OUTOFMEMORY` during the runtime intialization and want to see if it's due to reserving this range, you can look at the `VirtualAlloc`call with `MEM_RESERVE` on Windows and the `mmap` call with `PROT_NONE` on Linux during GC initialization and see if the OOM is from that call. If this reserve call is failing you can change it via this config.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.RegionRange` | *decimal value* | .NET 10 |
| **Environment variable** | `DOTNET_GCRegionRange` | *hexadecimal value* | .NET 7 |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

### Region size

Starting with .NET 7.0 the GC heap switched its physical representation from segments to regions for 64-bit Windows and Linux. See [Maoni Stephens' blog article](https://itnext.io/how-segments-and-regions-differ-in-decommitting-memory-in-the-net-7-gc-68c58465ab5a) for more details. By default each region is 4MB for SOH. For UOH (LOH and POH), it's 8 times the SOH region size. You can use this config to change the SOH region size and the UOH regions will be adjusted accordingly. 

Regions are only allocated when needed so in general you don't need to care about the region size. However there are 2 cases where you might want to adjust this size and use 

- For processes that have very small GC heaps, changing the region size to be smaller would be beneficial for native memory usage from GC's own bookkeeping. The recommendation is 1MB.
- If you are on Linux and need to reduce the number of memory mappings, you can change this to be larger, eg, 32MB.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.RegionSize` | *decimal value* | .NET 10 |
| **Environment variable** | `DOTNET_GCRegionSize` | *hexadecimal value* | .NET 7 |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

### High memory percent

Memory load is indicated by the percentage of physical memory in use. By default, when the physical memory load reaches **90%**, garbage collection becomes more aggressive about doing full, compacting garbage collections to avoid paging. When memory load is below 90%, GC favors background collections for full garbage collections, which have shorter pauses but don't reduce the total heap size by much. On machines with a significant amount of memory (80GB or more), the default load threshold is between 90% and 97%.

The high memory load threshold can be adjusted by the `DOTNET_GCHighMemPercent` environment variable or `System.GC.HighMemoryPercent` JSON configuration setting. Consider adjusting the threshold if you want to control heap size. For example, for the dominant process on a machine with 64GB of memory, it's reasonable for GC to start reacting when there's 10% of memory available. But for smaller processes, for example, a process that only consumes 1GB of memory, GC can comfortably run with less than 10% of memory available. For these smaller processes, consider setting the threshold higher. On the other hand, if you want larger processes to have smaller heap sizes (even when there's plenty of physical memory available), lowering this threshold is an effective way for GC to react sooner to compact the heap down.

> [!NOTE]
> For processes running in a container, GC considers the physical memory based on the container limit.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HighMemoryPercent` | *decimal value* | .NET 5 |
| **Environment variable** | `COMPlus_GCHighMemPercent` | *hexadecimal value* | .NET Core 3.0<br/>.NET Framework 4.7.2 |
| **Environment variable** | `DOTNET_GCHighMemPercent` | *hexadecimal value* | .NET 6 |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to set the high memory threshold to 75%, the values would be 75 for the JSON file and 0x4B or 4B for the environment variable.

### Retain VM

- Configures whether segments that should be deleted are put on a standby list for future use or are released back to the operating system (OS).
- Default: Release segments back to the operating system. This is equivalent to setting the value to `false`.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.RetainVM` | `false` - release to OS<br/>`true` - put on standby | .NET Core 1.0 |
| **MSBuild property** | `RetainVMGarbageCollection` | `false` - release to OS<br/>`true` - put on standby | .NET Core 1.0 |
| **Environment variable** | `COMPlus_GCRetainVM` | `0` - release to OS<br/>`1` - put on standby | .NET Core 1.0 |
| **Environment variable** | `DOTNET_GCRetainVM` | `0` - release to OS<br/>`1` - put on standby | .NET 6 |

#### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.RetainVM": true
      }
   }
}
```

*runtimeconfig.template.json* file:

```json
{
   "configProperties": {
      "System.GC.RetainVM": true
   }
}
```

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <RetainVMGarbageCollection>true</RetainVMGarbageCollection>
  </PropertyGroup>

</Project>
```

## Large pages

- Specifies whether large pages should be used when a heap hard limit is set.
- Default: Don't use large pages when a heap hard limit is set. This is equivalent to setting the value to `0`.
- This is an experimental setting.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | N/A | N/A | N/A |
| **Environment variable** | `COMPlus_GCLargePages` | `0` - disabled<br/>`1` - enabled | .NET Core 3.0 |
| **Environment variable** | `DOTNET_GCLargePages` | `0` - disabled<br/>`1` - enabled | .NET 6 |

## Allow large objects

- Configures garbage collector support on 64-bit platforms for arrays that are greater than 2 gigabytes (GB) in total size.
- Default: GC supports arrays greater than 2-GB. This is equivalent to setting the value to `1`.
- This option may become obsolete in a future version of .NET.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | N/A | N/A | N/A |
| **Environment variable** | `COMPlus_gcAllowVeryLargeObjects` | `1` - enabled<br/> `0` - disabled | .NET Core 1.0 |
| **Environment variable** | `DOTNET_gcAllowVeryLargeObjects` | `1` - enabled<br/> `0` - disabled | .NET 6 |
| **app.config for .NET Framework** | [gcAllowVeryLargeObjects](../../framework/configure-apps/file-schema/runtime/gcallowverylargeobjects-element.md) | `1` - enabled<br/> `0` - disabled | .NET Framework 4.5 |

## Large object heap threshold

- Specifies the threshold size, in bytes, that causes objects to go on the large object heap (LOH).
- The default threshold is 85,000 bytes.
- The value you specify must be larger than the default threshold.
- The value might be capped by the runtime to the maximum possible size for the current configuration. You can inspect the value in use at run time through the <xref:System.GC.GetConfigurationVariables?displayProperty=nameWithType> API.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.LOHThreshold` | *decimal value* | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCLOHThreshold` | *hexadecimal value* | .NET Core 3.0 |
| **Environment variable** | `DOTNET_GCLOHThreshold` | *hexadecimal value* | .NET 6 |
| **app.config for .NET Framework** | [GCLOHThreshold](../../framework/configure-apps/file-schema/runtime/gclohthreshold-element.md) | *decimal value* | .NET Framework 4.8 |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.LOHThreshold": 120000
      }
   }
}
```

*runtimeconfig.template.json* file:

```json
{
   "configProperties": {
      "System.GC.LOHThreshold": 120000
   }
}
```

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to set a threshold size of 120,000 bytes, the values would be 120000 for the JSON file and 0x1D4C0 or 1D4C0 for the environment variable.

## Standalone GC

To use a standalone garbage collector instead of the default GC implementation, you can specify either the *[path](#path)* (in .NET 9 and later versions) or the *[name](#name)* of a GC native library.

### Path

- Specifies the full path of a GC native library that the runtime loads in place of the default GC implementation. To be secure, this location should be protected from potentially malicious tampering.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.Path` | *string_path* | .NET 9 |
| **Environment variable** | `DOTNET_GCPath` | *string_path* | .NET 9 |

### Name

- Specifies the name of a GC native library that the runtime loads in place of the default GC implementation. The behavior changed in .NET 9 with the introduction of the [Path](#path) config.

  In .NET 8 and previous versions:

  - If only a name of the library is specified, the library must reside in the same directory as the .NET runtime (*coreclr.dll* on Windows, *libcoreclr.so* on Linux, or *libcoreclr.dylib* on OSX).
  - The value can also be a relative path, for example, if you specify "..\clrgc.dll" on Windows, *clrgc.dll* is loaded from the parent directory of the .NET runtime directory.

  In .NET 9 and later versions, this value specifies a file name only (paths aren't allowed):

  - .NET searches for the name you specify in the directory where the assembly that contains your app's `Main` method resides.
  - If the file isn't found, the .NET runtime directory is searched.

- This configuration setting is ignored if the [Path](#path) config is specified.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.Name` | *string_name* | .NET 7 |
| **Environment variable** | `COMPlus_GCName` | *string_name* | .NET Core 2.0 |
| **Environment variable** | `DOTNET_GCName` | *string_name* | .NET 6 |

## Conserve memory

- Configures the garbage collector to conserve memory at the expense of more frequent garbage collections and possibly longer pause times.
- Default value is 0 - this implies no change.
- Besides the default value 0, values between 1 and 9 (inclusive) are valid. The higher the value, the more the garbage collector tries to conserve memory and thus to keep the heap small.
- If the value is non-zero, the large object heap will be compacted automatically if it has too much fragmentation.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.ConserveMemory` | `0` - `9` | .NET 6 |
| **Environment variable** | `COMPlus_GCConserveMemory` | `0` -`9` | .NET Framework 4.8 |
| **Environment variable** | `DOTNET_GCConserveMemory` | `0` -`9` | .NET 6 |
| **app.config for .NET Framework** | [GCConserveMemory](../../framework/configure-apps/file-schema/runtime/gcconservememory-element.md) | `0` -`9` | .NET Framework 4.8 |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

Example *app.config* file:

```xml

<configuration>
  <runtime>
    <GCConserveMemory enabled="5"/>
  </runtime>
</configuration>
```

> [!TIP]
> Experiment with different numbers to see which value works best for you. Start with a value between 5 and 7.

## Dynamic adaptation to application sizes (DATAS)

- Configures the garbage collector to use DATAS. DATAS adapts to application memory requirements, meaning the app heap size should be roughly proportional to the long-lived data size.
- Enabled by default starting in .NET 9.

|                          | Setting name               | Values    | Version introduced |
|--------------------------|----------------------------|-----------|--------------------|
| **Environment variable** | `DOTNET_GCDynamicAdaptationMode`  | `1` - enabled<br/> `0` - disabled | .NET 8 |
| **MSBuild property** | `GarbageCollectionAdaptationMode` | `1` - enabled<br/> `0` - disabled | .NET 8 |
| **runtimeconfig.json**   | `System.GC.DynamicAdaptationMode` | `1` - enabled<br/> `0` - disabled | .NET 8 |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]
