---
title: What's new in .NET 7
description: Learn about the new features introduced in .NET 7.
ms.date: 10/21/2022
ms.topic: overview
ms.author: gewarren
author: gewarren
---
# What's new in .NET 7

.NET 7 continues the themes that were central to the [.NET 6](dotnet-6.md) release with improvements around the following key areas:

- Unified
- Modern
- Simple
- Fast

To find all the articles that have been updated for .NET 7, see [What's new in docs for .NET 7]().

.NET 7 will be [supported for 18 months](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a standard-term support (STS) release (previously known as a *current* release).

## Performance

- https://devblogs.microsoft.com/dotnet/performance_improvements_in_net_7/
- on-stack replacement (OSR)

Cloud native apps - simplify security configuration; improve app performance
.NET Upgrade Assistant improvements
WCF?
P/Invoke code generation - LibraryImport (https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-7/#libraryimport-p-invoke-source-generator)
STJ
- custom contracts
- polymorphism
RegEx
- source generators - builds an engine that's optimized for your pattern at compile time
- span support (new APIs)
- performance improvements
- analyzer to find (and fix) places you can use it
"dotnet new" - tab completion to explore templates and parameters
Template authoring - https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-6/#template-authoring
Native AOT (vs. JIT) - improves startup time. requires trimmed apps. native pre-compilation for .NET desktop client and server scenarios (focusing on console apps and native libraries).
- https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/
Library trimming
Observability ("understand the state of your application as scale and technical complexity increases") - OpenTelemetry - https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-4/#observability
Cache metrics - https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-4/#added-metrics-for-microsoft-extensions-caching
NuGet - central package management
Generic math
Text classification API for ML.NET - https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-5/#ml-net-text-classification-api
Unix file modes - https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-7/#support-for-unix-file-modes
Publish to a container using dotnet publish - https://devblogs.microsoft.com/dotnet/announcing-builtin-container-support-for-the-dotnet-sdk/

## System.Text.Json serialization

.NET 7 includes improvements to System.Text.Json serialization in the following areas:

- **Contract customization** gives you more control over how types are serialized and deserialized. For more information, see [Customize a JSON contract](../../standard/serialization/system-text-json/custom-contracts.md).
- **Polymorphic serialization** for user-defined type hierarchies. For more information, see [Serialize properties of derived classes](../../standard/serialization/system-text-json/polymorphism.md).
- Support for **required members**, which are properties that must be present in the JSON payload for deserialization to succeed. For more information, see [Required properties](../../standard/serialization/system-text-json/required-properties.md).

For information about these and other updates, see the [What's new in System.Text.Json in .NET 7](https://devblogs.microsoft.com/dotnet/system-text-json-in-dotnet-7/) blog post.

## .NET libraries

Track microseconds and nanoseconds in date and time structures
New Tar APIs
- https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-4/#added-new-tar-apis
- https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-6/#system-formats-tar-api-updates
Rate limiting - https://devblogs.microsoft.com/dotnet/announcing-rate-limiting-for-dotnet/
Stream.ReadExactly and Stream.ReadAtLeast (https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-5/#system-io-stream)
New type converters for DateOnly, TimeOnly, Int128, UInt128, and Half (converts value types to/from string, usually)

## Related releases

This section contains information about related products that have releases to coincide with the .NET 7 release.

### C# 11

C# 11 includes support for generic attributes and [generic math](../../standard/generics/math.md), file-scoped types, and many other new features. For more information, see [What's new in C# 11](../../csharp/whats-new/csharp-11.md).

### .NET MAUI

.NET Multi-platform App UI (.NET MAUI) is a cross-platform framework for creating native mobile and desktop apps with C# and XAML. It unifies Android, iOS, macOS, and Windows APIs into a single API. For information about the latest updates, see [...](/dotnet/maui/...).

### ASP.NET Core

ASP.NET Core 7.0 includes rate-limiting middleware, improvements to minimal APIs, and gRPC JSON transcoding. For information about all the updates, see [What's new in ASP.NET Core 7](/aspnet/core/release-notes/aspnetcore-7.0).

### EF Core

Entity Framework Core 7.0 includes provider-agnostic support for JSON columns, improved performance for saving changes, and custom reverse engineering templates. For information about all the updates, see [What's new in EF Core 7.0](/ef/core/what-is-new/ef-core-7.0/whatsnew).

### Orleans

Orleans is a cross-platform framework for building robust, scalable distributed applications. For information about the latest updates for Orleans, see [What's new in Orleans 7.0](../../orleans/whats-new-in-orleans.md).

## See also

- [Release notes for .NET 7](https://github.com/dotnet/core/tree/main/release-notes/7.0)
