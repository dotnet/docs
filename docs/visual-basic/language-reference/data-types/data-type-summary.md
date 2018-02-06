---
title: "Data Type Summary (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "Boolean data type [Visual Basic], supported types in Visual Basic"
  - "storage [Visual Basic], order of storage"
  - "data types [Visual Basic], Visual Basic"
  - "Single data type [Visual Basic], supported types in Visual Basic"
  - "notation [Visual Basic], scientific"
  - "memory requirements, data types"
  - "user-defined data types [Visual Basic], Visual Basic"
  - "Date data type [Visual Basic], Visual Basic"
  - "Visual Basic, data types"
  - "storage [Visual Basic], allocation"
  - "Integer data type [Visual Basic], Visual Basic data types"
  - "storage [Visual Basic], space"
  - "Variant data types [Visual Basic], supported types in Visual Basic"
  - "Char data type [Visual Basic], Visual Basic data types"
  - "intrinsic data types [Visual Basic]"
  - "memory consumption [Visual Basic], data types"
  - "single-precision numbers"
  - "data types [Visual Basic], order of storage"
  - "Long data type [Visual Basic], supported types in Visual Basic"
  - "String data type [Visual Basic], Visual Basic data types"
  - "storage order, data types"
  - "StructLayoutAttribute class, Visual Basic data type storage"
  - "scientific notation"
  - "Double data type [Visual Basic], Visual Basic data types"
  - "Byte data type [Visual Basic], Visual Basic data types"
  - "Object data type [Visual Basic], supported types in Visual Basic"
  - "data types [Visual Basic], storage allocation"
  - "double-precision numbers"
  - "data types [Visual Basic], summary"
  - "dates [Visual Basic], data types"
  - "strings [Visual Basic], data types"
  - "memory consumption"
  - "storage order, controlling in Visual Basic"
  - "data types [Visual Basic], memory requirements"
ms.assetid: e975cdb6-64d8-4a4a-ae27-f3b3ed198ae0
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
---
# Data Type Summary (Visual Basic)
The following table shows the Visual Basic data types, their supporting common language runtime types, their nominal storage allocation, and their value ranges.  
  
|Visual Basic type|Common language runtime type structure|Nominal storage allocation|Value range|  
|-----------------------|--------------------------------------------|--------------------------------|-----------------|  
|[Boolean](../../../visual-basic/language-reference/data-types/boolean-data-type.md)|<xref:System.Boolean>|Depends on implementing platform|`True` or `False`|  
|[Byte](../../../visual-basic/language-reference/data-types/byte-data-type.md)|<xref:System.Byte>|1 byte|0 through 255 (unsigned)|  
|[Char](../../../visual-basic/language-reference/data-types/char-data-type.md) (single character)|<xref:System.Char>|2 bytes|0 through 65535 (unsigned)|  
|[Date](../../../visual-basic/language-reference/data-types/date-data-type.md)|<xref:System.DateTime>|8 bytes|0:00:00 (midnight) on January 1, 0001 through 11:59:59 PM on December 31, 9999|  
|[Decimal](../../../visual-basic/language-reference/data-types/decimal-data-type.md)|<xref:System.Decimal>|16 bytes|0 through +/-79,228,162,514,264,337,593,543,950,335 (+/-7.9...E+28) <sup>†</sup> with no decimal point; 0 through +/-7.9228162514264337593543950335 with 28 places to the right of the decimal;<br /><br /> smallest nonzero number is +/-0.0000000000000000000000000001 (+/-1E-28) <sup>†</sup>|  
|[Double](../../../visual-basic/language-reference/data-types/double-data-type.md) (double-precision floating-point)|<xref:System.Double>|8 bytes|-1.79769313486231570E+308 through -4.94065645841246544E-324 <sup>†</sup> for negative values;<br /><br /> 4.94065645841246544E-324 through 1.79769313486231570E+308 <sup>†</sup> for positive values|  
|[Integer](../../../visual-basic/language-reference/data-types/integer-data-type.md)|<xref:System.Int32>|4 bytes|-2,147,483,648 through 2,147,483,647 (signed)|  
|[Long](../../../visual-basic/language-reference/data-types/long-data-type.md) (long integer)|<xref:System.Int64>|8 bytes|-9,223,372,036,854,775,808 through 9,223,372,036,854,775,807 (9.2...E+18 <sup>†</sup>) (signed)|  
|[Object](../../../visual-basic/language-reference/data-types/object-data-type.md)|<xref:System.Object> (class)|4 bytes on 32-bit platform<br /><br /> 8 bytes on 64-bit platform|Any type can be stored in a variable of type `Object`|  
|[SByte](../../../visual-basic/language-reference/data-types/sbyte-data-type.md)|<xref:System.SByte>|1 byte|-128 through 127 (signed)|  
|[Short](../../../visual-basic/language-reference/data-types/short-data-type.md) (short integer)|<xref:System.Int16>|2 bytes|-32,768 through 32,767 (signed)|  
|[Single](../../../visual-basic/language-reference/data-types/single-data-type.md) (single-precision floating-point)|<xref:System.Single>|4 bytes|-3.4028235E+38 through -1.401298E-45 <sup>†</sup> for negative values;<br /><br /> 1.401298E-45 through 3.4028235E+38 <sup>†</sup> for positive values|  
|[String](../../../visual-basic/language-reference/data-types/string-data-type.md) (variable-length)|<xref:System.String> (class)|Depends on implementing platform|0 to approximately 2 billion Unicode characters|  
|[UInteger](../../../visual-basic/language-reference/data-types/uinteger-data-type.md)|<xref:System.UInt32>|4 bytes|0 through 4,294,967,295 (unsigned)|  
|[ULong](../../../visual-basic/language-reference/data-types/ulong-data-type.md)|<xref:System.UInt64>|8 bytes|0 through 18,446,744,073,709,551,615 (1.8...E+19 <sup>†</sup>) (unsigned)|  
|[User-Defined](../../../visual-basic/language-reference/data-types/user-defined-data-type.md) (structure)|(inherits from <xref:System.ValueType>)|Depends on implementing platform|Each member of the structure has a range determined by its data type and independent of the ranges of the other members|  
|[UShort](../../../visual-basic/language-reference/data-types/ushort-data-type.md)|<xref:System.UInt16>|2 bytes|0 through 65,535 (unsigned)|  
  
 <sup>†</sup> In *scientific notation*, "E" refers to a power of 10. So 3.56E+2 signifies 3.56 x 10<sup>2</sup> or 356, and 3.56E-2 signifies 3.56 / 10<sup>2</sup> or 0.0356.  
  
