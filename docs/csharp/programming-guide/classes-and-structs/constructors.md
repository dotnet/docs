---
title: "Constructors"
description: A constructor in C# is called when a class or struct is created. Use constructors to set defaults, limit instantiation, and write flexible, easy-to-read code.
ms.date: 03/11/2025
helpviewer_keywords: 
  - "constructors [C#]"
  - "classes [C#], constructors"
  - "C# language, constructors"
ms.topic: article
---
# Constructors (C# programming guide)

A *constructor* is a method called by the runtime when an instance of a [class](../../language-reference/keywords/class.md) or a [struct](../../language-reference/builtin-types/struct.md) is created. A class or struct can have multiple constructors that take different arguments. Constructors enable you to ensure that instances of the type are valid when created. For more information and examples, see [Instance constructors](instance-constructors.md) and [Using constructors](using-constructors.md).

There are several actions that are part of initializing a new instance. The following actions take place in the following order:

1. *Instance fields are set to 0*. This initialization is typically done by the runtime.
1. *Field initializers run*. The field initializers in the most derived type run.
1. *Base type field initializers run*. Field initializers starting with the direct base through each base type to <xref:System.Object?displayProperty=fullName>.
1. *Base instance constructors run*. Any instance constructors, starting with <xref:System.Object.%23ctor%2A?displayProperty=nameWithType> through each base class to the direct base class.
1. *The instance constructor runs*. The instance constructor for the type runs.
1. *Object initializers run*. If the expression includes any object initializers, they run after the instance constructor runs. Object initializers run in the textual order.

The preceding actions take place when an instance is created using the [`new` operator](../../language-reference//operators/new-operator.md). If a new instance of a `struct` is set to its `default` value, all instance fields are set to 0. Elements of an array are set to their default value of 0 or `null` when an array is created.

The [static constructor](static-constructors.md), if any, runs before any of the instance constructor actions take place for any instance of the type. The static constructor runs at most once.

Beginning with C# 14, you can declare instance constructors as [partial members](./partial-classes-and-methods.md). [Partial constructors](#partial-constructors) must have both a declaring and implementing declaration.

## Constructor syntax

A constructor is a method with the same name as its type. Its method signature can include an optional [access modifier](./access-modifiers.md), the method name, and its parameter list; it doesn't include a return type. The following example shows the constructor for a class named `Person`.

:::code source="./snippets/constructors/Program.cs" id="InstanceCtor":::

If a constructor can be implemented as a single statement, you can use an [expression body member](../statements-expressions-operators/expression-bodied-members.md). The following example defines a `Location` class whose constructor has a single string parameter, `name`. The expression body definition assigns the argument to the `locationName` field.

:::code source="./snippets/constructors/Program.cs" id="ExpressionBodiedCtor":::

If a type requires a parameter to create an instance, you can use a *primary constructor* to indicate that one or more parameters are required to instantiate the type, as shown in the following example:

:::code source="./snippets/constructors/Program.cs" id="PrimaryCtor":::

You can declare a primary constructor on a `partial` type. Only one primary constructor declaration is allowed. In other words, only one declaration of the `partial` type can include the parameters for the primary constructor.

## Static constructors

The previous examples show instance constructors, which initialize a new object. A class or struct can also declare a static constructor, which initializes static members of the type. Static constructors are parameterless. If you don't provide a static constructor to initialize static fields, the C# compiler initializes static fields to their default value as listed in the [Default values of C# types](../../language-reference/builtin-types/default-values.md) article.

The following example uses a static constructor to initialize a static field.

:::code source="./snippets/constructors/Program.cs" id="StaticCtor":::

You can also define a static constructor with an expression body definition, as the following example shows.

:::code source="./snippets/constructors/Program.cs" id="StaticExpression":::

For more information and examples, see [Static Constructors](./static-constructors.md).

## Partial constructors

Beginning with C# 14, you can declare *partial constructors* in a partial class or struct. Any partial constructor must have a *defining declaration* and an *implementing declaration*. The signatures of the declaring and implementing partial constructors must match according to the rules of [partial members](./partial-classes-and-methods.md#partial-members). The defining declaration of the partial constructor can't use the `: base()` or `: this()` constructor initializer. You add any constructor initializer must be added on the implementing declaration.

## See also

- [The C# type system](../../fundamentals/types/index.md)
- [`static`](../../language-reference/keywords/static.md)
- [Why Do Initializers Run In The Opposite Order As Constructors? Part One](/archive/blogs/ericlippert/why-do-initializers-run-in-the-opposite-order-as-constructors-part-one)
