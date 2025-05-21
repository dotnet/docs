---
description: "Learn more about: Widening and Narrowing Conversions (Visual Basic)"
title: "Widening and Narrowing Conversions"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "widening conversions [Visual Basic]"
  - "narrowing conversions [Visual Basic]"
  - "conversions [Visual Basic], type"
  - "data types [Visual Basic], changing"
  - "variables [Visual Basic], changing data type"
  - "conversions [Visual Basic], exceptions during conversion"
  - "type conversion [Visual Basic], exceptions during conversion"
  - "conversions [Visual Basic], data type"
  - "conversions [Visual Basic], narrowing"
  - "type conversion [Visual Basic], narrowing"
  - "data type conversion [Visual Basic], widening"
  - "data type conversion [Visual Basic], narrowing"
  - "changing data types [Visual Basic]"
  - "type conversion [Visual Basic], widening"
  - "data type conversion [Visual Basic], exceptions during conversion"
  - "conversions [Visual Basic], widening"
ms.assetid: 058c3152-6c28-4268-af44-2209e774f0bd
ms.topic: concept-article
---
# Widening and Narrowing Conversions (Visual Basic)

An important consideration with a type conversion is whether the result of the conversion is within the range of the destination data type.  
  
 A *widening conversion* changes a value to a data type that can allow for any possible value of the original data.  Widening conversions preserve the source value but can change its representation. This occurs if you convert from an integral type to `Decimal`, or from `Char` to `String`.  
  
 A *narrowing conversion* changes a value to a data type that might not be able to hold some of the possible values. For example, a fractional value is rounded when it is converted to an integral type, and a numeric type being converted to `Boolean` is reduced to either `True` or `False`.  
  
## Widening Conversions  

 The following table shows the standard widening conversions.  
  
|Data type|Widens to data types <sup>1</sup>|  
|---|---|  
|[SByte](../../../language-reference/data-types/sbyte-data-type.md)|`SByte`, `Short`, `Integer`, `Long`, `Decimal`, `Single`, `Double`|  
|[Byte](../../../language-reference/data-types/byte-data-type.md)|`Byte`, `Short`, `UShort`, `Integer`, `UInteger`, `Long`, `ULong`, `Decimal`, `Single`, `Double`|  
|[Short](../../../language-reference/data-types/short-data-type.md)|`Short`, `Integer`, `Long`, `Decimal`, `Single`, `Double`|  
|[UShort](../../../language-reference/data-types/ushort-data-type.md)|`UShort`, `Integer`, `UInteger`, `Long`, `ULong`, `Decimal`, `Single`, `Double`|  
|[Integer](../../../language-reference/data-types/integer-data-type.md)|`Integer`, `Long`, `Decimal`, `Single`, `Double`<sup>2</sup>|  
|[UInteger](../../../language-reference/data-types/uinteger-data-type.md)|`UInteger`, `Long`, `ULong`, `Decimal`, `Single`, `Double`<sup>2</sup>|  
|[Long](../../../language-reference/data-types/long-data-type.md)|`Long`, `Decimal`, `Single`, `Double`<sup>2</sup>|  
|[ULong](../../../language-reference/data-types/ulong-data-type.md)|`ULong`, `Decimal`, `Single`, `Double`<sup>2</sup>|  
|[Decimal](../../../language-reference/data-types/decimal-data-type.md)|`Decimal`, `Single`, `Double`<sup>2</sup>|  
|[Single](../../../language-reference/data-types/single-data-type.md)|`Single`, `Double`|  
|[Double](../../../language-reference/data-types/double-data-type.md)|`Double`|  
|Any enumerated type ([Enum](../../../language-reference/statements/enum-statement.md))|Its underlying integral type and any type to which the underlying type widens.|  
|[Char](../../../language-reference/data-types/char-data-type.md)|`Char`, `String`|  
|`Char` array|`Char` array, `String`|  
|Any type|[Object](../../../language-reference/data-types/object-data-type.md)|  
|Any derived type|Any base type from which it is derived <sup>3</sup>.|  
|Any type|Any interface it implements.|  
|[Nothing](../../../language-reference/nothing.md)|Any data type or object type.|  
  
 <sup>1</sup> By definition, every data type widens to itself.  
  
 <sup>2</sup> Conversions from `Integer`, `UInteger`, `Long`, `ULong`, or `Decimal` to `Single` or `Double` might result in loss of precision, but never in loss of magnitude. In this sense they do not incur information loss.  
  
 <sup>3</sup> It might seem surprising that a conversion from a derived type to one of its base types is widening. The justification is that the derived type contains all the members of the base type, so it qualifies as an instance of the base type. In the opposite direction, the base type does not contain any new members defined by the derived type.  
  
 Widening conversions always succeed at run time and never incur data loss. You can always perform them implicitly, whether the [Option Strict Statement](../../../language-reference/statements/option-strict-statement.md) sets the type checking switch to `On` or to `Off`.  
  
