---
title: "How to: Implement a Form That Uses a Background Operation"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "threading [Windows Forms], forms"
  - "BackgroundWorker component"
  - "background tasks"
  - "forms [Windows Forms], multithreading"
  - "components [Windows Forms], asynchronous"
  - "forms [Windows Forms], background operations"
  - "background threads"
  - "threading [Windows Forms], background operations"
  - "background operations"
ms.assetid: 9f483f93-1613-4be1-a021-b4934e9c78f3
---
# How to: Implement a Form That Uses a Background Operation
The following example program creates a form that calculates Fibonacci numbers. The calculation runs on a thread that is separate from the user interface thread, so the user interface continues to run without delays as the calculation proceeds.  
  
 There is extensive support for this task in Visual Studio.  
  
 Also see [Walkthrough: Implementing a Form That Uses a Background Operation](walkthrough-implementing-a-form-that-uses-a-background-operation.md).  
  
## Example  
 [!code-cpp[System.ComponentModel.BackgroundWorker#1](~/samples/snippets/cpp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CPP/fibonacciform.cpp#1)]
 [!code-csharp[System.ComponentModel.BackgroundWorker#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CS/fibonacciform.cs#1)]
 [!code-vb[System.ComponentModel.BackgroundWorker#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/VB/fibonacciform.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System, System.Drawing, and System.Windows.Forms assemblies.  
  
## Robust Programming  
  
> [!CAUTION]
> When using multithreading of any sort, you potentially expose yourself to very serious and complex bugs. Consult the [Managed Threading Best Practices](../../../standard/threading/managed-threading-best-practices.md) before implementing any solution that uses multithreading.  
  
## See also

- <xref:System.ComponentModel.BackgroundWorker>
- <xref:System.ComponentModel.DoWorkEventArgs>
- [Event-based Asynchronous Pattern Overview](../../../standard/asynchronous-programming-patterns/event-based-asynchronous-pattern-overview.md)
- [Managed Threading Best Practices](../../../standard/threading/managed-threading-best-practices.md)
