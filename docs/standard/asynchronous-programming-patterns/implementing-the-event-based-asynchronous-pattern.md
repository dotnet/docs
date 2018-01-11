---
title: "Implementing the Event-based Asynchronous Pattern"
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
  - "components [.NET Framework], asynchronous"
  - "AsyncOperation class"
  - "AsyncCompletedEventArgs class"
ms.assetid: 43402d19-8d30-426d-8785-1a4478233bfa
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Implementing the Event-based Asynchronous Pattern
If you are writing a class with some operations that may incur noticeable delays, consider giving it asynchronous functionality by implementing [Event-based Asynchronous Pattern Overview](../../../docs/standard/asynchronous-programming-patterns/event-based-asynchronous-pattern-overview.md).  
  
 The Event-based Asynchronous Pattern provides a standardized way to package a class that has asynchronous features. If implemented with helper classes like <xref:System.ComponentModel.AsyncOperationManager>, your class will work correctly under any application model, including [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)], Console applications, and Windows Forms applications.  
  
 For an example that implements the Event-based Asynchronous Pattern, see [How to: Implement a Component That Supports the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/component-that-supports-the-event-based-asynchronous-pattern.md).  
  
 For simple asynchronous operations, you may find the <xref:System.ComponentModel.BackgroundWorker> component suitable. For more information about <xref:System.ComponentModel.BackgroundWorker>, see [How to: Run an Operation in the Background](../../../docs/framework/winforms/controls/how-to-run-an-operation-in-the-background.md).  
  
 The following list describes the features of the Event-based Asynchronous Pattern discussed in this topic.  
  
-   Opportunities for Implementing the Event-based Asynchronous Pattern  
  
-   Naming Asynchronous Methods  
  
-   Optionally Support Cancellation  
  
-   Optionally Support the IsBusy Property  
  
-   Optionally Provide Support for Progress Reporting  
  
-   Optionally Provide Support for Returning Incremental Results  
  
-   Handling Out and Ref Parameters in Methods  
  
## Opportunities for Implementing the Event-based Asynchronous Pattern  
 Consider implementing the Event-based Asynchronous Pattern when:  
  
-   Clients of your class do not need <xref:System.Threading.WaitHandle> and <xref:System.IAsyncResult> objects available for asynchronous operations, meaning that polling and <xref:System.Threading.WaitHandle.WaitAll%2A> or <xref:System.Threading.WaitHandle.WaitAny%2A> will need to be built up by the client.  
  
-   You want asynchronous operations to be managed by the client with the familiar event/delegate model.  
  
 Any operation is a candidate for an asynchronous implementation, but those you expect to incur long latencies should be considered. Especially appropriate are operations in which clients call a method and are notified on completion, with no further intervention required. Also appropriate are operations which run continuously, periodically notifying clients of progress, incremental results, or state changes.  
  
 For more information on deciding when to support the Event-based Asynchronous Pattern, see [Deciding When to Implement the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/deciding-when-to-implement-the-event-based-asynchronous-pattern.md).  
  
## Naming Asynchronous Methods  
 For each synchronous method *MethodName* for which you want to provide an asynchronous counterpart:  
  
 Define a *MethodName***Async** method that:  
  
-   Returns `void`.  
  
-   Takes the same parameters as the *MethodName* method.  
  
-   Accepts multiple invocations.  
  
 Optionally define a *MethodName***Async** overload, identical to *MethodName***Async**, but with an additional object-valued parameter called `userState`. Do this if you're prepared to manage multiple concurrent invocations of your method, in which case the `userState` value will be delivered back to all event handlers to distinguish invocations of the method. You may also choose to do this simply as a place to store user state for later retrieval.  
  
 For each separate *MethodName***Async** method signature:  
  
1.  Define the following event in the same class as the method:  
  
    ```vb  
    Public Event MethodNameCompleted As MethodNameCompletedEventHandler  
    ```  
  
    ```csharp  
    public event MethodNameCompletedEventHandler MethodNameCompleted;  
    ```  
  
2.  Define the following delegate and <xref:System.ComponentModel.AsyncCompletedEventArgs>. These will likely be defined outside of the class itself, but in the same namespace.  
  
    ```vb  
    Public Delegate Sub MethodNameCompletedEventHandler( _  
        ByVal sender As Object, _  
        ByVal e As MethodNameCompletedEventArgs)  
  
    Public Class MethodNameCompletedEventArgs  
        Inherits System.ComponentModel.AsyncCompletedEventArgs  
    Public ReadOnly Property Result() As MyReturnType  
    End Property  
    ```  
  
    ```csharp  
    public delegate void MethodNameCompletedEventHandler(object sender,   
        MethodNameCompletedEventArgs e);  
  
    public class MethodNameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs  
    {  
        public MyReturnType Result { get; }  
    }  
    ```  
  
    -   Ensure that the *MethodName***CompletedEventArgs** class exposes its members as read-only properties, and not fields, as fields prevent data binding.  
  
    -   Do not define any <xref:System.ComponentModel.AsyncCompletedEventArgs>-derived classes for methods that do not produce results. Simply use an instance of <xref:System.ComponentModel.AsyncCompletedEventArgs> itself.  
  
        > [!NOTE]
        >  It is perfectly acceptable, when feasible and appropriate, to reuse delegate and <xref:System.ComponentModel.AsyncCompletedEventArgs> types. In this case, the naming will not be as consistent with the method name, since a given delegate and <xref:System.ComponentModel.AsyncCompletedEventArgs> won't be tied to a single method.  
  
