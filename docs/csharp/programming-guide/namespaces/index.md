---
title: "Namespaces - C# Programming Guide"
ms.custom: seodec18
ms.date: 08/21/2018
helpviewer_keywords: 
  - "C# language, namespaces"
  - "namespaces [C#]"
ms.assetid: b1c4ab46-3fad-4ffa-9deb-dd50a2d8c65a
---
# Namespaces (C# Programming Guide)

Namespaces are heavily used in C# programming in two ways. First, the .NET Framework uses namespaces to organize its many classes, as follows:  
  
 [!code-csharp[csProgGuide#22](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuide/CS/progGuide.cs#22)]  
  
`System` is a namespace and `Console` is a class in that namespace. The `using` keyword can be used so that the complete name is not required, as in the following example:  
  
 [!code-csharp[csProgGuide#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuide/CS/using.cs#1)]  
  
 [!code-csharp[csProgGuide#25](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuide/CS/progGuide.cs#25)]  
  
For more information, see the [using Directive](../../language-reference/keywords/using-directive.md).  
  
Second, declaring your own namespaces can help you control the scope of class and method names in larger programming projects. Use the [namespace](../../language-reference/keywords/namespace.md) keyword to declare a namespace, as in the following example:  
  
 [!code-csharp[csProgGuideNamespaces#6](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideNamespaces/CS/Namespaces.cs#6)]

The name of the namespace must be a valid C# [identifier name](../inside-a-program/identifier-names.md).

## Namespaces Overview  

Namespaces have the following properties:  
  
- They organize large code projects.  
- They are delimited by using the `.` operator.  
- The `using` directive obviates the requirement to specify the name of the namespace for every class.  
- The `global` namespace is the "root" namespace: `global::System` will always refer to the .NET <xref:System> namespace.  

## C# language specification

For more information, see the [Namespaces](~/_csharplang/spec/namespaces.md) section of the [C# language specification](~/_csharplang/spec/introduction.md).
  
## See also

- [C# Programming Guide](../index.md)
- [Using Namespaces](using-namespaces.md)
- [How to: Use the My Namespace](how-to-use-the-my-namespace.md)
- [Identifier names](../inside-a-program/identifier-names.md)
- [using Directive](../../language-reference/keywords/using-directive.md)
- [:: Operator](../../language-reference/operators/namespace-alias-qualifier.md)
