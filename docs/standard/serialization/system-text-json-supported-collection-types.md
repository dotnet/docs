---
title: "Supported collection types in System.Text.Json"
description: "Learn which collection types are supported for serialization by the APIs in the System.Text.Json namespace."
ms.date: 02/01/2021
no-loc: [System.Text.Json]
ms.topic: reference
zone_pivot_groups: dotnet-version
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# Supported collection types in System.Text.Json

This article gives an overview of which collections are supported for serialization and deserialization. <xref:System.Text.Json.JsonSerializer?displayProperty=nameWithType> supports a collection type for serialization if it:

* Derives from <xref:System.Collections.IEnumerable>.
* Contains elements that are serializable.

The serializer calls the <xref:System.Collections.IEnumerable.GetEnumerator> method, and writes the elements.

Deserialization is more complicated and is not supported for some collection types.

The following sections are organized by namespace and show which types are supported for serialization and deserialization.

## System.Array namespace

| Type                                                                                            | Serialization | Deserialization |
|-------------------------------------------------------------------------------------------------|---------------|-----------------|
| [Single-dimensional arrays](../../csharp/programming-guide/arrays/single-dimensional-arrays.md) | ✔️           | ✔️              |
| [Multi-dimensional arrays](../../csharp/programming-guide/arrays/multidimensional-arrays.md)    | ❌           | ❌              |
| [Jagged arrays](../../csharp/programming-guide/arrays/jagged-arrays.md)                         | ✔️           | ✔️              |

## System.Collections namespace

| Type                                      | Serialization | Deserialization |
|-------------------------------------------|---------------|-----------------|
| <xref:System.Collections.ArrayList>       | ✔️           | ✔️              |
| <xref:System.Collections.BitArray>        | ✔️           | ❌              |
| <xref:System.Collections.DictionaryEntry> | ✔️           | ✔️              |
| <xref:System.Collections.Hashtable>       | ✔️           | ✔️              |
| <xref:System.Collections.Queue>           | ✔️           | ✔️              |
| <xref:System.Collections.SortedList>      | ✔️           | ✔️              |
| <xref:System.Collections.Stack>           | ✔️           | ✔️              |
| <xref:System.Collections.ICollection>     | ✔️           | ✔️              |
| <xref:System.Collections.IDictionary>     | ✔️           | ✔️              |
| <xref:System.Collections.IEnumerable>     | ✔️           | ✔️              |
| <xref:System.Collections.IList>           | ✔️           | ✔️              |

## System.Collections.Generic namespace

::: zone pivot="dotnet-5-0"

| Type                                                      | Serialization | Deserialization |
|-----------------------------------------------------------|---------------|-----------------|
| <xref:System.Collections.Generic.Dictionary%602> \*       | ✔️           | ✔️              |
| <xref:System.Collections.Generic.HashSet%601>             | ✔️           | ✔️              |
| <xref:System.Collections.Generic.KeyValuePair%602>        | ✔️           | ✔️              |
| <xref:System.Collections.Generic.LinkedList%601>          | ✔️           | ✔️              |
| <xref:System.Collections.Generic.LinkedListNode%601>      | ✔️           | ❌              |
| <xref:System.Collections.Generic.List%601>                | ✔️           | ✔️              |
| <xref:System.Collections.Generic.Queue%601>               | ✔️           | ✔️              |
| <xref:System.Collections.Generic.SortedDictionary%602> \* | ✔️           | ✔️              |
| <xref:System.Collections.Generic.SortedList%602> \*       | ✔️           | ✔️              |
| <xref:System.Collections.Generic.SortedSet%601>           | ✔️           | ✔️              |
| <xref:System.Collections.Generic.Stack%601>               | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IAsyncEnumerable%601>    | ❌           | ❌              |
| <xref:System.Collections.Generic.ICollection%601>         | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IDictionary%602> \*      | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IEnumerable%601>         | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IList%601>               | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IReadOnlyCollection%601> | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IReadOnlyDictionary%602> \* | ✔️        | ✔️              |
| <xref:System.Collections.Generic.IReadOnlyList%601>       | ✔️           | ✔️              |
| <xref:System.Collections.Generic.ISet%601>                | ✔️           | ✔️              |

::: zone-end

::: zone pivot="dotnet-core-3-1"

