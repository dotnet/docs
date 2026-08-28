---
title: "Supported types in System.Text.Json"
description: "Learn which types the APIs in the System.Text.Json namespace support for serialization."
ms.date: 08/18/2026
ai-usage: ai-assisted
no-loc: [System.Text.Json]
ms.topic: reference
---

# Supported types in System.Text.Json

This article lists the types that `System.Text.Json` supports for serialization and deserialization.

## Types that serialize as JSON objects

The following types serialize as JSON objects:

* Classes<sup>*</sup>
* Structs
* Interfaces
* Records and struct records

\* Non-dictionary types that implement <xref:System.Collections.Generic.IEnumerable`1> serialize as JSON arrays. Dictionary types also implement <xref:System.Collections.Generic.IEnumerable`1> but serialize as JSON objects.

The following code snippet shows the serialization of a simple struct.

:::code language="csharp" source="snippets/supported-types/csharp/Struct.cs" id="SerializeStruct":::

## Types that serialize as JSON arrays

.NET collection types serialize as JSON arrays. <xref:System.Text.Json.JsonSerializer?displayProperty=nameWithType> supports a collection type for serialization if it:

* Derives from <xref:System.Collections.IEnumerable> or <xref:System.Collections.Generic.IAsyncEnumerable`1>.
* Contains elements that are serializable.

The serializer calls the <xref:System.Collections.IEnumerable.GetEnumerator> method and writes the elements.

Deserialization has more constraints, and the serializer doesn't support it for some collection types.

The following sections group types by namespace and show their serialization and deserialization support.

* [System.Array namespace](#systemarray-namespace)
* [System.Collections namespace](#systemcollections-namespace)
* [System.Collections.Generic namespace](#systemcollectionsgeneric-namespace)
* [System.Collections.Immutable namespace](#systemcollectionsimmutable-namespace)
* [System.Collections.Specialized namespace](#systemcollectionsspecialized-namespace)
* [System.Collections.Concurrent namespace](#systemcollectionsconcurrent-namespace)
* [System.Collections.ObjectModel namespace](#systemcollectionsobjectmodel-namespace)
* [Custom collections](#custom-collections)

### System.Array namespace

| Type                                                                                            | Serialization | Deserialization |
|-------------------------------------------------------------------------------------------------|---------------|-----------------|
| [Single-dimensional arrays](../../../csharp/language-reference/builtin-types/arrays.md#single-dimensional-arrays)* | ✔️ | ✔️     |
| [Multi-dimensional arrays](../../../csharp/language-reference/builtin-types/arrays.md#multidimensional-arrays)    | ❌  | ❌     |
| [Jagged arrays](../../../csharp/language-reference/builtin-types/arrays.md#jagged-arrays)                         | ✔️  | ✔️     |

\* `JsonSerializer` handles `byte[]` specially and serializes it as a base64 string, not a JSON array.

### System.Collections namespace

| Type                                      | Serialization | Deserialization |
|-------------------------------------------|---------------|-----------------|
| <xref:System.Collections.ArrayList>       | ✔️           | ✔️              |
| <xref:System.Collections.BitArray>        | ✔️           | ❌              |
| <xref:System.Collections.DictionaryEntry> | ✔️           | ✔️              |
| <xref:System.Collections.Hashtable>       | ✔️           | ✔️              |
| <xref:System.Collections.ICollection>     | ✔️           | ✔️              |
| <xref:System.Collections.IDictionary>     | ✔️           | ✔️              |
| <xref:System.Collections.IEnumerable>     | ✔️           | ✔️              |
| <xref:System.Collections.IList>           | ✔️           | ✔️              |
| <xref:System.Collections.Queue>           | ✔️           | ✔️              |
| <xref:System.Collections.SortedList>      | ✔️           | ✔️              |
| <xref:System.Collections.Stack> \*       | ✔️           | ✔️              |

\* See [Support round trip for `Stack` types](converters-how-to.md#support-round-trip-for-stack-types).

### System.Collections.Generic namespace

| Type                                                      | Serialization | Deserialization |
|-----------------------------------------------------------|---------------|-----------------|
| <xref:System.Collections.Generic.Dictionary`2> \*      | ✔️           | ✔️              |
| <xref:System.Collections.Generic.HashSet`1>             | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IAsyncEnumerable`1> †  | ✔️         | ✔️              |
| <xref:System.Collections.Generic.ICollection`1>         | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IDictionary`2> \*     | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IEnumerable`1>         | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IList`1>               | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IReadOnlyCollection`1> | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IReadOnlyDictionary`2> \* | ✔️        | ✔️              |
| <xref:System.Collections.Generic.IReadOnlyList`1>       | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IReadOnlySet`1> §       | ✔️           | ✔️              |
| <xref:System.Collections.Generic.ISet`1>                | ✔️           | ✔️              |
| <xref:System.Collections.Generic.KeyValuePair`2>        | ✔️           | ✔️              |
| <xref:System.Collections.Generic.LinkedList`1>          | ✔️           | ✔️              |
| <xref:System.Collections.Generic.LinkedListNode`1>      | ✔️           | ❌              |
| <xref:System.Collections.Generic.List`1>                | ✔️           | ✔️              |
| <xref:System.Collections.Generic.Queue`1>               | ✔️           | ✔️              |
| <xref:System.Collections.Generic.SortedDictionary`2> \* | ✔️           | ✔️              |
| <xref:System.Collections.Generic.SortedList`2> \*      | ✔️           | ✔️              |
| <xref:System.Collections.Generic.SortedSet`1>           | ✔️           | ✔️              |
| <xref:System.Collections.Generic.Stack`1> ‡             | ✔️           | ✔️              |

