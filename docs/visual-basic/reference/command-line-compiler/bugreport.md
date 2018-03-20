---
title: "-bugreport"
ms.date: 03/08/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "-bugreport compiler option [Visual Basic]"
  - "bugreport compiler option [Visual Basic]"
  - "/bugreport compiler option [Visual Basic]"
ms.assetid: e4325406-8dbd-4b48-b311-9ee0799e48bb
author: dotnet-bot
ms.author: dotnetcontent
---
# -bugreport
Creates a file that you can use when you file a bug report.  
  
## Syntax  
  
```  
-bugreport:file  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`file`|Required. The name of the file that will contain your bug report. Enclose the file name in quotation marks (" ") if the name contains a space.|  
  
## Remarks  
 The following information is added to `file`:  
  
-   A copy of all source-code files in the compilation.  
  
-   A list of the compiler options used in the compilation.  
  
-   Version information about your compiler, common language runtime, and operating system.  
  
-   Compiler output, if any.  
  
-   A description of the problem, for which you are prompted.  
  
-   A description of how you think the problem should be fixed, for which you are prompted.  
  
 Because a copy of all source-code files is included in `file`, you may want to reproduce the (suspected) code defect in the shortest possible program.  
  
> [!IMPORTANT]
>  The `-bugreport` option produces a file that contains potentially sensitive information. This includes current time, compiler version, [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] version, OS version, user name, the command-line arguments with which the compiler was run, all source code, and the binary form of any referenced assembly. This option can be accessed by specifying command-line options in the Web.config file for a server-side compilation of an [!INCLUDE[vstecasp](~/includes/vstecasp-md.md)] application. To prevent this, modify the Machine.config file to disallow users from compiling on the server.  
  
 If this option is used with `-errorreport:prompt`, `-errorreport:queue`, or `-errorreport:send`, and your application encounters an internal compiler error, the information in `file` is sent to Microsoft Corporation. That information will help Microsoft engineers identify the cause of the error and may help improve the next release of [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)]. By default, no information is sent to Microsoft. However, when you compile an application by using `-errorreport:queue`, which is enabled by default, the application collects its error reports. Then, when the computer's administrator logs in, the error reporting system displays a pop-up window that enables the administrator to forward to Microsoft any error reports that occurred since the logon.  
  
> [!NOTE]
>  The `/bugreport` option is not available from within the Visual Studio development environment; it is available only when you compile from the command line.  
  
## Example  
 The following example compiles `T2.vb` and puts all bug-reporting information in the file `Problem.txt`.  
  
```  
vbc -bugreport:problem.txt t2.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [-debug (Visual Basic)](../../../visual-basic/reference/command-line-compiler/debug.md)  
 [-errorreport](../../../visual-basic/reference/command-line-compiler/errorreport.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)  
 [trustLevel Element for securityPolicy (ASP.NET Settings Schema)](http://msdn.microsoft.com/library/729ab04c-03da-4ee5-86b1-be9d08a09369)
