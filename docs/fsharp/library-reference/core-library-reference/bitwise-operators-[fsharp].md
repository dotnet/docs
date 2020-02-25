---
title: Bitwise Operators (F#)
description: Bitwise Operators (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8a2c87f5-b4c7-47fe-8580-82c956f605e5
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/symbol-and-operator-reference/bitwise-operators 
---

# Bitwise Operators (F#)

This topic describes bitwise operators that are available in the F# language.


## Summary of Bitwise Operators
The following table describes the bitwise operators that are supported for unboxed integral types in the F# language.



|Operator|Notes|
|--------|-----|
|`&&&`|Bitwise AND operator. Bits in the result have the value 1 if and only if the corresponding bits in both source operands are 1.|
|`|||`|Bitwise OR operator. Bits in the result have the value 1 if either of the corresponding bits in the source operands are 1.|
|`^^^`|Bitwise exclusive OR operator. Bits in the result have the value 1 if and only if bits in the source operands have unequal values.|
|`~~~`|Bitwise negation operator. This is a unary operator and produces a result in which all 0 bits in the source operand are converted to 1 bits and all 1 bits are converted to 0 bits.|
|`<<<`|Bitwise left-shift operator. The result is the first operand with bits shifted left by the number of bits in the second operand. Bits shifted off the most significant position are not rotated into the least significant position. The least significant bits are padded with zeros. The type of the second argument is `int32`.|
|`>>>`|Bitwise right-shift operator. The result is the first operand with bits shifted right by the number of bits in the second operand. Bits shifted off the least significant position are not rotated into the most significant position. For unsigned types, the most significant bits are padded with zeros. For signed types, the most significant bits are padded with ones. The type of the second argument is `int32`.|

The following types can be used with bitwise operators: `byte`, `sbyte`, `int16`, `uint16`, `int32 (int)`, `uint32`, `int64`, `uint64`, `nativeint`, and `unativeint`.


## See Also
[Symbol and Operator Reference &#40;F&#35;&#41;](Symbol-and-Operator-Reference-%5BFSharp%5D.md)

[Arithmetic Operators &#40;F&#35;&#41;](Arithmetic-Operators-%5BFSharp%5D.md)

[Boolean Operators &#40;F&#35;&#41;](Boolean-Operators-%5BFSharp%5D.md)

