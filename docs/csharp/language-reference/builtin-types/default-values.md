---
title: "Default values of built-in types"
description: "Learn the default values of C# types such as bool, char, int, float, double, and more."
ms.date: 11/22/2024
helpviewer_keywords: 
  - "default [C#]"
  - "parameterless constructor [C#]"
---
# Default values of C# types (C# reference)

The following table shows the default values of C# types:

|Type|Default value|
|---------|------------------|
|Any [reference type](../keywords/reference-types.md)|`null`|
|Any [built-in integral numeric type](integral-numeric-types.md)|0 (zero)|
|Any [built-in floating-point numeric type](floating-point-numeric-types.md)|0 (zero)|
|[bool](bool.md)|`false`|
|[char](char.md)|`'\0'` (U+0000)|
|[enum](enum.md)|The value produced by the expression `(E)0`, where `E` is the enum identifier.|
|[struct](struct.md)|The value produced by setting all value-type fields to their default values and all reference-type fields to `null`.|
|Any [nullable value type](nullable-value-types.md)|An instance for which the <xref:System.Nullable%601.HasValue%2A> property is `false` and the <xref:System.Nullable%601.Value%2A> property is undefined. That default value is also known as the *null* value of a nullable value type.|

## Default value expressions

Use the [`default` operator](../operators/default.md#default-operator) to produce the default value of a type, as the following example shows:

```csharp
int a = default(int);
```

You can use the [`default` literal](../operators/default.md#default-literal) to initialize a variable with the default value of its type:

```csharp
int a = default;
```

## Parameterless constructor of a value type

For a value type, the *implicit* parameterless constructor also produces the default value of the type, as the following example shows:

```csharp-interactive
var n = new System.Numerics.Complex();
Console.WriteLine(n);  // output: (0, 0)
```

At run time, if the <xref:System.Type?displayProperty=nameWithType> instance represents a value type, you can use the <xref:System.Activator.CreateInstance(System.Type)?displayProperty=nameWithType> method to invoke the parameterless constructor to obtain the default value of the type.

> [!NOTE]
> A [structure type](struct.md) (which is a value type) may have an [explicit parameterless constructor](struct.md#struct-initialization-and-default-values) that may produce a non-default value of the type. Thus, we recommend using the `default` operator or the `default` literal to produce the default value of a type.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [Default values](~/_csharpstandard/standard/variables.md#93-default-values)
- [Default constructors](~/_csharpstandard/standard/types.md#833-default-constructors)
- [Parameterless struct constructors](~/_csharplang/proposals/csharp-10.0/parameterless-struct-constructors.md)
- [C# 11 - Auto default structs](~/_csharplang/proposals/csharp-11.0/auto-default-structs.md)

## See also

- [Constructors](../../programming-guide/classes-and-structs/constructors.md)
