---
title: "Using Properties"
description: These examples illustrate using properties in C#. See how the get and set accessors implement read and write access and find out about uses for properties.
ms.date: 10/31/2024
helpviewer_keywords: 
  - "set accessor [C#]"
  - "get accessor [C#]"
  - "properties [C#], about properties"
ms.topic: concept-article
---
# Using Properties (C# Programming Guide)

Properties combine aspects of both fields and methods. To the user of an object, a property appears to be a field; accessing the property requires the same syntax. To the implementer of a class, a property is one or two code blocks, representing a [`get`](../../language-reference/keywords/get.md) accessor and/or a [`set`](../../language-reference/keywords/set.md) or [`init`](../../language-reference/keywords/init.md) accessor. The code block for the `get` accessor is executed when the property is read; the code block for the `set` or `init` accessor is executed when the property is assigned a value. A property without a `set` accessor is considered read-only. A property without a `get` accessor is considered write-only. A property that has both accessors is read-write. You can use an `init` accessor instead of a `set` accessor to enable the property to be set as part of object initialization but otherwise make it read-only.

Unlike fields, properties aren't classified as variables. Therefore, you can't pass a property as a [`ref`](../../language-reference/keywords/ref.md) or [`out`](../../language-reference/keywords/method-parameters.md#out-parameter-modifier) parameter.

Properties have many uses:

- They can validate data before allowing a change.
- They can transparently expose data on a class where that data is retrieved from some other source, such as a database.
- They can take an action when data is changed, such as raising an event, or changing the value of other fields.

Properties are declared in the class block by specifying the access level of the field, followed by the type of the property, followed by the name of the property, and followed by a code block that declares a `get`-accessor and/or a `set` accessor. For example:

:::code language="csharp" source="./snippets/properties/TimePeriod.cs" id="UsingExample":::

In this example, `Month` is declared as a property so that the `set` accessor can make sure that the `Month` value is set between 1 and 12. The `Month` property uses a private field to track the actual value. The real location of a property's data is often referred to as the property's "backing store." It's common for properties to use private fields as a backing store. The field is marked private in order to make sure that it can only be changed by calling the property. For more information about public and private access restrictions, see [Access Modifiers](./access-modifiers.md). Automatically implemented properties provide simplified syntax for simple property declarations. For more information, see [Automatically implemented properties](auto-implemented-properties.md).

Beginning with C# 13, you can use [field backed properties](../../language-reference/keywords/field.md) to add validation to the `set` accessor of an automatically implemented property, as shown in the following example:

:::code language="csharp" source="./snippets/properties/TimePeriod.cs" id="FieldExample":::

[!INCLUDE[field-preview](../../includes/field-preview.md)]

## The get accessor

The body of the `get` accessor resembles that of a method. It must return a value of the property type. The C# compiler and Just-in-time (JIT) compiler detect common patterns for implementing the `get` accessor, and optimizes those patterns. For example, a `get` accessor that returns a field without performing any computation is likely optimized to a memory read of that field. Automatically implemented properties follow this pattern and benefit from these optimizations. However, a virtual `get` accessor method can't be inlined because the compiler doesn't know at compile time which method might actually be called at run time. The following example shows a `get` accessor that returns the value of a private field `_name`:

:::code language="csharp" source="./snippets/properties/Person.cs" id="UsingEmployeeExample":::

When you reference the property, except as the target of an assignment, the `get` accessor is invoked to read the value of the property. For example:

:::code language="csharp" source="./snippets/properties/Program.cs" id="GetAccessor":::

The `get` accessor must be an expression-bodied member, or end in a [return](../../language-reference/statements/jump-statements.md#the-return-statement) or [throw](../../language-reference/statements/exception-handling-statements.md#the-throw-statement) statement, and control can't flow off the accessor body.

> [!WARNING]
>
> It's generally a bad programming style to change the state of the object by using the `get` accessor. One exception to this rule is a *lazy evaluated* property, where the value of a property is computed only when it's first accessed.

The `get` accessor can be used to return the field value or to compute it and return it. For example:

:::code language="csharp" source="./snippets/properties/Person.cs" id="ManageExample":::

In the previous example, if you don't assign a value to the `Name` property, it returns the value `NA`.

## The set accessor

The `set` accessor resembles a method whose return type is [void](../../language-reference/builtin-types/void.md). It uses an implicit parameter called `value`, whose type is the type of the property. The compiler and JIT compiler also recognize common patterns for a `set` or `init` accessor. Those common patterns are optimized, directly writing the memory for the backing field. In the following example, a `set` accessor is added to the `Name` property:

:::code language="csharp" source="./snippets/properties/Person.cs" id="StudentExample":::

When you assign a value to the property, the `set` accessor is invoked by using an argument that provides the new value. For example:

:::code language="csharp" source="./snippets/properties/Program.cs" id="SetAccessor":::

It's an error to use the implicit parameter name, `value`, for a local variable declaration in a `set` accessor.

## The init accessor

The code to create an `init` accessor is the same as the code to create a `set` accessor except that you use the `init` keyword instead of `set`. The difference is that the `init` accessor can only be used in the constructor or by using an [object-initializer](object-and-collection-initializers.md).

## Remarks

Properties can be marked as `public`, `private`, `protected`, `internal`, `protected internal`, or `private protected`. These access modifiers define how users of the class can access the property. The `get` and `set` accessors for the same property can have different access modifiers. For example, the `get` might be `public` to allow read-only access from outside the type, and the `set` can be `private` or `protected`. For more information, see [Access Modifiers](./access-modifiers.md).

A property can be declared as a static property by using the `static` keyword. Static properties are available to callers at any time, even if no instance of the class exists. For more information, see [Static Classes and Static Class Members](./static-classes-and-static-class-members.md).

A property can be marked as a virtual property by using the [virtual](../../language-reference/keywords/virtual.md) keyword. Virtual properties enable derived classes to override the property behavior by using the [override](../../language-reference/keywords/override.md) keyword. For more information about these options, see [Inheritance](../../fundamentals/object-oriented/inheritance.md).

A property overriding a virtual property can also be [sealed](../../language-reference/keywords/sealed.md), specifying that for derived classes it's no longer virtual. Lastly, a property can be declared [abstract](../../language-reference/keywords/abstract.md). Abstract properties don't define an implementation in the class, and derived classes must write their own implementation. For more information about these options, see [Abstract and Sealed Classes and Class Members](abstract-and-sealed-classes-and-class-members.md).

> [!NOTE]
> It is an error to use a [virtual](../../language-reference/keywords/virtual.md), [abstract](../../language-reference/keywords/abstract.md), or [override](../../language-reference/keywords/override.md) modifier on an accessor of a [static](../../language-reference/keywords/static.md) property.

## Examples

This example demonstrates instance, static, and read-only properties. It accepts the name of the employee from the keyboard, increments `NumberOfEmployees` by 1, and displays the Employee name and number.

:::code language="csharp" source="./snippets/Properties/CompleteEmployee.cs" id="EmployeeExample":::

## Hidden property example

This example demonstrates how to access a property in a base class that is hidden by another property that has the same name in a derived class:

:::code language="csharp" source="./snippets/Properties/HidingProperty.cs" id="Hiding":::

The following are important points in the previous example:

- The property `Name` in the derived class hides the property `Name` in the base class. In such a case, the `new` modifier is used in the declaration of the property in the derived class:
     :::code language="csharp" source="./snippets/Properties/HidingProperty.cs" id="NewProperty":::
- The cast `(Employee)` is used to access the hidden property in the base class:
     :::code language="csharp" source="./snippets/Properties/HidingProperty.cs" id="CastToBase":::

For more information about hiding members, see the [new Modifier](../../language-reference/keywords/new-modifier.md).

## Override property example

In this example, two classes, `Cube` and `Square`, implement an abstract class, `Shape`, and override its abstract `Area` property. Note the use of the [override](../../language-reference/keywords/override.md) modifier on the properties. The program accepts the side as an input and calculates the areas for the square and cube. It also accepts the area as an input and calculates the corresponding side for the square and cube.

:::code language="csharp" source="~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideProperties/CS/Properties.cs" id="Snippet6":::

## See also

- [Properties](properties.md)
- [Interface properties](interface-properties.md)
- [Automatically implemented properties](auto-implemented-properties.md)
- [Partial properties](../../language-reference/keywords/partial-member.md)
