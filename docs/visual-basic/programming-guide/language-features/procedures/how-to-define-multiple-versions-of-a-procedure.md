---
title: "How to: Define Multiple Versions of a Procedure (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "procedures [Visual Basic], defining"
  - "Visual Basic code, procedures"
  - "procedures [Visual Basic], overloading"
  - "procedures [Visual Basic], multiple versions"
  - "procedure overloading [Visual Basic], multiple versions"
ms.assetid: 71ccdd66-1b00-4b66-bee4-6926c0d696f4
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Define Multiple Versions of a Procedure (Visual Basic)
You can define a procedure in multiple versions by *overloading* it, using the same name but a different parameter list for each version. The purpose of overloading is to define several closely related versions of a procedure without having to differentiate them by name.  
  
 For more information, see [Procedure Overloading](./procedure-overloading.md).  
  
### To define multiple versions of a procedure  
  
1.  Write a `Sub` or `Function` declaration statement for each version of the procedure you want to define. Use the same procedure name in every declaration.  
  
2.  Precede the `Sub` or `Function` keyword in each declaration with the [Overloads](../../../../visual-basic/language-reference/modifiers/overloads.md) keyword. You can optionally omit `Overloads` in the declarations, but if you include it in any of the declarations, you must include it in every declaration.  
  
3.  Following each declaration statement, write procedure code to handle the specific case where the calling code supplies arguments matching that version's parameter list. You do not have to test for which parameters the calling code has supplied. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] passes control to the matching version of your procedure.  
  
4.  Terminate each version of the procedure with the `End Sub` or `End Function` statement as appropriate.  
  
## Example  
 The following example defines a `Sub` procedure to post a transaction against a customer's balance. It uses the `Overloads` keyword to define two versions of the procedure, one that accepts the customer by name and the other by account number.  
  
 [!code-vb[VbVbcnProcedures#72](./codesnippet/VisualBasic/how-to-define-multiple-versions-of-a-procedure_1.vb)]  
  
 The calling code can obtain the customer identification as either a `String` or an `Integer`, and then use the same calling statement in either case.  
  
 For information on how to call these versions of the `post` procedure, see [How to: Call an Overloaded Procedure](./how-to-call-an-overloaded-procedure.md).  
  
## Compiling the Code  
 Make sure each of your overloaded versions has the same procedure name but a different parameter list.  
  
## See Also  
 [Procedures](./index.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [Troubleshooting Procedures](./troubleshooting-procedures.md)  
 [How to: Overload a Procedure that Takes Optional Parameters](./how-to-overload-a-procedure-that-takes-optional-parameters.md)  
 [How to: Overload a Procedure that Takes an Indefinite Number of Parameters](./how-to-overload-a-procedure-that-takes-an-indefinite-number-of-parameters.md)  
 [Considerations in Overloading Procedures](./considerations-in-overloading-procedures.md)  
 [Overload Resolution](./overload-resolution.md)
