---
description: "Learn more about: Declared Element Characteristics (Visual Basic)"
title: "Declared Element Characteristics"
ms.date: 07/20/2015
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
---
# Declared Element Characteristics (Visual Basic)

A *characteristic* of a declared element is an aspect of that element that affects how code can interact with it. Every declared element has one or more of the following characteristics associated with it:  
  
- *Data type* — the values the element can hold, and how it stores those values. For more information, see [Data Types](../../../language-reference/data-types/index.md).  
  
- *Lifetime* — the period of execution time during which the element is available for use. For more information, see [Lifetime in Visual Basic](lifetime.md).  
  
- *Scope* — the set of all code that can refer to the element without qualifying its name. For more information, see [How to: Control the Scope of a Variable](how-to-control-the-scope-of-a-variable.md).  
  
- *Access level* — the permission for code to make use of the element. For more information, see [How to: Control the Availability of a Variable](how-to-control-the-availability-of-a-variable.md).  
  
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
  
## See also

- [Declared Elements](index.md)
- [Declared Element Names](declared-element-names.md)
- [References to Declared Elements](references-to-declared-elements.md)
- [Lifetime in Visual Basic](lifetime.md)
- [Scope in Visual Basic](scope.md)
- [Access levels in Visual Basic](access-levels.md)
- [Data Types](../data-types/index.md)
- [Variable Declaration](../variables/variable-declaration.md)
