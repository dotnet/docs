---
title: Fields and constants
description: Declare instance and static fields in C#, initialize stored state, and distinguish readonly fields from compile-time constants.
ms.date: 11/16/2026
ms.topic: concept-article
ai-usage: ai-generated
---

# Fields and constants

Use this article after [Class members and instances](index.md) to declare stored state and named fixed values.

## Store state in fields

A *field* is a variable declared directly in a type. Unlike a local variable inside a method, a field stores state that methods can use across calls. See the [class reference](../../language-reference/keywords/class.md) for member declaration syntax.

The counter uses one field per instance and one static field for the type:

:::code language="csharp" source="snippets/index/Program.cs" id="CounterDeclaration":::

`count` exists separately in each `VisitCounter` object. The `static` field `total` is shared by all instances of this class. Use [access modifiers](access-modifiers.md) independently of `static` to control which code can use a field.

Prefer private fields for state that the class manages. Expose operations through methods or values through [properties](../../programming-guide/classes-and-structs/properties.md). In the counter, `AddVisit` keeps the two counts in sync.

## Initialize fields

A *field initializer* supplies an initial value in the declaration:

:::code language="csharp" source="snippets/index/Program.cs" id="FieldInitializers":::

Each new `Reminder` starts with its own `"Take a break"` text. Without an explicit initializer, a field starts with its type's [default value](../../language-reference/builtin-types/default-values.md), such as `0` for `int`, `false` for `bool`, or `null` for a reference type. Local variables follow different definite-assignment rules.

An instance field initializer can't refer to another instance field. To use caller-supplied values or coordinate initialization across fields, see [Constructors](../../programming-guide/classes-and-structs/constructors.md). For caller-supplied object initializers and `required` members, see [Object and collection initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) and [`required`](../../language-reference/keywords/required.md).

## Name fixed values with constants

A *constant* is a named value that the compiler can determine at compile time. Declare it with [`const`](../../language-reference/keywords/const.md) and supply its value in the declaration:

:::code language="csharp" source="snippets/index/Program.cs" id="Constants":::

Use the type name to access a constant declared in another type:

:::code language="csharp" source="snippets/index/Program.cs" id="UseConstants":::

`SecondsPerMinute` isn't mutable shared storage. The compiler substitutes the constant value where code uses it. Don't add `static` to a `const` declaration. Constants can also be local to a method.

Numeric types, `bool`, `char`, `string`, and enum types support constant values. A reference-type constant other than a string can only hold `null`; you can't create a constant array or object with `new`. For related named integral values, see [Enumerations](../types/enums.md). C# [`#define`](../../language-reference/preprocessor-directives.md#defining-symbols) defines conditional-compilation symbols, not constant values.

> [!IMPORTANT]
> A compiled caller contains the value of a constant from a referenced assembly. If that assembly changes the constant, recompile the caller to use the new value. For compatibility details, see the existing [constants guide](../../programming-guide/classes-and-structs/constants.md).

## Assign a field once with `readonly`

A *readonly field* accepts assignment at its declaration or in a constructor of its containing type. Unlike a constant, its value needn't be known at compile time. A `static readonly` field can receive its value in a static constructor. See the [`readonly` reference](../../language-reference/keywords/readonly.md) for the precise rules.

For example, a readonly field can hold the time when an object was created:

:::code language="csharp" source="snippets/index/Program.cs" id="ReadonlyField":::

Each `Session` gets its own `startedAt` value. After initialization, a method can't assign a different value to that field.

For a reference-valued field, `readonly` prevents replacement of the reference, not changes to the referenced object. Similarly, an init-only record property doesn't make its contents immutable. See the [shallow-copy example for record classes](../types/records.md#nondestructive-mutation-with-with-expressions).

## Further reading

- [Properties](../../programming-guide/classes-and-structs/properties.md) explains how to expose values with accessors.
- [Constructors](../../programming-guide/classes-and-structs/constructors.md) explains object initialization.
- The [fields guide](../../programming-guide/classes-and-structs/fields.md) retains additional field forms. Specialized fields such as [`volatile`](../../language-reference/keywords/volatile.md), [fixed-size buffers](../../language-reference/unsafe-code.md#fixed-size-buffers), and [`ref` fields](../../language-reference/builtin-types/ref-struct.md#ref-fields) have separate reference coverage.
