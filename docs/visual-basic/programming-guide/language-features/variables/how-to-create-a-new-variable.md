---
title: "How to: Create a New Variable (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Dim statement [Visual Basic]"
  - "variables [Visual Basic], creating"
ms.assetid: 35300be3-77b0-4bef-a156-034d3cdedde0
caps.latest.revision: 29
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Create a New Variable (Visual Basic)
You create a variable with a [Dim Statement](../../../../visual-basic/language-reference/statements/dim-statement.md).  
  
### To create a new variable  
  
1.  Declare the variable in a `Dim` statement.  
  
    ```  
    Dim newCustomer  
    ```  
  
2.  Include specifications for the variable's characteristics, such as [Private](../../../../visual-basic/language-reference/modifiers/private.md), [Static](../../../../visual-basic/language-reference/modifiers/static.md), [Shadows](../../../../visual-basic/language-reference/modifiers/shadows.md), or [WithEvents](../../../../visual-basic/language-reference/modifiers/withevents.md). For more information, see [Declared Element Characteristics](../../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-characteristics.md).  
  
    ```  
    Public Static newCustomer  
    ```  
  
     You do not need the `Dim` keyword if you use other keywords in the declaration.  
  
3.  Follow the specifications with the variable's name, which must follow [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] rules and conventions. For more information, see [Declared Element Names](../../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md).  
  
    ```  
    Public Static newCustomer  
    ```  
  
4.  Follow the name with the [As](../../../../visual-basic/language-reference/statements/as-clause.md) clause to specify the variable's data type.  
  
    ```  
    Public Static newCustomer As Customer  
    ```  
  
     If you do not specify the data type, it uses the default: `Object`.  
  
5.  Follow the `As` clause with an equal sign (`=`) and follow the equal sign with the variable's initial value.  
  
     [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] assigns the specified value to the variable every time it runs the `Dim` statement. If you do not specify an initial value, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] assigns the default initial value for the variable's data type when it first enters the code that contains the `Dim` statement.  
  
     If the variable is a reference type, you can create an instance of its class by including the [New Operator](../../../../visual-basic/language-reference/operators/new-operator.md) keyword in the `As` clause. If you do not use `New`, the initial value of the variable is [Nothing](../../../../visual-basic/language-reference/nothing.md).  
  
    ```  
    Public Static newCustomer As New Customer  
    ```  
  
## See Also  
 [Variables](../../../../visual-basic/programming-guide/language-features/variables/index.md)  
 [Variable Declaration](../../../../visual-basic/programming-guide/language-features/variables/variable-declaration.md)  
 [Declared Element Names](../../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md)  
 [Declared Element Characteristics](../../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-characteristics.md)  
 [Value Types and Reference Types](../../../../visual-basic/programming-guide/language-features/data-types/value-types-and-reference-types.md)  
 [Statements](../../../../visual-basic/language-reference/statements/index.md)  
 [Local Type Inference](../../../../visual-basic/programming-guide/language-features/variables/local-type-inference.md)  
 [Option Infer Statement](../../../../visual-basic/language-reference/statements/option-infer-statement.md)
