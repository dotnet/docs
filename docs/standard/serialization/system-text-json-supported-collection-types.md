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

### System.Collections.Immutable namespace

| Type | Serialization | Deserialization |
| --- | --- | --- |
| [`ImmutableArray<T>`](https://docs.microsoft.com/dotnet/api/system.collections.immutable.immutablearray-1?view=netcore-3.1) |✔️|✔️|
| [`ImmutableDictionary<string, TValue>`](https://docs.microsoft.com/dotnet/api/system.collections.immutable.immutabledictionary-2?view=netcore-3.1) |✔️|✔️|
| [`ImmutableHashSet<T>`](https://docs.microsoft.com/dotnet/api/system.collections.immutable.immutablehashset-1?view=netcore-3.1) |✔️|✔️|
| [`IImmutableList<T>`](https://docs.microsoft.com/dotnet/api/system.collections.immutable.iimmutablelist-1?view=netcore-3.1) |✔️|✔️|
| [`ImmutableQueue<T>`](https://docs.microsoft.com/dotnet/api/system.collections.immutable.immutablequeue-1?view=netcore-3.1) |✔️|✔️|
| [`ImmutableSortedDictionary<string, TValue>`](https://docs.microsoft.com/dotnet/api/system.collections.immutable.immutablesorteddictionary-2?view=netcore-3.1) |✔️|✔️|
| [`ImmutableSortedSet<T>`](https://docs.microsoft.com/dotnet/api/system.collections.immutable.immutablesortedset-1?view=netcore-3.1) |✔️|✔️|
| [`ImmutableStack<T>`](https://docs.microsoft.com/dotnet/api/system.collections.immutable.immutablestack-1?view=netcore-3.1)* |✔️|✔️|
| [`IImmutableDictionary<string, TValue>`](https://docs.microsoft.com/dotnet/api/system.collections.immutable.iimmutabledictionary-2?view=netcore-3.1) |✔️|✔️|
| [`IImmutableList<T>`](https://docs.microsoft.com/dotnet/api/system.collections.immutable.iimmutablelist-1?view=netcore-3.1) |✔️|✔️|
| [`IImmutableQueue<T>`](https://docs.microsoft.com/dotnet/api/system.collections.immutable.iimmutablequeue-1?view=netcore-3.1) |✔️|✔️|
| [`IImmutableSet<T>`](https://docs.microsoft.com/dotnet/api/system.collections.immutable.iimmutableset-1?view=netcore-3.1) |✔️|✔️|
| [`IImmutableStack<T>`](https://docs.microsoft.com/dotnet/api/system.collections.immutable.iimmutablestack-1?view=netcore-3.1)* |✔️|✔️|

### [`System.Collections.Specialized`](https://docs.microsoft.com/dotnet/api/system.collections.specialized?view=netcore-3.1)

| Type | Serialization | Deserialization |
| --- | --- | --- |
| [`BitVector32`](https://docs.microsoft.com/dotnet/api/system.collections.specialized.bitvector32?view=netcore-3.1)** |✔️|❌|
| [`HybridDictionary`](https://docs.microsoft.com/dotnet/api/system.collections.specialized.hybriddictionary?view=netcore-3.1) |✔️|✔️|
| [`IOrderedDictionary`](https://docs.microsoft.com/dotnet/api/system.collections.specialized.iordereddictionary?view=netcore-3.1) |✔️|❌|
| [`ListDictionary`](https://docs.microsoft.com/dotnet/api/system.collections.specialized.listdictionary?view=netcore-3.1) |✔️|✔️|
| [`StringCollection`](https://docs.microsoft.com/dotnet/api/system.collections.specialized.stringcollection?view=netcore-3.1) |✔️|❌|
| [`StringDictionary`](https://docs.microsoft.com/dotnet/api/system.collections.specialized.stringdictionary?view=netcore-3.1) |✔️|❌|
| [`NameValueCollection`](https://docs.microsoft.com/dotnet/api/system.collections.specialized.namevaluecollection?view=netcore-3.1) |✔️|❌|

### [`System.Collections.Concurrent`](https://docs.microsoft.com/dotnet/api/system.collections.concurrent?view=netcore-3.1)

| Type | Serialization | Deserialization |
| --- | --- | --- |
| [`BlockingCollection<T>`](https://docs.microsoft.com/dotnet/api/system.collections.concurrent.blockingcollection-1?view=netcore-3.1) |✔️|❌|
| [`ConcurrentBag<T>`](https://docs.microsoft.com/dotnet/api/system.collections.concurrent.concurrentbag-1?view=netcore-3.1) |✔️| NotSupported |
| [`ConcurrentDictionary<string, TValue>`](https://docs.microsoft.com/dotnet/api/system.collections.concurrent.concurrentdictionary-2?view=netcore-3.1) |✔️|✔️|
| [`ConcurrentQueue<T>`](https://docs.microsoft.com/dotnet/api/system.collections.concurrent.concurrentqueue-1?view=netcore-3.1) |✔️|✔️|
| [`ConcurrentStack<T>`](https://docs.microsoft.com/dotnet/api/system.collections.concurrent.stack-1?view=netcore-3.1)* |✔️|✔️|

### [`System.Collections.ObjectModel`](https://docs.microsoft.com/dotnet/api/system.collections.objectmodel?view=netcore-3.1)

| Type | Serialization | Deserialization |
| --- | --- | --- |
| [`Collection<T>`](https://docs.microsoft.com/dotnet/api/system.collections.objectmodel.collection-1?view=netcore-3.1) |✔️|✔️|
| [`ObservableCollection<T>`](https://docs.microsoft.com/dotnet/api/system.collections.objectmodel.observablecollection-1?view=netcore-3.1) |✔️|✔️|
| [`KeyedCollection<string, TValue>`](https://docs.microsoft.com/dotnet/api/system.collections.objectmodel.keyedcollection-2?view=netcore-3.1) |✔️|❌|
| [`ReadOnlyCollection<T>`](https://docs.microsoft.com/dotnet/api/system.collections.objectmodel.readonlycollection-1?view=netcore-3.1) |✔️|❌|
| [`ReadOnlyObservableCollection<T>`](https://docs.microsoft.com/dotnet/api/system.collections.objectmodel.readonlyobservablecollection-1?view=netcore-3.1) |✔️|❌|
| [`ReadOnlyDictionary<string, TValue>`](https://docs.microsoft.com/dotnet/api/system.collections.objectmodel.readonlydictionary-2?view=netcore-3.1) |✔️|❌|

## Custom collections

For the purpose of serialization and deserialization in System.Text.Json, any
collection not in the BCL, (i.e. outside `System.Collections[.[.\*]]`), is considered
a custom collection. This includes user-defined types and ASP.NET defined types,
e.g. those in
[Microsoft.Extensions.Primitives](https://docs.microsoft.com/dotnet/api/microsoft.extensions.primitives?view=dotnet-plat-ext-3.1).

A custom collection is✔️for deserialization if it fulfils the following:

1. Is not an interface or abstract
2. Has a parameter-less constructor
3. Implements one or more of
   [`IList`](https://docs.microsoft.com/dotnet/api/system.collections.ilist?view=netcore-3.1),
   [`IList<T>`](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1?view=netcore-3.1),
   [`ICollection<T>`](https://docs.microsoft.com/dotnet/api/system.collections.generic.icollection-1?view=netcore-3.1),
   [`IDictionary`](https://docs.microsoft.com/dotnet/api/system.collections.idictionary?view=netcore-3.1),
   [`IDictionary<string, TValue>`](https://docs.microsoft.com/dotnet/api/system.collections.generic.idictionary-2?view=netcore-3.1),
   [`Stack<T>`](https://docs.microsoft.com/dotnet/api/system.collections.generic.stack-1?view=netcore-3.1)\*,
   [`Queue<T>`](https://docs.microsoft.com/dotnet/api/system.collections.generic.queue-1?view=netcore-3.1),
   [`ConcurrentStack<T>`](https://docs.microsoft.com/dotnet/api/system.collections.concurrent.concurrentstack-1?view=netcore-3.1)\*,
   [`ConcurrentQueue<T>`](https://docs.microsoft.com/dotnet/api/system.collections.concurrent.concurrentqueue-1?view=netcore-3.1),
   [`Stack`](https://docs.microsoft.com/dotnet/api/system.collections.stack?view=netcore-3.1)\*,
   and [`Queue`](https://docs.microsoft.com/dotnet/api/system.collections.queue?view=netcore-3.1)
4. The element type is✔️by [`JsonSerializer`](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializer?view=netcore-3.1)

All custom collections (everything that derives from [`IEnumerable`](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable?view=netcore-3.1))
are✔️for serialization, as long as their element types are supported.

There are known issues with some custom collections where we don't offer round-trippable support.
These include:

- Support for [`ExpandoObject`](https://docs.microsoft.com/dotnet/api/system.dynamic.expandoobject?view=netcore-3.1): https://github.com/dotnet/corefx/issues/38007
- Support for [`DynamicObject`](https://docs.microsoft.com/dotnet/api/system.dynamic.dynamicobject?view=netcore-3.1): https://github.com/dotnet/corefx/issues/41105
- Support for [`DataTable`](https://docs.microsoft.com/dotnet/api/system.data.datatable?view=netcore-3.1): https://github.com/dotnet/corefx/issues/38712
- Support for [`FormFile`](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.http.formfile?view=aspnetcore-3.1): https://github.com/dotnet/corefx/issues/41401
- Support for [`IFormCollection`](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.http.iformcollection?view=aspnetcore-3.1)
- Assigning `null` to value-type collections like [`ImmutableArray<T>`](https://docs.microsoft.com/dotnet/api/system.collections.immutable.immutablearray-1?view=netcore-3.1): https://github.com/dotnet/corefx/issues/42399

For more information, see the [open issues in System.Text.Json](https://github.com/dotnet/runtime/issues?q=is%3Aopen+is%3Aissue+label%3Aarea-System.Text.Json).

---

\* [`Stack`](https://docs.microsoft.com/dotnet/api/system.collections.stack?view=netcore-3.1),
[`Stack<T>`](https://docs.microsoft.com/dotnet/api/system.collections.generic.stack-1?view=netcore-3.1),
[`ImmutableStack<T>`](https://docs.microsoft.com/dotnet/api/system.collections.immutable.immutablestack-1?view=netcore-3.1),
[`IImmutableStack<T>`](https://docs.microsoft.com/dotnet/api/system.collections.immutable.iimmutablestack-1?view=netcore-3.1),
and [`ConcurrentStack<T>`](https://docs.microsoft.com/dotnet/api/system.collections.concurrent.concurrentstack-1?view=netcore-3.1)
instances; and instances of types that derive from them; are reversed on serialization. Thus, the serializer does not have round-trippable support
for these types. See https://github.com/dotnet/corefx/issues/41887.

\** No exception is thrown when deserializing [`BitVector32`](https://docs.microsoft.com/dotnet/api/system.collections.specialized.bitvector32?view=netcore-3.1),
but the [`Data`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.bitvector32.data?view=netcore-3.1)
property skipped because it is read-only (doesn't have a public setter).




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
