---
title: "new Constraint (C# Reference) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "new constraint keyword [C#]"
ms.assetid: 58850b64-cb97-4136-be50-1f3bc7fc1da9
caps.latest.revision: 20
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# new Constraint (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The `new` constraint specifies that any type argument in a generic class declaration must have a public parameterless constructor. To use the new constraint, the type cannot be abstract.  
  
## Example  
 Apply the `new` constraint to a type parameter when your generic class creates new instances of the type, as shown in the following example:  
  
 [!code-csharp[csrefKeywordsOperator#5](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsOperator/CS/csrefKeywordsOperators.cs#5)]  
  
## Example  
 When you use the `new()` constraint with other constraints, it must be specified last:  
  
 [!code-csharp[csrefKeywordsOperator#6](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsOperator/CS/csrefKeywordsOperators.cs#6)]  
  
 For more information, see [Constraints on Type Parameters](../../../csharp/programming-guide/generics/constraints-on-type-parameters.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 <xref:System.Collections.Generic>   
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [Operator Keywords](../../../csharp/language-reference/keywords/operator-keywords.md)   
 [Generics](../../../csharp/programming-guide/generics/index.md)