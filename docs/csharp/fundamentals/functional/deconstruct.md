---
title: Deconstructing tuples and other types
description: Learn how to deconstruct tuples and other types.
ms.date: 11/22/2024
ms.topic: concept-article
---
# Deconstructing tuples and other types

A tuple provides a lightweight way to retrieve multiple values from a method call. But once you retrieve the tuple, you have to handle its individual elements. Working on an element-by-element basis is cumbersome, as the following example shows. The `QueryCityData` method returns a three-tuple, and each of its elements is assigned to a variable in a separate operation.

:::code language="csharp" source="./snippets/deconstructing-tuples/deconstruct-tuple1.cs":::

Retrieving multiple field and property values from an object can be equally cumbersome: you must assign a field or property value to a variable on a member-by-member basis.

You can retrieve multiple elements from a tuple or retrieve multiple field, property, and computed values from an object in a single *deconstruct* operation. To deconstruct a tuple, you assign its elements to individual variables. When you deconstruct an object, you assign selected values to individual variables.

## Tuples

C# features built-in support for deconstructing tuples, which lets you unpackage all the items in a tuple in a single operation. The general syntax for deconstructing a tuple is similar to the syntax for defining one: you enclose the variables to which each element is to be assigned in parentheses in the left side of an assignment statement. For example, the following statement assigns the elements of a four-tuple to four separate variables:

```csharp
var (name, address, city, zip) = contact.GetAddressInfo();
```

There are three ways to deconstruct a tuple:

- You can explicitly declare the type of each field inside parentheses. The following example uses this approach to deconstruct the three-tuple returned by the `QueryCityData` method.

    :::code language="csharp" source="./snippets/deconstructing-tuples/deconstruct-tuple2.cs" ID="Snippet1":::

- You can use the `var` keyword so that C# infers the type of each variable. You place the `var` keyword outside of the parentheses. The following example uses type inference when deconstructing the three-tuple returned by the `QueryCityData` method.

    :::code language="csharp" source="./snippets/deconstructing-tuples/deconstruct-tuple3.cs" ID="Snippet1":::

    You can also use the `var` keyword individually with any or all of the variable declarations inside the parentheses.

    :::code language="csharp" source="./snippets/deconstructing-tuples/deconstruct-tuple4.cs" ID="Snippet1":::

    The preceding example is cumbersome and isn't recommended.

- Lastly, you can deconstruct the tuple into variables already declared.

    :::code language="csharp" source="./snippets/deconstructing-tuples/deconstruct-tuple5.cs" ID="Snippet1":::

- You can mix variable declaration and assignment in a deconstruction.

    :::code language="csharp" source="./snippets/deconstructing-tuples/deconstruct-tuple6.cs" ID="Snippet1":::

You can't specify a specific type outside the parentheses even if every field in the tuple has the
same type. Doing so generates compiler error CS8136, "Deconstruction 'var (...)' form disallows a specific type for 'var'."

You must assign each element of the tuple to a variable. If you omit any elements, the compiler generates error CS8132, "Can't deconstruct a tuple of 'x' elements into 'y' variables."

## Tuple elements with discards

Often when deconstructing a tuple, you're interested in the values of only some elements. You can take advantage of C#'s support for *discards*, which are write-only variables whose values you chose to ignore. You declare a discard with an underscore character ("\_") in an assignment. You can discard as many values as you like; a single discard, `_`, represents all the discarded values.

The following example illustrates the use of tuples with discards. The `QueryCityDataForYears` method returns a six-tuple with the name of a city, its area, a year, the city's population for that year, a second year, and the city's population for that second year. The example shows the change in population between those two years. Of the data available from the tuple, we're unconcerned with the city area, and we know the city name and the two dates at design-time. As a result, we're only interested in the two population values stored in the tuple, and can handle its remaining values as discards.

:::code language="csharp" source="./snippets/deconstructing-tuples/discard-tuple1.cs":::

