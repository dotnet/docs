---
description: "Use the `interface` keyword to define contracts that any implementing type must support. Interfaces provide the means to create common behavior among a set of unrelated types."
title: "interface keyword"
ms.date: 07/26/2024
f1_keywords:
  - "interface_CSharpKeyword"
helpviewer_keywords:
  - "interface keyword [C#]"
---
# :::no-loc text="interface"::: (C# Reference)

An interface defines a contract. Any [`class`](class.md), [`record`](../builtin-types/record.md) or [`struct`](../builtin-types/struct.md) that implements that contract must provide an implementation of the members defined in the interface. An interface may define a default implementation for members. It may also define [`static`](static.md) members in order to provide a single implementation for common functionality. Beginning with C# 11, an interface may define `static abstract` or `static virtual` members to declare that an implementing type must provide the declared members. Typically, `static virtual` methods declare that an implementation must define a set of [overloaded operators](../operators/operator-overloading.md).

In the following example, class `ImplementationClass` must implement a method named `SampleMethod` that has no parameters and returns `void`.

For more information and examples, see [Interfaces](../../fundamentals/types/interfaces.md).

A top-level interface, one declared in a namespace but not nested inside another type, can be declared `public` or `internal`. The default is `internal`. Nested interface declarations, those declared inside another type, can be declared using any access modifier.

Interface members without an implementation can't include an access modifier. Members with a default implementation can include any access modifier.

## Example interface

[!code-csharp[csrefKeywordsTypes#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#14)]

An interface can be a member of a namespace or a class. An interface declaration can contain declarations (signatures without any implementation) of the following members:

- [Methods](../../programming-guide/classes-and-structs/methods.md)
- [Properties](../../programming-guide/classes-and-structs/using-properties.md)
- [Indexers](../../programming-guide/indexers/using-indexers.md)
- [Events](event.md)

## Default interface members

These preceding member declarations typically don't contain a body. An interface member may declare a body. Member bodies in an interface are the *default implementation*. Members with bodies permit the interface to provide a "default" implementation for classes and structs that don't provide an overriding implementation.

> [!IMPORTANT]
> Adding default interfaces members forces any `ref struct` that implements the interface to add an explicit declaration of that member.

An interface may include:

- [Constants](const.md)
- [Operators](../operators/operator-overloading.md)
- [Static constructor](../../programming-guide/classes-and-structs/constructors.md#static-constructors).
- [Nested types](../../programming-guide/classes-and-structs/nested-types.md)
- [Static fields, methods, properties, indexers, and events](static.md)
- [Member declarations using the explicit interface implementation syntax](~/_csharplang/proposals/csharp-8.0/default-interface-methods.md#explicit-implementation-in-interfaces).
- Explicit access modifiers (the default access is [`public`](access-modifiers.md)).

## Static abstract and virtual members

Beginning with C# 11, an interface may declare `static abstract` and `static virtual` members for all member types except fields. Interfaces can declare that implementing types must define operators or other static members. This feature enables generic algorithms to specify number-like behavior. You can see examples in the numeric types in the .NET runtime, such as <xref:System.Numerics.INumber%601?displayProperty=nameWithType>. These interfaces define common mathematical operators that are implemented by many numeric types. The compiler must resolve calls to `static virtual` and `static abstract` methods at compile time. The `static virtual` and `static abstract` methods declared in interfaces don't have a runtime dispatch mechanism analogous to `virtual` or `abstract` methods declared in classes. Instead, the compiler uses type information available at compile time. Therefore, `static virtual` methods are almost exclusively declared in [generic interfaces](../../programming-guide/generics/generic-interfaces.md). Furthermore, most interfaces that declare `static virtual` or `static abstract` methods declare that one of the type parameters must [implement the declared interface](../../programming-guide/generics/constraints-on-type-parameters.md#type-arguments-implement-declared-interface). For example, the `INumber<T>` interface declares that `T` must implement `INumber<T>`. The compiler uses the type argument to resolve calls to the methods and operators declared in the interface declaration. For example, the `int` type implements `INumber<int>`. When the type parameter `T` denotes the type argument `int`, the `static` members declared on `int` are invoked. Alternatively, when `double` is the type argument, the `static` members declared on the `double` type are invoked.

> [!IMPORTANT]
> Method dispatch for `static abstract` and `static virtual` methods declared in interfaces is resolved using the compile time type of an expression. If the runtime type of an expression is derived from a different compile time type, the static methods on the base (compile time) type will be called.

You can try this feature by working with the tutorial on [static abstract members in interfaces](../../whats-new/tutorials/static-virtual-interface-members.md).

## Interface inheritance

Interfaces may not contain instance state. While static fields are now permitted, instance fields aren't permitted in interfaces. [Instance auto-properties](../../programming-guide/classes-and-structs/auto-implemented-properties.md) aren't supported in interfaces, as they would implicitly declare a hidden field. This rule has a subtle effect on property declarations. In an interface declaration, the following code doesn't declare an automatically implemented property as it does in a `class` or `struct`. Instead, it declares a property that doesn't have a default implementation but must be implemented in any type that implements the interface:

```csharp
public interface INamed
{
  public string Name {get; set;}
}
```

An interface can inherit from one or more base interfaces. When an interface inherits from another interface, a type implementing the derived interface must implement all the members in the base interfaces as well as those declared in the derived interface, as shown in the following code:

:::code language="csharp" source="./snippets/DefineTypes.cs" id="SnippetDerivedInterfaces":::

When an interface [overrides a method](override.md) implemented in a base interface, it must use the [explicit interface implementation](../../programming-guide/interfaces/explicit-interface-implementation.md) syntax.

When a base type list contains a base class and interfaces, the base class must come first in the list.

A class that implements an interface can explicitly implement members of that interface. An explicitly implemented member can't be accessed through a class instance, but only through an instance of the interface. In addition, default interface members can only be accessed through an instance of the interface.

For more information about explicit interface implementation, see [Explicit Interface Implementation](../../programming-guide/interfaces/explicit-interface-implementation.md).

## Example interface implementation

The following example demonstrates interface implementation. In this example, the interface contains the property declaration and the class contains the implementation. Any instance of a class that implements `IPoint` has integer properties `x` and `y`.

:::code language="csharp" source="./snippets/DefineTypes.cs" id="Snippet15":::

## C# language specification

For more information, see the [Interfaces](~/_csharpstandard/standard/interfaces.md) section of the [C# language specification](~/_csharpstandard/standard/README.md), the feature specification for [C# 8 - Default interface members](~/_csharplang/proposals/csharp-8.0/default-interface-methods.md), and the feature spec for [C# 11 - static abstract members in interfaces](~/_csharplang/proposals/csharp-11.0/static-abstracts-in-interfaces.md).

## See also

- [C# Keywords](index.md)
- [Reference Types](reference-types.md)
- [Interfaces](../../fundamentals/types/interfaces.md)
- [Using Properties](../../programming-guide/classes-and-structs/using-properties.md)
- [Using Indexers](../../programming-guide/indexers/using-indexers.md)
