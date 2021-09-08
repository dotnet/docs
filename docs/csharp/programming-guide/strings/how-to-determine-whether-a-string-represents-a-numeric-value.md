---
title: "How to determine whether a string represents a numeric value - C# Programming Guide"
description: Learn how to determine whether a string is a valid representation of a specified numeric type. See code examples and view additional resources.
ms.topic: how-to
ms.date: 07/20/2015
helpviewer_keywords: 
  - "numeric strings [C#]"
  - "validating numeric input [C#]"
  - "strings [C#], numeric"
ms.assetid: a4e84e10-ea0a-489f-a868-503dded9d85f
---
# How to determine whether a string represents a numeric value (C# Programming Guide)

To determine whether a string is a valid representation of a specified numeric type, use the static `TryParse` method that is implemented by all primitive numeric types and also by types such as <xref:System.DateTime> and <xref:System.Net.IPAddress>. The following example shows how to determine whether "108" is a valid [int](../../language-reference/builtin-types/integral-numeric-types.md).  
  
```csharp  
int i = 0;
string s = "108";  
bool result = int.TryParse(s, out i); //i now = 108  
```  
  
 If the string contains nonnumeric characters or the numeric value is too large or too small for the particular type you have specified, `TryParse` returns false and sets the out parameter to zero. Otherwise, it returns true and sets the out parameter to the numeric value of the string.  
  
> [!NOTE]
> A string may contain only numeric characters and still not be valid for the type whose `TryParse` method that you use. For example, "256" is not a valid value for `byte` but it is valid for `int`. "98.6" is not a valid value for `int` but it is a valid `decimal`.  
  
## Example  

 The following examples show how to use `TryParse` with string representations of `long`, `byte`, and `decimal` values.  
  
 [!code-csharp[csProgGuideStrings#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStrings/CS/Strings.cs#14)]  
  
## Robust Programming  

 Primitive numeric types also implement the `Parse` static method, which throws an exception if the string is not a valid number. `TryParse` is generally more efficient because it just returns false if the number is not valid.  
  
## .NET Security  

 Always use the `TryParse` or `Parse` methods to validate user input from controls such as text boxes and combo boxes.  
  
## See also

- [How to convert a byte array to an int](../types/how-to-convert-a-byte-array-to-an-int.md)
- [How to convert a string to a number](../types/how-to-convert-a-string-to-a-number.md)
- [How to convert between hexadecimal strings and numeric types](../types/how-to-convert-between-hexadecimal-strings-and-numeric-types.md)
- [Parsing Numeric Strings](../../../standard/base-types/parsing-numeric.md)
- [Formatting Types](../../../standard/base-types/formatting-types.md)
