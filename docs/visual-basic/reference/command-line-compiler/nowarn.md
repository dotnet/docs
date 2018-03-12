---
title: "-nowarn"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "nowarn compiler option [Visual Basic]"
  - "/nowarn compiler option [Visual Basic]"
  - "-nowarn compiler option [Visual Basic]"
ms.assetid: 7ebf2106-0652-4fdc-bf60-70fc86465d83
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# -nowarn
Suppresses the compiler's ability to generate warnings.  
  
## Syntax  
  
```  
-nowarn[:numberList]  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`numberList`|Optional. Comma-delimited list of the warning ID numbers that the compiler should suppress. If the warning IDs are not specified, all warnings are suppressed.|  
  
## Remarks  
 The `-nowarn` option causes the compiler to not generate warnings. To suppress an individual warning, supply the warning ID to the `-nowarn` option following the colon. Separate multiple warning numbers with commas.  
  
 You need to specify only the numeric part of the warning identifier. For example, if you want to suppress BC42024, the warning for unused local variables, specify `-nowarn:42024`.  
  
 For more information on the warning ID numbers, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).  
  
|To set -nowarn in the Visual Studio integrated development environment|  
|---|  
|1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**. <br />2.  Click the **Compile** tab.<br />3.  Select the **Disable all warnings** check box to disable all warnings.<br />     - or -<br />     To disable a particular warning, click **None** from the drop-down list adjacent to the warning.|  
  
## Example  
 The following code compiles `T2.vb` and does not display any warnings.  
  
```console
vbc -nowarn t2.vb  
```  
  
## Example  
 The following code compiles `T2.vb` and does not display the warnings for unused local variables (42024).  
  
```console
vbc -nowarn:42024 t2.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)  
 [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic)
