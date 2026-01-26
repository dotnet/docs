---
description: "sealed modifier - C# Reference"
title: "sealed modifier"
ms.date: 01/22/2026
f1_keywords: 
  - "sealed"
  - "sealed_CSharpKeyword"
helpviewer_keywords: 
  - "sealed keyword [C#]"
---
# sealed (C# Reference)

When you apply the `sealed` modifier to a class, it prevents other classes from inheriting from that class. In the following example, class `B` inherits from class `A`, but no class can inherit from class `B`.

```csharp
class A {}
sealed class B : A {}
```

You can also use the `sealed` modifier on a method or property that overrides a virtual method or property in a base class. By using this approach, you enable developers to derive classes from your class while preventing them from overriding specific virtual methods or properties.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

In the following example, `Z` inherits from `Y` but `Z` can't override the virtual function `F` that is declared in `X` and sealed in `Y`.

:::code language="csharp" source="./snippets/csrefKeywordsModifiers.cs" id="16":::

When you define new methods or properties in a class, you can prevent deriving classes from overriding them by not declaring them as [virtual](virtual.md).
When you override a `virtual` member declared in a base type, you can prevent deriving types from overriding it by using the `sealed` keyword as shown in the following example:

```
public sealed override string ToString() => Value;
```

It's an error to use the [abstract](abstract.md) modifier with a sealed class, because an abstract class must be inherited by a class that provides an implementation of the abstract methods or properties.

When you apply the `sealed` modifier to a method or property, always use it with [override](override.md).

Because structs are implicitly sealed, you can't inherit from them.

For more information, see [Inheritance](../../fundamentals/object-oriented/inheritance.md).

For more examples, see [Abstract and Sealed Classes and Class Members](../../programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md).

:::code language="csharp" source="./snippets/csrefKeywordsModifiers.cs" id="17":::

In the previous example, you might try to inherit from the sealed class by using the following statement:

`class MyDerivedC: SealedClass {}   // Error`

The result is an error message:

`'MyDerivedC': cannot derive from sealed type 'SealedClass'`

To determine whether to seal a class, method, or property, generally consider the following two points:

- The potential benefits that deriving classes might gain through the ability to customize your class.
- The potential that deriving classes could modify your classes in such a way that they no longer work correctly or as expected.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Keywords](index.md)
- [Static Classes and Static Class Members](../../programming-guide/classes-and-structs/static-classes-and-static-class-members.md)
- [Abstract and Sealed Classes and Class Members](../../programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md)
- [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md)
- [Modifiers](index.md)
- [override](override.md)
- [virtual](virtual.md)
