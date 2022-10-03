---
title: "Auto-Implemented Properties - C# Programming Guide"
description: For an auto-implemented property in C#, the compiler creates a private, anonymous backing field accessed only through get and set accessors of the property.
ms.date: 07/29/2022
f1_keywords:
  - "propertyInitializer_CSharpKeyword"
helpviewer_keywords:
  - "auto-implemented properties [C#]"
  - "properties [C#], auto-implemented"
---
# Auto-Implemented Properties (C# Programming Guide)

Auto-implemented properties make property-declaration more concise when no additional logic is required in the property accessors. They also enable client code to create objects. When you declare a property as shown in the following example, the compiler creates a private, anonymous backing field that can only be accessed through the property's `get` and `set` accessors. In C# 9 and later, `init` accessors can also be declared as auto-implemented properties.

## Example

The following example shows a simple class that has some auto-implemented properties:

:::code language="csharp" source="./snippets/properties/AutoImplemented.cs" id="Snippet28":::

You can't declare auto-implemented properties in interfaces. Auto-implemented properties declare a private instance backing field, and interfaces may not declare instance fields. Declaring a property in an interface without defining a body declares a property with accessors that must be implemented by each type that implements that interface.

You can initialize auto-implemented properties similarly to fields:

```csharp
public string FirstName { get; set; } = "Jane";
```

The class that is shown in the previous example is mutable. Client code can change the values in objects after creation. In complex classes that contain significant behavior (methods) as well as data, it's often necessary to have public properties. However, for small classes or structs that just encapsulate a set of values (data) and have little or no behaviors, you should use one of the following options for making the objects immutable:

* Declare only a `get` accessor (immutable everywhere except the constructor).
* Declare a `get` accessor and an `init` accessor (immutable everywhere except during object construction).
* Declare the `set` accessor as [private](../../language-reference/keywords/private.md) (immutable to consumers).

For more information, see [How to implement a lightweight class with auto-implemented properties](./how-to-implement-a-lightweight-class-with-auto-implemented-properties.md).

## See also

- [Use auto-implemented properties (style rule IDE0032)](../../../fundamentals/code-analysis/style-rules/ide0032.md)
- [Properties](./properties.md)
- [Modifiers](../../language-reference/keywords/index.md)
