---
title: "new operator - Create and initialize a new instance of a type"
description: "The C# new operator is used to create a optionally initialize a new instance of a type."
ms.date: 11/28/2022
f1_keywords:
 - new_CSharpKeyword
helpviewer_keywords:
  - "new operator keyword [C#]"
ms.assetid: a212b697-a79b-4105-9923-1f7b108036e8
---
# new operator - The `new` operator creates a new instance of a type

The `new` operator creates a new instance of a type. You can also use the `new` keyword as a [member declaration modifier](../keywords/new-modifier.md) or a [generic type constraint](../keywords/new-constraint.md).

## Constructor invocation

To create a new instance of a type, you typically invoke one of the [constructors](../../programming-guide/classes-and-structs/constructors.md) of that type using the `new` operator:

[!code-csharp-interactive[invoke constructor](snippets/shared/NewOperator.cs#Constructor)]

You can use an [object or collection initializer](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) with the `new` operator to instantiate and initialize an object in one statement, as the following example shows:

[!code-csharp-interactive[constructor with initializer](snippets/shared/NewOperator.cs#ConstructorWithInitializer)]

### Target-typed `new`

Constructor invocation expressions are target-typed. That is, if a target type of an expression is known, you can omit a type name, as the following example shows:

:::code language="csharp" source="snippets/shared/NewOperator.cs" id="SnippetTargetTyped":::

As the preceding example shows, you always use parentheses in a target-typed `new` expression.

If a target type of a `new` expression is unknown (for example, when you use the [`var`](../statements/declarations.md#implicitly-typed-local-variables) keyword), you must specify a type name.

## Array creation

You also use the `new` operator to create an array instance, as the following example shows:

[!code-csharp-interactive[create array](snippets/shared/NewOperator.cs#Array)]

Use array initialization syntax to create an array instance and populate it with elements in one statement. The following example shows various ways how you can do that:

[!code-csharp-interactive[initialize array](snippets/shared/NewOperator.cs#ArrayInitialization)]

For more information about arrays, see [Arrays](../builtin-types/arrays.md).

## Instantiation of anonymous types

To create an instance of an [anonymous type](../../fundamentals/types/anonymous-types.md), use the `new` operator and object initializer syntax:

[!code-csharp-interactive[anonymous type](snippets/shared/NewOperator.cs#AnonymousType)]

## Destruction of type instances

You don't have to destroy earlier created type instances. Instances of both reference and value types are destroyed automatically. Instances of value types are destroyed as soon as the context that contains them is destroyed. Instances of reference types are destroyed by the [garbage collector](../../../standard/garbage-collection/index.md) at some unspecified time after the last reference to them is removed.

For type instances that contain unmanaged resources, for example, a file handle, it's recommended to employ deterministic clean-up to ensure that the resources they contain are released as soon as possible. For more information, see the <xref:System.IDisposable?displayProperty=nameWithType> API reference and the [`using` statement](../statements/using.md) article.

## Operator overloadability

A user-defined type can't overload the `new` operator.

## C# language specification

For more information, see [The new operator](~/_csharpstandard/standard/expressions.md#12817-the-new-operator) section of the [C# language specification](~/_csharpstandard/standard/README.md).

For more information about a target-typed `new` expression, see the [feature proposal note](~/_csharplang/proposals/csharp-9.0/target-typed-new.md).

## See also

- [C# operators and expressions](index.md)
- [Object and collection initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md)
