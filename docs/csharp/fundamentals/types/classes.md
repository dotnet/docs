---
title: "C# classes"
description: Learn how a C# class defines a reference type, how new creates an instance, and why assignment shares an object rather than copying it.
ms.date: 11/16/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# C# classes

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first.

A *class* defines a type that groups data and behavior. Use a class to represent something your program works with, such as a counter, a document, or a connection. An *object*, also called an *instance*, is a value of that type. The [class reference](../../language-reference/keywords/class.md) describes the declaration syntax.

Classes are *reference types*: a variable holds a *reference* to an object rather than the object's data. Multiple variables can refer to the same object. See [Value types and reference types](index.md#value-types-and-reference-types) for the type-system vocabulary.

For example, `VisitCounter` defines the state and operations for a counter:

:::code language="csharp" source="../classes/snippets/index/Program.cs" id="CounterDeclaration":::

`GetCount` and `GetTotal` are *expression-bodied methods*: each `=> expression;` is shorthand for `{ return expression; }`.

The declarations inside a class are its *members*. Here, fields store counts and methods provide operations. `private` limits access to the class, and `public` lets other code use a member. For the next level of detail, see [Class members and instances](../classes/index.md).

## Create objects

The class declaration defines the type; it doesn't create an object. The [`new` operator](../../language-reference/operators/new-operator.md) creates an instance:

:::code language="csharp" source="../classes/snippets/index/Program.cs" id="IndependentInstances":::

Each object has its own instance state. The `static` field `total` belongs to the type and holds state shared by both counters. Access the static method through `VisitCounter`, not through `first` or `second`.

## Assignment shares a reference

A class variable holds a reference to an object. Assignment copies that reference:

:::code language="csharp" source="../classes/snippets/index/Program.cs" id="ReferenceAssignment":::

`first` and `alias` refer to the same object. A change through either variable affects that object. `second` refers to a different object even though its count is also `2`.

For an ordinary class that doesn't customize equality, `==` compares whether the references identify the same object. <xref:System.Object.ReferenceEquals*> tests that identity explicitly. See [Equality comparisons](../expressions/equality.md) for more detail.

## Record classes

For a class whose main purpose is to store data, use a *record class* when you want the compiler to provide value equality and copy support. `record` is shorthand for `record class`. Record classes are still reference types, so assignment still copies a reference.

Continue with [C# record types](records.md) for positional declarations, generated members, and shallow `with` copies.

## Next steps

- [Class members and instances](../classes/index.md) explains instance and static members and introduces nested types.
- [Class accessibility](../classes/access-modifiers.md) explains `public`, `private`, and the default access rules.
- [Fields and constants](../classes/fields-constants.md) explains stored state and named fixed values.
- [Properties](../classes/properties.md) explains value accessors.
- [Constructors](../../programming-guide/classes-and-structs/constructors.md) explains how to initialize objects, including [primary constructors](../../whats-new/tutorials/primary-constructors.md).
- [Object and collection initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) explains caller-supplied initial values and links to collection syntax.
- [Inheritance](../object-oriented/inheritance.md) explains base and derived classes.
