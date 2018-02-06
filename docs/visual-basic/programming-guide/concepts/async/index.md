---
title: "Asynchronous Programming with Async and Await (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bd7e462b-583b-4395-9c36-45aa9e61072c
caps.latest.revision: 4
author: dotnet-bot
ms.author: dotnetcontent
---
# Asynchronous Programming with Async and Await (Visual Basic)
You can avoid performance bottlenecks and enhance the overall responsiveness of your application by using asynchronous programming. However, traditional techniques for writing asynchronous applications can be complicated, making them difficult to write, debug, and maintain.  
  
 Visual Studio 2012 introduced a simplified approach, async programming, that leverages asynchronous support in the .NET Framework 4.5 and higher as well as  in the Windows Runtime. The compiler does the difficult work that the developer used to do, and your application retains a logical structure that resembles synchronous code. As a result, you get all the advantages of asynchronous programming with a fraction of the effort.  
  
 This topic provides an overview of when and how to use async programming and includes links to support topics that contain details and examples.  
  
##  <a name="BKMK_WhentoUseAsynchrony"></a> Async Improves Responsiveness  
 Asynchrony is essential for activities that are potentially blocking, such as when your application accesses the web. Access to a web resource sometimes is slow or delayed. If such an activity is blocked within a synchronous process, the entire application must wait. In an asynchronous process, the application can continue with other work that doesn't depend on the web resource until the potentially blocking task finishes.  
  
 The following table shows typical areas where asynchronous programming improves responsiveness. The listed APIs from the  .NET Framework 4.5 and the Windows Runtime contain methods that support async programming.  
  
