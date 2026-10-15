---
title: "C# Equality comparisons"
description: Learn how C# compares values and references with ==, !=, Equals, GetHashCode, and ReferenceEquals for classes, structs, records, and tuples. Covers the equivalence contract, polymorphic equality in class hierarchies, and records with collection members.
ms.date: 08/18/2026
ms.topic: concept-article
ai-usage: ai-assisted
helpviewer_keywords:
  - "object equality [C#]"
  - "value equality [C#]"
  - "reference equality [C#]"
  - "object identity [C#]"
  - "object equivalence [C#]"
  - "overriding Equals method [C#]"
  - "Equals method [C#], overriding"
  - "equivalence [C#]"
---

# C# Equality comparisons

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from another language?** In Java, `==` on objects and JavaScript `===` on objects test identity, not content. C# classes work the same way by default. In Python, `==` calls `__eq__` and tests content by default, similar to how C# [records](../types/records.md) compare. C# [structs](../types/structs.md) also compare by value when you call `Equals`.

C# distinguishes two kinds of equality. *Value equality* means two instances are equal when their data matches. *Reference equality* means two variables are equal only when they point to the same object in memory. This condition is also called *identity*. Value types usually compare data, and reference types usually compare identity. Type authors can change those defaults, but that mental model prevents subtle bugs where two objects that look identical aren't considered equal, or where a mutation through one variable silently changes what another variable sees.

## Value types, reference types, and equality defaults

Every type in C# is either a *value type* or a *reference type*. A *value type* holds its data directly in the variable. A *reference type* holds a reference to an object. When you assign a reference-type variable to another variable, both variables refer to the same object. For more information about value types and reference types, see [Type system overview](../types/index.md#value-types-and-reference-types).

The default equality behavior usually follows the kind of type:

- **Built-in numeric types and [enums](../types/enums.md)** are value types. Two `int` variables are equal when their numeric values match.
- **[Structs](../types/structs.md)** are value types. A plain `struct` uses value equality when you call <xref:System.Object.Equals*>.
- **[Tuples](../types/tuples.md)** are value types. Two tuples are equal when all their element values match.
- **[Classes](../types/classes.md)** are reference types. A plain class uses reference equality, so `==` and <xref:System.Object.Equals*> test whether two variables point to the same object.

A class uses reference equality. Two separate objects with the same data aren't equal, but two variables that refer to the same object are equal:

:::code language="csharp" source="snippets/equality/Program.cs" ID="ClassEquality":::

A `struct` shows value equality through <xref:System.Object.Equals*>. Two struct instances are equal when their fields match:

:::code language="csharp" source="snippets/equality/Program.cs" ID="StructEquality":::

Plain structs don't get a predefined `==` operator. Writing `p1 == p2` on a plain struct compiles only if the struct declares its own `operator ==`. If you need operator comparisons for a struct, define `==` and `!=` as a pair and keep them consistent with <xref:System.Object.Equals*> and <xref:System.Object.GetHashCode*>.

Tuples are value types too. Two tuples are equal when every element value matches. Element names in a named tuple are a compile-time convenience and aren't considered during comparison. Only positions and values matter:

:::code language="csharp" source="snippets/equality/Program.cs" ID="TupleEquality":::

For more information about tuple syntax and deconstruction, see [Tuples and deconstruction](../types/tuples.md).

## Use `Object.ReferenceEquals` to test identity directly

<xref:System.Object.ReferenceEquals*> always tests identity regardless of how a type overrides <xref:System.Object.Equals*> or overloads `==`. Use it as an identity diagnostic when you need to confirm whether two variables point to the exact same object:

:::code language="csharp" source="snippets/equality/Program.cs" ID="ReferenceEqualsDemo":::

A common use is inside an `Equals` override to short-circuit the full comparison: when both arguments are the same reference, they're always equal without checking individual fields.

> [!NOTE]
> When variables are typed as an [interface](../types/interfaces.md), `==` checks whether the interface variables refer to the same object. A call to `Equals` still runs the underlying object's implementation.

> [!NOTE]
> <xref:System.Object.ReferenceEquals*> always returns `false` when comparing value types, even if both arguments contain the same values. This behavior occurs because each value-type argument is independently *boxed* into a separate heap object when passed to `ReferenceEquals`.

