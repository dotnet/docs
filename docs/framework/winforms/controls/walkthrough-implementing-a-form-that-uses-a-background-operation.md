---
title: "Walkthrough: Implementing a Form That Uses a Background Operation"
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
  - "cpp"
helpviewer_keywords: 
  - "threading [Windows Forms], forms"
  - "BackgroundWorker component"
  - "background tasks"
  - "forms [Windows Forms], multithreading"
  - "threading [Windows Forms], walkthroughs"
  - "forms [Windows Forms], background operations"
  - "threading [Windows Forms], background operations"
  - "background operations"
ms.assetid: 4691b796-9200-471a-89c3-ba4c7cc78c03
caps.latest.revision: 25
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Implementing a Form That Uses a Background Operation
If you have an operation that will take a long time to complete, and you do not want your user interface (UI) to stop responding or "hang," you can use the <xref:System.ComponentModel.BackgroundWorker> class to execute the operation on another thread.  
  
 This walkthrough illustrates how to use the <xref:System.ComponentModel.BackgroundWorker> class to perform time-consuming computations "in the background," while the user interface remains responsive.  When you are through, you will have an application that computes Fibonacci numbers asynchronously. Even though computing a large Fibonacci number can take a noticeable amount of time, the main UI thread will not be interrupted by this delay, and the form will be responsive during the calculation.  
  
 Tasks illustrated in this walkthrough include:  
  
-   Creating a Windows-based Application  
  
-   Creating a <xref:System.ComponentModel.BackgroundWorker> in Your Form  
  
-   Adding Asynchronous Event Handlers  
  
-   Adding Progress Reporting and Support for Cancellation  
  
 For a complete listing of the code used in this example, see [How to: Implement a Form That Uses a Background Operation](../../../../docs/framework/winforms/controls/how-to-implement-a-form-that-uses-a-background-operation.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
## Creating the Project  
 The first step is to create the project and to set up the form.  
  
#### To create a form that uses a background operation  
  
1.  Create a Windows-based application project called `BackgroundWorkerExample`. For details, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa).  
  
2.  In **Solution Explorer**, right-click **Form1** and select **Rename** from the shortcut menu. Change the file name to `FibonacciCalculator`. Click the **Yes** button when you are asked if you want to rename all references to the code element '`Form1`'.  
  
3.  Drag a <xref:System.Windows.Forms.NumericUpDown> control from the **Toolbox** onto the form. Set the <xref:System.Windows.Forms.NumericUpDown.Minimum%2A> property to `1` and the <xref:System.Windows.Forms.NumericUpDown.Maximum%2A> property to `91`.  
  
4.  Add two <xref:System.Windows.Forms.Button> controls to the form.  
  
5.  Rename the first <xref:System.Windows.Forms.Button> control `startAsyncButton` and set the <xref:System.Windows.Forms.Control.Text%2A> property to `Start Async`. Rename the second <xref:System.Windows.Forms.Button> control `cancelAsyncButton`, and set the <xref:System.Windows.Forms.Control.Text%2A> property to `Cancel Async`. Set its <xref:System.Windows.Forms.Control.Enabled%2A> property to `false`.  
  
6.  Create an event handler for both of the <xref:System.Windows.Forms.Button> controls' <xref:System.Windows.Forms.Control.Click> events. For details, see [How to: Create Event Handlers Using the Designer](http://msdn.microsoft.com/library/8461e9b8-14e8-406f-936e-3726732b23d2).  
  
7.  Drag a <xref:System.Windows.Forms.Label> control from the **Toolbox** onto the form and rename it `resultLabel`.  
  
8.  Drag a <xref:System.Windows.Forms.ProgressBar> control from the **Toolbox** onto the form.  
  
## Creating a BackgroundWorker in Your Form  
 You can create the <xref:System.ComponentModel.BackgroundWorker> for your asynchronous operation using the **Windows** **Forms Designer**.  
  
#### To create a BackgroundWorker with the Designer  
  
-   From the **Components** tab of the **Toolbox**, drag a <xref:System.ComponentModel.BackgroundWorker> onto the form.  
  
## Adding Asynchronous Event Handlers  
 You are now ready to add event handlers for the <xref:System.ComponentModel.BackgroundWorker> component's asynchronous events. The time-consuming operation that will run in the background, which computes Fibonacci numbers, is called by one of these event handlers.  
  
#### To implement asynchronous event handlers  
  
