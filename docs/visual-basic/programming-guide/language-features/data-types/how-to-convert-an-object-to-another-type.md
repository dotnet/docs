---
description: "Learn more about: How to: Convert an Object to Another Type in Visual Basic"
title: "How to: Convert an Object to Another Type"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "objects [Visual Basic], converting"
ms.assetid: 60cb5fc7-7ba4-4ab5-9c24-480fa12ddcdc
ms.topic: how-to
---
# How to: Convert an Object to Another Type in Visual Basic

You convert an `Object` variable to another data type by using a conversion keyword such as [CType Function](../../../language-reference/functions/ctype-function.md).  
  
## Example  

 The following example converts an `Object` variable to an `Integer` and a `String`.  
  
```vb  
Public Sub objectConversion(ByVal anObject As Object)  
    Dim anInteger As Integer  
    Dim aString As String  
    anInteger = CType(anObject, Integer)  
    aString = CType(anObject, String)  
End Sub  
```  
  
 If you know that the contents of an `Object` variable are of a particular data type, it is better to convert the variable to that data type. If you continue to use the `Object` variable, you incur either *boxing* and *unboxing* (for a value type) or *late binding* (for a reference type). These operations all take extra execution time and make your performance slower.  
  
## Compile the code  

 This example requires:  
  
- A reference to the <xref:System?displayProperty=nameWithType> namespace.  
  
## See also

- <xref:System.Object>
- [Type Conversions in Visual Basic](type-conversions.md)
- [Widening and Narrowing Conversions](widening-and-narrowing-conversions.md)
- [Implicit and Explicit Conversions](implicit-and-explicit-conversions.md)
- [Conversions Between Strings and Other Types](conversions-between-strings-and-other-types.md)
- [Array Conversions](array-conversions.md)
- [Structures](structures.md)
- [Data Types](../../../language-reference/data-types/index.md)
- [Type Conversion Functions](../../../language-reference/functions/type-conversion-functions.md)
