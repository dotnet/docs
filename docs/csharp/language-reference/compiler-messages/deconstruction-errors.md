---
title: "Resolve errors and warnings related to deconstruction, discards, and out variables"
description: "This article helps you diagnose and correct compiler errors and warnings related to deconstruction, discards, and out variables"
f1_keywords:
  - "CS8129"
  - "CS8130"
  - "CS8131"
  - "CS8132"
  - "CS8134"
  - "CS8136"
  - "CS8183"
  - "CS8187"
  - "CS8197"
  - "CS8199"
helpviewer_keywords:
  - "CS8129"
  - "CS8130"
  - "CS8131"
  - "CS8132"
  - "CS8134"
  - "CS8136"
  - "CS8183"
  - "CS8187"
  - "CS8197"
  - "CS8199"
ms.date: 08/19/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings for deconstruction, discards, and out variables

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because it doesn't use contractions.
That's by design. The text closely matches the text of the compiler error or warning for SEO purposes.
 -->

- [**CS8129**](#deconstruct-method-requirements): *No suitable 'Deconstruct' instance or extension method was found for type 'type', with count out parameters and a void return type.*
- [**CS8130**](#type-inference-for-deconstruction-variables-discards-and-out-variables): *Cannot infer the type of implicitly-typed deconstruction variable 'variable'.*
- [**CS8131**](#type-inference-for-deconstruction-variables-discards-and-out-variables): *Deconstruct assignment requires an expression with a type on the right-hand-side.*
- [**CS8132**](#deconstruction-cardinality): *Cannot deconstruct a tuple of 'element count' elements into 'variable count' variables.*
- [**CS8134**](#deconstruction-cardinality): *Deconstruction must contain at least two variables.*
- [**CS8136**](#deconstruction-declaration-and-assignment-syntax): *Deconstruction 'var (...)' form disallows a specific type for 'var'.*
- [**CS8183**](#type-inference-for-deconstruction-variables-discards-and-out-variables): *Cannot infer the type of implicitly-typed discard.*
- [**CS8187**](#deconstruction-declaration-and-assignment-syntax): *Tuple element names are not permitted on the left of a deconstruction.*
- [**CS8197**](#type-inference-for-deconstruction-variables-discards-and-out-variables): *Cannot infer the type of implicitly-typed out variable 'variable'.*
- [**CS8199**](#deconstruction-declaration-and-assignment-syntax): *The syntax 'var (...)' as an lvalue is reserved.*

## `Deconstruct` method requirements

- **CS8129**: *No suitable 'Deconstruct' instance or extension method was found for type 'type', with count out parameters and a void return type.*

Provide an accessible instance or extension `Deconstruct` method that returns `void` and has one `out` parameter for each variable on the left. Match each parameter type to the corresponding deconstruction variable (**CS8129**). For more information, see [user-defined deconstruction](../../fundamentals/functional/deconstruct.md#user-defined-types) and the [`out` parameter modifier](../keywords/method-parameters.md#out-parameter-modifier).

## Type inference for deconstruction variables, discards, and `out` variables

- **CS8130**: *Cannot infer the type of implicitly-typed deconstruction variable 'variable'.*
- **CS8131**: *Deconstruct assignment requires an expression with a type on the right-hand-side.*
- **CS8183**: *Cannot infer the type of implicitly-typed discard.*
- **CS8197**: *Cannot infer the type of implicitly-typed out variable 'variable'.*

Supply a typed, deconstructable expression on the right so the compiler can determine each implicitly typed variable (**CS8130**, **CS8131**). Cast or otherwise give a discarded expression a type; in a deconstruction, specify an element type when appropriate (**CS8183**). For an `out` variable, use a method parameter that supplies the type or specify the type explicitly in the `out` argument (**CS8197**). For more information, see [deconstruction](../../fundamentals/functional/deconstruct.md) and [calls with `out` parameters](../../fundamentals/functional/discards.md#calls-to-methods-with-out-parameters).

## Deconstruction cardinality

- **CS8132**: *Cannot deconstruct a tuple of 'element count' elements into 'variable count' variables.*
- **CS8134**: *Deconstruction must contain at least two variables.*

Use at least two variables in a deconstruction (**CS8134**). Match the number of variables on the left to the number of tuple elements on the right, and add a discard (`_`) for each value that you don't need (**CS8132**). For more information, see [discards in tuple and object deconstruction](../../fundamentals/functional/discards.md#tuple-and-object-deconstruction).

## Deconstruction declaration and assignment syntax

- **CS8136**: *Deconstruction 'var (...)' form disallows a specific type for 'var'.*
- **CS8187**: *Tuple element names are not permitted on the left of a deconstruction.*
- **CS8199**: *The syntax 'var (...)' as an lvalue is reserved.*

Use `var` outside the parentheses only for an implicitly typed declaration. Put explicit types on the individual variables instead (**CS8136**). Remove tuple element names from the left side (**CS8187**). When assigning existing variables, omit `var` and use only the parenthesized variables (**CS8199**):

```csharp
var (x, y) = point;
(int a, int b) = point;
(a, b) = point;
```

For more information, see [tuple deconstruction](../../fundamentals/functional/deconstruct.md#tuples).
