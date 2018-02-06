---
title: "Default values table (C# Reference)"
descripton: Learn what are the default values of value types returned by the default constructors.
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "constructors [C#], return values"
  - "keywords [C#], new"
  - "default constructor [C#]"
  - "defaults [C#]"
  - "value types [C#], initializing"
  - "variables [C#], value types"
  - "constructors [C#], default constructor"
  - "types [C#], default constructor return values"
ms.assetid: 4af2c1df-9e3a-48c1-83ac-b192986fc5bc
caps.latest.revision: 12
author: "BillWagner"
ms.author: "wiwagn"
---
# Default values table (C# Reference)
The following table shows the default values of value types returned by the default constructors. Default constructors are invoked by using the `new` operator, as follows:

```csharp
int myInt = new int();
```

The preceding statement has the same effect as the following statement:

```csharp
int myInt = 0;
```

Remember that using uninitialized variables in C# is not allowed.

|Value type|Default value|
|----------------|-------------------|
|[bool](../../../csharp/language-reference/keywords/bool.md)|`false`|
|[byte](../../../csharp/language-reference/keywords/byte.md)|0|
|[char](../../../csharp/language-reference/keywords/char.md)|'\0'|
|[decimal](../../../csharp/language-reference/keywords/decimal.md)|0M|
|[double](../../../csharp/language-reference/keywords/double.md)|0.0D|
|[enum](../../../csharp/language-reference/keywords/enum.md)|The value produced by the expression (E)0, where E is the enum identifier.|
|[float](../../../csharp/language-reference/keywords/float.md)|0.0F|
|[int](../../../csharp/language-reference/keywords/int.md)|0|
|[long](../../../csharp/language-reference/keywords/long.md)|0L|
|[sbyte](../../../csharp/language-reference/keywords/sbyte.md)|0|
|[short](../../../csharp/language-reference/keywords/short.md)|0|
|[struct](../../../csharp/language-reference/keywords/struct.md)|The value produced by setting all value-type fields to their default values and all reference-type fields to `null`.|
|[uint](../../../csharp/language-reference/keywords/uint.md)|0|
|[ulong](../../../csharp/language-reference/keywords/ulong.md)|0|
|[ushort](../../../csharp/language-reference/keywords/ushort.md)|0|

## See also
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Value Types Table](../../../csharp/language-reference/keywords/value-types-table.md)  
 [Value Types](../../../csharp/language-reference/keywords/value-types.md)  
 [Built-In Types Table](../../../csharp/language-reference/keywords/built-in-types-table.md)  
 [Reference Tables for Types](../../../csharp/language-reference/keywords/reference-tables-for-types.md)
