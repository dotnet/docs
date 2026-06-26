---
title: "Resolve errors and warnings related to union type and closed hierarchy declarations"
description: "This article helps you diagnose and correct compiler errors and warnings related to union type and closed hierarchy declarations."
f1_keywords:
  - "CS9370"
  - "CS9371"
  - "CS9373"
  - "CS9374"
  - "CS9375"
  - "CS9380"
  - "CS9381"
  - "CS9382"
  - "CS9383"
  - "CS9384"
  - "CS9385"
  - "CS9386"
  - "CS9387"
helpviewer_keywords:
  - "CS9370"
  - "CS9371"
  - "CS9373"
  - "CS9374"
  - "CS9375"
  - "CS9380"
  - "CS9381"
  - "CS9382"
  - "CS9383"
  - "CS9384"
  - "CS9385"
  - "CS9386"
  - "CS9387"
ms.date: 06/26/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings for union type and closed hierarchy declarations

The C# compiler generates errors when you misuse [union types](../builtin-types/union.md) or closed type hierarchies. Union types represent a value that can be one of several *case types*, with implicit conversions and exhaustive pattern matching. Closed hierarchies restrict which types can derive from a base type. These diagnostics help you follow the rules for declaring and using union types and closed hierarchies.

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

- [**CS9370**](#union-declaration-requirements): *A union declaration must specify at least one case type.*
- [**CS9371**](#union-declaration-requirements): *Cannot convert type to 'object' via an implicit reference or boxing conversion.*
- [**CS9373**](#union-member-restrictions): *Instance fields, auto-properties, or field-like events are not permitted in a 'union' declaration.*
- [**CS9374**](#union-member-restrictions): *Explicitly declared public constructors with a single parameter are not permitted in a 'union' declaration.*
- [**CS9375**](#union-member-restrictions): *A constructor declared in a 'union' declaration must have a 'this' initializer that calls a synthesized constructor or an explicitly declared constructor.*
- [**CS9380**](#closed-hierarchy-restrictions): *Types and aliases cannot be named 'closed'.*
- [**CS9381**](#closed-hierarchy-restrictions): *'type': a closed type cannot be sealed or static*
- [**CS9382**](#closed-hierarchy-restrictions): *'type': cannot use a closed type 'type' from another assembly as a base type.*
- [**CS9383**](#closed-hierarchy-restrictions): *'type': The type parameter 'parameter' must be referenced in the base type 'type' because the base type is closed.*
- [**CS9384**](#closed-hierarchy-restrictions): *'type': a closed type cannot be marked abstract because it is always implicitly abstract.*
- [**CS9385**](#union-member-provider-requirements): *A union type must have at least one union creation member.*
- [**CS9386**](#union-member-provider-requirements): *A union member provider type must have an instance 'Value' property of type 'object?' or 'object'. The property must have a public get accessor.*
- [**CS9387**](#union-member-provider-requirements): *A 'union' declaration cannot use a union member provider interface.*

## Union declaration requirements

- **CS9370**: *A union declaration must specify at least one case type.*
- **CS9371**: *Cannot convert type to 'object' via an implicit reference or boxing conversion.*

A [union declaration](../builtin-types/union.md#union-declarations) specifies a name and a list of case types. These errors enforce the structural requirements of a valid union declaration. For the complete rules, see the [union types feature specification](~/_csharplang/proposals/unions.md).

To correct these errors, apply the following changes to your union declaration:

- Add at least one case type to the union's type list (**CS9370**). A union must have one or more case types because the union's purpose is to represent a closed set of alternatives. A declaration like `union Empty()` with no case types isn't meaningful.
- Change or remove case types that don't convert to `object` via an implicit reference or boxing conversion (**CS9371**). Union types store their contents as a single `object?` reference, so every case type must be convertible to `object`. Types like pointers or `ref struct` types don't satisfy this requirement. Replace them with a wrapper type that can be boxed or stored as a reference.

## Union member restrictions

- **CS9373**: *Instance fields, auto-properties, or field-like events are not permitted in a 'union' declaration.*
- **CS9374**: *Explicitly declared public constructors with a single parameter are not permitted in a 'union' declaration.*
- **CS9375**: *A constructor declared in a 'union' declaration must have a 'this' initializer that calls a synthesized constructor or an explicitly declared constructor.*

A [union declaration](../builtin-types/union.md#union-declarations) can include a body with additional members, but the compiler restricts what you can declare. These restrictions ensure that the compiler-generated conversion constructors and storage mechanism work correctly. For the complete rules, see the [union types feature specification](~/_csharplang/proposals/unions.md).

To correct these errors, apply the following changes to your union members:

- Remove instance fields, auto-implemented properties, and field-like events from the union body (**CS9373**). A union doesn't define new data members. It composes existing types into a closed set of alternatives. Declare any additional state in the case types themselves or use static members on the union.
- Remove or change the accessibility of any explicitly declared public constructor that takes a single parameter (**CS9374**). The compiler generates a public single-parameter constructor for each case type to support implicit union conversions. An explicit constructor with the same shape conflicts with those generated constructors. If you need a single-parameter constructor, make it `internal` or `private`.
- Add a `this` initializer to any explicitly declared constructor so that it chains to a synthesized constructor or another explicitly declared constructor (**CS9375**). The compiler-generated constructors initialize the union's internal storage correctly. Constructors that don't chain through them might leave the union in an invalid state. Use `: this(someValue)` to chain to a generated case-type constructor, or `: this()` to chain to an explicit parameterless constructor you declare.

## Union member provider requirements

- **CS9385**: *A union type must have at least one union creation member.*
- **CS9386**: *A union member provider type must have an instance 'Value' property of type 'object?' or 'object'. The property must have a public get accessor.*
- **CS9387**: *A 'union' declaration cannot use a union member provider interface.*

A union member provider is a type that implements the union pattern through an interface rather than the `union` keyword. These errors enforce the structural requirements for types participating in the union member provider pattern. For the complete rules, see the [union types feature specification](~/_csharplang/proposals/unions.md).

To correct these errors, apply the following changes to your union member provider:

- Add at least one union creation member to the type (**CS9385**). A union type must expose at least one creation member (such as a static factory method or implicit conversion) so that values of the union can be constructed from the case types.
- Add a public instance `Value` property of type `object?` or `object` with a public `get` accessor to the member provider type (**CS9386**). The `Value` property is how the runtime retrieves the stored value from the union. Without it, the union can't expose its contents for pattern matching or direct access.
- Remove the union member provider interface from the `union` declaration (**CS9387**). A `union` declaration synthesizes its own member provider implementation. You can't specify a union member provider interface on a type that uses the `union` keyword directly. Use the member provider interface only on types that implement the union pattern manually.

## Closed hierarchy restrictions

- **CS9380**: *Types and aliases cannot be named 'closed'.*
- **CS9381**: *'type': a closed type cannot be sealed or static*
- **CS9382**: *'type': cannot use a closed type 'type' from another assembly as a base type.*
- **CS9383**: *'type': The type parameter 'parameter' must be referenced in the base type 'type' because the base type is closed.*
- **CS9384**: *'type': a closed type cannot be marked abstract because it is always implicitly abstract.*

A closed type hierarchy restricts which types can derive from a base type. The compiler enforces these restrictions to ensure that the set of derived types is known and exhaustive. For the complete rules, see the [closed hierarchies feature specification](~/_csharplang/proposals/closed-hierarchies.md).

To correct these errors, apply the following changes to your closed hierarchy declaration:

- Rename any type or alias named `closed`, because `closed` is a reserved keyword in this context (**CS9380**). Choose a different name that doesn't conflict with the keyword.
- Remove the `sealed` or `static` modifier from a closed type (**CS9381**). A closed type is implicitly abstract (it must be derived from), so marking it `sealed` (which prevents derivation) or `static` (which prevents instantiation and derivation) contradicts its purpose.
- Don't derive from a closed type declared in another assembly (**CS9382**). Closed hierarchies must have all their subtypes defined in the same assembly as the base type. This restriction enables the compiler to perform exhaustive pattern matching. Move the derived type into the same assembly as the closed base type, or remove the inheritance relationship.
- Ensure that each type parameter of a generic subtype appears in the base type reference when the base type is closed (**CS9383**). Because a closed hierarchy requires exhaustive knowledge of all subtypes, every type parameter on a subtype must be constrained through the base type. If a type parameter isn't referenced in the base type, the compiler can't enumerate all possible instantiations.
- Remove the `abstract` modifier from a closed type declaration (**CS9384**). A closed type is always implicitly abstract because it serves as a base for a finite set of derived types. Adding `abstract` explicitly is redundant and disallowed to avoid confusion about whether the type has different semantics than other closed types.
