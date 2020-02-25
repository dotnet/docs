---
title: Type Abbreviations (F#)
description: Type Abbreviations (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 560af74f-935f-415c-af56-604cddb9da6b
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/type-abbreviations 
---

# Type Abbreviations (F#)

A *type abbreviation* is an alias or alternate name for a type.


## Syntax

```fsharp
type type-abbreviation = type-name
```

## Remarks
You can use type abbreviations to give a type a more meaningful name, in order to make code easier to read. You can also use them to create an easy to use name for a type that is otherwise cumbersome to write out. Additionally, you can use type abbreviations to make it easier to change an underlying type without changing all the code that uses the type. The following is a simple type abbreviation.

[!code-fsharp[Main](snippets/fslangref1/snippet2301.fs)]

Type abbreviations can include generic parameters, as in the following code.

[!code-fsharp[Main](snippets/fslangref1/snippet2302.fs)]

In the previous code, `transform` is a type abbreviation that represents a function that takes a single argument of any type and that returns a single value of that same type.

Type abbreviations are not preserved in the .NET Framework MSIL code. Therefore, when you use an F# assembly from another .NET Framework language, you must use the underlying type name for a type abbreviation.

Type abbreviations can also be used on units of measure. For more information, see [Units of Measure &#40;F&#35;&#41;](Units-of-Measure-%5BFSharp%5D.md).


## See Also
[F&#35; Language Reference](FSharp-Language-Reference.md)

