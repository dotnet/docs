---
title: What's new in .NET libraries for .NET 9
description: Learn about the new .NET libraries features introduced in .NET 9.
titleSuffix: ""
ms.date: 11/11/2024
ms.topic: whats-new
---

# What's new in .NET libraries for .NET 9

This article describes new features in the .NET libraries for .NET 9.

## Base64Url

Base64 is an encoding scheme that translates arbitrary bytes into text composed of a specific set of 64 characters. It's a common approach for transferring data and has long been supported via a variety of methods, such as with <xref:System.Convert.ToBase64String%2A?displayProperty=nameWithType> or <xref:System.Buffers.Text.Base64.DecodeFromUtf8(System.ReadOnlySpan{System.Byte},System.Span{System.Byte},System.Int32@,System.Int32@,System.Boolean)?displayProperty=nameWithType>. However, some of the characters it uses makes it less than ideal for use in some circumstances you might otherwise want to use it, such as in query strings. In particular, the 64 characters that comprise the Base64 table include '+' and '/', both of which have their own meaning in URLs. This led to the creation of the Base64Url scheme, which is similar to Base64 but uses a slightly different set of characters that makes it appropriate for use in URLs contexts. .NET 9 includes the new <xref:System.Buffers.Text.Base64Url> class, which provides many helpful and optimized methods for encoding and decoding with `Base64Url` to and from a variety of data types.

The following example demonstrates using the new class.

```csharp
ReadOnlySpan<byte> bytes = ...;
string encoded = Base64Url.EncodeToString(bytes);
```

## BinaryFormatter

.NET 9 removes <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> from the .NET runtime. The APIs are still present, but their implementations always throw an exception, regardless of project type. For more information about the removal and your options if you're affected, see [BinaryFormatter migration guide](../../../standard/serialization/binaryformatter-migration-guide/index.md).

## Collections

The collection types in .NET gain the following updates for .NET 9:

