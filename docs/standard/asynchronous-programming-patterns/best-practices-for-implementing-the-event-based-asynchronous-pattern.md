---
title: "Best Practices for Implementing the Event-based Asynchronous Pattern"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Event-based Asynchronous Pattern"
  - "ProgressChangedEventArgs class"
  - "BackgroundWorker component"
  - "events [.NET Framework], asynchronous"
  - "AsyncOperationManager class"
  - "threading [.NET Framework], asynchronous features"
  - "AsyncOperation class"
  - "AsyncCompletedEventArgs class"
ms.assetid: 4acd2094-4f46-4eff-9190-92d0d9ff47db
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Best Practices for Implementing the Event-based Asynchronous Pattern
The Event-based Asynchronous Pattern provides you with an effective way to expose asynchronous behavior in classes, with familiar event and delegate semantics. To implement Event-based Asynchronous Pattern, you need to follow some specific behavioral requirements. The following sections describe requirements and guidelines you should consider when you implement a class that follows the Event-based Asynchronous Pattern.  
  
 For an overview, see [Implementing the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/implementing-the-event-based-asynchronous-pattern.md).  
  
## Required Behavioral Guarantees  
 If you implement the Event-based Asynchronous Pattern, you must provide a number of guarantees to ensure that your class will behave properly and clients of your class can rely on such behavior.  
  
### Completion  
 Always invoke the *MethodName***Completed** event handler when you have successful completion, an error, or a cancellation. Applications should never encounter a situation where they remain idle and completion never occurs. One exception to this rule is if the asynchronous operation itself it designed so that it never completes.  
  
### Completed Event and EventArgs  
 For each separate *MethodName***Async** method, apply the following design requirements:  
  
-   Define a *MethodName***Completed** event on the same class as the method.  
  
-   Define an <xref:System.EventArgs> class and accompanying delegate for the *MethodName***Completed** event that derives from the <xref:System.ComponentModel.AsyncCompletedEventArgs> class. The default class name should be of the form *MethodName***CompletedEventArgs**.  
  
-   Ensure that the <xref:System.EventArgs> class is specific to the return values of the *MethodName* method. When you use the <xref:System.EventArgs> class, you should never require developers to cast the result.  
  
     The following code example shows good and bad implementation of this design requirement respectively.  
  
```csharp  
// Good design  
private void Form1_MethodNameCompleted(object sender, xxxCompletedEventArgs e)   
{   
    DemoType result = e.Result;  
}  
  
// Bad design  
private void Form1_MethodNameCompleted(object sender, MethodNameCompletedEventArgs e)   
{   
    DemoType result = (DemoType)(e.Result);  
}  
```  
  
-   Do not define an <xref:System.EventArgs> class for returning methods that return `void`. Instead, use an instance of the <xref:System.ComponentModel.AsyncCompletedEventArgs> class.  
  
-   Ensure that you always raise the *MethodName***Completed** event. This event should be raised on successful completion, on an error, or on cancellation. Applications should never encounter a situation where they remain idle and completion never occurs.  
  
-   Ensure that you catch any exceptions that occur in the asynchronous operation and assign the caught exception to the <xref:System.ComponentModel.AsyncCompletedEventArgs.Error%2A> property.  
  
-   If there was an error completing the task, the results should not be accessible. When the <xref:System.ComponentModel.AsyncCompletedEventArgs.Error%2A> property is not `null`, ensure that accessing any property in the <xref:System.EventArgs> structure raises an exception. Use the <xref:System.ComponentModel.AsyncCompletedEventArgs.RaiseExceptionIfNecessary%2A> method to perform this verification.  
  
-   Model a time out as an error. When a time out occurs, raise the *MethodName***Completed** event and assign a <xref:System.TimeoutException> to the <xref:System.ComponentModel.AsyncCompletedEventArgs.Error%2A> property.  
  
-   If your class supports multiple concurrent invocations, ensure that the *MethodName***Completed** event contains the appropriate `userSuppliedState` object.  
  
-   Ensure that the *MethodName***Completed** event is raised on the appropriate thread and at the appropriate time in the application lifecycle. For more information, see the Threading and Contexts section.  
  
### Simultaneously Executing Operations  
  
-   If your class supports multiple concurrent invocations, enable the developer to track each invocation separately by defining the *MethodName***Async** overload that takes an object-valued state parameter, or task ID, called `userSuppliedState`. This parameter should always be the last parameter in the *MethodName***Async** method's signature.  
  
