---
title: "Structure types - C# reference"
description: Learn about the struct type in C#
ms.date: 12/16/2021
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

[!code-csharp[struct example](snippets/shared/StructType.cs#StructExample)]

Structure types have *value semantics*. That is, a variable of a structure type contains an instance of the type. By default, variable values are copied on assignment, passing an argument to a method, and returning a method result. In the case of a structure-type variable, an instance of the type is copied. For more information, see [Value types](value-types.md).

Typically, you use structure types to design small data-centric types that provide little or no behavior. For example, .NET uses structure types to represent a number (both [integer](integral-numeric-types.md) and [real](floating-point-numeric-types.md)), a [Boolean value](bool.md), a [Unicode character](char.md), a [time instance](xref:System.DateTime). If you're focused on the behavior of a type, consider defining a [class](../keywords/class.md). Class types have *reference semantics*. That is, a variable of a class type contains a reference to an instance of the type, not the instance itself.

Because structure types have value semantics, we recommend you to define *immutable* structure types.

## `readonly` struct

Beginning with C# 7.2, you use the `readonly` modifier to declare that a structure type is immutable. All data members of a `readonly` struct must be read-only as follows:

- Any field declaration must have the [`readonly` modifier](../keywords/readonly.md)
- Any property, including auto-implemented ones, must be read-only. In C# 9.0 and later, a property may have an [`init` accessor](../keywords/init.md).

That guarantees that no member of a `readonly` struct modifies the state of the struct. In C# 8.0 and later, that means that other instance members except constructors are implicitly [`readonly`](#readonly-instance-members).

> [!NOTE]
> In a `readonly` struct, a data member of a mutable reference type still can mutate its own state. For example, you can't replace a <xref:System.Collections.Generic.List%601> instance, but you can add new elements to it.

The following code defines a `readonly` struct with init-only property setters, available in C# 9.0 and later:

[!code-csharp[readonly struct](snippets/shared/StructType.cs#ReadonlyStruct)]

## `readonly` instance members

Beginning with C# 8.0, you can also use the `readonly` modifier to declare that an instance member doesn't modify the state of a struct. If you can't declare the whole structure type as `readonly`, use the `readonly` modifier to mark the instance members that don't modify the state of the struct.

Within a `readonly` instance member, you can't assign to structure's instance fields. However, a `readonly` member can call a non-`readonly` member. In that case the compiler creates a copy of the structure instance and calls the non-`readonly` member on that copy. As a result, the original structure instance is not modified.

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

You can't apply the `readonly` modifier to static members of a structure type.

The compiler may make use of the `readonly` modifier for performance optimizations. For more information, see [Write safe and efficient C# code](../../write-safe-efficient-code.md).

## Nondestructive mutation

Beginning with C# 10, you can use the [`with` expression](../operators/with-expression.md) to produce a copy of a structure-type instance with the specified properties and fields modified. You use [object initializer](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) syntax to specify what members to modify and their new values, as the following example shows:

:::code language="csharp" source="snippets/shared/StructType.cs" id="WithExpression":::

## Limitations with the design of a structure type

When you design a structure type, you have the same capabilities as with a [class](../keywords/class.md) type, with the following exceptions:

- You can't declare a parameterless constructor. Every structure type already provides an implicit parameterless constructor that produces the [default value](default-values.md) of the type.

  > [!NOTE]
  > Beginning with C# 10, you can declare a parameterless constructor in a structure type. For more information, see the [Parameterless constructors and field initializers](#parameterless-constructors-and-field-initializers) section.

- You can't initialize an instance field or property at its declaration. However, you can initialize a [static](../keywords/static.md) or [const](../keywords/const.md) field or a static property at its declaration.

  > [!NOTE]
  > Beginning with C# 10, you can initialize an instance field or property at its declaration. For more information, see the [Parameterless constructors and field initializers](#parameterless-constructors-and-field-initializers) section.

- A constructor of a structure type must initialize all instance fields of the type.

- A structure type can't inherit from other class or structure type and it can't be the base of a class. However, a structure type can implement [interfaces](../keywords/interface.md).

- You can't declare a [finalizer](../../programming-guide/classes-and-structs/finalizers.md) within a structure type.

## Parameterless constructors and field initializers

Beginning with C# 10, you can declare a parameterless instance constructor in a structure type, as the following example shows:

:::code language="csharp" source="snippets/shared/StructType.cs" id="ParameterlessConstructor":::

As the preceding example shows, the [default value expression](../operators/default.md) ignores a parameterless constructor and produces the default value of a structure type, which is the value produced by setting all value-type fields to their [default values](default-values.md) (the 0-bit pattern) and all reference-type fields to `null`. Structure-type array instantiation also ignores a parameterless constructor and produces an array populated with the default values of a structure type.

Beginning with C# 10, you can also initialize an instance field or property at its declaration, as the following example shows:

:::code language="csharp" source="snippets/shared/StructType.cs" id="FieldInitializer":::

If you don't declare a parameterless constructor explicitly, a structure type provides a parameterless constructor whose behavior is as follows:

- If a structure type has explicit instance constructors or has no field initializers, an implicit parameterless constructor produces the default value of a structure type, regardless of field initializers, as the preceding example shows.
- If a structure type has no explicit instance constructors and has field initializers, the compiler synthesizes a public parameterless constructor that performs the specified field initializations, as the following example shows:

  :::code language="csharp" source="snippets/shared/StructType.cs" id="FieldInitializerNoConstructor":::

As the preceding example shows, the default value expression and array instantiation ignore field initializers.

> [!IMPORTANT]
> When a `struct` includes field initializers, but doesn't include any explicit instance constructors, the synthesized public parameterless constructor performs the specified field initializers. If that `struct` includes an explicit instance constructor, the synthesized parameterless constructor produces the same value as the `default` expression.

For more information, see the [Parameterless struct constructors](~/_csharplang/proposals/csharp-10.0/parameterless-struct-constructors.md) feature proposal note.

## Instantiation of a structure type

In C#, you must initialize a declared variable before it can be used. Because a structure-type variable can't be `null` (unless it's a variable of a [nullable value type](nullable-value-types.md)), you must instantiate an instance of the corresponding type. There are several ways to do that.

Typically, you instantiate a structure type by calling an appropriate constructor with the [`new`](../operators/new-operator.md) operator. Every structure type has at least one constructor. That's an implicit parameterless constructor, which produces the [default value](default-values.md) of the type. You can also use a [default value expression](../operators/default.md) to produce the default value of a type.

If all instance fields of a structure type are accessible, you can also instantiate it without the `new` operator. In that case you must initialize all instance fields before the first use of the instance. The following example shows how to do that:

[!code-csharp[without new](snippets/shared/StructType.cs#WithoutNew)]

In the case of the [built-in value types](value-types.md#built-in-value-types), use the corresponding literals to specify a value of the type.

## Passing structure-type variables by reference

When you pass a structure-type variable to a method as an argument or return a structure-type value from a method, the whole instance of a structure type is copied. That can affect the performance of your code in high-performance scenarios that involve large structure types. You can avoid value copying by passing a structure-type variable by reference. Use the [`ref`](../keywords/ref.md#passing-an-argument-by-reference), [`out`](../keywords/out-parameter-modifier.md), or [`in`](../keywords/in-parameter-modifier.md) method parameter modifiers to indicate that an argument must be passed by reference. Use [ref returns](../../programming-guide/classes-and-structs/ref-returns.md) to return a method result by reference. For more information, see [Write safe and efficient C# code](../../write-safe-efficient-code.md).

## `ref` struct

Beginning with C# 7.2, you can use the `ref` modifier in the declaration of a structure type. Instances of a `ref` struct type are allocated on the stack and can't escape to the managed heap. To ensure that, the compiler limits the usage of `ref` struct types as follows:

- A `ref` struct can't be the element type of an array.
- A `ref` struct can't be a declared type of a field of a class or a non-`ref` struct.
- A `ref` struct can't implement interfaces.
- A `ref` struct can't be boxed to <xref:System.ValueType?displayProperty=nameWithType> or <xref:System.Object?displayProperty=nameWithType>.
- A `ref` struct can't be a type argument.
- A `ref` struct variable can't be captured by a [lambda expression](../operators/lambda-expressions.md) or a [local function](../../programming-guide/classes-and-structs/local-functions.md).
- A `ref` struct variable can't be used in an [`async`](../keywords/async.md) method. However, you can use `ref` struct variables in synchronous methods, for example, in those that return <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601>.
- A `ref` struct variable can't be used in [iterators](../../iterators.md).

Beginning with C# 8.0, you can define a disposable `ref` struct. To do that, ensure that a `ref` struct fits the [disposable pattern](~/_csharplang/proposals/csharp-8.0/using.md#pattern-based-using). That is, it has an instance or extension `Dispose` method, which is accessible, parameterless and has a `void` return type.

Typically, you define a `ref` struct type when you need a type that also includes data members of `ref` struct types:

[!code-csharp[ref struct](snippets/shared/StructType.cs#RefStruct)]

To declare a `ref` struct as [`readonly`](#readonly-struct), combine the `readonly` and `ref` modifiers in the type declaration (the `readonly` modifier must come before the `ref` modifier):

[!code-csharp[readonly ref struct](snippets/shared/StructType.cs#ReadonlyRef)]

In .NET, examples of a `ref` struct are <xref:System.Span%601?displayProperty=nameWithType> and <xref:System.ReadOnlySpan%601?displayProperty=nameWithType>.

## struct constraint

You also use the `struct` keyword in the [`struct` constraint](../../programming-guide/generics/constraints-on-type-parameters.md) to specify that a type parameter is a non-nullable value type. Both structure and [enumeration](enum.md) types satisfy the `struct` constraint.

## Conversions

For any structure type (except [`ref` struct](#ref-struct) types), there exist [boxing and unboxing](../../programming-guide/types/boxing-and-unboxing.md) conversions to and from the <xref:System.ValueType?displayProperty=nameWithType> and <xref:System.Object?displayProperty=nameWithType> types. There exist also boxing and unboxing conversions between a structure type and any interface that it implements.

## C# language specification

For more information, see the [Structs](~/_csharplang/spec/structs.md) section of the [C# language specification](~/_csharplang/spec/introduction.md).

For more information about features introduced in C# 7.2 and later, see the following feature proposal notes:

- [Readonly structs](~/_csharplang/proposals/csharp-7.2/readonly-ref.md#readonly-structs)
- [Readonly instance members](~/_csharplang/proposals/csharp-8.0/readonly-instance-members.md)
- [Compile-time safety for ref-like types](~/_csharplang/proposals/csharp-7.2/span-safety.md)
- [Parameterless struct constructors](~/_csharplang/proposals/csharp-10.0/parameterless-struct-constructors.md)
- [Allow `with` expression on structs](~/_csharplang/proposals/csharp-10.0/record-structs.md#allow-with-expression-on-structs)

## See also

- [C# reference](../index.md)
- [Design guidelines - Choosing between class and struct](../../../standard/design-guidelines/choosing-between-class-and-struct.md)
- [Design guidelines - Struct design](../../../standard/design-guidelines/struct.md)
- [The C# type system](../../fundamentals/types/index.md)
