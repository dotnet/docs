---
title: Literals (F#)
description: Literals (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4b1d6e9d-f933-4cd4-966d-d643152c27e4
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/literals 
---

# Literals (F#)

This topic provides a table that shows how to specify the type of a literal in F#.


## Literal Types
The following table shows the literal types in F#. Characters that represent digits in hexadecimal notation are not case-sensitive; characters that identify the type are case-sensitive.



|Type|Description|Suffix or prefix|Examples|
|----|-----------|----------------|--------|
|sbyte|signed 8-bit integer|y|`86y`<br /><br />`0b00000101y`|
|byte|unsigned 8-bit natural number|uy|`86uy`<br /><br />`0b00000101uy`|
|int16|signed 16-bit integer|s|`86s`|
|uint16|unsigned 16-bit natural number|us|`86us`|
|int<br /><br />int32|signed 32-bit integer|l or none|`86`<br /><br />`86l`|
|uint<br /><br />uint32|unsigned 32-bit natural number|u or ul|`86u`<br /><br />`86ul`|
|unativeint|native pointer as an unsigned natural number|un|`0x00002D3Fun`|
|int64|signed 64-bit integer|L|`86L`|
|uint64|unsigned 64-bit natural number|UL|`86UL`|
|single, float32|32-bit floating point number|F or f|`4.14F` or `4.14f`|
|||lf|`0x00000000lf`|
|float; double|64-bit floating point number|none|`4.14` or `2.3E+32` or `2.3e+32`|
|||LF|`0x0000000000000000LF`|
|bigint|integer not limited to 64-bit representation|I|`9999999999999999999999999999I`|
|decimal|fractional number represented as a fixed point or rational number|M or m|`0.7833M` or `0.7833m`|
|Char|Unicode character|none|`'a'`|
|String|Unicode string|none|`"text\n"`<br /><br />or<br /><br />`@"c:\filename"`<br /><br />or<br /><br />`"""<book title="Paradise Lost">"""`<br /><br />or<br /><br />`"string1" + "string2"`<br /><br />See also [Strings &#40;F&#35;&#41;](Strings-%5BFSharp%5D.md).|
|byte|ASCII character|B|`'a'B`|
|byte[]|ASCII string|B|`"text"B`|
|String or byte[]|verbatim string|@ prefix|`@"\\server\share"` (Unicode)<br /><br />`@"\\server\share"B` (ASCII)|

## Remarks
Unicode strings can contain explicit encodings that you can specify by using `\u` followed by a 16-bit hexadecimal code or UTF-32 encodings that you can specify by using `\U` followed by a 32-bit hexadecimal code that represents a Unicode surrogate pair.

As of F# 3.1, you can use the + sign to combine string literals. You can also use the bitwise or (|||) operator to combine enum flags. For example, the following code is legal in F# 3.1:

```fsharp
[<Literal>]
let literal1 = "a" + "b"

[<Literal>]
let fileLocation =   __SOURCE_DIRECTORY__ + "/" + __SOURCE_FILE__

[<Literal>]
let literal2 = 1 ||| 64

[<Literal>]
let literal3 = System.IO.FileAccess.Read ||| System.IO.FileAccess.Write
```

The use of other bitwise operators isn't allowed.


## Named Literals
Values that are intended to be constants can be marked with the [Literal](https://msdn.microsoft.com/library/465f36ce-d146-41c0-b425-679c509cd285) attribute. This attribute has the effect of causing a value to be compiled as a constant.

In pattern matching expressions, identifiers that begin with lowercase characters are always treated as variables to be bound, rather than as literals, so you should generally use initial capitals when you define literals.


## See Also
[Literals &#40;F&#35;&#41;](Literals-%5BFSharp%5D.md)

[Core.LiteralAttribute Class &#40;F&#35;&#41;](Core.LiteralAttribute-Class-%5BFSharp%5D.md)