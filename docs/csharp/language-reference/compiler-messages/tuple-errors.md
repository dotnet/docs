---
title: "Resolve errors and warnings related to tuples"
description: "This article helps you diagnose and correct compiler errors and warnings related to tuple names, metadata, conversions, and equality"
f1_keywords:
  - CS8123
  - CS8126
  - CS8128
  - CS8135
  - CS8137
  - CS8138
  - CS8179
  - CS8182
  - CS8307
  - CS8383
  - CS8384
helpviewer_keywords:
  - CS8123
  - CS8126
  - CS8128
  - CS8135
  - CS8137
  - CS8138
  - CS8179
  - CS8182
  - CS8307
  - CS8383
  - CS8384
ms.date: 08/17/2026
ai-usage: ai-assisted
---

# Resolve errors and warnings for tuples

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

- [**CS8123**](#tuple-element-name-conflicts): *The tuple element name 'name' is ignored because a different name or no name is specified by the target type 'type'.*
- [**CS8126**](#tuple-element-names-reserved): *Tuple element name 'name' is disallowed at any position.*
- [**CS8128**](#valuetuple-types-missing): *Member 'member' was not found on type 'type' from assembly 'assembly'.*
- [**CS8135**](#tuple-cardinality-mismatch): *Tuple with 'count' elements cannot be converted to type 'type'.*
- [**CS8137**](#tuple-names-attribute-unavailable): *Cannot define a class or member that utilizes tuples because the compiler required type 'type' cannot be found. Are you missing a reference?*
- [**CS8138**](#tuple-names-attribute-unavailable): *Cannot reference 'System.Runtime.CompilerServices.TupleElementNamesAttribute' explicitly. Use the tuple syntax to define tuple names.*
- [**CS8179**](#valuetuple-types-missing): *Predefined type 'type' is not defined or imported*
- [**CS8182**](#valuetuple-types-missing): *Predefined type 'type' must be a struct.*
- [**CS8307**](#tuple-literal-type-inference): *The first operand of an 'as' operator may not be a tuple literal without a natural type.*
- [**CS8383**](#tuple-equality-element-name-conflicts): *The tuple element name 'name' is ignored because a different name or no name is specified on the other side of the tuple == or != operator.*
- [**CS8384**](#tuple-equality-cardinality-mismatch): *Tuple types used as operands of an == or != operator must have matching cardinalities. But this operator has tuple types of cardinality 'left' on the left and 'right' on the right.*

## Tuple element names and conflicts

### Tuple element name conflicts

- **CS8123**: *The tuple element name 'name' is ignored because a different name or no name is specified by the target type 'type'.*
- **CS8383**: *The tuple element name 'name' is ignored because a different name or no name is specified on the other side of the tuple == or != operator.*

The compiler warns when a tuple literal provides element names but the target type expects different names or no names. This can happen when assigning to a tuple type with unnamed elements or when comparing tuples with mismatched element names.

To resolve these warnings:

- If the element names in your tuple literal don't match the target type, either remove the names from the tuple literal or change the target type to use the same names (**CS8123**).
- When comparing tuples with the `==` or `!=` operator, ensure both operands have matching element names or both have no names. If you intentionally want to compare tuples with different naming conventions, ignore this warning (**CS8383**).

### Tuple element names reserved

- **CS8126**: *Tuple element name 'name' is disallowed at any position.*

Certain element names like `Rest` and `ToString` are reserved for internal tuple structure and cannot be used as tuple element names. The C# compiler requires these names to be available on the tuple's underlying `ValueTuple` type.

To resolve this error:

- Choose a different name for the tuple element. Avoid reserved names like `Rest`, `ToString`, and other members of the `System.Runtime.CompilerServices.ITuple` interface (**CS8126**).

## Tuple metadata and infrastructure

### Tuple names attribute unavailable

- **CS8137**: *Cannot define a class or member that utilizes tuples because the compiler required type 'type' cannot be found. Are you missing a reference?*
- **CS8138**: *Cannot reference 'System.Runtime.CompilerServices.TupleElementNamesAttribute' explicitly. Use the tuple syntax to define tuple names.*

When a type signature includes named tuples, the compiler must be able to reference the `TupleElementNamesAttribute` to store the element names in metadata. Errors occur when this attribute is unavailable or when you explicitly reference it in source code.

To resolve these errors:

- For **CS8137**: Ensure you have a reference to the .NET runtime that provides `System.Runtime.CompilerServices.TupleElementNamesAttribute`. This attribute is included in the `System.Runtime` NuGet package on older frameworks. Add the reference and rebuild (**CS8137**).
- For **CS8138**: Use tuple literal syntax with element names (`(int x, string y)`) rather than explicitly writing `[TupleElementNames(...)]`. The compiler automatically generates the attribute metadata when it encounters named tuples in your code (**CS8138**).

### ValueTuple types missing

- **CS8179**: *Predefined type 'type' is not defined or imported*
- **CS8182**: *Predefined type 'type' must be a struct.*
- **CS8128**: *Member 'member' was not found on type 'type' from assembly 'assembly'.*

These errors occur when the compiler cannot find the required `System.ValueTuple` or related tuple infrastructure types, or when a referenced tuple type doesn't match the expected structure.

To resolve these errors:

- For **CS8179**: Ensure your project references the .NET runtime that provides `System.ValueTuple`. This type is built into .NET Framework 4.7+, .NET Core, and .NET 5+. For older frameworks, add a reference to the `System.ValueTuple` NuGet package (**CS8179**).
- For **CS8182**: Verify that the `ValueTuple` type in your referenced assembly is defined as a `struct`. This is the expected implementation. If a custom `ValueTuple` type exists in your codebase, ensure it's a `struct` type (**CS8182**).
- For **CS8128**: The tuple infrastructure expects specific members (such as `Item1`, `Item2`, and `Rest` for large tuples) on the predefined `ValueTuple` types. This error indicates a mismatch between what the compiler expects and what was found in the referenced assembly. Verify that you're referencing the correct version of the runtime (**CS8128**).

## Tuple conversions and literals

### Tuple cardinality mismatch

- **CS8135**: *Tuple with 'count' elements cannot be converted to type 'type'.*

The compiler reports this error when you attempt to assign or convert a tuple with one number of elements to a type expecting a different number of elements.

To resolve this error:

- Ensure that the tuple literal has the same number of elements as the target tuple type. If converting from a tuple with 2 elements to a type expecting 3 elements, add or remove elements as needed (**CS8135**).

### Tuple literal type inference

- **CS8307**: *The first operand of an 'as' operator may not be a tuple literal without a natural type.*

The `as` operator requires type information to work correctly. A bare tuple literal without explicit type annotation doesn't have a "natural type" that the compiler can infer, so you cannot use it directly as the left operand of `as`.

To resolve this error:

- Provide an explicit type annotation for the tuple literal. Cast it to the desired type first: `((int x, string y) as object)` or `((int, string) tuple as object)` (**CS8307**).
- Alternatively, assign the tuple to a variable first: `var t = (1, "hello"); var obj = t as object;`

## Tuple equality

### Tuple equality element name conflicts

- **CS8383**: *The tuple element name 'name' is ignored because a different name or no name is specified on the other side of the tuple == or != operator.*

When comparing two tuples with the `==` or `!=` operator, the compiler warns if the tuples have mismatched element names. Element names don't affect runtime equality, but the mismatch suggests a potential logical error.

To resolve this warning:

- Ensure both tuples in the comparison have the same element names or both have no names. For example, compare `(int x, string y)` with `(int x, string y)`, not with `(int a, string b)`.
- If the naming mismatch is intentional, you can suppress the warning or document the reason in your code.

### Tuple equality cardinality mismatch

- **CS8384**: *Tuple types used as operands of an == or != operator must have matching cardinalities. But this operator has tuple types of cardinality 'left' on the left and 'right' on the right.*

You cannot use the `==` or `!=` operator to compare tuples with different numbers of elements. Tuples of different sizes are fundamentally incompatible types.

To resolve this error:

- Ensure both tuples have the same number of elements. Adjust your tuple literals or variable declarations to match the expected cardinality (**CS8384**).
- If you need to compare tuples of different sizes, consider comparing individual elements or converting one tuple's structure to match the other.

## See also

- [Value tuples](../builtin-types/value-tuples.md)
- [Deconstruction](../../fundamentals/functional/deconstruct.md)
- [Pattern matching](../../fundamentals/functional/pattern-matching.md)

