---
title: "New Operator (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.new"
  - "vb.NewConstraint"
helpviewer_keywords: 
  - "constraints, Visual Basic generic types"
  - "generics [Visual Basic], constraints"
  - "constraints, New keyword [Visual Basic]"
  - "New constraint"
  - "New keyword [Visual Basic]"
ms.assetid: d7d566d7-fe0e-4336-91f7-641a542de4d0
caps.latest.revision: 23
author: dotnet-bot
ms.author: dotnetcontent
---
# New Operator (Visual Basic)
Introduces a `New` clause to create a new object instance, specifies a constructor constraint on a type parameter, or identifies a `Sub` procedure as a class constructor.  
  
## Remarks  
 In a declaration or assignment statement, a `New` clause must specify a defined class from which the instance can be created. This means that the class must expose one or more constructors that the calling code can access.  
  
 You can use a `New` clause in a declaration statement or an assignment statement. When the statement runs, it calls the appropriate constructor of the specified class, passing any arguments you have supplied. The following example demonstrates this by creating instances of a `Customer` class that has two constructors, one that takes no parameters and one that takes a string parameter.  
  
 [!code-vb[VbVbalrKeywords#11](../../../visual-basic/language-reference/codesnippet/VisualBasic/new-operator_1.vb)]  
  
 Since arrays are classes, `New` can create a new array instance, as shown in the following examples.  
  
 [!code-vb[VbVbalrKeywords#12](../../../visual-basic/language-reference/codesnippet/VisualBasic/new-operator_2.vb)]  
  
 The common language runtime (CLR) throws an <xref:System.OutOfMemoryException> error if there is insufficient memory to create the new instance.  
  
> [!NOTE]
>  The `New` keyword is also used in type parameter lists to specify that the supplied type must expose an accessible parameterless constructor. For more information about type parameters and constraints, see [Type List](../../../visual-basic/language-reference/statements/type-list.md).  
  
 To create a constructor procedure for a class, set the name of a `Sub` procedure to the `New` keyword. For more information, see [Object Lifetime: How Objects Are Created and Destroyed](../../../visual-basic/programming-guide/language-features/objects-and-classes/object-lifetime-how-objects-are-created-and-destroyed.md).  
  
 The `New` keyword can be used in these contexts:  
  
 [Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md)  
  
 [Of](../../../visual-basic/language-reference/statements/of-clause.md)  
  
 [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)  
  
## See Also  
 <xref:System.OutOfMemoryException>  
 [Keywords](../../../visual-basic/language-reference/keywords/index.md)  
 [Type List](../../../visual-basic/language-reference/statements/type-list.md)  
 [Generic Types in Visual Basic](../../../visual-basic/programming-guide/language-features/data-types/generic-types.md)  
 [Object Lifetime: How Objects Are Created and Destroyed](../../../visual-basic/programming-guide/language-features/objects-and-classes/object-lifetime-how-objects-are-created-and-destroyed.md)
