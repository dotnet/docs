---
title: What's new in .NET libraries for .NET 11
description: Learn about the updates to the .NET libraries for .NET 11.
titleSuffix: ""
ms.date: 05/12/2026
ai-usage: ai-assisted
ms.update-cycle: 3650-days
---

# What's new in .NET libraries for .NET 11

This article describes new features in the .NET libraries for .NET 11. It was last updated for Preview 4.

## Process API expansion

<xref:System.Diagnostics.Process> has a substantial set of new APIs that cover common scenarios where you previously had to wire up `OutputDataReceived`/`ErrorDataReceived` events manually or use P/Invoke.

### Run-and-capture helpers

New one-shot APIs let you launch a process and get its result without manual setup:

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="ProcessRunAndCapture":::

The full set of helpers includes:

- `Process.Run` and `Process.RunAsync` — launch a process and return an exit-status result.
- `Process.RunAndCaptureText` and `Process.RunAndCaptureTextAsync` — launch and capture stdout/stderr together with exit code.
- `Process.ReadAllText`, `Process.ReadAllBytes`, and their async variants — read a child process's standard output in a single call.
- `Process.ReadAllLinesAsync` — returns a stream of `ProcessOutputLine` values that distinguish stdout from stderr without string parsing.

### Fire-and-forget launches

- `Process.StartAndForget` — starts a child process when you don't intend to wait for it; the runtime detaches the handle automatically.
- `ProcessStartInfo.StartDetached` — detaches from the parent's session/console so the child can outlive a terminal exit.
- `ProcessStartInfo.KillOnParentExit` (Windows only) — the child is terminated when the parent process exits.

### SafeProcessHandle lifecycle methods

<xref:Microsoft.Win32.SafeHandles.SafeProcessHandle> gains lifecycle methods for advanced scenarios:

- `SafeProcessHandle.Start` and a new `ProcessId` property — launch and identify processes without going through `Process` itself.
- `SafeProcessHandle.Kill` and `SafeProcessHandle.Signal` — terminate or signal a process by handle.
- `SafeProcessHandle.WaitForExit` and `SafeProcessHandle.WaitForExitAsync` — wait for a process to exit by handle.

### Tighter handle control

- `ProcessStartInfo.InheritedHandles` — specify exactly which OS handles a child process inherits, instead of using the all-or-nothing `UseShellExecute = false` default.
- `ProcessStartInfo.StandardInputHandle`, `StandardOutputHandle`, and `StandardErrorHandle` — supply already-open `SafeFileHandle` values for redirection without the framework opening new ones.

## String and character enhancements

.NET 11 introduces significant enhancements to string and character manipulation APIs, making it easier to work with Unicode characters and runes.

### Rune support in String methods

The <xref:System.String> class now includes methods that accept <xref:System.Text.Rune> parameters, enabling you to search, replace, and manipulate strings using Unicode scalar values directly. These new methods include:

- `Contains` - Check if a string contains a specific rune: <xref:System.String.Contains(System.Text.Rune)?displayProperty=nameWithType> and <xref:System.String.Contains(System.Text.Rune,System.StringComparison)?displayProperty=nameWithType>.
- `StartsWith` and `EndsWith` - Check if a string starts or ends with a specific rune: <xref:System.String.StartsWith(System.Text.Rune)?displayProperty=nameWithType>, <xref:System.String.StartsWith(System.Text.Rune,System.StringComparison)?displayProperty=nameWithType>, <xref:System.String.EndsWith(System.Text.Rune)?displayProperty=nameWithType>, and <xref:System.String.EndsWith(System.Text.Rune,System.StringComparison)?displayProperty=nameWithType>.
- `IndexOf` and `LastIndexOf` - Find the position of a rune in a string: <xref:System.String.IndexOf(System.Text.Rune)?displayProperty=nameWithType>, <xref:System.String.IndexOf(System.Text.Rune,System.StringComparison)?displayProperty=nameWithType>, <xref:System.String.LastIndexOf(System.Text.Rune)?displayProperty=nameWithType>, and <xref:System.String.LastIndexOf(System.Text.Rune,System.StringComparison)?displayProperty=nameWithType>.
- `Replace` - Replace occurrences of one rune with another: <xref:System.String.Replace(System.Text.Rune,System.Text.Rune)?displayProperty=nameWithType>.
- `Split` - Split a string using a rune as the separator: <xref:System.String.Split(System.Text.Rune,System.StringSplitOptions)?displayProperty=nameWithType> and <xref:System.String.Split(System.Text.Rune,System.Int32,System.StringSplitOptions)?displayProperty=nameWithType>.
- `Trim`, `TrimStart`, and `TrimEnd` - Trim runes from strings: <xref:System.String.Trim(System.Text.Rune)?displayProperty=nameWithType>, <xref:System.String.TrimStart(System.Text.Rune)?displayProperty=nameWithType>, and <xref:System.String.TrimEnd(System.Text.Rune)?displayProperty=nameWithType>.