-   If your class defines the *MethodName***Async** overload that takes an object-valued state parameter, or task ID, be sure to track the lifetime of the operation with that task ID, and be sure to provide it back into the completion handler. There are helper classes available to assist. For more information on concurrency management, see [Walkthrough: Implementing a Component That Supports the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/component-that-supports-the-event-based-asynchronous-pattern.md).  
  
-   If your class defines the *MethodName***Async** method without the state parameter, and it does not support multiple concurrent invocations, ensure that any attempt to invoke *MethodName***Async** before the prior *MethodName***Async** invocation has completed raises an <xref:System.InvalidOperationException>.  
  
-   In general, do not raise an exception if the *MethodName***Async** method without the `userSuppliedState` parameter is invoked multiple times so that there are multiple outstanding operations. You can raise an exception when your class explicitly cannot handle that situation, but assume that developers can handle these multiple indistinguishable callbacks  
  
### Accessing Results  
  
-   If there was an error during execution of the asynchronous operation, the results should not be accessible. Ensure that accessing any property in the <xref:System.ComponentModel.AsyncCompletedEventArgs> when <xref:System.ComponentModel.AsyncCompletedEventArgs.Error%2A> is not `null` raises the exception referenced by <xref:System.ComponentModel.AsyncCompletedEventArgs.Error%2A>. The <xref:System.ComponentModel.AsyncCompletedEventArgs> class provides the <xref:System.ComponentModel.AsyncCompletedEventArgs.RaiseExceptionIfNecessary%2A> method for this purpose.  
  
-   Ensure that any attempt to access the result raises an <xref:System.InvalidOperationException> stating that the operation was canceled. Use the <xref:System.ComponentModel.AsyncCompletedEventArgs.RaiseExceptionIfNecessary%2A?displayProperty=nameWithType> method to perform this verification.  
  
### Progress Reporting  
  
-   Support progress reporting, if possible. This enables developers to provide a better application user experience when they use your class.  
  
-   If you implement a **ProgressChanged** or *MethodName***ProgressChanged** event, ensure that there are no such events raised for a particular asynchronous operation after that operation's *MethodName***Completed** event has been raised.  
  
-   If the standard <xref:System.ComponentModel.ProgressChangedEventArgs> is being populated, ensure that the <xref:System.ComponentModel.ProgressChangedEventArgs.ProgressPercentage%2A> can always be interpreted as a percentage. The percentage does not need to be accurate, but it should represent a percentage. If your progress reporting metric must be something other than a percentage, derive a class from the <xref:System.ComponentModel.ProgressChangedEventArgs> class and leave <xref:System.ComponentModel.ProgressChangedEventArgs.ProgressPercentage%2A> at 0. Avoid using a reporting metric other than a percentage.  
  
-   Ensure that the `ProgressChanged` event is raised on the appropriate thread and at the appropriate time in the application lifecycle. For more information, see the Threading and Contexts section.  
  
### IsBusy Implementation  
  
-   Do not expose an `IsBusy` property if your class supports multiple concurrent invocations. For example, XML Web service proxies do not expose an `IsBusy` property because they support multiple concurrent invocations of asynchronous methods.  
  
-   The `IsBusy` property should return `true` after the *MethodName***Async** method has been called and before the *MethodName***Completed** event has been raised. Otherwise it should return `false`. The <xref:System.ComponentModel.BackgroundWorker> and <xref:System.Net.WebClient> components are examples of classes that expose an `IsBusy` property.  
  
### Cancellation  
  
-   Support cancellation, if possible. This enables developers to provide a better application user experience when they use your class.  
  
-   In the case of cancellation, set the <xref:System.ComponentModel.AsyncCompletedEventArgs.Cancelled%2A> flag in the <xref:System.ComponentModel.AsyncCompletedEventArgs> object.  
  
-   Ensure that any attempt to access the result raises an <xref:System.InvalidOperationException> stating that the operation was canceled. Use the <xref:System.ComponentModel.AsyncCompletedEventArgs.RaiseExceptionIfNecessary%2A?displayProperty=nameWithType> method to perform this verification.  
  
-   Ensure that calls to a cancellation method always return successfully, and never raise an exception. In general, a client is not notified as to whether an operation is truly cancelable at any given time, and is not notified as to whether a previously issued cancellation has succeeded. However, the application will always be given notification when a cancellation succeeded, because the application takes part in the completion status.  
  
-   Raise the *MethodName***Completed** event when the operation is canceled.  
  
### Errors and Exceptions  
  
-   Catch any exceptions that occur in the asynchronous operation and set the value of the <xref:System.ComponentModel.AsyncCompletedEventArgs.Error%2A?displayProperty=nameWithType> property to that exception.  
  
