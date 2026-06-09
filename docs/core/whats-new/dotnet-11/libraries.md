---
title: What's new in .NET libraries for .NET 11
description: Learn about the updates to the .NET libraries for .NET 11.
titleSuffix: ""
ms.date: 06/09/2026
ai-usage: ai-assisted
ms.update-cycle: 3650-days
---

# What's new in .NET libraries for .NET 11

This article describes new features in the .NET libraries for .NET 11. It was last updated for Preview 5.

## Diagnostics and process execution

- [Process API expansion](#process-api-expansion)
- [Console FORCE_COLOR support](#console-force_color-support)

### Process API expansion

<xref:System.Diagnostics.Process> has a substantial set of new APIs that cover common scenarios where you previously had to wire up <xref:System.Diagnostics.Process.OutputDataReceived>/<xref:System.Diagnostics.Process.ErrorDataReceived> events manually or use P/Invoke.

#### Run-and-capture helpers

New one-shot APIs let you launch a process and get its result without manual setup:

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="ProcessRunAndCapture":::

The full set of helpers includes:

- <xref:System.Diagnostics.Process.Run*?displayProperty=nameWithType> and <xref:System.Diagnostics.Process.RunAsync*?displayProperty=nameWithType> — launch a process and return an exit-status result.
- <xref:System.Diagnostics.Process.RunAndCaptureText*?displayProperty=nameWithType> and <xref:System.Diagnostics.Process.RunAndCaptureTextAsync*?displayProperty=nameWithType> — launch and capture stdout/stderr together with exit code.
- <xref:System.Diagnostics.Process.ReadAllText(System.Nullable{System.TimeSpan})?displayProperty=nameWithType>, <xref:System.Diagnostics.Process.ReadAllBytes(System.Nullable{System.TimeSpan})?displayProperty=nameWithType>, and their async variants — read a child process's standard output in a single call.
- <xref:System.Diagnostics.Process.ReadAllLines(System.Nullable{System.TimeSpan})?displayProperty=nameWithType> — synchronously reads all lines of output from a child process, returning a sequence of <xref:System.Diagnostics.ProcessOutputLine> values that distinguish stdout from stderr.
- <xref:System.Diagnostics.Process.ReadAllLinesAsync(System.Threading.CancellationToken)?displayProperty=nameWithType> — returns a stream of <xref:System.Diagnostics.ProcessOutputLine> values that distinguish stdout from stderr without string parsing.

#### Fire-and-forget launches

- <xref:System.Diagnostics.Process.StartAndForget*?displayProperty=nameWithType> — starts a child process when you don't intend to wait for it; the runtime detaches the handle automatically.
- <xref:System.Diagnostics.ProcessStartInfo.StartDetached?displayProperty=nameWithType> — detaches from the parent's session/console so the child can outlive a terminal exit.
- <xref:System.Diagnostics.ProcessStartInfo.KillOnParentExit?displayProperty=nameWithType> (Windows only) — the child is terminated when the parent process exits.

#### SafeProcessHandle lifecycle methods

<xref:Microsoft.Win32.SafeHandles.SafeProcessHandle> gains lifecycle methods for advanced scenarios:

- <xref:Microsoft.Win32.SafeHandles.SafeProcessHandle.Start(System.Diagnostics.ProcessStartInfo)?displayProperty=nameWithType> and a new <xref:Microsoft.Win32.SafeHandles.SafeProcessHandle.ProcessId?displayProperty=nameWithType> property — launch and identify processes without going through <xref:System.Diagnostics.Process> itself.
- <xref:Microsoft.Win32.SafeHandles.SafeProcessHandle.Kill?displayProperty=nameWithType> and <xref:Microsoft.Win32.SafeHandles.SafeProcessHandle.Signal(System.Runtime.InteropServices.PosixSignal)?displayProperty=nameWithType> — terminate or signal a process by handle.
- <xref:Microsoft.Win32.SafeHandles.SafeProcessHandle.WaitForExit?displayProperty=nameWithType> and <xref:Microsoft.Win32.SafeHandles.SafeProcessHandle.WaitForExitAsync(System.Threading.CancellationToken)?displayProperty=nameWithType> — wait for a process to exit by handle.

#### Tighter handle control

- <xref:System.Diagnostics.ProcessStartInfo.InheritedHandles?displayProperty=nameWithType> — specify exactly which OS handles a child process inherits, instead of using the all-or-nothing `UseShellExecute = false` default.
- <xref:System.Diagnostics.ProcessStartInfo.StandardInputHandle?displayProperty=nameWithType>, <xref:System.Diagnostics.ProcessStartInfo.StandardOutputHandle?displayProperty=nameWithType>, and <xref:System.Diagnostics.ProcessStartInfo.StandardErrorHandle?displayProperty=nameWithType> — supply already-open <xref:Microsoft.Win32.SafeHandles.SafeFileHandle?displayProperty=nameWithType> values for redirection without the framework opening new ones.

### Console FORCE_COLOR support

.NET console output now honors the [`FORCE_COLOR`](https://force-color.org/) standard alongside the existing `NO_COLOR` support. When `FORCE_COLOR` is set, <xref:System.Console.IsOutputRedirected?displayProperty=nameWithType> no longer suppresses ANSI escape codes. This is useful when you pipe `dotnet run` output through `tee`, into a CI log viewer, or through `less -R`:

```bash
FORCE_COLOR=1 dotnet run | tee build.log
```

## Text, serialization, and data handling

- [String and character enhancements](#string-and-character-enhancements)
- [Base64 encoding improvements](#base64-encoding-improvements)
- [UTF validation and invalid-subsequence search](#utf-validation-and-invalid-subsequence-search)
- [System.Text.Json improvements](#systemtextjson-improvements)
- [Regular expression improvements](#regular-expression-improvements)

### String and character enhancements

.NET 11 introduces significant enhancements to string and character manipulation APIs, making it easier to work with Unicode characters and runes.

#### Rune support in String methods

The <xref:System.String> class now includes methods that accept <xref:System.Text.Rune> parameters, enabling you to search, replace, and manipulate strings using Unicode scalar values directly. These new methods include:

- `Contains` - Check if a string contains a specific rune: <xref:System.String.Contains(System.Text.Rune)?displayProperty=nameWithType> and <xref:System.String.Contains(System.Text.Rune,System.StringComparison)?displayProperty=nameWithType>.
- `StartsWith` and `EndsWith` - Check if a string starts or ends with a specific rune: <xref:System.String.StartsWith(System.Text.Rune)?displayProperty=nameWithType>, <xref:System.String.StartsWith(System.Text.Rune,System.StringComparison)?displayProperty=nameWithType>, <xref:System.String.EndsWith(System.Text.Rune)?displayProperty=nameWithType>, and <xref:System.String.EndsWith(System.Text.Rune,System.StringComparison)?displayProperty=nameWithType>.
- `IndexOf` and `LastIndexOf` - Find the position of a rune in a string: <xref:System.String.IndexOf(System.Text.Rune)?displayProperty=nameWithType>, <xref:System.String.IndexOf(System.Text.Rune,System.StringComparison)?displayProperty=nameWithType>, <xref:System.String.LastIndexOf(System.Text.Rune)?displayProperty=nameWithType>, and <xref:System.String.LastIndexOf(System.Text.Rune,System.StringComparison)?displayProperty=nameWithType>.
- `Replace` - Replace occurrences of one rune with another: <xref:System.String.Replace(System.Text.Rune,System.Text.Rune)?displayProperty=nameWithType>.
- `Split` - Split a string using a rune as the separator: <xref:System.String.Split(System.Text.Rune,System.StringSplitOptions)?displayProperty=nameWithType> and <xref:System.String.Split(System.Text.Rune,System.Int32,System.StringSplitOptions)?displayProperty=nameWithType>.
- `Trim`, `TrimStart`, and `TrimEnd` - Trim runes from strings: <xref:System.String.Trim(System.Text.Rune)?displayProperty=nameWithType>, <xref:System.String.TrimStart(System.Text.Rune)?displayProperty=nameWithType>, and <xref:System.String.TrimEnd(System.Text.Rune)?displayProperty=nameWithType>.

Many of these methods include overloads that accept a <xref:System.StringComparison> parameter for culture-aware comparisons.

#### Char.Equals with StringComparison

The <xref:System.Char> struct now includes an <xref:System.Char.Equals(System.Char,System.StringComparison)?displayProperty=nameWithType> method that accepts a <xref:System.StringComparison> parameter, allowing you to compare characters using culture-aware or ordinal comparisons.

#### Rune support in TextInfo

The <xref:System.Globalization.TextInfo> class now provides <xref:System.Globalization.TextInfo.ToLower(System.Text.Rune)?displayProperty=nameWithType> and <xref:System.Globalization.TextInfo.ToUpper(System.Text.Rune)?displayProperty=nameWithType> methods that accept <xref:System.Text.Rune> parameters, enabling you to perform case conversions on individual Unicode scalar values.

#### StringBuilder.MoveChunks

To transfer content without copying characters, use the new static <xref:System.Text.StringBuilder.MoveChunks(System.Text.StringBuilder)?displayProperty=nameWithType> method, which moves all content from a source `StringBuilder` to a new `StringBuilder`. After the call, the source `StringBuilder` has a length of 0:

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="StringBuilderMoveChunks":::

### Base64 encoding improvements

.NET 11 adds new APIs and overloads to the existing <xref:System.Buffers.Text.Base64> type, providing comprehensive support for Base64 encoding and decoding. These additions offer improved performance and flexibility compared to existing methods.

#### New Base64 APIs

The new APIs support encoding and decoding operations with various input and output formats:

- **Encoding to chars**: <xref:System.Buffers.Text.Base64.EncodeToChars*> and <xref:System.Buffers.Text.Base64.EncodeToString*>
- **Encoding to UTF-8**: <xref:System.Buffers.Text.Base64.EncodeToUtf8*>
- **Decoding from chars**: <xref:System.Buffers.Text.Base64.DecodeFromChars*>
- **Decoding from UTF-8**: <xref:System.Buffers.Text.Base64.DecodeFromUtf8*>

These methods provide both high-level convenience methods (that allocate and return arrays or strings) and low-level span-based methods (for zero-allocation scenarios).

### UTF validation and invalid-subsequence search

<xref:System.Text.Unicode?displayProperty=fullName> has two new complementary features. <xref:System.Text.Unicode.Utf16.IsValid(System.ReadOnlySpan{System.Char})?displayProperty=nameWithType> answers whether a sequence is well-formed UTF-16 without scanning twice, and <xref:System.Text.Unicode.Utf8.IndexOfInvalidSubsequence(System.ReadOnlySpan{System.Byte})?displayProperty=nameWithType> / <xref:System.Text.Unicode.Utf16.IndexOfInvalidSubsequence(System.ReadOnlySpan{System.Char})?displayProperty=nameWithType> return the position of the first ill-formed code-unit sequence (or `-1` for valid input). Together, these methods let parsers, validators, and serializers report precise errors instead of generic encoding-error messages.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="UtfValidation":::

### System.Text.Json improvements

#### Generic type info retrieval

A common pattern when working with `System.Text.Json` type metadata is to retrieve a <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo`1> from <xref:System.Text.Json.JsonSerializerOptions>.
Previously, you had to manually downcast from the non-generic <xref:System.Text.Json.JsonSerializerOptions.GetTypeInfo(System.Type)> method.
New generic <xref:System.Text.Json.JsonSerializerOptions.GetTypeInfo``1?displayProperty=nameWithType> and <xref:System.Text.Json.JsonSerializerOptions.TryGetTypeInfo``1(System.Text.Json.Serialization.Metadata.JsonTypeInfo{``0}@)?displayProperty=nameWithType> methods return strongly typed metadata directly, eliminating the cast.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="JsonTypeInfoGeneric":::

This is particularly useful when working with source generation, NativeAOT, and polymorphic serialization scenarios where type metadata access is common.

#### Naming and ignore defaults

The naming and ignore options available in <xref:System.Text.Json?displayProperty=fullName> now include:

- **<xref:System.Text.Json.JsonNamingPolicy.PascalCase?displayProperty=nameWithType>**: A new built-in naming policy that converts property names to PascalCase. It joins the existing camelCase, snake_case, and kebab-case policies.
- **Per-member naming policy**: The new <xref:System.Text.Json.Serialization.JsonNamingPolicyAttribute?displayProperty=nameWithType> attribute lets you override the naming policy on individual properties or fields, giving you fine-grained control without a custom converter.
- **Type-level ignore conditions**: Applying <xref:System.Text.Json.Serialization.JsonIgnoreAttribute?displayProperty=nameWithType> at the class or struct level sets the default ignore behavior for all members, so you no longer need to repeat the attribute on every nullable property.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="JsonNamingIgnore":::

#### F# discriminated union support

The serializer now understands F# discriminated unions out of the box. Apps that share types between F# producers and C# consumers no longer need a custom converter for the most common shapes:

```fsharp
type Shape =
    | Circle of radius: float
    | Square of side: float

let json = System.Text.Json.JsonSerializer.Serialize(Circle 1.5)
// {"$type":"Circle","radius":1.5}
```

#### Utf8JsonWriter.Reset with options

<xref:System.Text.Json.Utf8JsonWriter.Reset*> now accepts a <xref:System.Text.Json.JsonWriterOptions> parameter, so writer instances can be repooled with different options without allocating a new writer:

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="Utf8JsonWriterReset":::

#### SerializeAsyncEnumerable improvements

<xref:System.Text.Json.JsonSerializer.SerializeAsyncEnumerable*?displayProperty=nameWithType> gains two new capabilities:

- **`PipeWriter` target:** For pipeline-based I/O scenarios, new overloads accept a <xref:System.IO.Pipelines.PipeWriter> as the output destination, making it easy to integrate JSON streaming directly.
- **`topLevelValues` parameter:** For NDJSON output, set this parameter to `true` to write each item as a top-level JSON value separated by newlines instead of wrapping all items in a JSON array. Both `Stream` and `PipeWriter` overloads support the parameter.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="JsonSerializeAsyncEnumerablePipe":::

### Regular expression improvements

#### AnyNewLine option

A new <xref:System.Text.RegularExpressions.RegexOptions.AnyNewLine?displayProperty=nameWithType> flag makes `^`, `$`, and `.` treat the full set of Unicode newline characters as line terminators—not just `\n`. This helps when parsing text that mixes Windows (`\r\n`), Unix (`\n`), and Unicode-specific (`\u0085`, `\u2028`, `\u2029`) line endings.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="RegexAnyNewLine":::

#### Regex engine and source generator fixes

.NET 11 includes several regex correctness and code-quality fixes:

- The non-backtracking engine no longer takes super-linear time on certain nested-loop patterns and produces correct results for cases that previously diverged.
- The regex compiler and source generator handle `resumeAt` correctly when a conditional appears inside a loop body.
- The [SYSLIB1045](../../../fundamentals/syslib-diagnostics/syslib1040-1049.md) code fixer no longer creates duplicate class names when applied across multiple partial declarations of the same class.

## Compression and archive formats

- [Compression enhancements](#compression-enhancements)
- [Zstandard compression](#zstandard-compression)
- [Tar archive format selection](#tar-archive-format-selection)

### Compression enhancements

.NET 11 includes several improvements to compression APIs.

#### ZIP archive entry access modes

The <xref:System.IO.Compression.ZipArchiveEntry> class now supports opening entries with specific file access modes through new overloads: <xref:System.IO.Compression.ZipArchiveEntry.Open(System.IO.FileAccess)?displayProperty=nameWithType> and <xref:System.IO.Compression.ZipArchiveEntry.OpenAsync(System.IO.FileAccess,System.Threading.CancellationToken)?displayProperty=nameWithType>. These overloads accept a <xref:System.IO.FileAccess> parameter and allow you to open ZIP entries for read, write, or read-write access.

Additionally, a new <xref:System.IO.Compression.ZipArchiveEntry.CompressionMethod> property exposes the compression method used for an entry through the <xref:System.IO.Compression.ZipCompressionMethod> enum, which includes values for <xref:System.IO.Compression.ZipCompressionMethod.Stored>, <xref:System.IO.Compression.ZipCompressionMethod.Deflate>, and <xref:System.IO.Compression.ZipCompressionMethod.Deflate64>.

#### ZIP CRC32 validation

<xref:System.IO.Compression.ZipArchive> validates the CRC32 checksum when reading ZIP entries. Corrupted or truncated archives that previously passed without error now throw <xref:System.IO.InvalidDataException>, helping you detect data integrity issues early.

#### DeflateStream and GZipStream behavior change

Starting in .NET 11, <xref:System.IO.Compression.DeflateStream> and <xref:System.IO.Compression.GZipStream> always write format headers and footers to the output stream, even when no data is written. This ensures the output is a valid compressed stream according to the Deflate and GZip specifications.

Previously, these streams didn't produce any output if no data was written, resulting in an empty output stream. This change ensures compatibility with tools that expect properly formatted compressed streams.

For more information, see [DeflateStream and GZipStream write headers and footers for empty payload](../../compatibility/core-libraries/11/deflatestream-gzipstream-empty-payload.md).

#### Span-based Deflate, ZLib, and GZip APIs

<xref:System.IO.Compression> now offers `Span<byte>`/`ReadOnlySpan<byte>` encode and decode entry points for the Deflate, ZLib, and GZip formats. The new APIs, on types such as <xref:System.IO.Compression.DeflateEncoder>, <xref:System.IO.Compression.ZLibEncoder>, and <xref:System.IO.Compression.GZipEncoder>, mirror the shape of <xref:System.IO.Compression.BrotliEncoder>/<xref:System.IO.Compression.BrotliDecoder> and the Zstandard primitives. You can compress and decompress buffers without allocating a `Stream`. This is useful for high-throughput scenarios such as protocol parsers, log shippers, and middleware that already operate on spans.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="ZLibEncoderSpan":::

### Zstandard compression

The Zstandard compression APIs, for example, <xref:System.IO.Compression.ZstandardStream> and <xref:System.IO.Compression.ZstandardEncoder>, are now part of the <xref:System.IO.Compression> namespace, alongside `DeflateStream`, `GZipStream`, and `BrotliStream`. The API surface is otherwise unchanged.

### Tar archive format selection

New overloads on <xref:System.Formats.Tar.TarFile.CreateFromDirectory*> and <xref:System.Formats.Tar.TarFile.CreateFromDirectoryAsync*> accept a <xref:System.Formats.Tar.TarEntryFormat> parameter, giving you direct control over the archive format. Previously, `CreateFromDirectory` always produced Pax archives. The new overloads support all four tar formats—Pax, Ustar, GNU, and V7—for compatibility with specific tools and environments.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="TarArchiveFormat":::

`TarReader` can now also read entries that use the GNU sparse format 1.0 (PAX) representation. The earlier 0.1 representation was already supported. With 1.0 support in place, `TarReader` matches what modern `tar` implementations write by default for sparse files.

## Collections, numerics, and low-level I/O

- [LINQ join improvements](#linq-join-improvements)
- [BFloat16 support in BitConverter](#bfloat16-support-in-bitconverter)
- [Floating-point hex formatting and parsing](#floating-point-hex-formatting-and-parsing)
- [Numerics improvements](#numerics-improvements)
- [Random generic methods](#random-generic-methods)
- [Low-level I/O improvements](#low-level-io-improvements)
- [Collections improvements](#collections-improvements)

### LINQ join improvements

LINQ gains several new join operations, plus tuple-returning overloads for the existing `Join` and `GroupJoin` methods. All new operations are available on <xref:System.Linq.Enumerable>, <xref:System.Linq.Queryable>, and <xref:System.Linq.AsyncEnumerable>.

#### LeftJoin, RightJoin, and FullJoin

Because the three new outer-join operations return tuples directly, you can work with them easily using pattern matching and deconstruction:

- <xref:System.Linq.Enumerable.LeftJoin*?displayProperty=nameWithType> — Returns all elements from the left (outer) sequence. When there's no matching element in the right (inner) sequence, the inner element is `null`.
- <xref:System.Linq.Enumerable.RightJoin*?displayProperty=nameWithType> — Returns all elements from the right (inner) sequence. When there's no matching element in the left (outer) sequence, the outer element is `null`.
- <xref:System.Linq.Enumerable.FullJoin*?displayProperty=nameWithType> — Returns all elements from both sequences, with `null` on either side when there's no match.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="LinqJoins":::

#### Tuple-returning Join and GroupJoin overloads

New overloads of <xref:System.Linq.Enumerable.Join*?displayProperty=nameWithType> and <xref:System.Linq.Enumerable.GroupJoin*?displayProperty=nameWithType> return tuples directly without requiring a result selector, and accept an optional <xref:System.Collections.Generic.IEqualityComparer`1> parameter. The optional comparer overload is also available on the `FullJoin`, `LeftJoin`, and `RightJoin` operations.

```csharp
var products = new[] { (Id: 1, Name: "Laptop"), (Id: 2, Name: "Mouse") };
var orders = new[] { (ProductId: 1, Qty: 3), (ProductId: 1, Qty: 1) };

var result = products.Join(orders, p => p.Id, o => o.ProductId);
foreach (var (product, order) in result)
    Console.WriteLine($"{product.Name}: qty={order.Qty}");
// Laptop: qty=3
// Laptop: qty=1
```

### BFloat16 support in BitConverter

The <xref:System.BitConverter> class now includes methods for converting between <xref:System.Numerics.BFloat16> values and byte arrays or bit representations. These new methods include:

- <xref:System.BitConverter.GetBytes(System.Numerics.BFloat16)?displayProperty=nameWithType> - Convert a BFloat16 value to a byte array.
- <xref:System.BitConverter.ToBFloat16(System.Byte[],System.Int32)?displayProperty=nameWithType> and <xref:System.BitConverter.ToBFloat16(System.ReadOnlySpan{System.Byte})?displayProperty=nameWithType> - Convert a byte array to a BFloat16 value.
- <xref:System.BitConverter.BFloat16ToInt16Bits(System.Numerics.BFloat16)?displayProperty=nameWithType>, <xref:System.BitConverter.BFloat16ToUInt16Bits(System.Numerics.BFloat16)?displayProperty=nameWithType>, <xref:System.BitConverter.Int16BitsToBFloat16(System.Int16)?displayProperty=nameWithType>, and <xref:System.BitConverter.UInt16BitsToBFloat16(System.UInt16)?displayProperty=nameWithType> - Methods for converting between BFloat16 and its bit representation as `short` or `ushort`.

BFloat16 (Brain Floating Point) is a 16-bit floating-point format that's commonly used in machine learning and scientific computing.

### Floating-point hex formatting and parsing

`double`, `float`, and `Half` can now be formatted and parsed in their hexadecimal IEEE-754 form. The hex form preserves every bit of the underlying value, making it the right choice for golden-file tests, cross-language interop with C/C++ `printf("%a", ...)`, and any scenario where round-tripping a `double` through decimal text is too lossy.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="FloatingPointHex":::

### Numerics improvements

<xref:System.Numerics.Matrix4x4.GetDeterminant?displayProperty=nameWithType> now uses an SSE-vectorized implementation, improving performance by approximately 15%.

### Random generic methods

<xref:System.Random> gains two new generic methods that work with any numeric type implementing the appropriate generic math interfaces:

- <xref:System.Random.NextInteger*?displayProperty=nameWithType> — Generates a random integer of type `T` where `T` implements `IBinaryInteger<T>` and `IMinMaxValue<T>`. Overloads accept an upper bound or both lower and upper bounds.
- <xref:System.Random.NextBinaryFloat*?displayProperty=nameWithType> — Generates a random floating-point value of type `T` where `T` implements `IBinaryFloatingPointIeee754<T>`.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="RandomGeneric":::

### Low-level I/O improvements

- [SafeFileHandle pipe support](#safefilehandle-pipe-support)
- [RandomAccess pipe support](#randomaccess-pipe-support)

#### SafeFileHandle pipe support

<xref:Microsoft.Win32.SafeHandles.SafeFileHandle> gains two new members:

- **<xref:Microsoft.Win32.SafeHandles.SafeFileHandle.Type?displayProperty=nameWithType> property:** Reports whether a handle represents a file, pipe, socket, directory, or other OS object, without requiring platform-specific code.
- **<xref:Microsoft.Win32.SafeHandles.SafeFileHandle.CreateAnonymousPipe(Microsoft.Win32.SafeHandles.SafeFileHandle@,Microsoft.Win32.SafeHandles.SafeFileHandle@,System.Boolean,System.Boolean)?displayProperty=nameWithType> method:** Creates a pair of connected anonymous pipe handles with independent async behavior for each end.

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="SafeFileHandlePipe":::

#### RandomAccess pipe support

<xref:System.IO.RandomAccess.Read*?displayProperty=nameWithType> and <xref:System.IO.RandomAccess.Write*?displayProperty=nameWithType> now work with non-seekable handles such as pipes, in addition to regular file handles.

On Windows, `Process` now uses overlapped I/O for redirected stdout/stderr, which reduces thread-pool blocking in process-heavy applications.

### Collections improvements

- [BitArray.PopCount](#bitarraypopcount)
- [IReadOnlySet support in JSON serialization](#ireadonlyset-support-in-json-serialization)
- [EqualityComparer\<T>.Create](#equalitycomparertcreate)

#### BitArray.PopCount

The <xref:System.Collections.BitArray> class now includes a <xref:System.Collections.BitArray.PopCount?displayProperty=nameWithType> method that returns the number of bits set to `true` in the array. This provides an efficient way to count set bits without manually iterating through the array.

#### IReadOnlySet support in JSON serialization

The <xref:System.Text.Json.Serialization.Metadata.JsonMetadataServices> class now includes a <xref:System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreateIReadOnlySetInfo*?displayProperty=nameWithType> method, enabling JSON serialization support for <xref:System.Collections.Generic.IReadOnlySet`1> collections.

#### EqualityComparer\<T>.Create

To create an equality comparer from a key selector function, use the new <xref:System.Collections.Generic.EqualityComparer`1.Create*?displayProperty=nameWithType> factory method. You can pass an optional <xref:System.Collections.Generic.IEqualityComparer`1> for the key type itself:

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="EqualityComparerCreate":::

## Extensions and developer platform

- [Discriminated-union scaffolding](#discriminated-union-scaffolding)
- [MetadataLoadContext additions](#metadataloadcontext-additions)
- [Reflection improvements](#reflection-improvements)
- [URI data scheme constant](#uri-data-scheme-constant)
- [StringSyntax attribute enhancements](#stringsyntax-attribute-enhancements)

### Discriminated-union scaffolding

> [!NOTE]
> This is a preview feature in .NET 11.

.NET 11 introduces <xref:System.Runtime.CompilerServices.UnionAttribute?displayProperty=nameWithType> and <xref:System.Runtime.CompilerServices.IUnion?displayProperty=nameWithType> in <xref:System.Runtime.CompilerServices?displayProperty=fullName>. These types are the runtime side of the C# discriminated-union design. They aren't directly user-facing yet—the C# compiler and source generators are the expected producers—but they ship in the framework so libraries can author against the surface now.

For the language-side design, see the [C# unions proposal](https://github.com/dotnet/csharplang/blob/main/proposals/unions.md).

### MetadataLoadContext additions

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

### URI data scheme constant

A new <xref:System.Uri.UriSchemeData?displayProperty=nameWithType> constant has been added, representing the `data:` URI scheme. This constant provides a standardized way to reference data URIs.

### Reflection improvements

#### Type.GetNullableUnderlyingType

<xref:System.Type?displayProperty=fullName> gains a new virtual method, <xref:System.Type.GetNullableUnderlyingType?displayProperty=nameWithType>, that returns the underlying value type for a `Nullable<T>` type, or `null` for any non-nullable type. Implementations are provided on <xref:System.Type>, <xref:System.Reflection.Emit.TypeBuilder>, <xref:System.Reflection.Emit.EnumBuilder>, <xref:System.Reflection.Emit.GenericTypeParameterBuilder>, and <xref:System.Reflection.TypeDelegator>:

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="NullableUnderlyingType":::

#### ConstructorInfo.GetGenericArguments

<xref:System.Reflection.ConstructorInfo.GetGenericArguments?displayProperty=nameWithType> now has an override, providing a consistent way to retrieve generic type arguments for constructor definitions, matching the behavior already available on other `MethodBase` subclasses.

### StringSyntax attribute enhancements

The <xref:System.Diagnostics.CodeAnalysis.StringSyntaxAttribute> class now includes constants for common programming languages:

- <xref:System.Diagnostics.CodeAnalysis.StringSyntaxAttribute.CSharp> - Indicates C# syntax.
- <xref:System.Diagnostics.CodeAnalysis.StringSyntaxAttribute.FSharp> - Indicates F# syntax.
- <xref:System.Diagnostics.CodeAnalysis.StringSyntaxAttribute.VisualBasic> - Indicates Visual Basic syntax.

These constants can be used with the `StringSyntax` attribute to provide better tooling support for string literals containing code in these languages.

## Caching and configuration

- [Configuration binding](#configuration-binding)
- [MemoryCache OpenTelemetry metrics](#memorycache-opentelemetry-metrics)
- [Options builder validation improvements](#options-builder-validation-improvements)

### Configuration binding

<xref:Microsoft.Extensions.Configuration?displayProperty=fullName> adds <xref:Microsoft.Extensions.Configuration.ConfigurationIgnoreAttribute?displayProperty=nameWithType>, so models can opt individual properties out of binding declaratively without relying on `BindNonPublicProperties` toggles or custom converters:

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

### MemoryCache OpenTelemetry metrics

<xref:Microsoft.Extensions.Caching.Memory.MemoryCache> now emits a built-in set of OpenTelemetry (OTel)-compatible metrics without an extra adapter package. To opt in, set <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheOptions.TrackStatistics?displayProperty=nameWithType> to `true`:

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

Pass an <xref:System.Diagnostics.Metrics.IMeterFactory?displayProperty=nameWithType> to the new <xref:Microsoft.Extensions.Caching.Memory.MemoryCache.%23ctor(Microsoft.Extensions.Options.IOptions{Microsoft.Extensions.Caching.Memory.MemoryCacheOptions},Microsoft.Extensions.Logging.ILoggerFactory,System.Diagnostics.Metrics.IMeterFactory)?displayProperty=nameWithType> constructor overload for per-instance metrics. Without one, the instruments are aggregated process-wide on a shared meter.

### Options builder validation improvements

<xref:Microsoft.Extensions.Options.OptionsBuilder`1> gains a new generic <xref:Microsoft.Extensions.Options.OptionsBuilder`1.Validate*?displayProperty=nameWithType> overload that accepts a type parameter instead of a factory delegate. The type must implement <xref:Microsoft.Extensions.Options.IValidateOptions`1> and be registered in the dependency-injection container. This aligns options validation with the standard DI pattern:

```csharp
services.AddSingleton<IValidateOptions<MyOptions>, MyOptionsValidator>();
services.AddOptions<MyOptions>()
    .Bind(configuration.GetSection("MyOptions"))
    .Validate<MyOptionsValidator>();
```

## Cryptography

- [X25519 Diffie-Hellman key exchange](#x25519-diffie-hellman-key-exchange)
- [CryptographicOperations.FixedTimeEquals overload](#cryptographicoperationsfixedtimeequals-overload)

### X25519 Diffie-Hellman key exchange

The new <xref:System.Security.Cryptography.X25519DiffieHellman?displayProperty=fullName> abstract class provides a clean API for the X25519 elliptic-curve Diffie-Hellman algorithm, which is widely used in TLS 1.3, SSH, and Signal-protocol implementations. Platform-specific implementations are provided through <xref:System.Security.Cryptography.X25519DiffieHellmanCng> (Windows) and <xref:System.Security.Cryptography.X25519DiffieHellmanOpenSsl> (Linux and macOS), but the portable `GenerateKey()` factory method picks the right one automatically:

:::code language="csharp" source="./snippets/csharp/Libraries.cs" id="X25519KeyExchange":::

The class supports the full key lifecycle: key generation, PKCS#8 and SubjectPublicKeyInfo import/export, PEM serialization, and raw private/public key access.

### CryptographicOperations.FixedTimeEquals overload

For secret-comparison scenarios where the expected value is a single known byte, use the new <xref:System.Security.Cryptography.CryptographicOperations.FixedTimeEquals*?displayProperty=nameWithType> overload that compares a <xref:System.ReadOnlySpan`1> with a single `byte` value in constant time:

```csharp
bool equal = CryptographicOperations.FixedTimeEquals(receivedSpan, 0x42);
```

## Networking and transport security

- [TLS handshake hardening](#tls-handshake-hardening)
- [HTTP/2 automatic downgrade for Windows authentication](#http2-automatic-downgrade-for-windows-authentication)
- [QUIC stream priority](#quic-stream-priority)
- [Video MIME type constants](#video-mime-type-constants)

### TLS handshake hardening

Two <xref:System.Net.Security?displayProperty=fullName> items improve TLS (Transport Layer Security) reliability:

- <xref:System.Net.Security.SslStream> server-side handshake bounds-checking fixes in `TlsFrameHelper` close several edge cases that could surface as `IOException` on malformed ClientHello records.
- On Linux, certificate-validation failures now surface as standard TLS alerts to the peer, matching Windows behavior. Connecting clients receive an actionable handshake error instead of a connection drop.

### HTTP/2 automatic downgrade for Windows authentication

<xref:System.Net.Http.HttpClient> automatically downgrades to HTTP/1.1 when a request requires Windows authentication (NTLM/Negotiate) over HTTP/2. The HTTP/2 specification disallows the connection-bound authentication schemes that NTLM and Kerberos rely on, so these requests previously failed. With the downgrade in place, applications targeting mixed-authentication environments—common in enterprise intranets—work without explicit `HttpRequestMessage.Version` overrides.

### QUIC stream priority

<xref:System.Net.Quic.QuicStream> gains a <xref:System.Net.Quic.QuicStream.Priority?displayProperty=nameWithType> property and a <xref:System.Net.Quic.QuicStream.DefaultPriority?displayProperty=nameWithType> constant that exposes HTTP/3 stream prioritization (RFC 9218). Priority values range from 0 (highest) to 255 (lowest), with a default of 127:

```csharp
// Increase priority for interactive streams
stream.Priority = 64; // Higher priority than the default 127
```

### Video MIME type constants

A new <xref:System.Net.Mime.MediaTypeNames.Video?displayProperty=nameWithType> class provides string constants for common video media types:

- `MediaTypeNames.Video.Mp4` — `"video/mp4"`
- `MediaTypeNames.Video.Mpeg` — `"video/mpeg"`
- `MediaTypeNames.Video.Ogg` — `"video/ogg"`
- `MediaTypeNames.Video.QuickTime` — `"video/quicktime"`
- `MediaTypeNames.Video.WebM` — `"video/webm"`

These join the existing `MediaTypeNames.Application`, `MediaTypeNames.Image`, `MediaTypeNames.Text`, and `MediaTypeNames.Multipart` classes.

## Unsafe API accessibility

.NET 11 removes the `[RequiresUnsafe]` attribute from a large set of APIs that take pointer parameters. Previously, calling these methods from code that used `unsafe` blocks still required a project-level `<AllowUnsafeBlocks>true</AllowUnsafeBlocks>` setting because the attribute enforced that requirement independently. Now, only the standard `unsafe` block or method modifier is required.

Affected APIs include:

- <xref:System.Buffer.MemoryCopy*?displayProperty=nameWithType>
- <xref:System.ReadOnlySpan`1.%23ctor(System.Void*,System.Int32)?displayProperty=nameWithType> and <xref:System.Span`1.%23ctor(System.Void*,System.Int32)?displayProperty=nameWithType>
- <xref:System.Runtime.CompilerServices.Unsafe?displayProperty=fullName> pointer methods such as `AsRef`, `Read`, `Write`, and `Copy`
- <xref:System.Runtime.InteropServices.NativeMemory?displayProperty=fullName> methods
- <xref:System.Text.Encoding?displayProperty=fullName> pointer overloads (all encoding classes)
- <xref:System.Numerics.Vector?displayProperty=fullName> pointer-based `Load` and `Store` methods
- Interop marshalling types in <xref:System.Runtime.InteropServices.Marshalling?displayProperty=fullName>

This change reduces friction for advanced scenarios such as interop authoring, memory-mapped files, and low-level buffer manipulation, where unsafe context is already required by the calling code.

## See also

- [What's new in the .NET 11 runtime](runtime.md)
- [What's new in the SDK for .NET 11](sdk.md)
- [Breaking changes in .NET 11](../../compatibility/11.md)
