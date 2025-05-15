---
title: What's new in .NET libraries for .NET 10
description: Learn about the updates to the .NET libraries for .NET 10.
titleSuffix: ""
ms.date: 05/15/2025
ms.topic: whats-new
ai-usage: ai-assisted
---

# What's new in .NET libraries for .NET 10

This article describes new features in the .NET libraries for .NET 10. It's updated for Preview 4.

## Cryptography

- [Find certificates by thumbprints other than SHA-1](#find-certificates-by-thumbprints-other-than-sha-1)
- [Find PEM-encoded data in ASCII/UTF-8](#find-pem-encoded-data-in-asciiutf-8)
- [Encryption algorithm for PKCS#12/PFX export](#encryption-algorithm-for-pkcs12pfx-export)

### Find certificates by thumbprints other than SHA-1

Finding certificates uniquely by thumbprint is a fairly common operation, but the <xref:System.Security.Cryptography.X509Certificates.X509Certificate2Collection.Find(System.Security.Cryptography.X509Certificates.X509FindType,System.Object,System.Boolean)?displayProperty=nameWithType> method (for the <xref:System.Security.Cryptography.X509Certificates.X509FindType.FindByThumbprint> mode) only searches for the SHA-1 thumbprint value.

There's some risk to using the `Find` method for finding SHA-2-256 ("SHA256") and SHA-3-256 thumbprints since these hash algorithms have the same lengths.

Instead, .NET 10 introduces a [new method](xref:System.Security.Cryptography.X509Certificates.X509Certificate2Collection.FindByThumbprint*) that accepts the name of the hash algorithm to use for matching.

```csharp
X509Certificate2Collection coll = store.Certificates.FindByThumbprint(HashAlgorithmName.SHA256, thumbprint);
Debug.Assert(coll.Count < 2, "Collection has too many matches, has SHA-2 been broken?");
return coll.SingleOrDefault();
```

### Find PEM-encoded data in ASCII/UTF-8

The PEM encoding (originally *Privacy Enhanced Mail*, but now used widely outside of email) is defined for "text", which means that the <xref:System.Security.Cryptography.PemEncoding> class was designed to run on <xref:System.String> and `ReadOnlySpan<char>`. However, it's common (especially on Linux) to have something like a certificate written in a file that uses the ASCII (string) encoding. Historically, that meant you needed to open the file and convert the bytes to chars (or a string) before you could use `PemEncoding`.

The new <xref:System.Security.Cryptography.PemEncoding.FindUtf8(System.ReadOnlySpan{System.Byte})?displayProperty=nameWithType> method takes advantage of the fact that PEM is only defined for 7-bit ASCII characters, and that 7-bit ASCII has a perfect overlap with single-byte UTF-8 values. By calling this new method, you can skip the UTF-8/ASCII-to-char conversion and read the file directly.

```diff
byte[] fileContents = File.ReadAllBytes(path);
-char[] text = Encoding.ASCII.GetString(fileContents);
-PemFields pemFields = PemEncoding.Find(text);
+PemFields pemFields = PemEncoding.FindUtf8(fileContents);

-byte[] contents = Base64.DecodeFromChars(text.AsSpan()[pemFields.Base64Data]);
+byte[] contents = Base64.DecodeFromUtf8(fileContents.AsSpan()[pemFields.Base64Data]);
```

### Encryption algorithm for PKCS#12/PFX export

The new <xref:System.Security.Cryptography.X509Certificates.X509Certificate.ExportPkcs12*> methods on <xref:System.Security.Cryptography.X509Certificates.X509Certificate> allow callers to choose what encryption and digest algorithms are used to produce the output:

- <xref:System.Security.Cryptography.X509Certificates.Pkcs12ExportPbeParameters.Pkcs12TripleDesSha1?displayProperty=nameWithType> indicates the Windows XP-era de facto standard. It produces an output supported by almost every library and platform that supports reading PKCS#12/PFX by choosing an older encryption algorithm.
- <xref:System.Security.Cryptography.X509Certificates.Pkcs12ExportPbeParameters.Pbes2Aes256Sha256?displayProperty=nameWithType> indicates that AES should be used instead of 3DES (and SHA-2-256 instead of SHA-1), but the output might not be understood by all readers (such as Windows XP).

If you want even more control, you can use [the overload](xref:System.Security.Cryptography.X509Certificates.X509Certificate.ExportPkcs12(System.Security.Cryptography.PbeParameters,System.String)) that accepts a <xref:System.Security.Cryptography.PbeParameters>.

## Globalization

- [New method overloads in ISOWeek for DateOnly type](#new-method-overloads-in-isoweek-for-dateonly-type)
- [Numeric ordering for string comparison](#numeric-ordering-for-string-comparison)

### New method overloads in ISOWeek for DateOnly type

The <xref:System.Globalization.ISOWeek> class was originally designed to work exclusively with <xref:System.DateTime>, as it was introduced before the <xref:System.DateOnly> type existed. Now that `DateOnly` is available, it makes sense for `ISOWeek` to support it as well. The following overloads are new:

- <xref:System.Globalization.ISOWeek.GetWeekOfYear(System.DateOnly)>
- <xref:System.Globalization.ISOWeek.GetYear(System.DateOnly)>
- <xref:System.Globalization.ISOWeek.ToDateOnly(System.Int32,System.Int32,System.DayOfWeek)>

### Numeric ordering for string comparison

Numerical string comparison is a highly requested feature for comparing strings numerically instead of lexicographically. For example, `2` is less than `10`, so `"2"` should appear before `"10"` when ordered numerically. Similarly, `"2"` and `"02"` are equal numerically. With the new <xref:System.Globalization.CompareOptions.NumericOrdering> option, it's now possible to do these types of comparisons:

:::code language="csharp" source="../snippets/dotnet-10/csharp/snippets.cs" id="snippet_numericOrdering":::

This option isn't valid for the following index-based string operations: `IndexOf`, `LastIndexOf`, `StartsWith`, `EndsWith`, `IsPrefix`, and `IsSuffix`.

## Strings

- [String normalization APIs to work with span of characters](#string-normalization-apis-to-work-with-span-of-characters)

### String normalization APIs to work with span of characters

Unicode string normalization has been supported for a long time, but existing APIs only worked with the string type. This means that callers with data stored in different forms, such as character arrays or spans, must allocate a new string to use these APIs. Additionally, APIs that return a normalized string always allocate a new string to represent the normalized output.

.NET 10 introduces new APIs that work with spans of characters, which expand normalization beyond string types and help to avoid unnecessary allocations:

- <xref:System.StringNormalizationExtensions.GetNormalizedLength(System.ReadOnlySpan{System.Char},System.Text.NormalizationForm)?displayProperty=nameWithType>
- <xref:System.StringNormalizationExtensions.IsNormalized(System.ReadOnlySpan{System.Char},System.Text.NormalizationForm)?displayProperty=nameWithType>
- <xref:System.StringNormalizationExtensions.TryNormalize(System.ReadOnlySpan{System.Char},System.Span{System.Char},System.Int32@,System.Text.NormalizationForm)?displayProperty=nameWithType>

## New `TimeSpan.FromMilliseconds` overload with single parameter

The <xref:System.TimeSpan.FromMilliseconds(System.Int64,System.Int64)?displayProperty=nameWithType> method was introduced previously without adding an overload that takes a single parameter.

Although this works since the second parameter is optional, it causes a compilation error when used in a LINQ expression like:

```csharp
Expression<Action> a = () => TimeSpan.FromMilliseconds(1000);
```

The issue arises because LINQ expressions can't handle optional parameters. To address this, .NET 10 introduces [a new overload](xref:System.TimeSpan.FromMilliseconds(System.Int64)) takes a single parameter. It also modifies [the existing method](xref:System.TimeSpan.FromMilliseconds(System.Int64,System.Int64)) to make the second parameter mandatory.

## Collections

- [Additional `TryAdd` and `TryGetValue` overloads for `OrderedDictionary<TKey, TValue>`](#additional-tryadd-and-trygetvalue-overloads-for-ordereddictionarytkey-tvalue)

### Additional `TryAdd` and `TryGetValue` overloads for `OrderedDictionary<TKey, TValue>`

<xref:System.Collections.Generic.OrderedDictionary`2> provides `TryAdd` and `TryGetValue` for addition and retrieval like any other `IDictionary<TKey, TValue>` implementation. However, there are scenarios where you might want to perform more operations, so new overloads are added that return an index to the entry:

- <xref:System.Collections.Generic.OrderedDictionary`2.TryAdd(`0,`1,System.Int32@)>
- <xref:System.Collections.Generic.OrderedDictionary`2.TryGetValue(`0,`1@,System.Int32@)>

This index can then be used with <xref:System.Collections.Generic.OrderedDictionary`2.GetAt*> and <xref:System.Collections.Generic.OrderedDictionary`2.SetAt*> for fast access to the entry. An example usage of the new `TryAdd` overload is to add or update a key-value pair in the ordered dictionary:

:::code language="csharp" source="../snippets/dotnet-10/csharp/snippets.cs" id="snippet_getAtSetAt":::

This new API is already used in <xref:System.Json.JsonObject> and improves the performance of updating properties by 10-20%.

## Serialization

- [Allow specifying ReferenceHandler in `JsonSourceGenerationOptions`](#allow-specifying-referencehandler-in-jsonsourcegenerationoptions)

### Allow specifying ReferenceHandler in `JsonSourceGenerationOptions`

When you use [source generators for JSON serialization](../../../standard/serialization/system-text-json/source-generation.md), the generated context throws when cycles are serialized or deserialized. Now you can customize this behavior by specifying the <xref:System.Text.Json.Serialization.ReferenceHandler> in the <xref:System.Text.Json.Serialization.JsonSourceGenerationOptionsAttribute>. Here's an example using `JsonKnownReferenceHandler.Preserve`:

:::code language="csharp" source="../snippets/dotnet-10/csharp/snippets.cs" id="snippet_selfReference":::

## System.Numerics

- [More left-handed matrix transformation methods](#more-left-handed-matrix-transformation-methods)
- [Tensor enhancements](#tensor-enhancements)

### More left-handed matrix transformation methods

.NET 10 adds the remaining APIs for creating left-handed transformation matrices for billboard and constrained-billboard matrices. You can use these methods like their existing right-handed counterparts, for example, <xref:System.Numerics.Matrix4x4.CreateBillboard(System.Numerics.Vector3,System.Numerics.Vector3,System.Numerics.Vector3,System.Numerics.Vector3)>, when using a left-handed coordinate system instead:

- <xref:System.Numerics.Matrix4x4.CreateBillboardLeftHanded(System.Numerics.Vector3,System.Numerics.Vector3,System.Numerics.Vector3,System.Numerics.Vector3)?displayProperty=nameWithType>
- <xref:System.Numerics.Matrix4x4.CreateConstrainedBillboardLeftHanded(System.Numerics.Vector3,System.Numerics.Vector3,System.Numerics.Vector3,System.Numerics.Vector3,System.Numerics.Vector3)?displayProperty=nameWithType>

### Tensor enhancements

The <xref:System.Numerics.Tensors> interface now includes a nongeneric interface, <xref:System.Numerics.Tensors.IReadOnlyTensor>, for operations like accessing <xref:System.Numerics.Tensors.IReadOnlyTensor.Lengths> and <xref:System.Numerics.Tensors.IReadOnlyTensor.Strides>. Slice operations no longer copy data, which improves performance. Additionally, you can access data nongenerically by boxing to `object` when performance isn't critical.

## Options validation

- [New AOT-safe constructor for `ValidationContext`](#new-aot-safe-constructor-for-validationcontext)

### New AOT-safe constructor for `ValidationContext`

The <xref:System.ComponentModel.DataAnnotations.ValidationContext> class, used during options validation, includes a new constructor overload that explicitly accepts the `displayName` parameter:

<xref:System.ComponentModel.DataAnnotations.ValidationContext.%23ctor(System.Object,System.String,System.IServiceProvider,System.Collections.Generic.IDictionary{System.Object,System.Object})>

The display name ensures AOT safety and enables its use in native builds without warnings.

## Diagnostics

- [Support for telemetry schema URLs in `ActivitySource` and `Meter`](#support-for-telemetry-schema-urls-in-activitysource-and-meter)
- [Out-of-proc trace support for Activity events and links](#out-of-proc-trace-support-for-activity-events-and-links)
- [Rate-limit trace-sampling support](#rate-limit-trace-sampling-support)

### Support for telemetry schema URLs in `ActivitySource` and `Meter`

<xref:System.Diagnostics.ActivitySource> and <xref:System.Diagnostics.Metrics.Meter> now support specifying a telemetry schema URL during construction, which aligns with OpenTelemetry specifications. The telemetry schema ensures consistency and compatibility for tracing and metrics data. Additionally, .NET 10 introduces <xref:System.Diagnostics.ActivitySourceOptions>, which simplifies the creation of <xref:System.Diagnostics.ActivitySource> instances with multiple configuration options (including the [telemetry schema URL](xref:System.Diagnostics.ActivitySourceOptions.TelemetrySchemaUrl)).

The new APIs are:

- <xref:System.Diagnostics.ActivitySource.%23ctor(System.Diagnostics.ActivitySourceOptions)>
- <xref:System.Diagnostics.ActivitySource.TelemetrySchemaUrl?displayProperty=nameWithType>
- <xref:System.Diagnostics.Metrics.Meter.TelemetrySchemaUrl?displayProperty=nameWithType>
- <xref:System.Diagnostics.ActivitySourceOptions>

### Out-of-proc trace support for Activity events and links

The <xref:System.Diagnostics.Activity> class enables distributed tracing by tracking the flow of operations across services or components. .NET supports serializing this tracing data out-of-process via the `Microsoft-Diagnostics-DiagnosticSource` event source provider. An `Activity` can include additional metadata such as <xref:System.Diagnostics.ActivityLink> and <xref:System.Diagnostics.ActivityEvent>. .NET 10 adds support for serializing these links and events, so out-of-proc trace data now includes that information. For example:

```txt
Events->"[(TestEvent1,​2025-03-27T23:34:10.6225721+00:00,​[E11:​EV1,​E12:​EV2]),​(TestEvent2,​2025-03-27T23:34:11.6276895+00:00,​[E21:​EV21,​E22:​EV22])]"
Links->"[(19b6e8ea216cb2ba36dd5d957e126d9f,​98f7abcb3418f217,​Recorded,​null,​false,​[alk1:​alv1,​alk2:​alv2]),​(2d409549aadfdbdf5d1892584a5f2ab2,​4f3526086a350f50,​None,​null,​false)]"
```

### Rate-limit trace-sampling support

When distributed tracing data is serialized out-of-process via the `Microsoft-Diagnostics-DiagnosticSource` event source provider, all recorded activities can be emitted, or sampling can be applied based on a trace ratio.

A new sampling option called **Rate Limiting Sampling** restricts the number of *root activities* serialized per second. This helps control data volume more precisely.

Out-of-proc trace data aggregators can enable and configure this sampling by specifying the option in [`FilterAndPayloadSpecs`](https://github.com/dotnet/runtime/blob/fb7050d93ea03854d469bb5f84c1f2addcd9e992/src/libraries/System.Diagnostics.DiagnosticSource/src/System/Diagnostics/DiagnosticSourceEventSource.cs#L43). For example, the following setting limits serialization to 100 root activities per second across all `ActivitySource` instances:

```txt
[AS]*/-ParentRateLimitingSampler(100)
```

## ZIP files

- [ZipArchive performance and memory improvements](#ziparchive-performance-and-memory-improvements)
- [New async ZIP APIs](#new-async-zip-apis)
- [Performance improvement in GZipStream for concatenated streams](#performance-improvement-in-gzipstream-for-concatenated-streams)

### ZipArchive performance and memory improvements

.NET 10 improves the performance and memory usage of <xref:System.IO.Compression.ZipArchive>.

First, the way entries are written to a `ZipArchive` when in `Update` mode has been optimized. Previously, all <xref:System.IO.Compression.ZipArchiveEntry> instances were loaded into memory and rewritten, which could lead to high memory usage and performance bottlenecks. The optimization reduces memory usage and improves performance by avoiding the need to load all entries into memory. For more information, see [dotnet/runtime#102704](https://github.com/dotnet/runtime/pull/102704).

Second, the extraction of <xref:System.IO.Compression.ZipArchive> entries is now parallelized, and internal data structures are optimized for better memory usage. These improvements address issues related to performance bottlenecks and high memory usage, making `ZipArchive` more efficient and faster, especially when dealing with large archives. For more information, see [dotnet/runtime#103153](https://github.com/dotnet/runtime/pull/103153#issue-2339713028).

### New async ZIP APIs

.NET 10 introduces new asynchronous APIs that make it easier to perform non-blocking operations when reading from or writing to ZIP files. This feature was highly requested by the community.

New `async` methods are available for extracting, creating, and updating ZIP archives. These methods enable developers to efficiently handle large files and improve application responsiveness, especially in scenarios involving I/O-bound operations. These methods include:

- <xref:System.IO.Compression.ZipArchive.CreateAsync(System.IO.Stream,System.IO.Compression.ZipArchiveMode,System.Boolean,System.Text.Encoding,System.Threading.CancellationToken)?displayProperty=nameWithType>
- <xref:System.IO.Compression.ZipArchiveEntry.OpenAsync(System.Threading.CancellationToken)?displayProperty=nameWithType>
- <xref:System.IO.Compression.ZipFile.CreateFromDirectoryAsync*?displayProperty=nameWithType>
- <xref:System.IO.Compression.ZipFile.ExtractToDirectoryAsync*?displayProperty=nameWithType>
- <xref:System.IO.Compression.ZipFile.OpenAsync*?displayProperty=nameWithType>
- <xref:System.IO.Compression.ZipFile.OpenReadAsync(System.String,System.Threading.CancellationToken)?displayProperty=nameWithType>
- <xref:System.IO.Compression.ZipFileExtensions.CreateEntryFromFileAsync*?displayProperty=nameWithType>
- <xref:System.IO.Compression.ZipFileExtensions.ExtractToDirectoryAsync*?displayProperty=nameWithType>
- <xref:System.IO.Compression.ZipFileExtensions.ExtractToFileAsync*?displayProperty=nameWithType>

For examples of using these APIs, see [the Preview 4 blog post](https://github.com/dotnet/core/blob/main/release-notes/10.0/preview/preview4/libraries.md#new-async-zip-apis).

### Performance improvement in GZipStream for concatenated streams

A community contribution improved the performance of <xref:System.IO.Compression.GZipStream> when processing concatenated GZip data streams. Previously, each new stream segment disposed and reallocated the internal `ZLibStreamHandle`, which resulted in additional memory allocations and initialization overhead. With this change, the handle is now reset and reused to reduce both managed and unmanaged memory allocations and improve execution time. The largest impact (~35% faster) is seen when processing a large number of small data streams. This change:

- Eliminates repeated allocation of ~64-80 bytes of memory per concatenated stream, with additional unmanaged memory savings.
- Reduces execution time by approximately 400 ns per concatenated stream.
