---
description: "virtual - C# Reference"
title: "virtual keyword"
ms.date: 01/22/2026
f1_keywords: 
  - "virtual_CSharpKeyword"
  - "virtual"
helpviewer_keywords: 
  - "virtual keyword [C#]"
---
# virtual (C# Reference)

Use the `virtual` keyword to modify a method, property, indexer, or event declaration and allow a derived class to override it.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

For example, any class that inherits this method can override it:

```csharp
public virtual double Area()
{
    return x * y;
}
```

An [overriding member](override.md) in a derived class can change the implementation of a virtual member. For more information about how to use the `virtual` keyword, see [Versioning with the Override and New Keywords](../../programming-guide/classes-and-structs/versioning-with-the-override-and-new-keywords.md) and [Knowing When to Use Override and New Keywords](../../programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords.md).

When you invoke a virtual method, the runtime checks the type of the object for an overriding member. It calls the overriding member in the most derived class. If no derived class overrides the member, the original member is called.

By default, methods are non-virtual. You can't override a non-virtual method.

The following example shows a virtual property:

:::code language="csharp" source="./snippets/csrefKeywordsModifiers.cs" id="26":::

Virtual properties behave like virtual methods, except for the differences in declaration and invocation syntax.

- A virtual inherited property can be overridden in a derived class by including a property declaration that uses the `override` modifier.

## Example

In this example, the `Shape` class contains the two coordinates `x` and `y`, and the `Area()` virtual method. Different shape classes such as `Circle`, `Cylinder`, and `Sphere` inherit the `Shape` class, and the surface area is calculated for each figure. Each derived class has its own override implementation of `Area()`.

The inherited classes `Circle`, `Cylinder`, and `Sphere` all use constructors that initialize the base class, as shown in the following declaration.

```csharp
public Cylinder(double r, double h): base(r, h) {}
```

The following program calculates and displays the appropriate area for each figure by invoking the appropriate implementation of the `Area()` method, according to the object that is associated with the method.

:::code language="csharp" source="./snippets/csrefKeywordsModifiers.cs" id="23":::

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [Polymorphism](../../fundamentals/object-oriented/polymorphism.md)
- [abstract](abstract.md)
- [override](override.md)
- [new (modifier)](new-modifier.md)
