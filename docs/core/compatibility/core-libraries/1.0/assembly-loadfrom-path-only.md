---
title: "Breaking change: Assembly.LoadFrom only accepts a file path, not a URI"
description: "Learn about the breaking change in .NET Core 1.0 where the assemblyFile parameter of Assembly.LoadFrom is treated as a file path rather than a URI."
ms.date: 03/11/2026
ai-usage: ai-assisted
---

# Assembly.LoadFrom only accepts a file path, not a URI

In .NET Core, the `assemblyFile` parameter of <xref:System.Reflection.Assembly.LoadFrom(System.String)?displayProperty=nameWithType> is treated strictly as a file path rather than a URI. Passing a URI string, such as a `file://` or `http://` URL, does not work as it did in .NET Framework.

## Version introduced

.NET Core 1.0

## Previous behavior

Previously, in .NET Framework, the `assemblyFile` parameter accepted either a file path or a URI. The documentation stated: "The assemblyFile parameter must refer to a URI without escape characters. This method supplies escape characters for all invalid characters in the URI."

For example, code like the following—which built a URI from <xref:System.Reflection.Assembly.CodeBase?displayProperty=nameWithType>—worked in .NET Framework:

```csharp
// Worked in .NET Framework
string codeBase = someAssembly.CodeBase; // Returns a "file://..." URI
Assembly asm = Assembly.LoadFrom(codeBase);
```

## New behavior

Starting in .NET Core 1.0, `Assembly.LoadFrom` passes the `assemblyFile` parameter directly to <xref:System.IO.Path.GetFullPath(System.String)?displayProperty=nameWithType>, which interprets the value as a file path. URI strings are mangled by this path-processing logic and the assembly cannot be loaded.

```csharp
// Does NOT work in .NET Core — the URI is treated as a path string
Assembly asm = Assembly.LoadFrom("file:///C:/mydir/myassembly.dll");

// Works in .NET Core — pass a local file path
Assembly asm2 = Assembly.LoadFrom(@"C:\mydir\myassembly.dll");
```

HTTP and other remote URIs are not supported at all:

```csharp
// Does NOT work in .NET Core
Assembly asm = Assembly.LoadFrom("http://myserver/mydir/myassembly.dll");
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Supporting URI schemes other than `file://` would require significant infrastructure to download assemblies from remote locations (such as HTTP servers), which introduces security concerns. Treating the parameter as a plain file path simplifies the implementation and avoids these risks.

## Recommended action

Update code that passes URI strings to `Assembly.LoadFrom` to pass a local file path instead.

If you previously used <xref:System.Reflection.Assembly.CodeBase?displayProperty=nameWithType> to obtain a URI and then passed it to `Assembly.LoadFrom`, use <xref:System.Reflection.Assembly.Location?displayProperty=nameWithType> instead to get a file path:

```csharp
// Before (.NET Framework)
string codeBase = someAssembly.CodeBase; // e.g., "file:///C:/mydir/myassembly.dll"
Assembly asm = Assembly.LoadFrom(codeBase);

// After (.NET Core)
string location = someAssembly.Location; // e.g., "C:\mydir\myassembly.dll"
Assembly asm = Assembly.LoadFrom(location);
```

> [!NOTE]
> <xref:System.Reflection.Assembly.CodeBase?displayProperty=nameWithType> itself is obsolete in .NET 5 and later (it throws <xref:System.PlatformNotSupportedException> in some contexts, such as single-file publish). Prefer <xref:System.Reflection.Assembly.Location?displayProperty=nameWithType>.

If you need to load an assembly from a remote location, download it to a local file first and then load it from the local path.

## Affected APIs

- <xref:System.Reflection.Assembly.LoadFrom(System.String)?displayProperty=nameWithType>

<!--

### Category

Core .NET libraries

### Affected APIs

- `M:System.Reflection.Assembly.LoadFrom(System.String)`

-->
