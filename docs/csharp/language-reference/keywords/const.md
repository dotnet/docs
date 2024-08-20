---
description: "const keyword - C# Reference"
title: "const keyword"
ms.date: 06/20/2021
f1_keywords: 
  - "const_CSharpKeyword"
  - "const"
helpviewer_keywords: 
  - "const keyword [C#]"
ms.assetid: 79eb447c-117b-4418-933f-97c50aa472db
---
# const (C# Reference)

You use the `const` keyword to declare a constant field or a local constant. Constant fields and locals aren't variables and may not be modified. Constants can be numbers, Boolean values, strings, or a null reference. Don’t create a constant to represent information that you expect to change at any time. For example, don’t use a constant field to store the price of a service, a product version number, or the brand name of a company. These values can change over time, and because compilers propagate constants, other code compiled with your libraries will have to be recompiled to see the changes. See also the [readonly](readonly.md) keyword. For example:

```csharp
const int X = 0;
public const double GravitationalConstant = 6.673e-11;
private const string ProductName = "Visual C#";
```

Beginning with C# 10, [interpolated strings](../tokens/interpolated.md) may be constants, if all expressions used are also constant strings. This feature can improve the code that builds constant strings:

```csharp
const string Language = "C#";
const string Platform = ".NET";
const string FullProductName = $"{Platform} - Language: {Language}";
```

## Remarks

The type of a constant declaration specifies the type of the members that the declaration introduces. The initializer of a local constant or a constant field must be a constant expression that can be implicitly converted to the target type.

A constant expression is an expression that can be fully evaluated at compile time. Therefore, the only possible values for constants of reference types are strings and a null reference.

The constant declaration can declare multiple constants, such as:

```csharp
public const double X = 1.0, Y = 2.0, Z = 3.0;
```

The `static` modifier is not allowed in a constant declaration.

A constant can participate in a constant expression, as follows:

```csharp
public const int C1 = 5;
public const int C2 = C1 + 100;
```

> [!NOTE]
> The [readonly](readonly.md) keyword differs from the `const` keyword. A `const` field can only be initialized at the declaration of the field. A `readonly` field can be initialized either at the declaration or in a constructor. Therefore, `readonly` fields can have different values depending on the constructor used. Also, although a `const` field is a compile-time constant, the `readonly` field can be used for run-time constants, as in this line: `public static readonly uint l1 = (uint)DateTime.Now.Ticks;`

## Examples

[!code-csharp[csrefKeywordsModifiers#5](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#5)]

The following example demonstrates how to declare a local constant:

[!code-csharp[csrefKeywordsModifiers#6](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#6)]

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [Constants](~/_csharpstandard/standard/classes.md#154-constants)
- [Constant expressions](~/_csharpstandard/standard/expressions.md#1223-constant-expressions)

## See also

- [C# keywords](index.md)
- [readonly](readonly.md)
