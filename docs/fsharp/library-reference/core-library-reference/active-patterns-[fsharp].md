---
title: Active Patterns (F#)
description: Active Patterns (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 11a724ff-f9ff-4056-b5e0-87e9ed986f4a
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/active-patterns 
---

# Active Patterns (F#)

*Active patterns* enable you to define named partitions that subdivide input data, so that you can use these names in a pattern matching expression just as you would for a discriminated union. You can use active patterns to decompose data in a customized manner for each partition.


## Syntax

```fsharp
// Complete active pattern definition.
let (|identifer1|identifier2|...|) [ arguments ] = expression
// Partial active pattern definition.
let (|identifier|_|) [ arguments ] = expression
```

## Remarks
In the previous syntax, the identifiers are names for partitions of the input data that is represented by *arguments*, or, in other words, names for subsets of the set of all values of the arguments. There can be up to seven partitions in an active pattern definition. The *expression* describes the form into which to decompose the data. You can use an active pattern definition to define the rules for determining which of the named partitions the values given as arguments belong to. The (| and |) symbols are referred to as *banana clips* and the function created by this type of let binding is called an *active recognizer*.

As an example, consider the following active pattern with an argument.

[!code-fsharp[Main](snippets/fslangref2/snippet5001.fs)]

You can use the active pattern in a pattern matching expression, as in the following example.

[!code-fsharp[Main](snippets/fslangref2/snippet5002.fs)]

The output of this program is as follows:

```
7 is odd
11 is odd
32 is even
```

Another use of active patterns is to decompose data types in multiple ways, such as when the same underlying data has various possible representations. For example, a `Color` object could be decomposed into an RGB representation or an HSB representation.

[!code-fsharp[Main](snippets/fslangref2/snippet5003.fs)]

The output of the above program is as follows:

```
Red
R: 255 G: 0 B: 0
H: 0.000000 S: 1.000000 B: 0.500000
Black
R: 0 G: 0 B: 0
H: 0.000000 S: 0.000000 B: 0.000000
White
R: 255 G: 255 B: 255
H: 0.000000 S: 0.000000 B: 1.000000
Gray
R: 128 G: 128 B: 128
H: 0.000000 S: 0.000000 B: 0.501961
BlanchedAlmond
R: 255 G: 235 B: 205
H: 36.000000 S: 1.000000 B: 0.901961
```

In combination, these two ways of using active patterns enable you to partition and decompose data into just the appropriate form and perform the appropriate computations on the appropriate data in the form most convenient for the computation.

The resulting pattern matching expressions enable data to be written in a convenient way that is very readable, greatly simplifying potentially complex branching and data analysis code.


## Partial Active Patterns
Sometimes, you need to partition only part of the input space. In that case, you write a set of partial patterns each of which match some inputs but fail to match other inputs. Active patterns that do not always produce a value are called *partial active patterns*; they have a return value that is an option type. To define a partial active pattern, you use a wildcard character (_) at the end of the list of patterns inside the banana clips. The following code illustrates the use of a partial active pattern.

[!code-fsharp[Main](snippets/fslangref2/snippet5004.fs)]

The output of the previous example is as follows:

```
1.100000 : Floating point
0 : Integer
0.000000 : Floating point
10 : Integer
Something else : Not matched.
```

When using partial active patterns, sometimes the individual choices can be disjoint or mutually exclusive, but they need not be. In the following example, the pattern Square and the pattern Cube are not disjoint, because some numbers are both squares and cubes, such as 64. The following program prints out all integers up to 1000000 that are both squares and cubes.

[!code-fsharp[Main](snippets/fslangref2/snippet5005.fs)]

The output is as follows:

```
1
64
729
4096
15625
46656
117649
262144
531441
1000000
```

## Parameterized Active Patterns
Active patterns always take at least one argument for the item being matched, but they may take additional arguments as well, in which case the name *parameterized active pattern* applies. Additional arguments allow a general pattern to be specialized. For example, active patterns that use regular expressions to parse strings often include the regular expression as an extra parameter, as in the following code, which also uses the partial active pattern `Integer` defined in the previous code example. In this example, strings that use regular expressions for various date formats are given to customize the general ParseRegex active pattern. The Integer active pattern is used to convert the matched strings into integers that can be passed to the DateTime constructor.

[!code-fsharp[Main](snippets/fslangref2/snippet5006.fs)]

The output of the previous code is as follows:

```
12/22/2008 12:00:00 AM 1/1/2009 12:00:00 AM 1/15/2008 12:00:00 AM 12/28/1995 12:00:00 AM
```

## See Also
[F&#35; Language Reference](FSharp-Language-Reference.md)

[Match Expressions &#40;F&#35;&#41;](Match-Expressions-%5BFSharp%5D.md)

