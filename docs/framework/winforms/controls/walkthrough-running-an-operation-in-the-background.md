---
title: "Walkthrough: Running an Operation in the Background"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "background tasks"
  - "forms [Windows Forms], multithreading"
  - "forms [Windows Forms], background operations"
  - "background threads"
  - "BackgroundWorker class [Windows Forms], examples"
  - "threading [Windows Forms], background operations"
  - "background operations"
ms.assetid: 1b9a4e0a-f134-48ff-a1be-c461446a31ba
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Running an Operation in the Background
If you have an operation that will take a long time to complete, and you do not want to cause delays in your user interface, you can use the <xref:System.ComponentModel.BackgroundWorker> class to run the operation on another thread.  
  
 For a complete listing of the code used in this example, see [How to: Run an Operation in the Background](../../../../docs/framework/winforms/controls/how-to-run-an-operation-in-the-background.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To run an operation in the background  
  
1.  With your form active in the Windows Forms Designer, drag two <xref:System.Windows.Forms.Button> controls from the **Toolbox** to the form, and then set the `Name` and <xref:System.Windows.Forms.Control.Text%2A> properties of the buttons according to the following table.  
  
    |Button|Name|Text|  
    |------------|----------|----------|  
    |`button1`|`startBtn`|**Start**|  
    |`button2`|`cancelBtn`|**Cancel**|  
  
2.  Open the **Toolbox**, click the **Components** tab, and then drag the <xref:System.ComponentModel.BackgroundWorker> component onto your form.  
  
     The `backgroundWorker1` component appears in the **Component Tray**.  
  
3.  In the **Properties** window, set the <xref:System.ComponentModel.BackgroundWorker.WorkerSupportsCancellation%2A> property to `true`.  
  
4.  In the **Properties** window, click on the **Events** button, and then double-click the <xref:System.ComponentModel.BackgroundWorker.DoWork> and <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted> events to create event handlers.  
  
5.  Insert your time-consuming code into the <xref:System.ComponentModel.BackgroundWorker.DoWork> event handler.  
  
6.  Extract any parameters required by the operation from the <xref:System.ComponentModel.DoWorkEventArgs.Argument%2A> property of the <xref:System.ComponentModel.DoWorkEventArgs> parameter.  
  
7.  Assign the result of the computation to the <xref:System.ComponentModel.DoWorkEventArgs.Result%2A> property of the <xref:System.ComponentModel.DoWorkEventArgs>.  
  
     This is will be available to the <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted> event handler.  
  
     [!code-csharp[System.ComponentModel.BackgroundWorker.Example#2](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.Example/CS/Form1.cs#2)]
     [!code-vb[System.ComponentModel.BackgroundWorker.Example#2](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.Example/VB/Form1.vb#2)]  
  
8.  Insert code for retrieving the result of your operation in the <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted> event handler.  
  
     [!code-csharp[System.ComponentModel.BackgroundWorker.Example#3](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.Example/CS/Form1.cs#3)]
     [!code-vb[System.ComponentModel.BackgroundWorker.Example#3](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.Example/VB/Form1.vb#3)]  
  
9. Implement the `TimeConsumingOperation` method.  
  
     [!code-csharp[System.ComponentModel.BackgroundWorker.Example#4](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.Example/CS/Form1.cs#4)]
     [!code-vb[System.ComponentModel.BackgroundWorker.Example#4](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.Example/VB/Form1.vb#4)]  
  
10. In the Windows Forms Designer, double-click `startButton` to create the <xref:System.Windows.Forms.Control.Click> event handler.  
  
11. Call the <xref:System.ComponentModel.BackgroundWorker.RunWorkerAsync%2A> method in the <xref:System.Windows.Forms.Control.Click> event handler for `startButton`.  
  
     [!code-csharp[System.ComponentModel.BackgroundWorker.Example#5](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.Example/CS/Form1.cs#5)]
     [!code-vb[System.ComponentModel.BackgroundWorker.Example#5](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.Example/VB/Form1.vb#5)]  
  
12. In the Windows Forms Designer, double-click `cancelButton` to create the <xref:System.Windows.Forms.Control.Click> event handler.  
  
13. Call the <xref:System.ComponentModel.BackgroundWorker.CancelAsync%2A> method in the <xref:System.Windows.Forms.Control.Click> event handler for `cancelButton`.  
  
     [!code-csharp[System.ComponentModel.BackgroundWorker.Example#6](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.Example/CS/Form1.cs#6)]
     [!code-vb[System.ComponentModel.BackgroundWorker.Example#6](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.Example/VB/Form1.vb#6)]  
  
14. At the top of the file, import the System.ComponentModel and System.Threading namespaces.  
  
     [!code-csharp[System.ComponentModel.BackgroundWorker.Example#7](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.Example/CS/Form1.cs#7)]
     [!code-vb[System.ComponentModel.BackgroundWorker.Example#7](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.Example/VB/Form1.vb#7)]  
  
15. Press F6 to build the solution, and then press CTRL-F5 to run the application outside the debugger.  
  
> [!NOTE]
>  If you press F5 to run the application under the debugger, the exception raised in the `TimeConsumingOperation` method is caught and displayed by the debugger. When you run the application outside the debugger, the <xref:System.ComponentModel.BackgroundWorker> handles the exception and caches it in the <xref:System.ComponentModel.AsyncCompletedEventArgs.Error%2A> property of the <xref:System.ComponentModel.RunWorkerCompletedEventArgs>.  
  
1.  Click the **Start** button to run an asynchronous operation, and then click the **Cancel** button to stop a running asynchronous operation.  
  
     The outcome of each operation is displayed in a <xref:System.Windows.Forms.MessageBox>.  
  
## Next Steps  
  
-   Implement a form that reports progress as an asynchronous operation proceeds. For more information, see [How to: Implement a Form That Uses a Background Operation](../../../../docs/framework/winforms/controls/how-to-implement-a-form-that-uses-a-background-operation.md).  
  
-   Implement a class that supports the Asynchronous Pattern for Components. For more information, see [Implementing the Event-based Asynchronous Pattern](../../../../docs/standard/asynchronous-programming-patterns/implementing-the-event-based-asynchronous-pattern.md).  
  
## See Also  
 <xref:System.ComponentModel.BackgroundWorker>  
 <xref:System.ComponentModel.DoWorkEventArgs>  
 [How to: Implement a Form That Uses a Background Operation](../../../../docs/framework/winforms/controls/how-to-implement-a-form-that-uses-a-background-operation.md)  
 [How to: Run an Operation in the Background](../../../../docs/framework/winforms/controls/how-to-run-an-operation-in-the-background.md)  
 [BackgroundWorker Component](../../../../docs/framework/winforms/controls/backgroundworker-component.md)
