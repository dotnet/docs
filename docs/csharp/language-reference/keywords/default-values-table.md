---
title: "Default values table (C# Reference)"
description: Learn what are the default values of C# value types.
ms.date: 08/23/2018
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

The following table shows the default values of [value types](value-types.md).

|Value type|Default value|
|----------------|-------------------|
|[bool](bool.md)|`false`|
|[byte](byte.md)|0|
|[char](char.md)|'\0'|
|[decimal](decimal.md)|0M|
|[double](double.md)|0.0D|
|[enum](enum.md)|The value produced by the expression `(E)0`, where `E` is the enum identifier.|
|[float](float.md)|0.0F|
|[int](int.md)|0|
|[long](long.md)|0L|
|[sbyte](sbyte.md)|0|
|[short](short.md)|0|
|[struct](struct.md)|The value produced by setting all value-type fields to their default values and all reference-type fields to `null`.|
|[uint](uint.md)|0|
|[ulong](ulong.md)|0|
|[ushort](ushort.md)|0|

## Remarks

You cannot use uninitialized variables in C#. You can initialize a variable with the default value of its type. You also can use the default value of a type to specify the default value of a method's [optional argument](../../programming-guide/classes-and-structs/named-and-optional-arguments.md#optional-arguments).

Use the [default value expression](../../programming-guide/statements-expressions-operators/default-value-expressions.md) to produce the default value of a type, as the following example shows:

```csharp
int a = default(int);
```

Beginning with C# 7.1, you can use the [`default` literal](../../programming-guide/statements-expressions-operators/default-value-expressions.md#default-literal-and-type-inference) to initialize a variable with the default value of its type:

```csharp
int a = default;
```

You also can use the default constructor or the implicit default constructor to produce the default value of a value type, as the following example shows. For more information about constructors, see the [Constructors](../../programming-guide/classes-and-structs/constructors.md) article.

```csharp
int a = new int();
```

The default value of any [reference type](reference-types.md) is `null`. The default value of a [nullable type](../../programming-guide/nullable-types/index.md) is an instance for which the <xref:System.Nullable%601.HasValue%2A> property is `false` and the <xref:System.Nullable%601.Value%2A> property is undefined.

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Reference tables for types](reference-tables-for-types.md)
- [Value types](value-types.md)
- [Value types table](value-types-table.md)
- [Built-in types table](built-in-types-table.md)
