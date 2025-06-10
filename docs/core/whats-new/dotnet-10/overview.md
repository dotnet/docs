---
title: What's new in .NET 10
description: Learn about the new features introduced in .NET 10 for the runtime, libraries, and SDK. Also find links to what's new in other areas, such as ASP.NET Core.
titleSuffix: ""
ms.date: 06/09/2025
ms.topic: whats-new
ai-usage: ai-assisted
---

# What's new in .NET 10

Learn about the new features in .NET 10 and find links to further documentation. This page is updated for Preview 5.

.NET 10, the successor to [.NET 9](../dotnet-9/overview.md), is [supported for three years](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a long-term support (LTS) release. You can [download .NET 10 here](https://get.dot.net/10).

Your feedback is important and appreciated. If you have questions or comments, use the discussion on [GitHub](https://github.com/dotnet/core/discussions/categories/news).

## .NET runtime

The .NET 10 runtime introduces improvements in JIT inlining, method devirtualization, and stack allocations. It also includes AVX10.2 support and NativeAOT enhancements.

For more information, see [What's new in the .NET 10 runtime](runtime.md).

## .NET libraries

The .NET 10 libraries introduce new APIs in cryptography, globalization, numerics, serialization, collections, and diagnostics, and when working with ZIP files.

For more information, see [What's new in the .NET 10 libraries](libraries.md).

## .NET SDK

The .NET 10 SDK includes support for Microsoft.Testing.Platform in `dotnet test`, standardizes CLI command order, and updates the CLI to generate native tab-completion scripts for popular shells. For containers, console apps can natively create container images, and a new property lets you explicitly set the format of container images.

For more information, see [What's new in the SDK for .NET 10](sdk.md).

## .NET Aspire

For information about what's new in .NET Aspire, see [.NET Aspire — what's new?](/dotnet/aspire/whats-new/).

## ASP.NET Core

The ASP.NET Core 10.0 release introduces several new features and enhancements, including Blazor improvements, OpenAPI enhancements, and minimal API updates.

For details, see [What's new in ASP.NET Core for .NET 10](/aspnet/core/release-notes/aspnetcore-10.0).

## C# 14

C# 14 introduces several new features and enhancements to improve developer productivity and code quality. Key updates include:

- Field-backed properties provide a smoother path from auto-implemented properties to writing custom `get` and `set` accessors. You can access the compiler-generated backing field using the `field` contextual keyword.
- The `nameof` expression now supports unbound generic types, such as `List<>`, where it returns the name of the type without requiring a type argument.
- First-class support for implicit conversions of `Span<T>` and `ReadOnlySpan<T>`.
- Parameter modifiers like `ref`, `in`, or `out` are allowed in lambda expressions without specifying parameter types.
- Support for partial instance constructors and partial events, complementing partial methods and properties introduced in C# 13.
- New `extension` blocks add support for static extension methods, and static and instance extension properties.
- Null-conditional assignment using the `?.` operator.

For more information, see [What's new in C# 14](../../../csharp/whats-new/csharp-14.md).

## F\#

The F# updates in .NET 10 include several new features and improvements across the language, standard library, and compiler service. Key updates include:

- **F# Language**:

  New language features require enabling the `<LangVersion>preview</LangVersion>` project property in `.fsproj` files. These features become the default with the .NET 10 release.

- **FSharp.Core Standard Library**:

  Changes to the `FSharp.Core` standard library are applied automatically to projects compiled with the new SDK unless a lower `FSharp.Core` version is explicitly pinned.

- **FSharp.Compiler.Service**:

  General improvements and bug fixes in the compiler implementation.

For more information, see the [F# release notes](https://fsharp.github.io/fsharp-compiler-docs/release-notes/About.html).

## Visual Basic

The Visual Basic updates in .NET 10 include the following enhancements to the compiler:

- The compiler now interprets and enforces the `unmanaged` generic constraint, which enables better compatibility with runtime APIs.
- The compiler respects the <xref:System.Runtime.CompilerServices.OverloadResolutionPriorityAttribute>. This enhancement ensures faster, Span-based overloads are preferred and helps to resolve overload ambiguities.

These updates ensure that Visual Basic can consume updated features in C# and the runtime. For more information, see [What's new in Visual Basic](../../../visual-basic/whats-new/index.md).

## .NET MAUI

The .NET MAUI updates in .NET 10 include several new features and quality improvements for .NET MAUI, .NET for Android, and .NET for iOS, Mac Catalyst, macOS, and tvOS.

For details, see [What's new in .NET MAUI in .NET 10](/dotnet/maui/whats-new/dotnet-10).

## EF Core

The EF Core 10 release introduces several new features and improvements, including LINQ enhancements, performance optimizations, and improved support for Azure Cosmos DB.

For details, see [What's new in EF Core for .NET 10](/ef/core/what-is-new/ef-core-10.0/whatsnew).

## Windows Forms

Changes in Windows Forms for .NET 10 include clipboard-related updates, ported `UITypeEditors` from .NET Framework, and quality enhancements.

For details, see [What's new in Windows Forms for .NET 10](/dotnet/desktop/winforms/whats-new/net100).

## WPF

The WPF updates in .NET 10 include several performance improvements, Fluent style changes, bug fixes, and more.

For details, see [What's new in WPF in .NET 10](/dotnet/desktop/wpf/whats-new/net100).
