---
title: What's new in .NET 8
description: Learn about the new .NET features introduced in .NET 8.
titleSuffix: ""
ms.date: 11/14/2023
ms.topic: overview
ms.author: gewarren
author: gewarren
---
# What's new in .NET 8

.NET 8 is the successor to [.NET 7](dotnet-7.md). It will be [supported for three years](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a long-term support (LTS) release. You can [download .NET 8 here](https://dotnet.microsoft.com/download/dotnet).

## .NET Aspire

.NET Aspire is an opinionated, cloud ready stack for building observable, production ready, distributed applications.​ .NET Aspire is delivered through a collection of NuGet packages that handle specific cloud-native concerns, and is available in preview for .NET 8. For more information, see [.NET Aspire (Preview)](/dotnet/aspire).

## ASP.NET Core

For information about what's new in ASP.NET Core, see [What's new in ASP.NET Core 8.0](/aspnet/core/release-notes/aspnetcore-8.0).

## Core .NET libraries

This section contains the following subtopics:

- [Serialization](#serialization)
- [Time abstraction](#time-abstraction)
- [UTF8 improvements](#utf8-improvements)
- [Methods for working with randomness](#methods-for-working-with-randomness)
- [Performance-focused types](#performance-focused-types)
- [System.Numerics and System.Runtime.Intrinsics](#systemnumerics-and-systemruntimeintrinsics)
- [Data validation](#data-validation)
- [Metrics](#metrics)
- [Cryptography](#cryptography)
- [Networking](#networking)
- [Stream-based ZipFile methods](#stream-based-zipfile-methods)

### Serialization

Many improvements have been made to <xref:System.Text.Json?displayProperty=fullName> serialization and deserialization functionality in .NET 8. For example, you can [customize handling of members that aren't in the JSON payload](../../standard/serialization/system-text-json/missing-members.md).

The following sections describe other serialization improvements:

- [Built-in support for additional types](#built-in-support-for-additional-types)
- [Source generator](#source-generator)
- [Interface hierarchies](#interface-hierarchies)
- [Naming policies](#naming-policies)
- [Read-only properties](#read-only-properties)
- [Disable reflection-based default](#disable-reflection-based-default)
- [New JsonNode API methods](#new-jsonnode-api-methods)
- [Non-public members](#non-public-members)
- [Streaming deserialization APIs](#streaming-deserialization-apis)
- [WithAddedModifier extension method](#withaddedmodifier-extension-method)
- [New JsonContent.Create overloads](#new-jsoncontentcreate-overloads)
- [Freeze a JsonSerializerOptions instance](#freeze-a-jsonserializeroptions-instance)

For more information about JSON serialization in general, see [JSON serialization and deserialization in .NET](../../standard/serialization/system-text-json/overview.md).

#### Built-in support for additional types

The serializer has built-in support for the following additional types.

- <xref:System.Half>, <xref:System.Int128>, and <xref:System.UInt128> numeric types.

  ```csharp
  Console.WriteLine(JsonSerializer.Serialize(
      [ Half.MaxValue, Int128.MaxValue, UInt128.MaxValue ]
  ));
  // [65500,170141183460469231731687303715884105727,340282366920938463463374607431768211455]
  ```

- <xref:System.Memory%601> and <xref:System.ReadOnlyMemory%601> values. `byte` values are serialized to Base64 strings, and other types to JSON arrays.

  ```csharp
  JsonSerializer.Serialize<ReadOnlyMemory<byte>>(new byte[] { 1, 2, 3 }); // "AQID"
  JsonSerializer.Serialize<Memory<int>>(new int[] { 1, 2, 3 }); // [1,2,3]
  ```

#### Source generator

.NET 8 includes enhancements of the System.Text.Json [source generator](../../standard/serialization/system-text-json/source-generation.md) that are aimed at making the [Native AOT](../../standard/glossary.md#native-aot) experience on par with the [reflection-based serializer](../../standard/serialization/system-text-json/reflection-vs-source-generation.md#reflection). For example:

- The source generator now supports serializing types with [`required`](../../standard/serialization/system-text-json/required-properties.md) and [`init`](../../csharp/language-reference/keywords/init.md) properties. These were both already supported in reflection-based serialization.
- Improved formatting of source-generated code.
- <xref:System.Text.Json.Serialization.JsonSourceGenerationOptionsAttribute> feature parity with <xref:System.Text.Json.JsonSerializerOptions>. For more information, see [Specify options (source generation)](../../standard/serialization/system-text-json/source-generation.md#specify-options).
- Additional diagnostics (such as [SYSLIB1034](../../fundamentals/syslib-diagnostics/syslib1034.md) and [SYSLIB1039](../../fundamentals/syslib-diagnostics/syslib1039.md)).
- Don't include types of ignored or inaccessible properties.
- Support for nesting `JsonSerializerContext` declarations within arbitrary type kinds.
- Support for compiler-generated or *unspeakable* types in weakly typed source generation scenarios. Since compiler-generated types can't be explicitly specified by the source generator, <xref:System.Text.Json?displayProperty=fullName> now performs nearest-ancestor resolution at run time. This resolution determines the most appropriate supertype with which to serialize the value.
- New converter type `JsonStringEnumConverter<TEnum>`. The existing <xref:System.Text.Json.Serialization.JsonStringEnumConverter> class isn't supported in Native AOT. You can annotate your enum types as follows:

  ```csharp
  [JsonConverter(typeof(JsonStringEnumConverter<MyEnum>))]
  public enum MyEnum { Value1, Value2, Value3 }

  [JsonSerializable(typeof(MyEnum))]
  public partial class MyContext : JsonSerializerContext { }
  ```

  For more information, see [Serialize enum fields as strings](../../standard/serialization/system-text-json/source-generation.md#serialize-enum-fields-as-strings).

- New `JsonConverter.Type` property lets you look up the type of a non-generic `JsonConverter` instance:

  ```csharp
  Dictionary<Type, JsonConverter> CreateDictionary(IEnumerable<JsonConverter> converters)
      => converters.Where(converter => converter.Type != null)
                   .ToDictionary(converter => converter.Type!);
  ```

  The property is nullable since it returns `null` for `JsonConverterFactory` instances and `typeof(T)` for `JsonConverter<T>` instances.

##### Chain source generators

The <xref:System.Text.Json.JsonSerializerOptions> class includes a new <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolverChain> property that complements the existing <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolver> property. These properties are used in contract customization for chaining source generators. The addition of the new property means that you don't have to specify all chained components at one call site&mdash;they can be added after the fact. <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolverChain> also lets you introspect the chain or remove components from it. For more information, see [Combine source generators](../../standard/serialization/system-text-json/source-generation.md#combine-source-generators).

In addition, <xref:System.Text.Json.JsonSerializerOptions.AddContext%60%601?displayProperty=nameWithType> is now obsolete. It's been superseded by the <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolver> and <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolverChain> properties. For more information, see [SYSLIB0049](../../fundamentals/syslib-diagnostics/syslib0049.md).

#### Interface hierarchies

.NET 8 adds support for serializing properties from interface hierarchies.

The following code shows an example where the properties from both the immediately implemented interface and its base interface are serialized.

```csharp
IDerived value = new DerivedImplement { Base = 0, Derived = 1 };
JsonSerializer.Serialize(value);
// {"Base":0,"Derived":1}

public interface IBase
{
    public int Base { get; set; }
}

public interface IDerived : IBase
{
    public int Derived { get; set; }
}

public class DerivedImplement : IDerived
{
    public int Base { get; set; }
    public int Derived { get; set; }
}
```

#### Naming policies

[`JsonNamingPolicy`](xref:System.Text.Json.JsonNamingPolicy#properties) includes new naming policies for `snake_case` (with an underscore) and `kebab-case` (with a hyphen) property name conversions. Use these policies similarly to the existing <xref:System.Text.Json.JsonNamingPolicy.CamelCase?displayProperty=nameWithType> policy:

```csharp
var options = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
};
JsonSerializer.Serialize(new { PropertyName = "value" }, options);
// { "property_name" : "value" }
```

For more information, see [Use a built-in naming policy](../../standard/serialization/system-text-json/customize-properties.md#use-a-built-in-naming-policy).

#### Read-only properties

You can now deserialize onto read-only fields or properties (that is, those that don't have a `set` accessor).

To opt into this support globally, set a new option, <xref:System.Text.Json.JsonSerializerOptions.PreferredObjectCreationHandling>, to <xref:System.Text.Json.Serialization.JsonObjectCreationHandling.Populate?displayProperty=nameWithType>. If compatibility is a concern, you can also enable the functionality more granularly by placing the `[JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]` attribute on specific types whose properties are to be populated, or on individual properties.

For example, consider the following code that deserializes into a `CustomerInfo` type that has two read-only properties.

```csharp
using System.Text.Json;

CustomerInfo customer =
    JsonSerializer.Deserialize<CustomerInfo>("""
        {"Names":["John Doe"],"Company":{"Name":"Contoso"}}
        """)!;

Console.WriteLine(JsonSerializer.Serialize(customer));

class CompanyInfo
{
    public required string Name { get; set; }
    public string? PhoneNumber { get; set; }
}

[JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
class CustomerInfo
{
    // Both of these properties are read-only.
    public List<string> Names { get; } = new();
    public CompanyInfo Company { get; } = new()
    {
        Name = "N/A", PhoneNumber = "N/A"
    };
}
```

Prior to .NET 8, the input values were ignored and the `Names` and `Company` properties retained their default values.

```output
{"Names":[],"Company":{"Name":"N/A","PhoneNumber":"N/A"}}
```

Now, the input values are used to populate the read-only properties during deserialization.

```output
{"Names":["John Doe"],"Company":{"Name":"Contoso","PhoneNumber":null}}
```

For more information about the *populate* deserialization behavior, see [Populate initialized properties](../../standard/serialization/system-text-json/populate-properties.md).

#### Disable reflection-based default

You can now disable using the reflection-based serializer by default. This disablement is useful to avoid accidental rooting of reflection components that aren't even in use, especially in trimmed and Native AOT apps. To disable default reflection-based serialization by requiring that a <xref:System.Text.Json.JsonSerializerOptions> argument be passed to the <xref:System.Text.Json.JsonSerializer> serialization and deserialization methods, set the `JsonSerializerIsReflectionEnabledByDefault` MSBuild property to `false` in your project file.

Use the new <xref:System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault> API to check the value of the feature switch. If you're a library author building on top of <xref:System.Text.Json?displayProperty=fullName>, you can rely on the property to configure your defaults without accidentally rooting reflection components.

For more information, see [Disable reflection defaults](../../standard/serialization/system-text-json/source-generation.md#disable-reflection-defaults).

#### New JsonNode API methods

The <xref:System.Text.Json.Nodes.JsonNode> and <xref:System.Text.Json.Nodes.JsonArray?displayProperty=fullName> types include the following new methods.

```csharp
public partial class JsonNode
{
    // Creates a deep clone of the current node and all its descendants.
    public JsonNode DeepClone();

    // Returns true if the two nodes are equivalent JSON representations.
    public static bool DeepEquals(JsonNode? node1, JsonNode? node2);

    // Determines the JsonValueKind of the current node.
    public JsonValueKind GetValueKind(JsonSerializerOptions options = null);

    // If node is the value of a property in the parent
    // object, returns its name.
    // Throws InvalidOperationException otherwise.
    public string GetPropertyName();

    // If node is the element of a parent JsonArray,
    // returns its index.
    // Throws InvalidOperationException otherwise.
    public int GetElementIndex();

    // Replaces this instance with a new value,
    // updating the parent object/array accordingly.
    public void ReplaceWith<T>(T value);

    // Asynchronously parses a stream as UTF-8 encoded data
    // representing a single JSON value into a JsonNode.
    public static Task<JsonNode?> ParseAsync(
        Stream utf8Json,
        JsonNodeOptions? nodeOptions = null,
        JsonDocumentOptions documentOptions = default,
        CancellationToken cancellationToken = default);
}

public partial class JsonArray
{
    // Returns an IEnumerable<T> view of the current array.
    public IEnumerable<T> GetValues<T>();
}
```

#### Non-public members

You can opt non-public members into the serialization contract for a given type using <xref:System.Text.Json.Serialization.JsonIncludeAttribute> and <xref:System.Text.Json.Serialization.JsonConstructorAttribute> attribute annotations.

```csharp
string json = JsonSerializer.Serialize(new MyPoco(42));
// {"X":42}

JsonSerializer.Deserialize<MyPoco>(json);

public class MyPoco
{
    [JsonConstructor]
    internal MyPoco(int x) => X = x;

    [JsonInclude]
    internal int X { get; }
}
```

For more information, see [Use immutable types and non-public members and accessors](../../standard/serialization/system-text-json/immutability.md).

#### Streaming deserialization APIs

.NET 8 includes new <xref:System.Collections.Generic.IAsyncEnumerable%601> streaming deserialization extension methods, for example <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsAsyncEnumerable%2A>. Similar methods have existed that return <xref:System.Threading.Tasks.Task%601>, for example, <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A?displayProperty=nameWithType>. The new extension methods invoke streaming APIs and return <xref:System.Collections.Generic.IAsyncEnumerable%601>.

The following code shows how you might use the new extension methods.

```csharp
const string RequestUri = "https://api.contoso.com/books";
using var client = new HttpClient();
IAsyncEnumerable<Book> books = client.GetFromJsonAsAsyncEnumerable<Book>(RequestUri);

await foreach (Book book in books)
{
    Console.WriteLine($"Read book '{book.title}'");
}

public record Book(int id, string title, string author, int publishedYear);
```

#### WithAddedModifier extension method

The new <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfoResolver.WithAddedModifier(System.Text.Json.Serialization.Metadata.IJsonTypeInfoResolver,System.Action{System.Text.Json.Serialization.Metadata.JsonTypeInfo})> extension method lets you easily introduce modifications to the serialization contracts of arbitrary `IJsonTypeInfoResolver` instances.

```csharp
var options = new JsonSerializerOptions
{
    TypeInfoResolver = MyContext.Default
        .WithAddedModifier(static typeInfo =>
        {
            foreach (JsonPropertyInfo prop in typeInfo.Properties)
            {
                prop.Name = prop.Name.ToUpperInvariant();
            }
        })
};
```

#### New JsonContent.Create overloads

You can now create <xref:System.Net.Http.Json.JsonContent> instances using trim-safe or source-generated contracts. The new methods are:

- <xref:System.Net.Http.Json.JsonContent.Create(System.Object,System.Text.Json.Serialization.Metadata.JsonTypeInfo,System.Net.Http.Headers.MediaTypeHeaderValue)?displayProperty=nameWithType>
- <xref:System.Net.Http.Json.JsonContent.Create%60%601(%60%600,System.Text.Json.Serialization.Metadata.JsonTypeInfo{%60%600},System.Net.Http.Headers.MediaTypeHeaderValue)?displayProperty=nameWithType>

```csharp
var book = new Book(id: 42, "Title", "Author", publishedYear: 2023);
HttpContent content = JsonContent.Create(book, MyContext.Default.Book);

public record Book(int id, string title, string author, int publishedYear);

[JsonSerializable(typeof(Book))]
public partial class MyContext : JsonSerializerContext
{
}
```

#### Freeze a JsonSerializerOptions instance

The following new methods let you control when a <xref:System.Text.Json.JsonSerializerOptions> instance is frozen:

- <xref:System.Text.Json.JsonSerializerOptions.MakeReadOnly?displayProperty=nameWithType>

  This overload is designed to be trim-safe and will therefore throw an exception in cases where the options instance hasn't been configured with a resolver.

- <xref:System.Text.Json.JsonSerializerOptions.MakeReadOnly(System.Boolean)?displayProperty=nameWithType>

  If you pass `true` to this overload, it populates the options instance with the default reflection resolver if one is missing. This method is marked `RequiresUnreferenceCode`/`RequiresDynamicCode` and is therefore unsuitable for Native AOT applications.

The new <xref:System.Text.Json.JsonSerializerOptions.IsReadOnly> property lets you check if the options instance is frozen.

### Time abstraction

The new <xref:System.TimeProvider> class and <xref:System.Threading.ITimer> interface add *time abstraction* functionality, which allows you to mock time in test scenarios. In addition, you can use the time abstraction to mock <xref:System.Threading.Tasks.Task> operations that rely on time progression using <xref:System.Threading.Tasks.Task.Delay%2A?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Task.WaitAsync%2A?displayProperty=nameWithType>. The time abstraction supports the following essential time operations:

- Retrieve local and UTC time
- Obtain a timestamp for measuring performance
- Create a timer

The following code snippet shows some usage examples.

```csharp
// Get system time.
DateTimeOffset utcNow = TimeProvider.System.GetUtcNow();
DateTimeOffset localNow = TimeProvider.System.GetLocalNow();

// Create a time provider that works with a
// time zone that's different than the local time zone.
private class ZonedTimeProvider : TimeProvider
{
    private TimeZoneInfo _zoneInfo;

    public ZonedTimeProvider(TimeZoneInfo zoneInfo) : base()
    {
        _zoneInfo = zoneInfo ?? TimeZoneInfo.Local;
    }

    public override TimeZoneInfo LocalTimeZone => _zoneInfo;

    public static TimeProvider FromLocalTimeZone(TimeZoneInfo zoneInfo) =>
        new ZonedTimeProvider(zoneInfo);
}

// Create a timer using a time provider.
ITimer timer = timeProvider.CreateTimer(
    callBack, state, delay, Timeout.InfiniteTimeSpan);

// Measure a period using the system time provider.
long providerTimestamp1 = TimeProvider.System.GetTimestamp();
long providerTimestamp2 = TimeProvider.System.GetTimestamp();

var period = GetElapsedTime(providerTimestamp1, providerTimestamp2);
```

### UTF8 improvements

If you want to enable writing out a string-like representation of your type to a destination span, implement the new <xref:System.IUtf8SpanFormattable> interface on your type. This new interface is closely related to <xref:System.ISpanFormattable>, but targets UTF8 and `Span<byte>` instead of UTF16 and `Span<char>`.

<xref:System.IUtf8SpanFormattable> has been implemented on all of the primitive types (plus others), with the exact same shared logic whether targeting `string`, `Span<char>`, or `Span<byte>`. It has full support for all formats (including the new ["B" binary specifier](../../standard/base-types/standard-numeric-format-strings.md#binary-format-specifier-b)) and all cultures. This means you can now format directly to UTF8 from `Byte`, `Complex`, `Char`, `DateOnly`, `DateTime`, `DateTimeOffset`, `Decimal`, `Double`, `Guid`, `Half`, `IPAddress`, `IPNetwork`, `Int16`, `Int32`, `Int64`, `Int128`, `IntPtr`, `NFloat`, `SByte`, `Single`, `Rune`, `TimeOnly`, `TimeSpan`, `UInt16`, `UInt32`, `UInt64`, `UInt128`, `UIntPtr`, and `Version`.

New <xref:System.Text.Unicode.Utf8.TryWrite%2A?displayProperty=nameWithType> methods provide a UTF8-based counterpart to the existing <xref:System.MemoryExtensions.TryWrite%2A?displayProperty=nameWithType> methods, which are UTF16-based. You can use interpolated string syntax to format a complex expression directly into a span of UTF8 bytes, for example:

```csharp
static bool FormatHexVersion(
    short major,
    short minor,
    short build,
    short revision,
    Span<byte> utf8Bytes,
    out int bytesWritten) =>
    Utf8.TryWrite(
        utf8Bytes,
        CultureInfo.InvariantCulture,
        $"{major:X4}.{minor:X4}.{build:X4}.{revision:X4}",
        out bytesWritten);
```

The implementation recognizes <xref:System.IUtf8SpanFormattable> on the format values and uses their implementations to write their UTF8 representations directly to the destination span.

The implementation also utilizes the new <xref:System.Text.Encoding.TryGetBytes(System.ReadOnlySpan{System.Char},System.Span{System.Byte},System.Int32@)?displayProperty=nameWithType> method, which together with its <xref:System.Text.Encoding.TryGetChars(System.ReadOnlySpan{System.Byte},System.Span{System.Char},System.Int32@)?displayProperty=nameWithType> counterpart, supports encoding and decoding into a destination span. If the span isn't long enough to hold the resulting state, the methods return `false` rather than throwing an exception.

### Methods for working with randomness

The <xref:System.Random?displayProperty=fullName> and <xref:System.Security.Cryptography.RandomNumberGenerator?displayProperty=fullName> types introduce two new methods for working with randomness.

#### GetItems\<T>()

The new <xref:System.Random.GetItems%2A?displayProperty=fullName> and <xref:System.Security.Cryptography.RandomNumberGenerator.GetItems%2A?displayProperty=fullName> methods let you randomly choose a specified number of items from an input set. The following example shows how to use `System.Random.GetItems<T>()` (on the instance provided by the <xref:System.Random.Shared?displayProperty=nameWithType> property) to randomly insert 31 items into an array. This example could be used in a game of "Simon" where players must remember a sequence of colored buttons.

```csharp
private static ReadOnlySpan<Button> s_allButtons = new[]
{
    Button.Red,
    Button.Green,
    Button.Blue,
    Button.Yellow,
};

// ...

Button[] thisRound = Random.Shared.GetItems(s_allButtons, 31);
// Rest of game goes here ...
```

#### Shuffle\<T>()

The new <xref:System.Random.Shuffle%2A?displayProperty=nameWithType> and <xref:System.Security.Cryptography.RandomNumberGenerator.Shuffle%60%601(System.Span{%60%600})?displayProperty=nameWithType> methods let you randomize the order of a span. These methods are useful for reducing training bias in machine learning (so the first thing isn't always training, and the last thing always test).

```csharp
YourType[] trainingData = LoadTrainingData();
Random.Shared.Shuffle(trainingData);

IDataView sourceData = mlContext.Data.LoadFromEnumerable(trainingData);

DataOperationsCatalog.TrainTestData split = mlContext.Data.TrainTestSplit(sourceData);
model = chain.Fit(split.TrainSet);

IDataView predictions = model.Transform(split.TestSet);
// ...
```

### Performance-focused types

.NET 8 introduces several new types aimed at improving app performance.

- The new <xref:System.Collections.Frozen?displayProperty=fullName> namespace includes the collection types <xref:System.Collections.Frozen.FrozenDictionary%602> and <xref:System.Collections.Frozen.FrozenSet%601>. These types don't allow any changes to keys and values once a collection created. That requirement allows faster read operations (for example, `TryGetValue()`). These types are particularly useful for collections that are populated on first use and then persisted for the duration of a long-lived service, for example:

  ```csharp
  private static readonly FrozenDictionary<string, bool> s_configurationData =
      LoadConfigurationData().ToFrozenDictionary(optimizeForReads: true);

  // ...
  if (s_configurationData.TryGetValue(key, out bool setting) && setting)
  {
      Process();
  }
  ```

- The new <xref:System.Buffers.SearchValues%601?displayProperty=fullName> type is designed to be passed to methods that look for the first occurrence of any value in the passed collection. For example, <xref:System.String.IndexOfAny(System.Char[])?displayProperty=nameWithType> looks for the first occurrence of any character in the specified array in the `string` it's called on. NET 8 adds new overloads of methods like <xref:System.String.IndexOfAny%2A?displayProperty=nameWithType> and <xref:System.MemoryExtensions.IndexOfAny%2A?displayProperty=nameWithType> that accept an instance of the new type. When you create an instance of <xref:System.Buffers.SearchValues%601?displayProperty=fullName>, all the data that's necessary to optimize subsequent searches is derived *at that time*, meaning the work is done up front.
- The new <xref:System.Text.CompositeFormat?displayProperty=fullName> type is useful for optimizing format strings that aren't known at compile time (for example, if the format string is loaded from a resource file). A little extra time is spent up front to do work such as parsing the string, but it saves the work from being done on each use.

  ```csharp
  private static readonly CompositeFormat s_rangeMessage =
      CompositeFormat.Parse(LoadRangeMessageResource());

  // ...
  static string GetMessage(int min, int max) =>
      string.Format(CultureInfo.InvariantCulture, s_rangeMessage, min, max);
  ```

- New <xref:System.IO.Hashing.XxHash3?displayProperty=fullName> and <xref:System.IO.Hashing.XxHash128?displayProperty=fullName> types provide implementations of the fast XXH3 and XXH128 hash algorithms.

### System.Numerics and System.Runtime.Intrinsics

This section covers improvements to the <xref:System.Numerics?displayProperty=fullName> and <xref:System.Runtime.Intrinsics?displayProperty=fullName> namespaces.

- <xref:System.Runtime.Intrinsics.Vector256%601>, <xref:System.Numerics.Matrix3x2>, and <xref:System.Numerics.Matrix4x4> have improved hardware acceleration on .NET 8. For example, <xref:System.Runtime.Intrinsics.Vector256%601> was reimplemented to internally be `2x Vector128<T>` operations, where possible. This allows partial acceleration of some functions when `Vector128.IsHardwareAccelerated == true` but `Vector256.IsHardwareAccelerated == false`, such as on Arm64.
- Hardware intrinsics are now annotated with the `ConstExpected` attribute. This ensures that users are aware when the underlying hardware expects a constant and therefore when a non-constant value may unexpectedly hurt performance.
- The <xref:System.Numerics.IFloatingPointIeee754%601.Lerp(%600,%600,%600)> `Lerp` API has been added to <xref:System.Numerics.IFloatingPointIeee754%601> and therefore to `float` (<xref:System.Single>), `double` (<xref:System.Double>), and <xref:System.Half>. This API allows a linear interpolation between two values to be performed efficiently and correctly.

#### Vector512 and AVX-512

.NET Core 3.0 expanded SIMD support to include the platform-specific hardware intrinsics APIs for x86/x64. .NET 5 added support for Arm64 and .NET 7 added the cross-platform hardware intrinsics. .NET 8 furthers SIMD support by introducing <xref:System.Runtime.Intrinsics.Vector512%601> and support for [Intel Advanced Vector Extensions 512 (AVX-512)](https://www.intel.com/content/www/us/en/developer/articles/technical/intel-avx-512-instructions.html) instructions.

Specifically, .NET 8 includes support for the following key features of AVX-512:

- 512-bit vector operations
- Additional 16 SIMD registers
- Additional instructions available for 128-bit, 256-bit, and 512-bit vectors

If you have hardware that supports the functionality, then <xref:System.Runtime.Intrinsics.Vector512.IsHardwareAccelerated?displayProperty=nameWithType> now reports `true`.

.NET 8 also adds several platform-specific classes under the <xref:System.Runtime.Intrinsics.X86?displayProperty=fullName> namespace:

- <xref:System.Runtime.Intrinsics.X86.Avx512F> (foundational)
- <xref:System.Runtime.Intrinsics.X86.Avx512BW> (byte and word)
- <xref:System.Runtime.Intrinsics.X86.Avx512CD> (conflict detection)
- <xref:System.Runtime.Intrinsics.X86.Avx512DQ> (doubleword and quadword)
- <xref:System.Runtime.Intrinsics.X86.Avx512Vbmi> (vector byte manipulation instructions)

These classes follow the same general shape as other instruction set architectures (ISAs) in that they expose an <xref:System.Runtime.Intrinsics.X86.Avx512F.IsSupported> property and a nested <xref:System.Runtime.Intrinsics.X86.Avx512F.X64> class for instructions available only to 64-bit processes. Additionally, each class has a nested <xref:System.Runtime.Intrinsics.X86.Avx512F.VL> class that exposes the `Avx512VL` (vector length) extensions for the corresponding instruction set.

Even if you don't explicitly use `Vector512`-specific or `Avx512F`-specific instructions in your code, you'll likely still benefit from the new AVX-512 support. The JIT can take advantage of the additional registers and instructions implicitly when using <xref:System.Runtime.Intrinsics.Vector128%601> or <xref:System.Runtime.Intrinsics.Vector256%601>. The base class library uses these hardware intrinsics internally in most operations exposed by <xref:System.Span%601> and <xref:System.ReadOnlySpan%601> and in many of the math APIs exposed for the primitive types.

### Data validation

The <xref:System.ComponentModel.DataAnnotations?displayProperty=fullName> namespace includes new data validation attributes intended for validation scenarios in cloud-native services. While the pre-existing `DataAnnotations` validators are geared towards typical UI data-entry validation, such as fields on a form, the new attributes are designed to validate non-user-entry data, such as [configuration options](../extensions/options.md#options-validation). In addition to the new attributes, new properties were added to the <xref:System.ComponentModel.DataAnnotations.RangeAttribute> and <xref:System.ComponentModel.DataAnnotations.RequiredAttribute> types.

| New API | Description |
|--|--|
| <xref:System.ComponentModel.DataAnnotations.RangeAttribute.MinimumIsExclusive?displayProperty=nameWithType><br/><xref:System.ComponentModel.DataAnnotations.RangeAttribute.MaximumIsExclusive?displayProperty=nameWithType> | Specifies whether bounds are included in the allowable range. |
| <xref:System.ComponentModel.DataAnnotations.LengthAttribute?displayProperty=nameWithType> | Specifies both lower and upper bounds for strings or collections. For example, `[Length(10, 20)]` requires at least 10 elements and at most 20 elements in a collection. |
| <xref:System.ComponentModel.DataAnnotations.Base64StringAttribute?displayProperty=nameWithType> | Validates that a string is a valid Base64 representation. |
| <xref:System.ComponentModel.DataAnnotations.AllowedValuesAttribute?displayProperty=nameWithType><br/><xref:System.ComponentModel.DataAnnotations.DeniedValuesAttribute?displayProperty=nameWithType> | Specify allow lists and deny lists, respectively. For example, `[AllowedValues("apple", "banana", "mango")]`. |

### Metrics

New APIs let you attach key-value pair tags to <xref:System.Diagnostics.Metrics.Meter> and <xref:System.Diagnostics.Metrics.Instrument> objects when you create them. Aggregators of published metric measurements can use the tags to differentiate the aggregated values.

```csharp
var options = new MeterOptions("name")
{
    Version = "version",
    // Attach these tags to the created meter
    Tags = new TagList()
    {
        { "MeterKey1", "MeterValue1" },
        { "MeterKey2", "MeterValue2" }
    }
};

Meter meter = meterFactory.Create(options);

Instrument instrument = meter.CreateCounter<int>(
    "counter", null, null, new TagList() { { "counterKey1", "counterValue1" } }
);
instrument.Add(1);
```

The new APIs include:

- <xref:System.Diagnostics.Metrics.MeterOptions>
- <xref:System.Diagnostics.Metrics.Meter.%23ctor(System.Diagnostics.Metrics.MeterOptions)>
- <xref:System.Diagnostics.Metrics.Meter.CreateCounter%60%601(System.String,System.String,System.String,System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}})>

### Cryptography

.NET 8 adds support for the SHA-3 hashing primitives. (SHA-3 is currently supported by Linux with OpenSSL 1.1.1 or later and Windows 11 Build 25324 or later.) APIs where SHA-2 is available now offer a SHA-3 compliment. This includes `SHA3_256`, `SHA3_384`, and `SHA3_512` for hashing; `HMACSHA3_256`, `HMACSHA3_384`, and `HMACSHA3_512` for HMAC; `HashAlgorithmName.SHA3_256`, `HashAlgorithmName.SHA3_384`, and `HashAlgorithmName.SHA3_512` for hashing where the algorithm is configurable; and `RSAEncryptionPadding.OaepSHA3_256`, `RSAEncryptionPadding.OaepSHA3_384`, and `RSAEncryptionPadding.OaepSHA3_512` for RSA OAEP encryption.

The following example shows how to use the APIs, including the `SHA3_256.IsSupported` property to determine if the platform supports SHA-3.

```csharp
// Hashing example
if (SHA3_256.IsSupported)
{
    byte[] hash = SHA3_256.HashData(dataToHash);
}
else
{
    // ...
}

// Signing example
if (SHA3_256.IsSupported)
{
     using ECDsa ec = ECDsa.Create(ECCurve.NamedCurves.nistP256);
     byte[] signature = ec.SignData(dataToBeSigned, HashAlgorithmName.SHA3_256);
}
else
{
    // ...
}
```

SHA-3 support is currently aimed at supporting cryptographic primitives. Higher-level constructions and protocols aren't expected to fully support SHA-3 initially. These protocols include X.509 certificates, <xref:System.Security.Cryptography.Xml.SignedXml>, and COSE.

### Networking

#### Support for HTTPS proxy

Until now, the proxy types that <xref:System.Net.Http.HttpClient> supported all allowed a "man-in-the-middle" to see which site the client is connecting to, even for HTTPS URIs. <xref:System.Net.Http.HttpClient> now supports *HTTPS proxy*, which creates an encrypted channel between the client and the proxy so all requests can be handled with full privacy.

To enable HTTPS proxy, set the `all_proxy` environment variable, or use the <xref:System.Net.WebProxy> class to control the proxy programmatically.

Unix: `export all_proxy=https://x.x.x.x:3218`
Windows: `set all_proxy=https://x.x.x.x:3218`

You can also use the <xref:System.Net.WebProxy> class to control the proxy programmatically.

### Stream-based ZipFile methods

.NET 8 includes new overloads of <xref:System.IO.Compression.ZipFile.CreateFromDirectory%2A?displayProperty=nameWithType> that allow you to collect all the files included in a directory and zip them, then store the resulting zip file into the provided stream. Similarly, new <xref:System.IO.Compression.ZipFile.ExtractToDirectory%2A?displayProperty=nameWithType> overloads let you provide a stream containing a zipped file and extract its contents into the filesystem. These are the new overloads:

```csharp
namespace System.IO.Compression;

public static partial class ZipFile
{
    public static void CreateFromDirectory(
        string sourceDirectoryName, Stream destination);

    public static void CreateFromDirectory(
        string sourceDirectoryName,
        Stream destination,
        CompressionLevel compressionLevel,
        bool includeBaseDirectory);

    public static void CreateFromDirectory(
        string sourceDirectoryName,
        Stream destination,
        CompressionLevel compressionLevel,
        bool includeBaseDirectory,
    Encoding? entryNameEncoding);

    public static void ExtractToDirectory(
        Stream source, string destinationDirectoryName) { }

    public static void ExtractToDirectory(
        Stream source, string destinationDirectoryName, bool overwriteFiles) { }

    public static void ExtractToDirectory(
        Stream source, string destinationDirectoryName, Encoding? entryNameEncoding) { }

    public static void ExtractToDirectory(
        Stream source, string destinationDirectoryName, Encoding? entryNameEncoding, bool overwriteFiles) { }
}
```

These new APIs can be useful when disk space is constrained, because they avoid having to use the disk as an intermediate step.

## Extension libraries

This section contains the following subtopics:

- [Options validation](#options-validation)
- [LoggerMessageAttribute constructors](#loggermessageattribute-constructors)
- [Extensions metrics](#extensions-metrics)
- [Hosted lifecycle services](#hosted-lifecycle-services)
- [Keyed DI services](#keyed-di-services)
- [System.Numerics.Tensors.TensorPrimitives](#systemnumericstensorstensorprimitives)

### Keyed DI services

Keyed dependency injection (DI) services provides a means for registering and retrieving DI services using keys. By using keys, you can scope how your register and consume services. These are some of the new APIs:

- The <xref:Microsoft.Extensions.DependencyInjection.IKeyedServiceProvider> interface.
- The <xref:Microsoft.Extensions.DependencyInjection.ServiceKeyAttribute> attribute, which can be used to inject the key that was used for registration/resolution in the constructor.
- The <xref:Microsoft.Extensions.DependencyInjection.FromKeyedServicesAttribute> attribute, which can be used on service constructor parameters to specify which keyed service to use.
- Various new extension methods for <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection> to support keyed services, for example, <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddKeyedScoped%2A?displayProperty=nameWithType>.
- The <xref:Microsoft.Extensions.DependencyInjection.ServiceProvider> implementation of <xref:Microsoft.Extensions.DependencyInjection.IKeyedServiceProvider>.

The following example shows you how to use keyed DI services.

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<BigCacheConsumer>();
builder.Services.AddSingleton<SmallCacheConsumer>();
builder.Services.AddKeyedSingleton<ICache, BigCache>("big");
builder.Services.AddKeyedSingleton<ICache, SmallCache>("small");
var app = builder.Build();
app.MapGet("/big", (BigCacheConsumer data) => data.GetData());
app.MapGet("/small", (SmallCacheConsumer data) => data.GetData());
app.MapGet("/big-cache", ([FromKeyedServices("big")] ICache cache) => cache.Get("data"));
app.MapGet("/small-cache", (HttpContext httpContext) => httpContext.RequestServices.GetRequiredKeyedService<ICache>("small").Get("data"));
app.Run();

class BigCacheConsumer([FromKeyedServices("big")] ICache cache)
{
    public object? GetData() => cache.Get("data");
}

class SmallCacheConsumer(IServiceProvider serviceProvider)
{
    public object? GetData() => serviceProvider.GetRequiredKeyedService<ICache>("small").Get("data");
}

public interface ICache
{
    object Get(string key);
}

public class BigCache : ICache
{
    public object Get(string key) => $"Resolving {key} from big cache.";
}

public class SmallCache : ICache
{
    public object Get(string key) => $"Resolving {key} from small cache.";
}
```

For more information, see [dotnet/runtime#64427](https://github.com/dotnet/runtime/issues/64427).

### Hosted lifecycle services

Hosted services now have more options for execution during the application lifecycle. <xref:Microsoft.Extensions.Hosting.IHostedService> provided `StartAsync` and `StopAsync`, and now <xref:Microsoft.Extensions.Hosting.IHostedLifecycleService> provides these additional methods:

- <xref:Microsoft.Extensions.Hosting.IHostedLifecycleService.StartingAsync(System.Threading.CancellationToken)>
- <xref:Microsoft.Extensions.Hosting.IHostedLifecycleService.StartedAsync(System.Threading.CancellationToken)>
- <xref:Microsoft.Extensions.Hosting.IHostedLifecycleService.StoppingAsync(System.Threading.CancellationToken)>
- <xref:Microsoft.Extensions.Hosting.IHostedLifecycleService.StoppedAsync(System.Threading.CancellationToken)>

These methods run before and after the existing points respectively.

The following example shows how to use the new APIs.

```csharp
using Microsoft.Extensions.Hosting;

IHostBuilder hostBuilder = new HostBuilder();
hostBuilder.ConfigureServices(services =>
{
    services.AddHostedService<MyService>();
});

using (IHost host = hostBuilder.Build())
{
    await host.StartAsync();
}

public class MyService : IHostedLifecycleService
{
    public Task StartingAsync(CancellationToken cancellationToken) => /* add logic here */ Task.CompletedTask;
    public Task StartAsync(CancellationToken cancellationToken) => /* add logic here */ Task.CompletedTask;
    public Task StartedAsync(CancellationToken cancellationToken) => /* add logic here */ Task.CompletedTask;
    public Task StopAsync(CancellationToken cancellationToken) => /* add logic here */ Task.CompletedTask;
    public Task StoppedAsync(CancellationToken cancellationToken) => /* add logic here */ Task.CompletedTask;
    public Task StoppingAsync(CancellationToken cancellationToken) => /* add logic here */ Task.CompletedTask;
}
```

For more information, see [dotnet/runtime#86511](https://github.com/dotnet/runtime/issues/86511).

### Options validation

#### Source generator

To reduce startup overhead and improve validation feature set, we've introduced a source code generator that implements the validation logic. The following code shows example models and validator classes.

```csharp
public class FirstModelNoNamespace
{
    [Required]
    [MinLength(5)]
    public string P1 { get; set; } = string.Empty;

    [Microsoft.Extensions.Options.ValidateObjectMembers(
        typeof(SecondValidatorNoNamespace))]
    public SecondModelNoNamespace? P2 { get; set; }
}

public class SecondModelNoNamespace
{
    [Required]
    [MinLength(5)]
    public string P4 { get; set; } = string. Empty;
}

[OptionsValidator]
public partial class FirstValidatorNoNamespace 
    : IValidateOptions<FirstModelNoNamespace>
{
}

[OptionsValidator]
public partial class SecondValidatorNoNamespace 
    : IValidateOptions<SecondModelNoNamespace>
{
}
```

If your app uses dependency injection, you can inject the validation as shown in the following example code.

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.Configure<FirstModelNoNamespace>(
    builder.Configuration.GetSection(...));

builder.Services.AddSingleton<
    IValidateOptions<FirstModelNoNamespace>, FirstValidatorNoNamespace>();
builder.Services.AddSingleton<
    IValidateOptions<SecondModelNoNamespace>, SecondValidatorNoNamespace>();
```

#### ValidateOptionsResultBuilder type

.NET 8 introduces the <xref:Microsoft.Extensions.Options.ValidateOptionsResultBuilder> type to facilitate the creation of a <xref:Microsoft.Extensions.Options.ValidateOptionsResult> object. Importantly, this builder allows for the accumulation of multiple errors. Previously, creating the <xref:Microsoft.Extensions.Options.ValidateOptionsResult> object that's required to implement <xref:Microsoft.Extensions.Options.IValidateOptions%601.Validate(System.String,%600)?displayProperty=nameWithType> was difficult and sometimes resulted in layered validation errors. If there were multiple errors, the validation process often stopped at the first error.

The following code snippet shows an example usage of <xref:Microsoft.Extensions.Options.ValidateOptionsResultBuilder>.

```csharp
ValidateOptionsResultBuilder builder = new();
builder.AddError("Error: invalid operation code");
builder.AddResult(ValidateOptionsResult.Fail("Invalid request parameters"));
builder.AddError("Malformed link", "Url");

// Build ValidateOptionsResult object has accumulating multiple errors.
ValidateOptionsResult result = builder.Build();

// Reset the builder to allow using it in new validation operation.
builder.Clear();
```

### LoggerMessageAttribute constructors

<xref:Microsoft.Extensions.Logging.LoggerMessageAttribute> now offers additional constructor overloads. Previously, you had to choose either the parameterless constructor or the constructor that required all of the parameters (event ID, log level, and message). The new overloads offer greater flexibility in specifying the required parameters with reduced code. If you don't supply an event ID, the system generates one automatically.

```csharp
public LoggerMessageAttribute(LogLevel level, string message);
public LoggerMessageAttribute(LogLevel level);
public LoggerMessageAttribute(string message);
```

### Extensions metrics

#### IMeterFactory interface

You can register the new <xref:System.Diagnostics.Metrics.IMeterFactory> interface in dependency injection (DI) containers and use it to create <xref:System.Diagnostics.Metrics.Meter> objects in an isolated manner.

Register the <xref:System.Diagnostics.Metrics.IMeterFactory> to the DI container using the default meter factory implementation:

```csharp
// 'services' is the DI IServiceCollection.
services.AddMetrics();
```

Consumers can then obtain the meter factory and use it to create a new <xref:System.Diagnostics.Metrics.Meter> object.

```csharp
IMeterFactory meterFactory = serviceProvider.GetRequiredService<IMeterFactory>();

MeterOptions options = new MeterOptions("MeterName")
{
    Version = "version",
};

Meter meter = meterFactory.Create(options);
```

#### MetricCollector\<T> class

The new <xref:Microsoft.Extensions.Diagnostics.Metrics.Testing.MetricCollector%601> class lets you record metric measurements along with timestamps. Additionally, the class offers the flexibility to use a time provider of your choice for accurate timestamp generation.

```csharp
const string CounterName = "MyCounter";

var now = DateTimeOffset.Now;

var timeProvider = new FakeTimeProvider(now);
using var meter = new Meter(Guid.NewGuid().ToString());
var counter = meter.CreateCounter<long>(CounterName);
using var collector = new MetricCollector<long>(counter, timeProvider);

Assert.Empty(collector.GetMeasurementSnapshot());
Assert.Null(collector.LastMeasurement);

counter. Add(3);

// Verify the update was recorded.
Assert.Equal(counter, collector.Instrument);
Assert.NotNull(collector.LastMeasurement);

Assert.Single(collector.GetMeasurementSnapshot());
Assert.Same(collector.GetMeasurementSnapshot().Last(), collector.LastMeasurement);
Assert.Equal(3, collector.LastMeasurement.Value);
Assert.Empty(collector.LastMeasurement.Tags);
Assert.Equal(now, collector.LastMeasurement.Timestamp);
```

### System.Numerics.Tensors.TensorPrimitives

The updated [System.Numerics.Tensors](https://www.nuget.org/packages/System.Numerics.Tensors) NuGet package includes APIs in the new <xref:System.Numerics.Tensors.TensorPrimitives> namespace that add support for tensor operations. The tensor primitives optimize data-intensive workloads like those of AI and machine learning.

AI workloads like semantic search and retrieval-augmented generation (RAG) extend the natural language capabilities of large language models such as ChatGPT by augmenting prompts with relevant data. For these workloads, operations on vectors&mdash;like *cosine similarity* to find the most relevant data to answer a question&mdash;are crucial. The System.Numerics.Tensors.TensorPrimitives package provides APIs for vector operations, meaning you don't need to take an external dependency or write your own implementation.

This package replaces the [System.Numerics.Tensors package](https://www.nuget.org/packages/System.Numerics.Tensors).

For more information, see the [Announcing .NET 8 RC 2 blog post](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-rc2/).

## Garbage collection

.NET 8 adds a capability to adjust the memory limit on the fly. This is useful in cloud-service scenarios, where demand comes and goes. To be cost-effective, services should scale up and down on resource consumption as the demand fluctuates. When a service detects a decrease in demand, it can scale down resource consumption by reducing its memory limit. Previously, this would fail because the garbage collector (GC) was unaware of the change and might allocate more memory than the new limit. With this change, you can call the <xref:System.GC.RefreshMemoryLimit> API to update the GC with the new memory limit.

There are some limitations to be aware of:

- On 32-bit platforms (for example, Windows x86 and Linux ARM), .NET is unable to establish a new heap hard limit if there isn't already one.
- The API might return a non-zero status code indicating the refresh failed. This can happen if the scale-down is too aggressive and leaves no room for the GC to maneuver. In this case, consider calling `GC.Collect(2, GCCollectionMode.Aggressive)` to shrink the current memory usage, and then try again.
- If you scale up the memory limit beyond the size that the GC believes the process can handle during startup, the `RefreshMemoryLimit` call will succeed, but it won't be able to use more memory than what it perceives as the limit.

The following code snippet shows how to call the API.

```csharp
GC.RefreshMemoryLimit();
```

You can also refresh some of the GC configuration settings related to the memory limit. The following code snippet sets the heap hard limit to 100 mebibytes (MiB):

```csharp
AppContext.SetData("GCHeapHardLimit", (ulong)100 * 1_024 * 1_024);
GC.RefreshMemoryLimit();
```

The API can throw an <xref:System.InvalidOperationException> if the hard limit is invalid, for example, in the case of negative heap hard limit percentages and if the hard limit is too low. This can happen if the heap hard limit that the refresh will set, either because of new AppData settings or implied by the container memory limit changes, is lower than what's already committed.

## Configuration-binding source generator

.NET 8 introduces a source generator to provide AOT and trim-friendly [configuration](/aspnet/core/fundamentals/configuration/) in ASP.NET Core. The generator is an alternative to the pre-existing reflection-based implementation.

The source generator probes for <xref:Microsoft.Extensions.Options.ConfigureOptions%601.Configure(%600)>, <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind%2A>, and <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get%2A> calls to retrieve type info from. When the generator is enabled in a project, the compiler implicitly chooses generated methods over the pre-existing reflection-based framework implementations.

No source code changes are needed to use the generator. It's enabled by default in AOT'd web apps. For other project types, the source generator is off by default, but you can opt in by setting the `EnableConfigurationBindingGenerator` property to `true` in your project file:

```xml
<PropertyGroup>
    <EnableConfigurationBindingGenerator>true</EnableConfigurationBindingGenerator>
</PropertyGroup>
```

The following code shows an example of invoking the binder.

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IConfigurationSection section = builder.Configuration.GetSection("MyOptions");

// !! Configure call - to be replaced with source-gen'd implementation
builder.Services.Configure<MyOptions>(section);

// !! Get call - to be replaced with source-gen'd implementation
MyOptions options0 = section.Get<MyOptions>();

// !! Bind call - to be replaced with source-gen'd implementation
MyOptions options1 = new MyOptions();
section.Bind(options1);

WebApplication app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.Run();

public class MyOptions
{
    public int A { get; set; }
    public string S { get; set; }
    public byte[] Data { get; set; }
    public Dictionary<string, string> Values { get; set; }
    public List<MyClass> Values2 { get; set; }
}

public class MyClass
{
    public int SomethingElse { get; set; }
}
```

## Reflection improvements

[Function pointers](../../csharp/language-reference/unsafe-code.md#function-pointers) were introduced in .NET 5, however, the corresponding support for reflection wasn't added at that time. When using `typeof` or reflection on a function pointer, for example, `typeof(delegate*<void>())` or `FieldInfo.FieldType` respectively, an <xref:System.IntPtr> was returned. Starting in .NET 8, a <xref:System.Type?displayProperty=nameWithType> object is returned instead. This type provides access to function pointer metadata, including the calling conventions, return type, and parameters.

> [!NOTE]
> A function pointer instance, which is a physical address to a function, continues to be represented as an <xref:System.IntPtr>. Only the reflection type has changed.

The new functionality is currently implemented only in the CoreCLR runtime and <xref:System.Reflection.MetadataLoadContext>.

New APIs have been added to <xref:System.Type?displayProperty=fullName>, such as <xref:System.Type.IsFunctionPointer>, and to <xref:System.Reflection.PropertyInfo?displayProperty=fullName>, <xref:System.Reflection.FieldInfo?displayProperty=fullName>, and <xref:System.Reflection.ParameterInfo?displayProperty=fullName>. The following code shows how to use some of the new APIs for reflection.

```csharp
// Sample class that contains a function pointer field.
public unsafe class UClass
{
    public delegate* unmanaged[Cdecl, SuppressGCTransition]<in int, void> _fp;
}

// ...

FieldInfo fieldInfo = typeof(UClass).GetField(nameof(UClass._fp));

// Obtain the function pointer type from a field.
Type fpType = fieldInfo.FieldType;

// New methods to determine if a type is a function pointer.
Console.WriteLine(
    $"IsFunctionPointer: {fpType.IsFunctionPointer}");
Console.WriteLine(
    $"IsUnmanagedFunctionPointer: {fpType.IsUnmanagedFunctionPointer}");

// New methods to obtain the return and parameter types.
Console.WriteLine($"Return type: {fpType.GetFunctionPointerReturnType()}");

foreach (Type parameterType in fpType.GetFunctionPointerParameterTypes())
{
    Console.WriteLine($"Parameter type: {parameterType}");
}

// Access to custom modifiers and calling conventions requires a "modified type".
Type modifiedType = fieldInfo.GetModifiedFieldType();

// A modified type forwards most members to its underlying type.
Type normalType = modifiedType.UnderlyingSystemType;

// New method to obtain the calling conventions.
foreach (Type callConv in modifiedType.GetFunctionPointerCallingConventions())
{
    Console.WriteLine($"Calling convention: {callConv}");
}

// New method to obtain the custom modifiers.
var modifiers =
    modifiedType.GetFunctionPointerParameterTypes()[0].GetRequiredCustomModifiers();

foreach (Type modreq in modifiers)
{
    Console.WriteLine($"Required modifier for first parameter: {modreq}");
}
```

The previous example produces the following output:

```Output
IsFunctionPointer: True
IsUnmanagedFunctionPointer: True
Return type: System.Void
Parameter type: System.Int32&
Calling convention: System.Runtime.CompilerServices.CallConvSuppressGCTransition
Calling convention: System.Runtime.CompilerServices.CallConvCdecl
Required modifier for first parameter: System.Runtime.InteropServices.InAttribute
```

## Native AOT support

The option to [publish as Native AOT](../deploying/native-aot/index.md) was first introduced in .NET 7. Publishing an app with Native AOT creates a fully self-contained version of your app that doesn't need a runtime&mdash;everything is included in a single file. .NET 8 brings the following improvements to Native AOT publishing:

- Adds support for the x64 and Arm64 architectures on *macOS*.
- Reduces the sizes of Native AOT apps on Linux by up to 50%. The following table shows the size of a "Hello World" app published with Native AOT that includes the entire .NET runtime on .NET 7 vs. .NET 8:

  | Operating system                        | .NET 7  | .NET 8  |
  |-----------------------------------------|---------|---------|
  | Linux x64 (with `-p:StripSymbols=true`) | 3.76 MB | 1.84 MB |
  | Windows x64                             | 2.85 MB | 1.77 MB |

- Lets you specify an optimization preference: size or speed. By default, the compiler chooses to generate fast code while being mindful of the size of the application. However, you can use the `<OptimizationPreference>` MSBuild property to optimize specifically for one or the other. For more information, see [Optimize AOT deployments](../deploying/native-aot/optimizing.md).

### Console app template

The default console app template now includes support for AOT out-of-the-box. To create a project that's configured for AOT compilation, just run `dotnet new console --aot`. The project configuration added by `--aot` has three effects:

- Generates a native self-contained executable with Native AOT when you publish the project, for example, with `dotnet publish` or Visual Studio.
- Enables compatibility analyzers for trimming, AOT, and single file. These analyzers alert you to potentially problematic parts of your project (if there are any).
- Enables debug-time emulation of AOT so that when you debug your project without AOT compilation, you get a similar experience to AOT. For example, if you use <xref:System.Reflection.Emit?displayProperty=nameWithType> in a NuGet package that wasn't annotated for AOT (and therefore was missed by the compatibility analyzer), the emulation means you won't have any surprises when you try to publish the project with AOT.

### Target iOS-like platforms with Native AOT

.NET 8 starts the work to enable Native AOT support for iOS-like platforms. You can now build and run .NET iOS and .NET MAUI applications with Native AOT on the following platforms:

- `ios`
- `iossimulator`
- `maccatalyst`
- `tvos`
- `tvossimulator`

Preliminary testing shows that app size on disk decreases by about 35% for .NET iOS apps that use Native AOT instead of Mono. App size on disk for .NET MAUI iOS apps decreases up to 50%. Additionally, the startup time is also faster. .NET iOS apps have about 28% faster startup time, while .NET MAUI iOS apps have about 50% better startup performance compared to Mono. The .NET 8 support is experimental and only the first step for the feature as a whole. For more information, see the [.NET 8 Performance Improvements in .NET MAUI blog post](https://devblogs.microsoft.com/dotnet/dotnet-8-performance-improvements-in-dotnet-maui/).

Native AOT support is available as an opt-in feature intended for app deployment; Mono is still the default runtime for app development and deployment. To build and run a .NET MAUI application with Native AOT on an iOS device, use `dotnet workload install maui` to install the .NET MAUI workload and `dotnet new maui -n HelloMaui` to create the app. Then, set the MSBuild property `PublishAot` to `true` in the project file.

```xml
<PropertyGroup>
  <PublishAot>true</PublishAot>
</PropertyGroup>
```

When you set the required property and run `dotnet publish` as shown in the following example, the app will be deployed by using Native AOT.

```dotnetcli
dotnet publish -f net8.0-ios -c Release -r ios-arm64  /t:Run
```

#### Limitations

Not all iOS features are compatible with Native AOT. Similarly, not all libraries commonly used in iOS are compatible with NativeAOT. And in addition to the existing [limitations of Native AOT deployment](../deploying/native-aot/index.md#limitations-of-native-aot-deployment), the following list shows some of the other limitations when targeting iOS-like platforms:

- Using Native AOT is only enabled during app deployment (`dotnet publish`).
- Managed code debugging is only supported with Mono.
- Compatibility with the .NET MAUI framework is limited.

## Performance improvements

.NET 8 includes improvements to code generation and just-in time (JIT) compilation:

- Arm64 performance improvements
- SIMD improvements
- Support for AVX-512 ISA extensions (see [Vector512 and AVX-512](#vector512-and-avx-512))
- Cloud-native improvements
- JIT throughput improvements
- Loop and general optimizations
- Optimized access for fields marked with <xref:System.ThreadStaticAttribute>
- Consecutive register allocation. Arm64 has two instructions for table vector lookup, which require that all entities in their tuple operands are present in consecutive registers.
- JIT/NativeAOT can now unroll and auto-vectorize some memory operations with SIMD, such as comparison, copying, and zeroing, if it can determine their sizes at compile time.

In addition, dynamic profile-guided optimization (PGO) has been improved and is now enabled by default. You no longer need to use a [runtime configuration option](../runtime-config/compilation.md#profile-guided-optimization) to enable it. Dynamic PGO works hand-in-hand with tiered compilation to further optimize code based on additional instrumentation that's put in place during tier 0.

On average, dynamic PGO increases performance by about 15%. In a benchmark suite of ~4600 tests, 23% saw performance improvements of 20% or more.

### Codegen struct promotion

.NET 8 includes a new physical promotion optimization pass for codegen that generalizes the JIT's ability to promote struct variables. This optimization (also called *scalar replacement of aggregates*) replaces the fields of struct variables by primitive variables that the JIT is then able to reason about and optimize more precisely.

The JIT already supported this optimization but with several large limitations including:

- It was only supported for structs with four or fewer fields.
- It was only supported if each field was a primitive type, or a simple struct wrapping a primitive type.

Physical promotion removes these limitations, which fixes a number of long-standing JIT issues.

## .NET MAUI

For information about what's new in .NET MAUI in .NET 8, see [What's new in .NET MAUI for .NET 8](/dotnet/maui/whats-new/dotnet-8).

## .NET SDK

This section contains the following subtopics:

- [CLI-based project evaluation](#cli-based-project-evaluation)
- [Terminal build output](#terminal-build-output)
- [Simplified output paths](#simplified-output-paths)
- ['dotnet workload clean' command](#dotnet-workload-clean-command)
- ['dotnet publish' and 'dotnet pack' assets](#dotnet-publish-and-dotnet-pack-assets)
- [Template engine](#template-engine)
- [Source Link](#source-link)
- [Source-build SDK](#source-build-sdk)

### CLI-based project evaluation

MSBuild includes a new feature that makes it easier to incorporate data from MSBuild into your scripts or tools. The following new flags are available for CLI commands such as [dotnet publish](../tools/dotnet-publish.md) to obtain data for use in CI pipelines and elsewhere.

| Flag                              | Description                                              |
|-----------------------------------|----------------------------------------------------------|
| `--getProperty:<PROPERTYNAME>`    | Retrieves the MSBuild property with the specified name.  |
| `--getItem:<ITEMTYPE>`            | Retrieves MSBuild items of the specified type.           |
| `--getTargetResults:<TARGETNAME>` | Retrieves the outputs from running the specified target. |

Values are written to the standard output. Multiple or complex values are output as JSON, as shown in the following examples.

```dotnetcli
>dotnet publish --getProperty:OutputPath
bin\Release\net8.0\
```

```dotnetcli
>dotnet publish -p PublishProfile=DefaultContainer --getProperty:GeneratedContainerDigest --getProperty:GeneratedContainerConfiguration
{
  "Properties": {
    "GeneratedContainerDigest": "sha256:ef880a503bbabcb84bbb6a1aa9b41b36dc1ba08352e7cd91c0993646675174c4",
    "GeneratedContainerConfiguration": "{\u0022config\u0022:{\u0022ExposedPorts\u0022:{\u00228080/tcp\u0022:{}},\u0022Labels\u0022...}}"
  }
}
```

```dotnetcli
>dotnet publish -p PublishProfile=DefaultContainer --getItem:ContainerImageTags
{
  "Items": {
    "ContainerImageTags": [
      {
        "Identity": "latest",
        ...
    ]
  }
}
```

### Terminal build output

`dotnet build` has a new option to produce more modernized build output. This *terminal logger* output groups errors with the project they came from, better differentiates the different target frameworks for multi-targeted projects, and provides real-time information about what the build is doing. To opt into the new output, use the `--tl` option. For more information about this option, see [dotnet build options](../tools/dotnet-build.md#options).

### Simplified output paths

.NET 8 introduces an option to simplify the output path and folder structure for build outputs. Previously, .NET apps produced a deep and complex set of output paths for different build artifacts. The new, simplified output path structure gathers all build outputs into a common location, which makes it easier for tooling to anticipate.

For more information, see [Artifacts output layout](../sdk/artifacts-output.md).

### `dotnet workload clean` command

.NET 8 introduces a new command to clean up workload packs that might be left over through several .NET SDK or Visual Studio updates. If you encounter issues when managing workloads, consider using `workload clean` to safely restore to a known state before trying again. The command has two modes:

- `dotnet workload clean`

  Runs [workload garbage collection](https://github.com/dotnet/designs/blob/main/accepted/2021/workloads/workload-installation.md#workload-pack-installation-records-and-garbage-collection) for file-based or MSI-based workloads, which cleans up orphaned packs. Orphaned packs are from uninstalled versions of the .NET SDK or packs where installation records for the pack no longer exist.

  If Visual Studio is installed, the command also lists any workloads that you should clean up manually using Visual Studio.

- `dotnet workload clean --all`

  This mode is more aggressive and cleans every pack on the machine that's of the current SDK workload installation type (and that's not from Visual Studio). It also removes all workload installation records for the running .NET SDK feature band and below.

### `dotnet publish` and `dotnet pack` assets

Since the [`dotnet publish`](../tools/dotnet-publish.md) and [`dotnet pack`](../tools/dotnet-pack.md) commands are intended to produce production assets, they now produce `Release` assets by default.

The following output shows the different behavior between `dotnet build` and `dotnet publish`, and how you can revert to publishing `Debug` assets by setting the `PublishRelease` property to `false`.

```console
/app# dotnet new console
/app# dotnet build
  app -> /app/bin/Debug/net8.0/app.dll
/app# dotnet publish
  app -> /app/bin/Release/net8.0/app.dll
  app -> /app/bin/Release/net8.0/publish/
/app# dotnet publish -p:PublishRelease=false
  app -> /app/bin/Debug/net8.0/app.dll
  app -> /app/bin/Debug/net8.0/publish/
```

For more information, see ['dotnet pack' uses Release config](../compatibility/sdk/8.0/dotnet-pack-config.md) and ['dotnet publish' uses Release config](../compatibility/sdk/8.0/dotnet-publish-config.md).

### `dotnet restore` security auditing

Starting in .NET 8, you can opt into security checks for known vulnerabilities when dependency packages are restored. This auditing produces a report of security vulnerabilities with the affected package name, the severity of the vulnerability, and a link to the advisory for more details. When you run `dotnet add` or `dotnet restore`, warnings NU1901-NU1904 will appear for any vulnerabilities that are found. For more information, see [Audit for security vulnerabilities](../tools/dotnet-restore.md#audit-for-security-vulnerabilities).

### Template engine

The [template engine](https://github.com/dotnet/templating) provides a more secure experience in .NET 8 by integrating some of NuGet's security-related features. The improvements include:

- Prevent downloading packages from `http://` feeds by default. For example, the following command will fail to install the template package because the source URL doesn't use HTTPS.

  `dotnet new install console --add-source "http://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-public/nuget/v3/index.json"`

   You can override this limitation by using the `--force` flag.

- For `dotnet new`, `dotnet new install`, and `dotnet new update`, check for known vulnerabilities in the template package. If vulnerabilities are found and you wish to proceed, you must use the `--force` flag.

- For `dotnet new`, provide information about the template package owner. Ownership is verified by the NuGet portal and can be considered a trustworthy characteristic.

- For `dotnet search` and `dotnet uninstall`, indicate whether a template is installed from a package that's "trusted"&mdash;that is, it uses a [reserved prefix](/nuget/nuget-org/id-prefix-reservation).

### Source Link

[Source Link](../../standard/library-guidance/sourcelink.md) is now included in the .NET SDK. The goal is that by bundling Source Link into the SDK, instead of requiring a separate `<PackageReference>` for the package, more packages will include this information by default. That information will improve the IDE experience for developers.

### Source-build SDK

The Linux distribution-built (source-build) SDK now has the capability to build self-contained applications using the source-build runtime packages. The distribution-specific runtime package is bundled with the source-build SDK. During self-contained deployment, this bundled runtime package will be referenced, thereby enabling the feature for users.

## Globalization

### HybridGlobalization mode on iOS/tvOS/MacCatalyst

Mobile apps can now use a new *hybrid* globalization mode that uses a lighter ICU bundle. In hybrid mode, globalization data is partially pulled from the ICU bundle and partially from calls into Native API. It serves all the [locales supported by mobile](https://github.com/dotnet/icu/blob/dotnet/main/icu-filters/icudt_mobile.json).

`HybridGlobalization` is most suitable for apps that can't work in `InvariantGlobalization` mode and that use cultures that were trimmed from ICU data on mobile. You can also use it when you want to load a smaller ICU data file. (The *icudt_hybrid.dat* file is 34.5 % smaller than the default ICU data file *icudt.dat*.)

To use `HybridGlobalization` mode, set the MSBuild property to true:

```xml
<PropertyGroup>
  <HybridGlobalization>true</HybridGlobalization>
</PropertyGroup>
```

There are some limitations to be aware of:

- Due to limitations of Native API, not all globalization APIs are supported in hybrid mode.
- Some of the supported APIs have different behavior.

To make sure your application isn't affected, see [Behavioral differences](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-hybrid-mode.md#behavioral-differences).

## Containers

- [Container images](#container-images)
- [Container publishing](#container-publishing)

### Container images

The following changes have been made to .NET container images for .NET 8:

- [Generated-image defaults](#generated-image-defaults)
- [Debian 12](#debian-12)
- [Non-root user](#non-root-user)
- [Chiseled Ubuntu images](#chiseled-ubuntu-images)
- [Build multi-platform container images](#build-multi-platform-container-images)
- [ASP.NET composite images](#aspnet-composite-images)

#### Generated-image defaults

The new [`non-root` capability](#non-root-user) of the Microsoft .NET containers is now the default, which helps your apps stay secure-by-default. Change this default at any time by setting your own `ContainerUser`.

The default container tag is now `latest`. This default is in line with other tooling in the containers space and makes containers easier to use in inner development loops.

#### Debian 12

The container images now use [Debian 12 (Bookworm)](https://wiki.debian.org/DebianBookworm). Debian is the default Linux distro in the .NET container images.

#### Non-root user

Images include a `non-root` user. This user makes the images `non-root` capable. To run as `non-root`, add the following line at the end of your Dockerfile (or a similar instruction in your Kubernetes manifests):

```dockerfile
USER app
```

.NET 8 adds an environment variable for the UID for the `non-root` user, which is 64198. This environment variable is useful for the Kubernetes `runAsNonRoot` test, which requires that the container user be set via UID and not by name. This [dockerfile](https://github.com/dotnet/dotnet-docker/blob/e5bc76bca49a1bbf9c11e74a590cf6a9fe9dbf2a/samples/aspnetapp/Dockerfile.alpine-non-root#L27) shows an example usage.

The default port also changed from port `80` to `8080`. To support this change, a new environment variable `ASPNETCORE_HTTP_PORTS` is available to make it easier to change ports. The variable accepts a list of ports, which is simpler than the format required by `ASPNETCORE_URLS`. If you change the port back to port `80` using one of these variables, you can't run as `non-root`.

#### Chiseled Ubuntu images

[Chiseled Ubuntu images](https://hub.docker.com/r/ubuntu/dotnet-deps) are available for .NET 8. Chiseled images have a reduced attacked surface because they're ultra-small, have no package manager or shell, and are `non-root`. This type of image is for developers who want the benefit of appliance-style computing. Chiseled images are published to the [.NET nightly artifact registry](https://mcr.microsoft.com/product/dotnet/nightly/aspnet/tags).

#### Build multi-platform container images

Docker supports using and building [multi-platform images](https://docs.docker.com/build/building/multi-platform/) that work across multiple environments. .NET 8 introduces a new pattern that enables you to mix and match architectures with the .NET images you build. As an example, if you're using macOS and want to target an x64 cloud service in Azure, you can build the image by using the `--platform` switch as follows:

`docker build --pull -t app --platform linux/amd64`

The .NET SDK now supports `$TARGETARCH` values and the `-a` argument on restore. The following code snippet shows an example:

```dockerfile
RUN dotnet restore -a $TARGETARCH

# Copy everything else and build app.
COPY aspnetapp/. .
RUN dotnet publish -a $TARGETARCH --self-contained false --no-restore -o /app
```

For more information, see the [Improving multi-platform container support](https://devblogs.microsoft.com/dotnet/improving-multiplatform-container-support/) blog post.

#### ASP.NET composite images

As part of an effort to improve containerization performance, new ASP.NET Docker images are available that have a composite version of the runtime. This composite is built by compiling multiple MSIL assemblies into a single ready-to-run (R2R) output binary. Because these assemblies are embedded into a single image, jitting takes less time, and the startup performance of apps improves. The other big advantage of the composite over the regular ASP.NET image is that the composite images have a smaller size on disk.

There is a caveat to be aware of. Since composites have multiple assemblies embedded into one, they have tighter version coupling. Apps can't use custom versions of framework or ASP.NET binaries.

Composite images are available for the Alpine Linux, Jammy Chiseled, and Mariner Distroless platforms from the `mcr.microsoft.com/dotnet/nightly/aspnet` repo. The tags are listed with the `-composite` suffix on the [ASP.NET Docker page](https://hub.docker.com/_/microsoft-dotnet-nightly-aspnet).

### Container publishing

- [Performance and compatibility](#performance-and-compatibility)
- [Authentication](#authentication)
- [Publish to tar.gz archive](#publish-to-targz-archive)

#### Performance and compatibility

.NET 8 has improved performance for pushing containers to remote registries, especially Azure registries. Speedup comes from pushing layers in one operation and, for registries that don't support atomic uploads, a more reliable chunking mechanism.

These improvements also mean that more registries are supported: Harbor, Artifactory, Quay.io, and Podman.

#### Authentication

.NET 8 adds support for OAuth token exchange authentication (Azure Managed Identity) when pushing containers to registries. This support means that you can now push to registries like Azure Container Registry without any authentication errors. The following commands show an example publishing flow:

```console
> az acr login -n <your registry name>
> dotnet publish -r linux-x64 -p PublishProfile=DefaultContainer
```

For more information containerizing .NET apps, see [Containerize a .NET app with dotnet publish](../docker/publish-as-container.md).

#### Publish to tar.gz archive

Starting in .NET 8, you can create a container directly as a *tar.gz* archive. This feature is useful if your workflow isn't straightforward and requires that you, for example, run a scanning tool over your images before pushing them. Once the archive is created, you can move it, scan it, or load it into a local Docker toolchain.

To publish to an archive, add the `ContainerArchiveOutputPath` property to your `dotnet publish` command, for example:

```dotnetcli
dotnet publish \
  -p PublishProfile=DefaultContainer \
  -p ContainerArchiveOutputPath=./images/sdk-container-demo.tar.gz
```

You can specify either a folder name or a path with a specific file name.

## Source-generated COM interop

.NET 8 includes a new source generator that supports interoperating with COM interfaces. You can use the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute> to mark an interface as a COM interface for the source generator. The source generator will then generate code to enable calling from C# code to unmanaged code. It also generates code to enable calling from unmanaged code into C#. This source generator integrates with <xref:System.Runtime.InteropServices.LibraryImportAttribute>, and you can use types with the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute> as parameters and return types in `LibraryImport`-attributed methods.

```csharp
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

[GeneratedComInterface]
[Guid("5401c312-ab23-4dd3-aa40-3cb4b3a4683e")]
interface IComInterface
{
    void DoWork();
}

internal class MyNativeLib
{
    [LibraryImport(nameof(MyNativeLib))]
    public static partial void GetComInterface(out IComInterface comInterface);
}
```

The source generator also supports the new <xref:System.Runtime.InteropServices.Marshalling.GeneratedComClassAttribute> attribute to enable you to pass types that implement interfaces with the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute> attribute to unmanaged code. The source generator will generate the code necessary to expose a COM object that implements the interfaces and forwards calls to the managed implementation.

Methods on interfaces with the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute> attribute support all the same types as `LibraryImportAttribute`, and `LibraryImportAttribute` now supports `GeneratedComInterface`-attributed types and `GeneratedComClass`-attributed types.

If your C# code only uses a `GeneratedComInterface`-attributed interface to either wrap a COM object from unmanaged code or wrap a managed object from C# to expose to unmanaged code, you can use the options in the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute.Options> property to customize which code will be generated. These options mean you don't need to write marshallers for scenarios that you know won't be used.

The source generator uses the new <xref:System.Runtime.InteropServices.Marshalling.StrategyBasedComWrappers> type to create and manage the COM object wrappers and the managed object wrappers. This new type handles providing the expected .NET user experience for COM interop, while providing customization points for advanced users. If your application has its own mechanism for defining types from COM or if you need to support scenarios that source-generated COM doesn't currently support, consider using the new <xref:System.Runtime.InteropServices.Marshalling.StrategyBasedComWrappers> type to add the missing features for your scenario and get the same .NET user experience for your COM types.

If you're using Visual Studio, new analyzers and code fixes make it easy to convert your existing COM interop code to use source-generated interop. Next to each interface that has the <xref:System.Runtime.InteropServices.ComImportAttribute>, a lightbulb offers an option to convert to source-generated interop. The fix changes the interface to use the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute> attribute. And next to every class that implements an interface with `GeneratedComInterfaceAttribute`, a lightbulb offers an option to add the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComClassAttribute> attribute to the type. Once your types are converted, you can move your `DllImport` methods to use `LibraryImportAttribute`.

### Limitations

The COM source generator doesn't support apartment affinity, using the `new` keyword to activate a COM CoClass, and the following APIs:

- <xref:System.Runtime.InteropServices.UnmanagedType.IDispatch>-based interfaces.
- <xref:System.Runtime.InteropServices.UnmanagedType.IInspectable>-based interfaces.
- COM properties and events.

## .NET on Linux

### Minimum support baselines for Linux

The minimum support baselines for Linux have been updated for .NET 8. .NET is built targeting Ubuntu 16.04, for all architectures. That's primarily important for defining the minimum `glibc` version for .NET 8. .NET 8 will fail to start on distro versions that include an older glibc, such as Ubuntu 14.04 or Red Hat Enterprise Linux 7.

For more information, see [Red Hat Enterprise Linux Family support](https://github.com/dotnet/core/blob/main/linux-support.md#red-hat-enterprise-linux-family-support).

### Build your own .NET on Linux

In previous .NET versions, you could build .NET from source, but it required you to create a "source tarball" from the [dotnet/installer](https://github.com/dotnet/installer) repo commit that corresponded to a release. In .NET 8, that's no longer necessary and you can build .NET on Linux directly from the [dotnet/dotnet](https://github.com/dotnet/dotnet) repository. That repo uses [dotnet/source-build](https://github.com/dotnet/source-build) to build .NET runtimes, tools, and SDKs. This is the same build that Red Hat and Canonical use to build .NET.

Building in a container is the easiest approach for most people, since the `dotnet-buildtools/prereqs` container images contain all the required dependencies. For more information, see the [build instructions](https://github.com/dotnet/dotnet#building).

## Cross-built Windows apps

When you build apps that target Windows on non-Windows platforms, the resulting executable is now updated with any specified Win32 resources&mdash;for example, application icon, manifest, version information.

Previously, applications had to be built on Windows in order to have such resources. Fixing this gap in cross-building support has been a popular request, as it was a significant pain point affecting both infrastructure complexity and resource usage.

## AOT compilation for Android apps

To decrease app size, .NET and .NET MAUI apps that target Android use *profiled* ahead-of-time (AOT) compilation mode when they're built in Release mode. Profiled AOT compilation affects fewer methods than regular AOT compilation. .NET 8 introduces the `<AndroidStripILAfterAOT>` property that lets you opt-in to further AOT compilation for Android apps to decrease app size even more.

```xml
<PropertyGroup>
  <AndroidStripILAfterAOT>true</AndroidStripILAfterAOT>
</PropertyGroup>
```

By default, setting `AndroidStripILAfterAOT` to `true` overrides the default `AndroidEnableProfiledAot` setting, allowing (nearly) all methods that were AOT-compiled to be trimmed. You can also use profiled AOT and IL stripping together by explicitly setting both properties to `true`:

```xml
<PropertyGroup>
  <AndroidStripILAfterAOT>true</AndroidStripILAfterAOT>
  <AndroidEnableProfiledAot>true</AndroidEnableProfiledAot>
</PropertyGroup>
```

## Code analysis

.NET 8 includes several new code analyzers and fixers to help verify that you're using .NET library APIs correctly and efficiently. The following table summarizes the new analyzers.

| Rule ID | Category | Description |
|--|--|--|
| CA1856 | Performance | Fires when the <xref:System.Diagnostics.CodeAnalysis.ConstantExpectedAttribute> attribute is not applied correctly on a parameter. |
| CA1857 | Performance | Fires when a parameter is annotated with <xref:System.Diagnostics.CodeAnalysis.ConstantExpectedAttribute> but the provided argument isn't a constant. |
| [CA1858](../../fundamentals/code-analysis/quality-rules/ca1858.md) | Performance | To determine whether a string starts with a given prefix, it's better to call <xref:System.String.StartsWith%2A?displayProperty=nameWithType> than to call <xref:System.String.IndexOf%2A?displayProperty=nameWithType> and then compare the result with zero. |
| [CA1859](../../fundamentals/code-analysis/quality-rules/ca1859.md) | Performance | This rule recommends upgrading the type of specific local variables, fields, properties, method parameters, and method return types from interface or abstract types to concrete types when possible. Using concrete types leads to higher quality generated code. |
| [CA1860](../../fundamentals/code-analysis/quality-rules/ca1860.md) | Performance | To determine whether a collection type has any elements, it's better to use `Length`, `Count`, or `IsEmpty` than to call <xref:System.Linq.Enumerable.Any%2A?displayProperty=nameWithType>. |
| [CA1861](../../fundamentals/code-analysis/quality-rules/ca1861.md) | Performance | Constant arrays passed as arguments aren't reused when called repeatedly, which implies a new array is created each time. To improve performance, consider extracting the array to a static readonly field. |
| [CA1865-CA1867](../../fundamentals/code-analysis/quality-rules/ca1865-ca1867.md) | Performance | The char overload is a better-performing overload for a string with a single char. |
| CA2021 | Reliability | <xref:System.Linq.Enumerable.Cast%60%601(System.Collections.IEnumerable)?displayProperty=nameWithType> and <xref:System.Linq.Enumerable.OfType%60%601(System.Collections.IEnumerable)?displayProperty=nameWithType> require compatible types to function correctly. Widening and user-defined conversions aren't supported with generic types. |
| CA1510-CA1513 | Maintainability | Throw helpers are simpler and more efficient than an `if` block constructing a new exception instance. These four analyzers were created for the following exceptions: <xref:System.ArgumentNullException>, <xref:System.ArgumentException>, <xref:System.ArgumentOutOfRangeException> and <xref:System.ObjectDisposedException>. |

## Windows Presentation Foundation

- [Hardware acceleration](#hardware-acceleration)
- [OpenFolderDialog](#openfolderdialog)

### Hardware acceleration

Previously, all WPF applications that were accessed remotely had to use software rendering, even if the system had hardware rendering capabilities. .NET 8 adds an option that lets you opt into hardware acceleration for Remote Desktop Protocol (RDP).

Hardware acceleration refers to the use of a computer's graphics processing unit (GPU) to speed up the rendering of graphics and visual effects in an application. This can result in improved performance and more seamless, responsive graphics. In contrast, software rendering relies solely on the computer's central processing unit (CPU) to render graphics, which can be slower and less effective.

To opt in, set the `Switch.System.Windows.Media.EnableHardwareAccelerationInRdp` configuration property to `true` in a *runtimeconfig.json* file. For more information, see [Hardware acceleration in RDP](../runtime-config/wpf.md#hardware-acceleration-in-rdp).

### OpenFolderDialog

WPF includes a new dialog box control called `OpenFolderDialog`. This control lets app users browse and select folders. Previously, app developers relied on third-party software to achieve this functionality.

```csharp
var openFolderDialog = new OpenFolderDialog()
{
    Title = "Select folder to open ...",
    InitialDirectory = Environment.GetFolderPath(
        Environment.SpecialFolder.ProgramFiles)
};

string folderName = "";
if (openFolderDialog.ShowDialog())
{
    folderName = openFolderDialog.FolderName;
}
```

For more information, see [WPF File Dialog Improvements in .NET 8 (.NET blog)](https://devblogs.microsoft.com/dotnet/wpf-file-dialog-improvements-in-dotnet-8/).

## NuGet

Starting in .NET 8, NuGet verifies signed packages on Linux by default. NuGet continues to verify signed packages on Windows as well.

Most users shouldn't notice the verification. However, if you have an existing root certificate bundle located at */etc/pki/ca-trust/extracted/pem/objsign-ca-bundle.pem*, you may see trust failures accompanied by [warning NU3042](/nuget/reference/errors-and-warnings/nu3042).

You can opt out of verification by setting the environment variable `DOTNET_NUGET_SIGNATURE_VERIFICATION` to `false`.

## Diagnostics

### C# Hot Reload supports modifying generics

Starting in .NET 8, C# Hot Reload [supports modifying generic types and generic methods](https://devblogs.microsoft.com/dotnet/hot-reload-generics/). When you debug console, desktop, mobile, or WebAssembly applications with Visual Studio, you can apply changes to generic classes and generic methods in C# code or Razor pages. For more information, see the [full list of edits supported by Roslyn](https://github.com/dotnet/roslyn/blob/main/docs/wiki/EnC-Supported-Edits.md)

## See also

- [Breaking changes in .NET 8](../compatibility/8.0.md)
- [What's new in ASP.NET Core 8.0](/aspnet/core/release-notes/aspnetcore-8.0)

### .NET blog

- [Announcing .NET 8](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8/)
- [Announcing .NET 8 RC 2](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-rc2/)
- [Announcing .NET 8 RC 1](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-rc1/)
- [Announcing .NET 8 Preview 7](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-7/)
- [Announcing .NET 8 Preview 6](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-6/)
- [Announcing .NET 8 Preview 5](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-5/)
- [Announcing .NET 8 Preview 4](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-4/)
- [Announcing .NET 8 Preview 3](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-3/)
- [Announcing .NET 8 Preview 2](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-2/)
- [Announcing .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-1/)
- [ASP.NET Core in .NET 8](https://devblogs.microsoft.com/dotnet/announcing-asp-net-core-in-dotnet-8)
- [ASP.NET Core updates in .NET 8 RC 2](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-rc-2/)
- [ASP.NET Core updates in .NET 8 RC 1](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-rc-1/)
- [ASP.NET Core updates in .NET 8 Preview 7](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-7/)
- [ASP.NET Core updates in .NET 8 Preview 6](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-6/)
- [ASP.NET Core updates in .NET 8 Preview 5](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-5/)
- [ASP.NET Core updates in .NET 8 Preview 4](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-4/)
- [ASP.NET Core updates in .NET 8 Preview 3](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-3/)
- [ASP.NET Core updates in .NET 8 Preview 2](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-2/)
- [ASP.NET Core updates in .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-1/)
