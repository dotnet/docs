---
title: "Event-based Asynchronous Pattern Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Event-based Asynchronous Pattern"
  - "ProgressChangedEventArgs class"
  - "BackgroundWorker component"
  - "events [.NET Framework], asynchronous"
  - "Asynchronous Pattern"
  - "AsyncOperationManager class"
  - "threading [.NET Framework], asynchronous features"
  - "AsyncOperation class"
  - "AsyncCompletedEventArgs class"
ms.assetid: 792aa8da-918b-458e-b154-9836b97735f3
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Event-based Asynchronous Pattern Overview
Applications that perform many tasks simultaneously, yet remain responsive to user interaction, often require a design that uses multiple threads. The <xref:System.Threading> namespace provides all the tools necessary to create high-performance multithreaded applications, but using these tools effectively requires significant experience with multithreaded software engineering. For relatively simple multithreaded applications, the <xref:System.ComponentModel.BackgroundWorker> component provides a straightforward solution. For more sophisticated asynchronous applications, consider implementing a class that adheres to the Event-based Asynchronous Pattern.  
  
 The Event-based Asynchronous Pattern makes available the advantages of multithreaded applications while hiding many of the complex issues inherent in multithreaded design. Using a class that supports this pattern can allow you to:  
  
-   Perform time-consuming tasks, such as downloads and database operations, "in the background," without interrupting your application.  
  
-   Execute multiple operations simultaneously, receiving notifications when each completes.  
  
-   Wait for resources to become available without stopping ("hanging") your application.  
  
-   Communicate with pending asynchronous operations using the familiar events-and-delegates model. For more information on using event handlers and delegates, see [Events](../../../docs/standard/events/index.md).  
  
 A class that supports the Event-based Asynchronous Pattern will have one or more methods named *MethodName***Async**. These methods may mirror synchronous versions, which perform the same operation on the current thread. The class may also have a *MethodName***Completed** event and it may have a *MethodName***AsyncCancel** (or simply **CancelAsync**) method.  
  
 <xref:System.Windows.Forms.PictureBox> is a typical component that supports the Event-based Asynchronous Pattern. You can download an image synchronously by calling its <xref:System.Windows.Forms.PictureBox.Load%2A> method, but if the image is large, or if the network connection is slow, your application will stop ("hang") until the download operation is completed and the call to <xref:System.Windows.Forms.PictureBox.Load%2A> returns.  
  
 If you want your application to keep running while the image is loading, you can call the <xref:System.Windows.Forms.PictureBox.LoadAsync%2A> method and handle the <xref:System.Windows.Forms.PictureBox.LoadCompleted> event, just as you would handle any other event. When you call the <xref:System.Windows.Forms.PictureBox.LoadAsync%2A> method, your application will continue to run while the download proceeds on a separate thread ("in the background"). Your event handler will be called when the image-loading operation is complete, and your event handler can examine the <xref:System.ComponentModel.AsyncCompletedEventArgs> parameter to determine if the download completed successfully.  
  
 The Event-based Asynchronous Pattern requires that an asynchronous operation can be canceled, and the <xref:System.Windows.Forms.PictureBox> control supports this requirement with its <xref:System.Windows.Forms.PictureBox.CancelAsync%2A> method. Calling <xref:System.Windows.Forms.PictureBox.CancelAsync%2A> submits a request to stop the pending download, and when the task is canceled, the <xref:System.Windows.Forms.PictureBox.LoadCompleted> event is raised.  
  
> [!CAUTION]
>  It is possible that the download will finish just as the <xref:System.Windows.Forms.PictureBox.CancelAsync%2A> request is made, so <xref:System.ComponentModel.AsyncCompletedEventArgs.Cancelled%2A> may not reflect the request to cancel. This is called a *race condition* and is a common issue in multithreaded programming. For more information on issues in multithreaded programming, see [Managed Threading Best Practices](../../../docs/standard/threading/managed-threading-best-practices.md).  
  
## Characteristics of the Event-based Asynchronous Pattern  
 The Event-based Asynchronous Pattern may take several forms, depending on the complexity of the operations supported by a particular class. The simplest classes may have a single *MethodName***Async** method and a corresponding *MethodName***Completed** event. More complex classes may have several *MethodName***Async** methods, each with a corresponding *MethodName***Completed** event, as well as synchronous versions of these methods. Classes can optionally support cancellation, progress reporting, and incremental results for each asynchronous method.  
  
 An asynchronous method may also support multiple pending calls (multiple concurrent invocations), allowing your code to call it any number of times before it completes other pending operations. Correctly handling this situation may require your application to track the completion of each operation.  
  
### Examples of the Event-based Asynchronous Pattern  
 The <xref:System.Media.SoundPlayer> and <xref:System.Windows.Forms.PictureBox> components represent simple implementations of the Event-based Asynchronous Pattern. The <xref:System.Net.WebClient> and <xref:System.ComponentModel.BackgroundWorker> components represent more complex implementations of the Event-based Asynchronous Pattern.  
  
 Below is an example class declaration that conforms to the pattern:  
  
```vb  
Public Class AsyncExample  
    ' Synchronous methods.  
    Public Function Method1(ByVal param As String) As Integer   
    Public Sub Method2(ByVal param As Double)   
  
    ' Asynchronous methods.  
    Overloads Public Sub Method1Async(ByVal param As String)   
    Overloads Public Sub Method1Async(ByVal param As String, ByVal userState As Object)   
    Public Event Method1Completed As Method1CompletedEventHandler  
  
    Overloads Public Sub Method2Async(ByVal param As Double)   
    Overloads Public Sub Method2Async(ByVal param As Double, ByVal userState As Object)   
    Public Event Method2Completed As Method2CompletedEventHandler  
  
    Public Sub CancelAsync(ByVal userState As Object)   
  
    Public ReadOnly Property IsBusy () As Boolean  
  
    ' Class implementation not shown.  
End Class  
```  
  
