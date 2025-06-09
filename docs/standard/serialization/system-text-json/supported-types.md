---
title: "Supported types in System.Text.Json"
description: "Learn which types are supported for serialization by the APIs in the System.Text.Json namespace."
ms.date: 11/25/2024
no-loc: [System.Text.Json]
ms.topic: reference
---

# Supported types in System.Text.Json

This article gives an overview of which types are supported for serialization and deserialization.

## Types that serialize as JSON objects

The following types serialize as JSON objects:

* Classes<sup>*</sup>
* Structs
* Interfaces
* Records and struct records

\* Non-dictionary types that implement <xref:System.Collections.Generic.IEnumerable`1> serialize as JSON arrays. Dictionary types, which do implement <xref:System.Collections.Generic.IEnumerable`1>, serialize as JSON objects.

The following code snippet shows the serialization of a simple struct.

:::code language="csharp" source="snippets/supported-types/csharp/Struct.cs" id="SerializeStruct":::

## Types that serialize as JSON arrays

.NET collection types serialize as JSON arrays. <xref:System.Text.Json.JsonSerializer?displayProperty=nameWithType> supports a collection type for serialization if it:

* Derives from <xref:System.Collections.IEnumerable> or <xref:System.Collections.Generic.IAsyncEnumerable%601>.
* Contains elements that are serializable.

The serializer calls the <xref:System.Collections.IEnumerable.GetEnumerator> method and writes the elements.

Deserialization is more complicated and is not supported for some collection types.

The following sections are organized by namespace and show which types are supported for serialization and deserialization.

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

\* `byte[]` is handled specially and serializes as a base64 string, not a JSON array.

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
| <xref:System.Collections.Generic.Dictionary%602> \*      | ✔️           | ✔️              |
| <xref:System.Collections.Generic.HashSet%601>             | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IAsyncEnumerable%601> †  | ✔️         | ✔️              |
| <xref:System.Collections.Generic.ICollection%601>         | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IDictionary%602> \*     | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IEnumerable%601>         | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IList%601>               | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IReadOnlyCollection%601> | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IReadOnlyDictionary%602> \* | ✔️        | ✔️              |
| <xref:System.Collections.Generic.IReadOnlyList%601>       | ✔️           | ✔️              |
| <xref:System.Collections.Generic.ISet%601>                | ✔️           | ✔️              |
| <xref:System.Collections.Generic.KeyValuePair%602>        | ✔️           | ✔️              |
| <xref:System.Collections.Generic.LinkedList%601>          | ✔️           | ✔️              |
| <xref:System.Collections.Generic.LinkedListNode%601>      | ✔️           | ❌              |
| <xref:System.Collections.Generic.List%601>                | ✔️           | ✔️              |
| <xref:System.Collections.Generic.Queue%601>               | ✔️           | ✔️              |
| <xref:System.Collections.Generic.SortedDictionary%602> \* | ✔️           | ✔️              |
| <xref:System.Collections.Generic.SortedList%602> \*      | ✔️           | ✔️              |
| <xref:System.Collections.Generic.SortedSet%601>           | ✔️           | ✔️              |
| <xref:System.Collections.Generic.Stack%601> ‡             | ✔️           | ✔️              |

