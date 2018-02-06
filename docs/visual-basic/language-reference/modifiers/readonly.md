---
title: "ReadOnly (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.ReadOnly"
helpviewer_keywords: 
  - "ReadOnly keyword [Visual Basic]"
  - "variables [Visual Basic], read-only"
  - "ReadOnly property"
  - "properties [Visual Basic], read-only"
  - "read-only variables"
ms.assetid: e868185d-6142-4359-a2fd-a7965cadfce8
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# ReadOnly (Visual Basic)
Specifies that a variable or property can be read but not written.  
  
## Remarks  
  
## Rules  
  
-   **Declaration Context.** You can use `ReadOnly` only at module level. This means the declaration context for a `ReadOnly` element must be a class, structure, or module, and cannot be a source file, namespace, or procedure.  
  
-   **Combined Modifiers.** You cannot specify `ReadOnly` together with `Static` in the same declaration.  
  
-   **Assigning a Value.** Code consuming a `ReadOnly` property cannot set its value. But code that has access to the underlying storage can assign or change the value at any time.  
  
     You can assign a value to a `ReadOnly` variable only in its declaration or in the constructor of a class or structure in which it is defined.  
  
## When to Use a ReadOnly Variable  
 There are situations in which you cannot use a [Const Statement](../../../visual-basic/language-reference/statements/const-statement.md) to declare and assign a constant value. For example, the `Const` statement might not accept the data type you want to assign, or you might not be able to compute the value at compile time with a constant expression. You might not even know the value at compile time. In these cases, you can use a `ReadOnly` variable to hold a constant value.  
  
> [!IMPORTANT]
>  If the data type of the variable is a reference type, such as an array or a class instance, its members can be changed even if the variable itself is `ReadOnly`. The following example illustrates this.  
  
 `ReadOnly characterArray() As Char = {"x"c, "y"c, "z"c}`  
  
 `Sub changeArrayElement()`  
  
 `characterArray(1) = "M"c`  
  
 `End Sub`  
  
 When initialized, the array pointed to by `characterArray()` holds "x", "y", and "z". Because the variable `characterArray` is `ReadOnly`, you cannot change its value once it is initialized; that is, you cannot assign a new array to it. However, you can change the values of one or more of the array members. Following a call to the procedure `changeArrayElement`, the array pointed to by `characterArray()` holds "x", "M", and "z".  
  
 Note that this is similar to declaring a procedure parameter to be [ByVal](../../../visual-basic/language-reference/modifiers/byval.md), which prevents the procedure from changing the calling argument itself but allows it to change its members.  
  
## Example  
 The following example defines a `ReadOnly` property for the date on which an employee was hired. The class stores the property value internally as a `Private` variable, and only code inside the class can change that value. However, the property is `Public`, and any code that can access the class can read the property.  
  
 [!code-vb[VbVbalrKeywords#4](../../../visual-basic/language-reference/codesnippet/VisualBasic/readonly_1.vb)]  
  
 The `ReadOnly` modifier can be used in these contexts:  
  
 [Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md)  
  
 [Property Statement](../../../visual-basic/language-reference/statements/property-statement.md)  
  
## See Also  
 [WriteOnly](../../../visual-basic/language-reference/modifiers/writeonly.md)  
 [Keywords](../../../visual-basic/language-reference/keywords/index.md)
