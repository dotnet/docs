---
description: Value types vs reference types, kinds of value types, and the built-in value types in C#
title: "Value types"
ms.date: 03/20/2026
f1_keywords: 
  - "cs.valuetypes"
helpviewer_keywords: 
  - "value types [C#]"
  - "types [C#], value types"
  - "C# language, value types"
---
# Value types (C# reference)

*Value types* and [reference types](../keywords/reference-types.md) are the two main categories of C# types. A variable of a value type contains an instance of the type. This behavior differs from a variable of a reference type, which contains a reference to an instance of the type. By default, on [assignment](../operators/assignment-operator.md), passing an argument to a method, and returning a method result, you copy variable values. In the case of value-type variables, you copy the corresponding type instances. The following example demonstrates that behavior:

:::code language="csharp" source="snippets/shared/ValueTypes.cs" id="ValueTypeCopied":::

As the preceding example shows, operations on a value-type variable affect only that instance of the value type, stored in the variable.

If a value type contains a data member of a reference type, you copy only the reference to the instance of the reference type when you copy a value-type instance. Both the copy and original value-type instance have access to the same reference-type instance. The following example demonstrates that behavior:

:::code language="csharp" source="snippets/shared/ValueTypes.cs" id="ShallowCopy":::

> [!NOTE]
> To make your code less error-prone and more robust, define and use immutable value types. This article uses mutable value types only for demonstration purposes.

## Kinds of value types and type constraints

A value type can be one of the following kinds:

- A [structure type](struct.md), which encapsulates data and related functionality.
- An [enumeration type](enum.md), which is defined by a set of named constants and represents a choice or a combination of choices.
- A [union declaration](union.md), which defines a closed set of case types that a value can represent.

A [nullable value type](nullable-value-types.md) `T?` represents all values of its underlying value type `T` and an additional [null](../keywords/null.md) value. You can't assign `null` to a variable of a value type, unless it's a nullable value type.

Use the [`struct` constraint](../../programming-guide/generics/constraints-on-type-parameters.md) to specify that a type parameter is a non-nullable value type. Both structure and enumeration types satisfy the `struct` constraint. Use `System.Enum` in a base class constraint (that is known as the [enum constraint](../../programming-guide/generics/constraints-on-type-parameters.md#enum-constraints)) to specify that a type parameter is an enumeration type.

## Built-in value types

C# provides the following built-in value types, also known as *simple types*:

- [Integral numeric types](integral-numeric-types.md)
- [Floating-point numeric types](floating-point-numeric-types.md)
- [bool](bool.md) that represents a Boolean value
- [char](char.md) that represents a Unicode UTF-16 character

All simple types are struct types. They differ from other struct types in that they permit certain additional operations:

- You can use literals to provide a value of a simple type.
<br/>For example, `'A'` is a literal of the type `char`, `2001` is a literal of the type `int`, and `12.34m` is a literal of the type `decimal`.

- You can declare constants of the simple types by using the [const](../keywords/const.md) keyword.
<br/>For example, you can define `const decimal = 12.34m`.
<br/>You can't declare constants of other struct types.

- Constant expressions, whose operands are all constants of the simple types, are evaluated at compile time.

A [value tuple](value-tuples.md) is a value type, but not a simple type.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [Value types](~/_csharpstandard/standard/types.md#83-value-types)
- [Simple types](~/_csharpstandard/standard/types.md#835-simple-types)
- [Variables](~/_csharpstandard/standard/variables.md)

## See also

- <xref:System.ValueType?displayProperty=nameWithType>
- [Reference types](../keywords/reference-types.md)
