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

## Find certificates by thumbprints other than SHA-1

Finding certificates uniquely by thumbprint is a fairly common operation, but the <xref:System.Security.Cryptography.X509Certificates.X509Certificate2Collection.Find(System.Security.Cryptography.X509Certificates.X509FindType,System.Object,System.Boolean)?displayProperty=nameWithType> method (for the <xref:System.Security.Cryptography.X509Certificates.X509FindType.FindByThumbprint> mode) only searches for the SHA-1 thumbprint value.

There's some risk to using the `Find` method for finding SHA-2-256 ("SHA256") and SHA-3-256 thumbprints since these hash algorithms have the same lengths.

Instead, .NET 10 introduces a [new method](xref:System.Security.Cryptography.X509Certificates.X509Certificate2Collection.FindByThumbprint*) that accepts the name of the hash algorithm to use for matching.

```csharp
X509Certificate2Collection coll = store.Certificates.FindByThumbprint(HashAlgorithmName.SHA256, thumbprint);
Debug.Assert(coll.Count < 2, "Collection has too many matches, has SHA-2 been broken?");
return coll.SingleOrDefault();
```

## Find PEM-encoded data in ASCII/UTF-8

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

## New method overloads in ISOWeek for DateOnly type

The <xref:System.Globalization.ISOWeek> class was originally designed to work exclusively with <xref:System.DateTime>, as it was introduced before the <xref:System.DateOnly> type existed. Now that `DateOnly` is available, it makes sense for `ISOWeek` to support it as well. The following overloads are new:

- <xref:System.Globalization.ISOWeek.GetWeekOfYear(System.DateOnly)>
- <xref:System.Globalization.ISOWeek.GetYear(System.DateOnly)>
- <xref:System.Globalization.ISOWeek.ToDateOnly(System.Int32,System.Int32,System.DayOfWeek)>

## String normalization APIs to work with span of characters

Unicode string normalization has been supported for a long time, but existing APIs only worked with the string type. This means that callers with data stored in different forms, such as character arrays or spans, must allocate a new string to use these APIs. Additionally, APIs that return a normalized string always allocate a new string to represent the normalized output.

.NET 10 introduces new APIs that work with spans of characters, which expand normalization beyond string types and help to avoid unnecessary allocations:

- <xref:System.StringNormalizationExtensions.GetNormalizedLength(System.ReadOnlySpan{System.Char},System.Text.NormalizationForm)?displayProperty=nameWithType>
- <xref:System.StringNormalizationExtensions.IsNormalized(System.ReadOnlySpan{System.Char},System.Text.NormalizationForm)?displayProperty=nameWithType>
- <xref:System.StringNormalizationExtensions.TryNormalize(System.ReadOnlySpan{System.Char},System.Span{System.Char},System.Int32@,System.Text.NormalizationForm)?displayProperty=nameWithType>

## Numeric ordering for string comparison

Numerical string comparison is a highly requested feature for comparing strings numerically instead of lexicographically. For example, `2` is less than `10`, so `"2"` should appear before `"10"` when ordered numerically. Similarly, `"2"` and `"02"` are equal numerically. With the new <xref:System.Globalization.CompareOptions.NumericOrdering> option, it's now possible to do these types of comparisons:

:::code language="csharp" source="../snippets/dotnet-10/csharp/snippets.cs" id="snippet_numericOrdering":::

This option isn't valid for the following index-based string operations: `IndexOf`, `LastIndexOf`, `StartsWith`, `EndsWith`, `IsPrefix`, and `IsSuffix`.

## New `TimeSpan.FromMilliseconds` overload with single parameter

The <xref:System.TimeSpan.FromMilliseconds(System.Int64,System.Int64)?displayProperty=nameWithType> method was introduced previously without adding an overload that takes a single parameter.

Although this works since the second parameter is optional, it causes a compilation error when used in a LINQ expression like:

```csharp
Expression<Action> a = () => TimeSpan.FromMilliseconds(1000);
```

The issue arises because LINQ expressions can't handle optional parameters. To address this, .NET 10 introduces [a new overload](xref:System.TimeSpan.FromMilliseconds(System.Int64)) takes a single parameter. It also modifies [the existing method](xref:System.TimeSpan.FromMilliseconds(System.Int64,System.Int64)) to make the second parameter mandatory.

## ZipArchive performance and memory improvements

.NET 10 improves the performance and memory usage of <xref:System.IO.Compression.ZipArchive>.

