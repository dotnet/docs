---
title: "Structure types - C# reference"
ms.date: 04/14/2020
f1_keywords: 
  - "struct_CSharpKeyword"
helpviewer_keywords: 
  - "struct keyword [C#]"
  - "struct type [C#]"
  - "structure type [C#]"
ms.assetid: ff3dd9b7-dc93-4720-8855-ef5558f65c7c
---
# Structure types (C# reference)

A *structure type* (or *struct type*) is a [value type](value-types.md) that can encapsulate data and related functionality. You use the `struct` keyword to define a structure type:

[!code-csharp[struct example](snippets/StructType.cs#StructExample)]

Structure types have *value semantics*. That is, a variable of a structure type contains an instance of the type. By default, variable values are copied on assignment, passing an argument to a method, and returning a method result. In the case of a structure-type variable, an instance of the type is copied. For more information, see [Value types](value-types.md).

Typically, you use structure types to design small data-centric types that provide little or no behavior. For example, .NET uses structure types to represent a number (both [integer](integral-numeric-types.md) and [real](floating-point-numeric-types.md)), a [Boolean value](bool.md), a [Unicode character](char.md), a [time instance](xref:System.DateTime). If you're focused on the behavior of a type, consider defining a [class](../keywords/class.md). Class types have *reference semantics*. That is, a variable of a class type contains a reference to an instance of the type, not the instance itself.

Because structure types have value semantics, we recommend you to define *immutable* structure types.

## `readonly` struct

Beginning with C# 7.2, you use the `readonly` modifier to declare that a structure type is immutable:

[!code-csharp[readonly struct](snippets/StructType.cs#ReadonlyStruct)]

All data members of a `readonly` struct must be read-only as follows:

- Any field declaration must have the [`readonly` modifier](../keywords/readonly.md)
- Any property, including auto-implemented ones, must be read-only

That guarantees that no member of a `readonly` struct modifies the state of the struct.

> [!NOTE]
> In a `readonly` struct, a data member of a mutable reference type still can mutate its own state. For example, you cannot replace a <xref:System.Collections.Generic.List%601> instance, but you can add new elements to it.

## `readonly` instance members

Beginning with C# 8.0, you can also use the `readonly` modifier to declare that an instance member doesn't modify the state of a struct. If you cannot declare the whole structure type as `readonly`, use the `readonly` modifier to mark the instance members that don't modify the state of the struct. In a `readonly` struct, every instance member is implicitly `readonly`.

Within a `readonly` instance member, you cannot assign to structure's instance fields. However, a `readonly` member can call a non-`readonly` member. In that case the compiler creates a copy of the structure instance and calls the non-`readonly` member on that copy. As a result, the original structure instance is not modified.

Typically, you apply the `readonly` modifier to the following kinds of instance members:

- methods:

  [!code-csharp[readonly method](snippets/StructType.cs#ReadonlyMethod)]

  You can also apply the `readonly` modifier to methods that override methods declared in <xref:System.Object?displayProperty=nameWithType>:

  [!code-csharp[readonly override](snippets/StructType.cs#ReadonlyOverride)]

- properties and indexers:

  [!code-csharp[readonly property get](snippets/StructType.cs#ReadonlyProperty)]

  If you need to apply the `readonly` modifier to both accessors of a property or indexer, apply it in the declaration of the property or indexer.

  > [!NOTE]
  > The compiler declares a `get` accessor of an [auto-implemented property](../../programming-guide/classes-and-structs/auto-implemented-properties.md) as `readonly`, regardless of presence of the `readonly` modifier in a property declaration.

You cannot apply the `readonly` modifier to static members of a structure type.

The compiler may make use of the `readonly` modifier for performance optimizations. For more information, see [Write safe and efficient C# code](../../write-safe-efficient-code.md).

## Limitations with the design of a structure type

When you design a structure type, you have the same capabilities as with a [class](../keywords/class.md) type, with the following exceptions:

- You cannot declare a parameterless constructor. Every structure type already provides an implicit parameterless constructor that produces the [default value](default-values.md) of the type.

- You cannot initialize an instance field or property at its declaration. However, you can initialize a [static](../keywords/static.md) or [const](../keywords/const.md) field or a static property at its declaration.

- A constructor of a structure type must initialize all instance fields of the type.

- A structure type cannot inherit from other class or structure type and it cannot be the base of a class. However, a structure type can implement [interfaces](../keywords/interface.md).

- You cannot declare a [finalizer](../../programming-guide/classes-and-structs/destructors.md) within a structure type.

## Instantiation of a structure type

In C#, you must initialize a declared variable before it can be used. Because a structure-type variable cannot be `null` (unless it's a variable of a [nullable value type](nullable-value-types.md)), you must instantiate an instance of the corresponding type. There are several ways to do that.

Typically, you instantiate a structure type by calling an appropriate constructor with the [`new`](../operators/new-operator.md) operator. Every structure type has at least one constructor. That's an implicit parameterless constructor, which produces the [default value](default-values.md) of the type. You can also use a [default value expression](../operators/default.md) to produce the default value of a type.

If all instance fields of a structure type are accessible, you can also instantiate it without the `new` operator. In that case you must initialize all instance fields before the first use of the instance. The following example shows how to do that:

[!code-csharp[without new](snippets/StructType.cs#WithoutNew)]

In the case of the [built-in value types](value-types.md#built-in-value-types), use the corresponding literals to specify a value of the type.

## Passing structure-type variables by reference

When you pass a structure-type variable to a method as an argument or return a structure-type value from a method, the whole instance of a structure type is copied. That can affect the performance of your code in high-performance scenarios that involve large structure types. You can avoid value copying by passing a structure-type variable by reference. Use the [`ref`](../keywords/ref.md#passing-an-argument-by-reference), [`out`](../keywords/out-parameter-modifier.md), or [`in`](../keywords/in-parameter-modifier.md) method parameter modifiers to indicate that an argument must be passed by reference. Use [ref returns](../../programming-guide/classes-and-structs/ref-returns.md) to return a method result by reference. For more information, see [Write safe and efficient C# code](../../write-safe-efficient-code.md).

## Conversions

For any structure type, there exist [boxing and unboxing](../../programming-guide/types/boxing-and-unboxing.md) conversions to and from the <xref:System.ValueType?displayProperty=nameWithType> and <xref:System.Object?displayProperty=nameWithType> types. There exist also boxing and unboxing conversions between a structure type and any interface that it implements.

## C# language specification

For more information, see the [Structs](~/_csharplang/spec/structs.md) section of the [C# language specification](~/_csharplang/spec/introduction.md).

For more information about features introduced in C# 7.2 and later, see the following feature proposal notes:

- [Readonly structs](~/_csharplang/proposals/csharp-7.2/readonly-ref.md#readonly-structs)
- [Readonly instance members](~/_csharplang/proposals/csharp-8.0/readonly-instance-members.md)

## See also

- [C# reference](../index.md)
- [Design guidelines - Choosing between class and struct](../../../standard/design-guidelines/choosing-between-class-and-struct.md)
- [Design guidelines - Struct design](../../../standard/design-guidelines/struct.md)
- [Classes and structs](../../programming-guide/classes-and-structs/index.md)