## Optionally Support Cancellation  
 If your class will support canceling asynchronous operations, cancellation should be exposed to the client as described below. Note that there are two decision points that need to be reached before defining your cancellation support:  
  
-   Does your class, including future anticipated additions to it, have only one asynchronous operation that supports cancellation?  
  
-   Can the asynchronous operations that support cancellation support multiple pending operations? That is, does the *MethodName***Async** method take a `userState` parameter, and does it allow multiple invocations before waiting for any to finish?  
  
 Use the answers to these two questions in the table below to determine what the signature for your cancellation method should be.  
  
### Visual Basic  
  
||Multiple Simultaneous Operations Supported|Only One Operation at a Time|  
|------|------------------------------------------------|----------------------------------|  
|One Async Operation in entire class|`Sub MethodNameAsyncCancel(ByVal userState As Object)`|`Sub MethodNameAsyncCancel()`|  
|Multiple Async Operations in class|`Sub CancelAsync(ByVal userState As Object)`|`Sub CancelAsync()`|  
  
### C#  
  
||Multiple Simultaneous Operations Supported|Only One Operation at a Time|  
|------|------------------------------------------------|----------------------------------|  
|One Async Operation in entire class|`void MethodNameAsyncCancel(object userState);`|`void MethodNameAsyncCancel();`|  
|Multiple Async Operations in class|`void CancelAsync(object userState);`|`void CancelAsync();`|  
  
 If you define the `CancelAsync(object userState)` method, clients must be careful when choosing their state values to make them capable of distinguishing among all asynchronous methods invoked on the object, and not just between all invocations of a single asynchronous method.  
  
 The decision to name the single-async-operation version *MethodName***AsyncCancel** is based on being able to more easily discover the method in a design environment like Visual Studio's IntelliSense. This groups the related members and distinguishes them from other members that have nothing to do with asynchronous functionality. If you expect that there may be additional asynchronous operations added in subsequent versions, it is better to define `CancelAsync`.  
  
 Do not define multiple methods from the table above in the same class. That will not make sense, or it will clutter the class interface with a proliferation of methods.  
  
 These methods typically will return immediately, and the operation may or may not actually cancel. In the event handler for the *MethodName***Completed** event, the *MethodName***CompletedEventArgs** object contains a `Cancelled` field, which clients can use to determine whether the cancellation occurred.  
  
 Abide by the cancellation semantics described in [Best Practices for Implementing the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/best-practices-for-implementing-the-event-based-asynchronous-pattern.md).  
  
## Optionally Support the IsBusy Property  
 If your class does not support multiple concurrent invocations, consider exposing an `IsBusy` property. This allows developers to determine whether a *MethodName***Async** method is running without catching an exception from the *MethodName***Async** method.  
  
 Abide by the `IsBusy` semantics described in [Best Practices for Implementing the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/best-practices-for-implementing-the-event-based-asynchronous-pattern.md).  
  
## Optionally Provide Support for Progress Reporting  
 It is frequently desirable for an asynchronous operation to report progress during its operation. The Event-based Asynchronous Pattern provides a guideline for doing so.  
  
-   Optionally define an event to be raised by the asynchronous operation and invoked on the appropriate thread. The <xref:System.ComponentModel.ProgressChangedEventArgs> object carries an integer-valued progress indicator that is expected to be between 0 and 100.  
  
-   Name this event as follows:  
  
    -   `ProgressChanged` if the class has multiple asynchronous operations (or is expected to grow to include multiple asynchronous operations in future versions);  
  
    -   *MethodName***ProgressChanged** if the class has a single asynchronous operation.  
  
     This naming choice parallels that made for the cancellation method, as described in the Optionally Support Cancellation section.  
  
 This event should use the <xref:System.ComponentModel.ProgressChangedEventHandler> delegate signature and the <xref:System.ComponentModel.ProgressChangedEventArgs> class. Alternatively, if a more domain-specific progress indicator can be provided (for instance, bytes read and total bytes for a download operation), then you should define a derived class of <xref:System.ComponentModel.ProgressChangedEventArgs>.  
  
 Note that there is only one `ProgressChanged` or *MethodName***ProgressChanged** event for the class, regardless of the number of asynchronous methods it supports. Clients are expected to use the `userState` object that is passed to the *MethodName***Async** methods to distinguish among progress updates on multiple concurrent operations.  
  
 There may be situations in which multiple operations support progress and each returns a different indicator for progress. In this case, a single `ProgressChanged` event is not appropriate, and you may consider supporting multiple `ProgressChanged` events. In this case use a naming pattern of *MethodName***ProgressChanged** for each *MethodName***Async** method.  
  
 Abide by the progress-reporting semantics described [Best Practices for Implementing the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/best-practices-for-implementing-the-event-based-asynchronous-pattern.md).  
  
