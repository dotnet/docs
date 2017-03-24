---
title: "Cannot convert anonymous type to expression tree because it contains a field that is used in the initialization of another field | Microsoft Docs"
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
  - "bc36548"
  - "vbc36548"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC36548"
ms.assetid: 27de068f-080e-4160-86bf-1ec23fd1925a
caps.latest.revision: 9
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Cannot convert anonymous type to expression tree because it contains a field that is used in the initialization of another field
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

The compiler does not accept conversion of an anonymous to an expression tree when one property of the anonymous type is used to initialize another property of the anonymous type. For example, in the following code, `Prop1` is declared in the initialization list and then used as the initial value for `Prop2`.  
  
```vb  
Module M2  
  
    Sub ExpressionExample(Of T)(ByVal x As Expressions.Expression(Of Func(Of T)))  
    End Sub  
  
    Sub Main()  
        ' The following line causes the error.  
        ' ExpressionExample(Function() New With {.Prop1 = 2, .Prop2 = .Prop1})  
  
    End Sub  
End Module  
```  
  
 **Error ID:** BC36548  
  
### To correct this error  
  
-   Assign the initial value for `Prop1` to a local variable. Assign that variable to both `Prop1` and `Prop2`, as shown in the following code.  
  
    ```  
    Sub Main()  
  
        Dim temp = 2  
        ExpressionExample(Function() New With {.Prop1 = temp, .Prop2 = temp})  
  
    End Sub  
    ```  
  
## See Also  
 [Anonymous Types](../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md)   
 [Expression Trees](../Topic/Expression%20Trees%20\(C%23%20and%20Visual%20Basic\).md)   
 [How to: Use Expression Trees to Build Dynamic Queries](../Topic/How%20to:%20Use%20Expression%20Trees%20to%20Build%20Dynamic%20Queries%20\(C%23%20and%20Visual%20Basic\).md)