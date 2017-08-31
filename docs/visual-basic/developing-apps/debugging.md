---
title: "Debugging Your Visual Basic Application | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "debugging [Visual Basic], common tasks"
ms.assetid: 904760b8-9fe9-42a7-9d65-d93774253219
caps.latest.revision: 28
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Debugging Your Visual Basic Application
[!INCLUDE[vs2017banner](../../includes/vs2017banner.md)]

This page provides links to documentation for the debugging features that are built into [!INCLUDE[vsprvs](../../includes/vsprvs-md.md)]. For example, you can find semantic errors in your application by observing its run-time behavior in the debugger itself.  
  
 By using the debugger, you can examine the content of variables in your application without inserting additional calls to output the values. Similarly, you can insert a breakpoint in your code to halt execution at the point that you specify.  
  
## Controlling Execution  
 The following table lists debugging tasks involving execution control and provides links to their associated Help pages.  
  
|||  
|-|-|  
|To|See|  
|Start to debug a Visual Studio project, attach to a process, break into code, step through code, run to the cursor, run to a function on the call stack, set the next statement, step through Just My Code, stop debugging, restart debugging, or detach from a debugged process.|[Navigating through Code with the Debugger](/visual-studio/debugger/navigating-through-code-with-the-debugger)|  
|Specify the configurations for the debug and release versions of a program.|[Debug and Release Project Configurations](http://msdn.microsoft.com/en-us/0440b300-0614-4511-901a-105b771b236e)|  
|Set start options (command-line arguments, working directory, remote machine)|[NIB: How to: Set Start Options for Application Debugging](http://msdn.microsoft.com/en-us/ce792058-7bac-4dd6-858b-466e872687b8)|  
|Debug at design time.|[Walkthrough: Debugging at Design Time](../Topic/Walkthrough:%20Debugging%20at%20Design%20Time.md)|  
|Enable just-in-time debugging, which launches the Visual Studio debugger when a program running outside Visual Studio encounters a fatal error.|[Just-In-Time Debugging](/visual-studio/debugger/just-in-time-debugging-in-visual-studio)|  
|Set breakpoints for source lines, assembly instructions, and call stack function. Specify conditions, hit counts, and execution location.|[Using Breakpoints](/visual-studio/debugger/using-breakpoints)|  
  
## Handling Exceptions  
 The following table lists debugging tasks involving exception handling and points to their associated Help pages.  
  
|||  
|-|-|  
|To|See|  
|Break on unhandled exceptions.|[How to: Break on User-Unhandled Exceptions](../Topic/How%20to:%20Break%20on%20User-Unhandled%20Exceptions.md)|  
|Break when an exception is thrown.|[How to: Break When an Exception is Thrown](../Topic/How%20to:%20Break%20When%20an%20Exception%20is%20Thrown.md)|  
|Break on first-chance exceptions.|[How to: Break When an Exception is Thrown](../Topic/How%20to:%20Break%20When%20an%20Exception%20is%20Thrown.md)|  
|Use the exception assistant.|[How to: Correct Run-Time Errors with the Exception Assistant](../Topic/How%20to:%20Correct%20Run-Time%20Errors%20with%20the%20Exception%20Assistant.md)|  
|Add a new exception.|[How to: Add New Exceptions](../Topic/How%20to:%20Add%20New%20Exceptions.md)|  
|Continue execution after an exception has been thrown.|[Continuing Execution After an Exception](/visual-studio/debugger/continuing-execution-after-an-exception)|  
  
## Edit and Continue  
 The following table lists debugging tasks involving Edit and Continue and points to their associated Help pages.  
  
|||  
|-|-|  
|To|See|  
|Turn Edit and Continue off and on.|[How to: Enable and Disable Edit and Continue](../Topic/How%20to:%20Enable%20and%20Disable%20Edit%20and%20Continue.md)|  
|Stop Edit and Continue from applying code changes.|[How to: Stop Code Changes](../Topic/How%20to:%20Stop%20Code%20Changes.md)|  
|Apply edits in break mode.|[How to: Apply Edits in Break Mode with Edit and Continue](../Topic/How%20to:%20Apply%20Edits%20in%20Break%20Mode%20with%20Edit%20and%20Continue.md)|  
  
## Examining Debugging Data  
 The following table lists debugging tasks involving viewing debugging data and points to their associated Help pages.  
  
|||  
|-|-|  
|To|See|  
|Use the **Registers** window to display register contents.|[How to: Use the Registers Window](../Topic/How%20to:%20Use%20the%20Registers%20Window.md)|  
|Use the **Call Stack** window to view function or procedure calls that are currently on the stack.|[How to: Use the Call Stack Window](../Topic/How%20to:%20Use%20the%20Call%20Stack%20Window.md)|  
|Use the **Disassembly** window to view assembly code corresponding to the instructions created by the compiler.|[How to: Use the Disassembly Window](../Topic/How%20to:%20Use%20the%20Disassembly%20Window.md)|  
|Use the **Modules** window to list and describe modules used by your program.|[How to: Use the Modules Window](../Topic/How%20to:%20Use%20the%20Modules%20Window.md)|  
|Use the **Script Explorer** window to list script files that are currently loaded into the program.|[How to: View Script Documents](../Topic/How%20to:%20View%20Script%20Documents.md)|  
|Use the **Threads** window to examine and control threads in the program.|[How to: Use the Threads Window](../Topic/How%20to:%20Use%20the%20Threads%20Window.md)|  
  
## See Also  
 [Walkthrough: Debugging a Windows Form](../Topic/Walkthrough:%20Debugging%20a%20Windows%20Form.md)   
 [Debugging Managed Code](/visual-studio/debugger/debugging-managed-code)   
 [Debugging Native Code](/visual-studio/debugger/debugging-native-code)   
 [Debugging Web Applications and Script](/visual-studio/debugger/debugging-web-applications-and-script)   
 [Debugging User Interface Reference](/visual-studio/debugger/debugging-user-interface-reference)   
 [Debugger Settings and Preparation](/visual-studio/debugger/debugger-settings-and-preparation)   
 [Debugger Basics](/visual-studio/debugger/debugger-basics)   
 [Navigating through Code with the Debugger](/visual-studio/debugger/navigating-through-code-with-the-debugger)   
 [IntelliTrace](/visual-studio/debugger/intellitrace)   
 [C#, F#, and Visual Basic Project Types](../Topic/Debugging%20Preparation:%20C%23,%20F%23,%20and%20Visual%20Basic%20Project%20Types.md)   
 [How to: Apply Edits in Break Mode with Edit and Continue](../Topic/How%20to:%20Apply%20Edits%20in%20Break%20Mode%20with%20Edit%20and%20Continue.md)