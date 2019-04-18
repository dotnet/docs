---
title: "namespace keyword - C# Reference"
ms.custom: seoapril2019

ms.date: 07/20/2015
f1_keywords: 
  - "namespace_CSharpKeyword"
  - "namespace"
helpviewer_keywords: 
  - "namespace keyword [C#]"
  - "scope [C#]"
ms.assetid: 0a788423-9110-42e0-97d9-bda41ca4870f
---
# namespace (C# Reference)

The `namespace` keyword is used to declare a scope that contains a set of related objects. You can use a namespace to organize code elements and to create globally unique types.

[!code-csharp[csrefKeywordsNamespace#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsNamespace/CS/csrefKeywordsNamespace.cs#1)]

## Remarks

Within a namespace, you can declare zero or more of the following types:

- another namespace

- [class](class.md)

- [interface](interface.md)

- [struct](struct.md)

- [enum](enum.md)

- [delegate](delegate.md)

Whether or not you explicitly declare a namespace in a C# source file, the compiler adds a default namespace. This unnamed namespace, sometimes referred to as the global namespace, is present in every file. Any identifier in the global namespace is available for use in a named namespace.

Namespaces implicitly have public access and this is not modifiable. For a discussion of the access modifiers you can assign to elements in a namespace, see [Access Modifiers](access-modifiers.md).

It is possible to define a namespace in two or more declarations. For example, the following example defines two classes as part of the `MyCompany` namespace:

[!code-csharp[csrefKeywordsNamespace#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsNamespace/CS/csrefKeywordsNamespace.cs#2)]

## Example

The following example shows how to call a static method in a nested namespace.

[!code-csharp[csrefKeywordsNamespace#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsNamespace/CS/csrefKeywordsNamespace.cs#3)]

## Related resources

For more information about using namespaces, see the following topics:

- [Namespaces](../../programming-guide/namespaces/index.md)

- [Using Namespaces](../../programming-guide/namespaces/using-namespaces.md)

- [How to: Use the Global Namespace Alias](../../programming-guide/namespaces/how-to-use-the-global-namespace-alias.md)

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../../language-reference/index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Namespace Keywords](namespace-keywords.md)
- [using](using-directive.md)
- [using static](using-static.md)