Many of these methods include overloads that accept a <xref:System.StringComparison> parameter for culture-aware comparisons.

### Char.Equals with StringComparison

The <xref:System.Char> struct now includes an <xref:System.Char.Equals(System.Char,System.StringComparison)?displayProperty=nameWithType> method that accepts a <xref:System.StringComparison> parameter, allowing you to compare characters using culture-aware or ordinal comparisons.

### Rune support in TextInfo

The <xref:System.Globalization.TextInfo> class now provides <xref:System.Globalization.TextInfo.ToLower(System.Text.Rune)?displayProperty=nameWithType> and <xref:System.Globalization.TextInfo.ToUpper(System.Text.Rune)?displayProperty=nameWithType> methods that accept <xref:System.Text.Rune> parameters, enabling you to perform case conversions on individual Unicode scalar values.

## Base64 encoding improvements

.NET 11 adds new APIs and overloads to the existing <xref:System.Buffers.Text.Base64> type, providing comprehensive support for Base64 encoding and decoding. These additions offer improved performance and flexibility compared to existing methods.

### New Base64 APIs

The new APIs support encoding and decoding operations with various input and output formats:

- **Encoding to chars**: <xref:System.Buffers.Text.Base64.EncodeToChars*> and <xref:System.Buffers.Text.Base64.EncodeToString*>
- **Encoding to UTF-8**: <xref:System.Buffers.Text.Base64.EncodeToUtf8*>
- **Decoding from chars**: <xref:System.Buffers.Text.Base64.DecodeFromChars*>
- **Decoding from UTF-8**: <xref:System.Buffers.Text.Base64.DecodeFromUtf8*>

These methods provide both high-level convenience methods (that allocate and return arrays or strings) and low-level span-based methods (for zero-allocation scenarios).

## Compression enhancements

.NET 11 includes several improvements to compression APIs.

### ZIP archive entry access modes

The <xref:System.IO.Compression.ZipArchiveEntry> class now supports opening entries with specific file access modes through new overloads: <xref:System.IO.Compression.ZipArchiveEntry.Open(System.IO.FileAccess)?displayProperty=nameWithType> and <xref:System.IO.Compression.ZipArchiveEntry.OpenAsync(System.IO.FileAccess,System.Threading.CancellationToken)?displayProperty=nameWithType>. These overloads accept a <xref:System.IO.FileAccess> parameter and allow you to open ZIP entries for read, write, or read-write access.

Additionally, a new <xref:System.IO.Compression.ZipArchiveEntry.CompressionMethod> property exposes the compression method used for an entry through the <xref:System.IO.Compression.ZipCompressionMethod> enum, which includes values for <xref:System.IO.Compression.ZipCompressionMethod.Stored>, <xref:System.IO.Compression.ZipCompressionMethod.Deflate>, and <xref:System.IO.Compression.ZipCompressionMethod.Deflate64>.

### ZIP CRC32 validation