## Types can define different equality semantics

Types *can* define equality semantics that differ from the default behavior. The most common reason is to implement value equality. If you create a type that represents data, such as a bank account, a product in inventory, or a user in a system, consider instances with the same values as equal. *Choose [record types](../types/records.md) for implementing value equality*, and the compiler generates all the necessary equality members for you.

> [!NOTE]
> **Strings** are classes, but `==` and <xref:System.Object.Equals*> compare string content, not identity.

- `==`: the equality operator. Most types use this operator as the primary equality check. Its behavior depends on whether the type has a built-in or user-defined `==` operator.
- `!=`: the inequality operator. When a type defines a user-defined `==` operator, it must also define `!=`.
- <xref:System.Object.Equals*>: a virtual method inherited by every type. You can override it to change equality semantics for a type.
- <xref:System.Object.GetHashCode*>: a virtual method used by hash-based collections. When two values are equal, their hash codes must also be equal.
- <xref:System.Object.ReferenceEquals*>: a static method that always tests identity.

## Use records for value equality

Use the `record` modifier to give a data-focused type value equality when the type can be a record. The compiler generates <xref:System.Object.Equals*>, <xref:System.Object.GetHashCode*>, and `==`/`!=` members that compare every declared property value.

A `record class` is still a reference type, but it compares values instead of identity:

:::code language="csharp" source="snippets/equality/Program.cs" ID="RecordEquality":::

<xref:System.Object.ReferenceEquals*> confirms that `person1` and `person2` are different objects in memory, while `==` and <xref:System.Object.Equals*> return `True` because the compiler-generated equality compares property values.

The same compiler generation applies to `record struct` types:

:::code language="csharp" source="snippets/equality/Program.cs" ID="RecordStructEquality":::

Record types generate the whole equality set for their own type. Both `record class` and `record struct` types override <xref:System.Object.Equals*> and <xref:System.Object.GetHashCode*>. They also generate `==` and `!=` operators, plus a typed `Equals` method for the record type. Unlike a plain `struct`, a `record struct` therefore supports `==` and `!=` automatically. For more information about record types and their equality semantics, see [Records](../types/records.md#value-equality).

### Records with reference-type members

Record equality uses the members' own equality semantics. Each property or field is compared by using its own `Equals` method. For most scalar values, such as `int`, `string`, or `DateTime`, this approach compares the values of the record members. The subtlety arises with common mutable collections such as `List<T>` or `T[]`: these types compare by reference, so two record instances that contain *different list objects with the same content* are **not** considered equal by the synthesized record equality.

:::code language="csharp" source="snippets/equality/Program.cs" ID="RecordWithCollectionProblem":::

`playlist1` and `playlist2` are separate `List<string>` instances. Even though their contents match, `Equals` returns `false`.

When you need record equality to reflect collection *contents*, you have a few options:

- **Implement `IEquatable<T>`** on the record and override `Equals` to use <xref:System.Linq.Enumerable.SequenceEqual*?displayProperty=nameWithType> for the collection members.
- **Use a collection type with value equality** — for example, a custom `IEqualityComparer<T>` or a type whose own `Equals` compares elements.
- **Design around identity**: if the record represents an entity rather than a pure value, reference equality for its collection members might be intentional.

> [!IMPORTANT]
> Manual implementation of equality is rare today in C#. Records handle the common scenario of value equality automatically. If you need to implement equality manually - for example, because your type must derive from a non-record base class - see [Implement equality yourself when a type can't be a record](../../language-reference/operators/equality-operators.md#implement-equality-yourself-when-a-type-cant-be-a-record) in the language reference.

## See also

- [Type system overview](../types/index.md)
- [Classes](../types/classes.md)
- [Structs](../types/structs.md)
- [Records](../types/records.md)
- [Tuples and deconstruction](../types/tuples.md).
- [Equality operators (language reference)](../../language-reference/operators/equality-operators.md).
- [Equality in class hierarchies](../../language-reference/operators/equality-operators.md#equality-in-class-hierarchies) — advanced guidance on polymorphic equality.
- [Arithmetic, comparison, logical, and assignment operators](operators.md) — the equality operator survey alongside arithmetic, logical, and assignment operators.
