---
title: Cross Platform P/Invoke
description: Learn which paths the runtime will search when loading native libraries via P/Invoke. Also learn how to use SetDllImportResolver.
author: saul
ms.date: 01/31/2021
---

# Writing cross platform P/Invoke code

## Library name variations

To facilitate simpler cross platform P/Invoke code, the runtime adds the canonical shared library extension (`.dll`, `.so` or `.dylib`) to native library names. On Linux and macOS, the runtime will also try prepending `lib`. These library names variations are automatically searched when you use APIs that load unmanaged libraries (e.g., <xref:System.Runtime.InteropServices.DllImportAttribute>).

> [!NOTE]
> Absolute paths in library names (e.g., `/usr/lib/libc`) are treated as-is and no variations will be searched.

Consider the following example of using P/Invoke:

```csharp
[DllImport("nativedep")]
static extern int ExportedFunction();
```

When running on Windows, the DLL is searched for in the following order:

1. `nativedep`
1. `nativedep.dll` (if the library name does not already end with `.dll` or .`exe`)

When running on Linux or macOS, the runtime will try prepending `lib` and appending the canonical shared library extension. On these OSes, library name variations are tried in the following order:

1. `nativedep.so` / `nativedep.dylib`
1. `libnativedep.so` / `libnativedep.dylib` <sup>1</sup>
1. `nativedep`
1. `libnativedep` <sup>1</sup>

On Linux, the search order is different if the library name ends with `.so` or contains `.so.` (note the trailing `.`). Consider the following example:

```csharp
[DllImport("nativedep.so.6")]
static extern int ExportedFunction();
```

In this case, the library name variations are tried in the following order:

1. `nativedep.so.6`
1. `libnativedep.so.6` <sup>1</sup>
1. `nativedep.so.6.so`
1. `libnativedep.so.6.so` <sup>1</sup>

<sup>1</sup> Path is checked only if the library name does not contain a directory separator character (`/`).

## Custom import resolver

In more complex scenarios, you can use <xref:System.Runtime.InteropServices.NativeLibrary.SetDllImportResolver%2A> to resolve DLL imports at run time. In the following example, `nativedep` is resolved to `nativedep_avx2` if the CPU supports it.

> [!TIP]
> This functionality is only available in .NET 5 and .NET Core 3.1 or later.

[!code-csharp[import resolver](~/samples/snippets/standard/interop/pinvoke/import-resolver/Program.cs)]

## See also

- [Platform Invoke (P/Invoke)](pinvoke.md)
