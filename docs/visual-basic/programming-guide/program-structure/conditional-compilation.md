---
title: "Conditional Compilation in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "conditional compilation [Visual Basic], about conditional compilation"
  - "compilation [Visual Basic], conditional"
ms.assetid: 9c35e55e-7eee-44fb-a586-dad1f1884848
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# Conditional Compilation in Visual Basic
In *conditional compilation*, particular blocks of code in a program are compiled selectively while others are ignored.  
  
 For example, you may want to write debugging statements that compare the speed of different approaches to the same programming task, or you may want to localize an application for multiple languages. Conditional compilation statements are designed to run during compile time, not at run time.  
  
 You denote blocks of code to be conditionally compiled with the `#If...Then...#Else` directive. For example, to create French- and German-language versions of the same application from the same source code, you embed platform-specific code segments in `#If...Then` statements using the predefined constants `FrenchVersion` and `GermanVersion`. The following example demonstrates how:  
  
 [!code-vb[VbVbalrConditionalComp#5](../../../visual-basic/language-reference/directives/codesnippet/VisualBasic/conditional-compilation_1.vb)]  
  
 If you set the value of the `FrenchVersion` conditional compilation constant to `True` at compile time, the conditional code for the French version is compiled. If you set the value of the `GermanVersion` constant to `True`, the compiler uses the German version. If neither is set to `True`, the code in the last `Else` block runs.  
  
> [!NOTE]
>  Autocompletion will not function when editing code and using conditional compilation directives if the code is not part of the current branch.  
  
## Declaring Conditional Compilation Constants  
 You can set conditional compilation constants in one of three ways:  
  
-   In the **Project Designer**  
  
-   At the command line when using the command-line compiler  
  
-   In your code  
  
 Conditional compilation constants have a special scope and cannot be accessed from standard code. The scope of a conditional compilation constant is dependent on the way it is set. The following table lists the scope of constants declared using each of the three ways mentioned above.  
  
|How constant is set|Scope of constant|  
|---|---|  
|**Project Designer**|Public to all files in the project|  
|Command line|Public to all files passed to the command-line compiler|  
|`#Const` statement in code|Private to the file in which it is declared|  
  
|To set constants in the Project Designer|  
|---|  
|-   Before creating your executable file, set constants in the **Project Designer** by following the steps provided in [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties).|  
  
|To set constants at the command line|  
|---|  
|-   Use the **/d** switch to enter conditional compilation constants, as in the following example:<br />     `vbc MyProj.vb /d:conFrenchVersion=–1:conANSI=0`<br />     No space is required between the **/d** switch and the first constant. For more information, see [/define (Visual Basic)](../../../visual-basic/reference/command-line-compiler/define.md).<br />     Command-line declarations override declarations entered in the **Project Designer**, but do not erase them. Arguments set in **Project Designer** remain in effect for subsequent compilations.<br />     When writing constants in the code itself, there are no strict rules as to their placement, since their scope is the entire module in which they are declared.|  
  
|To set constants in your code|  
|---|  
|-   Place the constants in the declaration block of the module in which they are used. This helps keep your code organized and easier to read.|  
  
## Related Topics  
  
|Title|Description|  
|---|---|  
|[Program Structure and Code Conventions](../../../visual-basic/programming-guide/program-structure/program-structure-and-code-conventions.md)|Provides suggestions for making your code easy to read and maintain.|  
  
## Reference  
 [#Const Directive](../../../visual-basic/language-reference/directives/const-directive.md)  
  
 [#If...Then...#Else Directives](../../../visual-basic/language-reference/directives/if-then-else-directives.md)  
  
 [/define (Visual Basic)](../../../visual-basic/reference/command-line-compiler/define.md)
