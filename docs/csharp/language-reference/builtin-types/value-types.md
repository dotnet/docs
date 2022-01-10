---
description: Value types vs reference types, kinds of value types, and the built-in value types in C#
title: "Value types - C# reference"
ms.date: 01/22/2020
f1_keywords: 
  - "cs.valuetypes"
helpviewer_keywords: 
  - "value types [C#]"
  - "types [C#], value types"
  - "C# language, value types"
ms.assetid: 471eb994-2958-49d5-a6be-19b4313f80a3
---
# Value types (C# reference)

*Value types* and [reference types](../keywords/reference-types.md) are the two main categories of C# types. A variable of a value type contains an instance of the type. This differs from a variable of a reference type, which contains a reference to an instance of the type. By default, on [assignment](../operators/assignment-operator.md), passing an argument to a method, and returning a method result, variable values are copied. In the case of value-type variables, the corresponding type instances are copied. The following example demonstrates that behavior:

[!code-csharp[copy of values](snippets/shared/ValueTypes.cs#ValueTypeCopied)]

As the preceding example shows, operations on a value-type variable affect only that instance of the value type, stored in the variable.

If a value type contains a data member of a reference type, only the reference to the instance of the reference type is copied when a value-type instance is copied. Both the copy and original value-type instance have access to the same reference-type instance. The following example demonstrates that behavior:

[!code-csharp[shallow copy](snippets/shared/ValueTypes.cs#ShallowCopy)]

> [!NOTE]
> To make your code less error-prone and more robust, define and use immutable value types. This article uses mutable value types only for demonstration purposes.

## Kinds of value types and type constraints

A value type can be one of the two following kinds:

- a [structure type](struct.md), which encapsulates data and related functionality
- an [enumeration type](enum.md), which is defined by a set of named constants and represents a choice or a combination of choices

A [nullable value type](nullable-value-types.md) `T?` represents all values of its underlying value type `T` and an additional [null](../keywords/null.md) value. You cannot assign `null` to a variable of a value type, unless it's a nullable value type.

You can use the [`struct` constraint](../../programming-guide/generics/constraints-on-type-parameters.md) to specify that a type parameter is a non-nullable value type. Both structure and enumeration types satisfy the `struct` constraint. Beginning with C# 7.3, you can use `System.Enum` in a base class constraint (that is known as the [enum constraint](../../programming-guide/generics/constraints-on-type-parameters.md#enum-constraints)) to specify that a type parameter is an enumeration type.

## Built-in value types

C# provides the following built-in value types, also known as *simple types*:

- [Integral numeric types](integral-numeric-types.md)
- [Floating-point numeric types](floating-point-numeric-types.md)
- [bool](bool.md) that represents a Boolean value
- [char](char.md) that represents a Unicode UTF-16 character

All simple types are structure types and differ from other structure types in that they permit certain additional operations:

- You can use literals to provide a value of a simple type. For example, `'A'` is a literal of the type `char` and `2001` is a literal of the type `int`.

- You can declare constants of the simple types with the [const](../keywords/const.md) keyword. It's not possible to have constants of other structure types.

- Constant expressions, whose operands are all constants of the simple types, are evaluated at compile time.

Beginning with C# 7.0, C# supports [value tuples](value-tuples.md). A value tuple is a value type, but not a simple type.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [Value types](~/_csharpstandard/standard/types.md#93-value-types)
- [Simple types](~/_csharpstandard/standard/types.md#935-simple-types)
- [Variables](~/_csharpstandard/standard/variables.md)

## See also

- [C# reference](../index.md)
- <xref:System.ValueType?displayProperty=nameWithType>
- [Reference types](../keywords/reference-types.md)
