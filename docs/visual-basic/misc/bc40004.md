---
title: "<type1> '<membername>' conflicts with <type2> '<membername>' on the base class <type3> '<classname>' and should be declared 'Shadows'"
ms.date: 07/20/2015
f1_keywords: 
  - "bc40004"
  - "vbc40004"
helpviewer_keywords: 
  - "BC40004"
ms.assetid: 24d10f31-3b3d-448c-b928-fc937e1f4a92
---
# \<type1> '\<membername>' conflicts with \<type2> '\<membername>' on the base class \<type3> '\<classname>' and should be declared 'Shadows'
A programming element is declared with the same name as an element defined in the base class. In this situation, the element in this class should shadow the base class element.  
  
 This message is a warning. `Shadows` is assumed by default. For more information about hiding warnings or treating warnings as errors, please see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).  
  
 **Error ID:** BC40004  
  
## To correct this error  
  
-   Add the `Shadows` keyword to the declaration, or change the name of the element being declared.  
  
## See also

- [Shadows](../../visual-basic/language-reference/modifiers/shadows.md)
- [Shadowing in Visual Basic](../../visual-basic/programming-guide/language-features/declared-elements/shadowing.md)
