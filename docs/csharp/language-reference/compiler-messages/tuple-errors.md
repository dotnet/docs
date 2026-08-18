---
title: "Resolve errors and warnings related to tuples"
description: "This article helps you diagnose and correct compiler errors and warnings related to tuple declarations, element names, metadata, conversions, equality, type inference, and pattern matching."
f1_keywords:
  - "CS8123"
  - "CS8124"
  - "CS8125"
  - "CS8126"
  - "CS8127"
  - "CS8128"
  - "CS8135"
  - "CS8137"
  - "CS8138"
  - "CS8139"
  - "CS8140"
  - "CS8141"
  - "CS8142"
  - "CS8179"
  - "CS8182"
  - "CS8210"
  - "CS8307"
  - "CS8383"
  - "CS8384"
  - "CS8516"
  - "CS8522"
helpviewer_keywords:
  - "CS8123"
  - "CS8124"
  - "CS8125"
  - "CS8126"
  - "CS8127"
  - "CS8128"
  - "CS8135"
  - "CS8137"
  - "CS8138"
  - "CS8139"
  - "CS8140"
  - "CS8141"
  - "CS8142"
  - "CS8179"
  - "CS8182"
  - "CS8210"
  - "CS8307"
  - "CS8383"
  - "CS8384"
  - "CS8516"
  - "CS8522"
ms.date: 08/17/2026
ai-usage: ai-assisted
---

# Resolve errors and warnings for tuples

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because it doesn't use contractions.
That's by design. The text closely matches the text of the compiler error or warning for SEO purposes.
 -->

