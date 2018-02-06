---
title: "Optional Parameters (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "parameters [Visual Basic], optional"
  - "Visual Basic code, procedures"
  - "procedures [Visual Basic], optional arguments"
  - "optional arguments"
  - "named arguments [Visual Basic], and optional arguments"
  - "optional parameters"
  - "Optional keyword [Visual Basic], optional arguments"
  - "arguments [Visual Basic], optional"
  - "optional arguments [Visual Basic], and named arguments"
ms.assetid: 398d2845-1069-4e94-b934-a73b545c8b87
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# Optional Parameters (Visual Basic)
You can specify that a procedure parameter is optional and no argument has to be supplied for it when the procedure is called. *Optional parameters* are indicated by the `Optional` keyword in the procedure definition. The following rules apply:  
  
-   Every optional parameter in the procedure definition must specify a default value.  
  
-   The default value for an optional parameter must be a constant expression.  
  
-   Every parameter following an optional parameter in the procedure definition must also be optional.  
  
 The following syntax shows a procedure declaration with an optional parameter:  
  
```vb  
Sub name(ByVal parameter1 As datatype1, Optional ByVal parameter2 As datatype2 = defaultvalue)  
```  
  
## Calling Procedures with Optional Parameters  
 When you call a procedure with an optional parameter, you can choose whether to supply the argument. If you do not, the procedure uses the default value declared for that parameter.  
  
 When you omit one or more optional arguments in the argument list, you use successive commas to mark their positions. The following example call supplies the first and fourth arguments but not the second or third:  
  
```vb  
Sub name(argument 1, , , argument 4)  
```  
  
 The following example makes several calls to the `MsgBox` function. `MsgBox` has one required parameter and two optional parameters.  
  
 The first call to `MsgBox` supplies all three arguments in the order that `MsgBox` defines them. The second call supplies only the required argument. The third and fourth calls supply the first and third arguments. The third call does this by position, and the fourth call does it by name.  
  
 [!code-vb[VbVbcnProcedures#47](./codesnippet/VisualBasic/optional-parameters_1.vb)]  
  
## Determining Whether an Optional Argument Is Present  
 A procedure cannot detect at run time whether a given argument has been omitted or the calling code has explicitly supplied the default value. If you need to make this distinction, you can set an unlikely value as the default. The following procedure defines the optional parameter `office`, and tests for its default value, `QJZ`, to see if it has been omitted in the call:  
  
 [!code-vb[VbVbcnProcedures#46](./codesnippet/VisualBasic/optional-parameters_2.vb)]  
  
 If the optional parameter is a reference type such as a `String`, you can use `Nothing` as the default value, provided this is not an expected value for the argument.  
  
## Optional Parameters and Overloading  
 Another way to define a procedure with optional parameters is to use overloading. If you have one optional parameter, you can define two overloaded versions of the procedure, one accepting the parameter and one without it. This approach becomes more complicated as the number of optional parameters increases. However, its advantage is that you can be absolutely sure whether the calling program supplied each optional argument.  
  
## See Also  
 [Procedures](./index.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [Passing Arguments by Value and by Reference](./passing-arguments-by-value-and-by-reference.md)  
 [Passing Arguments by Position and by Name](./passing-arguments-by-position-and-by-name.md)  
 [Parameter Arrays](./parameter-arrays.md)  
 [Procedure Overloading](./procedure-overloading.md)  
 [Optional](../../../../visual-basic/language-reference/modifiers/optional.md)  
 [ParamArray](../../../../visual-basic/language-reference/modifiers/paramarray.md)
