---
title: "Declared Element Characteristics (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "declared elements [Visual Basic], lifetime"
  - "access levels, declared elements"
  - "declared elements [Visual Basic], scope"
  - "visibility [Visual Basic], declared elements"
  - "elements [Visual Basic], programming"
  - "scope [Visual Basic], declared elements"
  - "lifetime [Visual Basic], declared elements"
  - "declared elements [Visual Basic], access level"
  - "data types [Visual Basic], declared elements"
  - "declared elements [Visual Basic], visibility"
ms.assetid: 1bc40fb8-b67c-4428-90a4-76b630ae2583
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# Declared Element Characteristics (Visual Basic)
A *characteristic* of a declared element is an aspect of that element that affects how code can interact with it. Every declared element has one or more of the following characteristics associated with it:  
  
-   *Data type* — the values the element can hold, and how it stores those values. For more information, see [Data Types](../../../../visual-basic/language-reference/data-types/data-type-summary.md).  
  
-   *Lifetime* — the period of execution time during which the element is available for use. For more information, see [Lifetime in Visual Basic](../../../../visual-basic/programming-guide/language-features/declared-elements/lifetime.md).  
  
-   *Scope* — the set of all code that can refer to the element without qualifying its name. For more information, see [How to: Control the Scope of a Variable](../../../../visual-basic/programming-guide/language-features/declared-elements/how-to-control-the-scope-of-a-variable.md).  
  
-   *Access level* — the permission for code to make use of the element. For more information, see [How to: Control the Availability of a Variable](../../../../visual-basic/programming-guide/language-features/declared-elements/how-to-control-the-availability-of-a-variable.md).  
  
## Characteristics of the Elements  
 The following table shows the declared elements and the characteristics that apply to each one.  
  
|Element|Data Type|Lifetime|Scope <sup>1</sup>|Access Level|  
|-------------|---------------|--------------|------------------------|------------------|  
|Variable|Yes|Yes|Yes|Yes|  
|Constant|Yes|No|Yes|Yes|  
|Enumeration|Yes|No|Yes|Yes|  
|Structure|No|No|Yes|Yes|  
|Property|Yes|Yes|Yes|Yes|  
|Method|No|Yes|Yes|Yes|  
|Procedure (`Sub` or `Function`)|No|Yes|Yes|Yes|  
|Procedure parameter|Yes|Yes|Yes|No|  
|Function return|Yes|Yes|Yes|No|  
|Operator|Yes|No|Yes|Yes|  
|Interface|No|No|Yes|Yes|  
|Class|No|No|Yes|Yes|  
|Event|No|No|Yes|Yes|  
|Delegate|No|No|Yes|Yes|  
  
 <sup>1</sup> Scope is sometimes referred to as *visibility*.  
  
## See Also  
 [Declared Elements](../../../../visual-basic/programming-guide/language-features/declared-elements/index.md)  
 [Declared Element Names](../../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md)  
 [References to Declared Elements](../../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md)  
 [Lifetime in Visual Basic](../../../../visual-basic/programming-guide/language-features/declared-elements/lifetime.md)  
 [Scope in Visual Basic](../../../../visual-basic/programming-guide/language-features/declared-elements/scope.md)  
 [Access levels in Visual Basic](../../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md)  
 [Data Types](../../../../visual-basic/programming-guide/language-features/data-types/index.md)  
 [Variable Declaration](../../../../visual-basic/programming-guide/language-features/variables/variable-declaration.md)