|Application area|Supporting APIs that contain async methods|  
|----------------------|------------------------------------------------|  
|Web access|<xref:System.Net.Http.HttpClient>, [SyndicationClient](http://go.microsoft.com/fwlink/p/?LinkId=259441)|  
|Working with files|[StorageFile](http://go.microsoft.com/fwlink/p/?LinkId=248220), <xref:System.IO.StreamWriter>, <xref:System.IO.StreamReader>, <xref:System.Xml.XmlReader>|  
|Working with images|[MediaCapture](http://go.microsoft.com/fwlink/p/?LinkId=261839), [BitmapEncoder](http://go.microsoft.com/fwlink/p/?LinkId=261840), [BitmapDecoder](http://go.microsoft.com/fwlink/p/?LinkId=261841)|  
|WCF programming|[Synchronous and Asynchronous Operations](http://go.microsoft.com/fwlink/p/?LinkID=192382)|  
|||  
  
 Asynchrony proves especially valuable for applications that access the UI thread because all UI-related activity usually shares one thread. If any process is blocked in a synchronous application, all are blocked. Your application stops responding, and you might conclude that it has failed when instead it's just waiting.  
  
 When you use asynchronous methods, the application continues to respond to the UI. You can resize or minimize a window, for example, or you can close the application if you don't want to wait for it to finish.  
  
 The async-based approach adds the equivalent of an automatic transmission to the list of options that you can choose from when designing asynchronous operations. That is, you get all the benefits of traditional asynchronous programming but with much less effort from the developer.  
  
##  <a name="BKMK_HowtoWriteanAsyncMethod"></a> Async Methods Are Easier to Write  
 The [Async](../../../../visual-basic/language-reference/modifiers/async.md) and [Await](../../../../visual-basic/language-reference/modifiers/async.md) keywords in Visual Basic are the heart of async programming. By using those two keywords, you can use resources in the .NET Framework or the Windows Runtime to create an asynchronous method almost as easily as you create a synchronous method. Asynchronous methods that you define by using `Async` and `Await` are referred to as async methods.  
  
 The following example shows an async method. Almost everything in the code should look completely familiar to you. The comments call out the features that you add to create the asynchrony.  
  
 You can find a complete Windows Presentation Foundation (WPF) example file at the end of this topic, and you can download the sample from [Async Sample: Example from "Asynchronous Programming with Async and Await"](http://go.microsoft.com/fwlink/?LinkID=261549).  
  
```vb  
' Three things to note in the signature:  
'  - The method has an Async modifier.   
'  - The return type is Task or Task(Of T). (See "Return Types" section.)  
'    Here, it is Task(Of Integer) because the return statement returns an integer.  
'  - The method name ends in "Async."  
Async Function AccessTheWebAsync() As Task(Of Integer)  
  
    ' You need to add a reference to System.Net.Http to declare client.  
    Dim client As HttpClient = New HttpClient()  
  
    ' GetStringAsync returns a Task(Of String). That means that when you await the  
    ' task you'll get a string (urlContents).  
    Dim getStringTask As Task(Of String) = client.GetStringAsync("http://msdn.microsoft.com")  
  
    ' You can do work here that doesn't rely on the string from GetStringAsync.  
    DoIndependentWork()  
  
    ' The Await operator suspends AccessTheWebAsync.  
    '  - AccessTheWebAsync can't continue until getStringTask is complete.  
    '  - Meanwhile, control returns to the caller of AccessTheWebAsync.  
    '  - Control resumes here when getStringTask is complete.   
    '  - The Await operator then retrieves the string result from getStringTask.  
    Dim urlContents As String = Await getStringTask  
  
    ' The return statement specifies an integer result.  
    ' Any methods that are awaiting AccessTheWebAsync retrieve the length value.  
    Return urlContents.Length  
End Function  
```  
  
 If `AccessTheWebAsync` doesn't have any work that it can do between calling `GetStringAsync` and awaiting its completion, you can simplify your code by calling and awaiting in the following single statement.  
  
```vb  
Dim urlContents As String = Await client.GetStringAsync()  
```  
  
 The following characteristics summarize what makes the previous example an async method.  
  
-   The method signature includes an `Async` modifier.  
  
-   The name of an async method, by convention, ends with an "Async" suffix.  
  
-   The return type is one of the following types:  
  
    -   <xref:System.Threading.Tasks.Task%601> if your method has a return statement in which the operand has type TResult.  
  
    -   <xref:System.Threading.Tasks.Task> if your method has no return statement or has a return statement with no operand.  
  
    -   [Sub](../../../../visual-basic/programming-guide/language-features/procedures/sub-procedures.md) if you're writing an async event handler.  
  
     For more information, see "Return Types and Parameters" later in this topic.  
  
-   The method usually includes at least one await expression, which marks a point where the method can't continue until the awaited asynchronous operation is complete. In the meantime, the method is suspended, and control returns to the method's caller. The next section of this topic illustrates what happens at the suspension point.  
  
 In async methods, you use the provided keywords and types to indicate what you want to do, and the compiler does the rest, including keeping track of what must happen when control returns to an await point in a suspended method. Some routine processes, such as loops and exception handling, can be difficult to handle in traditional asynchronous code. In an async method, you write these elements much as you would in a synchronous solution, and the problem is solved.  
  
 For more information about asynchrony in previous versions of the .NET Framework, see [TPL and Traditional .NET Framework Asynchronous Programming](http://msdn.microsoft.com/library/e7b31170-a156-433f-9f26-b1fc7cd1776f).  
  
##  <a name="BKMK_WhatHappensUnderstandinganAsyncMethod"></a> What Happens in an Async Method  
 The most important thing to understand in asynchronous programming is how the control flow moves from method to method. The following diagram leads you through the process.  
  
 ![Trace an async program](../../../../csharp/programming-guide/concepts/async/media/navigationtrace.png "NavigationTrace")  
  
 The numbers in the diagram correspond to the following steps.  
  
1.  An event handler calls and awaits  the  `AccessTheWebAsync` async method.  
  
2.  `AccessTheWebAsync` creates an <xref:System.Net.Http.HttpClient> instance and calls the <xref:System.Net.Http.HttpClient.GetStringAsync%2A> asynchronous method to download the contents of a website as a string.  
  
3.  Something happens in `GetStringAsync` that suspends its progress. Perhaps it must wait for a website to download or some other blocking activity. To avoid blocking resources, `GetStringAsync` yields control to its caller, `AccessTheWebAsync`.  
  
     `GetStringAsync` returns a <xref:System.Threading.Tasks.Task%601> where TResult is a string, and `AccessTheWebAsync` assigns the task to the `getStringTask` variable. The task represents the ongoing process for the call to `GetStringAsync`, with a commitment to produce an actual string value when the work is complete.  
  
4.  Because `getStringTask` hasn't been awaited yet, `AccessTheWebAsync` can continue with other work that doesn't depend on the final result from `GetStringAsync`. That work is represented by a call to the synchronous method `DoIndependentWork`.  
  
5.  `DoIndependentWork` is a synchronous method that does its work and returns to its caller.  
  
6.  `AccessTheWebAsync` has run out of work that it can do without a result from `getStringTask`. `AccessTheWebAsync` next wants to calculate and return the length of the downloaded string, but the method can't calculate that value until the method has the string.  
  
     Therefore, `AccessTheWebAsync` uses an await operator to suspend its progress and to yield control to the method that called `AccessTheWebAsync`. `AccessTheWebAsync` returns a `Task<int>` (`Task(Of Integer)` in Visual Basic) to the caller. The task represents a promise to produce an integer result that's the length of the downloaded string.  
  
    > [!NOTE]
    >  If `GetStringAsync` (and therefore `getStringTask`) is complete before `AccessTheWebAsync` awaits it, control remains in `AccessTheWebAsync`. The expense of suspending and then returning to `AccessTheWebAsync` would be wasted if the called asynchronous process (`getStringTask`) has already completed and AccessTheWebSync doesn't have to wait for the final result.  
  
     Inside the caller (the event handler in this example), the processing pattern continues. The caller might do other work that doesn't depend on the result from `AccessTheWebAsync` before awaiting that result, or the caller might await immediately.   The event handler is waiting for `AccessTheWebAsync`, and `AccessTheWebAsync` is waiting for `GetStringAsync`.  
  
7.  `GetStringAsync` completes and produces a string result. The string result isn't returned by the call to `GetStringAsync` in the way that you might expect. (Remember that the method already returned a task in step 3.) Instead, the string result is stored in the task that represents the completion of the method, `getStringTask`. The await operator retrieves the result from `getStringTask`. The assignment statement assigns the retrieved result to `urlContents`.  
  
8.  When `AccessTheWebAsync` has the string result, the method can calculate the length of the string. Then the work of `AccessTheWebAsync` is also complete, and the waiting event handler can resume. In the full example at the end of the topic, you can confirm that the event handler retrieves and prints the value of the length result.  
  
 If you are new to asynchronous programming, take a minute to consider the difference between synchronous and asynchronous behavior. A synchronous method returns when its work is complete (step 5), but an async method returns a task value when its work is suspended (steps 3 and 6). When the async method eventually completes its work, the task is marked as completed and the result, if any, is stored in the task.  
  
 For more information about control flow, see [Control Flow in Async Programs (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/control-flow-in-async-programs.md).  
  
##  <a name="BKMK_APIAsyncMethods"></a> API Async Methods  
 You might be wondering where to find methods such as `GetStringAsync` that support async programming. The  .NET Framework 4.5 or higher contains many members that work with `Async` and `Await`. You can recognize these members by the "Async" suffix that’s attached to the member name and a return type of <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601>. For example, the `System.IO.Stream` class contains methods such as <xref:System.IO.Stream.CopyToAsync%2A>, <xref:System.IO.Stream.ReadAsync%2A>, and <xref:System.IO.Stream.WriteAsync%2A> alongside the synchronous methods <xref:System.IO.Stream.CopyTo%2A>, <xref:System.IO.Stream.Read%2A>, and <xref:System.IO.Stream.Write%2A>.  
  
 The Windows Runtime also contains many methods that you can use with `Async` and `Await` in Windows apps. For more information and example methods, see [Quickstart: using the await operator for asynchronous programming](http://go.microsoft.com/fwlink/?LinkId=248545), [Asynchronous programming (Windows Store apps)](http://go.microsoft.com/fwlink/?LinkId=259592), and [WhenAny: Bridging between the .NET Framework and the Windows Runtime](https://msdn.microsoft.com/library/jj635140(v=vs.120).aspx).  
  
##  <a name="BKMK_Threads"></a> Threads  
 Async methods are intended to be non-blocking operations. An `Await` expression in an async method doesn’t block the current thread while the awaited task is running. Instead, the expression signs up the rest of the method as a continuation and returns control to the caller of the async method.  
  
 The `Async` and `Await` keywords don't cause additional threads to be created. Async methods don't require multithreading because an async method doesn't run on its own thread. The method runs on the current synchronization context and uses time on the thread only when the method is active. You can use <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType> to move CPU-bound work to a background thread, but a background thread doesn't help with a process that's just waiting for results to become available.  
  
 The async-based approach to asynchronous programming is preferable to existing approaches in almost every case. In particular, this approach is better than <xref:System.ComponentModel.BackgroundWorker> for IO-bound operations because the code is simpler and you don't have to guard against race conditions. In combination with <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType>, async programming is better than <xref:System.ComponentModel.BackgroundWorker> for CPU-bound operations because async programming separates the coordination details of running your code from the work that `Task.Run` transfers to the threadpool.  
  
##  <a name="BKMK_AsyncandAwait"></a> Async and Await  
 If you specify that a method is an async method by using an [Async](../../../../visual-basic/language-reference/modifiers/async.md) modifier, you enable the following two capabilities.  
  
-   The marked async method can use [Await](../../../../visual-basic/language-reference/operators/await-operator.md) to designate suspension points. The await operator tells the compiler that the async method can't continue past that point until the awaited asynchronous process is complete. In the meantime, control returns to the caller of the async method.  
  
     The suspension of an async method at an `Await` expression doesn't constitute an exit from the method, and `Finally` blocks don’t run.  
  
-   The marked async method can itself be awaited by methods that call it.  
  
 An async method typically contains one or more occurrences of an `Await` operator, but the absence of `Await` expressions doesn’t cause a compiler error. If an async method doesn’t use an `Await` operator to mark a suspension point, the method executes as a synchronous method does, despite the `Async` modifier. The compiler issues a warning for such methods.  
  
 `Async` and `Await` are contextual keywords. For more information and examples, see the following topics:  
  
-   [Async](../../../../visual-basic/language-reference/modifiers/async.md)  
  
-   [Await Operator](../../../../visual-basic/language-reference/operators/await-operator.md)  
  
##  <a name="BKMK_ReturnTypesandParameters"></a> Return Types and Parameters  
 In .NET Framework programming, an async method typically returns a <xref:System.Threading.Tasks.Task> or a <xref:System.Threading.Tasks.Task%601>. Inside an async method, an `Await` operator is applied to a task that's returned from a call to another async method.  
  
 You specify <xref:System.Threading.Tasks.Task%601> as the return type if the method contains a [Return](../../../../visual-basic/language-reference/statements/return-statement.md) statement that specifies an operand of type `TResult`.  
  
 You use `Task` as the return type if the method has no return statement or has a return statement that doesn't return an operand.  
  
 The following example shows how you declare and call a method that returns a <xref:System.Threading.Tasks.Task%601> or a <xref:System.Threading.Tasks.Task>.  
  
```vb  
' Signature specifies Task(Of Integer)  
Async Function TaskOfTResult_MethodAsync() As Task(Of Integer)  
  
    Dim hours As Integer  
    ' . . .  
    ' Return statement specifies an integer result.  
    Return hours  
End Function  
  
' Calls to TaskOfTResult_MethodAsync  
Dim returnedTaskTResult As Task(Of Integer) = TaskOfTResult_MethodAsync()  
Dim intResult As Integer = Await returnedTaskTResult  
' or, in a single statement  
Dim intResult As Integer = Await TaskOfTResult_MethodAsync()  
  
' Signature specifies Task  
Async Function Task_MethodAsync() As Task  
  
    ' . . .  
    ' The method has no return statement.  
End Function  
  
' Calls to Task_MethodAsync  
Task returnedTask = Task_MethodAsync()  
Await returnedTask  
' or, in a single statement  
Await Task_MethodAsync()  
```  
  
 Each returned task represents ongoing work. A task encapsulates information about the state of the asynchronous process and, eventually, either the final result from the process or the exception that the process raises if it doesn't succeed.  
  
 An async method can also be a `Sub` method. This return type is used primarily to define event handlers, where a return type is required. Async event handlers often serve as the starting point for async programs.  
  
 An async method that’s a `Sub` procedure can’t be awaited, and the caller can't catch any exceptions that the method throws.  
  
 An async method can't declare [ByRef](../../../../visual-basic/language-reference/modifiers/byref.md) parameters, but the method can call methods that have such parameters.  
  
 For more information and examples, see [Async Return Types (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/async-return-types.md). For more information about how to catch exceptions in async methods, see [Try...Catch...Finally Statement](../../../../visual-basic/language-reference/statements/try-catch-finally-statement.md).  
  
 Asynchronous APIs in Windows Runtime  programming have one of the following return types, which are similar to tasks:  
  
-   [IAsyncOperation](http://go.microsoft.com/fwlink/p/?LinkId=261896), which corresponds to <xref:System.Threading.Tasks.Task%601>  
  
-   [IAsyncAction](http://go.microsoft.com/fwlink/p/?LinkId=261897), which corresponds to <xref:System.Threading.Tasks.Task>  
  
-   [IAsyncActionWithProgress](http://go.microsoft.com/fwlink/p/?LinkId=261898)  
  
-   [IAsyncOperationWithProgress](http://go.microsoft.com/fwlink/p/?LinkID=259454)  
  
 For more information and an example, see [Quickstart: using the await operator for asynchronous programming](http://go.microsoft.com/fwlink/p/?LinkId=248545).  
  
##  <a name="BKMK_NamingConvention"></a> Naming Convention  
 By convention, you append "Async" to the names of methods that have an `Async` modifier.  
  
 You can ignore the convention where an event, base class, or interface contract suggests a different name. For example, you shouldn’t rename common event handlers, such as `Button1_Click`.  
  
##  <a name="BKMK_RelatedTopics"></a> Related Topics and Samples (Visual Studio)  
  
|Title|Description|Sample|  
|-----------|-----------------|------------|  
|[Walkthrough: Accessing the Web by Using Async and Await (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/walkthrough-accessing-the-web-by-using-async-and-await.md)|Shows how to convert a synchronous WPF solution to an asynchronous WPF solution. The application downloads a series of websites.|[Async Sample: Accessing the Web Walkthrough](http://go.microsoft.com/fwlink/p/?LinkID=255191&clcid=0x409)|  
|[How to: Extend the Async Walkthrough by Using Task.WhenAll (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/how-to-extend-the-async-walkthrough-by-using-task-whenall.md)|Adds <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType> to the previous walkthrough. The use of `WhenAll` starts all the downloads at the same time.||  
|[How to: Make Multiple Web Requests in Parallel by Using Async and Await (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/how-to-make-multiple-web-requests-in-parallel-by-using-async-and-await.md)|Demonstrates how to start several tasks at the same time.|[Async Sample: Make Multiple Web Requests in Parallel](http://go.microsoft.com/fwlink/p/?LinkID=254906&clcid=0x409)|  
|[Async Return Types (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/async-return-types.md)|Illustrates the types that async methods can return and explains when each type is appropriate.||  
|[Control Flow in Async Programs (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/control-flow-in-async-programs.md)|Traces in detail the flow of control through a succession of await expressions in an asynchronous program.|[Async Sample: Control Flow in Async Programs](http://go.microsoft.com/fwlink/p/?LinkID=255285&clcid=0x409)|  
|[Fine-Tuning Your Async Application (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/fine-tuning-your-async-application.md)|Shows how to add the following functionality to your async solution:<br /><br /> -   [Cancel an Async Task or a List of Tasks (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/cancel-an-async-task-or-a-list-of-tasks.md)<br />-   [Cancel Async Tasks after a Period of Time (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/cancel-async-tasks-after-a-period-of-time.md)<br />-   [Cancel Remaining Async Tasks after One Is Complete (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/cancel-remaining-async-tasks-after-one-is-complete.md)<br />-   [Start Multiple Async Tasks and Process Them As They Complete (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/start-multiple-async-tasks-and-process-them-as-they-complete.md)|[Async Sample: Fine Tuning Your Application](http://go.microsoft.com/fwlink/p/?LinkID=255046&clcid=0x409)|  
|[Handling Reentrancy in Async Apps (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/handling-reentrancy-in-async-apps.md)|Shows how to handle cases in which an active asynchronous operation is restarted while it’s running.||  
|[WhenAny: Bridging between the .NET Framework and the Windows Runtime](https://msdn.microsoft.com/library/jj635140(v=vs.120).aspx)|Shows how to bridge between Task types in the .NET Framework and IAsyncOperations in the [!INCLUDE[wrt](~/includes/wrt-md.md)] so that you can use <xref:System.Threading.Tasks.Task.WhenAny%2A> with a [!INCLUDE[wrt](~/includes/wrt-md.md)] method.|[Async Sample: Bridging between .NET and Windows Runtime (AsTask and WhenAny)](http://go.microsoft.com/fwlink/p/?LinkID=260638)|  
|Async Cancellation: Bridging between the .NET Framework and the Windows Runtime|Shows how to bridge between Task types in the .NET Framework and IAsyncOperations in the [!INCLUDE[wrt](~/includes/wrt-md.md)] so that you can use <xref:System.Threading.CancellationTokenSource> with a [!INCLUDE[wrt](~/includes/wrt-md.md)] method.|[Async Sample: Bridging between .NET and Windows Runtime (AsTask & Cancellation)](http://go.microsoft.com/fwlink/p/?LinkId=263004)|  
|[Using Async for File Access (Visual Basic)](../../../../visual-basic/programming-guide/concepts/async/using-async-for-file-access.md)|Lists and demonstrates the benefits of using async and await to access files.||  
|[Task-based Asynchronous Pattern (TAP)](http://msdn.microsoft.com/library/8cef1fcf-6f9f-417c-b21f-3fd8bac75007)|Describes a new pattern for asynchrony in the .NET Framework. The pattern is based on the <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> types.||  
|[Async Videos on Channel 9](http://go.microsoft.com/fwlink/p/?LinkID=267466)|Provides links to a variety of videos about async programming.||  
  
##  <a name="BKMK_CompleteExample"></a> Complete Example  
 The following code is the MainWindow.xaml.vb file from the Windows Presentation Foundation (WPF) application that this topic discusses. You can download the sample from [Async Sample: Example from "Asynchronous Programming with Async and Await"](http://go.microsoft.com/fwlink/p/?LinkID=261549).  
  
```vb  
' Add an Imports statement and a reference for System.Net.Http  
Imports System.Net.Http  
  
Class MainWindow  
  
    ' Mark the event handler with async so you can use Await in it.  
    Private Async Sub StartButton_Click(sender As Object, e As RoutedEventArgs)  
  
        ' Call and await separately.  
        'Task<int> getLengthTask = AccessTheWebAsync();  
        '' You can do independent work here.  
        'int contentLength = await getLengthTask;  
  
        Dim contentLength As Integer = Await AccessTheWebAsync()  
  
        ResultsTextBox.Text &=  
            String.Format(vbCrLf & "Length of the downloaded string: {0}." & vbCrLf, contentLength)  
    End Sub  
  
    ' Three things to note in the signature:  
    '  - The method has an Async modifier.   
    '  - The return type is Task or Task(Of T). (See "Return Types" section.)  
    '    Here, it is Task(Of Integer) because the return statement returns an integer.  
    '  - The method name ends in "Async."  
    Async Function AccessTheWebAsync() As Task(Of Integer)  
  
        ' You need to add a reference to System.Net.Http to declare client.  
        Dim client As HttpClient = New HttpClient()  
  
        ' GetStringAsync returns a Task(Of String). That means that when you await the  
        ' task you'll get a string (urlContents).  
        Dim getStringTask As Task(Of String) = client.GetStringAsync("http://msdn.microsoft.com")  
  
        ' You can do work here that doesn't rely on the string from GetStringAsync.  
        DoIndependentWork()  
  
        ' The Await operator suspends AccessTheWebAsync.  
        '  - AccessTheWebAsync can't continue until getStringTask is complete.  
        '  - Meanwhile, control returns to the caller of AccessTheWebAsync.  
        '  - Control resumes here when getStringTask is complete.   
        '  - The Await operator then retrieves the string result from getStringTask.  
        Dim urlContents As String = Await getStringTask  
  
        ' The return statement specifies an integer result.  
        ' Any methods that are awaiting AccessTheWebAsync retrieve the length value.  
        Return urlContents.Length  
    End Function  
  
    Sub DoIndependentWork()  
        ResultsTextBox.Text &= "Working . . . . . . ." & vbCrLf  
    End Sub  
End Class  
  
' Sample Output:  
  
' Working . . . . . . .  
  
' Length of the downloaded string: 41763.  
```  
  
## See Also  
 [Await Operator](../../../../visual-basic/language-reference/operators/await-operator.md)  
 [Async](../../../../visual-basic/language-reference/modifiers/async.md)
