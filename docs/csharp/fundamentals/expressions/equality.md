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
> **Coming from another language?** In Java, `==` on objects and JavaScript `===` on objects test identity, not content. C# classes work the same way by default. In Python, `==` calls `__eq__` and tests content by default , similar to how C# [records](../types/records.md) compare. C# [structs](../types/structs.md) also compare by value when you call `Equals`.

C# distinguishes two kinds of equality. *Value equality* means two instances are equal when their data matches. *Reference equality* means two variables are equal only when they point to the same object in memory. This condition is also called *identity*. The kind of type gives you the best first clue about the default equality behavior: value types usually compare data, and reference types usually compare identity. Defaults aren't destiny, but that mental model prevents subtle bugs where two objects that look identical aren't considered equal, or where a mutation through one variable silently changes what another variable sees.

## Value types, reference types, and equality defaults

Every type in C# is either a *value type* or a *reference type*. A *value type* holds its data directly in the variable. A *reference type* holds a reference to an object. When you assign a reference-type variable to another variable, both variables refer to the same object. This article uses that distinction as a quick refresher. For more information about value types and reference types, see [Type system overview](../types/index.md#value-types-and-reference-types).

The default equality behavior usually follows the kind of type:

- **Built-in numeric types and [enums](../types/enums.md)** are value types. Two `int` variables are equal when their numeric values match.
- **[Structs](../types/structs.md)** are value types. A plain `struct` uses value equality when you call <xref:System.Object.Equals*>.
- **[Tuples](../types/tuples.md)** are value types. Two tuples are equal when all their element values match.
- **[Classes](../types/classes.md)** are reference types. A plain class uses reference equality, so `==` and <xref:System.Object.Equals*> test whether two variables point to the same object.

A plain class shows reference equality. Two separate objects with the same data aren't equal, but two variables that refer to the same object are equal:

:::code language="csharp" source="snippets/equality/Program.cs" ID="ClassEquality":::

A plain `struct` shows value equality through <xref:System.Object.Equals*>. Two struct instances are equal when their fields match:

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
> Advanced detail: when variables are typed as an [interface](../types/interfaces.md), `==` checks whether the interface variables refer to the same object. A call to `Equals` still runs the underlying object's implementation.

> [!NOTE]
> <xref:System.Object.ReferenceEquals*> always returns `false` when comparing value types, even if both arguments contain the same values. This is because each value-type argument is independently *boxed* into a separate heap object when passed to `ReferenceEquals`.

## Types can define different equality semantics

Defaults aren't destiny. Some types define equality semantics that differ from the type-kind default, and your own types can do the same when their data should determine equality.

Common exceptions and customizations include:

- **[Records](../types/records.md)** generate value equality and include `==`/`!=` operators. The next section shows how the `record` modifier gives value equality to both record classes and record structs.
- **Strings** are classes, but `==` and <xref:System.Object.Equals*> compare string content, not identity.
- **Your own classes and structs** can define value equality when their data should determine equality.

Equality is woven through these related members:

- `==`: the equality operator. Most types use this as the primary equality check. Its behavior depends on whether the type has a built-in or user-defined `==` operator.
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

## Records with reference-type members

Record equality is synthesized from the members' own equality. Each property or field is compared using its own `Equals` method. For most scalar values—`int`, `string`, `DateTime`, and similar types—that works exactly as you'd expect. The subtlety arises with common mutable collections such as `List<T>` or `T[]`: these types compare by reference, so two record instances that contain *different list objects with the same content* are **not** considered equal by the synthesized record equality.

:::code language="csharp" source="snippets/equality/Program.cs" ID="RecordWithCollectionProblem":::

`playlist1` and `playlist2` are separate `List<string>` instances. Even though their contents match, `Equals` returns `false`.

When you need two-record equality to reflect collection *contents*, you have a few options:

- **Custom `IEquatable<T>` override**: Implement `IEquatable<T>` on the record and use <xref:System.Linq.Enumerable.SequenceEqual*?displayProperty=nameWithType> (or an appropriate comparison) for the collection members.

  :::code language="csharp" source="snippets/equality/Program.cs" ID="PlaylistFixedDefinition":::

  :::code language="csharp" source="snippets/equality/Program.cs" ID="RecordWithCollectionFixed":::

- **Use collection types with value equality**: <xref:System.Collections.Immutable.ImmutableArray`1?displayProperty=nameWithType> doesn't override equality either, but a record that wraps a `ReadOnlySpan<T>` or uses `SequenceEqual` in a custom `Equals` achieves the same goal. The key insight is to pick the right abstraction rather than fighting the defaults.

- **Design around identity**: If the record represents an entity rather than a value—and the collection members are logically shared—then reference equality for those members may be intentional. Design the type to reuse the same list instance where equality matters.

## Implement equality yourself when a type can't be a record

> [!IMPORTANT]
> This section shows how to implement by hand the equality behavior that the compiler generates when you add `record` to a type. If your type can be a record, use `record` instead. It generates all these members for you. Implement them manually only when your type can't be a record. Correctly implementing all the requirements for equality requires you to understand the expectations for these operations. This section contains all those rules. While those seem complicated remember that you can almost always use a `record` type and have the language automatically create implementations that comply with all these requirements.

When a class or struct represents a value, such as a color or a measurement, the equality members for that type must agree. The easiest way to achieve this consistency is to declare the type as a `record`. If the type can't be a record, such as when it must derive from a non-record class, implement the equality members yourself. The language enforces that user-defined `==` and `!=` operators must be declared as a pair. If you provide those operators, compiler warning [CS0660](../../language-reference/compiler-messages/overloaded-operator-errors.md#equality-operators) means the type also needs an <xref:System.Object.Equals*?displayProperty=nameWithType> override. Warning [CS0661](../../language-reference/compiler-messages/overloaded-operator-errors.md#equality-operators) means the type also needs an <xref:System.Object.GetHashCode*?displayProperty=nameWithType> override.

In a complete manual implementation, provide these members:

- `==` and `!=` operators. Add them as a pair because the compiler requires a type that overloads one to overload the other.
- An `override` of <xref:System.Object.Equals*>. This override changes equality semantics for the type and keeps object-level equality consistent.
- An `override` of <xref:System.Object.GetHashCode*>. Objects that are equal must return the same hash code. Without this pairing, the type behaves incorrectly in hash-based collections such as `Dictionary<TKey,TValue>` or `HashSet<T>`. See <xref:System.Object.GetHashCode*> for guidance on a correct implementation.
- Optionally, a typed `Equals` method by implementing <xref:System.IEquatable`1>. You often see this written as `Equals(T?)` in docs: `T` is a [type parameter](../types/generics.md), a placeholder for the current type, and `?` is a [nullable annotation](../null-safety/index.md) that says the argument can be `null`. This typed method can avoid extra conversions when callers already have the same type, but it's a secondary optimization.

