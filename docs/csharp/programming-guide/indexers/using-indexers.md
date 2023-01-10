---
title: "Using Indexers - C# Programming Guide"
description: Learn how to declare and use an indexer for a class, struct, or interface in C#. This article includes example code.
ms.date: 07/15/2020
helpviewer_keywords:
  - "indexers [C#], about indexers"
ms.assetid: df70e1a2-3ce3-4aba-ad80-4b2f3538699f
---

# Using indexers (C# Programming Guide)

Indexers are a syntactic convenience that enable you to create a [class](../../language-reference/keywords/class.md), [struct](../../language-reference/builtin-types/struct.md), or [interface](../../language-reference/keywords/interface.md) that client applications can access as an array. The compiler will generate an `Item` property (or an alternatively named property if <xref:System.Runtime.CompilerServices.IndexerNameAttribute> is present), and the appropriate accessor methods. Indexers are most frequently implemented in types whose primary purpose is to encapsulate an internal collection or array. For example, suppose you have a class `TempRecord` that represents the temperature in Fahrenheit as recorded at 10 different times during a 24-hour period. The class contains a `temps` array of type `float[]` to store the temperature values. By implementing an indexer in this class, clients can access the temperatures in a `TempRecord` instance as `float temp = tempRecord[4]` instead of as `float temp = tempRecord.temps[4]`. The indexer notation not only simplifies the syntax for client applications; it also makes the class, and its purpose more intuitive for other developers to understand.

To declare an indexer on a class or struct, use the [this](../../language-reference/keywords/this.md) keyword, as the following example shows:

```csharp
// Indexer declaration
public int this[int index]
{
    // get and set accessors
}
```

> [!IMPORTANT]
> Declaring an indexer will automatically generate a property named `Item` on the object. The `Item` property is not directly accessible from the instance [member access expression](../../language-reference/operators/member-access-operators.md#member-access-expression-). Additionally, if you add your own `Item` property to an object with an indexer, you'll get a [CS0102 compiler error](../../misc/cs0102.md). To avoid this error, use the <xref:System.Runtime.CompilerServices.IndexerNameAttribute> rename the indexer as detailed below.

## Remarks

The type of an indexer and the type of its parameters must be at least as accessible as the indexer itself. For more information about accessibility levels, see [Access Modifiers](../../language-reference/keywords/access-modifiers.md).

For more information about how to use indexers with an interface, see [Interface Indexers](./indexers-in-interfaces.md).

The signature of an indexer consists of the number and types of its formal parameters. It doesn't include the indexer type or the names of the formal parameters. If you declare more than one indexer in the same class, they must have different signatures.

An indexer is not classified as a variable; therefore, an indexer value cannot be passed by reference (as a [`ref`](../../language-reference/keywords/ref.md) or [`out`](../../language-reference/keywords/out-parameter-modifier.md) parameter) unless its value is a reference (i.e., it returns by reference.)

To provide the indexer with a name that other languages can use, use <xref:System.Runtime.CompilerServices.IndexerNameAttribute?displayProperty=nameWithType>, as the following example shows:

```csharp
// Indexer declaration
[System.Runtime.CompilerServices.IndexerName("TheItem")]
public int this[int index]
{
    // get and set accessors
}
```

This indexer will have the name `TheItem`, as it is overridden by the indexer name attribute. By default, the indexer name is `Item`.

## Example 1

The following example shows how to declare a private array field, `temps`, and an indexer. The indexer enables direct access to the instance `tempRecord[i]`. The alternative to using the indexer is to declare the array as a [public](../../language-reference/keywords/public.md) member and access its members, `tempRecord.temps[i]`, directly.

:::code language="csharp" source="snippets/Temperatures/TempRecord.cs":::

Notice that when an indexer's access is evaluated, for example, in a `Console.Write` statement, the [get](../../language-reference/keywords/get.md) accessor is invoked. Therefore, if no `get` accessor exists, a compile-time error occurs.

:::code language="csharp" source="snippets/Temperatures/Program.cs":::

## Indexing using other values

C# doesn't limit the indexer parameter type to integer. For example, it may be useful to use a string with an indexer. Such an indexer might be implemented by searching for the string in the collection, and returning the appropriate value. As accessors can be overloaded, the string and integer versions can coexist.

## Example 2

The following example declares a class that stores the days of the week. A `get` accessor takes a string, the name of a day, and returns the corresponding integer. For example, "Sunday" returns 0, "Monday" returns 1, and so on.

:::code language="csharp" source="snippets/StringIndexers/DayCollection.cs":::

### Consuming example 2

:::code language="csharp" source="snippets/StringIndexers/Program.cs":::

## Example 3

The following example declares a class that stores the days of the week using the <xref:System.DayOfWeek?displayProperty=fullName> enum. A `get` accessor takes a `DayOfWeek`, the value of a day, and returns the corresponding integer. For example, `DayOfWeek.Sunday` returns 0, `DayOfWeek.Monday` returns 1, and so on.

:::code language="csharp" source="snippets/DayOfWeekIndexers/DayOfWeekCollection.cs":::

### Consuming example 3

:::code language="csharp" source="snippets/DayOfWeekIndexers/Program.cs":::

## Robust programming

There are two main ways in which the security and reliability of indexers can be improved:

- Be sure to incorporate some type of error-handling strategy to handle the chance of client code passing in an invalid index value. In the first example earlier in this topic, the TempRecord class provides a Length property that enables the client code to verify the input before passing it to the indexer. You can also put the error handling code inside the indexer itself. Be sure to document for users any exceptions that you throw inside an indexer accessor.

- Set the accessibility of the [get](../../language-reference/keywords/get.md) and [set](../../language-reference/keywords/set.md) accessors to be as restrictive as is reasonable. This is important for the `set` accessor in particular. For more information, see [Restricting Accessor Accessibility](../classes-and-structs/restricting-accessor-accessibility.md).

## See also

- [C# Programming Guide](../index.md)
- [Indexers](./index.md)
- [Properties](../classes-and-structs/properties.md)
