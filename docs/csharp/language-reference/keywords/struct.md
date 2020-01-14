---
title: "struct - C# Reference"
ms.date: 07/20/2015
f1_keywords: 
  - "struct_CSharpKeyword"
helpviewer_keywords: 
  - "struct keyword [C#]"
  - "structs [C#], struct keyword"
ms.assetid: ff3dd9b7-dc93-4720-8855-ef5558f65c7c
---
# struct (C# Reference)

A `struct` type is a value type that is typically used to encapsulate small groups of related variables, such as the coordinates of a rectangle or the characteristics of an item in an inventory. The following example shows a simple struct declaration:

```csharp
public struct Book
{
    public decimal price;
    public string title;
    public string author;
}
```

## Remarks

Structs can also contain [constructors](../../programming-guide/classes-and-structs/constructors.md), [constants](../../programming-guide/classes-and-structs/constants.md), [fields](../../programming-guide/classes-and-structs/fields.md), [methods](../../programming-guide/classes-and-structs/methods.md), [properties](../../programming-guide/classes-and-structs/properties.md), [indexers](../../programming-guide/indexers/index.md), [operators](../operators/index.md), [events](../../programming-guide/events/index.md), and [nested types](../../programming-guide/classes-and-structs/nested-types.md), although if several such members are required, you should consider making your type a class instead.

For examples, see [Using Structs](../../programming-guide/classes-and-structs/using-structs.md).

Structs can implement an interface but they cannot inherit from another struct. For that reason, struct members cannot be declared as `protected`.

For more information, see [Structs](../../programming-guide/classes-and-structs/structs.md).

## Examples

For examples and more information, see [Using Structs](../../programming-guide/classes-and-structs/using-structs.md).

## C# language specification

For examples, see [Using Structs](../../programming-guide/classes-and-structs/using-structs.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Default Values Table](default-values-table.md)
- [Built-In Types Table](built-in-types-table.md)
- [Types](/dotnet/csharp/language-reference/keywords)
- [Value Types](value-types.md)
- [class](class.md)
- [interface](interface.md)
- [Classes and Structs](../../programming-guide/classes-and-structs/index.md)
