---
description: "static modifier - C# Reference"
title: "static modifier - C# Reference"
ms.date: 09/25/2020
f1_keywords: 
  - "static"
  - "static_CSharpKeyword"
helpviewer_keywords: 
  - "static keyword [C#]"
ms.assetid: 5509e215-2183-4da3-bab4-6b7e607a4fdf
---
# static (C# Reference)

This page covers the `static` modifier keyword. The `static` keyword is also part of the [`using static`](using-directive.md) directive.

Use the `static` modifier to declare a static member, which belongs to the type itself rather than to a specific object. The `static` modifier can be used to declare `static` classes. In classes, interfaces, and structs, you may add the `static` modifier to fields, methods, properties, operators, events, and constructors. The `static` modifier can't be used with indexers or finalizers. For more information, see [Static Classes and Static Class Members](../../programming-guide/classes-and-structs/static-classes-and-static-class-members.md).

Beginning with C# 8.0, you can add the `static` modifier to a [local function](../../programming-guide/classes-and-structs/local-functions.md). A static local function can't capture local variables or instance state.

Beginning with C# 9.0, you can add the `static` modifier to a [lambda expression](../operators/lambda-expressions.md) or [anonymous method](../operators/delegate-operator.md). A static lambda or anonymous method can't capture local variables or instance state.

## Example - static class

The following class is declared as `static` and contains only `static` methods:

[!code-csharp[csrefKeywordsModifiers#18](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#18)]

A constant or type declaration is implicitly a `static` member. A `static` member can't be referenced through an instance. Instead, it's referenced through the type name. For example, consider the following class:

[!code-csharp[csrefKeywordsModifiers#19](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#19)]

To refer to the `static` member `x`, use the fully qualified name, `MyBaseC.MyStruct.x`, unless the member is accessible from the same scope:

```csharp
Console.WriteLine(MyBaseC.MyStruct.x);
```

While an instance of a class contains a separate copy of all instance fields of the class, there's only one copy of each `static` field.

It isn't possible to use [`this`](this.md) to reference `static` methods or property accessors.

If the `static` keyword is applied to a class, all the members of the class must be `static`.

Classes, interfaces, and `static` classes may have `static` constructors. A `static` constructor is called at some point between when the program starts and the class is instantiated.

> [!NOTE]
> The `static` keyword has more limited uses than in C++. To compare with the C++ keyword, see [Storage classes (C++)](/cpp/cpp/storage-classes-cpp#static).

To demonstrate `static` members, consider a class that represents a company employee. Assume that the class contains a method to count employees and a field to store the number of employees. Both the method and the field don't belong to any one employee instance. Instead, they belong to the class of employees as a whole. They should be declared as `static` members of the class.

## Example - static field and method

This example reads the name and ID of a new employee, increments the employee counter by one, and displays the information for the new employee and the new number of employees. This program reads the current number of employees from the keyboard.

[!code-csharp[csrefKeywordsModifiers#20](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#20)]  

## Example - static initialization

This example shows that you can initialize a `static` field by using another `static` field that is not yet declared. The results will be undefined until you explicitly assign a value to the `static` field.

[!code-csharp[csrefKeywordsModifiers#21](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#21)]  

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Modifiers](index.md)
- [using static directive](using-directive.md)
- [Static Classes and Static Class Members](../../programming-guide/classes-and-structs/static-classes-and-static-class-members.md)
