---
title: Enumerations (F#)
description: Learn how to use F# enumerations in place of literals to make your code more readable and maintainable.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 9272bf5a-9a9f-4314-9e34-a3248e5244f5 
---

# Enumerations

*Enumerations*, also known as *enums*, , are integral types where labels are assigned to a subset of the values. You can use them in place of literals to make code more readable and maintainable.


## Syntax

```fsharp
type enum-name =
| value1 = integer-literal1
| value2 = integer-literal2
...
```

## Remarks
An enumeration looks much like a discriminated union that has simple values, except that the values can be specified. The values are typically integers that start at 0 or 1, or integers that represent bit positions. If an enumeration is intended to represent bit positions, you should also use the [Flags](xref:System.FlagsAttribute) attribute.

The underlying type of the enumeration is determined from the literal that is used, so that, for example, you can use literals with a suffix, such as `1u`, `2u`, and so on, for an unsigned integer (`uint32`) type.

When you refer to the named values, you must use the name of the enumeration type itself as a qualifier, that is, `enum-name.value1`, not just `value1`. This behavior differs from that of discriminated unions. This is because enumerations always have the [RequireQualifiedAccess](https://msdn.microsoft.com/library/8b9b6ade-0471-4413-ac5d-638cd0de5f15) attribute.

The following code shows the declaration and use of an enumeration.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet2101.fs)]

You can easily convert enumerations to the underlying type by using the appropriate operator, as shown in the following code.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet2102.fs)]

Enumerated types can have one of the following underlying types: `sbyte`, `byte`, `int16`, `uint16`, `int32`, `uint32`, `int64`, `uint16`, `uint64`, and `char`. Enumeration types are represented in the .NET Framework as types that are inherited from `System.Enum`, which in turn is inherited from `System.ValueType`. Thus, they are value types that are located on the stack or inline in the containing object, and any value of the underlying type is a valid value of the enumeration. This is significant when pattern matching on enumeration values, because you have to provide a pattern that catches the unnamed values.

The `enum` function in the F# library can be used to generate an enumeration value, even a value other than one of the predefined, named values. You use the `enum` function as follows.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet2103.fs)]

The default `enum` function works with type `int32`. Therefore, it cannot be used with enumeration types that have other underlying types. Instead, use the following.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet2104.fs)]
    
## See Also
[F# Language Reference](index.md)

[Casting and Conversions](casting-and-conversions.md)
