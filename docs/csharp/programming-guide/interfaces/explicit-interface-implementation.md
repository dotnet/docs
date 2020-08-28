---
title: "Explicit Interface Implementation - C# Programming Guide"
description: A class can implement interfaces that contain a member with the same signature in C#. Explicit implementation creates a class member specific to one interface.
ms.date: 01/24/2020
helpviewer_keywords: 
  - "explicit interfaces [C#]"
  - "interfaces [C#], explicit"
ms.assetid: 181c901f-0d4c-4f29-97fc-895079617bf2
---
# Explicit Interface Implementation (C# Programming Guide)

If a [class](../../language-reference/keywords/class.md) implements two interfaces that contain a member with the same signature, then implementing that member on the class will cause both interfaces to use that member as their implementation. In the following example, all the calls to `Paint` invoke the same method. This first sample defines the types:

[!code-csharp[DefineSimpleTypes](~/samples/snippets/csharp/interfaces/ExplicitImplementation.cs#DefineTypes)]

The following sample calls the methods:

[!code-csharp[DefineSimpleTypes](~/samples/snippets/csharp/interfaces/ExplicitImplementation.cs#CallMethods)]

When two interface members don't perform the same function, it leads to an incorrect implementation of one or both of the interfaces. It's possible to implement an interface member explicitly—creating a class member that is only called through the interface, and is specific to that interface. Name the class member with the name of the interface and a period. For example:

[!code-csharp[DefineExplicitImplementation](~/samples/snippets/csharp/interfaces/ExplicitImplementation.cs#ExplicitImplementation)]

The class member `IControl.Paint` is only available through the `IControl` interface, and `ISurface.Paint` is only available through `ISurface`. Both method implementations are separate, and neither are available directly on the class. For example:

[!code-csharp[CallExplicitImplementation](~/samples/snippets/csharp/interfaces/ExplicitImplementation.cs#CallExplicitImplementation)]

Explicit implementation is also used to resolve cases where two interfaces each declare different members of the same name such as a property and a method. To implement both interfaces, a class has to use explicit implementation either for the property `P`, or the method `P`, or both, to avoid a compiler error. For example:

[!code-csharp[NameCollisions](~/samples/snippets/csharp/interfaces/ExplicitImplementation.cs#NameCollision)]

Beginning with [C# 8.0](../../whats-new/csharp-8.md#default-interface-methods), you can define an implementation for members declared in an interface. If a class inherits a method implementation from an interface, that method is only accessible through a reference of the interface type. The inherited member doesn't appear as part of the public interface. The following sample defines a default implementation for an interface method:

[!code-csharp[NameCollisions](~/samples/snippets/csharp/interfaces/ExplicitImplementation.cs#DefaultImplementation)]

The following sample invokes the default implementation:

[!code-csharp[NameCollisions](~/samples/snippets/csharp/interfaces/ExplicitImplementation.cs#CallDefaultImplementation)]

Any class that implements the `IControl` interface can override the default `Paint` method, either as a public method, or as an explicit interface implementation.

## See also

- [C# Programming Guide](../index.md)
- [Classes and Structs](../classes-and-structs/index.md)
- [Interfaces](./index.md)
- [Inheritance](../classes-and-structs/inheritance.md)
