---
title: "Implicit and Explicit Conversions (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "conversions [Visual Basic], type"
  - "variables [Visual Basic], changing data type"
  - "casting"
  - "conversions [Visual Basic], data type"
  - "type conversion [Visual Basic], implicit conversions"
  - "CType function [Visual Basic], conversions"
  - "casting, data types"
  - "data type conversion [Visual Basic], explicit"
  - "type conversion [Visual Basic], explicit conversions"
  - "data types [Visual Basic], casting"
  - "conversions [Visual Basic], implicit"
  - "explicit data type conversions [Visual Basic]"
  - "conversions [Visual Basic]"
  - "changing data types [Visual Basic]"
  - "conversions [Visual Basic], explicit"
  - "data type conversion [Visual Basic], implicit"
  - "implicit data type conversions [Visual Basic]"
ms.assetid: 77de1659-af8a-492c-967e-e7ef60ccce66
caps.latest.revision: 25
author: dotnet-bot
ms.author: dotnetcontent
---
# Implicit and Explicit Conversions (Visual Basic)
An *implicit conversion* does not require any special syntax in the source code. In the following example, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] implicitly converts the value of `k` to a single-precision floating-point value before assigning it to `q`.  
  
```  
Dim k As Integer  
Dim q As Double  
' Integer widens to Double, so you can do this with Option Strict On.  
k = 432  
q = k  
```  
  
 An *explicit conversion* uses a type conversion keyword. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] provides several such keywords, which coerce an expression in parentheses to the desired data type. These keywords act like functions, but the compiler generates the code inline, so execution is slightly faster than with a function call.  
  
 In the following extension of the preceding example, the `CInt` keyword converts the value of `q` back to an integer before assigning it to `k`.  
  
```  
' q had been assigned the value 432 from k.  
q = Math.Sqrt(q)  
k = CInt(q)  
' k now has the value 21 (rounded square root of 432).  
```  
  
## Conversion Keywords  
 The following table shows the available conversion keywords.  
  
|Type conversion keyword|Converts an expression to data type|Allowable data types of expression to be converted|  
|---|---|---|  
|`CBool`|[Boolean Data Type](../../../../visual-basic/language-reference/data-types/boolean-data-type.md)|Any numeric type (including `Byte`, `SByte`, and enumerated types), `String`, `Object`|  
|`CByte`|[Byte Data Type](../../../../visual-basic/language-reference/data-types/byte-data-type.md)|Any numeric type (including `SByte` and enumerated types), `Boolean`, `String`, `Object`|  
|`CChar`|[Char Data Type](../../../../visual-basic/language-reference/data-types/char-data-type.md)|`String`, `Object`|  
|`CDate`|[Date Data Type](../../../../visual-basic/language-reference/data-types/date-data-type.md)|`String`, `Object`|  
|`CDbl`|[Double Data Type](../../../../visual-basic/language-reference/data-types/double-data-type.md)|Any numeric type (including `Byte`, `SByte`, and enumerated types), `Boolean`, `String`, `Object`|  
|`CDec`|[Decimal Data Type](../../../../visual-basic/language-reference/data-types/decimal-data-type.md)|Any numeric type (including `Byte`, `SByte`, and enumerated types), `Boolean`, `String`, `Object`|  
|`CInt`|[Integer Data Type](../../../../visual-basic/language-reference/data-types/integer-data-type.md)|Any numeric type (including `Byte`, `SByte`, and enumerated types), `Boolean`, `String`, `Object`|  
|`CLng`|[Long Data Type](../../../../visual-basic/language-reference/data-types/long-data-type.md)|Any numeric type (including `Byte`, `SByte`, and enumerated types), `Boolean`, `String`, `Object`|  
|`CObj`|[Object Data Type](../../../../visual-basic/language-reference/data-types/object-data-type.md)|Any type|  
|`CSByte`|[SByte Data Type](../../../../visual-basic/language-reference/data-types/sbyte-data-type.md)|Any numeric type (including `Byte` and enumerated types), `Boolean`, `String`, `Object`|  
|`CShort`|[Short Data Type](../../../../visual-basic/language-reference/data-types/short-data-type.md)|Any numeric type (including `Byte`, `SByte`, and enumerated types), `Boolean`, `String`, `Object`|  
|`CSng`|[Single Data Type](../../../../visual-basic/language-reference/data-types/single-data-type.md)|Any numeric type (including `Byte`, `SByte`, and enumerated types), `Boolean`, `String`, `Object`|  
|`CStr`|[String Data Type](../../../../visual-basic/language-reference/data-types/string-data-type.md)|Any numeric type (including `Byte`, `SByte`, and enumerated types), `Boolean`, `Char`, `Char` array, `Date`, `Object`|  
|`CType`|Type specified following the comma (`,`)|When converting to an *elementary data type* (including an array of an elementary type), the same types as allowed for the corresponding conversion keyword<br /><br /> When converting to a *composite data type*, the interfaces it implements and the classes from which it inherits<br /><br /> When converting to a class or structure on which you have overloaded `CType`, that class or structure|  
|`CUInt`|[UInteger Data Type](../../../../visual-basic/language-reference/data-types/uinteger-data-type.md)|Any numeric type (including `Byte`, `SByte`, and enumerated types), `Boolean`, `String`, `Object`|  
|`CULng`|[ULong Data Type](../../../../visual-basic/language-reference/data-types/ulong-data-type.md)|Any numeric type (including `Byte`, `SByte`, and enumerated types), `Boolean`, `String`, `Object`|  
|`CUShort`|[UShort Data Type](../../../../visual-basic/language-reference/data-types/ushort-data-type.md)|Any numeric type (including `Byte`, `SByte`, and enumerated types), `Boolean`, `String`, `Object`|  
  
