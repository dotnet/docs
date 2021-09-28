---
description: "Learn more about: Conversions Between Strings and Other Types (Visual Basic)"
title: "Conversions Between Strings and Other Types"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "data type conversion [Visual Basic], string"
  - "conversions [Visual Basic], type"
  - "string conversion [Visual Basic]"
  - "conversions [Visual Basic], data type"
  - "type conversion [Visual Basic], string"
  - "regional options"
ms.assetid: c3a99596-f09a-44a5-81dd-1b89a094f1df
---
# Conversions Between Strings and Other Types (Visual Basic)

You can convert a numeric, `Boolean`, or date/time value to a `String`. You can also convert in the reverse direction — from a string value to numeric, `Boolean`, or `Date` — provided the contents of the string can be interpreted as a valid value of the destination data type. If they cannot, a run-time error occurs.  
  
 The conversions for all these assignments, in either direction, are narrowing conversions. You should use the type conversion keywords (`CBool`, `CByte`, `CDate`, `CDbl`, `CDec`, `CInt`, `CLng`, `CSByte`, `CShort`, `CSng`, `CStr`, `CUInt`, `CULng`, `CUShort`, and `CType`). The <xref:Microsoft.VisualBasic.Strings.Format%2A> and <xref:Microsoft.VisualBasic.Conversion.Val%2A> functions give you additional control over conversions between strings and numbers.  
  
 If you have defined a class or structure, you can define type conversion operators between `String` and the type of your class or structure. For more information, see [How to: Define a Conversion Operator](../procedures/how-to-define-a-conversion-operator.md).  
  
## Conversion of Numbers to Strings  

 You can use the `Format` function to convert a number to a formatted string, which can include not only the appropriate digits but also formatting symbols such as a currency sign (such as `$`), thousands separators or *digit grouping symbols* (such as `,`), and a decimal separator (such as `.`). `Format` automatically uses the appropriate symbols according to the **Regional Options** settings specified in the Windows **Control Panel**.  
  
 Note that the concatenation (`&`) operator can convert a number to a string implicitly, as the following example shows.  
  
```vb  
' The following statement converts count to a String value.  
Str = "The total count is " & count  
```  
  
## Conversion of Strings to Numbers  

 You can use the `Val` function to explicitly convert the digits in a string to a number. `Val` reads the string until it encounters a character other than a digit, space, tab, line feed, or period. The sequences "&O" and "&H" alter the base of the number system and terminate the scanning. Until it stops reading, `Val` converts all appropriate characters to a numeric value. For example, the following statement returns the value `141.825`.  
  
 `Val("   14   1.825 miles")`  
  
 When Visual Basic converts a string to a numeric value, it uses the **Regional Options** settings specified in the Windows **Control Panel** to interpret the thousands separator, decimal separator, and currency symbol. This means that a conversion might succeed under one setting but not another. For example, `"$14.20"` is acceptable in the English (United States) locale but not in any French locale.  
  
## See also

- [Type Conversions in Visual Basic](type-conversions.md)
- [Widening and Narrowing Conversions](widening-and-narrowing-conversions.md)
- [Implicit and Explicit Conversions](implicit-and-explicit-conversions.md)
- [How to: Convert an Object to Another Type in Visual Basic](how-to-convert-an-object-to-another-type.md)
- [Array Conversions](array-conversions.md)
- [Data Types](../../../language-reference/data-types/index.md)
- [Type Conversion Functions](../../../language-reference/functions/type-conversion-functions.md)
- [Develop globalized and localized apps](/visualstudio/ide/globalizing-and-localizing-applications)
