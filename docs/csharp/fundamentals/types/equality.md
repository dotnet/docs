---
title: "Object equality in C#"
description: Learn how C# determines whether two values are equal. Understand value equality, reference equality, Equals, ==, ReferenceEquals, and IEquatable<T> for classes, structs, records, and tuples.
ms.date: 07/21/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Object equality in C#

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from another language?** In Java, `==` on objects tests identity, not content; C# classes work the same way by default. In Python, `==` calls `__eq__` and tests content by default — similar to how C# records and structs behave. In JavaScript, `===` on objects tests identity, like C# class defaults.

C# distinguishes two kinds of equality. *Value equality* means two instances are equal when their data matches. *Reference equality* means two variables are equal only when they point to the same object in memory — this is also called *identity*. Knowing which kind applies to a type prevents subtle bugs where two objects that look identical aren't considered equal, or where a mutation through one variable silently changes what another variable sees.

## Value equality and reference equality

Every type in C# is either a *value type* or a *reference type*. A *value type* holds its data directly in the variable. A *reference type* holds a reference — a pointer to an object stored on the managed heap. This distinction drives the default equality behavior:

- **Built-in numeric types and enums** (value types): value equality — two `int` variables are equal when their numeric values match.
- **Structs** (value types): value equality — <xref:System.ValueType.Equals*> compares all fields.
- **Records** (`record class` and `record struct`): compiler-generated value equality — the compiler synthesizes <xref:System.Object.Equals*>, <xref:System.Object.GetHashCode*>, and `==`/`!=` that compare every declared property.
- **Tuples** (value types): value equality — two tuples are equal when all their element values match.
- **Classes** (reference types): *reference equality* by default — `==` and <xref:System.Object.Equals*> test whether two variables point to the same object.

`string` is a notable exception: even though `string` is a class, `==` and <xref:System.Object.Equals*> compare string content, not identity.

The three tools for comparing values are:

- `==` — the equality operator. Most types use this as the primary equality check. Its behavior depends on whether the type overrides it.
- <xref:System.Object.Equals*> — a virtual method inherited by every type. Can be overridden to change equality semantics.
- <xref:System.Object.ReferenceEquals*> — a static method that always tests identity, regardless of any overrides.

## Classes use reference equality by default

A plain class inherits `==` and <xref:System.Object.Equals*> from <xref:System.Object>. Both test identity — whether two variables refer to the same object. Two distinct objects with identical data are not equal by default:

:::code language="csharp" source="snippets/equality/Program.cs" ID="ClassEquality":::

Assigning a class variable copies the reference, not the data. After `order3 = order1`, both variables point to the same object, so `==` returns `True`.

## Structs use value equality

A plain `struct` inherits <xref:System.ValueType.Equals*> from <xref:System.ValueType>, which overrides the object-level equality with a field-by-field comparison. Two struct instances are equal when all their fields match:

:::code language="csharp" source="snippets/equality/Program.cs" ID="StructEquality":::

Plain structs do not receive a `==` operator from the compiler. Use <xref:System.Object.Equals*> directly to compare structs, or implement <xref:System.IEquatable`1> to add typed equality and avoid the reflection overhead in the default <xref:System.ValueType.Equals*> implementation.

## Records provide value equality automatically

The `record` modifier generates value equality for both class-based and struct-based records. The compiler synthesizes <xref:System.Object.Equals*>, <xref:System.Object.GetHashCode*>, and `==`/`!=` that compare every declared property value:

:::code language="csharp" source="snippets/equality/Program.cs" ID="RecordEquality":::

<xref:System.Object.ReferenceEquals*> confirms that `person1` and `person2` are different objects in memory, while `==` and <xref:System.Object.Equals*> return `True` because the compiler-generated equality compares property values.

The same compiler generation applies to `record struct` types:

:::code language="csharp" source="snippets/equality/Program.cs" ID="RecordStructEquality":::

Unlike a plain `struct`, a `record struct` generates `==` and `!=` operators in addition to <xref:System.Object.Equals*>. For more about record types and their equality semantics, see [Records](records.md).

## Tuples use value equality

C# tuples are value types. Two tuples are equal when every element value matches. Element names in a named tuple are a compile-time convenience and aren't considered during comparison — only positions and values matter:

:::code language="csharp" source="snippets/equality/Program.cs" ID="TupleEquality":::

For more about tuple syntax and deconstruction, see [Tuples and deconstruction](tuples.md).

## Add value equality to a class

When a class represents a value — a color, a measurement, a currency amount — you want two instances with the same data to compare as equal. The simplest approach is the `record class` modifier, which generates all equality members automatically; see [Records](records.md).

When you need a full class with value equality — for example, because the type has mutable state, a complex constructor, or can't be a record — implement <xref:System.IEquatable`1>. The interface requires a strongly typed `Equals(T?)` method that avoids boxing and provides the most efficient comparison path:

:::code language="csharp" source="snippets/equality/Program.cs" ID="ColorDefinition":::

Implementing <xref:System.IEquatable`1> requires three members:

- A typed `Equals(T?)` that compares the fields you care about.
- An `override` of <xref:System.Object.Equals*>`(object?)` that delegates to the typed version.
- An `override` of <xref:System.Object.GetHashCode*>. Objects that are equal must return the same hash code; without this pairing, the type behaves incorrectly in hash-based collections such as `Dictionary<TKey,TValue>` or `HashSet<T>`. See <xref:System.Object.GetHashCode*> for guidance on a correct implementation.

After implementing <xref:System.IEquatable`1>, `Equals` reflects value equality, but `==` still tests identity unless you also add operator overloads:

:::code language="csharp" source="snippets/equality/Program.cs" ID="IEquatableUsage":::

Adding `==` and `!=` operators is a separate step. For details, see [Equality operators](../../language-reference/operators/equality-operators.md) in the language reference.

## `Object.ReferenceEquals` — test identity directly

<xref:System.Object.ReferenceEquals*> always tests identity regardless of how a type overrides <xref:System.Object.Equals*>. Use it when you need to confirm whether two variables point to the exact same object:

:::code language="csharp" source="snippets/equality/Program.cs" ID="ReferenceEqualsDemo":::

A common use is inside an `Equals` override to short-circuit the full comparison: when both arguments are the same reference, they're always equal without checking individual fields.

## See also

- [Type system overview](index.md)
- [Classes](classes.md)
- [Structs](structs.md)
- [Records](records.md)
- [Tuples and deconstruction](tuples.md)
- [Equality operators (language reference)](../../language-reference/operators/equality-operators.md)
- <xref:System.IEquatable`1>
- <xref:System.Object.Equals*>
- <xref:System.Object.ReferenceEquals*>
- <xref:System.Object.GetHashCode*>
