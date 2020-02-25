---
title: Loops - while...do Expression (F#)
description: Loops - while...do Expression (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 0416ffca-7ed9-4aff-9493-e001fdba8c9b
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/loops-while-do-expression 
---

# Loops: while...do Expression (F#)

The `while...do` expression is used to perform iterative execution (looping) while a specified test condition is true.


## Syntax

```fsharp
while test-expression do
body-expression
```

## Remarks
The *test-expression* is evaluated; if it is `true`, the *body-expression* is executed and the test expression is evaluated again. The *body-expression* must have type `unit`. If the test expression is `false`, the iteration ends.

The following example illustrates the use of the `while...do` expression.

[!code-fsharp[Main](snippets/fslangref2/snippet5301.fs)]

The output of the previous code is a stream of random numbers between 1 and 20, the last of which is 10.

```
13 19 8 18 16 2 10
Found a 10!
```

>[!NOTE] 
You can use `while...do` in sequence expressions and other computation expressions, in which case a customized version of the `while...do` expression is used. For more information, see [Sequences &#40;F&#35;&#41;](Sequences-%5BFSharp%5D.md), [Asynchronous Workflows &#40;F&#35;&#41;](Asynchronous-Workflows-%5BFSharp%5D.md), and [Computation Expressions &#40;F&#35;&#41;](Computation-Expressions-%5BFSharp%5D.md).


## See Also
[F&#35; Language Reference](FSharp-Language-Reference.md)

[Loops: for...in Expression &#40;F&#35;&#41;](Loops-for...in-Expression-%5BFSharp%5D.md)

[Loops: for...to Expression &#40;F&#35;&#41;](Loops-for...to-Expression-%5BFSharp%5D.md)