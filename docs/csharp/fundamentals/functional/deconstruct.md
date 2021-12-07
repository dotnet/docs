---
title: Deconstructing tuples and other types
description: Learn how to deconstruct tuples and other types.
ms.date: 11/10/2021
---
# Deconstructing tuples and other types

A tuple provides a lightweight way to retrieve multiple values from a method call. But once you retrieve the tuple, you have to handle its individual elements. Working on an element-by-element basis is cumbersome, as the following example shows. The `QueryCityData` method returns a three-tuple, and each of its elements is assigned to a variable in a separate operation.

:::code language="csharp" source="./snippets/deconstructing-tuples/deconstruct-tuple1.cs":::

Retrieving multiple field and property values from an object can be equally cumbersome: you must assign a field or property value to a variable on a member-by-member basis.

In C# 7.0 and later, you can retrieve multiple elements from a tuple or retrieve multiple field, property, and computed values from an object in a single *deconstruct* operation. To deconstruct a tuple, you assign its elements to individual variables. When you deconstruct an object, you assign selected values to individual variables.

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

    This is cumbersome and isn't recommended.

- Lastly, you may deconstruct the tuple into variables that have already been declared.

    :::code language="csharp" source="./snippets/deconstructing-tuples/deconstruct-tuple5.cs" ID="Snippet1":::

- Beginning in C# 10, you can mix variable declaration and assignment in a deconstruction.

    :::code language="csharp" source="./snippets/deconstructing-tuples/deconstruct-tuple6.cs" ID="Snippet1":::

You can't specify a specific type outside the parentheses even if every field in the tuple has the
same type. Doing so generates compiler error CS8136, "Deconstruction 'var (...)' form disallows a specific type for 'var'.".

You must assign each element of the tuple to a variable. If you omit any elements, the compiler generates error CS8132, "Can't deconstruct a tuple of 'x' elements into 'y' variables."

## Tuple elements with discards

Often when deconstructing a tuple, you're interested in the values of only some elements. Starting with C# 7.0, you can take advantage of C#'s support for *discards*, which are write-only variables whose values you've chosen to ignore. A discard is chosen by an underscore character ("\_") in an assignment. You can discard as many values as you like; all are represented by the single discard, `_`.

The following example illustrates the use of tuples with discards. The `QueryCityDataForYears` method returns a six-tuple with the name of a city, its area, a year, the city's population for that year, a second year, and the city's population for that second year. The example shows the change in population between those two years. Of the data available from the tuple, we're unconcerned with the city area, and we know the city name and the two dates at design-time. As a result, we're only interested in the two population values stored in the tuple, and can handle its remaining values as discards.  

:::code language="csharp" source="./snippets/deconstructing-tuples/discard-tuple1.cs":::

## User-defined types

C# doesn't offer built-in support for deconstructing non-tuple types other than the [`record`](#record-types) and [DictionaryEntry](xref:System.Collections.DictionaryEntry.Deconstruct%2A) types. However, as the author of a class, a struct, or an interface, you can allow instances of the type to be deconstructed by implementing one or more `Deconstruct` methods. The method returns void, and each value to be deconstructed is indicated by an [out](../../language-reference/keywords/out-parameter-modifier.md) parameter in the method signature. For example, the following `Deconstruct` method of a `Person` class returns the first, middle, and last name:

:::code language="csharp" source="./snippets/deconstructing-tuples/deconstruct-class1.cs" ID="Snippet1":::

You can then deconstruct an instance of the `Person` class named `p` with an assignment like the following code:

:::code language="csharp" source="./snippets/deconstructing-tuples/deconstruct-class1.cs" ID="Snippet2":::

The following example overloads the `Deconstruct` method to return various combinations of properties of a `Person` object. Individual overloads return:

- A first and last name.
- A first, middle, and last name.
- A first name, a last name, a city name, and a state name.

:::code language="csharp" source="./snippets/deconstructing-tuples/deconstruct-class2.cs":::

Multiple `Deconstruct` methods having the same number of parameters are ambiguous. You must be careful to define `Deconstruct` methods with different numbers of parameters, or "arity". `Deconstruct` methods with the same number of parameters cannot be distinguished during overload resolution.

## User-defined type with discards

Just as you do with [tuples](#tuple-elements-with-discards), you can use discards to ignore selected items returned by a `Deconstruct` method. Each discard is defined by a variable named "\_", and a single deconstruction operation can include multiple discards.

The following example deconstructs a `Person` object into four strings (the first and last names, the city, and the state) but discards the last name and the state.

:::code language="csharp" source="./snippets/deconstructing-tuples/class-discard1.cs" ID="Snippet1":::

## Extension methods for user-defined types

If you didn't author a class, struct, or interface, you can still deconstruct objects of that type by implementing one or more `Deconstruct` [extension methods](../../programming-guide/classes-and-structs/extension-methods.md) to return the values in which you're interested.

The following example defines two `Deconstruct` extension methods for the <xref:System.Reflection.PropertyInfo?displayProperty=nameWithType> class. The first returns a set of values that indicate the characteristics of the property, including its type, whether it's static or instance, whether it's read-only, and whether it's indexed. The second indicates the property's accessibility. Because the accessibility of get and set accessors can differ, Boolean values indicate whether the property has separate get and set accessors and, if it does, whether they have the same accessibility. If there's only one accessor or both the get and the set accessor have the same accessibility, the `access` variable indicates the accessibility of the property as a whole. Otherwise, the accessibility of the get and set accessors are indicated by the `getAccess` and `setAccess` variables.

:::code source="./snippets/deconstructing-tuples/deconstruct-extension1.cs":::

## Extension method for system types

Some system types provide the `Deconstruct` method as a convenience. For example, the <xref:System.Collections.Generic.KeyValuePair%602?displayProperty=nameWithType> type provides this functionality. When you're iterating over a <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType> each element is a `KeyValuePair<TKey, TValue>` and can be deconstructed. Consider the following example:

:::code source="./snippets/deconstructing-tuples/deconstruct-kvp.cs" id="KeyValuePair":::

You can add a `Deconstruct` method to system types that don't have one. Consider the following extension method:

:::code source="./snippets/deconstructing-tuples/deconstruct-extension2.cs" id="NullableExtensions":::

This extension method allows all <xref:System.Nullable%601> types to be deconstructed into a tuple of `(bool hasValue, T value)`. The following example shows code that uses this extension method:

:::code source="./snippets/deconstructing-tuples/deconstruct-extension2.cs" id="NullableExample":::

## `record` types

When you declare a [record](../../language-reference/builtin-types/record.md) type by using two or more positional parameters, the compiler creates a `Deconstruct` method with an `out` parameter for each positional parameter in the `record` declaration. For more information, see [Positional syntax for property definition](../../language-reference/builtin-types/record.md#positional-syntax-for-property-definition) and [Deconstructor behavior in derived records](../../language-reference/builtin-types/record.md#deconstructor-behavior-in-derived-records).

## See also

- [Discards](discards.md)
- [Tuple types](../../language-reference/builtin-types/value-tuples.md)
