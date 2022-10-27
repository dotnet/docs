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

Many improvements have been made to .NET library APIs. The following table shows some of the new APIs and why you might use them.

| Description | APIs | Further information |
| - | - | - |
| Support for microseconds and nanoseconds in <xref:System.TimeSpan>, <xref:System.TimeOnly>, <xref:System.DateTime>, and <xref:System.DateTimeOffset> types | <xref:System.DateTime.Microsecond?displayProperty=nameWithType><br /><xref:System.DateTime.Nanosecond?displayProperty=nameWithType><br /><xref:System.DateTime.AddMicroseconds(System.Double)?displayProperty=nameWithType><br />New <xref:System.DateTime> constructor overloads<br /><br /><xref:System.DateTimeOffset.Microsecond?displayProperty=nameWithType><br /><xref:System.DateTimeOffset.Nanosecond?displayProperty=nameWithType><br /><xref:System.DateTimeOffset.AddMicroseconds(System.Double)?displayProperty=nameWithType><br />New <xref:System.DateTimeOffset> constructor overloads<br /><br /><xref:System.TimeOnly.Microsecond?displayProperty=nameWithType><br /><xref:System.TimeOnly.Nanosecond?displayProperty=nameWithType><br /><br /><xref:System.TimeSpan.Microseconds?displayProperty=nameWithType><br /><xref:System.TimeSpan.Nanoseconds?displayProperty=nameWithType><br /><xref:System.TimeSpan.FromMicroseconds(System.Double)?displayProperty=nameWithType><br />and others... | These APIs mean you no longer have to perform computations on the "tick" value to determine microsecond and nanosecond values. For more information, see the [.NET 7 Preview 4](https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-4/#adding-microseconds-and-nanoseconds-to-timestamp-datetime-datetimeoffset-and-timeonly) blog post. |
| APIs for reading, writing, archiving, and extracting Tar archives | <xref:System.Formats.Tar?displayProperty=fullName> | For more information, see the [.NET 7 Preview 4](https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-4/#added-new-tar-apis) and [.NET 7 Preview 6](https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-6/#system-formats-tar-api-updates) blog posts. |
| Rate limiting APIs to protect a resource by keeping traffic at a safe level | <xref:System.Threading.RateLimiting.RateLimiter?displayProperty=fullName> and others in the [System.Threading.RateLimiting NuGet package](https://www.nuget.org/packages/System.Threading.RateLimiting) | For more information, see [Rate limit an HTTP handler in .NET](../extensions/http-ratelimiter.md) and [Announcing rate limiting for .NET](https://devblogs.microsoft.com/dotnet/announcing-rate-limiting-for-dotnet/). |
| APIs to read *all* the data from a <xref:System.IO.Stream> | <xref:System.IO.Stream.ReadExactly%2A?displayProperty=nameWithType> and <xref:System.IO.Stream.ReadAtLeast%2A?displayProperty=nameWithType> | <xref:System.IO.Stream.Read%2A?displayProperty=nameWithType> may return less data than what's available in the stream. The new `ReadExactly` methods read *exactly* the number of bytes requested, and the new `ReadAtLeast` methods read *at least* the number of bytes requested. For more information, see the [.NET 7 Preview 5 blog post](https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-5/#system-io-stream). |
| New type converters for `DateOnly`, `TimeOnly`, `Int128`, `UInt128`, and `Half` | <xref:System.ComponentModel.DateOnlyConverter?displayProperty=fullName><br /><xref:System.ComponentModel.TimeOnlyConverter?displayProperty=fullName><br /><xref:System.ComponentModel.Int128Converter?displayProperty=fullName><br /><xref:System.ComponentModel.UInt128Converter?displayProperty=fullName><br /><xref:System.ComponentModel.HalfConverter?displayProperty=fullName> | Type converters are often used to convert value types to and from a string. These new APIs add type converters for types that were added more recently. |

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
