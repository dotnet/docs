---
title: "System.Text.Json✔️types"
description: "Learn which types are✔️for serialization by the APIs in the System.Text.Json namespace."
ms.date: 12/18/2020
no-loc: [System.Text.Json, Newtonsoft.Json]
zone_pivot_groups: dotnet-version
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# System.Text.Json✔️collection types

All collections (any type that derives from <xref:System.Collections.IEnumerable> are✔️for serialization with <xref:System.Text.Json.JsonSerializer?displayProperty=nameWithType>. The serializer calls the <xref:System.Collections.IEnumerable.GetEnumerator> method of the collection and writes the elements if they are supported. Deserialization is more complicated and is❌for all collections.

This article gives a quick overview of which collections are supported.

## System.Collections namespace

| Type | Serialization | Deserialization |
| --- | --- | --- |
| <xref:System.Collections.ArrayList> |✔️|✔️|
| <xref:System.Collections.BitArray> |✔️|❌|
| <xref:System.Collections.Hashtable> |✔️|✔️|
| <xref:System.Collections.Queue> |✔️|✔️|
| <xref:System.Collections.SortedList> |✔️|✔️|
| <xref:System.Collections.Stack> |✔️|✔️|
| <xref:System.Collections.DictionaryEntr> |✔️|✔️|
| <xref:System.Collections.ICollection> |✔️|✔️|
| <xref:System.Collections.IDictionary> |✔️|✔️|
| <xref:System.Collections.IEnumerable> |✔️|✔️|
| <xref:System.Collections.IList> |✔️|✔️|

## System.Collections.Generic namespace

| Type | Serialization | Deserialization |
| --- | --- | --- |
| [Dictionary\<string, TValue>](xref:System.Collections.Generic.Dictionary%602) |✔️|✔️|
| <xref:System.Collections.Generic.HashSet%601> |✔️|✔️|
| <xref:System.Collections.Generic.LinkedList%601> |✔️|✔️|
| <xref:System.Collections.Generic.LinkedListNode%60> |✔️|❌|
| <xref:System.Collections.Generic.List%601> |✔️|✔️|
| <xref:System.Collections.Generic.Queue%601> |✔️|✔️|
| [SortedDictionary\<string, TValue>](xref:System.Collections.Generic.SortedDictionary%602) |✔️|✔️|
| [Sorted:List\<string, TValue>](xref:System.Collections.Generic.SortedList%602) |✔️|✔️|
| <xref:System.Collections.Generic.SortedSet%601> |✔️|✔️|
| <xref:System.Collections.Generic.Stack%601> |✔️|✔️|
| <xref:System.Collections.Generic.KeyValuePair%602> |✔️|✔️|
| <xref:System.Collections.Generic.IAsyncEnumerable%601> |❌|❌|
| <xref:System.Collections.Generic.ICollection%601> |✔️|✔️|
| [IDictionary\<string, TValue>](xref:System.Collections.Generic.IDictionary%602) |✔️|✔️|
| <xref:System.Collections.Generic.IEnumerable%601> |✔️|✔️|
| <xref:System.Collections.Generic.IList%601> |✔️|✔️|
| <xref:System.Collections.Generic.IReadOnlyCollection%601> |✔️|✔️|
| [IReadOnlyDictionary\<string, TValue>](xref:System.Collections.Generic.IReadOnlyDictionary%602) |✔️|✔️|
| <xref:System.Collections.Generic.IReadOnlyList%601> |✔️|✔️|
| <xref:System.Collections.Generic.ISet%601> |✔️|✔️|

## System.Collections.Immutable namespace

| Type | Serialization | Deserialization |
| --- | --- | --- |
| <ImmutableArray%601> |✔️|✔️|
| [ImmutableDictionary\<string, TValue>](xref:System.Collections.Immutable.ImmutableDictionary%602) |✔️|✔️|
| <ImmutableHashSet%601>(https://docs.microsoft.com/dotnet/api/system.collections.immutable.immutablehashset-1?view=netcore-3.1) |✔️|✔️|
| <IImmutableList%601>(https://docs.microsoft.com/dotnet/api/system.collections.immutable.iimmutablelist-1?view=netcore-3.1) |✔️|✔️|
| <ImmutableQueue%601>(https://docs.microsoft.com/dotnet/api/system.collections.immutable.immutablequeue-1?view=netcore-3.1) |✔️|✔️|
| [ImmutableSortedDictionary\<string, TValue>](xref:System.Collections.Immutable.ImmutableSortedDictionary%602) |✔️|✔️|
| <ImmutableSortedSet%601> |✔️|✔️|
| <ImmutableStack%601> \* |✔️|✔️|
| [IImmutableDictionary\<string, TValue>](xref:System.Collections.Immutable.IImmutableDictionary%602) |✔️|✔️|
| <IImmutableList%601> |✔️|✔️|
| <IImmutableQueue%601> |✔️|✔️|
| <IImmutableSet%601> |✔️|✔️|
| <IImmutableStack%601> ([Note](system-text-json-converters-how-to.md#support-round-trip-for-stackt)) |✔️|✔️|

\* See [Support round trip for Stack\<T>](system-text-json-converters-how-to.md#support-round-trip-for-stackt).

## System.Collections.Specialized namespace

| Type | Serialization | Deserialization |
| --- | --- | --- |
| <xref:System.Collections.Specialized.BitVector32> \* |✔️|❌|
| <xref:System.Collections.Specialized.HybridDictionary> |✔️|✔️|
| <xref:System.Collections.Specialized.IOrderedDictionary> |✔️|❌|
| <xref:System.Collections.Specialized.ListDictionary> |✔️|✔️|
| <xref:System.Collections.Specialized.StringCollection> |✔️|❌|
| <xref:System.Collections.Specialized.StringDictionary> |✔️|❌|
| <xref:System.Collections.Specialized.NameValueCollection> |✔️|❌|

\* No exception is thrown when deserializing <xref:System.Collections.Specialized.BitVector32>, but the <xref:System.Collections.Specialized.BitVector32.Data> property is skipped because it is read-only (doesn't have a public setter).

## System.Collections.Concurrent namespace

| Type | Serialization | Deserialization |
| --- | --- | --- |
| <xref:System.Collections.Concurrent.BlockingCollection%601> |✔️|❌|
| <xref:System.Collections.Concurrent.ConcurrentBag%601> |✔️| ❌ |
| [ConcurrentDictionary\<string, TValue>](xref:System.Collections.Concurrent.ConcurrentDictionary%602) |✔️|✔️|
| <xref:System.Collections.Concurrent.ConcurrentQueue%601> |✔️|✔️|
| <xref:System.Collections.Concurrent.ConcurrentStack%601> \* |✔️|✔️|

\* See [Support round trip for Stack\<T>](system-text-json-converters-how-to.md#support-round-trip-for-stackt).

## System.Collections.ObjectModel namespace

| Type | Serialization | Deserialization |
| --- | --- | --- |
| <xref:System.Collections.ObjectModel.Collection%601> |✔️|✔️|
| <xref:System.Collections.ObjectModel.ObservableCollection%601> |✔️|✔️|
| [KeyedCollection\<string, TValue>](xref:System.Collections.ObjectModel.KeyedCollection%602) |✔️|❌|
| <ReadOnlyCollection%601> |✔️|❌|
| <ReadOnlyObservableCollection%601> |✔️|❌|
| [ReadOnlyDictionary\<string, TValue>](xref:System.Collections.ObjectModel.ReadOnlyDictionary%602) |✔️|❌|

## Custom collections

For serialization and deserialization in `System.Text.Json`, any
collection type that is not in one of the preceding namespaces is considered
a custom collection. Such types include user-defined types and types defined by ASP.NET Core. For example, <xref:Microsoft.Extensions.Primitives> is in this group.

All custom collections (everything that derives from `IEnumerable`) are supported for serialization, as long as their element types are supported.

### Supported custom collections

A custom collection is supported for deserialization if it fulfills the following requirements:

* It is not an interface or abstract
* It has a parameterless constructor
* It implements or inherits one or more of the following interfaces or classes:
  * <xref:System.Collections.IList>
  * <xref:System.Collections.Generic.IList%601>
  * <xref:System.Collections.Generic.ICollection%601>
  * <xref:System.Collections.IDictionary>
  * [IDictionary\<string, TValue>](xref:System.Collections.Generic.IDictionary%602),
  * <xref:System.Collections.Generic.Stack%601> \*
  * <xref:System.Collections.Generic.Queue%601>
  * <xref:System.Collections.Concurrent.ConcurrentStack%601> \*
  * <xref:System.Collections.Concurrent.ConcurrentQueue%601>
  * <xref:System.Collections.Stack> \*
  * <xref:System.Collections.Queue>
* The element type is supported by <xref:System.Text.Json.JsonSerializer>

\* See [Support round trip for Stack\<T>](system-text-json-converters-how-to.md#support-round-trip-for-stackt).

### Custom collections with known issues

There are known issues with some custom collections:

- <xref:System.Dynamic.ExpandoObject>: See [dotnet/runtime#29690](https://github.com/dotnet/runtime/issues/29690).
- <xref:System.Dynamic.DynamicObject>: See [dotnet/runtime#1808](https://github.com/dotnet/runtime/issues/1808).
- <xref:System.Data.DataTable>: See [dotnet/docs#21366](https://github.com/dotnet/docs/issues/21366).
- <xref:Microsoft.AspNetCore.Http.FormFile>: See [dotnet/runtime#1559](https://github.com/dotnet/runtime/issues/1559).]
- <xref:Microsoft.AspNetCore.Http.IFormCollection>

## See also

For more information, see the [open issues in System.Text.Json](https://github.com/dotnet/runtime/issues?q=is%3Aopen+is%3Aissue+label%3Aarea-System.Text.Json).

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
