---
description: "private keyword - C# Reference"
title: "private keyword"
ms.date: 07/20/2015
f1_keywords: 
  - "private_CSharpKeyword"
  - "private"
helpviewer_keywords: 
  - "private keyword [C#]"
ms.assetid: 654c0bb8-e6ac-4086-bf96-7474fa6aa1c8
---
# private (C# Reference)

The `private` keyword is a member access modifier.

> This page covers `private` access. The `private` keyword is also part of the [`private protected`](./private-protected.md) access modifier.

Private access is the least permissive access level. Private members are accessible only within the body of the class or the struct in which they are declared, as in this example:

```csharp
class Employee
{
    private int _i;
    double _d;   // private access by default
}
```

Nested types in the same body can also access those private members.

It is a compile-time error to reference a private member outside the class or the struct in which it is declared.

For a comparison of `private` with the other access modifiers, see [Accessibility Levels](accessibility-levels.md) and [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md).

## Example

In this example, the `Employee` class contains two private data members, `_name` and `_salary`. As private members, they cannot be accessed except by member methods. Public methods named `GetName` and `Salary` are added to allow controlled access to the private members. The `_name` member is accessed by way of a public method, and the `_salary` member is accessed by way of a public read-only property. For more information, see [Properties](../../programming-guide/classes-and-structs/properties.md).

[!code-csharp[csrefKeywordsModifiers#10](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#10)]

## C# language specification  

For more information, see [Declared accessibility](~/_csharpstandard/standard/basic-concepts.md#752-declared-accessibility) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.

## See also

- [C# Keywords](index.md)
- [Access Modifiers](access-modifiers.md)
- [Accessibility Levels](accessibility-levels.md)
- [Modifiers](index.md)
- [public](public.md)
- [protected](protected.md)
- [internal](internal.md)
