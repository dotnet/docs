---
description: "static modifier - C# Reference"
title: "static modifier"
ms.date: 01/22/2026
f1_keywords: 
  - "static"
  - "static_CSharpKeyword"
helpviewer_keywords: 
  - "static keyword [C#]"
---
# static (C# Reference)

This article covers the `static` modifier keyword. The `static` keyword is also part of the [`using static`](using-directive.md) directive.

Use the `static` modifier to declare a static member, which belongs to the type itself rather than to a specific object. Use the `static` modifier to declare `static` classes. In classes, interfaces, and structs, you can add the `static` modifier to fields, methods, properties, operators, events, and constructors. You can't use the `static` modifier with indexers or finalizers. For more information, see [Static Classes and Static Class Members](../../programming-guide/classes-and-structs/static-classes-and-static-class-members.md).

You can add the `static` modifier to a [local function](../../programming-guide/classes-and-structs/local-functions.md). A static local function can't capture local variables or instance state.

:::code language="csharp" source="./snippets/csrefKeywordsModifiers.cs" id="28":::

You can add the `static` modifier to a [lambda expression](../operators/lambda-expressions.md) or [anonymous method](../operators/delegate-operator.md). A static lambda or anonymous method can't capture local variables or instance state.

:::code language="csharp" source="./snippets/csrefKeywordsModifiers.cs" id="29":::

The following class is declared as `static` and contains only `static` methods:

:::code language="csharp" source="./snippets/csrefKeywordsModifiers.cs" id="18":::

A constant or type declaration is implicitly a `static` member. You can't reference a `static` member through an instance. Instead, reference it through the type name. For example, consider the following class:

:::code language="csharp" source="./snippets/csrefKeywordsModifiers.cs" id="19":::

To refer to the `static` member `x`, use the fully qualified name, `MyBaseC.MyStruct.x`, unless the member is accessible from the same scope:

```csharp
Console.WriteLine(MyBaseC.MyStruct.x);
```

While an instance of a class contains a separate copy of all instance fields of the class, there's only one copy of each `static` field. For generic types, each closed generic type has its own copy of static fields. Static fields marked with <xref:System.ThreadStaticAttribute> have one copy per thread.

You can't use [`this`](this.md) to reference `static` methods or property accessors.

If you apply the `static` keyword to a class, all the members of the class must be `static`.

Classes, interfaces, and `static` classes can have `static` constructors. A `static` constructor is called at some point between when the program starts and the class is instantiated.

> [!NOTE]
> The `static` keyword has more limited uses than in C++. To compare with the C++ keyword, see [Storage classes (C++)](/cpp/cpp/storage-classes-cpp#static).

To demonstrate `static` members, consider a class that represents a company employee. Assume that the class contains a method to count employees and a field to store the number of employees. Both the method and the field don't belong to any one employee instance. Instead, they belong to the class of employees as a whole. They should be declared as `static` members of the class.

This example reads the name and ID of a new employee, increments the employee counter by one, and displays the information for the new employee and the new number of employees. This program reads the current number of employees from the keyboard.

:::code language="csharp" source="./snippets/csrefKeywordsModifiers.cs" id="20":::

This example shows that you can initialize a `static` field by using another `static` field that isn't yet declared. The results are undefined until you explicitly assign a value to the `static` field.

:::code language="csharp" source="./snippets/csrefKeywordsModifiers.cs" id="21":::

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Keywords](index.md)
- [Modifiers](index.md)
- [using static directive](using-directive.md)
- [Static Classes and Static Class Members](../../programming-guide/classes-and-structs/static-classes-and-static-class-members.md)
