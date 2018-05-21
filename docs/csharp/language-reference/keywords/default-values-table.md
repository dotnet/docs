---
title: "Default values table (C# Reference)"
description: Learn what are the default values of value types returned by the default constructors.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "constructors [C#], return values"
  - "keywords [C#], new"
  - "default constructor [C#]"
  - "defaults [C#]"
  - "value types [C#], initializing"
  - "variables [C#], value types"
  - "constructors [C#], default constructor"
  - "types [C#], default constructor return values"
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
|[bool](bool.md)|`false`|
|[byte](byte.md)|0|
|[char](char.md)|'\0'|
|[decimal](decimal.md)|0M|
|[double](double.md)|0.0D|
|[enum](enum.md)|The value produced by the expression (E)0, where E is the enum identifier.|
|[float](float.md)|0.0F|
|[int](int.md)|0|
|[long](long.md)|0L|
|[sbyte](sbyte.md)|0|
|[short](short.md)|0|
|[struct](struct.md)|The value produced by setting all value-type fields to their default values and all reference-type fields to `null`.|
|[uint](uint.md)|0|
|[ulong](ulong.md)|0|
|[ushort](ushort.md)|0|

## See also
 [C# Reference](../index.md)  
 [C# Programming Guide](../../programming-guide/index.md)  
 [Value Types Table](value-types-table.md)  
 [Value Types](value-types.md)  
 [Built-In Types Table](built-in-types-table.md)  
 [Reference Tables for Types](reference-tables-for-types.md)
