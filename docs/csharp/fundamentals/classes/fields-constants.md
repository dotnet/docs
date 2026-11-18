---
title: Fields and constants
description: Declare instance and static fields in C#, initialize stored state, and distinguish readonly fields from compile-time constants.
ms.date: 11/16/2026
ms.topic: concept-article
ai-usage: ai-generated
---

# Fields and constants

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from another language?** If you've used [Java fields and `static final` declarations](https://docs.oracle.com/javase/tutorial/java/javaOO/classvars.html), you'll recognize per-object state and named fixed values. In C#, choose `const` for a compile-time constant or `readonly` for a field you assign during initialization.

Use this article after [Class members and instances](index.md) to declare stored state and named fixed values.

## Store state in fields

A *field* is a variable declared directly in a type. Unlike a local variable inside a method, a field stores state that methods can use across calls. See the [class reference](../../language-reference/keywords/class.md) for member declaration syntax.

Use instance fields for each object's state and static fields for state shared by the type. For example, the counter uses one of each:

:::code language="csharp" source="snippets/index/Program.cs" id="CounterDeclaration":::

`count` exists separately in each `VisitCounter` object. The `static` field `total` is shared by all instances of this class. Use [access modifiers](access-modifiers.md) independently of `static` to control which code can use a field.

Prefer private fields for state that your class manages. Expose operations through methods or values through [properties](../../programming-guide/classes-and-structs/properties.md). In the counter, `AddVisit` keeps the two counts in sync.

## Initialize fields and limit reassignment with `readonly`

To give a field a starting value, use a *field initializer*, an expression that supplies an initial value in the declaration:

:::code language="csharp" source="snippets/index/Program.cs" id="FieldInitializers":::

Each new `Reminder` starts with its own `"Take a break"` text. If you omit an explicit initializer, a field starts with its type's [default value](../../language-reference/builtin-types/default-values.md), such as `0` for `int`, `false` for `bool`, or `null` for a reference type. Local variables follow different definite-assignment rules.

When you need caller-supplied values or need to coordinate initialization across fields, use a *constructor*, the member that initializes a new object. See [Constructors](../../programming-guide/classes-and-structs/constructors.md) for examples. An instance field initializer can't refer to another instance field. For caller-supplied object initializers and `required` members, see [Object and collection initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) and [`required`](../../language-reference/keywords/required.md).

To preserve a field's value after initialization, declare a *readonly field* with `readonly`. You can assign an instance readonly field at its declaration or in an instance constructor of its containing type. Its value needn't be known at compile time. See the [`readonly` reference](../../language-reference/keywords/readonly.md) for the precise rules.

For example, you can preserve the time when each session object was created:

:::code language="csharp" source="snippets/index/Program.cs" id="ReadonlyField":::

Each `Session` gets its own `startedAt` value. After initialization, you can read the field, but a method can't assign a different value to it.

For a reference-valued field, `readonly` prevents replacement of the reference, not changes to the referenced object. Similarly, an init-only record property doesn't make its contents immutable. See the [shallow-copy example for record classes](../types/records.md#nondestructive-mutation-with-with-expressions).

## Replace magic values with named constants

Give fixed values meaningful names so you can express their purpose instead of repeating unexplained literals, often called *magic values*, in your code. For example, `SecondsPerMinute` tells a reader why you use `60` in a time calculation.

A *constant* is a named value that the compiler can determine at compile time. Declare it with [`const`](../../language-reference/keywords/const.md) and supply its value in the declaration:

:::code language="csharp" source="snippets/index/Program.cs" id="Constants":::

Use the type name to access a constant declared in another type:

:::code language="csharp" source="snippets/index/Program.cs" id="UseConstants":::

A member constant such as `SecondsPerMinute` is implicitly static: it belongs to the type. Adding `static` would be redundant, and C# doesn't allow you to combine `static` with `const`. The compiler substitutes the constant value where your code uses it, rather than reading mutable shared storage. You can also declare a constant local to a method; a local constant isn't a type member.

You can declare constants of numeric types, `bool`, `char`, `string`, and enum types. A reference-type constant other than a string can only hold `null`; you can't create a constant array or object with `new`. For related named integral values, see [Enumerations](../types/enums.md). C# [`#define`](../../language-reference/preprocessor-directives.md#defining-symbols) defines conditional-compilation symbols, not constant values.

> [!IMPORTANT]
> A compiled caller contains the value of a constant from a referenced assembly. If that assembly changes the constant, recompile the caller to use the new value. For compatibility details, see the existing [constants guide](../../programming-guide/classes-and-structs/constants.md).

### Use `static readonly` for a runtime constant

When you need one fixed value for the type but must calculate it at run time, use a `static readonly` field. For example, you can capture the time when a type is initialized:

:::code language="csharp" source="snippets/index/Program.cs" id="RuntimeConstant":::

Unlike the instance field `Session.startedAt`, `RunInfo.StartedAt` holds one value for the type, not a separate value per object. The runtime evaluates its initializer once during type initialization, before you first read the field. The exact timing can be earlier than that first read, so don't depend on initialization occurring at program startup.

You can assign a `static readonly` field in its declaration, as shown, or in a *static constructor*, a member the runtime calls automatically to initialize a type. Use a static constructor when initialization needs multiple statements; static field initializers run before its body. After type initialization, you can read the field but can't reassign it. See [Static constructors](../../programming-guide/classes-and-structs/static-constructors.md) for initialization order and timing.

## Further reading

- [Properties](../../programming-guide/classes-and-structs/properties.md) explains how to expose values with accessors.
- [Constructors](../../programming-guide/classes-and-structs/constructors.md) explains object initialization.
- The [fields guide](../../programming-guide/classes-and-structs/fields.md) retains additional field forms. Specialized fields such as [`volatile`](../../language-reference/keywords/volatile.md), [fixed-size buffers](../../language-reference/unsafe-code.md#fixed-size-buffers), and [`ref` fields](../../language-reference/builtin-types/ref-struct.md#ref-fields) have separate reference coverage.
