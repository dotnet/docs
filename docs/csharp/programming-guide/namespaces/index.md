---
title: "Namespaces (C# Programming Guide)"
ms.date: 08/21/2018
helpviewer_keywords: 
  - "C# language, namespaces"
  - "namespaces [C#]"
ms.assetid: b1c4ab46-3fad-4ffa-9deb-dd50a2d8c65a
---
# Namespaces (C# Programming Guide)

Namespaces are heavily used in C# programming in two ways. First, the .NET Framework uses namespaces to organize its many classes, as follows:  
  
[!code-csharp[csProgGuide#22](../inside-a-program/codesnippet/CSharp/index_1.cs)]  
  
`System` is a namespace and `Console` is a class in that namespace. The `using` keyword can be used so that the complete name is not required, as in the following example:  
  
[!code-csharp[csProgGuide#1](../inside-a-program/codesnippet/CSharp/index_2.cs)]  
  
[!code-csharp[csProgGuide#25](../inside-a-program/codesnippet/CSharp/index_3.cs)]  
  
For more information, see the [using Directive](../../language-reference/keywords/using-directive.md).  
  
Second, declaring your own namespaces can help you control the scope of class and method names in larger programming projects. Use the [namespace](../../language-reference/keywords/namespace.md) keyword to declare a namespace, as in the following example:  
  
[!code-csharp[csProgGuideNamespaces#6](codesnippet/CSharp/index_4.cs)]

The name of the namespace must be a valid C# [identifier name](../inside-a-program/identifier-names.md).

## Namespaces Overview  

Namespaces have the following properties:  
  
- They organize large code projects.  
- They are delimited by using the `.` operator.  
- The `using` directive obviates the requirement to specify the name of the namespace for every class.  
- The `global` namespace is the "root" namespace: `global::System` will always refer to the .NET <xref:System> namespace.  

## C# Language Specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also

- [Using Namespaces](using-namespaces.md)
- [How to: Use the Global Namespace Alias](how-to-use-the-global-namespace-alias.md)
- [How to: Use the My Namespace](how-to-use-the-my-namespace.md)
- [C# Programming Guide](../index.md)  
- [Identifier names](../inside-a-program/identifier-names.md)
- [Namespace Keywords](../../language-reference/keywords/namespace-keywords.md)  
- [using Directive](../../language-reference/keywords/using-directive.md)  
- [:: Operator](../../language-reference/operators/namespace-alias-qualifer.md)  
- [. Operator](../../language-reference/operators/member-access-operator.md)
