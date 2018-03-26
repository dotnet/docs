---
title: How to articles (C# Guide)
description: A collection of quick tips and short, focused code samples
author: billwagner
ms.author: wiwagn
ms.date: 12/20/2017
ms.topic: article
ms.prod: .net
ms.devlang: devlang-csharp
---

# How to (C#)

In the How to section of the C# Guide you can find quick answers
to common questions. In some cases, articles may
be listed in multiple sections. We wanted to make them easy to find
for multiple search paths. 

## General C# concepts

There are several tips and tricks that are common C# developer practices.

- [Initialize objects using an object initializer](../programming-guide/classes-and-structs/how-to-initialize-objects-by-using-an-object-initializer.md).
- [Learn the differences between passing a struct and a class to a method](../programming-guide/classes-and-structs/how-to-know-the-difference-passing-a-struct-and-passing-a-class-to-a-method.md).
- [How to use lambda expressions](../programming-guide/statements-expressions-operators/how-to-use-lambda-expressions-outside-linq.md).
- [Resolve type name conflicts by using the global namespace alias](../programming-guide/namespaces/how-to-use-the-global-namespace-alias.md).
- [Use operator overloading](../programming-guide/statements-expressions-operators/how-to-use-operator-overloading-to-create-a-complex-number-class.md).
- [Implement and call a custom extension method](../programming-guide/classes-and-structs/how-to-implement-and-call-a-custom-extension-method.md).
- Even C# programmers may want to [use the `My` namespace from VB](../programming-guide/namespaces/how-to-use-the-my-namespace.md).
- [Create a new method for an `enum` type using extension methods](../programming-guide/classes-and-structs/how-to-create-a-new-method-for-an-enumeration.md).

### Class and struct members

You create classes and structs to implement your program. These techniques are commonly used when writing classes or structs.

- [Declare auto implemented properties](../programming-guide/classes-and-structs/how-to-implement-a-lightweight-class-with-auto-implemented-properties.md).
- [Declare and use read/write properties](../programming-guide/classes-and-structs/how-to-declare-and-use-read-write-properties.md).
- [Define constants](../programming-guide/classes-and-structs/how-to-define-constants.md).
- [Override the `ToString` method to provide string output](../programming-guide/classes-and-structs/how-to-override-the-tostring-method.md).
- [Define abstract properties](../programming-guide/classes-and-structs/how-to-define-abstract-properties.md).
- [Use the xml documentation features to document your code](../programming-guide/xmldoc/how-to-use-the-xml-documentation-features.md).
- [Explicitly implement interface members](../programming-guide/interfaces/how-to-explicitly-implement-interface-members.md) to keep your public interface concise.
- [Explicitly implement members of two interfaces](../programming-guide/interfaces/how-to-explicitly-implement-members-of-two-interfaces.md).

### Working with collections

These articles help you work with collections of data.

- [Initialize a dictionary with a collection initializer](../programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer.md).
- [Access all the elements in a collection using `foreach`](../programming-guide/classes-and-structs/how-to-access-a-collection-class-with-foreach.md).

## strings

Strings are the fundamental data type used to display or manipulate text. These articles demonstrate common practices with strings.

- [Compare strings](compare-strings.md).
- [Modify the contents of a string](modify-string-contents.md).
- [Determine if a string represents a number](../programming-guide/strings/how-to-determine-whether-a-string-represents-a-numeric-value.md).
- [Use `String.Split` to separate strings](parse-strings-using-split.md).
- [Combine multiple strings into one](concatenate-multiple-strings.md).
- [Search for text in a string](search-strings.md).

## Convert between types

You may need to convert an object to a different type.

- [Determine if a string represents a number](../programming-guide/strings/how-to-determine-whether-a-string-represents-a-numeric-value.md).
- [Convert between strings that represent hexadecimal numbers and the number](../programming-guide/types/how-to-convert-between-hexadecimal-strings-and-numeric-types.md).
- [Convert a string to a `DateTime`](../../standard/base-types/parsing-datetime.md).
- [Convert a byte array to an int](../programming-guide/types/how-to-convert-a-byte-array-to-an-int.md).
- [Convert a string to a number](../programming-guide/types/how-to-convert-a-string-to-a-number.md).
- [Use `as` and `is` to safely cast to a different type](../programming-guide/types/how-to-safely-cast-by-using-as-and-is-operators.md).
- [Define conversion operators for `struct` types](../programming-guide/statements-expressions-operators/how-to-implement-user-defined-conversions-between-structs.md).
- [Determine if a type is a nullable value type](../programming-guide/nullable-types/how-to-identify-a-nullable-type.md).
- [Convert between nullable and non-nullable value types](../programming-guide/nullable-types/how-to-safely-cast-from-bool-to-bool.md).

## Equality and ordering comparisons

You may create types that define their own rules for equality or define a
natural ordering among objects of that type.

- [Test for reference-based equality](../programming-guide/statements-expressions-operators/how-to-test-for-reference-equality-identity.md).
- [Define value-based equality for a type](../programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type.md).

## Exception handling

.NET programs report that methods did not
successfully complete their work by throwing exceptions. In these articles you'll learn to work
with exceptions.

- [Handle exceptions using `try` and `catch`](../programming-guide/exceptions/how-to-handle-an-exception-using-try-catch.md).
- [Cleanup resources using `finally` clauses](../programming-guide/exceptions/how-to-execute-cleanup-code-using-finally.md).
- [Recover from non-CLS (Common Language Specification) exceptions](../programming-guide/exceptions/how-to-catch-a-non-cls-exception.md).

## Delegates and events

Delegates and events provide a capability for strategies that involve
loosely coupled blocks of code.

- [Declare, instantiate, and use delegates](../programming-guide/delegates/how-to-declare-instantiate-and-use-a-delegate.md).
- [Combine multicast delegates](../programming-guide/delegates/how-to-combine-delegates-multicast-delegates.md).

Events provide a mechanism to publish or subscribe to notifications.

- [Subscribe and unsubscribe from events](../programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md).
- [Implement events declared in interfaces](../programming-guide/events/how-to-implement-interface-events.md).
- [Conform to .NET Framework guidelines when your code publishes events](../programming-guide/events/how-to-publish-events-that-conform-to-net-framework-guidelines.md).
- [Raise events defined in base classes from derived classes](../programming-guide/events/how-to-raise-base-class-events-in-derived-classes.md).
- [Store event instances in a dictionary](../programming-guide/events/how-to-use-a-dictionary-to-store-event-instances.md).
- [Implement custom event accessors](../programming-guide/events/how-to-implement-custom-event-accessors.md).

## LINQ practices

LINQ enables you to write code to query any data source that supports the
LINQ query expression pattern. These articles help you understand the pattern
and work with different data sources.

- [Query a collection](../programming-guide/concepts/linq/how-to-query-an-arraylist-with-linq.md).
- [Use lambda expressions in a query](../programming-guide/statements-expressions-operators/how-to-use-lambda-expressions-in-a-query.md).
- [Use `var` in query expressions](../programming-guide/classes-and-structs/how-to-use-implicitly-typed-local-variables-and-arrays-in-a-query-expression.md).
- [Return subsets of element properties from a query](../programming-guide/classes-and-structs/how-to-return-subsets-of-element-properties-in-a-query.md).
- [Write queries with complex filtering](../programming-guide/concepts/linq/how-to-write-queries-with-complex-filtering.md).
- [Sort elements of a data source](../programming-guide/concepts/linq/how-to-sort-elements.md).
- [Sort elements on multiple keys](../programming-guide/concepts/linq/how-to-sort-elements-on-multiple-keys.md).
- [Control the type of a projection](../programming-guide/concepts/linq/how-to-control-the-type-of-a-projection.md).
- [Count occurences of a value in a source sequence](../programming-guide/concepts/linq/how-to-count-occurrences-of-a-word-in-a-string-linq.md).
- [Calculate intermediate values](../programming-guide/concepts/linq/how-to-calculate-intermediate-values.md).
- [Merge data from multiple sources](../programming-guide/concepts/linq/how-to-populate-object-collections-from-multiple-sources-linq.md).
- [Find the set difference between two sequences](../programming-guide/concepts/linq/how-to-find-the-set-difference-between-two-lists-linq.md).
- [Debug empty query results](../programming-guide/concepts/linq/how-to-debug-empty-query-results-sets.md).
- [Add custom methods to LINQ queries](../programming-guide/concepts/linq/how-to-add-custom-methods-for-linq-queries.md).

## Multiple threads and async processing

Modern programs often use asynchronous operations. These articles will help you learn
to use these techniques.

- [Improve async performance using `System.Threading.Tasks.Task.WhenAll`](../programming-guide/concepts/async/how-to-extend-the-async-walkthrough-by-using-task-whenall.md).
- [Make multiple web requests in parallel using `async` and `await`](../programming-guide/concepts/async/how-to-make-multiple-web-requests-in-parallel-by-using-async-and-await.md).
- [Use a thread pool](../programming-guide/concepts/threading/how-to-use-a-thread-pool.md).

## Command line args to your program

Typically, C# programs have command line arguments. These articles teach you to access and process
those command line arguments.

- [Retrieve all command line arguments with `for`](../programming-guide/main-and-command-args/how-to-display-command-line-arguments.md).
- [Retrieve all command line arguments with `foreach`](../programming-guide/main-and-command-args/how-to-access-command-line-arguments-using-foreach.md).
