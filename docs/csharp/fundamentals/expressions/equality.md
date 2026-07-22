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
> **Coming from another language?** In Java, `==` on objects and JavaScript `===` on objects test identity, not content. C# classes work the same way by default. In Python, `==` calls `__eq__` and tests content by default - similar to how C# [records](../types/records.md) compare. C# [structs](../types/structs.md) also compare by value when you call `Equals`.

C# distinguishes two kinds of equality. *Value equality* means two instances are equal when their data matches. *Reference equality* means two variables are equal only when they point to the same object in memory. This condition is also called *identity*. Knowing which kind applies to a type prevents subtle bugs where two objects that look identical aren't considered equal, or where a mutation through one variable silently changes what another variable sees.

## Value equality and reference equality

Every type in C# is either a *value type* or a *reference type*. A *value type* holds its data directly in the variable. A *reference type* holds a reference to an object. When you assign a reference-type variable to another variable, both variables refer to the same object. This article uses that distinction as a quick refresher. For more information about value types and reference types, see [Type system overview](../types/index.md#value-types-and-reference-types).

The default equality behavior follows the kind of type:

- **Built-in numeric types and [enums](../types/enums.md)** (value types): value equality. Two `int` variables are equal when their numeric values match.
- **[Structs](../types/structs.md)** (value types): value equality through the inherited `Equals` method. All fields are compared, but plain structs don't get a predefined `==` operator.
- **[Tuples](../types/tuples.md)** (value types): value equality. Two tuples are equal when all their element values match.
- **[Classes](../types/classes.md)** (reference types): reference equality. `==` and <xref:System.Object.Equals*> test whether two variables point to the same object.

Some types change those defaults:

