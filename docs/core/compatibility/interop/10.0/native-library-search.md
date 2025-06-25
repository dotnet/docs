---
title: "Breaking change - Single-file apps no longer look for native libraries in executable directory"
description: "Learn about the breaking change in .NET 10 where single-file apps no longer look for native libraries in the executable directory."
ms.date: 06/25/2025
ms.custom: https://github.com/dotnet/docs/issues/46356
---

# Single-file apps no longer look for native libraries in executable directory

Previously, in [single-file .NET applications](../../../deploying/single-file/overview.md), the directory of the single-file executable was added to the `NATIVE_DLL_SEARCH_DIRECTORIES` property during startup. Consequently, .NET always [probed](../../../dependency-loading/default-probing.md#unmanaged-native-library-probing) the application directory when unmanaged libraries were loaded. On non-Windows with [NativeAOT](../../../deploying/native-aot/index.md), the `rpath` was set to the application directory by default, such that it also always looked for native libraries in the application directory.

The application directory is no longer added to `NATIVE_DLL_SEARCH_DIRECTORIES` in single-file apps, and the `rpath` setting has been removed in NativeAOT. In both cases, <xref:System.Runtime.InteropServices.DllImportSearchPath.AssemblyDirectory?displayProperty=nameWithType> (included in the default behaviour for p/invokes) means the application directory - specifying that flag or leaving the default will look in the application directory. Specifying flags without that value will no longer look in the application directory.

## Version introduced

.NET 10 Preview 6

## Previous behavior

Previously, single-file applications always looked in the application directory when loading native libraries. On non-Windows operating systems, NativeAOT applications always looked in the application directory when loading native libraries.

For example, the following P/Invoke looked *in the application directory* for `lib` and loaded it from there if it existed:

```csharp
[DllImport("lib")
[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
static extern void Method()
```

## New behavior

Starting in .NET 10, single-file applications only look in the application directory if the search paths for a native library load indicate including the assembly directory.

```csharp
// Look in System32 on Windows.
// Search the OS on non-Windows.
[DllImport("lib")
[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
static extern void Method()

// Look next to the single-file app because assembly directory
// means application directory for single-file apps.
[DllImport("lib")
[DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory)]
static extern void Method()

// Look next to the single-file app (because assembly
// directory is searched by default), then default OS search.
[DllImport("lib")
static extern void Method()
```

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The existing behavior (always look in the application directory even if search paths exclude it) has caused confusion. It's also inconsistent with how the search flags are handled in regular (non-single-file, non-NativeAOT) .NET applications.

## Recommended action

If the application/assembly directory is desired for a P/Invoke or native library load and wasn't previously specified, specify <xref:System.Runtime.InteropServices.DllImportSearchPath.AssemblyDirectory?displayProperty=nameWithType>.

If the `RPATH` setting is desired in NativeAOT, explicitly add the corresponding [linker arguments](../../../deploying/native-aot/interop.md#linking) to your project.

## Affected APIs

- P/Invokes
- <xref:System.Runtime.InteropServices.NativeLibrary.Load*?displayProperty=fullName>
- <xref:System.Runtime.InteropServices.NativeLibrary.TryLoad*?displayProperty=fullName>

## See also

- [Specifying DllImportSearchPath.AssemblyDirectory only searches the assembly directory](search-assembly-directory.md)
