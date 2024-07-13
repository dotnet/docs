---
title: What's new in .NET libraries for .NET 9
description: Learn about the new .NET libraries features introduced in .NET 9.
titleSuffix: ""
ms.date: 07/11/2024
ms.topic: whats-new
---
# What's new in .NET libraries for .NET 9

This article describes new features in the .NET libraries for .NET 9. It's been updated for .NET 9 Preview 6.

## Base64Url

Base64 is an encoding scheme that translates arbitrary bytes into text composed of a specific set of 64 characters. It's a very common approach for transferring data and has long been supported via a variety of methods, such as with <xref:System.Convert.ToBase64String%2A?displayProperty=nameWithType> or <xref:System.Buffers.Text.Base64.DecodeFromUtf8(ReadOnlySpan{System.Byte},System.Span{System.Byte},System.Int32,System.Int32,System.Boolean)?displayProperty=nameWithType>. However, some of the characters it uses makes it less than ideal for use in some circumstances you might otherwise want to use it, such as in query strings. In particular, the 64 characters that comprise the Base64 table include '+' and '/', both of which have their own meaning in URLs. This led to the creation of the Base64Url scheme, which is similar to Base64 but uses a slightly different set of characters that makes it appropriate for use in URLs contexts. .NET 9 includes the new `Base64Url` <!--<xref:System.Buffers.Text.Base64>--> class, which provides many helpful and optimized methods for encoding and decoding with `Base64Url` to and from a variety of data types.

The following example demonstrates using the new class.

```csharp
ReadOnlySpan<byte> bytes = ...;
string encoded = Base64Url.EncodeToString(bytes);
```

## Collections

The collection types in .NET gain the following updates for .NET 9:

