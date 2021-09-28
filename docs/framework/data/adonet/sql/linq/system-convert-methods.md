---
description: "Learn more about: System.Convert Methods"
title: "System.Convert Methods"
ms.date: "03/30/2017"
ms.assetid: 3ca6c5b6-ea5d-4ab0-b675-f082135b342c
---
# System.Convert Methods

[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not support the following <xref:System.Convert> methods.

- Versions with an <xref:System.IFormatProvider> parameter.

- Methods that involve char arrays or byte arrays:

  - <xref:System.Convert.FromBase64CharArray%2A>

  - <xref:System.Convert.ToBase64CharArray%2A>

  - <xref:System.Convert.FromBase64String%2A>

  - <xref:System.Convert.ToBase64String%2A>

- The following methods:

  - `public static <Type2> To<Type2>(<Type1> value);` where

    `Type1` and `Type2` are each one of `sbyte`, `uint`, `ulong`, or `ushort`.

  - C#:

    `int To<int type>(string value, int fromBase),`

    `ToString(... value, int toBase)`

  - Visual Basic:

    `Function To(Of [Numeric])(value as String, fromBase As Integer)`

    `As [Numeric], ToString( value As …, toBase As Integer)`

  - <xref:System.Convert.IsDBNull%2A>

  - <xref:System.Convert.GetTypeCode%2A>

  - <xref:System.Convert.ChangeType%2A>

## See also

- [Data Types and Functions](data-types-and-functions.md)
