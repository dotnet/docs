---
title: "Loops: for...to Expression (F#)"
description: See how the F# for...to expression is used to iterate in a loop over a range of values of a loop variable.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: e14c38d9-b1ef-4b7f-be9a-fb6ef6708e02 
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

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet5101.fs)]

The output of the previous code is as follows.

```
1 2 3 4 5 6 7 8 9 10
10 9 8 7 6 5 4 3 2 1
2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18
```

## See Also
[F# Language Reference](index.md)

[Loops: `for...in` Expression](loops-for-in-expression.md)

[Loops: `while...do` Expression](loops-while-do-expression.md)
