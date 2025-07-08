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
  - "CS9180"
  - "CS9181"
  - "CS9182"
  - "CS9183"
  - "CS9184"
  - "CS9189"
  - "CS9259"
helpviewer_keywords:
  - "CS9164"
  - "CS9165"
  - "CS9166"
  - "CS9167"
  - "CS9168"
  - "CS9169"
  - "CS9172"
  - "CS9173"
  - "CS9180"
  - "CS9181"
  - "CS9182"
  - "CS9183"
  - "CS9184"
  - "CS9189"
  - "CS9259"
ms.date: 11/06/2024
---
# Resolve errors and warnings with inline array declarations

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS9164**](#conversions-to-span): *Cannot convert expression to `Span<T>` because it is not an assignable variable*
- [**CS9165**](#conversions-to-span): *Cannot convert expression to `ReadOnlySpan<T>` because it may not be passed or returned by reference*
- [**CS9166**](#element-access): *Index is outside the bounds of the inline array*
- [**CS9167**](#inline-array-declaration): *Inline array length must be greater than 0.*
- [**CS9168**](#inline-array-declaration): *Inline array struct must not have explicit layout.*
- [**CS9169**](#inline-array-declaration): *Inline array struct must declare one and only one instance field which must not be a ref field.*
- [**CS9172**](#element-access): *Elements of an inline array type can be accessed only with a single argument implicitly convertible to `int`, `System.Index`, or `System.Range`.*
- [**CS9173**](#element-access): *An inline array access may not have a named argument specifier*
- [**CS9180**](#inline-array-declaration): *Inline array element field cannot be declared as required, readonly, volatile, or as a fixed size buffer.*
- [**CS9181**](#element-access): *Inline array indexer will not be used for element access expression.*
- [**CS9182**](#conversions-to-span): *Inline array 'Slice' method will not be used for element access expression.*
- [**CS9183**](#conversions-to-span): *Inline array conversion operator will not be used for conversion from expression of the declaring type.*
- [**CS9184**](#inline-array-declaration): *'Inline arrays' language feature is not supported for inline array types with element field which is either a '`ref`' field, or has type that is not valid as a type argument.*
- [**CS9189**](#element-access): *`foreach` statement on an inline array of type is not supported*
- [**CS9259**](#inline-array-declaration): *Attribute <xref:System.Runtime.CompilerServices.InlineArrayAttribute?displayProperty=fullName> cannot be applied to a record struct.*

## Inline array declaration

You declare inline arrays as a `struct` type with a single field, and an attribute that specifies the length of the array. The compiler generates the following errors for invalid inline array declarations:

- **CS9167**: *Inline array length must be greater than 0.*
- **CS9168**: *Inline array struct must not have explicit layout.*
- **CS9169**: *Inline array struct must declare one and only one instance field which must not be a ref field.*
- **CS9180**: *Inline array element field cannot be declared as required, readonly, volatile, or as a fixed size buffer.*
- **CS9184**: *'Inline arrays' language feature is not supported for inline array types with element field which is either a '`ref`' field, or has type that is not valid as a type argument.*
- **CS9259**: *Attribute <xref:System.Runtime.CompilerServices.InlineArrayAttribute?displayProperty=fullName> cannot be applied to a record struct.*

To fix these arrays, ensure the following are true:

- The argument to the <xref:System.Runtime.CompilerServices.InlineArrayAttribute?displayProperty=fullName> is a positive integer.
- The enclosing `struct` doesn't specify any explicit layout.
- The enclosing `struct` has a single instance field, and that instance field is not a `ref` field.
- The single instance field is not a fixed size buffer.
- The single instance field doesn't include the `required`, `volatile`, or `readonly` modifiers.
- Remove the `record` modifier from your inline array declaration.

## Element access

You access elements of an inline array in the same way as any array. The compiler emits the following errors from incorrect element access:

- **CS9166**: *Index is outside the bounds of the inline array*
- **CS9172**: *Elements of an inline array type can be accessed only with a single argument implicitly convertible to `int`, `System.Index`, or `System.Range`.*
- **CS9173**: *An inline array access may not have a named argument specifier*
- **CS9189**: *`foreach` statement on an inline array of type is not supported*

In addition, the compiler issues the following warning when you declare an [indexer](/dotnet/csharp/programming-guide/indexers):

- **CS9181**: *Inline array indexer will not be used for element access expression.*

The generated code for an inline buffer accesses the buffer memory directly, bypassing any declared indexers. Inline arrays can't be used with the `foreach` statement.

The argument to the indexer must be:

- One of these three types: `int`, a `System.Index` or a `System.Range`.
- Can't be a named argument. The compiler generates the element accessor. The parameter doesn't have a name, so you can't use named arguments.
- Is included in the bounds of the array. Like all .NET arrays, inline array element access is bounds-checked. The index must be within the bounds of the inline array.

## Conversions to Span

You often use <xref:System.Span%601?displayProperty=nameWithType> or <xref:System.ReadOnlySpan%601?displayProperty=nameWithType> to work with inline arrays. The compiler generates the following errors for invalid conversions:

- **CS9164**: *Cannot convert expression to `Span<T>` because it is not an assignable variable*
- **CS9165**: *Cannot convert expression to `ReadOnlySpan<T>` because it may not be passed or returned by reference*

The compiler generates code that directly accesses the memory for an inline buffer. Therefore, some members aren't ever called. The compiler generates the following warnings if you write one of the members that aren't ever called:

- **CS9182**: *Inline array 'Slice' method will not be used for element access expression.*
- **CS9183**: *Inline array conversion operator will not be used for conversion from expression of the declaring type.*

An inline array can be implicitly converted to a `Span<T>` or `ReadOnlySpan<T>` to pass an inline array to methods. The compiler enforces restrictions on those conversions:

- The inline array must be writable in order to convert an inline array to a `Span<T>`. If the array is readonly, you can't convert it to a writable `Span<T>`. You can use `ReadOnlySpan<T>` instead.
- The *safe context* of the inline array must be at least as wide as the *safe context* of the `Span<T>` or `ReadOnlySpan<T>` for the conversion to succeed. You must either limit the context of the span, or expand the scope of the inline array.

In addition, the compiler never generates calls to a `Slice` method in an inline buffer. Conversion operators to convert an inline buffer to a `Span` or `ReadOnlySpan` aren't called. The compiler generates code to create a <xref:System.Span%601?displayProperty=nameWithType> or <xref:System.ReadOnlySpan%601?displayProperty=nameWithType> directly from the memory buffer.
