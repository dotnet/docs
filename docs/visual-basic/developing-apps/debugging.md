---
title: "Debugging Your Visual Basic Application | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "debugging [Visual Basic], common tasks"
ms.assetid: 904760b8-9fe9-42a7-9d65-d93774253219
caps.latest.revision: 28
author: "stevehoag"
ms.author: "shoag"

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Debugging Your Visual Basic Application
This page provides links to documentation for the debugging features that are built into [!INCLUDE[vsprvs](../../csharp/includes/vsprvs_md.md)]. For example, you can find semantic errors in your application by observing its run-time behavior in the debugger itself.  
  
 By using the debugger, you can examine the content of variables in your application without inserting additional calls to output the values. Similarly, you can insert a breakpoint in your code to halt execution at the point that you specify.  
  
## Controlling Execution  
 The following table lists debugging tasks involving execution control and provides links to their associated Help pages.  
  
|To|See|
|---|---|  
|Start to debug a Visual Studio project, attach to a process, break into code, step through code, run to the cursor, run to a function on the call stack, set the next statement, step through Just My Code, stop debugging, restart debugging, or detach from a debugged process.|[Navigating through Code with the Debugger](https://docs.microsoft.com/visualstudio/debugger/navigating-through-code-with-the-debugger)|  
|Specify the configurations for the debug and release versions of a program.|[Debug and Release Project Configurations](http://msdn.microsoft.com/en-us/0440b300-0614-4511-901a-105b771b236e)|  
|Set start options (command-line arguments, working directory, remote machine)|[How to: Set Start Options for Application Debugging](http://msdn.microsoft.com/en-us/ce792058-7bac-4dd6-858b-466e872687b8)|  
|Debug at design time.|[Walkthrough: Debugging at Design Time](https://docs.microsoft.com/visualstudio/debugger/walkthrough-debugging-at-design-time)|  
|Enable just-in-time debugging, which launches the Visual Studio debugger when a program running outside Visual Studio encounters a fatal error.|[Just-In-Time Debugging](https://docs.microsoft.com/visualstudio/debugger/just-in-time-debugging-in-visual-studio)|  
|Set breakpoints for source lines, assembly instructions, and call stack function. Specify conditions, hit counts, and execution location.|[Using Breakpoints](https://docs.microsoft.com/visualstudio/debugger/using-breakpoints)|  
  
## Handling Exceptions  
 The following table lists debugging tasks involving exception handling and points to their associated Help pages.  
  
|To|See|  
|---|---|  
|Break when an exception is thrown.|[Setting the debugger to break when an exception is thrown](https://docs.microsoft.com/visualstudio/debugger/managing-exceptions-with-the-debugger#setting-the-debugger-to-break-when-an-exception-is-thrown)|  
|Continue on user-unhandled exceptions.|[Setting the debugger to continue on user-unhandled exceptions](https://docs.microsoft.com/visualstudio/debugger/managing-exceptions-with-the-debugger#BKMK_UserUnhandled)|
|Add and delete exceptions.|[Adding and Deleting Exceptions](https://docs.microsoft.com/visualstudio/debugger/managing-exceptions-with-the-debugger#adding-and-deleting-exceptions)|
|Examine code to determine cause of the exception.|[How to: Examine System Code After an Exception](https://docs.microsoft.com/visualstudio/debugger/how-to-examine-system-code-after-an-exception)|  
|Continue execution after an exception has been thrown.|[Continuing Execution After an Exception](https://docs.microsoft.com/visualstudio/debugger/continuing-execution-after-an-exception)|  
  
## Edit and Continue  
 The following table lists debugging tasks involving Edit and Continue and points to their associated Help pages.  
  
|To|See|  
|---|---| 
|Turn Edit and Continue off and on.|[How to: Enable and Disable Edit and Continue](https://docs.microsoft.com/visualstudio/debugger/how-to-enable-and-disable-edit-and-continue)|  
|Stop Edit and Continue from applying code changes.|[How to: Stop Code Changes](https://docs.microsoft.com/visualstudio/debugger/how-to-stop-code-changes)|  
|Apply edits in break mode.|[How to: Apply Edits in Break Mode with Edit and Continue](https://docs.microsoft.com/visualstudio/debugger/how-to-apply-edits-in-break-mode-with-edit-and-continue)|  
  
## Examining Debugging Data  
 The following table lists debugging tasks involving viewing debugging data and points to their associated Help pages.  
  
|To|See|  
|---|---|    
|Use the **Registers** window to display register contents.|[How to: Use the Registers Window](https://docs.microsoft.com/visualstudio/debugger/how-to-use-the-registers-window)|  
|Use the **Call Stack** window to view function or procedure calls that are currently on the stack.|[How to: Use the Call Stack Window](https://docs.microsoft.com/visualstudio/debugger/how-to-use-the-call-stack-window)|  
|Use the **Disassembly** window to view assembly code corresponding to the instructions created by the compiler.|[How to: Use the Disassembly Window](https://docs.microsoft.com/visualstudio/debugger/how-to-use-the-disassembly-window)|  
|Use the **Modules** window to list and describe modules used by your program.|[How to: Use the Modules Window](https://docs.microsoft.com/visualstudio/debugger/how-to-use-the-modules-window)|  
|Use the **Script Explorer** window to list script files that are currently loaded into the program.|[How to: View Script Documents](https://docs.microsoft.com/visualstudio/debugger/how-to-view-script-documents)|  
|Use the **Threads** window to examine and control threads in the program.|[How to: Use the Threads Window](https://docs.microsoft.com/visualstudio/debugger/how-to-use-the-threads-window)|  
  
## See Also  
 [Walkthrough: Debugging a Windows Form](https://docs.microsoft.com/visualstudio/debugger/walkthrough-debugging-a-windows-form)   
 [Debugging Managed Code](https://docs.microsoft.com/visualstudio/debugger/debugging-managed-code)   
 [Debugging Native Code](https://docs.microsoft.com/visualstudio/debugger/debugging-native-code)   
 [Debugging Web Applications and Script](https://docs.microsoft.com/visualstudio/debugger/debugging-web-applications-and-script)   
 [Debugging User Interface Reference](https://docs.microsoft.com/visualstudio/debugger/debugging-user-interface-reference)   
 [Debugger Settings and Preparation](https://docs.microsoft.com/visualstudio/debugger/debugger-settings-and-preparation)   
 [Debugger Basics](https://docs.microsoft.com/visualstudio/debugger/debugger-basics)   
 [Navigating through Code with the Debugger](https://docs.microsoft.com/visualstudio/debugger/navigating-through-code-with-the-debugger)   
 [IntelliTrace](https://docs.microsoft.com/visualstudio/debugger/intellitrace)   
 [C#, F#, and Visual Basic Project Types](https://docs.microsoft.com/visualstudio/debugger/debugging-preparation-csharp-f-hash-and-visual-basic-project-types)