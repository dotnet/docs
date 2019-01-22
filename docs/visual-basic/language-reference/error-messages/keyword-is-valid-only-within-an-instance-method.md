---
title: "&#39;&lt;keyword&gt;&#39; is valid only within an instance method"
ms.date: 07/20/2015
f1_keywords: 
  - "bc30043"
  - "vbc30043"
helpviewer_keywords: 
  - "BC30043"
ms.assetid: 7973aa82-a681-440c-9bca-242627d7ba86
---
# &#39;&lt;keyword&gt;&#39; is valid only within an instance method
The `Me`, `MyClass`, and `MyBase` keywords refer to specific class instances. You cannot use them inside a shared `Function` or `Sub` procedure.  
  
 **Error ID:** BC30043  
  
## To correct this error  
  
-   Remove the keyword from the procedure, or remove the `Shared` keyword from the procedure declaration.  
  
## See also
 [Object Variable Assignment](../../../visual-basic/programming-guide/language-features/variables/object-variable-assignment.md)  
 [Me, My, MyBase, and MyClass](../../../visual-basic/programming-guide/program-structure/me-my-mybase-and-myclass.md)  
 [Inheritance Basics](../../../visual-basic/programming-guide/language-features/objects-and-classes/inheritance-basics.md)
