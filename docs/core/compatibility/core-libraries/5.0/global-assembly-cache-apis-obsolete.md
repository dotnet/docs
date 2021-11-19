---
title: "Breaking change: Global assembly cache APIs are obsolete"
description: Learn about the .NET 5 breaking change in core .NET libraries where APIs that deal with the GAC either fail or perform no operation.
ms.date: 11/01/2020
---
# Global assembly cache APIs are obsolete

.NET Core and .NET 5 and later versions eliminate the concept of the global assembly cache (GAC) that was present in .NET Framework. As such, all .NET Core and .NET 5+ APIs that deal with the GAC either fail or perform no operation.

To help steer developers away from these APIs, some GAC-related APIs are marked as obsolete, and generate a `SYSLIB0005` warning at compile time. These APIs may be removed in a future version of .NET.

## Change description

The following APIs are marked obsolete.

| API | Marked obsolete in... |
| - | - |
| <xref:System.Reflection.Assembly.GlobalAssemblyCache?displayProperty=nameWithType> | 5.0 RC1 |

In .NET Framework 2.x - 4.x, the <xref:System.Reflection.Assembly.GlobalAssemblyCache> property returns `true` if the queried assembly was loaded from the GAC, and `false` if it was loaded from a different location on disk. In .NET Core 2.x - 3.x, the <xref:System.Reflection.Assembly.GlobalAssemblyCache> always returns `false`, reflecting that the GAC does not exist in .NET Core.

```csharp
Assembly asm = typeof(object).Assembly;
// Prints 'True' on .NET Framework, 'False' on .NET Core.
Console.WriteLine(asm.GlobalAssemblyCache);
```

In .NET 5 and later versions, the <xref:System.Reflection.Assembly.GlobalAssemblyCache> property continues to always return `false`. However, the property getter is also marked as obsolete to indicate to callers that they should stop accessing the property. Libraries and apps should not use the <xref:System.Reflection.Assembly.GlobalAssemblyCache> API to make determinations about run-time behavior, as it always returns `false` in .NET Core and .NET 5 and later versions.

```csharp
Assembly asm = typeof(object).Assembly;
// Prints 'False' on .NET 5+; also produces warning SYSLIB0005 at compile time.
Console.WriteLine(asm.GlobalAssemblyCache);
```

This is a compile-time only change. There is no run-time change from previous versions of .NET Core.

## Reason for change

The global assembly cache (GAC) does not exist as a concept in .NET Core and .NET 5 and later versions.

## Version introduced

.NET 5.0

## Recommended action

- If your application queries the <xref:System.Reflection.Assembly.GlobalAssemblyCache> property, consider removing the call. If you use the <xref:System.Reflection.Assembly.GlobalAssemblyCache> value to choose between an "assembly in the GAC"-flow vs. an "assembly not in the GAC"-flow at run time, reconsider whether the flow still makes sense for a .NET Core or .NET 5+ application.

- If you must continue to use the obsolete APIs, you can suppress the `SYSLIB0005` warning in code.

  ```csharp
  Assembly asm = typeof(object).Assembly;
  #pragma warning disable SYSLIB0005 // Disable the warning.
  // Prints 'False' on .NET 5+.
  Console.WriteLine(asm.GlobalAssemblyCache);
  #pragma warning restore SYSLIB0005 // Re-enable the warning.
  ```

  You can also suppress the warning in your project file, which disables the warning for all source files in the project.

  ```xml
  <Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
     <TargetFramework>net5.0</TargetFramework>
     <!-- NoWarn below will suppress SYSLIB0005 project-wide -->
     <NoWarn>$(NoWarn);SYSLIB0005</NoWarn>
    </PropertyGroup>
  </Project>
  ```

  Suppressing `SYSLIB0005` disables only the <xref:System.Reflection.Assembly.GlobalAssemblyCache> obsoletion warning. It does not disable any other warnings.

## Affected APIs

- <xref:System.Reflection.Assembly.GlobalAssemblyCache?displayProperty=fullName>

<!--

### Category

Core .NET libraries

### Affected APIs

- `P:System.Reflection.Assembly.GlobalAssemblyCache`

-->
