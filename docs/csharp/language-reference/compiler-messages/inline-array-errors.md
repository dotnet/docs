---
title: Resolve errors related to inline arrays
description: These compiler errors and warnings are generated when you create an inline array struct that is invalid. This article helps you diagnose and fix those issues.
f1_keywords:
  - "CS9164"
  - "CS9165"
  - "CS9166"
  - "CS9167"
  - "CS9168"
  - "CS9169"
  - "CS9172"
  - "CS9173"
helpviewer_keywords:
  - "CS9164"
  - "CS9165"
  - "CS9166"
  - "CS9167"
  - "CS9168"
  - "CS9169"
  - "CS9172"
  - "CS9173"
ms.date: 07/11/2023
---
# Resolve errors and warnings with inline array declarations

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS9164**](#conversions-to-span) - *Cannot convert expression to `Span<T>` because it is not an assignable variable*
- [**CS9165**](#conversions-to-span) - *Cannot convert expression to `ReadOnlySpan<T>` because it may not be passed or returned by reference*
- [**CS9166**](#element-access) - *Index is outside the bounds of the inline array*
- [**CS9167**](#inline-array-declaration) - *Inline array length must be greater than 0.*
- [**CS9168**](#inline-array-declaration) - *Inline array struct must not have explicit layout.*
- [**CS9169**](#inline-array-declaration) - *Inline array struct must declare one and only one instance field which must not be a ref field.*
- [**CS9172**](#element-access) - *Elements of an inline array type can be accessed only with a single argument implicitly convertible to `int`, `System.Index`, or `System.Range`.*
- [**CS9173**](#element-access) - *An inline array access may not have a named argument specifier*

## Inline array declaration

You declare inline arrays as a `struct` type with a single field, and an attribute that specifies the length of the array. The compiler generates the following errors for invalid inline array declarations:

- **CS9167** - *Inline array length must be greater than 0.*
- **CS9168** - *Inline array struct must not have explicit layout.*
- **CS9169** - *Inline array struct must declare one and only one instance field which must not be a ref field.*

To fix these arrays, ensure the following are true:

- The argument to the <xref:System.Runtime.CompilerServices.InlineArrayAttribute?displayProperty=fullName> is a positive integer.
- The enclosing `struct` doesn't specify any explicit layout.
- The enclosing `struct` has a single instance field, and that instance field is not a `ref` field.

## Element access

You access elements of an inline array in the same way as any array. The following errors may be generated from incorrect element access:

- **CS9166** - *Index is outside the bounds of the inline array*
- **CS9172** - *Elements of an inline array type can be accessed only with a single argument implicitly convertible to `int`, `System.Index`, or `System.Range`.*
- **CS9173** - *An inline array access may not have a named argument specifier*

The argument to the indexer must be:

- One of these three types: `int`, a `System.Index` or a `System.Range`.
- Can't be a named argument. The compiler generates the element accessor. The parameter doesn't have a name, so you can't use named arguments.
- Is included in the bounds of the array. Like all .NET arrays, inline array element access is bounds-checked. The index must be within the bounds of the inline array.

## Conversions to Span

You often use <xref:System.Span%601?displayProperty=nameWithType> or <xref:System.ReadOnlySpan%601?displayProperty=nameWithType> to work with inline arrays. The compiler generates the following errors for invalid conversions:

- **CS9164** - *Cannot convert expression to `Span<T>` because it is not an assignable variable*
- **CS9165** - *Cannot convert expression to `ReadOnlySpan<T>` because it may not be passed or returned by reference*

An inline array can be implicitly converted to a `Span<T>` or `ReadOnlySpan<T>` to pass an inline array to methods. The compiler enforces restrictions on those conversions:

- The inline array must be writable in order to convert an inline array to a `Span<T>`. If the array is readonly, you can't convert it to a writable `Span<T>`. You can use `ReadOnlySpan<T>` instead.
- The *safe context* of the inline array must be at least as wide as the *safe context* of the `Span<T>` or `ReadOnlySpan<T>` for the conversion to succeed. You must either limit the context of the span, or expand the scope of the inline array.
