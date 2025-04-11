---
title: "Breaking change - Linux native library resolution no longer uses `netcoredeps`"
description: "Learn about the breaking change in .NET 8 where Linux applications no longer search the `netcoredeps` subdirectory for native libraries."
ms.date: 4/10/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/45777
---

# Linux native library resolution no longer uses `netcoredeps`

Starting in .NET 8, Linux applications no longer search the `netcoredeps` subdirectory for native libraries.

## Version introduced

.NET 8

## Previous behavior

In earlier versions of .NET, Linux applications searched for native libraries in a `netcoredeps` subdirectory located next to the application executable. This behavior applied to all native library loads, including user-defined platform invokes (p/invokes).

## New behavior

In .NET 8 and later, Linux applications no longer search the `netcoredeps` subdirectory for native libraries. Native library resolution now follows standard mechanisms without relying on this subdirectory.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The `netcoredeps` behavior was originally introduced to handle complex dependencies on third-party libraries in earlier .NET versions. .NET 8+ no longer requires this behavior due to improved dependency handling. Additionally, the mechanism isn't aligned with recommended practices for ELF platforms.

For more information, see [GitHub issue #114393](https://github.com/dotnet/runtime/issues/114393).

## Recommended action

If your application relied on the `netcoredeps` subdirectory for p/invokes or custom native library resolution, use the following alternatives:

- Implement a custom resolution mechanism using one of the following:
  - <xref:System.Runtime.Loader.AssemblyLoadContext.ResolvingUnmanagedDll?displayProperty=fullName>
  - [System.Runtime.Loader.AssemblyLoadContext.LoadUnmanagedDll](/dotnet/api/system.runtime.loader.assemblyloadcontext.loadunmanageddll)
  - <xref:System.Runtime.InteropServices.NativeLibrary.SetDllImportResolver(System.Reflection.Assembly,System.Runtime.InteropServices.DllImportResolver)?displayProperty=fullName>
  - <xref:System.Runtime.InteropServices.NativeLibrary.Load*?displayProperty=fullName>
- If an `RPATH` is required in your deployment, modify the ELF file explicitly using the `patchelf` utility.

## Affected APIs

- `DllImport`
- <xref:System.Runtime.InteropServices.NativeLibrary.Load*?displayProperty=fullName>