> [!NOTE]
>  For strings containing text, use the <xref:Microsoft.VisualBasic.Strings.StrConv%2A> function to convert from one text format to another.  
  
 In addition to specifying a data type in a declaration statement, you can force the data type of some programming elements by using a type character. See [Type Characters](../../../visual-basic/programming-guide/language-features/data-types/type-characters.md).  
  
## Memory Consumption  
 When you declare an elementary data type, it is not safe to assume that its memory consumption is the same as its nominal storage allocation. This is due to the following considerations:  
  
-   **Storage Assignment.** The common language runtime can assign storage based on the current characteristics of the platform on which your application is executing. If memory is nearly full, it might pack your declared elements as closely together as possible. In other cases it might align their memory addresses to natural hardware boundaries to optimize performance.  
  
-   **Platform Width.** Storage assignment on a 64-bit platform is different from assignment on a 32-bit platform.  
  
### Composite Data Types  
 The same considerations apply to each member of a composite data type, such as a structure or an array. You cannot rely on simply adding together the nominal storage allocations of the type's members. Furthermore, there are other considerations, such as the following:  
  
-   **Overhead.** Some composite types have additional memory requirements. For example, an array uses extra memory for the array itself and also for each dimension. On a 32-bit platform, this overhead is currently 12 bytes plus 8 bytes for each dimension. On a 64-bit platform this requirement is doubled.  
  
-   **Storage Layout.** You cannot safely assume that the order of storage in memory is the same as your order of declaration. You cannot even make assumptions about byte alignment, such as a 2-byte or 4-byte boundary. If you are defining a class or structure and you need to control the storage layout of its members, you can apply the <xref:System.Runtime.InteropServices.StructLayoutAttribute> attribute to the class or structure.  
  
### Object Overhead  
 An `Object` referring to any elementary or composite data type uses 4 bytes in addition to the data contained in the data type.  
  
## See Also  
 <xref:Microsoft.VisualBasic.Strings.StrConv%2A>  
 <xref:System.Runtime.InteropServices.StructLayoutAttribute>  
 [Type Conversion Functions](../../../visual-basic/language-reference/functions/type-conversion-functions.md)  
 [Conversion Summary](../../../visual-basic/language-reference/keywords/conversion-summary.md)  
 [Type Characters](../../../visual-basic/programming-guide/language-features/data-types/type-characters.md)  
 [Efficient Use of Data Types](../../../visual-basic/programming-guide/language-features/data-types/efficient-use-of-data-types.md)
