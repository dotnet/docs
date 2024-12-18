---
title: "Deconstruction expression - extract properties or fields from a tuple or other type"
description: "Learn about deconstruction expressions: expressions that extract individual properties or fields from a tuple or user defined type into discrete expressions."
ms.date: 12/17/2024
---
# Deconstruction expression - Extract properties of fields from a tuple or other user defined type

A *deconstruction expression* deconstructs data fields in an instance of an object. Each discrete data element is stored in a distinct variable, as shown in the following example:

:::code language="csharp" source="./snippets/shared/Deconstruction.cs" id="TupleDeconstruction":::

The preceding code snippets creates a [tuple](../builtin-types/value-tuples.md) that has two integer values, `X` and `Y`. The second statement *deconstructs* that tuple and stores the tuple elements in discrete variables `x`, and `y`.

## Tuple deconstruction

All [tuple types](../builtin-types/value-tuples.md) support deconstruction expressions. Tuple deconstruction extracts all the tuple's elements. If you only want some of the tuple elements, use a [discard](../tokens/discard.md) for the unused tuple members, as shown in the following example:

:::code language="csharp" source="./snippets/shared/Deconstruction.cs" id="TupleDeconstructionWithDiscard":::

In the preceding example, the `Y` and `label` members are discarded. You can specify multiple discards in the same deconstruction expression.

## Record deconstruction

All [record](../builtin-types/record.md) types that have a [primary constructor](../builtin-types/record.md#positional-syntax-for-property-definition) support deconstruction. The compiler synthesizes a deconstruct method that extracts all properties declared in the primary constructor. Deconstruction for records doesn't extract properties that aren't declared using the primary constructor syntax.

The `record` shown in the following code declares two positional properties, `SquareFeet` and `Address`, along with another property, `RealtorNotes`:

:::code language="csharp" source="./snippets/shared/Deconstruction.cs" id="RecordDeconstruction":::

When you deconstruct a `House` object, all positional properties, and only positional properties, are deconstructed, as shown in the following example:

:::code language="csharp" source="./snippets/shared/Deconstruction.cs" id="RecordDeconstructionUsage":::

You can make use of this behavior to specify which properties of your record types are part of the compiler synthesized `Deconstruct` method.

## Declare `Deconstruct` methods

You can add deconstruct support to any class, struct, or interface you declare. You declare one or `Deconstruct` methods in your type, or as extension methods on that type. A deconstruction expression can resolve to a unique method `void Deconstruct(out var p1, ..., out var pn)`. The `Deconstruct` method can be either an instance method or an extension method. The type of each parameter in the `Deconstruct` method must match the type of the corresponding argument in the deconstruct method. The deconstruction expression assigns the value of each argument to the value of the corresponding `out` parameter in the `Deconstruct` method. If multiple `Deconstruct` methods match the deconstruction expression, the compiler reports an ambiguity.

The following code declares a `Point3D` struct that has two `Deconstruct` methods:

:::code language="csharp" source="./snippets/shared/Deconstruction.cs" id="StructDeconstruction":::

The first method supports deconstruction expressions that extract all three axes values: `X`, `Y`, and `Z`. The second method supports deconstructing only the planar values, `X` and `Y`. The first method has an *arity* of 3, the second has an arity of 2.

The preceding section described the compiler synthesized `Deconstruct` method for `record` types with a primary constructor. You can declare additional `Deconstruct` methods in record types. These can either add additional properties, remove some of the default properties, or both. You can also declare a `Deconstruct` that matches the compiler synthesized signature. If you declare such a `Deconstruct` method, the compiler won't synthesize one.

In most cases, multiple `Deconstruct` methods for the same type have different arities. This isn't a strict requirement. As long as the compiler can determine one unique `Deconstruct` method for a deconstruction expression, the multiple `Deconstruct` methods are allowed. However, in many cases, too many `Deconstruct` methods can lead to ambiguity errors and misleading results.

## C# language specification

For more information, see the following sections of the [C# Standard](~/_csharpstandard/standard/expressions.md#127-deconstruction):

## See also

- [C# operators and expressions](index.md)
- [Tuple types](../builtin-types/value-tuples.md)
- [Records](../builtin-types/record.md)
- [Structure types](../builtin-types/struct.md)