\* See [Supported key types](#supported-key-types).

† See the following section on `IAsyncEnumerable<T>`.

‡ See [Support round trip for `Stack` types](converters-how-to.md#support-round-trip-for-stack-types).

#### IAsyncEnumerable\<T>

The following examples use streams as a representation of any async source of data. The source could be files on a local machine, or results from a database query or web service API call.

##### Stream serialization

`System.Text.Json` supports serializing <xref:System.Collections.Generic.IAsyncEnumerable%601> values as JSON arrays, as shown in the following example:

:::code language="csharp" source="snippets/supported-types/csharp/IAsyncEnumerableSerialize.cs" highlight="15":::

`IAsyncEnumerable<T>` values are only supported by the asynchronous serialization methods, such as <xref:System.Text.Json.JsonSerializer.SerializeAsync%2A?displayProperty=nameWithType>.

##### Stream deserialization

The `DeserializeAsyncEnumerable` method supports streaming deserialization, as shown in the following example:

:::code language="csharp" source="snippets/supported-types/csharp/IAsyncEnumerableDeserialize.cs" highlight="11":::

The `DeserializeAsyncEnumerable` method only supports reading from root-level JSON arrays.

The <xref:System.Text.Json.JsonSerializer.DeserializeAsync%2A> method supports `IAsyncEnumerable<T>`, but its signature doesn't allow streaming. It returns the final result as a single value, as shown in the following example.

:::code language="csharp" source="snippets/supported-types/csharp/IAsyncEnumerableDeserializeNonStreaming.cs" highlight="16":::

In this example, the deserializer buffers all `IAsyncEnumerable<T>` contents in memory before returning the deserialized object. This behavior is necessary because the deserializer needs to read the entire JSON payload before returning a result.

### System.Collections.Immutable namespace

| Type                                                              | Serialization | Deserialization |
|-------------------------------------------------------------------|---------------|-----------------|
| <xref:System.Collections.Immutable.IImmutableDictionary%602> †    | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableList%601>            | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableQueue%601>           | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableSet%601>             | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableStack%601> \*       | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableArray%601>            | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableDictionary%602> †     | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableHashSet%601>          | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableQueue%601>            | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableSortedDictionary%602> † | ✔️         | ✔️              |
| <xref:System.Collections.Immutable.ImmutableSortedSet%601>        | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableStack%601> \*        | ✔️           | ✔️              |

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

\* When <xref:System.Collections.Specialized.BitVector32> is deserialized, the <xref:System.Collections.Specialized.BitVector32.Data> property is skipped because it doesn't have a public setter. No exception is thrown.

### System.Collections.Concurrent namespace

| Type                                                          | Serialization | Deserialization |
|---------------------------------------------------------------|---------------|-----------------|
| <xref:System.Collections.Concurrent.BlockingCollection%601>   | ✔️           | ❌              |
| <xref:System.Collections.Concurrent.ConcurrentBag%601>        | ✔️           | ❌              |
| <xref:System.Collections.Concurrent.ConcurrentDictionary%602> † | ✔️      | ✔️              |
| <xref:System.Collections.Concurrent.ConcurrentQueue%601>      | ✔️           | ✔️              |
| <xref:System.Collections.Concurrent.ConcurrentStack%601> \*  | ✔️           | ✔️              |

\* See [Support round trip for `Stack` types](converters-how-to.md#support-round-trip-for-stack-types).

† See [Supported key types](#supported-key-types).

### System.Collections.ObjectModel namespace

| Type                                                           | Serialization | Deserialization |
|----------------------------------------------------------------|---------------|-----------------|
| <xref:System.Collections.ObjectModel.Collection%601>           | ✔️            | ✔️             |
| [KeyedCollection\<string, TValue>](xref:System.Collections.ObjectModel.KeyedCollection%602) \* |✔️|❌|
| <xref:System.Collections.ObjectModel.ObservableCollection%601> | ✔️            | ✔️             |
| <xref:System.Collections.ObjectModel.ReadOnlyCollection%601>   | ✔️            | ❌             |
| <xref:System.Collections.ObjectModel.ReadOnlyDictionary%602>   | ✔️            | ❌             |
| <xref:System.Collections.ObjectModel.ReadOnlyObservableCollection%601> | ✔️    | ❌             |

\* Non-`string` keys are not supported.

### Custom collections

Any collection type that isn't in one of the preceding namespaces is considered a custom collection. Such types include user-defined types and types defined by ASP.NET Core. For example, <xref:Microsoft.Extensions.Primitives?displayProperty=fullName> is in this group.

All custom collections (everything that derives from `IEnumerable`) are supported for serialization, as long as their element types are supported.

#### Deserialization support

A custom collection is supported for deserialization if it:

* Isn't an interface or abstract.
* Has a parameterless constructor.
* Contains element types that are supported by <xref:System.Text.Json.JsonSerializer>.
* Implements or inherits one or more of the following interfaces or classes:
  * <xref:System.Collections.Concurrent.ConcurrentQueue%601>
  * <xref:System.Collections.Concurrent.ConcurrentStack%601> \*
  * <xref:System.Collections.Generic.ICollection%601>
  * <xref:System.Collections.IDictionary>
  * <xref:System.Collections.Generic.IDictionary%602> †
  * <xref:System.Collections.IList>
  * <xref:System.Collections.Generic.IList%601>
  * <xref:System.Collections.Queue>
  * <xref:System.Collections.Generic.Queue%601>
  * <xref:System.Collections.Stack> \*
  * <xref:System.Collections.Generic.Stack%601> \*

  \* See [Support round trip for `Stack` types](converters-how-to.md#support-round-trip-for-stack-types).

  † See [Supported key types](#supported-key-types).

#### Known issues

There are known issues with the following custom collections:

* <xref:System.Dynamic.ExpandoObject>: See [dotnet/runtime#29690](https://github.com/dotnet/runtime/issues/29690).
* <xref:System.Dynamic.DynamicObject>: See [dotnet/runtime#1808](https://github.com/dotnet/runtime/issues/1808).
* <xref:System.Data.DataTable>: See [dotnet/docs#21366](https://github.com/dotnet/docs/issues/21366).
* <xref:Microsoft.AspNetCore.Http.FormFile?displayProperty=fullName>: See [dotnet/runtime#1559](https://github.com/dotnet/runtime/issues/1559).
* <xref:Microsoft.AspNetCore.Http.IFormCollection?displayProperty=fullName>: See [dotnet/runtime#1559](https://github.com/dotnet/runtime/issues/1559).

For more information about known issues, see the [open issues in System.Text.Json](https://github.com/dotnet/runtime/issues?q=is%3Aopen+is%3Aissue+label%3Aarea-System.Text.Json).

### Supported key types

When used as the keys of `Dictionary` and `SortedList` types, the following types have built-in support:

* `Boolean`
* `Byte`
* `DateTime`
* `DateTimeOffset`
* `Decimal`
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

In addition, the <xref:System.Text.Json.Serialization.JsonConverter`1.WriteAsPropertyName(System.Text.Json.Utf8JsonWriter,`0,System.Text.Json.JsonSerializerOptions)?displayProperty=nameWithType> and <xref:System.Text.Json.Serialization.JsonConverter`1.ReadAsPropertyName(System.Text.Json.Utf8JsonReader@,System.Type,System.Text.Json.JsonSerializerOptions)?displayProperty=nameWithType> methods let you add dictionary key support for any type of your choosing.

## Unsupported types

The following types aren't supported for serialization:

* <xref:System.Type?displayProperty=fullName> and <xref:System.Reflection.MemberInfo?displayProperty=fullName>
* <xref:System.ReadOnlySpan`1>, <xref:System.Span`1>, and ref structs in general
* Delegate types
* <xref:System.IntPtr> and <xref:System.UIntPtr>

### System.Data namespace

There are no built-in converters for <xref:System.Data.DataSet>, <xref:System.Data.DataTable>, and related types in the <xref:System.Data> namespace. Deserializing these types from untrusted input is not safe, as explained in [the security guidance](../../../framework/data/adonet/dataset-datatable-dataview/security-guidance.md#safety-with-regard-to-untrusted-input). However, you can write a custom converter to support these types. For sample custom converter code that serializes and deserializes a `DataTable`, see [RoundtripDataTable.cs](https://github.com/dotnet/docs/blob/main/docs/standard/serialization/system-text-json/snippets/how-to/csharp/RoundtripDataTable.cs).

## See also

* [Populate initialized properties](populate-properties.md)
* [System.Text.Json overview](overview.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
