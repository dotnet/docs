---
title: "Resolve errors and warnings related to union type declarations"
description: "This article helps you diagnose and correct compiler errors and warnings related to union type declarations"
f1_keywords:
  - "CS9369"
  - "CS9370"
  - "CS9371"
  - "CS9372"
  - "CS9373"
  - "CS9374"
  - "CS9375"
helpviewer_keywords:
  - "CS9369"
  - "CS9370"
  - "CS9371"
  - "CS9372"
  - "CS9373"
  - "CS9374"
  - "CS9375"
ms.date: 04/03/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings for union type declarations

The C# compiler generates errors when you misuse [union types](../builtin-types/union.md). Union types represent a value that can be one of several *case types*, with implicit conversions and exhaustive pattern matching. These diagnostics help you follow the rules for declaring and using union types.

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

- [**CS9369**](#expression-and-pattern-limitations): *An expression tree may not contain a union conversion.*
- [**CS9370**](#union-declaration-requirements): *A union declaration must specify at least one case type.*
- [**CS9371**](#union-declaration-requirements): *Cannot convert type 'type' to 'object' via an implicit reference or boxing conversion*
- [**CS9372**](#expression-and-pattern-limitations): *An expression of type 'type' cannot be handled by this pattern, see additional errors at this location.*
- [**CS9373**](#union-member-restrictions): *Instance fields, auto-properties or field-like events are not permitted in a 'union' declaration.*
- [**CS9374**](#union-member-restrictions): *Explicitly declared public constructors with a single parameter are not permitted in a 'union' declaration.*
- [**CS9375**](#union-member-restrictions): *A constructor declared in a 'union' declaration must have a 'this' initializer that calls a synthesized constructor or an explicitly declared constructor.*

## Union declaration requirements

- **CS9370**: *A union declaration must specify at least one case type.*
- **CS9371**: *Cannot convert type 'type' to 'object' via an implicit reference or boxing conversion*

A [union declaration](../builtin-types/union.md#union-declarations) specifies a name and a list of case types. These errors enforce the structural requirements of a valid union declaration. For the complete rules, see the [union types feature specification](~/_csharplang/proposals/unions.md).

To correct these errors, apply the following changes to your union declaration:

- Add at least one case type to the union's type list (**CS9370**). A union must have one or more case types because the union's purpose is to represent a closed set of alternatives. A declaration like `union Empty()` with no case types isn't meaningful.
- Change or remove case types that don't convert to `object` via an implicit reference or boxing conversion (**CS9371**). Union types store their contents as a single `object?` reference, so every case type must be convertible to `object`. Types like pointers or `ref struct` types don't satisfy this requirement. Replace them with a wrapper type that can be boxed or stored as a reference.

## Union member restrictions

- **CS9373**: *Instance fields, auto-properties or field-like events are not permitted in a 'union' declaration.*
- **CS9374**: *Explicitly declared public constructors with a single parameter are not permitted in a 'union' declaration.*
- **CS9375**: *A constructor declared in a 'union' declaration must have a 'this' initializer that calls a synthesized constructor or an explicitly declared constructor.*

A [union declaration](../builtin-types/union.md#union-declarations) can include a body with additional members, but the compiler restricts what you can declare. These restrictions ensure that the compiler-generated conversion constructors and storage mechanism work correctly. For the complete rules, see the [union types feature specification](~/_csharplang/proposals/unions.md).

To correct these errors, apply the following changes to your union members:

- Remove instance fields, auto-implemented properties, and field-like events from the union body (**CS9373**). A union doesn't define new data members—it composes existing types into a closed set of alternatives. Declare any additional state in the case types themselves or use static members on the union.
- Remove or change the accessibility of any explicitly declared public constructor that takes a single parameter (**CS9374**). The compiler generates a public single-parameter constructor for each case type to support implicit union conversions. An explicit constructor with the same shape would conflict with those generated constructors. If you need a single-parameter constructor, make it `internal` or `private`.
- Add a `this` initializer to any explicitly declared constructor so that it chains to a synthesized constructor or another explicitly declared constructor (**CS9375**). The compiler-generated constructors initialize the union's internal storage correctly. Constructors that don't chain through them might leave the union in an invalid state. Use `: this(someValue)` to chain to a generated case-type constructor, or `: this()` to chain to an explicit parameterless constructor you've declared.

## Expression and pattern limitations

- **CS9369**: *An expression tree may not contain a union conversion.*
- **CS9372**: *An expression of type 'type' cannot be handled by this pattern, see additional errors at this location.*

These errors arise when you use union types in contexts that the compiler can't fully support. For the complete rules on union conversions and pattern matching, see [union conversions](../builtin-types/union.md#union-conversions) and [union matching](../builtin-types/union.md#union-matching).

To correct these errors, apply the following changes:

- Move the union conversion out of the expression tree (**CS9369**). Expression trees can't represent union conversions because they rely on compiler-generated constructors that have no equivalent in the `System.Linq.Expressions` API. Perform the conversion before passing the value into the expression tree, or restructure the code to avoid expression trees for that operation.
- Use the correct pattern form when matching against a union value (**CS9372**). Patterns on a union apply to the union's `Value` property, not the union value itself. If the compiler reports that a pattern can't handle the expression, check that you're matching against the case types listed in the union declaration. Review the additional errors at the same location for details about which pattern is invalid.
