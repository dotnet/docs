---
title: Deconstructing tuples and other types | Microsoft Docs
description: Learn how to deconstruct tuples and other types
keywords: .NET, .NET Core, C#
author: rpetrusha
ms-author: ronpet
ms.date: 07/18/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 0b0c4b0f-4a47-4f66-9b8e-f5c63b195960
---

# Deconstructing tuples and other types #

A tuple provides a light-weight way to retrieve multiple values from a method call. But once you retrieve the tuple, you have to handle its individual elements. Doing this on an element-by-element basis is cumbersome, as the following example shows. The `QueryCityData` method returns a 3-tuple. Each of its three elements is assigned to a variable in a separate operation.

[!code-csharp[WithoutDeconstruction](../../samples/snippets/csharp/programming-guide/deconstructing-tuples/deconstruct-tuple1.cs)]

Retrieving multiple field and property values from an object can be equally cumbersome: you have to make assign a field or property value to a variable on a member-by-member basis. 

Starting with C# 7, you can retrieve multiple elements from a tuple or retrieve multiple fields and properties from an object in a single *deconstruct* operation. When you deconstruct a tuple, you assign its elements to individual variables. When you deconstruct an object, you assign selected field or property values to individual variables. 

## Deconstructing a tuple

You can unpackage all the items in a tuple by deconstructing the tuple returned by a method. The general syntax for deconstructing a tuple is similar to the syntax for defining one: you enclose the variables to which each element is to be assigned in parentheses in the left side of an assignment statement. For example, the following statement assigns the elements of a 4-tuple to four separate variables:

```csharp
var (name, address, city, zip) = contact.GetAddressInfo();
```

There are two ways to do deconstruct a tuple:

- You can explicitly declare the type of each field inside parentheses. The following example uses this approach to deconstruct the 3-tuple returned by the `QueryCityData` method.

    [!code-csharp[Deconstruction-Explicit](../../samples/snippets/csharp/programming-guide/deconstructing-tuples/deconstruct-tuple2.cs#1)]

- You can use the `var` keyword so that C# infers the type of each variable. You can place the `var` keyword outside of the parentheses. The following example uses type inference when deconstructing the 3-tuple returned by the `QueryCityData` method.
 
      [!code-csharp[Deconstruction-Infer](../../samples/snippets/csharp/programming-guide/deconstructing-tuples/deconstruct-tuple3.cs#1)]

    You can also use the `var` keyword individually with any or all of the variable declarations inside the parentheses. 

      [!code-csharp[Deconstruction-Infer-Some](../../samples/snippets/csharp/programming-guide/deconstructing-tuples/deconstruct-tuple4.cs#1)]

Note that you specify a specific type outside the parentheses even if every field in the tuple has the
same type. This generates compiler error CS8136, "`var (...)` form disallows a specific type for `var`.

Note that you must also assign each element of the tuple to a variable. If you omit any elements, the compiler generates error CS8132, "Cannot deconstruct a tuple of 'x' elements into 'y' variables.

## Discarding tuple elements

Often when deconstructing a tuple, you're interested in the values of only some elements. Starting with C# 7, you can take advantage of C#'s support for *discards*, which ignores values in assignments, the value returned by a method  
### Deconstructing user defined types

Any tuple type can be deconstructed as shown above. It's also easy
to enable deconstruction on any user defined type (classes, structs, or 
even interfaces).

The type author can define one or more `Deconstruct` methods that
assign values to any number of `out` variables representing the
data elements that make up the type. For example, the following
`Person` type defines a `Deconstruct` method that deconstructs
a person object into the fields representing the first name
and last name:

[!code-csharp[TypeWithDeconstructMethod](../../samples/snippets/csharp/tuples/tuples/person.cs#12_TypeWithDeconstructMethod "Type with a deconstruct method")]

The deconstruct method enables assignment from a `Person` to two strings, 
representing the `FirstName` and `LastName` properties:

[!code-csharp[Deconstruct Type](../../samples/snippets/csharp/tuples/tuples/program.cs#12A_DeconstructType "Deconstruct a class type")]

You can enable deconstruction even for types you did not author.
The `Deconstruct` method can be an extension method that unpackages
the accessible data members of an object. The example below shows
a `Student` type, derived from the `Person` type, and an extension
method that deconstructs a `Student` into three variables, representing
the `FirstName`, the `LastName` and the `GPA`:

[!code-csharp[ExtensionDeconstructMethod](../../samples/snippets/csharp/tuples/tuples/person.cs#13_ExtensionDeconstructMethod "Type with a deconstruct extension method")]

A `Student` object now has two accessible `Deconstruct` methods: the extension method
declared for `Student` types, and the member of the `Person` type. Both are in scope,
and that enables a `Student` to be deconstructed into either two variables or three.
If you assign a student to three variables, the first name, last name, and GPA are
all returned. If you assign a student to two variables, only the first name and 
the last name are returned.

[!code-csharp[Deconstruct extension method](../../samples/snippets/csharp/tuples/tuples/program.cs#13A_DeconstructExtension "Deconstruct a class type using an extension method")]

You should be very careful defining multiple `Deconstruct` methods in a 
class or a class hierarchy. Multiple `Deconstruct` methods that have the
same number of `out` parameters can quickly cause ambiguities. Callers may
not be able to easily call the desired `Deconstruct` method.

In this example, there is minimal chance for an ambiguous call because the 
`Deconstruct` method for `Person` has two output parameters, and the `Deconstruct`
method for `Student` has three.

## Conclusion 

The new language and library support for named tuples makes it much easier
to work with designs that use data structures that store multiple fields
but do not define behavior, as classes and structs do. It's
easy and concise to use tuples for those types. You get all the benefits of
static type checking, without needing to author types using the more
verbose `class` or `struct` syntax. Even so, they are most useful for utility methods
that are `private`, or `internal`. Create user defined types, either
`class` or `struct` types when your public methods return a value
that has multiple fields.

## See also
[Tuples](tuples.md)   