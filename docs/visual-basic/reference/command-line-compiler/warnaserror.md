---
title: "-warnaserror (Visual Basic)"
ms.date: 03/13/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "warnaserror compiler option [Visual Basic]"
  - "/warnaserror compiler option [Visual Basic]"
  - "-warnaserror compiler option [Visual Basic]"
ms.assetid: 49819f1d-a1bd-4201-affe-5afe6d9712e1
author: rpetrusha
ms.author: ronpet
---
# -warnaserror (Visual Basic)
Causes the compiler to treat the first occurrence of a warning as an error.  
  
## Syntax  
  
```  
-warnaserror[+ | -][:numberList]  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|+ &#124; -|Optional. By default, `-warnaserror-` is in effect; warnings do not prevent the compiler from producing an output file. The `-warnaserror` option, which is the same as `-warnaserror+`, causes warnings to be treated as errors.|  
|`numberList`|Optional. Comma-delimited list of the warning ID numbers to which the `-warnaserror` option applies. If no warning ID is specified, the `-warnaserror` option applies to all warnings.|  
  
## Remarks  
 The `-warnaserror` option treats all warnings as errors. Any messages that would ordinarily be reported as warnings are instead reported as errors. The compiler reports subsequent occurrences of the same warning as warnings.  
  
 By default, `-warnaserror-` is in effect, which causes the warnings to be informational only. The `-warnaserror` option, which is the same as `-warnaserror+`, causes warnings to be treated as errors.  
  
 If you want only a few specific warnings to be treated as errors, you may specify a comma-separated list of warning numbers to treat as errors.  
  
> [!NOTE]
>  The `-warnaserror` option does not control how warnings are displayed. Use the [-nowarn](../../../visual-basic/reference/command-line-compiler/nowarn.md) option to disable warnings.  
  
|To set -warnaserror to treat all warnings as errors in the Visual Studio IDE|  
|---|  
|1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**. <br />2.  Click the **Compile** tab.<br />3.  Make sure the **Disable all warnings** check box is unchecked.<br />4.  Check the **Treat all warnings as errors** check box.|  
  
|To set -warnaserror to treat specific warnings as errors in the Visual Studio IDE|  
|---|  
|1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**.<br />2.  Click the **Compile** tab.<br />3.  Make sure the **Disable all warnings** check box is unchecked.<br />4.  Make sure the **Treat all warnings as errors** check box is unchecked.<br />5.  Select **Error** from the **Notification** column adjacent to the warning that should be treated as an error.|  
  
## Example  
 The following code compiles `In.vb` and directs the compiler to display an error for the first occurrence of every warning it finds.  
  
```console
vbc -warnaserror in.vb  
```  
  
## Example  
 The following code compiles `T2.vb` and treats only the warning for unused local variables (42024) as an error.  
  
```console
vbc -warnaserror:42024 t2.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)  
 [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic)
