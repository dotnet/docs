---
title: "Out (Generic Modifier) (Visual Basic) | Microsoft Docs"
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
  - "vb.VarianceOut"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "Out keyword [Visual Basic]"
  - "covariance, Out keyword [Visual Basic]"
ms.assetid: c4418369-1518-4a46-9a1e-054c61038eca
caps.latest.revision: 14
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Out (Generic Modifier) (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

For generic type parameters, the `Out` keyword specifies that the type is covariant.  
  
## Remarks  
 Covariance enables you to use a more derived type than that specified by the generic parameter. This allows for implicit conversion of classes that implement variant interfaces and implicit conversion of delegate types.  
  
 For more information, see [Covariance and Contravariance](../Topic/Covariance%20and%20Contravariance%20\(C%23%20and%20Visual%20Basic\).md).  
  
## Rules  
 You can use the `Out` keyword in generic interfaces and delegates.  
  
 In a generic interface, a type parameter can be declared covariant if it satisfies the following conditions:  
  
-   The type parameter is used only as a return type of interface methods and not used as a type of method arguments.  
  
    > [!NOTE]
    >  There is one exception to this rule. If in a covariant interface you have a contravariant generic delegate as a method parameter, you can use the covariant type as a generic type parameter for this delegate. For more information about covariant and contravariant generic delegates, see [Variance in Delegates](../Topic/Variance%20in%20Delegates%20\(C%23%20and%20Visual%20Basic\).md) and [Using Variance for Func and Action Generic Delegates](../Topic/Using%20Variance%20for%20Func%20and%20Action%20Generic%20Delegates%20\(C%23%20and%20Visual%20Basic\).md).  
  
-   The type parameter is not used as a generic constraint for the interface methods.  
  
 In a generic delegate, a type parameter can be declared covariant if it is used only as a method return type and not used for method arguments.  
  
 Covariance and contravariance are supported for reference types, but they are not supported for value types.  
  
 In Visual Basic, you cannot declare events in covariant interfaces without specifying the delegate type. Also, covariant interfaces cannot have nested classes, enums, or structures, but they can have nested interfaces.  
  
## Behavior  
 An interface that has a covariant type parameter enables its methods to return more derived types than those specified by the type parameter. For example, because in .NET Framework 4, in <xref:System.Collections.Generic.IEnumerable%601>, type T is covariant, you can assign an object of the `IEnumerabe(Of String)` type to an object of the `IEnumerable(Of Object)` type without using any special conversion methods.  
  
 A covariant delegate can be assigned another delegate of the same type, but with a more derived generic type parameter.  
  
## Example  
 The following example shows how to declare, extend, and implement a covariant generic interface. It also shows how to use implicit conversion for classes that implement a covariant interface.  
  
 [!code-vb[vbVarianceKeywords#3](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvariancekeywords/vb/module1.vb#3)]  
  
## Example  
 The following example shows how to declare, instantiate, and invoke a covariant generic delegate. It also shows how you can use implicit conversion for delegate types.  
  
 [!code-vb[vbVarianceKeywords#4](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvariancekeywords/vb/module1.vb#4)]  
  
## See Also  
 [Variance in Generic Interfaces](../Topic/Variance%20in%20Generic%20Interfaces%20\(C%23%20and%20Visual%20Basic\).md)   
 [In](../../../visual-basic/language-reference/modifiers/in-generic-modifier.md)