```csharp  
public class AsyncExample  
{  
    // Synchronous methods.  
    public int Method1(string param);  
    public void Method2(double param);  
  
    // Asynchronous methods.  
    public void Method1Async(string param);  
    public void Method1Async(string param, object userState);  
    public event Method1CompletedEventHandler Method1Completed;  
  
    public void Method2Async(double param);  
    public void Method2Async(double param, object userState);  
    public event Method2CompletedEventHandler Method2Completed;  
  
    public void CancelAsync(object userState);  
  
    public bool IsBusy { get; }  
  
    // Class implementation not shown.  
}  
```  
  
 The fictitious `AsyncExample` class has two methods, both of which support synchronous and asynchronous invocations. The synchronous overloads behave like any method call and execute the operation on the calling thread; if the operation is time-consuming, there may be a noticeable delay before the call returns. The asynchronous overloads will start the operation on another thread and then return immediately, allowing the calling thread to continue while the operation executes "in the background."  
  
### Asynchronous Method Overloads  
 There are potentially two overloads for the asynchronous operations: single-invocation and multiple-invocation. You can distinguish these two forms by their method signatures: the multiple-invocation form has an extra parameter called `userState`. This form makes it possible for your code to call `Method1Async(string param, object userState)` multiple times without waiting for any pending asynchronous operations to finish. If, on the other hand, you try to call `Method1Async(string param)` before a previous invocation has completed, the method raises an <xref:System.InvalidOperationException>.  
  
 The `userState` parameter for the multiple-invocation overloads allows you to distinguish among asynchronous operations. You provide a unique value (for example, a GUID or hash code) for each call to `Method1Async(string param, object userState)`, and when each operation is completed, your event handler can determine which instance of the operation raised the completion event.  
  
### Tracking Pending Operations  
 If you use the multiple-invocation overloads, your code will need to keep track of the `userState` objects (task IDs) for pending tasks. For each call to `Method1Async(string param, object userState)`, you will typically generate a new, unique `userState` object and add it to a collection. When the task corresponding to this `userState` object raises the completion event, your completion method implementation will examine <xref:System.ComponentModel.AsyncCompletedEventArgs.UserState%2A?displayProperty=nameWithType> and remove it from your collection. Used this way, the `userState` parameter takes the role of a task ID.  
  
> [!NOTE]
>  You must be careful to provide a unique value for `userState` in your calls to multiple-invocation overloads. Non-unique task IDs will cause the asynchronous class throw an <xref:System.ArgumentException>.  
  
### Canceling Pending Operations  
 It is important to be able to cancel asynchronous operations at any time before their completion. Classes that implement the Event-based Asynchronous Pattern will have a `CancelAsync` method (if there is only one asynchronous method) or a *MethodName***AsyncCancel** method (if there are multiple asynchronous methods).  
  
 Methods that allow multiple invocations take a `userState` parameter, which can be used to track the lifetime of each task. `CancelAsync` takes a `userState` parameter, which allows you to cancel particular pending tasks.  
  
 Methods that support only a single pending operation at a time, like `Method1Async(string param)`, are not cancelable.  
  
### Receiving Progress Updates and Incremental Results  
 A class that adheres to the Event-based Asynchronous Pattern may optionally provide an event for tracking progress and incremental results. This will typically be named `ProgressChanged` or *MethodName***ProgressChanged**, and its corresponding event handler will take a <xref:System.ComponentModel.ProgressChangedEventArgs> parameter.  
  
 The event handler for the `ProgressChanged` event can examine the <xref:System.ComponentModel.ProgressChangedEventArgs.ProgressPercentage%2A?displayProperty=nameWithType> property to determine what percentage of an asynchronous task has been completed. This property will range from 0 to 100, and it can be used to update the <xref:System.Windows.Forms.ProgressBar.Value%2A> property of a <xref:System.Windows.Forms.ProgressBar>. If multiple asynchronous operations are pending, you can use the <xref:System.ComponentModel.ProgressChangedEventArgs.UserState%2A?displayProperty=nameWithType> property to distinguish which operation is reporting progress.  
  
 Some classes may report incremental results as asynchronous operations proceed. These results will be stored in a class that derives from <xref:System.ComponentModel.ProgressChangedEventArgs> and they will appear as properties in the derived class. You can access these results in the event handler for the `ProgressChanged` event, just as you would access the <xref:System.ComponentModel.ProgressChangedEventArgs.ProgressPercentage%2A> property. If multiple asynchronous operations are pending, you can use the <xref:System.ComponentModel.ProgressChangedEventArgs.UserState%2A> property to distinguish which operation is reporting incremental results.  
  
## See Also  
 <xref:System.ComponentModel.ProgressChangedEventArgs>  
 <xref:System.ComponentModel.BackgroundWorker>  
 <xref:System.ComponentModel.AsyncCompletedEventArgs>  
 [How to: Use Components That Support the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/how-to-use-components-that-support-the-event-based-asynchronous-pattern.md)  
 [How to: Run an Operation in the Background](../../../docs/framework/winforms/controls/how-to-run-an-operation-in-the-background.md)  
 [How to: Implement a Form That Uses a Background Operation](../../../docs/framework/winforms/controls/how-to-implement-a-form-that-uses-a-background-operation.md)  
 [Multithreaded Programming with the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/multithreaded-programming-with-the-event-based-asynchronous-pattern.md)  
 [Best Practices for Implementing the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/best-practices-for-implementing-the-event-based-asynchronous-pattern.md)  
 [Deciding When to Implement the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/deciding-when-to-implement-the-event-based-asynchronous-pattern.md)
