---
title: "C# Equality comparisons"
description: Learn how C# compares values and references with ==, !=, Equals, GetHashCode, and ReferenceEquals for classes, structs, records, and tuples.
ms.date: 07/21/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# C# Equality comparisons

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from another language?** In Java, `==` on objects and JavaScript `===` on objects test identity, not content; C# classes work the same way by default. In Python, `==` calls `__eq__` and tests content by default — similar to how C# records and structs behave.

C# distinguishes two kinds of equality. *Value equality* means two instances are equal when their data matches. *Reference equality* means two variables are equal only when they point to the same object in memory — this is also called *identity*. Knowing which kind applies to a type prevents subtle bugs where two objects that look identical aren't considered equal, or where a mutation through one variable silently changes what another variable sees.

## Value equality and reference equality

Every type in C# is either a *value type* or a *reference type*. A *value type* holds its data directly in the variable. A *reference type* holds a reference — a pointer to an object stored on the managed heap. This article uses that distinction as a quick refresher. For more information about value types and reference types, see [Type system overview](../types/index.md).

The default equality behavior follows the kind of type:

- **Built-in numeric types and enums** (value types): value equality — two `int` variables are equal when their numeric values match.
- **Structs** (value types): value equality through <xref:System.ValueType.Equals*> — all fields are compared, but plain structs don't get a predefined `==` operator.
- **Tuples** (value types): value equality — two tuples are equal when all their element values match.
- **Classes** (reference types): reference equality — `==` and <xref:System.Object.Equals*> test whether two variables point to the same object.
- **Interfaces** (reference types): reference equality for `==` — interface variables hold references. The <xref:System.Object.Equals*> call is dispatched to the underlying object's implementation.

Some types change those defaults:

- **Record classes** generate value equality even though they're reference types. **Record structs** also generate value equality and include `==`/`!=` operators.
- **Strings** are classes, but `==` and <xref:System.Object.Equals*> compare string content, not identity.
- **Your own classes and structs** can define value equality when their data should determine equality.

Equality is woven through these related members:

- `==` — the equality operator. Most types use this as the primary equality check. Its behavior depends on whether the type has a built-in or user-defined `==` operator. In general, the operands must be comparable; the compiler can apply built-in conversions (such as numeric promotions), and user-defined operators can compare different types.
- `!=` — the inequality operator. When a type defines a user-defined `==` operator, it must also define `!=`.
- <xref:System.Object.Equals*> — a virtual method inherited by every type. It can be overridden to change equality semantics.
- <xref:System.Object.GetHashCode*> — a virtual method used by hash-based collections. When two values are equal, their hash codes must also be equal.
- <xref:System.Object.ReferenceEquals*> — a static method that always tests identity, regardless of any `Equals` override or operator overload.

## Classes use reference equality by default

A plain class inherits `==` and <xref:System.Object.Equals*> from <xref:System.Object>. Both test identity — whether two variables refer to the same object. Two distinct objects with identical data are not equal:

:::code language="csharp" source="snippets/equality/Program.cs" ID="ClassEquality":::

Assigning a class variable copies the reference, not the data. After `order3 = order1`, both variables point to the same object, so `==` returns `True`.

## Structs use value equality

A plain `struct` inherits <xref:System.ValueType.Equals*> from <xref:System.ValueType>, which overrides the object-level equality with a field-by-field comparison. Two struct instances are equal when all their fields match:

:::code language="csharp" source="snippets/equality/Program.cs" ID="StructEquality":::

Structs don't get a predefined `==` operator. Writing `p1 == p2` on a plain struct compiles only if the struct declares its own `operator ==`. For a complete, efficient value-type equality implementation, you typically provide both: a user-defined `==`/`!=` pair for operator comparisons and <xref:System.IEquatable`1> for typed equality that avoids the reflection overhead in the default <xref:System.ValueType.Equals*> implementation.

## Records provide value equality automatically

The `record` modifier generates value equality for both class-based and struct-based records. The compiler synthesizes <xref:System.Object.Equals*>, <xref:System.Object.GetHashCode*>, and `==`/`!=` that compare every declared property value:

