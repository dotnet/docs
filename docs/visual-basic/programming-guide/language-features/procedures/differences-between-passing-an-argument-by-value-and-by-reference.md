---
title: "Differences Between Passing an Argument By Value and By Reference (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "ByRef keyword [Visual Basic], passing arguments by reference"
  - "Visual Basic code, procedures"
  - "procedures [Visual Basic], passing arguments"
  - "ByVal keyword [Visual Basic], passing arguments by value"
  - "arguments [Visual Basic], passing by value or by reference"
ms.assetid: 5f5c38fe-3e2d-494c-8fff-f4025b55ec93
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# Differences Between Passing an Argument By Value and By Reference (Visual Basic)
When you pass one or more arguments to a procedure, each argument corresponds to an underlying programming element in the calling code. You can pass either the value of this underlying element, or a reference to it. This is known as the *passing mechanism*.  
  
## Passing by Value  
 You pass an argument *by value* by specifying the [ByVal](../../../../visual-basic/language-reference/modifiers/byval.md) keyword for the corresponding parameter in the procedure definition. When you use this passing mechanism, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] copies the value of the underlying programming element into a local variable in the procedure. The procedure code does not have any access to the underlying element in the calling code.  
  
## Passing by Reference  
 You pass an argument *by reference* by specifying the [ByRef](../../../../visual-basic/language-reference/modifiers/byref.md) keyword for the corresponding parameter in the procedure definition. When you use this passing mechanism, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] gives the procedure a direct reference to the underlying programming element in the calling code.  
  
## Passing Mechanism and Element Type  
 The choice of passing mechanism is not the same as the classification of the underlying element type. Passing by value or by reference refers to what [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] supplies to the procedure code. A value type or reference type refers to how a programming element is stored in memory.  
  
 However, the passing mechanism and element type are interrelated. The value of a reference type is a pointer to the data elsewhere in memory. This means that when you pass a reference type by value, the procedure code has a pointer to the underlying element's data, even though it cannot access the underlying element itself. For example, if the element is an array variable, the procedure code does not have access to the variable itself, but it can access the array members.  
  
## Ability to Modify  
 When you pass a nonmodifiable element as an argument, the procedure can never modify it in the calling code, whether it is passed `ByVal` or `ByRef`.  
  
 For a modifiable element, the following table summarizes the interaction between the element type and the passing mechanism.  
  
|Element type|Passed `ByVal`|Passed `ByRef`|  
|------------------|--------------------|--------------------|  
|Value type (contains only a value)|The procedure cannot change the variable or any of its members.|The procedure can change the variable and its members.|  
|Reference type (contains a pointer to a class or structure instance)|The procedure cannot change the variable but can change members of the instance to which it points.|The procedure can change the variable and members of the instance to which it points.|  
  
## See Also  
 [Procedures](./index.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [How to: Pass Arguments to a Procedure](./how-to-pass-arguments-to-a-procedure.md)  
 [Passing Arguments by Value and by Reference](./passing-arguments-by-value-and-by-reference.md)  
 [Differences Between Modifiable and Nonmodifiable Arguments](./differences-between-modifiable-and-nonmodifiable-arguments.md)  
 [How to: Change the Value of a Procedure Argument](./how-to-change-the-value-of-a-procedure-argument.md)  
 [How to: Protect a Procedure Argument Against Value Changes](./how-to-protect-a-procedure-argument-against-value-changes.md)  
 [How to: Force an Argument to Be Passed by Value](./how-to-force-an-argument-to-be-passed-by-value.md)  
 [Passing Arguments by Position and by Name](./passing-arguments-by-position-and-by-name.md)  
 [Value Types and Reference Types](../../../../visual-basic/programming-guide/language-features/data-types/value-types-and-reference-types.md)
