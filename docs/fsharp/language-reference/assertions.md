---
title: Assertions
description: Learn how to use the 'assert' expression as a debugging feature for testing expressions in the F# programming language.
ms.date: 05/16/2016
---
# Assertions

The `assert` expression is a debugging feature that you can use to test an expression. Upon failure in Debug mode, an assertion generates a system error dialog box.

## Syntax

```fsharp
assert condition
```

## Remarks

The `assert` expression has type `bool -> unit`.

The `assert` function resolves to <xref:System.Diagnostics.Debug.Assert*?displayProperty=nameWithType>. This means that behavior is identical to having called <xref:System.Diagnostics.Debug.Assert*?displayProperty=nameWithType> directly.

Assertion checking is enabled only when you compile in Debug mode; that is, if the constant `DEBUG` is defined. In the project system, by default, the `DEBUG` constant is defined in the Debug configuration but not in the Release configuration.

The assertion failure error cannot be caught by using F# exception handling.

## Example

The following code example illustrates the use of the `assert` expression.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet5401.fs)]

## See also

- [F# Language Reference](index.md)
