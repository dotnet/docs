---
title: "Early and Late Binding (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "early binding [Visual Basic]"
  - "objects [Visual Basic], late-bound"
  - "objects [Visual Basic], early-bound"
  - "objects [Visual Basic], late bound"
  - "early binding [Visual Basic], Visual Basic compiler"
  - "binding [Visual Basic], late and early"
  - "objects [Visual Basic], early bound"
  - "Visual Basic compiler, early and late binding"
  - "late binding [Visual Basic]"
  - "late binding [Visual Basic], Visual Basic compiler"
ms.assetid: d6ff7f1e-b94f-4205-ab8d-5cfa91758724
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# Early and Late Binding (Visual Basic)
The [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler performs a process called `binding` when an object is assigned to an object variable. An object is *early bound* when it is assigned to a variable declared to be of a specific object type. Early bound objects allow the compiler to allocate memory and perform other optimizations before an application executes. For example, the following code fragment declares a variable to be of type <xref:System.IO.FileStream>:  
  
 [!code-vb[VbVbalrOOP#90](../../../../visual-basic/misc/codesnippet/VisualBasic/early-and-late-binding_1.vb)]  
  
 Because <xref:System.IO.FileStream> is a specific object type, the instance assigned to `FS` is early bound.  
  
 By contrast, an object is *late bound* when it is assigned to a variable declared to be of type `Object`. Objects of this type can hold references to any object, but lack many of the advantages of early-bound objects. For example, the following code fragment declares an object variable to hold an object returned by the `CreateObject` function:  
  
 [!code-vb[VbVbalrOOP#91](../../../../visual-basic/misc/codesnippet/VisualBasic/early-and-late-binding_2.vb)]  
  
## Advantages of Early Binding  
 You should use early-bound objects whenever possible, because they allow the compiler to make important optimizations that yield more efficient applications. Early-bound objects are significantly faster than late-bound objects and make your code easier to read and maintain by stating exactly what kind of objects are being used. Another advantage to early binding is that it enables useful features such as automatic code completion and Dynamic Help because the [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] integrated development environment (IDE) can determine exactly what type of object you are working with as you edit the code. Early binding reduces the number and severity of run-time errors because it allows the compiler to report errors when a program is compiled.  
  
> [!NOTE]
>  Late binding can only be used to access type members that are declared as `Public`. Accessing members declared as `Friend` or `Protected Friend` results in a run-time error.  
  
## See Also  
 <xref:Microsoft.VisualBasic.Interaction.CreateObject%2A>  
 [Object Lifetime: How Objects Are Created and Destroyed](../../../../visual-basic/programming-guide/language-features/objects-and-classes/object-lifetime-how-objects-are-created-and-destroyed.md)  
 [Object Data Type](../../../../visual-basic/language-reference/data-types/object-data-type.md)
