---
title: "Calling a Property or Method Using a String Name (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "passing operators [Visual Basic]"
  - "strings [Visual Basic], passing new operators as"
  - "objects [Visual Basic], setting properties"
  - "setting properties, object properties at run time"
  - "method calls [Visual Basic], strings"
  - "methods [Visual Basic], calling with string names"
  - "calling methods [Visual Basic], string names"
  - "properties [Visual Basic], setting at run time"
  - "CallByName function"
ms.assetid: 79a7b8b4-b8c7-4ad8-aca8-12a9a2b32f03
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# Calling a Property or Method Using a String Name (Visual Basic)
In most cases, you can discover the properties and methods of an object at design time, and write code to handle them. However, in some cases you may not know about an object's properties and methods in advance, or you may just want the flexibility of enabling an end user to specify properties or execute methods at run time.  
  
## CallByName Function  
 Consider, for example, a client application that evaluates expressions entered by the user by passing an operator to a COM component. Suppose you are constantly adding new functions to the component that require new operators. When you use standard object access techniques, you must recompile and redistribute the client application before it could use the new operators. To avoid this, you can use the `CallByName` function to pass the new operators as strings, without changing the application.  
  
 The `CallByName` function lets you use a string to specify a property or method at run time. The signature for the `CallByName` function looks like this:  
  
 *Result* = `CallByName`(*Object*, *ProcedureName*, *CallType*, *Arguments*())  
  
 The first argument, *Object*, takes the name of the object you want to act upon. The *ProcedureName* argument takes a string that contains the name of the method or property procedure to be invoked. The *CallType* argument takes a constant that represents the type of procedure to invoke: a method (`Microsoft.VisualBasic.CallType.Method`), a property read (`Microsoft.VisualBasic.CallType.Get`), or a property set (`Microsoft.VisualBasic.CallType.Set`). The *Arguments* argument, which is optional, takes an array of type `Object` that contains any arguments to the procedure.  
  
 You can use `CallByName` with classes in your current solution, but it is most often used to access COM objects or objects from [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] assemblies.  
  
 Suppose you add a reference to an assembly that contains a class named `MathClass`, which has a new function named `SquareRoot`, as shown in the following code:  
  
 [!code-vb[VbVbalrOOP#53](../../../../visual-basic/misc/codesnippet/VisualBasic/calling-a-property-or-method-using-a-string-name_1.vb)]  
  
 Your application could use text box controls to control which method will be called and its arguments. For example, if `TextBox1` contains the expression to be evaluated, and `TextBox2` is used to enter the name of the function, you can use the following code to invoke the `SquareRoot` function on the expression in `TextBox1`:  
  
 [!code-vb[VbVbalrOOP#54](../../../../visual-basic/misc/codesnippet/VisualBasic/calling-a-property-or-method-using-a-string-name_2.vb)]  
  
 If you enter "64" in `TextBox1`, "SquareRoot" in `TextBox2`, and then call the `CallMath` procedure, the square root of the number in `TextBox1` is evaluated. The code in the example invokes the `SquareRoot` function (which takes a string that contains the expression to be evaluated as a required argument) and returns "8" in `TextBox1` (the square root of 64). Of course, if the user enters an invalid string in `TextBox2`, if the string contains the name of a property instead of a method, or if the method had an additional required argument, a run-time error occurs. You have to add robust error-handling code when you use `CallByName` to anticipate these or any other errors.  
  
> [!NOTE]
>  While the `CallByName` function may be useful in some cases, you must weigh its usefulness against the performance implications — using `CallByName` to invoke a procedure is slightly slower than a late-bound call. If you are invoking a function that is called repeatedly, such as inside a loop, `CallByName` can have a severe effect on performance.  
  
## See Also  
 <xref:Microsoft.VisualBasic.Interaction.CallByName%2A>  
 [Determining Object Type](../../../../visual-basic/programming-guide/language-features/early-late-binding/determining-object-type.md)
