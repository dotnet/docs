---
title: "Walkthrough: Implementing a Component That Supports the Event-based Asynchronous Pattern"
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
  - "threading [Windows Forms], asynchronous features"
  - "AsyncCompletedEventArgs class"
ms.assetid: 61f676b5-936f-40f6-83ce-f22805ec9c2f
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Walkthrough: Implementing a Component That Supports the Event-based Asynchronous Pattern
If you are writing a class with some operations that may incur noticeable delays, consider giving it asynchronous functionality by implementing the [Event-based Asynchronous Pattern Overview](../../../docs/standard/asynchronous-programming-patterns/event-based-asynchronous-pattern-overview.md).  
  
 This walkthrough illustrates how to create a component that implements the Event-based Asynchronous Pattern. It is implemented using helper classes from the <xref:System.ComponentModel?displayProperty=nameWithType> namespace, which ensures that the component works correctly under any application model, including [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)], Console applications and Windows Forms applications. This component is also designable with a <xref:System.Windows.Forms.PropertyGrid> control and your own custom designers.  
  
 When you are through, you will have an application that computes prime numbers asynchronously. Your application will have a main user interface (UI) thread and a thread for each prime number calculation. Although testing whether a large number is prime can take a noticeable amount of time, the main UI thread will not be interrupted by this delay, and the form will be responsive during the calculations. You will be able to run as many calculations as you like concurrently and selectively cancel pending calculations.  
  
 Tasks illustrated in this walkthrough include:  
  
-   Creating the Component  
  
-   Defining Public Asynchronous Events and Delegates  
  
-   Defining Private Delegates  
  
-   Implementing Public Events  
  
-   Implementing the Completion Method  
  
-   Implementing the Worker Methods  
  
-   Implementing Start and Cancel Methods  
  
 To copy the code in this topic as a single listing, see [How to: Implement a Client of the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/how-to-implement-a-client-of-the-event-based-asynchronous-pattern.md).  
  
## Creating the Component  
 The first step is to create the component that will implement the Event-based Asynchronous Pattern.  
  
#### To create the component  
  
-   Create a class called `PrimeNumberCalculator` that inherits from <xref:System.ComponentModel.Component>.  
  
## Defining Public Asynchronous Events and Delegates  
 Your component communicates to clients using events. The *MethodName***Completed** event alerts clients to the completion of an asynchronous task, and the *MethodName***ProgressChanged** event informs clients of the progress of an asynchronous task.  
  
#### To define asynchronous events for clients of your component:  
  