## Narrowing Conversions  

 The standard narrowing conversions include the following:  
  
- The reverse directions of the widening conversions in the preceding table (except that every type widens to itself)  
  
- Conversions in either direction between [Boolean](../../../language-reference/data-types/boolean-data-type.md) and any numeric type  
  
- Conversions from any numeric type to any enumerated type (`Enum`)  
  
- Conversions in either direction between [String](../../../language-reference/data-types/string-data-type.md) and any numeric type, `Boolean`, or [Date](../../../language-reference/data-types/date-data-type.md)  
  
- Conversions from a data type or object type to a type derived from it  
  
 Narrowing conversions do not always succeed at run time, and can fail or incur data loss. An error occurs if the destination data type cannot receive the value being converted. For example, a numeric conversion can result in an overflow. The compiler does not allow you to perform narrowing conversions implicitly unless the [Option Strict Statement](../../../language-reference/statements/option-strict-statement.md) sets the type checking switch to `Off`.  
  
> [!NOTE]
> The narrowing-conversion error is suppressed for conversions from the elements in a `For Each…Next` collection to the loop control variable. For more information and examples, see the "Narrowing Conversions" section in [For Each...Next Statement](../../../language-reference/statements/for-each-next-statement.md).  
  
### When to Use Narrowing Conversions  

 You use a narrowing conversion when you know the source value can be converted to the destination data type without error or data loss. For example, if you have a `String` that you know contains either "True" or "False," you can use the `CBool` keyword to convert it to `Boolean`.  
  
## Exceptions During Conversion  

 Because widening conversions always succeed, they do not throw exceptions. Narrowing conversions, when they fail, most commonly throw the following exceptions:  
  
- <xref:System.InvalidCastException> — if no conversion is defined between the two types  
  
- <xref:System.OverflowException> — (integral types only) if the converted value is too large for the target type  
  
 If a class or structure defines a [CType Function](../../../language-reference/functions/ctype-function.md) to serve as a conversion operator to or from that class or structure, that `CType` can throw any exception it deems appropriate. In addition, that `CType` might call Visual Basic functions or .NET Framework methods, which in turn could throw a variety of exceptions.  
  
## Changes During Reference Type Conversions  

 A conversion from a *reference type* copies only the pointer to the value. The value itself is neither copied nor changed in any way. The only thing that can change is the data type of the variable holding the pointer. In the following example, the data type is converted from the derived class to its base class, but the object that both variables now point to is unchanged.  
  
```vb  
' Assume class cSquare inherits from class cShape.  
Dim shape As cShape  
Dim square As cSquare = New cSquare  
' The following statement performs a widening  
' conversion from a derived class to its base class.  
shape = square  
```  
  
## See also

- [Data Types](index.md)
- [Type Conversions in Visual Basic](type-conversions.md)
- [Implicit and Explicit Conversions](implicit-and-explicit-conversions.md)
- [Conversions Between Strings and Other Types](conversions-between-strings-and-other-types.md)
- [How to: Convert an Object to Another Type in Visual Basic](how-to-convert-an-object-to-another-type.md)
- [Array Conversions](array-conversions.md)
- [Data Types](../../../language-reference/data-types/index.md)
- [Type Conversion Functions](../../../language-reference/functions/type-conversion-functions.md)