## User-defined types

C# offers built-in support for deconstructing tuple types, [`record`](#record-types), and [DictionaryEntry](xref:System.Collections.DictionaryEntry.Deconstruct%2A) types. However, as the author of a class, a struct, or an interface, you can allow instances of the type to be deconstructed by implementing one or more `Deconstruct` methods. The method returns void. An [out](../../language-reference/keywords/method-parameters.md#out-parameter-modifier) parameter in the method signature represents each value to be deconstructed. For example, the following `Deconstruct` method of a `Person` class returns the first, middle, and family name:

:::code language="csharp" source="./snippets/deconstructing-tuples/deconstruct-class1.cs" ID="Snippet1":::

You can then deconstruct an instance of the `Person` class named `p` with an assignment like the following code:

:::code language="csharp" source="./snippets/deconstructing-tuples/deconstruct-class1.cs" ID="Snippet2":::

The following example overloads the `Deconstruct` method to return various combinations of properties of a `Person` object. Individual overloads return:

- A first and family name.
- A first, middle, and family name.
- A first name, a family name, a city name, and a state name.

:::code language="csharp" source="./snippets/deconstructing-tuples/deconstruct-class2.cs":::

Multiple `Deconstruct` methods having the same number of parameters are ambiguous. You must be careful to define `Deconstruct` methods with different numbers of parameters, or "arity". `Deconstruct` methods with the same number of parameters can't be distinguished during overload resolution.

## User-defined type with discards

Just as you do with [tuples](#tuple-elements-with-discards), you can use discards to ignore selected items returned by a `Deconstruct` method. A variable named "\_" represents a discard. A single deconstruction operation can include multiple discards.

The following example deconstructs a `Person` object into four strings (the first and family names, the city, and the state) but discards the family name and the state.

:::code language="csharp" source="./snippets/deconstructing-tuples/class-discard1.cs" ID="Snippet1":::

## Deconstruction extension methods

If you didn't author a class, struct, or interface, you can still deconstruct objects of that type by implementing one or more `Deconstruct` [extension methods](../../programming-guide/classes-and-structs/extension-methods.md) to return the values in which you're interested.

The following example defines two `Deconstruct` extension methods for the <xref:System.Reflection.PropertyInfo?displayProperty=nameWithType> class. The first returns a set of values that indicate the characteristics of the property. The second indicates the property's accessibility. Boolean values indicate whether the property has separate get and set accessors or different accessibility. If there's only one accessor or both the get and the set accessor have the same accessibility, the `access` variable indicates the accessibility of the property as a whole. Otherwise, the accessibility of the get and set accessors are indicated by the `getAccess` and `setAccess` variables.

:::code source="./snippets/deconstructing-tuples/deconstruct-extension1.cs":::

## Extension method for system types

Some system types provide the `Deconstruct` method as a convenience. For example, the <xref:System.Collections.Generic.KeyValuePair%602?displayProperty=nameWithType> type provides this functionality. When you're iterating over a <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType>, each element is a `KeyValuePair<TKey, TValue>` and can be deconstructed. Consider the following example:

:::code source="./snippets/deconstructing-tuples/deconstruct-kvp.cs" id="KeyValuePair":::

## `record` types

When you declare a [record](../../language-reference/builtin-types/record.md) type by using two or more positional parameters, the compiler creates a `Deconstruct` method with an `out` parameter for each positional parameter in the `record` declaration. For more information, see [Positional syntax for property definition](../../language-reference/builtin-types/record.md#positional-syntax-for-property-and-field-definition) and [Deconstructor behavior in derived records](../../language-reference/builtin-types/record.md#deconstructor-behavior-in-derived-records).

## See also

- [Deconstruct variable declaration (style rule IDE0042)](../../../fundamentals/code-analysis/style-rules/ide0042.md)
- [Discards](discards.md)
- [Tuple types](../../language-reference/builtin-types/value-tuples.md)
