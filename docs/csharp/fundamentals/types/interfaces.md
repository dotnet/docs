---
title: "Interfaces - define behavior for multiple types"
description: Learn how to declare and implement interfaces in C#, use implicit and explicit implementation, and choose between interfaces and abstract classes.
ms.date: 04/07/2026
ms.topic: concept-article
ai-usage: ai-assisted
---
# Interfaces - define behavior for multiple types

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. You'll encounter interfaces once you need to define shared behavior across unrelated types.
>
> **Experienced in another language?** C# interfaces are similar to interfaces in Java or protocols in Swift. Skim the [explicit implementation](#explicit-implementation) section for C#-specific patterns.

An *interface* defines a contract—a group of related methods, properties, events, and indexers that a [`class`](../../language-reference/keywords/class.md) or [`struct`](../../language-reference/builtin-types/struct.md) must implement. Interfaces let you include behavior from multiple sources in a single type, which is important because C# doesn't support multiple inheritance of classes. Structs can't inherit from other structs or classes, so interfaces are the only way to add shared behavior across struct types.

The following example declares an interface and a class that implements it:

:::code language="csharp" source="./snippets/interfaces/interfaces.cs" ID="Equatable":::

:::code language="csharp" source="./snippets/interfaces/interfaces.cs" ID="ImplementEquatable":::

Any class or struct that implements <xref:System.IEquatable`1> must provide an `Equals` method matching the interface signature. You can count on any `IEquatable<T>` implementation to support equality comparison, regardless of the concrete type. That predictability is the core value of interfaces.

## Declare an interface

Define an interface with the [`interface`](../../language-reference/keywords/interface.md) keyword. By convention, interface names begin with a capital `I`:

:::code language="csharp" source="./snippets/interfaces/interfaces.cs" ID="DeclareInterface":::

Interfaces can contain methods, properties, events, and indexers. An interface can't contain instance fields, instance constructors, or finalizers. Members are `public` by default. You can specify other accessibility modifiers when needed—for example, `internal` for members that shouldn't be visible outside the assembly.

## Implement an interface

A class or struct lists the interfaces it implements after a colon in its declaration. The class must provide an implementation for every member declared in the interface:

:::code language="csharp" source="./snippets/interfaces/interfaces.cs" ID="ImplementInterface":::

A class can implement multiple interfaces, separated by commas. It must provide implementations for all members from every interface it lists.

### Explicit implementation

Sometimes you need to implement an interface member without making it part of the class's public API. *Explicit implementation* qualifies the member with the interface name. The member is only accessible through a variable of the interface type:

:::code language="csharp" source="./snippets/interfaces/interfaces.cs" ID="ExplicitImplementation":::

Explicit implementation is useful when two interfaces declare members with the same name, or when you want to keep the class's public surface clean. For more detail, see [Explicit Interface Implementation](../../programming-guide/interfaces/explicit-interface-implementation.md).

## Interface inheritance

Interfaces can inherit from one or more other interfaces. A class implementing a derived interface must implement all members from the derived interface and all of its base interfaces:

:::code language="csharp" source="./snippets/interfaces/interfaces.cs" ID="InterfaceInheritance":::

A class that implements `IShape` can be implicitly converted to `IDrawable`, because `IShape` inherits from it.

## Interfaces vs. abstract classes

Both interfaces and abstract classes define contracts that derived types must fulfill. Choose between them based on what your design requires:

- **Use an interface** when you need to define shared behavior across unrelated types, or when a type needs to implement multiple contracts. Classes and structs can implement any number of interfaces.
- **Use an abstract class** when you need to share implementation code (fields, constructors, non-public members) among related types that form an inheritance hierarchy.

A class can inherit from only one base class but can implement multiple interfaces. That distinction often makes interfaces the better choice for defining capabilities that cut across type hierarchies.

## Working with internal interfaces

An internal interface can typically be implemented with public members, as long as all types in the interface signature are publicly accessible. When an interface uses internal types in its member signatures, you must use explicit implementation because the implementing member can't be public while exposing internal types:

:::code language="csharp" source="./snippets/interfaces/interfaces.cs" ID="InternalInterfaceExample":::

In the preceding example, `IConfigurable` uses an internal type `InternalConfiguration` in its method signature. `ServiceImplementation` uses explicit implementation for that member. In contrast, `ILoggable` uses only public types (`string`) in its signature and can be implemented implicitly.

## Default interface members and static abstract members

Interfaces support two advanced features that go beyond basic contracts:

- **Default interface members** let an interface provide a method body. Implementing types inherit the default implementation and can optionally override it. For more information, see [default interface methods](../../advanced-topics/interface-implementation/default-interface-methods-versions.md).
- **Static abstract members** require implementing types to provide a static member, which is useful for defining operator contracts or factory patterns. For more information, see [static abstract members in interfaces](../../language-reference/keywords/interface.md#static-abstract-and-virtual-members).

Both features are covered in the advanced topics section. Most everyday interface usage involves the declaring and implementing patterns described earlier in this article.

## Interfaces summary

- An interface defines a contract of methods, properties, events, and indexers.
- A class or struct that implements an interface must provide implementations for all declared members (unless the interface provides a default implementation).
- An interface can't be instantiated directly.
- A class or struct can implement multiple interfaces. A class can inherit a base class and also implement one or more interfaces.
- Interface names conventionally start with `I`.