:::code language="csharp" source="snippets/equality/Program.cs" ID="RecordEquality":::

<xref:System.Object.ReferenceEquals*> confirms that `person1` and `person2` are different objects in memory, while `==` and <xref:System.Object.Equals*> return `True` because the compiler-generated equality compares property values.

The same compiler generation applies to `record struct` types:

:::code language="csharp" source="snippets/equality/Program.cs" ID="RecordStructEquality":::

Record types generate the whole equality set for their own type. Both `record class` and `record struct` types override <xref:System.Object.Equals*> and <xref:System.Object.GetHashCode*>. They also generate `==` and `!=` operators, plus a strongly typed `Equals(T?)` implementation. Unlike a plain `struct`, a `record struct` therefore supports `==` and `!=` automatically. For more information about record types and their equality semantics, see [Records](../types/records.md).

## Tuples use value equality

C# tuples are value types. Two tuples are equal when every element value matches. Element names in a named tuple are a compile-time convenience and aren't considered during comparison — only positions and values matter:

:::code language="csharp" source="snippets/equality/Program.cs" ID="TupleEquality":::

For more information about tuple syntax and deconstruction, see [Tuples and deconstruction](../types/tuples.md).

## Add value equality to your own types

> [!IMPORTANT]
> This section shows how to implement by hand the equality behavior that the compiler generates when you add `record` to a type. If your type can be a record, use `record` instead — it generates all these members for you. Implement them manually only when your type can't be a record.

When a class or struct represents a value — a color, a measurement, a currency amount — and it can't be a `record`, implement a consistent set of equality members. A correct value-equality type provides all the related members so every equality path agrees. The language enforces that user-defined `==` and `!=` must be declared as a pair. If you provide those operators, the compiler warns you if you don't also override <xref:System.Object.Equals?displayProperty=nameWithType> (CS0660) and <xref:System.Object.GetHashCode?displayProperty=nameWithType> (CS0661).

In a complete manual implementation, provide these members:

- `==` and `!=` operators. Add them as a pair because the compiler requires a type that overloads one to overload the other.
- An `override` of <xref:System.Object.Equals*> that delegates to the typed version. This override keeps object-level equality consistent.
- An `override` of <xref:System.Object.GetHashCode*>. Objects that are equal must return the same hash code. Without this pairing, the type behaves incorrectly in hash-based collections such as `Dictionary<TKey,TValue>` or `HashSet<T>`. See <xref:System.Object.GetHashCode*> for guidance on a correct implementation.
- `Equals(T?)`, declared by implementing <xref:System.IEquatable`1>. Compare the fields you care about.

The following example starts with the <xref:System.Object.Equals*> and <xref:System.Object.GetHashCode*> overrides, plus a typed `Equals(T?)` member, so you can see their effect before the `==` and `!=` operators are added:

:::code language="csharp" source="snippets/equality/Program.cs" ID="ColorDefinition":::

At this point, `Equals` reflects value equality, but `==` still tests identity for the class because the type hasn't declared `==` and `!=` operators. Plain structs likewise still don't have a predefined `==` operator unless you declare one:

:::code language="csharp" source="snippets/equality/Program.cs" ID="IEquatableUsage":::

Adding `==` and `!=` operators completes the member set. For details, see [Equality operators](../../language-reference/operators/equality-operators.md) in the language reference.

## `Object.ReferenceEquals` — test identity directly

<xref:System.Object.ReferenceEquals*> always tests identity regardless of how a type overrides <xref:System.Object.Equals*> or overloads `==`. Use it when you need to confirm whether two variables point to the exact same object:

:::code language="csharp" source="snippets/equality/Program.cs" ID="ReferenceEqualsDemo":::

A common use is inside an `Equals` override to short-circuit the full comparison: when both arguments are the same reference, they're always equal without checking individual fields.

## See also

- [Type system overview](../types/index.md)
- [Classes](../types/classes.md)
- [Structs](../types/structs.md)
- [Records](../types/records.md)
- [Tuples and deconstruction](../types/tuples.md)
- [Equality operators (language reference)](../../language-reference/operators/equality-operators.md)