- [Collection lookups with spans](#collection-lookups-with-spans)
- [`OrderedDictionary<TKey, TValue>`](#ordereddictionarytkey-tvalue)
- [PriorityQueue.Remove() method](#priorityqueueremove-method) lets you update the priority of an item in the queue.

### Collection lookups with spans

In high-performance code, spans are often used to avoid allocating strings unnecessarily, and lookup tables with types like <xref:System.Collections.Generic.Dictionary%602> and <xref:System.Collections.Generic.HashSet%601> are frequently used as caches. However, it's been challenging to use these types together, as there was no safe, built-in mechanism for doing lookups on these types with spans. Now with the new `allows ref struct` feature in C# 13 and new features on these collection types in .NET 9, it's possible to perform these kinds of lookups.

The following example demonstrates using `Dictionary<TKey, TValue>.GetAlternateLookup` <!--<xref:System.Collections.Generic.Dictionary%602.GetAlternateLookup?displayProperty=nameWithType>-->.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Collections.cs" id="AlternateLookup":::

### `OrderedDictionary<TKey, TValue>`

In many scenarios, you might want to store key-value pairs in a way where order can be maintained (a list of key-value pairs) but where fast lookup by key is also supported (a dictionary of key-value pairs). Since the early days of .NET, the <xref:System.Collections.Specialized.OrderedDictionary> type has supported this scenario, but only in a non-generic manner, with keys and values typed as `object`. .NET 9 introduces the long-requested `OrderedDictionary<TKey, TValue>` <!--<xref:System.Collections.Generic.OrderedDictionary%602>--> collection, which provides an efficient, generic type to support these scenarios.

The following code uses the new class.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Collections.cs" id="OrderedDictionary":::

### PriorityQueue.Remove() method

.NET 6 introduced the <xref:System.Collections.Generic.PriorityQueue%602> collection, which provides a simple and fast array-heap implementation. One issue with array heaps in general is that they [don't support priority updates](https://github.com/dotnet/runtime/issues/44871), which makes them prohibitive for use in algorithms such as variations of [Dijkstra's algorithm](https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#Using_a_priority_queue).

While it's not possible to implement efficient $O(\log n)$ priority updates in the existing collection, the new <xref:System.Collections.Generic.PriorityQueue%602.Remove(%600,%600@,%601@,System.Collections.Generic.IEqualityComparer{%600})?displayProperty=nameWithType> method makes it possible to emulate priority updates (albeit at $O(n)$ time):

:::code language="csharp" source="../snippets/dotnet-9/csharp/Collections.cs" id="UpdatePriority":::

This method unblocks users who want to implement graph algorithms in contexts where asymptotic performance isn't a blocker. (Such contexts include education and prototyping.) For example, here's a [toy implementation of Dijkstra's algorithm](https://github.com/dotnet/runtime/blob/16cb41496d595e2568574cfe11c763d5e05136c9/src/libraries/System.Collections/tests/Generic/PriorityQueue/PriorityQueue.Tests.Dijkstra.cs#L46-L76) that uses the new API.

### `ReadOnlySet<T>`

It's often desirable to give out read-only views of collections. <xref:System.Collections.ObjectModel.ReadOnlyCollection%601> lets you create a read-only wrapper around an arbitrary mutable <xref:System.Collections.Generic.IList%601>, and <xref:System.Collections.ObjectModel.ReadOnlyDictionary%602> lets you create a read-only wrapper around an arbitrary mutable <xref:System.Collections.Generic.IDictionary%602>. However, past versions of .NET had no built-in support for doing the same with <xref:System.Collections.Generic.ISet%601>. .NET 9 introduces `ReadOnlySet<T>` <!--<xref:System.Collections.Generic.ReadOnlySet%601>--> to address this.

The new class enables the following usage pattern.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Collections.cs" id="ReadOnlySet":::

## Component model

### `TypeDescriptor` trimming support

<xref:System.ComponentModel> includes new opt-in trimmer-compatible APIs for describing components. Any application, especially self-contained trimmed applications, can use these new APIs to help support trimming scenarios.

The primary API is the <xref:System.ComponentModel.TypeDescriptor.RegisterType%2A?displayProperty=nameWithType> method on the `TypeDescriptor` class. This method has the <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute> attribute so that the trimmer preserves members for that type. You should call this method once per type, and typically early on.

The secondary APIs have a `FromRegisteredType` suffix, such as <xref:System.ComponentModel.TypeDescriptor.GetPropertiesFromRegisteredType(System.Type)?displayProperty=nameWithType>. Unlike their counterparts that don't have the `FromRegisteredType` suffix, these APIs don't have `[RequiresUnreferencedCode]` or `[DynamicallyAccessedMembers]` trimmer attributes. The lack of trimmer attributes helps consumers by no longer having to either:

- Suppress trimming warnings, which can be risky.
- Propagate a strongly typed `Type` parameter to other methods, which can be cumbersome or infeasible.

:::code language="csharp" source="../snippets/dotnet-9/csharp/TypeDescriptor.cs" id="TypeDescriptor":::

For more information, see the [API proposal](https://github.com/dotnet/runtime/issues/101202).

## Cryptography

For cryptography, .NET 9 adds a new one-shot hash method on the <xref:System.Security.Cryptography.CryptographicOperations> type. It also adds new classes that use the KMAC algorithm.

### CryptographicOperations.HashData() method

.NET includes several static ["one-shot"](../../../standard/security/cryptography-model.md#one-shot-apis) implementations of hash functions and related functions. These APIs include <xref:System.Security.Cryptography.SHA256.HashData%2A?displayProperty=nameWithType> and <xref:System.Security.Cryptography.HMACSHA256.HashData%2A?displayProperty=nameWithType>. One-shot APIs are preferable to use because they can provide the best possible performance and reduce or eliminate allocations.

If a developer wants to provide an API that supports hashing where the caller defines which hash algorithm to use, it's typically done by accepting a <xref:System.Security.Cryptography.HashAlgorithmName> argument. However, using that pattern with one-shot APIs would require switching over every possible <xref:System.Security.Cryptography.HashAlgorithmName> and then using the appropriate method. To solve that problem, .NET 9 introduces the <xref:System.Security.Cryptography.CryptographicOperations.HashData%2A?displayProperty=nameWithType> API. This API lets you produce a hash or HMAC over an input as a one-shot where the algorithm used is determined by a <xref:System.Security.Cryptography.HashAlgorithmName>.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Cryptography.cs" id="HashData":::

### KMAC algorithm

.NET 9 provides the KMAC algorithm as specified by [NIST SP-800-185](https://csrc.nist.gov/pubs/sp/800/185/final). KECCAK Message Authentication Code (KMAC) is a pseudorandom function and keyed hash function based on KECCAK.

The following new classes use the KMAC algorithm. Use instances to accumulate data to produce a MAC, or use the static `HashData` method for a [one-shot](../../../standard/security/cryptography-model.md#one-shot-apis) over a single input.

- <xref:System.Security.Cryptography.Kmac128>
- <xref:System.Security.Cryptography.Kmac256>
- <xref:System.Security.Cryptography.KmacXof128>
- <xref:System.Security.Cryptography.KmacXof256>

KMAC is available on Linux with OpenSSL 3.0 or later, and on Windows 11 Build 26016 or later. You can use the static `IsSupported` property to determine if the platform supports the desired algorithm.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Cryptography.cs" id="Kmac":::

## Date and time

### New TimeSpan.From\* overloads

The <xref:System.TimeSpan> class offers several `From*` methods that let you create a `TimeSpan` object using a `double`. However, since `double` is a binary-based floating-point format, [inherent imprecision can lead to errors](https://github.com/dotnet/runtime/issues/93890). For instance, `TimeSpan.FromSeconds(101.832)` might not precisely represent `101 seconds, 832 milliseconds`, but rather approximately `101 seconds, 831.9999999999936335370875895023345947265625 milliseconds`. This discrepancy has caused frequent confusion, and it's also not the most efficient way to represent such data. To address this, .NET 9 adds new overloads that let you create `TimeSpan` objects from integers. There are new overloads from `FromDays`, `FromHours`, `FromMinutes`, `FromSeconds`, `FromMilliseconds`, and `FromMicroseconds`.

The following code shows an example of calling the `double` and one of the new integer overloads.

:::code language="csharp" source="../snippets/dotnet-9/csharp/TimeSpan.cs" id="TimeSpan.From":::

## Dependency injection

### `ActivatorUtilities.CreateInstance` constructor

The constructor resolution for <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance%2A?displayProperty=nameWithType> has changed in .NET 9. Previously, a constructor that was explicitly marked using the <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilitiesConstructorAttribute> attribute might not be called, depending on the ordering of constructors and the number of constructor parameters. The logic has changed in .NET 9 such that a constructor that has the attribute is always called.

## Diagnostics

### New Activity.AddLink method

Previously, you could only link a tracing <xref:System.Diagnostics.Activity> to other tracing contexts when you [created the `Activity`](xref:System.Diagnostics.ActivitySource.CreateActivity(System.String,System.Diagnostics.ActivityKind,System.Diagnostics.ActivityContext,System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}},System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink},System.Diagnostics.ActivityIdFormat)?displayProperty=nameWithType). New in .NET 9, the <xref:System.Diagnostics.Activity.AddLink(System.Diagnostics.ActivityLink)> API lets you link an `Activity` object to other tracing contexts after it's created. This change aligns with the [OpenTelemetry specifications](https://github.com/open-telemetry/opentelemetry-specification/blob/6360b49d20ae451b28f7ba0be168ed9a799ac9e1/specification/trace/api.md?plain=1#L804) as well.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Diagnostics.cs" id="AddLink":::

## Metrics.Gauge instrument

<xref:System.Diagnostics.Metrics> now provides the `Gauge` <!--<xref:<xref:System.Diagnostics.Metrics.Gauge>--> instrument according to the OpenTelemetry specification. The `Gauge` instrument is designed to record non-additive values when changes occur. For example, it can measure the background noise level, where summing the values from multiple rooms would be nonsensical. The `Gauge` instrument is a generic type that can record any value type, such as `int`, `double`, or `decimal`.

The following example demonstrates using the the `Gauge` instrument.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Diagnostics.cs" id="Gauge":::

## LINQ

New methods <xref:System.Linq.Enumerable.CountBy%2A> and <xref:System.Linq.Enumerable.AggregateBy%2A> have been introduced. These methods make it possible to aggregate state by key without needing to allocate intermediate groupings via <xref:System.Linq.Enumerable.GroupBy%2A>.

<xref:System.Linq.Enumerable.CountBy%2A> lets you quickly calculate the frequency of each key. The following example finds the word that occurs most frequently in a text string.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Linq.cs" id="CountBy":::

<xref:System.Linq.Enumerable.AggregateBy%2A> lets you implement more general-purpose workflows. The following example shows how you can calculate scores that are associated with a given key.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Linq.cs" id="AggregateBy":::

<xref:System.Linq.Enumerable.Index%60%601(System.Collections.Generic.IEnumerable{%60%600})> makes it possible to quickly extract the implicit index of an enumerable. You can now write code such as the following snippet to automatically index items in a collection.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Linq.cs" id="NewIndex":::

## Logging source generator

C# 12 introduced [primary constructors](../../../csharp/programming-guide/classes-and-structs/instance-constructors.md#primary-constructors), which allow you to define a constructor directly on the class declaration. The logging source generator now supports logging using classes that have a primary constructor.

```csharp
public partial class ClassWithPrimaryConstructor(ILogger logger)
{
    [LoggerMessage(0, LogLevel.Debug, "Test.")]
    public partial void Test();
}
```

## Miscellaneous

In this section, find information about:

- [`allows ref struct` used in libraries](#allows-ref-struct-used-in-libraries)
- [`SearchValues` expansion](#searchvalues-expansion)

### `allows ref struct` used in libraries

C# 13 introduces the ability to constrain a generic parameter with `allows ref struct`, which tells the compiler and runtime that a `ref struct` can be used for that generic parameter. Many APIs that are compatible with this have now been annotated. For example, the <xref:System.String.Create%2A?displayProperty=nameWithType> method has an overload that lets you create a `string` by writing directly into its memory, represented as a span. This method has a `TState` argument that's passed from the caller into the delegate that does the actual writing.

That `TState` type parameter on `String.Create` is now annotated with `allows ref struct`:

```csharp
public static string Create<TState>(int length, TState state, SpanAction<char, TState> action)
    where TState : allows ref struct;
```

This annotation enables you to pass a span (or any other `ref struct`) as input to this method.

The following example shows a new <xref:System.String.ToLowerInvariant?displayProperty=nameWithType> overload that uses this capability.

```csharp
public static string ToLowerInvariant(ReadOnlySpan<char> input) =>
    string.Create(span.Length, input, static (stringBuffer, input) => span.ToLowerInvariant(stringBuffer));
```

### `SearchValues` expansion

.NET 8 introduced the <xref:System.Buffers.SearchValues%601> type, which provides an optimized solution for searching for specific sets of characters or bytes within spans. In .NET 9, `SearchValues` has been extended to support searching for substrings within a larger string.

The following example searches for multiple animal names within a string value, and returns an index to the first one found.

:::code language="csharp" source="../snippets/dotnet-9/csharp/SearchValues.cs" id="SV":::

This new capability has an optimized implementation that takes advantage of the SIMD support in the underlying platform. It also enables higher-level types to be optimized. For example, <xref:System.Text.RegularExpressions.Regex> now utilizes this functionality as part of its implementation.

## Networking

The networking area includes in the following updates in .NET 9:

- [SocketsHttpHandler is default in HttpClientFactory](#socketshttphandler-is-default-in-httpclientfactory)
- [System.Net.ServerSentEvents](#systemnetserversentevents)
- [TLS resume with client certificates on Linux](#tls-resume-with-client-certificates-on-linux)

### SocketsHttpHandler is default in HttpClientFactory

`HttpClientFactory` creates <xref:System.Net.Http.HttpClient> objects backed by <xref:System.Net.Http.HttpClientHandler>, by default. `HttpClientHandler` is itself backed by <xref:System.Net.Http.SocketsHttpHandler>, which is much more configurable, including around connection lifetime management. `HttpClientFactory` now uses `SocketsHttpHandler` by default and configures it to set limits on its connection lifetimes to match that of the rotation lifetime specified in the factory.

### System.Net.ServerSentEvents

Server-sent events (SSE) is a simple and popular protocol for streaming data from a server to a client. It's used, for example, by OpenAI as part of streaming generated text from its AI services. To simplify the consumption of SSE, the new `System.Net.ServerSentEvents` <!--<xref:System.Net.ServerSentEvents>--> library provides a parser for easily ingesting server-sent events.

The following code demonstrates using the new class.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Networking.cs" id="SseParser":::

### TLS resume with client certificates on Linux

*TLS resume* is a feature of the TLS protocol that allows resuming previously established sessions to a server. Doing so avoids a few roundtrips and saves computational resources during TLS handshake.

*TLS resume* has already been supported on Linux for SslStream connections without client certificates. .NET 9 adds support for TLS resume of mutually authenticated TLS connections, which are common in server-to-server scenarios. The feature is enabled automatically.

## Reflection

The reflection area includes the following updates for .NET 9:

- [Persisted assemblies](#persisted-assemblies)
- [Type-name parsing](#type-name-parsing)

### Persisted assemblies

In .NET Core versions and .NET 5-8, support for building an assembly and emitting reflection metadata for dynamically created types was limited to a runnable <xref:System.Reflection.Emit.AssemblyBuilder>. The lack of support for *saving* an assembly was often a blocker for customers migrating from .NET Framework to .NET. .NET 9 adds a new type, <xref:System.Reflection.Emit.PersistedAssemblyBuilder>, that you can use to save an emitted assembly.

To create a `PersistedAssemblyBuilder` instance, call its constructor and pass the assembly name, the core assembly, `System.Private.CoreLib`, to reference base runtime types, and optional custom attributes. After you emit all members to the assembly, call the <xref:System.Reflection.Emit.PersistedAssemblyBuilder.Save(System.String)?displayProperty=nameWithType> method to create an assembly with default settings. If you want to set the entry point or other options, you can call <xref:System.Reflection.Emit.PersistedAssemblyBuilder.GenerateMetadata%2A?displayProperty=nameWithType> and use the metadata it returns to save the assembly. The following code shows an example of creating a persisted assembly and setting the entry point.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Reflection.cs" id="SaveAssembly":::

The new <xref:System.Reflection.Emit.PersistedAssemblyBuilder> class includes PDB support. You can emit symbol info and use it to debug a generated assembly. The API has a similar shape to the .NET Framework implementation. For more information, see [Emit symbols and generate PDB](../../../fundamentals/runtime-libraries/system-reflection-emit-persistedassemblybuilder.md#emit-symbols-and-generate-pdb).

### Type-name parsing

<xref:System.Reflection.Metadata.TypeName> is a parser for ECMA-335 type names that provides much the same functionality as <xref:System.Type?displayProperty=fullName> but is decoupled from the runtime environment. Components like serializers and compilers need to parse and process type names. For example, the Native AOT compiler has switched to using <xref:System.Reflection.Metadata.TypeName>.

The new `TypeName` class provides:

- Static `Parse` and `TryParse` methods for parsing input represented as `ReadOnlySpan<char>`. Both methods accept an instance of `TypeNameParseOptions` class (an option bag) that lets you customize the parsing.
- `Name`, `FullName`, and `AssemblyQualifiedName` properties that work exactly like their counterparts in <xref:System.Type?displayProperty=fullName>.
- Multiple properties and methods that provide additional information about the name itself:

  - `IsArray`, `IsSZArray` (`SZ` stands for single-dimension, zero-indexed array), `IsVariableBoundArrayType`, and `GetArrayRank` for working with arrays.
  - `IsConstructedGenericType`, `GetGenericTypeDefinition`, and `GetGenericArguments` for working with generic type names.
  - `IsByRef` and `IsPointer` for working with pointers and managed references.
  - `GetElementType()` for working with pointers, references, and arrays.
  - `IsNested` and `DeclaringType` for working with nested types.
  - `AssemblyName`, which exposes the assembly name information via the new <xref:System.Reflection.Metadata.AssemblyNameInfo> class. In contrast to `AssemblyName`, the new type is *immutable*, and parsing culture names doesn't create instances of `CultureInfo`.

Both `TypeName` and `AssemblyNameInfo` types are immutable and don't provide a way to check for equality (they don't implement `IEquatable`). Comparing assembly names is simple, but different scenarios need to compare only a subset of exposed information (`Name`, `Version`, `CultureName`, and `PublicKeyOrToken`).

The following code snippet shows some example usage.

:::code language="csharp" source="../snippets/dotnet-9/csharp/TypeName.cs":::

The new APIs are available from the [`System.Reflection.Metadata`](https://www.nuget.org/packages/System.Reflection.Metadata/) NuGet package, which can be used with down-level .NET versions.

## Regular expressions

For regular expressions, .NET 9 includes the following updates:

- [`[GeneratedRegex]` on properties](#generatedregex-on-properties)
- [`Regex.EnumerateSplits`](#regexenumeratesplits)

### `[GeneratedRegex]` on properties

.NET 7 introduced the `Regex` source generator and corresponding <xref:System.Text.RegularExpressions.GeneratedRegexAttribute> attribute.

The following partial method will be source generated with all the code necessary to implement this `Regex`.

:::code language="csharp" source="../snippets/dotnet-9/csharp/RegularExpressions.cs" id="GeneratedRegexMethod":::

C# 13 supports partial *properties* in addition to partial methods, so starting in .NET 9 you can also use `[GeneratedRegex(...)]` on a property.

The following partial property is the property equivalent of the previous example.

:::code language="csharp" source="../snippets/dotnet-9/csharp/RegularExpressions.cs" id="GeneratedRegexProperty":::

### `Regex.EnumerateSplits`

The <xref:System.Text.RegularExpressions.Regex> class provides a <xref:System.Text.RegularExpressions.Regex.Split%2A> method, similar in concept to the <xref:System.String.Split%2A?displayProperty=nameWithType> method. With `String.Split`, you supply one or more `char` or `string` separators, and the implementation splits the input text on those separators. With `Regex.Split`, instead of specifying the separator as a `char` or `string`, it's specified as a regular expression pattern.

The following example demonstrates `Regex.Split`.

:::code language="csharp" source="../snippets/dotnet-9/csharp/RegularExpressions.cs" id="RegexSplit":::

However, `Regex.Split` only accepts a `string` as input and doesn't support input being provided as a `ReadOnlySpan<char>`. Also, it outputs the full set of splits as a `string[]`, which requires allocating both the `string` array to hold the results and a `string` for each split. In .NET 9, the new `EnumerateSplits` <!--<xref:System.Text.RegularExpressions.Regex.EnumerateSplits%2A>--> method enables performing the same operation, but with a span-based input and without incurring any allocation for the results. It accepts a `ReadOnlySpan<char>` and returns an enumerable of <xref:System.Range> objects that represent the results.

The following example demonstrates `Regex.EnumerateSplits`, taking a `ReadOnlySpan<char>` as input.

:::code language="csharp" source="../snippets/dotnet-9/csharp/RegularExpressions.cs" id="EnumerateSplits":::

## Serialization

In <xref:System.Text.Json>, .NET 9 includes the following updates:

- [Indentation options](#indentation-options)
- [Default web options singleton](#default-web-options-singleton)
- [JsonSchemaExporter](#jsonschemaexporter)
- [Respect nullable annotations](#respect-nullable-annotations)
- [Require non-optional constructor parameters](#require-non-optional-constructor-parameters)
- [Order JsonObject properties](#order-jsonobject-properties)
- [Additional contract metadata APIs](#additional-contract-metadata-apis)

### Indentation options

<xref:System.Text.Json.JsonSerializerOptions> includes new properties that let you customize the indentation character and indentation size of written JSON.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="Indentation":::

### Default web options singleton

If you want to serialize with the [default options that ASP.NET Core uses](../../../standard/serialization/system-text-json/configure-options.md#web-defaults-for-jsonserializeroptions) for web apps, use the new <xref:System.Text.Json.JsonSerializerOptions.Web?displayProperty=nameWithType> singleton.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="Web":::

### JsonSchemaExporter

JSON is frequently used to represent types in method signatures as part of remote procedure&ndash;calling schemes. It's used, for example, as part of OpenAPI specifications, or as part of tool calling with AI services like those from OpenAI. Developers can serialize and deserialize .NET types as JSON using <xref:System.Text.Json>. But they also need to be able to get a JSON schema that describes the shape of the .NET type (that is, describes the shape of what would be serialized and what can be deserialized). <xref:System.Text.Json> now provides the `JsonSchemaExporter` <!--<xref:System.Text.Json.Schema.JsonSchemaExporter>--> type, which supports generating a JSON schema that represents a .NET type.

The following code generates a JSON schema from a type.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="Schema":::

The type is defined as follows:

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="Book":::

The generated schema is:

```json
{
  "type": [
    "object",
    "null"
  ],
  "properties": {
    "Title": {
      "type": "string"
    },
    "Author": {
      "type": [
        "string",
        "null"
      ]
    },
    "PublishYear": {
      "type": "integer"
    }
  }
}
```

### Respect nullable annotations

<xref:System.Text.Json> now recognizes nullability annotations of properties and can be configured to enforce those during serialization and deserialization using the `RespectNullableAnnotations` <!--<xref:System.Text.Json.JsonSerializerOptions.RespectNullableAnnotations>--> flag.

The following code shows how to set the option (the `Book` type definition is shown in the previous section):

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="RespectNullable":::

You can also enable this setting globally using the `System.Text.Json.JsonSerializerOptions.RespectNullableAnnotations` feature switch in your project file (for example, *.csproj* file):

```xml
<ItemGroup>
  <RuntimeHostConfigurationOption Include="System.Text.Json.JsonSerializerOptions.RespectNullableAnnotations" Value="true" />
</ItemGroup>
```

You can configure nullability at an individual property level using the `JsonPropertyInfo.IsGetNullable` <!--<xref:System.Text.Json.Serialization.Metadata.JsonPropertyInfo.IsGetNullable>--> and `JsonPropertyInfo.IsSetNullable` <!--<xref:System.Text.Json.Serialization.Metadata.JsonPropertyInfo.IsSetNullable>--> properties.

### Require non-optional constructor parameters

Historically, <xref:System.Text.Json> has treated non-optional constructor parameters as optional when using constructor-based deserialization. You can change that behavior using the new `RespectRequiredConstructorParameters` <!--<xref:System.Text.Json.JsonSerializerOptions.RespectRequiredConstructorParameters>--> flag.

The following code shows how to set the option:

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="RespectRequired":::

The `MyPoco` type is defined as follows:

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="Poco":::

You can also enable this setting globally using the `System.Text.Json.JsonSerializerOptions.RespectNullableAnnotations` feature switch in your project file (for example, *.csproj* file):

```xml
<ItemGroup>
  <RuntimeHostConfigurationOption Include="System.Text.Json.JsonSerializerOptions.RespectRequiredConstructorParameters" Value="true" />
</ItemGroup>
```

As with earlier versions of <xref:System.Text.Json>, you can configure whether individual properties are required using the <xref:System.Text.Json.Serialization.Metadata.JsonPropertyInfo.IsRequired?displayProperty=nameWithType> property.

### Order JsonObject properties

The <System.Json.JsonObject> type now exposes ordered dictionary&ndash;like APIs that enable explicit property order manipulation.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="PropertyOrder":::

### Additional contract metadata APIs

The JSON contract API now exposes additional metadata including constructor metadata information and improved attribute provider support for the case of the source generator.

The new APIs have the following shape:

```csharp
namespace System.Text.Json.Serialization.Metadata;

public partial class JsonTypeInfo
{
    // Typically the ConstructorInfo of the active deserialization constructor.
    public ICustomAttributeProvider? ConstructorAttributeProvider { get; }
}

public partial class JsonPropertyInfo
{
    public Type DeclaringType { get; }
    // Typically the FieldInfo or PropertyInfo of the property.
    public ICustomAttributeProvider? AttributeProvider { get; set; }
    // The constructor parameter that has been associated with the current property.
    public JsonParameterInfo? AssociatedParameter { get; }
}

public sealed class JsonParameterInfo
{
    public Type DeclaringType { get; }
    public int Position { get; }
    public Type ParameterType { get; }
    public bool HasDefaultValue { get; }
    public object? DefaultValue { get; }
    public bool IsNullable { get; }
    // Typically the ParameterInfo of the parameter.
    public ICustomAttributeProvider? AttributeProvider { get; }
}
```

## Spans

In high-performance code, spans are often used to avoid allocating strings unnecessarily. <xref:System.Span%601> and <xref:System.ReadOnlySpan%601> continue to revolutionize how code is written in .NET, and every release more and more methods are added that operate on spans. .NET 9 includes the following span-related updates:

- [File helpers](#file-helpers)
- [`params ReadOnlySpan<T>` overloads](#params-readonlyspant-overloads)

### File helpers

The <xref:System.IO.File> class now has new helpers to easily and directly write `ReadOnlySpan<char>`/`ReadOnlySpan<byte>` and `ReadOnlyMemory<char>`/`ReadOnlyMemory<byte>` to files.

The following code efficiently writes a `ReadOnlySpan<char>` to a file.

```csharp
ReadOnlySpan<char> text = ...;
File.WriteAllText(filePath, text);
```

New `ReadOnlySpan.StartsWith` <!--<xref:System.ReadOnlySpan.StartsWith%2A>--> and `ReadOnlySpan.EndsWith` <!--<xref:System.ReadOnlySpan.EndsWith%2A>--> extension methods have also been added for spans, making it easy to test whether a <xref:System.ReadOnlySpan%601> starts or ends with a specific `T` value.

The following code uses these new convenience APIs.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Spans.cs" id="StartsWith":::

### `params ReadOnlySpan<T>` overloads

C# has always supported marking array parameters as [`params`](../../../csharp/language-reference/keywords/method-parameters.md#params-modifier). This keyword enables a simplified calling syntax. For example, the <xref:System.String.Join(System.String,System.String[])?displayProperty=nameWithType> method's second parameter is marked with `params`. You can call this overload with an array or by passing the values individually:

```csharp
string result = string.Join(", ", new string[3] { "a", "b", "c" });
string result = string.Join(", ", "a", "b", "c");
```

Prior to .NET 9, when you pass the values individually, the C# compiler emits code identical to the first call by producing an implicit array around the three arguments.

Starting in C# 13, you can use `params` with any argument that can be constructed via a collection expression, including spans (<xref:System.Span%601> and <xref:System.ReadOnlySpan%601>). That's beneficial for usability and performance. The C# compiler can store the arguments on the stack, wrap a span around them, and pass that off to the method, which avoids the implicit array allocation that would have otherwise resulted.

.NET 9 includes over 60 methods with a `params ReadOnlySpan<T>` parameter. Some are brand new overloads, and some are existing methods that already took a `ReadOnlySpan<T>` but now have that parameter marked with `params`. The net effect is if you upgrade to .NET 9 and recompile your code, you'll see performance improvements without making any code changes. That's because the compiler prefers to bind to span-based overloads than to the array-based overloads.

For example, `String.Join` now includes the following overload, which implements the new pattern: <xref:System.String.Join(System.String,System.ReadOnlySpan{System.String})?displayProperty=nameWithType>

Now, a call like `string.Join(", ", "a", "b", "c")` is made without allocating an array to pass in the `"a"`, `"b"`, and `"c"` arguments.

## System.Numerics

The following changes have been made in the <xref:System.Numerics> namespace:

- [BigInteger upper limit](#biginteger-upper-limit)
- [`BigMul` APIs](#bigmul-apis)
- [Vector conversion APIs](#vector-conversion-apis)
- [Vector create APIs](#vector-create-apis)
- [Additional acceleration](#additional-acceleration)

### BigInteger upper limit

<xref:System.Numerics.BigInteger> supports representing integer values of essentially arbitrary length. However, in practice, the length is constrained by limits of the underlying computer, such as available memory or how long it would take to compute a given expression. Additionally, there exist some APIs that fail given inputs that result in a value that's too large. Because of these limits, .NET 9 enforces a maximum length of `BigInteger`, which is that it can contain no more than `(2^31) - 1` (approximately 2.14 billion) bits. Such a number represents an almost 256 MB allocation and contains approximately 646.5 million digits. This new limit ensures that all APIs exposed are well behaved and consistent while still allowing numbers that are far beyond most usage scenarios.

### `BigMul` APIs

`BigMul` is an operation that produces the full product of two numbers. .NET 9 adds dedicated `BigMul` APIs on `int`, `long`, `uint`, and `ulong` whose return type is the next larger [integer type](../../../csharp/language-reference/builtin-types/integral-numeric-types.md) than the parameter types.

<!--

The new APIs are:

- <xref:System.Int32.BigMul(System.Int32,System.Int32)> (returns `long`)
- <xref:System.Int64.BigMul(System.Int64,System.Int64)> (returns `Int128`)
- <xref:System.UInt32.BigMul(System.UInt32,System.UInt32)> (returns `ulong`)
- <xref:System.UInt64.BigMul(System.UInt64,System.UInt64)> (returns `UInt128`)

-->

### Vector conversion APIs

.NET 9 adds dedicated extension APIs for converting between <xref:System.Numerics.Vector2>, <xref:System.Numerics.Vector3>, <xref:System.Numerics.Vector4>, <xref:System.Numerics.Quaternion>, and <xref:System.Numerics.Plane>.

<!--

The new APIs are as follows:

- <xref:System.Numerics.Vector.AsPlane(System.Numerics.Vector4)>
- <xref:System.Numerics.Vector.AsQuaternion(System.Numerics.Vector4)>
- <xref:System.Numerics.Vector.AsVector2(System.Numerics.Vector4)>
- <xref:System.Numerics.Vector.AsVector3(System.Numerics.Vector4)>
- <xref:System.Numerics.Vector.AsVector4(System.Numerics.Plane)>
- <xref:System.Numerics.Vector.AsVector4(System.Numerics.Quaternion)>
- <xref:System.Numerics.Vector.AsVector4(System.Numerics.Vector2)>
- <xref:System.Numerics.Vector.AsVector4(System.Numerics.Vector3)>
- <xref:System.Numerics.Vector.AsVector4Unsafe(System.Numerics.Vector2)>
- <xref:System.Numerics.Vector.AsVector4Unsafe(System.Numerics.Vector3)>

-->

For same-sized conversions, such as between `Vector4`, `Quaternion`, and `Plane`, these conversions are zero cost. The same can be said for narrowing conversions, such as from `Vector4` to `Vector2` or `Vector3`. For widening conversions, such as from `Vector2` or `Vector3` to `Vector4`, there is the normal API, which initializes new elements to 0, and an `Unsafe` suffixed API that leaves these new elements undefined and therefore can be zero cost.

### Vector create APIs

There are new `Create` APIs exposed for <xref:System.Numerics.Vector%601>, <xref:System.Numerics.Vector2>, <xref:System.Numerics.Vector3>, and <xref:System.Numerics.Vector4> that parity the equivalent APIs exposed for the hardware vector types exposed in the <xref:System.Runtime.Intrinsics> namespace.

<!--

The new APIs are as follows:

- <xref:System.Numerics.Vector.Create%601(%601)>
- <xref:System.Numerics.Vector.Create%601(System.ReadOnlySpan%601)>
- <xref:System.Numerics.Vector2.Create(System.Single)>
- <xref:System.Numerics.Vector2.Create(System.Single,System.Single)>
- <xref:System.Numerics.Vector2.Create(System.ReadOnlySpan%601)>
- <xref:System.Numerics.Vector3.Create(System.Single)>
- <xref:System.Numerics.Vector3.Create(System.Numerics.Vector2,System.Single)>
- <xref:System.Numerics.Vector3.Create(System.Single,System.Single,System.Single)>
- <xref:System.Numerics.Vector3.Create(System.ReadOnlySpan%601)>
- <xref:System.Numerics.Vector4.Create(System.Single)>
- <xref:System.Numerics.Vector4.Create(System.Numerics.Vector2,System.Single,System.Single)>
- <xref:System.Numerics.Vector4.Create(System.Numerics.Vector3,System.Single)>
- <xref:System.Numerics.Vector4.Create(System.Single,System.Single,System.Single,System.Single)>
- <xref:System.Numerics.Vector4.Create(System.ReadOnlySpan%601)>

-->

These APIs are primarily for convenience and overall consistency across .NET's SIMD-accelerated types.

### Additional acceleration

Additional performance improvements have been made to many types in the <xref:System.Numerics> namespace, including to <xref:System.Numerics.BigInteger>, <xref:System.Numerics.Vector2>, <xref:System.Numerics.Vector3>, <xref:System.Numerics.Vector4>, <xref:System.Numerics.Quaternion>, and <xref:System.Numerics.Plane>.

In some cases, this has resulted in a 2-5x speedup to core APIs including `Matrix4x4` multiplication, creation of <xref:System.Numerics.Plane> from a series of vertices, <xref:System.Numerics.Quaternion> concatenation, and computing the cross product of a <xref:System.Numerics.Vector3>.

There's also constant folding support for the `SinCos` API, which computes both `Sin(x)` and `Cos(x)` in a single call, making it more efficient.

## Tensors for AI

Tensors are the cornerstone data structure of artificial intelligence (AI). They can often be thought of as multidimensional arrays.

Tensors are used to:

- Represent and encode data such as text sequences (tokens), images, video, and audio.
- Efficiently manipulate higher-dimensional data.
- Efficiently apply computations on higher-dimensional data.
- Store weight information and intermediate computations (in neural networks).

To use the .NET tensor APIs, install the [System.Numerics.Tensors](https://www.nuget.org/packages/System.Numerics.Tensors/) NuGet package.

### New Tensor\<T> type

The new <xref:System.Numerics.Tensors.Tensor%601> type expands the AI capabilities of the .NET libraries and runtime. This type:

- Provides efficient interop with AI libraries like ML.NET, TorchSharp, and ONNX Runtime using zero copies where possible.
- Builds on top of <xref:System.Numerics.Tensors.TensorPrimitives> for efficient math operations.
- Enables easy and efficient data manipulation by providing indexing and slicing operations.
- Is not a replacement for existing AI and machine learning libraries. Instead, it's intended to provide a common set of APIs to reduce code duplication and dependencies, and to achieve better performance by using the latest runtime features.

The following codes shows some of the APIs included with the new `Tensor<T>` type.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Tensors.cs" id="Tensor":::

### TensorPrimitives

The `System.Numerics.Tensors` library includes the <xref:System.Numerics.Tensors.TensorPrimitives> class, which provides static methods for performing numerical operations on spans of values. In .NET 9, the scope of methods exposed by <xref:System.Numerics.Tensors.TensorPrimitives> has been significantly expanded, growing from 40 (in .NET 8) to almost 200 overloads. The surface area encompasses familiar numerical operations from types like <xref:System.Math> and <xref:System.MathF>. It also includes the generic math interfaces like <xref:System.Numerics.INumber%601>, except instead of processing an individual value, they process a span of values. Many operations have also been accelerated via SIMD-optimized implementations for .NET 9.

<xref:System.Numerics.Tensors.TensorPrimitives> now exposes generic overloads for any type `T` that implements a certain interface. (The .NET 8 version only included overloads for manipulating spans of `float` values.) For example, the new <xref:System.Numerics.Tensors.TensorPrimitives.CosineSimilarity%60%601(System.ReadOnlySpan{%60%600},System.ReadOnlySpan{%60%600})> overload performs cosine similarity on two vectors of `float`, `double`, or `Half` values, or values of any other type that implements <xref:System.Numerics.IRootFunctions%601>.

Compare the precision of the cosine similarity operation on two vectors of type `float` versus `double`:

:::code language="csharp" source="../snippets/dotnet-9/csharp/Tensors.cs" id="CosineSimilarity":::

## Threading

The threading APIs include improvements for iterating through tasks, and for prioritized channels, which can order their elements instead of being first-in-first-out (FIFO).

### `Task.WhenEach`

A variety of helpful new APIs have been added for working with <xref:System.Threading.Tasks.Task%601> objects. The new <xref:System.Threading.Tasks.Task.WhenEach%2A?displayProperty=nameWithType> method lets you iterate through tasks as they complete using an `await foreach` statement. You no longer need to do things like repeatedly call <xref:System.Threading.Tasks.Task.WaitAny%2A?displayProperty=nameWithType> on a set of tasks to pick off the next one that completes.

The following code makes multiple `HttpClient` calls and operates on their results as they complete.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Task.cs" id="TaskWhenEach":::

### Prioritized unbounded channel

The <xref:System.Threading.Channels> namespace lets you create first-in-first-out (FIFO) channels using the <xref:System.Threading.Channels.Channel.CreateBounded%2A> and <xref:System.Threading.Channels.Channel.CreateUnbounded%2A> methods. With FIFO channels, elements are read from the channel in the order they were written to it. In .NET 9, the new <xref:System.Threading.Channels.Channel.CreateUnboundedPrioritized%2A> method has been added, which orders the elements such that the next element read from the channel is the one deemed to be most important, according to either <xref:System.Collections.Generic.Comparer%601.Default?displayProperty=nameWithType> or a custom <xref:System.Collections.Generic.IComparer%601>.

The following example uses the new method to create a channel that outputs the numbers 1 through 5 in order, even though they're written to the channel in a different order.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Channels.cs" id="Channel":::
