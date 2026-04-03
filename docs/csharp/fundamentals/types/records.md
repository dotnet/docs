---
title: "C# record types"
description: Learn how the record modifier enhances classes and structs with compiler-generated value equality, ToString, with expressions, and positional syntax.
ms.date: 03/25/2026
ms.topic: concept-article
ai-usage: ai-assisted
---
# C# record types

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. You'll encounter records when you need concise data types with built-in equality.
>
> **Experienced in another language?** C# records are similar to data classes in Kotlin or case classes in Scala. They're types optimized for storing data, with compiler-generated equality, `ToString`, and copy semantics. Skim the [`record class` vs `record struct`](#record-class-vs-record-struct) and [`with` expressions](#nondestructive-mutation-with-with-expressions) sections for C#-specific patterns.

The [`record`](../../language-reference/builtin-types/record.md) keyword is a modifier you apply to either a `class` or a `struct`. It tells the compiler to generate value equality, a formatted `ToString`, and nondestructive mutation through [`with` expressions](../../language-reference/operators/with-expression.md). The underlying type, a class or a struct, still determines whether instances use reference or value semantics. The `record` modifier adds data-friendly behavior on top of those semantics. Use records when a type's primary role is storing data and two instances with the same values should be considered equal.

## Declare a record

You can apply `record` to either a class or a struct. The simplest form uses *positional parameters* that define both the constructor and the properties in a single line:

:::code language="csharp" source="snippets/records/FirstRecord.cs" ID="DeclareRecord":::

:::code language="csharp" source="snippets/records/RecordStruct.cs" ID="RecordStructDecl":::

Writing `record` alone is shorthand for [`record class`](../../language-reference/builtin-types/record.md) which is a reference type. Writing [`record struct`](../../language-reference/builtin-types/record.md) creates a value type. The compiler generates properties from the positional parameters in both cases, but the defaults differ:

- **`record class`**: Properties are `init`-only (immutable after construction).
- **`record struct`**: Properties are read-write by default. Add `readonly` (`readonly record struct`) to make them `init`-only.

You can also write records with standard property syntax when you need more control. For example, to make a property read/write instead of `init`-only:

:::code language="csharp" source="snippets/records/FirstRecord.cs" ID="RecordWithBody":::

Create and use record instances the same way you create any object:

:::code language="csharp" source="snippets/records/FirstRecord.cs" ID="UsingRecord":::

## `record class` vs. `record struct`

Because the `record` modifier preserves the underlying type's semantics, a `record class` and a `record struct` behave differently when you assign or compare references. Assigning a `record class` copies the reference. Both variables point to the same object. Assigning a `record struct` copies the data, so changes to one variable don't affect the other:

:::code language="csharp" source="snippets/records/RecordStruct.cs" ID="RecordClassVsStruct":::

:::code language="csharp" source="snippets/records/RecordStruct.cs" ID="UsingRecordStruct":::

Choose `record class` when you need inheritance or when instances are large enough that copying would be expensive. Choose `record struct` for small, self-contained data where value-type copy semantics are appropriate. For more on value type semantics, see [Structs](structs.md).

## Value equality

The `record` modifier gives both classes and structs compiler-generated, property-by-property equality. Here's how equality works across all four type kinds:

- **Plain class**: Uses *reference equality* by default. The `==` operator checks whether two variables point to the same object, not whether the data matches.
- **Plain struct**: Supports value equality through <xref:System.ValueType.Equals*?displayProperty=nameWithType>, but the default implementation uses reflection, which is slower and doesn't generate `==`/`!=` operators.
- **`record class`**: The compiler generates `Equals` and `GetHashCode` methods, and `==`/`!=` operators, that compare every property value. Two distinct objects with the same data are equal.
- **`record struct`**: Same compiler-generated equality as a `record class`, but without using reflection, which makes it faster than plain struct equality.

The following example demonstrates record class equality:

:::code language="csharp" source="snippets/records/EqualityTest.cs" ID="EqualityTest":::

The two `Person` instances are different objects, but they're equal because all their property values match. Array properties compare by reference, not by contents. Mutating the shared array is visible through both records because the array itself isn't copied.

## Nondestructive mutation with `with` expressions

Records are often immutable, so you can't change a property after creation. A `with` expression creates a copy with one or more properties changed, leaving the original record unchanged. This approach works for both `record class` and `record struct` types:

:::code language="csharp" source="snippets/records/ImmutableRecord.cs" ID="WithExpression":::

:::code language="csharp" source="snippets/records/RecordStruct.cs" ID="RecordStructWith":::

A `with` expression copies the existing instance, then applies the specified property changes.

## Positional records and deconstruction

Positional records generate a `Deconstruct` method that you use to extract property values into individual variables:

:::code language="csharp" source="snippets/records/FirstRecord.cs" ID="Deconstruct":::

Deconstruction works with both `record class` and `record struct` types. You can use it in assignments, `foreach` loops, and pattern matching.

## Record inheritance

A `record class` can inherit from another `record class`. A record can't inherit from a regular class, and a class can't inherit from a record:

:::code language="csharp" source="snippets/records/FirstRecord.cs" ID="RecordInheritance":::

Value equality checks include the run-time type, so a `Person` and a `Student` with the same `FirstName` and `LastName` aren't considered equal. Record structs don't support inheritance because structs can't inherit from other types.

## When to use records

Use a record when all of the following conditions are true:

- The type's primary role is storing data.
- Two instances with the same values should be equal.
- You want immutability (especially for `record class` types).
- You want a readable `ToString` without writing one manually.

When choosing between `record class` and `record struct`:

- Use `record class` when you need inheritance, or when the type is large enough that copying on every assignment would be expensive.
- Use `record struct` for small, self-contained values where copy semantics and stack allocation are beneficial.

Avoid records for entity types in [Entity Framework Core](/ef/core/), which depends on reference equality to track entities. For a broader comparison of type options, see [Choose which kind of type](index.md#choose-which-kind-of-type).

## See also

- [Type system overview](index.md)
- [Classes](classes.md)
- [Structs](structs.md)
- [Records (C# reference)](../../language-reference/builtin-types/record.md)
