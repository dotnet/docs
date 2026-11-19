---
title: Class members and instances
description: Learn how C# class members define instance state, shared static state, and behavior, and find the next steps for properties, constructors, and inheritance.
ms.date: 11/16/2026
ms.topic: concept-article
ai-usage: ai-generated
---

# Class members and instances

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from another language?** C# instance and static members serve similar purposes to [Java instance and class members](https://docs.oracle.com/javase/tutorial/java/javaOO/classvars.html): they let you work with individual objects or with the type as a whole.

After the [overview of class types](../types/classes.md), use this section to learn more details about classes and their members.

For example, you can give each visit counter its own count and track a total across all counters:

:::code language="csharp" source="snippets/index/Program.cs" id="CounterDeclaration":::

You define a type's behavior by declaring its *members*, the declarations inside a type that describe its data, operations, and nested types. In `VisitCounter`, the fields `count` and `total` store data. The methods `AddVisit`, `GetCount`, and `GetTotal` provide operations on that data. Classes support many other kinds of members, including properties, constructors, and events, which you'll explore as you need them. The [class reference](../../language-reference/keywords/class.md) describes the complete declaration syntax.

Use instance state and members to define the behavior of an individual object: `count`, `AddVisit`, and `GetCount` work with one counter. Use `static` state and members for behavior that belongs to the type: `total` and `GetTotal` track visits across all counters.

With `private` fields, you keep direct access to the data inside `VisitCounter`. Other code uses its `public` methods. [Accessibility](access-modifiers.md) controls which code can use a member, independently of whether that member belongs to an instance or the type.

## Instance state and shared state

An *instance member* belongs to an individual object. Use instance members when you need to store or work with each object's own state. Each `VisitCounter` object has its own `count` field. A *static member* belongs to the type. Use static members to store shared state or provide operations that don't need a particular object. The static field `total` stores one count shared by all `VisitCounter` instances. See the [`static` reference](../../language-reference/keywords/static.md) for the full rules.

Create two counters and add visits:

:::code language="csharp" source="snippets/index/Program.cs" id="IndependentInstances":::

At the end of this example, `first` has had one visit and `second` has had two visits, so their `GetCount` calls report `1` and `2`. The static member `GetTotal` reports all three visits as `3`.

Access instance members through an object reference such as `first`. Access static members through the type name, as in `VisitCounter.GetTotal()`. You can use static members even before you create any objects, as the initial call that returns `0` demonstrates.

In an instance method, you can use both instance and static members directly. A static method has no current instance, so you supply an object reference to access instance members. In this example, `GetTotal` needs only the static field.

As you learned in [Assignment shares a reference](../types/classes.md#assignment-shares-a-reference), assignment copies a reference to an existing object. If you give `first` another name, `alias`, you still have two counters, not three:

:::code language="csharp" source="snippets/index/Program.cs" id="ReferenceAssignment":::

Both `alias` and `first` refer to the same counter, so a visit through `alias` raises `first.GetCount()` to `2`. For an ordinary class that doesn't customize equality, `==` compares references, not field contents. For data-focused classes with compiler-generated value equality and copy support, see [Records](../types/records.md).

## Static classes

Sometimes you need a group of related operations without any objects to represent. For example, you use <xref:System.Math> to perform calculations without creating a `Math` object:

:::code language="csharp" source="snippets/index/Program.cs" id="StaticClass":::

For this purpose, declare a *static class*, a class whose members you use through the type rather than through instances. Use `static class` for your declaration. A static class can't declare instance members or instance constructors, and you can't create instances of it or derive another class from it. In a non-static class such as `VisitCounter`, you can combine instance members with static members. For initialization rules and specialized static storage, see [Static classes and static class members](../../programming-guide/classes-and-structs/static-classes-and-static-class-members.md).

## Nested types

A *nested type* is a type declared inside another type. Use nesting when a type is usually needed only in the context of its containing type. For example, you can declare `Entry` inside `Notebook` to keep that supporting type with the class that uses it:

:::code language="csharp" source="snippets/index/Program.cs" id="NestedType":::

When you create a `Notebook`, the field initializer `new Entry()` creates a separate `Entry` object. Nesting alone doesn't create either object or give an `Entry` a reference to a `Notebook` instance. Pass an object reference explicitly if the nested type needs one.

Nesting places the type's name within its containing type. To choose which code can use a nested type, continue with [Class accessibility](access-modifiers.md). For more declaration examples, see [Nested types](../../programming-guide/classes-and-structs/nested-types.md).

## Continue with other members

Use the following articles for the next part of your class:

- [Fields and constants](fields-constants.md) explains stored state, default values, `readonly`, and compile-time constants.
- [Properties](../../programming-guide/classes-and-structs/properties.md) explains members that expose values through accessors.
- [Methods](../../programming-guide/classes-and-structs/methods.md) explains parameters, return values, and calls.
- [Constructors](../../programming-guide/classes-and-structs/constructors.md) explains how an object starts with its initial state.
- [Object and collection initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) explains how callers supply initial member values.
- [Inheritance](../object-oriented/inheritance.md) explains base and derived classes and inherited members.

Classes can also declare [events](../../programming-guide/events/index.md), [indexers](../../programming-guide/indexers/index.md), [operators](../../language-reference/operators/operator-overloading.md), and [finalizers](../../programming-guide/classes-and-structs/finalizers.md). Follow those articles when you need those members rather than add them to every class.
