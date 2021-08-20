---
title: Compilation config settings
description: Learn about run-time settings that configure how the JIT compiler works for .NET Core apps.
ms.date: 11/27/2019
ms.topic: reference
---
# Runtime configuration options for compilation

This article details the settings you can use to configure .NET compilation.

[!INCLUDE [complus-prefix](../../../includes/complus-prefix.md)]

## Tiered compilation

- Configures whether the just-in-time (JIT) compiler uses [tiered compilation](../whats-new/dotnet-core-3-0.md#tiered-compilation). Tiered compilation transitions methods through two tiers:
  - The first tier generates code more quickly ([quick JIT](#quick-jit)) or loads pre-compiled code ([ReadyToRun](#readytorun)).
  - The second tier generates optimized code in the background ("optimizing JIT").
- In .NET Core 3.0 and later, tiered compilation is enabled by default.
- In .NET Core 2.1 and 2.2, tiered compilation is disabled by default.
- For more information, see the [Tiered compilation guide](https://github.com/dotnet/runtime/blob/main/docs/design/features/tiered-compilation.md).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Runtime.TieredCompilation` | `true` - enabled<br/>`false` - disabled |
| **MSBuild property** | `TieredCompilation` | `true` - enabled<br/>`false` - disabled |
| **Environment variable** | `COMPlus_TieredCompilation` or `DOTNET_TieredCompilation` | `1` - enabled<br/>`0` - disabled |

### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.Runtime.TieredCompilation": false
      }
   }
}
```

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TieredCompilation>false</TieredCompilation>
  </PropertyGroup>

</Project>
```

## Quick JIT

- Configures whether the JIT compiler uses *quick JIT*. For methods that don't contain loops and for which pre-compiled code is not available, quick JIT compiles them more quickly but without optimizations.
- Enabling quick JIT decreases startup time but can produce code with degraded performance characteristics. For example, the code may use more stack space, allocate more memory, and run slower.
- If quick JIT is disabled but [tiered compilation](#tiered-compilation) is enabled, only pre-compiled code participates in tiered compilation. If a method is not pre-compiled with [ReadyToRun](#readytorun), the JIT behavior is the same as if [tiered compilation](#tiered-compilation) were disabled.
- In .NET Core 3.0 and later, quick JIT is enabled by default.
- In .NET Core 2.1 and 2.2, quick JIT is disabled by default.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Runtime.TieredCompilation.QuickJit` | `true` - enabled<br/>`false` - disabled |
| **MSBuild property** | `TieredCompilationQuickJit` | `true` - enabled<br/>`false` - disabled |
| **Environment variable** | `COMPlus_TC_QuickJit` or `DOTNET_TC_QuickJit` | `1` - enabled<br/>`0` - disabled |

### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.Runtime.TieredCompilation.QuickJit": false
      }
   }
}
```

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TieredCompilationQuickJit>false</TieredCompilationQuickJit>
  </PropertyGroup>

</Project>
```

## Quick JIT for loops

- Configures whether the JIT compiler uses quick JIT on methods that contain loops.
- Enabling quick JIT for loops may improve startup performance. However, long-running loops can get stuck in less-optimized code for long periods.
- If [quick JIT](#quick-jit) is disabled, this setting has no effect.
- If you omit this setting, quick JIT is not used for methods that contain loops. This is equivalent to setting the value to `false`.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Runtime.TieredCompilation.QuickJitForLoops` | `false` - disabled<br/>`true` - enabled |
| **MSBuild property** | `TieredCompilationQuickJitForLoops` | `false` - disabled<br/>`true` - enabled |
| **Environment variable** | `COMPlus_TC_QuickJitForLoops` or `DOTNET_TC_QuickJitForLoops` | `0` - disabled<br/>`1` - enabled |

### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.Runtime.TieredCompilation.QuickJitForLoops": false
      }
   }
}
```

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TieredCompilationQuickJitForLoops>true</TieredCompilationQuickJitForLoops>
  </PropertyGroup>

</Project>
```

## ReadyToRun

- Configures whether the .NET Core runtime uses pre-compiled code for images with available ReadyToRun data. Disabling this option forces the runtime to JIT-compile framework code.
- For more information, see [Ready to Run](../deploying/ready-to-run.md).
- If you omit this setting, .NET uses ReadyToRun data when it's available. This is equivalent to setting the value to `1`.

| | Setting name | Values |
| - | - | - |
| **Environment variable** | `COMPlus_ReadyToRun` or `DOTNET_ReadyToRun` | `1` - enabled<br/>`0` - disabled |
