---
title: "Loops: for...in Expression (F#)"
description: See how the F# for...in expression looping construct is used to iterate over the matches of a pattern in an enumerable collection.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: f54e3228-4aec-4d0a-ae37-bc3376508284 
---

# Loops: for...in Expression

This looping construct is used to iterate over the matches of a pattern in an enumerable collection such as a range expression, sequence, list, array, or other construct that supports enumeration.


## Syntax

```fsharp
for pattern in enumerable-expression do
    body-expression
```

## Remarks
The `for...in` expression can be compared to the `for each` statement in other .NET languages because it is used to loop over the values in an enumerable collection. However, `for...in` also supports pattern matching over the collection instead of just iteration over the whole collection.

The enumerable expression can be specified as an enumerable collection or, by using the `..` operator, as a range on an integral type. Enumerable collections include lists, sequences, arrays, sets, maps, and so on. Any type that implements `System.Collections.IEnumerable` can be used.

When you express a range by using the `..` operator, you can use the following syntax.

*start* .. *finish*

You can also use a version that includes an increment called the *skip*, as in the following code.

*start* .. *skip* .. *finish*

When you use integral ranges and a simple counter variable as a pattern, the typical behavior is to increment the counter variable by 1 on each iteration, but if the range includes a skip value, the counter is incremented by the skip value instead.

Values matched in the pattern can also be used in the body expression.

The following code examples illustrate the use of the `for...in` expression.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet5201.fs)]

The output is as follows.

```
1
5
100
450
788
```

The following example shows how to loop over a sequence, and how to use a tuple pattern instead of a simple variable.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet5202.fs)]

The output is as follows.

```
1 squared is 1
2 squared is 4
3 squared is 9
4 squared is 16
5 squared is 25
6 squared is 36
7 squared is 49
8 squared is 64
9 squared is 81
10 squared is 100
```

The following example shows how to loop over a simple integer range.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet5203.fs)]

The output of function1 is as follows.

```
1 2 3 4 5 6 7 8 9 10
```

The following example shows how to loop over a range with a skip of 2, which includes every other element of the range.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet5204.fs)]

The output of `function2` is as follows.

```
1 3 5 7 9
```

The following example shows how to use a character range.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet5205.fs)]

The output of `function3` is as follows.

```
a b c d e f g h i j k l m n o p q r s t u v w x y z
```

The following example shows how to use a negative skip value for a reverse iteration.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet5208.fs)]

The output of `function4` is as follows.

```
10 9 8 7 6 5 4 3 2 1 ... Lift off!
```

The beginning and ending of the range can also be expressions, such as functions, as in the following code.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet5206.fs)]

The output of `function5` with this input is as follows.

```
2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18
```

The next example shows the use of a wildcard character (_) when the element is not needed in the loop.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet5207.fs)]

The output is as follows.

```
Number of elements in list1: 5
```

`Note` You can use `for...in` in sequence expressions and other computation expressions, in which case a customized version of the `for...in` expression is used. For more information, see [Sequences](sequences.md), [Asynchronous Workflows](asynchronous-workflows.md), and [Computation Expressions](computation-expressions.md).


## See Also
[F# Language Reference](index.md)

[Loops: `for...to` Expression](loops-for-to-expression.md)

[Loops: `while...do` Expression](loops-while-do-expression.md)
