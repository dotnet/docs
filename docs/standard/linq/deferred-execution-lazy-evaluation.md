---
title: Deferred execution and lazy evaluation - LINQ to XML
description: Learn the advantages and requirements of deferred execution, and how to implement it using query and axis operations.
ms.date: 07/20/2015
ms.assetid: 8683d1b4-b7ec-407b-be12-906ebe958a09
---

# Deferred execution and lazy evaluation (LINQ to XML)

Query and axis operations are often implemented to use deferred execution. This article explains the requirements and advantages of deferred execution, and some implementation considerations.

## Deferred execution

Deferred execution means that the evaluation of an expression is delayed until its *realized* value is actually required. Deferred execution can greatly improve performance when you have to manipulate large data collections, especially in programs that contain a series of chained queries or manipulations. In the best case, deferred execution enables only a single iteration through the source collection.

The LINQ technologies make extensive use of deferred execution in both the members of core <xref:System.Linq?displayProperty=nameWithType> classes and in the extension methods in the various LINQ namespaces, such as <xref:System.Xml.Linq.Extensions?displayProperty=nameWithType>.

Deferred execution is supported directly in the C# language by the [yield (C# Reference)](../../csharp/language-reference/statements/yield.md) keyword (in the form of the `yield-return` statement) when used within an iterator block. Such an iterator must return a collection of type <xref:System.Collections.IEnumerator> or <xref:System.Collections.Generic.IEnumerator%601> (or a derived type).

## Eager vs. lazy evaluation

When you write a method that implements deferred execution, you also have to decide whether to implement the method using lazy evaluation or eager evaluation.

- In *lazy evaluation*, a single element of the source collection is processed during each call to the iterator. This is the typical way in which iterators are implemented.
- In *eager evaluation*, the first call to the iterator will result in the entire collection being processed. A temporary copy of the source collection might also be required. For example, the <xref:System.Linq.Enumerable.OrderBy%2A> method has to sort the entire collection before it returns the first element.

Lazy evaluation usually yields better performance because it distributes overhead processing evenly throughout the evaluation of the collection and minimizes the use of temporary data. Of course, for some operations, there is no other option than to materialize intermediate results.

See [Deferred execution example](deferred-execution-example.md) for an example of programming deferred execution in C# and Visual Basic.

## See also

- [Tutorial: Chain Queries Together in C#](chain-queries-example.md)
- [Concepts and terminology (functional transformation)](concepts-terminology-functional-transformation.md)
- [Aggregation Operations (C#)](../../csharp/linq/standard-query-operators/index.md)
- [Aggregation Operations (Visual Basic)](../../visual-basic/programming-guide/concepts/linq/aggregation-operations.md)
- [yield (C# Reference)](../../csharp/language-reference/statements/yield.md)
