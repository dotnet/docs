---
title: "NETSDK1130: Can't reference a Windows Metadata component directly"
description: How to resolve the issue of not being able to reference a Windows Metadata component directly from an app that targets .NET 5 or later.
ms.topic: error-reference
ms.date: 06/29/2021
f1_keywords:
- NETSDK1130
---
# NETSDK1130: Can't reference a Windows Metadata component directly

NETSDK1130 indicates that you're trying to reference a Windows Metadata component directly from an app that targets .NET 5 or later. The full error message is similar to the following example:

> *\<Component name>* cannot be referenced. Referencing a Windows Metadata component directly when targeting .NET 5 or higher is not supported.

To resolve this error:

* Remove references to the [Microsoft.Windows.SDK.Contracts package](https://www.nuget.org/packages/Microsoft.Windows.SDK.Contracts). Instead, specify the version of the Windows APIs that you want to access via the `TargetFramework` property of the project. For example:

  ```xml
  <TargetFramework>net5.0-windows10.0.19041.0</TargetFramework>
  ```

* If you're consuming a third-party runtime component that's defined in a *.winmd* file, add a reference to the [Microsoft.Windows.CsWinRT NuGet package](https://www.nuget.org/packages/Microsoft.Windows.CsWinRT/). For information on how to generate the C# projection, see the [C#/WinRT](/windows/uwp/csharp-winrt/) documentation.

For more information, see [Built-in support for WinRT is removed from .NET](../../compatibility/interop/5.0/built-in-support-for-winrt-removed.md) and [Call Windows Runtime APIs in desktop apps](/windows/apps/desktop/modernize/desktop-to-uwp-enhance).
