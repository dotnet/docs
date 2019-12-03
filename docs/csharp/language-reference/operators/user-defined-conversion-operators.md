---
title: "User-defined conversion operators - C# reference"
description: "Learn how to define custom implicit and explicit type conversions in C#."
ms.date: 07/09/2019
f1_keywords: 
  - "explicit_CSharpKeyword"
  - "implicit_CSharpKeyword"
helpviewer_keywords: 
  - "explicit keyword [C#]"
  - "implicit keyword [C#]"
  - "conversion operator [C#]"
  - "user-defined conversion [C#]"
---
# User-defined conversion operators (C# reference)

A user-defined type can define a custom implicit or explicit conversion from or to another type.

Implicit conversions don't require special syntax to be invoked and can occur in a variety of situations, for example, in assignments and methods invocations. Predefined C# implicit conversions always succeed and never throw an exception. User-defined implicit conversions should behave in that way as well. If a custom conversion can throw an exception or lose information, define it as an explicit conversion.

User-defined conversions are not considered by the [is](type-testing-and-cast.md#is-operator) and [as](type-testing-and-cast.md#as-operator) operators. Use the [cast operator ()](type-testing-and-cast.md#cast-operator-) to invoke a user-defined explicit conversion.

Use the `operator` and `implicit` or `explicit` keywords to define an implicit or explicit conversion, respectively. The type that defines a conversion must be either a source type or a target type of that conversion. A conversion between two user-defined types can be defined in either of the two types.

The following example demonstrates how to define an implicit and explicit conversion:

[!code-csharp[implicit an explicit conversions](~/samples/csharp/language-reference/operators/UserDefinedConversions.cs)]

You also use the `operator` keyword to overload a predefined C# operator. For more information, see [Operator overloading](operator-overloading.md).

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharplang/spec/introduction.md):

- [Conversion operators](~/_csharplang/spec/classes.md#conversion-operators)
- [User-defined conversions](~/_csharplang/spec/conversions.md#user-defined-conversions)
- [Implicit conversions](~/_csharplang/spec/conversions.md#implicit-conversions)
- [Explicit conversions](~/_csharplang/spec/conversions.md#explicit-conversions)

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [Operator overloading](operator-overloading.md)
- [Type-testing and cast operators](type-testing-and-cast.md)
- [Casting and type conversion](../../programming-guide/types/casting-and-type-conversions.md)
- [Chained user-defined explicit conversions in C#](https://blogs.msdn.microsoft.com/ericlippert/2007/04/16/chained-user-defined-explicit-conversions-in-c/)
