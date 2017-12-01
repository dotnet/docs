---
title: "Considerations in Overloading Procedures (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "signatures [Visual Basic], ParamArray arguments"
  - "ParamArray keyword [Visual Basic], parameter arrays"
  - "ParamArray keyword [Visual Basic], arguments and signatures"
  - "function overloading [Visual Basic], implicit overloads for ParamArray"
  - "ParamArray keyword [Visual Basic], signatures"
  - "Visual Basic code, procedures"
  - "arguments [Visual Basic], parameter arrays"
  - "procedures [Visual Basic], overloading"
  - "parameters [Visual Basic], lists"
  - "function overloading [Visual Basic], typeless programming"
  - "typeless programming"
  - "function overloading [Visual Basic], restrictions"
  - "arguments [Visual Basic], optional"
  - "optional arguments [Visual Basic], overloading"
  - "signatures [Visual Basic], procedure"
  - "parameter lists [Visual Basic]"
  - "parameter arrays [Visual Basic], overloading arguments"
  - "Visual Basic code, parameter lists"
  - "procedure overloading [Visual Basic], considerations"
  - "Option Explicit statement [Visual Basic]"
  - "restrictions [Visual Basic], overloading procedures"
  - "procedures [Visual Basic], parameter lists"
ms.assetid: a2001248-10d0-42c5-b0ce-eeedc987319f
caps.latest.revision: 26
author: dotnet-bot
ms.author: dotnetcontent
---
# Considerations in Overloading Procedures (Visual Basic)
When you overload a procedure, you must use a different *signature* for each overloaded version. This usually means each version must specify a different parameter list. For more information, see "Different Signature" in [Procedure Overloading](./procedure-overloading.md).  
  
 You can overload a `Function` procedure with a `Sub` procedure, and vice versa, provided they have different signatures. Two overloads cannot differ only in that one has a return value and the other does not.  
  
 You can overload a property the same way you overload a procedure, and with the same restrictions. However, you cannot overload a procedure with a property, or vice versa.  
  
## Alternatives to Overloaded Versions  
 You sometimes have alternatives to overloaded versions, particularly when the presence of arguments is optional or their number is variable.  
  
 Keep in mind that optional arguments are not necessarily supported by all languages, and parameter arrays are limited to [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)]. If you are writing a procedure that is likely to be called from code written in any of several different languages, overloaded versions offer the greatest flexibility.  
  
### Overloads and Optional Arguments  
 When the calling code can optionally supply or omit one or more arguments, you can define multiple overloaded versions or use optional parameters.  
  
#### When to Use Overloaded Versions  
 You can consider defining a series of overloaded versions in the following cases:  
  
-   The logic in the procedure code is significantly different depending on whether the calling code supplies an optional argument or not.  
  
-   The procedure code cannot reliably test whether the calling code has supplied an optional argument. This is the case, for example, if there is no possible candidate for a default value that the calling code could not be expected to supply.  
  
#### When to Use Optional Parameters  
 You might prefer one or more optional parameters in the following cases:  
  
-   The only required action when the calling code does not supply an optional argument is to set the parameter to a default value. In such a case, the procedure code can be less complicated if you define a single version with one or more `Optional` parameters.  
  
 For more information, see [Optional Parameters](./optional-parameters.md).  
  
### Overloads and ParamArrays  
 When the calling code can pass a variable number of arguments, you can define multiple overloaded versions or use a parameter array.  
  
#### When to Use Overloaded Versions  
 You can consider defining a series of overloaded versions in the following cases:  
  
-   You know that the calling code never passes more than a small number of values to the parameter array.  
  
-   The logic in the procedure code is significantly different depending on how many values the calling code passes.  
  
-   The calling code can pass values of different data types.  
  
#### When to Use a Parameter Array  
 You are better served by a `ParamArray` parameter in the following cases:  
  
