---
description: ":::no-loc text=interface::: (C# Reference)"
title: "interface - C# Reference"
ms.date: 01/17/2020
f1_keywords: 
  - "interface_CSharpKeyword"
helpviewer_keywords: 
  - "interface keyword [C#]"
ms.assetid: 7da38e81-4f99-4bc5-b07d-c986b687eeba
---
# :::no-loc text="interface"::: (C# Reference)

An interface defines a contract. Any [`class`](class.md) or [`struct`](../builtin-types/struct.md) that implements that contract must provide an implementation of the members defined in the interface. Beginning with C# 8.0, an interface may define a default implementation for members. It may also define [`static`](static.md) members in order to provide a single implementation for common functionality.

In the following example, class `ImplementationClass` must implement a method named `SampleMethod` that has no parameters and returns `void`.

For more information and examples, see [Interfaces](../../fundamentals/types/interfaces.md).

## Example interface

[!code-csharp[csrefKeywordsTypes#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#14)]

An interface can be a member of a namespace or a class. An interface declaration can contain declarations (signatures without any implementation) of the following members:

- [Methods](../../programming-guide/classes-and-structs/methods.md)
- [Properties](../../programming-guide/classes-and-structs/using-properties.md)
- [Indexers](../../programming-guide/indexers/using-indexers.md)
- [Events](event.md)

These preceding member declarations typically do not contain a body. Beginning with C# 8.0, an interface member may declare a body. This is called a *default implementation*. Members with bodies permit the interface to provide a "default" implementation for classes and structs that don't provide an overriding implementation. In addition, beginning with C# 8.0, an interface may include:

- [Constants](const.md)
- [Operators](../operators/operator-overloading.md)
- [Static constructor](../../programming-guide/classes-and-structs/constructors.md#static-constructors).
- [Nested types](../../programming-guide/classes-and-structs/nested-types.md)
- [Static fields, methods, properties, indexers, and events](static.md)
- Member declarations using the explicit interface implementation syntax.
- Explicit access modifiers (the default access is [`public`](access-modifiers.md)).

Interfaces may not contain instance state. While static fields are now permitted, instance fields are not permitted in interfaces. [Instance auto-properties](../../programming-guide/classes-and-structs/auto-implemented-properties.md) are not supported in interfaces, as they would implicitly declare a hidden field. This rule has a subtle effect on property declarations. In an interface declaration, the following code does not declare an auto-implemented property as it does in a `class` or `struct`. Instead, it declares a property that doesn't have a default implementation but must be implemented in any type that implements the interface:

```csharp
public interface INamed
{
  public string Name {get; set;}
}
```

An interface can inherit from one or more base interfaces. When an interface [overrides a method](override.md) implemented in a base interface, it must use the [explicit interface implementation](../../programming-guide/interfaces/explicit-interface-implementation.md) syntax.

When a base type list contains a base class and interfaces, the base class must come first in the list.

A class that implements an interface can explicitly implement members of that interface. An explicitly implemented member cannot be accessed through a class instance, but only through an instance of the interface. In addition, default interface members can only be accessed through an instance of the interface.

For more information about explicit interface implementation, see [Explicit Interface Implementation](../../programming-guide/interfaces/explicit-interface-implementation.md).

## Example interface implementation

The following example demonstrates interface implementation. In this example, the interface contains the property declaration and the class contains the implementation. Any instance of a class that implements `IPoint` has integer properties `x` and `y`.

[!code-csharp[csrefKeywordsTypes#15](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#15)]

## C# language specification

For more information, see the [Interfaces](~/_csharplang/spec/interfaces.md) section of the [C# language specification](~/_csharplang/spec/introduction.md) and the feature specification for [Default interface members - C# 8.0](~/_csharplang/proposals/csharp-8.0/default-interface-methods.md)

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Reference Types](reference-types.md)
- [Interfaces](../../fundamentals/types/interfaces.md)
- [Using Properties](../../programming-guide/classes-and-structs/using-properties.md)
- [Using Indexers](../../programming-guide/indexers/using-indexers.md)