1.  In the **Properties** window, with the <xref:System.ComponentModel.BackgroundWorker> component still selected, click the **Events** button. Double-click the <xref:System.ComponentModel.BackgroundWorker.DoWork> and <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted> events to create event handlers. For more information about how to use event handlers, see [How to: Create Event Handlers Using the Designer](http://msdn.microsoft.com/library/8461e9b8-14e8-406f-936e-3726732b23d2).  
  
2.  Create a new method, called `ComputeFibonacci`, in your form. This method does the actual work, and it will run in the background. This code demonstrates the recursive implementation of the Fibonacci algorithm, which is notably inefficient, taking exponentially longer time to complete for larger numbers. It is used here for illustrative purposes, to show an operation that can introduce long delays in your application.  
  
     [!code-cpp[System.ComponentModel.BackgroundWorker#10](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CPP/fibonacciform.cpp#10)]
     [!code-csharp[System.ComponentModel.BackgroundWorker#10](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CS/fibonacciform.cs#10)]
     [!code-vb[System.ComponentModel.BackgroundWorker#10](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/VB/fibonacciform.vb#10)]  
  
3.  In the <xref:System.ComponentModel.BackgroundWorker.DoWork> event handler, add a call to the `ComputeFibonacci` method. Take the first parameter for `ComputeFibonacci` from the <xref:System.ComponentModel.DoWorkEventArgs.Argument%2A> property of the <xref:System.ComponentModel.DoWorkEventArgs>. The <xref:System.ComponentModel.BackgroundWorker> and <xref:System.ComponentModel.DoWorkEventArgs> parameters will be used later for progress reporting and cancellation support. Assign the return value from `ComputeFibonacci` to the <xref:System.ComponentModel.DoWorkEventArgs.Result%2A> property of the <xref:System.ComponentModel.DoWorkEventArgs>. This result will be available to the <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted> event handler.  
  
    > [!NOTE]
    >  The <xref:System.ComponentModel.BackgroundWorker.DoWork> event handler does not reference the `backgroundWorker1` instance variable directly, as this would couple this event handler to a specific instance of <xref:System.ComponentModel.BackgroundWorker>. Instead, a reference to the <xref:System.ComponentModel.BackgroundWorker> that raised this event is recovered from the `sender` parameter. This is important when the form hosts more than one <xref:System.ComponentModel.BackgroundWorker>. It is also important not to manipulate any user-interface objects in your <xref:System.ComponentModel.BackgroundWorker.DoWork> event handler. Instead, communicate to the user interface through the <xref:System.ComponentModel.BackgroundWorker> events.  
  
     [!code-cpp[System.ComponentModel.BackgroundWorker#5](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CPP/fibonacciform.cpp#5)]
     [!code-csharp[System.ComponentModel.BackgroundWorker#5](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CS/fibonacciform.cs#5)]
     [!code-vb[System.ComponentModel.BackgroundWorker#5](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/VB/fibonacciform.vb#5)]  
  
4.  In the `startAsyncButton` control's <xref:System.Windows.Forms.Control.Click> event handler, add the code that starts the asynchronous operation.  
  
     [!code-cpp[System.ComponentModel.BackgroundWorker#13](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CPP/fibonacciform.cpp#13)]
     [!code-csharp[System.ComponentModel.BackgroundWorker#13](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CS/fibonacciform.cs#13)]
     [!code-vb[System.ComponentModel.BackgroundWorker#13](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/VB/fibonacciform.vb#13)]  
  
5.  In the <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted> event handler, assign the result of the calculation to the `resultLabel` control.  
  
     [!code-cpp[System.ComponentModel.BackgroundWorker#6](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CPP/fibonacciform.cpp#6)]
     [!code-csharp[System.ComponentModel.BackgroundWorker#6](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CS/fibonacciform.cs#6)]
     [!code-vb[System.ComponentModel.BackgroundWorker#6](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/VB/fibonacciform.vb#6)]  
  
## Adding Progress Reporting and Support for Cancellation  
 For asynchronous operations that will take a long time, it is often desirable to report progress to the user and to allow the user to cancel the operation. The <xref:System.ComponentModel.BackgroundWorker> class provides an event that allows you to post progress as your background operation proceeds. It also provides a flag that allows your worker code to detect a call to <xref:System.ComponentModel.BackgroundWorker.CancelAsync%2A> and interrupt itself.  
  
#### To implement progress reporting  
  
1.  In the **Properties**, window, select `backgroundWorker1`. Set the <xref:System.ComponentModel.BackgroundWorker.WorkerReportsProgress%2A> and <xref:System.ComponentModel.BackgroundWorker.WorkerSupportsCancellation%2A> properties to `true`.  
  
2.  Declare two variables in the `FibonacciCalculator` form. These will be used to track progress.  
  
     [!code-cpp[System.ComponentModel.BackgroundWorker#14](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CPP/fibonacciform.cpp#14)]
     [!code-csharp[System.ComponentModel.BackgroundWorker#14](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CS/fibonacciform.cs#14)]
     [!code-vb[System.ComponentModel.BackgroundWorker#14](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/VB/fibonacciform.vb#14)]  
  
3.  Add an event handler for the <xref:System.ComponentModel.BackgroundWorker.ProgressChanged> event. In the <xref:System.ComponentModel.BackgroundWorker.ProgressChanged> event handler, update the <xref:System.Windows.Forms.ProgressBar> with the <xref:System.ComponentModel.ProgressChangedEventArgs.ProgressPercentage%2A> property of the <xref:System.ComponentModel.ProgressChangedEventArgs> parameter.  
  
     [!code-cpp[System.ComponentModel.BackgroundWorker#7](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CPP/fibonacciform.cpp#7)]
     [!code-csharp[System.ComponentModel.BackgroundWorker#7](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CS/fibonacciform.cs#7)]
     [!code-vb[System.ComponentModel.BackgroundWorker#7](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/VB/fibonacciform.vb#7)]  
  
#### To implement support for cancellation  
  
1.  In the `cancelAsyncButton` control's <xref:System.Windows.Forms.Control.Click> event handler, add the code that cancels the asynchronous operation.  
  
     [!code-cpp[System.ComponentModel.BackgroundWorker#4](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CPP/fibonacciform.cpp#4)]
     [!code-csharp[System.ComponentModel.BackgroundWorker#4](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CS/fibonacciform.cs#4)]
     [!code-vb[System.ComponentModel.BackgroundWorker#4](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/VB/fibonacciform.vb#4)]  
  
2.  The following code fragments in the `ComputeFibonacci` method report progress and support cancellation.  
  
     [!code-cpp[System.ComponentModel.BackgroundWorker#11](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CPP/fibonacciform.cpp#11)]
     [!code-csharp[System.ComponentModel.BackgroundWorker#11](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CS/fibonacciform.cs#11)]
     [!code-vb[System.ComponentModel.BackgroundWorker#11](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/VB/fibonacciform.vb#11)]  
    [!code-cpp[System.ComponentModel.BackgroundWorker#12](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CPP/fibonacciform.cpp#12)]
    [!code-csharp[System.ComponentModel.BackgroundWorker#12](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/CS/fibonacciform.cs#12)]
    [!code-vb[System.ComponentModel.BackgroundWorker#12](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker/VB/fibonacciform.vb#12)]  
  
## Checkpoint  
 At this point, you can compile and run the Fibonacci Calculator application.  
  
#### To test your project  
  
-   Press F5 to compile and run the application.  
  
     While the calculation is running in the background, you will see the <xref:System.Windows.Forms.ProgressBar> displaying the progress of the calculation toward completion. You can also cancel the pending operation.  
  
     For small numbers, the calculation should be very fast, but for larger numbers, you should see a noticeable delay. If you enter a value of 30 or greater, you should see a delay of several seconds, depending on the speed of your computer. For values greater than 40, it may take minutes or hours to finish the calculation. While the calculator is busy computing a large Fibonacci number, notice that you can freely move the form around, minimize, maximize, and even dismiss it. This is because the main UI thread is not waiting for the calculation to finish.  
  
## Next Steps  
 Now that you have implemented a form that uses a <xref:System.ComponentModel.BackgroundWorker> component to execute a computation in the background, you can explore other possibilities for asynchronous operations:  
  
-   Use multiple <xref:System.ComponentModel.BackgroundWorker> objects for several simultaneous operations.  
  
-   To debug your multithreaded application, see [How to: Use the Threads Window](/visualstudio/debugger/how-to-use-the-threads-window).  
  
-   Implement your own component that supports the asynchronous programming model. For more information, see [Event-based Asynchronous Pattern Overview](../../../../docs/standard/asynchronous-programming-patterns/event-based-asynchronous-pattern-overview.md).  
  
    > [!CAUTION]
    >  When using multithreading of any sort, you potentially expose yourself to very serious and complex bugs. Consult the [Managed Threading Best Practices](../../../../docs/standard/threading/managed-threading-best-practices.md) before implementing any solution that uses multithreading.  
  
## See Also  
 <xref:System.ComponentModel.BackgroundWorker>  
 [Managed Threading Best Practices](../../../../docs/standard/threading/managed-threading-best-practices.md)  
 [Multithreading in Components](http://msdn.microsoft.com/library/2fc31e68-fb71-4544-b654-0ce720478779)  
 [NOT IN BUILD: Multithreading in Visual Basic](http://msdn.microsoft.com/library/c731a50c-09c1-4468-9646-54c86b75d269)  
 [How to: Implement a Form That Uses a Background Operation](../../../../docs/framework/winforms/controls/how-to-implement-a-form-that-uses-a-background-operation.md)  
 [Walkthrough: Running an Operation in the Background](../../../../docs/framework/winforms/controls/walkthrough-running-an-operation-in-the-background.md)  
 [BackgroundWorker Component](../../../../docs/framework/winforms/controls/backgroundworker-component.md)
