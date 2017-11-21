---
title: "How to: Overload a Procedure that Takes an Indefinite Number of Parameters (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "procedures [Visual Basic], parameters"
  - "procedure overloading [Visual Basic], indefinite number of parameters"
  - "procedures [Visual Basic], defining"
  - "Visual Basic code, procedures"
  - "procedure parameters"
  - "procedures [Visual Basic], overloading"
  - "procedures [Visual Basic], multiple versions"
ms.assetid: c7042de2-2422-4039-94e8-ac298896af69
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Overload a Procedure that Takes an Indefinite Number of Parameters (Visual Basic)
If a procedure has a [ParamArray](../../../../visual-basic/language-reference/modifiers/paramarray.md) parameter, you cannot define an overloaded version taking a one-dimensional array for the parameter array. For more information, see "Implicit Overloads for a ParamArray Parameter" in [Considerations in Overloading Procedures](./considerations-in-overloading-procedures.md).  
  
### To overload a procedure that takes a variable number of parameters  
  
1.  Ascertain that the procedure and calling code logic benefits from overloaded versions more than from a `ParamArray` parameter. See "Overloads and ParamArrays" in [Considerations in Overloading Procedures](./considerations-in-overloading-procedures.md).  
  
2.  Determine which numbers of supplied values the procedure should accept in the variable part of the parameter list. This might include the case of no value, and it might include the case of a single one-dimensional array.  
  
3.  For each acceptable number of supplied values, write a `Sub` or `Function` declaration statement that defines the corresponding parameter list. Do not use either the `Optional` or the `ParamArray` keyword in this overloaded version.  
  
4.  In each declaration, precede the `Sub` or `Function` keyword with the [Overloads](../../../../visual-basic/language-reference/modifiers/overloads.md) keyword.  
  
5.  Following each declaration, write the procedure code that should execute when the calling code supplies values corresponding to that declaration's parameter list.  
  
6.  Terminate each procedure with the `End Sub` or `End Function` statement as appropriate.  
  
## Example  
 The following example shows a procedure defined with a [ParamArray](../../../../visual-basic/language-reference/modifiers/paramarray.md) parameter, and then an equivalent set of overloaded procedures.  
  
 [!code-vb[VbVbcnProcedures#69](./codesnippet/VisualBasic/how-to-overload-a-procedure-that-takes-an-indefinite-number-of-parameters_1.vb)]  
  
 [!code-vb[VbVbcnProcedures#70](./codesnippet/VisualBasic/how-to-overload-a-procedure-that-takes-an-indefinite-number-of-parameters_2.vb)]  
  
 You cannot overload such a procedure with a parameter list that takes a one-dimensional array for the parameter array. However, you can use the signatures of the other implicit overloads. The following declarations illustrate this.  
  
 [!code-vb[VbVbcnProcedures#71](./codesnippet/VisualBasic/how-to-overload-a-procedure-that-takes-an-indefinite-number-of-parameters_3.vb)]  
  
 The code in the overloaded versions does not have to test whether the calling code supplied one or more values for the `ParamArray` parameter, or if so, how many. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] passes control to the version matching the calling argument list.  
  
## Compiling the Code  
 Because a procedure with a `ParamArray` parameter is equivalent to a set of overloaded versions, you cannot overload such a procedure with a parameter list corresponding to any of these implicit overloads. For more information, see [Considerations in Overloading Procedures](./considerations-in-overloading-procedures.md).  
  
## .NET Framework Security  
 Whenever you deal with an array which can be indefinitely large, there is a risk of overrunning some internal capacity of your application. If you accept a parameter array, you should test for the length of the array the calling code passed to it, and take appropriate steps if it is too large for your application.  
  
## See Also  
 [Procedures](./index.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [Optional Parameters](./optional-parameters.md)  
 [Parameter Arrays](./parameter-arrays.md)  
 [Procedure Overloading](./procedure-overloading.md)  
 [Troubleshooting Procedures](./troubleshooting-procedures.md)  
 [How to: Define Multiple Versions of a Procedure](./how-to-define-multiple-versions-of-a-procedure.md)  
 [How to: Call an Overloaded Procedure](./how-to-call-an-overloaded-procedure.md)  
 [How to: Overload a Procedure that Takes Optional Parameters](./how-to-overload-a-procedure-that-takes-optional-parameters.md)  
 [Overload Resolution](./overload-resolution.md)