First, the way entries are written to a `ZipArchive` when in `Update` mode has been optimized. Previously, all <xref:System.IO.Compression.ZipArchiveEntry> instances were loaded into memory and rewritten, which could lead to high memory usage and performance bottlenecks. The optimization reduces memory usage and improves performance by avoiding the need to load all entries into memory. For more information, see [dotnet/runtime#102704](https://github.com/dotnet/runtime/pull/102704).

Second, the extraction of <xref:System.IO.Compression.ZipArchive> entries is now parallelized, and internal data structures are optimized for better memory usage. These improvements address issues related to performance bottlenecks and high memory usage, making `ZipArchive` more efficient and faster, especially when dealing with large archives. For more information, see [dotnet/runtime#103153](https://github.com/dotnet/runtime/pull/103153#issue-2339713028).

## Additional `TryAdd` and `TryGetValue` overloads for `OrderedDictionary<TKey, TValue>`

<xref:System.Collections.Generic.OrderedDictionary`2> provides `TryAdd` and `TryGetValue` for addition and retrieval like any other `IDictionary<TKey, TValue>` implementation. However, there are scenarios where you might want to perform more operations, so new overloads are added that return an index to the entry:

- <xref:System.Collections.Generic.OrderedDictionary`2.TryAdd(`0,`1,System.Int32@)>
- <xref:System.Collections.Generic.OrderedDictionary`2.TryGetValue(`0,`1@,System.Int32@)>

This index can then be used with <xref:System.Collections.Generic.OrderedDictionary`2.GetAt*> and <xref:System.Collections.Generic.OrderedDictionary`2.SetAt*> for fast access to the entry. An example usage of the new `TryAdd` overload is to add or update a key-value pair in the ordered dictionary:

:::code language="csharp" source="../snippets/dotnet-10/csharp/snippets.cs" id="snippet_getAtSetAt":::

This new API is already used in <xref:System.Json.JsonObject> and improves the performance of updating properties by 10-20%.

## Allow specifying ReferenceHandler in `JsonSourceGenerationOptions`

When you use [source generators for JSON serialization](../../../standard/serialization/system-text-json/source-generation.md), the generated context throws when cycles are serialized or deserialized. Now you can customize this behavior by specifying the <xref:System.Text.Json.Serialization.ReferenceHandler> in the <xref:System.Text.Json.Serialization.JsonSourceGenerationOptionsAttribute>. Here's an example using `JsonKnownReferenceHandler.Preserve`:

:::code language="csharp" source="../snippets/dotnet-10/csharp/snippets.cs" id="snippet_selfReference":::

## More left-handed matrix transformation methods

.NET 10 adds the remaining APIs for creating left-handed transformation matrices for billboard and constrained-billboard matrices. You can use these methods like their existing right-handed counterparts, for example, <xref:System.Numerics.Matrix4x4.CreateBillboard(System.Numerics.Vector3,System.Numerics.Vector3,System.Numerics.Vector3,System.Numerics.Vector3)>, when using a left-handed coordinate system instead:

- <xref:System.Numerics.Matrix4x4.CreateBillboardLeftHanded(System.Numerics.Vector3,System.Numerics.Vector3,System.Numerics.Vector3,System.Numerics.Vector3)?displayProperty=nameWithType>
- <xref:System.Numerics.Matrix4x4.CreateConstrainedBillboardLeftHanded(System.Numerics.Vector3,System.Numerics.Vector3,System.Numerics.Vector3,System.Numerics.Vector3,System.Numerics.Vector3)?displayProperty=nameWithType>

## Encryption algorithm for PKCS#12/PFX export

The new <xref:System.Security.Cryptography.X509Certificates.X509Certificate.ExportPkcs12*> methods on <xref:System.Security.Cryptography.X509Certificates.X509Certificate> allow callers to choose what encryption and digest algorithms are used to produce the output:

- <xref:System.Security.Cryptography.X509Certificates.Pkcs12ExportPbeParameters.Pkcs12TripleDesSha1?displayProperty=nameWithType> indicates the Windows XP-era de facto standard. It produces an output supported by almost every library and platform that supports reading PKCS#12/PFX by choosing an older encryption algorithm.
- <xref:System.Security.Cryptography.X509Certificates.Pkcs12ExportPbeParameters.Pbes2Aes256Sha256?displayProperty=nameWithType> indicates that AES should be used instead of 3DES (and SHA-2-256 instead of SHA-1), but the output might not be understood by all readers (such as Windows XP).

If you want even more control, you can use [the overload](xref:System.Security.Cryptography.X509Certificates.X509Certificate.ExportPkcs12(System.Security.Cryptography.PbeParameters,System.String)) that accepts a <xref:System.Security.Cryptography.PbeParameters>.

## New AOT-safe constructor for `ValidationContext`

The <xref:System.ComponentModel.DataAnnotations.ValidationContext> class, used during options validation, includes a new constructor overload that explicitly accepts the `displayName` parameter:

<xref:System.ComponentModel.DataAnnotations.ValidationContext.%23ctor(System.Object,System.String,System.IServiceProvider,System.Collections.Generic.IDictionary{System.Object,System.Object})>

The display name ensures AOT safety and enables its use in native builds without warnings.

## Support for telemetry schema URLs in `ActivitySource` and `Meter`

<xref:System.Diagnostics.ActivitySource> and <xref:System.Diagnostics.Metrics.Meter> now support specifying a telemetry schema URL during construction, which aligns with OpenTelemetry specifications. The telemetry schema ensures consistency and compatibility for tracing and metrics data. Additionally, .NET 10 introduces <xref:System.Diagnostics.ActivitySourceOptions>, which simplifies the creation of <xref:System.Diagnostics.ActivitySource> instances with multiple configuration options (including the [telemetry schema URL](xref:System.Diagnostics.ActivitySourceOptions.TelemetrySchemaUrl)).

The new APIs are:

- <xref:System.Diagnostics.ActivitySource.%23ctor(System.Diagnostics.ActivitySourceOptions)>
- <xref:System.Diagnostics.ActivitySource.TelemetrySchemaUrl?displayProperty=nameWithType>
- <xref:System.Diagnostics.Metrics.Meter.TelemetrySchemaUrl?displayProperty=nameWithType>
- <xref:System.Diagnostics.ActivitySourceOptions>

## Tensor enhancements

The <xref:System.Numerics.Tensors> interface now includes a nongeneric interface, <xref:System.Numerics.Tensors.IReadOnlyTensor>, for operations like accessing <xref:System.Numerics.Tensors.IReadOnlyTensor.Lengths> and <xref:System.Numerics.Tensors.IReadOnlyTensor.Strides>. Slice operations no longer copy data, which improves performance. Additionally, you can access data nongenerically by boxing to `object` when performance isn't critical.