## Optionally Provide Support for Returning Incremental Results  
 Sometimes an asynchronous operation can return incremental results prior to completion. There are a number of options that can be used to support this scenario. Some examples follow.  
  
### Single-operation Class  
 If your class only supports a single asynchronous operation, and that operation is able to return incremental results, then:  
  
-   Extend the <xref:System.ComponentModel.ProgressChangedEventArgs> type to carry the incremental result data, and define a *MethodName***ProgressChanged** event with this extended data.  
  
-   Raise this *MethodName***ProgressChanged** event when there is an incremental result to report.  
  
 This solution applies specifically to a single-async-operation class because there is no problem with the same event occurring to return incremental results on "all operations", as the *MethodName***ProgressChanged** event does.  
  
### Multiple-operation Class with Homogeneous Incremental Results  
 In this case, your class supports multiple asynchronous methods, each capable of returning incremental results, and these incremental results all have the same type of data.  
  
 Follow the model described above for single-operation classes, as the same <xref:System.EventArgs> structure will work for all incremental results. Define a `ProgressChanged` event instead of a *MethodName***ProgressChanged** event, since it applies to multiple asynchronous methods.  
  
### Multiple-operation Class with Heterogeneous Incremental Results  
 If your class supports multiple asynchronous methods, each returning a different type of data, you should:  
  
-   Separate your incremental result reporting from your progress reporting.  
  
-   Define a separate *MethodName***ProgressChanged** event with appropriate <xref:System.EventArgs> for each asynchronous method to handle that method's incremental result data.  
  
 Invoke that event handler on the appropriate thread as described in [Best Practices for Implementing the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/best-practices-for-implementing-the-event-based-asynchronous-pattern.md).  
  
## Handling Out and Ref Parameters in Methods  
 Although the use of `out` and `ref` is, in general, discouraged in the .NET Framework, here are the rules to follow when they are present:  
  
 Given a synchronous method *MethodName*:  
  
-   `out` parameters to *MethodName* should not be part of *MethodName***Async**. Instead, they should be part of *MethodName***CompletedEventArgs** with the same name as its parameter equivalent in *MethodName* (unless there is a more appropriate name).  
  
-   `ref` parameters to *MethodName* should appear as part of *MethodName***Async**, and as part of *MethodName***CompletedEventArgs** with the same name as its parameter equivalent in *MethodName* (unless there is a more appropriate name).  
  
 For example, given:  
  
```vb  
Public Function MethodName(ByVal arg1 As String, ByRef arg2 As String, ByRef arg3 As String) As Integer  
```  
  
```csharp  
public int MethodName(string arg1, ref string arg2, out string arg3);  
```  
  
 Your asynchronous method and its <xref:System.ComponentModel.AsyncCompletedEventArgs> class would look like this:  
  
```vb  
Public Sub MethodNameAsync(ByVal arg1 As String, ByVal arg2 As String)  
  
Public Class MethodNameCompletedEventArgs  
    Inherits System.ComponentModel.AsyncCompletedEventArgs  
    Public ReadOnly Property Result() As Integer   
    End Property  
    Public ReadOnly Property Arg2() As String   
    End Property  
    Public ReadOnly Property Arg3() As String   
    End Property  
End Class  
```  
  
```csharp  
public void MethodNameAsync(string arg1, string arg2);  
  
public class MethodNameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs  
{  
    public int Result { get; };  
    public string Arg2 { get; };  
    public string Arg3 { get; };  
}  
```  
  
## See Also  
 <xref:System.ComponentModel.ProgressChangedEventArgs>  
 <xref:System.ComponentModel.AsyncCompletedEventArgs>  
 [How to: Implement a Component That Supports the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/component-that-supports-the-event-based-asynchronous-pattern.md)  
 [How to: Run an Operation in the Background](../../../docs/framework/winforms/controls/how-to-run-an-operation-in-the-background.md)  
 [How to: Implement a Form That Uses a Background Operation](../../../docs/framework/winforms/controls/how-to-implement-a-form-that-uses-a-background-operation.md)  
 [Deciding When to Implement the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/deciding-when-to-implement-the-event-based-asynchronous-pattern.md)  
 [Multithreaded Programming with the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/multithreaded-programming-with-the-event-based-asynchronous-pattern.md)  
 [Best Practices for Implementing the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/best-practices-for-implementing-the-event-based-asynchronous-pattern.md)
