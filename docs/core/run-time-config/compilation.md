---
title: Compilation config settings
description: Learn about run-time settings that configure how the JIT compiler works for .NET Core apps.
ms.date: 11/27/2019
ms.topic: reference
---
# Run-time configuration options for compilation

## Tiered compilation

- Configures whether the just-in-time (JIT) compiler uses [tiered compilation](../whats-new/dotnet-core-3-0.md#tiered-compilation).
- In .NET Core 3.0 and later, tiered compilation is enabled by default.
- In .NET Core 2.1 and 2.2, tiered compilation is disabled by default.
- For more information, see the [Tiered compilation](https://devblogs.microsoft.com/dotnet/tiered-compilation-preview-in-net-core-2-1/) blog entry.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Runtime.TieredCompilation` | `true` - enabled<br/>`false` - disabled |
| **MSBuild property** | `TieredCompilation` | `true` - enabled<br/>`false` - disabled |
| **Environment variable** | `COMPlus_TieredCompilation` | `1` - enabled<br/>`0` - disabled |

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

- Configures whether the JIT compiler uses *Quick JIT*. Quick JIT compiles methods that don't have loops quickly to improve application startup performance.
- In .NET Core 3.0 and later, Quick JIT is enabled by default.
- In .NET Core 2.1 and 2.2, Quick JIT is disabled by default.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Runtime.TieredCompilation.QuickJit` | `true` - enabled<br/>`false` - disabled |
| **MSBuild property** | `TieredCompilationQuickJit` | `true` - enabled<br/>`false` - disabled |

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

- Configures whether the JIT compiler uses Quick JIT on methods that contain loops.
- Default: Disabled (`false`).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Runtime.TieredCompilation.QuickJitForLoops` | `false` - disabled<br/>`true` - enabled |
| **MSBuild property** | `TieredCompilationQuickJitForLoops` | `false` - disabled<br/>`true` - enabled |

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
    <TieredCompilationQuickJitForLoops>false</TieredCompilationQuickJitForLoops>
  </PropertyGroup>

</Project>
```