- [Collection lookups with spans](#collection-lookups-with-spans)
- [`OrderedDictionary<TKey, TValue>`](#ordereddictionarytkey-tvalue)
- [PriorityQueue.Remove() method](#priorityqueueremove-method) lets you update the priority of an item in the queue.
- [`ReadOnlySet<T>`](#readonlysett)

### Collection lookups with spans

In high-performance code, spans are often used to avoid allocating strings unnecessarily, and lookup tables with types like <xref:System.Collections.Generic.Dictionary%602> and <xref:System.Collections.Generic.HashSet%601> are frequently used as caches. However, there has been no safe, built-in mechanism for doing lookups on these collection types with spans. With the new `allows ref struct` feature in C# 13 and new features on these collection types in .NET 9, it's now possible to perform these kinds of lookups.

The following example demonstrates using [Dictionary<TKey,TValue>.GetAlternateLookup](xref:System.Collections.Generic.Dictionary`2.GetAlternateLookup``1).

:::code language="csharp" source="../snippets/dotnet-9/csharp/Collections.cs" id="AlternateLookup":::

### `OrderedDictionary<TKey, TValue>`

In many scenarios, you might want to store key-value pairs in a way where order can be maintained (a list of key-value pairs) but where fast lookup by key is also supported (a dictionary of key-value pairs). Since the early days of .NET, the <xref:System.Collections.Specialized.OrderedDictionary> type has supported this scenario, but only in a non-generic manner, with keys and values typed as `object`. .NET 9 introduces the long-requested <xref:System.Collections.Generic.OrderedDictionary%602> collection, which provides an efficient, generic type to support these scenarios.

The following code uses the new class.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Collections.cs" id="OrderedDictionary":::

### PriorityQueue.Remove() method

.NET 6 introduced the <xref:System.Collections.Generic.PriorityQueue%602> collection, which provides a simple and fast array-heap implementation. One issue with array heaps in general is that they [don't support priority updates](https://github.com/dotnet/runtime/issues/44871), which makes them prohibitive for use in algorithms such as variations of [Dijkstra's algorithm](https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#Using_a_priority_queue).

While it's not possible to implement efficient $O(\log n)$ priority updates in the existing collection, the new <xref:System.Collections.Generic.PriorityQueue%602.Remove(%600,%600@,%601@,System.Collections.Generic.IEqualityComparer{%600})?displayProperty=nameWithType> method makes it possible to emulate priority updates (albeit at $O(n)$ time):

:::code language="csharp" source="../snippets/dotnet-9/csharp/Collections.cs" id="UpdatePriority":::

This method unblocks users who want to implement graph algorithms in contexts where asymptotic performance isn't a blocker. (Such contexts include education and prototyping.) For example, here's a [toy implementation of Dijkstra's algorithm](https://github.com/dotnet/runtime/blob/16cb41496d595e2568574cfe11c763d5e05136c9/src/libraries/System.Collections/tests/Generic/PriorityQueue/PriorityQueue.Tests.Dijkstra.cs#L46-L76) that uses the new API.

### `ReadOnlySet<T>`

It's often desirable to give out read-only views of collections. <xref:System.Collections.ObjectModel.ReadOnlyCollection%601> lets you create a read-only wrapper around an arbitrary mutable <xref:System.Collections.Generic.IList%601>, and <xref:System.Collections.ObjectModel.ReadOnlyDictionary%602> lets you create a read-only wrapper around an arbitrary mutable <xref:System.Collections.Generic.IDictionary%602>. However, past versions of .NET had no built-in support for doing the same with <xref:System.Collections.Generic.ISet%601>. .NET 9 introduces <xref:System.Collections.ObjectModel.ReadOnlySet%601> to address this.

The new class enables the following usage pattern.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Collections.cs" id="ReadOnlySet":::

## Component model - `TypeDescriptor` trimming support

<xref:System.ComponentModel> includes new opt-in trimmer-compatible APIs for describing components. Any application, especially self-contained trimmed applications, can use these new APIs to help support trimming scenarios.

The primary API is the <xref:System.ComponentModel.TypeDescriptor.RegisterType%2A?displayProperty=nameWithType> method on the `TypeDescriptor` class. This method has the <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute> attribute so that the trimmer preserves members for that type. You should call this method once per type, and typically early on.

The secondary APIs have a `FromRegisteredType` suffix, such as <xref:System.ComponentModel.TypeDescriptor.GetPropertiesFromRegisteredType(System.Type)?displayProperty=nameWithType>. Unlike their counterparts that don't have the `FromRegisteredType` suffix, these APIs don't have `[RequiresUnreferencedCode]` or `[DynamicallyAccessedMembers]` trimmer attributes. The lack of trimmer attributes helps consumers by no longer having to either:

- Suppress trimming warnings, which can be risky.
- Propagate a strongly typed `Type` parameter to other methods, which can be cumbersome or infeasible.

:::code language="csharp" source="../snippets/dotnet-9/csharp/TypeDescriptor.cs" id="TypeDescriptor":::

For more information, see the [API proposal](https://github.com/dotnet/runtime/issues/101202).

## Cryptography

- [CryptographicOperations.HashData() method](#cryptographicoperationshashdata-method)
- [KMAC algorithm](#kmac-algorithm)
- [AES-GCM and ChaChaPoly1305 algorithms enabled for iOS/tvOS/MacCatalyst](#aes-gcm-and-chachapoly1305-algorithms-enabled-for-iostvosmaccatalyst)
- [X.509 certificate loading](#x509-certificate-loading)
- [OpenSSL providers support](#openssl-providers-support)
- [Windows CNG virtualization-based security](#windows-cng-virtualization-based-security)

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

### AES-GCM and ChaChaPoly1305 algorithms enabled for iOS/tvOS/MacCatalyst

<xref:System.Security.Cryptography.AesGcm.IsSupported> and `ChaChaPoly1305.IsSupported` now return true when running on iOS 13+, tvOS 13+, and Mac Catalyst.

<xref:System.Security.Cryptography.AesGcm> only supports 16-byte (128-bit) tag values on Apple operating systems.

### X.509 certificate loading

Since .NET Framework 2.0, the way to load a certificate has been `new X509Certificate2(bytes)`. There have also been other patterns, such as `new X509Certificate2(bytes, password, flags)`, `new X509Certificate2(path)`, `new X509Certificate2(path, password, flags)`, and `X509Certificate2Collection.Import(bytes, password, flags)` (and its overloads).

Those methods all used content-sniffing to figure out if the input was something it could handle, and then loaded it if it could. For some callers, this strategy was very convenient. But it also has some problems:

- Not every file format works on every OS.
- It's a protocol deviation.
- It's a source of security issues.

.NET 9 introduces a new <xref:System.Security.Cryptography.X509Certificates.X509CertificateLoader> class, which has a "one method, one purpose" design. In its initial version, it only supports two of the five formats that the <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> constructor supported. Those are the two formats that worked on all operation systems.

### OpenSSL providers support

.NET 8 introduced the OpenSSL-specific APIs <xref:System.Security.Cryptography.SafeEvpPKeyHandle.OpenPrivateKeyFromEngine(System.String,System.String)> and <xref:System.Security.Cryptography.SafeEvpPKeyHandle.OpenPublicKeyFromEngine(System.String,System.String)>. They enable interacting with OpenSSL [`ENGINE` components](https://github.com/openssl/openssl/blob/master/README-ENGINES.md) and use hardware security modules (HSM), for example.

.NET 9 introduces <xref:System.Security.Cryptography.SafeEvpPKeyHandle.OpenKeyFromProvider(System.String,System.String)?displayProperty=nameWithType>, which enables using [OpenSSL providers](https://docs.openssl.org/master/man7/provider/) and interacting with providers such as `tpm2` or `pkcs11`.

Some distros have [removed `ENGINE` support](https://github.com/dotnet/runtime/issues/104775) since it is now deprecated.

The following snippet shows basic usage:

```csharp
byte[] data = [ /* example data */ ];

// Refer to your provider documentation, for example, https://github.com/tpm2-software/tpm2-openssl/tree/master.
using (SafeEvpPKeyHandle priKeyHandle = SafeEvpPKeyHandle.OpenKeyFromProvider("tpm2", "handle:0x81000007"))
using (ECDsa ecdsaPri = new ECDsaOpenSsl(priKeyHandle))
{
    byte[] signature = ecdsaPri.SignData(data, HashAlgorithmName.SHA256);
    // Do stuff with signature created by TPM.
}
```

There are some performance improvements during the TLS handshake as well as improvements to interactions with RSA private keys that use `ENGINE` components.

### Windows CNG virtualization-based security

Windows 11 has added new APIs to help secure Windows keys with [virtualization-based security (VBS)](https://techcommunity.microsoft.com/t5/windows-it-pro-blog/advancing-key-protection-in-windows-using-vbs/ba-p/4050988). With this new capability, keys can be protected from admin-level key theft attacks with negligible effect on performance, reliability, or scale.

.NET 9 has added matching <xref:System.Security.Cryptography.CngKeyCreationOptions> flags. The following three flags were added:

- `CngKeyCreationOptions.PreferVbs` matching `NCRYPT_PREFER_VBS_FLAG`
- `CngKeyCreationOptions.RequireVbs` matching `NCRYPT_REQUIRE_VBS_FLAG`
- `CngKeyCreationOptions.UsePerBootKey` matching `NCRYPT_USE_PER_BOOT_KEY_FLAG`

The following snippet demonstrates how to use one of the flags:

```csharp
using System.Security.Cryptography;

CngKeyCreationParameters cngCreationParams = new()
{
    Provider = CngProvider.MicrosoftSoftwareKeyStorageProvider,
    KeyCreationOptions = CngKeyCreationOptions.RequireVbs | CngKeyCreationOptions.OverwriteExistingKey,
};

using (CngKey key = CngKey.Create(CngAlgorithm.ECDsaP256, "myKey", cngCreationParams))
using (ECDsaCng ecdsa = new ECDsaCng(key))
{
    // Do stuff with the key.
}
```

## Date and time - new TimeSpan.From\* overloads

The <xref:System.TimeSpan> class offers several `From*` methods that let you create a `TimeSpan` object using a `double`. However, since `double` is a binary-based floating-point format, [inherent imprecision can lead to errors](https://github.com/dotnet/runtime/issues/93890). For instance, `TimeSpan.FromSeconds(101.832)` might not precisely represent `101 seconds, 832 milliseconds`, but rather approximately `101 seconds, 831.9999999999936335370875895023345947265625 milliseconds`. This discrepancy has caused frequent confusion, and it's also not the most efficient way to represent such data. To address this, .NET 9 adds new overloads that let you create `TimeSpan` objects from integers. There are new overloads from `FromDays`, `FromHours`, `FromMinutes`, `FromSeconds`, `FromMilliseconds`, and `FromMicroseconds`.

The following code shows an example of calling the `double` and one of the new integer overloads.

:::code language="csharp" source="../snippets/dotnet-9/csharp/TimeSpan.cs" id="TimeSpan.From":::

## Dependency injection - `ActivatorUtilities.CreateInstance` constructor

The constructor resolution for <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance%2A?displayProperty=nameWithType> has changed in .NET 9. Previously, a constructor that was explicitly marked using the <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilitiesConstructorAttribute> attribute might not be called, depending on the ordering of constructors and the number of constructor parameters. The logic has changed in .NET 9 such that a constructor that has the attribute is always called.

## Diagnostics

- [Debug.Assert reports assert condition by default](#debugassert-reports-assert-condition-by-default)
- [New Activity.AddLink method](#new-activityaddlink-method)
- [Metrics.Gauge instrument](#metricsgauge-instrument)
- [Out-of-proc Meter wildcard listening](#out-of-proc-meter-wildcard-listening)

### Debug.Assert reports assert condition by default

<xref:System.Diagnostics.Debug.Assert%2A?displayProperty=nameWithType> is commonly used to help validate conditions that are expected to always be true. Failure typically indicates a bug in the code. There are many overloads of <xref:System.Diagnostics.Debug.Assert%2A?displayProperty=nameWithType>, the simplest of which just accepts a condition:

```csharp
Debug.Assert(a > 0 && b > 0);
```

The assert fails if the condition is false. Historically, however, such asserts were void of any information about what condition failed. Starting in .NET 9, if no message is explicitly provided by the user, the assert will contain the textual representation of the condition. For example, for the previous assert example, rather than getting a message like:

```console
Process terminated. Assertion failed.
   at Program.SomeMethod(Int32 a, Int32 b)
```

The message would now be:

```console
Process terminated. Assertion failed.
a > 0 && b > 0
   at Program.SomeMethod(Int32 a, Int32 b)
```

### New Activity.AddLink method

Previously, you could only link a tracing <xref:System.Diagnostics.Activity> to other tracing contexts when you [created the `Activity`](xref:System.Diagnostics.ActivitySource.CreateActivity(System.String,System.Diagnostics.ActivityKind,System.Diagnostics.ActivityContext,System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}},System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink},System.Diagnostics.ActivityIdFormat)?displayProperty=nameWithType). New in .NET 9, the <xref:System.Diagnostics.Activity.AddLink(System.Diagnostics.ActivityLink)> API lets you link an `Activity` object to other tracing contexts after it's created. This change aligns with the [OpenTelemetry specifications](https://github.com/open-telemetry/opentelemetry-specification/blob/6360b49d20ae451b28f7ba0be168ed9a799ac9e1/specification/trace/api.md?plain=1#L804) as well.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Diagnostics.cs" id="AddLink":::

### Metrics.Gauge instrument

<xref:System.Diagnostics.Metrics> now provides the <xref:System.Diagnostics.Metrics.Gauge%601> instrument according to the OpenTelemetry specification. The `Gauge` instrument is designed to record non-additive values when changes occur. For example, it can measure the background noise level, where summing the values from multiple rooms would be nonsensical. The `Gauge` instrument is a generic type that can record any value type, such as `int`, `double`, or `decimal`.

The following example demonstrates using the the `Gauge` instrument.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Diagnostics.cs" id="Gauge":::

### Out-of-proc Meter wildcard listening

It's already possible to listen to meters out-of-process using the <xref:System.Diagnostics.Metrics> event source provider, but prior to .NET 9, you had to specify the full meter name. In .NET 9, you can listen to all meters by using the wildcard character `*`, which allows you to capture metrics from every meter in a process. Additionally, it adds support for listening by meter prefix, so you can listen to all meters whose names start with a specified prefix. For example, specifying `MyMeter*` enables listening to all meters with names that begin with `MyMeter`.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Diagnostics.cs" id="Wildcard":::

The `MyEventListener` class is defined as follows.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Diagnostics.cs" id="EventListener":::

When you execute the code, the output is as follows:

```txt
CounterRateValuePublished
        sessionId: 7cd94a65-0d0d-460e-9141-016bf390d522
        meterName: MyCompany.MyMeter
        meterVersion:
        instrumentName: MyCounter
        unit:
        tags:
        rate: 0
        value: 1
        instrumentId: 1
CounterRateValuePublished
        sessionId: 7cd94a65-0d0d-460e-9141-016bf390d522
        meterName: MyCompany.MyMeter
        meterVersion:
        instrumentName: MyCounter
        unit:
        tags:
        rate: 0
        value: 1
        instrumentId: 1
```

You can also use the wildcard character to listen to metrics with monitoring tools like [dotnet-counters](../../diagnostics/dotnet-counters.md).

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

- [SocketsHttpHandler is default in HttpClientFactory](#socketshttphandler-is-default-in-httpclientfactory)
- [System.Net.ServerSentEvents](#systemnetserversentevents)
- [TLS resume with client certificates on Linux](#tls-resume-with-client-certificates-on-linux)
- [WebSocket keep-alive ping and timeout](#websocket-keep-alive-ping-and-timeout)
- [HttpClientFactory no longer logs header values by default](#httpclientfactory-no-longer-logs-header-values-by-default)

### SocketsHttpHandler is default in HttpClientFactory

`HttpClientFactory` creates <xref:System.Net.Http.HttpClient> objects backed by <xref:System.Net.Http.HttpClientHandler>, by default. `HttpClientHandler` is itself backed by <xref:System.Net.Http.SocketsHttpHandler>, which is much more configurable, including around connection lifetime management. `HttpClientFactory` now uses `SocketsHttpHandler` by default and configures it to set limits on its connection lifetimes to match that of the rotation lifetime specified in the factory.

### System.Net.ServerSentEvents

Server-sent events (SSE) is a simple and popular protocol for streaming data from a server to a client. It's used, for example, by OpenAI as part of streaming generated text from its AI services. To simplify the consumption of SSE, the new <xref:System.Net.ServerSentEvents> library provides a parser for easily ingesting server-sent events.

The following code demonstrates using the new class.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Networking.cs" id="SseParser":::

### TLS resume with client certificates on Linux

_TLS resume_ is a feature of the TLS protocol that allows resuming previously established sessions to a server. Doing so avoids a few roundtrips and saves computational resources during TLS handshake.

_TLS resume_ has already been supported on Linux for SslStream connections without client certificates. .NET 9 adds support for TLS resume of mutually authenticated TLS connections, which are common in server-to-server scenarios. The feature is enabled automatically.

### WebSocket keep-alive ping and timeout

New APIs on <xref:System.Net.WebSockets.ClientWebSocketOptions> and <xref:System.Net.WebSockets.WebSocketCreationOptions> let you opt in to sending <xref:System.Net.WebSockets.WebSocket> pings and aborting the connection if the peer doesn't respond in time.

Until now, you could specify a <xref:System.Net.WebSockets.ClientWebSocketOptions.KeepAliveInterval> to keep the connection from staying idle, but there was no built-in mechanism to enforce that the peer is responding.

The following example pings the server every 5 seconds and aborts the connection if it doesn't respond within a second.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Networking.cs" id="KeepAliveTimeout":::

### HttpClientFactory no longer logs header values by default

<xref:Microsoft.Extensions.Logging.LogLevel.Trace?displayProperty=nameWithType> events logged by `HttpClientFactory` no longer include header values by default. You can opt in to logging values for specific headers via the <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.RedactLoggedHeaders*> helper method.

The following example redacts all headers, except for the user agent.

```csharp
services.AddHttpClient("myClient")
    .RedactLoggedHeaders(name => name != "User-Agent");
```

For more information, see [HttpClientFactory logging redacts header values by default](../../compatibility/networking/9.0/redact-headers.md).

## Reflection

- [Persisted assemblies](#persisted-assemblies)
- [Type-name parsing](#type-name-parsing)

### Persisted assemblies

In .NET Core versions and .NET 5-8, support for building an assembly and emitting reflection metadata for dynamically created types was limited to a runnable <xref:System.Reflection.Emit.AssemblyBuilder>. The lack of support for _saving_ an assembly was often a blocker for customers migrating from .NET Framework to .NET. .NET 9 adds a new type, <xref:System.Reflection.Emit.PersistedAssemblyBuilder>, that you can use to save an emitted assembly.

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
  - `AssemblyName`, which exposes the assembly name information via the new <xref:System.Reflection.Metadata.AssemblyNameInfo> class. In contrast to `AssemblyName`, the new type is _immutable_, and parsing culture names doesn't create instances of `CultureInfo`.

Both `TypeName` and `AssemblyNameInfo` types are immutable and don't provide a way to check for equality (they don't implement `IEquatable`). Comparing assembly names is simple, but different scenarios need to compare only a subset of exposed information (`Name`, `Version`, `CultureName`, and `PublicKeyOrToken`).

The following code snippet shows some example usage.

:::code language="csharp" source="../snippets/dotnet-9/csharp/TypeName.cs":::

The new APIs are available from the [`System.Reflection.Metadata`](https://www.nuget.org/packages/System.Reflection.Metadata/) NuGet package, which can be used with down-level .NET versions.

## Regular expressions

- [`[GeneratedRegex]` on properties](#generatedregex-on-properties)
- [`Regex.EnumerateSplits`](#regexenumeratesplits)

### `[GeneratedRegex]` on properties

.NET 7 introduced the `Regex` source generator and corresponding <xref:System.Text.RegularExpressions.GeneratedRegexAttribute> attribute.

The following partial method will be source generated with all the code necessary to implement this `Regex`.

:::code language="csharp" source="../snippets/dotnet-9/csharp/RegularExpressions.cs" id="GeneratedRegexMethod":::

C# 13 supports partial _properties_ in addition to partial methods, so starting in .NET 9 you can also use `[GeneratedRegex(...)]` on a property.

The following partial property is the property equivalent of the previous example.

:::code language="csharp" source="../snippets/dotnet-9/csharp/RegularExpressions.cs" id="GeneratedRegexProperty":::

### `Regex.EnumerateSplits`

The <xref:System.Text.RegularExpressions.Regex> class provides a <xref:System.Text.RegularExpressions.Regex.Split%2A> method, similar in concept to the <xref:System.String.Split%2A?displayProperty=nameWithType> method. With `String.Split`, you supply one or more `char` or `string` separators, and the implementation splits the input text on those separators. With `Regex.Split`, instead of specifying the separator as a `char` or `string`, it's specified as a regular expression pattern.

The following example demonstrates `Regex.Split`.

:::code language="csharp" source="../snippets/dotnet-9/csharp/RegularExpressions.cs" id="RegexSplit":::

However, `Regex.Split` only accepts a `string` as input and doesn't support input being provided as a `ReadOnlySpan<char>`. Also, it outputs the full set of splits as a `string[]`, which requires allocating both the `string` array to hold the results and a `string` for each split. In .NET 9, the new <xref:System.Text.RegularExpressions.Regex.EnumerateSplits%2A> method enables performing the same operation, but with a span-based input and without incurring any allocation for the results. It accepts a `ReadOnlySpan<char>` and returns an enumerable of <xref:System.Range> objects that represent the results.

The following example demonstrates `Regex.EnumerateSplits`, taking a `ReadOnlySpan<char>` as input.

:::code language="csharp" source="../snippets/dotnet-9/csharp/RegularExpressions.cs" id="EnumerateSplits":::

## Serialization (System.Text.Json)

- [Indentation options](#indentation-options)
- [Default web options singleton](#default-web-options-singleton)
- [JsonSchemaExporter](#jsonschemaexporter)
- [Respect nullable annotations](#respect-nullable-annotations)
- [Require non-optional constructor parameters](#require-non-optional-constructor-parameters)
- [Order JsonObject properties](#order-jsonobject-properties)
- [Customize enum member names](#customize-enum-member-names)
- [Stream multiple JSON documents](#stream-multiple-json-documents)

### Indentation options

<xref:System.Text.Json.JsonSerializerOptions> includes new properties that let you customize the indentation character and indentation size of written JSON.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="Indentation":::

### Default web options singleton

If you want to serialize with the [default options that ASP.NET Core uses](../../../standard/serialization/system-text-json/configure-options.md#web-defaults-for-jsonserializeroptions) for web apps, use the new <xref:System.Text.Json.JsonSerializerOptions.Web?displayProperty=nameWithType> singleton.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="Web":::

### JsonSchemaExporter

JSON is frequently used to represent types in method signatures as part of remote procedure&ndash;calling schemes. It's used, for example, as part of OpenAPI specifications, or as part of tool calling with AI services like those from OpenAI. Developers can serialize and deserialize .NET types as JSON using <xref:System.Text.Json>. But they also need to be able to get a JSON schema that describes the shape of the .NET type (that is, describes the shape of what would be serialized and what can be deserialized). <xref:System.Text.Json> now provides the <xref:System.Text.Json.Schema.JsonSchemaExporter> type, which supports generating a JSON schema that represents a .NET type.

For more information, see [JSON schema exporter](../../../standard/serialization/system-text-json/extract-schema.md).

### Respect nullable annotations

<xref:System.Text.Json> now recognizes nullability annotations of properties and can be configured to enforce those during serialization and deserialization using the <xref:System.Text.Json.JsonSerializerOptions.RespectNullableAnnotations> flag.

The following code shows how to set the option:

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="RespectNullable":::

For more information, see [Respect nullable annotations](../../../standard/serialization/system-text-json/nullable-annotations.md).

### Require non-optional constructor parameters

Historically, <xref:System.Text.Json> has treated non-optional constructor parameters as optional when using constructor-based deserialization. You can change that behavior using the new <xref:System.Text.Json.JsonSerializerOptions.RespectRequiredConstructorParameters> flag.

The following code shows how to set the option:

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="RespectRequired":::

The `MyPoco` type is defined as follows:

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="Poco":::

For more information, see [Non-optional constructor parameters](../../../standard/serialization/system-text-json/required-properties.md#non-optional-constructor-parameters).

### Order JsonObject properties

The <xref:System.Json.JsonObject> type now exposes ordered dictionary&ndash;like APIs that enable explicit property order manipulation.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="PropertyOrder":::

For more information, see [Manipulate property order](../../../standard/serialization/system-text-json/use-dom.md#manipulate-property-order).

### Customize enum member names

The new <xref:System.Text.Json.Serialization.JsonStringEnumMemberNameAttribute?displayProperty=nameWithType> attribute can be used to customize the names of individual enum members for types that are serialized as strings:

```csharp
JsonSerializer.Serialize(MyEnum.Value1 | MyEnum.Value2); // "Value1, Custom enum value"

[Flags, JsonConverter(typeof(JsonStringEnumConverter))]
enum MyEnum
{
    Value1 = 1,
    [JsonStringEnumMemberName("Custom enum value")]
    Value2 = 2,
}
```

For more information, see [Custom enum member names](../../../standard/serialization/system-text-json/customize-properties.md#custom-enum-member-names).

### Stream multiple JSON documents

<xref:System.Text.Json.Utf8JsonReader?displayProperty=nameWithType> now supports reading multiple, whitespace-separated JSON documents from a single buffer or stream. By default, the reader throws an exception if it detects any non-whitespace characters that are trailing the first top-level document. You can change this behavior using the <xref:System.Text.Json.JsonReaderOptions.AllowMultipleValues> flag.

For more information, see [Read multiple JSON documents](../../../standard/serialization/system-text-json/use-utf8jsonreader.md#read-multiple-json-documents).

## Spans

In high-performance code, spans are often used to avoid allocating strings unnecessarily. <xref:System.Span%601> and <xref:System.ReadOnlySpan%601> continue to revolutionize how code is written in .NET, and every release more and more methods are added that operate on spans. .NET 9 includes the following span-related updates:

- [File helpers](#file-helpers)
- [`params ReadOnlySpan<T>` overloads](#params-readonlyspant-overloads)
- [Enumerate over ReadOnlySpan\<char>.Split() segments](#enumerate-over-readonlyspancharsplit-segments)

### File helpers

The <xref:System.IO.File> class now has new helpers to easily and directly write `ReadOnlySpan<char>`/`ReadOnlySpan<byte>` and `ReadOnlyMemory<char>`/`ReadOnlyMemory<byte>` to files.

The following code efficiently writes a `ReadOnlySpan<char>` to a file.

```csharp
ReadOnlySpan<char> text = ...;
File.WriteAllText(filePath, text);
```

New <xref:System.MemoryExtensions.StartsWith%60%601(System.ReadOnlySpan{%60%600},%60%600)> and <xref:System.MemoryExtensions.EndsWith%60%601(System.ReadOnlySpan{%60%600},%60%600)> extension methods have also been added for spans, making it easy to test whether a <xref:System.ReadOnlySpan%601> starts or ends with a specific `T` value.

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

### Enumerate over ReadOnlySpan\<char>.Split() segments

`string.Split` is a convenient method for quickly partitioning a string with one or more supplied separators. For code focused on performance, however, the allocation profile of `string.Split` can be prohibitive, because it allocates a string for each parsed component and a `string[]` to store them all. It also doesn't work with spans, so if you have a `ReadOnlySpan<char>`, you're forced to allocate yet another string when you convert it to a string to be able to call `string.Split` on it.

In .NET 8, a set of `Split` and `SplitAny` methods were introduced for `ReadOnlySpan<char>`. Rather than returning a new `string[]`, these methods accept a destination `Span<Range>` into which the bounding indices for each component are written. This makes the operation fully allocation-free. These methods are appropriate to use when the number of ranges is both known and small.

In .NET 9, new overloads of `Split` and `SplitAny` have been added to allow incrementally parsing a `ReadOnlySpan<T>` with an _a priori_ unknown number of segments. The new methods enable enumerating through each segment, which is similarly represented as a `Range` that can be used to slice into the original span.

```csharp
public static bool ListContainsItem(ReadOnlySpan<char> span, string item)
{
    foreach (Range segment in span.Split(','))
    {
        if (span[segment].SequenceEquals(item))
        {
            return true;
        }
    }

    return false;
}
```

## System.Formats

The position or offset of the data in the enclosing stream for a <xref:System.Formats.Tar.TarEntry> object is now a public property. <xref:System.Formats.Tar.TarEntry.DataOffset?displayProperty=nameWithType> returns the position in the entry's archive stream where the entry's first data byte is located. The entry's data is encapsulated in a substream that you can access via <xref:System.Formats.Tar.TarEntry.DataStream?displayProperty=nameWithType>, which hides the real position of the data relative to the archive stream. That's enough for most users, but if you need more flexibility and want to know the real starting position of the data in the archive stream, the new <xref:System.Formats.Tar.TarEntry.DataOffset?displayProperty=nameWithType> API makes it easy to support features like concurrent access with very large TAR files.

:::code language="csharp" source="../snippets/dotnet-9/csharp/TarEntry.cs" id="DataOffset":::

## System.Guid

<xref:System.Guid.NewGuid> creates a `Guid` filled mostly with [cryptographically secure random data](https://www.rfc-editor.org/rfc/rfc9562#section-6.9), following the UUID Version 4 specification in RFC 9562. That same RFC also defines other versions, including Version 7, which "features a time-ordered value field derived from the widely implemented and well-known Unix Epoch timestamp source". In other words, much of the data is still random, but some of it is reserved for data based on a timestamp, which enables these values to have a natural sort order. In .NET 9, you can create a `Guid` according to Version 7 via the new <xref:System.Guid.CreateVersion7?displayProperty=nameWithType> and <xref:System.Guid.CreateVersion7(System.DateTimeOffset)?displayProperty=nameWithType> methods. You can also use the new <xref:System.Guid.Version> property to retrieve a `Guid` object's version field.

## System.IO

- [Compression with zlib-ng](#compression-with-zlib-ng)
- [ZLib and Brotli compression options](#zlib-and-brotli-compression-options)
- [XPS documents from XPS virtual printer](#xps-documents-from-xps-virtual-printer)

### Compression with zlib-ng

<xref:System.IO.Compression> features like <xref:System.IO.Compression.ZipArchive>, <xref:System.IO.Compression.DeflateStream>, <xref:System.IO.Compression.GZipStream>, and <xref:System.IO.Compression.ZLibStream> are all based primarily on the zlib library. Starting in .NET 9, these features instead all use [zlib-ng](https://github.com/zlib-ng/zlib-ng), a library that yields more consistent and efficient processing across a wider array of operating systems and hardware.

### ZLib and Brotli compression options

<xref:System.IO.Compression.ZLibCompressionOptions> and <xref:System.IO.Compression.BrotliCompressionOptions> are new types for setting algorithm-specific compression [level](xref:System.IO.Compression.CompressionLevel) and strategy (`Default`, `Filtered`, `HuffmanOnly`, `RunLengthEncoding`, or `Fixed`). These types are aimed at users who want more fine-tuned settings than the only existing option, <System.IO.Compression.CompressionLevel>.

The new compression option types might be expanded in the future.

The following code snippet shows some example usage:

:::code language="csharp" source="../snippets/dotnet-9/csharp/Compression.cs" id="CompressStream":::

### XPS documents from XPS virtual printer

XPS documents coming from a V4 XPS virtual printer previously couldn't be opened using the <xref:System.IO.Packaging> library, due to lack of support for handling _.piece_ files. This gap has been addressed in .NET 9.

## System.Numerics

- [BigInteger upper limit](#biginteger-upper-limit)
- [`BigMul` APIs](#bigmul-apis)
- [Vector conversion APIs](#vector-conversion-apis)
- [Vector create APIs](#vector-create-apis)
- [Additional acceleration](#additional-acceleration)

### BigInteger upper limit

<xref:System.Numerics.BigInteger> supports representing integer values of essentially arbitrary length. However, in practice, the length is constrained by limits of the underlying computer, such as available memory or how long it would take to compute a given expression. Additionally, there exist some APIs that fail given inputs that result in a value that's too large. Because of these limits, .NET 9 enforces a maximum length of `BigInteger`, which is that it can contain no more than `(2^31) - 1` (approximately 2.14 billion) bits. Such a number represents an almost 256 MB allocation and contains approximately 646.5 million digits. This new limit ensures that all APIs exposed are well behaved and consistent while still allowing numbers that are far beyond most usage scenarios.

### `BigMul` APIs

`BigMul` is an operation that produces the full product of two numbers. .NET 9 adds dedicated `BigMul` APIs on `int`, `long`, `uint`, and `ulong` whose return type is the next larger [integer type](../../../csharp/language-reference/builtin-types/integral-numeric-types.md) than the parameter types.

The new APIs are:

- <xref:System.Int32.BigMul(System.Int32,System.Int32)> (returns `long`)
- <xref:System.Int64.BigMul(System.Int64,System.Int64)> (returns `Int128`)
- <xref:System.UInt32.BigMul(System.UInt32,System.UInt32)> (returns `ulong`)
- <xref:System.UInt64.BigMul(System.UInt64,System.UInt64)> (returns `UInt128`)

### Vector conversion APIs

.NET 9 adds dedicated extension APIs for converting between <xref:System.Numerics.Vector2>, <xref:System.Numerics.Vector3>, <xref:System.Numerics.Vector4>, <xref:System.Numerics.Quaternion>, and <xref:System.Numerics.Plane>.

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

For same-sized conversions, such as between `Vector4`, `Quaternion`, and `Plane`, these conversions are zero cost. The same can be said for narrowing conversions, such as from `Vector4` to `Vector2` or `Vector3`. For widening conversions, such as from `Vector2` or `Vector3` to `Vector4`, there is the normal API, which initializes new elements to 0, and an `Unsafe` suffixed API that leaves these new elements undefined and therefore can be zero cost.

### Vector create APIs

There are new `Create` APIs exposed for <xref:System.Numerics.Vector>, <xref:System.Numerics.Vector2>, <xref:System.Numerics.Vector3>, and <xref:System.Numerics.Vector4> that parity the equivalent APIs exposed for the hardware vector types exposed in the <xref:System.Runtime.Intrinsics> namespace.

For more information about the new APIs, see:

- <xref:System.Numerics.Vector.Create%2A?displayProperty=nameWithType>
- <xref:System.Numerics.Vector2.Create%2A?displayProperty=nameWithType>
- <xref:System.Numerics.Vector3.Create%2A?displayProperty=nameWithType>
- <xref:System.Numerics.Vector4.Create%2A?displayProperty=nameWithType>

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

> [!NOTE]
> This API is marked as [experimental](../../../fundamentals/syslib-diagnostics/experimental-overview.md) for .NET 9.

### TensorPrimitives

The `System.Numerics.Tensors` library includes the <xref:System.Numerics.Tensors.TensorPrimitives> class, which provides static methods for performing numerical operations on spans of values. In .NET 9, the scope of methods exposed by <xref:System.Numerics.Tensors.TensorPrimitives> has been significantly expanded, growing from 40 (in .NET 8) to almost 200 overloads. The surface area encompasses familiar numerical operations from types like <xref:System.Math> and <xref:System.MathF>. It also includes the generic math interfaces like <xref:System.Numerics.INumber%601>, except instead of processing an individual value, they process a span of values. Many operations have also been accelerated via SIMD-optimized implementations for .NET 9.

<xref:System.Numerics.Tensors.TensorPrimitives> now exposes generic overloads for any type `T` that implements a certain interface. (The .NET 8 version only included overloads for manipulating spans of `float` values.) For example, the new <xref:System.Numerics.Tensors.TensorPrimitives.CosineSimilarity%60%601(System.ReadOnlySpan{%60%600},System.ReadOnlySpan{%60%600})> overload performs cosine similarity on two vectors of `float`, `double`, or `Half` values, or values of any other type that implements <xref:System.Numerics.IRootFunctions%601>.

Compare the precision of the cosine similarity operation on two vectors of type `float` versus `double`:

:::code language="csharp" source="../snippets/dotnet-9/csharp/Tensors.cs" id="CosineSimilarity":::

## Threading

The threading APIs include improvements for iterating through tasks, for prioritized channels, which can order their elements instead of being first-in-first-out (FIFO), and `Interlocked.CompareExchange` for more types.

### `Task.WhenEach`

A variety of helpful new APIs have been added for working with <xref:System.Threading.Tasks.Task%601> objects. The new <xref:System.Threading.Tasks.Task.WhenEach%2A?displayProperty=nameWithType> method lets you iterate through tasks as they complete using an `await foreach` statement. You no longer need to do things like repeatedly call <xref:System.Threading.Tasks.Task.WaitAny%2A?displayProperty=nameWithType> on a set of tasks to pick off the next one that completes.

The following code makes multiple `HttpClient` calls and operates on their results as they complete.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Task.cs" id="TaskWhenEach":::

### Prioritized unbounded channel

The <xref:System.Threading.Channels> namespace lets you create first-in-first-out (FIFO) channels using the <xref:System.Threading.Channels.Channel.CreateBounded%2A> and <xref:System.Threading.Channels.Channel.CreateUnbounded%2A> methods. With FIFO channels, elements are read from the channel in the order they were written to it. In .NET 9, the new <xref:System.Threading.Channels.Channel.CreateUnboundedPrioritized%2A> method has been added, which orders the elements such that the next element read from the channel is the one deemed to be most important, according to either <xref:System.Collections.Generic.Comparer%601.Default?displayProperty=nameWithType> or a custom <xref:System.Collections.Generic.IComparer%601>.

The following example uses the new method to create a channel that outputs the numbers 1 through 5 in order, even though they're written to the channel in a different order.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Channels.cs" id="Channel":::

### Interlocked.CompareExchange for more types

In previous versions of .NET, <xref:System.Threading.Interlocked.Exchange%2A?displayProperty=nameWithType> and <xref:System.Threading.Interlocked.CompareExchange%2A?displayProperty=nameWithType> had overloads for working with `int`, `uint`, `long`, `ulong`, `nint`, `nuint`, `float`, `double`, and `object`, as well as a generic overload for working with any reference type `T`. In .NET 9, there are new overloads for atomically working with `byte`, `sbyte`, `short`, and `ushort`. Also, the generic constraint on the generic `Interlocked.Exchange<T>` and `Interlocked.CompareExchange<T>` overloads has been removed, so those methods are no longer constrained to only work with reference types. They can now work with any primitive type, which includes all of the aforementioned types as well as `bool` and `char`, as well as any `enum` type.