Starting in Preview 3, <xref:System.IO.Compression.ZipArchive> validates the CRC32 checksum when reading ZIP entries. Corrupted or truncated archives that previously passed without error now throw <xref:System.IO.InvalidDataException>, helping you detect data integrity issues early.

### DeflateStream and GZipStream behavior change

Starting in .NET 11, <xref:System.IO.Compression.DeflateStream> and <xref:System.IO.Compression.GZipStream> always write format headers and footers to the output stream, even when no data is written. This ensures the output is a valid compressed stream according to the Deflate and GZip specifications.

Previously, these streams didn't produce any output if no data was written, resulting in an empty output stream. This change ensures compatibility with tools that expect properly formatted compressed streams.

For more information, see [DeflateStream and GZipStream write headers and footers for empty payload](../../compatibility/core-libraries/11/deflatestream-gzipstream-empty-payload.md).

### Span-based Deflate, ZLib, and GZip APIs

<xref:System.IO.Compression> now offers `Span<byte>`/`ReadOnlySpan<byte>` encode and decode entry points for the Deflate, ZLib, and GZip formats. The new APIs mirror the shape of `BrotliEncoder`/`BrotliDecoder` and the Zstandard primitives, so you can compress and decompress buffers without allocating a `Stream`. This is useful for high-throughput scenarios such as protocol parsers, log shippers, and middleware that already operate on spans.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="ZLibEncoderSpan":::

## BFloat16 support in BitConverter

The <xref:System.BitConverter> class now includes methods for converting between <xref:System.Numerics.BFloat16> values and byte arrays or bit representations. These new methods include:

- <xref:System.BitConverter.GetBytes(System.Numerics.BFloat16)?displayProperty=nameWithType> - Convert a BFloat16 value to a byte array.
- <xref:System.BitConverter.ToBFloat16(System.Byte[],System.Int32)?displayProperty=nameWithType> and <xref:System.BitConverter.ToBFloat16(System.ReadOnlySpan{System.Byte})?displayProperty=nameWithType> - Convert a byte array to a BFloat16 value.
- <xref:System.BitConverter.BFloat16ToInt16Bits(System.Numerics.BFloat16)?displayProperty=nameWithType>, <xref:System.BitConverter.BFloat16ToUInt16Bits(System.Numerics.BFloat16)?displayProperty=nameWithType>, <xref:System.BitConverter.Int16BitsToBFloat16(System.Int16)?displayProperty=nameWithType>, and <xref:System.BitConverter.UInt16BitsToBFloat16(System.UInt16)?displayProperty=nameWithType> - Methods for converting between BFloat16 and its bit representation as `short` or `ushort`.

BFloat16 (Brain Floating Point) is a 16-bit floating-point format that's commonly used in machine learning and scientific computing.

## Floating-point hex formatting and parsing

`double`, `float`, and `Half` can now be formatted and parsed in their hexadecimal IEEE-754 form. The hex form preserves every bit of the underlying value, making it the right choice for golden-file tests, cross-language interop with C/C++ `printf("%a", ...)`, and any scenario where round-tripping a `double` through decimal text is too lossy.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="FloatingPointHex":::

## UTF validation and invalid-subsequence search

<xref:System.Text.Unicode?displayProperty=fullName> has two new complementary features. `Utf16.IsValid` answers whether a sequence is well-formed UTF-16 without scanning twice, and `Utf8.IndexOfInvalidSubsequence` / `Utf16.IndexOfInvalidSubsequence` return the position of the first ill-formed code-unit sequence (or `-1` for valid input). Together, these methods let parsers, validators, and serializers report precise errors instead of generic encoding-error messages.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="UtfValidation":::

## Collections improvements

### BitArray.PopCount

The <xref:System.Collections.BitArray> class now includes a <xref:System.Collections.BitArray.PopCount?displayProperty=nameWithType> method that returns the number of bits set to `true` in the array. This provides an efficient way to count set bits without manually iterating through the array.

### IReadOnlySet support in JSON serialization

