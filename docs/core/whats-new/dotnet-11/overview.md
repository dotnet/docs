---
title: What's new in .NET 11
description: Learn about the new features introduced in .NET 11 for the runtime, libraries, and SDK. Also find links to what's new in other areas, such as ASP.NET Core.
titleSuffix: ""
ms.date: 05/12/2026
ai-usage: ai-assisted
ms.update-cycle: 3650-days
---

# What's new in .NET 11

This article describes new features in .NET 11. It was last updated for Preview 4.

.NET 11 is currently in preview. The final release is expected in November 2026. You can [download .NET 11 here](https://dotnet.microsoft.com/download/dotnet/11.0).

## .NET runtime

The .NET 11 runtime includes:

- Updated minimum hardware requirements for x86/x64 and Arm64 architectures, requiring more modern instruction sets to improve performance and reduce maintenance complexity.
- Runtime-native async (Runtime Async), which produces cleaner stack traces and lower overhead. Runtime Async no longer requires `<EnablePreviewFeatures>true</EnablePreviewFeatures>` for projects that target `net11.0`. The runtime libraries themselves are compiled with `runtime-async=on`.
- JIT improvements for bounds check elimination, redundant checked context removal, switch expression folding, constant-folding `SequenceEqual`, and redundant branch elimination. There are also new Arm SVE2 intrinsics and improved hardware-intrinsic cost modeling.

For more information, see [What's new in the .NET 11 runtime](runtime.md).

## .NET libraries

The .NET 11 libraries include new APIs for:

- <xref:System.Diagnostics.Process> expansion with run-and-capture helpers, fire-and-forget launches, `SafeProcessHandle` lifecycle methods, and tighter handle control.
- Compression, including improved Base64 APIs, new methods for ZIP archive entries, Zstandard compression in <xref:System.IO.Compression?displayProperty=fullName>, and CRC32 validation when reading ZIP entries.
- System.Text.Json improvements, including generic type info retrieval, <xref:System.Text.Json.JsonNamingPolicy.PascalCase?displayProperty=nameWithType>, per-member naming policy overrides, type-level ignore conditions, F# discriminated union support, and <xref:System.Text.Json.Utf8JsonWriter.Reset*?displayProperty=nameWithType> with options.
- Built-in OpenTelemetry metrics for <xref:Microsoft.Extensions.Caching.Memory.MemoryCache>.
- Discriminated-union scaffolding (`UnionAttribute` and `IUnion`) in <xref:System.Runtime.CompilerServices>.
- Tar archive format selection and GNU sparse format 1.0 support.
- `Console` support for the `FORCE_COLOR` environment variable.
- TLS handshake hardening and certificate-validation alerts on Linux.
- HTTP/2 automatic downgrade for Windows authentication.

For more information, see [What's new in the .NET 11 libraries](libraries.md).

## .NET SDK

The .NET 11 SDK includes:

- Smaller SDK installers on Linux and macOS through assembly deduplication, with additional savings by skipping crossgen for `DotnetTools`-only assemblies.
- Improved [CA1873](../../../fundamentals/code-analysis/quality-rules/ca1873.md) code analyzer with reduced noise and clearer diagnostic messages.
- Support for creating and editing solution filters (`.slnf`) from the `dotnet sln` CLI.
- File-based app support for `#:include` to split apps across multiple files.
- A new `dotnet run -e` option to pass environment variables from the command line.
- `dotnet watch` improvements, including Aspire app-host integration, automatic crash recovery, and device selection for MAUI and mobile projects.
- OpenTelemetry replaces Application Insights for CLI telemetry.
- Foundation for a NativeAOT entry point for the `dotnet` CLI.

For more information, see [What's new in the SDK for .NET 11](sdk.md).

## ASP.NET Core

For information about what's new in ASP.NET Core, see [What's new in ASP.NET Core for .NET 11](/aspnet/core/release-notes/aspnetcore-11).

## C# 15

C# 15 includes these features:

- [Collection expression arguments](../../../csharp/whats-new/csharp-15.md#collection-expression-arguments)
- [Union types](../../../csharp/whats-new/csharp-15.md#union-types)

For information about new C# features, see [What's new in C# 15](../../../csharp/whats-new/csharp-15.md).

## EF Core

See [What's new in EF Core for .NET 11](/ef/core/what-is-new/ef-core-11.0/whatsnew).

## Extensions libraries

See [dotnet/extensions release notes](https://github.com/dotnet/extensions/releases).

## Windows Forms

See [What's new in Windows Forms for .NET 11](/dotnet/desktop/winforms/whats-new/net110).

## WPF

See [What's new in WPF in .NET 11](/dotnet/desktop/wpf/whats-new/net110).

## See also

- [What's new in .NET 10](../dotnet-10/overview.md)
