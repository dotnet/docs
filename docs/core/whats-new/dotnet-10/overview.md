---
title: What's new in .NET 10
description: Learn about the new features introduced in .NET 10 for the runtime, libraries, and SDK. Also find links to what's new in other areas, such as ASP.NET Core.
titleSuffix: ""
ms.date: 04/09/2025
ms.topic: whats-new
ai-usage: ai-assisted
---

# What's new in .NET 10

Learn about the new features in .NET 10 and find links to further documentation. This page is updated for Preview 3.

.NET 10, the successor to [.NET 9](../dotnet-9/overview.md), is [supported for three years](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a long-term support (LTS) release. You can [download .NET 10 here](https://get.dot.net/10).

Your feedback is important and appreciated. If you have questions or comments, use the discussion on [GitHub](https://github.com/dotnet/core/discussions/categories/news).

## .NET runtime

The .NET 10 runtime introduces new features and performance improvements. Key updates include:

- **Array interface method devirtualization**: The JIT can now devirtualize and inline array interface methods, improving performance for array enumerations.
- **Array enumeration de-abstraction**: Enhancements to reduce abstraction overhead for array iteration via enumerators, enabling better inlining and stack allocation.
- **Inlining of late devirtualized methods**: The JIT can now inline methods that become eligible for devirtualization due to previous inlining.
- **Devirtualization based on inlining observations**: The JIT uses precise type information from inlining to devirtualize subsequent calls.
- **Stack allocation of arrays of value types**: Small, fixed-sized arrays of value types without GC pointers can now be stack-allocated.
- **AVX10.2 support**: Introduced support for Advanced Vector Extensions (AVX) 10.2 for x64-based processors, though currently disabled by default.
- **NativeAOT enhancements**: Support for casting and negation in NativeAOT's type preinitializer.

For more information, see [What's new in the .NET 10 runtime](runtime.md).

## .NET libraries

The .NET 10 libraries introduce several new features and improvements, including:

- **Find certificates by thumbprints other than SHA-1**: A new method allows finding certificates using hash algorithms like SHA-256.
- **Find PEM-encoded data in ASCII/UTF-8**: PEM encoding APIs now support reading directly from ASCII/UTF-8 data.
- **ISOWeek support for DateOnly**: New overloads in the <xref:System.Globalization.ISOWeek> class support the <xref:System.DateOnly> type.
- **String normalization APIs for spans**: New APIs allow Unicode string normalization to work with spans of characters, reducing allocations.
- **Numeric ordering for string comparison**: A new <xref:System.Globalization.CompareOptions.NumericOrdering?displayProperty=nameWithType> option enables numerical string comparisons.
- **New TimeSpan.FromMilliseconds overload**: A single-parameter overload resolves issues with LINQ expressions.
- **ZipArchive performance improvements**: Optimizations reduce memory usage and improve performance for <xref:System.IO.Compression.ZipArchive> in `Update` mode and parallel extraction.
- **OrderedDictionary enhancements**: New `TryAdd` and `TryGetValue` overloads return an index for fast access.
- **JSON serialization updates**: Source generators now allow specifying `ReferenceHandler` in <xref:System.Text.Json.Serialization.JsonSourceGenerationOptionsAttribute>.
- **Left-handed matrix transformations**: New APIs for creating left-handed transformation matrices.
- **PKCS#12 export enhancements**: New methods allow specifying encryption and digest algorithms for PKCS#12/PFX export.

For more information, see [What's new in the .NET 10 libraries](libraries.md).

## .NET SDK

The .NET 10 SDK introduces the following new features and enhancements, including:

- **Pruning of framework-provided package references**: Automatically removes unused framework-provided package references, reducing build times and disk usage.
- **More consistent command order**: New noun-first aliases for `dotnet` CLI commands improve readability and consistency.
- **CLI commands default to interactive mode in interactive terminals**: The `--interactive` flag is now enabled by default for CLI commands in interactive terminals.
- **Native shell tab-completion scripts**: The `dotnet` CLI now supports generating native tab-completion scripts for popular shells using the `dotnet completions generate [SHELL]` command. Supported shells include `bash`, `fish`, `nushell`, `powershell`, and `zsh`.
- **Console apps can natively create container images**: Console apps can now create container images via `dotnet publish /t:PublishContainer` without requiring the `<EnableSdkContainerSupport>` property in the project file.
- **Explicitly control the image format of containers**: A new `<ContainerImageFormat>` property allows you to explicitly set the format of container images to either `Docker` or `OCI`.
- **Support for Microsoft.Testing.Platform in `dotnet test`**: A new `dotnet test` experience made specifically for Microsoft.Testing.Platform can be opted-in via `dotnet.config`. For more information about the existing `dotnet test` integration for MTP and the new integration, see [Testing with `dotnet test`](../../testing/unit-testing-with-dotnet-test.md).

For more information, see [What's new in the SDK for .NET 10](sdk.md).

## .NET Aspire

.NET Aspire releases version 9.1, which focuses on quality-of-life fixes.

For details, see [What's new in .NET Aspire 9.1](/dotnet/aspire/whats-new/dotnet-aspire-9.1).

## ASP.NET Core

The ASP.NET Core 10.0 release introduces several new features and enhancements, including Blazor improvements, OpenAPI enhancements, and minimal API updates.

For details, see [What's new in ASP.NET Core for .NET 10](/aspnet/core/release-notes/aspnetcore-10.0).

## C# 14

C# 14 introduces several new features and enhancements to improve developer productivity and code quality. Key updates include:

- **Field-backed properties**: Provides a smoother path from auto-implemented properties to writing custom `get` and `set` accessors. The compiler-generated backing field can now be accessed using the `field` contextual keyword.
- **Unbound generic support for `nameof`**: The `nameof` expression now supports unbound generic types, such as `List<>`, returning the name of the type without requiring type arguments.
- **Implicit span conversions**: Introduces first-class support for `Span<T>` and `ReadOnlySpan<T>` with new implicit conversions, enabling more natural programming with these types.
- **Modifiers on simple lambda parameters**: Allows parameter modifiers like `ref`, `in`, or `out` in lambda expressions without specifying parameter types.
- **Partial events and constructors**: Adds support for partial instance constructors and partial events, complementing partial methods and properties introduced in C# 13.
- **Extension members**: Extension methods now support static methods, instance properties, and static properties through `extension` blocks, enabling more flexible and powerful extensions.
- **Null-conditional assignment**: Simplifies conditional assignments by allowing properties or fields to be updated only if the containing instance exists, using the `?.` operator.
- **Experimental feature - String literals in data section**: Enables emitting string literals as UTF-8 data into a separate section of the PE file, improving efficiency for certain scenarios.

For more information, see [What's new in C# 14](../../../csharp/whats-new/csharp-14.md).

## F\#

The F# updates in .NET 10 include several new features and improvements across the language, standard library, and compiler service. Key updates include:

- **F# Language**:
  - New language features require enabling the `<LangVersion>preview</LangVersion>` project property in `.fsproj` files. These features become the default with the .NET 10 release.

- **FSharp.Core Standard Library**:
  - Changes to the `FSharp.Core` standard library are applied automatically to projects compiled with the new SDK unless a lower `FSharp.Core` version is explicitly pinned.

- **FSharp.Compiler.Service**:
  - General improvements and bug fixes in the compiler implementation.

For more information, see the [F# release notes](https://fsharp.github.io/fsharp-compiler-docs/release-notes/About.html).

## Visual Basic

The Visual Basic updates in .NET 10 include the following features and enhancements:

- **`unmanaged` constraint support**: The Visual Basic compiler now interprets and enforces the `unmanaged` generic constraint, enabling better compatibility with runtime APIs.
- **Honor overload resolution priority**: The Visual Basic compiler respects the <xref:System.Runtime.CompilerServices.OverloadResolutionPriorityAttribute>, ensuring faster Span-based overloads are preferred and resolving ambiguities among method overloads.

These updates ensure that Visual Basic can consume updated features in C# and the runtime, improving compatibility and performance.

For more information, see [What's new in Visual Basic](../../../visual-basic/whats-new/index.md).

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
