---
title: "?: Operator (C# Reference) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "?:_CSharpKeyword"
  - "?_CSharpKeyword"
  - ":_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "?: operator [C#]"
  - "conditional operator (?:) [C#]"
ms.assetid: e83a17f1-7500-48ba-8bee-2fbc4c847af4
caps.latest.revision: 23
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# ?: Operator (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The conditional operator (`?:`) returns one of two values depending on the value of a Boolean expression. Following is the syntax for the conditional operator.  
  
```  
condition ? first_expression : second_expression;  
```  
  
## Remarks  
 The `condition` must evaluate to `true` or `false`. If `condition` is `true`, `first_expression` is evaluated and becomes the result. If `condition` is `false`, `second_expression` is evaluated and becomes the result. Only one of the two expressions is evaluated.  
  
 Either the type of `first_expression` and `second_expression` must be the same, or an implicit conversion must exist from one type to the other.  
  
 You can express calculations that might otherwise require an `if-else` construction more concisely by using the conditional operator. For example, the following code uses first an `if` statement and then a conditional operator to classify an integer as positive or negative.  
  
```  
  
int input = Convert.ToInt32(Console.ReadLine());  
string classify;  
  
// if-else construction.  
if (input > 0)  
    classify = "positive";  
else  
    classify = "negative";  
  
// ?: conditional operator.  
classify = (input > 0) ? "positive" : "negative";  
  
```  
  
 The conditional operator is right-associative. The expression `a ? b : c ? d : e` is evaluated as `a ? b : (c ? d : e)`, not as `(a ? b : c) ? d : e`.  
  
 The conditional operator cannot be overloaded.  
  
## Example  
 [!code-csharp[csRefOperators#41](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#41)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Operators](../../../csharp/language-reference/operators/index.md)   
 [if-else](../../../csharp/language-reference/keywords/if-else.md)   
 [?. and ?Operators](../../../csharp/language-reference/operators/null-conditional-operators.md)   
 [?? Operator](../../../csharp/language-reference/operators/null-conditional-operator.md)