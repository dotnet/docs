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
|Debug at design time.|[Walkthrough: Debugging at Design Time](http://msdn.microsoft.com/library/35bfdd2c-6f60-4be1-ba9d-55fce70ee4d8)|  
|Enable just-in-time debugging, which launches the Visual Studio debugger when a program running outside Visual Studio encounters a fatal error.|[Just-In-Time Debugging](/visual-studio/debugger/just-in-time-debugging-in-visual-studio)|  
|Set breakpoints for source lines, assembly instructions, and call stack function. Specify conditions, hit counts, and execution location.|[Using Breakpoints](/visual-studio/debugger/using-breakpoints)|  
  
## Handling Exceptions  
 The following table lists debugging tasks involving exception handling and points to their associated Help pages.  
  
|||  
|-|-|  
|To|See|  
|Break on unhandled exceptions.|[How to: Break on User-Unhandled Exceptions](http://msdn.microsoft.com/library/4fc34fb2-9eae-4b36-aaa5-ed32dbc2bb9a)|  
|Break when an exception is thrown.|[How to: Break When an Exception is Thrown](http://msdn.microsoft.com/library/4bc7a048-78fb-4a4a-9b17-9912da6613a4)|  
|Break on first-chance exceptions.|[How to: Break When an Exception is Thrown](http://msdn.microsoft.com/library/4bc7a048-78fb-4a4a-9b17-9912da6613a4)|  
|Use the exception assistant.|[How to: Correct Run-Time Errors with the Exception Assistant](http://msdn.microsoft.com/library/23b08d45-7b20-42c9-bdc9-fb3157ad823b)|  
|Add a new exception.|[How to: Add New Exceptions](http://msdn.microsoft.com/library/354ef787-f8aa-4638-9fa8-75d34c793a4d)|  
|Continue execution after an exception has been thrown.|[Continuing Execution After an Exception](/visual-studio/debugger/continuing-execution-after-an-exception)|  
  
## Edit and Continue  
 The following table lists debugging tasks involving Edit and Continue and points to their associated Help pages.  
  
|||  
|-|-|  
|To|See|  
|Turn Edit and Continue off and on.|[How to: Enable and Disable Edit and Continue](http://msdn.microsoft.com/library/fd961a1c-76fa-420d-ad8f-c1a6c003b0db)|  
|Stop Edit and Continue from applying code changes.|[How to: Stop Code Changes](http://msdn.microsoft.com/library/9e72a50c-bb0a-4eaa-9ac1-d00930b68d38)|  
|Apply edits in break mode.|[How to: Apply Edits in Break Mode with Edit and Continue](http://msdn.microsoft.com/library/1eef7498-6a1f-4fba-8146-510adc6375c9)|  
  
## Examining Debugging Data  
 The following table lists debugging tasks involving viewing debugging data and points to their associated Help pages.  
  
|||  
|-|-|  
|To|See|  
|Use the **Registers** window to display register contents.|[How to: Use the Registers Window](http://msdn.microsoft.com/library/2918ffa2-562f-40d6-9053-ef321bbeb767)|  
|Use the **Call Stack** window to view function or procedure calls that are currently on the stack.|[How to: Use the Call Stack Window](http://msdn.microsoft.com/library/5154a2a1-4729-4dbb-b675-db611a72a731)|  
|Use the **Disassembly** window to view assembly code corresponding to the instructions created by the compiler.|[How to: Use the Disassembly Window](http://msdn.microsoft.com/library/eaf84dd0-c82d-481b-af51-690b74e7794c)|  
|Use the **Modules** window to list and describe modules used by your program.|[How to: Use the Modules Window](http://msdn.microsoft.com/library/d840fdca-b035-4452-b652-72580c831896)|  
|Use the **Script Explorer** window to list script files that are currently loaded into the program.|[How to: View Script Documents](http://msdn.microsoft.com/library/8b621e53-4508-4b4a-9995-70995b0b9ac8)|  
|Use the **Threads** window to examine and control threads in the program.|[How to: Use the Threads Window](http://msdn.microsoft.com/library/adfbe002-3d7b-42a9-b42a-5ac0903dfc25)|  
  
## See Also  
 [Walkthrough: Debugging a Windows Form](http://msdn.microsoft.com/library/529db1e2-d9ea-482a-b6a0-7c543d17f114)   
 [Debugging Managed Code](/visual-studio/debugger/debugging-managed-code)   
 [Debugging Native Code](/visual-studio/debugger/debugging-native-code)   
 [Debugging Web Applications and Script](/visual-studio/debugger/debugging-web-applications-and-script)   
 [Debugging User Interface Reference](/visual-studio/debugger/debugging-user-interface-reference)   
 [Debugger Settings and Preparation](/visual-studio/debugger/debugger-settings-and-preparation)   
 [Debugger Basics](/visual-studio/debugger/debugger-basics)   
 [Navigating through Code with the Debugger](/visual-studio/debugger/navigating-through-code-with-the-debugger)   
 [IntelliTrace](/visual-studio/debugger/intellitrace)   
 [C#, F#, and Visual Basic Project Types](http://msdn.microsoft.com/library/7a0535f6-1cd4-4b51-ad34-f4a45b9f1ce3)   
 [How to: Apply Edits in Break Mode with Edit and Continue](http://msdn.microsoft.com/library/1eef7498-6a1f-4fba-8146-510adc6375c9)