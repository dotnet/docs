---
title: "Structure of a Visual Basic Program"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "conditional compilation [Visual Basic], Visual Basic"
  - "program structure [Visual Basic], Visual Basic"
  - "procedures [Visual Basic], structure"
  - "Visual Basic code, program structure"
ms.assetid: ad0c6531-d762-4c77-a700-de16b07b6119
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# Structure of a Visual Basic Program
A [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] program is built up from standard building blocks. A *solution* comprises one or more projects. A *project* in turn can contain one or more assemblies. Each *assembly* is compiled from one or more source files. A *source file* provides the definition and implementation of classes, structures, modules, and interfaces, which ultimately contain all your code.  
  
 For more information about these building blocks of a [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] program, see [Solutions and Projects](/visualstudio/ide/solutions-and-projects-in-visual-studio) and [Assemblies and the Global Assembly Cache](../../../visual-basic/programming-guide/concepts/assemblies-gac/index.md).  
  
## File-Level Programming Elements  
 When you start a project or file and open the code editor, you see some code already in place and in the correct order. Any code that you write should follow the following sequence:  
  
1.  `Option` statements  
  
2.  `Imports` statements  
  
3.  `Namespace` statements and namespace-level elements  
  
 If you enter statements in a different order, compilation errors can result.  
  
 A program can also contain conditional compilation statements. You can intersperse these in the source file among the statements of the preceding sequence.  
  
### Option Statements  
 `Option` statements establish ground rules for subsequent code, helping prevent syntax and logic errors. The [Option Explicit Statement](../../../visual-basic/language-reference/statements/option-explicit-statement.md) ensures that all variables are declared and spelled correctly, which reduces debugging time. The [Option Strict Statement](../../../visual-basic/language-reference/statements/option-strict-statement.md) helps to minimize logic errors and data loss that can occur when you work between variables of different data types. The [Option Compare Statement](../../../visual-basic/language-reference/statements/option-compare-statement.md) specifies the way strings are compared to each other, based on either their `Binary` or `Text` values.  
  
### Imports Statements  
 You can include an [Imports Statement (.NET Namespace and Type)](../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md) to import names defined outside your project. An `Imports` statement allows your code to refer to classes and other types defined within the imported namespace, without having to qualify them. You can use as many `Imports` statements as appropriate. For more information, see [References and the Imports Statement](../../../visual-basic/programming-guide/program-structure/references-and-the-imports-statement.md).  
  
### Namespace Statements  
 Namespaces help you organize and classify your programming elements for ease of grouping and accessing. You use the [Namespace Statement](../../../visual-basic/language-reference/statements/namespace-statement.md) to classify the following statements within a particular namespace. For more information, see [Namespaces in Visual Basic](../../../visual-basic/programming-guide/program-structure/namespaces.md).  
  
### Conditional Compilation Statements  
 Conditional compilation statements can appear almost anywhere in your source file. They cause parts of your code to be included or excluded at compile time depending on certain conditions. You can also use them for debugging your application, because conditional code runs in debugging mode only. For more information, see [Conditional Compilation](../../../visual-basic/programming-guide/program-structure/conditional-compilation.md).  
  
## Namespace-Level Programming Elements  
 Classes, structures, and modules contain all the code in your source file. They are *namespace-level* elements, which can appear within a namespace or at the source file level. They hold the declarations of all other programming elements. Interfaces, which define element signatures but provide no implementation, also appear at module level. For more information on the module-level elements, see the following:  
  
-   [Class Statement](../../../visual-basic/language-reference/statements/class-statement.md)  
  
-   [Structure Statement](../../../visual-basic/language-reference/statements/structure-statement.md)  
  
-   [Module Statement](../../../visual-basic/language-reference/statements/module-statement.md)  
  
-   [Interface Statement](../../../visual-basic/language-reference/statements/interface-statement.md)  
  
 Data elements at namespace level are enumerations and delegates.  
  
## Module-Level Programming Elements  
 Procedures, operators, properties, and events are the only programming elements that can hold executable code (statements that perform actions at run time). They are the *module-level* elements of your program. For more information on the procedure-level elements, see the following:  
  
-   [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)  
  
-   [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)  
  
-   [Declare Statement](../../../visual-basic/language-reference/statements/declare-statement.md)  
  
-   [Operator Statement](../../../visual-basic/language-reference/statements/operator-statement.md)  
  
-   [Property Statement](../../../visual-basic/language-reference/statements/property-statement.md)  
  
-   [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md)  
  
 Data elements at module level are variables, constants, enumerations, and delegates.  
  
## Procedure-Level Programming Elements  
 Most of the contents of *procedure-level* elements are executable statements, which constitute the run-time code of your program. All executable code must be in some procedure (`Function`, `Sub`, `Operator`, `Get`, `Set`, `AddHandler`, `RemoveHandler`, `RaiseEvent`). For more information, see [Statements](../../../visual-basic/programming-guide/language-features/statements.md).  
  
 Data elements at procedure level are limited to local variables and constants.  
  
## The Main Procedure  
 The `Main` procedure is the first code to run when your application has been loaded. `Main` serves as the starting point and overall control for your application. There are four varieties of `Main`:  
  
-   `Sub Main()`  
  
-   `Sub Main(ByVal cmdArgs() As String)`  
  
-   `Function Main() As Integer`  
  
-   `Function Main(ByVal cmdArgs() As String) As Integer`  
  
 The most common variety of this procedure is `Sub Main()`. For more information, see [Main Procedure in Visual Basic](../../../visual-basic/programming-guide/program-structure/main-procedure.md).  
  
## See Also  
 [Main Procedure in Visual Basic](../../../visual-basic/programming-guide/program-structure/main-procedure.md)  
 [Visual Basic Naming Conventions](../../../visual-basic/programming-guide/program-structure/naming-conventions.md)  
 [Visual Basic Limitations](../../../visual-basic/programming-guide/program-structure/limitations.md)