### Threading and Contexts  
 For correct operation of your class, it is critical that the client's event handlers are invoked on the proper thread or context for the given application model, including [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] and Windows Forms applications. Two important helper classes are provided to ensure that your asynchronous class behaves correctly under any application model: <xref:System.ComponentModel.AsyncOperation> and <xref:System.ComponentModel.AsyncOperationManager>.  
  
 <xref:System.ComponentModel.AsyncOperationManager> provides one method, <xref:System.ComponentModel.AsyncOperationManager.CreateOperation%2A>, which returns an <xref:System.ComponentModel.AsyncOperation>. Your *MethodName***Async** method calls <xref:System.ComponentModel.AsyncOperationManager.CreateOperation%2A> and your class uses the returned <xref:System.ComponentModel.AsyncOperation> to track the lifetime of the asynchronous task.  
  
 To report progress, incremental results, and completion to the client, call the <xref:System.ComponentModel.AsyncOperation.Post%2A> and <xref:System.ComponentModel.AsyncOperation.OperationCompleted%2A> methods on the <xref:System.ComponentModel.AsyncOperation>. <xref:System.ComponentModel.AsyncOperation> is responsible for marshaling calls to the client's event handlers to the proper thread or context.  
  
> [!NOTE]
>  You can circumvent these rules if you explicitly want to go against the policy of the application model, but still benefit from the other advantages of using the Event-based Asynchronous Pattern. For example, you may want a class operating in Windows Forms to be free threaded. You can create a free threaded class, as long as developers understand the implied restrictions. Console applications do not synchronize the execution of <xref:System.ComponentModel.AsyncOperation.Post%2A> calls. This can cause `ProgressChanged` events to be raised out of order. If you wish to have serialized execution of <xref:System.ComponentModel.AsyncOperation.Post%2A> calls, implement and install a <xref:System.Threading.SynchronizationContext?displayProperty=nameWithType> class.  
  
 For more information about using <xref:System.ComponentModel.AsyncOperation> and <xref:System.ComponentModel.AsyncOperationManager> to enable your asynchronous operations, see [Walkthrough: Implementing a Component That Supports the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/component-that-supports-the-event-based-asynchronous-pattern.md).  
  
## Guidelines  
  
-   Ideally, each method invocation should be independent of others. You should avoid coupling invocations with shared resources. If resources are to be shared among invocations, you will need to provide a proper synchronization mechanism in your implementation.  
  
-   Designs that require the client to implement synchronization are discouraged. For example, you could have an asynchronous method that receives a global static object as a parameter; multiple concurrent invocations of such a method could result in data corruption or deadlocks.  
  
-   If you implement a method with the multiple-invocation overload (`userState` in the signature), your class will need to manage a collection of user states, or task IDs, and their corresponding pending operations. This collection should be protected with `lock` regions, because the various invocations add and remove `userState` objects in the collection.  
  
-   Consider reusing `CompletedEventArgs` classes where feasible and appropriate. In this case, the naming is not consistent with the method name, because a given delegate and <xref:System.EventArgs> type are not tied to a single method. However, forcing developers to cast the value retrieved from a property on the <xref:System.EventArgs> is never acceptable.  
  
-   If you are authoring a class that derives from <xref:System.ComponentModel.Component>, do not implement and install your own <xref:System.Threading.SynchronizationContext> class. Application models, not components, control the <xref:System.Threading.SynchronizationContext> that is used.  
  
-   When you use multithreading of any sort, you potentially expose yourself to very serious and complex bugs. Before implementing any solution that uses multithreading, see [Managed Threading Best Practices](../../../docs/standard/threading/managed-threading-best-practices.md).  
  
## See Also  
 <xref:System.ComponentModel.AsyncOperation>  
 <xref:System.ComponentModel.AsyncOperationManager>  
 <xref:System.ComponentModel.AsyncCompletedEventArgs>  
 <xref:System.ComponentModel.ProgressChangedEventArgs>  
 <xref:System.ComponentModel.BackgroundWorker>  
 [Implementing the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/implementing-the-event-based-asynchronous-pattern.md)  
 [Multithreaded Programming with the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/multithreaded-programming-with-the-event-based-asynchronous-pattern.md)  
 [Deciding When to Implement the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/deciding-when-to-implement-the-event-based-asynchronous-pattern.md)  
 [Best Practices for Implementing the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/best-practices-for-implementing-the-event-based-asynchronous-pattern.md)  
 [How to: Use Components That Support the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/how-to-use-components-that-support-the-event-based-asynchronous-pattern.md)  
 [Walkthrough: Implementing a Component That Supports the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/component-that-supports-the-event-based-asynchronous-pattern.md)
