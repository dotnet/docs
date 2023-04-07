---
title: "Structure types - C# reference"
description: Learn about the struct type in C#
ms.date: 04/05/2023
f1_keywords: 
  - "struct_CSharpKeyword"
helpviewer_keywords: 
  - "struct keyword [C#]"
  - "struct type [C#]"
  - "structure type [C#]"
---
# Structure types (C# reference)

A *structure type* (or *struct type*) is a [value type](value-types.md) that can encapsulate data and related functionality. You use the `struct` keyword to define a structure type:

[!code-csharp[struct example](snippets/shared/StructType.cs#StructExample)]

For information about `ref struct` and `readonly ref struct` types, see the [ref structure types](ref-struct.md) article.

Structure types have *value semantics*. That is, a variable of a structure type contains an instance of the type. By default, variable values are copied on assignment, passing an argument to a method, and returning a method result. For structure-type variables, an instance of the type is copied. For more information, see [Value types](value-types.md).

Typically, you use structure types to design small data-centric types that provide little or no behavior. For example, .NET uses structure types to represent a number (both [integer](integral-numeric-types.md) and [real](floating-point-numeric-types.md)), a [Boolean value](bool.md), a [Unicode character](char.md), a [time instance](xref:System.DateTime). If you're focused on the behavior of a type, consider defining a [class](../keywords/class.md). Class types have *reference semantics*. That is, a variable of a class type contains a reference to an instance of the type, not the instance itself.

Because structure types have value semantics, we recommend you define *immutable* structure types.

## `readonly` struct

You use the `readonly` modifier to declare that a structure type is immutable. All data members of a `readonly` struct must be read-only as follows:

- Any field declaration must have the [`readonly` modifier](../keywords/readonly.md)
- Any property, including auto-implemented ones, must be read-only. In C# 9.0 and later, a property may have an [`init` accessor](../keywords/init.md).

That guarantees that no member of a `readonly` struct modifies the state of the struct. That means that other instance members except constructors are implicitly [`readonly`](#readonly-instance-members).

> [!NOTE]
> In a `readonly` struct, a data member of a mutable reference type still can mutate its own state. For example, you can't replace a <xref:System.Collections.Generic.List%601> instance, but you can add new elements to it.

The following code defines a `readonly` struct with init-only property setters, available in C# 9.0 and later:

[!code-csharp[readonly struct](snippets/shared/StructType.cs#ReadonlyStruct)]

## `readonly` instance members

You can also use the `readonly` modifier to declare that an instance member doesn't modify the state of a struct. If you can't declare the whole structure type as `readonly`, use the `readonly` modifier to mark the instance members that don't modify the state of the struct.

Within a `readonly` instance member, you can't assign to structure's instance fields. However, a `readonly` member can call a non-`readonly` member. In that case the compiler creates a copy of the structure instance and calls the non-`readonly` member on that copy. As a result, the original structure instance isn't modified.

Typically, you apply the `readonly` modifier to the following kinds of instance members:

- methods:

  [!code-csharp[readonly method](snippets/shared/StructType.cs#ReadonlyMethod)]

  You can also apply the `readonly` modifier to methods that override methods declared in <xref:System.Object?displayProperty=nameWithType>:

  [!code-csharp[readonly override](snippets/shared/StructType.cs#ReadonlyOverride)]

- properties and indexers:

  [!code-csharp[readonly property get](snippets/shared/StructType.cs#ReadonlyProperty)]

  If you need to apply the `readonly` modifier to both accessors of a property or indexer, apply it in the declaration of the property or indexer.

  > [!NOTE]
  > The compiler declares a `get` accessor of an [auto-implemented property](../../programming-guide/classes-and-structs/auto-implemented-properties.md) as `readonly`, regardless of presence of the `readonly` modifier in a property declaration.

  In C# 9.0 and later, you may apply the `readonly` modifier to a property or indexer with an `init` accessor:

  :::code language="csharp" source="snippets/shared/StructType.cs" id="ReadonlyWithInit":::

You can apply the `readonly` modifier to static fields of a structure type, but not any other static members, such as properties or methods.

The compiler may make use of the `readonly` modifier for performance optimizations. For more information, see [Avoiding allocations](../../advanced-topics/performance/index.md).

## Nondestructive mutation

Beginning with C# 10, you can use the [`with` expression](../operators/with-expression.md) to produce a copy of a structure-type instance with the specified properties and fields modified. You use [object initializer](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) syntax to specify what members to modify and their new values, as the following example shows:

:::code language="csharp" source="snippets/shared/StructType.cs" id="WithExpression":::

## `record` struct

Beginning with C# 10, you can define record structure types. Record types provide built-in functionality for encapsulating data. You can define both `record struct` and `readonly record struct` types. A record struct can't be a [`ref struct`](ref-struct.md). For more information and examples, see [Records](record.md).

## Struct initialization and default values

A variable of a `struct` type directly contains the data for that `struct`. That creates a distinction between an uninitialized `struct`, which has its default value and an initialized `struct`, which stores values set by constructing it. For example consider the following code:

:::code language="csharp" source="snippets/shared/StructType.cs" id="ParameterlessConstructor":::

As the preceding example shows, the [default value expression](../operators/default.md) ignores a parameterless constructor and produces the [default value](default-values.md) of the structure type. Structure-type array instantiation also ignores a parameterless constructor and produces an array populated with the default values of a structure type.

The most common situation where you'll see default values is in arrays or in other collections where internal storage includes blocks of variables. The following example creates an array of 30 `TemperatureRange` structures, each of which has the default value:

```csharp
// All elements have default values of 0:
TemperatureRange[] lastMonth = new TemperatureRange[30];
```

All of a struct's member fields must be *definitely assigned* when it's created because `struct` types directly store their data. The `default` value of a struct has *definitely assigned* all fields to 0. All fields must be definitely assigned when a constructor is invoked. You initialize fields using the following mechanisms:

- You can add *field initializers* to any field or auto implemented property.
- You can initialize any fields, or auto properties, in the body of the constructor.

Beginning with C# 11, if you don't initialize all fields in a struct, the compiler adds code to the constructor that initializes those fields to the default value. The compiler performs its usual definite assignment analysis. Any fields that are accessed before being assigned, or not definitely assigned when the constructor finishes executing are assigned their default values before the constructor body executes. If `this` is accessed before all fields are assigned, the struct is initialized to the default value before the constructor body executes.

:::code language="csharp" source="snippets/shared/StructType.cs" id="FieldInitializer":::

Every `struct` has a `public` parameterless constructor. If you write a parameterless constructor, it must be public. If a struct declares any field initializers, it must explicitly declare a constructor. That constructor need not be parameterless. If a struct declares a field initializer but no constructors, the compiler reports an error. Any explicitly declared constructor (with parameters, or parameterless) executes all field initializers for that struct. All fields without a field initializer or an assignment in a constructor are set to the [default value](default-values.md). For more information, see the [Parameterless struct constructors](~/_csharplang/proposals/csharp-10.0/parameterless-struct-constructors.md) feature proposal note.

Beginning with C# 12, `struct` types can define a [primary constructor](../../programming-guide/classes-and-structs/constructors.md#primary-constructors) as part of its declaration. This provides a concise syntax for constructor parameters that can be used throughout the `struct` body, in any member declaration for that struct.

If all instance fields of a structure type are accessible, you can also instantiate it without the `new` operator. In that case you must initialize all instance fields before the first use of the instance. The following example shows how to do that:

:::code language="csharp" source="snippets/shared/StructType.cs" id="SnippetWithoutNew":::

In the case of the [built-in value types](value-types.md#built-in-value-types), use the corresponding literals to specify a value of the type.

## Limitations with the design of a structure type

Structs have most of the capabilities of a [class](../keywords/class.md) type. There are some exceptions, and some exceptions that have been removed in more recent versions:

- A structure type can't inherit from other class or structure type and it can't be the base of a class. However, a structure type can implement [interfaces](../keywords/interface.md).
- You can't declare a [finalizer](../../programming-guide/classes-and-structs/finalizers.md) within a structure type.
- Prior to C# 11, a constructor of a structure type must initialize all instance fields of the type.
- Prior to C# 10, you can't declare a parameterless constructor.
- Prior to C# 10, you can't initialize an instance field or property at its declaration.

## Passing structure-type variables by reference

When you pass a structure-type variable to a method as an argument or return a structure-type value from a method, the whole instance of a structure type is copied. Pass by value can affect the performance of your code in high-performance scenarios that involve large structure types. You can avoid value copying by passing a structure-type variable by reference. Use the [`ref`](../keywords/ref.md#passing-an-argument-by-reference), [`out`](../keywords/out-parameter-modifier.md), or [`in`](../keywords/in-parameter-modifier.md) method parameter modifiers to indicate that an argument must be passed by reference. Use [ref returns](../statements/jump-statements.md#the-return-statement) to return a method result by reference. For more information, see [Avoid allocations](../../advanced-topics/performance/index.md).

## struct constraint

You also use the `struct` keyword in the [`struct` constraint](../../programming-guide/generics/constraints-on-type-parameters.md) to specify that a type parameter is a non-nullable value type. Both structure and [enumeration](enum.md) types satisfy the `struct` constraint.

## Conversions

For any structure type (except [`ref struct`](ref-struct.md) types), there exist [boxing and unboxing](../../programming-guide/types/boxing-and-unboxing.md) conversions to and from the <xref:System.ValueType?displayProperty=nameWithType> and <xref:System.Object?displayProperty=nameWithType> types. There exist also boxing and unboxing conversions between a structure type and any interface that it implements.

## C# language specification

For more information, see the [Structs](~/_csharpstandard/standard/structs.md) section of the [C# language specification](~/_csharpstandard/standard/README.md).

For more information about `struct` features, see the following feature proposal notes:

- [C# 7.2 - Readonly structs](~/_csharplang/proposals/csharp-7.2/readonly-ref.md#readonly-structs)
- [C# 8 - Readonly instance members](~/_csharplang/proposals/csharp-8.0/readonly-instance-members.md)
- [C# 10 - Parameterless struct constructors](~/_csharplang/proposals/csharp-10.0/parameterless-struct-constructors.md)
- [C# 10 - Allow `with` expression on structs](~/_csharplang/proposals/csharp-10.0/record-structs.md#allow-with-expression-on-structs)
- [C# 10 - Record structs](~/_csharplang/proposals/csharp-10.0/record-structs.md)
- [C# 11 - Auto default structs](~/_csharplang/proposals/csharp-11.0/auto-default-structs.md)

## See also

- [C# reference](../index.md)
- [The C# type system](../../fundamentals/types/index.md)
- [Design guidelines - Choosing between class and struct](../../../standard/design-guidelines/choosing-between-class-and-struct.md)
- [Design guidelines - Struct design](../../../standard/design-guidelines/struct.md)
