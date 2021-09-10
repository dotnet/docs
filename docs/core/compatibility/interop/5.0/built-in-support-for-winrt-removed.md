---
title: "Breaking change: Built-in support for WinRT is removed from .NET"
description: Learn about the interop breaking change in .NET 5 where built-in support for WinRT is removed from .NET.
ms.date: 10/13/2020
---
# Built-in support for WinRT is removed from .NET

Built-in support for consumption of [Windows runtime (WinRT)](/uwp/winrt-cref/winrt-type-system) APIs in .NET is removed.

## Version introduced

5.0

## Change description

Previously, CoreCLR could consume [Windows metadata (WinMD) files](/uwp/winrt-cref/winmd-files) to active and consume WinRT types. Starting in .NET 5, CoreCLR can no longer consume WinMD files directly.

If you attempt to reference an unsupported assembly, you'll get a <xref:System.IO.FileNotFoundException>. If you activate a WinRT class, you'll get a <xref:System.PlatformNotSupportedException>.

This breaking change was made for the following reasons:

- So WinRT can be developed and improved separately from the .NET runtime.
- For symmetry with interop systems provided for other operating systems, such as iOS and Android.
- To take advantage of other .NET features, such as C# features, intermediate language (IL) trimming, and ahead-of-time (AOT) compilation.
- To simplify the .NET runtime codebase.

## Recommended action

- Remove references to the [Microsoft.Windows.SDK.Contracts package](https://www.nuget.org/packages/Microsoft.Windows.SDK.Contracts).  Instead, specify the version of the Windows APIs that you want to access via the `TargetFramework` property of the project.  For example:

  ```xml
  <TargetFramework>net5.0-windows10.0.19041.0</TargetFramework>
  ```

- Use the [C#/WinRT](/windows/uwp/csharp-winrt/) tool chain to generate or customize WinRT APIs and types for .NET 5 and later versions.

For more information, see [Call Windows Runtime APIs in desktop apps](/windows/apps/desktop/modernize/desktop-to-uwp-enhance).

## Affected APIs

- <xref:System.IO.WindowsRuntimeStorageExtensions?displayProperty=fullName>
- <xref:System.IO.WindowsRuntimeStreamExtensions?displayProperty=fullName>
- <xref:System.Runtime.InteropServices.WindowsRuntime?displayProperty=fullName>
- <xref:System.WindowsRuntimeSystemExtensions?displayProperty=fullName>
- <xref:Windows.Foundation.Point?displayProperty=fullName>
- <xref:Windows.Foundation.Size?displayProperty=fullName>
- <xref:Windows.UI.Color?displayProperty=fullName>

<!--

### Affected APIs

- `T:System.IO.WindowsRuntimeStorageExtensions`
- `T: System.IO.WindowsRuntimeStreamExtensions`
- `N:System.Runtime.InteropServices.WindowsRuntime`
- `T:System.WindowsRuntimeSystemExtensions`
- `T:Windows.Foundation.Point`
- `T:Windows.Foundation.Size`
- `T:Windows.UI.Color`

### Category

Interop

-->
