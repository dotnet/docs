---
description: "Learn more about: Miscellaneous Data Types (Visual Basic)"
title: "Miscellaneous Data Types"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "Object data type [Visual Basic], data types"
  - "data types [Visual Basic], choosing"
ms.assetid: 64c71a12-9057-4dbf-baca-7379c4aada69
---
# Miscellaneous Data Types (Visual Basic)

Visual Basic supplies several data types that are not oriented toward numbers or characters. Instead, they deal with specialized data such as yes/no values, date/time values, and object addresses.  
  
 For a table showing a side-by-side comparison of the Visual Basic data types, see [Data Types](../../../language-reference/data-types/index.md).  
  
## Boolean Type  

 The [Boolean Data Type](../../../language-reference/data-types/boolean-data-type.md) is an unsigned value that is interpreted as either `True` or `False`. Its data width depends on the implementing platform. If a variable can contain only two-state values such as true/false, yes/no, or on/off, declare it as `Boolean`.  
  
## Date Type  

 The [Date Data Type](../../../language-reference/data-types/date-data-type.md) is a 64-bit value that holds both date and time information. Each increment represents 100 nanoseconds of elapsed time since the beginning (12:00 AM) of January 1 of the year 1 in the Gregorian calendar. If a variable can contain a date value, a time value, or both, declare it as `Date`.  
  
## Object Type  

 The [Object Data Type](../../../language-reference/data-types/object-data-type.md) is a 32-bit address that points to an object instance within your application or in some other application. An `Object` variable can refer to any object your application recognizes, or to data of any data type. This includes both *value types*, such as `Integer`, `Boolean`, and structure instances, and *reference types*, which are instances of objects created from classes such as `String` and <xref:System.Windows.Forms.Form>, and array instances.  
  
 If a variable stores a pointer to an instance of a class that you do not know at compile time, or if it can point to data of various data types, declare it as `Object`.  
  
 The advantage of the `Object` data type is that you can use it to store data of any data type. The disadvantage is that you incur extra operations that take more execution time and make your application perform slower. If you use an `Object` variable for value types, you incur *boxing* and *unboxing*. If you use it for reference types, you incur *late binding*.  
  
## See also

- [Type Characters](type-characters.md)
- [Elementary Data Types](elementary-data-types.md)
- [Numeric Data Types](numeric-data-types.md)
- [Character Data Types](character-data-types.md)
- [Troubleshooting Data Types](troubleshooting-data-types.md)
- [Early and Late Binding](../early-late-binding/index.md)
