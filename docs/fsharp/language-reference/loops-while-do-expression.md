---
title: "Loops: while...do Expression (F#)"
description: See how the while...do expression is used to perform iterative execution (looping) while a specified test condition is true.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 0416ffca-7ed9-4aff-9493-e001fdba8c9b 
---

# Loops: while...do Expression

The `while...do` expression is used to perform iterative execution (looping) while a specified test condition is true.


## Syntax

```fsharp
while test-expression do
    body-expression
```

## Remarks
The *test-expression* is evaluated; if it is `true`, the *body-expression* is executed and the test expression is evaluated again. The *body-expression* must have type `unit`. If the test expression is `false`, the iteration ends.

The following example illustrates the use of the `while...do` expression.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet5301.fs)]

The output of the previous code is a stream of random numbers between 1 and 20, the last of which is 10.

```
13 19 8 18 16 2 10
Found a 10!
```

>[!NOTE] 
You can use `while...do` in sequence expressions and other computation expressions, in which case a customized version of the `while...do` expression is used. For more information, see [Sequences](sequences.md), [Asynchronous Workflows](asynchronous-workflows.md), and [Computation Expressions](computation-expressions.md).


## See Also
[F# Language Reference](index.md)

[Loops: `for...in` Expression](loops-for-in-expression.md)

[Loops: `for...to` Expression](loops-for-to-expression.md)
