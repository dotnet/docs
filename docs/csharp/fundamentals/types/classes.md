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
> **Experienced in another language?** C# classes are similar to classes in Java or C++. Skim the [object initializers](#object-initializers) section for C#-specific patterns, and see [Records](records.md) for a data-focused alternative.

A *class* is a reference type that defines a blueprint for objects. When you create a variable of a class type, the variable holds a *reference* to an object on the managed heap. The variable doesn't hold the object data itself. Assigning a class variable to another variable copies the reference, so both variables point to the same object. Classes are the most common way to define custom types in C#. Use them when you need complex behavior, inheritance, or shared identity between references.

## When to use classes

Use a class when:

- The type has complex behavior or manages mutable state.
- You need inheritance to create a base class with derived specializations, or to create a derived type that extends an existing class.
- Instances represent a shared identity, not objects that happen to hold equal values. Two references to the same object should stay in sync.
- The type is large or long-lived and benefits from [heap allocation](../../../standard/garbage-collection/fundamentals.md#the-managed-heap) and reference semantics.

## Declare a class

Define a class with the `class` keyword followed by the type name. An optional [access modifier](../../language-reference/keywords/access-modifiers.md) controls visibility. The default is `internal`. Specify `public` to allow callers from other assemblies to use your types.

:::code language="csharp" source="snippets/classes/Program.cs" ID="ClassDeclaration":::

The class body contains fields, properties, methods, and events, collectively called *class members*. The name must be a valid C# [identifier name](../coding-style/identifier-names.md).

## Create objects

A class defines a type, but it isn't an object itself. You create an object (an *instance* of the class) with the `new` keyword:

:::code language="csharp" source="snippets/classes/Program.cs" ID="CreateObject":::

The variable `customer` holds a reference to the object, not the object itself. You can assign multiple variables to the same object. Changes through one reference are visible through the other:

:::code language="csharp" source="snippets/classes/Program.cs" ID="ReferenceSemantics":::

This reference-sharing behavior is one distinction between classes and [structs](structs.md). With structs, assignment copies the data. More importantly, classes support [inheritance](#inheritance). You can build hierarchies where derived types reuse and specialize behavior from a base class. Structs can't participate in inheritance hierarchies. For more on the distinction, see [Value types and reference types](index.md#value-types-and-reference-types).

## Constructors and initialization

When you create an instance, you want its fields and properties initialized to useful values. C# offers several approaches: field initializers, constructor parameters, primary constructors, and required properties.

**[Field initializers](../../programming-guide/classes-and-structs/instance-constructors.md)** set a default value directly on the field declaration:

:::code language="csharp" source="snippets/classes/Containers.cs" ID="ContainerFieldInitializer":::

Field initializers assign a reasonable default to a field or property. This distinguishes it from the following approaches where callers can provide the initial value.

**Constructor parameters** require callers to provide values:

:::code language="csharp" source="snippets/classes/Containers.cs" ID="ContainerConstructor":::

**[Primary constructors](../../whats-new/tutorials/primary-constructors.md)** (C# 12+) add parameters directly to the class declaration. Those parameters are available throughout the class body:

:::code language="csharp" source="snippets/classes/Containers.cs" ID="ContainerPrimaryConstructor":::

Primary constructors and field initializers can work together: the field initializer `_capacity = capacity` uses the primary-constructor parameter as its value. This pattern lets you capture constructor arguments in fields with a single, concise declaration.

**[Required properties](../../language-reference/keywords/required.md)** enforce that callers set specific properties through an object initializer:

:::code language="csharp" source="snippets/classes/Program.cs" ID="RequiredProperties":::

:::code language="csharp" source="snippets/classes/Program.cs" ID="UsingRequired":::

For a deeper look at constructor patterns, including parameter validation and constructor chaining, see [Constructors](../../programming-guide/classes-and-structs/constructors.md).

## Static classes

A `static` class can't be instantiated and contains only static members. Use static classes to organize utility methods that don't operate on instance data:

:::code language="csharp" source="snippets/classes/Program.cs" ID="StaticClass":::

:::code language="csharp" source="snippets/classes/Program.cs" ID="UsingStaticClass":::

The .NET class library includes many static classes, such as <xref:System.Math> and <xref:System.Console>. A static class is implicitly sealed. You can't derive from it or instantiate it.

## Object initializers

*[Object initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md)* let you set properties when you create an object, without writing a constructor for every combination of values:

:::code language="csharp" source="snippets/classes/Program.cs" ID="ObjectInitializer":::

:::code language="csharp" source="snippets/classes/Program.cs" ID="UsingObjectInitializer":::

Object initializers work with any accessible property that has a `set` or [`init`](../../language-reference/keywords/init.md) accessor. They combine naturally with `required` properties and with constructors that accept some parameters while letting the caller set others.

When the property is a *collection*, you can use a [Collection expressions (C# reference)](../../language-reference/operators/collection-expressions.md) to initialize that object.

## Inheritance

Classes support *inheritance*. You can define a new class that reuses, extends, or modifies the behavior of an existing class. The class you inherit from is the *base class*, and the new class is the *derived class*:

:::code language="csharp" source="snippets/classes/Program.cs" ID="Inheritance":::

A class can inherit from one base class and implement multiple interfaces. Derived classes inherit all members of the base class except constructors. For more information, see [Inheritance](../object-oriented/inheritance.md) and [Interfaces](interfaces.md).

## See also

- [Type system overview](index.md)
- [Structs](structs.md)
- [Records](records.md)
- [Interfaces](interfaces.md)
- [Inheritance](../object-oriented/inheritance.md)
