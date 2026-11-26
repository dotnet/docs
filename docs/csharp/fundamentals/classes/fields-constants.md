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
> **Coming from another language?** If you used [Java fields and `static final` declarations](https://docs.oracle.com/javase/tutorial/java/javaOO/classvars.html), you recognize per-object state and named fixed values. In C#, choose `const` for a compile-time constant or `readonly` for a field you assign during initialization.

A *field* is a variable declared in a type. A field stores state associated with an instance of the type or the type itself. See the [class reference](../../language-reference/keywords/class.md) for member declaration syntax. Use instance fields for each object's state and static fields for state shared by the type. For example, the counter uses one of each:

:::code language="csharp" source="snippets/index/Program.cs" id="CounterDeclaration":::

A separate copy of `count` exists in each `VisitCounter` object. The `static` field `total` is shared by all instances of this class.

Use private fields for state that your class manages. Expose operations through methods or values through [properties](../../programming-guide/classes-and-structs/properties.md). In the counter, `AddVisit` keeps the two counts in sync.

## Initialize fields and limit reassignment with `readonly`

To give a field a starting value, use a *field initializer*, an expression that supplies an initial value in the declaration:

:::code language="csharp" source="snippets/index/Program.cs" id="FieldInitializers":::

Each new `Reminder` starts with its own `"Take a break"` text. If you omit an explicit initializer, a field starts with its type's [default value](../../language-reference/builtin-types/default-values.md), such as `0` for `int`, `false` for `bool`, or `null` for a reference type.

When you need caller-supplied values or need to coordinate initialization across fields, use a *constructor*. A constructor is a member that initializes a new object. See [Constructors](../../programming-guide/classes-and-structs/constructors.md) for examples.

To preserve a field's value after runtime initialization, declare a *readonly field* using the `readonly` keyword. You can assign an instance readonly field at its declaration or in an instance constructor of its containing type. Its value needn't be known at compile time. See the [`readonly` reference](../../language-reference/keywords/readonly.md) for the precise rules.

For example, you can preserve the time when each session object was created:

:::code language="csharp" source="snippets/index/Program.cs" id="ReadonlyField":::

Each `Session` gets its own `startedAt` value. After initialization, you can read the field, but a method can't assign a different value to it.

For a reference-valued field, `readonly` prevents replacement of the reference, not changes to the referenced object. See the [shallow-copy example for record classes](../types/records.md#nondestructive-mutation-with-with-expressions).

## Use named constants for common values

Give fixed values meaningful names so you can express their purpose instead of repeating unexplained literals, often called "magic values", in your code. For example, `SecondsPerMinute` tells a reader why you use `60` in a time calculation.

A *constant* is a named value that the compiler can determine at compile time. Declare it with [`const`](../../language-reference/keywords/const.md) and supply its value in the declaration:

:::code language="csharp" source="snippets/index/Program.cs" id="Constants":::

Use the type name and constant name to access a constant declared in another type. The compiler substitutes the constant value where your code uses it:

:::code language="csharp" source="snippets/index/Program.cs" id="UseConstants":::

A member constant such as `SecondsPerMinute` is implicitly static: it belongs to the type. Adding `static` would be redundant, and C# doesn't allow you to combine `static` with `const`.

You can declare constants of numeric types, `bool`, `char`, `string`, and [`enum` types](../types/enums.md). A reference-type constant other than a string can only hold `null`; you can't create a constant array or object with `new`. For related named integral values, see [Enumerations](../types/enums.md). C# [`#define`](../../language-reference/preprocessor-directives.md#defining-symbols) defines conditional-compilation symbols, not constant values.

> [!IMPORTANT]
> A compiled caller contains the value of a constant from a referenced assembly. If that assembly changes the constant, recompile the caller to use the new value. For compatibility details, see the existing [constants guide](../../programming-guide/classes-and-structs/constants.md).

### Use `static readonly` for a runtime constant

When you need one fixed value for the type that can't be a compile-time constant, use a `static readonly` field. For example, give reminders a shared interval:

:::code language="csharp" source="snippets/index/Program.cs" id="RuntimeConstant":::

A <xref:System.TimeSpan> represents a time interval. The call to `TimeSpan.FromMinutes(15)` creates the value at run time. A `TimeSpan` value can't be declared with `const`, so `static readonly` gives this shared interval a name and prevents reassignment after initialization.

You can assign a `static readonly` field in its declaration, as shown, or in a *static constructor*, a member the runtime calls automatically to initialize a type. Use a static constructor when initialization needs multiple statements. See [Static constructors](../../programming-guide/classes-and-structs/static-constructors.md) for details.

## Further reading

- [Properties](../../programming-guide/classes-and-structs/properties.md) explains how to expose values with accessors.
- [Constructors](../../programming-guide/classes-and-structs/constructors.md) explains object initialization.
- The [fields guide](../../programming-guide/classes-and-structs/fields.md) covers other field forms. Specialized fields such as [`volatile`](../../language-reference/keywords/volatile.md), [fixed-size buffers](../../language-reference/unsafe-code.md#fixed-size-buffers), and [`ref` fields](../../language-reference/builtin-types/ref-struct.md#ref-fields) have separate reference articles.