1.  Import the <xref:System.Threading?displayProperty=nameWithType> and <xref:System.Collections.Specialized?displayProperty=nameWithType> namespaces at the top of your file.  
  
     [!code-csharp[System.ComponentModel.AsyncOperationManager#11](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#11)]
     [!code-vb[System.ComponentModel.AsyncOperationManager#11](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#11)]  
  
2.  Before the `PrimeNumberCalculator` class definition, declare delegates for progress and completion events.  
  
     [!code-csharp[System.ComponentModel.AsyncOperationManager#7](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#7)]
     [!code-vb[System.ComponentModel.AsyncOperationManager#7](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#7)]  
  
3.  In the `PrimeNumberCalculator` class definition, declare events for reporting progress and completion to clients.  
  
     [!code-csharp[System.ComponentModel.AsyncOperationManager#8](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#8)]
     [!code-vb[System.ComponentModel.AsyncOperationManager#8](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#8)]  
  
4.  After the `PrimeNumberCalculator` class definition, derive the `CalculatePrimeCompletedEventArgs` class for reporting the outcome of each calculation to the client's event handler for the `CalculatePrimeCompleted`.event. In addition to the `AsyncCompletedEventArgs` properties, this class enables the client to determine what number was tested, whether it is prime, and what the first divisor is if it is not prime.  
  
     [!code-csharp[System.ComponentModel.AsyncOperationManager#6](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#6)]
     [!code-vb[System.ComponentModel.AsyncOperationManager#6](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#6)]  
  
## Checkpoint  
 At this point, you can build the component.  
  
#### To test your component  
  
-   Compile the component.  
  
     You will receive two compiler warnings:  
  
    ```  
    warning CS0067: The event 'AsynchronousPatternExample.PrimeNumberCalculator.ProgressChanged' is never used  
    warning CS0067: The event 'AsynchronousPatternExample.PrimeNumberCalculator.CalculatePrimeCompleted' is never used  
    ```  
  
     These warnings will be cleared in the next section.  
  
## Defining Private Delegates  
 The asynchronous aspects of the `PrimeNumberCalculator` component are implemented internally with a special delegate known as a <xref:System.Threading.SendOrPostCallback>. A <xref:System.Threading.SendOrPostCallback> represents a callback method that executes on a <xref:System.Threading.ThreadPool> thread. The callback method must have a signature that takes a single parameter of type <xref:System.Object>, which means you will need to pass state among delegates in a wrapper class. For more information, see <xref:System.Threading.SendOrPostCallback>.  
  
#### To implement your component's internal asynchronous behavior:  
  
1.  Declare and create the <xref:System.Threading.SendOrPostCallback> delegates in the `PrimeNumberCalculator` class. Create the <xref:System.Threading.SendOrPostCallback> objects in a utility method called `InitializeDelegates`.  
  
     You will need two delegates: one for reporting progress to the client, and one for reporting completion to the client.  
  
     [!code-csharp[System.ComponentModel.AsyncOperationManager#9](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#9)]
     [!code-vb[System.ComponentModel.AsyncOperationManager#9](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#9)]  
    [!code-csharp[System.ComponentModel.AsyncOperationManager#20](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#20)]
    [!code-vb[System.ComponentModel.AsyncOperationManager#20](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#20)]  
  
2.  Call the `InitializeDelegates` method in your component's constructor.  
  
     [!code-csharp[System.ComponentModel.AsyncOperationManager#21](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#21)]
     [!code-vb[System.ComponentModel.AsyncOperationManager#21](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#21)]  
  
3.  Declare a delegate in the `PrimeNumberCalculator` class that handles the actual work to be done asynchronously. This delegate wraps the worker method that tests whether a number is prime. The delegate takes an <xref:System.ComponentModel.AsyncOperation> parameter, which will be used to track the lifetime of the asynchronous operation.  
  
     [!code-csharp[System.ComponentModel.AsyncOperationManager#22](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#22)]
     [!code-vb[System.ComponentModel.AsyncOperationManager#22](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#22)]  
  
4.  Create a collection for managing lifetimes of pending asynchronous operations. The client needs a way to track operations as they are executed and completed, and this tracking is done by requiring the client to pass a unique token, or task ID, when the client makes the call to the asynchronous method. The `PrimeNumberCalculator` component must keep track of each call by associating the task ID with its corresponding invocation. If the client passes a task ID that is not unique, the `PrimeNumberCalculator` component must raise an exception.  
  
     The `PrimeNumberCalculator` component keeps track of task ID by using a special collection class called a <xref:System.Collections.Specialized.HybridDictionary>. In the class definition, create a <xref:System.Collections.Specialized.HybridDictionary> called `userTokenToLifetime`.  
  
     [!code-csharp[System.ComponentModel.AsyncOperationManager#23](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#23)]
     [!code-vb[System.ComponentModel.AsyncOperationManager#23](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#23)]  
  
## Implementing Public Events  
 Components that implement the Event-based Asynchronous Pattern communicate to clients using events. These events are invoked on the proper thread with the help of the <xref:System.ComponentModel.AsyncOperation> class.  
  
#### To raise events to your component's clients:  
  
1.  Implement public events for reporting to clients. You will need an event for reporting progress and one for reporting completion.  
  
     [!code-csharp[System.ComponentModel.AsyncOperationManager#24](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#24)]
     [!code-vb[System.ComponentModel.AsyncOperationManager#24](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#24)]  
  
## Implementing the Completion Method  
 The completion delegate is the method that the underlying, free-threaded asynchronous behavior will invoke when the asynchronous operation ends by successful completion, error, or cancellation. This invocation happens on an arbitrary thread.  
  
 This method is where the client's task ID is removed from the internal collection of unique client tokens. This method also ends the lifetime of a particular asynchronous operation by calling the <xref:System.ComponentModel.AsyncOperation.PostOperationCompleted%2A> method on the corresponding <xref:System.ComponentModel.AsyncOperation>. This call raises the completion event on the thread that is appropriate for the application model. After the <xref:System.ComponentModel.AsyncOperation.PostOperationCompleted%2A> method is called, this instance of <xref:System.ComponentModel.AsyncOperation> can no longer be used, and any subsequent attempts to use it will throw an exception.  
  
 The `CompletionMethod` signature must hold all state necessary to describe the outcome of the asynchronous operation. It holds state for the number that was tested by this particular asynchronous operation, whether the number is prime, and the value of its first divisor if it is not a prime number. It also holds state describing any exception that occurred, and the <xref:System.ComponentModel.AsyncOperation> corresponding to this particular task.  
  
#### To complete an asynchronous operation:  
  
-   Implement the completion method. It takes six parameters, which it uses to populate a `CalculatePrimeCompletedEventArgs` that is returned to the client through the client's `CalculatePrimeCompletedEventHandler`. It removes the client's task ID token from the internal collection, and it ends the asynchronous operation's lifetime with a call to <xref:System.ComponentModel.AsyncOperation.PostOperationCompleted%2A>. The <xref:System.ComponentModel.AsyncOperation> marshals the call to the thread or context that is appropriate for the application model.  
  
     [!code-csharp[System.ComponentModel.AsyncOperationManager#26](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#26)]
     [!code-vb[System.ComponentModel.AsyncOperationManager#26](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#26)]  
  
## Checkpoint  
 At this point, you can build the component.  
  
#### To test your component  
  
-   Compile the component.  
  
     You will receive one compiler warning:  
  
    ```  
    warning CS0169: The private field 'AsynchronousPatternExample.PrimeNumberCalculator.workerDelegate' is never used  
    ```  
  
     This warning will be resolved in the next section.  
  
## Implementing the Worker Methods  
 So far, you have implemented the supporting asynchronous code for the `PrimeNumberCalculator` component. Now you can implement the code that does the actual work. You will implement three methods: `CalculateWorker`, `BuildPrimeNumberList`, and `IsPrime`. Together, `BuildPrimeNumberList` and `IsPrime` comprise a well-known algorithm called the Sieve of Eratosthenes, which determines if a number is prime by finding all the prime numbers up to the square root of the test number. If no divisors are found by that point, the test number is prime.  
  
 If this component were written for maximum efficiency, it would remember all the prime numbers discovered by various invocations for different test numbers. It would also check for trivial divisors like 2, 3, and 5. The intent of this example is to demonstrate how time-consuming operations can be executed asynchronously, however, so these optimizations are left as an exercise for you.  
  
 The `CalculateWorker` method is wrapped in a delegate and is invoked asynchronously with a call to `BeginInvoke`.  
  
> [!NOTE]
>  Progress reporting is implemented in the `BuildPrimeNumberList` method. On fast computers, `ProgressChanged` events can be raised in rapid succession. The client thread, on which these events are raised, must be able to handle this situation. User interface code may be flooded with messages and unable to keep up, resulting in hanging behavior. For an example user interface that handles this situation, see [How to: Implement a Client of the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/how-to-implement-a-client-of-the-event-based-asynchronous-pattern.md).  
  
#### To execute the prime number calculation asynchronously:  
  
1.  Implement the `TaskCanceled` utility method. This checks the task lifetime collection for the given task ID, and returns `true` if the task ID is not found.  
  
     [!code-csharp[System.ComponentModel.AsyncOperationManager#32](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#32)]
     [!code-vb[System.ComponentModel.AsyncOperationManager#32](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#32)]  
  
2.  Implement the `CalculateWorker` method. It takes two parameters: a number to test, and an <xref:System.ComponentModel.AsyncOperation>.  
  
     [!code-csharp[System.ComponentModel.AsyncOperationManager#27](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#27)]
     [!code-vb[System.ComponentModel.AsyncOperationManager#27](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#27)]  
  
3.  Implement `BuildPrimeNumberList`. It takes two parameters: the number to test, and an <xref:System.ComponentModel.AsyncOperation>. It uses the <xref:System.ComponentModel.AsyncOperation> to report progress and incremental results. This assures that the client's event handlers are called on the proper thread or context for the application model. When `BuildPrimeNumberList` finds a prime number, it reports this as an incremental result to the client's event handler for the `ProgressChanged` event. This requires a class derived from <xref:System.ComponentModel.ProgressChangedEventArgs>, called `CalculatePrimeProgressChangedEventArgs`, which has one added property called `LatestPrimeNumber`.  
  
     The `BuildPrimeNumberList` method also periodically calls the `TaskCanceled` method and exits if the method returns `true`.  
  
     [!code-csharp[System.ComponentModel.AsyncOperationManager#5](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#5)]
     [!code-vb[System.ComponentModel.AsyncOperationManager#5](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#5)]  
  
4.  Implement `IsPrime`. It takes three parameters: a list of known prime numbers, the number to test, and an output parameter for the first divisor found. Given the list of prime numbers, it determines if the test number is prime.  
  
     [!code-csharp[System.ComponentModel.AsyncOperationManager#28](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#28)]
     [!code-vb[System.ComponentModel.AsyncOperationManager#28](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#28)]  
  
5.  Derive `CalculatePrimeProgressChangedEventArgs` from <xref:System.ComponentModel.ProgressChangedEventArgs>. This class is necessary for reporting incremental results to the client's event handler for the `ProgressChanged` event. It has one added property called `LatestPrimeNumber`.  
  
     [!code-csharp[System.ComponentModel.AsyncOperationManager#29](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#29)]
     [!code-vb[System.ComponentModel.AsyncOperationManager#29](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#29)]  
  
## Checkpoint  
 At this point, you can build the component.  
  
#### To test your component  
  
-   Compile the component.  
  
     All that remains to be written are the methods to start and cancel asynchronous operations, `CalculatePrimeAsync` and `CancelAsync`.  
  
## Implementing the Start and Cancel Methods  
 You start the worker method on its own thread by calling `BeginInvoke` on the delegate that wraps it. To manage the lifetime of a particular asynchronous operation, you call the <xref:System.ComponentModel.AsyncOperationManager.CreateOperation%2A> method on the <xref:System.ComponentModel.AsyncOperationManager> helper class. This returns an <xref:System.ComponentModel.AsyncOperation>, which marshals calls on the client's event handlers to the proper thread or context.  
  
 You cancel a particular pending operation by calling <xref:System.ComponentModel.AsyncOperation.PostOperationCompleted%2A> on its corresponding <xref:System.ComponentModel.AsyncOperation>. This ends that operation, and any subsequent calls to its <xref:System.ComponentModel.AsyncOperation> will throw an exception.  
  
#### To implement Start and Cancel functionality:  
  
1.  Implement the `CalculatePrimeAsync` method. Make sure the client-supplied token (task ID) is unique with respect to all the tokens representing currently pending tasks. If the client passes in a non-unique token, `CalculatePrimeAsync` raises an exception. Otherwise, the token is added to the task ID collection.  
  
     [!code-csharp[System.ComponentModel.AsyncOperationManager#3](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#3)]
     [!code-vb[System.ComponentModel.AsyncOperationManager#3](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#3)]  
  
2.  Implement the `CancelAsync` method. If the `taskId` parameter exists in the token collection, it is removed. This prevents canceled tasks that have not started from running. If the task is running, the `BuildPrimeNumberList` method exits when it detects that the task ID has been removed from the lifetime collection.  
  
     [!code-csharp[System.ComponentModel.AsyncOperationManager#4](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/CS/primenumbercalculatormain.cs#4)]
     [!code-vb[System.ComponentModel.AsyncOperationManager#4](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.AsyncOperationManager/VB/primenumbercalculatormain.vb#4)]  
  
## Checkpoint  
 At this point, you can build the component.  
  
#### To test your component  
  
-   Compile the component.  
  
 The `PrimeNumberCalculator` component is now complete and ready to use.  
  
 For an example client that uses the `PrimeNumberCalculator` component, see [How to: Implement a Client of the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/how-to-implement-a-client-of-the-event-based-asynchronous-pattern.md).  
  
## Next Steps  
 You can fill out this example by writing `CalculatePrime`, the synchronous equivalent of `CalculatePrimeAsync` method. This will make the `PrimeNumberCalculator` component fully compliant with the Event-based Asynchronous Pattern.  
  
 You can improve this example by retaining the list of all the prime numbers discovered by various invocations for different test numbers. Using this approach, each task will benefit from the work done by previous tasks. Be careful to protect this list with `lock` regions, so access to the list by different threads is serialized.  
  
 You can also improve this example by testing for trivial divisors, like 2, 3, and 5.  
  
## See Also  
 [How to: Run an Operation in the Background](../../../docs/framework/winforms/controls/how-to-run-an-operation-in-the-background.md)  
 [Event-based Asynchronous Pattern Overview](../../../docs/standard/asynchronous-programming-patterns/event-based-asynchronous-pattern-overview.md)  
 [NOT IN BUILD: Multithreading in Visual Basic](https://msdn.microsoft.com/library/c731a50c-09c1-4468-9646-54c86b75d269)  
 [How to: Implement a Component That Supports the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/component-that-supports-the-event-based-asynchronous-pattern.md)  
 [Multithreaded Programming with the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/multithreaded-programming-with-the-event-based-asynchronous-pattern.md)