The <xref:System.Text.Json.Serialization.Metadata.JsonMetadataServices> class now includes a <xref:System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreateIReadOnlySetInfo*?displayProperty=nameWithType> method, enabling JSON serialization support for <xref:System.Collections.Generic.IReadOnlySet`1> collections.

## URI data scheme constant

A new <xref:System.Uri.UriSchemeData?displayProperty=nameWithType> constant has been added, representing the `data:` URI scheme. This constant provides a standardized way to reference data URIs.

## StringSyntax attribute enhancements

The <xref:System.Diagnostics.CodeAnalysis.StringSyntaxAttribute> class now includes constants for common programming languages:

- <xref:System.Diagnostics.CodeAnalysis.StringSyntaxAttribute.CSharp> - Indicates C# syntax.
- <xref:System.Diagnostics.CodeAnalysis.StringSyntaxAttribute.FSharp> - Indicates F# syntax.
- <xref:System.Diagnostics.CodeAnalysis.StringSyntaxAttribute.VisualBasic> - Indicates Visual Basic syntax.

These constants can be used with the `StringSyntax` attribute to provide better tooling support for string literals containing code in these languages.

## System.Text.Json improvements

### Generic type info retrieval

A common pattern when working with `System.Text.Json` type metadata is to retrieve a <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo`1> from <xref:System.Text.Json.JsonSerializerOptions>.
Previously, you had to manually downcast from the non-generic <xref:System.Text.Json.JsonSerializerOptions.GetTypeInfo(System.Type)> method.
New generic <xref:System.Text.Json.JsonSerializerOptions.GetTypeInfo``1?displayProperty=nameWithType> and <xref:System.Text.Json.JsonSerializerOptions.TryGetTypeInfo``1(System.Text.Json.Serialization.Metadata.JsonTypeInfo{``0}@)?displayProperty=nameWithType> methods return strongly typed metadata directly, eliminating the cast.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="JsonTypeInfoGeneric":::

This is particularly useful when working with source generation, NativeAOT, and polymorphic serialization scenarios where type metadata access is common.

### Naming and ignore defaults

Preview 3 expands the naming and ignore options available in `System.Text.Json`:

- **`JsonNamingPolicy.PascalCase`**: A new built-in naming policy that converts property names to PascalCase. It joins the existing camelCase, snake_case, and kebab-case policies.
- **Per-member naming policy**: The new `[JsonNamingPolicy]` attribute lets you override the naming policy on individual properties or fields, giving you fine-grained control without a custom converter.
- **Type-level ignore conditions**: Applying `[JsonIgnore(Condition = ...)]` at the class or struct level sets the default ignore behavior for all members, so you no longer need to repeat the attribute on every nullable property.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="JsonNamingIgnore":::

### F# discriminated union support

The serializer now understands F# discriminated unions out of the box. Apps that share types between F# producers and C# consumers no longer need a custom converter for the most common shapes:

```fsharp
type Shape =
    | Circle of radius: float
    | Square of side: float

let json = System.Text.Json.JsonSerializer.Serialize(Circle 1.5)
// {"$type":"Circle","radius":1.5}
```

### Utf8JsonWriter.Reset with options

<xref:System.Text.Json.Utf8JsonWriter.Reset*> now accepts a <xref:System.Text.Json.JsonWriterOptions> parameter, so writer instances can be repooled with different options without allocating a new writer:

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="Utf8JsonWriterReset":::

## Zstandard compression

The Zstandard compression APIs are now part of the <xref:System.IO.Compression?displayProperty=fullName> namespace, alongside `DeflateStream`, `GZipStream`, and `BrotliStream`. If you referenced the earlier preview package, remove the separate package reference:

```diff
-<PackageReference Include="System.IO.Compression.Zstandard" />
```

The API surface is otherwise unchanged.

## Tar archive format selection

