---
title: "new Constraint (C# Reference)"
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
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# new Constraint (C# Reference)
The `new` constraint specifies that any type argument in a generic class declaration must have a public parameterless constructor. To use the new constraint, the type cannot be abstract.  
  
## Example  
 Apply the `new` constraint to a type parameter when your generic class creates new instances of the type, as shown in the following example:  
  
 [!code[csrefKeywordsOperator#5](../keywords/codesnippet/CSharp/new-constraint--csharp-reference-_1.cs)]  
  
## Example  
 When you use the `new()` constraint with other constraints, it must be specified last:  
  
 [!code[csrefKeywordsOperator#6](../keywords/codesnippet/CSharp/new-constraint--csharp-reference-_2.cs)]  
  
 For more information, see [Constraints on Type Parameters](../generics/constraints-on-type-parameters--csharp-programming-guide-.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 <xref:System.Collections.Generic>   
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Operator Keywords](../keywords/operator-keywords--csharp-reference-.md)   
 [Generics](../generics/generics--csharp-programming-guide-.md)