- **[Record classes and record structs](../types/records.md#record-class-vs-record-struct)** generate value equality and include `==`/`!=` operators.
- **Strings** are classes, but `==` and <xref:System.Object.Equals*> compare string content, not identity.
- **Your own classes and structs** can define value equality when their data should determine equality.

Equality is woven through these related members:

- `==` - the equality operator. Most types use this as the primary equality check. Its behavior depends on whether the type has a built-in or user-defined `==` operator.
- `!=` - the inequality operator. When a type defines a user-defined `==` operator, it must also define `!=`.
- <xref:System.Object.Equals*> - a virtual method inherited by every type. You can override it to change equality semantics.
- <xref:System.Object.GetHashCode*> - a virtual method used by hash-based collections. When two values are equal, their hash codes must also be equal.
- <xref:System.Object.ReferenceEquals*> - a static method that always tests identity.

## Classes use reference equality by default

A plain class inherits `==` and <xref:System.Object.Equals*> from <xref:System.Object>. Both test identity: whether two variables refer to the same object. Two distinct objects with identical data aren't equal:

:::code language="csharp" source="snippets/equality/Program.cs" ID="ClassEquality":::

Assigning a class variable copies the reference, not the data. After `order3 = order1`, both variables point to the same object, so `==` returns `True`.

## Structs use value equality

A plain `struct` compares values when you call `Equals`. Two struct instances are equal when all their fields match:

:::code language="csharp" source="snippets/equality/Program.cs" ID="StructEquality":::

Structs don't get a predefined `==` operator. Writing `p1 == p2` on a plain struct compiles only if the struct declares its own `operator ==`. If you need operator comparisons for a struct, define `==` and `!=` as a pair and keep them consistent with `Equals` and `GetHashCode`.

## Records provide value equality automatically

The `record` modifier generates value equality for both class-based and struct-based records. The compiler synthesizes <xref:System.Object.Equals*>, <xref:System.Object.GetHashCode*>, and `==`/`!=` that compare every declared property value:

:::code language="csharp" source="snippets/equality/Program.cs" ID="RecordEquality":::

<xref:System.Object.ReferenceEquals*> confirms that `person1` and `person2` are different objects in memory, while `==` and <xref:System.Object.Equals*> return `True` because the compiler-generated equality compares property values.

The same compiler generation applies to `record struct` types:

:::code language="csharp" source="snippets/equality/Program.cs" ID="RecordStructEquality":::

Record types generate the whole equality set for their own type. Both `record class` and `record struct` types override <xref:System.Object.Equals*> and <xref:System.Object.GetHashCode*>. They also generate `==` and `!=` operators, plus a typed `Equals` method for the record type. Unlike a plain `struct`, a `record struct` therefore supports `==` and `!=` automatically. For more information about record types and their equality semantics, see [Records](../types/records.md#value-equality).

## Tuples use value equality

C# tuples are value types. Two tuples are equal when every element value matches. Element names in a named tuple are a compile-time convenience and aren't considered during comparison. Only positions and values matter:

:::code language="csharp" source="snippets/equality/Program.cs" ID="TupleEquality":::

For more information about tuple syntax and deconstruction, see [Tuples and deconstruction](../types/tuples.md).

## Add value equality to your own types

> [!IMPORTANT]
> This section shows how to implement by hand the equality behavior that the compiler generates when you add `record` to a type. If your type can be a record, use `record` instead. It generates all these members for you. Implement them manually only when your type can't be a record.

When a class or struct represents a value, such as a color or a measurement, you must implement a consistent set of equality members. A correct value-equality type provides all the related members so every equality path agrees. The easiest way to achieve this consistency is to declare the type as a `record`. If you must derive from some non-record class, you need to implement these methods yourself. The language enforces that user-defined `==` and `!=` operators must be declared as a pair. If you provide those operators, compiler warning [CS0660](../../language-reference/compiler-messages/overloaded-operator-errors.md#equality-operators) means the type also needs an <xref:System.Object.Equals*?displayProperty=nameWithType> override. Warning [CS0661](../../language-reference/compiler-messages/overloaded-operator-errors.md#equality-operators) means the type also needs an <xref:System.Object.GetHashCode?displayProperty=nameWithType> override.

In a complete manual implementation, provide these members:

- `==` and `!=` operators. Add them as a pair because the compiler requires a type that overloads one to overload the other.
- An `override` of <xref:System.Object.Equals*>. This override keeps object-level equality consistent.
- An `override` of <xref:System.Object.GetHashCode*>. Objects that are equal must return the same hash code. Without this pairing, the type behaves incorrectly in hash-based collections such as `Dictionary<TKey,TValue>` or `HashSet<T>`. See <xref:System.Object.GetHashCode*> for guidance on a correct implementation.
- Optionally, a typed `Equals` method by implementing <xref:System.IEquatable`1>. You often see this written as `Equals(T?)` in docs: `T` is a [type parameter](../types/generics.md), a placeholder for the current type, and `?` is a [nullable annotation](../null-safety/index.md) that says the argument can be `null`. This typed method can avoid extra conversions when callers already have the same type, but it's a secondary optimization.

The following example starts with the <xref:System.Object.Equals*> and <xref:System.Object.GetHashCode*> overrides, plus the optional typed `Equals` member, so you can see their effect before the `==` and `!=` operators are added. `HashCode.Combine` is a library helper that builds one hash code from the same values used by `Equals`:

:::code language="csharp" source="snippets/equality/Program.cs" ID="ColorDefinition":::

At this point, `Equals` reflects value equality, but `==` still tests identity for the class because the type hasn't declared `==` and `!=` operators. Plain structs likewise still don't have a predefined `==` operator unless you declare one:

:::code language="csharp" source="snippets/equality/Program.cs" ID="IEquatableUsage":::

Adding `==` and `!=` operators is the remaining step when you need operator comparisons. This article intentionally stops before the full operator implementation so the first pass can focus on the equality contract. The operator-focused follow-up shows the completed shape. For the operator syntax, see [Equality operators](../../language-reference/operators/equality-operators.md) in the language reference.

## `Object.ReferenceEquals` — test identity directly

<xref:System.Object.ReferenceEquals*> always tests identity regardless of how a type overrides <xref:System.Object.Equals*> or overloads `==`. Use it when you need to confirm whether two variables point to the exact same object:

:::code language="csharp" source="snippets/equality/Program.cs" ID="ReferenceEqualsDemo":::

A common use is inside an `Equals` override to short-circuit the full comparison: when both arguments are the same reference, they're always equal without checking individual fields.

> [!NOTE]
> Advanced detail: when variables are typed as an [interface](../types/interfaces.md), `==` checks whether the interface variables refer to the same object. A call to `Equals` still runs the underlying object's implementation.

## See also

- [Type system overview](../types/index.md)
- [Classes](../types/classes.md)
- [Structs](../types/structs.md)
- [Records](../types/records.md)
- [Tuples and deconstruction](../types/tuples.md)
- [Equality operators (language reference)](../../language-reference/operators/equality-operators.md)
