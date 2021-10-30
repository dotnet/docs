---
title: What's new in .NET 6
description: Learn about the new features introduced in .NET 6.
ms.date: 10/22/2021
ms.topic: overview
ms.author: gewarren
author: gewarren
---
# What's new in .NET 6

.NET 6 delivers the final parts of the .NET unification plan that started with [.NET 5](dotnet-5.md). .NET 6 unifies the SDK, base libraries, and runtime across mobile, desktop, IoT, and cloud apps. In addition to this unification, the .NET 6 ecosystem focuses on the following themes:

- Simplified development

  Getting started is easy. New language features in [C# 10](../../csharp/whats-new/csharp-10.md) reduce the amount of code you need to write. And investments in the web stack and minimal APIs make it easy to quickly write smaller, faster microservices.

- Better performance

  .NET 6 is the fastest full stack web framework, which lowers your compute costs if you're running in the cloud.

- Ultimate productivity

  .NET 6 and [Visual Studio 2022](/visualstudio/releases/2022/release-notes) provide hot reload, new git tooling, intelligent code editing experiences, robust diagnostics and testing tools, and better team collaboration.

.NET 6 will be [supported for three years](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a long-term support (LTS) release.

For features that are noted as being in *preview*, this means that they are disabled by default. They are also not supported for use in production and may be removed in a future version. The new <xref:System.Runtime.Versioning.RequiresPreviewFeaturesAttribute> is used to annotate preview APIs, and a corresponding analyzer alerts you if you're using these preview APIs.

## Performance

For detailed information, see [Performance Improvements in .NET 6](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6/).

### Hot reload

Inner loop perf.

### FileStream

FileStream perf on Windows.

### Arm64

Better Arm64 perf. Support macOS and Windows Arm64 (including x64 emulation) - native is best. Don't used emulation unless you need to. Arm64 and x64 need to install SxS.

### Profile-guided optimization

Profile-guided optimization (PGO) is where the JIT compiler generates optimized code in terms of the types and code paths that are most frequently used. .NET 6 introduces *dynamic* PGO. Dynamic PGO works hand-in-hand with tiered compilation to further optimize code based on additional instrumentation that's put in place during tier 0. Dynamic PGO is disabled by default, but you can enable it with the `DOTNET_TieredPGO` [environment variable](../run-time-config/compilation.md#profile-guided-optimization). For more information, see [JIT performance improvements](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6/#jit).

### Crossgen2

.NET 6 introduces Crossgen2, the successor to Crossgen. Crossgen and Crossgen2 are tools that provide ahead-of-time (AOT) compilation to improve the startup time of an app. Crossgen2 is written in C# instead of C++, and can perform analysis and optimization that weren't possible with the previous version. For more information, see [Conversation about Crossgen2](https://devblogs.microsoft.com/dotnet/conversation-about-crossgen2/).

### OpenTelemetry

Improved support for OpenTelemetry.

### EventPipe


## C# 10 and templates

C# 10 includes innovations such as `global using` directives, file-scoped namespace declarations, and record structs. For more information, see [What's new in C# 10](../../csharp/whats-new/csharp-10.md).

In concert with that work, the .NET SDK project templates for C# have been modernized to use some of the new language features:

- `async main` method
- Top-level statements
- Target-typed new expressions
- `global using` directives
- File-scoped namespaces
- Nullable reference types

By adding these new language features to the project templates, new code starts with the features enabled. However, existing code isn't affected when you upgrade to .NET 6. For more information about these template changes, see [.NET SDK: C# project templates modernized](https://devblogs.microsoft.com/dotnet/announcing-net-6-release-candidate-2/#net-sdk-c-project-templates-modernized).

## Visual Basic and F#

Visual Basic has improvements in the Visual Studio experience and Windows Forms project startup.

F# 6 adds several improvements to the F# language and F# Interactive. For more information, see [What's new in F# 6](../../fsharp/whats-new/fsharp-6.md).

## Cloud diagnostics


## SDK Workloads

To keep the size of the .NET SDK smaller, some components have been placed in new, optional *SDK workloads*. These components include .NET MAUI, Android, iOS, and WebAssembly. For more information, see [Optional SDK Workloads](https://github.com/dotnet/designs/blob/main/accepted/2020/workloads/workloads.md).

## System.Text.Json APIs

STJ is now "industrial strength" - can ignore object cycles, streaming serialization with IAsyncEnumerable, efficient writeable DOM, serialization notifications, serialization property ordering, write "raw" JSON.

## HTTP/3

.NET 6 includes preview support for HTTP/3, a new version of HTTP. HTTP/3 solves some existing functional and performance challenges by using a new underlying connection protocol called QUIC. QUIC establishes connections more quickly, and connections are independent of the IP address, allowing mobile clients to roam between wifi and cellular networks. For more information, see [HTTP/3 support in .NET 6](https://devblogs.microsoft.com/dotnet/http-3-support-in-dotnet-6/).

## ASP.NET Core

ASP.NET Core includes improvements in minimal APIs, ahead-of-time (AOT) compilation for Blazor WebAssembly apps, and single-page apps. In addition, Blazor components can now be rendered from JavaScript and integrated with existing JavaScript based apps. <!--For more information, see [What's new in ASP.NET Core 6](/aspnet/core/release-notes/aspnetcore-6.0).-->

## File I/O


## Security

.NET 6 adds preview support for two key security mitigations: Control-flow Enforcement Technology (CET) and W^X.

CET is an Intel technology available in some newer Intel and AMD processors. It adds capabilities to the hardware that protect against some control-flow hijacking attacks. .NET 6 provides support for CET for Windows x64 apps, and you must explicitly enable it. For more information, see [.NET 6 compatibility with Intel CET shadow stacks](https://github.com/dotnet/runtime/blob/release/6.0/docs/design/features/intel-cet-dotnet6.md).

W^X is available all operating systems with .NET 6 but only enabled by default on Apple Silicon. W^X blocks the simplest attack path by disallowing memory pages to be writeable and executable at the same time.

Support for OpenSSL 3, support for new algorithms (e.g. Poly1305).

## Single-file apps

Not just Linux. Single file works for macOS and Windows now as well.

## IL trimming

more aggressive IL trimming - analyzer warns of bad patterns, warnings enabled by default. Removes unused types, members, and assemblies. (Unused types/members is new for .NET 6.)

## Source generators

JSON (de)serialization, MS.Extensions.Logging

## Analyzers

API compatibility, platform compatibility, trimming safety, use Span, use faster String APIs, use faster collection APIs.

## Windows Forms

Default font.
Application bootstrap.

## Source build

The source tarball, which contains all the source for the .NET SDK, is a now a product of the .NET SDK build. Other organizations, such as Red Hat, can build their own version of the SDK using this source tarball.

## Generic math

Another new *preview* feature is the ability to use operators on generic types in .NET 6. .NET 6 introduces numerous interfaces that make use of C# 10's new preview feature, `static abstract` interface members. These interfaces correspond to different operators, for example, `IAdditionOperators` represents the `+` operator. The interfaces are available in the [System.Runtime.Experimental](https://www.nuget.org/packages/System.Runtime.Experimental) NuGet package. For more information, see the [Generic math](https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/) blog post.

## NuGet package validation


## Custom platform guards


## New APIs

### Reflection APIs for nullability information

.NET 6 introduces the following new APIs that inspect code and provide nullability information:

- <xref:System.Reflection.NullabilityInfo?displayProperty=fullName>
- <xref:System.Reflection.NullabilityInfoContext?displayProperty=fullName>
- <xref:System.Reflection.NullabilityState?displayProperty=fullName>

These APIs are useful for reflection-based tools and serializers.


- implicit using directives based on SDK
- Support Apple Silicon for macOS and arm64 for Windows
- tfms
- CLI template search
- APIs
  - priorityqueue
  - Microsoft.Extensions
    - hosting
    - dependency injection
  - new LINQ APIs
  - DateOnly, TimeOnly, time zone improvements
  - WebSocket compression

## See also

- [What's new in C# 10.0](../../csharp/whats-new/csharp-10.md)
- [What's new in F# 6](../../fsharp/whats-new/fsharp-6.md)
- [What's new in EF Core 6](/ef/core/what-is-new/ef-core-6.0/whatsnew)
- [Release notes for .NET 6](https://github.com/dotnet/core/tree/main/release-notes/6.0)
- [Release notes for Visual Studio 2022](/visualstudio/releases/2022/release-notes)
- [Blog: Announcing .NET 6 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-1/)
- [Blog: Announcing .NET 6 Preview 2](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-2/)
- [Blog: Announcing .NET 6 Preview 3](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-3/)
- [Blog: Announcing .NET 6 Preview 4](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-4/)
- [Blog: Announcing .NET 6 Preview 5](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-5/)
- [Blog: Announcing .NET 6 Preview 6](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-6/)
- [Blog: Announcing .NET 6 Preview 7](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-7/)
- [Blog: Announcing .NET 6 Release Candidate 1](https://devblogs.microsoft.com/dotnet/announcing-net-6-release-candidate-1/)
- [Blog: Announcing .NET 6 Release Candidate 2](https://devblogs.microsoft.com/dotnet/announcing-net-6-release-candidate-2/)
