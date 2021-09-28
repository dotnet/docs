---
description: "Learn more about: Efficient Use of Data Types (Visual Basic)"
title: "Efficient Use of Data Types"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "performance, data type efficiency"
  - "data types [Visual Basic], weak typing"
  - "AscW function [Visual Basic], preferred to Asc"
  - "data types [Visual Basic], using efficiently"
  - "optimization [Visual Basic], data types"
  - "data types [Visual Basic], strong typing"
  - "strong typing"
  - "typing, strong"
  - "data types [Visual Basic], optimizing"
  - "ChrW function [Visual Basic], preferred to Chr"
ms.assetid: 28f5e4ba-ec24-4f37-b90a-e8ee822f778a
---
# Efficient Use of Data Types (Visual Basic)

Undeclared variables and variables declared without a data type are assigned the `Object` data type. This makes it easy to write programs quickly, but it can cause them to execute more slowly.

## Strong Typing

 Specifying data types for all your variables is known as *strong typing*. Using strong typing has several advantages:

- It enables IntelliSense support for your variables. This allows you to see their properties and other members as you type in the code.

- It takes advantage of compiler type checking. This catches statements that can fail at run time due to errors such as overflow. It also catches calls to methods on objects that do not support them.

- It results in faster execution of your code.

## Most Efficient Data Types

 For variables that never contain fractions, the integral data types are more efficient than the nonintegral types. In Visual Basic, `Integer` and `UInteger` are the most efficient numeric types.

 For fractional numbers, `Double` is the most efficient data type, because the processors on current platforms perform floating-point operations in double precision. However, operations with `Double` are not as fast as with the integral types such as `Integer`.

## Specifying Data Type

 Use the [Dim Statement](../../../language-reference/statements/dim-statement.md) to declare a variable of a specific type. You can simultaneously specify its access level by using the [Public](../../../language-reference/modifiers/public.md), [Protected](../../../language-reference/modifiers/protected.md), [Friend](../../../language-reference/modifiers/friend.md), or [Private](../../../language-reference/modifiers/private.md) keyword, as in the following example.

```vb
Private x As Double
Protected s As String
```

## Character Conversion

 The `AscW` and `ChrW` functions operate in Unicode. You should use them in preference to `Asc` and `Chr`, which must translate into and out of Unicode.

## See also

- <xref:Microsoft.VisualBasic.Strings.Asc%2A>
- <xref:Microsoft.VisualBasic.Strings.AscW%2A>
- <xref:Microsoft.VisualBasic.Strings.Chr%2A>
- <xref:Microsoft.VisualBasic.Strings.ChrW%2A>
- [Data Types](index.md)
- [Numeric Data Types](numeric-data-types.md)
- [Variable Declaration](../variables/variable-declaration.md)
- [Using IntelliSense](/visualstudio/ide/using-intellisense)