-   You are not able to predict how many values the calling code can pass to the parameter array, and it could be a large number.  
  
-   The procedure logic lends itself to iterating through all the values the calling code passes, performing essentially the same operations on every value.  
  
 For more information, see [Parameter Arrays](./parameter-arrays.md).  
  
## Implicit Overloads for Optional Parameters  
 A procedure with an [Optional](../../../../visual-basic/language-reference/modifiers/optional.md) parameter is equivalent to two overloaded procedures, one with the optional parameter and one without it. You cannot overload such a procedure with a parameter list corresponding to either of these. The following declarations illustrate this.  
  
 [!code-vb[VbVbcnProcedures#58](./codesnippet/VisualBasic/considerations-in-overloading-procedures_1.vb)]  
  
 [!code-vb[VbVbcnProcedures#60](./codesnippet/VisualBasic/considerations-in-overloading-procedures_2.vb)]  
  
 [!code-vb[VbVbcnProcedures#61](./codesnippet/VisualBasic/considerations-in-overloading-procedures_3.vb)]  
  
 For a procedure with more than one optional parameter, there is a set of implicit overloads, arrived at by logic similar to that in the preceding example.  
  
## Implicit Overloads for a ParamArray Parameter  
 The compiler considers a procedure with a [ParamArray](../../../../visual-basic/language-reference/modifiers/paramarray.md) parameter to have an infinite number of overloads, differing from each other in what the calling code passes to the parameter array, as follows:  
  
-   One overload for when the calling code does not supply an argument to the `ParamArray`  
  
-   One overload for when the calling code supplies a one-dimensional array of the `ParamArray` element type  
  
-   For every positive integer, one overload for when the calling code supplies that number of arguments, each of the `ParamArray` element type  
  
 The following declarations illustrate these implicit overloads.  
  
 [!code-vb[VbVbcnProcedures#68](./codesnippet/VisualBasic/considerations-in-overloading-procedures_4.vb)]  
  
 [!code-vb[VbVbcnProcedures#70](./codesnippet/VisualBasic/considerations-in-overloading-procedures_5.vb)]  
  
 You cannot overload such a procedure with a parameter list that takes a one-dimensional array for the parameter array. However, you can use the signatures of the other implicit overloads. The following declarations illustrate this.  
  
 [!code-vb[VbVbcnProcedures#71](./codesnippet/VisualBasic/considerations-in-overloading-procedures_6.vb)]  
  
## Typeless Programming as an Alternative to Overloading  
 If you want to allow the calling code to pass different data types to a parameter, an alternative approach is typeless programming. You can set the type checking switch to `Off` with either the [Option Strict Statement](../../../../visual-basic/language-reference/statements/option-strict-statement.md) or the [/optionstrict](../../../../visual-basic/reference/command-line-compiler/optionstrict.md) compiler option. Then you do not have to declare the parameter's data type. However, this approach has the following disadvantages compared to overloading:  
  
-   Typeless programming produces less efficient execution code.  
  
-   The procedure must test for every data type it anticipates being passed.  
  
-   The compiler cannot signal an error if the calling code passes a data type that the procedure does not support.  
  
## See Also  
 [Procedures](./index.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [Troubleshooting Procedures](./troubleshooting-procedures.md)  
 [How to: Define Multiple Versions of a Procedure](./how-to-define-multiple-versions-of-a-procedure.md)  
 [How to: Call an Overloaded Procedure](./how-to-call-an-overloaded-procedure.md)  
 [How to: Overload a Procedure that Takes Optional Parameters](./how-to-overload-a-procedure-that-takes-optional-parameters.md)  
 [How to: Overload a Procedure that Takes an Indefinite Number of Parameters](./how-to-overload-a-procedure-that-takes-an-indefinite-number-of-parameters.md)  
 [Overload Resolution](./overload-resolution.md)  
 [Overloads](../../../../visual-basic/language-reference/modifiers/overloads.md)