New overloads on <xref:System.Formats.Tar.TarFile.CreateFromDirectory*> and <xref:System.Formats.Tar.TarFile.CreateFromDirectoryAsync*> accept a <xref:System.Formats.Tar.TarEntryFormat> parameter, giving you direct control over the archive format. Previously, `CreateFromDirectory` always produced Pax archives. The new overloads support all four tar formats—Pax, Ustar, GNU, and V7—for compatibility with specific tools and environments.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="TarArchiveFormat":::

`TarReader` can now also read entries that use the GNU sparse format 1.0 (PAX) representation. The earlier 0.1 representation was already supported. With 1.0 support in place, `TarReader` matches what modern `tar` implementations write by default for sparse files.

## Numerics improvements

### Matrix4x4 performance

<xref:System.Numerics.Matrix4x4.GetDeterminant?displayProperty=nameWithType> now uses an SSE-vectorized implementation, improving performance by approximately 15%.

## Low-level I/O improvements

### SafeFileHandle pipe support

<xref:Microsoft.Win32.SafeHandles.SafeFileHandle> gains two new members:

- **`Type` property:** Reports whether a handle represents a file, pipe, socket, directory, or other OS object, without requiring platform-specific code.
- **`CreateAnonymousPipe` method:** Creates a pair of connected anonymous pipe handles with independent async behavior for each end.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="SafeFileHandlePipe":::

### RandomAccess pipe support

<xref:System.IO.RandomAccess.Read*?displayProperty=nameWithType> and <xref:System.IO.RandomAccess.Write*?displayProperty=nameWithType> now work with non-seekable handles such as pipes, in addition to regular file handles.

On Windows, `Process` now uses overlapped I/O for redirected stdout/stderr, which reduces thread-pool blocking in process-heavy applications.

## Regular expression improvements

### AnyNewLine option

A new <xref:System.Text.RegularExpressions.RegexOptions> flag, `AnyNewLine`, makes `^`, `$`, and `.` treat the full set of Unicode newline characters as line terminators—not just `\n`. This helps when parsing text that mixes Windows (`\r\n`), Unix (`\n`), and Unicode-specific (`\u0085`, `\u2028`, `\u2029`) line endings.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="RegexAnyNewLine":::

### Regex engine and source generator fixes

.NET 11 includes several regex correctness and code-quality fixes:

- The non-backtracking engine no longer takes super-linear time on certain nested-loop patterns and produces correct results for cases that previously diverged.
- The regex compiler and source generator handle `resumeAt` correctly when a conditional appears inside a loop body.
- The [SYSLIB1045](../../../fundamentals/syslib-diagnostics/syslib1040-1049.md) code fixer no longer creates duplicate class names when applied across multiple partial declarations of the same class.

## Rate-limiting improvements

The <xref:System.Threading.RateLimiting?displayProperty=fullName> class has a handful of fixes in .NET 11:

- <xref:System.Threading.RateLimiting.FixedWindowRateLimiter> now reports a `RetryAfter` metadata value that points to the next window boundary, so callers and middleware can honor it without guessing.
- `TokenBucketRateLimiter.AttemptAcquire(0)` no longer mishandles partial token refills.
- `ChainedRateLimiter` now correctly forwards `IdleDuration` and replenishment behavior from its inner limiters.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="RateLimitingRetryAfter":::

## Configuration binding

<xref:Microsoft.Extensions.Configuration?displayProperty=fullName> adds `ConfigurationIgnoreAttribute`, so models can opt individual properties out of binding declaratively without relying on `BindNonPublicProperties` toggles or custom converters:

```csharp
public sealed class AppOptions
{
    public string Endpoint { get; set; } = "";

    [ConfigurationIgnore]
    public string ComputedKey => Endpoint + ":default";
}
```

`ConfigurationBinder` now also binds an empty array to a constructor parameter instead of throwing.

`PhysicalFilesWatcher` no longer throws when its root directory doesn't yet exist, and `InMemoryDirectoryInfo` resolves `..` and other relative segments consistently with the physical provider.

## MemoryCache OpenTelemetry metrics

