---
title: "How to: Overload a Procedure that Takes Optional Parameters (Visual Basic) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "procedures, parameters"
  - "procedure overloading, optional parameters"
  - "procedures, defining"
  - "Visual Basic code, procedures"
  - "procedure parameters"
  - "procedures, overloading"
  - "procedures, multiple versions"
ms.assetid: 825f9d56-4cde-43fd-993a-b9171717e2eb
caps.latest.revision: 17
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# How to: Overload a Procedure that Takes Optional Parameters (Visual Basic)
[!INCLUDE[vs2017banner](../../../../includes/vs2017banner.md)]

If a procedure has one or more [Optional](../../../../visual-basic/language-reference/modifiers/optional.md) parameters, you cannot define an overloaded version matching any of its implicit overloads. For more information, see "Implicit Overloads for Optional Parameters" in [Considerations in Overloading Procedures](../../../../visual-basic/programming-guide/language-features/procedures/considerations-in-overloading-procedures.md).  
  
## One Optional Parameter  
  
#### To overload a procedure that takes one optional parameter  
  
1.  Write a `Sub` or `Function` declaration statement that includes the optional parameter in the parameter list. Do not use the `Optional` keyword in this overloaded version.  
  
2.  Precede the `Sub` or `Function` keyword with the [Overloads](../../../../visual-basic/language-reference/modifiers/overloads.md) keyword.  
  
3.  Write the procedure code that should execute when the calling code supplies the optional argument.  
  
4.  Terminate the procedure with the `End Sub` or `End Function` statement as appropriate.  
  
5.  Write a second declaration statement that is identical to the first declaration except that it does not include the optional parameter in the parameter list.  
  
6.  Write the procedure code that should execute when the calling code does not supply the optional argument. Terminate the procedure with the `End Sub` or `End Function` statement as appropriate.  
  
     The following example shows a procedure defined with an optional parameter,  an equivalent set of two overloaded procedures, and finally examples of both invalid and valid overloaded versions.  
  
     [!code-vb[VbVbcnProcedures#59](../../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#59)]  
  
     [!code-vb[VbVbcnProcedures#60](../../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#60)]  
  
     [!code-vb[VbVbcnProcedures#61](../../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#61)]  
  
## Multiple Optional Parameters  
 For a procedure with more than one optional parameter, you normally need more than two overloaded versions. For example, if there are two optional parameters, and the calling code can supply or omit each one independently of the other, you need four overloaded versions, one for each possible combination of supplied arguments.  
  
 As the number of optional parameters increases, the complexity of the overloading increases. Unless some combinations of supplied arguments are not acceptable, for N optional parameters you need 2 ^ N overloaded versions. Depending on the nature of the procedure, you might find that the clarity of logic justifies the extra effort of defining all the overloaded versions.  
  
#### To overload a procedure that takes more than one optional parameter  
  
1.  Determine which combinations of supplied optional arguments are acceptable to the logic of the procedure. An unacceptable combination might arise if one optional parameter depends on another. For example, if one parameter accepts a spouse's name and another accepts the spouse's age, a combination of arguments supplying the age but omitting the name is unacceptable.  
  
2.  For each acceptable combination of supplied optional arguments, write a `Sub` or `Function` declaration statement that defines the corresponding parameter list. Do not use the `Optional` keyword.  
  
3.  In each declaration, precede the `Sub` or `Function` keyword with the [Overloads](../../../../visual-basic/language-reference/modifiers/overloads.md) keyword.  
  
4.  Following each declaration, write the procedure code that should execute when the calling code supplies an argument list corresponding to that declaration's parameter list.  
  
5.  Terminate each procedure with the `End Sub` or `End Function` statement as appropriate.  
  
## See Also  
 [Procedures](../../../../visual-basic/programming-guide/language-features/procedures/index.md)   
 [Procedure Parameters and Arguments](../../../../visual-basic/programming-guide/language-features/procedures/procedure-parameters-and-arguments.md)   
 [Optional Parameters](../../../../visual-basic/programming-guide/language-features/procedures/optional-parameters.md)   
 [Parameter Arrays](../../../../visual-basic/programming-guide/language-features/procedures/parameter-arrays.md)   
 [Procedure Overloading](../../../../visual-basic/programming-guide/language-features/procedures/procedure-overloading.md)   
 [Troubleshooting Procedures](../../../../visual-basic/programming-guide/language-features/procedures/troubleshooting-procedures.md)   
 [How to: Define Multiple Versions of a Procedure](../../../../visual-basic/programming-guide/language-features/procedures/how-to-define-multiple-versions-of-a-procedure.md)   
 [How to: Call an Overloaded Procedure](../../../../visual-basic/programming-guide/language-features/procedures/how-to-call-an-overloaded-procedure.md)   
 [How to: Overload a Procedure that Takes an Indefinite Number of Parameters](../../../../visual-basic/programming-guide/language-features/procedures/how-to-overload-a-procedure-that-takes-an-indefinite-number-of-parameters.md)   
 [Overload Resolution](../../../../visual-basic/programming-guide/language-features/procedures/overload-resolution.md)