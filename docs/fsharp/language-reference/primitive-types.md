---
title: Primitive Types (F#)
description: Discover the fundamental primitive types that are used in the F# language.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 2f23d98b-551b-4fd2-9f4f-0fd7254288ed
---

# Primitive Types

This topic lists the fundamental primitive types that are used in the F# language. It also provides the corresponding .NET types and the minimum and maximum values for each type.

## Summary of Primitive Types
The following table summarizes the properties of the primitive F# types.

|Type|.NET type|Description|
|----|---------|-----------|
|`bool`|`System.Boolean`|Possible values are `true` and `false`.|
|`byte`|`System.Byte`|Values from 0 to 255.|
|`sbyte`|`System.SByte`|Values from -128 to 127.|
|`int16`|`System.Int16`|Values from -32768 to 32767.|
|`uint16`|`System.UInt16`|Values from 0 to 65535.|
|`int`|`System.Int32`|Values from -2,147,483,648 to 2,147,483,647.|
|`uint32`|`System.UInt32`|Values from 0 to 4,294,967,295.|
|`int64`|`System.Int64`|Values from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807.|
|`uint64`|`System.UInt64`|Values from 0 to 18,446,744,073,709,551,615.|
|`nativeint`|`System.IntPtr`|A native pointer as a signed integer.|
|`unativeint`|`System.UIntPtr`|A native pointer as an unsigned integer.|
|`char`|`System.Char`|Unicode character values.|
|`string`|`System.String`|Unicode text.|
|`decimal`|`System.Decimal`|A floating point data type that has at least 28 significant digits.|
|`unit`|not applicable|Indicates the absence of an actual value. The type has only one formal value, which is denoted `()`. The unit value, `()`, is often used as a placeholder where a value is needed but no real value is available or makes sense.|
|`void`|`System.Void`|Indicates no type or value.|
|`float32, single`|`System.Single`|A 32-bit floating point type.|
|`float, double`|`System.Double`|A 64-bit floating point type.|

>[!NOTE]
You can perform computations with integers too big for the 64-bit integer type by using the [bigint](https://msdn.microsoft.com/library/dc8be18d-4042-46c4-b136-2f21a84f6efa) type. `bigint` is not considered a primitive type; it is an abbreviation for `System.Numerics.BigInteger`.

## See Also
[F# Language Reference](index.md)
