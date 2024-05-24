---
title: What's new in .NET 9
description: Learn about the new .NET features introduced in .NET 9.
titleSuffix: ""
ms.date: 05/21/2024
ms.topic: whats-new
---
# What's new in .NET 9

Learn about the new features in .NET 9 and find links to further documentation.

.NET 9, the successor to [.NET 8](../dotnet-8/overview.md), has a special focus on cloud-native apps and performance. It will be [supported for 18 months](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a standard-term support (STS) release. You can [download .NET 9 here](https://dotnet.microsoft.com/download/dotnet/9.0).

New for .NET 9, the engineering team posts .NET 9 preview updates on [GitHub Discussions](https://github.com/dotnet/core/discussions/9234). That's a great place to ask questions and provide feedback about the release.

## .NET runtime

The .NET 9 runtime includes a new attribute model for feature switches with trimming support. The new attributes make it possible to define [feature switches](https://github.com/dotnet/designs/blob/main/accepted/2020/feature-switch.md) that the libraries can use to toggle areas of functionality.

The runtime also includes numerous performance improvements in the following areas:

- Loop optimizations
- Inlining improvements
- PGO improvements: Type checks and casts
- Arm64 vectorization in .NET libraries
- Faster exceptions

For more information, see [What's new in the .NET 9 runtime](runtime.md).

## .NET libraries

<xref:System.Text.Json> has new options that let you customize the indentation character and indentation size of written JSON. It also includes a new <xref:System.Text.Json.JsonSerializerOptions.Web?displayProperty=nameWithType> singleton that makes it easier to serialize using web defaults.

In LINQ, the new methods <xref:System.Linq.Enumerable.CountBy%2A> and <xref:System.Linq.Enumerable.AggregateBy%2A> make it possible to aggregate state by key without needing to allocate intermediate groupings via <xref:System.Linq.Enumerable.GroupBy%2A>.

For collection types, the <xref:System.Collections.Generic.PriorityQueue%602?displayProperty=fullName> collection type includes a new <xref:System.Collections.Generic.PriorityQueue%602.Remove(%600,%600@,%601@,System.Collections.Generic.IEqualityComparer{%600})> method that you can use to *update* the priority of an item in the queue.

For cryptography, .NET 9 adds a new one-shot hash method on the <xref:System.Security.Cryptography.CryptographicOperations> type. It also adds new classes that use the KMAC algorithm.

In the reflection area, the new <xref:System.Reflection.Emit.PersistedAssemblyBuilder> type lets you *save* an emitted assembly. This new class also includes PDB support, meaning you can emit symbol info and use it to debug a generated assembly.

The <xref:System.TimeSpan> class includes new `From*` methods that let you create a `TimeSpan` object from an `int` (instead of a `double`). These methods help to avoid errors caused by inherent imprecision in floating-point calculations.

In diagnostics, the new <xref:System.Diagnostics.Activity.AddLink(System.Diagnostics.ActivityLink)?displayProperty=nameWithType> API lets you link an <xref:System.Diagnostics.Activity> object to other tracing contexts after it's created. Previously, you could only link a tracing `Activity` to other tracing contexts when you created it.

For more information, see [What's new in the .NET 9 libraries](libraries.md).

## .NET SDK

The .NET 9 SDK includes improvements to unit testing, including better integration with MSBuild that allows you to run tests in parallel. For tools, a new option for [`dotnet tool install`](../../tools/dotnet-tool-install.md) lets *users* decide whether a tool is allowed to run on a newer .NET runtime version than the version the tool targets. Also, the terminal logger is now enabled by default and also has improved usability, including summarizing the total count of failures and warnings at the end of a build.

For more information, see [What's new in the SDK for .NET 9](sdk.md).

## ML.NET

ML.NET is an open-source, cross-platform machine learning framework for .NET developers that enables integration of custom machine learning models into .NET applications. The latest version, ML.NET 4.0, adds [additional tokenizer support](../../../machine-learning/whats-new/overview.md#additional-tokenizer-support) for tokenizers such as Tiktoken and models such as Llama and CodeGen.

## .NET Aspire

.NET Aspire is an opinionated, cloud-ready stack for building observable, production ready, distributed applications.​ .NET Aspire is delivered through a collection of NuGet packages that handle specific cloud-native concerns, and is available in preview for .NET 9. For more information, see [.NET Aspire](/dotnet/aspire).

## ASP.NET Core

ASP.NET Core includes improvements to Blazor, SignalR, minimal APIs, OpenAPI, and authentication and authorization. For more information, see [What's new in ASP.NET Core 9.0](/aspnet/core/release-notes/aspnetcore-9.0).

## .NET MAUI

The focus of .NET Multi-platform App UI (.NET MAUI) in .NET 9 is to improve product quality. For more information about that and the new features, see [What's new in .NET MAUI for .NET 9](/dotnet/maui/whats-new/dotnet-9).

## EF Core

Entity Framework Core includes significant updates to the database provider for Azure Cosmos DB for NoSQL. It also includes some steps towards AOT compilation and pre-compiled queries, among other improvements. For more information, see [What's New in EF Core 9](/ef/core/what-is-new/ef-core-9.0/whatsnew).

## C# 13

C# 13 ships with the .NET 9 SDK and includes the following new features:

- `params` collections
- New `lock` type and semantics
- New escape sequence - `\e`
- Method group natural type improvements
- Implicit indexer access in object initializers

For more information, see [What's new in C# 13](../../../csharp/whats-new/csharp-13.md).

## Windows Presentation Foundation

Windows Presentation Foundation (WPF) includes support for Windows 11 theming and hyphen-based ligatures. For more information, see [WPF in .NET 9 Preview 4 - Release Notes](https://github.com/dotnet/core/blob/main/release-notes/9.0/preview/preview4/wpf.md).

<!--

## Windows Forms

...

-->

## See also

- [Our vision for .NET 9](https://devblogs.microsoft.com/dotnet/our-vision-for-dotnet-9/) blog post
- [What's new in ASP.NET Core 9.0](/aspnet/core/release-notes/aspnetcore-9.0)
- [What's new in .NET MAUI](/dotnet/maui/whats-new/dotnet-9)
- [What's new in EF Core](/ef/core/what-is-new/ef-core-9.0/whatsnew)