## The CType Function  
 The [CType Function](../../../../visual-basic/language-reference/functions/ctype-function.md) operates on two arguments. The first is the expression to be converted, and the second is the destination data type or object class. Note that the first argument must be an expression, not a type.  
  
 `CType` is an *inline function*, meaning the compiled code makes the conversion, often without generating a function call. This improves performance.  
  
 For a comparison of `CType` with the other type conversion keywords, see [DirectCast Operator](../../../../visual-basic/language-reference/operators/directcast-operator.md) and [TryCast Operator](../../../../visual-basic/language-reference/operators/trycast-operator.md).  
  
### Elementary Types  
 The following example demonstrates the use of `CType`.  
  
```  
k = CType(q, Integer)  
' The following statement coerces w to the specific object class Label.  
f = CType(w, Label)  
```  
  
### Composite Types  
 You can use `CType` to convert values to composite data types as well as to elementary types. You can also use it to coerce an object class to the type of one of its interfaces, as in the following example.  
  
```  
' Assume class cZone implements interface iZone.  
Dim h As Object  
' The first argument to CType must be an expression, not a type.  
Dim cZ As cZone  
' The following statement coerces a cZone object to its interface iZone.  
h = CType(cZ, iZone)  
```  
  
### Array Types  
 `CType` can also convert array data types, as in the following example.  
  
```  
Dim v() As classV  
Dim obArray() As Object  
' Assume some object array has been assigned to obArray.  
' Check for run-time type compatibility.  
If TypeOf obArray Is classV()  
    ' obArray can be converted to classV.  
    v = CType(obArray, classV())  
End If  
```  
  
 For more information and an example, see [Array Conversions](../../../../visual-basic/programming-guide/language-features/data-types/array-conversions.md).  
  
### Types Defining CType  
 You can define `CType` on a class or structure you have defined. This allows you to convert values to and from the type of your class or structure. For more information and an example, see [How to: Define a Conversion Operator](../../../../visual-basic/programming-guide/language-features/procedures/how-to-define-a-conversion-operator.md).  
  
> [!NOTE]
>  Values used with a conversion keyword must be valid for the destination data type, or an error occurs. For example, if you attempt to convert a `Long` to an `Integer`, the value of the `Long` must be within the valid range for the `Integer` data type.  
  
> [!CAUTION]
>  Specifying `CType` to convert from one class type to another fails at run time if the source type does not derive from the destination type. Such a failure throws an <xref:System.InvalidCastException> exception.  
  
 However, if one of the types is a structure or class you have defined, and if you have defined `CType` on that structure or class, a conversion can succeed if it satisfies the requirements of your `CType`. See [How to: Define a Conversion Operator](../../../../visual-basic/programming-guide/language-features/procedures/how-to-define-a-conversion-operator.md).  
  
 Performing an explicit conversion is also known as *casting* an expression to a given data type or object class.  
  
## See Also  
 [Type Conversions in Visual Basic](../../../../visual-basic/programming-guide/language-features/data-types/type-conversions.md)  
 [Conversions Between Strings and Other Types](../../../../visual-basic/programming-guide/language-features/data-types/conversions-between-strings-and-other-types.md)  
 [How to: Convert an Object to Another Type in Visual Basic](../../../../visual-basic/programming-guide/language-features/data-types/how-to-convert-an-object-to-another-type.md)  
 [Structures](../../../../visual-basic/programming-guide/language-features/data-types/structures.md)  
 [Data Types](../../../../visual-basic/language-reference/data-types/data-type-summary.md)  
 [Type Conversion Functions](../../../../visual-basic/language-reference/functions/type-conversion-functions.md)  
 [Troubleshooting Data Types](../../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md)
