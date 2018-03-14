---
title: Discards - C# Guide
description: Describes C#'s support for discards, which are unassigned, discardable variables, and the ways in which discards can be used.
keywords: .NET,.NET Core
author: rpetrusha
ms.author: ronpet
ms.date: 07/21/2017
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
---
# Discards - C# Guide

Starting with C# 7, C# supports discards, which are temporary, dummy variables that are intentionally unused in application code. Discards are equivalent to unassigned variables; they do not have a value. Because there is only a single discard variable, and that variable may not even be allocated storage, discards can reduce memory allocations. Because they make the intent of your code clear, they enhance its readability and maintainability.

You indicate that a variable is a discard by assigning it the underscore (`_`) as its name. For example, the following method call returns a 3-tuple in which the first and second values are discards and *area* is a previously declared variable to be set to the corresponding third component returned by *GetCityInformation*:

```csharp
(_, _, area) = city.GetCityInformation(cityName);
```

In C# 7, discards are supported in assignments in the following contexts:

- Tuple and object [deconstruction](deconstruct.md).
- Pattern matching with [is](language-reference/keywords/is.md) and [switch](language-reference/keywords/switch.md).
- Calls to methods with `out` parameters.
- A standalone `_` when no `_` is in scope.

When `_` is a valid discard, attempting to retrieve its value or use it in an assignment operation generates compiler error CS0301, "The name '\_' does not exist in the current context". This is because `_` is not assigned a value, and may not even be assigned a storage location. If it were an actual variable, you could not discard more than one value, as the previous example did.

## Tuple and object deconstruction

Discards are particularly useful in working with tuples when your application code uses some tuple elements but ignores others. For example, the following `QueryCityDataForYears` method returns a 6-tuple with the name of a city, its area, a year, the city's population for that year, a second year, and the city's population for that second year. The example shows the change in population between those two years. Of the data available from the tuple, we're unconcerned with the city area, and we know the city name and the two dates at design-time. As a result, we're only interested in the two population values stored in the tuple, and can handle its remaining values as discards.  

[!code-csharp[Tuple-discard](../../samples/snippets/csharp/programming-guide/deconstructing-tuples/discard-tuple1.cs)]

For more information on deconstructing tuples with discards, see [Deconstructing tuples and other types](deconstruct.md#deconstructing-tuple-elements-with-discards).

The `Deconstruct` method of a class, structure, or interface also allows you to retrieve and deconstruct a specific set of data from an object. You can use discards when you are interested in working with only a subset of the deconstructed values. Ihe following example deconstructs a `Person` object into four strings (the first and last names, the city, and the state), but discards the last name and the state.

[!code-csharp[Class-discard](../../samples/snippets/csharp/programming-guide/deconstructing-tuples/class-discard1.cs)]

For more information on deconstructing user-defined types with discards, see [Deconstructing tuples and other types](deconstruct.md#deconstructing-a-user-defined-type-with-discards).

## Pattern matching with `switch` and `is`

The *discard pattern* can be used in pattern matching with the [is](language-reference/keywords/is.md) and [switch](language-reference/keywords/switch.md) keywords. Every expression always matches the discard pattern.

The following example defines a `ProvidesFormatInfo` method that uses [is](language-reference/keywords/is.md) statements to determine whether an object provides an <xref:System.IFormatProvider> implementation and tests whether the object is `null`. It also uses the discard pattern to handle non-null objects of any other type.

[!code-csharp[discard-pattern](../../samples/snippets/csharp/programming-guide/discards/discard-pattern2.cs)]

## Calls to methods with out parameters

When calling the `Deconstruct` method to deconstruct a user-defined type (an instance of a class, structure, or interface), you can discard the values of individual `out` arguments. But you can also discard the value of `out` arguments when calling any method with an out parameter. 

The following example calls the [DateTime.TryParse(String, out DateTime)](<xref:System.DateTime.TryParse(System.String,System.DateTime@)>) method to determine whether the string representation of a date is valid in the current culture. Because the example is concerned only with validating the date string and not with parsing it to extract the date, the `out` argument to the method is a discard.

[!code-csharp[discard-with-out](../../samples/snippets/csharp/programming-guide/discards/discard-out1.cs)]

## A standalone discard

You can use a standalone discard to indicate any variable that you choose to ignore. The following example uses a standalone discard to ignore the <xref:System.Threading.Tasks.Task> object returned by an asynchronous operation. This has the effect of suppressing the exception that the operation throws as it is about to complete.

[!code-csharp[standalone-discard](../../samples/snippets/csharp/programming-guide/discards/standalone-discard1.cs)]

Note that `_` is also a valid identifier. When used outside of a supported context, `_` is treated not as a discard but as a valid variable. If an identifier named `_` is already in scope, the use of `_` as a standalone discard can result in:

- Accidental modification of the value of the in-scope `_` variable by assigning it the value of the intended discard. For example:

   [!code-csharp[standalone-discard](../../samples/snippets/csharp/programming-guide/discards/standalone-discard2.cs#1)]
 
- A compiler error for violating type safety. For example:

   [!code-csharp[standalone-discard](../../samples/snippets/csharp/programming-guide/discards/standalone-discard2.cs#2)]
 
- Compiler error CS0136, "A local or parameter named '_' cannot be declared in this scope because that name is used in an enclosing local scope to define a local or parameter." For example:

   [!code-csharp[standalone-discard](../../samples/snippets/csharp/programming-guide/discards/standalone-discard2.cs#3)]

## See also
[Deconstructing tuples and other types](deconstruct.md)   
[`is` keyword](language-reference/keywords/is.md)   
[`switch` keyword](language-reference/keywords/switch.md)   
