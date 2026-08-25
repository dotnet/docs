---
description: "A partial type is a type declaration that allows you to split the declaration of the type into multiple files."
title: "Partial type"
ms.date: 01/22/2026
f1_keywords: 
  - "partialtype"
  - "partialtype_CSharpKeyword"
helpviewer_keywords: 
  - "partial types [C#]"
---
# Partial type (C# Reference)

Partial type definitions allow you to split the definition of a class, struct, interface, or record into multiple definitions. You can put these multiple definitions in different files within the same project. One type declaration contains only the signatures for [partial members](./partial-member.md):

:::code language="csharp" source="./snippets/PartialMembers.cs" id="DeclaringPart":::

The other declaration contains the implementation of the partial members:

:::code language="csharp" source="./snippets/PartialMembers.cs" id="ImplementingPart":::

The declarations for a partial type can appear in either the same or multiple files. Typically, the two declarations are in different files. You split a class, struct, or interface type when you're working with large projects, with automatically generated code such as that provided by the [Windows Forms Designer](/dotnet/desktop/winforms/controls/developing-windows-forms-controls-at-design-time), or [Source generators like RegEx](../../../standard/base-types/regular-expression-source-generators.md). A partial type can contain [partial members](partial-member.md).

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

Starting with C# 13, you can define partial properties and partial indexers. Starting with C# 14, you can define partial instance constructors and partial events. Before C# 13, only methods could be defined as partial members.

You can provide documentation comments on either the declaring declaration or the implementing declaration. When you apply documentation comments to both type declarations, the XML elements from each declaration are included in the output XML. For the rules on partial member declarations, see the article on [partial members](./partial-member.md).

You can apply attributes to either declaration. The compiler combines all attributes from both declarations, including duplicates.

For more information, see [Partial Classes and Methods](../../programming-guide/classes-and-structs/partial-classes-and-methods.md).

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [Modifiers](index.md)
- [Introduction to Generics](../../fundamentals/types/generics.md)
