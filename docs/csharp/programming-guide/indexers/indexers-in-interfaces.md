---
title: "Indexers in Interfaces - C# Programming Guide"
description: Indexers can be declared on an interface in C#. Learn how accessors of interface indexers differ from the accessors of class indexers.
ms.date: 02/08/2020
helpviewer_keywords: 
  - "indexers [C#], in interfaces"
  - "accessors [C#], indexers"
ms.assetid: e16b54bd-4a83-4f52-bd75-65819fca79e8
---
# Indexers in Interfaces (C# Programming Guide)

Indexers can be declared on an [interface](../../language-reference/keywords/interface.md). Accessors of interface indexers differ from the accessors of [class](../../language-reference/keywords/class.md) indexers in the following ways:

- Interface accessors do not use modifiers.
- An interface accessor typically does not have a body.

The purpose of the accessor is to indicate whether the indexer is read-write, read-only, or write-only. You may provide an implementation for an indexer defined in an interface, but this is rare. Indexers typically define an API to access data fields, and data fields cannot be defined in an interface.

The following is an example of an interface indexer accessor:

[!code-csharp[DefineInterface](~/samples/snippets/csharp/interfaces/indexers.cs#DefineIndexer)]

The signature of an indexer must differ from the signatures of all other indexers declared in the same interface.

## Example

The following example shows how to implement interface indexers.

[!code-csharp[Implement](~/samples/snippets/csharp/interfaces/indexers.cs#ImplementInterface)]

[!code-csharp[DefineInterface](~/samples/snippets/csharp/interfaces/indexers.cs#ExampleCode)]

In the preceding example, you could use the explicit interface member implementation by using the fully qualified name of the interface member. For example

```csharp
string IIndexInterface.this[int index]
{
}
```

However, the fully qualified name is only needed to avoid ambiguity when the class is implementing more than one interface with the same indexer signature. For example, if an `Employee` class is implementing two interfaces, `ICitizen` and `IEmployee`, and both interfaces have the same indexer signature, the explicit interface member implementation is necessary. That is, the following indexer declaration:

```csharp
string IEmployee.this[int index]
{
}
```

implements the indexer on the `IEmployee` interface, while the following declaration:

```csharp
string ICitizen.this[int index]
{
}
```

implements the indexer on the `ICitizen` interface.

## See also

- [C# Programming Guide](../index.md)
- [Indexers](./index.md)
- [Properties](../classes-and-structs/properties.md)
- [Interfaces](../../fundamentals/types/interfaces.md)
