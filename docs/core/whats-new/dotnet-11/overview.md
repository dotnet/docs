---
title: What's new in .NET 11
description: Learn about the new features introduced in .NET 11 for the runtime, libraries, and SDK. Also find links to what's new in other areas, such as ASP.NET Core.
titleSuffix: ""
ms.date: 03/10/2026
ai-usage: ai-assisted
ms.update-cycle: 3650-days
---

# What's new in .NET 11

This article describes new features in .NET 11. It was last updated for Preview 2.

.NET 11 is currently in preview. The final release is expected in November 2026. You can [download .NET 11 here](https://dotnet.microsoft.com/download/dotnet/11.0).

Your feedback is important and appreciated. If you have questions or comments, use the discussion on [GitHub](https://github.com/dotnet/core/discussions/categories/news).

## .NET runtime

The .NET 11 runtime includes:

- Updated minimum hardware requirements for x86/x64 and Arm64 architectures, requiring more modern instruction sets to improve performance and reduce maintenance complexity
- Runtime-native async (Runtime Async), which produces cleaner stack traces and lower overhead
- JIT improvements for bounds check elimination, redundant checked context removal, and new Arm SVE2 intrinsics

For more information, see [What's new in the .NET 11 runtime](runtime.md).

## .NET libraries

The .NET 11 libraries include new APIs for:

- String and character manipulation, including Rune-based operations in String and BFloat16 support in BitConverter
- Compression, including improved Base64 APIs and new methods for ZIP archive entries
- Generic type info retrieval in System.Text.Json
- Tar archive format selection
- Numerics, including a Matrix4x4 performance improvement

For more information, see [What's new in the .NET 11 libraries](libraries.md).

## .NET SDK

The .NET 11 SDK includes:

- Smaller SDK installers on Linux and macOS through assembly deduplication
- Improved CA1873 code analyzer with reduced noise and clearer diagnostic messages
- Analyzer bug fixes for CA1515, CA1034, and CA1859
- A new NETSDK1235 warning for custom `.nuspec` files used with PackAsTool

For more information, see [What's new in the SDK for .NET 11](sdk.md).

## ASP.NET Core

For information about what's new in ASP.NET Core, see [What's new in ASP.NET Core for .NET 11](/aspnet/core/release-notes/aspnetcore-11).

## C# 15

C# 15 includes these features:

- [Collection expression arguments](../../../csharp/whats-new/csharp-15.md#collection-expression-arguments)

For information about new C# features, see [What's new in C# 15](../../../csharp/whats-new/csharp-15.md).

## Breaking changes

For information about breaking changes in .NET 11, see [Breaking changes in .NET 11](../../compatibility/11.md).

## See also

- [What's new in .NET 10](../dotnet-10/overview.md)