A correct implementation also satisfies the *equivalence contract*. The following rules assume `x`, `y`, and `z` are not null:

1. **Reflexive**: `x.Equals(x)` returns `true`.
2. **Symmetric**: `x.Equals(y)` returns the same value as `y.Equals(x)`.
3. **Transitive**: if `x.Equals(y)` and `y.Equals(z)` are both `true`, then `x.Equals(z)` must be `true`.
4. **Consistent**: successive calls to `x.Equals(y)` return the same value as long as neither object changes.
5. **Null behavior**: `x.Equals(null)` returns `false`; `x.Equals(y)` must not throw when called on a non-null `x`.

The symmetric and transitive rules are easy to violate in inheritance hierarchies. See [Polymorphic equality in unsealed class hierarchies](#polymorphic-equality-in-unsealed-class-hierarchies) for guidance.

The following example starts with the <xref:System.Object.Equals*> and <xref:System.Object.GetHashCode*> overrides, plus the optional typed `Equals` member, so you can see their effect before the `==` and `!=` operators are added. `HashCode.Combine` is a library helper that builds one hash code from the same values used by `Equals`:

:::code language="csharp" source="snippets/equality/Program.cs" ID="ColorDefinition":::

At this point, `Equals` reflects value equality, but `==` still tests identity for the class because the type hasn't declared `==` and `!=` operators. Plain structs likewise still don't have a predefined `==` operator unless you declare one:

:::code language="csharp" source="snippets/equality/Program.cs" ID="IEquatableUsage":::

Adding `==` and `!=` operators is the remaining step when you need operator comparisons. This article intentionally stops before the full operator implementation so the first pass can focus on the equality contract. The operator-focused follow-up shows the completed shape. For the operator syntax, see [Equality operators](../../language-reference/operators/equality-operators.md) in the language reference.

## Polymorphic equality in unsealed class hierarchies

Implementing value equality in an unsealed class hierarchy requires extra care. The hazard is that `IEquatable<T>.Equals(T? other)` is dispatched at compile time based on the *declared type* of the variable, not the runtime type. If `TwoDPoint` declares a non-virtual `Equals(TwoDPoint? other)`, then a variable declared as `TwoDPoint` but holding a `ThreeDPoint` at runtime calls `TwoDPoint.Equals`, silently ignoring the extra dimension. The result is that two points with different `Z` values incorrectly compare as equal.

**The fix**: make the typed `Equals` method `virtual` and add a `GetType() == other.GetType()` guard. This ensures that objects of different runtime types are never considered equal, regardless of the declared type of the variable.

:::code language="csharp" source="snippets/equality/Program.cs" ID="PolymorphicEqualityDefinition":::

Usage with a variable declared as the base type:

:::code language="csharp" source="snippets/equality/Program.cs" ID="PolymorphicEqualityUsage":::

Key points for unsealed class hierarchies:

- **`GetType()` guard**: including `GetType() == other.GetType()` in the base class `Equals` prevents a `Circle` from comparing equal to a `Square` with the same color, and prevents a `Circle` from comparing equal to a `Shape` base with the same color.
- **`virtual` on the typed `Equals`**: lets each derived class augment the comparison with its own fields by calling `base.Equals(other)`.
- **`GetHashCode` must include `GetType()`**: two objects are only considered equal when their runtime types match, so `GetHashCode` must reflect that. `HashCode.Combine(GetType(), ...)` achieves this.
- **Sealed classes are simpler**: a `sealed` class can't be subclassed, so compile-time and runtime types always agree. The standard `IEquatable<T>` pattern shown for `Color` earlier in this article is correct and complete for sealed classes without any virtual dispatch.

> [!TIP]
> Records handle inheritance correctly out of the box. When a base record and a derived record are both compared using `==` or `Equals`, the compiler-generated equality checks both the runtime type and all declared properties. Prefer `record` over a manual unsealed-class hierarchy when value equality is your goal.

## See also

- [Type system overview](../types/index.md)
- [Classes](../types/classes.md)
- [Structs](../types/structs.md)
- [Records](../types/records.md)
- [Tuples and deconstruction](../types/tuples.md)
- [Equality operators (language reference)](../../language-reference/operators/equality-operators.md)
- [Arithmetic, comparison, logical, and assignment operators](operators.md) — the equality operator survey alongside arithmetic, logical, and assignment operators
