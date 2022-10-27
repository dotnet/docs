---
title: What's new in .NET 7
description: Learn about the new features introduced in .NET 7.
ms.date: 10/21/2022
ms.topic: overview
ms.author: gewarren
author: gewarren
---
# What's new in .NET 7

.NET 7 is the successor to [.NET 6](dotnet-6.md) and focuses on being unified, modern, simple, and *fast*. .NET 7 will be [supported for 18 months](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a standard-term support (STS) release (previously known as a *current* release). This article lists the new features of .NET 7 and provides links to more detailed information on each.

To find all the <https://learn.microsoft.com/dotnet> articles that have been updated for .NET 7, see [What's new in docs for .NET 7]().

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
- https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/
Library trimming
Observability ("understand the state of your application as scale and technical complexity increases") - OpenTelemetry - https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-4/#observability
NuGet - central package management
Text classification API for ML.NET - https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-5/#ml-net-text-classification-api
Publish to a container using dotnet publish - https://devblogs.microsoft.com/dotnet/announcing-builtin-container-support-for-the-dotnet-sdk/

## Performance

Performance is a key focus of .NET 7, and all of its features are designed with performance in mind. In addition, .NET 7 includes the following enhancements aimed purely at performance:

- On-stack replacement (OSR) is a complement to tiered compilation. It allows the runtime to change the code executed by a currently running method in the middle of its execution (that is, while it's "on stack"). Long-running methods can switch to more optimized versions mid-execution.
- Profile-guided optimization (PGO) now works with OSR and is easier to enable (by adding `<TieredPGO>true</TieredPGO>` to your project file). PGO can also instrument and optimize additional things, such as delegates.
- Improved code generation for Arm64.
- Native AOT produces a standalone executable in the target platform's file format with no external dependencies. It's entirely native, with no IL or JIT, and provides fast startup time and a small, self-contained deployment. In .NET 7, Native AOT focuses on console apps and requires apps to be trimmed.
- Performance improvements to the mono runtime, which powers Blazor WebAssembly, Android, and iOS apps.

For a detailed look at everything that's gone into making .NET 7 so fast, see the epic [Performance improvements in .NET 7](https://devblogs.microsoft.com/dotnet/performance_improvements_in_net_7/) blog post.

## System.Text.Json serialization

.NET 7 includes improvements to System.Text.Json serialization in the following areas:

- **Contract customization** gives you more control over how types are serialized and deserialized. For more information, see [Customize a JSON contract](../../standard/serialization/system-text-json/custom-contracts.md).
- **Polymorphic serialization** for user-defined type hierarchies. For more information, see [Serialize properties of derived classes](../../standard/serialization/system-text-json/polymorphism.md).
- Support for **required members**, which are properties that must be present in the JSON payload for deserialization to succeed. For more information, see [Required properties](../../standard/serialization/system-text-json/required-properties.md).

For information about these and other updates, see the [What's new in System.Text.Json in .NET 7](https://devblogs.microsoft.com/dotnet/system-text-json-in-dotnet-7/) blog post.

## Generic math

.NET 7 and C# 11 include innovations that allow you to perform mathematical operations generically&mdash;that is, without having to know the exact type you're working with. For example, if you wanted to write a method that adds two numbers, previously you had to add an overload of the method for each type. Now you can write a single, generic method, where the type parameter is constrained to be a number-like type. For more information, see [Generic math](../../standard/generics/math.md) and the [Generic math](https://devblogs.microsoft.com/dotnet/dotnet-7-generic-math/) blog post.

## .NET libraries

Many improvements have been made to .NET library APIs. The following table shows some of the new APIs and why you might use them.

| Description | APIs | Further information |
| - | - | - |
| Support for microseconds and nanoseconds in <xref:System.TimeSpan>, <xref:System.TimeOnly>, <xref:System.DateTime>, and <xref:System.DateTimeOffset> types | <xref:System.DateTime.Microsecond?displayProperty=nameWithType> and <xref:System.DateTime.Nanosecond?displayProperty=nameWithType><br /><xref:System.DateTime.AddMicroseconds(System.Double)?displayProperty=nameWithType><br />New <xref:System.DateTime> constructor overloads<br /><br /><xref:System.DateTimeOffset.Microsecond?displayProperty=nameWithType> and <xref:System.DateTimeOffset.Nanosecond?displayProperty=nameWithType><br /><xref:System.DateTimeOffset.AddMicroseconds(System.Double)?displayProperty=nameWithType><br />New <xref:System.DateTimeOffset> constructor overloads<br /><br /><xref:System.TimeOnly.Microsecond?displayProperty=nameWithType> and <xref:System.TimeOnly.Nanosecond?displayProperty=nameWithType><br /><br /><xref:System.TimeSpan.Microseconds?displayProperty=nameWithType> and <xref:System.TimeSpan.Nanoseconds?displayProperty=nameWithType><br /><xref:System.TimeSpan.FromMicroseconds(System.Double)?displayProperty=nameWithType><br />and others... | These APIs mean you no longer have to perform computations on the "tick" value to determine microsecond and nanosecond values. For more information, see the [.NET 7 Preview 4](https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-4/#adding-microseconds-and-nanoseconds-to-timestamp-datetime-datetimeoffset-and-timeonly) blog post. |
| APIs for reading, writing, archiving, and extracting Tar archives | <xref:System.Formats.Tar?displayProperty=fullName> | For more information, see the [.NET 7 Preview 4](https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-4/#added-new-tar-apis) and [.NET 7 Preview 6](https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-6/#system-formats-tar-api-updates) blog posts. |
| Rate limiting APIs to protect a resource by keeping traffic at a safe level | <xref:System.Threading.RateLimiting.RateLimiter?displayProperty=fullName> and others in the [System.Threading.RateLimiting NuGet package](https://www.nuget.org/packages/System.Threading.RateLimiting) | For more information, see [Rate limit an HTTP handler in .NET](../extensions/http-ratelimiter.md) and [Announcing rate limiting for .NET](https://devblogs.microsoft.com/dotnet/announcing-rate-limiting-for-dotnet/). |
| APIs to read *all* the data from a <xref:System.IO.Stream> | <xref:System.IO.Stream.ReadExactly%2A?displayProperty=nameWithType><br /><xref:System.IO.Stream.ReadAtLeast%2A?displayProperty=nameWithType> | <xref:System.IO.Stream.Read%2A?displayProperty=nameWithType> may return less data than what's available in the stream. The new `ReadExactly` methods read *exactly* the number of bytes requested, and the new `ReadAtLeast` methods read *at least* the number of bytes requested. For more information, see the [.NET 7 Preview 5](https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-5/#system-io-stream) blog post. |
| New type converters for `DateOnly`, `TimeOnly`, `Int128`, `UInt128`, and `Half` | <xref:System.ComponentModel.DateOnlyConverter?displayProperty=fullName><br /><xref:System.ComponentModel.TimeOnlyConverter?displayProperty=fullName><br /><xref:System.ComponentModel.Int128Converter?displayProperty=fullName><br /><xref:System.ComponentModel.UInt128Converter?displayProperty=fullName><br /><xref:System.ComponentModel.HalfConverter?displayProperty=fullName> | Type converters are often used to convert value types to and from a string. These new APIs add type converters for types that were added more recently. |
| Metrics support for <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache> | <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheStatistics?displayProperty=fullName><br /><xref:Microsoft.Extensions.Caching.Memory.MemoryCache.GetCurrentStatistics?displayProperty=nameWithType> | <xref:Microsoft.Extensions.Caching.Memory.MemoryCache.GetCurrentStatistics> lets you use event counters or metrics APIs to track statistics for one or more memory caches. For more information, see the [.NET 7 Preview 4](https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-4/#added-metrics-for-microsoft-extensions-caching) blog post. |
| APIs to get and set Unix file permissions | <xref:System.IO.UnixFileMode?displayProperty=fullName> enum<br /><xref:System.IO.File.GetUnixFileMode%2A?displayProperty=nameWithType><br /><xref:System.IO.File.SetUnixFileMode%2A?displayProperty=nameWithType><xref:System.IO.FileSystemInfo.UnixFileMode?displayProperty=nameWithType><br /><xref:System.IO.Directory.CreateDirectory(System.String,System.IO.UnixFileMode)?displayProperty=nameWithType><br /><xref:System.IO.FileStreamOptions.UnixCreateMode?displayProperty=nameWithType> | For more information, see the [.NET 7 Preview 7](https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-7/#support-for-unix-file-modes) blog post. |

## Related releases

This section contains information about related products that have releases to coincide with the .NET 7 release.

### Visual Studio 2022 version 17.4

For more information, see [What's new in Visual Studio 2022](/visualstudio/ide/whats-new-visual-studio-2022).

### C# 11

C# 11 includes support for [generic math](../../standard/generics/math.md), raw string literals, file-scoped types, and other new features. For more information, see [What's new in C# 11](../../csharp/whats-new/csharp-11.md).

### .NET MAUI

.NET Multi-platform App UI (.NET MAUI) is a cross-platform framework for creating native mobile and desktop apps with C# and XAML. It unifies Android, iOS, macOS, and Windows APIs into a single API. For information about the latest updates, see [...](/dotnet/maui/...).

### ASP.NET Core

ASP.NET Core 7.0 includes rate-limiting middleware, improvements to minimal APIs, and gRPC JSON transcoding. For information about all the updates, see [What's new in ASP.NET Core 7](/aspnet/core/release-notes/aspnetcore-7.0).

### EF Core

Entity Framework Core 7.0 includes provider-agnostic support for JSON columns, improved performance for saving changes, and custom reverse engineering templates. For information about all the updates, see [What's new in EF Core 7.0](/ef/core/what-is-new/ef-core-7.0/whatsnew).

### Windows Forms



### Orleans

Orleans is a cross-platform framework for building robust, scalable distributed applications. For information about the latest updates for Orleans, see [What's new in Orleans 7.0](../../orleans/whats-new-in-orleans.md).

## See also

- [Release notes for .NET 7](https://github.com/dotnet/core/tree/main/release-notes/7.0)
