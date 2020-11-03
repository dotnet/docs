---
title: Implement custom operator
description: Learn how to implement custom operators, or customize existing operators with Reactive Extension in .NET.
author: IEvangelist
ms.date: 11/03/2020
ms.author: dapine
ms.topic: tutorial
---

# Implement custom operator

You can extend Rx by adding new operators for operations that are not provided by the LINQ library, or by creating your own implementation of standard query operators to improve readability and performance. Writing a customized version of a standard LINQ operator is useful when you want to operate with in-memory objects and when the intended customization does not require a comprehensive view of the query.

## Create new operators

LINQ offers a full set of operators that cover most of the possible operations on a set of entities. However, you might need an operator to add a particular semantic meaning to your query—especially if you can reuse that same operator several times in your code.

Many existing LINQ operators are in fact built using other basic LINQ operators. For example, the SelectMany operator is built by composing the Select and Merge operators, as the following code shows.

```csharp
public static IObservable<TResult> SelectMany<TSource, TResult>(
    this IObservable<TSource> source,
    Func<TSource, IObservable<TResult>> selector) =>
    source.Select(selector).Merge();
```

By reusing existing LINQ operators when you build a new one, you can take advantage of the existing performance or exception handling capabilities implemented in the Rx libraries.

When writing a custom operator, it is good practice not to leave any disposables unused; otherwise, you may find that resources could actually be leaked and cancellation may not work correctly.

### Customize existing operators

Adding new operators to LINQ is a way to extend its capabilities. However, you can also improve code readability by wrapping existing operators into more specialized and meaningful ones.
