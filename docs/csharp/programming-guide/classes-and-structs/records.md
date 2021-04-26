---
title: "Records - C# Programming Guide"
description: Learn about the record types and how to create them
ms.date: 02/26/2021
helpviewer_keywords: 
  - "records [C#]"
  - "C# language, records"
---
# Records (C# Programming Guide)

A [record](../../language-reference/builtin-types/record.md) is a [class](../../language-reference/keywords/class.md) that provides special syntax and behavior for working with data models. For information about classes, see [Classes (C# Programming Guide)](classes.md).

## When to use records

Consider using a record in place of a class in the following scenarios:

* You want to define a reference type for which objects are immutable.
* You want to define a data model that depends on [value equality](../statements-expressions-operators/equality-comparisons.md#value-equality).

### Immutability

An immutable type is one that prevents you from changing any property or field values of an object after it's instantiated. Immutability can be useful when you need a type to be thread-safe or you're depending on a hash code remaining the same in a hash table. Records provide concise syntax for creating and working with immutable types.

Immutability isn't appropriate for all data scenarios. [Entity Framework Core](/ef/core/), for example, doesn't support updating with immutable entity types.

### Value equality

For records, value equality means that two variables of a record type are equal if the types match and all property and field values match. For other reference types such as classes, equality means [reference equality](../statements-expressions-operators/equality-comparisons.md#reference-equality). That is, two variables of a class type are equal if they refer to the same object. Methods and operators that determine equality of two record instances use value equality.

Not all data models work well with value equality. For example, [Entity Framework Core](/ef/core/) depends on reference equality to ensure that it uses only one instance of an entity type for what is conceptually one entity. For this reason, record types aren't appropriate for use as entity types in Entity Framework Core.

## How records differ from classes

The same syntax that [declares](classes.md#declaring-classes) and [instantiates](classes.md#creating-objects) classes can be used with records. Just substitute the `record` keyword for the `class` keyword. Likewise, the same syntax for expressing inheritance relationships is supported by records. Records differ from classes in the following ways:

* You can use [positional parameters](../../language-reference/builtin-types/record.md#positional-syntax-for-property-definition) to create and instantiate a type with immutable properties.
* The same methods and operators that indicate reference equality or inequality in classes (such as <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType> and `==`), indicate [value equality or inequality](../../language-reference/builtin-types/record.md#value-equality) in records.
* You can use a [`with` expression](../../language-reference/builtin-types/record.md#nondestructive-mutation) to create a copy of an immutable object with new values in selected properties.
* A record's `ToString` method creates a formatted string that shows an object's type name and the names and values of all its public properties.
* A record can [inherit from another record](../../language-reference/builtin-types/record.md#inheritance). A record can't inherit from a class, and a class can't inherit from a record.

## Examples

The following example defines a public record that uses positional parameters to declare and instantiate a record. It then prints out the type name and property values:

:::code language="csharp" source="../../language-reference/builtin-types/snippets/shared/RecordType.cs" id="InstantiatePositional":::

The following example demonstrates value equality in records:

:::code language="csharp" source="../../language-reference/builtin-types/snippets/shared/RecordType.cs" id="Equality":::

The following example demonstrates use of a `with` expression to copy an immutable object and change one of the properties:

:::code language="csharp" source="../../language-reference/builtin-types/snippets/shared/RecordType.cs" id="WithExpressions":::

For more information, see [Records (C# reference)](../../language-reference/builtin-types/record.md).
  
## C# Language Specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See also

- [Classes (C# Programming Guide)](classes.md)
- [Records (C# reference)](../../language-reference/builtin-types/record.md)
- [C# Programming Guide](../index.md)
- [Object-Oriented Programming](../../tutorials/intro-to-csharp/object-oriented-programming.md)
- [Polymorphism](polymorphism.md)
- [Identifier names](../inside-a-program/identifier-names.md)
- [Members](members.md)
- [Methods](methods.md)
- [Constructors](constructors.md)
- [Finalizers](destructors.md)
- [Objects](objects.md)
