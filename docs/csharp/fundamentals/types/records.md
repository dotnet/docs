---
title: "C# record types"
description: Learn how to define and use record types in C#, including value equality, immutability, with expressions, record structs, and positional syntax.
ms.date: 03/25/2026
ms.topic: concept-article
ai-usage: ai-assisted
---
# C# record types

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. You'll encounter records once you need concise data types with built-in equality.
>
> **Experienced in another language?** C# records are similar to data classes in Kotlin or case classes in Scala. They're types optimized for storing data, with compiler-generated equality, `ToString`, and copy semantics. Skim the [record structs](#record-structs) and [`with` expressions](#nondestructive-mutation-with-with-expressions) sections for C#-specific patterns.

A *record* is a class or struct that the compiler enhances with members useful for data-centric types. When you add the [`record`](../../language-reference/builtin-types/record.md) modifier, the compiler generates value equality, a formatted `ToString`, and nondestructive mutation through [`with` expressions](../../language-reference/operators/with-expression.md). Use records when a type's primary role is storing data and two instances with the same values should be considered equal.

## Declare a record

Declare a record with the `record` keyword. Writing `record` alone is shorthand for [`record class`](../../language-reference/builtin-types/record.md). The type is a reference type. (For value-type records, write [`record struct`](../../language-reference/builtin-types/record.md) explicitly; see [Record structs](#record-structs).) The simplest form uses *positional parameters* that define both the constructor and the properties in a single line:

:::code language="csharp" source="snippets/records/FirstRecord.cs" ID="DeclareRecord":::

The compiler generates a `FirstName` property and a `LastName` property from the positional parameters. For a `record class`, the properties are `init`-only (immutable after construction). You can also write records with standard property syntax when you need more control. For example, to make a property read/write instead of `init`-only:

:::code language="csharp" source="snippets/records/FirstRecord.cs" ID="RecordWithBody":::

Create and use record instances the same way you create any object:

:::code language="csharp" source="snippets/records/FirstRecord.cs" ID="UsingRecord":::

## Value equality

Records use *value equality*: `==` checks whether the types match and all property values are equal. The compiler generates `Equals`, `GetHashCode`, and the `==`/`!=` operators for you, so you don't write any of that boilerplate. In contrast, classes use *reference equality* by default. The `==` operator checks whether two variables point to the same object. Regular structs support value equality through `ValueType.Equals`, but that default implementation can be slower. Record structs get a compiler-generated, reflection-free equality check that's more efficient:

:::code language="csharp" source="snippets/records/EqualityTest.cs" ID="EqualityTest":::

The two `Person` instances are different objects, but they're equal because all their property values match. Array properties compare by reference, not by contents. Mutating the shared array is visible through both records because the array itself isn't copied.

## Nondestructive mutation with `with` expressions

Records are often immutable, so you can't change a property after creation. A `with` expression creates a copy with one or more properties changed, leaving the original intact:

:::code language="csharp" source="snippets/records/ImmutableRecord.cs" ID="WithExpression":::

A `with` expression copies the existing instance, then applies the specified property changes.

## Record structs

A `record struct` is a value type with the same compiler-generated members as a record class: equality, `ToString`, and `Deconstruct`. The key differences are:

- A `record struct` is a value type. Assignment copies the data, not a reference.
- Positional properties in a `record struct` are read-write by default (not `init`-only like in a `record class`).
- Add `readonly` to make a `record struct` immutable: `readonly record struct`.

The following example shows the difference. Assigning a record class copies the reference. Both variables point to the same object. Assigning a record struct copies the data, so changes to one variable don't affect the other:

:::code language="csharp" source="snippets/records/RecordStruct.cs" ID="RecordClassVsStruct":::

:::code language="csharp" source="snippets/records/RecordStruct.cs" ID="RecordStructDecl":::

:::code language="csharp" source="snippets/records/RecordStruct.cs" ID="UsingRecordStruct":::

Record structs support `with` expressions, just like record classes:

:::code language="csharp" source="snippets/records/RecordStruct.cs" ID="RecordStructWith":::

For more on value type semantics and when to choose a struct over a class, see [Structs](structs.md).

## Positional records and deconstruction

Positional records generate a `Deconstruct` method that lets you extract property values into individual variables:

:::code language="csharp" source="snippets/records/FirstRecord.cs" ID="Deconstruct":::

Deconstruction works with both `record class` and `record struct` types. You can use it in assignments, `foreach` loops, and pattern matching.

## Record inheritance

A `record class` can inherit from another `record class`. A record can't inherit from a regular class, and a class can't inherit from a record:

:::code language="csharp" source="snippets/records/FirstRecord.cs" ID="RecordInheritance":::

Value equality checks include the run-time type, so a `Person` and a `Student` with the same `FirstName` and `LastName` aren't considered equal. Record structs don't support inheritance because structs can't inherit from other types.

## When to use records

Use a record when:

- The type's primary role is storing data.
- Two instances with the same values should be equal.
- You want immutability (especially for `record class` types).
- You want a readable `ToString` without writing one manually.

Avoid records for entity types in [Entity Framework Core](/ef/core/), which depends on reference equality to track entities. For a broader comparison of type options, see [Choose which kind of type](index.md#choose-which-kind-of-type).

## See also

- [Type system overview](index.md)
- [Classes](classes.md)
- [Structs](structs.md)
- [Records (C# reference)](../../language-reference/builtin-types/record.md)
