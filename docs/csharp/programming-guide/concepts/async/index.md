---
title: "Asynchronous Programming with async and await (C#)"
ms.date: 05/22/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 9bcf896a-5826-4189-8c1a-3e35fa08243a
caps.latest.revision: 5
author: "BillWagner"
ms.author: "wiwagn"
---
# Asynchronous programming with async and await (C#)
You can avoid performance bottlenecks and enhance the overall responsiveness of your application by using asynchronous programming. However, traditional techniques for writing asynchronous applications can be complicated, making them difficult to write, debug, and maintain.  
  
[C# 5](../../../whats-new/index.md#previous-versions) introduced a simplified approach, async programming, that leverages asynchronous support in the .NET Framework 4.5 and higher, .NET Core, and the Windows Runtime. The compiler does the difficult work that the developer used to do, and your application retains a logical structure that resembles synchronous code. As a result, you get all the advantages of asynchronous programming with a fraction of the effort.  
  
This topic provides an overview of when and how to use async programming and includes links to support topics that contain details and examples.  
  
##  <a name="BKMK_WhentoUseAsynchrony"></a> Async improves responsiveness  
 Asynchrony is essential for activities that are potentially blocking, such as web access. Access to a web resource sometimes is slow or delayed. If such an activity is blocked in a synchronous process, the entire application must wait. In an asynchronous process, the application can continue with other work that doesn't depend on the web resource until the potentially blocking task finishes.  
  
 The following table shows typical areas where asynchronous programming improves responsiveness. The listed APIs from .NET and the Windows Runtime contain methods that support async programming.  
  
| Application area    | .NET types with async methods     | Windows Runtime types with async methods  |
|---------------------|-----------------------------------|-------------------------------------------|
|Web access|<xref:System.Net.Http.HttpClient>|<xref:Windows.Web.Syndication.SyndicationClient>|
|Working with files|<xref:System.IO.StreamWriter>, <xref:System.IO.StreamReader>, <xref:System.Xml.XmlReader>|<xref:Windows.Storage.StorageFile>|  
|Working with images||<xref:Windows.Media.Capture.MediaCapture>, <xref:Windows.Graphics.Imaging.BitmapEncoder>, <xref:Windows.Graphics.Imaging.BitmapDecoder>|  
|WCF programming|[Synchronous and Asynchronous Operations](../../../../framework/wcf/synchronous-and-asynchronous-operations.md)||  
  
Asynchrony proves especially valuable for applications that access the UI thread because all UI-related activity usually shares one thread. If any process is blocked in a synchronous application, all are blocked. Your application stops responding, and you might conclude that it has failed when instead it's just waiting.  
  
 When you use asynchronous methods, the application continues to respond to the UI. You can resize or minimize a window, for example, or you can close the application if you don't want to wait for it to finish.  
  
 The async-based approach adds the equivalent of an automatic transmission to the list of options that you can choose from when designing asynchronous operations. That is, you get all the benefits of traditional asynchronous programming but with much less effort from the developer.  
  
##  <a name="BKMK_HowtoWriteanAsyncMethod"></a> Async methods are easier to write  
 The [async](../../../../csharp/language-reference/keywords/async.md) and [await](../../../../csharp/language-reference/keywords/await.md) keywords in C# are the heart of async programming. By using those two keywords, you can use resources in the .NET Framework, .NET Core, or the Windows Runtime to create an asynchronous method almost as easily as you create a synchronous method. Asynchronous methods that you define by using the `async` keyword are referred to as *async methods*.  
  
 The following example shows an async method. Almost everything in the code should look completely familiar to you. The comments call out the features that you add to create the asynchrony.  
  
 You can find a complete Windows Presentation Foundation (WPF) example file at the end of this topic, and you can download the sample from [Async Sample: Example from "Asynchronous Programming with Async and Await"](https://code.msdn.microsoft.com/Async-Sample-Example-from-9b9f505c).  
  
```csharp  
// Three things to note in the signature:  
//  - The method has an async modifier.   
//  - The return type is Task or Task<T>. (See "Return Types" section.)  
//    Here, it is Task<int> because the return statement returns an integer.  
//  - The method name ends in "Async."  
async Task<int> AccessTheWebAsync()  
{   
    // You need to add a reference to System.Net.Http to declare client.  
    HttpClient client = new HttpClient();  
  
    // GetStringAsync returns a Task<string>. That means that when you await the  
    // task you'll get a string (urlContents).  
    Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");  
  
    // You can do work here that doesn't rely on the string from GetStringAsync.  
    DoIndependentWork();  
  
    // The await operator suspends AccessTheWebAsync.  
    //  - AccessTheWebAsync can't continue until getStringTask is complete.  
    //  - Meanwhile, control returns to the caller of AccessTheWebAsync.  
    //  - Control resumes here when getStringTask is complete.   
    //  - The await operator then retrieves the string result from getStringTask.  
    string urlContents = await getStringTask;  
  
    // The return statement specifies an integer result.  
    // Any methods that are awaiting AccessTheWebAsync retrieve the length value.  
    return urlContents.Length;  
}  
```  
  
 If `AccessTheWebAsync` doesn't have any work that it can do between calling `GetStringAsync` and awaiting its completion, you can simplify your code by calling and awaiting in the following single statement.  
  
```csharp  
string urlContents = await client.GetStringAsync();  
```  
 
The following characteristics summarize what makes the previous example an async method.  
  
-   The method signature includes an `async` modifier.  
  
-   The name of an async method, by convention, ends with an "Async" suffix.  
  
-   The return type is one of the following types:  
  
    -   <xref:System.Threading.Tasks.Task%601> if your method has a return statement in which the operand has type `TResult`.  
  
    -   <xref:System.Threading.Tasks.Task> if your method has no return statement or has a return statement with no operand.  
  
    -   `void` if you're writing an async event handler.  

    -   Any other type that has a `GetAwaiter` method (starting with C# 7).
  
     For more information, see the [Return Types and Parameters](#BKMK_ReturnTypesandParameters) section.  
  
-   The method usually includes at least one await expression, which marks a point where the method can't continue until the awaited asynchronous operation is complete. In the meantime, the method is suspended, and control returns to the method's caller. The next section of this topic illustrates what happens at the suspension point.  
  
 In async methods, you use the provided keywords and types to indicate what you want to do, and the compiler does the rest, including keeping track of what must happen when control returns to an await point in a suspended method. Some routine processes, such as loops and exception handling, can be difficult to handle in traditional asynchronous code. In an async method, you write these elements much as you would in a synchronous solution, and the problem is solved.  
  
 For more information about asynchrony in previous versions of the .NET Framework, see [TPL and Traditional .NET Framework Asynchronous Programming](../../../../standard/parallel-programming/tpl-and-traditional-async-programming.md).  
  
##  <a name="BKMK_WhatHappensUnderstandinganAsyncMethod"></a> What happens in an async method  
 The most important thing to understand in asynchronous programming is how the control flow moves from method to method. The following diagram leads you through the process.  
  
 ![Trace an async program](../../../../csharp/programming-guide/concepts/async/media/navigationtrace.png "NavigationTrace")  
  
 The numbers in the diagram correspond to the following steps.  
  
1.  An event handler calls and awaits the  `AccessTheWebAsync` async method.  
  
2.  `AccessTheWebAsync` creates an <xref:System.Net.Http.HttpClient> instance and calls the <xref:System.Net.Http.HttpClient.GetStringAsync%2A> asynchronous method to download the contents of a website as a string.  
  
3.  Something happens in `GetStringAsync` that suspends its progress. Perhaps it must wait for a website to download or some other blocking activity. To avoid blocking resources, `GetStringAsync` yields control to its caller, `AccessTheWebAsync`.  
  
     `GetStringAsync` returns a <xref:System.Threading.Tasks.Task%601> where `TResult` is a string, and `AccessTheWebAsync` assigns the task to the `getStringTask` variable. The task represents the ongoing process for the call to `GetStringAsync`, with a commitment to produce an actual string value when the work is complete.  
  
4.  Because `getStringTask` hasn't been awaited yet, `AccessTheWebAsync` can continue with other work that doesn't depend on the final result from `GetStringAsync`. That work is represented by a call to the synchronous method `DoIndependentWork`.  
  
5.  `DoIndependentWork` is a synchronous method that does its work and returns to its caller.  
  
6.  `AccessTheWebAsync` has run out of work that it can do without a result from `getStringTask`. `AccessTheWebAsync` next wants to calculate and return the length of the downloaded string, but the method can't calculate that value until the method has the string.  
  
     Therefore, `AccessTheWebAsync` uses an await operator to suspend its progress and to yield control to the method that called `AccessTheWebAsync`. `AccessTheWebAsync` returns a `Task<int>` to the caller. The task represents a promise to produce an integer result that's the length of the downloaded string.  
  
    > [!NOTE]
    >  If `GetStringAsync` (and therefore `getStringTask`) is complete before `AccessTheWebAsync` awaits it, control remains in `AccessTheWebAsync`. The expense of suspending and then returning to `AccessTheWebAsync` would be wasted if the called asynchronous process (`getStringTask`) has already completed and `AccessTheWebSync` doesn't have to wait for the final result.  
  
     Inside the caller (the event handler in this example), the processing pattern continues. The caller might do other work that doesn't depend on the result from `AccessTheWebAsync` before awaiting that result, or the caller might await immediately.   The event handler is waiting for `AccessTheWebAsync`, and `AccessTheWebAsync` is waiting for `GetStringAsync`.  
  
7.  `GetStringAsync` completes and produces a string result. The string result isn't returned by the call to `GetStringAsync` in the way that you might expect. (Remember that the method already returned a task in step 3.) Instead, the string result is stored in the task that represents the completion of the method, `getStringTask`. The await operator retrieves the result from `getStringTask`. The assignment statement assigns the retrieved result to `urlContents`.  
  
8.  When `AccessTheWebAsync` has the string result, the method can calculate the length of the string. Then the work of `AccessTheWebAsync` is also complete, and the waiting event handler can resume. In the full example at the end of the topic, you can confirm that the event handler retrieves and prints the value of the length result.    
If you are new to asynchronous programming, take a minute to consider the difference between synchronous and asynchronous behavior. A synchronous method returns when its work is complete (step 5), but an async method returns a task value when its work is suspended (steps 3 and 6). When the async method eventually completes its work, the task is marked as completed and the result, if any, is stored in the task.  
  
For more information about control flow, see [Control Flow in Async Programs (C#)](../../../../csharp/programming-guide/concepts/async/control-flow-in-async-programs.md).  
  
##  <a name="BKMK_APIAsyncMethods"></a> API async methods  
 You might be wondering where to find methods such as `GetStringAsync` that support async programming. The  .NET Framework 4.5 or higher and .NET Core contain many members that work with `async` and `await`. You can recognize them by the "Async" suffix that’s appended to the member name, and by their return type of <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601>. For example, the `System.IO.Stream` class contains methods such as <xref:System.IO.Stream.CopyToAsync%2A>, <xref:System.IO.Stream.ReadAsync%2A>, and <xref:System.IO.Stream.WriteAsync%2A> alongside the synchronous methods <xref:System.IO.Stream.CopyTo%2A>, <xref:System.IO.Stream.Read%2A>, and <xref:System.IO.Stream.Write%2A>.  
  
 The Windows Runtime also contains many methods that you can use with `async` and `await` in Windows apps. For more information, see [Threading and async programming](/windows/uwp/threading-async/) for UWP development, and [Asynchronous programming (Windows Store apps)](/previous-versions/windows/apps/hh464924(v=win.10)) and [Quickstart: Calling asynchronous APIs in C# or Visual Basic](/previous-versions/windows/apps/hh452713(v=win.10)) if you use earlier versions of the Windows Runtime.  
  
##  <a name="BKMK_Threads"></a> Threads  
Async methods are intended to be non-blocking operations. An `await` expression in an async method doesn’t block the current thread while the awaited task is running. Instead, the expression signs up the rest of the method as a continuation and returns control to the caller of the async method.  
  
The `async` and `await` keywords don't cause additional threads to be created. Async methods don't require multithreading because an async method doesn't run on its own thread. The method runs on the current synchronization context and uses time on the thread only when the method is active. You can use <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType> to move CPU-bound work to a background thread, but a background thread doesn't help with a process that's just waiting for results to become available.  
  
The async-based approach to asynchronous programming is preferable to existing approaches in almost every case. In particular, this approach is better than the <xref:System.ComponentModel.BackgroundWorker> class for IO-bound operations because the code is simpler and you don't have to guard against race conditions. In combination with the <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType> method, async programming is better than <xref:System.ComponentModel.BackgroundWorker> for CPU-bound operations because async programming separates the coordination details of running your code from the work that `Task.Run` transfers to the threadpool.  
  
##  <a name="BKMK_AsyncandAwait"></a> async and await  
 If you specify that a method is an async method by using the [async](../../../../csharp/language-reference/keywords/async.md) modifier, you enable the following two capabilities.  
  
-   The marked async method can use [await](../../../../csharp/language-reference/keywords/await.md) to designate suspension points. The `await` operator tells the compiler that the async method can't continue past that point until the awaited asynchronous process is complete. In the meantime, control returns to the caller of the async method.  
  
     The suspension of an async method at an `await` expression doesn't constitute an exit from the method, and `finally` blocks don’t run.  
  
-   The marked async method can itself be awaited by methods that call it.  
  
An async method typically contains one or more occurrences of an `await` operator, but the absence of `await` expressions doesn’t cause a compiler error. If an async method doesn’t use an `await` operator to mark a suspension point, the method executes as a synchronous method does, despite the `async` modifier. The compiler issues a warning for such methods.  
  
 `async` and `await` are contextual keywords. For more information and examples, see the following topics:  
  
-   [async](../../../../csharp/language-reference/keywords/async.md)  
  
-   [await](../../../../csharp/language-reference/keywords/await.md)  
  
##  <a name="BKMK_ReturnTypesandParameters"></a> Return types and parameters  
An async method typically returns a <xref:System.Threading.Tasks.Task> or a <xref:System.Threading.Tasks.Task%601>. Inside an async method, an `await` operator is applied to a task that's returned from a call to another async method.  
  
You specify <xref:System.Threading.Tasks.Task%601> as the return type if the method contains a [return](../../../../csharp/language-reference/keywords/return.md) statement that specifies an operand of type `TResult`. 
  
You use <xref:System.Threading.Tasks.Task>  as the return type if the method has no return statement or has a return statement that doesn't return an operand.  

Starting with C# 7, you can also specify any other return type, provided that that type includes a `GetAwaiter` method. <xref:System.Threading.Tasks.ValueTask%601> is an example of such a type. It is available in the [System.Threading.Tasks.Extension](https://www.nuget.org/packages/System.Threading.Tasks.Extensions/) NuGet package.
  
 The following example shows how you declare and call a method that returns a <xref:System.Threading.Tasks.Task%601> or a <xref:System.Threading.Tasks.Task>.  
  
```csharp  
// Signature specifies Task<TResult>  
async Task<int> TaskOfTResult_MethodAsync()  
{  
    int hours;  
    // . . .  
    // Return statement specifies an integer result.  
    return hours;  
}  
  
// Calls to TaskOfTResult_MethodAsync  
Task<int> returnedTaskTResult = TaskOfTResult_MethodAsync();  
int intResult = await returnedTaskTResult;  
// or, in a single statement  
int intResult = await TaskOfTResult_MethodAsync();  
  
// Signature specifies Task  
async Task Task_MethodAsync()  
{  
    // . . .  
    // The method has no return statement.    
}  
  
// Calls to Task_MethodAsync  
Task returnedTask = Task_MethodAsync();  
await returnedTask;  
// or, in a single statement  
await Task_MethodAsync();  
```  
  
Each returned task represents ongoing work. A task encapsulates information about the state of the asynchronous process and, eventually, either the final result from the process or the exception that the process raises if it doesn't succeed.  
  
An async method can also have a `void` return type. This return type is used primarily to define event handlers, where a `void` return type is required. Async event handlers often serve as the starting point for async programs.  
  
An async method that has a `void` return type can’t be awaited, and the caller of a void-returning method can't catch any exceptions that the method throws.  
  
An async method can't declare [in](../../../../csharp/language-reference/keywords/in-parameter-modifier.md), [ref](../../../../csharp/language-reference/keywords/ref.md) or [out](../../../../csharp/language-reference/keywords/out-parameter-modifier.md) parameters, but the method can call methods that have such parameters. Similarly, an async method can't return a value by reference, although it can call methods with ref return values. 
  
For more information and examples, see [Async Return Types (C#)](../../../../csharp/programming-guide/concepts/async/async-return-types.md). For more information about how to catch exceptions in async methods, see [try-catch](../../../../csharp/language-reference/keywords/try-catch.md). 
  
Asynchronous APIs in Windows Runtime programming have one of the following return types, which are similar to tasks:  
  
-   <xref:Windows.Foundation.IAsyncOperation%601>, which corresponds to <xref:System.Threading.Tasks.Task%601>  
  
-   <xref:Windows.Foundation.IAsyncAction>, which corresponds to <xref:System.Threading.Tasks.Task>  
  
-   <xref:Windows.Foundation.IAsyncActionWithProgress%601>  
  
-   <xref:Windows.Foundation.IAsyncOperationWithProgress%602>  
   
  
##  <a name="BKMK_NamingConvention"></a> Naming convention  
 By convention, you append "Async" to the names of methods that have an `async` modifier.  
  
 You can ignore the convention where an event, base class, or interface contract suggests a different name. For example, you shouldn’t rename common event handlers, such as `Button1_Click`.  
  
##  <a name="BKMK_RelatedTopics"></a> Related topics and samples (Visual Studio)  
  
|Title|Description|Sample|  
|-----------|-----------------|------------|  
|[Walkthrough: Accessing the Web by Using async and await (C#)](../../../../csharp/programming-guide/concepts/async/walkthrough-accessing-the-web-by-using-async-and-await.md)|Shows how to convert a synchronous WPF solution to an asynchronous WPF solution. The application downloads a series of websites.|[Async Sample: Accessing the Web Walkthrough](https://code.msdn.microsoft.com/Async-Sample-Accessing-the-9c10497f)|  
|[How to: Extend the async Walkthrough by Using Task.WhenAll (C#)](../../../../csharp/programming-guide/concepts/async/how-to-extend-the-async-walkthrough-by-using-task-whenall.md)|Adds <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType> to the previous walkthrough. The use of `WhenAll` starts all the downloads at the same time.||  
|[How to: Make Multiple Web Requests in Parallel by Using async and await (C#)](../../../../csharp/programming-guide/concepts/async/how-to-make-multiple-web-requests-in-parallel-by-using-async-and-await.md)|Demonstrates how to start several tasks at the same time.|[Async Sample: Make Multiple Web Requests in Parallel](https://code.msdn.microsoft.com/Async-Make-Multiple-Web-49adb82e)|  
|[Async Return Types (C#)](../../../../csharp/programming-guide/concepts/async/async-return-types.md)|Illustrates the types that async methods can return and explains when each type is appropriate.||  
|[Control Flow in Async Programs (C#)](../../../../csharp/programming-guide/concepts/async/control-flow-in-async-programs.md)|Traces in detail the flow of control through a succession of await expressions in an asynchronous program.|[Async Sample: Control Flow in Async Programs](https://code.msdn.microsoft.com/Async-Sample-Control-Flow-5c804fc0)|  
|[Fine-Tuning Your Async Application (C#)](../../../../csharp/programming-guide/concepts/async/fine-tuning-your-async-application.md)|Shows how to add the following functionality to your async solution:<br /><br /> -   [Cancel an Async Task or a List of Tasks (C#)](../../../../csharp/programming-guide/concepts/async/cancel-an-async-task-or-a-list-of-tasks.md)<br />-   [Cancel Async Tasks after a Period of Time (C#)](../../../../csharp/programming-guide/concepts/async/cancel-async-tasks-after-a-period-of-time.md)<br />-   [Cancel Remaining Async Tasks after One Is Complete (C#)](../../../../csharp/programming-guide/concepts/async/cancel-remaining-async-tasks-after-one-is-complete.md)<br />-   [Start Multiple Async Tasks and Process Them As They Complete (C#)](../../../../csharp/programming-guide/concepts/async/start-multiple-async-tasks-and-process-them-as-they-complete.md)|[Async Sample: Fine Tuning Your Application](https://code.msdn.microsoft.com/Async-Fine-Tuning-Your-a676abea)|  
|[Handling Reentrancy in Async Apps (C#)](../../../../csharp/programming-guide/concepts/async/handling-reentrancy-in-async-apps.md)|Shows how to handle cases in which an active asynchronous operation is restarted while it’s running.||  
|[WhenAny: Bridging between the .NET Framework and the Windows Runtime](https://msdn.microsoft.com/library/jj635140(v=vs.120).aspx)|Shows how to bridge between Task types in the .NET Framework and IAsyncOperations in the [!INCLUDE[wrt](~/includes/wrt-md.md)] so that you can use <xref:System.Threading.Tasks.Task.WhenAny%2A> with a [!INCLUDE[wrt](~/includes/wrt-md.md)] method.|[Async Sample: Bridging between .NET and Windows Runtime (AsTask and WhenAny)](https://code.msdn.microsoft.com/Async-Sample-Bridging-d6a2f739)|  
|Async Cancellation: Bridging between the .NET Framework and the Windows Runtime|Shows how to bridge between Task types in the .NET Framework and IAsyncOperations in the [!INCLUDE[wrt](~/includes/wrt-md.md)] so that you can use <xref:System.Threading.CancellationTokenSource> with a [!INCLUDE[wrt](~/includes/wrt-md.md)] method.|[Async Sample: Bridging between .NET and Windows Runtime (AsTask & Cancellation)](https://code.msdn.microsoft.com/Async-Sample-Bridging-9479eca3)|  
|[Using Async for File Access (C#)](../../../../csharp/programming-guide/concepts/async/using-async-for-file-access.md)|Lists and demonstrates the benefits of using async and await to access files.||  
|[Task-based Asynchronous Pattern (TAP)](../../../../standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md)|Describes a new pattern for asynchrony in the .NET Framework. The pattern is based on the <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> types.||  
|[Async Videos on Channel 9](https://channel9.msdn.com/search?term=async%20&type=All#pubDate=year&ch9Search&lang-en=en)|Provides links to a variety of videos about async programming.||  
  
##  <a name="BKMK_CompleteExample"></a> Complete example  
 The following code is the MainWindow.xaml.cs file from the Windows Presentation Foundation (WPF) application that this topic discusses. You can download the sample from [Async Sample: Example from "Asynchronous Programming with Async and Await"](https://code.msdn.microsoft.com/Async-Sample-Example-from-9b9f505c).  
  
```csharp  
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
using System.Windows;  
using System.Windows.Controls;  
using System.Windows.Data;  
using System.Windows.Documents;  
using System.Windows.Input;  
using System.Windows.Media;  
using System.Windows.Media.Imaging;  
using System.Windows.Navigation;  
using System.Windows.Shapes;  
  
// Add a using directive and a reference for System.Net.Http;  
using System.Net.Http;  
  
namespace AsyncFirstExample  
{  
    public partial class MainWindow : Window  
    {  
        // Mark the event handler with async so you can use await in it.  
        private async void StartButton_Click(object sender, RoutedEventArgs e)  
        {  
            // Call and await separately.  
            //Task<int> getLengthTask = AccessTheWebAsync();  
            //// You can do independent work here.  
            //int contentLength = await getLengthTask;  
  
            int contentLength = await AccessTheWebAsync();  
  
            resultsTextBox.Text +=  
                String.Format("\r\nLength of the downloaded string: {0}.\r\n", contentLength);  
        }  
  
        // Three things to note in the signature:  
        //  - The method has an async modifier.   
        //  - The return type is Task or Task<T>. (See "Return Types" section.)  
        //    Here, it is Task<int> because the return statement returns an integer.  
        //  - The method name ends in "Async."  
        async Task<int> AccessTheWebAsync()  
        {   
            // You need to add a reference to System.Net.Http to declare client.  
            HttpClient client = new HttpClient();  
  
            // GetStringAsync returns a Task<string>. That means that when you await the  
            // task you'll get a string (urlContents).  
            Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");  
  
            // You can do work here that doesn't rely on the string from GetStringAsync.  
            DoIndependentWork();  
  
            // The await operator suspends AccessTheWebAsync.  
            //  - AccessTheWebAsync can't continue until getStringTask is complete.  
            //  - Meanwhile, control returns to the caller of AccessTheWebAsync.  
            //  - Control resumes here when getStringTask is complete.   
            //  - The await operator then retrieves the string result from getStringTask.  
            string urlContents = await getStringTask;  
  
            // The return statement specifies an integer result.  
            // Any methods that are awaiting AccessTheWebAsync retrieve the length value.  
            return urlContents.Length;  
        }  
  
        void DoIndependentWork()  
        {  
            resultsTextBox.Text += "Working . . . . . . .\r\n";  
        }  
    }  
}  
  
// Sample Output:  
  
// Working . . . . . . .  
  
// Length of the downloaded string: 41564.  
```  
  
## See also  
 [async](../../../../csharp/language-reference/keywords/async.md)  
 [await](../../../../csharp/language-reference/keywords/await.md)  
 [Asynchronous programming](../../../../csharp/async.md)  
 [Async overview](../../../../standard/async.md)  
