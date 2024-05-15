---
title: "Generic Interfaces"
description: Learn about using generic interfaces in C#. See code examples and view other available resources.
ms.date: 07/08/2022
helpviewer_keywords: 
  - "C# language, generic interfaces"
  - "generics [C#], interfaces"
---
# Generic Interfaces (C# Programming Guide)

It's often useful to define interfaces either for generic collection classes, or for the generic classes that represent items in the collection. To avoid boxing and unboxing operations on value types, it's better to use [generic interfaces](../../../standard/generics/interfaces.md), such as <xref:System.IComparable%601>, on generic classes. The .NET class library defines several generic interfaces for use with the collection classes in the <xref:System.Collections.Generic> namespace. For more information about these interfaces, see [Generic interfaces](../../../standard/generics/interfaces.md).

When an interface is specified as a constraint on a type parameter, only types that implement the interface can be used. The following code example shows a `SortedList<T>` class that derives from the `GenericList<T>` class. For more information, see [Introduction to Generics](../../fundamentals/types/generics.md). `SortedList<T>` adds the constraint `where T : IComparable<T>`. This constraint enables the `BubbleSort` method in `SortedList<T>` to use the generic <xref:System.IComparable%601.CompareTo%2A> method on list elements. In this example, list elements are a simple class, `Person` that implements `IComparable<Person>`.

:::code language="csharp" source="./snippets/GenericInterfaces.cs" id="GenericLists":::

Multiple interfaces can be specified as constraints on a single type, as follows:

:::code language="csharp" source="./snippets/GenericInterfaces.cs" id="GenericStack":::

An interface can define more than one type parameter, as follows:

:::code language="csharp" source="./snippets/GenericInterfaces.cs" id="GenericDictionary":::

The rules of inheritance that apply to classes also apply to interfaces:

:::code language="csharp" source="./snippets/GenericInterfaces.cs" id="Months":::

Generic interfaces can inherit from non-generic interfaces if the generic interface is covariant, which means it only uses its type parameter as a return value. In the .NET class library, <xref:System.Collections.Generic.IEnumerable%601> inherits from <xref:System.Collections.IEnumerable> because <xref:System.Collections.Generic.IEnumerable%601> only uses `T` in the return value of <xref:System.Collections.Generic.IEnumerable%601.GetEnumerator%2A> and in the <xref:System.Collections.Generic.IEnumerator%601.Current%2A> property getter.

Concrete classes can implement closed constructed interfaces, as follows:

:::code language="csharp" source="./snippets/GenericInterfaces.cs" id="BaseInterfaces":::

Generic classes can implement generic interfaces or closed constructed interfaces as long as the class parameter list supplies all arguments required by the interface, as follows:

:::code language="csharp" source="./snippets/GenericInterfaces.cs" id="InterfaceInheritance":::

The rules that control method overloading are the same for methods within generic classes, generic structs, or generic interfaces. For more information, see [Generic Methods](./generic-methods.md).

Beginning with C# 11, interfaces may declare `static abstract` or `static virtual` members. Interfaces that declare either `static abstract` or `static virtual` members are almost always generic interfaces. The compiler must resolve calls to `static virtual` and `static abstract` methods at compile time. `static virtual` and `static abstract` methods declared in interfaces don't have a runtime dispatch mechanism analogous to `virtual` or `abstract` methods declared in classes. Instead, the compiler uses type information available at compile time. These members are typically declared in generic interfaces. Furthermore, most interfaces that declare `static virtual` or `static abstract` methods declare that one of the type parameters must [implement the declared interface](../../programming-guide/generics/constraints-on-type-parameters.md#type-arguments-implement-declared-interface). The compiler then uses the supplied type arguments to resolve the type of the declared member.

## See also

- [Introduction to Generics](../../fundamentals/types/generics.md)
- [interface](../../language-reference/keywords/interface.md)
- [Generics](../../../standard/generics/index.md)
