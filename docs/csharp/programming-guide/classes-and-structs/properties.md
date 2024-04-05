---
title: "Properties - C# Programming Guide"
description: A property in C# is a member that uses accessor methods to read, write, or compute the value of a private field as if it were a public data member.
ms.date: 03/15/2024
f1_keywords:
  - "cs.properties"
helpviewer_keywords:
  - "properties [C#]"
  - "C# language, properties"
---
# Properties (C# Programming Guide)

A property is a member that provides a flexible mechanism to read, write, or compute the value of a private field. Properties can be used as if they're public data members, but they're special methods called *accessors*. This feature enables data to be accessed easily and still helps promote the safety and flexibility of methods.

## Properties overview

- Properties enable a class to expose a public way of getting and setting values, while hiding implementation or verification code.
- A [get](../../language-reference/keywords/get.md) property accessor is used to return the property value, and a [set](../../language-reference/keywords/set.md) property accessor is used to assign a new value. An [init](../../language-reference/keywords/init.md) property accessor is used to assign a new value only during object construction. These accessors can have different access levels. For more information, see [Restricting Accessor Accessibility](./restricting-accessor-accessibility.md).
- The [value](../../language-reference/keywords/value.md) keyword is used to define the value the `set` or `init` accessor is assigning.
- Properties can be *read-write* (they have both a `get` and a `set` accessor), *read-only* (they have a `get` accessor but no `set` accessor), or *write-only* (they have a `set` accessor, but no `get` accessor). Write-only properties are rare and are most commonly used to restrict access to sensitive data.
- Simple properties that require no custom accessor code can be implemented either as expression body definitions or as [auto-implemented properties](./auto-implemented-properties.md).

## Properties with backing fields

One basic pattern for implementing a property involves using a private backing field for setting and retrieving the property value. The `get` accessor returns the value of the private field, and the `set` accessor may perform some data validation before assigning a value to the private field. Both accessors may also perform some conversion or computation on the data before it's stored or returned.

The following example illustrates this pattern. In this example, the `TimePeriod` class represents an interval of time. Internally, the class stores the time interval in seconds in a private field named `_seconds`. A read-write property named `Hours` allows the customer to specify the time interval in hours. Both the `get` and the `set` accessors perform the necessary conversion between hours and seconds. In addition, the `set` accessor validates the data and throws an <xref:System.ArgumentOutOfRangeException> if the number of hours is invalid.

:::code language="csharp" source="./snippets/properties/TimePeriod.cs" id="PropertyExample":::

You could access properties to get and set the value as shown in the following example:

:::code language="csharp" source="./snippets/properties/Program.cs" id="UseTimePeriod":::

## Expression body definitions

Property accessors often consist of single-line statements that just assign or return the result of an expression. You can implement these properties as expression-bodied members. Expression body definitions consist of the `=>` symbol followed by the expression to assign to or retrieve from the property.

Read-only properties can implement the `get` accessor as an expression-bodied member. In this case, neither the `get` accessor keyword nor the `return` keyword is used. The following example implements the read-only `Name` property as an expression-bodied member.

:::code language="csharp" source="./snippets/properties/Person.cs" id="ExpressionBodiedProperty":::

Both the `get` and the `set` accessor can be implemented as expression-bodied members. In this case, the `get` and `set` keywords must be present. The following example illustrates the use of expression body definitions for both accessors. The `return` keyword isn't used with the `get` accessor.

:::code language="csharp" source="./snippets/properties/SaleItem.cs" id="SaleItemV1":::

## Auto-implemented properties

In some cases, property `get` and `set` accessors just assign a value to or retrieve a value from a backing field without including any extra logic. By using auto-implemented properties, you can simplify your code while having the C# compiler transparently provide the backing field for you.

If a property has both a `get` and a `set` (or a `get` and an `init`) accessor, both must be auto-implemented. You define an auto-implemented property by using the `get` and `set` keywords without providing any implementation. The following example repeats the previous one, except that `Name` and `Price` are auto-implemented properties. The example also removes the parameterized constructor, so that `SaleItem` objects are now initialized with a call to the parameterless constructor and an [object initializer](object-and-collection-initializers.md).

:::code language="csharp" source="./snippets/properties/SaleItem.cs" id="SaleItemV2":::

Auto-implemented properties can declare different accessibilities for the `get` and `set` accessors. You commonly declare a public `get` accessor and a private `set` accessor. You can learn more in the article on [restricting accessor accessibility](./restricting-accessor-accessibility.md).

## Required properties

Beginning with C# 11, you can add the `required` member to force client code to initialize any property or field:

:::code language="csharp" source="./snippets/properties/SaleItem.cs" id="SaleItemV3":::

To create a `SaleItem`, you must set both the `Name` and `Price` properties using [object initializers](./object-and-collection-initializers.md), as shown in the following code:

:::code language="csharp" source="./snippets/properties/Program.cs" id="RequiredExample":::

## Related sections

- [Using Properties](./using-properties.md)
- [Interface Properties](./interface-properties.md)
- [Comparison Between Properties and Indexers](../indexers/comparison-between-properties-and-indexers.md)
- [Restricting Accessor Accessibility](./restricting-accessor-accessibility.md)
- [Auto-Implemented Properties](./auto-implemented-properties.md)

## C# Language Specification

For more information, see [Properties](~/_csharpstandard/standard/classes.md#157-properties) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.

## See also

- [Indexers](../indexers/index.md)
- [init keyword](../../language-reference/keywords/init.md)
- [get keyword](../../language-reference/keywords/get.md)
- [set keyword](../../language-reference/keywords/set.md)
