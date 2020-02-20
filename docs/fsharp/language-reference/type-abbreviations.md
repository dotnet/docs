---
title: Type Abbreviations
description: Learn about F# type abbreviations to give a type a more meaningful name in order to make code easier to read.
ms.date: 05/16/2016
---
# Type Abbreviations

A *type abbreviation* is an alias or alternate name for a type.

## Syntax

```fsharp
type [accessibility-modifier] type-abbreviation = type-name
```

## Remarks

You can use type abbreviations to give a type a more meaningful name, in order to make code easier to read. You can also use them to create an easy to use name for a type that is otherwise cumbersome to write out. Additionally, you can use type abbreviations to make it easier to change an underlying type without changing all the code that uses the type. The following is a simple type abbreviation.

Accessibility of type abbreviations defaults to `public`.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet2301.fs)]

Type abbreviations can include generic parameters, as in the following code.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet2302.fs)]

In the previous code, `Transform` is a type abbreviation that represents a function that takes a single argument of any type and that returns a single value of that same type.

Type abbreviations are not preserved in the .NET Framework MSIL code. Therefore, when you use an F# assembly from another .NET Framework language, you must use the underlying type name for a type abbreviation.

Type abbreviations can also be used on units of measure. For more information, see [Units of Measure](units-of-measure.md).

## See also

- [F# Language Reference](index.md)