\* See [Supported key types](#supported-key-types).

† See the following section on `IAsyncEnumerable<T>`.

‡ See [Support round trip for `Stack` types](converters-how-to.md#support-round-trip-for-stack-types).

§ `System.Text.Json` supports <xref:System.Collections.Generic.IReadOnlySet`1> in .NET 11 and later versions. When you deserialize the interface, the serializer creates a <xref:System.Collections.Generic.HashSet`1> instance. Source generation supports the type, and the generated metadata calls <xref:System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreateIReadOnlySetInfo*?displayProperty=nameWithType>.

#### IAsyncEnumerable\<T>

The following examples use streams to represent asynchronous data sources. Sources include local files, database query results, and web service API responses.

##### Streaming serialization

`System.Text.Json` supports serializing <xref:System.Collections.Generic.IAsyncEnumerable`1> values as JSON arrays, as shown in the following example:

:::code language="csharp" source="snippets/supported-types/csharp/IAsyncEnumerableSerialize.cs" highlight="15":::

Only asynchronous serialization methods, such as <xref:System.Text.Json.JsonSerializer.SerializeAsync*?displayProperty=nameWithType>, support `IAsyncEnumerable<T>` values.

In .NET 11 and later versions, <xref:System.Text.Json.JsonSerializer.SerializeAsyncEnumerable*?displayProperty=nameWithType> writes an `IAsyncEnumerable<T>` sequence to either a <xref:System.IO.Stream> or a <xref:System.IO.Pipelines.PipeWriter>. With the default `topLevelValues: false`, the method writes a single root-level JSON array. Set `topLevelValues: true` to write [JSON Lines](https://jsonlines.org/) instead, where each element is a separate top-level value:

```json
{"id":1,"name":"apple"}
{"id":2,"name":"banana"}
```

The method writes a single line feed (LF), `\n`, after every value, including the last. It always uses LF, regardless of <xref:System.Text.Json.JsonSerializerOptions.NewLine?displayProperty=nameWithType>. The method ignores <xref:System.Text.Json.JsonSerializerOptions.WriteIndented?displayProperty=nameWithType>, so each value remains on one line.

##### Streaming deserialization

The `DeserializeAsyncEnumerable` method supports streaming deserialization, as shown in the following example:

:::code language="csharp" source="snippets/supported-types/csharp/IAsyncEnumerableDeserialize.cs" highlight="11":::

By default, <xref:System.Text.Json.JsonSerializer.DeserializeAsyncEnumerable*?displayProperty=nameWithType> reads elements from a single root-level JSON array. Set `topLevelValues: true` to read a sequence of whitespace-separated top-level values instead. This input format is a superset of JSON Lines. Overloads accept either a <xref:System.IO.Stream> or a <xref:System.IO.Pipelines.PipeReader>.

The <xref:System.Text.Json.JsonSerializer.DeserializeAsync*> method supports `IAsyncEnumerable<T>`, but its signature doesn't allow streaming. It returns the final result as a single value, as shown in the following example.

:::code language="csharp" source="snippets/supported-types/csharp/IAsyncEnumerableDeserializeNonStreaming.cs" highlight="16":::

In this example, the deserializer buffers all `IAsyncEnumerable<T>` contents in memory because it must read the entire JSON payload before returning a result.

### System.Collections.Immutable namespace

| Type                                                              | Serialization | Deserialization |
|-------------------------------------------------------------------|---------------|-----------------|
| <xref:System.Collections.Immutable.IImmutableDictionary`2> †    | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableList`1>            | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableQueue`1>           | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableSet`1>             | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableStack`1> \*       | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableArray`1>            | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableDictionary`2> †     | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableHashSet`1>          | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableQueue`1>            | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableSortedDictionary`2> † | ✔️         | ✔️              |
| <xref:System.Collections.Immutable.ImmutableSortedSet`1>        | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableStack`1> \*        | ✔️           | ✔️              |

\* See [Support round trip for `Stack` types](converters-how-to.md#support-round-trip-for-stack-types).

† See [Supported key types](#supported-key-types).

### System.Collections.Specialized namespace

| Type                                                      | Serialization | Deserialization |
|-----------------------------------------------------------|---------------|-----------------|
| <xref:System.Collections.Specialized.BitVector32>         | ✔️           | ❌\*           |
| <xref:System.Collections.Specialized.HybridDictionary>    | ✔️           | ✔️              |
| <xref:System.Collections.Specialized.IOrderedDictionary>  | ✔️           | ❌              |
| <xref:System.Collections.Specialized.ListDictionary>      | ✔️           | ✔️              |
| <xref:System.Collections.Specialized.NameValueCollection> | ✔️           | ❌              |
| <xref:System.Collections.Specialized.StringCollection>    | ✔️           | ❌              |
| <xref:System.Collections.Specialized.StringDictionary>    | ✔️           | ❌              |

\* When you deserialize <xref:System.Collections.Specialized.BitVector32>, the serializer skips the <xref:System.Collections.Specialized.BitVector32.Data> property because it doesn't have a public setter. The serializer doesn't throw an exception.

### System.Collections.Concurrent namespace

| Type                                                          | Serialization | Deserialization |
|---------------------------------------------------------------|---------------|-----------------|
| <xref:System.Collections.Concurrent.BlockingCollection`1>   | ✔️           | ❌              |
| <xref:System.Collections.Concurrent.ConcurrentBag`1>        | ✔️           | ❌              |
| <xref:System.Collections.Concurrent.ConcurrentDictionary`2> † | ✔️      | ✔️              |
| <xref:System.Collections.Concurrent.ConcurrentQueue`1>      | ✔️           | ✔️              |
| <xref:System.Collections.Concurrent.ConcurrentStack`1> \*  | ✔️           | ✔️              |

\* See [Support round trip for `Stack` types](converters-how-to.md#support-round-trip-for-stack-types).

† See [Supported key types](#supported-key-types).

### System.Collections.ObjectModel namespace

| Type                                                           | Serialization | Deserialization |
|----------------------------------------------------------------|---------------|-----------------|
| <xref:System.Collections.ObjectModel.Collection`1>           | ✔️            | ✔️             |
| [KeyedCollection\<string, TValue>](xref:System.Collections.ObjectModel.KeyedCollection`2) \* |✔️|❌|
| <xref:System.Collections.ObjectModel.ObservableCollection`1> | ✔️            | ✔️             |
| <xref:System.Collections.ObjectModel.ReadOnlyCollection`1>   | ✔️            | ❌             |
| <xref:System.Collections.ObjectModel.ReadOnlyDictionary`2>   | ✔️            | ❌             |
| <xref:System.Collections.ObjectModel.ReadOnlyObservableCollection`1> | ✔️    | ❌             |

\* `JsonSerializer` doesn't support non-`string` keys.

### Custom collections

`System.Text.Json` treats any collection type outside the preceding namespaces as a custom collection. This group includes user-defined types and ASP.NET Core types. For example, <xref:Microsoft.Extensions.Primitives?displayProperty=fullName> is in this group.

`JsonSerializer` supports all custom collections that derive from `IEnumerable` when it also supports their element types.

#### Deserialization support

`JsonSerializer` can deserialize a custom collection when the collection:

* Isn't an interface or abstract.
* Has a parameterless constructor.
* Contains element types that <xref:System.Text.Json.JsonSerializer> supports.
* Implements or inherits one or more of the following interfaces or classes:
  * <xref:System.Collections.Concurrent.ConcurrentQueue`1>
  * <xref:System.Collections.Concurrent.ConcurrentStack`1> \*
  * <xref:System.Collections.Generic.ICollection`1>
  * <xref:System.Collections.IDictionary>
  * <xref:System.Collections.Generic.IDictionary`2> †
  * <xref:System.Collections.IList>
  * <xref:System.Collections.Generic.IList`1>
  * <xref:System.Collections.Queue>
  * <xref:System.Collections.Generic.Queue`1>
  * <xref:System.Collections.Stack> \*
  * <xref:System.Collections.Generic.Stack`1> \*

  \* See [Support round trip for `Stack` types](converters-how-to.md#support-round-trip-for-stack-types).

  † See [Supported key types](#supported-key-types).

#### Known issues

The following custom collections have known issues:

* <xref:System.Dynamic.ExpandoObject>: See [dotnet/runtime#29690](https://github.com/dotnet/runtime/issues/29690).
* <xref:System.Dynamic.DynamicObject>: See [dotnet/runtime#1808](https://github.com/dotnet/runtime/issues/1808).
* <xref:System.Data.DataTable>: See [dotnet/docs#21366](https://github.com/dotnet/docs/issues/21366).
* <xref:Microsoft.AspNetCore.Http.FormFile?displayProperty=fullName>: See [dotnet/runtime#1559](https://github.com/dotnet/runtime/issues/1559).
* <xref:Microsoft.AspNetCore.Http.IFormCollection?displayProperty=fullName>: See [dotnet/runtime#1559](https://github.com/dotnet/runtime/issues/1559).

For more information about known issues, see the [open issues in System.Text.Json](https://github.com/dotnet/runtime/issues?q=is%3Aopen+is%3Aissue+label%3Aarea-System.Text.Json).

### Supported key types

The following types have built-in support as keys for `Dictionary` and `SortedList` types:

* <xref:System.Numerics.BFloat16> (.NET 11 and later)
* `Boolean`
* `Byte`
* `DateTime`
* `DateTimeOffset`
* `Decimal`
* <xref:System.Numerics.Decimal32> (.NET 11 and later)
* <xref:System.Numerics.Decimal64> (.NET 11 and later)
* <xref:System.Numerics.Decimal128> (.NET 11 and later)
* `Double`
* `Enum`
* `Guid`
* `Int16`
* `Int32`
* `Int64`
* `Object` (Only on serialization and if the runtime type is one of the supported types in this list.)
* `SByte`
* `Single`
* `String`
* <xref:System.TimeSpan>
* `UInt16`
* `UInt32`
* `UInt64`
* <xref:System.Uri>
* <xref:System.Version>

The <xref:System.Text.Json.Serialization.JsonConverter`1.WriteAsPropertyName(System.Text.Json.Utf8JsonWriter,`0,System.Text.Json.JsonSerializerOptions)?displayProperty=nameWithType> and <xref:System.Text.Json.Serialization.JsonConverter`1.ReadAsPropertyName(System.Text.Json.Utf8JsonReader@,System.Type,System.Text.Json.JsonSerializerOptions)?displayProperty=nameWithType> methods also let you add dictionary key support for any type.

## BFloat16 and decimal floating-point types

Starting in .NET 11, `System.Text.Json` includes built-in converters for the <xref:System.Numerics.BFloat16>, <xref:System.Numerics.Decimal32>, <xref:System.Numerics.Decimal64>, and <xref:System.Numerics.Decimal128> types. Finite values serialize as JSON numbers.

These types behave like the other built-in numeric types:

* Source generation supports them without extra configuration.
* Dictionary-key conversion supports all four types.
* They honor <xref:System.Text.Json.Serialization.JsonNumberHandling>, including the `"NaN"`, `"Infinity"`, and `"-Infinity"` literals through <xref:System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals>.

<xref:System.Text.Json.Serialization.Metadata.JsonMetadataServices> exposes converter properties for source-generated metadata. The properties are <xref:System.Text.Json.Serialization.Metadata.JsonMetadataServices.BFloat16Converter?displayProperty=nameWithType>, <xref:System.Text.Json.Serialization.Metadata.JsonMetadataServices.Decimal32Converter?displayProperty=nameWithType>, <xref:System.Text.Json.Serialization.Metadata.JsonMetadataServices.Decimal64Converter?displayProperty=nameWithType>, and <xref:System.Text.Json.Serialization.Metadata.JsonMetadataServices.Decimal128Converter?displayProperty=nameWithType>.

## F# discriminated unions

Starting in .NET 11, `System.Text.Json` serializes and deserializes F# discriminated unions, including class, struct, and recursive unions:

```fsharp
type Shape =
    | Point
    | Circle of radius: float
```

* A case without fields serializes as a JSON string that contains the case name, such as `"Point"`.
* A case that has fields serializes as a JSON object. The object contains a `$type` discriminator followed by the case's named fields, such as `{"$type":"Circle","radius":3.14}`.

<xref:System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy?displayProperty=nameWithType> applies to case names and field names. A case-level <xref:System.Text.Json.Serialization.JsonPropertyNameAttribute> takes precedence. To use a discriminator property name other than `$type`, set <xref:System.Text.Json.Serialization.JsonPolymorphicAttribute.TypeDiscriminatorPropertyName?displayProperty=nameWithType>.

> [!IMPORTANT]
> F# discriminated union support is reflection-only. It requires dynamic code and untrimmed reflection metadata. You can't use it with `System.Text.Json` source generation or Native AOT.

## Unsupported types

`JsonSerializer` doesn't support the following types for serialization:

* <xref:System.Type?displayProperty=fullName> and <xref:System.Reflection.MemberInfo?displayProperty=fullName>
* <xref:System.ReadOnlySpan`1>, <xref:System.Span`1>, and ref structs in general
* Delegate types
* <xref:System.IntPtr> and <xref:System.UIntPtr>

### System.Data namespace

`System.Text.Json` doesn't provide built-in converters for <xref:System.Data.DataSet>, <xref:System.Data.DataTable>, and related types in the <xref:System.Data> namespace. Don't deserialize these types from untrusted input. For more information, see [the security guidance](../../../framework/data/adonet/dataset-datatable-dataview/security-guidance.md#safety-with-regard-to-untrusted-input). To support these types, write a custom converter. For a `DataTable` converter sample, see [RoundtripDataTable.cs](https://github.com/dotnet/docs/blob/main/docs/standard/serialization/system-text-json/snippets/how-to/csharp/RoundtripDataTable.cs).

## See also

* [Populate initialized properties](populate-properties.md)
* [System.Text.Json overview](overview.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
