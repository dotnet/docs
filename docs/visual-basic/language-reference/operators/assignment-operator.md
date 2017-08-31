---
title: "= Operator (Visual Basic) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "vb.Assign"
  - "vb.="
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "= operator [Visual Basic]"
  - "= assignment statements [Visual Basic]"
ms.assetid: 2dac2e49-86c8-42f8-80c1-458452fb5e29
caps.latest.revision: 16
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# = Operator (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Assigns a value to a variable or property.  
  
## Syntax  
  
```  
  
variableorproperty = value  
```  
  
## Parts  
 `variableorproperty`  
 Any writable variable or any property.  
  
 `value`  
 Any literal, constant, or expression.  
  
## Remarks  
 The element on the left side of the equal sign (`=`) can be a simple scalar variable, a property, or an element of an array. The variable or property cannot be [ReadOnly](../../../visual-basic/language-reference/modifiers/readonly.md). The `=` operator assigns the value on its right to the variable or property on its left.  
  
> [!NOTE]
>  The `=` operator is also used as a comparison operator. For details, see [Comparison Operators](../../../visual-basic/language-reference/operators/comparison-operators.md).  
  
## Overloading  
 The `=` operator can be overloaded only as a relational comparison operator, not as an assignment operator. For more information, see [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  
 The following example demonstrates the assignment operator. The value on the right is assigned to the variable on the left.  
  
 [!code-vb[VbVbalrOperators#9](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#9)]  
  
## See Also  
 [&= Operator](../../../visual-basic/language-reference/operators/and-assignment-operator.md)   
 [*= Operator](../../../visual-basic/language-reference/operators/multiplication-assignment-operator.md)   
 [+= Operator](../../../visual-basic/language-reference/operators/addition-assignment-operator.md)   
 [-= Operator (Visual Basic)](../../../visual-basic/language-reference/operators/operator-visual-basic.md)   
 [/= Operator (Visual Basic)](../../../visual-basic/language-reference/operators/operator-visual-basic.md)   
 [\\= Operator](../../../visual-basic/language-reference/operators/operator.md)   
 [^= Operator](../../../visual-basic/language-reference/operators/exponentiation-assignment-operator.md)   
 [Statements](../../../visual-basic/programming-guide/language-features/statements.md)   
 [Comparison Operators](../../../visual-basic/language-reference/operators/comparison-operators.md)   
 [ReadOnly](../../../visual-basic/language-reference/modifiers/readonly.md)   
 [Local Type Inference](../../../visual-basic/programming-guide/language-features/variables/local-type-inference.md)