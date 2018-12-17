---
title: Basic Types
description: Discover the fundamental basic types that are used in the F# language.
ms.date: 07/09/2018
---
# Basic types

This topic lists the basic types that are defined in the F# language. These types are the most fundamental in F#, forming the basis of nearly every F# program. They are a superset of .NET primitive types.

|Type|.NET type|Description|
|----|---------|-----------|
|`bool`|<xref:System.Boolean>|Possible values are `true` and `false`.|
|`byte`|<xref:System.Byte>|Values from 0 to 255.|
|`sbyte`|<xref:System.SByte>|Values from -128 to 127.|
|`int16`|<xref:System.Int16>|Values from -32768 to 32767.|
|`uint16`|<xref:System.UInt16>|Values from 0 to 65535.|
|`int`|<xref:System.Int32>|Values from -2,147,483,648 to 2,147,483,647.|
|`uint32`|<xref:System.UInt32>|Values from 0 to 4,294,967,295.|
|`int64`|<xref:System.Int64>|Values from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807.|
|`uint64`|<xref:System.UInt64>|Values from 0 to 18,446,744,073,709,551,615.|
|`nativeint`|<xref:System.IntPtr>|A native pointer as a signed integer.|
|`unativeint`|<xref:System.UIntPtr>|A native pointer as an unsigned integer.|
|`char`|<xref:System.Char>|Unicode character values.|
|`string`|<xref:System.String>|Unicode text.|
|`decimal`|<xref:System.Decimal>|A floating point data type that has at least 28 significant digits.|
|`unit`|not applicable|Indicates the absence of an actual value. The type has only one formal value, which is denoted `()`. The unit value, `()`, is often used as a placeholder where a value is needed but no real value is available or makes sense.|
|`void`|<xref:System.Void>|Indicates no type or value.|
|`float32`, `single`|<xref:System.Single>|A 32-bit floating point type.|
|`float`, `double`|<xref:System.Double>|A 64-bit floating point type.|

> [!NOTE]
> You can perform computations with integers too big for the 64-bit integer type by using the [bigint](https://msdn.microsoft.com/library/dc8be18d-4042-46c4-b136-2f21a84f6efa) type. `bigint` is not considered a basic type; it is an abbreviation for `System.Numerics.BigInteger`.

## See also

- [F# Language Reference](index.md)