---
title: "-errorreport"
ms.date: 03/10/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "-errorreport compiler option [Visual Basic]"
  - "/errorreport compiler option [Visual Basic]"
  - "errorreport compiler option [Visual Basic]"
ms.assetid: a7fe83a2-a6d8-460c-8dad-79a8f433f501
author: rpetrusha
ms.author: ronpet
---
# -errorreport
Specifies how the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler should report internal compiler errors.  
  
## Syntax  
  
```  
-errorreport:{ prompt | queue | send | none }  
```  
  
## Remarks  
 This option provides a convenient way to report a [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] internal compiler error (ICE) to the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] team at Microsoft. By default, the compiler sends no information to Microsoft. However, if you do encounter an internal compiler error, this option allows you to report the error to Microsoft. That information will help Microsoft engineers identify the cause and may help improve the next release of [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)].  
  
 A user's ability to send reports depends on machine and user policy permissions.  
  
 The following table summarizes the effect of the `-errorreport` option.  
  
|Option|Behavior|  
|---|---|  
|`prompt`|If an internal compiler error occurs, a dialog box comes up so that you can view the exact data that the compiler collected. You can determine if there is any sensitive information in the error report and make a decision on whether to send it to Microsoft. If you decide to send it, and the machine and user policy settings allow it, the compiler sends the data to Microsoft.|  
|`queue`|Queues the error report. When you log in with administrator privileges, you can report any failures since the last time you were logged in (you will not be prompted to send reports for failures more than once every three days). This is the default behavior when the `-errorreport` option is not specified.|  
|`send`|If an internal compiler error occurs, and the machine and user policy settings allow it, the compiler sends the data to Microsoft.<br /><br /> The option `-errorreport:send` attempts to automatically send error information to Microsoft. This option depends on the registry. For more information about setting the appropriate values in the registry, see [How to Turn on Automatic Error Reporting in Visual Studio 2008 Command-line Tools](http://go.microsoft.com/fwlink/?LinkID=184695).|  
|`none`|If an internal compiler error occurs, it will not be collected or sent to Microsoft.|  
  
 The compiler sends data that includes the stack at the time of the error, which usually includes some source code. If `-errorreport` is used with the [-bugreport](../../../visual-basic/reference/command-line-compiler/bugreport.md) option, then the entire source file is sent.  
  
 This option is best used with the [/bugreport](../../../visual-basic/reference/command-line-compiler/bugreport.md) option, because it allows Microsoft engineers to more easily reproduce the error.  
  
> [!NOTE]
>  The `-errorreport` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## Example  
 The following code attempts to compile `T2.vb`, and if the compiler encounters an internal compiler error, it prompts you to send the error report to Microsoft.  
  
```  
vbc -errorreport:prompt t2.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)  
 [-bugreport](../../../visual-basic/reference/command-line-compiler/bugreport.md)
