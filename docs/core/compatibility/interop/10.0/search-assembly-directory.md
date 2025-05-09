---
title: "Breaking change - Specifying DllImportSearchPath.AssemblyDirectory only searches the assembly directory"
description: "Learn about the breaking change in .NET 10 Preview 5 where specifying DllImportSearchPath.AssemblyDirectory as the only search flag restricts the search to the assembly directory."
ms.date: 5/9/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/45911
---

# Specifying DllImportSearchPath.AssemblyDirectory only searches the assembly directory

In .NET 10 Preview 5, specifying `DllImportSearchPath.AssemblyDirectory` as the only search flag now restricts the runtime to search exclusively in the assembly directory. This change affects the behavior of P/Invokes and the `NativeLibrary` class.

## Version introduced

.NET 10 Preview 5

## Previous behavior

When `DllImportSearchPath.AssemblyDirectory` was specified as the only search flag, the runtime searched the assembly directory first. If the library was not found, it fell back to the operating system's default library search behavior.

Example:

```csharp
[DllImport("example.dll", DllImportSearchPath = DllImportSearchPath.AssemblyDirectory)]
public static extern void ExampleMethod();
```

In this case, the runtime would search the assembly directory and then fall back to the OS search paths.

## New behavior

When `DllImportSearchPath.AssemblyDirectory` is specified as the only search flag, the runtime searches only in the assembly directory. It does not fall back to the operating system's default library search behavior.

The previous code example would now only search the assembly directory for *example.dll*. If the library is not found there, a `DllNotFoundException` will be thrown.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The fallback behavior when specifying `DllImportSearchPath.AssemblyDirectory` caused confusion and was inconsistent with the design of search flags. This change ensures clarity and consistency in behavior.

## Recommended action

If fallback behavior is required, avoid specifying an explicit `DllImportSearchPath`. By default, when no flags are specified, the runtime searches the assembly directory and then falls back to the operating system's default library search behavior.

Example:

```csharp
[DllImport("example.dll")]
public static extern void ExampleMethod();
```

## Affected APIs

- P/Invokes using [`DefaultDllImportSearchPaths`](https://learn.microsoft.com/dotnet/api/system.runtime.interopservices.defaultdllimportsearchpathsattribute)
- [`NativeLibrary.Load`](https://learn.microsoft.com/dotnet/api/system.runtime.interopservices.nativelibrary.load#system-runtime-interopservices-nativelibrary-load(system-string-system-reflection-assembly-system-nullable((system-runtime-interopservices-dllimportsearchpath))))
- [`NativeLibrary.TryLoad`](https://learn.microsoft.com/dotnet/api/system.runtime.interopservices.nativelibrary.tryload#system-runtime-interopservices-nativelibrary-tryload(system-string-system-reflection-assembly-system-nullable((system-runtime-interopservices-dllimportsearchpath))-system-intptr@))
