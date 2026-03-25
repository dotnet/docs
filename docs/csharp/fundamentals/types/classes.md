---
title: "C# classes"
description: Learn how to define and use classes in C#, including reference type semantics, constructors, static classes, object initializers, collection initializers, and inheritance basics.
ms.date: 03/25/2026
ms.topic: concept-article
ai-usage: ai-assisted
---
# C# classes

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. You'll encounter classes once you need to model objects with behavior and state.
>
> **Experienced in another language?** C# classes are similar to classes in Java or C++. Skim the [object initializers](#object-initializers) and [collection initializers](#collection-initializers) sections for C#-specific patterns, and see [Records](records.md) for a data-focused alternative.

A *class* is a reference type that defines a blueprint for objects. When you create a variable of a class type, the variable holds a *reference* to an object on the managed heap—not the object data itself. Assigning a class variable to another variable copies the reference, so both variables point to the same object. Classes are the most common way to define custom types in C#. Use them when you need complex behavior, inheritance, or shared identity between references.

## Declare a class

Define a class with the `class` keyword followed by the type name. An optional access modifier controls visibility—the default is `internal`:

:::code language="csharp" source="snippets/classes/Program.cs" ID="ClassDeclaration":::

The class body contains fields, properties, methods, and events, collectively called *class members*. The name must be a valid C# [identifier name](../coding-style/identifier-names.md).

## Create objects

A class defines a type, but it isn't an object itself. You create an object (an *instance* of the class) with the `new` keyword:

:::code language="csharp" source="snippets/classes/Program.cs" ID="CreateObject":::

The variable `customer` holds a reference to the object, not the object itself. You can assign multiple variables to the same object—changes through one reference are visible through the other:

:::code language="csharp" source="snippets/classes/Program.cs" ID="ReferenceSemantics":::

This reference-sharing behavior is what distinguishes classes from [structs](structs.md), where assignment copies the data. For more on the distinction, see [Value types and reference types](index.md#value-types-and-reference-types).

## Constructors and initialization

When you create an instance, you want its fields and properties initialized to useful values. C# offers several approaches:

**Field initializers** set a default value directly on the field declaration:

:::code language="csharp" source="snippets/classes/Containers.cs" ID="ContainerFieldInitializer":::

**Constructor parameters** require callers to provide values:

:::code language="csharp" source="snippets/classes/Containers.cs" ID="ContainerConstructor":::

**Primary constructors** (C# 12) add parameters directly to the class declaration. Those parameters are available throughout the class body:

:::code language="csharp" source="snippets/classes/Containers.cs" ID="ContainerPrimaryConstructor":::

**Required properties** enforce that callers set specific properties through an object initializer:

:::code language="csharp" source="snippets/classes/Program.cs" ID="RequiredProperties":::

:::code language="csharp" source="snippets/classes/Program.cs" ID="UsingRequired":::

For a deeper look at constructor patterns, including parameter validation and constructor chaining, see [Constructors](../object-oriented/index.md).

## Static classes

A `static` class can't be instantiated and contains only static members. Use static classes as containers for utility methods that don't operate on instance data:

:::code language="csharp" source="snippets/classes/Program.cs" ID="StaticClass":::

:::code language="csharp" source="snippets/classes/Program.cs" ID="UsingStaticClass":::

The .NET class library includes many static classes, such as <xref:System.Math> and <xref:System.Console>. A static class is sealed implicitly—you can't derive from it or instantiate it.

## Object initializers

*Object initializers* let you set properties when you create an object, without writing a constructor for every combination of values:

:::code language="csharp" source="snippets/classes/Program.cs" ID="ObjectInitializer":::

:::code language="csharp" source="snippets/classes/Program.cs" ID="UsingObjectInitializer":::

Object initializers work with any accessible settable property. They combine naturally with `required` properties and with constructors that accept some parameters while letting the caller set others.

## Collection initializers

*Collection initializers* let you populate a collection inline when you create it. You can use the traditional brace syntax or, starting with C# 12, *collection expressions* with bracket syntax:

:::code language="csharp" source="snippets/classes/Program.cs" ID="CollectionInitializers":::

Collection expressions work with arrays, `List<T>`, `Span<T>`, and any type that supports collection initialization. The spread operator (`..`) lets you compose collections from existing sequences. For more information, see [Collection expressions (C# reference)](../../language-reference/operators/collection-expressions.md).

## Inheritance

Classes support *inheritance*—you can define a new class that reuses, extends, or modifies the behavior of an existing class. The class you inherit from is the *base class*, and the new class is the *derived class*:

:::code language="csharp" source="snippets/classes/Program.cs" ID="Inheritance":::

A class can inherit from one base class and implement multiple interfaces. Derived classes inherit all members of the base class except constructors. For more information, see [Inheritance](../object-oriented/inheritance.md) and [Interfaces](interfaces.md).

## See also

- [Type system overview](index.md)
- [Structs](structs.md)
- [Records](records.md)
- [Interfaces](interfaces.md)
- [Inheritance](../object-oriented/inheritance.md)
