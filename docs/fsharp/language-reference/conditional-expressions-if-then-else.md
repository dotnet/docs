---
title: "Conditional Expressions: if... then...else (F#)"
description: Learn how to write conditional expressions in F# to execute different branches of code.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 16e1871c-4d4d-4691-9ab2-bd2c6f65589a 
---

# Conditional Expressions: `if...then...else`

The `if...then...else` expression runs different branches of code and also evaluates to a different value depending on the Boolean expression given.


## Syntax

```fsharp
if boolean-expression then expression1 [ else expression2 ]
```

## Remarks
In the previous syntax, *expression1* runs when the Boolean expression evaluates to `true`; otherwise, *expression2* runs.

Unlike in other languages, the `if...then...else` construct is an expression, not a statement. That means that it produces a value, which is the value of the last expression in the branch that executes. The types of the values produced in each branch must match. If there is no explicit `else` branch, its type is `unit`. Therefore, if the type of the `then` branch is any type other than `unit`, there must be an `else` branch with the same return type. When chaining `if...then...else` expressions together, you can use the keyword `elif` instead of `else if`; they are equivalent.

## Example
The following example illustrates how to use the `if...then...else` expression.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet4501.fs)]

```
10 is less than 20
What is your name? John
How old are you? 9
You are only 9 years old and already learning F#? Wow!
```

## See Also
[F# Language Reference](index.md)

