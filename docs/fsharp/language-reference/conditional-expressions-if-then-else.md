---
title: "Conditional Expressions: if... then...else"
description: Learn how to write conditional expressions in F# to execute different branches of code.
ms.date: 05/16/2016
---
# Conditional Expressions: `if...then...else`

The `if...then...else` expression runs different branches of code and also evaluates to a different value depending on the Boolean expression given.

## Syntax

```fsharp
if boolean-expression then expression1 [ else expression2 ]
```

## Remarks

In the previous syntax, *expression1* runs when the Boolean expression evaluates to `true`; otherwise, *expression2* runs.

Like other languages, the `if...then...else` construct can be used to conditionally execute code. In F#, `if...then...else` is an expression and produces a value by the branch that executes. The types of the expressions in each branch must match.

If there is no explicit `else` branch, the overall type is `unit`, and the type of the `then` branch must also be `unit`.

When chaining `if...then...else` expressions together, you can use the keyword `elif` instead of `else if`; they are equivalent.

## Example

The following example illustrates how to use the `if...then...else` expression.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet4501.fs)]

```console
10 is less than 20
What is your name? John
How old are you? 9
You are only 9 years old and already learning F#? Wow!
```

## See also

- [F# Language Reference](index.md)
