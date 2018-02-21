---
title: ":: Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "::_CSharpKeyword"
helpviewer_keywords: 
  - ":: operator [C#]"
  - "namespaces [C#], :: operator"
  - "namespace alias qualifier operator (::) [C#]"
ms.assetid: 698b5a73-85cf-4e0e-9e8e-6496887f8527
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"
---
# :: Operator (C# Reference)
The namespace alias qualifier (`::`) is used to look up identifiers. It is always positioned between two identifiers, as in this example:  
  
 [!code-csharp[csRefOperators#27](../../../csharp/language-reference/operators/codesnippet/CSharp/namespace-alias-qualifer_1.cs)]  
  
## Remarks  
 The namespace alias qualifier can be `global`. This invokes a lookup in the global namespace, rather than an aliased namespace.  
  
## For More Information  
 For an example of how to use the `::` operator, see the following section:  
  
-   [How to: Use the Global Namespace Alias](../../../csharp/programming-guide/namespaces/how-to-use-the-global-namespace-alias.md)  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)  
 [Namespace Keywords](../../../csharp/language-reference/keywords/namespace-keywords.md)  
 [. Operator](../../../csharp/language-reference/operators/member-access-operator.md)  
 [extern alias](../../../csharp/language-reference/keywords/extern-alias.md)
