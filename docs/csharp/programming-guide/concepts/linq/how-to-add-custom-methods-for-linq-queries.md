---
title: "How to add custom methods for LINQ queries (C#)"
description: Learn how to extend the syntax of LINQ queries by adding extension methods to the IEnumerable<T> interface in C#.
ms.topic: how-to
ms.date: 09/10/2021
ms.assetid: 1a500f60-2e10-49fb-8b2a-d8d08e4817cb
---

# How to add custom methods for LINQ queries (C#)

You extend the set of methods that you use for LINQ queries by adding extension methods to the <xref:System.Collections.Generic.IEnumerable%601> interface. For example, in addition to the standard average or maximum operations, you create a custom aggregate method to compute a single value from a sequence of values. You also create a method that works as a custom filter or a specific data transform for a sequence of values and returns a new sequence. Examples of such methods are <xref:System.Linq.Enumerable.Distinct%2A>, <xref:System.Linq.Enumerable.Skip%2A>, and <xref:System.Linq.Enumerable.Reverse%2A>.

When you extend the <xref:System.Collections.Generic.IEnumerable%601> interface, you can apply your custom methods to any enumerable collection. For more information, see [Extension Methods](../../classes-and-structs/extension-methods.md).

## Add an aggregate method

An aggregate method computes a single value from a set of values. LINQ provides several aggregate methods, including <xref:System.Linq.Enumerable.Average%2A>, <xref:System.Linq.Enumerable.Min%2A>, and <xref:System.Linq.Enumerable.Max%2A>. You can create your own aggregate method by adding an extension method to the <xref:System.Collections.Generic.IEnumerable%601> interface.

The following code example shows how to create an extension method called `Median` to compute a median for a sequence of numbers of type `double`.

:::code language="csharp" source="./snippets/extensions/LinqExtensions.cs" ID="LinqExtensionClass":::

You call this extension method for any enumerable collection in the same way you call other aggregate methods from the <xref:System.Collections.Generic.IEnumerable%601> interface.

The following code example shows how to use the `Median` method for an array of type `double`.

:::code language="csharp" source="./snippets/extensions/Program.cs" ID="MedianUsage":::

### Overload an aggregate method to accept various types

You can overload your aggregate method so that it accepts sequences of various types. The standard approach is to create an overload for each type. Another approach is to create an overload that will take a generic type and convert it to a specific type by using a delegate. You can also combine both approaches.

#### Create an overload for each type

You can create a specific overload for each type that you want to support. The following code example shows an overload of the `Median` method for the `int` type.

:::code language="csharp" source="./snippets/extensions/LinqExtensions.cs" ID="IntOverload":::

You can now call the `Median` overloads for both `integer` and `double` types, as shown in the following code:

:::code language="csharp" source="./snippets/extensions/Program.cs" ID="OverloadUsage":::

#### Create a generic overload

You can also create an overload that accepts a sequence of generic objects. This overload takes a delegate as a parameter and uses it to convert a sequence of objects of a generic type to a specific type.

The following code shows an overload of the `Median` method that takes the <xref:System.Func%602> delegate as a parameter. This delegate takes an object of generic type T and returns an object of type `double`.

:::code language="csharp" source="./snippets/extensions/LinqExtensions.cs" ID="GenericOverload":::

You can now call the `Median` method for a sequence of objects of any type. If the type doesn't have its own method overload, you have to pass a delegate parameter. In C#, you can use a lambda expression for this purpose. Also, in Visual Basic only, if you use the `Aggregate` or `Group By` clause instead of the method call, you can pass any value or expression that is in the scope this clause.

The following example code shows how to call the `Median` method for an array of integers and an array of strings. For strings, the median for the lengths of strings in the array is calculated. The example shows how to pass the <xref:System.Func%602> delegate parameter to the `Median` method for each case.

:::code language="csharp" source="./snippets/extensions/Program.cs" ID="GenericUsage":::

## Add a method that returns a sequence

You can extend the <xref:System.Collections.Generic.IEnumerable%601> interface with a custom query method that returns a sequence of values. In this case, the method must return a collection of type <xref:System.Collections.Generic.IEnumerable%601>. Such methods can be used to apply filters or data transforms to a sequence of values.

The following example shows how to create an extension method named `AlternateElements` that returns every other element in a collection, starting from the first element.

:::code language="csharp" source="./snippets/extensions/LinqExtensions.cs" ID="SequenceElement":::

You can call this extension method for any enumerable collection just as you would call other methods from the <xref:System.Collections.Generic.IEnumerable%601> interface, as shown in the following code:

:::code language="csharp" source="./snippets/extensions/Program.cs" ID="SequenceUsage":::

## See also

- <xref:System.Collections.Generic.IEnumerable%601>
- [Extension Methods](../../classes-and-structs/extension-methods.md)
