---
title: "Objects - create instances of types"
description: Follow object references in C# and distinguish object identity from value equality.
ms.date: 11/16/2026
ms.topic: concept-article
ai-usage: ai-assisted
helpviewer_keywords:
  - "objects [C#], about objects"
  - "variables [C#]"
---

# Objects - create instances of types

After [C# classes](../types/classes.md), use this article to follow object references and distinguish identity from equality. For class declarations and instance creation, start with that introduction.

## Follow references to an object

A variable of a class type refers to an object. It doesn't contain a separate copy of the object's state. Two variables can refer to the same object:

:::code language="csharp" source="../classes/snippets/index/Program.cs" id="IndependentInstances":::

`first` and `second` refer to distinct objects. Each call to `new VisitCounter()` creates another counter with its own instance fields. An assignment, by contrast, copies a reference:

:::code language="csharp" source="../classes/snippets/index/Program.cs" id="ReferenceAssignment":::

`alias` and `first` refer to one counter. Calling `AddVisit` through `alias` changes the count that `first.GetCount()` returns. See the [counter declaration](../classes/index.md) for the complete class.

For value-type assignment, see [Structs](../types/structs.md). Storage location isn't a rule for deciding how assignment behaves.

## Object identity vs. value equality

*Object identity* asks whether two references identify the same object. <xref:System.Object.ReferenceEquals*> tests identity even when a type supplies its own equality behavior.

*Value equality* asks whether objects' data compares equal according to their type's rules. An ordinary class uses reference equality by default, but a class can define different equality behavior. A [record class](../types/records.md) provides compiler-generated value equality while remaining a reference type.

Use [Equality comparisons](../expressions/equality.md) for the equality operators, collection-valued members, and guidance on custom equality.

## Object lifetime

An object can remain in use after the method that created it returns if other code still holds a reference to it. You don't explicitly destroy class instances. The garbage collector reclaims their memory when they're no longer reachable. See [Garbage collection](../../../standard/garbage-collection/index.md) for memory-management details.

## Next steps

- [Class members and instances](../classes/index.md).
- [Constructors](../../programming-guide/classes-and-structs/constructors.md).
- [C# record types](../types/records.md).
