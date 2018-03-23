---
title: "-main"
ms.date: 03/13/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "main compiler option [Visual Basic]"
  - "/main compiler option [Visual Basic]"
  - "-main compiler option [Visual Basic]"
ms.assetid: 83fc339d-6652-415d-b205-b5133319b5b0
author: rpetrusha
ms.author: ronpet
---
# -main
Specifies the class or module that contains the `Sub Main` procedure.  
  
## Syntax  
  
```  
-main:location  
```  
  
## Arguments  
 `location`  
 Required. The name of the class or module that contains the `Sub Main` procedure to be called when the program starts. This may be in the form **-main:module** or **-main:namespace.module**.  
  
## Remarks  
 Use this option when you create an executable file or Windows executable program. If the **-main** option is omitted, the compiler searches for a valid shared `Sub Main` in all public classes and modules.  
  
 See [Main Procedure in Visual Basic](../../../visual-basic/programming-guide/program-structure/main-procedure.md) for a discussion of the various forms of the `Main` procedure.  
  
 When `location` is a class that inherits from <xref:System.Windows.Forms.Form>, the compiler provides a default `Main` procedure that starts the application if the class has no `Main` procedure. This lets you compile code at the command line that was created in the development environment.  
  
 [!code-vb[VbVbalrCompiler#16](../../../visual-basic/reference/command-line-compiler/codesnippet/VisualBasic/main_1.vb)]  
  
### To set -main in the Visual Studio integrated development environment  
  
1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**.  
  
2.  Click the **Application** tab.  
  
3.  Make sure the **Enable application framework** check box is not checked.  
  
4.  Modify the value in the **Startup object** box.  
  
## Example  
 The following code compiles `T2.vb` and `T3.vb`, specifying that the `Sub Main` procedure will be found in the `Test2` class.  
  
```console
vbc t2.vb t3.vb -main:Test2  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [-target (Visual Basic)](../../../visual-basic/reference/command-line-compiler/target.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)  
 [Main Procedure in Visual Basic](../../../visual-basic/programming-guide/program-structure/main-procedure.md)
