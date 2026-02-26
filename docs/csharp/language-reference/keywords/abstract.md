---
description: "abstract - C# Reference"
title: "abstract keyword"
ms.date: 01/21/2026
f1_keywords: 
  - "abstract"
  - "abstract_CSharpKeyword"
helpviewer_keywords: 
  - "abstract keyword [C#]"
---
# abstract (C# Reference)

The `abstract` modifier indicates that its target has a missing or incomplete implementation. Use the abstract modifier with classes, methods, properties, indexers, and events. Use the `abstract` modifier in a class declaration to indicate that a class is intended only to be a base class of other classes, not instantiated on its own. Non-abstract classes that derive from the abstract class must implement members marked as abstract.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

Abstract classes can contain both abstract members (which have no implementation and must be overridden in derived classes) and fully implemented members (such as regular methods, properties, and constructors). This feature allows abstract classes to provide common functionality while still requiring derived classes to implement specific abstract members.

> [!NOTE]
> Interface members are `abstract` by default.

## Abstract class with mixed members

The following example demonstrates an abstract class that contains both implemented methods and abstract members:

:::code language="csharp" source="snippets/shared/Abstract.cs" id="snippet1":::

In this example, the `Vehicle` abstract class provides:

- **Implemented members**: `GetInfo()` method, `StartEngine()` method, and constructor - these members provide common functionality for all vehicles.
- **Abstract members**: `Move()` method and `MaxSpeed` property - these members must be implemented by each specific vehicle type.

This design allows the abstract class to provide shared functionality while ensuring that derived classes implement vehicle-specific behavior.

## Concrete class derived from an abstract class

In this example, the class `Square` must provide an implementation of `GetArea` because it derives from `Shape`:

:::code language="csharp" source="snippets/csrefKeywordsModifiers.cs" id="1":::

Abstract classes have the following features:

- You can't create an instance of an abstract class.
- An abstract class can contain abstract methods and accessors.
- An abstract class can also contain implemented methods, properties, fields, and other members that provide functionality to derived classes.
- You can't use the [`sealed`](./sealed.md) modifier on an abstract class because the two modifiers have opposite meanings. The `sealed` modifier prevents a class from being inherited and the `abstract` modifier requires a class to be inherited.
- A non-abstract class derived from an abstract class must include actual implementations of all inherited abstract methods and accessors.

Use the `abstract` modifier in a method or property declaration to indicate that the method or property doesn't contain implementation.

Abstract methods have the following features:

- An abstract method is implicitly a virtual method.
- Abstract method declarations are only permitted in abstract classes.
- Because an abstract method declaration provides no actual implementation, there's no method body. The method declaration simply ends with a semicolon. For example:

  ```csharp
  public abstract void MyMethod();
  ```

  The implementation is provided by a method [`override`](./override.md), which is a member of a non-abstract class.

- It's an error to use the [`static`](./static.md) or [`virtual`](./virtual.md) modifiers in an abstract method declaration in a `class` type. You can declare `static abstract` and `static virtual` methods in interfaces.

  Abstract properties behave like abstract methods, except for the differences in declaration and invocation syntax.

- It's an error to use the `abstract` modifier on a static property in a `class` type. You can declare `static abstract` or `static virtual` properties in interface declarations.
- An abstract inherited property can be overridden in a derived class by including a property declaration that uses the [`override`](./override.md) modifier.

For more information about abstract classes, see [Abstract and Sealed Classes and Class Members](../../programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md).

An abstract class must provide implementation for all interface members. An abstract class that implements an interface might map the interface methods onto abstract methods. For example:

:::code language="csharp" source="snippets/csrefKeywordsModifiers.cs" id="2":::

In the following example, the class `DerivedClass` derives from an abstract class `BaseClass`. The abstract class contains an abstract method, `AbstractMethod`, and two abstract properties, `X` and `Y`.

:::code language="csharp" source="snippets/csrefKeywordsModifiers.cs" id="3":::

In the preceding example, if you attempt to instantiate the abstract class by using a statement like this:

```csharp
BaseClass bc = new BaseClass();   // Error
```

You get an error saying that the compiler can't create an instance of the abstract class 'BaseClass'. Nonetheless, you can use an abstract class constructor, as shown in the following example.

:::code language="csharp" source="snippets/csrefKeywordsModifiers.cs" id="27":::

The `Shape` class is declared `abstract`, which means you can't instantiate it directly. Instead, it serves as a blueprint for other classes.

- Even though you can't create objects of an abstract class, it can still have a constructor. This constructor is typically `protected`, meaning only derived classes can access it.
  In this case, the `Shape` constructor takes a `color` parameter and initializes the `Color` property. It also prints a message to the console.
  The `public Square(string color, double side) : base(color)` part calls the base class's constructor (`Shape`) and passes the `color` argument to it.
- In the `Shape` class, the defined constructor takes a color as a parameter `protected Shape(string color)`. This means C# no longer provides a default parameterless constructor automatically. Derived classes must use the `: base(color)` expression to invoke the base constructor. Setting the default value to color `protected Shape(string color="green")` allows omitting the `: base(color)` expression in derived classes. The constructor `protected Shape(string color="green")` sets the color to green.

## C# Language Specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [virtual](./virtual.md)
- [override](./override.md)
- [C# Keywords](./index.md)
