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

.NET MAUI - unifies Android, iOS, macOS, and Windows APIs into a single API
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
Track microseconds and nanoseconds in date and time structures
Cache metrics - https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-4/#added-metrics-for-microsoft-extensions-caching
New Tar APIs
- https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-4/#added-new-tar-apis
- https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-6/#system-formats-tar-api-updates
NuGet - central package management
Generic math
Text classification API for ML.NET - https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-5/#ml-net-text-classification-api
Stream.ReadExactly and Stream.ReadAtLeast (https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-5/#system-io-stream)
New type converters for DateOnly, TimeOnly, Int128, UInt128, and Half (converts value types to/from string, usually).
Unix file modes - https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-7/#support-for-unix-file-modes
Publish to a container using dotnet publish - https://devblogs.microsoft.com/dotnet/announcing-builtin-container-support-for-the-dotnet-sdk/
Rate limiting - https://devblogs.microsoft.com/dotnet/announcing-rate-limiting-for-dotnet/



## See also

- [What's new in ASP.NET Core 6](/aspnet/core/release-notes/aspnetcore-7.0)
- [What's new in EF Core 7.0](/ef/core/what-is-new/ef-core-7.0/whatsnew)
- [What's new in C# 11](../../csharp/whats-new/csharp-11.md)
- [Release notes for .NET 7](https://github.com/dotnet/core/tree/main/release-notes/7.0)
