---
title: What's new in .NET 10
description: Learn about the new features introduced in .NET 10 for the runtime, libraries, and SDK. Also find links to what's new in other areas, such as ASP.NET Core.
titleSuffix: ""
ms.date: 02/20/2025
ms.topic: whats-new
ai-usage: ai-assisted
---

# What's new in .NET 10

Learn about the new features in .NET 10 and find links to further documentation. This page has been updated for Preview 1.

.NET 10, the successor to [.NET 9](../dotnet-9/overview.md) and will be [supported for 3 years](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a long-term support (LTS) release. You can [download .NET 10 here](https://get.dot.net/10).

Your feedback is important and appreciated. If you have questions or comments, please use the discussion on [GitHub](https://github.com/dotnet/core/discussions/categories/news).

## .NET runtime

The .NET 10 runtime has introduced new features and performance improvements, which have been updated for Preview 1. One of the main focuses for .NET 10 is to reduce the abstraction overhead of popular language features. In order to achieve this goal, the JIT's ability to devirtualize method calls has been expanded to cover array interface methods. This means that the JIT can now optimize code that loops over an array, even if there are virtual calls involved. Additionally, the JIT now has the ability to stack-allocate small, fixed-sized arrays of value types that do not contain GC pointers, further reducing the abstraction penalty of reference types.

Another new feature in .NET 10 is the support for Advanced Vector Extensions (AVX) 10.2 for x64-based processors. This is currently disabled by default as hardware supporting AVX10.2 is not yet available. Once it is available, the new intrinsics in the `System.Runtime.Intrinsics.X86.Avx10v2` class can be tested. These updates and improvements are part of the ongoing efforts to achieve performance parity between different implementations in .NET 10.

For more information, see [What's new in the .NET 10 runtime](runtime.md).

## .NET libraries

The .NET 10 libraries introduce several new features and improvements. A new method `FindByThumbprint` allows finding certificates by thumbprints using hash algorithms other than SHA-1. Additionally, support has been added for reading PEM-encoded data directly from ASCII encoded files. The <xref:System.Globalization.ISOWeek> class now includes new method overloads to support the <xref:System.DateOnly> type. Unicode string normalization APIs have been enhanced to work with spans of characters, and a new `CompareOptions.NumericOrdering` option has been introduced for numerical string comparison.

Additionally, a new <xref:System.TimeSpan.FromMilliseconds*?displayProperty=nameWithType> overload that takes a single parameter has been added. The performance and memory usage of [ZipArchive](xref:System.IO.Compression.ZipArchive) have been improved. New `TryAdd` and `TryGetValue` overloads for <xref:System.Collections.Generic.OrderedDictionary`2?displayProperty=nameWithType> now return an index to the entry. JSON serialization has been enhanced by allowing the specification of <xref:System.Text.Json.Serialization.ReferenceHandler> in <xref:System.Text.Json.Serialization.JsonSourceGenerationOptionsAttribute>. Lastly, new APIs have been introduced for creating left-handed transformation matrices for billboard and constrained-billboard matrices.

For more information, see [What's new in the .NET 10 libraries](libraries.md).

## .NET SDK

The .NET 10 SDK introduces following new features and enhancements:

- [Pruning of Framework-provided Package References](sdk.md#pruning-of-framework-provided-package-references)

For more information, see [What's new in the SDK for .NET 10](sdk.md).

## .NET Aspire

.NET Aspire releases version 9.1, which focuses on quality-of-life fixes.

For more information, see [.NET Aspire — what's new?](/dotnet/aspire/whats-new/).

## ASP.NET Core

Changes in ASP.NET Core 10.0 include:

- Blazor: Added new features for Blazor, including the QuickGrid RowClass parameter and Blazor script serving as a static web asset.
- SignalR: Added new features for SignalR.
- Minimal APIs: Added new features for minimal APIs.
- OpenAPI: Added support for generating OpenAPI version 3.1 documents and serving the generated OpenAPI document in YAML format.
- Authentication and authorization: Added new features for authentication and authorization.
- Miscellaneous: Added better support for testing apps with top-level statements and a new helper method for detecting local URLs.

For more information, see [What's new in ASP.NET Core for .NET 10](/aspnet/core/release-notes/aspnetcore-10.0).

## .NET MAUI

This release was focused on quality improvements to .NET MAUI, .NET for Android, and .NET for iOS, Mac Catalyst, macOS, and tvOS.

For more information, see [What's new in .NET MAUI in .NET 10](/dotnet/maui/whats-new/dotnet-10).

## EF Core

Changes for EF Core 10 include:

- LINQ and SQL translation enhancements.
- ExecuteUpdateAsync now accepts a regular, non-expression lambda.

For more information, see [What's new in EF Core for .NET 10](/ef/core/what-is-new/ef-core-10.0/whatsnew).

## C# 14

C# 14 introduces several new features and enhancements to improve developer productivity and code quality. Some of the key updates include:

- `nameof` in unbound generics.
- Implicit span conversions.
- `field` backed properties.
- Modifiers on simple lambda parameters.
- Experimental feature - String literals in data section.

For more information, see [What's new in C# 14](/dotnet/csharp/whats-new/csharp-14).

## Windows Forms

Changes in Windows Forms for .NET 10 include:

- Clipboard-related serialization and deserialization changes.
- Obsoleted Clipboard APIs.
- New Clipboard-related APIs.

For more information, see [What's new in Windows Forms for .NET 10](/dotnet/desktop/winforms/whats-new/net100).

## See also

- [.NET 10 Preview 1 container image updates](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/containers.md)
- [F# updates in .NET 10 Preview 1](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/fsharp.md)
- [Visual Basic updates in .NET 10 Preview 1](https://github.com/dotnet/core/blob/dotnet10p1/release-notes/10.0/preview/preview1/visualbasic.md)
