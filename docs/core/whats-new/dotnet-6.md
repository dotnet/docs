---
title: What's new in .NET 6
description: Learn about the new features introduced in .NET 6.
ms.date: 10/22/2021
ms.topic: overview
ms.author: gewarren
author: gewarren
---
# What's new in .NET 6

.NET 6 delivers the final parts of the .NET unification plan that started with [.NET 5](dotnet-5.md). .NET 6 unifies the SDK, base libraries, and runtime across mobile, desktop, IoT, and cloud apps. In addition to this unification, The .NET 6 ecosystem focuses on the following themes:

- Simplified development

  Getting started is easy. New language features in [C# 10](../../csharp/whats-new/csharp-10.md) reduce the amount of code you need to write. And investments in the web stack and minimal APIs make it easy to quickly write smaller, faster microservices.

- Better performance

  .NET 6 is the fastest full stack web framework, which lowers your compute costs if you're running in the cloud.

- Ultimate productivity

  .NET 6 and [Visual Studio 2022](/visualstudio/releases/2022/release-notes) provide hot reload, new git tooling, intelligent code editing experiences, robust diagnostics and testing tools, and better team collaboration.

.NET 6 will be [supported for three years](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a long-term support (LTS) release.

## Performance

### Hot reload

Inner loop perf.

### FileStream

FileStream perf on Windows.

### Arm64

Better Arm64 perf. Support macOS and Windows Arm64 (including x64 emulation) - native is best. Don't used emulation unless you need to. Arm64 and x64 need to install SxS.

### Profile-guided optimization

RyuJIT generates code in terms of types and codepaths actually observed

### OpenTelemetry

Improved support for OpenTelemetry.

### Crossgen2

New AOT code generator (Crossgen2) - precompiles apps to ready-to-run format

### NativeMemory APIs

NativeMemory APIs (simd)

### EventPipe


## C# 10 and templates

Modernized templates.

## Visual Basic 16.9


## Cloud diagnostics


## Workloads

Optional workloads for SDK components for iOS and Android, which are large.

## System.Text.Json APIs

STJ is now "industrial strength" - can ignore object cycles, streaming serialization with IAsyncEnumerable, efficient writeable DOM, serialization notifications, serialization property ordering, write "raw" JSON.

## HTTP/3


## ASP.NET Core

ASP.NET Core includes improvements in minimal APIs, ahead-of-time (AOT) compilation for Blazor WebAssembly apps, and single-page apps. In addition, Blazor components can now be rendered from JavaScript and integrated with existing JavaScript based apps. <!--For more information, see [What's new in ASP.NET Core 6](/aspnet/core/release-notes/aspnetcore-6.0).-->

## File I/O


## Security

Support for OpenSSL 3, support for new algorithms (e.g. Poly1305), support for W^X, preview of CET defense in depth mechanism (Windows only)

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

## Source build

Source build the .NET SDK.

## NuGet package validation


## Custom platform guards



- Support Apple Silicon for macOS and arm64 for Windows
- tfms
- CLI template search
- Preview features
  - static abstract interface members
- APIs
  - priorityqueue
  - Microsoft.Extensions
    - hosting
    - dependency injection
  - new LINQ APIs
  - DateOnly, TimeOnly, time zone improvements
  - WebSocket compression
  - Reflection APIs for nullability info

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
