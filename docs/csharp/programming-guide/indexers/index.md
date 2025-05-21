---
title: "Indexers"
description: Indexers in C# allow class or struct instances to be indexed like arrays. You can set or get the indexed value without specifying a type or instance member.
ms.date: 08/20/2024
f1_keywords: 
  - "cs.indexers"
helpviewer_keywords: 
  - "indexers [C#]"
  - "C# language, indexers"
ms.topic: article
---
# Indexers

You define *indexers* when instances of a class or struct can be indexed like an array or other collection. The indexed value can be set or retrieved without explicitly specifying a type or instance member. Indexers resemble [properties](../classes-and-structs/properties.md) except that their accessors take parameters.

The following example defines a generic class with [`get`](../../language-reference/keywords/get.md) and [`set`](../../language-reference/keywords/set.md) accessor methods to assign and retrieve values.

:::code language="csharp" source="./snippets/indexers/indexer-1.cs":::

The preceding example shows a read / write indexer. It contains both the `get` and `set` accessors. You can define read only indexers as an expression bodied member, as shown in the following examples:

:::code language="csharp" source="./snippets/indexers/indexer-2.cs":::

The `get` keyword isn't used; `=>` introduces the expression body.

Indexers enable *indexed* properties: properties referenced using one or more arguments. Those arguments provide an index into some collection of values.

- Indexers enable objects to be indexed similar to arrays.
- A `get` accessor returns a value. A `set` accessor assigns a value.
- The [`this`](../../language-reference/keywords/this.md) keyword defines the indexer.
- The [`value`](../../language-reference/keywords/value.md) keyword is the argument to the `set` accessor.
- Indexers don't require an integer index value; it's up to you how to define the specific look-up mechanism.
- Indexers can be overloaded.
- Indexers can have one or more formal parameters, for example, when accessing a two-dimensional array.
- You can declare [`partial` indexers](../../language-reference/keywords/partial-member.md) in [`partial` types](../../language-reference/keywords/partial-type.md).

You can apply almost everything you learned from working with properties to indexers. The only exception to that rule is *automatically implemented properties*. The compiler can't always generate the correct storage for an indexer. You can define multiple indexers on a type, as long as the argument lists for each indexer is unique.

## Uses of indexers

You define *indexers* in your type when its API models some collection. Your indexer isn't required to map directly to the collection types that are part of the .NET core framework. Indexers enable you to provide the API that matches your type's abstraction without exposing the inner details of how the values for that abstraction are stored or computed.

### Arrays and Vectors

Your type might model an array or a vector. The advantage of creating your own indexer is that you can define the storage for that collection to suit your needs. Imagine a scenario where your type models historical data that is too large to load into memory at once. You need to load and unload sections of the collection based on usage. The example following models this behavior. It reports on how many data points exist. It creates pages to hold sections of the data on demand. It removes pages from memory to make room for pages needed by more recent requests.

:::code language="csharp" source="./snippets/indexers/DataSamples.cs":::

You can follow this design idiom to model any sort of collection where there are good reasons not to load the entire set of data into an in-memory collection. Notice that the `Page` class is a private nested class that isn't part of the public interface. Those details are hidden from users of this class.

### Dictionaries

Another common scenario is when you need to model a dictionary or a map. This scenario is when your type stores values based on key, possibly text keys. This example creates a dictionary that maps command line arguments to [lambda expressions](../../delegates-overview.md) that manage those options. The following example shows two classes: an `ArgsActions` class that maps a command line option to an <xref:System.Action?displayProperty=nameWithType> delegate, and an `ArgsProcessor` that uses the `ArgsActions` to execute each <xref:System.Action> when it encounters that option.

:::code language="csharp" source="./snippets/indexers/ArgsProcessor.cs":::

In this example, the `ArgsAction` collection maps closely to the underlying collection. The `get` determines if a given option is configured. If so, it returns the <xref:System.Action> associated with that option. If not, it returns an <xref:System.Action> that does nothing. The public accessor doesn't include a `set` accessor. Rather, the design is using a public method for setting options.

### Multi-Dimensional Maps

You can create indexers that use multiple arguments. In addition, those arguments aren't constrained to be the same type.

The following example shows a class that generates values for a Mandelbrot set. For more information on the mathematics behind the set, read [this article](https://en.wikipedia.org/wiki/Mandelbrot_set). The indexer uses two doubles to define a point in the X, Y plane. The `get` accessor computes the number of iterations until a point is determined to be not in the set. When the maximum number of iterations is reached, the point is in the set, and the class's maxIterations value is returned. (The computer generated images popularized for the Mandelbrot set define colors for the number of iterations necessary to determine that a point is outside the set.)

:::code language="csharp" source="./snippets/indexers/Mandelbrot.cs":::

The Mandelbrot Set defines values at every (x,y) coordinate for real number values. That defines a dictionary that could contain an infinite number of values. Therefore, there's no storage behind the set. Instead, this class computes the value for each point when code calls the `get` accessor. There's no underlying storage used.

## Summing Up

You create indexers anytime you have a property-like element in your class where that property represents not a single value, but rather a set of values. One or more arguments identify each individual item. Those arguments can uniquely identify which item in the set should be referenced. Indexers extend the concept of [properties](../classes-and-structs/properties.md), where a member is treated like a data item from outside the class, but like a method on the inside. Indexers allow arguments to find a single item in a property that represents a set of items.

You can access the [sample folder for indexers](https://github.com/dotnet/samples/tree/main/csharp/indexers). For download instructions, see [Samples and Tutorials](../../../samples-and-tutorials/index.md#view-and-download-samples).

## C# Language Specification

For more information, see [Indexers](~/_csharpstandard/standard/classes.md#159-indexers) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.
