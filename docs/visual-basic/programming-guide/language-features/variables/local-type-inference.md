---
title: "Local Type Inference (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "local type inference"
  - "vb.TypeInfer"
helpviewer_keywords: 
  - "Option Infer statement [Visual Basic]"
  - "local type inference [Visual Basic]"
  - "implicitly-typed local variables [Visual Basic]"
  - "variables [Visual Basic], type inference"
  - "inference [Visual Basic]"
  - "type inference [Visual Basic]"
ms.assetid: b8307f18-2e56-4ab3-a45a-826873f400f6
caps.latest.revision: 43
author: dotnet-bot
ms.author: dotnetcontent
---
# Local Type Inference (Visual Basic)
The Visual Basic compiler uses *type inference* to determine the data types of local variables declared without an `As` clause. The compiler infers the type of the variable from the type of the initialization expression. This enables you to declare variables without explicitly stating a type, as shown in the following example. As a result of the declarations, both `num1` and `num2` are strongly typed as integers.  
  
 [!code-vb[VbVbalrTypeInference#1](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/local-type-inference_1.vb)]  
 
> [!NOTE]
>  If you do not want `num2` in the previous example to be typed as an `Integer`, you can specify another type by using a declaration like `Dim num3 As Object = 3` or `Dim num4 As Double = 3`.  

> [!NOTE]
>  Type inference can be used only for non-static local variables; it cannot be used to determine the type of class fields, properties, or functions.
 
 Local type inference applies at procedure level. It cannot be used to declare variables at module level (within a class, structure, module, or interface but not within a procedure or block). If `num2` in the previous example were a field of a class instead of a local variable in a procedure, the declaration would cause an error with `Option Strict` on, and would classify `num2` as an `Object` with `Option Strict` off. Similarly, local type inference does not apply to procedure level variables declared as `Static`.  
  
## Type Inference vs. Late Binding  
 Code that uses type inference resembles code that relies on late binding. However, type inference strongly types the variable instead of leaving it as `Object`. The compiler uses a variable's initializer to determine the variable's type at compile time to produce early-bound code. In the previous example, `num2`, like `num1`, is typed as an `Integer`.  
  
 The behavior of early-bound variables differs from that of late-bound variables, for which the type is known only at run time. Knowing the type early enables the compiler to identify problems before execution, allocate memory precisely, and perform other optimizations. Early binding also enables the Visual Basic integrated development environment (IDE) to provide IntelliSense Help about the members of an object. Early binding is also preferred for performance. This is because all data stored in a late-bound variable must be wrapped as type `Object`, and accessing members of the type at run time makes the program slower.  
  
## Examples  
 Type inference occurs when a local variable is declared without an `As` clause and initialized. The compiler uses the type of the assigned initial value as the type of the variable. For example, each of the following lines of code declares a variable of type `String`.  
  
 [!code-vb[VbVbalrTypeInference#2](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/local-type-inference_2.vb)]  
  
 The following code demonstrates two equivalent ways to create an array of integers.  
  
 [!code-vb[VbVbalrTypeInference#3](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/local-type-inference_3.vb)]  
  
 It is convenient to use type inference to determine the type of a loop control variable. In the following code, the compiler infers that `number` is an `Integer` because `someNumbers2` from the previous example is an array of integers.  
  
 [!code-vb[VbVbalrTypeInference#4](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/local-type-inference_4.vb)]  
  
 Local type inference can be used in `Using` statements to establish the type of the resource name, as the following example demonstrates.  
  
 [!code-vb[VbVbalrTypeInference#7](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/local-type-inference_5.vb)]  
  
 The type of a variable can also be inferred from the return values of functions, as the following example demonstrates. Both `pList1` and `pList2` are arrays of processes because `Process.GetProcesses` returns an array of processes.  
  
 [!code-vb[VbVbalrTypeInference#5](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/local-type-inference_6.vb)]  
  
## Option Infer  
 `Option Infer` enables you specify whether local type inference is allowed in a particular file. To enable or to block the option, type one of the following statements at the start of the file.  
  
 `Option Infer On`  
  
 `Option Infer Off`  
  
 If you do not specify a value for `Option Infer` in your code, the compiler default is `Option Infer On`. For projects upgraded from [!INCLUDE[vb_orcas_long](~/includes/vb-orcas-long-md.md)] or earlier, the compiler default is `Option Infer Off`.  
  
 If the value set for `Option Infer` in a file conflicts with the value set in the IDE or on the command line, the value in the file has precedence.  
  
 For more information, see [Option Infer Statement](../../../../visual-basic/language-reference/statements/option-infer-statement.md) and [Compile Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/compile-page-project-designer-visual-basic).  
  
## See Also  
 [Anonymous Types](../../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md)  
 [Early and Late Binding](../../../../visual-basic/programming-guide/language-features/early-late-binding/index.md)  
 [For Each...Next Statement](../../../../visual-basic/language-reference/statements/for-each-next-statement.md)  
 [For...Next Statement](../../../../visual-basic/language-reference/statements/for-next-statement.md)  
 [Option Infer Statement](../../../../visual-basic/language-reference/statements/option-infer-statement.md)  
 [/optioninfer](../../../../visual-basic/reference/command-line-compiler/optioninfer.md)  
 [Introduction to LINQ in Visual Basic](../../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)
