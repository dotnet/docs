---
title: What's new in .NET 11
description: Learn about the new features introduced in .NET 11 for the runtime, libraries, and SDK. Also find links to what's new in other areas, such as ASP.NET Core.
titleSuffix: ""
ms.date: 09/08/2026
ai-usage: ai-assisted
ms.update-cycle: 3650-days
---

# What's new in .NET 11

This article describes new features in .NET 11. It was last updated for release candidate 1 (RC 1).

.NET 11 is currently in release candidate. General availability is expected in November 2026. You can [download .NET 11 here](https://dotnet.microsoft.com/download/dotnet/11.0).

## .NET runtime

The .NET 11 runtime includes:

- Updated minimum hardware requirements for x86/x64 and Arm64 architectures, requiring more modern instruction sets to improve performance and reduce maintenance complexity.
- Runtime-native async (Runtime Async), which produces cleaner stack traces and lower overhead. Runtime Async no longer requires `<EnablePreviewFeatures>true</EnablePreviewFeatures>` for projects that target `net11.0`. The runtime libraries themselves are compiled with `runtime-async=on`.
- Runtime Async performance improvements, including JIT compilation of a dedicated runtime-async version of synchronous task-returning methods, async continuations that opt out of `ExecutionContext` capture when no ambient state is in use, and tail-merged suspension points that reduce generated code size.
- Runtime Async tiered compilation, task and value-task factory intrinsics, and implicit tailcall improvements that reduce warm-up allocations and speed up common `await` paths.
- JIT improvements for bounds check elimination, redundant checked context removal, devirtualization, switch expression folding, constant-folding `SequenceEqual`, and redundant branch elimination. There are also new Arm SVE2 intrinsics, improved hardware-intrinsic cost modeling, and a faster `Math.BigMul` on x64 that emits a single `MUL` instruction.
- CoreCLR on WebAssembly now runs the libraries test suite end to end, and the runtime adds AVX-VNNI-512 hardware intrinsics for vectorized multiply-add workloads.
- In-process crash report logging that captures the managed stack trace and runtime state before the process exits, available on mobile platforms as well as Linux and macOS.
- NativeAOT faster interface dispatch using a shared dispatch helper, reducing binary size at call sites and improving throughput for interface-heavy workloads.
- SIMD lane construction and composition APIs (`CreateGeometricSequence`, `Zip`, `Unzip`, and the `Concat` family) across `Vector128<T>`, `Vector256<T>`, `Vector512<T>`, `Vector64<T>`, and `Vector<T>`.
- Hardware FP16 instructions for `Half` arithmetic and conversions on x64 and Arm64.

For more information, see [What's new in the .NET 11 runtime](runtime.md).

## .NET libraries

The .NET 11 libraries include new APIs for:

- <xref:System.Diagnostics.Process> expansion with run-and-capture helpers, fire-and-forget launches, <xref:Microsoft.Win32.SafeHandles.SafeProcessHandle> lifecycle methods, tighter handle control, new <xref:System.Diagnostics.ProcessStartInfo.StartSuspended?displayProperty=nameWithType> for suspended starts, <xref:System.Diagnostics.Process.TryGetProcessById(System.Int32,System.Diagnostics.Process@)?displayProperty=nameWithType> for safe process lookup, and <xref:System.Diagnostics.Process.Signal(System.Runtime.InteropServices.PosixSignal)?displayProperty=nameWithType> with <xref:System.Diagnostics.ProcessExitStatus> for signaling processes and inspecting how they exited.
- Compression, including improved Base64 APIs, new methods for ZIP archive entries, Zstandard compression in <xref:System.IO.Compression?displayProperty=fullName>, CRC32 validation when reading ZIP entries, and a `Reset()` method on the streamless Deflate, ZLib, and GZip encoders and decoders.
- New numeric APIs, including IEEE 754 decimal floating-point types (<xref:System.Numerics.Decimal32>, <xref:System.Numerics.Decimal64>, and <xref:System.Numerics.Decimal128>), <xref:System.Numerics.INumberBase`1.TryParsePartial*?displayProperty=nameWithType> for delimiter-aware parsing, and generic <xref:System.Numerics.Complex`1>.
- System.Text.Json improvements, including generic type info retrieval, <xref:System.Text.Json.JsonNamingPolicy.PascalCase?displayProperty=nameWithType>, per-member naming policy overrides, type-level ignore conditions, F# discriminated union support, <xref:System.Text.Json.Utf8JsonWriter.Reset*?displayProperty=nameWithType> with options, `SerializeAsyncEnumerable` overloads for `PipeWriter` targets and top-level values (NDJSON) output, serialization of C# union types with the new `JsonUnionTypeStructuralClassifier`, built-in converters for `BFloat16` and the new decimal floating-point types, and base64 schema metadata from `JsonSchemaExporter`.
- Built-in OpenTelemetry metrics for <xref:Microsoft.Extensions.Caching.Memory.MemoryCache>.
- Discriminated-union scaffolding (`UnionAttribute` and `IUnion`) in <xref:System.Runtime.CompilerServices>.
- Tar archive format selection and GNU sparse format 1.0 support.
- `Console` support for the `FORCE_COLOR` environment variable.
- TLS handshake hardening, certificate-validation alerts on Linux, channel binding validation on Unix, and an experimental caller-driven TLS session API (`TlsBufferSession` and `TlsSocketSession`).
- Networking additions, including HTTP request-body compression wrappers, configurable HTTP connection eviction, and typed DNS record resolution APIs on Windows, Linux, and macOS through <xref:System.Net.Dns> and the new <xref:System.Net.DnsResolver> class.
- HTTP/2 automatic downgrade for Windows authentication.
- LINQ join improvements, including `FullJoin` and tuple-returning `Join` and `GroupJoin` overloads, across <xref:System.Linq.Enumerable>, <xref:System.Linq.Queryable>, and <xref:System.Linq.AsyncEnumerable>.
- A new <xref:System.Security.Cryptography.X25519DiffieHellman> class for X25519 key exchange, and unpadded AES Key Wrap support (`EncryptKeyWrap`/`DecryptKeyWrap`) on <xref:System.Security.Cryptography.Aes>.
- Generic overloads on <xref:System.Random> — `NextInteger<T>` and `NextBinaryFloat<T>` — that work with any numeric generic type.
- <xref:System.Collections.Generic.EqualityComparer`1.Create*?displayProperty=nameWithType> factory method that creates a comparer from a key selector.
- <xref:System.Net.Quic.QuicStream.Priority?displayProperty=nameWithType> for HTTP/3 stream prioritization.
- Video MIME type constants in <xref:System.Net.Mime.MediaTypeNames.Video>.
- Four new `Stream` types (`ReadOnlyMemoryStream`, `WritableMemoryStream`, `ReadOnlySequenceStream`, `StringStream`) that wrap in-memory data without copying.
- <xref:System.Collections.BitArray> constructors that accept `ReadOnlySpan<bool>`, `ReadOnlySpan<byte>`, and `ReadOnlySpan<int>`.
- Asynchronous validation in `System.ComponentModel.DataAnnotations` via `AsyncValidationAttribute`, `IAsyncValidatableObject`, and new `Validator.ValidateObjectAsync` methods, along with asynchronous `Microsoft.Extensions.Options` validation through `IAsyncStartupValidator`.
- Activity tracing configuration using rules in `Microsoft.Extensions.Diagnostics`, enabling declarative control of `Activity` tracing without wiring up `ActivityListener` instances manually.
- Cross-lane vector operations including `CreateGeometricSequence`, `Zip`, `Unzip`, and the `Concat` family on `Vector128<T>`, `Vector256<T>`, `Vector512<T>`, `Vector64<T>`, and `Vector<T>`.

For more information, see [What's new in the .NET 11 libraries](libraries.md).

## .NET SDK

The .NET 11 SDK includes:

- Smaller SDK installers on Linux and macOS through assembly deduplication, with additional savings by skipping crossgen for `DotnetTools`-only assemblies.
- Improved [CA1873](../../../fundamentals/code-analysis/quality-rules/ca1873.md) code analyzer with reduced noise and clearer diagnostic messages.
- Support for creating and editing solution filters (`.slnf`) from the `dotnet sln` CLI.
- File-based app support for `#:include` to split apps across multiple files and to include compiled DLL references directly, plus Native AOT build-output reuse and `dotnet format` support for file-based programs.
- A new `dotnet run -e` option to pass environment variables from the command line.
- `dotnet watch` improvements, including Aspire app-host integration, automatic crash recovery, and device selection for MAUI and mobile projects.
- OpenTelemetry replaces Application Insights for CLI telemetry.
- NativeAOT CLI entry point that serves the full command surface—including `--help` for all built-in commands and tool/external-command launches—out-of-process from the AOT path, skipping managed CLI startup.
- NativeAOT CLI and the MSBuild server are now enabled by default.
- `dotnet test` improvements, including `--no-dependencies`, `DOTNET_TEST_RUNNER` environment variable, `--use-current-runtime`, `--test-modules` exclusion patterns, per-assembly test counts, and live display of in-flight tests.
- `dotnet test` support for Android, iOS, macOS, and Mac Catalyst test projects, with device selection and new `androidtest`, `iostest`, `macostest`, and `maccatalysttest` templates.
- Additional `dotnet test` run-level options, including `--timeout`, `--maximum-failed-tests`, `--results-directory-layout per-module`, and an experimental affected-test workflow, along with traversal-project support, JSON output for `--list-tests`, and artifact post-processing for multi-module runs.
- Built-in test templates support xUnit v3 (defaulting to Microsoft.Testing.Platform) and NUnit with an opt-in `--test-runner` option.
- Multi-architecture container image builds with Podman using the SDK's container publishing support.
- Container publishing now prefers platform-native local runtimes (`wslc` on Windows and `container` on macOS) before Docker and Podman, produces reproducible image digests through `SOURCE_DATE_EPOCH`, and skips redundant layer uploads when the target manifest already exists.
- TypeScript compilation outputs from Razor Class Libraries now integrate correctly with the Static Web Assets pipeline.
- `dotnet format` limits `.editorconfig` discovery in folder mode to the ancestor directories of included files.
- The `dotnet` CLI no longer suppresses the MSBuild build server when `DOTNET_CLI_USE_MSBUILD_SERVER` is unset, and the OTLP telemetry exporter activates on any standard `OTEL_EXPORTER_OTLP_*` environment variable.

For more information, see [What's new in the SDK for .NET 11](sdk.md).

## ASP.NET Core

For information about what's new in ASP.NET Core, see [What's new in ASP.NET Core for .NET 11](/aspnet/core/release-notes/aspnetcore-11).

## C# 15

C# 15 is the default language version for projects that target .NET 11 and includes these features:

- [Collection expression arguments](../../../csharp/whats-new/csharp-15.md#collection-expression-arguments)
- [Union types](../../../csharp/whats-new/csharp-15.md#union-types)
- [Closed hierarchies](../../../csharp/whats-new/csharp-15.md#closed-hierarchies)
- [Extension indexers](../../../csharp/whats-new/csharp-15.md#extension-indexers)
- [Labeled `break` and `continue`](../../../csharp/whats-new/csharp-15.md#labeled-break-and-continue)
- [Memory safety](../../../csharp/whats-new/csharp-15.md#memory-safety)

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
