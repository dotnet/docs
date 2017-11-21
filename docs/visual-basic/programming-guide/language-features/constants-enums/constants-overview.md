---
title: "Constants Overview (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "constants [Visual Basic]"
ms.assetid: 29016fe8-78b3-4dc8-90b8-1cfec2fa8ac9
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# Constants Overview (Visual Basic)
A constant is a meaningful name that takes the place of a number or string that does not change. Constants store values that, as the name implies, remain the same throughout the execution of an application. You can greatly improve the readability of your code and make it easier to maintain by using constants. Use them in code that contains values that reappear or that depends on certain numbers that are difficult to remember or have no obvious meaning.  
  
## How to Create and Use Constants  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] contains a number of predefined constants, mainly using for printing and displaying. You can also create your own constants with the `Const` statement, using the same guidelines you would for creating a variable name. If `Option Strict` is `On`, you must explicitly declare the constant type.  
  
 A constant's scope, which is the set of all code that can refer to it without qualifying its name, is the same as that of a variable declared in the same location. To create a constant that exists within the scope of a particular procedure, declare it inside that procedure. To create a constant that is available throughout an application, declare it using the `Public` keyword in the declarations section of the class.  
  
> [!NOTE]
>  Although constants somewhat resemble variables, you cannot modify them or assign new values to them as you can to variables.  
  
 The constants you use in your code can be defined by the object model for controls or components you work with, or they can be user-defined (that is, those you create yourself).  
  
## Compile-time and Run-time Constants  
 A compile-time constant is computed at the time the code is compiled, while a run-time constant can only be computed while the application is running. A compile-time constant will have the same value each time an application runs, while a run-time constant may change each time. Compile-time constants are required for cases such as array bounds, case expressions, or enumerator initializers.  
  
## In This Section  
  
|Definition|Term|  
|---|---|  
|[How to: Declare A Constant](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-declare-a-constant.md)|Explains how to use the `Const` statement to declare a constant and set its value; by declaring a constant, you assign a meaningful name to the value.|  
|[User-Defined Constants](../../../../visual-basic/programming-guide/language-features/constants-enums/user-defined-constants.md)|Describes how to create your own constants, including information on scoping and how to avoid circular references.|  
|[Constant and Literal Data Types](../../../../visual-basic/programming-guide/language-features/constants-enums/constant-and-literal-data-types.md)|Provides information on how the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler initializes constants when `Option Explicit` is turned off.|  
|[How to: Group Related Constant Values Together](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-group-related-constant-values-together.md)|Demonstrates how to group constant values that are related.|  
  
## Reference  
  
|Definition|Term|  
|---|---|  
|[Constants and Enumerations](../../../../visual-basic/language-reference/constants-and-enumerations.md)|Lists the constants predefined by [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)].|  
|[Const Statement](../../../../visual-basic/language-reference/statements/const-statement.md)|Describes the `Const` statement and its use.|  
|[Option Strict Statement](../../../../visual-basic/language-reference/statements/option-strict-statement.md)|Describes the `Option Strict` statement and its use.|  
  
## See Also  
 [Enumerations Overview](../../../../visual-basic/programming-guide/language-features/constants-enums/enumerations-overview.md)  
 [How to: Initialize an Array Variable in Visual Basic](../../../../visual-basic/programming-guide/language-features/arrays/how-to-initialize-an-array-variable.md)
