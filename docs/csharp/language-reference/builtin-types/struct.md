---
title: "Structure types - C# reference"
ms.date: 02/20/2020
f1_keywords: 
  - "struct_CSharpKeyword"
helpviewer_keywords: 
  - "struct keyword [C#]"
  - "structs [C#], struct keyword"
ms.assetid: ff3dd9b7-dc93-4720-8855-ef5558f65c7c
---
# Structure types (C# reference)

A *structure type* (or *struct type*) is a [value type](value-types.md) that encapsulates data and related functionality. As the following example shows, you use the `struct` keyword to define a structure type:

[!code-csharp[struct example](~/samples/csharp/language-reference/builtin-types/StructType.cs#StructExample)]

Because a structure type is a value type, a variable of a structure type contains an instance of the type. That is called value semantics. By default, variables are copied on assignment, passing an argument to a method, or returning a method result. In the case of a structure-type variable, an instance of the type is copied (for the examples, see [Value types](value-types.md)). In high-performance scenarios that involve large structure types, you can avoid value copying and pass around an alias to a value-type variable. For information about how to do that, see [Write safe and efficient C# code](../../write-safe-efficient-code.md).

Typically, you define a structure type when you need to represent a small data structure that has value semantics. For example, .NET uses structure types to represent a number (both [integer](integral-numeric-types.md) and [real](floating-point-numeric-types.md)), a [Boolean value](bool.md), a [Unicode character](char.md), a [time instance](xref:System.DateTime). If you need a type with reference semantics (that is, a variable of the type contains a reference to an instance of that type, not the instance itself), define a [class](../keywords/class.md).

## Limitations with the design of a structure type

When you design a structure type, you have the same capabilities as with a [class](../keywords/class.md) type, with the following exceptions:

- You cannot declare a parameterless constructor. Every structure type already provides an implicit parameterless constructor that returns the [default value](default-values.md) of the type.

- You cannot initialize an instance field at its declaration. However, you can initialize a [static](../keywords/static.md) or [const](../keywords/const.md) field at its declaration.

- A structure type cannot inherit from other class or structure type and it cannot be the base of a class. However, a structure type can implement [interfaces](../keywords/interface.md).

- You cannot declare a [finalizer](../../programming-guide/classes-and-structs/destructors.md) within a structure type.

## Instantiation of a structure type

You use the [`new`](../operators/new-operator.md) operator to instantiate a structure type. In the case of the [built-in value types](value-types.md#built-in-value-types), use the corresponding literals to specify a value of the type.

You can also instantiate a structure type without the `new` operator. However, you must initialize all instance fields before the first use of the instance. The following example shows how to do that:

[!code-csharp[without new](~/samples/csharp/language-reference/builtin-types/StructType.cs#WithoutNew)]

If a structure type contains private fields, you must use the `new` operator to instantiate the type.

## Conversions

For any structure type, there exist [boxing and unboxing](../../programming-guide/types/boxing-and-unboxing.md) conversions to and from the <xref:System.ValueType?displayProperty=nameWithType> and <xref:System.Object?displayProperty=nameWithType> types. There exist also boxing and unboxing conversions between a structure type and any interface that it implements.

## C# language specification

For more information, see the [Structs](~/_csharplang/spec/structs.md) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [Design guidelines - Choosing between class and struct](../../../standard/design-guidelines/choosing-between-class-and-struct.md)
- [Design guidelines - Struct design](../../../standard/design-guidelines/struct.md)
- [Classes and structs](../../programming-guide/classes-and-structs/index.md)