- [**CS8123**](#tuple-element-names): *The tuple element name 'name' is ignored because a different name or no name is specified by the target type 'type'.*
- [**CS8124**](#tuple-structure-and-literals): *Tuple must contain at least two elements.*
- [**CS8125**](#tuple-element-names): *Tuple element name 'name' is only allowed at position N.*
- [**CS8126**](#tuple-element-names): *Tuple element name 'name' is disallowed at any position.*
- [**CS8127**](#tuple-element-names): *Tuple element names must be unique.*
- [**CS8128**](#valuetuple-infrastructure): *Member 'member' was not found on type 'type' from assembly 'assembly'.*
- [**CS8135**](#tuple-structure-and-literals): *Tuple with 'count' elements cannot be converted to type 'type'.*
- [**CS8137**](#tuple-metadata): *Cannot define a class or member that utilizes tuples because the compiler required type 'type' cannot be found. Are you missing a reference?*
- [**CS8138**](#tuple-metadata): *Cannot reference 'System.Runtime.CompilerServices.TupleElementNamesAttribute' explicitly. Use the tuple syntax to define tuple names.*
- [**CS8139**](#tuple-element-names-in-type-hierarchy): *'member': cannot change tuple element names when overriding inherited member 'base member'.*
- [**CS8140**](#tuple-element-names-in-type-hierarchy): *'interface' is already listed in the interface list on type 'type' with different tuple element names, as 'alias'.*
- [**CS8141**](#tuple-element-names-in-type-hierarchy): *The tuple element names in the signature of method 'method' must match the tuple element names of interface method 'interface method' (including on the return type).*
- [**CS8142**](#tuple-element-names-in-type-hierarchy): *Both partial member declarations, 'member' and 'other partial', must use the same tuple element names.*
- [**CS8179**](#valuetuple-infrastructure): *Predefined type 'type' is not defined or imported.*
- [**CS8182**](#valuetuple-infrastructure): *Predefined type 'type' must be a struct.*
- [**CS8210**](#tuple-structure-and-literals): *A tuple may not contain a value of type 'void'.*
- [**CS8307**](#tuple-type-inference): *The first operand of an 'as' operator may not be a tuple literal without a natural type.*
- [**CS8383**](#tuple-equality): *The tuple element name 'name' is ignored because a different name or no name is specified on the other side of the tuple == or != operator.*
- [**CS8384**](#tuple-equality): *Tuple types used as operands of an == or != operator must have matching cardinalities. But this operator has tuple types of cardinality 'left' on the left and 'right' on the right.*
- [**CS8516**](#pattern-matching-with-tuples): *The name 'name' does not identify tuple element 'element'.*
- [**CS8522**](#pattern-matching-with-tuples): *Element names are not permitted when pattern-matching via 'System.Runtime.CompilerServices.ITuple'.*

## Tuple element names

- **CS8123**: *The tuple element name 'name' is ignored because a different name or no name is specified by the target type 'type'.*
- **CS8125**: *Tuple element name 'name' is only allowed at position N.*
- **CS8126**: *Tuple element name 'name' is disallowed at any position.*
- **CS8127**: *Tuple element names must be unique.*

The compiler warns when tuple element names conflict with the target type or constraints. The compiler ignores names in tuple literals during type conversion. If the target type expects different names or no names, rename the tuple literal to match the target type or change the target type (**CS8123**). `ItemN` names are reserved for their specific positions (`Item1` at position 1, `Item2` at position 2, and so on). Reorder elements or use custom names (**CS8125**). Names like `Rest`, `ToString`, `GetHashCode`, and `Equals` are reserved for `ValueTuple` infrastructure and can't be used as element names. Choose a different name (**CS8126**). Ensure all element names within a tuple are distinct. Rename any duplicates (**CS8127**).

## Tuple element names in type hierarchy

- **CS8139**: *'member': cannot change tuple element names when overriding inherited member 'base member'.*
- **CS8140**: *'interface' is already listed in the interface list on type 'type' with different tuple element names, as 'alias'.*
- **CS8141**: *The tuple element names in the signature of method 'method' must match the tuple element names of interface method 'interface method' (including on the return type).*
- **CS8142**: *Both partial member declarations, 'member' and 'other partial', must use the same tuple element names.*

Tuple element names are part of method signatures and must be consistent across inheritance, interface implementation, and partial declarations. Match tuple element names in overriding methods to the base member (**CS8139**). Align element names across all base types and interface implementations so that all inheritance paths to the same generic interface use matching element names (**CS8140**). Match element names in interface implementations to the interface declaration, for both parameters and return types (**CS8141**). Update one partial declaration to match the other exactly (**CS8142**).

## Tuple metadata

- **CS8137**: *Cannot define a class or member that utilizes tuples because the compiler required type 'type' cannot be found. Are you missing a reference?*
- **CS8138**: *Cannot reference 'System.Runtime.CompilerServices.TupleElementNamesAttribute' explicitly. Use the tuple syntax to define tuple names.*

When a type signature includes named tuples, the compiler must reference `TupleElementNamesAttribute` to store element names in metadata. Ensure your project references a .NET runtime that provides `System.Runtime.CompilerServices.TupleElementNamesAttribute`, or add the `System.Runtime` NuGet package for older frameworks (**CS8137**). Use tuple literal syntax with element names—for example, `(int x, string y)`—instead of explicitly referencing the attribute. The compiler generates the metadata automatically (**CS8138**).

## ValueTuple infrastructure

- **CS8128**: *Member 'member' was not found on type 'type' from assembly 'assembly'.*
- **CS8179**: *Predefined type 'type' is not defined or imported.*
- **CS8182**: *Predefined type 'type' must be a struct.*

These errors occur when the compiler can't find or validate required <Xref:System.ValueTuple?displayProperty=fullName> types that underlie tuple syntax. Add the `System.ValueTuple` NuGet package for frameworks that don't include it built-in (for example, older .NET Framework versions) (**CS8179**). Verify that `ValueTuple` types are structs, not classes. If a custom class shadows system types, remove or rename it (**CS8182**). If a specific member (`Item1`, `Item2`, `Rest`) is missing from the predefined `ValueTuple` type, verify that your project references the correct runtime or NuGet package version (**CS8128**).

## Tuple structure and literals

- **CS8124**: *Tuple must contain at least two elements.*
- **CS8135**: *Tuple with 'count' elements cannot be converted to type 'type'.*
- **CS8210**: *A tuple may not contain a value of type 'void'.*

These errors relate to tuple expression formation. Tuples require at least two elements; convert single-element or zero-element tuples to two or more elements (**CS8124**). Ensure tuple literals have the same element count as the destination type (**CS8135**). Remove `void`-returning method calls from tuple elements; tuples can only contain values, not `void` results (**CS8210**).

## Tuple type inference

- **CS8307**: *The first operand of an 'as' operator may not be a tuple literal without a natural type.*

**CS8307** occurs when a tuple literal without explicit element types is used as the left operand of an `as` operator. Assign the literal to a typed variable first, then apply `as` to the variable, or annotate the tuple with an explicit type before using `as` (**CS8307**).

## Tuple equality

- **CS8383**: *The tuple element name 'name' is ignored because a different name or no name is specified on the other side of the tuple == or != operator.*
- **CS8384**: *Tuple types used as operands of an == or != operator must have matching cardinalities. But this operator has tuple types of cardinality 'left' on the left and 'right' on the right.*

**CS8383** is a warning when `==` or `!=` operands have different or absent element names. Names don't affect equality semantics (comparison is positional), but mismatches often indicate naming inconsistency. Align element names on both sides or use unnamed tuples (**CS8383**). **CS8384** occurs when `==` or `!=` operands have different numbers of elements. Adjust tuple literals or types so both operands have the same element count (**CS8384**).

## Pattern matching with tuples

- **CS8516**: *The name 'name' does not identify tuple element 'element'.*
- **CS8522**: *Element names are not permitted when pattern-matching via 'System.Runtime.CompilerServices.ITuple'.*

**CS8516** occurs when a tuple pattern uses a property name that doesn't match any element of the tuple type. Verify the element names of the tuple type and correct the pattern property name. **CS8522** occurs when a positional pattern uses named subpatterns against a type that implements <xref:System.Runtime.CompilerServices.ITuple> but isn't a known tuple type. Remove element names from the pattern and match positionally.

## See also

- [Value tuples](../builtin-types/value-tuples.md)
- [Deconstruction](../../fundamentals/functional/deconstruct.md)
- [Pattern matching](../../fundamentals/functional/pattern-matching.md)
- [Void](../builtin-types/void.md)