| Type                                                                                            | Serialization | Deserialization |
|-------------------------------------------------------------------------------------------------|---------------|-----------------|
| [Dictionary\<string, TValue>](xref:System.Collections.Generic.Dictionary%602) \*                | ✔️           | ✔️              |
| <xref:System.Collections.Generic.HashSet%601>                                                   | ✔️           | ✔️              |
| <xref:System.Collections.Generic.KeyValuePair%602>                                              | ✔️           | ✔️              |
| <xref:System.Collections.Generic.LinkedList%601>                                                | ✔️           | ✔️              |
| <xref:System.Collections.Generic.LinkedListNode%601>                                            | ✔️           | ❌              |
| <xref:System.Collections.Generic.List%601>                                                      | ✔️           | ✔️              |
| <xref:System.Collections.Generic.Queue%601>                                                     | ✔️           | ✔️              |
| [SortedDictionary\<string, TValue>](xref:System.Collections.Generic.SortedDictionary%602) \*    | ✔️           | ✔️              |
| [SortedList\<string, TValue>](xref:System.Collections.Generic.SortedList%602) \*                | ✔️           | ✔️              |
| <xref:System.Collections.Generic.SortedSet%601>                                                 | ✔️           | ✔️              |
| <xref:System.Collections.Generic.Stack%601>                                                     | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IAsyncEnumerable%601>                                          | ❌           | ❌              |
| <xref:System.Collections.Generic.ICollection%601>                                               | ✔️           | ✔️              |
| [IDictionary\<string, TValue>](xref:System.Collections.Generic.IDictionary%602) \*              | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IEnumerable%601>                                               | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IList%601>                                                     | ✔️           | ✔️              |
| <xref:System.Collections.Generic.IReadOnlyCollection%601>                                       | ✔️           | ✔️              |
| [IReadOnlyDictionary\<string, TValue>](xref:System.Collections.Generic.IReadOnlyDictionary%602) \* | ✔️        | ✔️              |
| <xref:System.Collections.Generic.IReadOnlyList%601>                                             | ✔️           | ✔️              |
| <xref:System.Collections.Generic.ISet%601>                                                      | ✔️           | ✔️              |

::: zone-end

