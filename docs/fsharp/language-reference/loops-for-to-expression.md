---
title: "Loops: for...to Expression"
description: See how the F# for...to expression is used to iterate in a loop over a range of values of a loop variable.
ms.date: 05/16/2016
---

# Loops: for...to Expression

The `for...to` expression is used to iterate in a loop over a range of values of a loop variable.

## Syntax

```fsharp
for identifier = start [ to | downto ] finish do
    body-expression
```

## Remarks

The type of the identifier is inferred from the type of the *start* and *finish* expressions. Types for these expressions must be 32-bit integers.

Although technically an expression, `for...to` is more like a traditional statement in an imperative programming language. The return type for the *body-expression* must be `unit`. The following examples show various uses of the `for...to` expression.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet5101.fs)]

The output of the previous code is as follows.

```console
1 2 3 4 5 6 7 8 9 10
10 9 8 7 6 5 4 3 2 1
2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18
```

## See also

- [F# Language Reference](index.md)
- [Loops: `for...in` Expression](loops-for-in-expression.md)
- [Loops: `while...do` Expression](loops-while-do-expression.md)
