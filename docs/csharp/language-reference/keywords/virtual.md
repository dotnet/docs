---
description: "virtual - C# Reference"
title: "virtual - C# Reference"
ms.date: 07/20/2015
f1_keywords: 
  - "virtual_CSharpKeyword"
  - "virtual"
helpviewer_keywords: 
  - "virtual keyword [C#]"
ms.assetid: 5da9abae-bc1e-434f-8bea-3601b8dcb3b2
---
# virtual (C# Reference)

The `virtual` keyword is used to modify a method, property, indexer, or event declaration and allow for it to be overridden in a derived class. For example, this method can be overridden by any class that inherits it:

```csharp
public virtual double Area()
{
    return x * y;
}
```

The implementation of a virtual member can be changed by an [overriding member](override.md) in a derived class. For more information about how to use the `virtual` keyword, see [Versioning with the Override and New Keywords](../../programming-guide/classes-and-structs/versioning-with-the-override-and-new-keywords.md) and [Knowing When to Use Override and New Keywords](../../programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords.md).

## Remarks

When a virtual method is invoked, the run-time type of the object is checked for an overriding member. The overriding member in the most derived class is called, which might be the original member, if no derived class has overridden the member.

By default, methods are non-virtual. You cannot override a non-virtual method.

You cannot use the `virtual` modifier with the `static`, `abstract`, `private`, or `override` modifiers. The following example shows a virtual property:

[!code-csharp[csrefKeywordsModifiers#26](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#26)]

Virtual properties behave like virtual methods, except for the differences in declaration and invocation syntax.

- It is an error to use the `virtual` modifier on a static property.

- A virtual inherited property can be overridden in a derived class by including a property declaration that uses the `override` modifier.

## Example

In this example, the `Shape` class contains the two coordinates `x`, `y`, and the `Area()` virtual method. Different shape classes such as `Circle`, `Cylinder`, and `Sphere` inherit the `Shape` class, and the surface area is calculated for each figure. Each derived class has its own override implementation of `Area()`.

Notice that the inherited classes `Circle`, `Sphere`, and `Cylinder` all use constructors that initialize the base class, as shown in the following declaration.

```csharp
public Cylinder(double r, double h): base(r, h) {}
```

The following program calculates and displays the appropriate area for each figure by invoking the appropriate implementation of the `Area()` method, according to the object that is associated with the method.

[!code-csharp[csrefKeywordsModifiers#23](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#23)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [Polymorphism](../../fundamentals/object-oriented/polymorphism.md)
- [abstract](abstract.md)
- [override](override.md)
- [new (modifier)](new-modifier.md)
