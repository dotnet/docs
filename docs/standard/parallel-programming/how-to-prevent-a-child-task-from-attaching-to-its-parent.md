---
title: "How to: Prevent a Child Task from Attaching to its Parent"
ms.date: "03/30/2017"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "tasks, preventing attachments"
ms.assetid: c0fb85d4-9e80-4905-9f65-29acc54201c4
author: "rpetrusha"
ms.author: "ronpet"
---
# How to: Prevent a Child Task from Attaching to its Parent
This document demonstrates how to prevent a child task from attaching to the parent task. Preventing a child task from attaching to its parent is useful when you call a component that is written by a third party and that also uses tasks. For example, a third-party component that uses the <xref:System.Threading.Tasks.TaskCreationOptions.AttachedToParent?displayProperty=nameWithType> option to create a <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601> object can cause problems in your code if it is long-running or throws an unhandled exception.  
  
## Example  
 The following example compares the effects of using the default options to the effects of preventing a child task from attaching to the parent. The example creates a <xref:System.Threading.Tasks.Task> object that calls into a third-party library that also uses a <xref:System.Threading.Tasks.Task> object. The third-party library uses the <xref:System.Threading.Tasks.TaskCreationOptions.AttachedToParent> option to create the <xref:System.Threading.Tasks.Task> object. The application uses the <xref:System.Threading.Tasks.TaskCreationOptions.DenyChildAttach?displayProperty=nameWithType> option to create the parent task. This option instructs the runtime to remove the <xref:System.Threading.Tasks.TaskCreationOptions.AttachedToParent> specification in child tasks.  
  
 [!code-csharp[TPL_DenyChildAttach#1](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_denychildattach/cs/denychildattach.cs#1)]
 [!code-vb[TPL_DenyChildAttach#1](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_denychildattach/vb/denychildattach.vb#1)]  
  
 Because a parent task does not finish until all child tasks finish, a long-running child task can cause the overall application to perform poorly. In this example, when the application uses the default options to create the parent task, the child task must finish before the parent task finishes. When the application uses the <xref:System.Threading.Tasks.TaskCreationOptions.DenyChildAttach?displayProperty=nameWithType> option, the child is not attached to the parent. Therefore, the application can perform additional work after the parent task finishes and before it must wait for the child task to finish.  
  
## Compiling the Code  
 Copy the example code and paste it in a Visual Studio project, or paste it in a file that is named `DenyChildAttach.cs` (`DenyChildAttach.vb` for Visual Basic), and then run the following command in a Developer Command Prompt for Visual Studio window.  
  
 Visual C#  
  
 **csc.exe DenyChildAttach.cs**  
  
 Visual Basic  
  
 **vbc.exe DenyChildAttach.vb**  
  
## Robust Programming  
  
## See also

- [Task-based Asynchronous Programming](../../../docs/standard/parallel-programming/task-based-asynchronous-programming.md)