\* See [Supported key types](#supported-key-types).

## System.Collections.Immutable namespace

::: zone pivot="dotnet-5-0"

| Type                                                              | Serialization | Deserialization |
|-------------------------------------------------------------------|---------------|-----------------|
| <xref:System.Collections.Immutable.ImmutableArray%601>            | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableDictionary%602> \*\*  | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableHashSet%601>          | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableList%601>            | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableQueue%601>            | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableSortedDictionary%602> \*\* | ✔️      | ✔️              |
| <xref:System.Collections.Immutable.ImmutableSortedSet%601>        | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableStack%601> \*         | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableDictionary%602> \*\* | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableList%601>            | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableQueue%601>           | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableSet%601>             | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableStack%601> \*        | ✔️           | ✔️              |

::: zone-end

::: zone pivot="dotnet-core-3-1"

| Type                                                                                                          | Serialization | Deserialization |
|---------------------------------------------------------------------------------------------------------------|---------------|-----------------|
| <xref:System.Collections.Immutable.ImmutableArray%601>                                                        | ✔️           | ✔️              |
| [ImmutableDictionary\<string, TValue>](xref:System.Collections.Immutable.ImmutableDictionary%602) \*\*        | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableHashSet%601>                                                      | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableList%601>                                                        | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableQueue%601>                                                        | ✔️           | ✔️              |
| [ImmutableSortedDictionary\<string, TValue>](xref:System.Collections.Immutable.ImmutableSortedDictionary%602) \*\*| ✔️       | ✔️              |
| <xref:System.Collections.Immutable.ImmutableSortedSet%601>                                                    | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.ImmutableStack%601> \*                                                     | ✔️           | ✔️              |
| [IImmutableDictionary\<string, TValue>](xref:System.Collections.Immutable.IImmutableDictionary%602) \*\*      | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableList%601>                                                        | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableQueue%601>                                                       | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableSet%601>                                                         | ✔️           | ✔️              |
| <xref:System.Collections.Immutable.IImmutableStack%601> \*                                                    | ✔️           | ✔️              |

::: zone-end

\* See [Support round trip for Stack\<T>](system-text-json-converters-how-to.md#support-round-trip-for-stackt).

\*\* See [Supported key types](#supported-key-types).

## System.Collections.Specialized namespace

| Type                                                      | Serialization | Deserialization |
|-----------------------------------------------------------|---------------|-----------------|
| <xref:System.Collections.Specialized.BitVector32>         | ✔️           | ❌\*            |
| <xref:System.Collections.Specialized.HybridDictionary>    | ✔️           | ✔️              |
| <xref:System.Collections.Specialized.IOrderedDictionary>  | ✔️           | ❌              |
| <xref:System.Collections.Specialized.ListDictionary>      | ✔️           | ✔️              |
| <xref:System.Collections.Specialized.StringCollection>    | ✔️           | ❌              |
| <xref:System.Collections.Specialized.StringDictionary>    | ✔️           | ❌              |
| <xref:System.Collections.Specialized.NameValueCollection> | ✔️           | ❌              |

\* When <xref:System.Collections.Specialized.BitVector32> is deserialized, the <xref:System.Collections.Specialized.BitVector32.Data> property is skipped because it doesn't have a public setter. No exception is thrown.

## System.Collections.Concurrent namespace

::: zone pivot="dotnet-5-0"

| Type                                                          | Serialization | Deserialization |
|---------------------------------------------------------------|---------------|-----------------|
| <xref:System.Collections.Concurrent.BlockingCollection%601>   | ✔️           | ❌              |
| <xref:System.Collections.Concurrent.ConcurrentBag%601>        | ✔️           | ❌              |
| <xref:System.Collections.Concurrent.ConcurrentDictionary%602> \*\* | ✔️      | ✔️              |
| <xref:System.Collections.Concurrent.ConcurrentQueue%601>      | ✔️           | ✔️              |
| <xref:System.Collections.Concurrent.ConcurrentStack%601> \*   | ✔️           | ✔️              |

::: zone-end

::: zone pivot="dotnet-core-3-1"

| Type                                                        | Serialization | Deserialization |
|-------------------------------------------------------------|---------------|-----------------|
| <xref:System.Collections.Concurrent.BlockingCollection%601> | ✔️           | ❌              |
| <xref:System.Collections.Concurrent.ConcurrentBag%601>      | ✔️           | ❌              |
| [ConcurrentDictionary\<string, TValue>](xref:System.Collections.Concurrent.ConcurrentDictionary%602) \*\* |✔️|✔️|
| <xref:System.Collections.Concurrent.ConcurrentQueue%601>    | ✔️           | ✔️              |
| <xref:System.Collections.Concurrent.ConcurrentStack%601> \* | ✔️           | ✔️              |

::: zone-end

\* See [Support round trip for Stack\<T>](system-text-json-converters-how-to.md#support-round-trip-for-stackt).

\*\* See [Supported key types](#supported-key-types).

## System.Collections.ObjectModel namespace

::: zone pivot="dotnet-5-0"

| Type                                                           | Serialization | Deserialization |
|----------------------------------------------------------------|---------------|-----------------|
| <xref:System.Collections.ObjectModel.Collection%601>           | ✔️            | ✔️             |
| [KeyedCollection\<string, TValue>](xref:System.Collections.ObjectModel.KeyedCollection%602) \* |✔️|❌|
| <xref:System.Collections.ObjectModel.ObservableCollection%601> | ✔️            | ✔️             |
| <xref:System.Collections.ObjectModel.ReadOnlyCollection%601>   | ✔️            | ❌             |
| <xref:System.Collections.ObjectModel.ReadOnlyDictionary%602>   | ✔️            | ❌             |
| <xref:System.Collections.ObjectModel.ReadOnlyObservableCollection%601> | ✔️    | ❌             |

\* Non-`string` keys are not supported.

::: zone-end

::: zone pivot="dotnet-core-3-1"

| Type                                                           | Serialization | Deserialization |
|----------------------------------------------------------------|---------------|-----------------|
| <xref:System.Collections.ObjectModel.Collection%601>           | ✔️            | ✔️             |
| [KeyedCollection\<string, TValue>](xref:System.Collections.ObjectModel.KeyedCollection%602) \* |✔️|❌|
| <xref:System.Collections.ObjectModel.ObservableCollection%601> | ✔️            | ✔️             |
| <xref:System.Collections.ObjectModel.ReadOnlyCollection%601>   | ✔️            | ❌             |
| [ReadOnlyDictionary\<string, TValue>](xref:System.Collections.ObjectModel.ReadOnlyDictionary%602) \* |✔️|❌|
| <xref:System.Collections.ObjectModel.ReadOnlyObservableCollection%601>| ✔️     | ❌             |

\* See [Supported key types](#supported-key-types).

::: zone-end

## Custom collections

Any collection type that isn't in one of the preceding namespaces is considered a custom collection. Such types include user-defined types and types defined by ASP.NET Core. For example, <xref:Microsoft.Extensions.Primitives?displayProperty=fullName> is in this group.

All custom collections (everything that derives from `IEnumerable`) are supported for serialization, as long as their element types are supported.

### Custom collections with deserialization support

A custom collection is supported for deserialization if it:

::: zone pivot="dotnet-5-0"

* Isn't an interface or abstract.
* Has a parameterless constructor.
* Contains element types that are supported by <xref:System.Text.Json.JsonSerializer>.
* Implements or inherits one or more of the following interfaces or classes:
  * <xref:System.Collections.Concurrent.ConcurrentQueue%601>
  * <xref:System.Collections.Concurrent.ConcurrentStack%601> \*
  * <xref:System.Collections.Generic.ICollection%601>
  * <xref:System.Collections.IDictionary>
  * <xref:System.Collections.Generic.IDictionary%602> \*\*
  * <xref:System.Collections.IList>
  * <xref:System.Collections.Generic.IList%601>
  * <xref:System.Collections.Queue>
  * <xref:System.Collections.Generic.Queue%601>
  * <xref:System.Collections.Stack> \*
  * <xref:System.Collections.Generic.Stack%601> \*

::: zone-end

::: zone pivot="dotnet-core-3-1"

* Isn't an interface or abstract.
* Has a parameterless constructor.
* Contains element types that are supported by <xref:System.Text.Json.JsonSerializer>.
* Implements or inherits one or more of the following interfaces or classes:
  * <xref:System.Collections.Concurrent.ConcurrentQueue%601>
  * <xref:System.Collections.Concurrent.ConcurrentStack%601> \*
  * <xref:System.Collections.Generic.ICollection%601>
  * <xref:System.Collections.IDictionary>
  * [IDictionary\<string, TValue>](xref:System.Collections.Generic.IDictionary%602) \*\*
  * <xref:System.Collections.IList>
  * <xref:System.Collections.Generic.IList%601>
  * <xref:System.Collections.Queue>
  * <xref:System.Collections.Generic.Queue%601>
  * <xref:System.Collections.Stack> \*
  * <xref:System.Collections.Generic.Stack%601> \*

::: zone-end

  \* See [Support round trip for Stack\<T>](system-text-json-converters-how-to.md#support-round-trip-for-stackt).

  \*\* See [Supported key types](#supported-key-types).

### Custom collections with known issues

There are known issues with the following custom collections:

- <xref:System.Dynamic.ExpandoObject>: See [dotnet/runtime#29690](https://github.com/dotnet/runtime/issues/29690).
- <xref:System.Dynamic.DynamicObject>: See [dotnet/runtime#1808](https://github.com/dotnet/runtime/issues/1808).
- <xref:System.Data.DataTable>: See [dotnet/docs#21366](https://github.com/dotnet/docs/issues/21366).
- <xref:Microsoft.AspNetCore.Http.FormFile?displayProperty=fullName>: See [dotnet/runtime#1559](https://github.com/dotnet/runtime/issues/1559).
- <xref:Microsoft.AspNetCore.Http.IFormCollection?displayProperty=fullName>: See [dotnet/runtime#1559](https://github.com/dotnet/runtime/issues/1559).

For more information about known issues, see the [open issues in System.Text.Json](https://github.com/dotnet/runtime/issues?q=is%3Aopen+is%3Aissue+label%3Aarea-System.Text.Json).

## Supported key types

::: zone pivot="dotnet-5-0"

Supported types for the keys of `Dictionary` and `SortedList` types include the following:

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
* `UInt16`
* `UInt32`
* `UInt64`

::: zone-end

::: zone pivot="dotnet-core-3-1"

\*\* Non-`string` keys for `Dictionary` and `SortedList` types are not supported in .NET Core 3.1.

::: zone-end

## See also

* [System.Text.Json overview](system-text-json-overview.md)
* [Instantiate JsonSerializerOptions instances](system-text-json-configure-options.md)
* [Enable case-insensitive matching](system-text-json-character-casing.md)
* [Customize property names and values](system-text-json-customize-properties.md)
* [Ignore properties](system-text-json-ignore-properties.md)
* [Allow invalid JSON](system-text-json-invalid-json.md)
* [Handle overflow JSON](system-text-json-handle-overflow.md)
* [Preserve references](system-text-json-preserve-references.md)
* [Immutable types and non-public accessors](system-text-json-immutability.md)
* [Polymorphic serialization](system-text-json-polymorphism.md)
* [Migrate from Newtonsoft.Json to System.Text.Json](system-text-json-migrate-from-newtonsoft-how-to.md)
* [Customize character encoding](system-text-json-character-encoding.md)
* [Write custom serializers and deserializers](write-custom-serializer-deserializer.md)
* [Write custom converters for JSON serialization](system-text-json-converters-how-to.md)
* [DateTime and DateTimeOffset support](../datetime/system-text-json-support.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
