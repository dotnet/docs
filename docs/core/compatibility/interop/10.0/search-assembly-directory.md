---
title: "Breaking change - Specifying DllImportSearchPath.AssemblyDirectory only searches the assembly directory"
description: "Learn about the breaking change in .NET 10 Preview 5 where specifying DllImportSearchPath.AssemblyDirectory as the only search flag restricts the search to the assembly directory."
ms.date: 5/9/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/45911
---

# Specifying DllImportSearchPath.AssemblyDirectory only searches the assembly directory

In .NET 10 Preview 5, specifying <xref:System.Runtime.InteropServices.DllImportSearchPath.AssemblyDirectory?displayProperty=nameWithType> as the only search flag now restricts the runtime to search exclusively in the assembly directory. This change affects the behavior of P/Invokes and the <xref:System.Runtime.InteropServices.NativeLibrary> class.

## Version introduced

.NET 10 Preview 5

## Previous behavior

When <xref:System.Runtime.InteropServices.DllImportSearchPath.AssemblyDirectory?displayProperty=nameWithType> was specified as the only search flag, the runtime searched the assembly directory first. If the library was not found, it fell back to the operating system's default library search behavior.

Example:

```csharp
[DllImport("example.dll", DllImportSearchPath = DllImportSearchPath.AssemblyDirectory)]
public static extern void ExampleMethod();
```

In this case, the runtime would search the assembly directory and then fall back to the OS search paths.

## New behavior

When <xref:System.Runtime.InteropServices.DllImportSearchPath.AssemblyDirectory?displayProperty=nameWithType> is specified as the only search flag, the runtime searches only in the assembly directory. It does not fall back to the operating system's default library search behavior.

The previous code example would now only search the assembly directory for *example.dll*. If the library is not found there, a <xref:System.DllNotFoundException> will be thrown.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The fallback behavior when specifying <xref:System.Runtime.InteropServices.DllImportSearchPath.AssemblyDirectory?displayProperty=nameWithType> caused confusion and was inconsistent with the design of search flags. This change ensures clarity and consistency in behavior.

## Recommended action

If fallback behavior is required, avoid specifying an explicit <xref:System.Runtime.InteropServices.DllImportSearchPath>. By default, when no flags are specified, the runtime searches the assembly directory and then falls back to the operating system's default library search behavior.

Example:

```csharp
[DllImport("example.dll")]
public static extern void ExampleMethod();
```

## Affected APIs

- P/Invokes using <xref:System.Runtime.InteropServices.DefaultDllImportSearchPathsAttribute>
- <xref:System.Runtime.InteropServices.NativeLibrary.Load*?displayProperty=fullName>
- <xref:System.Runtime.InteropServices.NativeLibrary.TryLoad*?displayProperty=fullName>
