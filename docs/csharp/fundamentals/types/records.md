---
title: "C# record types"
description: Use record classes for data-focused reference types with positional declarations, generated value equality, and shallow copies through with expressions.
ms.date: 11/16/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# C# record types

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first, then read [C# classes](classes.md).

Use a *record class* for a data-focused reference type when you want the compiler to provide value equality, formatted output, and copy support. The [`record` reference](../../language-reference/builtin-types/record.md) describes the full feature.

Record classes follow the class rules for instances, accessibility, and static members. Assignment copies a reference, not the object. Their generated equality and `with` expressions add behavior without changing that reference-type foundation.

## When to use records

Choose a record class when the type's main purpose is to store data and its members' values should determine equality. For example, two routes with the same start and end can represent equal data even when they're different objects. Prefer an ordinary class when object identity is the equality behavior you need.

Records support init-only properties, but they don't require immutable state. Choose the properties that suit your type; don't assume that `record` makes every reachable object immutable.

Avoid records for entity types in [Entity Framework Core](/ef/core/), which depends on reference equality to track entities.

## Declare a record

Writing `record` alone is shorthand for `record class`:

:::code language="csharp" source="snippets/records/RecordClasses.cs" id="PositionalRecordClass":::

The equivalent declaration starts with `public record class Route`. A *positional record* lists parameters in its declaration, and the compiler uses those parameters to generate a constructor, properties, and deconstruction support.

For `Route`, the compiler normally generates:

- A public constructor that accepts `Start` and `End`.
- Public `Start` and `End` properties with `get` and `init` accessors.
- A `Deconstruct` method that exposes those values in parameter order.
- Equality methods, a hash-code method, and `==` and `!=` operators.
- A `ToString` method that includes the type name and public data members.
- Copy support that `with` expressions use to create another instance.

An *init-only property* permits assignment during object initialization but not through an ordinary assignment afterward. See [`init`](../../language-reference/keywords/init.md) for its rules. An init-only property that holds a reference doesn't make the referenced object immutable.

For accessor mechanics and custom declarations, see [Properties](../classes/properties.md). For initialization mechanics, see [Constructors](../../programming-guide/classes-and-structs/constructors.md). Positional record parameters normally generate properties; ordinary class [primary constructors](../../whats-new/tutorials/primary-constructors.md) don't automatically generate public properties.

You can also declare properties in a record body, including read-write properties:

:::code language="csharp" source="snippets/records/FirstRecord.cs" id="RecordWithBody":::

The [`required`](../../language-reference/keywords/required.md) modifier means you must supply `Name` when you initialize a `Product`. `Name` is init-only, while `Price` can change after initialization because it has a `set` accessor. `record` doesn't change that accessor's behavior.

## Value equality

*Value equality* means that two instances compare equal according to their data rather than their identity. Record classes generate this behavior:

:::code language="csharp" source="snippets/records/RecordClasses.cs" id="RecordClassEquality":::

`outward` and `sameRoute` refer to distinct objects. Their generated `==` operator compares the stored values, so the two routes are equal. An ordinary class without customized equality compares references by default.

The constructor initializes `Start` and `End`. After construction, `outward.End = "West";` doesn't compile because `End` is init-only.

Generated record equality compares the instance fields, including fields that store auto-implemented properties, and requires matching run-time types. Each member's type determines how its value compares. It isn't a recursive comparison of every object reachable from the record.

Use [Equality comparisons](../expressions/equality.md#use-records-for-value-equality) for the full equality lesson and guidance on records with collection members.

## Nondestructive mutation with `with` expressions

*Nondestructive mutation* creates a modified copy instead of changing the original object's members. A [`with` expression](../../language-reference/operators/with-expression.md) creates a record-class copy and applies the specified member initializers:

:::code language="csharp" source="snippets/records/RecordClasses.cs" id="RecordClassWith":::

The expression creates a different `Route` object, even though its properties are init-only. The initializer sets `End` on that new object; `outward.End` stays `"South"`.

### Assignment and shallow copies

For reference-valued members, distinguish a new record object from a new copy of everything it references. Consider a record with an array:

:::code language="csharp" source="snippets/records/RecordClasses.cs" id="ReferenceMemberRecord":::

Assignment shares the record object. A `with` expression creates a different record object but performs a *shallow copy*: it copies member values, including references, without copying the referenced objects.

:::code language="csharp" source="snippets/records/RecordClasses.cs" id="ShallowRecordClassCopy":::

`alias` refers to `original` itself. `copy` is a distinct record object, but all three variables reach the same array. The init-only `Samples` property prevents ordinary replacement of the array reference after initialization; it doesn't prevent changes to array elements.

The records remain equal after the element changes because they hold the same array reference. By default, arrays compare references rather than their elements. A separately allocated array with the same contents doesn't make another record equal:

:::code language="csharp" source="snippets/records/RecordClasses.cs" id="RecordClassArrayEquality":::

For collection equality choices, see [Records with reference-type members](../expressions/equality.md#records-with-reference-type-members).

## Positional records and deconstruction

*Deconstruction* extracts values into separate variables. A positional record's generated `Deconstruct` method supports this syntax:

:::code language="csharp" source="snippets/records/RecordClasses.cs" id="RecordClassDeconstruction":::

See [Deconstruct tuples and other types](../patterns/deconstruct.md) for the complete lesson.

## `record class` vs. `record struct`

The `record` modifier also applies to structs. Use `record struct` to declare a value type:

:::code language="csharp" source="snippets/records/RecordStruct.cs" id="RecordStructDecl":::

A positional `record struct` normally generates read-write properties; a `readonly record struct` normally generates init-only properties. Unlike record-class assignment, record-struct assignment copies the value:

:::code language="csharp" source="snippets/records/RecordStruct.cs" id="RecordClassVsStruct":::

Record structs also support generated value equality and `with` expressions. See [Structs](structs.md) for value-type semantics.

## Record inheritance

A record class can inherit from another record class, but not from an ordinary class other than <xref:System.Object>. An ordinary class can't inherit from a record class. The generated equality includes the run-time type.

For the declaration rules and examples, see [Inheritance in records](../../language-reference/builtin-types/record.md#inheritance). For the underlying class mechanics, see [Inheritance](../object-oriented/inheritance.md).

## Next steps

- [Use record types](../tutorials/records.md) applies records to temperature calculations.
- [Class members and instances](../classes/index.md) explains the class foundation.
- [Records (C# reference)](../../language-reference/builtin-types/record.md) supplies the detailed rules.
