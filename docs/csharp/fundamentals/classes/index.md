---
title: Class members and instances
description: Learn how C# class members define instance state, shared static state, and behavior, and find the next steps for properties, constructors, and inheritance.
ms.date: 11/16/2026
ms.topic: concept-article
ai-usage: ai-generated
---

# Class members and instances

After the [class introduction](../types/classes.md), use this article to declare members and predict which state belongs to an object and which state belongs to its type.

A visit counter needs a count for each counter and a total across all counters:

:::code language="csharp" source="snippets/index/Program.cs" id="CounterDeclaration":::

*Members* are the declarations inside a type that describe its data, behavior, and nested types. In `VisitCounter`, the fields `count` and `total` store data. The methods `AddVisit`, `GetCount`, and `GetTotal` provide behavior. The [class reference](../../language-reference/keywords/class.md) describes the complete declaration syntax.

The `private` fields are accessible inside `VisitCounter`. Other code uses its `public` methods. [Accessibility](access-modifiers.md) controls which code can use a member, independently of whether that member belongs to an instance or the type.

## Instance state and shared state

An *instance member* belongs to an individual object. Each `VisitCounter` object has its own `count` field. A *static member* belongs to the type. The ordinary static field `total` stores one count shared by all `VisitCounter` instances. See the [`static` reference](../../language-reference/keywords/static.md) for the full rules.

Create two counters and add visits:

:::code language="csharp" source="snippets/index/Program.cs" id="IndependentInstances":::

The first call changes `first.count` but not `second.count`. Both counters contribute to `total`. Access instance methods through a reference such as `first`. Access a static method through the type name, as in `VisitCounter.GetTotal()`, even when no objects exist yet.

An instance method can use both instance and static fields. A static method has no current instance, so it needs an object reference to access instance members. In this example, `GetTotal` needs only the static field.

Assignment doesn't create a third counter:

:::code language="csharp" source="snippets/index/Program.cs" id="ReferenceAssignment":::

Both `alias` and `first` refer to the same counter. By default, ordinary classes compare references, not the contents of their fields. For data-focused classes with compiler-generated value equality and copy support, see [Records](../types/records.md).

## Static classes

A *static class* groups members that don't require an instance. You can't create an instance of a static class or derive another class from it. For example, <xref:System.Math> supplies operations through the type name:

:::code language="csharp" source="snippets/index/Program.cs" id="StaticClass":::

Declare your own static class with `static class`. It can't declare instance members or instance constructors. A non-static class such as `VisitCounter` can combine instance members with static members. For initialization rules and specialized static storage, see [Static classes and static class members](../../programming-guide/classes-and-structs/static-classes-and-static-class-members.md).

## Nested types

A *nested type* is a type declared inside another type. Nesting places the type's name within its containing type and lets you restrict access to that name. For example, `Notebook` uses a private helper type:

:::code language="csharp" source="snippets/index/Program.cs" id="NestedType":::

Creating a `Notebook` doesn't automatically create an `Entry`. The field initializer `new Entry()` creates that separate object. An `Entry` also doesn't automatically hold a reference to a `Notebook` instance. Pass an object reference explicitly if the nested type needs one.

Here, only code inside `Notebook` can name `Entry`. For the complete access rules, see [Nested types](../../programming-guide/classes-and-structs/nested-types.md).

## Continue with other members

Use the following articles for the next part of your class:

- [Fields and constants](fields-constants.md) explains stored state, default values, `readonly`, and compile-time constants.
- [Properties](../../programming-guide/classes-and-structs/properties.md) explains members that expose values through accessors.
- [Methods](../../programming-guide/classes-and-structs/methods.md) explains parameters, return values, and calls.
- [Constructors](../../programming-guide/classes-and-structs/constructors.md) explains how an object starts with its initial state.
- [Object and collection initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) explains how callers supply initial member values.
- [Inheritance](../object-oriented/inheritance.md) explains base and derived classes and inherited members.

Classes can also declare [events](../../programming-guide/events/index.md), [indexers](../../programming-guide/indexers/index.md), [operators](../../language-reference/operators/operator-overloading.md), and [finalizers](../../programming-guide/classes-and-structs/finalizers.md). Follow those articles when you need those members rather than add them to every class.
