---
title: "Default values table - C# reference"
ms.custom: seodec18
description: Learn what are the default values of C# types.
ms.date: 07/29/2019
helpviewer_keywords: 
  - "default [C#]"
  - "parameterless constructor [C#]"
---
# Default values table (C# reference)

The following table shows the default values of C# types:

|Type|Default value|
|---------|------------------|
|Any reference type|`null`|
|Any [built-in integral numeric type](../builtin-types/integral-numeric-types.md)|0 (zero)|
|Any [built-in floating-point numeric type](../builtin-types/floating-point-numeric-types.md)|0 (zero)|
|[bool](bool.md)|`false`|
|[char](char.md)|`'\0'` (U+0000)|
|[enum](enum.md)|The value produced by the expression `(E)0`, where `E` is the enum identifier.|
|[struct](struct.md)|The value produced by setting all value-type fields to their default values and all reference-type fields to `null`.|
|Any [nullable value type](../../programming-guide/nullable-types/index.md)|An instance for which the <xref:System.Nullable%601.HasValue%2A> property is `false` and the <xref:System.Nullable%601.Value%2A> property is undefined. That default value is also known as the *null* value of the nullable value type.|

Use the [default operator](../operators/default.md) to produce the default value of a type, as the following example shows:

```csharp
int a = default(int);
```

Beginning with C# 7.1, you can use the [`default` literal](../operators/default.md#default-literal) to initialize a variable with the default value of its type:

```csharp
int a = default;
```

For a value type, the implicit parameterless constructor also produces the default value of the type, as the following example shows:

```csharp-interactive
var n = new System.Numerics.Complex();
Console.WriteLine(n);  // output: (0, 0)
```

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharplang/spec/introduction.md):

- [Default values](~/_csharplang/spec/variables.md#default-values)
- [Default constructors](~/_csharplang/spec/types.md#default-constructors)

## See also

- [C# reference](../index.md)
- [C# keywords](index.md)
- [Built-in types table](built-in-types-table.md)
- [Constructors](../../programming-guide/classes-and-structs/constructors.md)
