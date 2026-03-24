---
title: "Built-in types and literals"
description: Learn about the built-in types in C#, including numeric types, bool, char, and string. Explore literal syntax, default expressions, var, target-typed new, and the dynamic type.
ms.date: 03/24/2026
ms.topic: concept-article
ai-usage: ai-assisted
---
# Built-in types and literals

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. They introduce types as you write your first programs.
>
> **Experienced in another language?** C# built-in types map closely to types in Java, C++, and other languages. Skim the [literal syntax](#literal-syntax) and [type inference](#implicitly-typed-variables-with-var) sections for C#-specific details.

C# provides a set of built-in types that you can use in any program without additional references. These types cover the most common data you work with: numbers, true/false values, individual characters, and text. For a complete reference table mapping C# keywords to .NET types, see [Built-in types (C# reference)](../../language-reference/builtin-types/built-in-types.md).

## Numeric types

C# has built-in types for integers, floating-point numbers, and decimal numbers. The most commonly used types are `int`, `double`, and `decimal`:

:::code language="csharp" source="snippets/built-in-types/Program.cs" ID="NumericTypes":::

Each numeric type has a fixed size and range. `int` stores 32-bit integers (roughly ±2.1 billion), `long` stores 64-bit integers, and `short` and `byte` store smaller values. For the full list of sizes and ranges, see [Integral numeric types](../../language-reference/builtin-types/integral-numeric-types.md) and [Floating-point numeric types](../../language-reference/builtin-types/floating-point-numeric-types.md).

Use `double` for general floating-point math, `float` when memory is constrained, and `decimal` when you need exact decimal precision (such as financial calculations). The `m` and `f` suffixes distinguish these literal types.

### Unsigned types

Each signed integer type has an unsigned counterpart that stores only non-negative values with double the positive range:

:::code language="csharp" source="snippets/built-in-types/Program.cs" ID="UnsignedTypes":::

Use unsigned types when negative values don't make sense for the data, such as file sizes or network ports.

### Native-sized integers

The `nint` and `nuint` types represent integers whose size matches the platform's native pointer size—32 bits on a 32-bit platform, 64 bits on a 64-bit platform:

:::code language="csharp" source="snippets/built-in-types/Program.cs" ID="NativeSizedIntegers":::

Use `nint` and `nuint` primarily for interop scenarios and low-level memory operations. For most application code, `int` or `long` is a better choice. For more information, see [`nint` and `nuint`](../../language-reference/builtin-types/integral-numeric-types.md#native-sized-integers).

## `bool`, `char`, and `string`

Beyond numbers, C# provides three other frequently used built-in types:

:::code language="csharp" source="snippets/built-in-types/Program.cs" ID="BoolCharString":::

- **`bool`** — Stores `true` or `false`. Used in conditions, loops, and logical expressions.
- **`char`** — Stores a single Unicode character (UTF-16 code unit), enclosed in single quotes.
- **`string`** — Stores a sequence of characters, enclosed in double quotes. Strings are *immutable*—once created, their contents can't change. Operations that appear to modify a string actually create a new one.

Strings are one of the most-used types in C#. For in-depth coverage of string operations—interpolation, raw string literals, searching, splitting, and comparison—see the [Strings](../../language-reference/builtin-types/reference-types.md#the-string-type) section.

## Literal syntax

A *literal* is a value written directly in your code. The compiler assigns each literal a type based on its format and any suffix you provide.

### Integer literals

:::code language="csharp" source="snippets/built-in-types/Program.cs" ID="IntegerLiterals":::

Prefix `0x` for hexadecimal, `0b` for binary. Use the `_` digit separator anywhere within a number for readability—the compiler ignores it. Append `L` for `long`, `U` for `uint`, or `UL` for `ulong`.

### Floating-point literals

:::code language="csharp" source="snippets/built-in-types/Program.cs" ID="FloatingPointLiterals":::

Without a suffix, a numeric literal with a decimal point is `double`. Append `f` for `float` and `m` for `decimal`. Scientific notation (`1.5e6`) is also supported.

### Character and string literals

:::code language="csharp" source="snippets/built-in-types/Program.cs" ID="CharAndStringLiterals":::

Character literals use single quotes and support escape sequences (`\n`, `\t`, `\u`). String literals use double quotes. Prefix strings with `@` for verbatim strings (no escape processing), `$` for interpolation, or both `@$` to combine them.

## `default` expressions

The `default` expression produces the default value for a type—`0` for numeric types, `false` for `bool`, and `null` for reference types:

:::code language="csharp" source="snippets/built-in-types/Program.cs" ID="DefaultExpressions":::

Use `default` when you need a type's zero-value without specifying it explicitly. The `default` literal (without a type argument) works when the compiler can infer the type from context. Use `default(T)` when the type isn't clear from context.

## Implicitly typed variables with `var`

The `var` keyword tells the compiler to infer a local variable's type from its initializer:

:::code language="csharp" source="snippets/built-in-types/Program.cs" ID="VarKeyword":::

The variable is still strongly typed—`var` doesn't make it dynamic. The compiler determines the type at compile time and enforces type safety as usual. Use `var` when the type is obvious from the right-hand side to reduce visual noise. Spell out the type when it makes the code clearer.

## Target-typed `new` expressions

When the target type is already known from context—such as a variable declaration or a method parameter—you can omit the type name from the `new` expression:

:::code language="csharp" source="snippets/built-in-types/Program.cs" ID="TargetTypedNew":::

Target-typed `new` reduces repetition when the type name is long or appears on the left-hand side of the assignment. It works anywhere the compiler can determine the target type, including method arguments and return statements.

## The `dynamic` type

The `dynamic` type bypasses compile-time type checking. Operations on a `dynamic` variable are resolved at run time instead:

:::code language="csharp" source="snippets/built-in-types/Program.cs" ID="DynamicType":::

Use `dynamic` when interacting with COM APIs, dynamic languages, or reflection-heavy scenarios where types aren't known at compile time. Avoid `dynamic` in most application code because you lose compile-time safety—errors that the compiler would normally catch become run-time exceptions instead.

## See also

- [Type system overview](index.md)
- [Built-in types (C# reference)](../../language-reference/builtin-types/built-in-types.md)
- [Integral numeric types](../../language-reference/builtin-types/integral-numeric-types.md)
- [Floating-point numeric types](../../language-reference/builtin-types/floating-point-numeric-types.md)
- [Value types](../../language-reference/builtin-types/value-types.md)
