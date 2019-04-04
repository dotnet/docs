---
title: "global contextual keyword - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "global"
  - "global_CSharpKeyword"
helpviewer_keywords: 
  - "global keyword [C#]"
ms.assetid: 8932c16a-6959-42c2-86e7-2c4221ab788b
---
# global (C# Reference)

The `global` contextual keyword, when it comes before the [:: operator](../operators/namespace-alias-qualifer.md), refers to the global namespace, which is the default namespace for any C# program and is otherwise unnamed. For more information, see [How to: Use the Global Namespace Alias](../../programming-guide/namespaces/how-to-use-the-global-namespace-alias.md).

## Example

The following example shows how to use the `global` contextual keyword to specify that the class `TestApp` is defined in the global namespace:

[!code-csharp[csrefKeywordsContextual#13](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsContextual/CS/csrefKeywordsContextual.cs#13)]

## See also

- [Namespaces](../../programming-guide/namespaces/index.md)