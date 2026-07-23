---
title: What's new in .NET 11
description: Learn about the new features introduced in .NET 11 for the runtime, libraries, and SDK. Also find links to what's new in other areas, such as ASP.NET Core.
titleSuffix: ""
ms.date: 07/14/2026
ai-usage: ai-assisted
ms.update-cycle: 3650-days
---

# What's new in .NET 11

This article describes new features in .NET 11. It was last updated for Preview 6.

.NET 11 is currently in preview. The final release is expected in November 2026. You can [download .NET 11 here](https://dotnet.microsoft.com/download/dotnet/11.0).

## .NET runtime

The .NET 11 runtime includes:

- Updated minimum hardware requirements for x86/x64 and Arm64 architectures, requiring more modern instruction sets to improve performance and reduce maintenance complexity.
- Runtime-native async (Runtime Async), which produces cleaner stack traces and lower overhead. Runtime Async no longer requires `<EnablePreviewFeatures>true</EnablePreviewFeatures>` for projects that target `net11.0`. The runtime libraries themselves are compiled with `runtime-async=on`.
- Runtime Async performance improvements, including JIT compilation of a dedicated runtime-async version of synchronous task-returning methods, async continuations that opt out of `ExecutionContext` capture when no ambient state is in use, and tail-merged suspension points that reduce generated code size.
- JIT improvements for bounds check elimination, redundant checked context removal, switch expression folding, constant-folding `SequenceEqual`, and redundant branch elimination. There are also new Arm SVE2 intrinsics, improved hardware-intrinsic cost modeling, and a faster `Math.BigMul` on x64 that emits a single `MUL` instruction.
- In-process crash report logging on mobile platforms that captures the managed stack trace and runtime state before the process exits.
- NativeAOT faster interface dispatch using a shared dispatch helper, reducing binary size at call sites and improving throughput for interface-heavy workloads.
- SIMD lane construction and composition APIs (`CreateGeometricSequence`, `Zip`, `Unzip`, and the `Concat` family) across `Vector128<T>`, `Vector256<T>`, `Vector512<T>`, `Vector64<T>`, and `Vector<T>`.

For more information, see [What's new in the .NET 11 runtime](runtime.md).

## .NET libraries

The .NET 11 libraries include new APIs for:

- <xref:System.Diagnostics.Process> expansion with run-and-capture helpers, fire-and-forget launches, `SafeProcessHandle` lifecycle methods, tighter handle control, and new `ProcessStartInfo.StartSuspended` for suspended starts and `Process.TryGetProcessById` for safe process lookup.
- Compression, including improved Base64 APIs, new methods for ZIP archive entries, Zstandard compression in <xref:System.IO.Compression?displayProperty=fullName>, and CRC32 validation when reading ZIP entries.
- System.Text.Json improvements, including generic type info retrieval, <xref:System.Text.Json.JsonNamingPolicy.PascalCase?displayProperty=nameWithType>, per-member naming policy overrides, type-level ignore conditions, F# discriminated union support, <xref:System.Text.Json.Utf8JsonWriter.Reset*?displayProperty=nameWithType> with options, `SerializeAsyncEnumerable` overloads for `PipeWriter` targets and top-level values (NDJSON) output, and serialization of C# union types.
- Built-in OpenTelemetry metrics for <xref:Microsoft.Extensions.Caching.Memory.MemoryCache>.
- Discriminated-union scaffolding (`UnionAttribute` and `IUnion`) in <xref:System.Runtime.CompilerServices>.
- Tar archive format selection and GNU sparse format 1.0 support.
- `Console` support for the `FORCE_COLOR` environment variable.
- TLS handshake hardening and certificate-validation alerts on Linux.
- HTTP/2 automatic downgrade for Windows authentication.
- LINQ join improvements, including `FullJoin` and tuple-returning `Join` and `GroupJoin` overloads, across <xref:System.Linq.Enumerable>, <xref:System.Linq.Queryable>, and <xref:System.Linq.AsyncEnumerable>.
- A new <xref:System.Security.Cryptography.X25519DiffieHellman> class for X25519 key exchange.
- Generic overloads on <xref:System.Random> — `NextInteger<T>` and `NextBinaryFloat<T>` — that work with any numeric generic type.
- <xref:System.Collections.Generic.EqualityComparer`1.Create*?displayProperty=nameWithType> factory method that creates a comparer from a key selector.
- <xref:System.Net.Quic.QuicStream.Priority?displayProperty=nameWithType> for HTTP/3 stream prioritization.
- Video MIME type constants in <xref:System.Net.Mime.MediaTypeNames.Video>.
- Four new `Stream` types (`ReadOnlyMemoryStream`, `WritableMemoryStream`, `ReadOnlySequenceStream`, `StringStream`) that wrap in-memory data without copying.
- Asynchronous validation in `System.ComponentModel.DataAnnotations` via `AsyncValidationAttribute`, `IAsyncValidatableObject`, and new `Validator.ValidateObjectAsync` methods.
- Activity tracing configuration using rules in `Microsoft.Extensions.Diagnostics`, enabling declarative control of `Activity` tracing without wiring up `ActivityListener` instances manually.
- Cross-lane vector operations including `CreateGeometricSequence`, `Zip`, `Unzip`, and the `Concat` family on `Vector128<T>`, `Vector256<T>`, `Vector512<T>`, `Vector64<T>`, and `Vector<T>`.

For more information, see [What's new in the .NET 11 libraries](libraries.md).

## .NET SDK

The .NET 11 SDK includes:

- Smaller SDK installers on Linux and macOS through assembly deduplication, with additional savings by skipping crossgen for `DotnetTools`-only assemblies.
- Improved [CA1873](../../../fundamentals/code-analysis/quality-rules/ca1873.md) code analyzer with reduced noise and clearer diagnostic messages.
- Support for creating and editing solution filters (`.slnf`) from the `dotnet sln` CLI.
- File-based app support for `#:include` to split apps across multiple files, and `#:include ./libs/MyLib.dll` to include compiled DLL references directly.
- A new `dotnet run -e` option to pass environment variables from the command line.
- `dotnet watch` improvements, including Aspire app-host integration, automatic crash recovery, and device selection for MAUI and mobile projects.
- OpenTelemetry replaces Application Insights for CLI telemetry.
- NativeAOT CLI entry point that serves the full command surface—including `--help` for all built-in commands and tool/external-command launches—out-of-process from the AOT path, skipping managed CLI startup.
- `dotnet test` improvements, including `--no-dependencies`, `DOTNET_TEST_RUNNER` environment variable, `--use-current-runtime`, `--test-modules` exclusion patterns, per-assembly test counts, and live display of in-flight tests.
- Built-in test templates support xUnit v3 (defaulting to Microsoft.Testing.Platform) and NUnit with an opt-in `--test-runner` option.
- Multi-architecture container image builds with Podman using the SDK's container publishing support.
- TypeScript compilation outputs from Razor Class Libraries now integrate correctly with the Static Web Assets pipeline.
- The `dotnet` CLI no longer suppresses the MSBuild build server when `DOTNET_CLI_USE_MSBUILD_SERVER` is unset, and the OTLP telemetry exporter activates on any standard `OTEL_EXPORTER_OTLP_*` environment variable.

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
