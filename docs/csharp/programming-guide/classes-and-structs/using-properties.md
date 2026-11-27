---
title: "Using properties"
description: Explore property validation, stored and computed values, implementation hiding, and inheritance examples in C#.
ms.date: 11/25/2026
ms.topic: concept-article
ai-usage: ai-assisted
helpviewer_keywords: 
  - "set accessor [C#]"
  - "get accessor [C#]"
  - "properties [C#], about properties"
---
# Using properties

For property declarations, accessor accessibility, and initialization, see [Declare and initialize properties](../../fundamentals/classes/properties.md). The examples here explore how properties control state and hide their implementation from callers.

An ordinary value-returning property isn't a variable that you can pass as a [`ref`](../../language-reference/keywords/ref.md) or [`out`](../../language-reference/keywords/method-parameters.md#out-parameter-modifier) argument. For properties that return references, see [Reference return values](../../language-reference/statements/jump-statements.md#ref-returns).

Properties have many uses:

- They can validate data before allowing a change.
- They can transparently expose data on a class where that data is retrieved from some other source, such as a database.
- They can take an action when data is changed, such as raising an event, or changing the value of other fields.

## Validate stored values

The following `Month` property stores values from 1 through 12:

:::code language="csharp" source="./snippets/properties/TimePeriod.cs" id="UsingExample":::

The `Month` setter updates its private backing field only when the supplied value falls within the accepted range. Other assignments leave the value unchanged. The private field keeps callers from bypassing the setter. For accessibility rules, see [Class accessibility](../../fundamentals/classes/access-modifiers.md).

The following field-backed version uses [`field`](../../language-reference/keywords/field.md) rather than an explicitly declared field:

:::code language="csharp" source="./snippets/properties/TimePeriod.cs" id="FieldExample":::

Both setters accept the same range, but their objects start with different values. `Date` initializes its field to `7`; `DateExample` leaves its backing field at the default value, `0`. A setter's validation applies when that setter runs, not to the field's default value.

## Stored and computed values

The following property returns a stored field directly:

:::code language="csharp" source="./snippets/properties/Person.cs" id="UsingEmployeeExample":::

Callers read the property without access to the field:

:::code language="csharp" source="./snippets/properties/Program.cs" id="GetAccessor":::

The compiler and just-in-time (JIT) compiler can optimize simple accessor patterns, including direct reads and writes of backing fields. Actual optimizations depend on the runtime and calling context.

> [!WARNING]
>
> It's generally a bad programming style to change the state of the object by using the `get` accessor. One exception to this rule is a *lazy evaluated* property, where the value of a property is computed only when it's first accessed.

The next property computes a fallback value instead of returning an uninitialized name:

:::code language="csharp" source="./snippets/properties/Person.cs" id="ManageExample":::

In the previous example, if you don't assign a value to the `Name` property, it returns the value `NA`.

## Changes through a setter

The following `Student` class exposes its private name through a read/write property:

:::code language="csharp" source="./snippets/properties/Person.cs" id="StudentExample":::

The caller assigns and reads the name through the same public member:

:::code language="csharp" source="./snippets/properties/Program.cs" id="SetAccessor":::

Property syntax also lets callers express a read and update as `person.Age += 1`. If a type instead exposes separate `GetAge` and `SetAge` methods, the equivalent operation is:

```csharp
person.SetAge(person.GetAge() + 1);
```

Both versions read the current age and write the incremented value. The property version expresses the accessor calls through assignment syntax. See [Compound property assignment](../../fundamentals/classes/properties.md#declare-an-auto-implemented-property) for a runnable example.

## Remarks

A property can be declared as a static property by using the `static` keyword. Static properties are available to callers at any time, even if no instance of the class exists. For more information, see [Static Classes and Static Class Members](./static-classes-and-static-class-members.md).

A property can be marked as a virtual property by using the [virtual](../../language-reference/keywords/virtual.md) keyword. Virtual properties enable derived classes to override the property behavior by using the [override](../../language-reference/keywords/override.md) keyword. For more information about these options, see [Inheritance](../../fundamentals/object-oriented/inheritance.md).

A property overriding a virtual property can also be [sealed](../../language-reference/keywords/sealed.md), specifying that for derived classes it's no longer virtual. Lastly, a property can be declared [abstract](../../language-reference/keywords/abstract.md). Abstract properties don't define an implementation in the class, and derived classes must write their own implementation. For more information about these options, see [Abstract and Sealed Classes and Class Members](abstract-and-sealed-classes-and-class-members.md).

> [!NOTE]
> It's an error to use a [virtual](../../language-reference/keywords/virtual.md), [abstract](../../language-reference/keywords/abstract.md), or [override](../../language-reference/keywords/override.md) modifier on an accessor of a [static](../../language-reference/keywords/static.md) property.

## Examples

This example demonstrates instance, static, and read-only properties. It accepts the name of the employee from the keyboard, increments `NumberOfEmployees` by 1, and displays the Employee name and number.

:::code language="csharp" source="./snippets/properties/CompleteEmployee.cs" id="EmployeeExample":::

## Hidden property example

This example demonstrates how to access a property in a base class that's hidden by another property that has the same name in a derived class:

:::code language="csharp" source="./snippets/properties/HidingProperty.cs" id="Hiding":::

The following are important points in the previous example:

- The property `Name` in the derived class hides the property `Name` in the base class. In such a case, the `new` modifier is used in the declaration of the property in the derived class:
     :::code language="csharp" source="./snippets/properties/HidingProperty.cs" id="NewProperty":::
- The cast `(Employee)` is used to access the hidden property in the base class:
     :::code language="csharp" source="./snippets/properties/HidingProperty.cs" id="CastToBase":::

For more information about hiding members, see the [new Modifier](../../language-reference/keywords/new-modifier.md).

## Override property example

In this example, two classes, `Cube` and `Square`, implement an abstract class, `Shape`, and override its abstract `Area` property. Note the use of the [override](../../language-reference/keywords/override.md) modifier on the properties. The program accepts the side as an input and calculates the areas for the square and cube. It also accepts the area as an input and calculates the corresponding side for the square and cube.

:::code language="csharp" source="~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideProperties/CS/Properties.cs" id="Snippet6":::

## See also

- [Properties](../../fundamentals/classes/properties.md)
- [Interface properties](interface-properties.md)
- [Automatically implemented properties](../../fundamentals/classes/properties.md#declare-an-auto-implemented-property)
- [Partial properties](../../language-reference/keywords/partial-member.md)
