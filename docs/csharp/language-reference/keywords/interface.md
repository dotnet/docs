---
title: "interface - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "interface_CSharpKeyword"
helpviewer_keywords: 
  - "interface keyword [C#]"
ms.assetid: 7da38e81-4f99-4bc5-b07d-c986b687eeba
---
# interface (C# Reference)

An interface contains only the signatures of [methods](../../programming-guide/classes-and-structs/methods.md), [properties](../../programming-guide/classes-and-structs/properties.md), [events](../../programming-guide/events/index.md) or [indexers](../../programming-guide/indexers/index.md). A class or struct that implements the interface must implement the members of the interface that are specified in the interface definition. In the following example, class `ImplementationClass` must implement a method named `SampleMethod` that has no parameters and returns `void`.

For more information and examples, see [Interfaces](../../programming-guide/interfaces/index.md).

## Example

[!code-csharp[csrefKeywordsTypes#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#14)]

An interface can be a member of a namespace or a class and can contain signatures of the following members:

- [Methods](../../programming-guide/classes-and-structs/methods.md)

- [Properties](../../programming-guide/classes-and-structs/using-properties.md)

- [Indexers](../../programming-guide/indexers/using-indexers.md)

- [Events](event.md)

An interface can inherit from one or more base interfaces.

When a base type list contains a base class and interfaces, the base class must come first in the list.

A class that implements an interface can explicitly implement members of that interface. An explicitly implemented member cannot be accessed through a class instance, but only through an instance of the interface.

For more details and code examples on explicit interface implementation, see [Explicit Interface Implementation](../../programming-guide/interfaces/explicit-interface-implementation.md).

## Example

The following example demonstrates interface implementation. In this example, the interface contains the property declaration and the class contains the implementation. Any instance of a class that implements `IPoint` has integer properties `x` and `y`.

[!code-csharp[csrefKeywordsTypes#15](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#15)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../../../csharp/language-reference/index.md)  
- [C# Programming Guide](../../programming-guide/index.md)  
- [C# Keywords](index.md)  
- [Reference Types](reference-types.md)  
- [Interfaces](../../programming-guide/interfaces/index.md)  
- [Using Properties](../../programming-guide/classes-and-structs/using-properties.md)  
- [Using Indexers](../../programming-guide/indexers/using-indexers.md)  
- [class](class.md)  
- [struct](struct.md)  
- [Interfaces](../../programming-guide/interfaces/index.md)