<xref:Microsoft.Extensions.Caching.Memory.MemoryCache> now emits a built-in set of OpenTelemetry (OTel)-compatible metrics without an extra adapter package. To opt in, set `TrackStatistics = true`:

```csharp
var cache = new MemoryCache(new MemoryCacheOptions
{
    TrackStatistics = true
});
```

The new `Microsoft.Extensions.Caching.Memory.MemoryCache` meter publishes four observable instruments:

- `dotnet.cache.requests` (with a `dotnet.cache.request.type` tag that distinguishes `hit` from `miss`)
- `dotnet.cache.evictions`
- `dotnet.cache.entries`
- `dotnet.cache.estimated_size`

Pass an `IMeterFactory` to the new `MemoryCache(options, loggerFactory, meterFactory)` constructor overload for per-instance metrics. Without one, the instruments are aggregated process-wide on a shared meter.

## Discriminated-union scaffolding

> [!NOTE]
> This is a preview feature in .NET 11.

.NET 11 introduces `UnionAttribute` and `IUnion` in `System.Runtime.CompilerServices`. These types are the runtime side of the C# discriminated-union design. They aren't directly user-facing yet—the C# compiler and source generators are the expected producers—but they ship in the framework so libraries can author against the surface now.

For the language-side design, see the [C# unions proposal](https://github.com/dotnet/csharplang/blob/main/proposals/unions.md).

## MetadataLoadContext additions

<xref:System.Reflection.MetadataLoadContext.GetLoadContext(System.Reflection.Assembly)?displayProperty=nameWithType> returns the load context that produced a given `Assembly`, mirroring the long-existing API on <xref:System.Runtime.Loader.AssemblyLoadContext>. This closes a gap for tooling that reflects over assemblies in an isolated `MetadataLoadContext` and needs to walk back from an `Assembly` reference to the context that owns it:

```csharp
using System.Reflection;
using System.Reflection.Metadata;

string[] paths = [typeof(object).Assembly.Location];
using var mlc = new MetadataLoadContext(new PathAssemblyResolver(paths));
Assembly asm = mlc.LoadFromAssemblyPath(typeof(object).Assembly.Location);

MetadataLoadContext owner = MetadataLoadContext.GetLoadContext(asm)!;
Console.WriteLine(ReferenceEquals(owner, mlc)); // true
```

## Console FORCE_COLOR support

.NET console output now honors the [`FORCE_COLOR`](https://force-color.org/) standard alongside the existing `NO_COLOR` support. When `FORCE_COLOR` is set, `Console.IsOutputRedirected` no longer suppresses ANSI escape codes. This is useful when you pipe `dotnet run` output through `tee`, into a CI log viewer, or through `less -R`:

```bash
FORCE_COLOR=1 dotnet run | tee build.log
```

## TLS handshake hardening

Two <xref:System.Net.Security?displayProperty=fullName> items improve TLS (Transport Layer Security) reliability:

- `SslStream` server-side handshake bounds-checking fixes in `TlsFrameHelper` close several edge cases that could surface as `IOException` on malformed ClientHello records.
- On Linux, certificate-validation failures now surface as standard TLS alerts to the peer, matching Windows behavior. Connecting clients receive an actionable handshake error instead of a connection drop.

## HTTP/2 automatic downgrade for Windows authentication

<xref:System.Net.Http.HttpClient> automatically downgrades to HTTP/1.1 when a request requires Windows authentication (NTLM/Negotiate) over HTTP/2. The HTTP/2 specification disallows the connection-bound authentication schemes that NTLM and Kerberos rely on, so these requests previously failed. With the downgrade in place, applications targeting mixed-authentication environments—common in enterprise intranets—work without explicit `HttpRequestMessage.Version` overrides.

## See also

- [What's new in the .NET 11 runtime](runtime.md)
- [What's new in the SDK for .NET 11](sdk.md)
- [Breaking changes in .NET 11](../../compatibility/11.md)
